Imports Npgsql

Public Class frmTerminalsManager

    Private gSortingColumn As ColumnHeader

    Private Sub ImplementPrivileges()
    End Sub

    Private Sub frmTerminalsManager_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

        ' 0 .Add("Terminal ID", 100, HorizontalAlignment.Left)
        ' 1 .Add("Description", 200, HorizontalAlignment.Left)
        ' 2 .Add("Type", 100, HorizontalAlignment.Left)
        ' 3 .Add("Serial", 100, HorizontalAlignment.Left)
        ' 4 .Add("MAC", 100, HorizontalAlignment.Left)
        ' 5 .Add("IP", 100, HorizontalAlignment.Left)
        ' 6 .Add("Status", 100, HorizontalAlignment.Left)
        ' 7 .Add("PETC Code", 100, HorizontalAlignment.Left)
        ' 8 .Add("PETC name", 200, HorizontalAlignment.Left)
        ' 9 .Add("PETC lane", 100, HorizontalAlignment.Right)
        '10 .Add("Machine description", 100, HorizontalAlignment.Left)
        '11 .Add("Machine serial", 100, HorizontalAlignment.Left)
        '12 .Add("Machine calibrated", 100, HorizontalAlignment.Left)
        '13 .Add("Lock status", 100, HorizontalAlignment.Left)
        '14 .Add("DLL", 100, HorizontalAlignment.Left)
        '15 .Add("Machine settings", 300, HorizontalAlignment.Left)
        '16 .Add("Is SCSI/SAS", 100, HorizontalAlignment.Left)

        With lsvItems.Columns
            .Clear()

            .Add("Terminal ID", 150, HorizontalAlignment.Left)
            .Add("Description", 200, HorizontalAlignment.Left)
            .Add("Type", 50, HorizontalAlignment.Left)
            .Add("Serial", 100, HorizontalAlignment.Left)
            .Add("MAC", 100, HorizontalAlignment.Left)
            .Add("IP", 100, HorizontalAlignment.Left)
            .Add("Status", 75, HorizontalAlignment.Left)
            .Add("PETC Code", 80, HorizontalAlignment.Left)
            .Add("PETC name", 200, HorizontalAlignment.Left)
            .Add("Lane", 50, HorizontalAlignment.Right)
            .Add("Machine description", 100, HorizontalAlignment.Left)
            .Add("Machine serial", 100, HorizontalAlignment.Left)
            .Add("Machine calibrated", 100, HorizontalAlignment.Left)
            .Add("Lock status", 100, HorizontalAlignment.Left)
            .Add("DLL", 100, HorizontalAlignment.Left)
            .Add("Machine settings", 300, HorizontalAlignment.Left)
            .Add("Is SCSI/SAS", 100, HorizontalAlignment.Left)
        End With

        lsvItems.Items.Clear()

        txtTerminalID.Text = ""
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

            '            vDataRow1 = vDataTable1.NewRow
            '            vDataRow1(0) = "User name"
            '            vDataRow1(1) = "sb.user_name"
            '            vDataTable1.Rows.Add(vDataRow1)

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

            '            vDataRow2 = vDataTable2.NewRow
            '            vDataRow2(0) = "User name"
            '            vDataRow2(1) = "sc.user_name"
            '            vDataTable2.Rows.Add(vDataRow2)

            .DataSource = vDataTable2
            .DisplayMember = "description"
            .ValueMember = "field"
        End With

        txtValue1.Text = ""
        txtValue2.Text = ""

        ImplementPrivileges()

        Dim vTmpStr As String

        'log event
        vTmpStr = modModule.CreateLog(Me.Name, "Terminals Manager - Open", "")

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
        Dim vTmpStr As String

        Dim vRecs As Long
        Dim vTmpVar As Integer

        timerDataLoad.Enabled = False

        Try
            gSortingColumn = Nothing
            lsvItems.ListViewItemSorter = Nothing
            modModule.RemoveSortHeaderInColumns(lsvItems)
            lsvItems.Items.Clear()

            vFilter = ""

            If txtTerminalID.Text <> "" Then
                vFilter = vFilter & IIf(Trim(vFilter) = "", " WHERE ", " AND ") & "LOWER(a.terminal_id) = '" & modModule.CorrectSqlString(LCase(txtTerminalID.Text)) & "'"
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

            vSortBy = "ORDER BY a.petc_code, a.terminal_id"

            vQuery = "SELECT a.terminal_id, a.terminal_type, a.terminal_serial, a.terminal_mac, a.terminal_ip, a.terminal_machine_description, a.terminal_machine_serial, " & _
                "a.terminal_machine_calibrated, a.petc_code, b.petc_name, a.petc_lane, a.is_active, a.description, a.lock_status, " & _
                "a.dll_file, a.machine_parity, a.machine_bits, a.machine_port, a.machine_baud_rate, a.machine_stop_bits, a.is_scsi " & _
                "FROM tb_stations AS a LEFT OUTER JOIN tb_petcs AS b ON a.petc_code = b.petc_code " & vFilter & " " & vSortBy

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

                    If IsDBNull(vMyPgRd("terminal_id")) = True Then
                        lsvItems.Items.Add("")
                    Else
                        lsvItems.Items.Add(vMyPgRd("terminal_id"))
                    End If

                    lsvItems.Items(lsvItems.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)

                    If IsDBNull(vMyPgRd("description")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("description"))
                    End If

                    If IsDBNull(vMyPgRd("terminal_type")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("terminal_type"))
                    End If

                    If IsDBNull(vMyPgRd("terminal_serial")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("terminal_serial"))
                    End If

                    If IsDBNull(vMyPgRd("terminal_mac")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("terminal_mac"))
                    End If

                    If IsDBNull(vMyPgRd("terminal_ip")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("terminal_ip"))
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

                    If IsDBNull(vMyPgRd("petc_lane")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("petc_lane"))
                    End If

                    If IsDBNull(vMyPgRd("terminal_machine_description")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("terminal_machine_description"))
                    End If

                    If IsDBNull(vMyPgRd("terminal_machine_serial")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("terminal_machine_serial"))
                    End If

                    If IsDBNull(vMyPgRd("terminal_machine_calibrated")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(Format(CDate(vMyPgRd("terminal_machine_calibrated").ToString), "MM/dd/yyyy"))
                    End If

                    If IsDBNull(vMyPgRd("lock_status")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("Unknown")
                    Else
                        Select Case vMyPgRd("lock_status")
                            Case 1
                                lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("Yes")

                            Case 0
                                lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("No")

                            Case Else
                                lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("Unknown")
                        End Select
                    End If

                    If IsDBNull(vMyPgRd("dll_file")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("dll_file"))
                    End If

                    vTmpStr = ""

                    If IsDBNull(vMyPgRd("machine_port")) = True Then
                        vTmpStr = "COM:Unknown"
                    Else
                        vTmpStr = "COM:" & vMyPgRd("machine_port")
                    End If

                    If IsDBNull(vMyPgRd("machine_baud_rate")) = True Then
                        vTmpStr = vTmpStr & " Baud:Unknown"
                    Else
                        vTmpStr = vTmpStr & " Baud:" & vMyPgRd("machine_baud_rate")
                    End If

                    If IsDBNull(vMyPgRd("machine_parity")) = True Then
                        vTmpStr = vTmpStr & " Parity:Unknown"
                    Else
                        vTmpStr = vTmpStr & " Parity:" & vMyPgRd("machine_parity")
                    End If

                    If IsDBNull(vMyPgRd("machine_bits")) = True Then
                        vTmpStr = vTmpStr & " Bits:Unknown"
                    Else
                        vTmpStr = vTmpStr & " Bits:" & vMyPgRd("machine_bits")
                    End If

                    If IsDBNull(vMyPgRd("machine_stop_bits")) = True Then
                        vTmpStr = vTmpStr & " Stop bits:Unknown"
                    Else
                        vTmpStr = vTmpStr & " Stop bits:" & vMyPgRd("machine_stop_bits")
                    End If

                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vTmpStr)

                    If IsDBNull(vMyPgRd("is_scsi")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("Unknown")
                    Else
                        Select Case vMyPgRd("is_scsi")
                            Case 1
                                lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("Yes")

                            Case 0
                                lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("No")

                            Case Else
                                lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("Unknown")
                        End Select
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

    Private Sub frmTerminalsManager_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
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

        txtTerminalID_LostFocus(sender, e)
        txtPetcCode_LostFocus(sender, e)

        If timerDataLoad.Enabled = False Then timerDataLoad.Enabled = True
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Dim vTmpStr As String

        'log event
        vTmpStr = modModule.CreateLog(Me.Name, "Terminals Manager - Close", "")

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

    Private Sub txtTerminalID_GotFocus(sender As Object, e As EventArgs) Handles txtTerminalID.GotFocus
        txtTerminalID.SelectAll()
    End Sub

    Private Sub txtTerminalID_LostFocus(sender As Object, e As EventArgs) Handles txtTerminalID.LostFocus
        txtTerminalID.Text = Trim(modModule.StripInvalidStringChars(txtTerminalID.Text))
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
        With frmTerminalsManagerAddEdit
            .Mode = "new"
            .TerminalID = ""

            .ShowDialog()
        End With
    End Sub

    Private Sub cmdEdit_Click(sender As Object, e As EventArgs) Handles cmdEdit.Click
        Dim vTerminalID As String

        If lsvItems.Items.Count <= 0 Then Exit Sub

        If lsvItems.FocusedItem Is Nothing Then
            lsvItems.Items(0).Focused = True
        End If

        vTerminalID = lsvItems.Items(lsvItems.FocusedItem.Index).Text

        With frmTerminalsManagerAddEdit
            .Mode = "edit"
            .TerminalID = vTerminalID

            .ShowDialog()
        End With
    End Sub

    Private Sub lsvItems_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsvItems.SelectedIndexChanged

    End Sub

    Private Sub cmdOptions_Click(sender As Object, e As EventArgs) Handles cmdOptions.Click

    End Sub
End Class