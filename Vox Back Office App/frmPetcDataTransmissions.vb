Imports Npgsql
Imports System.IO

Public Class frmPetcDataTransmissions

    Private gSortingColumn As ColumnHeader

    Private Sub ImplementPrivileges()
    End Sub

    Private Sub frmPetcDataTransmissions_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

        With lsvItems.Columns
            .Clear()

            .Add("Date/Time tested", 125, HorizontalAlignment.Left)
            .Add("Petc code", 70, HorizontalAlignment.Left)
            .Add("Petc name", 150, HorizontalAlignment.Left)
            .Add("Terminal ID", 100, HorizontalAlignment.Left)
            .Add("Plate no.", 100, HorizontalAlignment.Left)
            .Add("Name/Organization", 150, HorizontalAlignment.Left)
            .Add("CEC no.", 100, HorizontalAlignment.Left)
            .Add("Stradcom processed", 50, HorizontalAlignment.Left)
            .Add("LTO processed", 50, HorizontalAlignment.Left)
            .Add("Doc. status", 70, HorizontalAlignment.Left)
            .Add("Status description", 150, HorizontalAlignment.Left)
            .Add("Authorization ID", 100, HorizontalAlignment.Left)
            .Add("MV File no.", 100, HorizontalAlignment.Left)
            .Add("Chassis no.", 100, HorizontalAlignment.Left)
            .Add("Engine no.", 100, HorizontalAlignment.Left)
            .Add("MV type", 60, HorizontalAlignment.Left)
            .Add("Make", 100, HorizontalAlignment.Left)
            .Add("Fuel type", 60, HorizontalAlignment.Left)
            .Add("Color", 100, HorizontalAlignment.Left)
            .Add("Model", 50, HorizontalAlignment.Left)
            .Add("Series", 100, HorizontalAlignment.Left)
            .Add("CR no.", 100, HorizontalAlignment.Left)
            .Add("OR no.", 100, HorizontalAlignment.Left)
            .Add("Technician", 100, HorizontalAlignment.Left)
            .Add("Test purpose", 100, HorizontalAlignment.Left)
            .Add("Engine type", 100, HorizontalAlignment.Left)
            .Add("Opacity", 50, HorizontalAlignment.Right)
            .Add("CO", 50, HorizontalAlignment.Right)
            .Add("HC", 50, HorizontalAlignment.Right)
            .Add("PETC result", 100, HorizontalAlignment.Left)
            .Add("DENR result", 100, HorizontalAlignment.Left)
            .Add("Reprint", 60, HorizontalAlignment.Left)
            .Add("Retest", 60, HorizontalAlignment.Left)
            .Add("Owner address", 150, HorizontalAlignment.Left)
            .Add("Rec. no.", 100, HorizontalAlignment.Right)
        End With

        lsvItems.Items.Clear()

        txtDateFrom.Text = DateTime.Now.ToString("MM/dd/yyyy")
        txtDateTo.Text = txtDateFrom.Text

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

            vDataRow1 = vDataTable1.NewRow
            vDataRow1(0) = "Petc code"
            vDataRow1(1) = "epetc_code"
            vDataTable1.Rows.Add(vDataRow1)

            vDataRow1 = vDataTable1.NewRow
            vDataRow1(0) = "Petc name"
            vDataRow1(1) = "spetc_name"
            vDataTable1.Rows.Add(vDataRow1)

            vDataRow1 = vDataTable1.NewRow
            vDataRow1(0) = "CEC number"
            vDataRow1(1) = "scec_number"
            vDataTable1.Rows.Add(vDataRow1)

            vDataRow1 = vDataTable1.NewRow
            vDataRow1(0) = "MV file number"
            vDataRow1(1) = "smv_file_no"
            vDataTable1.Rows.Add(vDataRow1)

            vDataRow1 = vDataTable1.NewRow
            vDataRow1(0) = "Engine number"
            vDataRow1(1) = "sengine_no"
            vDataTable1.Rows.Add(vDataRow1)

            vDataRow1 = vDataTable1.NewRow
            vDataRow1(0) = "Chassis number"
            vDataRow1(1) = "schassis_no"
            vDataTable1.Rows.Add(vDataRow1)

            vDataRow1 = vDataTable1.NewRow
            vDataRow1(0) = "Fuel type"
            vDataRow1(1) = "sfuel_type"
            vDataTable1.Rows.Add(vDataRow1)

            .DataSource = vDataTable1
            .DisplayMember = "description"
            .ValueMember = "field"

            .Text = ""
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

            vDataRow2 = vDataTable2.NewRow
            vDataRow2(0) = "Petc code"
            vDataRow2(1) = "epetc_code"
            vDataTable2.Rows.Add(vDataRow2)

            vDataRow2 = vDataTable2.NewRow
            vDataRow2(0) = "Petc name"
            vDataRow2(1) = "spetc_name"
            vDataTable2.Rows.Add(vDataRow2)

            vDataRow2 = vDataTable2.NewRow
            vDataRow2(0) = "CEC number"
            vDataRow2(1) = "scec_number"
            vDataTable2.Rows.Add(vDataRow2)

            vDataRow2 = vDataTable2.NewRow
            vDataRow2(0) = "MV file number"
            vDataRow2(1) = "smv_file_no"
            vDataTable2.Rows.Add(vDataRow2)

            vDataRow2 = vDataTable2.NewRow
            vDataRow2(0) = "Engine number"
            vDataRow2(1) = "sengine_no"
            vDataTable2.Rows.Add(vDataRow2)

            vDataRow2 = vDataTable2.NewRow
            vDataRow2(0) = "Chassis number"
            vDataRow2(1) = "schassis_no"
            vDataTable2.Rows.Add(vDataRow2)

            vDataRow2 = vDataTable2.NewRow
            vDataRow2(0) = "Fuel type"
            vDataRow2(1) = "sfuel_type"
            vDataTable2.Rows.Add(vDataRow2)

            .DataSource = vDataTable2
            .DisplayMember = "description"
            .ValueMember = "field"

            .Text = ""
        End With

        txtValue1.Text = ""
        txtValue2.Text = ""

        txtRecs.Text = "1,000"

        picImage1.Visible = False
        picImage2.Visible = False
        picImage3.Visible = False
        picImage4.Visible = False
        picImage5.Visible = False

        grpImages.Text = "Images:"

        chkExcludeUnprocessedStradcom.Checked = False
        chkExcludeUnprocessedLTO.Checked = False
        chkExcludeInvalid.Checked = True
        chkExcludeRePrint.Checked = False
        chkExcludeReTest.Checked = False

        ImplementPrivileges()

        Dim vTmpStr As String

        'log event
        vTmpStr = modModule.CreateLog(Me.Name, "PETC Data Transmissions - Open", "")

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
        Dim vTmpStr As String = ""

        Dim vStradcomBalance As Double = 0

        timerDataLoad.Enabled = False

        Try
            gSortingColumn = Nothing
            lsvItems.ListViewItemSorter = Nothing
            modModule.RemoveSortHeaderInColumns(lsvItems)
            lsvItems.Items.Clear()

            lblHeader.Text = "PETC Data Transmissions"

            lblStatusPrompt.Text = "Opening database..."
            lblStatusPrompt.Visible = True
            lblStatusPrompt.Refresh()

            'open db connection
            vMyPgCon.ConnectionString = pConnectVox
            vMyPgCon.Open()

            lblStatusPrompt.Text = "Please wait... gathering petc data transactions..."

            vFilter = ""

            If txtDateFrom.Text <> "" And txtDateTo.Text <> "" Then
                If CDate(txtDateFrom.Text) > CDate(txtDateTo.Text) Then
                    vTmpStr = txtDateFrom.Text
                    txtDateFrom.Text = vTmpStr
                    txtDateTo.Text = vTmpStr
                End If

                vFilter = vFilter & IIf(Trim(vFilter) = "", " WHERE ", " AND ") & " datetime_tested :: date >= '" & _
                    modModule.CorrectSqlString(CDate(txtDateFrom.Text).ToString("yyyy-MM-dd")) & "' AND " & _
                    "datetime_tested :: date <= '" & modModule.CorrectSqlString(CDate(txtDateTo.Text).ToString("yyyy-MM-dd")) & "'"
            End If

            If chkExcludeUnprocessedStradcom.Checked = True Then
                vFilter = vFilter & IIf(Trim(vFilter) = "", " WHERE ", " AND ") & " uploaded_stradcom = 1"
            End If

            If chkExcludeUnprocessedLTO.Checked = True Then
                vFilter = vFilter & IIf(Trim(vFilter) = "", " WHERE ", " AND ") & " uploaded_lto = 1"
            End If

            If chkExcludeInvalid.Checked = True Then
                vFilter = vFilter & IIf(Trim(vFilter) = "", " WHERE ", " AND ") & " statuscode = '1'"
            End If

            If chkExcludeRePrint.Checked = True Then
                vFilter = vFilter & IIf(Trim(vFilter) = "", " WHERE ", " AND ") & " reprint <> '1'"
            End If

            If chkExcludeReTest.Checked = True Then
                vFilter = vFilter & IIf(Trim(vFilter) = "", " WHERE ", " AND ") & " retest <> '1'"
            End If

            If cmbFilter1.SelectedItem Is Nothing Then
            Else
                If cmbFilter1.Text <> "" And txtValue1.Text <> "" Then
                    Select Case Mid(cmbFilter1.SelectedItem(1).ToString, 1, 1)
                        Case "n"
                            Select Case LCase(cmbFilter1.SelectedItem(0).ToString)
                                Case Else
                                    vTmpStr = txtValue1.Text
                            End Select

                            If vTmpStr <> "" Then
                                vFilter = vFilter & IIf(vFilter = "", "WHERE ", " AND ") & _
                                    Mid(cmbFilter1.SelectedItem(1).ToString, 2, Len(cmbFilter1.SelectedItem(1).ToString)) & "=" & vTmpStr
                            End If

                        Case "e"
                            vFilter = vFilter & IIf(vFilter = "", "WHERE ", " AND ") & _
                                Mid(cmbFilter1.SelectedItem(1).ToString, 2, Len(cmbFilter1.SelectedItem(1).ToString)) & "='" & txtValue1.Text & "'"

                        Case "d"
                            vFilter = vFilter & IIf(vFilter = "", "WHERE ", " AND ") & _
                                    Mid(cmbFilter1.SelectedItem(1).ToString, 2, Len(cmbFilter1.SelectedItem(1).ToString)) & "='" & _
                                    CDate(txtValue1.Text).ToString("yyyy-MM-dd") & "'"

                        Case Else
                            vFilter = vFilter & IIf(vFilter = "", "WHERE ", " AND ") & "LOWER(" & _
                                Mid(cmbFilter1.SelectedItem(1).ToString, 2, Len(cmbFilter1.SelectedItem(1).ToString)) & ") LIKE '%" & LCase(Trim(txtValue1.Text)) & "%'"
                    End Select
                End If
            End If

            If cmbFilter2.SelectedItem Is Nothing Then
            Else
                If cmbFilter2.Text <> "" And txtValue2.Text <> "" Then
                    Select Case Mid(cmbFilter2.SelectedItem(1).ToString, 1, 1)
                        Case "n"
                            Select Case LCase(cmbFilter2.SelectedItem(0).ToString)
                                Case Else
                                    vTmpStr = txtValue2.Text
                            End Select

                            If vTmpStr <> "" Then
                                vFilter = vFilter & IIf(vFilter = "", "WHERE ", " AND ") & _
                                    Mid(cmbFilter2.SelectedItem(1).ToString, 2, Len(cmbFilter2.SelectedItem(1).ToString)) & "=" & vTmpStr
                            End If

                        Case "e"
                            vFilter = vFilter & IIf(vFilter = "", "WHERE ", " AND ") & _
                                Mid(cmbFilter2.SelectedItem(1).ToString, 2, Len(cmbFilter2.SelectedItem(1).ToString)) & "='" & txtValue2.Text & "'"

                        Case "d"
                            vFilter = vFilter & IIf(vFilter = "", "WHERE ", " AND ") & _
                                    Mid(cmbFilter2.SelectedItem(1).ToString, 2, Len(cmbFilter2.SelectedItem(1).ToString)) & "='" & _
                                    CDate(txtValue2.Text).ToString("yyyy-MM-dd") & "'"

                        Case Else
                            vFilter = vFilter & IIf(vFilter = "", "WHERE ", " AND ") & "LOWER(" & _
                                Mid(cmbFilter2.SelectedItem(1).ToString, 2, Len(cmbFilter2.SelectedItem(1).ToString)) & ") LIKE '%" & LCase(Trim(txtValue2.Text)) & "%'"
                    End Select
                End If
            End If

            vSortBy = "ORDER BY recno DESC"

            vQuery = "SELECT petc_code, petc_name, terminal_id, plate_no, lname, mname, fname, organization, cec_number, " & _
                 "uploaded_stradcom, uploaded_lto, doc_status, statusdesc, authorization_id, mv_file_no, chassis_no, " & _
                 "engine_no, mv_type, make_description, fuel_type, color_description, vehicle_model, vehicle_series, cr_no, or_no, " & _
                 "datetime_tested, technician, test_purpose, engine_type, test_ave_d, test_co, test_hc, petc_result, " & _
                 "denr_result, reprint, retest, owner_address, recno FROM tb_petc_test " & vFilter & " " & _
                 vSortBy & IIf(txtRecs.Text = "" Or txtRecs.Text = "0", "", " LIMIT " & Trim(Str(CDbl(txtRecs.Text))))

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

                    If IsDBNull(vMyPgRd("datetime_tested")) = True Then
                        lsvItems.Items.Add("")
                    Else
                        lsvItems.Items.Add(Format(CDate(vMyPgRd("datetime_tested").ToString), "MM/dd/yyyy HH:mm:ss"))
                    End If

                    lsvItems.Items(lsvItems.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)

                    If IsDBNull(vMyPgRd("petc_code")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("petc_code"))
                    End If

                    If IsDBNull(vMyPgRd("petc_name")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("petc_name"))
                    End If

                    'If IsDBNull(vMyPgRd("terminal_id")) = True Then
                    ' lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    ' Else
                    ' lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(Format(vMyPgRd("debit"), "###,###,###,##0.00"))
                    ' End If

                    If IsDBNull(vMyPgRd("terminal_id")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("terminal_id"))
                    End If

                    If IsDBNull(vMyPgRd("plate_no")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("plate_no"))
                    End If

                    vTmpStr = ""

                    If IsDBNull(vMyPgRd("fname")) = False Then
                        If Trim(vMyPgRd("fname")) <> "" Then vTmpStr = vMyPgRd("fname")
                    End If

                    If IsDBNull(vMyPgRd("mname")) = False Then
                        If Trim(vMyPgRd("mname")) <> "" Then vTmpStr = vTmpStr & IIf(vTmpStr = "", "", " ") & vMyPgRd("mname")
                    End If

                    If IsDBNull(vMyPgRd("lname")) = False Then
                        If Trim(vMyPgRd("lname")) <> "" Then vTmpStr = vTmpStr & IIf(vTmpStr = "", "", " ") & vMyPgRd("lname")
                    End If

                    If IsDBNull(vMyPgRd("organization")) = False Then
                        If Trim(vMyPgRd("organization")) <> "" Then vTmpStr = vTmpStr & IIf(vTmpStr = "", "", " / ") & vMyPgRd("organization")
                    End If

                    lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vTmpStr)

                    If IsDBNull(vMyPgRd("cec_number")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("cec_number"))
                    End If

                    If IsDBNull(vMyPgRd("uploaded_stradcom")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("No")
                    Else
                        If vMyPgRd("uploaded_stradcom") = 1 Then
                            lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("Yes")
                        Else
                            lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("No")
                        End If
                    End If

                    If IsDBNull(vMyPgRd("uploaded_lto")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("No")
                    Else
                        If vMyPgRd("uploaded_lto") = 1 Then
                            lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("Yes")
                        Else
                            lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("No")
                        End If
                    End If

                    If IsDBNull(vMyPgRd("doc_status")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("doc_status"))
                    End If

                    If IsDBNull(vMyPgRd("statusdesc")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("statusdesc"))
                    End If

                    If IsDBNull(vMyPgRd("authorization_id")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("authorization_id"))
                    End If

                    If IsDBNull(vMyPgRd("mv_file_no")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("mv_file_no"))
                    End If

                    If IsDBNull(vMyPgRd("chassis_no")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("chassis_no"))
                    End If

                    If IsDBNull(vMyPgRd("engine_no")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("engine_no"))
                    End If

                    If IsDBNull(vMyPgRd("mv_type")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("mv_type"))
                    End If

                    If IsDBNull(vMyPgRd("make_description")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("make_description"))
                    End If

                    If IsDBNull(vMyPgRd("fuel_type")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("fuel_type"))
                    End If

                    If IsDBNull(vMyPgRd("color_description")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("color_description"))
                    End If

                    If IsDBNull(vMyPgRd("vehicle_model")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("vehicle_model"))
                    End If

                    If IsDBNull(vMyPgRd("vehicle_series")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("vehicle_series"))
                    End If

                    If IsDBNull(vMyPgRd("cr_no")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("cr_no"))
                    End If

                    If IsDBNull(vMyPgRd("or_no")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("or_no"))
                    End If

                    If IsDBNull(vMyPgRd("technician")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("technician"))
                    End If

                    If IsDBNull(vMyPgRd("test_purpose")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("test_purpose"))
                    End If

                    If IsDBNull(vMyPgRd("engine_type")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("engine_type"))
                    End If

                    If IsDBNull(vMyPgRd("test_ave_d")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        If vMyPgRd("test_ave_d") = 0 Then
                            lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                        Else
                            lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(CDbl(vMyPgRd("test_ave_d")).ToString("0.00"))
                        End If
                    End If

                    If IsDBNull(vMyPgRd("test_co")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        If vMyPgRd("test_co") = 0 Then
                            lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                        Else
                            lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(CDbl(vMyPgRd("test_co")).ToString("0.00"))
                        End If
                    End If

                    If IsDBNull(vMyPgRd("test_hc")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        If vMyPgRd("test_hc") = 0 Then
                            lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                        Else
                            lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(CDbl(vMyPgRd("test_hc")).ToString("0.00"))
                        End If
                    End If

                    If IsDBNull(vMyPgRd("petc_result")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("petc_result"))
                    End If

                    If IsDBNull(vMyPgRd("denr_result")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("denr_result"))
                    End If

                    If IsDBNull(vMyPgRd("reprint")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("No")
                    Else
                        If vMyPgRd("reprint") = "1" Then
                            lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("Yes")
                        Else
                            lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("No")
                        End If
                    End If

                    If IsDBNull(vMyPgRd("retest")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("No")
                    Else
                        If vMyPgRd("retest") = "1" Then
                            lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("Yes")
                        Else
                            lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("No")
                        End If
                    End If

                    If IsDBNull(vMyPgRd("owner_address")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("owner_address"))
                    End If

                    If IsDBNull(vMyPgRd("recno")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("recno"))
                    End If

                    vRecs = vRecs + 1

                    If vRecs = 1 Then
                        lblStatusPrompt.Text = "Gathering details... " & Trim(Str(vRecs)) & " records read"
                        lblStatusPrompt.Refresh()
                    ElseIf (vRecs Mod 25) = 0 Then
                        lblStatusPrompt.Text = "Gathering details... " & Trim(Str(vRecs)) & " records read"
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

            lblHeader.Text = "PETC Data Transmissions: " & Trim(Str(vRecs)) & " record(s) found"

            lblStatusPrompt.Visible = False

            If lsvItems.Items.Count > 0 Then
                RefreshImages(lsvItems.Items(0).SubItems(34).Text, lsvItems.Items(0).SubItems(4).Text)
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
            vQuery = modModule.CreateLog(Me.Name, "Error:timerDataLoad", ex.Message)

            lblStatusPrompt.Visible = False
        End Try
    End Sub

    Private Sub frmPetcDataTransmissions_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
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

        Dim vTopBorder As Byte = 17
        Dim vBorder As Byte = 6
        Dim vTmpWidth As Long = grpImages.Width - (vBorder * 2)
        Dim vTmpHeight As Long = 0
        Dim vImageWidth As Long = 0
        Dim vImageHeight As Long = 0

        vImageWidth = (vTmpWidth / 4)
        vImageHeight = vImageWidth * 0.7

        vTmpHeight = vImageHeight + vBorder + vTopBorder

        Dim vLocation = New Point(lsvItems.Location.X, grpFilters.Location.Y - vTmpHeight - vBorder + 2)

        grpImages.Location = vLocation
        grpImages.Height = vTmpHeight

        vLocation = New Point(vBorder + 1, vTopBorder)
        picImage1.Location = vLocation
        picImage1.Width = vImageWidth
        picImage1.Height = vImageHeight

        vLocation = New Point(picImage1.Location.X + vImageWidth, vTopBorder)
        picImage3.Location = vLocation
        picImage3.Width = vImageWidth
        picImage3.Height = vImageHeight

        vLocation = New Point(picImage3.Location.X + vImageWidth, vTopBorder)
        picImage4.Location = vLocation
        picImage4.Width = vImageWidth
        picImage4.Height = vImageHeight

        vLocation = New Point(picImage4.Location.X + vImageWidth, vTopBorder)
        picImage5.Location = vLocation
        picImage5.Width = vImageWidth
        picImage5.Height = vImageHeight

        lsvItems.Height = grpImages.Location.Y - vBorder - lsvItems.Location.Y

        cmdEnlargeImage.Location = New Point(grpImages.Width - cmdEnlargeImage.Width, cmdEnlargeImage.Location.Y)
    End Sub

    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click
        Dim vTmpStr As String = ""

        txtDateFrom_LostFocus(sender, e)
        txtDateTo_LostFocus(sender, e)

        If timerDataLoad.Enabled = False Then timerDataLoad.Enabled = True
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Dim vTmpStr As String

        'log event
        vTmpStr = modModule.CreateLog(Me.Name, "PETC Data Transmissions - Close", "")

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

    Private Sub txtDateFrom_GotFocus(sender As Object, e As EventArgs) Handles txtDateFrom.GotFocus
        txtDateFrom.SelectAll()
    End Sub

    Private Sub txtDateFrom_LostFocus(sender As Object, e As EventArgs) Handles txtDateFrom.LostFocus
        If IsDate(txtDateFrom.Text) = True Then
            txtDateFrom.Text = CDate(txtDateFrom.Text).ToString("MM/dd/yyyy")
        Else
            txtDateFrom.Text = ""
        End If
    End Sub

    Private Sub cmdDetails_Click(sender As Object, e As EventArgs) Handles cmdDetails.Click
        If lsvItems.Items.Count <= 0 Then Exit Sub

        If lsvItems.FocusedItem Is Nothing Then
            lsvItems.Items(0).Focused = True
        End If

        With frmPetcDataTransmissionViewAllFields
            .RecNo = lsvItems.Items(lsvItems.FocusedItem.Index).SubItems(34).Text

            .ShowDialog()
        End With
    End Sub

    Private Sub lsvItems_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsvItems.SelectedIndexChanged
        RefreshImages(lsvItems.Items(lsvItems.FocusedItem.Index).SubItems(34).Text, _
                      lsvItems.Items(lsvItems.FocusedItem.Index).SubItems(4).Text)
    End Sub

    Private Sub txtDateTo_GotFocus(sender As Object, e As EventArgs) Handles txtDateTo.GotFocus
        txtDateTo.SelectAll()
    End Sub

    Private Sub txtDateTo_LostFocus(sender As Object, e As EventArgs) Handles txtDateTo.LostFocus
        If IsDate(txtDateTo.Text) = True Then
            txtDateTo.Text = CDate(txtDateTo.Text).ToString("MM/dd/yyyy")
        Else
            txtDateTo.Text = ""
        End If
    End Sub

    Private Sub txtDateTo_TextChanged(sender As Object, e As EventArgs) Handles txtDateTo.TextChanged

    End Sub

    Private Sub txtDateFrom_TextChanged(sender As Object, e As EventArgs) Handles txtDateFrom.TextChanged

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

    Private Sub cmbFilter1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFilter1.SelectedIndexChanged

    End Sub

    Private Sub RefreshImages(ByVal bRecNo As String, ByVal bPlateNo As String)
        'open postgres connection
        Dim vMyPgCon As New NpgsqlConnection
        Dim vMyPgCmd = New NpgsqlCommand
        Dim vMyPgRd As NpgsqlDataReader
        Dim vFound As Boolean

        Dim vQuery As String

        Dim vTmpVar As Integer
        Dim vValueByte As Byte() = Nothing
        Dim vImageData As Byte() = Nothing

        timerDataLoad.Enabled = False

        Try
            vQuery = "SELECT recno, span, image1_size, image2_size, image1, image2 FROM tb_petc_test WHERE recno = " & bRecNo

            lblStatusPrompt.Text = "Opening database..."
            lblStatusPrompt.Visible = True
            lblStatusPrompt.Refresh()

            grpImages.Text = "Images of Plate no. " & bPlateNo

            picImage1.Visible = False
            picImage2.Visible = False
            picImage3.Visible = False
            picImage4.Visible = False
            picImage5.Visible = False

            'open db connection
            vMyPgCon.ConnectionString = pConnectVox
            vMyPgCon.Open()

            'create query
            vMyPgCmd = New NpgsqlCommand(vQuery, vMyPgCon)

            lblStatusPrompt.Text = "Gathering data..."

            'execute query
            vMyPgRd = vMyPgCmd.ExecuteReader()

            'read values
            vFound = vMyPgRd.Read

            If vFound = False Then
                'no record found
            Else
                'get result

                If IsDBNull(vMyPgRd("image1")) = False Then
                    'extract image
                    ReDim vValueByte(CLng(vMyPgRd("image1_size")))

                    'put into picturebox
                    vValueByte = vMyPgRd("image1")
                    picImage1.Image = Image.FromStream(New MemoryStream(vValueByte))
                    picImage1.Visible = True
                End If

                If IsDBNull(vMyPgRd("image2")) = False Then
                    'extract image
                    ReDim vImageData(CLng(vMyPgRd("image2_size")))

                    vImageData = vMyPgRd("image2")

                    'get start and ending pointer in image
                    Dim vSize(4) As Long
                    Dim vPosSpan As Long = 0
                    Dim vPosCtr As Integer = 0
                    Dim vTmpStr As String
                    Dim vTmpStr2 As String

                    For vCtr = 1 To 4
                        vSize(vCtr) = 0
                    Next

                    vTmpStr = vMyPgRd("span")
                    vPosSpan = InStr(vTmpStr, ",")

                    Do While vPosSpan <> 0
                        vPosCtr = vPosCtr + 1
                        vTmpStr2 = Mid(vTmpStr, 1, vPosSpan - 1)

                        If vPosCtr >= 2 And vPosCtr <= 5 Then
                            vSize(vPosCtr - 1) = vTmpStr2
                        End If

                        vTmpStr = Mid(vTmpStr, vPosSpan + 1)
                        vPosSpan = InStr(vTmpStr, ",")

                        If vPosSpan = 0 Then
                            vPosCtr = vPosCtr + 1
                            vTmpStr2 = vTmpStr

                            If vPosCtr >= 2 And vPosCtr <= 5 Then
                                vSize(vPosCtr - 1) = vTmpStr2
                            End If
                        End If
                    Loop

                    'extract the 4 images
                    vPosSpan = 0
                    For vCtr = 1 To 4
                        If vSize(vCtr) <> 0 Then
                            ReDim vValueByte(CLng(vSize(vCtr)))

                            vPosSpan = vPosSpan + vSize(vCtr)

                            Array.Copy(vImageData, vPosSpan - vSize(vCtr), vValueByte, 0, CLng(vSize(vCtr)))

                            Select Case vCtr
                                Case 1
                                    picImage2.Image = Image.FromStream(New MemoryStream(vValueByte))
                                    picImage2.Visible = False

                                Case 2
                                    picImage3.Image = Image.FromStream(New MemoryStream(vValueByte))
                                    picImage3.Visible = True

                                Case 3
                                    picImage4.Image = Image.FromStream(New MemoryStream(vValueByte))
                                    picImage4.Visible = True

                                Case 4
                                    picImage5.Image = Image.FromStream(New MemoryStream(vValueByte))
                                    picImage5.Visible = True
                            End Select

                            'File.WriteAllBytes("C:\Test\C" & vCtr.ToString & ".jpg", vValueByte)
                        End If
                    Next
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
            vQuery = modModule.CreateLog(Me.Name, "Error:RefreshImages", ex.Message)

            lblStatusPrompt.Visible = False
        End Try
    End Sub

    Private Sub cmdEnlargeImage_Click(sender As Object, e As EventArgs) Handles cmdEnlargeImage.Click
        If lsvItems.Items.Count <= 0 Then Exit Sub

        If lsvItems.FocusedItem Is Nothing Then
            lsvItems.Items(0).Focused = True
        End If

        With frmPetcDataTransmissionsEnlargeImage
            .PlateNo = lsvItems.Items(lsvItems.FocusedItem.Index).SubItems(4).Text
            .Image1 = picImage1.Image
            .Image2 = picImage2.Image
            .Image3 = picImage3.Image
            .Image4 = picImage4.Image
            .Image5 = picImage5.Image

            .ShowDialog()
        End With
    End Sub

    Private Sub frmPetcDataTransmissions_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        'frmPetcDataTransmissions_Resize(sender, e)
    End Sub
End Class