﻿Imports Npgsql
Imports System.Xml

'uncomment active column if needed

Public Class frmAddColorModule
    Private gSortingColumn As ColumnHeader

    Private Sub frmAddColorModule_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MinimumSize = Me.Size
        Me.WindowState = FormWindowState.Maximized

        With cmItems.Columns
            .Clear()
            .Add("Color Code", 100, HorizontalAlignment.Left)
            .Add("Color Description", 500, HorizontalAlignment.Left)
            '.Add("Active Status", 100, HorizontalAlignment.Left)
        End With
        Dim vTmpStr As String

        'log event
        vTmpStr = modModule.CreateLog(Me.Name, "Add Color Module - Open", "")

        timerDataLoad.Enabled = True
    End Sub

    Private Sub cmItems_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles cmItems.ColumnClick
        Dim vNewSortingColumn As ColumnHeader = cmItems.Columns(e.Column)   ' get the new sorting column.
        Dim vSortOrder As System.Windows.Forms.SortOrder                    ' figure out the new sorting order.

        If gSortingColumn Is Nothing Then
            vSortOrder = SortOrder.Ascending                                ' new column. Sort ascending.
        Else
            If vNewSortingColumn.Equals(gSortingColumn) Then                ' see if this is the same column.
                If gSortingColumn.Text.StartsWith("> ") Then                ' same column. Switch the sort order.
                    vSortOrder = SortOrder.Descending
                Else
                    vSortOrder = SortOrder.Ascending
                End If
            Else
                vSortOrder = SortOrder.Ascending                            ' new column. Sort ascending.
            End If

            gSortingColumn.Text = gSortingColumn.Text.Substring(2)          ' remove the old sort indicator.
        End If

        gSortingColumn = vNewSortingColumn                                  ' display the new sort order.

        If vSortOrder = SortOrder.Ascending Then
            gSortingColumn.Text = "> " & gSortingColumn.Text
        Else
            gSortingColumn.Text = "< " & gSortingColumn.Text
        End If

        cmItems.ListViewItemSorter = New modModule.ListViewItemComparer(e.Column, vSortOrder)  ' create a comparer.

        cmItems.Sort()                                                     ' sort.

        modModule.RefreshAlternateViewColors(cmItems)
    End Sub

    Private Sub timerDataLoad_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timerDataLoad.Tick
        'open postgres connection
        Dim vMyPgCon As New NpgsqlConnection
        Dim vMyPgCmd = New NpgsqlCommand
        Dim vMyPgRd As NpgsqlDataReader
        Dim vFound As Boolean
        Dim vRecs As Long

        timerDataLoad.Enabled = False

        Try
            cmItems.Items.Clear()

            Dim vQuery As String = "SELECT color_code, color_description, is_active FROM tb_colors ORDER BY color_code DESC"

            vMyPgCon.ConnectionString = pConnectVox
            vMyPgCon.Open()

            vMyPgCmd = New NpgsqlCommand(vQuery, vMyPgCon)

            vMyPgRd = vMyPgCmd.ExecuteReader()

            vFound = vMyPgRd.Read
            vRecs = 0

            If vFound Then
                Do While vFound
                    Dim listItem As New ListViewItem()

                    If Not IsDBNull(vMyPgRd("color_code")) Then
                        listItem.Text = vMyPgRd("color_code").ToString()
                    Else
                        listItem.Text = ""
                    End If

                    If Not IsDBNull(vMyPgRd("color_description")) Then
                        listItem.SubItems.Add(vMyPgRd("color_description").ToString())
                    Else
                        listItem.SubItems.Add("")
                    End If

                    'If Not IsDBNull(vMyPgRd("is_active")) Then
                    '    listItem.SubItems.Add(vMyPgRd("is_active").ToString())
                    'Else
                    '    listItem.SubItems.Add("")
                    'End If

                    cmItems.Items.Add(listItem)
                    vRecs += 1

                    vFound = vMyPgRd.Read
                    modModule.RefreshAlternateViewColors(cmItems)
                Loop
            End If

            vMyPgRd.Close()
            vMyPgCmd.Dispose()

            vMyPgCon.Close()
            txtValue1.Clear()
            txtValue2.Clear()

        Catch ex As Exception
            If Not IsNothing(vMyPgCon) AndAlso vMyPgCon.State <> ConnectionState.Closed Then
                vMyPgCon.Close()
            End If

            MsgBox("An error occurred: " & ex.Message, MsgBoxStyle.OkOnly, "Error")
        End Try
    End Sub

    Private Sub cmdAdd_Click(sender As Object, e As EventArgs) Handles cmdAdd.Click
        Dim colorCode As String = txtValue1.Text
        Dim colorDescription As String = txtValue2.Text
        'Dim isActive As Integer = txtIsActive.Text
        Dim isActive As Integer = 1

        ' validation
        If String.IsNullOrWhiteSpace(colorCode) OrElse String.IsNullOrWhiteSpace(colorDescription) Then
            MsgBox("Please fill in all required fields.", MsgBoxStyle.OkOnly, "Validation Error")
            Return
        End If

        Try
            Dim vMyPgCon As New NpgsqlConnection(pConnectVox)
            vMyPgCon.Open()

            ' validation - check for existing record with the same color_code or color_description
            Dim checkQuery As String = "SELECT COUNT(*) FROM tb_colors WHERE color_code ILIKE @color_code OR color_description ILIKE @color_description"
            Dim vMyPgCmdCheck As New NpgsqlCommand(checkQuery, vMyPgCon)
            vMyPgCmdCheck.Parameters.AddWithValue("@color_code", colorCode)
            vMyPgCmdCheck.Parameters.AddWithValue("@color_description", colorDescription)

            Dim recordExists As Integer = Convert.ToInt32(vMyPgCmdCheck.ExecuteScalar())

            If recordExists > 0 Then
                MsgBox("Color Code or Color Description already exists. Please enter unique values.", MsgBoxStyle.OkOnly, "Duplicate Error")
                vMyPgCmdCheck.Dispose()
                vMyPgCon.Close()
                Return
            End If

            Dim insertQuery As String = "INSERT INTO tb_colors (color_code, color_description, is_active) VALUES (@color_code, @color_description, @is_active)"
            Dim vMyPgCmdInsert As New NpgsqlCommand(insertQuery, vMyPgCon)

            vMyPgCmdInsert.Parameters.AddWithValue("@color_code", colorCode)
            vMyPgCmdInsert.Parameters.AddWithValue("@color_description", colorDescription)
            vMyPgCmdInsert.Parameters.AddWithValue("@is_active", isActive)

            vMyPgCmdInsert.ExecuteNonQuery()

            vMyPgCmdInsert.Dispose()
            vMyPgCon.Close()

            Dim listItem As New ListViewItem(colorCode)
            listItem.SubItems.Add(colorDescription)
            listItem.SubItems.Add(isActive)

            cmItems.Items.Add(listItem)

            txtValue1.Clear()
            txtValue2.Clear()
            'txtIsActive.Clear()

            MsgBox("Color added successfully!", MsgBoxStyle.OkOnly, "Success")
        Catch ex As Exception
            MsgBox("An error occurred: " & ex.Message, MsgBoxStyle.OkOnly, "Error")
        End Try
    End Sub

    ' helper function to remove invalid XML characters
    Private Function SanitizeForXml(input As String) As String
        ' this removes all characters below ASCII 32 except for valid ones like tab (9), newline (10), and carriage return (13)
        Return New String(input.Where(Function(c) c >= " "c OrElse c = vbTab OrElse c = vbLf OrElse c = vbCr).ToArray())
    End Function

    Private Sub cmdExportXml_Click(sender As Object, e As EventArgs) Handles cmdExportXml.Click
        Dim vMyPgCon As New NpgsqlConnection
        Dim vMyPgCmd As NpgsqlCommand
        Dim vMyPgRd As NpgsqlDataReader

        Try
            Dim vQuery As String = "SELECT color_code, color_description, is_active FROM tb_colors ORDER BY color_description ASC"

            vMyPgCon.ConnectionString = pConnectVox
            vMyPgCon.Open()

            vMyPgCmd = New NpgsqlCommand(vQuery, vMyPgCon)
            vMyPgRd = vMyPgCmd.ExecuteReader()

            Dim xmlDoc As New XmlDocument()

            Dim root As XmlElement = xmlDoc.CreateElement("Table")
            xmlDoc.AppendChild(root)

            While vMyPgRd.Read()
                Dim colorElement As XmlElement = xmlDoc.CreateElement("Colors")

                Dim colorCodeElement As XmlElement = xmlDoc.CreateElement("Code")
                colorCodeElement.InnerText = SanitizeForXml(vMyPgRd("color_code").ToString())
                colorElement.AppendChild(colorCodeElement)

                Dim colorDescriptionElement As XmlElement = xmlDoc.CreateElement("Color")
                colorDescriptionElement.InnerText = SanitizeForXml(vMyPgRd("color_description").ToString())
                colorElement.AppendChild(colorDescriptionElement)

                'Dim isActiveElement As XmlElement = xmlDoc.CreateElement("IsActive")
                'isActiveElement.InnerText = vMyPgRd("is_active").ToString()
                'colorElement.AppendChild(isActiveElement)

                root.AppendChild(colorElement)
            End While

            Dim xmlFilePath As String = "C:\temp\Colors.xml" ' change path as needed
            xmlDoc.Save(xmlFilePath)

            MsgBox("Data has been exported to XML successfully.", MsgBoxStyle.Information, "Export Success")
            vMyPgRd.Close()
            vMyPgCmd.Dispose()

            vMyPgCon.Close()
        Catch ex As Exception
            MsgBox("An error occurred: " & ex.Message, MsgBoxStyle.Critical, "Error")

        End Try
    End Sub

    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click
        Dim vTmpStr As String = ""

        txtValue1.Clear()
        txtValue2.Clear()

        If timerDataLoad.Enabled = False Then timerDataLoad.Enabled = True
    End Sub

    Private Sub cmdClose_Click(sender As Object, e As EventArgs) Handles cmdClose.Click
        Dim vTmpStr As String

        'log event
        vTmpStr = modModule.CreateLog(Me.Name, "Add Color Module - Close", "")

        If vTmpStr = "1" Then
            Me.Close()
        Else
            MsgBox("An error occurred while saving log. Operation aborted.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Operation cancelled")
        End If
    End Sub
End Class