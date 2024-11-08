Imports Npgsql
Imports System.Xml

'uncomment active column if needed


Public Class frmAddMakeSeries
    Private gSortingColumn As ColumnHeader

    Private Sub frmAddMakeSeries_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MinimumSize = Me.Size
        Me.WindowState = FormWindowState.Maximized

        With cmItems.Columns
            .Clear()
            .Add("Make Code", 100, HorizontalAlignment.Left)
            .Add("Description", 500, HorizontalAlignment.Left)
            .Add("Series", 500, HorizontalAlignment.Left)
        End With
        Dim vTmpStr As String

        'log event
        vTmpStr = modModule.CreateLog(Me.Name, "Add Make and Series Module - Open", "")

        timerDataLoad.Enabled = True
    End Sub

    Private Sub cmItems_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles cmItems.ColumnClick
        Dim vNewSortingColumn As ColumnHeader = cmItems.Columns(e.Column)   ' get the new sorting column.
        Dim vSortOrder As System.Windows.Forms.SortOrder                    ' figure out the new sorting order.

        If gSortingColumn Is Nothing Then
            vSortOrder = SortOrder.Ascending                                ' new column. Sort ascending.
        Else
            If vNewSortingColumn.Equals(gSortingColumn) Then                ' see if this is the same  column.
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

        gSortingColumn = vNewSortingColumn
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
        ' open PostgreSQL connection
        Dim vMyPgCon As New NpgsqlConnection
        Dim vMyPgCmd = New NpgsqlCommand
        Dim vMyPgRd As NpgsqlDataReader

        timerDataLoad.Enabled = False

        Try
            cmItems.Items.Clear()
            cbb_make.Items.Clear()

            Dim vQuery As String = "SELECT make, make_description, series FROM tb_mv_make_series ORDER BY recno DESC"

            vMyPgCon.ConnectionString = pConnectVox
            vMyPgCon.Open()

            vMyPgCmd = New NpgsqlCommand(vQuery, vMyPgCon)

            vMyPgRd = vMyPgCmd.ExecuteReader()

            While vMyPgRd.Read()
                Dim listItem As New ListViewItem()

                listItem.Text = If(IsDBNull(vMyPgRd("make")), "", vMyPgRd("make").ToString())
                listItem.SubItems.Add(If(IsDBNull(vMyPgRd("make_description")), "", vMyPgRd("make_description").ToString()))
                listItem.SubItems.Add(If(IsDBNull(vMyPgRd("series")), "", vMyPgRd("series").ToString()))

                cmItems.Items.Add(listItem)

                ' add make_description to combo box
                Dim makeDescription As String = If(IsDBNull(vMyPgRd("make_description")), "", vMyPgRd("make_description").ToString())
                If Not cbb_make.Items.Contains(makeDescription) Then  ' check if make_description is already in combo box, to avoid duplications
                    cbb_make.Items.Add(makeDescription)
                End If

            End While

            vMyPgRd.Close()
            vMyPgCmd.Dispose()

            vMyPgCon.Close()
        Catch ex As Exception

            If vMyPgCon.State <> ConnectionState.Closed Then
                vMyPgCon.Close()
            End If

            MsgBox("An error occurred: " & ex.Message, MsgBoxStyle.OkOnly, "Error")
        End Try
        modModule.RefreshAlternateViewColors(cmItems)
    End Sub

    Private Sub ckb_newMake_CheckedChanged(sender As Object, e As EventArgs) Handles ckb_newMake.CheckedChanged
        If ckb_newMake.Checked Then

            txt_newMake.Visible = True
            cbb_make.Visible = False

        Else

            txt_newMake.Visible = False
            cbb_make.Visible = True

        End If
    End Sub

    'uncomment incase needed
    ' function to increment an alphabetic code like 'AAA' -> 'AAB', etc.
    'Private Function IncrementAlphabetic(code As String) As String
    '    Dim letters() As Char = code.ToCharArray()
    '    For i As Integer = letters.Length - 1 To 0 Step -1
    '        If letters(i) < "Z"c Then
    '            letters(i) = Chr(Asc(letters(i)) + 1)
    '            Return New String(letters)
    '        Else
    '            letters(i) = "A"c
    '        End If
    '    Next
    '    ' If all letters are 'Z', add another letter (e.g., ZZZ -> AAAA)
    '    Return "A" & New String(letters)
    'End Function

    Private Sub cmdAdd_Click(sender As Object, e As EventArgs) Handles cmdAdd.Click
        Dim makeDescription As String
        If ckb_newMake.Checked Then
            makeDescription = txt_newMake.Text
        Else
            makeDescription = cbb_make.Text
        End If
        Dim series As String = txt_series.Text
        Dim isActive As Integer = 1

        ' validation
        If String.IsNullOrWhiteSpace(makeDescription) Then
            MsgBox("Please fill in all required fields.", MsgBoxStyle.OkOnly, "Validation Error")
            Return
        End If

        Try
            Dim vMyPgCon As New NpgsqlConnection(pConnectVox)
            vMyPgCon.Open()

            ' check if the make_description already exists
            Dim selectQuery As String = "SELECT make FROM tb_mv_make_series WHERE make_description = @make_description LIMIT 1"
            Dim vMyPgCmdSelect As New NpgsqlCommand(selectQuery, vMyPgCon)
            vMyPgCmdSelect.Parameters.AddWithValue("@make_description", makeDescription)

            Dim existingMakeCode As Object = vMyPgCmdSelect.ExecuteScalar()

            Dim makeCode As String
            If existingMakeCode IsNot Nothing Then
                ' if the description exists, use the existing make_code
                makeCode = existingMakeCode.ToString()
            Else
                ' Dim random As New Random()
                ' Dim makeCode As String = "VOX" & random.Next(100, 1000).ToString()

                ' get the latest make code to increment
                Dim latestCodeQuery As String = "SELECT make FROM tb_mv_make_series WHERE make ILIKE 'VOX%' ORDER BY make DESC LIMIT 1"
                Dim vMyPgCmdLatest As New NpgsqlCommand(latestCodeQuery, vMyPgCon)

                Dim latestMakeCode As Object = vMyPgCmdLatest.ExecuteScalar()

                If latestMakeCode IsNot Nothing Then
                    ' extract the numeric part, increment, and pad with leading zeros
                    Dim latestNumber As Integer = CInt(latestMakeCode.ToString().Substring(3)) ' get the number part
                    makeCode = "VOX" & (latestNumber + 1).ToString("D3") ' increment and format as 3 digits
                Else
                    ' if no previous records exist, start from VOX001
                    makeCode = "VOX001"
                End If

                'Dim latestCodeQuery As String = "SELECT make FROM tb_mv_make_series WHERE make ILIKE 'VOX%' ORDER BY make DESC LIMIT 1"
                'Dim vMyPgCmdLatest As New NpgsqlCommand(latestCodeQuery, vMyPgCon)

                'Dim latestMakeCode As Object = vMyPgCmdLatest.ExecuteScalar()

                'If latestMakeCode IsNot Nothing Then
                '    ' extract the numeric or alphabetic part
                '    Dim codePart As String = latestMakeCode.ToString().Substring(3)

                '    If IsNumeric(codePart) Then
                '        ' if the latest code is numeric and below 999, increment it
                '        Dim latestNumber As Integer = CInt(codePart)
                '        If latestNumber < 999 Then
                '            makeCode = "VOX" & (latestNumber + 1).ToString("D3") '  increment and format as 3 digits
                '        Else
                '            ' when 999 is reached, switch to 'AAA'
                '            makeCode = "VOXAAA"
                '        End If
                '    Else
                '        ' if the latest code is alphabetic, increment the alphabetic sequence
                '        makeCode = "VOX" & IncrementAlphabetic(codePart)
                '    End If
                'Else
                '    ' if no previous records exist, start from VOX001
                '    makeCode = "VOX001"
                'End If
            End If

            Dim insertQuery As String = "INSERT INTO tb_mv_make_series (make, make_description, series, is_active) VALUES (@make, @make_description, @series, @is_active)"
            Dim vMyPgCmdInsert As New NpgsqlCommand(insertQuery, vMyPgCon)

            vMyPgCmdInsert.Parameters.AddWithValue("@make", makeCode)
            vMyPgCmdInsert.Parameters.AddWithValue("@make_description", makeDescription)
            vMyPgCmdInsert.Parameters.AddWithValue("@series", series)
            vMyPgCmdInsert.Parameters.AddWithValue("@is_active", isActive)

            vMyPgCmdInsert.ExecuteNonQuery()
            vMyPgCmdInsert.Dispose()

            vMyPgCmdSelect.Dispose()
            vMyPgCon.Close()

            Dim listItem As New ListViewItem(makeCode)
            listItem.SubItems.Add(makeDescription)
            listItem.SubItems.Add(series)

            cmItems.Items.Add(listItem)

            cbb_make.Items.Clear()
            txt_newMake.Clear()
            txt_series.Clear()

            MsgBox("Make and Series added successfully!", MsgBoxStyle.OkOnly, "Success")

        Catch ex As Exception
            MsgBox("An error occurred: " & ex.Message, MsgBoxStyle.OkOnly, "Error")
        End Try
    End Sub

    ' helper function to remove invalid XML characters
    Private Function SanitizeForXml(input As String) As String
        ' this removes all characters below ASCII 32 except for valid ones like tab (9), newline (10), and carriage return (13)
        Return New String(input.Where(Function(c) c >= " "c OrElse c = vbTab OrElse c = vbLf OrElse c = vbCr).ToArray())
    End Function

    Private Sub cmdExportXmlMake_Click(sender As Object, e As EventArgs) Handles cmdExportXmlMake.Click
        Dim vMyPgCon As New NpgsqlConnection
        Dim vMyPgCmd As NpgsqlCommand
        Dim vMyPgRd As NpgsqlDataReader

        Try
            Dim vQuery As String = "SELECT recno, make, make_description, series, is_active FROM tb_mv_make_series ORDER BY make_description ASC"

            vMyPgCon.ConnectionString = pConnectVox
            vMyPgCon.Open()

            vMyPgCmd = New NpgsqlCommand(vQuery, vMyPgCon)

            vMyPgRd = vMyPgCmd.ExecuteReader()

            Dim xmlDoc As New XmlDocument()

            Dim root As XmlElement = xmlDoc.CreateElement("Table")
            xmlDoc.AppendChild(root)

            While vMyPgRd.Read()
                Dim makeElement As XmlElement = xmlDoc.CreateElement("MakeSeries")

                'Dim recnoElement As XmlElement = xmlDoc.CreateElement("Recno")
                'recnoElement.InnerText = vMyPgRd("recno").ToString()
                'makeElement.AppendChild(recnoElement)

                Dim makeCodeElement As XmlElement = xmlDoc.CreateElement("Code")
                makeCodeElement.InnerText = SanitizeForXml(vMyPgRd("make").ToString())
                makeElement.AppendChild(makeCodeElement)

                Dim makeDescriptionElement As XmlElement = xmlDoc.CreateElement("Make")
                makeDescriptionElement.InnerText = SanitizeForXml(vMyPgRd("make_description").ToString())
                makeElement.AppendChild(makeDescriptionElement)

                Dim makeSeriesElement As XmlElement = xmlDoc.CreateElement("Series")
                makeSeriesElement.InnerText = SanitizeForXml(vMyPgRd("series").ToString())
                makeElement.AppendChild(makeSeriesElement)

                'Dim isActiveElement As XmlElement = xmlDoc.CreateElement("IsActive")
                'isActiveElement.InnerText = vMyPgRd("is_active").ToString()
                'makeElement.AppendChild(isActiveElement)

                root.AppendChild(makeElement)
            End While

            Dim xmlFilePath As String = "C:\temp\MakeSeries.xml" ' change path as needed
            xmlDoc.Save(xmlFilePath)

            MsgBox("Make Data has been exported to XML successfully.", MsgBoxStyle.Information, "Export Success")

            vMyPgRd.Close()
            vMyPgCmd.Dispose()
            vMyPgCon.Close()
        Catch ex As Exception
            MsgBox("An error occurred: " & ex.Message, MsgBoxStyle.Critical, "Error")

        End Try
    End Sub

    Private Sub cmdExportXmlSeries_Click(sender As Object, e As EventArgs) Handles cmdExportXmlSeries.Click
        Dim vMyPgCon As New NpgsqlConnection
        Dim vMyPgCmd As NpgsqlCommand
        Dim vMyPgRd As NpgsqlDataReader

        Try
            Dim vQuery As String = "SELECT recno, make, series, is_active FROM tb_mv_make_series ORDER BY series ASC"

            vMyPgCon.ConnectionString = pConnectVox
            vMyPgCon.Open()

            vMyPgCmd = New NpgsqlCommand(vQuery, vMyPgCon)

            vMyPgRd = vMyPgCmd.ExecuteReader()

            Dim xmlDoc As New XmlDocument()

            Dim root As XmlElement = xmlDoc.CreateElement("Series")
            xmlDoc.AppendChild(root)

            While vMyPgRd.Read()
                Dim makeElement As XmlElement = xmlDoc.CreateElement("Series")

                ' Create sanitized make and series elements
                Dim makeCodeElement As XmlElement = xmlDoc.CreateElement("MakeCode")
                makeCodeElement.InnerText = SanitizeForXml(vMyPgRd("make").ToString())
                makeElement.AppendChild(makeCodeElement)

                Dim makeDescriptionElement As XmlElement = xmlDoc.CreateElement("Series")
                makeDescriptionElement.InnerText = SanitizeForXml(vMyPgRd("series").ToString())
                makeElement.AppendChild(makeDescriptionElement)

                root.AppendChild(makeElement)
            End While

            Dim xmlFilePath As String = "C:\temp\series.xml" ' change path as needed
            xmlDoc.Save(xmlFilePath)

            MsgBox("Series Data has been exported to XML successfully.", MsgBoxStyle.Information, "Export Success")

            vMyPgRd.Close()
            vMyPgCmd.Dispose()

            vMyPgCon.Close()

        Catch ex As Exception
            MsgBox("An error occurred: " & ex.Message, MsgBoxStyle.Critical, "Error")

        End Try
    End Sub

    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click
        cmItems.ListViewItemSorter = Nothing
        Dim vTmpStr As String = ""

        txt_newMake.Clear()
        txt_series.Clear()

        If timerDataLoad.Enabled = False Then timerDataLoad.Enabled = True
    End Sub

    Private Sub cmdClose_Click(sender As Object, e As EventArgs) Handles cmdClose.Click
        Dim vTmpStr As String = modModule.CreateLog(Me.Name, "Add Make and Series Module - Close", "")
        If vTmpStr = "1" Then
            Me.Close()
        Else
            MsgBox("An error occurred while saving log. Operation aborted.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Operation cancelled")
        End If
    End Sub

    Private Sub txt_newMake_TextChanged(sender As Object, e As EventArgs) Handles txt_newMake.TextChanged
        If txt_newMake.Text.Length > 0 Then
            txt_newMake.Text = Char.ToUpper(txt_newMake.Text(0)) & txt_newMake.Text.Substring(1)
            txt_newMake.SelectionStart = txt_newMake.Text.Length
        End If
    End Sub

    Private Sub txt_series_TextChanged(sender As Object, e As EventArgs) Handles txt_series.TextChanged
        If txt_series.Text.Length > 0 Then
            txt_series.Text = Char.ToUpper(txt_series.Text(0)) & txt_series.Text.Substring(1)
            txt_series.SelectionStart = txt_series.Text.Length
        End If
    End Sub
End Class