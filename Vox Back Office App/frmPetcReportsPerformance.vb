Imports Npgsql

Public Class frmPetcReportsPerformance

    Private gSortingColumn As ColumnHeader
    Private gPrintListview As ListView
    Private gSeq As Long
    Private gPrintPageNo As Integer

    Private Sub ImplementPrivileges()
        '
    End Sub

    Private Sub frmPetcReportsPerformance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lsvItems.Visible = True

        lblDate1.Text = ""
        lblDate2.Text = ""

        With lsvItems.Columns
            .Clear()

            .Add("PETC Code", 75, HorizontalAlignment.Left)
            .Add("PETC name", 125, HorizontalAlignment.Left)
            .Add("Address", 100, HorizontalAlignment.Left)
            .Add("G-Passed", 75, HorizontalAlignment.Right)
            .Add("G-Failed", 75, HorizontalAlignment.Right)
            .Add("G-Reprint", 75, HorizontalAlignment.Right)
            .Add("G-Petest", 75, HorizontalAlignment.Right)
            .Add("G-Invalid", 75, HorizontalAlignment.Right)
            .Add("G-Uploaded", 75, HorizontalAlignment.Right)
            .Add("G-Not uploaded", 75, HorizontalAlignment.Right)
            .Add("D-Passed", 75, HorizontalAlignment.Right)
            .Add("D-Failed", 75, HorizontalAlignment.Right)
            .Add("D-Reprint", 75, HorizontalAlignment.Right)
            .Add("D-Petest", 75, HorizontalAlignment.Right)
            .Add("D-Invalid", 75, HorizontalAlignment.Right)
            .Add("D-Uploaded", 75, HorizontalAlignment.Right)
            .Add("D-Not uploaded", 75, HorizontalAlignment.Right)
            .Add("Total uploaded", 75, HorizontalAlignment.Right)
            .Add("Total not uploaded", 75, HorizontalAlignment.Right)
        End With

        'With lsvPetcSummary
        ' .Size = lsvItems.Size
        ' .Location = lsvItems.Location
        ' End With

        txtDateFrom.Text = CDate(Now).ToString("MM/dd/yyyy")
        txtDateTo.Text = txtDateFrom.Text

        txtPetcCode.Text = ""

        ImplementPrivileges()

        Dim vTmpStr As String

        'log event
        vTmpStr = modModule.CreateLog(Me.Name, "Reports - PETC Performance Report - Open", "")

        lblStatusPrompt.Text = "Ready"
        lblStatusPrompt.Visible = True

        timerDataLoad.Enabled = True
    End Sub

    Private Sub cmdRefresh_Click(sender As Object, e As EventArgs) Handles cmdRefresh.Click
        txtPetcCode_LostFocus(sender, e)

        txtDateFrom_LostFocus(sender, e)
        txtDateTo_LostFocus(sender, e)

        If timerDataLoad.Enabled = False Then timerDataLoad.Enabled = True
    End Sub

    Private Sub txtPetcCode_GotFocus(sender As Object, e As EventArgs) Handles txtPetcCode.GotFocus
        txtPetcCode.SelectAll()
    End Sub

    Private Sub txtPetcCode_LostFocus(sender As Object, e As EventArgs) Handles txtPetcCode.LostFocus
        txtPetcCode.Text = Trim(modModule.StripInvalidStringChars(txtPetcCode.Text))
    End Sub

    Private Sub txtPetcCode_TextChanged(sender As Object, e As EventArgs) Handles txtPetcCode.TextChanged

    End Sub

    Private Sub txtDateFrom_GotFocus(sender As Object, e As EventArgs) Handles txtDateFrom.GotFocus
        txtDateFrom.SelectAll()
    End Sub

    Private Sub txtDateFrom_LostFocus(sender As Object, e As EventArgs) Handles txtDateFrom.LostFocus
        If IsDate(txtDateFrom.Text) = False Then
            txtDateFrom.Text = ""
        Else
            txtDateFrom.Text = CDate(txtDateFrom.Text).ToString("MM/dd/yyyy")
        End If
    End Sub

    Private Sub txtDateFrom_TextChanged(sender As Object, e As EventArgs) Handles txtDateFrom.TextChanged

    End Sub

    Private Sub txtDateTo_GotFocus(sender As Object, e As EventArgs) Handles txtDateTo.GotFocus
        txtDateTo.SelectAll()
    End Sub

    Private Sub txtDateTo_LostFocus(sender As Object, e As EventArgs) Handles txtDateTo.LostFocus
        If IsDate(txtDateTo.Text) = False Then
            txtDateTo.Text = ""
        Else
            txtDateTo.Text = CDate(txtDateTo.Text).ToString("MM/dd/yyyy")
        End If
    End Sub

    Private Sub txtDateTo_TextChanged(sender As Object, e As EventArgs) Handles txtDateTo.TextChanged

    End Sub

    Private Sub timerDataLoad_Tick(sender As Object, e As EventArgs) Handles timerDataLoad.Tick
        'open postgres connection
        Dim vMyPgCon As New NpgsqlConnection
        Dim vMyPgCmd = New NpgsqlCommand
        Dim vMyPgRd As NpgsqlDataReader
        Dim vFound As Boolean
        Dim vCtr As Integer

        Dim vFilter As String
        Dim vFilter2 As String
        Dim vSortBy As String
        Dim vQuery As String

        Dim vTmpVar As Integer
        Dim vTmpStr As String

        Dim vTmpCode As String = ""
        Dim vTmpName As String
        Dim vTmpAddress As String

        Dim vTmpGasPassed As Double = 0
        Dim vTmpGasFailed As Double = 0
        Dim vTmpGasReprint As Double = 0
        Dim vTmpGasRetest As Double = 0
        Dim vTmpGasInvalid As Double = 0
        Dim vTmpGasUploaded As Double = 0
        Dim vTmpGasNotUploaded As Double = 0

        Dim vTmpDieselPassed As Double = 0
        Dim vTmpDieselFailed As Double = 0
        Dim vTmpDieselReprint As Double = 0
        Dim vTmpDieselRetest As Double = 0
        Dim vTmpDieselInvalid As Double = 0
        Dim vTmpDieselUploaded As Double = 0
        Dim vTmpDieselNotUploaded As Double = 0

        Dim vTmpTotalPassed As Double = 0
        Dim vTmpTotalFailed As Double = 0
        Dim vTmpTotalReprint As Double = 0
        Dim vTmpTotalRetest As Double = 0
        Dim vTmpTotalInvalid As Double = 0
        Dim vTmpTotalUploaded As Double = 0
        Dim vTmpTotalNotUploaded As Double = 0

        timerDataLoad.Enabled = False

        Try
            lblDate1.Text = ""
            lblDate2.Text = ""

            gSortingColumn = Nothing
            lsvItems.ListViewItemSorter = Nothing
            modModule.RemoveSortHeaderInColumns(lsvItems)
            lsvItems.Items.Clear()

            vFilter = ""

            If txtPetcCode.Text <> "" Then
                vFilter = vFilter & " WHERE LOWER(a.petc_code) = '" & LCase(modModule.CorrectSqlString(txtPetcCode.Text)) & "'"
            End If

            If txtDateFrom.Text <> "" And txtDateTo.Text <> "" Then
                If CDate(txtDateFrom.Text) > CDate(txtDateTo.Text) Then
                    vTmpStr = txtDateFrom.Text

                    txtDateFrom.Text = txtDateTo.Text
                    txtDateTo.Text = vTmpStr
                End If

                vFilter = vFilter & IIf(Trim(vFilter) = "", " WHERE ", " AND ") & "a.datetime_tested :: date >= '" & _
                    modModule.CorrectSqlString(txtDateFrom.Text) & "' AND a.datetime_tested :: date <= '" & _
                    modModule.CorrectSqlString(txtDateTo.Text) & "'"
            End If

            vFilter2 = ""

            If txtPetcCode.Text <> "" Then
                vFilter2 = vFilter2 & " WHERE LOWER(petc_code) = '" & LCase(modModule.CorrectSqlString(txtPetcCode.Text)) & "'"
            End If

            If txtDateFrom.Text <> "" And txtDateTo.Text <> "" Then
                If CDate(txtDateFrom.Text) > CDate(txtDateTo.Text) Then
                    vTmpStr = txtDateFrom.Text

                    txtDateFrom.Text = txtDateTo.Text
                    txtDateTo.Text = vTmpStr
                End If

                vFilter2 = vFilter2 & IIf(Trim(vFilter2) = "", " WHERE ", " AND ") & "datetime_tested :: date >= '" & _
                    modModule.CorrectSqlString(txtDateFrom.Text) & "' AND datetime_tested :: date <= '" & _
                    modModule.CorrectSqlString(txtDateTo.Text) & "'"
            End If

            vSortBy = "ORDER BY b.petc_name"

            lblStatusPrompt.Text = "Opening database..."
            lblStatusPrompt.Visible = True
            lblStatusPrompt.Refresh()

            'open db connection
            vMyPgCon.ConnectionString = pConnectVox
            vMyPgCon.Open()

            lblStatusPrompt.Text = "Analyzing PETC transmission data..."
            lblStatusPrompt.Visible = True
            lblStatusPrompt.Refresh()

            vQuery = "SELECT DISTINCT a.petc_code, b.petc_name, b.petc_address, c.f_gas_passed, d.f_gas_failed, e.f_gas_reprint, f.f_gas_retest, g.f_gas_invalid, " & _
                "h.f_gas_uploaded, i.f_gas_not_uploaded, j.f_diesel_passed, k.f_diesel_failed, l.f_diesel_reprint, m.f_diesel_retest, n.f_diesel_invalid, " & _
                "o.f_diesel_uploaded, p.f_diesel_not_uploaded " & _
                "FROM tb_petc_test AS a LEFT OUTER JOIN tb_petcs AS b ON a.petc_code = b.petc_code " & _
                "LEFT OUTER JOIN (SELECT petc_code, COUNT(recno) AS f_gas_passed FROM tb_petc_test " & vFilter2 & IIf(Trim(vFilter2) = "", " WHERE ", " AND ") & _
                    "LOWER(fuel_type) <> 'diesel' AND LOWER(denr_result) = 'passed' AND uploaded_stradcom = 1 AND uploaded_lto = 1 AND statuscode = '1' " & _
                    "GROUP BY petc_code) AS c ON a.petc_code = c.petc_code " & _
                "LEFT OUTER JOIN (SELECT petc_code, COUNT(recno) AS f_gas_failed FROM tb_petc_test " & vFilter2 & IIf(Trim(vFilter2) = "", " WHERE ", " AND ") & _
                    "LOWER(fuel_type) <> 'diesel' AND LOWER(denr_result) = 'failed' AND uploaded_stradcom = 1 AND uploaded_lto = 1 AND statuscode = '1' " & _
                    "GROUP BY petc_code) AS d ON a.petc_code = d.petc_code " & _
                "LEFT OUTER JOIN (SELECT petc_code, COUNT(recno) AS f_gas_reprint FROM tb_petc_test " & vFilter2 & IIf(Trim(vFilter2) = "", " WHERE ", " AND ") & _
                    "LOWER(fuel_type) <> 'diesel' AND uploaded_stradcom = 1 AND uploaded_lto = 1 AND statuscode = '1' AND reprint = '1' " & _
                    "GROUP BY petc_code) AS e ON a.petc_code = e.petc_code " & _
                "LEFT OUTER JOIN (SELECT petc_code, COUNT(recno) AS f_gas_retest FROM tb_petc_test " & vFilter2 & IIf(Trim(vFilter2) = "", " WHERE ", " AND ") & _
                    "LOWER(fuel_type) <> 'diesel' AND uploaded_stradcom = 1 AND uploaded_lto = 1 AND statuscode = '1' AND retest = '1' " & _
                    "GROUP BY petc_code) AS f ON a.petc_code = f.petc_code " & _
                "LEFT OUTER JOIN (SELECT petc_code, COUNT(recno) AS f_gas_invalid FROM tb_petc_test " & vFilter2 & IIf(Trim(vFilter2) = "", " WHERE ", " AND ") & _
                    "LOWER(fuel_type) <> 'diesel' AND uploaded_stradcom = 1 AND uploaded_lto = 0 AND statuscode <> '1' " & _
                    "GROUP BY petc_code) AS g ON a.petc_code = g.petc_code " & _
                "LEFT OUTER JOIN (SELECT petc_code, COUNT(recno) AS f_gas_uploaded FROM tb_petc_test " & vFilter2 & IIf(Trim(vFilter2) = "", " WHERE ", " AND ") & _
                    "LOWER(fuel_type) <> 'diesel' AND uploaded_stradcom = 1 AND uploaded_lto = 1 " & _
                    "GROUP BY petc_code) AS h ON a.petc_code = h.petc_code " & _
                "LEFT OUTER JOIN (SELECT petc_code, COUNT(recno) AS f_gas_not_uploaded FROM tb_petc_test " & vFilter2 & IIf(Trim(vFilter2) = "", " WHERE ", " AND ") & _
                    "LOWER(fuel_type) <> 'diesel' AND uploaded_stradcom = 1 AND uploaded_lto = 0 " & _
                    "GROUP BY petc_code) AS i ON a.petc_code = i.petc_code " & _
                "LEFT OUTER JOIN (SELECT petc_code, COUNT(recno) AS f_diesel_passed FROM tb_petc_test " & vFilter2 & IIf(Trim(vFilter2) = "", " WHERE ", " AND ") & _
                    "LOWER(fuel_type) = 'diesel' AND LOWER(denr_result) = 'passed' AND uploaded_stradcom = 1 AND uploaded_lto = 1 AND statuscode = '1' " & _
                    "GROUP BY petc_code) AS j ON a.petc_code = j.petc_code " & _
                "LEFT OUTER JOIN (SELECT petc_code, COUNT(recno) AS f_diesel_failed FROM tb_petc_test " & vFilter2 & IIf(Trim(vFilter2) = "", " WHERE ", " AND ") & _
                    "LOWER(fuel_type) = 'diesel' AND LOWER(denr_result) = 'failed' AND uploaded_stradcom = 1 AND uploaded_lto = 1 AND statuscode = '1' " & _
                    "GROUP BY petc_code) AS k ON a.petc_code = k.petc_code " & _
                "LEFT OUTER JOIN (SELECT petc_code, COUNT(recno) AS f_diesel_reprint FROM tb_petc_test " & vFilter2 & IIf(Trim(vFilter2) = "", " WHERE ", " AND ") & _
                    "LOWER(fuel_type) = 'diesel' AND uploaded_stradcom = 1 AND uploaded_lto = 1 AND statuscode = '1' AND reprint = '1' " & _
                    "GROUP BY petc_code) AS l ON a.petc_code = l.petc_code " & _
                "LEFT OUTER JOIN (SELECT petc_code, COUNT(recno) AS f_diesel_retest FROM tb_petc_test " & vFilter2 & IIf(Trim(vFilter2) = "", " WHERE ", " AND ") & _
                    "LOWER(fuel_type) = 'diesel' AND uploaded_stradcom = 1 AND uploaded_lto = 1 AND statuscode = '1' AND retest = '1' " & _
                    "GROUP BY petc_code) AS m ON a.petc_code = m.petc_code " & _
                "LEFT OUTER JOIN (SELECT petc_code, COUNT(recno) AS f_diesel_invalid FROM tb_petc_test " & vFilter2 & IIf(Trim(vFilter2) = "", " WHERE ", " AND ") & _
                    "LOWER(fuel_type) = 'diesel' AND uploaded_stradcom = 1 AND uploaded_lto = 0 AND statuscode <> '1' " & _
                    "GROUP BY petc_code) AS n ON a.petc_code = n.petc_code " & _
                "LEFT OUTER JOIN (SELECT petc_code, COUNT(recno) AS f_diesel_uploaded FROM tb_petc_test " & vFilter2 & IIf(Trim(vFilter2) = "", " WHERE ", " AND ") & _
                    "LOWER(fuel_type) = 'diesel' AND uploaded_stradcom = 1 AND uploaded_lto = 1 " & _
                    "GROUP BY petc_code) AS o ON a.petc_code = o.petc_code " & _
                "LEFT OUTER JOIN (SELECT petc_code, COUNT(recno) AS f_diesel_not_uploaded FROM tb_petc_test " & vFilter2 & IIf(Trim(vFilter2) = "", " WHERE ", " AND ") & _
                    "LOWER(fuel_type) = 'diesel' AND uploaded_stradcom = 1 AND uploaded_lto = 0 " & _
                    "GROUP BY petc_code) AS p ON a.petc_code = p.petc_code " & _
                vFilter & " " & vSortBy

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

                Do While vFound = True
                    vTmpGasPassed = 0
                    vTmpGasFailed = 0
                    vTmpGasReprint = 0
                    vTmpGasRetest = 0
                    vTmpGasInvalid = 0
                    vTmpGasUploaded = 0
                    vTmpGasNotUploaded = 0

                    vTmpDieselPassed = 0
                    vTmpDieselFailed = 0
                    vTmpDieselReprint = 0
                    vTmpDieselRetest = 0
                    vTmpDieselInvalid = 0
                    vTmpDieselUploaded = 0
                    vTmpDieselNotUploaded = 0

                    If IsDBNull(vMyPgRd("petc_code")) = False Then
                        vTmpCode = vMyPgRd("petc_code")
                    Else
                        vTmpCode = ""
                    End If

                    If IsDBNull(vMyPgRd("petc_name")) = False Then
                        vTmpName = vMyPgRd("petc_name")
                    Else
                        vTmpName = ""
                    End If

                    If IsDBNull(vMyPgRd("petc_address")) = False Then
                        vTmpAddress = vMyPgRd("petc_address")
                    Else
                        vTmpAddress = ""
                    End If

                    If IsDBNull(vMyPgRd("f_gas_passed")) = False Then
                        vTmpGasPassed = vMyPgRd("f_gas_passed")
                    End If

                    If IsDBNull(vMyPgRd("f_gas_failed")) = False Then
                        vTmpGasFailed = vMyPgRd("f_gas_failed")
                    End If

                    If IsDBNull(vMyPgRd("f_gas_reprint")) = False Then
                        vTmpGasReprint = vMyPgRd("f_gas_reprint")
                    End If

                    If IsDBNull(vMyPgRd("f_gas_retest")) = False Then
                        vTmpGasRetest = vMyPgRd("f_gas_retest")
                    End If

                    If IsDBNull(vMyPgRd("f_gas_invalid")) = False Then
                        vTmpGasInvalid = vMyPgRd("f_gas_invalid")
                    End If

                    If IsDBNull(vMyPgRd("f_gas_uploaded")) = False Then
                        vTmpGasUploaded = vMyPgRd("f_gas_uploaded")
                    End If

                    If IsDBNull(vMyPgRd("f_gas_not_uploaded")) = False Then
                        vTmpGasNotUploaded = vMyPgRd("f_gas_not_uploaded")
                    End If

                    If IsDBNull(vMyPgRd("f_diesel_passed")) = False Then
                        vTmpDieselPassed = vMyPgRd("f_diesel_passed")
                    End If

                    If IsDBNull(vMyPgRd("f_diesel_failed")) = False Then
                        vTmpDieselFailed = vMyPgRd("f_diesel_failed")
                    End If

                    If IsDBNull(vMyPgRd("f_diesel_reprint")) = False Then
                        vTmpDieselReprint = vMyPgRd("f_diesel_reprint")
                    End If

                    If IsDBNull(vMyPgRd("f_diesel_retest")) = False Then
                        vTmpDieselRetest = vMyPgRd("f_diesel_retest")
                    End If

                    If IsDBNull(vMyPgRd("f_diesel_invalid")) = False Then
                        vTmpDieselInvalid = vMyPgRd("f_diesel_invalid")
                    End If

                    If IsDBNull(vMyPgRd("f_diesel_uploaded")) = False Then
                        vTmpDieselUploaded = vMyPgRd("f_diesel_uploaded")
                    End If

                    If IsDBNull(vMyPgRd("f_diesel_not_uploaded")) = False Then
                        vTmpDieselNotUploaded = vMyPgRd("f_diesel_not_uploaded")
                    End If

                    vTmpTotalPassed = vTmpGasPassed + vTmpDieselPassed
                    vTmpTotalFailed = vTmpGasFailed + vTmpDieselFailed
                    vTmpTotalReprint = vTmpGasReprint + vTmpDieselReprint
                    vTmpTotalRetest = vTmpGasRetest + vTmpDieselRetest
                    vTmpTotalInvalid = vTmpGasInvalid + vTmpDieselInvalid
                    vTmpTotalUploaded = vTmpGasUploaded + vTmpDieselUploaded
                    vTmpTotalNotUploaded = vTmpGasNotUploaded + vTmpDieselNotUploaded

                    With lsvItems
                        pViewBackgroundCtr = pViewBackgroundCtr + 1
                        If pViewBackgroundCtr > pViewBackgroundColorMax Then
                            pViewBackgroundCtr = 1
                        End If

                        .Items.Add(vTmpCode)

                        vCtr = .Items.Count
                        .Items(vCtr - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)

                        .Items(vCtr - 1).SubItems.Add(vTmpName)
                        .Items(vCtr - 1).SubItems.Add(vTmpAddress)

                        .Items(vCtr - 1).SubItems.Add(vTmpGasPassed.ToString("###,###,###,##0"))
                        .Items(vCtr - 1).SubItems.Add(vTmpGasFailed.ToString("###,###,###,##0"))
                        .Items(vCtr - 1).SubItems.Add(vTmpGasReprint.ToString("###,###,###,##0"))
                        .Items(vCtr - 1).SubItems.Add(vTmpGasRetest.ToString("###,###,###,##0"))
                        .Items(vCtr - 1).SubItems.Add(vTmpGasInvalid.ToString("###,###,###,##0"))
                        .Items(vCtr - 1).SubItems.Add(vTmpGasUploaded.ToString("###,###,###,##0"))
                        .Items(vCtr - 1).SubItems.Add(vTmpGasNotUploaded.ToString("###,###,###,##0"))

                        .Items(vCtr - 1).SubItems.Add(vTmpDieselPassed.ToString("###,###,###,##0"))
                        .Items(vCtr - 1).SubItems.Add(vTmpDieselFailed.ToString("###,###,###,##0"))
                        .Items(vCtr - 1).SubItems.Add(vTmpDieselReprint.ToString("###,###,###,##0"))
                        .Items(vCtr - 1).SubItems.Add(vTmpDieselRetest.ToString("###,###,###,##0"))
                        .Items(vCtr - 1).SubItems.Add(vTmpDieselInvalid.ToString("###,###,###,##0"))
                        .Items(vCtr - 1).SubItems.Add(vTmpDieselUploaded.ToString("###,###,###,##0"))
                        .Items(vCtr - 1).SubItems.Add(vTmpDieselNotUploaded.ToString("###,###,###,##0"))

                        .Items(vCtr - 1).SubItems.Add(vTmpTotalUploaded.ToString("###,###,###,##0"))
                        .Items(vCtr - 1).SubItems.Add(vTmpTotalNotUploaded.ToString("###,###,###,##0"))
                    End With

                    'read values
                    vFound = vMyPgRd.Read
                Loop
            End If

            'close and dispose to avoid memory leak
            vMyPgRd.Close()
            vMyPgCmd.Dispose()

            lblStatusPrompt.Text = "Closing database..."
            lblStatusPrompt.Refresh()

            'close and dispose connection
            vMyPgCon.Close()
            vMyPgCon = Nothing

            lblDate1.Text = txtDateFrom.Text
            lblDate2.Text = txtDateTo.Text

            lblStatusPrompt.Text = "Ready"

        Catch ex As Exception
            'an error has occured

            'close connections that might be open
            If IsNothing(vMyPgCon) = False Then
                If vMyPgCon.State <> ConnectionState.Closed Then
                    vMyPgCon.Close()
                    vMyPgCon = Nothing
                End If
            End If

            lblDate1.Text = ""
            lblDate2.Text = ""

            vTmpVar = MsgBox("An error has occured." & vbCrLf & vbCr & _
                           "Error number: " & Trim(Str(Err.Number)) & vbCrLf & _
                           "Error description: " & Err.Description, MsgBoxStyle.OkOnly, "Error warning")

            'log event
            vQuery = modModule.CreateLog(Me.Name, "Error:timerDataLoad", ex.Message)

            lblStatusPrompt.Text = "An error has occured"
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

    Private Sub cmdClose_Click(sender As Object, e As EventArgs) Handles cmdClose.Click
        Dim vTmpStr As String

        'log event
        vTmpStr = modModule.CreateLog(Me.Name, "Reports - PETC Performance Report - Close", "")

        If vTmpStr = "1" Then
            Me.Close()
        Else
            MsgBox("An error occurred while saving log. Operation aborted.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Operation cancelled")
        End If
    End Sub

    Private Sub cmdPrint_Click(sender As Object, e As EventArgs) Handles cmdPrint.Click
        Dim vForm As Form
        Dim vResult As DialogResult

        If lsvItems.Items.Count <= 0 Then Exit Sub

        If Trim(lblDate1.Text) = "" Or Trim(lblDate2.Text) = "" Then
            MsgBox("Please process the report first before printing.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "No or incomplete data")

            Exit Sub
        End If

        If lsvitems.FocusedItem Is Nothing Then
            lsvitems.Items(lsvitems.Items.Count - 1).Focused = True
        End If

        'get items
        With lsvitems.FocusedItem
        End With

        'printer setup
        With PrintDialog
            .Document = PrintDocument
            .AllowPrintToFile = True
            .ShowNetwork = True
            .ShowHelp = True
            vResult = PrintDialog.ShowDialog()
        End With

        If vResult <> DialogResult.OK Then Exit Sub

        gPrintListview = lsvItems
        gSeq = 0
        gPrintPageNo = 1

        'print preview
        vForm = DirectCast(PrintPreviewDialog, Form)
        vForm.WindowState = FormWindowState.Maximized

        'set page default settings
        PrintDocument.DefaultPageSettings.Landscape = True

        'show preview
        PrintPreviewDialog.Document = PrintDocument
        PrintPreviewDialog.ShowDialog()
    End Sub

    Private Sub PrintDocument_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument.PrintPage
        Dim vLineSpace As Integer = 0
        Dim vLeftMargin As Integer = 0
        Dim vRightMargin As Integer = 0

        'Dim vDeliveryNo As String
        'Dim vLocationID As String
        'Dim vLocationName As String
        'Dim vSuppID As String
        'Dim vSuppName As String
        'Dim vDeliveryDate As String
        'Dim vDeliveryType As String
        'Dim vRemarks As String
        'Dim vInvoiceDate As String
        'Dim vInvoiceNo As String
        'Dim vDrNo As String
        'Dim vReceivedBy As String
        'Dim vNotedBy As String
        'Dim vPoNo As String
        'Dim vReqNo As String

        'Dim vCurrentDateTime As String

        'vCurrentDateTime = CDate(DateTime.Now).ToString("MM/dd/yyyy")

        vLineSpace = 5
        vLeftMargin = 25
        vRightMargin = 50

        'vDeliveryNo = Trim(Str(CDbl(lsvitems.FocusedItem.Text)))
        'vLocationID = lsvitems.FocusedItem.SubItems(1).Text
        'vLocationName = lsvitems.FocusedItem.SubItems(2).Text
        'vSuppID = lsvitems.FocusedItem.SubItems(5).Text
        'vSuppName = lsvitems.FocusedItem.SubItems(6).Text
        'vDeliveryDate = lsvitems.FocusedItem.SubItems(3).Text
        'vDeliveryType = lsvitems.FocusedItem.SubItems(4).Text
        'vRemarks = lsvitems.FocusedItem.SubItems(16).Text
        'vInvoiceDate = lsvitems.FocusedItem.SubItems(7).Text
        'vInvoiceNo = lsvitems.FocusedItem.SubItems(8).Text
        'vDrNo = lsvitems.FocusedItem.SubItems(9).Text
        'vReceivedBy = lsvitems.FocusedItem.SubItems(21).Text
        'vNotedBy = lsvitems.FocusedItem.SubItems(22).Text
        'vPoNo = lsvitems.FocusedItem.SubItems(10).Text & "-" & lsvitems.FocusedItem.SubItems(10).Text
        'vReqNo = lsvitems.FocusedItem.SubItems(13).Text & "-" & lsvitems.FocusedItem.SubItems(14).Text

        modPrinting.PrintPetcPerformanceReport(gSeq, vLeftMargin, vRightMargin, vLineSpace, lblDate1.Text, lblDate2.Text, gPrintPageNo, gPrintListview, e)

        If gSeq >= gPrintListview.Items.Count Then
            gSeq = 0
            gPrintPageNo = 1

            e.HasMorePages = False
        Else
            e.HasMorePages = True

            gPrintPageNo = gPrintPageNo + 1
        End If
    End Sub
End Class