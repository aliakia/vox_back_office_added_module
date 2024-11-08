Imports Npgsql

Public Class frmRegionsProvincesCitiesAddEntry

    Private gFirstLoad As Boolean
    Private gMode As String

    Private gParamRegion As String
    Private gParamProvince As String
    Private gParamCity As String
    Private gParamTarget As String
    Private gParamRecNo As String

    Property ParamRecNo() As String
        Get
            Return gParamRecNo
        End Get

        Set(ByVal value As String)
            gParamRecNo = value
        End Set
    End Property

    Property ParamRegion() As String
        Get
            Return gParamRegion
        End Get

        Set(ByVal value As String)
            gParamRegion = value
        End Set
    End Property

    Property ParamProvince() As String
        Get
            Return gParamProvince
        End Get

        Set(ByVal value As String)
            gParamProvince = value
        End Set
    End Property

    Property ParamCity() As String
        Get
            Return gParamCity
        End Get

        Set(ByVal value As String)
            gParamCity = value
        End Set
    End Property

    Property Mode() As String
        Get
            Return gMode
        End Get

        Set(ByVal value As String)
            gMode = value
        End Set
    End Property

    Property ParamTarget() As String
        Get
            Return gParamTarget
        End Get

        Set(ByVal value As String)
            gParamTarget = value
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
        vTmpStr = modModule.CreateLog(Me.Name, "Regions, Provinces, Cities Manager - " & Me.Mode & " " & Me.ParamTarget & " - Close", "")

        If vTmpStr = "1" Then
            Me.Close()
        Else
            MsgBox("An error occurred while saving log. Operation aborted.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Operation cancelled")
        End If
    End Sub

    Private Sub InitializeValues()
        cmbRegion.Text = ""
        cmbProvince.Text = ""
        txtData.Text = ""
    End Sub

    Private Sub frmRegionsProvincesCitiesAddEntry_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        gFirstLoad = True

        Select Case UCase(Me.Mode)
            Case "NEW"
                Me.Text = "ADD NEW " & UCase(Me.ParamTarget)
                cmdProcess.Text = "CREATE"

            Case "EDIT"
                Me.Text = "UPDATE " & UCase(Me.ParamTarget)
                cmdProcess.Text = "UPDATE"
        End Select

        lblStatusPrompt.Visible = True
        lblStatusPrompt.Text = "Ready"

        'initialize controls

        txtData.MaxLength = 128

        InitializeValues()

        ImplementPrivileges()

        Select Case UCase(Me.ParamTarget)
            Case "REGION"
                cmbRegion.Text = "N/A"
                cmbRegion.Enabled = False

                cmbProvince.Text = "N/A"
                cmbProvince.Enabled = False

                lblRegion.Enabled = False
                lblProvince.Enabled = False

                If Trim(Me.ParamRegion) <> "" Then txtData.Text = Me.ParamRegion

            Case "PROVINCE"
                cmbRegion.Text = ""
                cmbRegion.Enabled = True

                cmbProvince.Text = "N/A"
                cmbProvince.Enabled = False

                lblRegion.Enabled = True
                lblProvince.Enabled = False

                If Trim(Me.ParamProvince) <> "" Then txtData.Text = Me.ParamProvince

            Case "CITY"
                cmbRegion.Text = ""
                cmbRegion.Enabled = True

                cmbProvince.Text = ""
                cmbProvince.Enabled = True

                lblRegion.Enabled = True
                lblProvince.Enabled = True

                If Trim(Me.ParamCity) <> "" Then txtData.Text = Me.ParamCity
        End Select

        lblLogisticDescription.Text = "Name of new " & UCase(Me.ParamTarget) & ":"

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

        timerRefreshPredefinedData.Enabled = False

        Select Case UCase(Me.ParamTarget)
            Case "REGION"

            Case "PROVINCE"
                modModule.LoadTableFieldInComboBox(cmbRegion, "region_code", "tb_region_codes", _
                                                       "is_active = 1", "region_code ASC", lblStatusPrompt, True)

                If Trim(Me.ParamRegion) <> "" Then cmbRegion.Text = Me.ParamRegion

            Case "CITY"
                modModule.LoadTableFieldInComboBox(cmbRegion, "region_code", "tb_region_codes", _
                                                       "is_active = 1", "region_code ASC", lblStatusPrompt, True)

                If Trim(Me.ParamRegion) <> "" Then cmbRegion.Text = Me.ParamRegion

                modModule.LoadTableFieldInComboBox(cmbProvince, "province", "tb_region_province_city", _
                                                       "region = '" & modModule.CorrectSqlString(cmbRegion.Text) & "'", "province ASC", lblStatusPrompt, True)

                If Trim(Me.ParamProvince) <> "" Then cmbProvince.Text = Me.ParamProvince

        End Select

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
        'Dim vTmpStr As String = ""
        'Dim vTmpBalance As Double = 0

        Dim vTmpVar As Integer
        Dim vTmpRegion As String = ""
        Dim vTmpProvince As String = ""
        Dim vTmpCity As String = ""

        Try

            If cmbRegion.Enabled = True Then
                If Trim(cmbRegion.Text) = "" Then
                    vTmpVar = MsgBox("Region is required." & vbCrLf & vbCrLf & _
                                   "Please select region from list.", vbOKOnly + vbEmpty, "Incomplete data")

                    cmbRegion.Select()
                    cmbRegion.Focus()

                    Exit Sub
                End If
            End If

            If cmbProvince.Enabled = True Then
                If Trim(cmbProvince.Text) = "" Then
                    vTmpVar = MsgBox("Province is required." & vbCrLf & vbCrLf & _
                                   "Please select province from list.", vbOKOnly + vbEmpty, "Incomplete data")

                    cmbProvince.Select()
                    cmbProvince.Focus()

                    Exit Sub
                End If
            End If

            If Trim(txtData.Text) = "" Then
                vTmpVar = MsgBox(UCase(Me.ParamTarget) & " information is required." & vbCrLf & vbCrLf & _
                               "Please enter " & UCase(Me.ParamTarget) & " information.", vbOKOnly + vbEmpty, "Incomplete data")

                txtData.Select()
                txtData.Focus()

                Exit Sub
            End If

            Select Case LCase(Me.Mode)
                Case "new"
                    vTmpVar = MsgBox("You are about to create a new " & UCase(Me.ParamTarget) & " with the following info.:" & vbCrLf & vbCrLf & _
                                     IIf(cmbRegion.Enabled = False, "", "Region: " & cmbRegion.Text & vbCrLf) & _
                                     IIf(cmbProvince.Enabled = False, "", "Province: " & cmbProvince.Text & vbCrLf) & _
                                     UCase(Me.ParamTarget) & ": " & txtData.Text & vbCrLf & vbCrLf & _
                                     "Please make sure the above information are true and correct." & vbCrLf & vbCrLf & _
                                     "Are you sure you want to create the new " & UCase(Me.ParamTarget) & " info.?", _
                                     MsgBoxStyle.YesNo + MsgBoxStyle.Question, "User confirmation")

                Case "edit"
            End Select

            If vTmpVar = MsgBoxResult.No Then Exit Sub

            lblStatusPrompt.Text = "Opening database..."
            lblStatusPrompt.Refresh()

            'open db connection
            vMyPgCon.ConnectionString = pConnectVox
            vMyPgCon.Open()

            lblStatusPrompt.Text = "Validating in PETC in database..."
            lblStatusPrompt.Refresh()

            If cmbRegion.Enabled = True Then
                'check if region exist
                vQuery = "SELECT region_code FROM tb_region_codes WHERE region_code = '" & modModule.CorrectSqlString(cmbRegion.Text) & "'"

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
                    vTmpVar = MsgBox("Region " & modModule.CorrectSqlString(cmbRegion.Text) & " does not exist in record." & vbCrLf & vbCrLf & _
                                    "Please double check records.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Validation failed")

                    cmbRegion.Select()
                    cmbRegion.Focus()

                    lblStatusPrompt.Text = "Closing database..."
                    lblStatusPrompt.Refresh()

                    'close and dispose connection
                    vMyPgCon.Close()
                    vMyPgCon = Nothing

                    lblStatusPrompt.Text = "Ready"
                    lblStatusPrompt.Visible = True

                    Exit Sub
                End If

                'close and dispose to avoid memory leak
                vMyPgRd.Close()
                vMyPgCmd.Dispose()
            End If

            If cmbProvince.Enabled = True Then
                'check if province exist
                vQuery = "SELECT recno FROM tb_region_province_city WHERE province = '" & modModule.CorrectSqlString(cmbProvince.Text) & "'"

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
                    vTmpVar = MsgBox("Province " & modModule.CorrectSqlString(cmbProvince.Text) & " does not exist in record." & vbCrLf & vbCrLf & _
                                    "Please double check records.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Validation failed")

                    cmbProvince.Select()
                    cmbProvince.Focus()

                    lblStatusPrompt.Text = "Closing database..."
                    lblStatusPrompt.Refresh()

                    'close and dispose connection
                    vMyPgCon.Close()
                    vMyPgCon = Nothing

                    lblStatusPrompt.Text = "Ready"
                    lblStatusPrompt.Visible = True

                    Exit Sub
                End If

                'close and dispose to avoid memory leak
                vMyPgRd.Close()
                vMyPgCmd.Dispose()
            End If

            Select Case UCase(Me.Mode)
                Case "NEW"
                    'check if already exist

                    Select Case UCase(Me.ParamTarget)
                        Case "REGION"
                            'check if region exist
                            vQuery = "SELECT region_code FROM tb_region_codes WHERE " & _
                                "UPPER(region_code) = '" & UCase(modModule.CorrectSqlString(txtData.Text)) & "'"

                        Case "PROVINCE"
                            'check if province exist
                            vQuery = "SELECT recno FROM tb_region_province_city WHERE " & _
                                "UPPER(region) = '" & UCase(modModule.CorrectSqlString(cmbRegion.Text)) & "' AND " & _
                                "UPPER(province) = '" & UCase(modModule.CorrectSqlString(txtData.Text)) & "'"

                        Case "CITY"
                            'check if province exist
                            vQuery = "SELECT recno FROM tb_region_province_city WHERE " & _
                                "UPPER(region) = '" & UCase(modModule.CorrectSqlString(cmbRegion.Text)) & "' AND " & _
                                "UPPER(province) = '" & UCase(modModule.CorrectSqlString(cmbProvince.Text)) & "' AND " & _
                                "UPPER(town_city) = '" & UCase(modModule.CorrectSqlString(txtData.Text)) & "'"
                    End Select

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
                        vTmpVar = MsgBox(UCase(Me.ParamTarget) & " " & txtData.Text & " already exist in record." & vbCrLf & vbCrLf & _
                                        "Please double check records.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Validation failed")

                        txtData.Select()
                        txtData.Focus()

                        lblStatusPrompt.Text = "Closing database..."
                        lblStatusPrompt.Refresh()

                        'close and dispose connection
                        vMyPgCon.Close()
                        vMyPgCon = Nothing

                        lblStatusPrompt.Text = "Ready"
                        lblStatusPrompt.Visible = True

                        Exit Sub
                    End If

                    'close and dispose to avoid memory leak
                    vMyPgRd.Close()
                    vMyPgCmd.Dispose()

                Case "EDIT"
                    'check if record still exists and no duplicate
            End Select

            lblStatusPrompt.Text = "Initializing transaction..."
            lblStatusPrompt.Refresh()

            vQuery = "BEGIN TRANSACTION"

            'create query
            vMyPgCmd = New NpgsqlCommand(vQuery, vMyPgCon)

            'execute query
            vMyPgCmd.ExecuteNonQuery()

            'close and dispose to avoid memory leak
            vMyPgCmd.Dispose()

            Select Case UCase(Me.Mode)
                Case "NEW"
                    lblStatusPrompt.Text = "Creating record in database..."
                    lblStatusPrompt.Refresh()

                    Select Case UCase(Me.ParamTarget)
                        Case "REGION"
                            vTmpRegion = txtData.Text
                            vTmpProvince = ""
                            vTmpCity = ""

                            'insert in tb_region_codes table
                            vQuery = "INSERT INTO tb_region_codes (region_code, description, is_active) " & _
                                "VALUES ('" & modModule.CorrectSqlString(vTmpRegion) & "', '" & modModule.CorrectSqlString(vTmpRegion) & "', 1)"

                        Case "PROVINCE"
                            vTmpRegion = cmbRegion.Text
                            vTmpProvince = txtData.Text
                            vTmpCity = ""

                            'insert in tb_region_province_city table
                            vQuery = "INSERT INTO tb_region_province_city (region, province, town_city) " & _
                                "VALUES ('" & modModule.CorrectSqlString(vTmpRegion) & "', '" & modModule.CorrectSqlString(vTmpProvince) & "', " & _
                                "'" & modModule.CorrectSqlString(vTmpCity) & "')"

                        Case "CITY"
                            vTmpRegion = cmbRegion.Text
                            vTmpProvince = cmbProvince.Text
                            vTmpCity = txtData.Text

                            'insert in tb_region_province_city table
                            vQuery = "INSERT INTO tb_region_province_city (region, province, town_city) " & _
                                "VALUES ('" & modModule.CorrectSqlString(vTmpRegion) & "', '" & modModule.CorrectSqlString(vTmpProvince) & "', " & _
                                "'" & modModule.CorrectSqlString(vTmpCity) & "')"
                    End Select

                    'create query
                    vMyPgCmd = New NpgsqlCommand(vQuery, vMyPgCon)

                    'execute query
                    vMyPgCmd.ExecuteNonQuery()

                    'close and dispose to avoid memory leak
                    vMyPgCmd.Dispose()

                Case "EDIT"
                    lblStatusPrompt.Text = "Updating record in database..."
                    lblStatusPrompt.Refresh()

                    'update database codes here
            End Select

            'create log
            vQuery = modModule.CreateLogCn(vMyPgCon, Me.Name, modModule.CorrectSqlString(Me.Mode) & " " & modModule.CorrectSqlString(Me.ParamTarget), _
                                           "Region: " & modModule.CorrectSqlString(cmbRegion.Text) & ", " & _
                                           "Province: " & modModule.CorrectSqlString(cmbProvince.Text) & ", " & _
                                           "Data: " & modModule.CorrectSqlString(txtData.Text))

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

            MsgBox("Successfull in " & IIf(LCase(Me.Mode) = "new", "creating", "updating") & " " & modModule.CorrectSqlString(Me.ParamTarget) & " " & txtData.Text, _
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

    Private Sub txtData_GotFocus(sender As Object, e As EventArgs) Handles txtData.GotFocus
        txtData.SelectAll()
    End Sub

    Private Sub txtData_LostFocus(sender As Object, e As EventArgs) Handles txtData.LostFocus
        txtData.Text = UCase(Trim(modModule.CorrectSqlString(txtData.Text)))
    End Sub

    Private Sub timerLoad_Tick(sender As Object, e As EventArgs) Handles timerLoad.Tick
        timerLoad.Enabled = False
    End Sub

    Private Sub txtData_TextChanged(sender As Object, e As EventArgs) Handles txtData.TextChanged

    End Sub

    Private Sub cmbRegion_GotFocus(sender As Object, e As EventArgs) Handles cmbRegion.GotFocus
        cmbRegion.SelectAll()
    End Sub

    Private Sub cmbRegion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbRegion.KeyPress
        e.Handled = True
    End Sub

    Private Sub cmbRegion_LostFocus(sender As Object, e As EventArgs) Handles cmbRegion.LostFocus
        If Me.ParamTarget = "city" Then
            If Trim(cmbRegion.Text) = "" Then
                With cmbProvince
                    .Items.Clear()
                    .Text = ""
                End With
            End If
        End If
    End Sub

    Private Sub cmbRegion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbRegion.SelectedIndexChanged
        If Me.ParamTarget = "city" Then
            cmbProvince.Text = ""

            modModule.LoadTableFieldInComboBox(cmbProvince, "province", "tb_region_province_city", _
                                            "region = '" & modModule.CorrectSqlString(cmbRegion.Text) & "'", "province ASC", lblStatusPrompt, True)
        End If
    End Sub

    Private Sub cmbProvince_GotFocus(sender As Object, e As EventArgs) Handles cmbProvince.GotFocus
        cmbProvince.SelectAll()
    End Sub

    Private Sub cmbProvince_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbProvince.KeyPress
        e.Handled = True
    End Sub

    Private Sub cmbProvince_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbProvince.SelectedIndexChanged

    End Sub
End Class