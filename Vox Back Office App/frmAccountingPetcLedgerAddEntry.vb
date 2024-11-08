Imports Npgsql

Public Class frmAccountingPetcLedgerAddEntry

    Private gPetcCode As String
    Private gFirstLoad As Boolean

    Property PetcCode() As String
        Get
            Return gPetcCode
        End Get

        Set(ByVal value As String)
            gPetcCode = value
        End Set
    End Property

    Private Sub ImplementPrivileges()
        '        If Mid(pUserPrivilege, 34, 1) = "1" Or Mid(pUserPrivilege, 34, 1) = "2" Then
        ' cmdCountries.Enabled = True
        ' Else
        ' cmdCountries.Enabled = False
        ' End If
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        If timerRefreshPredefinedData.Enabled = True Then timerRefreshPredefinedData.Enabled = False
        If timerLoad.Enabled = True Then timerLoad.Enabled = False

        Dim vTmpStr As String

        'log event
        vTmpStr = modModule.CreateLog(Me.Name, "PETC Ledger - Add payment - Close", "")

        If vTmpStr = "1" Then
            Me.Close()
        Else
            MsgBox("An error occurred while saving log. Operation aborted.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Operation cancelled")
        End If
    End Sub

    Private Sub InitializeValues()
        txtPetcCode.Text = ""
        txtRemarks.Text = ""
        txtLedgerCode.Text = "I02"
        txtLedgerDescription.Text = "PETC payment"
        cmbBank.Text = "BPI"
        txtAccountNo.Text = "3086-3063-07"
        txtPaymentDetails.Text = ""
        cmbType.Text = "Cash"
        txtDateDeposited.Text = ""
        txtAmount.Text = "0.00"
    End Sub

    Private Sub frmAccountingPetcLedgerAddEntry_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        gFirstLoad = True

        Me.Text = "ADD NEW PETC PAYMENT INFORMATION"

        lblStatusPrompt.Visible = True
        lblStatusPrompt.Text = "Ready"

        'initialize controls

        txtPetcCode.MaxLength = 16
        txtRemarks.MaxLength = 0
        txtLedgerCode.MaxLength = 16
        txtLedgerDescription.MaxLength = 32

        cmbBank.MaxLength = 0
        txtAccountNo.MaxLength = 0
        txtPaymentDetails.MaxLength = 0
        txtDateDeposited.MaxLength = 0
        txtAmount.MaxLength = 15

        txtPetcCode.ReadOnly = False
        txtRemarks.ReadOnly = False

        txtLedgerCode.ReadOnly = True
        txtLedgerDescription.ReadOnly = True

        cmbBank.Enabled = True
        txtAccountNo.ReadOnly = False
        txtPaymentDetails.ReadOnly = False
        txtDateDeposited.ReadOnly = False
        txtAmount.ReadOnly = False

        txtAmount.TextAlign = HorizontalAlignment.Right

        cmdBrowsePetc.Visible = True
        cmdProcess.Text = "CREATE"

        With cmbBank
            .Items.Clear()

            .Items.Add("BDO")
            .Items.Add("BPI")
            '.Items.Add("BPI Family")
            .Items.Add("Chinabank")
            .Items.Add("Landbank")
            .Items.Add("Metrobank")
            '.Items.Add("Unionbank")
            '.Items.Add("PS Bank")
            '.Items.Add("UCPB")
            '.Items.Add("RCBC")
            '.Items.Add("East West")
            '.Items.Add("Allied Bank")
            .Items.Add("Smart money")
            .Items.Add("Globe G-cash")
            .Items.Add("Cebuana")
            .Items.Add("MLhuiller")
            .Items.Add("Western union")
            .Items.Add("Palawan Express")
            .Items.Add("Others")

            .Text = ""
        End With

        With cmbType
            .Items.Clear()

            .Items.Add("Cash")
            .Items.Add("Check")
        End With

        InitializeValues()

        If Me.PetcCode <> "" Then txtPetcCode.Text = Me.PetcCode

        ImplementPrivileges()

        timerRefreshPredefinedData.Enabled = True

        If Trim(txtPetcCode.Text) <> "" Then timerLoad.Enabled = True
    End Sub

    Private Sub cmdRefreshPredefinedData_Click(sender As Object, e As EventArgs) Handles cmdRefreshPredefinedData.Click
        If timerRefreshPredefinedData.Enabled = False Then
            timerRefreshPredefinedData.Enabled = True
        End If
    End Sub

    Private Sub timerRefreshPredefinedData_Tick(sender As Object, e As EventArgs) Handles timerRefreshPredefinedData.Tick
        lblStatusPrompt.Text = "Ready"
        lblStatusPrompt.Visible = True

        If gFirstLoad = True Then
            EnableButtons()
        End If

        gFirstLoad = False
    End Sub

    Private Sub DisableButtons()
        cmdBrowsePetc.Enabled = False
        cmdRefreshPredefinedData.Enabled = False
        cmdProcess.Enabled = False
        cmdCancel.Enabled = False
    End Sub

    Private Sub EnableButtons()
        cmdBrowsePetc.Enabled = True
        cmdRefreshPredefinedData.Enabled = True
        cmdProcess.Enabled = True
        cmdCancel.Enabled = True

        ImplementPrivileges()
    End Sub

    Private Sub cmdProcess_Click(sender As Object, e As EventArgs) Handles cmdProcess.Click
        'open postgres connection
        Dim vMyPgCon As New NpgsqlConnection
        Dim vMyPgCmd = New NpgsqlCommand
        Dim vMyPgRd As NpgsqlDataReader
        Dim vFound As Boolean

        Dim vQuery As String = ""
        Dim vTmpStr As String = ""
        Dim vTmpBalance As Double = 0

        Dim vTmpVar As Integer

        Try

            If Trim(txtPetcCode.Text) = "" Then
                vTmpVar = MsgBox("PETC Code is required." & vbCrLf & vbCrLf & _
                               "Please enter PETC Code.", vbOKOnly + vbEmpty, "Incomplete data")

                txtPetcCode.Select()
                txtPetcCode.Focus()

                Exit Sub
            End If

            If Trim(cmbBank.Text) = "" Then
                vTmpVar = MsgBox("Bank information is required." & vbCrLf & vbCrLf & _
                               "Please enter Bank information.", vbOKOnly + vbEmpty, "Incomplete data")

                cmbBank.Select()
                cmbBank.Focus()

                Exit Sub
            End If

            If Trim(txtAccountNo.Text) = "" Then
                vTmpVar = MsgBox("Bank account number is required." & vbCrLf & vbCrLf & _
                               "Please enter Bank account number used.", vbOKOnly + vbEmpty, "Incomplete data")

                txtAccountNo.Select()
                txtAccountNo.Focus()

                Exit Sub
            End If

            If Trim(cmbType.Text) = "" Then
                vTmpVar = MsgBox("Payment type is required." & vbCrLf & vbCrLf & _
                               "Please select type of payment.", vbOKOnly + vbEmpty, "Incomplete data")

                cmbType.Select()
                cmbType.Focus()

                Exit Sub
            End If

            If Trim(txtDateDeposited.Text) = "" Then
                vTmpVar = MsgBox("Date and time of deposit is required." & vbCrLf & vbCrLf & _
                               "Please enter date and time when the deposit was made.", vbOKOnly + vbEmpty, "Incomplete data")

                txtDateDeposited.Select()
                txtDateDeposited.Focus()

                Exit Sub
            End If

            If CDbl(txtAmount.Text) = 0 Then
                vTmpVar = MsgBox("Amount of payment is required." & vbCrLf & vbCrLf & _
                               "Please enter amount of payment made.", vbOKOnly + vbEmpty, "Incomplete data")

                txtAmount.Select()
                txtAmount.Focus()

                Exit Sub
            End If

            vTmpVar = MsgBox("You are about to record a new PETC payment with the following info.:" & vbCrLf & vbCrLf & _
                             "PETC Code: " & txtPetcCode.Text & vbCrLf & _
                             IIf(txtRemarks.Text = "", "", "Remarks: " & txtRemarks.Text & vbCrLf) & _
                             IIf(txtLedgerCode.Text = "", "", "Ledger code: " & txtLedgerCode.Text & vbCrLf) & _
                             IIf(txtLedgerDescription.Text = "", "", "Ledger description: " & txtLedgerDescription.Text & vbCrLf) & _
                             IIf(cmbBank.Text = "", "", "Bank information: " & cmbBank.Text & vbCrLf) & _
                             IIf(txtAccountNo.Text = "", "", "Account number: " & txtAccountNo.Text & vbCrLf) & _
                             IIf(txtPaymentDetails.Text = "", "", "Payment details: " & txtPaymentDetails.Text & vbCrLf) & _
                             IIf(txtDateDeposited.Text = "", "", "Date/time deposited: " & txtDateDeposited.Text & vbCrLf) & _
                             IIf(txtAmount.Text = "", "", "Amount paid: " & txtAmount.Text & vbCrLf) & vbCrLf & _
                             "Please make sure the above information are true and correct." & vbCrLf & vbCrLf & _
                             "Are you sure you want to create the new PETC payment info.?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "User confirmation")

            If vTmpVar = MsgBoxResult.No Then Exit Sub

            lblStatusPrompt.Text = "Opening database..."
            lblStatusPrompt.Refresh()

            'open db connection
            vMyPgCon.ConnectionString = pConnectVox
            vMyPgCon.Open()

            lblStatusPrompt.Text = "Validating in PETC in database..."
            lblStatusPrompt.Refresh()

            'check if PETC exist
            vQuery = "SELECT petc_code FROM tb_petcs WHERE petc_code = '" & modModule.CorrectSqlString(txtPetcCode.Text) & "'"

            'create query
            vMyPgCmd = New NpgsqlCommand(vQuery, vMyPgCon)

            'execute query
            vMyPgRd = vMyPgCmd.ExecuteReader()

            'read values
            vFound = vMyPgRd.Read

            If vFound = False Then
                'close and dispose to avoid memory leak
                vMyPgRd.Close()
                vMyPgCmd.Dispose()

                lblStatusPrompt.Text = "Closing database..."
                lblStatusPrompt.Refresh()

                'close and dispose connection
                vMyPgCon.Close()
                vMyPgCon = Nothing

                lblStatusPrompt.Text = "Ready"
                lblStatusPrompt.Visible = True

                'record found
                vTmpVar = MsgBox("PETC with code " & modModule.CorrectSqlString(txtPetcCode.Text) & " does not exist in record." & vbCrLf & vbCrLf & _
                                "Please double check records.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Validation failed")
                Exit Sub
            End If

            'close and dispose to avoid memory leak
            vMyPgRd.Close()
            vMyPgCmd.Dispose()

            'check current balance
            vQuery = "SELECT balance FROM tb_petc_balance WHERE petc_code = '" & modModule.CorrectSqlString(txtPetcCode.Text) & "' FOR UPDATE"

            'create query
            vMyPgCmd = New NpgsqlCommand(vQuery, vMyPgCon)

            'execute query
            vMyPgRd = vMyPgCmd.ExecuteReader()

            'read values
            vFound = vMyPgRd.Read

            If vFound = False Then
                'close and dispose to avoid memory leak
                vMyPgRd.Close()
                vMyPgCmd.Dispose()

                lblStatusPrompt.Text = "Closing database..."
                lblStatusPrompt.Refresh()

                'close and dispose connection
                vMyPgCon.Close()
                vMyPgCon = Nothing

                lblStatusPrompt.Text = "Ready"
                lblStatusPrompt.Visible = True

                'record found
                vTmpVar = MsgBox("PETC with code " & modModule.CorrectSqlString(txtPetcCode.Text) & " does not exist in accounting record." & vbCrLf & vbCrLf & _
                                "Please double check records.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Validation failed")
                Exit Sub
            Else
                If IsDBNull(vMyPgRd("balance")) = True Then
                    vTmpBalance = 0
                Else
                    vTmpBalance = vMyPgRd("balance")
                End If
            End If

            'close and dispose to avoid memory leak
            vMyPgRd.Close()
            vMyPgCmd.Dispose()

            'provisions here to check if bank information is correct

            lblStatusPrompt.Text = "Initializing transaction..."
            lblStatusPrompt.Refresh()

            vQuery = "BEGIN TRANSACTION"

            'create query
            vMyPgCmd = New NpgsqlCommand(vQuery, vMyPgCon)

            'execute query
            vMyPgCmd.ExecuteNonQuery()

            'close and dispose to avoid memory leak
            vMyPgCmd.Dispose()

            lblStatusPrompt.Text = "Creating record in database..."
            lblStatusPrompt.Refresh()

            vTmpStr = "Bank: " & modModule.CorrectSqlString(cmbBank.Text) & ", " & _
                "Account no.: " & modModule.CorrectSqlString(txtAccountNo.Text) & ", " & _
                "Type: " & modModule.CorrectSqlString(cmbType.Text) & ", " & _
                "Payment details: " & modModule.CorrectSqlString(txtPaymentDetails.Text) & ", " & _
                "Period: " & modModule.CorrectSqlString(txtDateDeposited.Text) & ", " & _
                "Amount: " & modModule.CorrectSqlString(Trim(Str(CDbl(txtAmount.Text)))) & ", " & _
                "Additional remarks: " & modModule.CorrectSqlString(txtRemarks.Text)

            vTmpBalance = vTmpBalance + CDbl(txtAmount.Text)

            'insert in tb_petc_blance_details table
            vQuery = "INSERT INTO tb_petc_balance_details (trans_date, petc_code, ledger_code, ledger_description, debit, credit, balance, remarks) " & _
                "VALUES (CURRENT_timestamp AT TIME ZONE 'Hongkong', '" & modModule.CorrectSqlString(txtPetcCode.Text) & "', " & _
                    "'" & modModule.CorrectSqlString(txtLedgerCode.Text) & "', '" & modModule.CorrectSqlString(txtLedgerDescription.Text) & "', " & _
                    "0, " & Trim(Str(CDbl(txtAmount.Text))) & ", " & Trim(Str(vTmpBalance)) & ", " & _
                    "'" & modModule.CorrectSqlString(vTmpStr) & "')"

            'create query
            vMyPgCmd = New NpgsqlCommand(vQuery, vMyPgCon)

            'execute query
            vMyPgCmd.ExecuteNonQuery()

            'close and dispose to avoid memory leak
            vMyPgCmd.Dispose()

            'update tb_petc_blance table
            vQuery = "UPDATE tb_petc_balance SET balance = " & Trim(Str(vTmpBalance)) & " WHERE petc_code = '" & modModule.CorrectSqlString(txtPetcCode.Text) & "'"

            'create query
            vMyPgCmd = New NpgsqlCommand(vQuery, vMyPgCon)

            'execute query
            vMyPgCmd.ExecuteNonQuery()

            'close and dispose to avoid memory leak
            vMyPgCmd.Dispose()

            'create log
            vQuery = modModule.CreateLogCn(vMyPgCon, Me.Name, "new petc payment - petc " & txtPetcCode.Text, txtAmount.Text)

            If vQuery <> "1" Then
                lblStatusPrompt.Text = "An error has occurred"

                MsgBox("An error occurred while saving log. Operation aborted.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Operation cancelled")

                'close and dispose to avoid memory leak
                vMyPgCon.Close()
                vMyPgCon = Nothing

                Exit Sub
            End If

            lblStatusPrompt.Text = "Finalizing transaction..."
            lblStatusPrompt.Refresh()

            vQuery = "COMMIT TRANSACTION"

            'create query
            vMyPgCmd = New NpgsqlCommand(vQuery, vMyPgCon)

            'execute query
            vMyPgCmd.ExecuteNonQuery()

            'close and dispose to avoid memory leak
            vMyPgCmd.Dispose()

            'Create log

            lblStatusPrompt.Text = "Closing database..."
            lblStatusPrompt.Refresh()

            'close and dispose connection
            vMyPgCon.Close()
            vMyPgCon = Nothing

            lblStatusPrompt.Text = "Ready"
            lblStatusPrompt.Visible = True

            MsgBox("Successfull in creating new PETC payment (PETC: " & txtPetcCode.Text & ")", _
                   MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Operation complete")

            Me.Close()

            Exit Sub

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
            vQuery = modModule.CreateLog(Me.Name, "Error:cmdProcess", ex.Message)

            lblStatusPrompt.Text = "An error has occurred"
            lblStatusPrompt.Visible = True
            lblStatusPrompt.Refresh()

            EnableButtons()
        End Try
    End Sub

    Private Sub txtPetcCode_GotFocus(sender As Object, e As EventArgs) Handles txtPetcCode.GotFocus
        txtPetcCode.SelectAll()
    End Sub

    Private Sub txtPetcCode_Invalidated(sender As Object, e As InvalidateEventArgs) Handles txtPetcCode.Invalidated

    End Sub

    Private Sub txtPetcCode_LostFocus(sender As Object, e As EventArgs) Handles txtPetcCode.LostFocus
        txtPetcCode.Text = UCase(Trim(modModule.StripInvalidStringChars(txtPetcCode.Text)))
    End Sub

    Private Sub txtPetcCode_TextChanged(sender As Object, e As EventArgs) Handles txtPetcCode.TextChanged

    End Sub

    Private Sub txtRemarks_GotFocus(sender As Object, e As EventArgs) Handles txtRemarks.GotFocus
        txtRemarks.SelectAll()
    End Sub

    Private Sub txtRemarks_LostFocus(sender As Object, e As EventArgs) Handles txtRemarks.LostFocus
        txtRemarks.Text = UCase(Trim(modModule.StripInvalidStringChars(txtRemarks.Text)))
    End Sub

    Private Sub txtRemarks_TextChanged(sender As Object, e As EventArgs) Handles txtRemarks.TextChanged

    End Sub

    Private Sub txtLedgerDescription_GotFocus(sender As Object, e As EventArgs) Handles txtLedgerDescription.GotFocus
        txtLedgerDescription.SelectAll()
    End Sub

    Private Sub txtLedgerDescription_LostFocus(sender As Object, e As EventArgs) Handles txtLedgerDescription.LostFocus
        'txtLedgerDescription.Text = LCase(Trim(modModule.StripInvalidStringChars(txtLedgerDescription.Text)))
    End Sub

    Private Sub txtLedgerDescription_TextChanged(sender As Object, e As EventArgs) Handles txtLedgerDescription.TextChanged

    End Sub


    Private Sub txtLedgerCode_GotFocus(sender As Object, e As EventArgs) Handles txtLedgerCode.GotFocus
        txtLedgerCode.SelectAll()
    End Sub

    Private Sub txtLedgerCode_LostFocus(sender As Object, e As EventArgs) Handles txtLedgerCode.LostFocus
        'txtLedgerCode.Text = LCase(Trim(modModule.StripInvalidStringChars(txtLedgerCode.Text)))
    End Sub

    Private Sub txtLedgerCode_TextChanged(sender As Object, e As EventArgs) Handles txtLedgerCode.TextChanged

    End Sub

    Private Sub cmdBrowsePetc_Click(sender As Object, e As EventArgs) Handles cmdBrowsePetc.Click
        MsgBox("This option is currently unavailable", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Option unavailable")
    End Sub

    Private Sub txtDateDeposited_GotFocus(sender As Object, e As EventArgs) Handles txtDateDeposited.GotFocus
        txtDateDeposited.SelectAll()
    End Sub

    Private Sub txtDateDeposited_LostFocus(sender As Object, e As EventArgs) Handles txtDateDeposited.LostFocus
        If IsDate(txtDateDeposited.Text) = True Then
            txtDateDeposited.Text = Format(CDate(txtDateDeposited.Text), "yyyy-MM-dd HH:mm:ss")
        Else
            txtDateDeposited.Text = ""
        End If
    End Sub

    Private Sub cmbBank_GotFocus(sender As Object, e As EventArgs) Handles cmbBank.GotFocus
        cmbBank.SelectAll()
    End Sub

    Private Sub cmbBank_LostFocus(sender As Object, e As EventArgs) Handles cmbBank.LostFocus
        If modModule.ValidComboBoxData(cmbBank.Text, cmbBank) = False Then cmbBank.Text = ""
    End Sub

    Private Sub txtAccountNo_GotFocus(sender As Object, e As EventArgs) Handles txtAccountNo.GotFocus
        txtAccountNo.SelectAll()
    End Sub

    Private Sub txtAccountNo_LostFocus(sender As Object, e As EventArgs) Handles txtAccountNo.LostFocus
        txtAccountNo.Text = modModule.StripInvalidStringChars(UCase(Trim(txtAccountNo.Text)))
    End Sub

    Private Sub cmbType_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbType.KeyPress
        e.Handled = True
    End Sub

    Private Sub cmbType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbType.SelectedIndexChanged

    End Sub

    Private Sub txtPaymentDetails_GotFocus(sender As Object, e As EventArgs) Handles txtPaymentDetails.GotFocus
        txtPaymentDetails.SelectAll()
    End Sub

    Private Sub txtPaymentDetails_LostFocus(sender As Object, e As EventArgs) Handles txtPaymentDetails.LostFocus
        txtPaymentDetails.Text = UCase(Trim(modModule.StripInvalidStringChars(txtPaymentDetails.Text)))
    End Sub

    Private Sub txtPaymentDetails_TextChanged(sender As Object, e As EventArgs) Handles txtPaymentDetails.TextChanged

    End Sub

    Private Sub txtAmount_GotFocus(sender As Object, e As EventArgs) Handles txtAmount.GotFocus
        txtAmount.SelectAll()
    End Sub

    Private Sub txtAmount_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAmount.KeyPress
        Select Case e.KeyChar
            Case "0" To "9"
            Case "."
            Case "-"
            Case ","
            Case Else
                e.Handled = True
        End Select
    End Sub

    Private Sub txtAmount_LostFocus(sender As Object, e As EventArgs) Handles txtAmount.LostFocus
        If IsNumeric(txtAmount.Text) = True Then
            txtAmount.Text = Format(CDbl(txtAmount.Text), "###,###,##0.00")
        Else
            txtAmount.Text = "0"
        End If
    End Sub

    Private Sub txtAmount_TextChanged_1(sender As Object, e As EventArgs) Handles txtAmount.TextChanged

    End Sub

    Private Sub cmbBank_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbBank.SelectedIndexChanged

    End Sub

    Private Sub timerLoad_Tick(sender As Object, e As EventArgs) Handles timerLoad.Tick
        timerLoad.Enabled = False

        'open postgres connection
        Dim vMyPgCon As New NpgsqlConnection
        Dim vMyPgCmd = New NpgsqlCommand
        Dim vMyPgRd As NpgsqlDataReader
        Dim vFound As Boolean

        Dim vQuery As String = ""
        Dim vCtr As Long = 0

        Dim vTmpVar As Integer

        Try
            If Trim(txtPetcCode.Text) = "" Then Exit Sub

            lblStatusPrompt.Text = "Opening database..."
            lblStatusPrompt.Refresh()

            'open db connection
            vMyPgCon.ConnectionString = pConnectVox
            vMyPgCon.Open()

            lblStatusPrompt.Text = "Gathering PETC last payment in database..."
            lblStatusPrompt.Refresh()

            'check if PETC last payment exist
            vQuery = "SELECT recno, remarks FROM tb_petc_balance_details WHERE petc_code = '" & modModule.CorrectSqlString(txtPetcCode.Text) & "' AND " & _
                "debit = 0 AND credit <> 0 ORDER BY recno DESC LIMIT 1"

            'create query
            vMyPgCmd = New NpgsqlCommand(vQuery, vMyPgCon)

            'execute query
            vMyPgRd = vMyPgCmd.ExecuteReader()

            'read values
            vFound = vMyPgRd.Read

            If vFound = False Then
                'close and dispose to avoid memory leak
                vMyPgRd.Close()
                vMyPgCmd.Dispose()

                lblStatusPrompt.Text = "Closing database..."
                lblStatusPrompt.Refresh()

                'close and dispose connection
                vMyPgCon.Close()
                vMyPgCon = Nothing

                lblStatusPrompt.Text = "Ready"
                lblStatusPrompt.Visible = True
                Exit Sub
            End If

            Dim vPos As Long = 0
            Dim vTmpStr As String = ""
            Dim vTmpData As String = ""
            Dim vTmpRemarks As String = ""
            Dim vTmpBankNo As String = ""
            Dim vTmpAccountNo As String = ""
            Dim vTmpPaymentDetails As String = ""
            Dim vTmpType As String = ""

            If IsDBNull(vMyPgRd("remarks")) = True Then
                vTmpRemarks = ""
            Else
                vTmpRemarks = Trim(vMyPgRd("remarks"))
            End If

            'close and dispose to avoid memory leak
            vMyPgRd.Close()
            vMyPgCmd.Dispose()

            lblStatusPrompt.Text = "Closing database..."
            lblStatusPrompt.Refresh()

            'close and dispose connection
            vMyPgCon.Close()
            vMyPgCon = Nothing

            For vCtr = 1 To 4
                Select Case vCtr
                    Case 1
                        'get bank
                        vTmpData = "BANK:"

                    Case 2
                        'get account no.
                        vTmpData = "ACCOUNT NO.:"

                    Case 3
                        'get payment type
                        vTmpData = "TYPE:"

                    Case 4
                        'get payment details
                        vTmpData = "PAYMENT DETAILS:"
                End Select

                If vTmpData <> "" Then
                    'extract data
                    vPos = InStr(UCase(vTmpRemarks), vTmpData)
                    If vPos > 0 Then
                        'data info found:

                        vTmpStr = Mid(vTmpRemarks, vPos + vTmpData.Length + 1)

                        'set next field as delimiter
                        Select Case vCtr
                            Case 1
                                vTmpData = "ACCOUNT NO.:"

                            Case 2
                                vTmpData = "TYPE:"

                            Case 3
                                vTmpData = "PAYMENT DETAILS:"

                            Case 4
                                vTmpData = "PERIOD:"
                        End Select

                        vPos = InStr(UCase(vTmpStr), vTmpData)

                        If vPos > 0 Then
                            'end portion found

                            vTmpStr = Mid(vTmpStr, 1, vPos - 3)
                        End If

                        'set value of object
                        If vTmpStr <> "" Then
                            Select Case vCtr
                                Case 1
                                    cmbBank.Text = vTmpStr

                                Case 2
                                    txtAccountNo.Text = vTmpStr

                                Case 3
                                    cmbType.Text = vTmpStr

                                Case 4
                                    txtPaymentDetails.Text = vTmpStr
                            End Select
                        End If
                    End If
                End If
            Next

            lblStatusPrompt.Text = "Ready"
            lblStatusPrompt.Visible = True

            Exit Sub

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
            vQuery = modModule.CreateLog(Me.Name, "Error:timerLoad", ex.Message)

            lblStatusPrompt.Text = "An error has occurred"
            lblStatusPrompt.Visible = True
            lblStatusPrompt.Refresh()

            EnableButtons()
        End Try
    End Sub
End Class