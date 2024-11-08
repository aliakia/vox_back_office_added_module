Imports Npgsql

Public Class frmMaintenanceEWalletPetc

    Private gSortingColumn As ColumnHeader

    Private Sub ImplementPrivileges()
    End Sub

    Private Sub frmMaintenanceEWalletPetc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

        '0 .Add("Petc code", 100, HorizontalAlignment.Left)
        '1 .Add("Petc name", 100, HorizontalAlignment.Left)
        '2 .Add("Initial balance", 100, HorizontalAlignment.Right)
        '3 .Add("Current balance", 100, HorizontalAlignment.Right)
        '4 .Add("Calc. balance", 100, HorizontalAlignment.Right)
        '5 .Add("Remarks", 100, HorizontalAlignment.Right)

        With lsvPetc.Columns
            .Clear()

            .Add("Petc code", 100, HorizontalAlignment.Left)
            .Add("Petc name", 200, HorizontalAlignment.Left)
            .Add("Initial balance", 100, HorizontalAlignment.Right)
            .Add("Current balance", 100, HorizontalAlignment.Right)
            .Add("Calc. balance", 100, HorizontalAlignment.Right)
            .Add("Remarks", 100, HorizontalAlignment.Right)
        End With

        lsvPetc.Items.Clear()

        '0  .Add("No", 75, HorizontalAlignment.Right)
        '1  .Add("Petc code", 100, HorizontalAlignment.Left)
        '2  .Add("Petc name", 100, HorizontalAlignment.Left)
        '3  .Add("Date", 125, HorizontalAlignment.Left)
        '4  .Add("Description", 150, HorizontalAlignment.Left)
        '5  .Add("Debit", 100, HorizontalAlignment.Right)
        '6  .Add("Credit", 100, HorizontalAlignment.Right)
        '7  .Add("Balance", 150, HorizontalAlignment.Right)
        '8  .Add("Calc. balance", 150, HorizontalAlignment.Right)
        '9  .Add("Remarks", 150, HorizontalAlignment.Left)
        '10 .Add("Work done", 100, HorizontalAlignment.Left)
        '11 .Add("RecNo", 0, HorizontalAlignment.Right)

        With lsvItems.Columns
            .Clear()

            .Add("No", 50, HorizontalAlignment.Right)
            .Add("Petc code", 75, HorizontalAlignment.Left)
            .Add("Petc name", 100, HorizontalAlignment.Left)
            .Add("Date", 125, HorizontalAlignment.Left)
            .Add("Description", 200, HorizontalAlignment.Left)
            .Add("Debit", 75, HorizontalAlignment.Right)
            .Add("Credit", 75, HorizontalAlignment.Right)
            .Add("Balance", 100, HorizontalAlignment.Right)
            .Add("Calc. balance", 100, HorizontalAlignment.Right)
            .Add("Remarks", 100, HorizontalAlignment.Left)
            .Add("Work done", 100, HorizontalAlignment.Left)
            .Add("RecNo", 0, HorizontalAlignment.Right)
        End With

        lsvItems.Items.Clear()

        txtDateFrom.Text = ""
        txtPetcCode.Text = ""

        ImplementPrivileges()

        Dim vTmpStr As String

        'log event
        vTmpStr = modModule.CreateLog(Me.Name, "Maintenance - E-wallet - PETC - Open", "")
    End Sub

    Private Sub frmMaintenanceEWalletPetc_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
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

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Dim vTmpStr As String

        'log event
        vTmpStr = modModule.CreateLog(Me.Name, "Maintenance - E-wallet - PETC - Close", "")

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

    Private Sub txtDateFrom_TextChanged(sender As Object, e As EventArgs) Handles txtDateFrom.TextChanged

    End Sub

    Private Sub txtPetcCode_GotFocus(sender As Object, e As EventArgs) Handles txtPetcCode.GotFocus
        txtPetcCode.SelectAll()
    End Sub

    Private Sub txtPetcCode_LostFocus(sender As Object, e As EventArgs) Handles txtPetcCode.LostFocus
        txtPetcCode.Text = modModule.StripInvalidStringChars(UCase(txtPetcCode.Text))
    End Sub

    Private Sub txtPetcCode_TextChanged(sender As Object, e As EventArgs) Handles txtPetcCode.TextChanged

    End Sub

    Private Sub cmdCheckBalance_Click(sender As Object, e As EventArgs) Handles cmdCheckBalance.Click
        Dim vTmpVar As Integer

        If Trim(txtDateFrom.Text) = "" Then
            vTmpVar = MsgBox("You did not enter starting date to process." & vbCrLf & vbCrLf & _
                           "Please enter date wherein balance will be checked.", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Incomplete data")

            txtDateFrom.Focus()
            txtDateFrom.Select()

            Exit Sub
        End If

        If chkCorrect.Checked = True Then
            vTmpVar = MsgBox("You chose to automatically correct any error if found." & vbCrLf & vbCrLf & _
                           "NOTE: This will tamper the PETC balance detail in the database. Please proceed with caution." & vbCrLf & vbCrLf & _
                           "Are you sure you want to proceed?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "User confirmation")

            If vTmpVar <> MsgBoxResult.Yes Then Exit Sub
        End If

        If timerCheckPerTransBalance.Enabled = False Then timerCheckPerTransBalance.Enabled = True
    End Sub

    Private Sub timerDataLoad_Tick(sender As Object, e As EventArgs)

    End Sub

    Private Sub timerCheckPerTransBalance_Tick(sender As Object, e As EventArgs) Handles timerCheckPerTransBalance.Tick
        'open postgres connection
        Dim vMyPgCon As New NpgsqlConnection
        Dim vMyPgConCorrect As New NpgsqlConnection
        Dim vMyPgCmd = New NpgsqlCommand
        Dim vMyPgCmdCorrect = New NpgsqlCommand
        Dim vMyPgRd As NpgsqlDataReader

        Dim vFound As Boolean

        Dim vFilter As String
        Dim vQuery As String

        Dim vRecs As Long
        Dim vCtr As Integer
        Dim vPetcFound As Boolean
        Dim vTmpVar As Integer
        Dim vTmpStr As String = ""
        Dim vShowErrorOnly As Boolean = True
        Dim vCorrectData As Boolean = True
        Dim vFilterDate As String = ""
        Dim vFilterPetcCode As String = ""
        Dim vPetcBalance As Double = 0
        Dim vPetcCode As String = ""
        Dim vBalanced As Boolean
        Dim vProcessed As Double = 0
        Dim vCorrected As Double = 0
        Dim vErrors As Double = 0

        timerCheckPerTransBalance.Enabled = False

        Try
            gSortingColumn = Nothing
            lsvItems.ListViewItemSorter = Nothing
            modModule.RemoveSortHeaderInColumns(lsvItems)
            lsvItems.Items.Clear()
            lsvPetc.Items.Clear()

            lblHeader.Text = "PETC E-wallet Maintenance"

            lblStatusPrompt.Text = "Opening database..."
            lblStatusPrompt.Visible = True
            lblStatusPrompt.Refresh()

            'open db connection
            vMyPgCon.ConnectionString = pConnectVox
            vMyPgCon.Open()

            'open db connection
            vMyPgConCorrect.ConnectionString = pConnectVox
            vMyPgConCorrect.Open()

            lblStatusPrompt.Text = "Please wait... gathering petcs to process..."
            lblStatusPrompt.Refresh()

            If chkShowErrorOnly.Checked = True Then
                vShowErrorOnly = True
            Else
                vShowErrorOnly = False
            End If

            If chkCorrect.Checked = True Then
                vCorrectData = True
            Else
                vCorrectData = False
            End If

            'get records prior to process date

            vFilterDate = CDate(txtDateFrom.Text).ToString("yyyy-MM-dd")
            vFilterPetcCode = Trim(txtPetcCode.Text)

            vFilter = ""

            If Trim(vFilterDate) <> "" Then
                vFilter = vFilter & IIf(Trim(vFilter) = "", " WHERE ", " AND ") & " trans_date < '" & modModule.CorrectSqlString(vFilterDate) & "'"
            End If

            If Trim(vFilterPetcCode) <> "" Then
                vFilter = vFilter & IIf(Trim(vFilter) = "", " WHERE ", " AND ") & " petc_code = '" & _
                    modModule.CorrectSqlString(vFilterPetcCode) & "'"
            End If

            vQuery = "SELECT DISTINCT petc_code FROM tb_petc_balance_details " & vFilter

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
                'get data

                Do While vFound = True
                    If IsDBNull(vMyPgRd("petc_code")) = True Then
                    Else
                        lsvPetc.Items.Add(vMyPgRd("petc_code"))
                        lsvPetc.Items(lsvPetc.Items.Count - 1).SubItems.Add("")
                        lsvPetc.Items(lsvPetc.Items.Count - 1).SubItems.Add("0.00")
                        lsvPetc.Items(lsvPetc.Items.Count - 1).SubItems.Add("0.00")
                        lsvPetc.Items(lsvPetc.Items.Count - 1).SubItems.Add("0.00")
                        lsvPetc.Items(lsvPetc.Items.Count - 1).SubItems.Add("")
                    End If

                    vRecs = vRecs + 1

                    lblStatusPrompt.Text = "Please wait... gathering petcs to process... " & Trim(Str(vRecs)) & " records read"
                    lblStatusPrompt.Refresh()

                    'read values
                    vFound = vMyPgRd.Read
                Loop
            End If

            'close and dispose to avoid memory leak
            vMyPgRd.Close()
            vMyPgCmd.Dispose()

            'get records starting from process date

            vFilter = ""

            If Trim(vFilterDate) <> "" Then
                vFilter = vFilter & IIf(Trim(vFilter) = "", " WHERE ", " AND ") & " trans_date >= '" & modModule.CorrectSqlString(vFilterDate) & "'"
            End If

            If Trim(vFilterPetcCode) <> "" Then
                vFilter = vFilter & IIf(Trim(vFilter) = "", " WHERE ", " AND ") & " petc_code = '" & _
                    modModule.CorrectSqlString(vFilterPetcCode) & "'"
            End If

            vQuery = "SELECT DISTINCT petc_code FROM tb_petc_balance_details " & vFilter

            'create query
            vMyPgCmd = New NpgsqlCommand(vQuery, vMyPgCon)

            'execute query
            vMyPgRd = vMyPgCmd.ExecuteReader()

            'read values
            vFound = vMyPgRd.Read

            If vFound = False Then
                'no record found
            Else
                'get data

                Do While vFound = True
                    If IsDBNull(vMyPgRd("petc_code")) = True Then
                    Else
                        vPetcFound = False
                        For vCtr = 1 To lsvPetc.Items.Count
                            If lsvPetc.Items(vCtr - 1).Text = vMyPgRd("petc_code") Then
                                vPetcFound = True
                                Exit For
                            End If
                        Next

                        If vPetcFound = False Then
                            lsvPetc.Items.Add(vMyPgRd("petc_code"))
                            lsvPetc.Items(lsvPetc.Items.Count - 1).SubItems.Add("")
                            lsvPetc.Items(lsvPetc.Items.Count - 1).SubItems.Add("0.00")
                            lsvPetc.Items(lsvPetc.Items.Count - 1).SubItems.Add("0.00")
                            lsvPetc.Items(lsvPetc.Items.Count - 1).SubItems.Add("0.00")
                            lsvPetc.Items(lsvPetc.Items.Count - 1).SubItems.Add("")
                        End If
                    End If

                    vRecs = vRecs + 1

                    lblStatusPrompt.Text = "Please wait... gathering petcs to process... " & Trim(Str(vRecs)) & " records read"
                    lblStatusPrompt.Refresh()

                    'read values
                    vFound = vMyPgRd.Read
                Loop
            End If

            'close and dispose to avoid memory leak
            vMyPgRd.Close()
            vMyPgCmd.Dispose()

            'get beginning balance of all petc to process
            lblStatusPrompt.Text = "Please wait... gathering beginning balances... "

            vRecs = 0
            For vCtr = 1 To lsvPetc.Items.Count
                'get balance
                vQuery = "SELECT petc_code, balance FROM tb_petc_balance_details " & _
                    "WHERE trans_date < '" & modModule.CorrectSqlString(vFilterDate) & "' AND " & _
                    "petc_code = '" & modModule.CorrectSqlString(lsvPetc.Items(vCtr - 1).Text) & "' ORDER BY recno DESC LIMIT 1"

                'create query
                vMyPgCmd = New NpgsqlCommand(vQuery, vMyPgCon)

                'execute query
                vMyPgRd = vMyPgCmd.ExecuteReader()

                'read values
                vFound = vMyPgRd.Read

                If vFound = False Then
                    'no record found
                Else
                    'get data

                    If IsDBNull(vMyPgRd("balance")) = True Then
                    Else
                        lsvPetc.Items(vCtr - 1).SubItems(2).Text = CDbl(vMyPgRd("balance")).ToString("###,###,###,###,##0.00")
                    End If

                    vRecs = vRecs + 1

                    lblStatusPrompt.Text = "Please wait... gathering beginning balances... " & Trim(Str(vRecs)) & " records read"
                    lblStatusPrompt.Refresh()
                End If

                'close and dispose to avoid memory leak
                vMyPgRd.Close()
                vMyPgCmd.Dispose()
            Next

            'process petcs
            vCorrected = 0
            vProcessed = 0
            vErrors = 0
            vRecs = 0
            pViewBackgroundCtr = 2
            For vCtr = 1 To lsvPetc.Items.Count
                vPetcCode = lsvPetc.Items(vCtr - 1).Text
                vPetcBalance = CDbl(lsvPetc.Items(vCtr - 1).SubItems(2).Text)

                'process petc
                lblStatusPrompt.Text = "Please wait... processing petc " & vPetcCode & " data... "

                'get records
                vQuery = "SELECT a.recno, a.trans_date, a.debit, a.credit, a.petc_code, b.petc_name, a.balance, a.remarks, a.ledger_description " & _
                    "FROM tb_petc_balance_details AS a LEFT OUTER JOIN tb_petcs AS b ON a.petc_code = b.petc_code " & _
                    "WHERE a.trans_date >= '" & modModule.CorrectSqlString(vFilterDate) & "' AND " & _
                    "a.petc_code = '" & modModule.CorrectSqlString(vPetcCode) & "' ORDER BY a.recno ASC"

                'create query
                vMyPgCmd = New NpgsqlCommand(vQuery, vMyPgCon)

                'execute query
                vMyPgRd = vMyPgCmd.ExecuteReader()

                'read values
                vFound = vMyPgRd.Read

                If vFound = False Then
                    'no record found
                Else
                    'check data

                    Do While vFound = True
                        'compute for balance
                        If IsDBNull(vMyPgRd("debit")) = True Then
                        Else
                            vPetcBalance = vPetcBalance - vMyPgRd("debit")
                        End If

                        If IsDBNull(vMyPgRd("credit")) = True Then
                        Else
                            vPetcBalance = vPetcBalance + vMyPgRd("credit")
                        End If

                        'check if balanced
                        vBalanced = True
                        If IsDBNull(vMyPgRd("balance")) = True Then
                            If vPetcBalance <> 0 Then vBalanced = False
                        Else
                            If vPetcBalance <> vMyPgRd("balance") Then vBalanced = False
                        End If

                        'if not balance then report
                        If vBalanced = False Or vShowErrorOnly = False Then
                            pViewBackgroundCtr = pViewBackgroundCtr + 1
                            If pViewBackgroundCtr > pViewBackgroundColorMax Then
                                pViewBackgroundCtr = 1
                            End If

                            lsvItems.Items.Add(Trim(lsvItems.Items.Count + 1))

                            lsvItems.Items(lsvItems.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)

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

                            If IsDBNull(vMyPgRd("trans_date")) = True Then
                                lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                            Else
                                lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(CDate(vMyPgRd("trans_date")).ToString("MM/dd/yyyy HH:mm:ss"))
                            End If

                            vTmpStr = ""

                            If IsDBNull(vMyPgRd("ledger_description")) = True Then
                            Else
                                vTmpStr = vTmpStr & vMyPgRd("ledger_description")
                            End If

                            If IsDBNull(vMyPgRd("remarks")) = True Then
                            Else
                                vTmpStr = Trim(vTmpStr & " " & vMyPgRd("remarks"))
                            End If

                            lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vTmpStr)

                            If IsDBNull(vMyPgRd("debit")) = True Then
                                lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("0.00")
                            Else
                                lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(CDbl(vMyPgRd("debit")).ToString("###,###,###,###,##0.00"))
                            End If

                            If IsDBNull(vMyPgRd("credit")) = True Then
                                lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("0.00")
                            Else
                                lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(CDbl(vMyPgRd("credit")).ToString("###,###,###,###,##0.00"))
                            End If

                            If IsDBNull(vMyPgRd("balance")) = True Then
                                lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("0.00")
                            Else
                                lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(CDbl(vMyPgRd("balance")).ToString("###,###,###,###,##0.00"))
                            End If

                            lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vPetcBalance.ToString("###,###,###,###,##0.00"))

                            Select Case vBalanced
                                Case True
                                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("Balanced")

                                Case False
                                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("Not balanced")
                            End Select

                            If vBalanced = False Then
                                If vCorrectData = True Then
                                    'correct data
                                    lblStatusPrompt.Text = "Please wait... correcting petc " & vPetcCode & " data... "

                                    'get records
                                    vQuery = "UPDATE tb_petc_balance_details SET balance = " & modModule.CorrectSqlString(Trim(vPetcBalance)) & " " & _
                                        "WHERE recno = " & modModule.CorrectSqlString(vMyPgRd("recno"))

                                    'create query
                                    vMyPgCmdCorrect = New NpgsqlCommand(vQuery, vMyPgConCorrect)

                                    'execute query
                                    vMyPgCmdCorrect.ExecuteNonQuery()

                                    'close and dispose to avoid memory leak
                                    vMyPgCmdCorrect.Dispose()

                                    'increase counter
                                    vCorrected = vCorrected + 1

                                    'report as corrected
                                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("Corrected")
                                Else
                                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("Ignored")
                                End If

                                vErrors = vErrors + 1
                            Else
                                lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("None")
                            End If

                            If IsDBNull(vMyPgRd("recno")) = True Then
                                lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                            Else
                                lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("recno").ToString)
                            End If
                        End If

                        vRecs = vRecs + 1
                        vProcessed = vProcessed + 1

                        lblStatusPrompt.Text = "Please wait... processing petc " & vPetcCode & " data... " & Trim(Str(vRecs)) & " records processed"
                        lblStatusPrompt.Refresh()

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

                'close and dispose to avoid memory leak
                vMyPgRd.Close()
                vMyPgCmd.Dispose()

                'update petc calculated balance
                lsvPetc.Items(vCtr - 1).SubItems(4).Text = vPetcBalance.ToString("###,###,###,###,##0.00")

                lblStatusPrompt.Text = "Please wait... gathering petc data..."
                lblStatusPrompt.Refresh()

                'get petc balance data
                vQuery = "SELECT a.petc_code, b.petc_name, a.balance " & _
                    "FROM tb_petc_balance AS a LEFT OUTER JOIN tb_petcs AS b ON a.petc_code = b.petc_code " & _
                    "WHERE a.petc_code = '" & modModule.CorrectSqlString(vPetcCode) & "'"

                'create query
                vMyPgCmd = New NpgsqlCommand(vQuery, vMyPgCon)

                'execute query
                vMyPgRd = vMyPgCmd.ExecuteReader()

                'read values
                vFound = vMyPgRd.Read

                If vFound = False Then
                    'no record found
                Else
                    If IsDBNull(vMyPgRd("petc_name")) = True Then
                    Else
                        'update petc name
                        lsvPetc.Items(vCtr - 1).SubItems(1).Text = vMyPgRd("petc_name")
                    End If

                    'update petc current balance
                    If IsDBNull(vMyPgRd("balance")) = True Then
                    Else
                        'update petc balance
                        lsvPetc.Items(vCtr - 1).SubItems(3).Text = CDbl(vMyPgRd("balance")).ToString("###,###,###,###,##0.00")
                    End If

                    'put remarks
                    If CDbl(lsvPetc.Items(vCtr - 1).SubItems(3).Text) <> CDbl(lsvPetc.Items(vCtr - 1).SubItems(4).Text) Then
                        lsvPetc.Items(vCtr - 1).SubItems(5).Text = "Not balanced"
                    Else
                        lsvPetc.Items(vCtr - 1).SubItems(5).Text = "Balanced"
                    End If
                End If

                'close and dispose to avoid memory leak
                vMyPgRd.Close()
                vMyPgCmd.Dispose()
            Next

            lblStatusPrompt.Text = "Closing database..."
            lblStatusPrompt.Refresh()

            'close and dispose connection
            vMyPgCon.Close()
            vMyPgCon = Nothing

            vMyPgConCorrect.Close()
            vMyPgConCorrect = Nothing

            lblHeader.Text = "PETC E-wallet Maintenance - " & lsvPetc.Items.Count.ToString("###,###,###,##0") & " PETC(s) processed"

            lblStatusPrompt.Visible = False

            MsgBox("Finished processing." & vbCrLf & vbCrLf & _
                   "Parameters used:" & vbCrLf & _
                   "   Date from: " & CDate(vFilterDate).ToString("MM/dd/yyyy") & vbCrLf & _
                   "   PETC code: " & IIf(Trim(vFilterPetcCode) = "", "Process all PETCs", vFilterPetcCode) & vbCrLf & vbCrLf & _
                   "Result:" & vbCrLf & _
                   "   Number of PETC: " & lsvPetc.Items.Count.ToString("###,###,###,###,##0") & vbCrLf & _
                   "   Records processed: " & vProcessed.ToString("###,###,###,###,##0") & vbCrLf & _
                   "   Records found with error: " & vErrors.ToString("###,###,###,###,##0") & vbCrLf & _
                   "   Records corrected: " & vCorrected.ToString("###,###,###,###,##0"), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Operation complete")

        Catch ex As Exception
            'an error has occured

            'close connections that might be open
            If IsNothing(vMyPgCon) = False Then
                If vMyPgCon.State <> ConnectionState.Closed Then
                    vMyPgCon.Close()
                    vMyPgCon = Nothing
                End If
            End If

            If IsNothing(vMyPgConCorrect) = False Then
                If vMyPgConCorrect.State <> ConnectionState.Closed Then
                    vMyPgConCorrect.Close()
                    vMyPgConCorrect = Nothing
                End If
            End If

            vTmpVar = MsgBox("An error has occured." & vbCrLf & vbCr & _
                           "Error number: " & Trim(Str(Err.Number)) & vbCrLf & _
                           "Error description: " & Err.Description, MsgBoxStyle.OkOnly, "Error warning")

            'log event
            vQuery = modModule.CreateLog(Me.Name, "Error:timerCheckPerTransBalance", ex.Message)

            lblStatusPrompt.Visible = False
        End Try
    End Sub
End Class