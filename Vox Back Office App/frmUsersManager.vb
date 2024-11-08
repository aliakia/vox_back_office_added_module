Imports Npgsql

Public Class frmUsersManager

    Private gSortingColumn As ColumnHeader

    Private Sub ImplementPrivileges()
    End Sub

    Private Sub frmUsersManager_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim vDataTable1 As New DataTable
        Dim vDataColumn1 As DataColumn
        Dim vDataRow1 As DataRow

        Dim vDataTable2 As New DataTable
        Dim vDataColumn2 As DataColumn
        Dim vDataRow2 As DataRow

        '        Dim vScreenX As Long
        '        Dim vScreenY As Long
        '        Dim vTmpVar As Long

        Me.MinimumSize = Me.Size
        Me.WindowState = FormWindowState.Maximized

        '        ' Get full screen width.
        '        vScreenX = GetSystemMetrics(SM_CXSCREEN)
        '
        '        ' Get full screen height.
        '        vScreenY = GetSystemMetrics(SM_CYSCREEN)
        '
        '        ' Call API to set new size of window.
        '        vTmpVar = SetWindowPos(Me.Handle, HWND_TOP, 0, 0, vScreenX, vScreenY, SWP_SHOWWINDOW)

        ' 0 .Add("User ID", 100, HorizontalAlignment.Left)
        ' 1 .Add("Full name", 200, HorizontalAlignment.Left)
        ' 2 .Add("Type", 100, HorizontalAlignment.Left)
        ' 3 .Add("PETC Code", 80, HorizontalAlignment.Left)
        ' 4 .Add("PETC name", 100, HorizontalAlignment.Left)
        ' 5 .Add("Status", 75, HorizontalAlignment.Left)
        ' 6 .Add("Description", 200, HorizontalAlignment.Left)
        ' 7 .Add("Gender", 75, HorizontalAlignment.Left)
        ' 8 .Add("TESDA certificate no.", 100, HorizontalAlignment.Left)
        ' 9 .Add("TESDA certification expiration", 100, HorizontalAlignment.Left)
        '10 .Add("Employee ID", 100, HorizontalAlignment.Left)
        '11 .Add("RecNo", 0, HorizontalAlignment.Left)

        With lsvItems.Columns
            .Clear()

            .Add("User ID", 100, HorizontalAlignment.Left)
            .Add("Full name", 200, HorizontalAlignment.Left)
            .Add("Type", 100, HorizontalAlignment.Left)
            .Add("PETC Code", 80, HorizontalAlignment.Left)
            .Add("PETC name", 100, HorizontalAlignment.Left)
            .Add("Status", 75, HorizontalAlignment.Left)
            .Add("Description", 200, HorizontalAlignment.Left)
            .Add("Gender", 75, HorizontalAlignment.Left)
            .Add("TESDA certificate no.", 100, HorizontalAlignment.Left)
            .Add("TESDA certification expiration", 100, HorizontalAlignment.Left)
            .Add("Employee ID", 100, HorizontalAlignment.Left)
            .Add("RecNo", 0, HorizontalAlignment.Left)
        End With

        lsvItems.Items.Clear()

        txtUserID.Text = ""
        txtPetcCode.Text = ""

        chkDisplayActiveOnly.Checked = True

        With cmbFilter1
            vDataColumn1 = New DataColumn
            vDataColumn1.ColumnName = "description"
            vDataTable1.Columns.Add(vDataColumn1)

            vDataColumn1 = New DataColumn
            vDataColumn1.ColumnName = "field"
            vDataTable1.Columns.Add(vDataColumn1)

            vDataRow1 = vDataTable1.NewRow
            vDataRow1(0) = ""
            vDataRow1(1) = ""
            vDataTable1.Rows.Add(vDataRow1)

            'vDataRow1 = vDataTable1.NewRow
            'vDataRow1(0) = "User name"
            'vDataRow1(1) = "sb.user_name"
            'vDataTable1.Rows.Add(vDataRow1)

            .DataSource = vDataTable1
            .DisplayMember = "description"
            .ValueMember = "field"
        End With

        With cmbFilter2
            vDataColumn2 = New DataColumn
            vDataColumn2.ColumnName = "description"
            vDataTable2.Columns.Add(vDataColumn2)

            vDataColumn2 = New DataColumn
            vDataColumn2.ColumnName = "field"
            vDataTable2.Columns.Add(vDataColumn2)

            vDataRow2 = vDataTable2.NewRow
            vDataRow2(0) = ""
            vDataRow2(1) = ""
            vDataTable2.Rows.Add(vDataRow2)

            'vDataRow2 = vDataTable2.NewRow
            'vDataRow2(0) = "User name"
            'vDataRow2(1) = "sc.user_name"
            'vDataTable2.Rows.Add(vDataRow2)

            .DataSource = vDataTable2
            .DisplayMember = "description"
            .ValueMember = "field"
        End With

        txtValue1.Text = ""
        txtValue2.Text = ""

        ImplementPrivileges()

        Dim vTmpStr As String

        'log event
        vTmpStr = modModule.CreateLog(Me.Name, "Users Manager - Open", "")

        timerDataLoad.Enabled = True
    End Sub

    Private Sub timerDataLoad_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timerDataLoad.Tick
        'open postgres connection
        Dim vMyPgCon As New NpgsqlConnection
        Dim vMyPgCmd = New NpgsqlCommand
        Dim vMyPgRd As NpgsqlDataReader
        Dim vFound As Boolean

        Dim vFilter As String
        Dim vSortBy As String
        Dim vQuery As String

        Dim vRecs As Long
        Dim vTmpVar As Integer

        timerDataLoad.Enabled = False

        Try
            gSortingColumn = Nothing
            lsvItems.ListViewItemSorter = Nothing
            modModule.RemoveSortHeaderInColumns(lsvItems)
            lsvItems.Items.Clear()

            vFilter = ""

            If txtUserID.Text <> "" Then
                vFilter = vFilter & IIf(Trim(vFilter) = "", " WHERE ", " AND ") & "LOWER(a.user_id) = '" & modModule.CorrectSqlString(LCase(txtUserID.Text)) & "'"
            End If

            If txtPetcCode.Text <> "" Then
                vFilter = vFilter & IIf(Trim(vFilter) = "", " WHERE ", " AND ") & "LOWER(a.petc_code) = '" & modModule.CorrectSqlString(LCase(txtPetcCode.Text)) & "'"
            End If

            If cmbFilter1.SelectedItem Is Nothing Then
            Else
                If cmbFilter1.Text <> "" And txtValue1.Text <> "" Then
                    Select Case Mid(cmbFilter1.SelectedItem(1).ToString, 1, 1)
                        Case "n"
                            vFilter = vFilter & " AND " & Mid(cmbFilter1.SelectedItem(1).ToString, 2, Len(cmbFilter1.SelectedItem(1).ToString)) & "=" & txtValue1.Text

                        Case "e"
                            vFilter = vFilter & " AND " & Mid(cmbFilter1.SelectedItem(1).ToString, 2, Len(cmbFilter1.SelectedItem(1).ToString)) & "='" & txtValue1.Text & "'"

                        Case Else
                            vFilter = vFilter & " AND LOWER(" & Mid(cmbFilter1.SelectedItem(1).ToString, 2, Len(cmbFilter1.SelectedItem(1).ToString)) & ") LIKE '%" & _
                                LCase(Trim(txtValue1.Text)) & "%'"
                    End Select
                End If
            End If

            If cmbFilter2.SelectedItem Is Nothing Then
            Else
                If cmbFilter2.Text <> "" And txtValue2.Text <> "" Then
                    Select Case Mid(cmbFilter2.SelectedItem(1).ToString, 1, 1)
                        Case "n"
                            vFilter = vFilter & " AND " & Mid(cmbFilter2.SelectedItem(1).ToString, 2, Len(cmbFilter2.SelectedItem(1).ToString)) & "=" & txtValue2.Text

                        Case "e"
                            vFilter = vFilter & " AND " & Mid(cmbFilter2.SelectedItem(1).ToString, 2, Len(cmbFilter2.SelectedItem(1).ToString)) & "='" & txtValue2.Text & "'"

                        Case Else
                            vFilter = vFilter & " AND LOWER(" & Mid(cmbFilter2.SelectedItem(1).ToString, 2, Len(cmbFilter2.SelectedItem(1).ToString)) & ") LIKE '%" & _
                                LCase(Trim(txtValue2.Text)) & "%'"
                    End Select
                End If
            End If

            If chkDisplayActiveOnly.Checked = True Then
                vFilter = vFilter & IIf(Trim(vFilter) = "", " WHERE ", " AND ") & "a.is_active = 1"
            End If

            vSortBy = "ORDER BY a.petc_code, a.user_id"

            vQuery = "SELECT a.user_id, a.user_name, a.user_type, a.petc_code, b.petc_name, a.is_active, a.description, a.gender, " & _
                "a.certificate_tesda, a.certificate_tesda_expiration, a.employee_id, a.recno FROM tb_users AS a " & _
                "LEFT OUTER JOIN tb_petcs AS b ON a.petc_code = b.petc_code " & vFilter & " " & vSortBy

            lblStatusPrompt.Text = "Opening database..."
            lblStatusPrompt.Visible = True
            lblStatusPrompt.Refresh()

            'open db connection
            vMyPgCon.ConnectionString = pConnectVox
            vMyPgCon.Open()

            'create query
            vMyPgCmd = New NpgsqlCommand(vQuery, vMyPgCon)

            'execute query
            vMyPgRd = vMyPgCmd.ExecuteReader()

            'read values
            vFound = vMyPgRd.Read

            vRecs = 0
            If vFound = False Then
                'no record found
            Else
                'get result

                pViewBackgroundCtr = 2

                Do While vFound = True
                    pViewBackgroundCtr = pViewBackgroundCtr + 1
                    If pViewBackgroundCtr > pViewBackgroundColorMax Then
                        pViewBackgroundCtr = 1
                    End If

                    If IsDBNull(vMyPgRd("user_id")) = True Then
                        lsvItems.Items.Add("")
                    Else
                        lsvItems.Items.Add(vMyPgRd("user_id"))
                    End If

                    lsvItems.Items(lsvItems.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)

                    If IsDBNull(vMyPgRd("user_name")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("user_name"))
                    End If

                    If IsDBNull(vMyPgRd("user_type")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("user_type"))
                    End If

                    If IsDBNull(vMyPgRd("petc_code")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("petc_code"))
                    End If

                    If IsDBNull(vMyPgRd("petc_name")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("petc_name"))
                    End If

                    If IsDBNull(vMyPgRd("is_active")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("Unknown")
                    Else
                        Select Case vMyPgRd("is_active")
                            Case 1
                                lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("Active")

                            Case 0
                                lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("Inactive")

                            Case Else
                                lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("Unknown")
                        End Select
                    End If

                    If IsDBNull(vMyPgRd("description")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("description"))
                    End If

                    If IsDBNull(vMyPgRd("gender")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("gender"))
                    End If

                    If IsDBNull(vMyPgRd("certificate_tesda")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("certificate_tesda"))
                    End If

                    If IsDBNull(vMyPgRd("certificate_tesda_expiration")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(Format(CDate(vMyPgRd("certificate_tesda_expiration").ToString), "MM/dd/yyyy"))
                    End If

                    If IsDBNull(vMyPgRd("employee_id")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("employee_id"))
                    End If

                    If IsDBNull(vMyPgRd("recno")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("recno"))
                    End If

                    vRecs = vRecs + 1

                    If vRecs = 1 Then
                        lblStatusPrompt.Text = "Gathering data... " & Trim(Str(vRecs)) & " records read"
                        lblStatusPrompt.Refresh()
                    ElseIf (vRecs Mod 25) = 0 Then
                        lblStatusPrompt.Text = "Gathering data... " & Trim(Str(vRecs)) & " records read"
                        lblStatusPrompt.Refresh()
                    End If

                    'read values
                    vFound = vMyPgRd.Read
                Loop
            End If

            lblStatusPrompt.Text = "Closing database..."
            lblStatusPrompt.Refresh()

            'close and dispose to avoid memory leak
            vMyPgRd.Close()
            vMyPgCmd.Dispose()

            'close and dispose connection
            vMyPgCon.Close()
            vMyPgCon = Nothing

            lblStatusPrompt.Visible = False

        Catch ex As Exception
            'an error has occured

            'close connections that might be open
            If IsNothing(vMyPgCon) = False Then
                If vMyPgCon.State <> ConnectionState.Closed Then
                    vMyPgCon.Close()
                    vMyPgCon = Nothing
                End If
            End If

            vTmpVar = MsgBox("An error has occured." & vbCrLf & vbCr & _
                           "Error number: " & Trim(Str(Err.Number)) & vbCrLf & _
                           "Error description: " & Err.Description, MsgBoxStyle.OkOnly, "Error warning")

            'log event
            vQuery = modModule.CreateLog(Me.Name, "Error:timerDataLoad", ex.Message)

            lblStatusPrompt.Visible = False
        End Try
    End Sub

    Private Sub frmUsersManager_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        '        Dim vPadding As Integer
        '        Dim vViewHeight As Integer
        '
        '        vPadding = 12
        '        vViewHeight = (Me.ClientSize.Height - grpFilters.Height - lblHeader.Height - (vPadding * 2)) + 2
        '
        '        lsvItems.Top = lblHeader.Height - 1
        '        lsvItems.Left = vPadding
        '        lsvItems.Width = Me.ClientSize.Width - (vPadding * 2)
        '        lsvItems.Height = vViewHeight * vViewHeight
    End Sub

    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click
        Dim vTmpStr As String = ""

        'lsvItems.Items.Clear()
        'lsvDetails.Items.Clear()

        txtUserID_LostFocus(sender, e)
        txtPetcCode_LostFocus(sender, e)

        If timerDataLoad.Enabled = False Then timerDataLoad.Enabled = True
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Dim vTmpStr As String

        'log event
        vTmpStr = modModule.CreateLog(Me.Name, "Users Manager - Close", "")

        If vTmpStr = "1" Then
            Me.Close()
        Else
            MsgBox("An error occurred while saving log. Operation aborted.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Operation cancelled")
        End If
    End Sub

    Private Sub lsvItems_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles lsvItems.ColumnClick
        Dim vNewSortingColumn As ColumnHeader = lsvItems.Columns(e.Column)  ' Get the new sorting column.
        Dim vSortOrder As System.Windows.Forms.SortOrder                    ' Figure out the new sorting order.

        If gSortingColumn Is Nothing Then
            vSortOrder = SortOrder.Ascending                                ' New column. Sort ascending.
        Else
            If vNewSortingColumn.Equals(gSortingColumn) Then                ' See if this is the same column.
                If gSortingColumn.Text.StartsWith("> ") Then                ' Same column. Switch the sort order.
                    vSortOrder = SortOrder.Descending
                Else
                    vSortOrder = SortOrder.Ascending
                End If
            Else
                vSortOrder = SortOrder.Ascending                            ' New column. Sort ascending.
            End If

            gSortingColumn.Text = gSortingColumn.Text.Substring(2)          ' Remove the old sort indicator.
        End If

        gSortingColumn = vNewSortingColumn                                  ' Display the new sort order.

        If vSortOrder = SortOrder.Ascending Then
            gSortingColumn.Text = "> " & gSortingColumn.Text
        Else
            gSortingColumn.Text = "< " & gSortingColumn.Text
        End If

        lsvItems.ListViewItemSorter = New modModule.ListViewItemComparer(e.Column, vSortOrder)  ' Create a comparer.

        lsvItems.Sort()                                                     ' Sort.

        modModule.RefreshAlternateViewColors(lsvItems)
    End Sub

    Private Sub lsvItems_DoubleClick(sender As Object, e As EventArgs) Handles lsvItems.DoubleClick
        If (cmdEdit.Visible = True And cmdEdit.Enabled = True) Then cmdEdit_Click(sender, e)
    End Sub

    Private Sub lsvItems_KeyPress(sender As Object, e As KeyPressEventArgs) Handles lsvItems.KeyPress
        Select Case Asc(e.KeyChar)
            Case 3
                modModule.CopyListViewToClipboard(lsvItems)

            Case 1
                modModule.ListViewSelectAll(lsvItems)
        End Select
    End Sub

    Private Sub txtUserID_GotFocus(sender As Object, e As EventArgs) Handles txtUserID.GotFocus
        txtUserID.SelectAll()
    End Sub

    Private Sub txtUserID_LostFocus(sender As Object, e As EventArgs) Handles txtUserID.LostFocus
        txtUserID.Text = Trim(modModule.StripInvalidStringChars(txtUserID.Text))
    End Sub

    Private Sub cmbFilter1_FormatStringChanged(sender As Object, e As EventArgs) Handles cmbFilter1.FormatStringChanged
        cmbFilter1.SelectAll()
    End Sub

    Private Sub cmbFilter2_GotFocus(sender As Object, e As EventArgs) Handles cmbFilter2.GotFocus
        cmbFilter2.SelectAll()
    End Sub

    Private Sub txtValue1_GotFocus(sender As Object, e As EventArgs) Handles txtValue1.GotFocus
        txtValue1.SelectAll()
    End Sub

    Private Sub txtValue1_LostFocus(sender As Object, e As EventArgs) Handles txtValue1.LostFocus
        txtValue1.Text = modModule.StripInvalidStringChars(Trim(txtValue1.Text))
    End Sub

    Private Sub txtValue2_GotFocus(sender As Object, e As EventArgs) Handles txtValue2.GotFocus
        txtValue2.SelectAll()
    End Sub

    Private Sub txtValue2_LostFocus(sender As Object, e As EventArgs) Handles txtValue2.LostFocus
        txtValue2.Text = modModule.StripInvalidStringChars(Trim(txtValue2.Text))
    End Sub

    Private Sub cmbFilter1_LostFocus(sender As Object, e As EventArgs) Handles cmbFilter1.LostFocus
        If modModule.ValidComboBoxData2(cmbFilter1.Text, cmbFilter1) = False Then
            cmbFilter1.Text = ""
        End If
    End Sub

    Private Sub cmbFilter2_LostFocus(sender As Object, e As EventArgs) Handles cmbFilter2.LostFocus
        If modModule.ValidComboBoxData2(cmbFilter2.Text, cmbFilter2) = False Then
            cmbFilter2.Text = ""
        End If
    End Sub

    Private Sub txtPetcCode_GotFocus(sender As Object, e As EventArgs) Handles txtPetcCode.GotFocus
        txtPetcCode.SelectAll()
    End Sub

    Private Sub txtPetcCode_LostFocus(sender As Object, e As EventArgs) Handles txtPetcCode.LostFocus
        txtPetcCode.Text = Trim(modModule.StripInvalidStringChars(txtPetcCode.Text))
    End Sub

    Private Sub cmdAdd_Click(sender As Object, e As EventArgs) Handles cmdAdd.Click
        With frmUsersManagerAddEdit
            .Mode = "new"
            .RecNo = ""

            .ShowDialog()
        End With
    End Sub

    Private Sub cmdEdit_Click(sender As Object, e As EventArgs) Handles cmdEdit.Click
        Dim vRecNo As String

        If lsvItems.Items.Count <= 0 Then Exit Sub

        If lsvItems.FocusedItem Is Nothing Then
            lsvItems.Items(0).Focused = True
        End If

        vRecNo = lsvItems.Items(lsvItems.FocusedItem.Index).SubItems(11).Text

        With frmUsersManagerAddEdit
            .Mode = "edit"
            .RecNo = vRecNo

            .ShowDialog()
        End With
    End Sub

    Private Sub txtUserID_TextChanged(sender As Object, e As EventArgs) Handles txtUserID.TextChanged

    End Sub

    Private Sub lsvItems_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsvItems.SelectedIndexChanged

    End Sub

    Private Sub txtPetcCode_TextChanged(sender As Object, e As EventArgs) Handles txtPetcCode.TextChanged

    End Sub

    Private Sub cmbFilter1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFilter1.SelectedIndexChanged

    End Sub

    Private Sub txtValue1_TextChanged(sender As Object, e As EventArgs) Handles txtValue1.TextChanged

    End Sub
End Class