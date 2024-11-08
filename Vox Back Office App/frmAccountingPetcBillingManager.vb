Imports Npgsql

Public Class frmAccountingPetcBillingManager

    Private gSortingColumn As ColumnHeader
    Private gPrintListview As ListView
    Private gPrintListDetails As ListView
    Private gSeq As Long
    Private gDetailsSeq As Long
    Private gDetailsSeqPrint As Long
    Private gPrintFirstPage As Boolean
    Private gTotalCredit As Double
    Private gPrintPageNo As Integer
    Private gFooterPrinted As Boolean
    Private gPrintDetails As Boolean

    Private Sub ImplementPrivileges()
    End Sub

    Private Sub frmAccountingPetcBillingManager_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

        With lsvItems.Columns
            .Clear()

            .Add("SOA No.", 100, HorizontalAlignment.Left)
            .Add("Petc code", 100, HorizontalAlignment.Left)
            .Add("Series", 100, HorizontalAlignment.Left)
            .Add("Petc name", 150, HorizontalAlignment.Left)
            .Add("Date from", 75, HorizontalAlignment.Left)
            .Add("Date to", 75, HorizontalAlignment.Left)
            .Add("Date due", 75, HorizontalAlignment.Left)
            .Add("Transactions", 100, HorizontalAlignment.Right)
            .Add("Begin balance", 125, HorizontalAlignment.Right)
            .Add("Total debit", 125, HorizontalAlignment.Right)
            .Add("Total credit", 125, HorizontalAlignment.Right)
            .Add("Amount due", 125, HorizontalAlignment.Right)
            .Add("Remarks", 150, HorizontalAlignment.Left)
            .Add("Processed by", 150, HorizontalAlignment.Left)
            .Add("Date/time processed", 150, HorizontalAlignment.Left)
            .Add("Station used", 150, HorizontalAlignment.Left)
            .Add("Active", 75, HorizontalAlignment.Center)
            .Add("Type", 100, HorizontalAlignment.Left)
            .Add("Address", 200, HorizontalAlignment.Left)
        End With

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

        lsvItems.Items.Clear()
        lsvDetails.Items.Clear()

        txtDateFrom.Text = CDate(DateTime.Now).AddDays(-30).ToString("MM/dd/yyyy")
        txtDateTo.Text = CDate(DateTime.Now).ToString("MM/dd/yyyy")

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

        txtRecs.Text = "1,000"

        ImplementPrivileges()

        Dim vTmpStr As String

        'log event
        vTmpStr = modModule.CreateLog(Me.Name, "PETC Billing Manager - Open", "")

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

        Dim vTotalReceivables As Double = 0

        timerDataLoad.Enabled = False

        Try
            gSortingColumn = Nothing
            lsvItems.ListViewItemSorter = Nothing
            modModule.RemoveSortHeaderInColumns(lsvItems)
            lsvItems.Items.Clear()

            lblHeader.Text = "PETC Billing Manager"

            lblStatusPrompt.Text = "Opening database..."
            lblStatusPrompt.Visible = True
            lblStatusPrompt.Refresh()

            'open db connection
            vMyPgCon.ConnectionString = pConnectVox
            vMyPgCon.Open()

            lblStatusPrompt.Text = "Please wait... gathering transaction details..."

            vFilter = ""

            If txtDateFrom.Text <> "" And txtDateTo.Text <> "" Then
                If CDate(txtDateFrom.Text) > CDate(txtDateTo.Text) Then
                    Dim vTmpStr As String

                    vTmpStr = txtDateFrom.Text
                    txtDateFrom.Text = vTmpStr
                    txtDateTo.Text = vTmpStr
                End If

                vFilter = vFilter & IIf(Trim(vFilter) = "", " WHERE ", " AND ") & " a.date_start >= '" & modModule.CorrectSqlString(txtDateFrom.Text) & "' AND " & _
                    "a.date_end <= '" & modModule.CorrectSqlString(txtDateTo.Text) & "'"
            End If

            If chkDisplayActiveOnly.Checked = True Then
                vFilter = vFilter & IIf(Trim(vFilter) = "", " WHERE ", " AND ") & " a.is_active = 1"
            End If

            lblDate1.Text = txtDateFrom.Text
            lblDate2.Text = txtDateTo.Text

            vSortBy = " ORDER BY recno DESC "

            vQuery = "SELECT a.recno, a.series, a.petc_code, a.petc_name, a.date_start, a.date_end, a.date_due, " & _
                "a.begin_balance, a.total_debit, a.total_credit, a.amount_due, a.transactions, " & _
                "a.remarks, a.processed_by, a.date_processed, a.station_used, a.is_active, b.account_type, c.petc_address " & _
                "FROM tb_petc_billing AS a LEFT OUTER JOIN tb_petc_balance AS b ON a.petc_code = b.petc_code " & _
                "LEFT OUTER JOIN tb_petcs AS c ON a.petc_code = c.petc_code " & vFilter & vSortBy & _
                IIf(txtRecs.Text = "" Or txtRecs.Text = "0", "", " LIMIT " & Trim(Str(CDbl(txtRecs.Text))))

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

                    If IsDBNull(vMyPgRd("recno")) = True Then
                        lsvItems.Items.Add("0")
                    Else
                        lsvItems.Items.Add(vMyPgRd("recno"))
                    End If

                    lsvItems.Items(lsvItems.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)

                    If IsDBNull(vMyPgRd("petc_code")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("petc_code"))
                    End If

                    If IsDBNull(vMyPgRd("series")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("0")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("series"))
                    End If

                    If IsDBNull(vMyPgRd("petc_name")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("petc_name"))
                    End If

                    If IsDBNull(vMyPgRd("date_start")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(Format(CDate(vMyPgRd("date_start").ToString), "MM/dd/yyyy"))
                    End If

                    If IsDBNull(vMyPgRd("date_end")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(Format(CDate(vMyPgRd("date_end").ToString), "MM/dd/yyyy"))
                    End If

                    If IsDBNull(vMyPgRd("date_due")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(Format(CDate(vMyPgRd("date_due").ToString), "MM/dd/yyyy"))
                    End If

                    If IsDBNull(vMyPgRd("transactions")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("0.00")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(Format(vMyPgRd("transactions"), "###,###,###,##0.00"))
                    End If

                    If IsDBNull(vMyPgRd("begin_balance")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("0.00")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(Format(vMyPgRd("begin_balance"), "###,###,###,##0.00"))
                    End If

                    If IsDBNull(vMyPgRd("total_debit")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("0.00")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(Format(vMyPgRd("total_debit"), "###,###,###,##0.00"))
                    End If

                    If IsDBNull(vMyPgRd("total_credit")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("0.00")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(Format(vMyPgRd("total_credit"), "###,###,###,##0.00"))
                    End If

                    If IsDBNull(vMyPgRd("amount_due")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("0.00")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(Format(vMyPgRd("amount_due"), "###,###,###,##0.00"))
                        If CDbl(vMyPgRd("amount_due")) < 0 Then vTotalReceivables = vTotalReceivables + CDbl(vMyPgRd("amount_due"))

                        If CDbl(lsvItems.Items(lsvItems.Items.Count - 1).SubItems(8).Text) - CDbl(lsvItems.Items(lsvItems.Items.Count - 1).SubItems(9).Text) + _
                            CDbl(lsvItems.Items(lsvItems.Items.Count - 1).SubItems(10).Text) <> CDbl(lsvItems.Items(lsvItems.Items.Count - 1).SubItems(11).Text) Then
                            lsvItems.Items(lsvItems.Items.Count - 1).ForeColor = Color.DarkRed
                        End If
                    End If

                    If IsDBNull(vMyPgRd("remarks")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("remarks"))
                    End If

                    If IsDBNull(vMyPgRd("processed_by")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("processed_by"))
                    End If

                    If IsDBNull(vMyPgRd("date_processed")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(CDate(vMyPgRd("date_processed")).ToString("MM/dd/yyyy HH:mm:ss"))
                    End If

                    If IsDBNull(vMyPgRd("station_used")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("station_used"))
                    End If

                    If IsDBNull(vMyPgRd("is_active")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("Unknown")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(IIf(vMyPgRd("is_active") = 1, "Yes", "No"))
                    End If

                    If IsDBNull(vMyPgRd("account_type")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("Unknown")
                    Else
                        Select Case vMyPgRd("account_type")
                            Case 1
                                lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("Post-paid")

                            Case 2
                                lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("Pre-paid")

                            Case Else
                                lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("Unknown")
                        End Select
                    End If

                    If IsDBNull(vMyPgRd("petc_address")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("petc_address"))
                    End If

                    vRecs = vRecs + 1

                    If vRecs = 1 Then
                        lblStatusPrompt.Text = "Gathering details... " & Trim(Str(vRecs)) & " records read"
                        lblStatusPrompt.Refresh()
                    ElseIf (vRecs Mod 25) = 0 Then
                        lblStatusPrompt.Text = "Gathering details... " & Trim(Str(vRecs)) & " records read"
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

            lblHeader.Text = "PETC Billing Manager. Total receivables: " & vTotalReceivables.ToString("###,###,###,##0.00")

            lblStatusPrompt.Visible = False

            If lsvItems.Items.Count > 0 Then
                If lsvItems.FocusedItem Is Nothing Then
                    lsvItems.Items(0).Focused = True
                End If

                'get items
                With lsvItems.FocusedItem
                    RefreshDetails(lsvDetails, _
                                   lsvItems.Items(lsvItems.FocusedItem.Index).SubItems(1).Text, _
                                   lsvItems.Items(lsvItems.FocusedItem.Index).SubItems(4).Text, _
                                   lsvItems.Items(lsvItems.FocusedItem.Index).SubItems(5).Text)
                End With
            End If

        Catch ex As Exception
            'an error has occured

            lblDate1.Text = ""
            lblDate2.Text = ""

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

    Private Sub frmAccountingPetcBillingManager_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
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

        txtDateFrom_LostFocus(sender, e)
        txtDateTo_LostFocus(sender, e)

        If timerDataLoad.Enabled = False Then timerDataLoad.Enabled = True
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Dim vTmpStr As String

        'log event
        vTmpStr = modModule.CreateLog(Me.Name, "PETC Billing Manager - Close", "")

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

    Private Sub txtDateFrom_GotFocus(sender As Object, e As EventArgs) Handles txtDateFrom.GotFocus
        txtDateFrom.SelectAll()
    End Sub

    Private Sub txtDateFrom_LostFocus(sender As Object, e As EventArgs) Handles txtDateFrom.LostFocus
        If IsDate(txtDateFrom.Text) = True Then
            txtDateFrom.Text = CDate(txtDateFrom.Text).ToString("MM/dd/yyyy")
        Else
            txtDateFrom.Text = ""
        End If
    End Sub

    Private Sub cmdAdd_Click(sender As Object, e As EventArgs) Handles cmdAdd.Click
        Dim vDateStart As String
        Dim vDateEnd As String
        Dim vDueDate As String
        Dim vRemarks As String

        cmbPetcs.Items.Clear()

        With frmAccountingPetcBillingManagerProcess
            .PromptMessage = "Please select PETC(s) and fill-in necessary billing data:"
            .DataList = cmbPetcs

            .ShowDialog()

            vDateStart = .DateStart
            vDateEnd = .DateEnd
            vDueDate = .DueDate
            vRemarks = .Remarks
        End With

        '        Dim vTmpStr As String = ""
        '        Dim vCtr As Long
        '
        '        For vCtr = 1 To cmbPetcs.Items.Count
        ' vTmpStr = vTmpStr & " " & cmbPetcs.Items(vCtr - 1).ToString & " "
        ' Next
        '
        '        MsgBox(pResultStr & vbCrLf & vbCrLf & _
        '                   vTmpStr & vbCrLf & vbCrLf & _
        '                   "Date start: " & vDateStart & vbCrLf & _
        '                   "Date end: " & vDateEnd & vbCrLf & _
        '                   "Due date: " & vDueDate & vbCrLf & _
        '                   "Remarks: " & vRemarks)
    End Sub

    Private Sub lsvItems_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsvItems.SelectedIndexChanged
        Me.RefreshDetails(lsvDetails, _
                          lsvItems.Items(lsvItems.FocusedItem.Index).SubItems(1).Text, _
                          lsvItems.Items(lsvItems.FocusedItem.Index).SubItems(4).Text, _
                          lsvItems.Items(lsvItems.FocusedItem.Index).SubItems(5).Text)
    End Sub

    Private Sub txtDateTo_GotFocus(sender As Object, e As EventArgs) Handles txtDateTo.GotFocus
        txtDateTo.SelectAll()
    End Sub

    Private Sub txtDateTo_LostFocus(sender As Object, e As EventArgs) Handles txtDateTo.LostFocus
        If IsDate(txtDateTo.Text) = True Then
            txtDateTo.Text = CDate(txtDateTo.Text).ToString("MM/dd/yyyy")
        Else
            txtDateTo.Text = ""
        End If
    End Sub

    Private Sub txtDateTo_TextChanged(sender As Object, e As EventArgs) Handles txtDateTo.TextChanged

    End Sub

    Private Sub txtDateFrom_TextChanged(sender As Object, e As EventArgs) Handles txtDateFrom.TextChanged

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

    Private Sub cmdPrint_Click(sender As Object, e As EventArgs) Handles cmdPrint.Click
        Dim vForm As Form
        Dim vResult As DialogResult

        If lsvItems.Items.Count <= 0 Then Exit Sub

        '        If Trim(lblDate1.Text) = "" Or Trim(lblDate2.Text) = "" Then
        ' MsgBox("Please process the report first before printing.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "No or incomplete data")
        '
        '        Exit Sub
        '        End If

        If lsvItems.FocusedItem Is Nothing Then
            lsvItems.Items(lsvItems.Items.Count - 1).Focused = True
        End If

        'get items
        With lsvItems.FocusedItem
            gSeq = lsvItems.FocusedItem.Index + 1
        End With

        'printer setup
        With PrintDialog
            .Document = PrintDocument
            .AllowPrintToFile = True
            .ShowNetwork = True
            .ShowHelp = True
            vResult = PrintDialog.ShowDialog()
        End With

        If vResult <> DialogResult.OK Then Exit Sub

        gPrintListview = lsvItems
        gPrintListDetails = lsvDetails
        gDetailsSeq = 0
        gDetailsSeqPrint = 0
        gTotalCredit = 0
        gPrintPageNo = 1
        gPrintFirstPage = True
        gFooterPrinted = False
        gPrintDetails = False

        'print preview
        vForm = DirectCast(PrintPreviewDialog, Form)
        vForm.WindowState = FormWindowState.Maximized

        'set page default settings
        PrintDocument.DefaultPageSettings.Landscape = False
        PrintDocument.DefaultPageSettings.PaperSize = New System.Drawing.Printing.PaperSize("A4", 827, 1169)

        'show preview
        PrintPreviewDialog.Document = PrintDocument
        PrintPreviewDialog.ShowDialog()
    End Sub

    Private Sub PrintDocument_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument.PrintPage
        Dim vLineSpace As Integer = 0
        Dim vLeftMargin As Integer = 0
        Dim vRightMargin As Integer = 0
        Dim vAccountType As String = ""
        Dim vPetcAddress As String = ""
        Dim vDueDate As String = ""

        vLineSpace = 5
        vLeftMargin = 75
        vRightMargin = 75

        vAccountType = lsvItems.Items(lsvItems.FocusedItem.Index).SubItems(17).Text
        vPetcAddress = lsvItems.Items(lsvItems.FocusedItem.Index).SubItems(18).Text
        vDueDate = lsvItems.Items(lsvItems.FocusedItem.Index).SubItems(6).Text

        modPrinting.PrintPetcBillingReport(gSeq, vLeftMargin, vRightMargin, vLineSpace, _
                                           gPrintFirstPage, gDetailsSeq, gDetailsSeqPrint, gTotalCredit, gFooterPrinted, gPrintDetails, _
                                           vAccountType, vPetcAddress, vDueDate, gPrintListview, gPrintListDetails, e)

        If gDetailsSeq >= gPrintListDetails.Items.Count Then
            If gFooterPrinted = False Then
                e.HasMorePages = True

                gPrintPageNo = gPrintPageNo + 1
            Else
                If gPrintDetails = True Then
                    e.HasMorePages = False

                    gDetailsSeq = 0
                    gDetailsSeqPrint = 0
                    gTotalCredit = 0
                    gPrintPageNo = 1
                    gPrintFirstPage = True
                    gFooterPrinted = False
                    gPrintDetails = False
                End If
            End If
        Else
            e.HasMorePages = True

            gPrintPageNo = gPrintPageNo + 1
        End If
    End Sub

    Private Sub RefreshDetails(ByVal bListView As ListView, ByVal bPetcCode As String, ByVal bDateFrom As String, ByVal bDateEnd As String)
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
            vFilter = vFilter & IIf(Trim(vFilter) = "", " WHERE ", " AND ") & _
                "trans_date :: date >= '" & CDate(modModule.CorrectSqlString(bDateFrom)).ToString("yyyy-MM-dd") & "' AND " & _
                "trans_date :: date <= '" & CDate(modModule.CorrectSqlString(bDateEnd)).ToString("yyyy-MM-dd") & "'"

            If optShowCreditOnly.Checked = True Then
                vFilter = vFilter & IIf(Trim(vFilter) = "", " WHERE ", " AND ") & "credit <> 0 "
            End If

            If optShowDebitOnly.Checked = True Then
                vFilter = vFilter & IIf(Trim(vFilter) = "", " WHERE ", " AND ") & "debit <> 0 "
            End If

            vSortBy = "ORDER BY recno ASC"

            vQuery = "SELECT trans_date, ledger_code, ledger_description, debit, credit, balance, remarks, recno " & _
                "FROM tb_petc_balance_details " & vFilter & " " & vSortBy

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

End Class