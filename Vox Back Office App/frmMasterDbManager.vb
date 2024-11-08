Imports Npgsql

Public Class frmMasterDbManager

    Private gSortingColumn As ColumnHeader

    Private Sub ImplementPrivileges()
    End Sub

    Private Sub frmMasterDbManagerfrmAccountingStradcomBalanceManager_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

        ' 1 .Add("Plate no.", 100, HorizontalAlignment.Left)
        ' 2 .Add("Name", 150, HorizontalAlignment.Left)
        ' 3 .Add("First name", 75, HorizontalAlignment.Left)
        ' 4 .Add("Middle name", 75, HorizontalAlignment.Left)
        ' 5 .Add("Last name", 75, HorizontalAlignment.Left)
        ' 6 .Add("Organization", 75, HorizontalAlignment.Left)
        ' 7 .Add("MV file no.", 100, HorizontalAlignment.Left)
        ' 8 .Add("Chassis no.", 100, HorizontalAlignment.Left)
        ' 9 .Add("Engine no.", 100, HorizontalAlignment.Left)
        '10 .Add("MV type", 100, HorizontalAlignment.Left)
        '11 .Add("Make", 100, HorizontalAlignment.Left)
        '12 .Add("Fuel type", 100, HorizontalAlignment.Left)
        '13 .Add("Color", 100, HorizontalAlignment.Left)
        '14 .Add("Classification", 100, HorizontalAlignment.Left)
        '15 .Add("Model", 100, HorizontalAlignment.Left)
        '16 .Add("Series", 100, HorizontalAlignment.Left)
        '17 .Add("Date first registration", 100, HorizontalAlignment.Left)
        '18 .Add("CR no.", 100, HorizontalAlignment.Left)
        '19 .Add("Address", 150, HorizontalAlignment.Left)
        '20 .Add("Body type", 100, HorizontalAlignment.Left)
        '21 .Add("Diesel type", 100, HorizontalAlignment.Left)
        '22 .Add("Cylinder", 100, HorizontalAlignment.Left)
        '23 .Add("Gross weight", 100, HorizontalAlignment.Left)
        '24 .Add("Engine type", 100, HorizontalAlignment.Left)
        '25 .Add("Transmission", 100, HorizontalAlignment.Left)
        '26 .Add("Net cap", 100, HorizontalAlignment.Left)
        '27 .Add("Rebuilt", 100, HorizontalAlignment.Left)
        '28 .Add("Cat. conv.", 100, HorizontalAlignment.Left)
        '29 .Add("Turbo", 100, HorizontalAlignment.Left)
        '30 .Add("Non-turbo", 100, HorizontalAlignment.Left)
        '31 .Add("Elevation", 100, HorizontalAlignment.Left)
        '32 .Add("N aspirated", 100, HorizontalAlignment.Left)
        '33 .Add("Span", 100, HorizontalAlignment.Left)
        '34 .Add("Denomination", 100, HorizontalAlignment.Left)
        '35 .Add("Displaement", 100, HorizontalAlignment.Left)
        '36 .Add("Net weight", 100, HorizontalAlignment.Left)
        '37 .Add("Ship weight", 100, HorizontalAlignment.Left)
        '38 .Add("Cap weight", 100, HorizontalAlignment.Left)
        '39 .Add("Status", 100, HorizontalAlignment.Left)
        '40 .Add("RecNo", 0, HorizontalAlignment.Right)

        With lsvItems.Columns
            .Clear()

            .Add("Plate no.", 100, HorizontalAlignment.Left)
            .Add("Name", 150, HorizontalAlignment.Left)
            .Add("First name", 75, HorizontalAlignment.Left)
            .Add("Middle name", 75, HorizontalAlignment.Left)
            .Add("Last name", 75, HorizontalAlignment.Left)
            .Add("Organization", 75, HorizontalAlignment.Left)

            .Add("MV file no.", 100, HorizontalAlignment.Left)
            .Add("Chassis no.", 100, HorizontalAlignment.Left)
            .Add("Engine no.", 100, HorizontalAlignment.Left)
            .Add("MV type", 100, HorizontalAlignment.Left)
            .Add("Make", 100, HorizontalAlignment.Left)
            .Add("Fuel type", 100, HorizontalAlignment.Left)
            .Add("Color", 100, HorizontalAlignment.Left)
            .Add("Classification", 100, HorizontalAlignment.Left)
            .Add("Model", 100, HorizontalAlignment.Left)
            .Add("Series", 100, HorizontalAlignment.Left)

            .Add("Date first registration", 100, HorizontalAlignment.Left)
            .Add("CR no.", 100, HorizontalAlignment.Left)
            .Add("Address", 150, HorizontalAlignment.Left)

            .Add("Body type", 100, HorizontalAlignment.Left)
            .Add("Diesel type", 100, HorizontalAlignment.Left)
            .Add("Cylinder", 100, HorizontalAlignment.Left)
            .Add("Gross weight", 100, HorizontalAlignment.Left)
            .Add("Engine type", 100, HorizontalAlignment.Left)
            .Add("Transmission", 100, HorizontalAlignment.Left)
            .Add("Net cap", 100, HorizontalAlignment.Left)
            .Add("Rebuilt", 100, HorizontalAlignment.Left)
            .Add("Cat. conv.", 100, HorizontalAlignment.Left)
            .Add("Turbo", 100, HorizontalAlignment.Left)
            .Add("Non-turbo", 100, HorizontalAlignment.Left)
            .Add("Elevation", 100, HorizontalAlignment.Left)
            .Add("N aspirated", 100, HorizontalAlignment.Left)
            .Add("Span", 100, HorizontalAlignment.Left)
            .Add("Denomination", 100, HorizontalAlignment.Left)
            .Add("Displaement", 100, HorizontalAlignment.Left)
            .Add("Net weight", 100, HorizontalAlignment.Left)
            .Add("Ship weight", 100, HorizontalAlignment.Left)
            .Add("Cap weight", 100, HorizontalAlignment.Left)
            .Add("Status", 100, HorizontalAlignment.Left)

            .Add("RecNo", 0, HorizontalAlignment.Right)
        End With

        lsvItems.Items.Clear()

        txtPlateNo.Text = "PLEASE ENTER FILTER HERE"
        txtName.Text = ""

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

        cmdRebuild.Enabled = False

        ImplementPrivileges()

        Dim vTmpStr As String

        'log event
        vTmpStr = modModule.CreateLog(Me.Name, "Emission Master DB Manager - Open", "")

        timerDataLoad.Enabled = True
    End Sub

    Private Sub timerDataLoad_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timerDataLoad.Tick
        'open postgres connection
        Dim vMyPgCon As New NpgsqlConnection
        Dim vMyPgCmd = New NpgsqlCommand
        Dim vMyPgRd As NpgsqlDataReader

        Dim vMyPgCon2 As New NpgsqlConnection
        Dim vMyPgCmd2 = New NpgsqlCommand
        Dim vMyPgRd2 As NpgsqlDataReader

        Dim vFound As Boolean

        Dim vFilter As String
        Dim vQuery As String

        Dim vRecs As Long
        Dim vTmpVar As Integer
        Dim vTmpStr As String = ""

        timerDataLoad.Enabled = False

        Try
            gSortingColumn = Nothing
            lsvItems.ListViewItemSorter = Nothing
            modModule.RemoveSortHeaderInColumns(lsvItems)
            lsvItems.Items.Clear()

            lblHeader.Text = "Emission Master DB Manager"

            lblStatusPrompt.Text = "Opening database..."
            lblStatusPrompt.Visible = True
            lblStatusPrompt.Refresh()

            'open db connection
            vMyPgCon.ConnectionString = pConnectMasterDb
            vMyPgCon.Open()

            vMyPgCon2.ConnectionString = pConnectVox
            vMyPgCon2.Open()

            lblStatusPrompt.Text = "Please wait... gathering emission master db record..."
            lblStatusPrompt.Refresh()

            vFilter = ""

            If Trim(txtPlateNo.Text) <> "" Then
                vFilter = vFilter & IIf(Trim(vFilter) = "", " WHERE ", " AND ") & " plate_no = '" & _
                    modModule.CorrectSqlString(modModule.HashData(1, txtPlateNo.Text)) & "'"
            End If

            If Trim(txtName.Text) <> "" Then
                vFilter = vFilter & IIf(Trim(vFilter) = "", " WHERE ", " AND ") & " name LIKE '%" & _
                    modModule.CorrectSqlString(modModule.HashData(1, txtName.Text)) & "%'"
            End If

            vQuery = "SELECT plate_no, name, lname, mname, fname, organization, mv_file_no, chassis_no, " & _
                        "engine_no, mv_type, make, fuel_type, color, classification, vehicle_model, vehicle_series, date_first_reg, " & _
                        "cr_no, owner_address, body_type, diesel_type, cylinder, gross_mv_weight, engine_type, transmission_type, " & _
                        "net_cap, rebuilt, cat_conv, turbo, non_turbo, elevation, n_aspirated, span, denomination, displacement, " & _
                        "net_weight, ship_weight, cap_weight, status, recno FROM lto.tb_emission_db " & vFilter & " " & _
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
                'get data then decrypt

                pViewBackgroundCtr = 2

                Do While vFound = True
                    pViewBackgroundCtr = pViewBackgroundCtr + 1
                    If pViewBackgroundCtr > pViewBackgroundColorMax Then
                        pViewBackgroundCtr = 1
                    End If

                    If IsDBNull(vMyPgRd("plate_no")) = True Then
                        lsvItems.Items.Add("")
                    Else
                        lsvItems.Items.Add(modModule.UnHashData(1, vMyPgRd("plate_no")))
                    End If

                    lsvItems.Items(lsvItems.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)

                    If IsDBNull(vMyPgRd("name")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(modModule.UnHashData(1, vMyPgRd("name")))
                    End If

                    If IsDBNull(vMyPgRd("fname")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(modModule.UnHashData(1, vMyPgRd("fname")))
                    End If

                    If IsDBNull(vMyPgRd("mname")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(modModule.UnHashData(1, vMyPgRd("mname")))
                    End If

                    If IsDBNull(vMyPgRd("lname")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(modModule.UnHashData(1, vMyPgRd("lname")))
                    End If

                    If IsDBNull(vMyPgRd("organization")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(modModule.UnHashData(1, vMyPgRd("organization")))
                    End If

                    If IsDBNull(vMyPgRd("mv_file_no")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(modModule.UnHashData(1, vMyPgRd("mv_file_no")))
                    End If

                    If IsDBNull(vMyPgRd("chassis_no")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(modModule.UnHashData(1, vMyPgRd("chassis_no")))
                    End If

                    If IsDBNull(vMyPgRd("engine_no")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(modModule.UnHashData(1, vMyPgRd("engine_no")))
                    End If

                    If IsDBNull(vMyPgRd("mv_type")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        vTmpStr = modModule.UnHashData(1, vMyPgRd("mv_type"))

                        'get description
                        vQuery = "SELECT class_name FROM tb_mv_types WHERE UPPER(class_code) = '" & UCase(vTmpStr) & "' ORDER BY is_active DESC"

                        'create query
                        vMyPgCmd2 = New NpgsqlCommand(vQuery, vMyPgCon2)

                        'execute query
                        vMyPgRd2 = vMyPgCmd2.ExecuteReader()

                        'read values
                        vFound = vMyPgRd2.Read

                        If vFound = True Then
                            If IsDBNull(vMyPgRd2("class_name")) = False Then
                                vTmpStr = vTmpStr & " (" & vMyPgRd2("class_name") & ")"
                            End If
                        End If

                        'close connection
                        vMyPgRd2.Close()
                        vMyPgCmd2.Dispose()

                        'display code and description
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vTmpStr)
                    End If

                    If IsDBNull(vMyPgRd("make")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        vTmpStr = modModule.UnHashData(1, vMyPgRd("make"))

                        'get description
                        vQuery = "SELECT make_description FROM tb_mv_make_series WHERE UPPER(make) = '" & UCase(vTmpStr) & "' ORDER BY is_active DESC"

                        'create query
                        vMyPgCmd2 = New NpgsqlCommand(vQuery, vMyPgCon2)

                        'execute query
                        vMyPgRd2 = vMyPgCmd2.ExecuteReader()

                        'read values
                        vFound = vMyPgRd2.Read

                        If vFound = True Then
                            If IsDBNull(vMyPgRd2("make_description")) = False Then
                                vTmpStr = vTmpStr & " (" & vMyPgRd2("make_description") & ")"
                            End If
                        End If

                        'close connection
                        vMyPgRd2.Close()
                        vMyPgCmd2.Dispose()

                        'display code and description
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vTmpStr)
                    End If

                    If IsDBNull(vMyPgRd("fuel_type")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(modModule.UnHashData(1, vMyPgRd("fuel_type")))
                    End If

                    If IsDBNull(vMyPgRd("color")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        vTmpStr = modModule.UnHashData(1, vMyPgRd("color"))

                        'get description
                        vQuery = "SELECT color_description FROM tb_colors WHERE UPPER(color_code) = '" & UCase(vTmpStr) & "' ORDER BY is_active DESC"

                        'create query
                        vMyPgCmd2 = New NpgsqlCommand(vQuery, vMyPgCon2)

                        'execute query
                        vMyPgRd2 = vMyPgCmd2.ExecuteReader()

                        'read values
                        vFound = vMyPgRd2.Read

                        If vFound = True Then
                            If IsDBNull(vMyPgRd2("color_description")) = False Then
                                vTmpStr = vTmpStr & " (" & vMyPgRd2("color_description") & ")"
                            End If
                        End If

                        'close connection
                        vMyPgRd2.Close()
                        vMyPgCmd2.Dispose()

                        'display code and description
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vTmpStr)
                    End If

                    If IsDBNull(vMyPgRd("classification")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        vTmpStr = modModule.UnHashData(1, vMyPgRd("classification"))

                        'get description
                        vQuery = "SELECT class_name FROM tb_classifications WHERE UPPER(class_code) = '" & UCase(vTmpStr) & "' ORDER BY is_active DESC"

                        'create query
                        vMyPgCmd2 = New NpgsqlCommand(vQuery, vMyPgCon2)

                        'execute query
                        vMyPgRd2 = vMyPgCmd2.ExecuteReader()

                        'read values
                        vFound = vMyPgRd2.Read

                        If vFound = True Then
                            If IsDBNull(vMyPgRd2("class_name")) = False Then
                                vTmpStr = vTmpStr & " (" & vMyPgRd2("class_name") & ")"
                            End If
                        End If

                        'close connection
                        vMyPgRd2.Close()
                        vMyPgCmd2.Dispose()

                        'display code and description
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vTmpStr)
                    End If

                    If IsDBNull(vMyPgRd("vehicle_model")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(modModule.UnHashData(1, vMyPgRd("vehicle_model")))
                    End If

                    If IsDBNull(vMyPgRd("vehicle_series")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(modModule.UnHashData(1, vMyPgRd("vehicle_series")))
                    End If

                    If IsDBNull(vMyPgRd("date_first_reg")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(modModule.UnHashData(1, vMyPgRd("date_first_reg")))
                    End If

                    If IsDBNull(vMyPgRd("cr_no")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(modModule.UnHashData(1, vMyPgRd("cr_no")))
                    End If

                    If IsDBNull(vMyPgRd("owner_address")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(modModule.UnHashData(1, vMyPgRd("owner_address")))
                    End If

                    If IsDBNull(vMyPgRd("body_type")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        vTmpStr = modModule.UnHashData(1, vMyPgRd("body_type"))

                        'get description
                        vQuery = "SELECT body_type_name FROM tb_body_types WHERE UPPER(body_type_code) = '" & UCase(vTmpStr) & "' ORDER BY is_active DESC"

                        'create query
                        vMyPgCmd2 = New NpgsqlCommand(vQuery, vMyPgCon2)

                        'execute query
                        vMyPgRd2 = vMyPgCmd2.ExecuteReader()

                        'read values
                        vFound = vMyPgRd2.Read

                        If vFound = True Then
                            If IsDBNull(vMyPgRd2("body_type_name")) = False Then
                                vTmpStr = vTmpStr & " (" & vMyPgRd2("body_type_name") & ")"
                            End If
                        End If

                        'close connection
                        vMyPgRd2.Close()
                        vMyPgCmd2.Dispose()

                        'display code and description
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vTmpStr)
                    End If

                    If IsDBNull(vMyPgRd("diesel_type")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        vTmpStr = modModule.UnHashData(1, vMyPgRd("diesel_type"))

                        'get description
                        vQuery = "SELECT diesel_description FROM tb_diesel_types WHERE UPPER(diesel_code) = '" & UCase(vTmpStr) & "' ORDER BY is_active DESC"

                        'create query
                        vMyPgCmd2 = New NpgsqlCommand(vQuery, vMyPgCon2)

                        'execute query
                        vMyPgRd2 = vMyPgCmd2.ExecuteReader()

                        'read values
                        vFound = vMyPgRd2.Read

                        If vFound = True Then
                            If IsDBNull(vMyPgRd2("diesel_description")) = False Then
                                vTmpStr = vTmpStr & " (" & vMyPgRd2("diesel_description") & ")"
                            End If
                        End If

                        'close connection
                        vMyPgRd2.Close()
                        vMyPgCmd2.Dispose()

                        'display code and description
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vTmpStr)
                    End If

                    If IsDBNull(vMyPgRd("cylinder")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(modModule.UnHashData(1, vMyPgRd("cylinder")))
                    End If

                    If IsDBNull(vMyPgRd("gross_mv_weight")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(modModule.UnHashData(1, vMyPgRd("gross_mv_weight")))
                    End If

                    If IsDBNull(vMyPgRd("engine_type")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(modModule.UnHashData(1, vMyPgRd("engine_type")))
                    End If

                    If IsDBNull(vMyPgRd("transmission_type")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(modModule.UnHashData(1, vMyPgRd("transmission_type")))
                    End If

                    If IsDBNull(vMyPgRd("net_cap")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(modModule.UnHashData(1, vMyPgRd("net_cap")))
                    End If

                    If IsDBNull(vMyPgRd("rebuilt")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(modModule.UnHashData(1, vMyPgRd("rebuilt")))
                    End If

                    If IsDBNull(vMyPgRd("cat_conv")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(modModule.UnHashData(1, vMyPgRd("cat_conv")))
                    End If

                    If IsDBNull(vMyPgRd("turbo")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(modModule.UnHashData(1, vMyPgRd("turbo")))
                    End If

                    If IsDBNull(vMyPgRd("non_turbo")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(modModule.UnHashData(1, vMyPgRd("non_turbo")))
                    End If

                    If IsDBNull(vMyPgRd("elevation")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(modModule.UnHashData(1, vMyPgRd("elevation")))
                    End If

                    If IsDBNull(vMyPgRd("n_aspirated")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(modModule.UnHashData(1, vMyPgRd("n_aspirated")))
                    End If

                    If IsDBNull(vMyPgRd("span")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(modModule.UnHashData(1, vMyPgRd("span")))
                    End If

                    If IsDBNull(vMyPgRd("denomination")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(modModule.UnHashData(1, vMyPgRd("denomination")))
                    End If

                    If IsDBNull(vMyPgRd("displacement")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(modModule.UnHashData(1, vMyPgRd("displacement")))
                    End If

                    If IsDBNull(vMyPgRd("net_weight")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(modModule.UnHashData(1, vMyPgRd("net_weight")))
                    End If

                    If IsDBNull(vMyPgRd("ship_weight")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(modModule.UnHashData(1, vMyPgRd("ship_weight")))
                    End If

                    If IsDBNull(vMyPgRd("cap_weight")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(modModule.UnHashData(1, vMyPgRd("cap_weight")))
                    End If

                    If IsDBNull(vMyPgRd("status")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(modModule.UnHashData(1, vMyPgRd("status")))
                    End If

                    If IsDBNull(vMyPgRd("recno")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("recno"))
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

            'close and dispose to avoid memory leak
            vMyPgRd.Close()
            vMyPgCmd.Dispose()

            lblStatusPrompt.Text = "Closing database..."
            lblStatusPrompt.Refresh()

            'close and dispose to avoid memory leak
            vMyPgRd.Close()
            vMyPgCmd.Dispose()

            'close and dispose connection
            vMyPgCon2.Close()
            vMyPgCon2 = Nothing

            vMyPgCon.Close()
            vMyPgCon = Nothing

            lblHeader.Text = "Emission Master DB Manager - " & vRecs.ToString("###,###,###,##0") & " record(s) found"

            lblStatusPrompt.Visible = False

        Catch ex As Exception
            'an error has occured

            'close connections that might be open
            If IsNothing(vMyPgCon2) = False Then
                If vMyPgCon2.State <> ConnectionState.Closed Then
                    vMyPgCon2.Close()
                    vMyPgCon2 = Nothing
                End If
            End If

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

    Private Sub frmMasterDbManager_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
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
        Dim vTmpVar As Integer

        'lsvItems.Items.Clear()
        'lsvDetails.Items.Clear()

        If Trim(txtName.Text) = "" And Trim(txtPlateNo.Text) = "" Then
            vTmpVar = MsgBox("You did not enter any filters and may return large number of records." & vbCrLf & vbCrLf & _
                           "Are you sure of this?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "User confirmation")

            If vTmpVar <> vbYes Then Exit Sub
        End If

        If timerDataLoad.Enabled = False Then timerDataLoad.Enabled = True
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Dim vTmpStr As String

        'log event
        vTmpStr = modModule.CreateLog(Me.Name, "Emission Master DB Manager - Close", "")

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

    Private Sub txtPlateNo_GotFocus(sender As Object, e As EventArgs) Handles txtPlateNo.GotFocus
        txtPlateNo.SelectAll()
    End Sub

    Private Sub txtPlateNo_LostFocus(sender As Object, e As EventArgs) Handles txtPlateNo.LostFocus
        txtPlateNo.Text = modModule.StripInvalidStringChars(UCase(txtPlateNo.Text))
    End Sub

    Private Sub lsvItems_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsvItems.SelectedIndexChanged

    End Sub

    Private Sub txtName_GotFocus(sender As Object, e As EventArgs) Handles txtName.GotFocus
        txtName.SelectAll()
    End Sub

    Private Sub txtName_LostFocus(sender As Object, e As EventArgs) Handles txtName.LostFocus
        txtName.Text = modModule.StripInvalidStringChars(UCase(txtName.Text))
    End Sub

    Private Sub txtDateTo_TextChanged(sender As Object, e As EventArgs) Handles txtName.TextChanged

    End Sub

    Private Sub txtDateFrom_TextChanged(sender As Object, e As EventArgs) Handles txtPlateNo.TextChanged

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

    Private Sub cmdRebuild_Click(sender As Object, e As EventArgs) Handles cmdRebuild.Click
        frmMasterDbRebuild.ShowDialog()
    End Sub
End Class