Imports Npgsql

Public Class frmLogsUserActivities

    Private gSortingColumn As ColumnHeader

    Private Sub ImplementPrivileges()
    End Sub

    Private Sub frmLogsUserActivities_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

        '0 .Add("Period", 125, HorizontalAlignment.Left)
        '1 .Add("User ID", 100, HorizontalAlignment.Left)
        '2 .Add("User name", 100, HorizontalAlignment.Left)
        '3 .Add("Description", 250, HorizontalAlignment.Left)
        '4 .Add("Remarks", 250, HorizontalAlignment.Left)
        '5 .Add("Terminal used", 100, HorizontalAlignment.Left)
        '6 .Add("Terminal serial", 100, HorizontalAlignment.Left)
        '7 .Add("Rec. no.", 0, HorizontalAlignment.Right)

        With lsvItems.Columns
            .Clear()

            .Add("Period", 125, HorizontalAlignment.Left)

            .Add("User ID", 100, HorizontalAlignment.Left)
            .Add("User name", 100, HorizontalAlignment.Left)
            .Add("Description", 250, HorizontalAlignment.Left)
            .Add("Remarks", 250, HorizontalAlignment.Left)
            .Add("Terminal used", 100, HorizontalAlignment.Left)
            .Add("Terminal serial", 100, HorizontalAlignment.Left)

            .Add("Rec. no.", 0, HorizontalAlignment.Right)
        End With

        lsvItems.Items.Clear()

        txtFilterDateFrom.Text = Format(DateTime.Now, "MM/dd/yyyy")
        txtFilterDateTo.Text = txtFilterDateFrom.Text

        txtUserID.Text = pUserID

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

            vDataRow1 = vDataTable1.NewRow
            vDataRow1(0) = "User name"
            vDataRow1(1) = "sb.user_name"
            vDataTable1.Rows.Add(vDataRow1)

            vDataRow1 = vDataTable1.NewRow
            vDataRow1(0) = "Description"
            vDataRow1(1) = "sa.description"
            vDataTable1.Rows.Add(vDataRow1)

            vDataRow1 = vDataTable1.NewRow
            vDataRow1(0) = "Remarks"
            vDataRow1(1) = "sa.remarks"
            vDataTable1.Rows.Add(vDataRow1)

            vDataRow1 = vDataTable1.NewRow
            vDataRow1(0) = "Terminal used"
            vDataRow1(1) = "sa.terminal_used"
            vDataTable1.Rows.Add(vDataRow1)

            vDataRow1 = vDataTable1.NewRow
            vDataRow1(0) = "Terminal serial"
            vDataRow1(1) = "sa.terminal_serial"
            vDataTable1.Rows.Add(vDataRow1)

            vDataRow1 = vDataTable1.NewRow
            vDataRow1(0) = "Record number"
            vDataRow1(1) = "na.recno"
            vDataTable1.Rows.Add(vDataRow1)

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

            vDataRow2 = vDataTable2.NewRow
            vDataRow2(0) = "User name"
            vDataRow2(1) = "sc.user_name"
            vDataTable2.Rows.Add(vDataRow2)

            vDataRow2 = vDataTable2.NewRow
            vDataRow2(0) = "Description"
            vDataRow2(1) = "sa.description"
            vDataTable2.Rows.Add(vDataRow2)

            vDataRow2 = vDataTable2.NewRow
            vDataRow2(0) = "Remarks"
            vDataRow2(1) = "sa.remarks"
            vDataTable2.Rows.Add(vDataRow2)

            vDataRow2 = vDataTable2.NewRow
            vDataRow2(0) = "Terminal used"
            vDataRow2(1) = "sa.terminal_used"
            vDataTable2.Rows.Add(vDataRow2)

            vDataRow2 = vDataTable2.NewRow
            vDataRow2(0) = "Terminal serial"
            vDataRow2(1) = "sa.terminal_serial"
            vDataTable2.Rows.Add(vDataRow2)

            vDataRow2 = vDataTable2.NewRow
            vDataRow2(0) = "Record number"
            vDataRow2(1) = "na.recno"
            vDataTable2.Rows.Add(vDataRow2)

            .DataSource = vDataTable2
            .DisplayMember = "description"
            .ValueMember = "field"
        End With

        txtValue1.Text = ""
        txtValue2.Text = ""

        ImplementPrivileges()

        Dim vTmpStr As String

        'log event
        vTmpStr = modModule.CreateLog(Me.Name, "User Activity Logs - Open", "")

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

            If txtFilterDateFrom.Text <> "" And txtFilterDateTo.Text <> "" Then
                vFilter = vFilter & " WHERE (a.period :: date >= '" & Format(CDate(txtFilterDateFrom.Text), "yyyy-MM-dd") & "' AND " & _
                    "a.period :: date <= '" & Format(CDate(txtFilterDateTo.Text), "yyyy-MM-dd") & "')"
            End If

            If txtUserID.Text <> "" Then
                vFilter = vFilter & IIf(Trim(vFilter) = "", " WHERE ", " AND ") & "LOWER(a.processed_by) = '" & LCase(txtUserID.Text) & "'"
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

            vSortBy = "ORDER BY a.recno"

            vQuery = "SELECT a.recno, a.description, a.remarks, a.processed_by, a.terminal_used, a.terminal_serial, a.period, b.user_name " & _
                "FROM tb_back_office_logs AS a LEFT OUTER JOIN tb_users AS b ON a.processed_by = b.user_id AND b.petc_code = 'tech.support' " & _
                vFilter & " " & vSortBy

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

                    If IsDBNull(vMyPgRd("period")) = True Then
                        lsvItems.Items.Add("")
                    Else
                        lsvItems.Items.Add(Format(CDate(vMyPgRd("period").ToString), "MM/dd/yyyy HH:mm:ss"))
                    End If

                    lsvItems.Items(lsvItems.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)

                    If IsDBNull(vMyPgRd("processed_by")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("processed_by"))
                    End If

                    If IsDBNull(vMyPgRd("user_name")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("user_name"))
                    End If

                    If IsDBNull(vMyPgRd("description")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("description"))
                    End If

                    If IsDBNull(vMyPgRd("remarks")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("remarks"))
                    End If

                    If IsDBNull(vMyPgRd("terminal_used")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("terminal_used"))
                    End If

                    If IsDBNull(vMyPgRd("terminal_serial")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("terminal_serial"))
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

    Private Sub frmLogsUserActivities_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
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

        txtFilterDateFrom_LostFocus(sender, e)
        txtFilterDateTo_LostFocus(sender, e)
        txtUserID_LostFocus(sender, e)

        If txtFilterDateFrom.Text = "" Then
            MsgBox("Please enter date range to process.", vbOK + vbExclamation, "Incomplete data")

            txtFilterDateFrom.Select()
            txtFilterDateFrom.Focus()

            Exit Sub
        End If

        If txtFilterDateTo.Text = "" Then
            MsgBox("Please enter date range to process.", vbOK + vbExclamation, "Incomplete data")

            txtFilterDateTo.Select()
            txtFilterDateTo.Focus()

            Exit Sub
        End If

        If CDate(txtFilterDateFrom.Text) > CDate(txtFilterDateTo.Text) Then
            vTmpStr = txtFilterDateFrom.Text

            txtFilterDateFrom.Text = txtFilterDateTo.Text
            txtFilterDateTo.Text = vTmpStr
        End If

        If timerDataLoad.Enabled = False Then timerDataLoad.Enabled = True
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Dim vTmpStr As String

        'log event
        vTmpStr = modModule.CreateLog(Me.Name, "User Activity Logs - Close", "")

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

    Private Sub lsvItems_KeyPress(sender As Object, e As KeyPressEventArgs) Handles lsvItems.KeyPress
        Select Case Asc(e.KeyChar)
            Case 3
                modModule.CopyListViewToClipboard(lsvItems)

            Case 1
                modModule.ListViewSelectAll(lsvItems)
        End Select
    End Sub

    Private Sub txtFilterDateFrom_GotFocus(sender As Object, e As EventArgs) Handles txtFilterDateFrom.GotFocus
        txtFilterDateFrom.SelectAll()
    End Sub

    Private Sub txtFilterDateFrom_LostFocus(sender As Object, e As EventArgs) Handles txtFilterDateFrom.LostFocus
        If IsDate(txtFilterDateFrom.Text) = True Then
            txtFilterDateFrom.Text = CDate(txtFilterDateFrom.Text).ToString("MM/dd/yyyy")
        Else
            txtFilterDateFrom.Text = ""
        End If
    End Sub

    Private Sub txtFilterDateTo_GotFocus(sender As Object, e As EventArgs) Handles txtFilterDateTo.GotFocus
        txtFilterDateTo.SelectAll()
    End Sub

    Private Sub txtFilterDateTo_LostFocus(sender As Object, e As EventArgs) Handles txtFilterDateTo.LostFocus
        If IsDate(txtFilterDateTo.Text) = True Then
            txtFilterDateTo.Text = CDate(txtFilterDateTo.Text).ToString("MM/dd/yyyy")
        Else
            txtFilterDateTo.Text = ""
        End If
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

    Private Sub lsvItems_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsvItems.SelectedIndexChanged

    End Sub

    Private Sub txtUserID_TextChanged(sender As Object, e As EventArgs) Handles txtUserID.TextChanged

    End Sub

    Private Sub txtUserID_TextChanged_1(sender As Object, e As EventArgs) Handles txtUserID.TextChanged

    End Sub

End Class