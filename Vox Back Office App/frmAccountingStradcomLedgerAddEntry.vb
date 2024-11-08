Imports Npgsql

Public Class frmAccountingStradcomLedgerAddEntry

    Private gSuppID As String
    Private gFirstLoad As Boolean

    Property SuppID() As String
        Get
            Return gSuppID
        End Get

        Set(ByVal value As String)
            gSuppID = value
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
        vTmpStr = modModule.CreateLog(Me.Name, "Stradcom Ledger - Add payment - Close", "")

        If vTmpStr = "1" Then
            Me.Close()
        Else
            MsgBox("An error occurred while saving log. Operation aborted.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Operation cancelled")
        End If
    End Sub

    Private Sub InitializeValues()
        txtSuppID.Text = "stradcom"
        txtRemarks.Text = ""
        txtLedgerCode.Text = "I02"
        txtLedgerDescription.Text = "Vox payment"
        cmbBank.Text = "Metrobank"
        txtAccountNo.Text = "186-3-18616619-2"
        txtPaymentDetails.Text = ""
        cmbType.Text = "Cash"
        txtDateDeposited.Text = ""
        txtAmount.Text = "0.00"
    End Sub

    Private Sub frmAccountingStradcomLedgerAddEntry_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        gFirstLoad = True

        Me.Text = "ADD NEW STRADCOM PAYMENT INFORMATION"

        lblStatusPrompt.Visible = True
        lblStatusPrompt.Text = "Ready"

        'initialize controls

        txtSuppID.MaxLength = 16
        txtRemarks.MaxLength = 0
        txtLedgerCode.MaxLength = 16
        txtLedgerDescription.MaxLength = 32

        cmbBank.MaxLength = 0
        txtAccountNo.MaxLength = 0
        txtPaymentDetails.MaxLength = 0
        txtDateDeposited.MaxLength = 0
        txtAmount.MaxLength = 15

        txtSuppID.ReadOnly = True
        txtRemarks.ReadOnly = False

        txtLedgerCode.ReadOnly = True
        txtLedgerDescription.ReadOnly = True

        cmbBank.Enabled = True
        txtAccountNo.ReadOnly = False
        txtPaymentDetails.ReadOnly = False
        txtDateDeposited.ReadOnly = False
        txtAmount.ReadOnly = False

        txtAmount.TextAlign = HorizontalAlignment.Right

        cmdProcess.Text = "CREATE"

        With cmbBank
            .Items.Clear()

            .Items.Add("BPI")
            .Items.Add("BPI Family")
            .Items.Add("BDO")
            .Items.Add("Metrobank")
            .Items.Add("Chinabank")
            .Items.Add("Unionbank")
            .Items.Add("PS Bank")
            .Items.Add("UCPB")
            .Items.Add("RCBC")
            .Items.Add("East West")
            .Items.Add("Allied Bank")

            .Text = ""
        End With

        With cmbType
            .Items.Clear()

            .Items.Add("Cash")
            .Items.Add("Check")
        End With

        InitializeValues()

        ImplementPrivileges()

        timerRefreshPredefinedData.Enabled = True
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
        cmdRefreshPredefinedData.Enabled = False
        cmdProcess.Enabled = False
        cmdCancel.Enabled = False
    End Sub

    Private Sub EnableButtons()
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

            If Trim(txtSuppID.Text) = "" Then
                vTmpVar = MsgBox("Supplier ID is required." & vbCrLf & vbCrLf & _
                               "Please enter Supplier ID.", vbOKOnly + vbEmpty, "Incomplete data")

                txtSuppID.Select()
                txtSuppID.Focus()

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

            vTmpVar = MsgBox("You are about to record a new Stradcom payment with the following info.:" & vbCrLf & vbCrLf & _
                             "Supplier ID: " & txtSuppID.Text & vbCrLf & _
                             IIf(txtRemarks.Text = "", "", "Remarks: " & txtRemarks.Text & vbCrLf) & _
                             IIf(txtLedgerCode.Text = "", "", "Ledger code: " & txtLedgerCode.Text & vbCrLf) & _
                             IIf(txtLedgerDescription.Text = "", "", "Ledger description: " & txtLedgerDescription.Text & vbCrLf) & _
                             IIf(cmbBank.Text = "", "", "Bank information: " & cmbBank.Text & vbCrLf) & _
                             IIf(txtAccountNo.Text = "", "", "Account number: " & txtAccountNo.Text & vbCrLf) & _
                             IIf(txtPaymentDetails.Text = "", "", "Payment details: " & txtPaymentDetails.Text & vbCrLf) & _
                             IIf(txtDateDeposited.Text = "", "", "Date/time deposited: " & txtDateDeposited.Text & vbCrLf) & _
                             IIf(txtAmount.Text = "", "", "Amount paid: " & txtAmount.Text & vbCrLf) & vbCrLf & _
                             "Please make sure the above information are true and correct." & vbCrLf & vbCrLf & _
                             "Are you sure you want to create the new Stradcom payment info.?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "User confirmation")

            If vTmpVar = MsgBoxResult.No Then Exit Sub

            lblStatusPrompt.Text = "Opening database..."
            lblStatusPrompt.Refresh()

            'open db connection
            vMyPgCon.ConnectionString = pConnectVox
            vMyPgCon.Open()

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

            'check current balance
            vQuery = "SELECT balance FROM tb_stradcom_balance WHERE supp_id = '" & modModule.CorrectSqlString(txtSuppID.Text) & "' FOR UPDATE"

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
                vTmpVar = MsgBox("Supplier with ID " & modModule.CorrectSqlString(txtSuppID.Text) & " does not exist in accounting record." & vbCrLf & vbCrLf & _
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

            'insert in tb_stradcom_blance_details table
            vQuery = "INSERT INTO tb_stradcom_balance_details (trans_date, petc_code, ledger_code, ledger_description, debit, credit, balance, remarks, supp_id) " & _
                "VALUES (CURRENT_timestamp AT TIME ZONE 'Hongkong', '', " & _
                    "'" & modModule.CorrectSqlString(txtLedgerCode.Text) & "', '" & modModule.CorrectSqlString(txtLedgerDescription.Text) & "', 0, " & _
                    Trim(Str(CDbl(txtAmount.Text))) & ", " & Trim(Str(vTmpBalance)) & ", " & _
                    "'" & modModule.CorrectSqlString(vTmpStr) & "', '" & modModule.CorrectSqlString(txtSuppID.Text) & "')"

            'create query
            vMyPgCmd = New NpgsqlCommand(vQuery, vMyPgCon)

            'execute query
            vMyPgCmd.ExecuteNonQuery()

            'close and dispose to avoid memory leak
            vMyPgCmd.Dispose()

            'update tb_stadcom_blance table
            vQuery = "UPDATE tb_stradcom_balance SET balance = " & Trim(Str(vTmpBalance)) & " WHERE supp_id = '" & modModule.CorrectSqlString(txtSuppID.Text) & "'"

            'create query
            vMyPgCmd = New NpgsqlCommand(vQuery, vMyPgCon)

            'execute query
            vMyPgCmd.ExecuteNonQuery()

            'close and dispose to avoid memory leak
            vMyPgCmd.Dispose()

            'create log
            vQuery = modModule.CreateLogCn(vMyPgCon, Me.Name, "new stradcom payment - supp.id: " & txtSuppID.Text, txtAmount.Text)

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

            MsgBox("Successfull in creating new Stradcom payment.", _
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
        txtLedgerDescription.Text = LCase(Trim(modModule.StripInvalidStringChars(txtLedgerDescription.Text)))
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

    Private Sub txtAmount_TextChanged(sender As Object, e As EventArgs) Handles txtAmount.TextChanged

    End Sub

    Private Sub txtPaymentDetails_GotFocus(sender As Object, e As EventArgs) Handles txtPaymentDetails.GotFocus
        txtPaymentDetails.SelectAll()
    End Sub

    Private Sub txtPaymentDetails_LostFocus(sender As Object, e As EventArgs) Handles txtPaymentDetails.LostFocus
        txtPaymentDetails.Text = UCase(Trim(modModule.StripInvalidStringChars(txtPaymentDetails.Text)))
    End Sub

    Private Sub txtPaymentDetails_TextChanged(sender As Object, e As EventArgs) Handles txtPaymentDetails.TextChanged

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

    Private Sub txtDateDeposited_TextChanged(sender As Object, e As EventArgs) Handles txtDateDeposited.TextChanged

    End Sub

    Private Sub cmbType_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbType.KeyPress
        e.Handled = True
    End Sub

    Private Sub cmbType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbType.SelectedIndexChanged

    End Sub

    Private Sub cmbBank_GotFocus(sender As Object, e As EventArgs) Handles cmbBank.GotFocus
        cmbBank.SelectAll()
    End Sub

    Private Sub cmbBank_LostFocus(sender As Object, e As EventArgs) Handles cmbBank.LostFocus
        If modModule.ValidComboBoxData(cmbBank.Text, cmbBank) = False Then cmbBank.Text = ""
    End Sub

    Private Sub cmbBank_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbBank.SelectedIndexChanged

    End Sub

    Private Sub txtAccountNo_GotFocus(sender As Object, e As EventArgs) Handles txtAccountNo.GotFocus
        txtAccountNo.SelectAll()
    End Sub

    Private Sub txtAccountNo_LostFocus(sender As Object, e As EventArgs) Handles txtAccountNo.LostFocus
        txtAccountNo.Text = modModule.StripInvalidStringChars(UCase(Trim(txtAccountNo.Text)))
    End Sub

    Private Sub txtAccountNo_TextChanged(sender As Object, e As EventArgs) Handles txtAccountNo.TextChanged

    End Sub
End Class