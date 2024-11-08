Imports Npgsql

Public Class frmPetcManagerImport

    Private gSortingColumn As ColumnHeader

    Private Sub ImplementPrivileges()
    End Sub

    Private Sub frmPetcManagerImport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        ' 2 .Add("Description", 200, HorizontalAlignment.Left)
        ' 3 .Add("Status", 100, HorizontalAlignment.Left)
        ' 4 .Add("Lanes", 100, HorizontalAlignment.Right)
        ' 5 .Add("Category", 100, HorizontalAlignment.Left)
        ' 6 .Add("Address", 200, HorizontalAlignment.Left)
        ' 7 .Add("Contact", 100, HorizontalAlignment.Left)
        ' 8 .Add("Business type", 100, HorizontalAlignment.Left)
        ' 9 .Add("LTO service area", 100, HorizontalAlignment.Left)
        '10 .Add("DTI accreditation no.", 100, HorizontalAlignment.Left)
        '11 .Add("LTO authorization no.", 100, HorizontalAlignment.Left)
        '12 .Add("I.T. started", 100, HorizontalAlignment.Left)
        '13 .Add("I.T. accredited", 100, HorizontalAlignment.Left)
        '14 .Add("I.T. renewal", 100, HorizontalAlignment.Left)
        '15 .Add("PETC started", 100, HorizontalAlignment.Left)
        '16 .Add("PETC accredited", 100, HorizontalAlignment.Left)
        '17 .Add("PETC authorized", 100, HorizontalAlignment.Left)
        '18 .Add("GM", 0, HorizontalAlignment.Left)
        '19 .Add("Province", 100, HorizontalAlignment.Left)
        '20 .Add("Region", 100, HorizontalAlignment.Left)
        '21 Account ID
        '22 Account manager
        '23 Tech. manager
        '24 Marketing agent
        '25 Marketing commission
        '26 transmission_fee
        '27 account_type
        '28 remarks
        '29 stradcom_fee
        '30 max_credit

        With lsvItems.Columns
            .Clear()

            .Add("Petc code", 100, HorizontalAlignment.Left)
            .Add("Name", 200, HorizontalAlignment.Left)
            .Add("Description", 200, HorizontalAlignment.Left)
            .Add("Status", 100, HorizontalAlignment.Left)
            .Add("Lanes", 100, HorizontalAlignment.Right)
            .Add("Category", 100, HorizontalAlignment.Left)
            .Add("Address", 200, HorizontalAlignment.Left)
            .Add("Contact", 100, HorizontalAlignment.Left)
            .Add("Business type", 100, HorizontalAlignment.Left)
            .Add("LTO service area", 100, HorizontalAlignment.Left)
            .Add("DTI accreditation no.", 100, HorizontalAlignment.Left)
            .Add("LTO authorization no.", 100, HorizontalAlignment.Left)
            .Add("I.T. started", 100, HorizontalAlignment.Left)
            .Add("I.T. accredited", 100, HorizontalAlignment.Left)
            .Add("I.T. renewal", 100, HorizontalAlignment.Left)
            .Add("PETC started", 100, HorizontalAlignment.Left)
            .Add("PETC accredited", 100, HorizontalAlignment.Left)
            .Add("PETC authorized", 100, HorizontalAlignment.Left)
            .Add("GM", 0, HorizontalAlignment.Left)
            .Add("Province", 100, HorizontalAlignment.Left)
            .Add("Region", 100, HorizontalAlignment.Left)
            .Add("Account ID", 100, HorizontalAlignment.Left)
            .Add("Account manager", 100, HorizontalAlignment.Left)
            .Add("Tech. manager", 100, HorizontalAlignment.Left)
            .Add("Marketing agent", 100, HorizontalAlignment.Left)
            .Add("Marketing commission", 100, HorizontalAlignment.Right)
            .Add("Transmission fee", 100, HorizontalAlignment.Right)
            .Add("Account type", 100, HorizontalAlignment.Left)
            .Add("Remarks", 100, HorizontalAlignment.Left)
            .Add("Stradcom fee", 100, HorizontalAlignment.Right)
            .Add("Max credit", 100, HorizontalAlignment.Right)
        End With

        ' 0 .Add("Terminal ID", 100, HorizontalAlignment.Left)
        ' 1 .Add("Description", 200, HorizontalAlignment.Left)
        ' 2 .Add("Type", 100, HorizontalAlignment.Left)
        ' 3 .Add("Serial", 100, HorizontalAlignment.Left)
        ' 4 .Add("MAC", 100, HorizontalAlignment.Left)
        ' 5 .Add("IP", 100, HorizontalAlignment.Left)
        ' 6 .Add("Status", 100, HorizontalAlignment.Left)
        ' 7 .Add("PETC Code", 100, HorizontalAlignment.Left)
        ' 8 .Add("PETC lane", 100, HorizontalAlignment.Right)
        ' 9 .Add("Machine description", 100, HorizontalAlignment.Left)
        '10 .Add("Machine serial", 100, HorizontalAlignment.Left)
        '11 .Add("Machine calibrated", 100, HorizontalAlignment.Left)
        '12 .Add("Lock status", 100, HorizontalAlignment.Left)
        '13 .Add("DLL", 100, HorizontalAlignment.Left)
        '14 .Add("Machine settings", 300, HorizontalAlignment.Left)
        '15 .Add("Is SCSI/SAS", 100, HorizontalAlignment.Left)

        With lsvTerminals.Columns
            .Clear()

            .Add("Terminal ID", 150, HorizontalAlignment.Left)
            .Add("Description", 200, HorizontalAlignment.Left)
            .Add("Type", 50, HorizontalAlignment.Left)
            .Add("Serial", 100, HorizontalAlignment.Left)
            .Add("MAC", 100, HorizontalAlignment.Left)
            .Add("IP", 100, HorizontalAlignment.Left)
            .Add("Status", 75, HorizontalAlignment.Left)
            .Add("PETC Code", 80, HorizontalAlignment.Left)
            .Add("Lane", 50, HorizontalAlignment.Right)
            .Add("Machine description", 100, HorizontalAlignment.Left)
            .Add("Machine serial", 100, HorizontalAlignment.Left)
            .Add("Machine calibrated", 100, HorizontalAlignment.Left)
            .Add("Lock status", 100, HorizontalAlignment.Left)
            .Add("DLL", 100, HorizontalAlignment.Left)
            .Add("Machine settings", 300, HorizontalAlignment.Left)
            .Add("Is SCSI/SAS", 100, HorizontalAlignment.Left)
        End With

        ' 0 .Add("User ID", 100, HorizontalAlignment.Left)
        ' 1 .Add("Full name", 200, HorizontalAlignment.Left)
        ' 2 .Add("Type", 100, HorizontalAlignment.Left)
        ' 3 .Add("PETC Code", 80, HorizontalAlignment.Left)
        ' 4 .Add("Status", 75, HorizontalAlignment.Left)
        ' 5 .Add("Description", 200, HorizontalAlignment.Left)
        ' 6 .Add("Gender", 75, HorizontalAlignment.Left)
        ' 7 .Add("TESDA certificate no.", 100, HorizontalAlignment.Left)
        ' 8 .Add("TESDA certification expiration", 100, HorizontalAlignment.Left)
        ' 9 .Add("Employee ID", 100, HorizontalAlignment.Left)
        '10 .Add("RecNo", 0, HorizontalAlignment.Left)

        With lsvUsers.Columns
            .Clear()

            .Add("User ID", 100, HorizontalAlignment.Left)
            .Add("Full name", 200, HorizontalAlignment.Left)
            .Add("Type", 100, HorizontalAlignment.Left)
            .Add("PETC Code", 80, HorizontalAlignment.Left)
            .Add("Status", 75, HorizontalAlignment.Left)
            .Add("Description", 200, HorizontalAlignment.Left)
            .Add("Gender", 75, HorizontalAlignment.Left)
            .Add("TESDA certificate no.", 100, HorizontalAlignment.Left)
            .Add("TESDA certification expiration", 100, HorizontalAlignment.Left)
            .Add("Employee ID", 100, HorizontalAlignment.Left)
            .Add("RecNo", 0, HorizontalAlignment.Left)
        End With

        lsvItems.Items.Clear()
        lsvTerminals.Items.Clear()
        lsvUsers.Items.Clear()

        txtPetcCode.Text = ""

        ImplementPrivileges()

        Dim vTmpStr As String

        'log event
        vTmpStr = modModule.CreateLog(Me.Name, "PETC Manager", "Open Import PETC module")
    End Sub

    Private Sub frmPetcManagerImport_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
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

    Private Sub cmdImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdImport.Click
        Dim vPetcCode As String = ""

        vPetcCode = Trim(txtPetcCode.Text)

        'validate

        If vPetcCode = "" Then
            MsgBox("Please enter PETC Code to import.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Incomplete data")

            Exit Sub
        End If

        ImportData(vPetcCode)
    End Sub

    Private Sub ImportData(ByVal bPetcCode As String)
        'open postgres connection
        Dim vMyPgCon As New NpgsqlConnection
        Dim vMyPgCmd = New NpgsqlCommand
        Dim vMyPgRd As NpgsqlDataReader
        Dim vFound As Boolean

        Dim vQuery As String
        Dim vTmpStr As String
        Dim vTmpVar As Integer

        Dim vFilename As String = ""
        Dim vPetcCode As String = ""
        Dim vRecs As Long

        Try
            vPetcCode = bPetcCode

            lblPETC.Text = "PETC:"

            gSortingColumn = Nothing
            lsvItems.ListViewItemSorter = Nothing
            modModule.RemoveSortHeaderInColumns(lsvItems)
            lsvItems.Items.Clear()

            lsvTerminals.ListViewItemSorter = Nothing
            modModule.RemoveSortHeaderInColumns(lsvTerminals)
            lsvTerminals.Items.Clear()

            lsvUsers.ListViewItemSorter = Nothing
            modModule.RemoveSortHeaderInColumns(lsvUsers)
            lsvUsers.Items.Clear()

            lblStatusPrompt.Text = "Opening database..."
            lblStatusPrompt.Visible = True
            lblStatusPrompt.Refresh()

            'open db connection
            vMyPgCon.ConnectionString = pConnectVox
            vMyPgCon.Open()

            lblStatusPrompt.Text = "Initializing data..."
            lblStatusPrompt.Refresh()

            vQuery = "truncate tb_tmp_petcs"

            'create query
            vMyPgCmd = New NpgsqlCommand(vQuery, vMyPgCon)

            'execute query
            vMyPgCmd.ExecuteNonQuery()

            'close
            vMyPgCmd.Dispose()

            vQuery = "truncate tb_tmp_stations"

            'create query
            vMyPgCmd = New NpgsqlCommand(vQuery, vMyPgCon)

            'execute query
            vMyPgCmd.ExecuteNonQuery()

            'close
            vMyPgCmd.Dispose()

            vQuery = "truncate tb_tmp_users"

            'create query
            vMyPgCmd = New NpgsqlCommand(vQuery, vMyPgCon)

            'execute query
            vMyPgCmd.ExecuteNonQuery()

            'close
            vMyPgCmd.Dispose()

            lblStatusPrompt.Text = "Importing PETC data..."
            lblStatusPrompt.Refresh()

            'import PETC data
            vFilename = pWorkDirectory & "\Export - " & vPetcCode & " - PETC DATA.csv"

            vQuery = "COPY tb_tmp_petcs FROM '" & modModule.CorrectSqlString(vFilename) & "' HEADER CSV"

            'create query
            vMyPgCmd = New NpgsqlCommand(vQuery, vMyPgCon)

            'execute query
            vMyPgCmd.ExecuteNonQuery()

            'close
            vMyPgCmd.Dispose()

            'import PETC stations
            lblStatusPrompt.Text = "Importing PETC terminals..."
            lblStatusPrompt.Refresh()

            vFilename = pWorkDirectory & "\Export - " & vPetcCode & " - STATIONS DATA.csv"

            vQuery = "COPY tb_tmp_stations FROM '" & modModule.CorrectSqlString(vFilename) & "' HEADER CSV"

            'create query
            vMyPgCmd = New NpgsqlCommand(vQuery, vMyPgCon)

            'execute query
            vMyPgCmd.ExecuteNonQuery()

            'close
            vMyPgCmd.Dispose()

            'import PETC users
            lblStatusPrompt.Text = "Importing PETC users..."
            lblStatusPrompt.Refresh()

            vFilename = pWorkDirectory & "\Export - " & vPetcCode & " - USERS DATA.csv"

            vQuery = "COPY tb_tmp_users FROM '" & modModule.CorrectSqlString(vFilename) & "' HEADER CSV"

            'create query
            vMyPgCmd = New NpgsqlCommand(vQuery, vMyPgCon)

            'execute query
            vMyPgCmd.ExecuteNonQuery()

            'close
            vMyPgCmd.Dispose()

            'load imported PETC data

            lblStatusPrompt.Text = "Loading PETC data..."
            lblStatusPrompt.Refresh()

            vQuery = "SELECT petc_code, petc_lanes, petc_category, petc_name, petc_address, contact_no, business_type, " & _
                "lto_service_area, dti_accreditation_no, lto_authorization_no, date_it_started, date_it_accredited, date_it_renewal, " & _
                "date_petc_started, date_petc_accredited, date_petc_authorized, is_active, description, gm, province, region, " & _
                "account_id, account_manager, tech_manager, marketing_agent, marketing_commission, " & _
                "transmission_fee, account_type, remarks, stradcom_fee, max_credit FROM tb_tmp_petcs"

            'create query
            vMyPgCmd = New NpgsqlCommand(vQuery, vMyPgCon)

            'execute query
            vMyPgRd = vMyPgCmd.ExecuteReader()

            'read values
            vFound = vMyPgRd.Read

            If vFound = False Then
                'no record found
            Else
                'get result

                pViewBackgroundCtr = 2

                vRecs = 0
                Do While vFound = True
                    pViewBackgroundCtr = pViewBackgroundCtr + 1
                    If pViewBackgroundCtr > pViewBackgroundColorMax Then
                        pViewBackgroundCtr = 1
                    End If

                    lsvItems.Items.Add(vPetcCode)

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

                    If IsDBNull(vMyPgRd("lto_service_area")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("lto_service_area"))
                    End If

                    If IsDBNull(vMyPgRd("dti_accreditation_no")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("dti_accreditation_no"))
                    End If

                    If IsDBNull(vMyPgRd("lto_authorization_no")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("lto_authorization_no"))
                    End If

                    If IsDBNull(vMyPgRd("date_it_started")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(Format(CDate(vMyPgRd("date_it_started").ToString), "yyyy-MM-dd"))
                    End If

                    If IsDBNull(vMyPgRd("date_it_accredited")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(Format(CDate(vMyPgRd("date_it_accredited").ToString), "yyyy-MM-dd"))
                    End If

                    If IsDBNull(vMyPgRd("date_it_renewal")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(Format(CDate(vMyPgRd("date_it_renewal").ToString), "yyyy-MM-dd"))
                    End If

                    If IsDBNull(vMyPgRd("date_petc_started")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(Format(CDate(vMyPgRd("date_petc_started").ToString), "yyyy-MM-dd"))
                    End If

                    If IsDBNull(vMyPgRd("date_petc_accredited")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(Format(CDate(vMyPgRd("date_petc_accredited").ToString), "yyyy-MM-dd"))
                    End If

                    If IsDBNull(vMyPgRd("date_petc_authorized")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(Format(CDate(vMyPgRd("date_petc_authorized").ToString), "yyyy-MM-dd"))
                    End If

                    If IsDBNull(vMyPgRd("gm")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("gm"))
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

                    If IsDBNull(vMyPgRd("account_id")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("account_id"))
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

                    If IsDBNull(vMyPgRd("marketing_commission")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("0.00")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(Format(vMyPgRd("marketing_commission"), "###,###,###,##0.00"))
                    End If

                    If IsDBNull(vMyPgRd("transmission_fee")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("0.00")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(Format(vMyPgRd("transmission_fee"), "###,###,###,##0.00"))
                    End If

                    If IsDBNull(vMyPgRd("account_type")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("account_type"))
                    End If

                    If IsDBNull(vMyPgRd("remarks")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("remarks"))
                    End If

                    If IsDBNull(vMyPgRd("stradcom_fee")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("0.00")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(Format(vMyPgRd("stradcom_fee"), "###,###,###,##0.00"))
                    End If

                    If IsDBNull(vMyPgRd("max_credit")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("0.00")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(Format(vMyPgRd("max_credit"), "###,###,###,##0.00"))
                    End If

                    vRecs = vRecs + 1

                    lblStatusPrompt.Text = "Loading PETC data..." & Trim(Str(vRecs)) & " records read"
                    lblStatusPrompt.Refresh()

                    'read values
                    vFound = vMyPgRd.Read
                Loop
            End If

            lblStatusPrompt.Text = "Closing database..."
            lblStatusPrompt.Refresh()

            'close and dispose to avoid memory leak
            vMyPgRd.Close()
            vMyPgCmd.Dispose()

            'load imported PETC stations

            lblStatusPrompt.Text = "Loading PETC terminals..."
            lblStatusPrompt.Refresh()

            vQuery = "SELECT terminal_id, terminal_type, terminal_serial, terminal_mac, terminal_ip, terminal_machine_description, " & _
                "terminal_machine_serial, terminal_machine_calibrated, petc_code, petc_lane, is_active, description, lock_status, " & _
                "dll_file, machine_parity, machine_bits, machine_port, machine_baud_rate, machine_stop_bits, is_scsi FROM tb_tmp_stations"

            'create query
            vMyPgCmd = New NpgsqlCommand(vQuery, vMyPgCon)

            'execute query
            vMyPgRd = vMyPgCmd.ExecuteReader()

            'read values
            vFound = vMyPgRd.Read

            If vFound = False Then
                'no record found
            Else
                'get result

                pViewBackgroundCtr = 2

                vRecs = 0
                Do While vFound = True
                    pViewBackgroundCtr = pViewBackgroundCtr + 1
                    If pViewBackgroundCtr > pViewBackgroundColorMax Then
                        pViewBackgroundCtr = 1
                    End If

                    'If IsDBNull(vMyPgRd("terminal_id")) = True Then
                    ' lsvTerminals.Items.Add("")
                    ' Else
                    ' lsvTerminals.Items.Add(vMyPgRd("terminal_id"))
                    ' End If

                    If IsDBNull(vMyPgRd("petc_lane")) = True Then
                        lsvTerminals.Items.Add("PETC:" & vPetcCode)
                    Else
                        lsvTerminals.Items.Add("PETC:" & vPetcCode & "-" & vMyPgRd("petc_lane"))
                    End If

                    lsvTerminals.Items(lsvTerminals.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)

                    If IsDBNull(vMyPgRd("description")) = True Then
                        lsvTerminals.Items(lsvTerminals.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvTerminals.Items(lsvTerminals.Items.Count - 1).SubItems.Add(vMyPgRd("description"))
                    End If

                    If IsDBNull(vMyPgRd("terminal_type")) = True Then
                        lsvTerminals.Items(lsvTerminals.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvTerminals.Items(lsvTerminals.Items.Count - 1).SubItems.Add(vMyPgRd("terminal_type"))
                    End If

                    If IsDBNull(vMyPgRd("terminal_serial")) = True Then
                        lsvTerminals.Items(lsvTerminals.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvTerminals.Items(lsvTerminals.Items.Count - 1).SubItems.Add(vMyPgRd("terminal_serial"))
                    End If

                    If IsDBNull(vMyPgRd("terminal_mac")) = True Then
                        lsvTerminals.Items(lsvTerminals.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvTerminals.Items(lsvTerminals.Items.Count - 1).SubItems.Add(vMyPgRd("terminal_mac"))
                    End If

                    If IsDBNull(vMyPgRd("terminal_ip")) = True Then
                        lsvTerminals.Items(lsvTerminals.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvTerminals.Items(lsvTerminals.Items.Count - 1).SubItems.Add(vMyPgRd("terminal_ip"))
                    End If

                    If IsDBNull(vMyPgRd("is_active")) = True Then
                        lsvTerminals.Items(lsvTerminals.Items.Count - 1).SubItems.Add("Unknown")
                    Else
                        Select Case vMyPgRd("is_active")
                            Case 1
                                lsvTerminals.Items(lsvTerminals.Items.Count - 1).SubItems.Add("Active")

                            Case 0
                                lsvTerminals.Items(lsvTerminals.Items.Count - 1).SubItems.Add("Inactive")

                            Case Else
                                lsvTerminals.Items(lsvTerminals.Items.Count - 1).SubItems.Add("Unknown")
                        End Select
                    End If

                    'If IsDBNull(vMyPgRd("petc_code")) = True Then
                    ' lsvTerminals.Items(lsvTerminals.Items.Count - 1).SubItems.Add("")
                    ' Else
                    ' lsvTerminals.Items(lsvTerminals.Items.Count - 1).SubItems.Add(vMyPgRd("petc_code"))
                    ' End If

                    lsvTerminals.Items(lsvTerminals.Items.Count - 1).SubItems.Add(vPetcCode)

                    If IsDBNull(vMyPgRd("petc_lane")) = True Then
                        lsvTerminals.Items(lsvTerminals.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvTerminals.Items(lsvTerminals.Items.Count - 1).SubItems.Add(vMyPgRd("petc_lane"))
                    End If

                    If IsDBNull(vMyPgRd("terminal_machine_description")) = True Then
                        lsvTerminals.Items(lsvTerminals.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvTerminals.Items(lsvTerminals.Items.Count - 1).SubItems.Add(vMyPgRd("terminal_machine_description"))
                    End If

                    If IsDBNull(vMyPgRd("terminal_machine_serial")) = True Then
                        lsvTerminals.Items(lsvTerminals.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvTerminals.Items(lsvTerminals.Items.Count - 1).SubItems.Add(vMyPgRd("terminal_machine_serial"))
                    End If

                    If IsDBNull(vMyPgRd("terminal_machine_calibrated")) = True Then
                        lsvTerminals.Items(lsvTerminals.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvTerminals.Items(lsvTerminals.Items.Count - 1).SubItems.Add(Format(CDate(vMyPgRd("terminal_machine_calibrated").ToString), "MM/dd/yyyy"))
                    End If

                    If IsDBNull(vMyPgRd("lock_status")) = True Then
                        lsvTerminals.Items(lsvTerminals.Items.Count - 1).SubItems.Add("Unknown")
                    Else
                        Select Case vMyPgRd("lock_status")
                            Case 1
                                lsvTerminals.Items(lsvTerminals.Items.Count - 1).SubItems.Add("Yes")

                            Case 0
                                lsvTerminals.Items(lsvTerminals.Items.Count - 1).SubItems.Add("No")

                            Case Else
                                lsvTerminals.Items(lsvTerminals.Items.Count - 1).SubItems.Add("Unknown")
                        End Select
                    End If

                    If IsDBNull(vMyPgRd("dll_file")) = True Then
                        lsvTerminals.Items(lsvTerminals.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvTerminals.Items(lsvTerminals.Items.Count - 1).SubItems.Add(vMyPgRd("dll_file"))
                    End If

                    vTmpStr = ""

                    If IsDBNull(vMyPgRd("machine_port")) = True Then
                        vTmpStr = "COM:Unknown"
                    Else
                        vTmpStr = "COM:" & vMyPgRd("machine_port")
                    End If

                    If IsDBNull(vMyPgRd("machine_baud_rate")) = True Then
                        vTmpStr = vTmpStr & " Baud:Unknown"
                    Else
                        vTmpStr = vTmpStr & " Baud:" & vMyPgRd("machine_baud_rate")
                    End If

                    If IsDBNull(vMyPgRd("machine_parity")) = True Then
                        vTmpStr = vTmpStr & " Parity:Unknown"
                    Else
                        vTmpStr = vTmpStr & " Parity:" & vMyPgRd("machine_parity")
                    End If

                    If IsDBNull(vMyPgRd("machine_bits")) = True Then
                        vTmpStr = vTmpStr & " Bits:Unknown"
                    Else
                        vTmpStr = vTmpStr & " Bits:" & vMyPgRd("machine_bits")
                    End If

                    If IsDBNull(vMyPgRd("machine_stop_bits")) = True Then
                        vTmpStr = vTmpStr & " Stop bits:Unknown"
                    Else
                        vTmpStr = vTmpStr & " Stop bits:" & vMyPgRd("machine_stop_bits")
                    End If

                    lsvTerminals.Items(lsvTerminals.Items.Count - 1).SubItems.Add(vTmpStr)

                    If IsDBNull(vMyPgRd("is_scsi")) = True Then
                        lsvTerminals.Items(lsvTerminals.Items.Count - 1).SubItems.Add("Unknown")
                    Else
                        Select Case vMyPgRd("is_scsi")
                            Case 1
                                lsvTerminals.Items(lsvTerminals.Items.Count - 1).SubItems.Add("Yes")

                            Case 0
                                lsvTerminals.Items(lsvTerminals.Items.Count - 1).SubItems.Add("No")

                            Case Else
                                lsvTerminals.Items(lsvTerminals.Items.Count - 1).SubItems.Add("Unknown")
                        End Select
                    End If

                    vRecs = vRecs + 1

                    lblStatusPrompt.Text = "Loading PETC data..." & Trim(Str(vRecs)) & " records read"
                    lblStatusPrompt.Refresh()

                    'read values
                    vFound = vMyPgRd.Read
                Loop
            End If

            lblStatusPrompt.Text = "Closing database..."
            lblStatusPrompt.Refresh()

            'close and dispose to avoid memory leak
            vMyPgRd.Close()
            vMyPgCmd.Dispose()

            'load imported PETC users

            lblStatusPrompt.Text = "Loading PETC users..."
            lblStatusPrompt.Refresh()

            vQuery = "SELECT recno, user_id, employee_id, password, first_name, middle_name, last_name, gender, " & _
                "petc_code, certificate_tesda, certificate_tesda_expiration, is_active, description, user_type, user_name " & _
                "FROM tb_tmp_users"

            'create query
            vMyPgCmd = New NpgsqlCommand(vQuery, vMyPgCon)

            'execute query
            vMyPgRd = vMyPgCmd.ExecuteReader()

            'read values
            vFound = vMyPgRd.Read

            If vFound = False Then
                'no record found
            Else
                'get result

                pViewBackgroundCtr = 2

                vRecs = 0
                Do While vFound = True
                    pViewBackgroundCtr = pViewBackgroundCtr + 1
                    If pViewBackgroundCtr > pViewBackgroundColorMax Then
                        pViewBackgroundCtr = 1
                    End If

                    If IsDBNull(vMyPgRd("user_id")) = True Then
                        lsvUsers.Items.Add("")
                    Else
                        lsvUsers.Items.Add(vMyPgRd("user_id"))
                    End If

                    lsvUsers.Items(lsvUsers.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)

                    If IsDBNull(vMyPgRd("user_name")) = True Then
                        lsvUsers.Items(lsvUsers.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvUsers.Items(lsvUsers.Items.Count - 1).SubItems.Add(vMyPgRd("user_name"))
                    End If

                    If IsDBNull(vMyPgRd("user_type")) = True Then
                        lsvUsers.Items(lsvUsers.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvUsers.Items(lsvUsers.Items.Count - 1).SubItems.Add(vMyPgRd("user_type"))
                    End If

                    'If IsDBNull(vMyPgRd("petc_code")) = True Then
                    ' lsvUsers.Items(lsvUsers.Items.Count - 1).SubItems.Add("")
                    ' Else
                    ' lsvUsers.Items(lsvUsers.Items.Count - 1).SubItems.Add(vMyPgRd("petc_code"))
                    ' End If

                    lsvUsers.Items(lsvUsers.Items.Count - 1).SubItems.Add(vPetcCode)

                    If IsDBNull(vMyPgRd("is_active")) = True Then
                        lsvUsers.Items(lsvUsers.Items.Count - 1).SubItems.Add("Unknown")
                    Else
                        Select Case vMyPgRd("is_active")
                            Case 1
                                lsvUsers.Items(lsvUsers.Items.Count - 1).SubItems.Add("Active")

                            Case 0
                                lsvUsers.Items(lsvUsers.Items.Count - 1).SubItems.Add("Inactive")

                            Case Else
                                lsvUsers.Items(lsvUsers.Items.Count - 1).SubItems.Add("Unknown")
                        End Select
                    End If

                    If IsDBNull(vMyPgRd("description")) = True Then
                        lsvUsers.Items(lsvUsers.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvUsers.Items(lsvUsers.Items.Count - 1).SubItems.Add(vMyPgRd("description"))
                    End If

                    If IsDBNull(vMyPgRd("gender")) = True Then
                        lsvUsers.Items(lsvUsers.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvUsers.Items(lsvUsers.Items.Count - 1).SubItems.Add(vMyPgRd("gender"))
                    End If

                    If IsDBNull(vMyPgRd("certificate_tesda")) = True Then
                        lsvUsers.Items(lsvUsers.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvUsers.Items(lsvUsers.Items.Count - 1).SubItems.Add(vMyPgRd("certificate_tesda"))
                    End If

                    If IsDBNull(vMyPgRd("certificate_tesda_expiration")) = True Then
                        lsvUsers.Items(lsvUsers.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvUsers.Items(lsvUsers.Items.Count - 1).SubItems.Add(Format(CDate(vMyPgRd("certificate_tesda_expiration").ToString), "MM/dd/yyyy"))
                    End If

                    If IsDBNull(vMyPgRd("employee_id")) = True Then
                        lsvUsers.Items(lsvUsers.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvUsers.Items(lsvUsers.Items.Count - 1).SubItems.Add(vMyPgRd("employee_id"))
                    End If

                    If IsDBNull(vMyPgRd("recno")) = True Then
                        lsvUsers.Items(lsvUsers.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvUsers.Items(lsvUsers.Items.Count - 1).SubItems.Add(vMyPgRd("recno"))
                    End If

                    vRecs = vRecs + 1

                    lblStatusPrompt.Text = "Loading PETC data..." & Trim(Str(vRecs)) & " records read"
                    lblStatusPrompt.Refresh()

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

            lblPETC.Text = "PETC:" & vPetcCode

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
            vQuery = modModule.CreateLog(Me.Name, "Error:cmdImport", ex.Message)

            lblStatusPrompt.Visible = False
        End Try
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Dim vTmpStr As String

        'log event
        vTmpStr = modModule.CreateLog(Me.Name, "PETC Manager", "Import PETC - Close")

        If vTmpStr = "1" Then
            Me.Close()
        Else
            MsgBox("An error occurred while saving log. Operation aborted.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Operation cancelled")
        End If
    End Sub

    Private Sub txtPetcCode_GotFocus(sender As Object, e As EventArgs) Handles txtPetcCode.GotFocus
        txtPetcCode.SelectAll()
    End Sub

    Private Sub txtPetcCode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPetcCode.KeyPress
        If e.KeyChar = Chr(Keys.Return) Then
            cmdImport.Focus()
            cmdImport.Select()
        End If
    End Sub

    Private Sub txtPetcCode_LostFocus(sender As Object, e As EventArgs) Handles txtPetcCode.LostFocus
        txtPetcCode.Text = Trim(UCase(modModule.StripInvalidStringChars(txtPetcCode.Text)))
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

    Private Sub lsvItems_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsvItems.SelectedIndexChanged

    End Sub

    Private Sub lsvTerminals_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles lsvTerminals.ColumnClick
        Dim vNewSortingColumn As ColumnHeader = lsvTerminals.Columns(e.Column)  ' Get the new sorting column.
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

        lsvTerminals.ListViewItemSorter = New modModule.ListViewItemComparer(e.Column, vSortOrder)  ' Create a comparer.

        lsvTerminals.Sort()                                                     ' Sort.

        modModule.RefreshAlternateViewColors(lsvTerminals)
    End Sub

    Private Sub lsvTerminals_KeyPress(sender As Object, e As KeyPressEventArgs) Handles lsvTerminals.KeyPress
        Select Case Asc(e.KeyChar)
            Case 3
                modModule.CopyListViewToClipboard(lsvTerminals)

            Case 1
                modModule.ListViewSelectAll(lsvTerminals)
        End Select
    End Sub

    Private Sub lsvTerminals_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsvTerminals.SelectedIndexChanged

    End Sub

    Private Sub lsvUsers_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles lsvUsers.ColumnClick
        Dim vNewSortingColumn As ColumnHeader = lsvUsers.Columns(e.Column)  ' Get the new sorting column.
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

        lsvUsers.ListViewItemSorter = New modModule.ListViewItemComparer(e.Column, vSortOrder)  ' Create a comparer.

        lsvUsers.Sort()                                                     ' Sort.

        modModule.RefreshAlternateViewColors(lsvUsers)
    End Sub

    Private Sub lsvUsers_KeyPress(sender As Object, e As KeyPressEventArgs) Handles lsvUsers.KeyPress
        Select Case Asc(e.KeyChar)
            Case 3
                modModule.CopyListViewToClipboard(lsvUsers)

            Case 1
                modModule.ListViewSelectAll(lsvUsers)
        End Select
    End Sub

    Private Sub lsvUsers_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsvUsers.SelectedIndexChanged

    End Sub

    Private Sub txtPetcCode_TextChanged(sender As Object, e As EventArgs) Handles txtPetcCode.TextChanged

    End Sub

    Private Sub cmdCreate_Click(sender As Object, e As EventArgs) Handles cmdCreate.Click
        Dim vTmpVar As Integer

        If Len(Trim(lblPETC.Text)) <= 5 Then
            MsgBox("There is no PETC data or loading of data is incomplete." & vbCrLf & vbCrLf & _
                   "Please import or re-import data.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Incomplete data")

            Exit Sub
        End If

        If lsvItems.Items.Count <= 0 Then
            MsgBox("There is no PETC data." & vbCrLf & vbCrLf & _
                   "Please import PETC data first.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Incomplete data")

            Exit Sub
        End If

        If lsvItems.Items.Count > 1 Then
            MsgBox("There are more than one PETC data." & vbCrLf & vbCrLf & _
                   "You can only import only one PETC data. Please check imported data file.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Incomplete data")

            Exit Sub
        End If

        vTmpVar = MsgBox("You are about to create PETC, Terminals and Users data in the database." & vbCrLf & vbCrLf & _
                         "PETC Code: " & lsvItems.Items(0).Text & vbCrLf & _
                         "Terminals: " & lsvTerminals.Items.Count.ToString & vbCrLf & _
                         "Users: " & lsvUsers.Items.Count.ToString & vbCrLf & vbCrLf & _
                         "Are you sure of this?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "User confirmation")

        If vTmpVar <> MsgBoxResult.Yes Then
            Exit Sub
        End If

        're-import just to make sure nothing was changed or modified
        ImportData(Mid(lblPETC.Text, 6))

        pResultFrom = ""
        pResultStr = ""

        frmPetcManagerImportCreate.ShowDialog()
    End Sub

End Class