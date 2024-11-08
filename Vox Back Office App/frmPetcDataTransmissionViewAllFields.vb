Imports Npgsql

Public Class frmPetcDataTransmissionViewAllFields

    Private gRecNo As String
    Private gSortingColumn As ColumnHeader

    Property RecNo() As String
        Get
            Return gRecNo
        End Get

        Set(ByVal value As String)
            gRecNo = value
        End Set
    End Property

    Private Sub frmPetcDataTransmissionViewAllFields_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then Me.Close()
    End Sub

    Private Sub frmPetcDataTransmissionViewAllFields_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With lsvItems.Columns
            .Clear()

            .Add("Field").Width = 125
            .Add("Value").Width = 500
        End With

        lsvItems.Items.Clear()

        Me.KeyPreview = True

        timerLoad.Enabled = True
    End Sub

    Private Sub timerLoad_Tick(sender As Object, e As EventArgs) Handles timerLoad.Tick
        'open postgres connection
        Dim vMyPgCon As New NpgsqlConnection
        Dim vMyPgCmd = New NpgsqlCommand
        Dim vMyPgRd As NpgsqlDataReader
        Dim vFound As Boolean
        Dim vQuery As String

        timerLoad.Enabled = False

        Try
            gSortingColumn = Nothing
            lsvItems.ListViewItemSorter = Nothing
            modModule.RemoveSortHeaderInColumns(lsvItems)
            lsvItems.Items.Clear()

            'open db connection
            vMyPgCon.ConnectionString = pConnectVox
            vMyPgCon.Open()

            vQuery = "SELECT recno, terminal_id, lname, mname, fname, organization, plate_no, mv_file_no, chassis_no, engine_no, mv_type, " & _
                "make, fuel_type, color, classification, vehicle_model, vehicle_series, date_first_reg, cr_no, or_no, or_type, cec_number, " & _
                "petc_accr_no, datetime_tested, test_purpose, petc_name, test_ave_d, test_co, test_hc, rpm, petc_result, region_code, " & _
                "district_code, owner_address, body_type, diesel_type, gross_mv_weight, tesda, reprint, retest, voxid, image_filename, " & _
                "petc_code, authorization_id, valid_until, engine_type, transmission_type, net_cap, cylinder, rebuilt, cat_conv, turbo, " & _
                "non_turbo, elevation, n_aspirated, amount, cec_receipt_no, span, technician, co2, lambda, nox, o2, test_by, test_ip, " & _
                "test_station, test_date_time, image1_size, image2_size, mac, uploaded_stradcom, uploaded_lto, date_time_validated, " & _
                "transmission_fee, stradcom_fee, tran_id, statuscode, doc_status, statusdesc, denr_result, datetime_uploaded, " & _
                "remarks, date_inserted, processtimeid, color_description, body_type_name, class_name, make_description " & _
                 "FROM tb_petc_test WHERE recno = " & modModule.CorrectSqlString(Me.RecNo)

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

                pViewBackgroundCtr = pViewBackgroundCtr + 1
                If pViewBackgroundCtr > pViewBackgroundColorMax Then
                    pViewBackgroundCtr = 1
                End If

                lsvItems.Items.Add("Record no.")

                If IsDBNull(vMyPgRd("recno")) = True Then
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                Else
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("recno"))
                End If

                lsvItems.Items(lsvItems.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)

                pViewBackgroundCtr = pViewBackgroundCtr + 1
                If pViewBackgroundCtr > pViewBackgroundColorMax Then
                    pViewBackgroundCtr = 1
                End If

                lsvItems.Items.Add("Terminal ID")

                If IsDBNull(vMyPgRd("terminal_id")) = True Then
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                Else
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("terminal_id"))
                End If

                lsvItems.Items(lsvItems.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)

                pViewBackgroundCtr = pViewBackgroundCtr + 1
                If pViewBackgroundCtr > pViewBackgroundColorMax Then
                    pViewBackgroundCtr = 1
                End If

                lsvItems.Items.Add("Last name")

                If IsDBNull(vMyPgRd("lname")) = True Then
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                Else
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("lname"))
                End If

                lsvItems.Items(lsvItems.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)

                pViewBackgroundCtr = pViewBackgroundCtr + 1
                If pViewBackgroundCtr > pViewBackgroundColorMax Then
                    pViewBackgroundCtr = 1
                End If

                lsvItems.Items.Add("Middle name")

                If IsDBNull(vMyPgRd("mname")) = True Then
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                Else
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("mname"))
                End If

                lsvItems.Items(lsvItems.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)

                pViewBackgroundCtr = pViewBackgroundCtr + 1
                If pViewBackgroundCtr > pViewBackgroundColorMax Then
                    pViewBackgroundCtr = 1
                End If

                lsvItems.Items.Add("First name")

                If IsDBNull(vMyPgRd("fname")) = True Then
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                Else
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("fname"))
                End If

                lsvItems.Items(lsvItems.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)

                pViewBackgroundCtr = pViewBackgroundCtr + 1
                If pViewBackgroundCtr > pViewBackgroundColorMax Then
                    pViewBackgroundCtr = 1
                End If

                lsvItems.Items.Add("Organization")

                If IsDBNull(vMyPgRd("organization")) = True Then
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                Else
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("organization"))
                End If

                lsvItems.Items(lsvItems.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)

                pViewBackgroundCtr = pViewBackgroundCtr + 1
                If pViewBackgroundCtr > pViewBackgroundColorMax Then
                    pViewBackgroundCtr = 1
                End If

                lsvItems.Items.Add("Plate no.")

                If IsDBNull(vMyPgRd("plate_no")) = True Then
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                Else
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("plate_no"))
                End If

                lsvItems.Items(lsvItems.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)

                pViewBackgroundCtr = pViewBackgroundCtr + 1
                If pViewBackgroundCtr > pViewBackgroundColorMax Then
                    pViewBackgroundCtr = 1
                End If

                lsvItems.Items.Add("MV file no.")

                If IsDBNull(vMyPgRd("mv_file_no")) = True Then
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                Else
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("mv_file_no"))
                End If

                lsvItems.Items(lsvItems.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)

                pViewBackgroundCtr = pViewBackgroundCtr + 1
                If pViewBackgroundCtr > pViewBackgroundColorMax Then
                    pViewBackgroundCtr = 1
                End If

                lsvItems.Items.Add("Chassis no.")

                If IsDBNull(vMyPgRd("chassis_no")) = True Then
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                Else
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("chassis_no"))
                End If

                lsvItems.Items(lsvItems.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)

                pViewBackgroundCtr = pViewBackgroundCtr + 1
                If pViewBackgroundCtr > pViewBackgroundColorMax Then
                    pViewBackgroundCtr = 1
                End If

                lsvItems.Items.Add("Engine no.")

                If IsDBNull(vMyPgRd("engine_no")) = True Then
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                Else
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("engine_no"))
                End If

                lsvItems.Items(lsvItems.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)

                pViewBackgroundCtr = pViewBackgroundCtr + 1
                If pViewBackgroundCtr > pViewBackgroundColorMax Then
                    pViewBackgroundCtr = 1
                End If

                lsvItems.Items.Add("MV type")

                If IsDBNull(vMyPgRd("mv_type")) = True Then
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                Else
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("mv_type"))
                End If

                lsvItems.Items(lsvItems.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)

                pViewBackgroundCtr = pViewBackgroundCtr + 1
                If pViewBackgroundCtr > pViewBackgroundColorMax Then
                    pViewBackgroundCtr = 1
                End If

                lsvItems.Items.Add("Make")

                If IsDBNull(vMyPgRd("make")) = True Then
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                Else
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("make"))
                End If

                lsvItems.Items(lsvItems.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)

                pViewBackgroundCtr = pViewBackgroundCtr + 1
                If pViewBackgroundCtr > pViewBackgroundColorMax Then
                    pViewBackgroundCtr = 1
                End If

                lsvItems.Items.Add("Fuel type")

                If IsDBNull(vMyPgRd("fuel_type")) = True Then
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                Else
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("fuel_type"))
                End If

                lsvItems.Items(lsvItems.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)

                pViewBackgroundCtr = pViewBackgroundCtr + 1
                If pViewBackgroundCtr > pViewBackgroundColorMax Then
                    pViewBackgroundCtr = 1
                End If

                lsvItems.Items.Add("Color")

                If IsDBNull(vMyPgRd("color")) = True Then
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                Else
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("color"))
                End If

                lsvItems.Items(lsvItems.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)

                pViewBackgroundCtr = pViewBackgroundCtr + 1
                If pViewBackgroundCtr > pViewBackgroundColorMax Then
                    pViewBackgroundCtr = 1
                End If

                lsvItems.Items.Add("Classification")

                If IsDBNull(vMyPgRd("classification")) = True Then
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                Else
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("classification"))
                End If

                lsvItems.Items(lsvItems.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)

                pViewBackgroundCtr = pViewBackgroundCtr + 1
                If pViewBackgroundCtr > pViewBackgroundColorMax Then
                    pViewBackgroundCtr = 1
                End If

                lsvItems.Items.Add("Vehicle model")

                If IsDBNull(vMyPgRd("vehicle_model")) = True Then
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                Else
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("vehicle_model"))
                End If

                lsvItems.Items(lsvItems.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)

                pViewBackgroundCtr = pViewBackgroundCtr + 1
                If pViewBackgroundCtr > pViewBackgroundColorMax Then
                    pViewBackgroundCtr = 1
                End If

                lsvItems.Items.Add("Vehicle series")

                If IsDBNull(vMyPgRd("vehicle_series")) = True Then
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                Else
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("vehicle_series"))
                End If

                lsvItems.Items(lsvItems.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)

                pViewBackgroundCtr = pViewBackgroundCtr + 1
                If pViewBackgroundCtr > pViewBackgroundColorMax Then
                    pViewBackgroundCtr = 1
                End If

                lsvItems.Items.Add("Date first reg.")

                If IsDBNull(vMyPgRd("date_first_reg")) = True Then
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                Else
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("date_first_reg"))
                End If

                lsvItems.Items(lsvItems.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)

                pViewBackgroundCtr = pViewBackgroundCtr + 1
                If pViewBackgroundCtr > pViewBackgroundColorMax Then
                    pViewBackgroundCtr = 1
                End If

                lsvItems.Items.Add("CR no.")

                If IsDBNull(vMyPgRd("cr_no")) = True Then
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                Else
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("cr_no"))
                End If

                lsvItems.Items(lsvItems.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)

                pViewBackgroundCtr = pViewBackgroundCtr + 1
                If pViewBackgroundCtr > pViewBackgroundColorMax Then
                    pViewBackgroundCtr = 1
                End If

                lsvItems.Items.Add("OR no.")

                If IsDBNull(vMyPgRd("or_no")) = True Then
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                Else
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("or_no"))
                End If

                lsvItems.Items(lsvItems.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)

                pViewBackgroundCtr = pViewBackgroundCtr + 1
                If pViewBackgroundCtr > pViewBackgroundColorMax Then
                    pViewBackgroundCtr = 1
                End If

                lsvItems.Items.Add("OR type")

                If IsDBNull(vMyPgRd("or_type")) = True Then
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                Else
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("or_type"))
                End If

                lsvItems.Items(lsvItems.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)

                pViewBackgroundCtr = pViewBackgroundCtr + 1
                If pViewBackgroundCtr > pViewBackgroundColorMax Then
                    pViewBackgroundCtr = 1
                End If

                lsvItems.Items.Add("CEC number")

                If IsDBNull(vMyPgRd("cec_number")) = True Then
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                Else
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("cec_number"))
                End If

                lsvItems.Items(lsvItems.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)

                pViewBackgroundCtr = pViewBackgroundCtr + 1
                If pViewBackgroundCtr > pViewBackgroundColorMax Then
                    pViewBackgroundCtr = 1
                End If

                lsvItems.Items.Add("PETC accr. no.")

                If IsDBNull(vMyPgRd("petc_accr_no")) = True Then
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                Else
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("petc_accr_no"))
                End If

                lsvItems.Items(lsvItems.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)

                pViewBackgroundCtr = pViewBackgroundCtr + 1
                If pViewBackgroundCtr > pViewBackgroundColorMax Then
                    pViewBackgroundCtr = 1
                End If

                lsvItems.Items.Add("Date/time tested")

                If IsDBNull(vMyPgRd("datetime_tested")) = True Then
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                Else
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("datetime_tested"))
                End If

                lsvItems.Items(lsvItems.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)

                pViewBackgroundCtr = pViewBackgroundCtr + 1
                If pViewBackgroundCtr > pViewBackgroundColorMax Then
                    pViewBackgroundCtr = 1
                End If

                lsvItems.Items.Add("Test purpose")

                If IsDBNull(vMyPgRd("test_purpose")) = True Then
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                Else
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("test_purpose"))
                End If

                lsvItems.Items(lsvItems.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)

                pViewBackgroundCtr = pViewBackgroundCtr + 1
                If pViewBackgroundCtr > pViewBackgroundColorMax Then
                    pViewBackgroundCtr = 1
                End If

                lsvItems.Items.Add("PETC name")

                If IsDBNull(vMyPgRd("petc_name")) = True Then
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                Else
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("petc_name"))
                End If

                lsvItems.Items(lsvItems.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)

                pViewBackgroundCtr = pViewBackgroundCtr + 1
                If pViewBackgroundCtr > pViewBackgroundColorMax Then
                    pViewBackgroundCtr = 1
                End If

                lsvItems.Items.Add("Test ave. diesel")

                If IsDBNull(vMyPgRd("test_ave_d")) = True Then
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                Else
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("test_ave_d"))
                End If

                lsvItems.Items(lsvItems.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)

                pViewBackgroundCtr = pViewBackgroundCtr + 1
                If pViewBackgroundCtr > pViewBackgroundColorMax Then
                    pViewBackgroundCtr = 1
                End If

                lsvItems.Items.Add("Test CO")

                If IsDBNull(vMyPgRd("test_co")) = True Then
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                Else
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("test_co"))
                End If

                lsvItems.Items(lsvItems.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)

                pViewBackgroundCtr = pViewBackgroundCtr + 1
                If pViewBackgroundCtr > pViewBackgroundColorMax Then
                    pViewBackgroundCtr = 1
                End If

                lsvItems.Items.Add("Test HC")

                If IsDBNull(vMyPgRd("test_hc")) = True Then
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                Else
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("test_hc"))
                End If

                lsvItems.Items(lsvItems.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)

                pViewBackgroundCtr = pViewBackgroundCtr + 1
                If pViewBackgroundCtr > pViewBackgroundColorMax Then
                    pViewBackgroundCtr = 1
                End If

                lsvItems.Items.Add("RPM")

                If IsDBNull(vMyPgRd("rpm")) = True Then
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                Else
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("rpm"))
                End If

                lsvItems.Items(lsvItems.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)

                pViewBackgroundCtr = pViewBackgroundCtr + 1
                If pViewBackgroundCtr > pViewBackgroundColorMax Then
                    pViewBackgroundCtr = 1
                End If

                lsvItems.Items.Add("PETC result")

                If IsDBNull(vMyPgRd("petc_result")) = True Then
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                Else
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("petc_result"))
                End If

                lsvItems.Items(lsvItems.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)

                pViewBackgroundCtr = pViewBackgroundCtr + 1
                If pViewBackgroundCtr > pViewBackgroundColorMax Then
                    pViewBackgroundCtr = 1
                End If

                lsvItems.Items.Add("Region code")

                If IsDBNull(vMyPgRd("region_code")) = True Then
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                Else
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("region_code"))
                End If

                lsvItems.Items(lsvItems.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)

                pViewBackgroundCtr = pViewBackgroundCtr + 1
                If pViewBackgroundCtr > pViewBackgroundColorMax Then
                    pViewBackgroundCtr = 1
                End If

                lsvItems.Items.Add("District code")

                If IsDBNull(vMyPgRd("district_code")) = True Then
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                Else
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("district_code"))
                End If

                lsvItems.Items(lsvItems.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)

                pViewBackgroundCtr = pViewBackgroundCtr + 1
                If pViewBackgroundCtr > pViewBackgroundColorMax Then
                    pViewBackgroundCtr = 1
                End If

                lsvItems.Items.Add("Owner address")

                If IsDBNull(vMyPgRd("owner_address")) = True Then
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                Else
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("owner_address"))
                End If

                lsvItems.Items(lsvItems.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)

                pViewBackgroundCtr = pViewBackgroundCtr + 1
                If pViewBackgroundCtr > pViewBackgroundColorMax Then
                    pViewBackgroundCtr = 1
                End If

                lsvItems.Items.Add("Body type")

                If IsDBNull(vMyPgRd("body_type")) = True Then
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                Else
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("body_type"))
                End If

                lsvItems.Items(lsvItems.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)

                pViewBackgroundCtr = pViewBackgroundCtr + 1
                If pViewBackgroundCtr > pViewBackgroundColorMax Then
                    pViewBackgroundCtr = 1
                End If

                lsvItems.Items.Add("Diesel type")

                If IsDBNull(vMyPgRd("diesel_type")) = True Then
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                Else
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("diesel_type"))
                End If

                lsvItems.Items(lsvItems.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)

                pViewBackgroundCtr = pViewBackgroundCtr + 1
                If pViewBackgroundCtr > pViewBackgroundColorMax Then
                    pViewBackgroundCtr = 1
                End If

                lsvItems.Items.Add("Gross MV weight")

                If IsDBNull(vMyPgRd("gross_mv_weight")) = True Then
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                Else
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("gross_mv_weight"))
                End If

                lsvItems.Items(lsvItems.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)

                pViewBackgroundCtr = pViewBackgroundCtr + 1
                If pViewBackgroundCtr > pViewBackgroundColorMax Then
                    pViewBackgroundCtr = 1
                End If

                lsvItems.Items.Add("TESDA")

                If IsDBNull(vMyPgRd("tesda")) = True Then
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                Else
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("tesda"))
                End If

                lsvItems.Items(lsvItems.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)

                pViewBackgroundCtr = pViewBackgroundCtr + 1
                If pViewBackgroundCtr > pViewBackgroundColorMax Then
                    pViewBackgroundCtr = 1
                End If

                lsvItems.Items.Add("Re-print")

                If IsDBNull(vMyPgRd("reprint")) = True Then
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                Else
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("reprint"))
                End If

                lsvItems.Items(lsvItems.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)

                pViewBackgroundCtr = pViewBackgroundCtr + 1
                If pViewBackgroundCtr > pViewBackgroundColorMax Then
                    pViewBackgroundCtr = 1
                End If

                lsvItems.Items.Add("Re-test")

                If IsDBNull(vMyPgRd("retest")) = True Then
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                Else
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("retest"))
                End If

                lsvItems.Items(lsvItems.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)

                pViewBackgroundCtr = pViewBackgroundCtr + 1
                If pViewBackgroundCtr > pViewBackgroundColorMax Then
                    pViewBackgroundCtr = 1
                End If

                lsvItems.Items.Add("VOX ID")

                If IsDBNull(vMyPgRd("voxid")) = True Then
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                Else
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("voxid"))
                End If

                lsvItems.Items(lsvItems.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)

                pViewBackgroundCtr = pViewBackgroundCtr + 1
                If pViewBackgroundCtr > pViewBackgroundColorMax Then
                    pViewBackgroundCtr = 1
                End If

                lsvItems.Items.Add("Image filename")

                If IsDBNull(vMyPgRd("image_filename")) = True Then
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                Else
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("image_filename"))
                End If

                lsvItems.Items(lsvItems.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)

                pViewBackgroundCtr = pViewBackgroundCtr + 1
                If pViewBackgroundCtr > pViewBackgroundColorMax Then
                    pViewBackgroundCtr = 1
                End If

                lsvItems.Items.Add("PETC code")

                If IsDBNull(vMyPgRd("petc_code")) = True Then
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                Else
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("petc_code"))
                End If

                lsvItems.Items(lsvItems.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)

                pViewBackgroundCtr = pViewBackgroundCtr + 1
                If pViewBackgroundCtr > pViewBackgroundColorMax Then
                    pViewBackgroundCtr = 1
                End If

                lsvItems.Items.Add("Authorization ID")

                If IsDBNull(vMyPgRd("authorization_id")) = True Then
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                Else
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("authorization_id"))
                End If

                lsvItems.Items(lsvItems.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)

                pViewBackgroundCtr = pViewBackgroundCtr + 1
                If pViewBackgroundCtr > pViewBackgroundColorMax Then
                    pViewBackgroundCtr = 1
                End If

                lsvItems.Items.Add("Valid until")

                If IsDBNull(vMyPgRd("valid_until")) = True Then
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                Else
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("valid_until"))
                End If

                lsvItems.Items(lsvItems.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)

                pViewBackgroundCtr = pViewBackgroundCtr + 1
                If pViewBackgroundCtr > pViewBackgroundColorMax Then
                    pViewBackgroundCtr = 1
                End If

                lsvItems.Items.Add("Engine type")

                If IsDBNull(vMyPgRd("engine_type")) = True Then
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                Else
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("engine_type"))
                End If

                lsvItems.Items(lsvItems.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)

                pViewBackgroundCtr = pViewBackgroundCtr + 1
                If pViewBackgroundCtr > pViewBackgroundColorMax Then
                    pViewBackgroundCtr = 1
                End If

                lsvItems.Items.Add("Transmission type")

                If IsDBNull(vMyPgRd("transmission_type")) = True Then
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                Else
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("transmission_type"))
                End If

                lsvItems.Items(lsvItems.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)

                pViewBackgroundCtr = pViewBackgroundCtr + 1
                If pViewBackgroundCtr > pViewBackgroundColorMax Then
                    pViewBackgroundCtr = 1
                End If

                lsvItems.Items.Add("Net cap")

                If IsDBNull(vMyPgRd("net_cap")) = True Then
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                Else
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("net_cap"))
                End If

                lsvItems.Items(lsvItems.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)

                pViewBackgroundCtr = pViewBackgroundCtr + 1
                If pViewBackgroundCtr > pViewBackgroundColorMax Then
                    pViewBackgroundCtr = 1
                End If

                lsvItems.Items.Add("Cylinder")

                If IsDBNull(vMyPgRd("cylinder")) = True Then
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                Else
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("cylinder"))
                End If

                lsvItems.Items(lsvItems.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)

                pViewBackgroundCtr = pViewBackgroundCtr + 1
                If pViewBackgroundCtr > pViewBackgroundColorMax Then
                    pViewBackgroundCtr = 1
                End If

                lsvItems.Items.Add("Rebuilt")

                If IsDBNull(vMyPgRd("rebuilt")) = True Then
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                Else
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("rebuilt"))
                End If

                lsvItems.Items(lsvItems.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)

                pViewBackgroundCtr = pViewBackgroundCtr + 1
                If pViewBackgroundCtr > pViewBackgroundColorMax Then
                    pViewBackgroundCtr = 1
                End If

                lsvItems.Items.Add("Cat converter")

                If IsDBNull(vMyPgRd("cat_conv")) = True Then
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                Else
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("cat_conv"))
                End If

                lsvItems.Items(lsvItems.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)

                pViewBackgroundCtr = pViewBackgroundCtr + 1
                If pViewBackgroundCtr > pViewBackgroundColorMax Then
                    pViewBackgroundCtr = 1
                End If

                lsvItems.Items.Add("Turbo")

                If IsDBNull(vMyPgRd("turbo")) = True Then
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                Else
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("turbo"))
                End If

                lsvItems.Items(lsvItems.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)

                pViewBackgroundCtr = pViewBackgroundCtr + 1
                If pViewBackgroundCtr > pViewBackgroundColorMax Then
                    pViewBackgroundCtr = 1
                End If

                lsvItems.Items.Add("Non-turbo")

                If IsDBNull(vMyPgRd("non_turbo")) = True Then
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                Else
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("non_turbo"))
                End If

                lsvItems.Items(lsvItems.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)

                pViewBackgroundCtr = pViewBackgroundCtr + 1
                If pViewBackgroundCtr > pViewBackgroundColorMax Then
                    pViewBackgroundCtr = 1
                End If

                lsvItems.Items.Add("Elevation")

                If IsDBNull(vMyPgRd("elevation")) = True Then
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                Else
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("elevation"))
                End If

                lsvItems.Items(lsvItems.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)

                pViewBackgroundCtr = pViewBackgroundCtr + 1
                If pViewBackgroundCtr > pViewBackgroundColorMax Then
                    pViewBackgroundCtr = 1
                End If

                lsvItems.Items.Add("N. aspirated")

                If IsDBNull(vMyPgRd("n_aspirated")) = True Then
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                Else
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("n_aspirated"))
                End If

                lsvItems.Items(lsvItems.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)

                pViewBackgroundCtr = pViewBackgroundCtr + 1
                If pViewBackgroundCtr > pViewBackgroundColorMax Then
                    pViewBackgroundCtr = 1
                End If

                lsvItems.Items.Add("Amount")

                If IsDBNull(vMyPgRd("amount")) = True Then
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                Else
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("amount"))
                End If

                lsvItems.Items(lsvItems.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)

                pViewBackgroundCtr = pViewBackgroundCtr + 1
                If pViewBackgroundCtr > pViewBackgroundColorMax Then
                    pViewBackgroundCtr = 1
                End If

                lsvItems.Items.Add("CEC receipt no.")

                If IsDBNull(vMyPgRd("cec_receipt_no")) = True Then
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                Else
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("cec_receipt_no"))
                End If

                lsvItems.Items(lsvItems.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)

                pViewBackgroundCtr = pViewBackgroundCtr + 1
                If pViewBackgroundCtr > pViewBackgroundColorMax Then
                    pViewBackgroundCtr = 1
                End If

                lsvItems.Items.Add("Span")

                If IsDBNull(vMyPgRd("span")) = True Then
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                Else
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("span"))
                End If

                lsvItems.Items(lsvItems.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)

                pViewBackgroundCtr = pViewBackgroundCtr + 1
                If pViewBackgroundCtr > pViewBackgroundColorMax Then
                    pViewBackgroundCtr = 1
                End If

                lsvItems.Items.Add("Technician")

                If IsDBNull(vMyPgRd("technician")) = True Then
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                Else
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("technician"))
                End If

                lsvItems.Items(lsvItems.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)

                pViewBackgroundCtr = pViewBackgroundCtr + 1
                If pViewBackgroundCtr > pViewBackgroundColorMax Then
                    pViewBackgroundCtr = 1
                End If

                lsvItems.Items.Add("CO2")

                If IsDBNull(vMyPgRd("co2")) = True Then
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                Else
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("co2"))
                End If

                lsvItems.Items(lsvItems.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)

                pViewBackgroundCtr = pViewBackgroundCtr + 1
                If pViewBackgroundCtr > pViewBackgroundColorMax Then
                    pViewBackgroundCtr = 1
                End If

                lsvItems.Items.Add("Lambda")

                If IsDBNull(vMyPgRd("lambda")) = True Then
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                Else
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("lambda"))
                End If

                lsvItems.Items(lsvItems.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)

                pViewBackgroundCtr = pViewBackgroundCtr + 1
                If pViewBackgroundCtr > pViewBackgroundColorMax Then
                    pViewBackgroundCtr = 1
                End If

                lsvItems.Items.Add("Nox")

                If IsDBNull(vMyPgRd("nox")) = True Then
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                Else
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("nox"))
                End If

                lsvItems.Items(lsvItems.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)

                pViewBackgroundCtr = pViewBackgroundCtr + 1
                If pViewBackgroundCtr > pViewBackgroundColorMax Then
                    pViewBackgroundCtr = 1
                End If

                lsvItems.Items.Add("O2")

                If IsDBNull(vMyPgRd("o2")) = True Then
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                Else
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("o2"))
                End If

                lsvItems.Items(lsvItems.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)

                pViewBackgroundCtr = pViewBackgroundCtr + 1
                If pViewBackgroundCtr > pViewBackgroundColorMax Then
                    pViewBackgroundCtr = 1
                End If

                lsvItems.Items.Add("Tested by")

                If IsDBNull(vMyPgRd("test_by")) = True Then
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                Else
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("test_by"))
                End If

                lsvItems.Items(lsvItems.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)

                pViewBackgroundCtr = pViewBackgroundCtr + 1
                If pViewBackgroundCtr > pViewBackgroundColorMax Then
                    pViewBackgroundCtr = 1
                End If

                lsvItems.Items.Add("Test IP")

                If IsDBNull(vMyPgRd("test_ip")) = True Then
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                Else
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("test_ip"))
                End If

                lsvItems.Items(lsvItems.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)

                pViewBackgroundCtr = pViewBackgroundCtr + 1
                If pViewBackgroundCtr > pViewBackgroundColorMax Then
                    pViewBackgroundCtr = 1
                End If

                lsvItems.Items.Add("Test station")

                If IsDBNull(vMyPgRd("test_station")) = True Then
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                Else
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("test_station"))
                End If

                lsvItems.Items(lsvItems.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)

                pViewBackgroundCtr = pViewBackgroundCtr + 1
                If pViewBackgroundCtr > pViewBackgroundColorMax Then
                    pViewBackgroundCtr = 1
                End If

                lsvItems.Items.Add("Test date/time")

                If IsDBNull(vMyPgRd("test_date_time")) = True Then
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                Else
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("test_date_time"))
                End If

                lsvItems.Items(lsvItems.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)

                pViewBackgroundCtr = pViewBackgroundCtr + 1
                If pViewBackgroundCtr > pViewBackgroundColorMax Then
                    pViewBackgroundCtr = 1
                End If

                lsvItems.Items.Add("Image 1 size")

                If IsDBNull(vMyPgRd("image1_size")) = True Then
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("0")
                Else
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(Trim(Str(vMyPgRd("image1_size"))))
                End If

                lsvItems.Items(lsvItems.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)

                pViewBackgroundCtr = pViewBackgroundCtr + 1
                If pViewBackgroundCtr > pViewBackgroundColorMax Then
                    pViewBackgroundCtr = 1
                End If

                lsvItems.Items.Add("Image 2 size")

                If IsDBNull(vMyPgRd("image2_size")) = True Then
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("0")
                Else
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(Trim(Str(vMyPgRd("image2_size"))))
                End If

                lsvItems.Items(lsvItems.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)

                pViewBackgroundCtr = pViewBackgroundCtr + 1
                If pViewBackgroundCtr > pViewBackgroundColorMax Then
                    pViewBackgroundCtr = 1
                End If

                lsvItems.Items.Add("MAC")

                If IsDBNull(vMyPgRd("mac")) = True Then
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                Else
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("mac"))
                End If

                lsvItems.Items(lsvItems.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)

                pViewBackgroundCtr = pViewBackgroundCtr + 1
                If pViewBackgroundCtr > pViewBackgroundColorMax Then
                    pViewBackgroundCtr = 1
                End If

                lsvItems.Items.Add("Uploaded to Stradcom")

                If IsDBNull(vMyPgRd("uploaded_stradcom")) = True Then
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("0")
                Else
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(Trim(Str(vMyPgRd("uploaded_stradcom"))))
                End If

                lsvItems.Items(lsvItems.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)

                pViewBackgroundCtr = pViewBackgroundCtr + 1
                If pViewBackgroundCtr > pViewBackgroundColorMax Then
                    pViewBackgroundCtr = 1
                End If

                lsvItems.Items.Add("Uploaded to LTO")

                If IsDBNull(vMyPgRd("uploaded_lto")) = True Then
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("0")
                Else
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(Trim(Str(vMyPgRd("uploaded_lto"))))
                End If

                lsvItems.Items(lsvItems.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)

                pViewBackgroundCtr = pViewBackgroundCtr + 1
                If pViewBackgroundCtr > pViewBackgroundColorMax Then
                    pViewBackgroundCtr = 1
                End If

                lsvItems.Items.Add("Date/Time validated")

                If IsDBNull(vMyPgRd("date_time_validated")) = True Then
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                Else
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("date_time_validated"))
                End If

                lsvItems.Items(lsvItems.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)

                pViewBackgroundCtr = pViewBackgroundCtr + 1
                If pViewBackgroundCtr > pViewBackgroundColorMax Then
                    pViewBackgroundCtr = 1
                End If

                lsvItems.Items.Add("Transmission fee")

                If IsDBNull(vMyPgRd("transmission_fee")) = True Then
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("0")
                Else
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(Trim(Str(vMyPgRd("transmission_fee"))))
                End If

                lsvItems.Items(lsvItems.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)

                pViewBackgroundCtr = pViewBackgroundCtr + 1
                If pViewBackgroundCtr > pViewBackgroundColorMax Then
                    pViewBackgroundCtr = 1
                End If

                lsvItems.Items.Add("Stradcom fee")

                If IsDBNull(vMyPgRd("stradcom_fee")) = True Then
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("0")
                Else
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(Trim(Str(vMyPgRd("stradcom_fee"))))
                End If

                lsvItems.Items(lsvItems.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)

                pViewBackgroundCtr = pViewBackgroundCtr + 1
                If pViewBackgroundCtr > pViewBackgroundColorMax Then
                    pViewBackgroundCtr = 1
                End If

                lsvItems.Items.Add("Tran ID")

                If IsDBNull(vMyPgRd("tran_id")) = True Then
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                Else
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("tran_id"))
                End If

                lsvItems.Items(lsvItems.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)

                pViewBackgroundCtr = pViewBackgroundCtr + 1
                If pViewBackgroundCtr > pViewBackgroundColorMax Then
                    pViewBackgroundCtr = 1
                End If

                lsvItems.Items.Add("Status code")

                If IsDBNull(vMyPgRd("statuscode")) = True Then
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                Else
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("statuscode"))
                End If

                lsvItems.Items(lsvItems.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)

                pViewBackgroundCtr = pViewBackgroundCtr + 1
                If pViewBackgroundCtr > pViewBackgroundColorMax Then
                    pViewBackgroundCtr = 1
                End If

                lsvItems.Items.Add("Doc status")

                If IsDBNull(vMyPgRd("doc_status")) = True Then
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                Else
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("doc_status"))
                End If

                lsvItems.Items(lsvItems.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)

                pViewBackgroundCtr = pViewBackgroundCtr + 1
                If pViewBackgroundCtr > pViewBackgroundColorMax Then
                    pViewBackgroundCtr = 1
                End If

                lsvItems.Items.Add("Status description")

                If IsDBNull(vMyPgRd("statusdesc")) = True Then
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                Else
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("statusdesc"))
                End If

                lsvItems.Items(lsvItems.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)

                pViewBackgroundCtr = pViewBackgroundCtr + 1
                If pViewBackgroundCtr > pViewBackgroundColorMax Then
                    pViewBackgroundCtr = 1
                End If

                lsvItems.Items.Add("DENR result")

                If IsDBNull(vMyPgRd("denr_result")) = True Then
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                Else
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("denr_result"))
                End If

                lsvItems.Items(lsvItems.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)

                pViewBackgroundCtr = pViewBackgroundCtr + 1
                If pViewBackgroundCtr > pViewBackgroundColorMax Then
                    pViewBackgroundCtr = 1
                End If

                lsvItems.Items.Add("Date/Time uploaded")

                If IsDBNull(vMyPgRd("datetime_uploaded")) = True Then
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                Else
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("datetime_uploaded"))
                End If

                lsvItems.Items(lsvItems.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)

                pViewBackgroundCtr = pViewBackgroundCtr + 1
                If pViewBackgroundCtr > pViewBackgroundColorMax Then
                    pViewBackgroundCtr = 1
                End If

                lsvItems.Items.Add("Remarks")

                If IsDBNull(vMyPgRd("remarks")) = True Then
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                Else
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("remarks"))
                End If

                lsvItems.Items(lsvItems.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)

                pViewBackgroundCtr = pViewBackgroundCtr + 1
                If pViewBackgroundCtr > pViewBackgroundColorMax Then
                    pViewBackgroundCtr = 1
                End If

                lsvItems.Items.Add("Date inserted")

                If IsDBNull(vMyPgRd("date_inserted")) = True Then
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                Else
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("date_inserted"))
                End If

                lsvItems.Items(lsvItems.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)

                pViewBackgroundCtr = pViewBackgroundCtr + 1
                If pViewBackgroundCtr > pViewBackgroundColorMax Then
                    pViewBackgroundCtr = 1
                End If

                lsvItems.Items.Add("Process time ID")

                If IsDBNull(vMyPgRd("processtimeid")) = True Then
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                Else
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("processtimeid"))
                End If

                lsvItems.Items(lsvItems.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)

                pViewBackgroundCtr = pViewBackgroundCtr + 1
                If pViewBackgroundCtr > pViewBackgroundColorMax Then
                    pViewBackgroundCtr = 1
                End If

                lsvItems.Items.Add("Color description")

                If IsDBNull(vMyPgRd("color_description")) = True Then
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                Else
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("color_description"))
                End If

                lsvItems.Items(lsvItems.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)

                pViewBackgroundCtr = pViewBackgroundCtr + 1
                If pViewBackgroundCtr > pViewBackgroundColorMax Then
                    pViewBackgroundCtr = 1
                End If

                lsvItems.Items.Add("Body type name")

                If IsDBNull(vMyPgRd("body_type_name")) = True Then
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                Else
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("body_type_name"))
                End If

                lsvItems.Items(lsvItems.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)

                pViewBackgroundCtr = pViewBackgroundCtr + 1
                If pViewBackgroundCtr > pViewBackgroundColorMax Then
                    pViewBackgroundCtr = 1
                End If

                lsvItems.Items.Add("Class name")

                If IsDBNull(vMyPgRd("class_name")) = True Then
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                Else
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("class_name"))
                End If

                lsvItems.Items(lsvItems.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)

                pViewBackgroundCtr = pViewBackgroundCtr + 1
                If pViewBackgroundCtr > pViewBackgroundColorMax Then
                    pViewBackgroundCtr = 1
                End If

                lsvItems.Items.Add("Make description")

                If IsDBNull(vMyPgRd("make_description")) = True Then
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                Else
                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("make_description"))
                End If

                lsvItems.Items(lsvItems.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)
            End If

            'close and dispose to avoid memory leak
            vMyPgRd.Close()
            vMyPgCmd.Dispose()

            'close and dispose connection
            vMyPgCon.Close()
            vMyPgCon = Nothing

        Catch ex As Exception
            'an error has occured

            'close connections that might be open
            If IsNothing(vMyPgCon) = False Then
                If vMyPgCon.State <> ConnectionState.Closed Then
                    vMyPgCon.Close()
                    vMyPgCon = Nothing
                End If
            End If

            MsgBox("An error has occured." & vbCrLf & vbCr & _
                   "Error number: " & Trim(Str(Err.Number)) & vbCrLf & _
                   "Error description: " & Err.Description, MsgBoxStyle.OkOnly, "Error warning")

            'log event
            vQuery = modModule.CreateLog(Me.Name, "Error:timerLoad", ex.Message)
        End Try
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
End Class