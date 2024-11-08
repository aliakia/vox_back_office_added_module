Imports Npgsql

Public Class frmAccountingPetcBillingManagerProcess

    Private gPrevPos As New Point
    Private gSortingColumn As ColumnHeader
    Private gPromptMessage As String
    Private gDataList As ComboBox
    Private gDateStart As String
    Private gDateEnd As String
    Private gDueDate As String
    Private gRemarks As String

    Property DateStart() As String
        Get
            Return gDateStart
        End Get

        Set(ByVal value As String)
            gDateStart = value
        End Set
    End Property

    Property DateEnd() As String
        Get
            Return gDateEnd
        End Get

        Set(ByVal value As String)
            gDateEnd = value
        End Set
    End Property

    Property DueDate() As String
        Get
            Return gDueDate
        End Get

        Set(ByVal value As String)
            gDueDate = value
        End Set
    End Property

    Property Remarks() As String
        Get
            Return gRemarks
        End Get

        Set(ByVal value As String)
            gRemarks = value
        End Set
    End Property

    Property PromptMessage() As String
        Get
            Return gPromptMessage
        End Get

        Set(ByVal value As String)
            gPromptMessage = value
        End Set
    End Property

    Property DataList() As ComboBox
        Get
            Return gDataList
        End Get

        Set(ByVal value As ComboBox)
            gDataList = value
        End Set
    End Property

    Private Sub ImplementPrivileges()
        '
    End Sub

    Private Sub frmAccountingPetcBillingManagerProcess_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then cmdClose_Click(sender, e)
    End Sub

    Private Sub frmAccountingPetcBillingManagerProcess_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MinimumSize = Me.Size

        Me.KeyPreview = True

        lblHeader.Text = Me.PromptMessage

        With lsvItems.Columns
            .Clear()

            .Add("Petc code", 100, HorizontalAlignment.Left)
            .Add("Name", 200, HorizontalAlignment.Left)
            .Add("Description", 0, HorizontalAlignment.Left)
            .Add("Status", 75, HorizontalAlignment.Left)
            .Add("Lanes", 75, HorizontalAlignment.Right)
            .Add("Pay type", 75, HorizontalAlignment.Left)

            .Add("LTO service area", 100, HorizontalAlignment.Left)
            .Add("Province", 100, HorizontalAlignment.Left)
            .Add("Region", 100, HorizontalAlignment.Left)

            .Add("Category", 0, HorizontalAlignment.Left)
            .Add("Address", 200, HorizontalAlignment.Left)
            .Add("Contact", 100, HorizontalAlignment.Left)
            .Add("Business type", 100, HorizontalAlignment.Left)

            .Add("Account ID", 0, HorizontalAlignment.Left)
            .Add("Account name", 0, HorizontalAlignment.Left)
            .Add("Account manager", 0, HorizontalAlignment.Left)
            .Add("Tech. manager", 0, HorizontalAlignment.Left)
            .Add("Marketing agent", 0, HorizontalAlignment.Left)
        End With

        lsvItems.Items.Clear()

        txtPetcCode.Text = ""
        txtPetcName.Text = ""

        chkDisplayActiveOnly.Checked = True

        ImplementPrivileges()

        Dim vTmpStr As String

        'log event
        vTmpStr = modModule.CreateLog(Me.Name, "Accounting - Petc Billing Manager - Create - Open", "")

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

            If txtPetcCode.Text <> "" Then
                vFilter = vFilter & " WHERE LOWER(a.petc_code) = '" & LCase(modModule.CorrectSqlString(txtPetcCode.Text)) & "'"
            End If

            If txtPetcName.Text <> "" Then
                vFilter = vFilter & IIf(Trim(vFilter) = "", " WHERE ", " AND ") & "LOWER(a.petc_name) LIKE '%" & LCase(txtPetcName.Text) & "%'"
            End If

            If chkDisplayActiveOnly.Checked = True Then
                vFilter = vFilter & IIf(Trim(vFilter) = "", " WHERE ", " AND ") & "a.is_active = 1"
            End If

            vSortBy = "ORDER BY a.petc_name, a.petc_code ASC"

            vQuery = "SELECT a.petc_code, a.petc_lanes, a.petc_category, a.petc_name, a.petc_address, a.contact_no, a.business_type, a.lto_service_area," & _
                "a.is_active, a.description, b.account_type, " & _
                "a.province, a.region, a.account_id, c.account_name, a.account_manager, a.tech_manager, a.marketing_agent " & _
                "FROM tb_petcs AS a LEFT OUTER JOIN tb_petc_balance AS b ON a.petc_code = b.petc_code " & _
                "LEFT OUTER JOIN tb_client_accounts AS c ON a.account_id = c.account_id " & vFilter & " " & vSortBy

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
                        lsvItems.Items.Add("")
                    Else
                        lsvItems.Items.Add(vMyPgRd("petc_code"))
                    End If

                    lsvItems.Items(lsvItems.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)

                    If IsDBNull(vMyPgRd("petc_name")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("petc_name"))
                    End If

                    If IsDBNull(vMyPgRd("description")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("description"))
                    End If

                    Select Case vMyPgRd("is_active")
                        Case 0
                            lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("Inactive")

                        Case 1
                            lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("Active")

                        Case 2
                            lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("Suspended")

                        Case 3
                            lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("Expired")

                        Case 4
                            lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("Revoked")

                        Case Else
                            lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("Unknown")
                    End Select

                    If IsDBNull(vMyPgRd("petc_lanes")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("Unknown")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(Trim(Str(vMyPgRd("petc_lanes"))))
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

                    If IsDBNull(vMyPgRd("lto_service_area")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("lto_service_area"))
                    End If

                    If IsDBNull(vMyPgRd("province")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("province"))
                    End If

                    If IsDBNull(vMyPgRd("region")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("region"))
                    End If

                    If IsDBNull(vMyPgRd("petc_category")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("petc_category"))
                    End If

                    If IsDBNull(vMyPgRd("petc_address")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("petc_address"))
                    End If

                    If IsDBNull(vMyPgRd("contact_no")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("contact_no"))
                    End If

                    If IsDBNull(vMyPgRd("business_type")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("business_type"))
                    End If

                    If IsDBNull(vMyPgRd("account_id")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("account_id"))
                    End If

                    If IsDBNull(vMyPgRd("account_name")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("account_name"))
                    End If

                    If IsDBNull(vMyPgRd("account_manager")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("account_manager"))
                    End If

                    If IsDBNull(vMyPgRd("tech_manager")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("tech_manager"))
                    End If

                    If IsDBNull(vMyPgRd("marketing_agent")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("marketing_agent"))
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

    Private Sub lblHeader_MouseMove(sender As Object, e As MouseEventArgs) Handles lblHeader.MouseMove
        Dim vDelta As New Size(e.X - gPrevPos.X, e.Y - gPrevPos.Y)

        If (e.Button = MouseButtons.Left) Then
            Me.Location += vDelta
            gPrevPos = e.Location - vDelta
        Else
            gPrevPos = e.Location
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

    Private Sub cmdClose_Click(sender As Object, e As EventArgs) Handles cmdClose.Click
        Dim vTmpStr As String

        'log event
        vTmpStr = modModule.CreateLog(Me.Name, "Accounting - Petc Billing Manager - Create - Cancel", "")

        pResultStr = "cancel"

        If vTmpStr = "1" Then
            Me.Close()
        Else
            MsgBox("An error occurred while saving log. Operation aborted.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Operation cancelled")
        End If
    End Sub

    Private Sub cmdRefresh_Click(sender As Object, e As EventArgs) Handles cmdRefresh.Click
        'lsvItems.Items.Clear()

        txtPetcCode_LostFocus(sender, e)
        txtPetcName_LostFocus(sender, e)

        If timerDataLoad.Enabled = False Then timerDataLoad.Enabled = True
    End Sub

    Private Sub txtPetcCode_GotFocus(sender As Object, e As EventArgs) Handles txtPetcCode.GotFocus
        txtPetcCode.SelectAll()
    End Sub

    Private Sub txtPetcCode_LostFocus(sender As Object, e As EventArgs) Handles txtPetcCode.LostFocus
        txtPetcCode.Text = modModule.StripInvalidStringChars(Trim(txtPetcCode.Text))
    End Sub

    Private Sub txtPetcName_GotFocus(sender As Object, e As EventArgs) Handles txtPetcName.GotFocus
        txtPetcName.SelectAll()
    End Sub

    Private Sub txtPetcName_LostFocus(sender As Object, e As EventArgs) Handles txtPetcName.LostFocus
        txtPetcName.Text = Trim(modModule.StripInvalidStringChars(txtPetcName.Text))
    End Sub

    Private Sub cmdSelect_Click(sender As Object, e As EventArgs) Handles cmdSelect.Click
        Dim vCtr As Integer
        Dim vSelected As Integer = 0
        Dim vTmpStr As String

        If txtDateStart.Text = "" Or IsDate(txtDateStart.Text) = False Then
            MsgBox("Please enter starting date to process.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Incomplete data")

            txtDateStart.Select()
            txtDateStart.Focus()

            Exit Sub
        End If

        If txtDateEnd.Text = "" Or IsDate(txtDateEnd.Text) = False Then
            MsgBox("Please enter ending date to process.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Incomplete data")

            txtDateEnd.Select()
            txtDateEnd.Focus()

            Exit Sub
        End If

        If CDate(txtDateStart.Text) > CDate(txtDateEnd.Text) Then
            vTmpStr = txtDateStart.Text
            txtDateStart.Text = txtDateEnd.Text
            txtDateEnd.Text = vTmpStr
        End If

        If txtDueDate.Text = "" Or IsDate(txtDueDate.Text) = False Then
            MsgBox("Please enter due date for this billing.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Incomplete data")

            txtDueDate.Select()
            txtDueDate.Focus()

            Exit Sub
        End If

        If CDate(txtDueDate.Text) < CDate(txtDateEnd.Text) Then
            MsgBox("Due date must be greater than or equal to ending date.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Invalid data")

            txtDueDate.Select()
            txtDueDate.Focus()

            Exit Sub
        End If

        For vCtr = 1 To lsvItems.Items.Count
            If lsvItems.Items(vCtr - 1).Checked = True Then vSelected = vSelected + 1
        Next

        If vSelected > 0 Then
            Me.DataList.Items.Clear()

            For vCtr = 1 To lsvItems.Items.Count
                If lsvItems.Items(vCtr - 1).Checked = True Then
                    Me.DataList.Items.Add(lsvItems.Items(vCtr - 1).Text)
                End If
            Next

            Dim vSeries As Long = 0
            Dim vPetcCode As String
            Dim vPetcName As String
            Dim vDateStart As String
            Dim vDateEnd As String
            Dim vDueDate As String
            Dim vBeginBalance As Double = 0
            Dim vTotalDebit As Double = 0
            Dim vTotalCredit As Double = 0
            Dim vAmountDue As Double = 0
            Dim vTransaction As Double = 0
            Dim vRemarks As String

            vDateStart = txtDateStart.Text
            vDateEnd = txtDateEnd.Text
            vDueDate = txtDueDate.Text
            vRemarks = txtRemarks.Text

            'open postgres connection
            Dim vMyPgCon As New NpgsqlConnection
            Dim vMyPgCmd = New NpgsqlCommand
            Dim vMyPgRd As NpgsqlDataReader
            Dim vFound As Boolean

            Dim vQuery As String
            Dim vTmpVar As Integer
            Dim vDoProcess As Boolean

            'Dim vTotalBalance As Double = 0
            'Dim vDaysProcess As Integer
            'Dim vDaysDue As Integer

            '            'billing days to process
            '            vDaysProcess = 7
            '
            '            'due date
            '            vDaysDue = 7

            Try
                lblStatusPrompt.Text = "Opening database..."
                lblStatusPrompt.Visible = True
                lblStatusPrompt.Refresh()

                'open db connection
                vMyPgCon.ConnectionString = pConnectVox
                vMyPgCon.Open()

                vTmpStr = "You are about to process PETC billing with the following info:" & vbCrLf & vbCrLf & _
                    "Number of PETC to process: " & vSelected.ToString("###,###,###,##0") & vbCrLf & _
                    "Starting date: " & vDateStart & vbCrLf & _
                    "Ending date: " & vDateEnd & vbCrLf & _
                    "Due date: " & vDueDate & vbCrLf & _
                    "Remarks: " & vRemarks & vbCrLf & vbCrLf & _
                    "Are you sure of this?"

                'ask for user confirmation
                vTmpVar = MsgBox(vTmpStr, MsgBoxStyle.YesNo + MsgBoxStyle.Question, "User confirmation")

                vDoProcess = False
                If vTmpVar = vbYes Then
                    'process billing
                    vDoProcess = True

                    For vCtr = 1 To lsvItems.Items.Count
                        If lsvItems.Items(vCtr - 1).Checked = True Then
                            vPetcCode = lsvItems.Items(vCtr - 1).Text
                            vPetcName = lsvItems.Items(vCtr - 1).SubItems(1).Text

                            lblStatusPrompt.Text = "Please wait... processing billing of PETC " & vPetcCode & "..."

                            'initialize values
                            vSeries = 0
                            vBeginBalance = 0
                            vTotalDebit = 0
                            vTotalCredit = 0
                            vAmountDue = 0
                            vTransaction = 0

                            'get last series number of petc billing
                            vQuery = "SELECT series FROM tb_petc_billing WHERE petc_code = '" & modModule.CorrectSqlString(vPetcCode) & "' ORDER BY series DESC LIMIT 1"

                            'create query
                            vMyPgCmd = New NpgsqlCommand(vQuery, vMyPgCon)

                            'execute query
                            vMyPgRd = vMyPgCmd.ExecuteReader()

                            'get values
                            vFound = vMyPgRd.Read

                            If vFound = True Then
                                If IsDBNull(vMyPgRd("series")) = False Then
                                    vSeries = CDbl(vMyPgRd("series"))
                                End If
                            End If

                            'close and dispose to avoid memory leak
                            vMyPgRd.Close()
                            vMyPgCmd.Dispose()

                            'set series number for this petc
                            vSeries = vSeries + 1

                            'get beginning balance
                            vQuery = "SELECT balance FROM tb_petc_balance_details WHERE petc_code = '" & modModule.CorrectSqlString(vPetcCode) & "' AND " & _
                                "trans_date :: date < '" & CDate(vDateStart).ToString("yyyy-MM-dd") & "' ORDER BY recno DESC LIMIT 1"

                            'create query
                            vMyPgCmd = New NpgsqlCommand(vQuery, vMyPgCon)

                            'execute query
                            vMyPgRd = vMyPgCmd.ExecuteReader()

                            'get values
                            vFound = vMyPgRd.Read

                            If vFound = True Then
                                If IsDBNull(vMyPgRd("balance")) = False Then
                                    vBeginBalance = CDbl(vMyPgRd("balance"))
                                End If
                            End If

                            'close and dispose to avoid memory leak
                            vMyPgRd.Close()
                            vMyPgCmd.Dispose()

                            'get total debit and total credit 
                            vQuery = "SELECT SUM(debit) AS f_debit, SUM(credit) AS f_credit FROM tb_petc_balance_details " & _
                                "WHERE petc_code = '" & modModule.CorrectSqlString(vPetcCode) & "' AND " & _
                                "trans_date :: date >= '" & CDate(vDateStart).ToString("yyyy-MM-dd") & "' AND " & _
                                "trans_date :: date <= '" & CDate(vDateEnd).ToString("yyyy-MM-dd") & "'"

                            'create query
                            vMyPgCmd = New NpgsqlCommand(vQuery, vMyPgCon)

                            'execute query
                            vMyPgRd = vMyPgCmd.ExecuteReader()

                            'get values
                            vFound = vMyPgRd.Read

                            If vFound = True Then
                                If IsDBNull(vMyPgRd("f_debit")) = False Then
                                    vTotalDebit = CDbl(vMyPgRd("f_debit"))
                                End If

                                If IsDBNull(vMyPgRd("f_credit")) = False Then
                                    vTotalCredit = CDbl(vMyPgRd("f_credit"))
                                End If
                            End If

                            'close and dispose to avoid memory leak
                            vMyPgRd.Close()
                            vMyPgCmd.Dispose()

                            'get total transactions
                            vQuery = "SELECT COUNT(recno) AS f_transactions FROM tb_petc_balance_details " & _
                                "WHERE petc_code = '" & modModule.CorrectSqlString(vPetcCode) & "' AND " & _
                                "trans_date :: date >= '" & CDate(vDateStart).ToString("yyyy-MM-dd") & "' AND " & _
                                "trans_date :: date <= '" & CDate(vDateEnd).ToString("yyyy-MM-dd") & "' AND " & _
                                "ledger_code = 'I01'"

                            'create query
                            vMyPgCmd = New NpgsqlCommand(vQuery, vMyPgCon)

                            'execute query
                            vMyPgRd = vMyPgCmd.ExecuteReader()

                            'get values
                            vFound = vMyPgRd.Read

                            If vFound = True Then
                                If IsDBNull(vMyPgRd("f_transactions")) = False Then
                                    vTransaction = CDbl(vMyPgRd("f_transactions"))
                                End If
                            End If

                            'close and dispose to avoid memory leak
                            vMyPgRd.Close()
                            vMyPgCmd.Dispose()

                            'get ending balance
                            vQuery = "SELECT balance FROM tb_petc_balance_details WHERE petc_code = '" & modModule.CorrectSqlString(vPetcCode) & "' AND " & _
                                "trans_date :: date <= '" & CDate(vDateEnd).ToString("yyyy-MM-dd") & "' ORDER BY recno DESC LIMIT 1"

                            'create query
                            vMyPgCmd = New NpgsqlCommand(vQuery, vMyPgCon)

                            'execute query
                            vMyPgRd = vMyPgCmd.ExecuteReader()

                            'get values
                            vFound = vMyPgRd.Read

                            If vFound = True Then
                                If IsDBNull(vMyPgRd("balance")) = False Then
                                    vAmountDue = CDbl(vMyPgRd("balance"))
                                End If
                            End If

                            'close and dispose to avoid memory leak
                            vMyPgRd.Close()
                            vMyPgCmd.Dispose()

                            'compute amount due and check if balanced
                            Dim vTmpAmountDue As Double
                            vTmpAmountDue = vBeginBalance + vTotalCredit - vTotalDebit

                            If vTmpAmountDue <> vAmountDue Then
                                'do this if not balanced
                            End If

                            'create record in database
                            vQuery = "INSERT INTO tb_petc_billing (series, petc_code, petc_name, date_start, date_end, date_due, " & _
                                "begin_balance, total_debit, total_credit, amount_due, transactions, " & _
                                "remarks, processed_by, date_processed, station_used, is_active) " & _
                                "VALUES (" & modModule.CorrectSqlString(vSeries.ToString) & ", '" & modModule.CorrectSqlString(vPetcCode) & "', " & _
                                    "'" & modModule.CorrectSqlString(vPetcName) & "', " & _
                                    "'" & modModule.CorrectSqlString(CDate(vDateStart).ToString("yyyy-MM-dd")) & "', " & _
                                    "'" & modModule.CorrectSqlString(CDate(vDateEnd).ToString("yyyy-MM-dd")) & "', " & _
                                    "'" & modModule.CorrectSqlString(CDate(vDueDate).ToString("yyyy-MM-dd")) & "', " & _
                                    "" & modModule.CorrectSqlString(vBeginBalance.ToString) & ", " & modModule.CorrectSqlString(vTotalDebit.ToString) & ", " & _
                                    "" & modModule.CorrectSqlString(vTotalCredit.ToString) & ", " & modModule.CorrectSqlString(vAmountDue.ToString) & ", " & _
                                    "" & modModule.CorrectSqlString(vTransaction.ToString) & ", '" & modModule.CorrectSqlString(vRemarks) & "', " & _
                                    "'" & modModule.CorrectSqlString(pUserID) & "', CURRENT_timestamp AT TIME ZONE 'Hongkong', " & _
                                    "'" & modModule.CorrectSqlString(Environ("COMPUTERNAME")) & "', 1)"

                            'create query
                            vMyPgCmd = New NpgsqlCommand(vQuery, vMyPgCon)

                            'execute query
                            vMyPgCmd.ExecuteNonQuery()

                            'close and dispose to avoid memory leak
                            vMyPgCmd.Dispose()
                        End If
                    Next
                End If

                lblStatusPrompt.Text = "Closing database..."
                lblStatusPrompt.Refresh()

                'close and dispose connection
                vMyPgCon.Close()
                vMyPgCon = Nothing

                lblStatusPrompt.Visible = False

                If vDoProcess = True Then
                    vTmpVar = MsgBox("Finished processing PETC billing." & vbCrLf & vbCrLf & _
                                   "Enter necessary filters and click the < REFRESH > button to view it.", _
                                   MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Operation complete")

                    'log event
                    vTmpStr = modModule.CreateLog(Me.Name, "Accounting - Petc Billing Manager - Create - Process", "")

                    pResultStr = "select"

                    If vTmpStr = "1" Then
                        Me.Close()

                        Exit Sub
                    Else
                        MsgBox("An error occurred while saving log. Operation aborted.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Operation cancelled")
                    End If
                End If

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
                vQuery = modModule.CreateLog(Me.Name, "Error:cmdSelect", ex.Message)

                lblStatusPrompt.Visible = False
            End Try
        Else
            MsgBox("Please select by checking atleast one PETC to process.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "No data selected")
        End If
    End Sub

    Private Sub txtPetcCode_TextChanged(sender As Object, e As EventArgs) Handles txtPetcCode.TextChanged

    End Sub

    Private Sub txtDateStart_GotFocus(sender As Object, e As EventArgs) Handles txtDateStart.GotFocus
        txtDateStart.SelectAll()
    End Sub

    Private Sub txtDateStart_LostFocus(sender As Object, e As EventArgs) Handles txtDateStart.LostFocus
        If IsDate(txtDateStart.Text) = False Then
            txtDateStart.Text = ""
        Else
            txtDateStart.Text = CDate(txtDateStart.Text).ToString("MM/dd/yyyy")
        End If
    End Sub

    Private Sub txtDateStart_TextChanged(sender As Object, e As EventArgs) Handles txtDateStart.TextChanged

    End Sub

    Private Sub txtDateEnd_GotFocus(sender As Object, e As EventArgs) Handles txtDateEnd.GotFocus
        txtDateEnd.SelectAll()
    End Sub

    Private Sub txtDateEnd_LostFocus(sender As Object, e As EventArgs) Handles txtDateEnd.LostFocus
        If IsDate(txtDateEnd.Text) = False Then
            txtDateEnd.Text = ""
        Else
            txtDateEnd.Text = CDate(txtDateEnd.Text).ToString("MM/dd/yyyy")
        End If
    End Sub

    Private Sub txtDateEnd_TextChanged(sender As Object, e As EventArgs) Handles txtDateEnd.TextChanged

    End Sub

    Private Sub txtDueDate_GotFocus(sender As Object, e As EventArgs) Handles txtDueDate.GotFocus
        txtDueDate.SelectAll()
    End Sub

    Private Sub txtDueDate_LostFocus(sender As Object, e As EventArgs) Handles txtDueDate.LostFocus
        If IsDate(txtDueDate.Text) = False Then
            txtDueDate.Text = ""
        Else
            txtDueDate.Text = CDate(txtDueDate.Text).ToString("MM/dd/yyyy")
        End If
    End Sub

    Private Sub txtDueDate_TextChanged(sender As Object, e As EventArgs) Handles txtDueDate.TextChanged

    End Sub

    Private Sub txtRemarks_GotFocus(sender As Object, e As EventArgs) Handles txtRemarks.GotFocus
        txtRemarks.SelectAll()
    End Sub

    Private Sub txtRemarks_LostFocus(sender As Object, e As EventArgs) Handles txtRemarks.LostFocus
        txtRemarks.Text = modModule.StripInvalidStringChars(Trim(txtRemarks.Text))
    End Sub

    Private Sub txtRemarks_TextChanged(sender As Object, e As EventArgs) Handles txtRemarks.TextChanged

    End Sub

    Private Sub txtPetcName_TextChanged(sender As Object, e As EventArgs) Handles txtPetcName.TextChanged

    End Sub
End Class