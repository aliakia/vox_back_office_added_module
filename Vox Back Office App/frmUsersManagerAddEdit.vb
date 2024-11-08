Imports Npgsql
Imports System.Security.Cryptography

Public Class frmUsersManagerAddEdit

    Private gMode As String
    Private gRecNo As String
    Private gFirstLoad As Boolean

    Private gOldUserID As String
    Private gOldGender As String
    Private gOldFirstName As String
    Private gOldMiddleName As String
    Private gOldLastName As String
    Private gOldDescription As String
    Private gOldUserType As String
    Private gOldPetcCode As String
    Private gOldEmployeeID As String
    Private gOldStatus As String
    Private gOldPassword As String

    Private gOldTesdaCertificate As String
    Private gOldTesdaExpiration As String

    Property Mode() As String
        Get
            Return gMode
        End Get

        Set(ByVal value As String)
            gMode = value
        End Set
    End Property

    Property RecNo() As String
        Get
            Return gRecNo
        End Get

        Set(ByVal value As String)
            gRecNo = value
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
        vTmpStr = modModule.CreateLog(Me.Name, "Users Manager - Add/Edit - Close", "")

        If vTmpStr = "1" Then
            Me.Close()
        Else
            MsgBox("An error occurred while saving log. Operation aborted.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Operation cancelled")
        End If
    End Sub

    Private Sub InitializeValues()
        txtUserID.Text = ""
        cmbGender.Text = ""
        txtFirstName.Text = ""
        txtMiddleName.Text = ""
        txtLastName.Text = ""
        txtFullName.Text = ""
        txtDescription.Text = ""

        cmbType.Text = ""
        txtPetcCode.Text = ""
        txtEmployeeID.Text = ""
        cmbStatus.Text = ""
        txtPassword.Text = ""
        txtConfirmPassword.Text = ""

        txtTesdaCertificate.Text = ""
        txtTesdaExpiration.Text = ""

        gOldUserID = ""
        gOldGender = ""
        gOldFirstName = ""
        gOldMiddleName = ""
        gOldLastName = ""
        gOldDescription = ""
        gOldUserType = ""
        gOldPetcCode = ""
        gOldEmployeeID = ""
        gOldStatus = ""
        gOldPassword = ""
        gOldTesdaCertificate = ""
        gOldTesdaExpiration = ""
    End Sub

    Private Sub SaveOldValues()
        gOldUserID = txtUserID.Text
        gOldGender = cmbGender.Text
        gOldFirstName = txtFirstName.Text
        gOldMiddleName = txtMiddleName.Text
        gOldLastName = txtLastName.Text
        gOldDescription = txtDescription.Text
        gOldUserType = cmbType.Text
        gOldPetcCode = txtPetcCode.Text
        gOldEmployeeID = txtEmployeeID.Text
        gOldStatus = cmbStatus.Text
        gOldPassword = txtPassword.Text
        gOldTesdaCertificate = txtTesdaCertificate.Text
        gOldTesdaExpiration = txtTesdaExpiration.Text
    End Sub

    Private Function ChangesMade(Optional ByRef bChanges As String = "", Optional ByVal bPutCrLf As Boolean = False) As Boolean
        ChangesMade = False
        bChanges = ""

        If gOldGender <> cmbGender.Text Then
            ChangesMade = True
            bChanges = bChanges & IIf(bChanges <> "", IIf(bPutCrLf = True, vbCrLf, ", "), "") & _
                "Gender from " & gOldGender & " to " & cmbGender.Text
        End If

        If gOldFirstName <> txtFirstName.Text Then
            ChangesMade = True
            bChanges = bChanges & IIf(bChanges <> "", IIf(bPutCrLf = True, vbCrLf, ", "), "") & _
                "Firstname from " & gOldFirstName & " to " & txtFirstName.Text
        End If

        If gOldMiddleName <> txtMiddleName.Text Then
            ChangesMade = True
            bChanges = bChanges & IIf(bChanges <> "", IIf(bPutCrLf = True, vbCrLf, ", "), "") & _
                "Middlename from " & gOldMiddleName & " to " & txtMiddleName.Text
        End If

        If gOldLastName <> txtLastName.Text Then
            ChangesMade = True
            bChanges = bChanges & IIf(bChanges <> "", IIf(bPutCrLf = True, vbCrLf, ", "), "") & _
                "Lastname from " & gOldLastName & " to " & txtLastName.Text
        End If

        If gOldDescription <> txtDescription.Text Then
            ChangesMade = True
            bChanges = bChanges & IIf(bChanges <> "", IIf(bPutCrLf = True, vbCrLf, ", "), "") & _
                "Description from " & gOldDescription & " to " & txtDescription.Text
        End If

        If gOldUserType <> cmbType.Text Then
            ChangesMade = True
            bChanges = bChanges & IIf(bChanges <> "", IIf(bPutCrLf = True, vbCrLf, ", "), "") & _
                "User type from " & gOldUserType & " to " & cmbType.Text
        End If

        If gOldPetcCode <> txtPetcCode.Text Then
            ChangesMade = True
            bChanges = bChanges & IIf(bChanges <> "", IIf(bPutCrLf = True, vbCrLf, ", "), "") & _
                "PETC Code from " & gOldPetcCode & " to " & txtPetcCode.Text
        End If

        If gOldEmployeeID <> txtEmployeeID.Text Then
            ChangesMade = True
            bChanges = bChanges & IIf(bChanges <> "", IIf(bPutCrLf = True, vbCrLf, ", "), "") & _
                "Employee ID from " & gOldEmployeeID & " to " & txtEmployeeID.Text
        End If

        If gOldStatus <> cmbStatus.Text Then
            ChangesMade = True
            bChanges = bChanges & IIf(bChanges <> "", IIf(bPutCrLf = True, vbCrLf, ", "), "") & _
                "User status from " & gOldStatus & " to " & cmbStatus.Text
        End If

        If gOldTesdaCertificate <> txtTesdaCertificate.Text Then
            ChangesMade = True
            bChanges = bChanges & IIf(bChanges <> "", IIf(bPutCrLf = True, vbCrLf, ", "), "") & _
                "TESDA certificate no. from " & gOldTesdaCertificate & " to " & txtTesdaCertificate.Text
        End If

        If gOldTesdaExpiration <> txtTesdaExpiration.Text Then
            ChangesMade = True
            bChanges = bChanges & IIf(bChanges <> "", IIf(bPutCrLf = True, vbCrLf, ", "), "") & _
                "TESDA expiration from " & gOldTesdaExpiration & " to " & txtTesdaExpiration.Text
        End If

        If Trim(txtPassword.Text) <> "" Then
            Using md5Hash As MD5 = MD5.Create()
                Dim vHash As String = LCase(GetMd5Hash(md5Hash, txtPassword.Text))

                If gOldPassword <> vHash Then
                    ChangesMade = True
                    bChanges = bChanges & IIf(bChanges <> "", IIf(bPutCrLf = True, vbCrLf, ", "), "") & _
                        "Password from ***** to *****"
                End If
            End Using
        End If

    End Function

    Private Sub frmLocationsManagerAddEdit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        gFirstLoad = True

        Select Case Me.Mode
            Case "new"
                Me.Text = "ADD NEW USER DATA"

                txtUserID.ReadOnly = False
                txtPetcCode.ReadOnly = False
                cmdBrowsePetc.Visible = True

                txtPetcCode.Size = New Size(74, 20)

                cmdProcess.Text = "CREATE"

            Case "edit"
                Me.Text = "EDIT USER DATA"

                txtUserID.ReadOnly = True
                txtPetcCode.ReadOnly = True
                cmdBrowsePetc.Visible = False

                txtPetcCode.Size = New Size(138, 20)

                cmdProcess.Text = "SAVE"
        End Select

        lblStatusPrompt.Visible = True
        lblStatusPrompt.Text = "Ready"

        'initialize controls

        txtUserID.MaxLength = 64
        txtFirstName.MaxLength = 32
        txtMiddleName.MaxLength = 32
        txtLastName.MaxLength = 32
        txtDescription.MaxLength = 0

        txtPetcCode.MaxLength = 16
        txtEmployeeID.MaxLength = 64
        txtPassword.MaxLength = 128
        txtConfirmPassword.MaxLength = 128

        txtTesdaCertificate.MaxLength = 32
        txtTesdaExpiration.MaxLength = 0

        With cmbGender
            .Items.Clear()

            .Items.Add("Male")
            .Items.Add("Female")
        End With

        With cmbType
            .Items.Clear()

            .Items.Add("petc_encoder")
            .Items.Add("petc_technician")
            .Items.Add("tech_support")
        End With

        With cmbStatus
            .Items.Clear()

            .Items.Add("Active")
            .Items.Add("Inactive")
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
            If LCase(Me.Mode) = "edit" Then
                If timerLoad.Enabled = False Then timerLoad.Enabled = True
            Else
                EnableButtons()
            End If
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

        Dim vTmpVar As Integer
        Dim vTmpStatus As String = ""

        Try

            If Trim(txtUserID.Text) = "" Then
                vTmpVar = MsgBox("User ID is required." & vbCrLf & vbCrLf & _
                               "Please enter User ID.", vbOKOnly + vbEmpty, "Incomplete data")

                txtUserID.Select()
                txtUserID.Focus()

                Exit Sub
            End If

            If txtFirstName.Text = "" Then
                vTmpVar = MsgBox("First name is required." & vbCrLf & vbCrLf & _
                               "Please enter first name of user.", vbOKOnly + vbEmpty, "Incomplete data")

                txtFirstName.Select()
                txtFirstName.Focus()

                Exit Sub
            End If

            'If txtMiddleName.Text = "" Then
            ' vTmpVar = MsgBox("Middle name is required." & vbCrLf & vbCrLf & _
            '                "Please enter middle name of user.", vbOKOnly + vbEmpty, "Incomplete data")
            '
            '            txtMiddleName.Select()
            '            txtMiddleName.Focus()
            '
            '            Exit Sub
            '            End If

            If txtLastName.Text = "" Then
                vTmpVar = MsgBox("Last name is required." & vbCrLf & vbCrLf & _
                               "Please enter last name of user.", vbOKOnly + vbEmpty, "Incomplete data")

                txtLastName.Select()
                txtLastName.Focus()

                Exit Sub
            End If

            '            If txtDescription.Text = "" Then
            ' vTmpVar = MsgBox("Description is required." & vbCrLf & vbCrLf & _
            '                "Please enter description of user.", vbOKOnly + vbEmpty, "Incomplete data")
            '
            '            txtDescription.Select()
            '            txtDescription.Focus()
            '
            '            Exit Sub
            '            End If

            If cmbType.Text = "" Then
                vTmpVar = MsgBox("User type is required." & vbCrLf & vbCrLf & _
                               "Please select type from the list.", vbOKOnly + vbEmpty, "Incomplete data")

                cmbType.Select()
                cmbType.Focus()

                Exit Sub
            Else
                Select Case LCase(cmbType.Text)
                    Case "petc_technician", "petc_encoder"
                        If LCase(txtPetcCode.Text) = "tech.support" Then
                            vTmpVar = MsgBox("This user is configured as a PETC user. PETC Code value cannot be 'tech.support'." & vbCrLf & vbCrLf & _
                                           "Please enter the correct PETC Code.", vbOKOnly + vbEmpty, "Invalid data")

                            txtPetcCode.Select()
                            txtPetcCode.Focus()

                            Exit Sub
                        End If

                    Case "tech_support"
                        If txtPetcCode.Text <> "tech.support" Then
                            vTmpVar = MsgBox("This terminal is configured as technical support / office user. PETC Code does not apply." & vbCrLf & vbCrLf & _
                                           "Please put 'tech.support' in PETC Code.", vbOKOnly + vbEmpty, "Invalid data")

                            txtPetcCode.Select()
                            txtPetcCode.Focus()

                            Exit Sub
                        End If

                    Case Else
                        vTmpVar = MsgBox("Invalid user type." & vbCrLf & vbCrLf & _
                                       "Please select type from the list.", vbOKOnly + vbEmpty, "Invalid data")

                        cmbType.Select()
                        cmbType.Focus()

                        Exit Sub
                End Select
            End If

            If txtPetcCode.Text = "" Then
                vTmpVar = MsgBox("PETC code is required." & vbCrLf & vbCrLf & _
                               "Please enter PETC code.", vbOKOnly + vbEmpty, "Incomplete data")

                txtPetcCode.Select()
                txtPetcCode.Focus()

                Exit Sub
            End If

            'If txtEmployeeID.Text = "" Then
            ' vTmpVar = MsgBox("Employee ID is required." & vbCrLf & vbCrLf & _
            '                "Please enter Employee ID of user.", vbOKOnly + vbEmpty, "Incomplete data")
            '
            '            txtEmployeeID.Select()
            '            txtEmployeeID.Focus()
            '
            '            Exit Sub
            '            End If

            If cmbStatus.Text = "" Then
                vTmpVar = MsgBox("User status is required." & vbCrLf & vbCrLf & _
                               "Please select the current status of this user.", vbOKOnly + vbEmpty, "Incomplete data")

                cmbStatus.Select()
                cmbStatus.Focus()

                Exit Sub
            End If

            Select Case Me.Mode
                Case "new"
                    If txtPassword.Text = "" Then
                        vTmpVar = MsgBox("Password is required." & vbCrLf & vbCrLf & _
                                       "Please enter password for this user.", vbOKOnly + vbEmpty, "Incomplete data")

                        txtPassword.Select()
                        txtPassword.Focus()

                        Exit Sub
                    End If

                Case "edit"
            End Select

            If txtPassword.Text <> "" Or txtConfirmPassword.Text <> "" Then
                If txtPassword.Text <> txtConfirmPassword.Text Then
                    vTmpVar = MsgBox("Password confirmation failed." & vbCrLf & vbCrLf & _
                                   "Please make sure Password and Confirm Password are the same.", vbOKOnly + vbEmpty, "Invalid data")

                    txtPassword.Select()
                    txtPassword.Focus()

                    Exit Sub
                End If
            End If

            Select Case LCase(cmbType.Text)
                Case "petc_technician"
                    If txtTesdaCertificate.Text = "" Then
                        vTmpVar = MsgBox("TESDA certification number is required." & vbCrLf & vbCrLf & _
                                       "Please enter TESDA certification number for this user.", vbOKOnly + vbEmpty, "Incomplete data")

                        txtTesdaCertificate.Select()
                        txtTesdaCertificate.Focus()

                        Exit Sub
                    End If

                    If txtTesdaExpiration.Text <> "" Then
                        If IsDate(txtTesdaExpiration.Text) = False Then
                            vTmpVar = MsgBox("TESDA certificate expiration date entered is not a valid date." & vbCrLf & vbCrLf & _
                                           "Please enter the correct date of TESDA certification expiration.", vbOKOnly + vbEmpty, "Invalid data")

                            txtTesdaExpiration.Select()
                            txtTesdaExpiration.Focus()

                            Exit Sub
                        End If
                    End If

                Case "tech_support", "petc_encoder"
                    'TESDA certificate is not required
            End Select

            Select Case Me.Mode
                Case "new"
                    vTmpVar = MsgBox("You are about to create a new User with the following info.:" & vbCrLf & vbCrLf & _
                                     "User ID: " & txtUserID.Text & vbCrLf & _
                                     IIf(cmbGender.Text = "", "", "Gender: " & cmbGender.Text & vbCrLf) & _
                                     IIf(txtFirstName.Text = "", "", "First name: " & txtFirstName.Text & vbCrLf) & _
                                     IIf(txtMiddleName.Text = "", "", "Middle name: " & txtMiddleName.Text & vbCrLf) & _
                                     IIf(txtLastName.Text = "", "", "Last name: " & txtLastName.Text & vbCrLf) & _
                                     IIf(txtFullName.Text = "", "", "Full name: " & txtFullName.Text & vbCrLf) & _
                                     IIf(txtDescription.Text = "", "", "Description: " & txtDescription.Text & vbCrLf) & _
                                     IIf(cmbType.Text = "", "", "User type: " & cmbType.Text & vbCrLf) & _
                                     IIf(txtPetcCode.Text = "", "", "PETC Code: " & txtPetcCode.Text & vbCrLf) & _
                                     IIf(txtEmployeeID.Text = "", "", "Employee ID: " & txtEmployeeID.Text & vbCrLf) & _
                                     IIf(cmbStatus.Text = "", "", "Status: " & cmbStatus.Text & vbCrLf) & _
                                     IIf(txtTesdaCertificate.Text = "", "", "TESDA certificate no.: " & txtTesdaCertificate.Text & vbCrLf) & _
                                     IIf(txtTesdaExpiration.Text = "", "", "TESDA cert. expiration: " & txtTesdaExpiration.Text & vbCrLf) & vbCrLf & _
                                     "Please make sure the above information are true and correct." & vbCrLf & vbCrLf & _
                                     "Are you sure you want to create the new User?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "User confirmation")

                Case "edit"
                    If ChangesMade(vTmpStr, True) = False Then
                        MsgBox("Nothing to save. No changes haved been made.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Operation cancelled")

                        Exit Sub
                    Else
                        vTmpVar = MsgBox("You are about to update User with the following changes:" & vbCrLf & vbCrLf & _
                                         vTmpStr & vbCrLf & _
                                         "Please make sure the above information are true and correct." & vbCrLf & vbCrLf & _
                                         "Are you sure you want to update the User record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "User confirmation")
                    End If
            End Select

            If vTmpVar = MsgBoxResult.No Then Exit Sub

            Select Case LCase(cmbStatus.Text)
                Case "active"
                    vTmpStatus = "1"

                Case "inactive"
                    vTmpStatus = "0"

                Case Else
                    MsgBox("Invalid user status. Please select in the list the current status of user.", _
                           MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Validation failed")
            End Select

            lblStatusPrompt.Text = "Opening database..."
            lblStatusPrompt.Refresh()

            'open db connection
            vMyPgCon.ConnectionString = pConnectVox
            vMyPgCon.Open()

            lblStatusPrompt.Text = "Validating in database..."
            lblStatusPrompt.Refresh()

            Select Case Me.Mode
                Case "new"
                    'check if already exist
                    vQuery = "SELECT recno FROM tb_users WHERE user_id = '" & modModule.CorrectSqlString(txtUserID.Text) & "' " & _
                        "AND petc_code = '" & modModule.CorrectSqlString(txtPetcCode.Text) & "'"

                    'create query
                    vMyPgCmd = New NpgsqlCommand(vQuery, vMyPgCon)

                    'execute query
                    vMyPgRd = vMyPgCmd.ExecuteReader()

                    'read values
                    vFound = vMyPgRd.Read

                    If vFound = True Then
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
                        vTmpVar = MsgBox("User with code " & modModule.CorrectSqlString(txtUserID.Text) & " already exist in record." & vbCrLf & vbCrLf & _
                                        "Please assign another User ID or double check records.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Validation failed")
                        Exit Sub
                    End If

                    'close and dispose to avoid memory leak
                    vMyPgRd.Close()
                    vMyPgCmd.Dispose()

                    If LCase(Trim(cmbType.Text)) = "petc_technician" Then
                        'check if technician tesda cert already exist
                        vQuery = "SELECT recno FROM tb_users WHERE LOWER(certificate_tesda) = '" & LCase(modModule.CorrectSqlString(txtTesdaCertificate.Text)) & "' AND " & _
                            "is_active = 1"

                        'create query
                        vMyPgCmd = New NpgsqlCommand(vQuery, vMyPgCon)

                        'execute query
                        vMyPgRd = vMyPgCmd.ExecuteReader()

                        'read values
                        vFound = vMyPgRd.Read

                        If vFound = True Then
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

                            txtTesdaCertificate.Select()
                            txtTesdaCertificate.Focus()

                            'record found
                            vTmpVar = MsgBox("TESDA Certificate with code " & modModule.CorrectSqlString(txtTesdaCertificate.Text) & " already exist in record." & vbCrLf & vbCrLf & _
                                            "Please check records.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Validation failed")
                            Exit Sub
                        End If

                        'close and dispose to avoid memory leak
                        vMyPgRd.Close()
                        vMyPgCmd.Dispose()
                    End If

                Case "edit"
                    'check if already exist
                    vQuery = "SELECT recno FROM tb_users WHERE user_id = '" & modModule.CorrectSqlString(txtUserID.Text) & "' " & _
                        "AND petc_code = '" & modModule.CorrectSqlString(txtPetcCode.Text) & "'"

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
                        vTmpVar = MsgBox("User with ID " & modModule.CorrectSqlString(txtUserID.Text) & " no longer exist in record." & vbCrLf & vbCrLf & _
                                        "Please make sure the record was not deleted.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Validation failed")
                        Exit Sub
                    Else
                        'check if record number is the same

                        If Trim(Str(vMyPgRd("recno"))) <> Me.RecNo Then
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
                            vTmpVar = MsgBox("User with ID " & modModule.CorrectSqlString(txtUserID.Text) & " already exist in record." & vbCrLf & vbCrLf & _
                                            "Please make sure the data entered was correct.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Validation failed")
                            Exit Sub
                        End If
                    End If

                    'close and dispose to avoid memory leak
                    vMyPgRd.Close()
                    vMyPgCmd.Dispose()
            End Select

            Dim vPasswordMD5 As String = ""

            If txtPassword.Text = "" Then
                vPasswordMD5 = gOldPassword
            Else
                'get MD5 conversion of current password
                Using md5Hash As MD5 = MD5.Create()
                    vPasswordMD5 = LCase(GetMd5Hash(md5Hash, txtPassword.Text))
                End Using
            End If

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

            Select Case LCase(Me.Mode)
                Case "new"
                    'insert in tb_stations table
                    vQuery = "INSERT INTO tb_users (user_id, employee_id, password, first_name, middle_name, last_name, gender, petc_code, " & _
                        "certificate_tesda, certificate_tesda_expiration, is_active, description, user_type, user_name) " & _
                        "VALUES ('" & modModule.CorrectSqlString(txtUserID.Text) & "', '" & modModule.CorrectSqlString(txtEmployeeID.Text) & "', " & _
                            "'" & modModule.CorrectSqlString(vPasswordMD5) & "', '" & modModule.CorrectSqlString(txtFirstName.Text) & "', " & _
                            "'" & modModule.CorrectSqlString(txtMiddleName.Text) & "', '" & modModule.CorrectSqlString(txtLastName.Text) & "', " & _
                            "'" & modModule.CorrectSqlString(cmbGender.Text) & "', '" & modModule.CorrectSqlString(txtPetcCode.Text) & "', " & _
                            "'" & modModule.CorrectSqlString(txtTesdaCertificate.Text) & "', " & _
                             IIf(txtTesdaExpiration.Text = "", "NULL, ", "'" & txtTesdaExpiration.Text & "', ") & _
                             modModule.CorrectSqlString(vTmpStatus) & ", '" & modModule.CorrectSqlString(txtDescription.Text) & "', " & _
                             "'" & modModule.CorrectSqlString(cmbType.Text) & "', '" & modModule.CorrectSqlString(txtFullName.Text) & "')"

                Case "edit"
                    'update in tb_petc table
                    vQuery = "UPDATE tb_users SET user_id = '" & modModule.CorrectSqlString(txtUserID.Text) & "', " & _
                        "employee_id = '" & modModule.CorrectSqlString(txtEmployeeID.Text) & "', " & _
                        "password = '" & modModule.CorrectSqlString(vPasswordMD5) & "', " & _
                        "first_name = '" & modModule.CorrectSqlString(txtFirstName.Text) & "', " & _
                        "middle_name = '" & modModule.CorrectSqlString(txtMiddleName.Text) & "', " & _
                        "last_name = '" & modModule.CorrectSqlString(txtLastName.Text) & "', " & _
                        "gender = '" & modModule.CorrectSqlString(cmbGender.Text) & "', " & _
                        "petc_code = '" & modModule.CorrectSqlString(txtPetcCode.Text) & "', " & _
                        "certificate_tesda = '" & modModule.CorrectSqlString(txtTesdaCertificate.Text) & "', " & _
                        "certificate_tesda_expiration = " & IIf(txtTesdaExpiration.Text = "", "NULL, ", "'" & txtTesdaExpiration.Text & "', ") & _
                        "is_active = " & vTmpStatus & ", " & _
                        "description = '" & modModule.CorrectSqlString(txtDescription.Text) & "', " & _
                        "user_type = '" & modModule.CorrectSqlString(cmbType.Text) & "', " & _
                        "user_name = '" & modModule.CorrectSqlString(txtFullName.Text) & "' " & _
                        "WHERE recno = " & modModule.CorrectSqlString(Me.RecNo)
            End Select

            'create query
            vMyPgCmd = New NpgsqlCommand(vQuery, vMyPgCon)

            'execute query
            vMyPgCmd.ExecuteNonQuery()

            'close and dispose to avoid memory leak
            vMyPgCmd.Dispose()

            'create log
            Select Case LCase(Me.Mode)
                Case "new"
                    vTmpStr = ""

                Case "edit"
                    'changes made
                    vFound = ChangesMade(vTmpStr, False)
            End Select

            vQuery = modModule.CreateLogCn(vMyPgCon, Me.Name, LCase(Me.Mode) & " user " & txtUserID.Text, vTmpStr)

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

            MsgBox("Successful in " & IIf(LCase(Me.Mode) = "new", " creating new ", " updating ") & " User " & txtUserID.Text & ".", _
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

    Private Sub timerLoad_Tick(sender As Object, e As EventArgs) Handles timerLoad.Tick
        'open postgres connection
        Dim vMyPgCon As New NpgsqlConnection
        Dim vMyPgCmd = New NpgsqlCommand
        Dim vMyPgRd As NpgsqlDataReader
        Dim vFound As Boolean

        Dim vQuery As String

        Dim vTmpVar As Integer

        timerLoad.Enabled = False

        If LCase(Me.Mode) <> "edit" Then Exit Sub
        If Trim(Me.RecNo) = "" Then Exit Sub

        Try
            DisableButtons()

            InitializeValues()

            vQuery = "SELECT user_id, employee_id, password, first_name, middle_name, last_name, gender, petc_code, " & _
                "certificate_tesda, certificate_tesda_expiration, is_active, description, user_type, user_name " & _
                "FROM tb_users WHERE recno = " & modModule.CorrectSqlString(Me.RecNo)

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

            If vFound = False Then
                'no record found
                vTmpVar = MsgBox("User record no longer exist." & vbCrLf & vbCrLf & _
                                "Please make sure the record was not deleted.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Unexpected error")

                Me.Close()

                Exit Sub
            Else
                'get result

                If IsDBNull(vMyPgRd("user_id")) = False Then
                    txtUserID.Text = vMyPgRd("user_id")
                End If

                If IsDBNull(vMyPgRd("gender")) = False Then
                    cmbGender.Text = vMyPgRd("gender")
                End If

                If IsDBNull(vMyPgRd("first_name")) = False Then
                    txtFirstName.Text = vMyPgRd("first_name")
                End If

                If IsDBNull(vMyPgRd("middle_name")) = False Then
                    txtMiddleName.Text = vMyPgRd("middle_name")
                End If

                If IsDBNull(vMyPgRd("last_name")) = False Then
                    txtLastName.Text = vMyPgRd("last_name")
                End If

                If IsDBNull(vMyPgRd("user_name")) = False Then
                    txtFullName.Text = vMyPgRd("user_name")
                End If

                If IsDBNull(vMyPgRd("description")) = False Then
                    txtDescription.Text = vMyPgRd("description")
                End If

                If IsDBNull(vMyPgRd("user_type")) = False Then
                    cmbType.Items.Clear()

                    Select Case vMyPgRd("user_type")
                        Case "petc_encoder", "petc_technician"
                            With cmbType.Items
                                .Add("petc_encoder")
                                .Add("petc_technician")

                                cmbType.Text = vMyPgRd("user_type")
                            End With

                        Case "tech_support"
                            With cmbType.Items
                                .Add("tech_support")
                            End With

                            cmbType.Text = vMyPgRd("user_type")
                    End Select
                End If

                If IsDBNull(vMyPgRd("petc_code")) = False Then
                    txtPetcCode.Text = vMyPgRd("petc_code")
                End If

                If IsDBNull(vMyPgRd("employee_id")) = False Then
                    txtEmployeeID.Text = vMyPgRd("employee_id")
                End If

                If IsDBNull(vMyPgRd("is_active")) = False Then
                    Select Case vMyPgRd("is_active")
                        Case 1
                            cmbStatus.Text = "Active"

                        Case 0
                            cmbStatus.Text = "Inactive"

                        Case Else
                            cmbStatus.Text = "Unknown"
                    End Select
                End If

                If IsDBNull(vMyPgRd("certificate_tesda")) = False Then
                    txtTesdaCertificate.Text = vMyPgRd("certificate_tesda")
                End If

                If IsDBNull(vMyPgRd("certificate_tesda_expiration")) = False Then
                    txtTesdaExpiration.Text = vMyPgRd("certificate_tesda_expiration")
                End If

                If IsDBNull(vMyPgRd("password")) = False Then
                    txtPassword.Text = vMyPgRd("password")
                End If

                'clear password values for security
                txtPassword.Visible = False

                txtConfirmPassword.Text = ""
                'cmbType_SelectedIndexChanged(sender, e)
            End If

            'save old values for later comparison
            SaveOldValues()

            'clear password values for security
            txtPassword.Text = ""
            txtPassword.Visible = True

            lblStatusPrompt.Text = "Closing database..."
            lblStatusPrompt.Refresh()

            'close and dispose to avoid memory leak
            vMyPgRd.Close()
            vMyPgCmd.Dispose()

            'close and dispose connection
            vMyPgCon.Close()
            vMyPgCon = Nothing

            lblStatusPrompt.Text = "Ready"
            lblStatusPrompt.Visible = True
            lblStatusPrompt.Refresh()

            EnableButtons()

        Catch ex As Exception
            'an error has occured

            'clear password values for security
            txtPassword.Text = ""
            txtConfirmPassword.Text = ""

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

            Me.Close()

            Exit Sub
        End Try
    End Sub

    Private Sub txtUserID_GotFocus(sender As Object, e As EventArgs) Handles txtUserID.GotFocus
        txtUserID.SelectAll()
    End Sub

    Private Sub txtUserID_LostFocus(sender As Object, e As EventArgs) Handles txtUserID.LostFocus
        txtUserID.Text = Trim(modModule.StripInvalidStringChars(txtUserID.Text))
    End Sub

    Private Sub txtUserID_TextChanged(sender As Object, e As EventArgs) Handles txtUserID.TextChanged

    End Sub

    Private Sub cmbGender_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbGender.KeyPress
        e.Handled = True
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

    Private Sub txtFirstName_GotFocus(sender As Object, e As EventArgs) Handles txtFirstName.GotFocus
        txtFirstName.SelectAll()
    End Sub

    Private Sub txtFirstName_LostFocus(sender As Object, e As EventArgs) Handles txtFirstName.LostFocus
        txtFirstName.Text = UCase(Trim(modModule.StripInvalidStringChars(txtFirstName.Text)))
    End Sub

    Private Sub txtFirstName_TextChanged(sender As Object, e As EventArgs) Handles txtFirstName.TextChanged
        txtFullName.Text = Trim(txtFirstName.Text) & _
            IIf(Trim(txtMiddleName.Text) = "", "", " " & Microsoft.VisualBasic.Left(Trim(txtMiddleName.Text), 1) & ".") & _
                IIf(Trim(txtLastName.Text) = "", "", " " & Trim(txtLastName.Text))
    End Sub

    Private Sub txtMiddleName_GotFocus(sender As Object, e As EventArgs) Handles txtMiddleName.GotFocus
        txtMiddleName.SelectAll()
    End Sub

    Private Sub txtMiddleName_LostFocus(sender As Object, e As EventArgs) Handles txtMiddleName.LostFocus
        txtMiddleName.Text = UCase(Trim(modModule.StripInvalidStringChars(txtMiddleName.Text)))
    End Sub

    Private Sub txtMiddleName_TextChanged(sender As Object, e As EventArgs) Handles txtMiddleName.TextChanged
        txtFullName.Text = Trim(txtFirstName.Text) & _
            IIf(Trim(txtMiddleName.Text) = "", "", " " & Microsoft.VisualBasic.Left(Trim(txtMiddleName.Text), 1) & ".") & _
                IIf(Trim(txtLastName.Text) = "", "", " " & Trim(txtLastName.Text))
    End Sub

    Private Sub cmbStatus_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbStatus.KeyPress
        e.Handled = True
    End Sub

    Private Sub cmbStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbStatus.SelectedIndexChanged

    End Sub

    Private Sub txtLastName_GotFocus(sender As Object, e As EventArgs) Handles txtLastName.GotFocus
        txtLastName.SelectAll()
    End Sub

    Private Sub txtLastName_LostFocus(sender As Object, e As EventArgs) Handles txtLastName.LostFocus
        txtLastName.Text = UCase(Trim(modModule.StripInvalidStringChars(txtLastName.Text)))
    End Sub

    Private Sub txtLastName_TextChanged(sender As Object, e As EventArgs) Handles txtLastName.TextChanged
        txtFullName.Text = Trim(txtFirstName.Text) & _
            IIf(Trim(txtMiddleName.Text) = "", "", " " & Microsoft.VisualBasic.Left(Trim(txtMiddleName.Text), 1) & ".") & _
                IIf(Trim(txtLastName.Text) = "", "", " " & Trim(txtLastName.Text))
    End Sub

    Private Sub txtDescription_GotFocus(sender As Object, e As EventArgs) Handles txtDescription.GotFocus
        txtDescription.SelectAll()
    End Sub

    Private Sub txtDescription_LostFocus(sender As Object, e As EventArgs) Handles txtDescription.LostFocus
        txtDescription.Text = UCase(Trim(modModule.StripInvalidStringChars(txtDescription.Text)))
    End Sub

    Private Sub txtDescription_TextChanged(sender As Object, e As EventArgs) Handles txtDescription.TextChanged

    End Sub

    Private Sub txtEmployeeID_GotFocus(sender As Object, e As EventArgs) Handles txtEmployeeID.GotFocus
        txtEmployeeID.SelectAll()
    End Sub

    Private Sub txtEmployeeID_LostFocus(sender As Object, e As EventArgs) Handles txtEmployeeID.LostFocus
        txtEmployeeID.Text = UCase(Trim(modModule.StripInvalidStringChars(txtEmployeeID.Text)))
    End Sub

    Private Sub txtEmployeeID_TextChanged(sender As Object, e As EventArgs) Handles txtEmployeeID.TextChanged

    End Sub

    Private Sub txtTesdaCertificate_GotFocus(sender As Object, e As EventArgs) Handles txtTesdaCertificate.GotFocus
        txtTesdaCertificate.SelectAll()
    End Sub

    Private Sub txtTesdaCertificate_LostFocus(sender As Object, e As EventArgs) Handles txtTesdaCertificate.LostFocus
        txtTesdaCertificate.Text = UCase(Trim(modModule.StripInvalidStringChars(txtTesdaCertificate.Text)))
    End Sub

    Private Sub txtTesdaCertificate_TextChanged(sender As Object, e As EventArgs) Handles txtTesdaCertificate.TextChanged

    End Sub

    Private Sub txtPassword_GotFocus(sender As Object, e As EventArgs) Handles txtPassword.GotFocus
        txtPassword.SelectAll()
    End Sub

    Private Sub txtPassword_LostFocus(sender As Object, e As EventArgs) Handles txtPassword.LostFocus
        txtPassword.Text = modModule.StripInvalidStringChars(txtPassword.Text)
    End Sub

    Private Sub txtPassword_TextChanged(sender As Object, e As EventArgs) Handles txtPassword.TextChanged

    End Sub

    Private Sub txtTesdaExpiration_GotFocus(sender As Object, e As EventArgs) Handles txtTesdaExpiration.GotFocus
        txtTesdaExpiration.SelectAll()
    End Sub

    Private Sub txtTesdaExpiration_LostFocus(sender As Object, e As EventArgs) Handles txtTesdaExpiration.LostFocus
        If IsDate(txtTesdaExpiration.Text) = True Then
            txtTesdaExpiration.Text = Format(CDate(txtTesdaExpiration.Text), "yyyy-MM-dd")
        Else
            txtTesdaExpiration.Text = ""
        End If
    End Sub

    Private Sub txtTesdaExpiration_TextChanged(sender As Object, e As EventArgs) Handles txtTesdaExpiration.TextChanged

    End Sub

    Private Sub cmdBrowsePetc_Click(sender As Object, e As EventArgs) Handles cmdBrowsePetc.Click
        MsgBox("This option is currently unavailable", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Option unavailable")
    End Sub

    Private Sub cmbType_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbType.KeyPress
        e.Handled = True
    End Sub

    Private Sub cmbType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbType.SelectedIndexChanged
        Select Case LCase(cmbType.Text)
            Case "petc_encoder", "petc_technician"
                txtPetcCode.ReadOnly = False

                If Me.Mode = "edit" Then txtPetcCode.Text = gOldPetcCode

                cmdBrowsePetc.Enabled = True

            Case "tech_support"
                txtPetcCode.Text = "tech.support"
                txtPetcCode.ReadOnly = True

                cmdBrowsePetc.Enabled = False

            Case Else
                txtPetcCode.ReadOnly = False
                cmdBrowsePetc.Enabled = False

                If Me.Mode = "edit" Then txtPetcCode.Text = gOldPetcCode
        End Select
    End Sub

    Private Sub txtConfirmPassword_GotFocus(sender As Object, e As EventArgs) Handles txtConfirmPassword.GotFocus
        txtConfirmPassword.SelectAll()
    End Sub

    Private Sub txtConfirmPassword_LostFocus(sender As Object, e As EventArgs) Handles txtConfirmPassword.LostFocus
        txtConfirmPassword.Text = modModule.StripInvalidStringChars(txtConfirmPassword.Text)
    End Sub

    Private Sub txtConfirmPassword_TextChanged(sender As Object, e As EventArgs) Handles txtConfirmPassword.TextChanged

    End Sub

    Private Sub txtFullName_TextChanged(sender As Object, e As EventArgs) Handles txtFullName.TextChanged

    End Sub
End Class