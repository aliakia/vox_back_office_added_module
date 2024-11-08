Imports Npgsql

Public Class frmPetcManagerImportCreate

    Private Sub frmPetcManagerImportCreate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim vTmpStr As String

        lblPrompt.Text = "Initializing..."
        txtPrompt.Text = ""

        vTmpStr = modModule.CreateLog(Me.Name, "PETC Manager - Import PETC - Create", "Open")

        timerLoad.Enabled = True
    End Sub

    Private Sub timerLoad_Tick(sender As Object, e As EventArgs) Handles timerLoad.Tick
        timerLoad.Enabled = False

        '******************************************************* VALIDATE *******************************************************

        'PETC:                                                                                                  Category
        '---------------------------------------------------------------------------------------------------------------
        ' 1. check if petc code is present and same with petc code being processed                              Critical
        ' 2. check if lanes is numeric and not "" or "0"                                                        Critical
        ' 3. check if category is not ""                                                                        Critical
        ' 4. check if business types is not ""                                                                  Critical
        ' 5. check if petc name is not ""                                                                       Critical
        ' 6. check if petc address is not ""                                                                    Critical
        ' 7. check if petc status is "0", "1", "2", "3"                                                         Critical
        ' 8. check if petc owner is not ""                                                                      Critical
        ' 9. check if petc region is not ""                                                                     Critical
        '10. check if petc province is not ""                                                                   Critical
        '11. check if petc lto service area is not ""                                                           Critical
        '12. check if petc dti accreditation no. is not ""                                                      Critical
        '13. check if petc lto authorization no. is no ""                                                       Critical
        '14. check if petc account type is "1" (postpaid) or "2" (prepaid)                                      Critical
        '15. check if petc transmission fee is not "" or "0"                                                    Critical
        '16. check if petc stradcom fee is not "" or "0"                                                        Critical
        '17. if account type is "1" postpaid - max credit must be > 0                                           Critical
        '18. if account type is "2" prepaid - max credit must be <= 0                                           Critical
        '19. check if petc gm must be 16 chars and each character must be "1" or "0"                            Critical
        '20. check if petc code is already present in tb_petcs                                                  Critical
        '21. check if petc code is already present in tb_petc_balance                                           Critical
        '22. check if petc code is already present in tb_petc_test                                              Critical
        '23. check if province is present in tb_region_codes where region and province are match                Critical
        '24. check if region is present in tb_region_codes                                                      Critical
        '25. check if account_id is present in tb_client_accounts                                               Critical
        '26. check if account_manager is present in tb_managing_accounts                                        Critical
        '27. check if tech_manager is present in tb_managing_accounts                                           Critical
        '28. check if marketing_agent is present in tb_managing_accounts                                        Critical

        'TERMINALS:                                                                                             Category
        '---------------------------------------------------------------------------------------------------------------
        ' 1. check if terminal id is present                                                                    Critical
        ' 2. check if petc code is present and same with petc code being processed                              Critical
        ' 3. check if terminal id format is "PETC:xxxx"                                                         Critical
        ' 4. check if petc code is not "tech.support"                                                           Critical
        ' 5. check if terminal type is present and must be either "gas" or "diesel"                             Critical
        ' 6. check if terminal lane is numeric and must not be "" or "0"                                        Critical
        ' 7. check if terminal serial is present                                                                Critical
        ' 8. check if temrinal status is present and must be "1" or "0"                                         Critical
        ' 9. check if terminal machine description is present                                                   Critical
        '10. check if terminal machine serial is present                                                        Critical
        '11. check if terminal machine calibrated is present and is a valid date                                Critical
        '12. check if terminal id is already present in tb_stations                                             Critical
        '13. check if petc code is already present in tb_petcs                                                  Critical
        '14. check if terminal lane and petc code is already present in tb_stations                             Critical

        'USERS:                                                                                                 Category
        '---------------------------------------------------------------------------------------------------------------
        ' 1. check if user id is present                                                                        Critical
        ' 2. check if first name is present                                                                     Critical
        ' 3. check if last name is present                                                                      Critical
        ' 4. check if user type is present and must be "petc_technician" or "petc_encoder"                      Critical
        ' 5. check if petc code is present and same with petc code being processed                              Critical
        ' 6. check if user status is present and must be "0" or "1"                                             Critical
        ' 7. check if user password is present                                                                  Critical
        ' 8. if user is "petc_technician", check if tesda cert no. is present                                   Critical
        ' 9. if user is "petc_technician", check if tesda expiration is present                                 Critical
        '10. check if user id + petc code is already present in tb_users                                        Critical
        '11. if user is "petc_technician", check if tesda cert no. + active is already present in tb_users      Critical
        '12. check if gender is "Male" or "Female" or blank                                                     Critical

        '******************************************************* CREATE *******************************************************
        'General - 1. create log
        'General - 2. validate petc data
        'General - 3. validate terminals data
        'General - 4. validate users data
        'General - 5. create log - prepare
        'General - 6. create table dump backups
        'General - 7. create transaction
        '
        'Create PETC
        '1. create in tb_petcs
        '2. create in tb_petc_balance
        '3. create in tb_petc_balance_details
        '4. create log
        '
        'Create TERMINALS
        '1. create in tb_stations
        '2. create log
        '
        'Create USERS
        '1. create in tb_users
        '2. create log
        '
        'General - 8. commit transaction
        'General - 9. create log

        Dim vTmpVar As Integer
        Dim vTmpStr As String
        Dim vTmpStr2 As String
        Dim vErrorWarning As Long = 0
        Dim vErrorCritical As Long = 0
        Dim vTestCtr As Long = 0
        Dim vErrorCtr As Long = 0
        Dim vErrorStr As String = ""
        Dim vPassed As Boolean
        Dim vCtr As Long
        Dim vRowCtr As Integer

        Dim vPetcCode As String
        Dim vTmpID As String
        Dim vTmpID2 As String
        Dim vTmpID3 As String

        'open postgres connection
        Dim vMyPgCon As New NpgsqlConnection
        Dim vMyPgCmd = New NpgsqlCommand
        Dim vMyPgRd As NpgsqlDataReader
        Dim vFound As Boolean
        Dim vQuery As String

        Try
            'log event
            lblHeader.Text = "PLEASE WAIT..."
            lblPrompt.Text = "Preparing operation..."

            lblHeader.Refresh()
            lblPrompt.Refresh()

            'General - 1. create log
            txtPrompt.Text = "Create system log... "

            vTmpStr = modModule.CreateLog(Me.Name, "PETC Manager - Import PETC - Create", "Start operation - validating")

            txtPrompt.Text = txtPrompt.Text & "done" & vbCrLf & vbCrLf

            lblHeader.Text = "PLEASE WAIT..."
            lblPrompt.Text = "Opening database..."
            lblPrompt.Refresh()

            txtPrompt.Text = txtPrompt.Text & "Opening database... "

            'open db connection
            vMyPgCon.ConnectionString = pConnectVox
            vMyPgCon.Open()

            txtPrompt.Text = txtPrompt.Text & "done" & vbCrLf & vbCrLf

            lblPrompt.Text = "Validating imported PETC data..."
            lblPrompt.Refresh()

            txtPrompt.Text = txtPrompt.Text & "Validating imported PETC data:" & vbCrLf

            'PETC:                                                                                                  Category
            '---------------------------------------------------------------------------------------------------------------
            ' 1. check if petc code is present and same with petc code being processed                              Critical

            vTmpStr = "Validating if PETC Code being processed is same with imported data"
            txtPrompt.Text = txtPrompt.Text & vTmpStr & "..."

            vPassed = False
            With frmPetcManagerImport
                vPetcCode = Mid(.lblPETC.Text, 6)

                vTmpStr2 = .lsvItems.Items(0).Text
                If .lsvItems.Items(0).Text <> vPetcCode Then
                    'not the same
                Else
                    vPassed = True
                End If

                Me.ProcessValidation(vPassed, vErrorCritical, vErrorWarning, vErrorStr, vTmpStr, txtPrompt, "")
            End With

            ' 2. check if lanes is numeric and not "" or "0"   
            vTmpStr = "Validating PETC Lanes value"
            txtPrompt.Text = txtPrompt.Text & vTmpStr & "..."

            vPassed = False
            With frmPetcManagerImport
                vTmpStr2 = .lsvItems.Items(0).SubItems(4).Text
                If IsNumeric(.lsvItems.Items(0).SubItems(4).Text) = False Then
                    'not numeric
                Else
                    If CDbl(.lsvItems.Items(0).SubItems(4).Text) = 0 Then
                        'zero value
                    Else
                        vPassed = True
                    End If
                End If

                Me.ProcessValidation(vPassed, vErrorCritical, vErrorWarning, vErrorStr, vTmpStr, txtPrompt, "")
            End With

            ' 3. check if category is not ""                                                                        Critical
            vTmpStr = "Validating PETC Category if with value"
            txtPrompt.Text = txtPrompt.Text & vTmpStr & "..."

            vPassed = False
            With frmPetcManagerImport
                vTmpStr2 = .lsvItems.Items(0).SubItems(5).Text
                If Trim(.lsvItems.Items(0).SubItems(5).Text) = "" Then
                    'empty
                Else
                    vPassed = True
                End If

                Me.ProcessValidation(vPassed, vErrorCritical, vErrorWarning, vErrorStr, vTmpStr, txtPrompt, "")
            End With

            ' 4. check if business types is not ""                                                                  Critical
            vTmpStr = "Validating PETC Business Type if with value"
            txtPrompt.Text = txtPrompt.Text & vTmpStr & "..."

            vPassed = False
            With frmPetcManagerImport
                vTmpStr2 = .lsvItems.Items(0).SubItems(8).Text
                If Trim(.lsvItems.Items(0).SubItems(8).Text) = "" Then
                    'empty
                Else
                    vPassed = True
                End If

                Me.ProcessValidation(vPassed, vErrorCritical, vErrorWarning, vErrorStr, vTmpStr, txtPrompt, "")
            End With

            ' 5. check if petc name is not ""                                                                       Critical
            vTmpStr = "Validating PETC Name if with value"
            txtPrompt.Text = txtPrompt.Text & vTmpStr & "..."

            vPassed = False
            With frmPetcManagerImport
                vTmpStr2 = .lsvItems.Items(0).SubItems(1).Text
                If Trim(.lsvItems.Items(0).SubItems(1).Text) = "" Then
                    'empty
                Else
                    vPassed = True
                End If

                Me.ProcessValidation(vPassed, vErrorCritical, vErrorWarning, vErrorStr, vTmpStr, txtPrompt, "")
            End With

            ' 6. check if petc address is not ""                                                                    Critical
            vTmpStr = "Validating PETC Address if with value"
            txtPrompt.Text = txtPrompt.Text & vTmpStr & "..."

            vPassed = False
            With frmPetcManagerImport
                vTmpStr2 = .lsvItems.Items(0).SubItems(6).Text
                If Trim(.lsvItems.Items(0).SubItems(6).Text) = "" Then
                    'empty
                Else
                    vPassed = True
                End If

                Me.ProcessValidation(vPassed, vErrorCritical, vErrorWarning, vErrorStr, vTmpStr, txtPrompt, "")
            End With

            ' 7. check if petc status is "0", "1", "2", "3"                                                         Critical
            vTmpStr = "Validating PETC Status value"
            txtPrompt.Text = txtPrompt.Text & vTmpStr & "..."

            vPassed = False
            With frmPetcManagerImport
                vTmpStr2 = .lsvItems.Items(0).SubItems(3).Text
                If Trim(.lsvItems.Items(0).SubItems(3).Text) = "" Or LCase(Trim(.lsvItems.Items(0).SubItems(3).Text)) = "unknown" Then
                    'not valid status
                Else
                    vPassed = True
                End If

                Me.ProcessValidation(vPassed, vErrorCritical, vErrorWarning, vErrorStr, vTmpStr, txtPrompt, "")
            End With

            ' 8. check if petc account id is not ""                                                                      Critical
            vTmpStr = "Validating PETC Account ID if with value"
            txtPrompt.Text = txtPrompt.Text & vTmpStr & "..."

            vPassed = False
            With frmPetcManagerImport
                vTmpStr2 = .lsvItems.Items(0).SubItems(21).Text
                If Trim(.lsvItems.Items(0).SubItems(21).Text) = "" Then
                    'empty
                Else
                    vPassed = True
                End If

                Me.ProcessValidation(vPassed, vErrorCritical, vErrorWarning, vErrorStr, vTmpStr, txtPrompt, "")
            End With

            ' 9. check if petc region is not ""                                                                     Critical
            vTmpStr = "Validating PETC Region if with value"
            txtPrompt.Text = txtPrompt.Text & vTmpStr & "..."

            vPassed = False
            With frmPetcManagerImport
                vTmpStr2 = .lsvItems.Items(0).SubItems(20).Text
                If Trim(.lsvItems.Items(0).SubItems(20).Text) = "" Then
                    'empty
                Else
                    vPassed = True
                End If

                Me.ProcessValidation(vPassed, vErrorCritical, vErrorWarning, vErrorStr, vTmpStr, txtPrompt, "")
            End With

            '10. check if petc province is not ""                                                                   Critical
            vTmpStr = "Validating PETC Province if with value"
            txtPrompt.Text = txtPrompt.Text & vTmpStr & "..."

            vPassed = False
            With frmPetcManagerImport
                vTmpStr2 = .lsvItems.Items(0).SubItems(19).Text
                If Trim(.lsvItems.Items(0).SubItems(19).Text) = "" Then
                    'empty
                Else
                    vPassed = True
                End If

                Me.ProcessValidation(vPassed, vErrorCritical, vErrorWarning, vErrorStr, vTmpStr, txtPrompt, "")
            End With

            '11. check if petc lto service area is not ""                                                           Critical
            vTmpStr = "Validating PETC LTO Service Area if with value"
            txtPrompt.Text = txtPrompt.Text & vTmpStr & "..."

            vPassed = False
            With frmPetcManagerImport
                vTmpStr2 = .lsvItems.Items(0).SubItems(9).Text
                If Trim(.lsvItems.Items(0).SubItems(9).Text) = "" Then
                    'empty
                Else
                    vPassed = True
                End If

                Me.ProcessValidation(vPassed, vErrorCritical, vErrorWarning, vErrorStr, vTmpStr, txtPrompt, "")
            End With

            '12. check if petc dti accreditation no. is not ""                                                      Critical
            vTmpStr = "Validating PETC DTI Accreditation Number if with value"
            txtPrompt.Text = txtPrompt.Text & vTmpStr & "..."

            vPassed = False
            With frmPetcManagerImport
                vTmpStr2 = .lsvItems.Items(0).SubItems(10).Text
                If Trim(.lsvItems.Items(0).SubItems(10).Text) = "" Then
                    'empty
                Else
                    vPassed = True
                End If

                Me.ProcessValidation(vPassed, vErrorCritical, vErrorWarning, vErrorStr, vTmpStr, txtPrompt, "")
            End With

            '13. check if petc lto authorization no. is no ""                                                       Critical
            vTmpStr = "Validating PETC LTO Authorization Number if with value"
            txtPrompt.Text = txtPrompt.Text & vTmpStr & "..."

            vPassed = False
            With frmPetcManagerImport
                vTmpStr2 = .lsvItems.Items(0).SubItems(11).Text
                If Trim(.lsvItems.Items(0).SubItems(11).Text) = "" Then
                    'empty
                Else
                    vPassed = True
                End If

                Me.ProcessValidation(vPassed, vErrorCritical, vErrorWarning, vErrorStr, vTmpStr, txtPrompt, "")
            End With

            '14. check if petc account type is "1" (postpaid) or "2" (prepaid)                                      Critical
            vTmpStr = "Validating PETC Account Type value"
            txtPrompt.Text = txtPrompt.Text & vTmpStr & "..."

            vPassed = False
            With frmPetcManagerImport
                vTmpStr2 = .lsvItems.Items(0).SubItems(27).Text
                Select Case .lsvItems.Items(0).SubItems(27).Text
                    Case "1", "2"
                        vPassed = True

                    Case Else
                        'invalid or no value
                End Select

                Me.ProcessValidation(vPassed, vErrorCritical, vErrorWarning, vErrorStr, vTmpStr, txtPrompt, "")
            End With

            '15. check if petc transmission fee is not "" or "0"                                                    Critical
            vTmpStr = "Validating PETC Transmission Fee value"
            txtPrompt.Text = txtPrompt.Text & vTmpStr & "..."

            vPassed = False
            With frmPetcManagerImport
                vTmpStr2 = .lsvItems.Items(0).SubItems(26).Text
                If IsNumeric(.lsvItems.Items(0).SubItems(26).Text) = False Then
                    'invalid value
                Else
                    vPassed = True
                End If

                Me.ProcessValidation(vPassed, vErrorCritical, vErrorWarning, vErrorStr, vTmpStr, txtPrompt, "")
            End With

            '16. check if petc stradcom fee is not "" or "0"                                                        Critical
            vTmpStr = "Validating PETC Stradcom Fee value"
            txtPrompt.Text = txtPrompt.Text & vTmpStr & "..."

            vPassed = False
            With frmPetcManagerImport
                vTmpStr2 = .lsvItems.Items(0).SubItems(29).Text
                If IsNumeric(.lsvItems.Items(0).SubItems(29).Text) = False Then
                    'invalid value
                Else
                    vPassed = True
                End If

                Me.ProcessValidation(vPassed, vErrorCritical, vErrorWarning, vErrorStr, vTmpStr, txtPrompt, "")
            End With

            '17. if account type is "1" postpaid - max credit must be > 0                                           Critical
            vTmpStr = "Validating PETC Post-paid value"
            txtPrompt.Text = txtPrompt.Text & vTmpStr & "..."

            vPassed = False
            With frmPetcManagerImport
                vTmpStr2 = .lsvItems.Items(0).SubItems(30).Text
                If .lsvItems.Items(0).SubItems(27).Text = "1" Then
                    If IsNumeric(.lsvItems.Items(0).SubItems(30).Text) = False Then
                        'invalid value
                    Else
                        If CDbl(.lsvItems.Items(0).SubItems(30).Text) > 0 Then
                            vPassed = True
                        End If
                    End If
                Else
                    vPassed = True
                End If

                Me.ProcessValidation(vPassed, vErrorCritical, vErrorWarning, vErrorStr, vTmpStr, txtPrompt, "")
            End With

            '18. if account type is "2" prepaid - max credit must be <= 0                                           Critical
            vTmpStr = "Validating PETC Pre-paid value"
            txtPrompt.Text = txtPrompt.Text & vTmpStr & "..."

            vPassed = False
            With frmPetcManagerImport
                vTmpStr2 = .lsvItems.Items(0).SubItems(30).Text
                If .lsvItems.Items(0).SubItems(27).Text = "2" Then
                    If IsNumeric(.lsvItems.Items(0).SubItems(30).Text) = False Then
                        'invalid value
                    Else
                        If CDbl(.lsvItems.Items(0).SubItems(30).Text) <= 0 Then
                            vPassed = True
                        End If
                    End If
                Else
                    vPassed = True
                End If

                Me.ProcessValidation(vPassed, vErrorCritical, vErrorWarning, vErrorStr, vTmpStr, txtPrompt, "")
            End With

            '19. check if petc gm must be 16 chars and each character must be "1" or "0"                            Critical
            vTmpStr = "Validating PETC GM value"
            txtPrompt.Text = txtPrompt.Text & vTmpStr & "..."

            vPassed = False
            With frmPetcManagerImport
                vTmpStr2 = .lsvItems.Items(0).SubItems(18).Text
                If Len(.lsvItems.Items(0).SubItems(18).Text) <> 16 Then
                    'invalid value
                Else
                    vPassed = True
                    For vCtr = 1 To Len(.lsvItems.Items(0).SubItems(18).Text)
                        Select Case Mid(.lsvItems.Items(0).SubItems(18).Text, vCtr, 1)
                            Case "1", "0"

                            Case Else
                                vPassed = False
                        End Select
                    Next
                End If

                Me.ProcessValidation(vPassed, vErrorCritical, vErrorWarning, vErrorStr, vTmpStr, txtPrompt, "")
            End With

            '20. check if petc code is already present in tb_petcs                                                  Critical
            vTmpStr = "Validating if PETC Code is already existing in PETC records"
            txtPrompt.Text = txtPrompt.Text & vTmpStr & "..."

            vPassed = False

            vTmpID = vPetcCode
            vQuery = "SELECT petc_code FROM tb_petcs WHERE petc_code = '" & modModule.CorrectSqlString(vTmpID) & "'"

            'create query
            vMyPgCmd = New NpgsqlCommand(vQuery, vMyPgCon)

            'execute query
            vMyPgRd = vMyPgCmd.ExecuteReader()

            'read values
            vFound = vMyPgRd.Read

            If vFound = False Then
                'no record found

                vPassed = True
            Else
                'already existing
            End If

            'close and dispose to avoid memory leak
            vMyPgRd.Close()
            vMyPgCmd.Dispose()

            Me.ProcessValidation(vPassed, vErrorCritical, vErrorWarning, vErrorStr, vTmpStr, txtPrompt, "")

            '21. check if petc code is already present in tb_petc_balance                                           Critical
            vTmpStr = "Validating if PETC Code is already existing in PETC Accounting records"
            txtPrompt.Text = txtPrompt.Text & vTmpStr & "..."

            vPassed = False

            vTmpID = vPetcCode
            vQuery = "SELECT petc_code FROM tb_petc_balance WHERE petc_code = '" & modModule.CorrectSqlString(vTmpID) & "'"

            'create query
            vMyPgCmd = New NpgsqlCommand(vQuery, vMyPgCon)

            'execute query
            vMyPgRd = vMyPgCmd.ExecuteReader()

            'read values
            vFound = vMyPgRd.Read

            If vFound = False Then
                'no record found

                vPassed = True
            Else
                'already existing
            End If

            'close and dispose to avoid memory leak
            vMyPgRd.Close()
            vMyPgCmd.Dispose()

            Me.ProcessValidation(vPassed, vErrorCritical, vErrorWarning, vErrorStr, vTmpStr, txtPrompt, "")

            '22. check if petc code is already present in tb_petc_test                                              Critical
            vTmpStr = "Validating if PETC Code is already existing in PETC Test records"
            txtPrompt.Text = txtPrompt.Text & vTmpStr & "..."

            vPassed = False

            vTmpID = vPetcCode
            vQuery = "SELECT petc_code FROM tb_petc_test WHERE petc_code = '" & modModule.CorrectSqlString(vTmpID) & "'"

            'create query
            vMyPgCmd = New NpgsqlCommand(vQuery, vMyPgCon)

            'execute query
            vMyPgRd = vMyPgCmd.ExecuteReader()

            'read values
            vFound = vMyPgRd.Read

            If vFound = False Then
                'no record found

                vPassed = True
            Else
                'already existing
            End If

            'close and dispose to avoid memory leak
            vMyPgRd.Close()
            vMyPgCmd.Dispose()

            Me.ProcessValidation(vPassed, vErrorCritical, vErrorWarning, vErrorStr, vTmpStr, txtPrompt, "")

            '23. check if region is present in tb_region_codes                                                    Critical
            vTmpStr = "Validating if PETC Region is in Region records"
            txtPrompt.Text = txtPrompt.Text & vTmpStr & "..."

            vPassed = False

            vTmpID = frmPetcManagerImport.lsvItems.Items(0).SubItems(20).Text
            vQuery = "SELECT region_code FROM tb_region_codes WHERE region_code = '" & modModule.CorrectSqlString(vTmpID) & "'"

            'create query
            vMyPgCmd = New NpgsqlCommand(vQuery, vMyPgCon)

            'execute query
            vMyPgRd = vMyPgCmd.ExecuteReader()

            'read values
            vFound = vMyPgRd.Read

            If vFound = False Then
                'no record found
            Else
                'found in record

                vPassed = True
            End If

            'close and dispose to avoid memory leak
            vMyPgRd.Close()
            vMyPgCmd.Dispose()

            Me.ProcessValidation(vPassed, vErrorCritical, vErrorWarning, vErrorStr, vTmpStr, txtPrompt, "")

            '24. check if region + province is present in tb_region_province_city where region and province are match                 Critical
            vTmpStr = "Validating if PETC Region/Province/City is in record"
            txtPrompt.Text = txtPrompt.Text & vTmpStr & "..."

            vPassed = False

            vTmpID = frmPetcManagerImport.lsvItems.Items(0).SubItems(20).Text
            vTmpID2 = frmPetcManagerImport.lsvItems.Items(0).SubItems(19).Text
            vTmpID3 = frmPetcManagerImport.lsvItems.Items(0).SubItems(9).Text
            vQuery = "SELECT recno FROM tb_region_province_city WHERE region = '" & modModule.CorrectSqlString(vTmpID) & "' AND " & _
                "province = '" & modModule.CorrectSqlString(vTmpID2) & "' AND town_city = '" & modModule.CorrectSqlString(vTmpID3) & "'"

            'create query
            vMyPgCmd = New NpgsqlCommand(vQuery, vMyPgCon)

            'execute query
            vMyPgRd = vMyPgCmd.ExecuteReader()

            'read values
            vFound = vMyPgRd.Read

            If vFound = False Then
                'no record found
            Else
                'found in record

                vPassed = True
            End If

            'close and dispose to avoid memory leak
            vMyPgRd.Close()
            vMyPgCmd.Dispose()

            Me.ProcessValidation(vPassed, vErrorCritical, vErrorWarning, vErrorStr, vTmpStr, txtPrompt, "")

            '25. check if account_id is present in tb_client_accounts                                               Critical
            vTmpStr = "Validating if PETC owner Account ID is in record"
            txtPrompt.Text = txtPrompt.Text & vTmpStr & "..."

            vPassed = False

            vTmpID = frmPetcManagerImport.lsvItems.Items(0).SubItems(21).Text
            vQuery = "SELECT account_id FROM tb_client_accounts WHERE account_id = '" & modModule.CorrectSqlString(vTmpID) & "'"

            'create query
            vMyPgCmd = New NpgsqlCommand(vQuery, vMyPgCon)

            'execute query
            vMyPgRd = vMyPgCmd.ExecuteReader()

            'read values
            vFound = vMyPgRd.Read

            If vFound = False Then
                'no record found
            Else
                'found in record

                vPassed = True
            End If

            'close and dispose to avoid memory leak
            vMyPgRd.Close()
            vMyPgCmd.Dispose()

            Me.ProcessValidation(vPassed, vErrorCritical, vErrorWarning, vErrorStr, vTmpStr, txtPrompt, "")

            '26. check if account_manager is present in tb_managing_accounts                                        Critical
            vTmpStr = "Validating if PETC Account Manager is in record"
            txtPrompt.Text = txtPrompt.Text & vTmpStr & "..."

            vPassed = False

            vTmpID = frmPetcManagerImport.lsvItems.Items(0).SubItems(22).Text
            If Trim(vTmpID) = "" Then
                vPassed = True
            Else
                vQuery = "SELECT account_id FROM tb_managing_accounts WHERE account_id = '" & modModule.CorrectSqlString(vTmpID) & "'"

                'create query
                vMyPgCmd = New NpgsqlCommand(vQuery, vMyPgCon)

                'execute query
                vMyPgRd = vMyPgCmd.ExecuteReader()

                'read values
                vFound = vMyPgRd.Read

                If vFound = False Then
                    'no record found
                Else
                    'found in record

                    vPassed = True
                End If

                'close and dispose to avoid memory leak
                vMyPgRd.Close()
                vMyPgCmd.Dispose()
            End If

            Me.ProcessValidation(vPassed, vErrorCritical, vErrorWarning, vErrorStr, vTmpStr, txtPrompt, "")

            '27. check if tech_manager is present in tb_managing_accounts                                           Critical
            vTmpStr = "Validating if PETC Technical Manager is in record"
            txtPrompt.Text = txtPrompt.Text & vTmpStr & "..."

            vPassed = False

            vTmpID = frmPetcManagerImport.lsvItems.Items(0).SubItems(23).Text
            If Trim(vTmpID) = "" Then
                vPassed = True
            Else
                vQuery = "SELECT account_id FROM tb_managing_accounts WHERE account_id = '" & modModule.CorrectSqlString(vTmpID) & "'"

                'create query
                vMyPgCmd = New NpgsqlCommand(vQuery, vMyPgCon)

                'execute query
                vMyPgRd = vMyPgCmd.ExecuteReader()

                'read values
                vFound = vMyPgRd.Read

                If vFound = False Then
                    'no record found
                Else
                    'found in record

                    vPassed = True
                End If

                'close and dispose to avoid memory leak
                vMyPgRd.Close()
                vMyPgCmd.Dispose()
            End If

            Me.ProcessValidation(vPassed, vErrorCritical, vErrorWarning, vErrorStr, vTmpStr, txtPrompt, "")

            '28. check if marketing_agent is present in tb_managing_accounts                                        Critical
            vTmpStr = "Validating if PETC Marketing Agent is in record"
            txtPrompt.Text = txtPrompt.Text & vTmpStr & "..."

            vPassed = False

            vTmpID = frmPetcManagerImport.lsvItems.Items(0).SubItems(24).Text
            If Trim(vTmpID) = "" Then
                vPassed = True
            Else
                vQuery = "SELECT account_id FROM tb_managing_accounts WHERE account_id = '" & modModule.CorrectSqlString(vTmpID) & "'"

                'create query
                vMyPgCmd = New NpgsqlCommand(vQuery, vMyPgCon)

                'execute query
                vMyPgRd = vMyPgCmd.ExecuteReader()

                'read values
                vFound = vMyPgRd.Read

                If vFound = False Then
                    'no record found
                Else
                    'found in record

                    vPassed = True
                End If

                'close and dispose to avoid memory leak
                vMyPgRd.Close()
                vMyPgCmd.Dispose()
            End If

            Me.ProcessValidation(vPassed, vErrorCritical, vErrorWarning, vErrorStr, vTmpStr, txtPrompt, "")

            '----------------------------------------------- END of PETC -------------------------------------------------------

            lblPrompt.Text = "Validating imported Terminals data..."
            lblPrompt.Refresh()

            For vRowCtr = 1 To frmPetcManagerImport.lsvTerminals.Items.Count
                txtPrompt.Text = txtPrompt.Text & vbCrLf & "Validating imported Terminals data: Record " & vRowCtr.ToString & vbCrLf

                'TERMINALS:                                                                                             Category
                '---------------------------------------------------------------------------------------------------------------
                ' 1. check if terminal id is present                                                                    Critical
                vTmpStr = "Validating Terminal ID if with value"
                txtPrompt.Text = txtPrompt.Text & vTmpStr & "..."

                vPassed = False
                With frmPetcManagerImport
                    vTmpStr2 = .lsvTerminals.Items(vRowCtr - 1).Text
                    If Trim(.lsvTerminals.Items(vRowCtr - 1).Text) = "" Then
                        'empty
                    Else
                        vPassed = True
                    End If

                    Me.ProcessValidation(vPassed, vErrorCritical, vErrorWarning, vErrorStr, vTmpStr, txtPrompt, vRowCtr)
                End With

                ' 2. check if petc code is present and same with petc code being processed                              Critical
                vTmpStr = "Validating PETC Code in Terminal data is correct"
                txtPrompt.Text = txtPrompt.Text & vTmpStr & "..."

                vPassed = False
                With frmPetcManagerImport
                    vTmpStr2 = vPetcCode
                    If .lsvTerminals.Items(vRowCtr - 1).SubItems(7).Text <> vPetcCode Then
                        'not the same
                    Else
                        vPassed = True
                    End If

                    Me.ProcessValidation(vPassed, vErrorCritical, vErrorWarning, vErrorStr, vTmpStr, txtPrompt, vRowCtr)
                End With

                ' 3. check if terminal id format is "PETC:xxxx"                                                         Critical
                vTmpStr = "Validating Terminal ID if in correct format"
                txtPrompt.Text = txtPrompt.Text & vTmpStr & "..."

                vPassed = False
                With frmPetcManagerImport
                    vTmpStr2 = .lsvTerminals.Items(vRowCtr - 1).Text
                    If Len(.lsvTerminals.Items(vRowCtr - 1).Text) <= 5 Or Mid(.lsvTerminals.Items(vRowCtr - 1).Text, 1, 5) <> "PETC:" Then
                        'incorrect format
                    Else
                        vPassed = True
                    End If

                    Me.ProcessValidation(vPassed, vErrorCritical, vErrorWarning, vErrorStr, vTmpStr, txtPrompt, vRowCtr)
                End With

                ' 4. check if petc code is not "tech.support"                                                           Critical
                vTmpStr = "Validating PETC Code of Terminal data is correct"
                txtPrompt.Text = txtPrompt.Text & vTmpStr & "..."

                vPassed = False
                With frmPetcManagerImport
                    vTmpStr2 = .lsvTerminals.Items(vRowCtr - 1).SubItems(7).Text
                    If LCase(Trim(.lsvTerminals.Items(vRowCtr - 1).SubItems(7).Text)) = "tech.support" Then
                        'incorrect
                    Else
                        vPassed = True
                    End If

                    Me.ProcessValidation(vPassed, vErrorCritical, vErrorWarning, vErrorStr, vTmpStr, txtPrompt, vRowCtr)
                End With

                ' 5. check if terminal type is present and must be either "gas" or "diesel"                             Critical
                vTmpStr = "Validating Terminal Type value"
                txtPrompt.Text = txtPrompt.Text & vTmpStr & "..."

                vPassed = False
                With frmPetcManagerImport
                    vTmpStr2 = .lsvTerminals.Items(vRowCtr - 1).SubItems(2).Text
                    Select Case .lsvTerminals.Items(vRowCtr - 1).SubItems(2).Text
                        Case "gas", "diesel"
                            vPassed = True

                        Case Else
                    End Select

                    Me.ProcessValidation(vPassed, vErrorCritical, vErrorWarning, vErrorStr, vTmpStr, txtPrompt, vRowCtr)
                End With

                ' 6. check if terminal lane is numeric and must not be "" or "0"                                        Critical
                vTmpStr = "Validating Terminal Lane value"
                txtPrompt.Text = txtPrompt.Text & vTmpStr & "..."

                vPassed = False
                With frmPetcManagerImport
                    vTmpStr2 = .lsvTerminals.Items(vRowCtr - 1).SubItems(8).Text
                    If IsNumeric(.lsvTerminals.Items(vRowCtr - 1).SubItems(8).Text) = False Then
                        'not numeric
                    Else
                        Select Case CDbl(.lsvTerminals.Items(vRowCtr - 1).SubItems(8).Text)
                            Case 1, 2, 3, 4, 5, 6, 7, 8, 9, 10
                                vPassed = True

                            Case Else
                                'invalid
                        End Select
                    End If

                    Me.ProcessValidation(vPassed, vErrorCritical, vErrorWarning, vErrorStr, vTmpStr, txtPrompt, vRowCtr)
                End With

                ' 7. check if terminal serial is present                                                                Critical
                vTmpStr = "Validating Terminal HDD Serial if with value"
                txtPrompt.Text = txtPrompt.Text & vTmpStr & "..."

                vPassed = False
                With frmPetcManagerImport
                    vTmpStr2 = .lsvTerminals.Items(vRowCtr - 1).SubItems(3).Text
                    If Trim(.lsvTerminals.Items(vRowCtr - 1).SubItems(3).Text) = "" Then
                        'empty
                    Else
                        vPassed = True
                    End If

                    Me.ProcessValidation(vPassed, vErrorCritical, vErrorWarning, vErrorStr, vTmpStr, txtPrompt, vRowCtr)
                End With

                ' 8. check if temrinal status is present and must be "1" or "0"                                         Critical
                vTmpStr = "Validating Terminal Status value"
                txtPrompt.Text = txtPrompt.Text & vTmpStr & "..."

                vPassed = False
                With frmPetcManagerImport
                    vTmpStr2 = .lsvTerminals.Items(vRowCtr - 1).SubItems(6).Text
                    If LCase(Trim(.lsvTerminals.Items(vRowCtr - 1).SubItems(6).Text)) = "unknown" Or LCase(Trim(.lsvTerminals.Items(vRowCtr - 1).SubItems(6).Text)) = "" Then
                        'invalid
                    Else
                        vPassed = True
                    End If

                    Me.ProcessValidation(vPassed, vErrorCritical, vErrorWarning, vErrorStr, vTmpStr, txtPrompt, vRowCtr)
                End With

                ' 9. check if terminal machine description is present                                                   Critical
                vTmpStr = "Validating Terminal Machine Description if with value"
                txtPrompt.Text = txtPrompt.Text & vTmpStr & "..."

                vPassed = False
                With frmPetcManagerImport
                    vTmpStr2 = .lsvTerminals.Items(vRowCtr - 1).SubItems(9).Text
                    If Trim(.lsvTerminals.Items(vRowCtr - 1).SubItems(9).Text) = "" Then
                        'empty
                    Else
                        vPassed = True
                    End If

                    Me.ProcessValidation(vPassed, vErrorCritical, vErrorWarning, vErrorStr, vTmpStr, txtPrompt, vRowCtr)
                End With

                '10. check if terminal machine serial is present                                                        Critical
                vTmpStr = "Validating Terminal Machine Serial if with value"
                txtPrompt.Text = txtPrompt.Text & vTmpStr & "..."

                vPassed = False
                With frmPetcManagerImport
                    vTmpStr2 = .lsvTerminals.Items(vRowCtr - 1).SubItems(10).Text
                    If Trim(.lsvTerminals.Items(vRowCtr - 1).SubItems(10).Text) = "" Then
                        'empty
                    Else
                        vPassed = True
                    End If

                    Me.ProcessValidation(vPassed, vErrorCritical, vErrorWarning, vErrorStr, vTmpStr, txtPrompt, vRowCtr)
                End With

                '11. check if terminal machine calibrated is present and is a valid date                                Critical
                vTmpStr = "Validating Terminal Machine Date of Calibration value"
                txtPrompt.Text = txtPrompt.Text & vTmpStr & "..."

                vPassed = False
                With frmPetcManagerImport
                    vTmpStr2 = .lsvTerminals.Items(vRowCtr - 1).SubItems(11).Text
                    If Trim(.lsvTerminals.Items(vRowCtr - 1).SubItems(11).Text) = "" Then
                        'empty
                    Else
                        If IsDate(.lsvTerminals.Items(vRowCtr - 1).SubItems(11).Text) = False Then
                            'not a valid date
                        Else
                            vPassed = True
                        End If
                    End If

                    Me.ProcessValidation(vPassed, vErrorCritical, vErrorWarning, vErrorStr, vTmpStr, txtPrompt, vRowCtr)
                End With

                '12. check if terminal id is already present in tb_stations                                             Critical
                vTmpStr = "Validating if Terminal ID is in record"
                txtPrompt.Text = txtPrompt.Text & vTmpStr & "..."

                vPassed = False

                vTmpID = frmPetcManagerImport.lsvTerminals.Items(vRowCtr - 1).Text
                vQuery = "SELECT terminal_id FROM tb_stations WHERE terminal_id = '" & modModule.CorrectSqlString(vTmpID) & "'"

                'create query
                vMyPgCmd = New NpgsqlCommand(vQuery, vMyPgCon)

                'execute query
                vMyPgRd = vMyPgCmd.ExecuteReader()

                'read values
                vFound = vMyPgRd.Read

                If vFound = False Then
                    'no record found

                    vPassed = True
                Else
                    'found in record
                End If

                'close and dispose to avoid memory leak
                vMyPgRd.Close()
                vMyPgCmd.Dispose()

                Me.ProcessValidation(vPassed, vErrorCritical, vErrorWarning, vErrorStr, vTmpStr, txtPrompt, vRowCtr)

                '13. check if petc code is already present in tb_petcs                                                  Critical
                vTmpStr = "Validating if Terminal PETC Code is in record"
                txtPrompt.Text = txtPrompt.Text & vTmpStr & "..."

                vPassed = False

                vTmpID = frmPetcManagerImport.lsvTerminals.Items(vRowCtr - 1).SubItems(7).Text
                vQuery = "SELECT terminal_id FROM tb_stations WHERE petc_code = '" & modModule.CorrectSqlString(vTmpID) & "'"

                'create query
                vMyPgCmd = New NpgsqlCommand(vQuery, vMyPgCon)

                'execute query
                vMyPgRd = vMyPgCmd.ExecuteReader()

                'read values
                vFound = vMyPgRd.Read

                If vFound = False Then
                    'no record found
                    vPassed = True
                Else
                    'found in record
                End If

                'close and dispose to avoid memory leak
                vMyPgRd.Close()
                vMyPgCmd.Dispose()

                Me.ProcessValidation(vPassed, vErrorCritical, vErrorWarning, vErrorStr, vTmpStr, txtPrompt, vRowCtr)

                '14. check if terminal lane and petc code is already present in tb_stations                             Critical
                vTmpStr = "Validating if Terminal Lane is already in record"
                txtPrompt.Text = txtPrompt.Text & vTmpStr & "..."

                vPassed = False

                vTmpID = frmPetcManagerImport.lsvTerminals.Items(vRowCtr - 1).SubItems(7).Text
                vTmpID2 = frmPetcManagerImport.lsvTerminals.Items(vRowCtr - 1).SubItems(8).Text
                vQuery = "SELECT terminal_id FROM tb_stations WHERE petc_code = '" & modModule.CorrectSqlString(vTmpID) & "' AND " & _
                    "petc_lane = '" & modModule.CorrectSqlString(vTmpID2) & "' AND is_active = 1"

                'create query
                vMyPgCmd = New NpgsqlCommand(vQuery, vMyPgCon)

                'execute query
                vMyPgRd = vMyPgCmd.ExecuteReader()

                'read values
                vFound = vMyPgRd.Read

                If vFound = False Then
                    'no record found
                    vPassed = True
                Else
                    'found in record
                End If

                'close and dispose to avoid memory leak
                vMyPgRd.Close()
                vMyPgCmd.Dispose()

                Me.ProcessValidation(vPassed, vErrorCritical, vErrorWarning, vErrorStr, vTmpStr, txtPrompt, vRowCtr)
            Next

            '----------------------------------------------- END of TERMINALS -------------------------------------------------------

            lblPrompt.Text = "Validating imported Users data..."
            lblPrompt.Refresh()

            For vRowCtr = 1 To frmPetcManagerImport.lsvUsers.Items.Count
                txtPrompt.Text = txtPrompt.Text & vbCrLf & "Validating imported Users data: Record " & vRowCtr.ToString & vbCrLf

                'USERS:                                                                                                 Category
                '---------------------------------------------------------------------------------------------------------------
                ' 1. check if user id is present                                                                        Critical
                vTmpStr = "Validating User ID if with value"
                txtPrompt.Text = txtPrompt.Text & vTmpStr & "..."

                vPassed = False
                With frmPetcManagerImport
                    vTmpStr2 = .lsvUsers.Items(vRowCtr - 1).Text
                    If Trim(.lsvUsers.Items(vRowCtr - 1).Text) = "" Then
                        'empty
                    Else
                        vPassed = True
                    End If

                    Me.ProcessValidation(vPassed, vErrorCritical, vErrorWarning, vErrorStr, vTmpStr, txtPrompt, vRowCtr)
                End With

                ' 2. check if name is present                                                                     Critical
                vTmpStr = "Validating User Name if with value"
                txtPrompt.Text = txtPrompt.Text & vTmpStr & "..."

                vPassed = False
                With frmPetcManagerImport
                    vTmpStr2 = .lsvUsers.Items(vRowCtr - 1).SubItems(1).Text
                    If Trim(.lsvUsers.Items(vRowCtr - 1).SubItems(1).Text) = "" Then
                        'empty
                    Else
                        vPassed = True
                    End If

                    Me.ProcessValidation(vPassed, vErrorCritical, vErrorWarning, vErrorStr, vTmpStr, txtPrompt, vRowCtr)
                End With

                ' 3. check if user type is present and must be "petc_technician" or "petc_encoder"                      Critical
                vTmpStr = "Validating User Type value"
                txtPrompt.Text = txtPrompt.Text & vTmpStr & "..."

                vPassed = False
                With frmPetcManagerImport
                    vTmpStr2 = .lsvUsers.Items(vRowCtr - 1).SubItems(2).Text
                    If Trim(.lsvUsers.Items(vRowCtr - 1).SubItems(2).Text) = "" Then
                        'empty
                    Else
                        Select Case .lsvUsers.Items(vRowCtr - 1).SubItems(2).Text
                            Case "petc_technician", "petc_encoder"
                                vPassed = True

                            Case Else
                                'invalid type
                        End Select
                    End If

                    Me.ProcessValidation(vPassed, vErrorCritical, vErrorWarning, vErrorStr, vTmpStr, txtPrompt, vRowCtr)
                End With

                ' 4. check if petc code is present and same with petc code being processed                              Critical
                vTmpStr = "Validating User PETC Code value"
                txtPrompt.Text = txtPrompt.Text & vTmpStr & "..."

                vPassed = False
                With frmPetcManagerImport
                    vTmpStr2 = .lsvUsers.Items(vRowCtr - 1).SubItems(3).Text
                    If Trim(.lsvUsers.Items(vRowCtr - 1).SubItems(3).Text) = "" Then
                        'empty
                    Else
                        If .lsvUsers.Items(vRowCtr - 1).SubItems(3).Text <> vPetcCode Then
                            'invalid value
                        Else
                            vPassed = True
                        End If
                    End If

                    Me.ProcessValidation(vPassed, vErrorCritical, vErrorWarning, vErrorStr, vTmpStr, txtPrompt, vRowCtr)
                End With

                ' 5. check if user status is present and must be "0" or "1"                                             Critical
                vTmpStr = "Validating User Status value"
                txtPrompt.Text = txtPrompt.Text & vTmpStr & "..."

                vPassed = False
                With frmPetcManagerImport
                    vTmpStr2 = .lsvUsers.Items(vRowCtr - 1).SubItems(4).Text
                    If Trim(.lsvUsers.Items(vRowCtr - 1).SubItems(4).Text) = "" Or LCase(Trim(.lsvUsers.Items(vRowCtr - 1).SubItems(4).Text) = "unknown") Then
                        'empty
                    Else
                        vPassed = True
                    End If

                    Me.ProcessValidation(vPassed, vErrorCritical, vErrorWarning, vErrorStr, vTmpStr, txtPrompt, vRowCtr)
                End With

                ' 6. check if user password is present                                                                  Critical
                vTmpStr = "Validating User Password value"
                txtPrompt.Text = txtPrompt.Text & vTmpStr & "..."

                vPassed = True          'no record loaded in listview
                Me.ProcessValidation(vPassed, vErrorCritical, vErrorWarning, vErrorStr, vTmpStr, txtPrompt, vRowCtr)

                ' 7. if user is "petc_technician", check if tesda cert no. is present                                   Critical
                vTmpStr = "Validating User TESDA Certification Number value"
                txtPrompt.Text = txtPrompt.Text & vTmpStr & "..."

                vPassed = False
                With frmPetcManagerImport
                    vTmpStr2 = .lsvUsers.Items(vRowCtr - 1).SubItems(7).Text
                    Select Case LCase(Trim(.lsvUsers.Items(vRowCtr - 1).SubItems(2).Text))
                        Case "petc_technician"
                            If Trim(.lsvUsers.Items(vRowCtr - 1).SubItems(7).Text) = "" Then
                                'empty
                            Else
                                vPassed = True
                            End If

                        Case Else
                            vPassed = True
                    End Select

                    Me.ProcessValidation(vPassed, vErrorCritical, vErrorWarning, vErrorStr, vTmpStr, txtPrompt, vRowCtr)
                End With

                ' 8. if user is "petc_technician", check if tesda expiration is present                                 Critical
                vTmpStr = "Validating User TESDA Certification Expiration value"
                txtPrompt.Text = txtPrompt.Text & vTmpStr & "..."

                vPassed = False
                With frmPetcManagerImport
                    vTmpStr2 = .lsvUsers.Items(vRowCtr - 1).SubItems(8).Text
                    Select Case LCase(Trim(.lsvUsers.Items(vRowCtr - 1).SubItems(2).Text))
                        Case "petc_technician"
                            If Trim(.lsvUsers.Items(vRowCtr - 1).SubItems(8).Text) = "" Then
                                'empty
                            Else
                                If IsDate(.lsvUsers.Items(vRowCtr - 1).SubItems(8).Text) = False Then
                                    'invalid
                                Else
                                    vPassed = True
                                End If
                            End If

                        Case Else
                            vPassed = True
                    End Select

                    Me.ProcessValidation(vPassed, vErrorCritical, vErrorWarning, vErrorStr, vTmpStr, txtPrompt, vRowCtr)
                End With

                ' 9. check if user id + petc code is already present in tb_users                                        Critical
                vTmpStr = "Validating if User and PETC Code is already in record"
                txtPrompt.Text = txtPrompt.Text & vTmpStr & "..."

                vPassed = False

                vTmpID = frmPetcManagerImport.lsvUsers.Items(vRowCtr - 1).Text
                vQuery = "SELECT recno FROM tb_users WHERE petc_code = '" & modModule.CorrectSqlString(vPetcCode) & "' AND " & _
                    "user_id = '" & modModule.CorrectSqlString(vTmpID) & "'"

                'create query
                vMyPgCmd = New NpgsqlCommand(vQuery, vMyPgCon)

                'execute query
                vMyPgRd = vMyPgCmd.ExecuteReader()

                'read values
                vFound = vMyPgRd.Read

                If vFound = False Then
                    'no record found
                    vPassed = True
                Else
                    'found in record
                End If

                'close and dispose to avoid memory leak
                vMyPgRd.Close()
                vMyPgCmd.Dispose()

                Me.ProcessValidation(vPassed, vErrorCritical, vErrorWarning, vErrorStr, vTmpStr, txtPrompt, vRowCtr)

                '10. if user is "petc_technician", check if tesda cert no. + active is already present in tb_users      Critical
                vTmpStr = "Validating User TESDA Certification Number if existing in record"
                txtPrompt.Text = txtPrompt.Text & vTmpStr & "..."

                vPassed = False
                With frmPetcManagerImport
                    vTmpStr2 = .lsvUsers.Items(vRowCtr - 1).SubItems(7).Text
                    Select Case LCase(Trim(.lsvUsers.Items(vRowCtr - 1).SubItems(2).Text))
                        Case "petc_technician"
                            vTmpID = frmPetcManagerImport.lsvUsers.Items(vRowCtr - 1).SubItems(7).Text
                            vQuery = "SELECT recno FROM tb_users WHERE certificate_tesda = '" & modModule.CorrectSqlString(vTmpID) & "' AND " & _
                                "is_active = 1"

                            'create query
                            vMyPgCmd = New NpgsqlCommand(vQuery, vMyPgCon)

                            'execute query
                            vMyPgRd = vMyPgCmd.ExecuteReader()

                            'read values
                            vFound = vMyPgRd.Read

                            If vFound = False Then
                                'no record found

                                vPassed = True
                            Else
                                'found in record
                            End If

                            'close and dispose to avoid memory leak
                            vMyPgRd.Close()
                            vMyPgCmd.Dispose()

                        Case Else
                            vPassed = True
                    End Select

                    Me.ProcessValidation(vPassed, vErrorCritical, vErrorWarning, vErrorStr, vTmpStr, txtPrompt, vRowCtr)
                End With

                '11. check if gender is "Male" or "Female" or blank                                                     Critical
                vTmpStr = "Validating User Gender value"
                txtPrompt.Text = txtPrompt.Text & vTmpStr & "..."

                vPassed = False
                With frmPetcManagerImport
                    vTmpStr2 = .lsvUsers.Items(vRowCtr - 1).SubItems(6).Text
                    Select Case .lsvUsers.Items(vRowCtr - 1).SubItems(6).Text
                        Case "Male", "Female"
                            vPassed = True

                        Case Else
                            vPassed = True
                    End Select

                    Me.ProcessValidation(vPassed, vErrorCritical, vErrorWarning, vErrorStr, vTmpStr, txtPrompt, vRowCtr)
                End With
            Next

            '----------------------------------------------- END of USERS -------------------------------------------------------

            'General - 5. create log - prepare
            If vErrorCritical > 0 Or vErrorWarning > 0 Then
                txtPrompt.Text = txtPrompt.Text & "Operation halted."
                modModule.GotoTextBoxLastLine(txtPrompt)

                lblHeader.Text = "OPERATION HALTED"
                lblPrompt.Text = "Errors where found. NO PETC, Terminal or User created."

                lblHeader.Refresh()
                lblPrompt.Refresh()

                vTmpStr2 = "No. of errors found: " & vbCrLf & _
                            Space(10) & "Critical: " & vErrorCritical.ToString & vbCrLf & _
                            Space(10) & "Warning: " & vErrorWarning.ToString & vbCrLf & vbCrLf & _
                            "Error remarks: " & vbCrLf & vErrorStr
                vTmpStr = modModule.CreateLog(Me.Name, "PETC Manager - Import PETC - Create", "Errors where found:" & vbCrLf & vTmpStr2)

                pResultStr = Me.Name

                MsgBox("Operation halted." & vbCrLf & vbCrLf & _
                       "Critical errors were found. No records were created." & vbCrLf & vbCrLf & _
                       vTmpStr2 & vbCrLf & vbCrLf & _
                       "Click OK to close and go back to previous menu.", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Operation failed")

                pResultStr = "validation failed"

                Me.Close()

                Exit Sub
            Else
                vTmpStr = modModule.CreateLog(Me.Name, "PETC Manager - Import PETC - Create", "Prepare for database update")
            End If

            'General - 6. create table dump backups

            'create export tables - PETC DATA

            Dim vFileName As String

            'get filename to process
            vFileName = pWorkDirectory & "\Temp\" & Format(Now, "yyyy-MM-dd HH.mm.ss ") & "tb_petcs.tmp"

            vQuery = "COPY tb_petcs TO '" & vFileName & "' CSV"

            'create query
            vMyPgCmd = New NpgsqlCommand(vQuery, vMyPgCon)

            'execute query
            vMyPgCmd.ExecuteNonQuery()

            'close and dispose to avoid memory leak
            vMyPgCmd.Dispose()

            'create export tables - BILLING SUMMARY

            'get filename to process
            vFileName = pWorkDirectory & "\Temp\" & Format(Now, "yyyy-MM-dd HH.mm.ss ") & "tb_petc_balance.tmp"

            vQuery = "COPY tb_petc_balance TO '" & vFileName & "' CSV"

            'create query
            vMyPgCmd = New NpgsqlCommand(vQuery, vMyPgCon)

            'execute query
            vMyPgCmd.ExecuteNonQuery()

            'close and dispose to avoid memory leak
            vMyPgCmd.Dispose()

            'create export tables - BILLING DETAILS

            'get filename to process
            vFileName = pWorkDirectory & "\Temp\" & Format(Now, "yyyy-MM-dd HH.mm.ss ") & "tb_petc_balance_details.tmp"

            vQuery = "COPY tb_petc_balance_details TO '" & vFileName & "' CSV"

            'create query
            vMyPgCmd = New NpgsqlCommand(vQuery, vMyPgCon)

            'execute query
            vMyPgCmd.ExecuteNonQuery()

            'close and dispose to avoid memory leak
            vMyPgCmd.Dispose()

            'create export tables - PETC STATIONS DATA

            'get filename to process
            vFileName = pWorkDirectory & "\Temp\" & Format(Now, "yyyy-MM-dd HH.mm.ss ") & "tb_stations.tmp"

            vQuery = "COPY tb_stations TO '" & vFileName & "' CSV"

            'create query
            vMyPgCmd = New NpgsqlCommand(vQuery, vMyPgCon)

            'execute query
            vMyPgCmd.ExecuteNonQuery()

            'close and dispose to avoid memory leak
            vMyPgCmd.Dispose()

            'create export tables - PETC USERS DATA

            'get filename to process
            vFileName = pWorkDirectory & "\Temp\" & Format(Now, "yyyy-MM-dd HH.mm.ss ") & "tb_users.tmp"

            vQuery = "COPY tb_users TO '" & vFileName & "' CSV"

            'create query
            vMyPgCmd = New NpgsqlCommand(vQuery, vMyPgCon)

            'execute query
            vMyPgCmd.ExecuteNonQuery()

            'close and dispose to avoid memory leak
            vMyPgCmd.Dispose()

            'General - 7. create transaction
            txtPrompt.Text = txtPrompt.Text & vbCrLf &
                "Update database:" & vbCrLf & _
                "Creating PETC record" & "..."

            vQuery = "BEGIN TRANSACTION"

            'create query
            vMyPgCmd = New NpgsqlCommand(vQuery, vMyPgCon)

            'execute query
            vMyPgCmd.ExecuteNonQuery()

            'close and dispose to avoid memory leak
            vMyPgCmd.Dispose()

            txtPrompt.Text = txtPrompt.Text & "done" & vbCrLf

            'Create PETC
            '1. create in tb_petcs
            txtPrompt.Text = txtPrompt.Text & vbCrLf & "Creating PETC record" & "..."

            vQuery = "INSERT INTO tb_petcs (petc_code, petc_lanes, petc_category, petc_name, petc_address, contact_no, business_type, " & _
                "lto_service_area, dti_accreditation_no, lto_authorization_no, date_it_started, date_it_accredited, date_it_renewal, " & _
                "date_petc_started, date_petc_accredited, date_petc_authorized, is_active, description, gm, province, region, " & _
                "account_id, account_manager, tech_manager, marketing_agent, marketing_commission) " & _
                "SELECT '" & modModule.CorrectSqlString(vPetcCode) & "', petc_lanes, petc_category, petc_name, petc_address, contact_no, business_type, " & _
                "lto_service_area, dti_accreditation_no, lto_authorization_no, date_it_started, date_it_accredited, date_it_renewal, " & _
                "date_petc_started, date_petc_accredited, date_petc_authorized, is_active, description, gm, province, region, " & _
                "account_id, account_manager, tech_manager, marketing_agent, marketing_commission FROM tb_tmp_petcs"

            'create query
            vMyPgCmd = New NpgsqlCommand(vQuery, vMyPgCon)

            'execute query
            vMyPgCmd.ExecuteNonQuery()

            'close and dispose to avoid memory leak
            vMyPgCmd.Dispose()

            txtPrompt.Text = txtPrompt.Text & "done" & vbCrLf

            '2. create in tb_petc_balance
            txtPrompt.Text = txtPrompt.Text & "Creating PETC Accounting record" & "..."

            vQuery = "INSERT INTO tb_petc_balance (petc_code, transmission_fee, account_type, balance, remarks, stradcom_fee, max_credit) " & _
                "SELECT '" & modModule.CorrectSqlString(vPetcCode) & "', transmission_fee, account_type, 0, remarks, stradcom_fee, max_credit " & _
                "FROM tb_tmp_petcs"

            'create query
            vMyPgCmd = New NpgsqlCommand(vQuery, vMyPgCon)

            'execute query
            vMyPgCmd.ExecuteNonQuery()

            'close and dispose to avoid memory leak
            vMyPgCmd.Dispose()

            txtPrompt.Text = txtPrompt.Text & "done" & vbCrLf

            '3. create in tb_petc_balance_details

            vQuery = "INSERT INTO tb_petc_balance_details (trans_date, petc_code, ledger_code, ledger_description, debit, credit, balance, remarks, old_balance) " & _
                "SELECT CURRENT_timestamp AT TIME ZONE 'Hongkong', '" & modModule.CorrectSqlString(vPetcCode) & "', '', 'Beginning balance', 0, 0, 0, 'First record', 0"

            'create query
            vMyPgCmd = New NpgsqlCommand(vQuery, vMyPgCon)

            'execute query
            vMyPgCmd.ExecuteNonQuery()

            'close and dispose to avoid memory leak
            vMyPgCmd.Dispose()

            '4. create log
            vTmpStr = modModule.CreateLog(Me.Name, "PETC Manager - Import PETC - Create", "Finished creating new PETC " & modModule.CorrectSqlString(vPetcCode))

            'Create TERMINALS
            '1. create in tb_stations
            txtPrompt.Text = txtPrompt.Text & "Creating Terminals record" & "..."

            vTmpStr = "'PETC:" & modModule.CorrectSqlString(vPetcCode) & "-' || petc_lane"
            vQuery = "INSERT INTO tb_stations (terminal_id, terminal_type, terminal_serial, terminal_mac, terminal_ip, terminal_machine_description, " & _
                "terminal_machine_serial, terminal_machine_calibrated, petc_code, petc_lane, is_active, description, lock_status, " & _
                "dll_file, machine_parity, machine_bits, machine_port, machine_baud_rate, machine_stop_bits, is_scsi) " & _
                "SELECT " & vTmpStr & ", terminal_type, terminal_serial, terminal_mac, terminal_ip, terminal_machine_description, " & _
                "terminal_machine_serial, terminal_machine_calibrated, '" & modModule.CorrectSqlString(vPetcCode) & "', petc_lane, is_active, description, lock_status, " & _
                "dll_file, machine_parity, machine_bits, machine_port, machine_baud_rate, machine_stop_bits, is_scsi FROM tb_tmp_stations"

            'create query
            vMyPgCmd = New NpgsqlCommand(vQuery, vMyPgCon)

            'execute query
            vMyPgCmd.ExecuteNonQuery()

            'close and dispose to avoid memory leak
            vMyPgCmd.Dispose()

            txtPrompt.Text = txtPrompt.Text & "done" & vbCrLf

            '2. create log
            vTmpStr = modModule.CreateLog(Me.Name, "PETC Manager - Import PETC - Create", "Finished creating new Terminals " & modModule.CorrectSqlString(vPetcCode))

            'Create USERS
            '1. create in tb_users
            txtPrompt.Text = txtPrompt.Text & "Creating Users record" & "..."

            vQuery = "INSERT INTO tb_users (user_id, employee_id, password, first_name, middle_name, last_name, gender, " & _
                "petc_code, certificate_tesda, certificate_tesda_expiration, is_active, description, user_type, user_name) " & _
                "SELECT user_id, employee_id, password, first_name, middle_name, last_name, gender, '" & modModule.CorrectSqlString(vPetcCode) & "', " & _
                "certificate_tesda, certificate_tesda_expiration, is_active, description, user_type, user_name FROM tb_tmp_users"

            'create query
            vMyPgCmd = New NpgsqlCommand(vQuery, vMyPgCon)

            'execute query
            vMyPgCmd.ExecuteNonQuery()

            'close and dispose to avoid memory leak
            vMyPgCmd.Dispose()

            txtPrompt.Text = txtPrompt.Text & "done" & vbCrLf

            '2. create log
            vTmpStr = modModule.CreateLog(Me.Name, "PETC Manager - Import PETC - Create", "Finished creating new Users " & modModule.CorrectSqlString(vPetcCode))

            'General - 8. commit transaction
            txtPrompt.Text = txtPrompt.Text & vbCrLf &
                "Updating database" & "..."

            vQuery = "COMMIT TRANSACTION"

            'create query
            vMyPgCmd = New NpgsqlCommand(vQuery, vMyPgCon)

            'execute query
            vMyPgCmd.ExecuteNonQuery()

            'close and dispose to avoid memory leak
            vMyPgCmd.Dispose()

            txtPrompt.Text = txtPrompt.Text & "done" & vbCrLf

            'General - 9. create log
            vTmpStr = modModule.CreateLog(Me.Name, "PETC Manager - Import PETC - Create", "Finished creating new PETC, Terminals, Users from imported data")

            lblHeader.Text = "PLEASE WAIT..."
            lblPrompt.Text = "Closing database... "
            lblPrompt.Refresh()

            txtPrompt.Text = txtPrompt.Text & vbCrLf & "Closing database... "

            'close and dispose connection
            vMyPgCon.Close()
            vMyPgCon = Nothing

            txtPrompt.Text = txtPrompt.Text & "done" & vbCrLf & vbCrLf

            'finished

            txtPrompt.Text = txtPrompt.Text & "Operation complete."
            modModule.GotoTextBoxLastLine(txtPrompt)

            lblHeader.Text = "OPERATION COMPLETE"
            lblPrompt.Text = "PETC, Terminals and Users successfully created."

            lblHeader.Refresh()
            lblPrompt.Refresh()

            pResultStr = Me.Name

            MsgBox("Finished." & vbCrLf & vbCrLf & _
                       "No errors were encountered." & vbCrLf & _
                       "PETC, Terminals and Users are all created successfully." & vbCrLf & vbCrLf & _
                       "Click OK to close and go back to previous menu.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Operation complete")

            pResultStr = "created"

            Me.Close()

        Catch ex As Exception
            'an error has occured

            'close connections that might be open
            If IsNothing(vMyPgCon) = False Then
                If vMyPgCon.State <> ConnectionState.Closed Then
                    vMyPgCon.Close()
                    vMyPgCon = Nothing
                End If
            End If

            modModule.GotoTextBoxLastLine(txtPrompt)

            lblHeader.Text = "OPERATION FAILED"
            lblPrompt.Text = "Error(s) were found. No changes were made."

            lblHeader.Refresh()
            lblPrompt.Refresh()

            vTmpVar = MsgBox("An error has occured." & vbCrLf & vbCr & _
                           "Error number: " & Trim(Str(Err.Number)) & vbCrLf & _
                           "Error description: " & Err.Description, MsgBoxStyle.OkOnly, "Error warning")

            'log event
            vTmpStr = modModule.CreateLog(Me.Name, "Error:timerLoad", ex.Message)

            txtPrompt.Text = txtPrompt.Text & vbCrLf & vbCrLf & _
                "An error has occured." & vbCrLf & vbCrLf & _
                "Error number: " & Trim(Str(Err.Number)) & vbCrLf & _
                "Error description: " & Err.Description & vbCrLf & vbCrLf & _
                "Execution halted."

            pResultStr = Me.Name
            pResultStr = "error"

            Me.Close()

            Exit Sub
        End Try
    End Sub

    Private Sub ProcessValidation(ByVal bPassed As Boolean, ByRef bErrorCritical As Long, ByRef bErrorWarning As Long, _
                                  ByRef bString As String, ByVal bPrompt As String, ByRef bTextBox As TextBox, _
                                  ByVal bRecNo As String)
        If bPassed = False Then
            bErrorCritical = bErrorCritical + 1

            bString = bString & IIf(Trim(bString) = "", "", vbCrLf) & _
                (bErrorCritical + bErrorWarning).ToString & ". " & bPrompt & "... Failed (critical)" & _
                IIf(Trim(bRecNo) = "", "", ", Record: " & bRecNo)

            bTextBox.Text = bTextBox.Text & "Failed (critical)" & vbCrLf
        Else
            bTextBox.Text = bTextBox.Text & "Passed" & vbCrLf
        End If

        modModule.GotoTextBoxLastLine(bTextBox)
    End Sub

End Class