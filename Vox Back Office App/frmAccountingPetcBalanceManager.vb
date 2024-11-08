Imports Npgsql

Public Class frmAccountingPetcBalanceManager

    Private gSortingColumn As ColumnHeader

    Private Sub ImplementPrivileges()
    End Sub

    Private Sub frmAccountingPetcBalanceManager_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

        ' 0 .Add("Petc code", 100, HorizontalAlignment.Left)
        ' 1 .Add("Name", 200, HorizontalAlignment.Left)
        ' 2 .Add("Status", 100, HorizontalAlignment.Left)
        ' 3 .Add("Pay type", 100, HorizontalAlignment.Left)
        ' 4 .Add("Balance", 0, HorizontalAlignment.Right)
        ' 5 .Add("Contact", 100, HorizontalAlignment.Left)
        ' 6 .Add("Transmission fee", 100, HorizontalAlignment.Right)
        ' 7 .Add("Stradcom fee", 100, HorizontalAlignment.Right)
        ' 8 .Add("Max credit", 100, HorizontalAlignment.Right)
        ' 9 .Add("Address", 200, HorizontalAlignment.Left)
        '10 .Add("Remarks", 200, HorizontalAlignment.Left)

        With lsvSummary.Columns
            .Clear()

            .Add("Petc code", 100, HorizontalAlignment.Left)
            .Add("Name", 200, HorizontalAlignment.Left)
            .Add("Status", 100, HorizontalAlignment.Left)
            .Add("Pay type", 100, HorizontalAlignment.Left)
            .Add("Balance", 100, HorizontalAlignment.Right)
            .Add("Contact", 100, HorizontalAlignment.Left)
            .Add("Transmission fee", 100, HorizontalAlignment.Right)
            .Add("Stradcom fee", 100, HorizontalAlignment.Right)
            .Add("Maximum credit", 100, HorizontalAlignment.Right)
            .Add("Address", 200, HorizontalAlignment.Left)
            .Add("Remarks", 200, HorizontalAlignment.Left)
        End With

        '0 .Add("Date", 100, HorizontalAlignment.Left)
        '1 .Add("Ledger code", 0, HorizontalAlignment.Left)
        '2 .Add("Description", 100, HorizontalAlignment.Left)
        '3 .Add("Debit", 0, HorizontalAlignment.Right)
        '4 .Add("Credit", 0, HorizontalAlignment.Right)
        '5 .Add("Balance", 0, HorizontalAlignment.Right)
        '6 .Add("Remarks", 100, HorizontalAlignment.Left)
        '7 .Add("RecNo", 100, HorizontalAlignment.Right)

        With lsvDetails.Columns
            .Clear()

            .Add("Period", 120, HorizontalAlignment.Left)
            .Add("Ledger code", 0, HorizontalAlignment.Left)
            .Add("Description", 200, HorizontalAlignment.Left)
            .Add("Debit", 100, HorizontalAlignment.Right)
            .Add("Credit", 100, HorizontalAlignment.Right)
            .Add("Balance", 100, HorizontalAlignment.Right)
            .Add("Remarks", 500, HorizontalAlignment.Left)
            .Add("RecNo", 100, HorizontalAlignment.Right)
        End With

        lsvSummary.Items.Clear()
        lsvDetails.Items.Clear()

        txtPetcCode.Text = ""
        txtRecs.Text = "1,000"

        chkWithBalanceOnly.Checked = True

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
        vTmpStr = modModule.CreateLog(Me.Name, "PETC Balance Manager - Open", "")

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
            lsvSummary.ListViewItemSorter = Nothing
            modModule.RemoveSortHeaderInColumns(lsvSummary)
            lsvSummary.Items.Clear()

            vFilter = ""

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

            If chkWithBalanceOnly.Checked = True Then
                vFilter = vFilter & IIf(Trim(vFilter) = "", " WHERE ", " AND ") & "a.balance <> 0"
            End If

            vSortBy = "ORDER BY b.petc_name, a.petc_code"

            vQuery = "SELECT a.petc_code, b.petc_name, b.is_active, a.account_type, a.balance, b.contact_no, a.transmission_fee, a.stradcom_fee, a.max_credit, " & _
                "b.petc_address, a.remarks " & _
                "FROM tb_petc_balance AS a LEFT OUTER JOIN tb_petcs AS b ON a.petc_code = b.petc_code " & vFilter & " " & vSortBy

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

                    If IsDBNull(vMyPgRd("petc_code")) = True Then
                        lsvSummary.Items.Add("")
                    Else
                        lsvSummary.Items.Add(vMyPgRd("petc_code"))
                    End If

                    lsvSummary.Items(lsvSummary.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)

                    If IsDBNull(vMyPgRd("petc_name")) = True Then
                        lsvSummary.Items(lsvSummary.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvSummary.Items(lsvSummary.Items.Count - 1).SubItems.Add(vMyPgRd("petc_name"))
                    End If

                    If IsDBNull(vMyPgRd("is_active")) = True Then
                        lsvSummary.Items(lsvSummary.Items.Count - 1).SubItems.Add("Unknown")
                    Else
                        Select Case vMyPgRd("is_active")
                            Case 0
                                lsvSummary.Items(lsvSummary.Items.Count - 1).SubItems.Add("Inactive")

                            Case 1
                                lsvSummary.Items(lsvSummary.Items.Count - 1).SubItems.Add("Active")

                            Case 2
                                lsvSummary.Items(lsvSummary.Items.Count - 1).SubItems.Add("Suspended")

                            Case 3
                                lsvSummary.Items(lsvSummary.Items.Count - 1).SubItems.Add("Expired")

                            Case 4
                                lsvSummary.Items(lsvSummary.Items.Count - 1).SubItems.Add("Revoked")

                            Case Else
                                lsvSummary.Items(lsvSummary.Items.Count - 1).SubItems.Add("Unknown")
                        End Select
                    End If

                    Select Case vMyPgRd("account_type")
                        Case 1
                            lsvSummary.Items(lsvSummary.Items.Count - 1).SubItems.Add("Post-paid")

                        Case 2
                            lsvSummary.Items(lsvSummary.Items.Count - 1).SubItems.Add("Pre-paid")

                        Case Else
                            lsvSummary.Items(lsvSummary.Items.Count - 1).SubItems.Add("Unknown")
                    End Select

                    If IsDBNull(vMyPgRd("balance")) = True Then
                        lsvSummary.Items(lsvSummary.Items.Count - 1).SubItems.Add("Unknown")
                    Else
                        lsvSummary.Items(lsvSummary.Items.Count - 1).SubItems.Add(Format(vMyPgRd("balance"), "###,###,###,##0.00"))
                    End If

                    If IsDBNull(vMyPgRd("contact_no")) = True Then
                        lsvSummary.Items(lsvSummary.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvSummary.Items(lsvSummary.Items.Count - 1).SubItems.Add(vMyPgRd("contact_no"))
                    End If

                    If IsDBNull(vMyPgRd("transmission_fee")) = True Then
                        lsvSummary.Items(lsvSummary.Items.Count - 1).SubItems.Add("Unknown")
                    Else
                        lsvSummary.Items(lsvSummary.Items.Count - 1).SubItems.Add(Format(vMyPgRd("transmission_fee"), "###,###,###,##0.00"))
                    End If

                    If IsDBNull(vMyPgRd("stradcom_fee")) = True Then
                        lsvSummary.Items(lsvSummary.Items.Count - 1).SubItems.Add("Unknown")
                    Else
                        lsvSummary.Items(lsvSummary.Items.Count - 1).SubItems.Add(Format(vMyPgRd("stradcom_fee"), "###,###,###,##0.00"))
                    End If

                    If IsDBNull(vMyPgRd("max_credit")) = True Then
                        lsvSummary.Items(lsvSummary.Items.Count - 1).SubItems.Add("Unknown")
                    Else
                        lsvSummary.Items(lsvSummary.Items.Count - 1).SubItems.Add(Format(vMyPgRd("max_credit"), "###,###,###,##0.00"))
                    End If

                    If IsDBNull(vMyPgRd("petc_address")) = True Then
                        lsvSummary.Items(lsvSummary.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvSummary.Items(lsvSummary.Items.Count - 1).SubItems.Add(vMyPgRd("petc_address"))
                    End If

                    If IsDBNull(vMyPgRd("remarks")) = True Then
                        lsvSummary.Items(lsvSummary.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvSummary.Items(lsvSummary.Items.Count - 1).SubItems.Add(vMyPgRd("remarks"))
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

            If lsvSummary.Items.Count > 0 Then
                RefreshDetails(lsvDetails, lsvSummary.Items(0).Text)
            End If

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

    Private Sub frmAccountingPetcBalanceManager_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        '        Dim vPadding As Integer
        '        Dim vViewHeight As Integer
        '
        '        vPadding = 12
        '        vViewHeight = (Me.ClientSize.Height - grpFilters.Height - lblHeader.Height - (vPadding * 2)) + 2
        '
        '        lsvSummary.Top = lblHeader.Height - 1
        '        lsvSummary.Left = vPadding
        '        lsvSummary.Width = Me.ClientSize.Width - (vPadding * 2)
        '        lsvSummary.Height = vViewHeight * vViewHeight
    End Sub

    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click
        Dim vTmpStr As String = ""

        'lsvSummary.Items.Clear()
        'lsvDetails.Items.Clear()

        txtPetcCode_LostFocus(sender, e)

        If timerDataLoad.Enabled = False Then timerDataLoad.Enabled = True
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Dim vTmpStr As String

        'log event
        vTmpStr = modModule.CreateLog(Me.Name, "PETC Balance Manager - Close", "")

        If vTmpStr = "1" Then
            Me.Close()
        Else
            MsgBox("An error occurred while saving log. Operation aborted.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Operation cancelled")
        End If
    End Sub

    Private Sub lsvSummary_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles lsvSummary.ColumnClick
        Dim vNewSortingColumn As ColumnHeader = lsvSummary.Columns(e.Column)  ' Get the new sorting column.
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

        lsvSummary.ListViewItemSorter = New modModule.ListViewItemComparer(e.Column, vSortOrder)  ' Create a comparer.

        lsvSummary.Sort()                                                     ' Sort.

        modModule.RefreshAlternateViewColors(lsvSummary)
    End Sub

    Private Sub lsvSummary_KeyPress(sender As Object, e As KeyPressEventArgs) Handles lsvSummary.KeyPress
        Select Case Asc(e.KeyChar)
            Case 3
                modModule.CopyListViewToClipboard(lsvSummary)

            Case 1
                modModule.ListViewSelectAll(lsvSummary)
        End Select
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
        Dim vPetcCode As String

        If lsvSummary.Items.Count <= 0 Then
            vPetcCode = ""
        ElseIf lsvSummary.FocusedItem Is Nothing Then
            vPetcCode = ""
        Else
            vPetcCode = lsvSummary.Items(lsvSummary.FocusedItem.Index).Text
        End If

        With frmAccountingPetcLedgerAddEntry
            .PetcCode = vPetcCode

            .ShowDialog()
        End With
    End Sub

    Private Sub lsvDetails_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles lsvDetails.ColumnClick
        Dim vNewSortingColumn As ColumnHeader = lsvDetails.Columns(e.Column)  ' Get the new sorting column.
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

        lsvDetails.ListViewItemSorter = New modModule.ListViewItemComparer(e.Column, vSortOrder)  ' Create a comparer.

        lsvDetails.Sort()                                                     ' Sort.

        modModule.RefreshAlternateViewColors(lsvDetails)
    End Sub

    Private Sub lsvDetails_KeyPress(sender As Object, e As KeyPressEventArgs) Handles lsvDetails.KeyPress
        Select Case Asc(e.KeyChar)
            Case 3
                modModule.CopyListViewToClipboard(lsvDetails)

            Case 1
                modModule.ListViewSelectAll(lsvDetails)
        End Select
    End Sub

    Private Sub lsvDetails_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsvDetails.SelectedIndexChanged

    End Sub

    Private Sub lsvSummary_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsvSummary.SelectedIndexChanged
        Me.RefreshDetails(lsvDetails, lsvSummary.Items(lsvSummary.FocusedItem.Index).Text)
    End Sub

    Private Sub RefreshDetails(ByVal bListView As ListView, ByVal bPetcCode As String)
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
            bListView.ListViewItemSorter = Nothing
            modModule.RemoveSortHeaderInColumns(bListView)
            bListView.Items.Clear()

            vFilter = ""
            vFilter = vFilter & IIf(Trim(vFilter) = "", " WHERE ", " AND ") & "LOWER(petc_code) = '" & modModule.CorrectSqlString(LCase(bPetcCode)) & "'"

            If optShowCreditOnly.Checked = True Then
                vFilter = vFilter & IIf(Trim(vFilter) = "", " WHERE ", " AND ") & "credit <> 0 "
            End If

            If optShowDebitOnly.Checked = True Then
                vFilter = vFilter & IIf(Trim(vFilter) = "", " WHERE ", " AND ") & "debit <> 0 "
            End If

            vSortBy = "ORDER BY recno DESC"

            vQuery = "SELECT trans_date, ledger_code, ledger_description, debit, credit, balance, remarks, recno " & _
                "FROM tb_petc_balance_details " & vFilter & " " & vSortBy & IIf(txtRecs.Text = "" Or txtRecs.Text = "0", "", " LIMIT " & Trim(Str(CDbl(txtRecs.Text))))

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

                    If IsDBNull(vMyPgRd("trans_date")) = True Then
                        bListView.Items.Add("")
                    Else
                        bListView.Items.Add(Format(CDate(vMyPgRd("trans_date").ToString), "MM/dd/yyyy HH:mm:ss"))
                    End If

                    bListView.Items(bListView.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)

                    If IsDBNull(vMyPgRd("ledger_code")) = True Then
                        bListView.Items(bListView.Items.Count - 1).SubItems.Add("")
                    Else
                        bListView.Items(bListView.Items.Count - 1).SubItems.Add(vMyPgRd("ledger_code"))
                    End If

                    If IsDBNull(vMyPgRd("ledger_description")) = True Then
                        bListView.Items(bListView.Items.Count - 1).SubItems.Add("")
                    Else
                        bListView.Items(bListView.Items.Count - 1).SubItems.Add(vMyPgRd("ledger_description"))
                    End If

                    If IsDBNull(vMyPgRd("debit")) = True Then
                        bListView.Items(bListView.Items.Count - 1).SubItems.Add("Unknown")
                    Else
                        bListView.Items(bListView.Items.Count - 1).SubItems.Add(Format(vMyPgRd("debit"), "###,###,###,##0.00"))
                    End If

                    If IsDBNull(vMyPgRd("credit")) = True Then
                        bListView.Items(bListView.Items.Count - 1).SubItems.Add("Unknown")
                    Else
                        bListView.Items(bListView.Items.Count - 1).SubItems.Add(Format(vMyPgRd("credit"), "###,###,###,##0.00"))
                    End If

                    If IsDBNull(vMyPgRd("balance")) = True Then
                        bListView.Items(bListView.Items.Count - 1).SubItems.Add("Unknown")
                    Else
                        bListView.Items(bListView.Items.Count - 1).SubItems.Add(Format(vMyPgRd("balance"), "###,###,###,##0.00"))
                    End If

                    If IsDBNull(vMyPgRd("remarks")) = True Then
                        bListView.Items(bListView.Items.Count - 1).SubItems.Add("")
                    Else
                        bListView.Items(bListView.Items.Count - 1).SubItems.Add(vMyPgRd("remarks"))
                    End If

                    If IsDBNull(vMyPgRd("recno")) = True Then
                        bListView.Items(bListView.Items.Count - 1).SubItems.Add("")
                    Else
                        bListView.Items(bListView.Items.Count - 1).SubItems.Add(vMyPgRd("recno"))
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
            vQuery = modModule.CreateLog(Me.Name, "Error:RefreshDetails", ex.Message)

            lblStatusPrompt.Visible = False
        End Try
    End Sub

    Private Sub cmdDetails_Click(sender As Object, e As EventArgs) Handles cmdDetails.Click

    End Sub

    Private Sub txtRecs_GotFocus(sender As Object, e As EventArgs) Handles txtRecs.GotFocus
        txtRecs.SelectAll()
    End Sub

    Private Sub txtRecs_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRecs.KeyPress
        Select Case e.KeyChar
            Case "0" To "9"
            Case "."
            Case "-"
            Case ","
            Case Else
                e.Handled = True
        End Select
    End Sub

    Private Sub txtRecs_LostFocus(sender As Object, e As EventArgs) Handles txtRecs.LostFocus
        If IsNumeric(txtRecs.Text) = True Then
            txtRecs.Text = Format(CDbl(txtRecs.Text), "###,###,##0")
        Else
            txtRecs.Text = "0"
        End If
    End Sub

    Private Sub txtRecs_TextChanged(sender As Object, e As EventArgs) Handles txtRecs.TextChanged

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub

    Private Sub cmdPrint_Click(sender As Object, e As EventArgs) Handles cmdPrint.Click

    End Sub
End Class