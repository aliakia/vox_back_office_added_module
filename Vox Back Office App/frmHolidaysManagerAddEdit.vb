Imports Npgsql

Public Class frmHolidaysManagerAddEdit

    Private gMode As String
    Private gRecNo As String
    Private gFirstLoad As Boolean

    Private gOldHolidayDate As String
    Private gOldDescription As String
    Private gOldType As String
    Private gOldRegion As String
    Private gOldProvince As String
    Private gOldCity As String
    Private gOldSchedule As String
    Private gOldActive As String

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
        vTmpStr = modModule.CreateLog(Me.Name, "Holidays Manager - Add/Edit - Close", "")

        If vTmpStr = "1" Then
            Me.Close()
        Else
            MsgBox("An error occurred while saving log. Operation aborted.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Operation cancelled")
        End If
    End Sub

    Private Sub InitializeValues()
        txtDate.Text = ""
        txtDescription.Text = ""
        cmbType.Text = ""
        cmbRegion.Text = ""
        cmbProvince.Text = "NATIONAL"
        cmbCity.Text = ""
        cmbSchedule.Text = "one time"
        chkActive.Checked = True

        optNationalHoliday.Checked = True
        optLocalHoliday.Checked = False

        cmbRegion.Enabled = False
        cmbProvince.Enabled = False
        cmbCity.Enabled = False
    End Sub

    Private Sub SaveOldValues()
        gOldHolidayDate = txtDate.Text
        gOldDescription = txtDescription.Text
        gOldType = cmbType.Text
        gOldRegion = cmbRegion.Text
        gOldProvince = cmbProvince.Text
        gOldCity = cmbCity.Text
        gOldSchedule = cmbSchedule.Text
        gOldActive = IIf(chkActive.Checked = True, "1", "0")
    End Sub

    Private Function ChangesMade(Optional ByRef bChanges As String = "", Optional ByVal bPutCrLf As Boolean = False) As Boolean
        ChangesMade = False
        bChanges = ""

        If gOldHolidayDate <> txtDate.Text Then
            ChangesMade = True
            bChanges = bChanges & IIf(bChanges <> "", IIf(bPutCrLf = True, vbCrLf, ", "), "") & _
                "Holiday date from " & gOldHolidayDate & " to " & txtDate.Text
        End If

        If gOldDescription <> txtDescription.Text Then
            ChangesMade = True
            bChanges = bChanges & IIf(bChanges <> "", IIf(bPutCrLf = True, vbCrLf, ", "), "") & _
                "Holiday description from " & gOldDescription & " to " & txtDescription.Text
        End If

        If gOldType <> cmbType.Text Then
            ChangesMade = True
            bChanges = bChanges & IIf(bChanges <> "", IIf(bPutCrLf = True, vbCrLf, ", "), "") & _
                "Holiday type from " & gOldType & " to " & cmbType.Text
        End If

        If gOldRegion <> cmbRegion.Text Then
            ChangesMade = True
            bChanges = bChanges & IIf(bChanges <> "", IIf(bPutCrLf = True, vbCrLf, ", "), "") & _
                "Region from " & gOldRegion & " to " & cmbRegion.Text
        End If

        If gOldProvince <> cmbProvince.Text Then
            ChangesMade = True
            bChanges = bChanges & IIf(bChanges <> "", IIf(bPutCrLf = True, vbCrLf, ", "), "") & _
                "Province from " & gOldProvince & " to " & cmbProvince.Text
        End If

        If gOldCity <> cmbCity.Text Then
            ChangesMade = True
            bChanges = bChanges & IIf(bChanges <> "", IIf(bPutCrLf = True, vbCrLf, ", "), "") & _
                "Town / City from " & gOldCity & " to " & cmbCity.Text
        End If

        If gOldSchedule <> cmbSchedule.Text Then
            ChangesMade = True
            bChanges = bChanges & IIf(bChanges <> "", IIf(bPutCrLf = True, vbCrLf, ", "), "") & _
                "Holiday schedule from " & gOldSchedule & " to " & cmbSchedule.Text
        End If

        If gOldActive <> IIf(chkActive.Checked = True, "1", "0") Then
            ChangesMade = True
            bChanges = bChanges & IIf(bChanges <> "", IIf(bPutCrLf = True, vbCrLf, ", "), "") & _
                "Active from " & gOldActive & " to " & IIf(chkActive.Checked = True, "1", "0")
        End If
    End Function

    Private Sub frmHolidaysManagerAddEdit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        gFirstLoad = True

        Select Case Me.Mode
            Case "new"
                Me.Text = "ADD NEW HOLIDAY SCHEDULE"

                cmdProcess.Text = "CREATE"

            Case "edit"
                Me.Text = "EDIT HOLIDAY SCHEDULE"

                cmdProcess.Text = "UPDATE"
        End Select

        lblStatusPrompt.Visible = True
        lblStatusPrompt.Text = "Ready"

        'initialize controls

        txtDate.MaxLength = 0
        txtDescription.MaxLength = 256
        cmbType.MaxLength = 128
        cmbRegion.MaxLength = 256
        cmbProvince.MaxLength = 256
        cmbCity.MaxLength = 256
        cmbSchedule.MaxLength = 128

        With cmbType
            .Items.Clear()

            .Items.Add("regular")
            .Items.Add("special non-working")
        End With

        With cmbSchedule
            .Items.Clear()

            .Items.Add("one time")
            '.Items.Add("yearly")
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

        timerRefreshPredefinedData.Enabled = False

        modModule.LoadTableFieldInComboBox(cmbRegion, "region_code", "tb_region_codes", _
                                               "is_active = 1", "region_code ASC", lblStatusPrompt, True)

        cmbRegion.Text = ""

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
        Dim vTmpStr As String = ""

        Dim vTmpVar As Integer
        Dim vTmpStatus As String = ""

        Try

            If Trim(txtDate.Text) = "" Then
                vTmpVar = MsgBox("Holiday date is required." & vbCrLf & vbCrLf & _
                               "Please enter date of Holiday.", vbOKOnly + vbEmpty, "Incomplete data")

                txtDate.Select()
                txtDate.Focus()

                Exit Sub
            End If

            If txtDescription.Text = "" Then
                vTmpVar = MsgBox("Holiday description is required." & vbCrLf & vbCrLf & _
                               "Please enter description for this holiday.", vbOKOnly + vbEmpty, "Incomplete data")

                txtDescription.Select()
                txtDescription.Focus()

                Exit Sub
            End If

            If cmbType.Text = "" Then
                vTmpVar = MsgBox("Holiday type is required." & vbCrLf & vbCrLf & _
                               "Please select type of holiday from list.", vbOKOnly + vbEmpty, "Incomplete data")

                cmbType.Select()
                cmbType.Focus()

                Exit Sub
            End If

            If cmbRegion.Text = "" Then
                If cmbProvince.Text <> "NATIONAL" Then
                    vTmpVar = MsgBox("Region is required." & vbCrLf & vbCrLf & _
                                   "Please select region from list.", vbOKOnly + vbEmpty, "Incomplete data")

                    cmbRegion.Select()
                    cmbRegion.Focus()

                    Exit Sub
                End If
            End If

            If cmbProvince.Text = "" Then
                vTmpVar = MsgBox("Province is required." & vbCrLf & vbCrLf & _
                                   "Please select province from list.", vbOKOnly + vbEmpty, "Incomplete data")

                cmbProvince.Select()
                cmbProvince.Focus()

                Exit Sub
            End If

            If cmbCity.Text = "" Then
                If cmbProvince.Text <> "NATIONAL" Then
                    vTmpVar = MsgBox("City is required." & vbCrLf & vbCrLf & _
                                   "Please select city from list.", vbOKOnly + vbEmpty, "Incomplete data")

                    cmbCity.Select()
                    cmbCity.Focus()

                    Exit Sub
                End If
            End If

            If cmbSchedule.Text = "" Then
                vTmpVar = MsgBox("Holiday schedule is required." & vbCrLf & vbCrLf & _
                               "Please select schedule of holiday from list.", vbOKOnly + vbEmpty, "Incomplete data")

                cmbSchedule.Select()
                cmbSchedule.Focus()

                Exit Sub
            End If

            Select Case Me.Mode
                Case "new"
                    vTmpVar = MsgBox("You are about to create a new Holiday with the following info.:" & vbCrLf & vbCrLf & _
                                     "Holiday date: " & txtDate.Text & vbCrLf & _
                                     IIf(txtDescription.Text = "", "", "Description: " & txtDescription.Text & vbCrLf) & _
                                     IIf(cmbType.Text = "", "", "Holiday type: " & cmbType.Text & vbCrLf) & _
                                     IIf(cmbRegion.Text = "", "", "Region: " & cmbRegion.Text & vbCrLf) & _
                                     IIf(cmbProvince.Text = "", "", "Province: " & cmbProvince.Text & vbCrLf) & _
                                     IIf(cmbCity.Text = "", "", "City: " & cmbCity.Text & vbCrLf) & _
                                     IIf(cmbSchedule.Text = "", "", "Holiday schedule: " & cmbSchedule.Text & vbCrLf) & _
                                     "Active: " & IIf(chkActive.Checked = True, "Yes", "No") & vbCrLf & vbCrLf & _
                                     "Please make sure the above information are true and correct." & vbCrLf & vbCrLf & _
                                     "Are you sure you want to create the new Holiday?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "User confirmation")

                Case "edit"
                    If ChangesMade(vTmpStr, True) = False Then
                        MsgBox("Nothing to save. No changes haved been made.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Operation cancelled")

                        Exit Sub
                    Else
                        vTmpVar = MsgBox("You are about to update Holiday with the following changes:" & vbCrLf & vbCrLf & _
                                         vTmpStr & vbCrLf & vbCrLf & _
                                         "Please make sure the above information are true and correct." & vbCrLf & vbCrLf & _
                                         "Are you sure you want to update the Holiday record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "User confirmation")
                    End If
            End Select

            If vTmpVar = MsgBoxResult.No Then Exit Sub

            If chkActive.Checked = True Then
                vTmpStatus = "1"
            Else
                vTmpStatus = "0"
            End If

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
                    vQuery = "SELECT recno FROM tb_holidays WHERE region = '" & modModule.CorrectSqlString(cmbRegion.Text) & "' AND " & _
                        "province = '" & modModule.CorrectSqlString(cmbProvince.Text) & "' AND " & _
                        "town_city = '" & modModule.CorrectSqlString(cmbCity.Text) & "' AND " & _
                        "holiday_date = '" & modModule.CorrectSqlString(CDate(txtDate.Text).ToString("yyyy-MM-dd")) & "' AND " & _
                        "holiday_type = '" & modModule.CorrectSqlString(cmbType.Text) & "' AND " & _
                        "description = '" & modModule.CorrectSqlString(txtDescription.Text) & "' AND " & _
                        "period_schedule = '" & modModule.CorrectSqlString(cmbSchedule.Text) & "'"

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
                        vTmpVar = MsgBox("Holiday to create already exist in record." & vbCrLf & vbCrLf & _
                                        "Please re-check data.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Validation failed")
                        Exit Sub
                    End If

                    'close and dispose to avoid memory leak
                    vMyPgRd.Close()
                    vMyPgCmd.Dispose()

                Case "edit"
                    'check if already exist
                    vQuery = "SELECT recno FROM tb_holidays WHERE recno = " & modModule.CorrectSqlString(Me.RecNo)

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
                        vTmpVar = MsgBox("Holiday record to edit no longer exist in record." & vbCrLf & vbCrLf & _
                                        "Please make sure the record was not deleted.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Validation failed")
                        Exit Sub
                    End If

                    'close and dispose to avoid memory leak
                    vMyPgRd.Close()
                    vMyPgCmd.Dispose()

                    'check if already existing
                    vQuery = "SELECT recno FROM tb_holidays WHERE region = '" & modModule.CorrectSqlString(cmbRegion.Text) & "' AND " & _
                            "province = '" & modModule.CorrectSqlString(cmbProvince.Text) & "' AND " & _
                            "town_city = '" & modModule.CorrectSqlString(cmbCity.Text) & "' AND " & _
                            "holiday_date = '" & modModule.CorrectSqlString(CDate(txtDate.Text).ToString("yyyy-MM-dd")) & "' AND " & _
                            "holiday_type = '" & modModule.CorrectSqlString(cmbType.Text) & "' AND " & _
                            "description = '" & modModule.CorrectSqlString(txtDescription.Text) & "' AND " & _
                            "period_schedule = '" & modModule.CorrectSqlString(cmbSchedule.Text) & "' AND " & _
                            "recno <> " & modModule.CorrectSqlString(Me.RecNo)

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
                        vTmpVar = MsgBox("Holiday to create already exist in record." & vbCrLf & vbCrLf & _
                                        "Please re-check data.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Validation failed")
                        Exit Sub
                    End If

                    'close and dispose to avoid memory leak
                    vMyPgRd.Close()
                    vMyPgCmd.Dispose()
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

            lblStatusPrompt.Text = "Creating record in database..."
            lblStatusPrompt.Refresh()

            Select Case LCase(Me.Mode)
                Case "new"
                    'insert in tb_stations table
                    vQuery = "INSERT INTO tb_holidays (region, province, town_city, holiday_date, holiday_type, description, period_schedule, is_active) " & _
                        "VALUES ('" & modModule.CorrectSqlString(cmbRegion.Text) & "', '" & modModule.CorrectSqlString(cmbProvince.Text) & "', " & _
                            "'" & modModule.CorrectSqlString(cmbCity.Text) & "', '" & modModule.CorrectSqlString(CDate(txtDate.Text).ToString("yyyy-MM-dd")) & "', " & _
                            "'" & modModule.CorrectSqlString(cmbType.Text) & "', '" & modModule.CorrectSqlString(txtDescription.Text) & "', " & _
                            "'" & modModule.CorrectSqlString(cmbSchedule.Text) & "', " & vTmpStatus & ")"

                Case "edit"
                    'update in tb_petc table
                    vQuery = "UPDATE tb_holidays SET region = '" & modModule.CorrectSqlString(cmbRegion.Text) & "', " & _
                        "province = '" & modModule.CorrectSqlString(cmbProvince.Text) & "', " & _
                        "town_city = '" & modModule.CorrectSqlString(cmbCity.Text) & "', " & _
                        "holiday_date = '" & modModule.CorrectSqlString(CDate(txtDate.Text).ToString("yyyy-MM-dd")) & "', " & _
                        "holiday_type = '" & modModule.CorrectSqlString(cmbType.Text) & "', " & _
                        "description = '" & modModule.CorrectSqlString(txtDescription.Text) & "', " & _
                        "period_schedule = '" & modModule.CorrectSqlString(cmbSchedule.Text) & "', " & _
                        "is_active = " & modModule.CorrectSqlString(vTmpStatus) & " " & _
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

            vQuery = modModule.CreateLogCn(vMyPgCon, Me.Name, LCase(Me.Mode) & " holiday " & txtDate.Text, vTmpStr)

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

            MsgBox("Successful in " & IIf(LCase(Me.Mode) = "new", " creating new ", " updating ") & " holiday.", _
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

            vQuery = "SELECT recno, region, province, town_city, holiday_date, holiday_type, description, period_schedule, is_active " & _
                "FROM tb_holidays WHERE recno = " & modModule.CorrectSqlString(Me.RecNo)

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
                vTmpVar = MsgBox("Holiday record no longer exist." & vbCrLf & vbCrLf & _
                                "Please make sure the record was not deleted.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Unexpected error")

                Me.Close()

                Exit Sub
            Else
                'get result

                If IsDBNull(vMyPgRd("holiday_date")) = False Then
                    txtDate.Text = vMyPgRd("holiday_date")
                    txtDate_LostFocus(sender, e)
                End If

                If IsDBNull(vMyPgRd("description")) = False Then
                    txtDescription.Text = vMyPgRd("description")
                    txtDescription_LostFocus(sender, e)
                End If

                If IsDBNull(vMyPgRd("holiday_type")) = False Then
                    cmbType.Text = vMyPgRd("holiday_type")
                End If

                If IsDBNull(vMyPgRd("province")) = False Then
                    If vMyPgRd("province") = "NATIONAL" Then
                        optNationalHoliday.Checked = True
                        optLocalHoliday.Checked = False
                    Else
                        optNationalHoliday.Checked = False
                        optLocalHoliday.Checked = True
                    End If
                End If

                If IsDBNull(vMyPgRd("region")) = False Then
                    cmbRegion.Text = vMyPgRd("region")

                    'load provinces
                    modModule.LoadTableFieldInComboBox(cmbProvince, "province", "tb_region_province_city", _
                                "region = '" & modModule.CorrectSqlString(cmbRegion.Text) & "' AND province <> ''", "province ASC", lblStatusPrompt, True)
                End If

                If IsDBNull(vMyPgRd("province")) = False Then
                    cmbProvince.Text = vMyPgRd("province")

                    'load cities
                    modModule.LoadTableFieldInComboBox(cmbProvince, "town_city", "tb_region_province_city", _
                                "province = '" & modModule.CorrectSqlString(cmbProvince.Text) & "' AND town_city <> ''", "province ASC", lblStatusPrompt, True)
                End If

                If IsDBNull(vMyPgRd("town_city")) = False Then
                    cmbCity.Text = vMyPgRd("town_city")
                End If

                If IsDBNull(vMyPgRd("period_schedule")) = False Then
                    cmbSchedule.Text = vMyPgRd("period_schedule")
                End If

                If IsDBNull(vMyPgRd("is_active")) = False Then
                    Select Case vMyPgRd("is_active")
                        Case 0
                            chkActive.Checked = False

                        Case 1
                            chkActive.Checked = True

                        Case Else
                            chkActive.Checked = False
                    End Select
                End If
            End If

            lblStatusPrompt.Text = "Closing database..."
            lblStatusPrompt.Refresh()

            'close and dispose to avoid memory leak
            vMyPgRd.Close()
            vMyPgCmd.Dispose()

            'close and dispose connection
            vMyPgCon.Close()
            vMyPgCon = Nothing

            'save old values for later comparison
            SaveOldValues()

            lblStatusPrompt.Text = "Ready"
            lblStatusPrompt.Visible = True
            lblStatusPrompt.Refresh()

            EnableButtons()

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

            Me.Close()

            Exit Sub
        End Try
    End Sub

    Private Sub cmbType_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbType.KeyPress
        e.Handled = True
    End Sub

    Private Sub txtDescription_GotFocus(sender As Object, e As EventArgs) Handles txtDescription.GotFocus
        txtDescription.SelectAll()
    End Sub

    Private Sub txtDescription_LostFocus(sender As Object, e As EventArgs) Handles txtDescription.LostFocus
        txtDescription.Text = UCase(Trim(modModule.StripInvalidStringChars(txtDescription.Text)))
    End Sub

    Private Sub txtDescription_TextChanged(sender As Object, e As EventArgs) Handles txtDescription.TextChanged

    End Sub

    Private Sub txtDate_GotFocus(sender As Object, e As EventArgs) Handles txtDate.GotFocus
        txtDate.SelectAll()
    End Sub

    Private Sub txtDate_LostFocus(sender As Object, e As EventArgs) Handles txtDate.LostFocus
        If IsDate(txtDate.Text) = True Then
            txtDate.Text = Format(CDate(txtDate.Text), "MM/dd/yyyy")
        Else
            txtDate.Text = ""
        End If
    End Sub

    Private Sub txtDate_TextChanged(sender As Object, e As EventArgs) Handles txtDate.TextChanged

    End Sub

    Private Sub cmbSchedule_GotFocus(sender As Object, e As EventArgs) Handles cmbSchedule.GotFocus
        cmbSchedule.SelectAll()
    End Sub

    Private Sub cmbSchedule_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbSchedule.KeyPress
        e.Handled = True
    End Sub

    Private Sub optNationalHoliday_CheckedChanged(sender As Object, e As EventArgs) Handles optNationalHoliday.CheckedChanged
        cmbRegion.Text = ""
        cmbProvince.Text = "NATIONAL"
        cmbCity.Text = ""

        cmbRegion.Enabled = False
        cmbProvince.Enabled = False
        cmbCity.Enabled = False
    End Sub

    Private Sub optLocalHoliday_CheckedChanged(sender As Object, e As EventArgs) Handles optLocalHoliday.CheckedChanged
        cmbRegion.Text = ""
        cmbProvince.Text = ""
        cmbCity.Text = ""

        cmbProvince.Items.Clear()
        cmbCity.Items.Clear()

        cmbRegion.Enabled = True
        cmbProvince.Enabled = True
        cmbCity.Enabled = True
    End Sub

    Private Sub cmbRegion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbRegion.KeyPress
        e.Handled = True
    End Sub

    Private Sub cmbRegion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbRegion.SelectedIndexChanged
        cmbProvince.Text = ""
        cmbCity.Text = ""

        cmbProvince.Items.Clear()
        cmbCity.Items.Clear()

        If cmbRegion.Text <> "" Then
            modModule.LoadTableFieldInComboBox(cmbProvince, "province", "tb_region_province_city", _
                                           "region = '" & modModule.CorrectSqlString(cmbRegion.Text) & "' AND province <> ''", "province ASC", lblStatusPrompt, True)
        End If
    End Sub

    Private Sub cmbProvince_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbProvince.KeyPress
        e.Handled = True
    End Sub

    Private Sub cmbProvince_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbProvince.SelectedIndexChanged
        cmbCity.Text = ""

        cmbCity.Items.Clear()

        If cmbProvince.Text <> "" Then
            modModule.LoadTableFieldInComboBox(cmbCity, "town_city", "tb_region_province_city", _
                                           "province = '" & modModule.CorrectSqlString(cmbProvince.Text) & "' AND town_city <> ''", "town_city ASC", lblStatusPrompt, True)
        End If
    End Sub

    Private Sub cmbType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbType.SelectedIndexChanged

    End Sub

    Private Sub cmbSchedule_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSchedule.SelectedIndexChanged

    End Sub

    Private Sub cmbCity_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbCity.KeyPress
        e.Handled = True
    End Sub

    Private Sub cmbCity_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCity.SelectedIndexChanged

    End Sub
End Class