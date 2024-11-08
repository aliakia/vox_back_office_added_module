Imports Npgsql

Public Class frmToolsMonitoringReport

    Private gSortingColumn As ColumnHeader

    Private Sub ImplementPrivileges()
        '
    End Sub

    Private Sub frmToolsMonitoringReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lsvItems.Visible = True
        lsvPetcSummary.Visible = True
        lsvPetcBalances.Visible = True

        Me.MinimumSize = New Size(1024, 700)
        Me.Text = "Vox Dei - Tools - Monitoring Screen"

        lblDate1.Text = ""
        lblDate2.Text = ""

        With lsvItems.Columns
            .Clear()

            .Add("Description", 190, HorizontalAlignment.Left)
            .Add("Count", 75, HorizontalAlignment.Right)
            .Add("Amount", 125, HorizontalAlignment.Right)
        End With

        With lsvPetcSummary.Columns
            .Clear()

            .Add("Code", 50, HorizontalAlignment.Left)
            .Add("PETC ame", 250, HorizontalAlignment.Left)
            .Add("Count", 100, HorizontalAlignment.Right)
            .Add("Amount", 125, HorizontalAlignment.Right)
        End With

        With lsvPetcBalances.Columns
            .Clear()

            .Add("Code", 50, HorizontalAlignment.Left)
            .Add("PETC name", 225, HorizontalAlignment.Left)
            .Add("Balance", 100, HorizontalAlignment.Right)
            .Add("Max credit", 125, HorizontalAlignment.Right)
            .Add("Status", 75, HorizontalAlignment.Left)
        End With

        'With lsvPetcSummary
        ' .Size = lsvItems.Size
        ' .Location = lsvItems.Location
        ' End With

        txtDateFrom.Text = CDate(Now).ToString("MM/dd/yyyy")
        txtDateTo.Text = txtDateFrom.Text

        txtPetcCode.Text = ""
        chkPetcBalancesActiveOnly.Checked = True
        chkPetcBalancesWithBalance.Checked = True

        ImplementPrivileges()

        chkAutoRefresh.Checked = True
        txtAutoRefreshInterval.Text = "1"
        txtAutoRefreshInterval.MaxLength = 2

        EnableAutoRefresh()

        'timerAutoRefresh.Interval = 60 * 1000

        Dim vTmpStr As String

        'log event
        vTmpStr = modModule.CreateLog(Me.Name, "Reports - PETC Transmission Sales Summary - Open", "")

        lblStatusPrompt.Text = "Ready"
        lblStatusPrompt.Visible = True

        timerDataLoad.Enabled = True
        If chkAutoRefresh.Checked = True Then timerAutoRefresh.Enabled = True
    End Sub

    Private Sub cmdRefresh_Click(sender As Object, e As EventArgs) Handles cmdRefresh.Click
        txtPetcCode_LostFocus(sender, e)

        txtDateFrom_LostFocus(sender, e)
        txtDateTo_LostFocus(sender, e)

        If timerDataLoad.Enabled = False Then timerDataLoad.Enabled = True
    End Sub

    Private Sub timerDataLoad_Tick(sender As Object, e As EventArgs) Handles timerDataLoad.Tick
        'open postgres connection
        Dim vMyPgCon As New NpgsqlConnection
        Dim vMyPgCmd = New NpgsqlCommand
        Dim vMyPgRd As NpgsqlDataReader
        Dim vFound As Boolean
        Dim vCtr As Integer

        Dim vFilter As String
        Dim vSortBy As String
        Dim vQuery As String

        Dim vTmpVar As Integer
        Dim vTmpStr As String

        Dim vTotalSalesCount As Double = 0
        Dim vTotalSalesAmount As Double = 0
        Dim vTotalReprintCount As Double = 0
        Dim vTotalReprintAmount As Double = 0
        Dim vTotalRetestCount As Double = 0
        Dim vTotalRetestAmount As Double = 0
        Dim vTotalSalesDieselCount As Double = 0
        Dim vTotalSalesDieselAmount As Double = 0
        Dim vTotalSalesGasCount As Double = 0
        Dim vTotalSalesGasAmount As Double = 0
        Dim vTotalStradcomCount As Double = 0
        Dim vTotalStradcomFee As Double = 0
        Dim vTotalStradcomRetestCount As Double = 0
        Dim vTotalStradcomRetestAmount As Double = 0
        Dim vTotalStradcomReprintCount As Double = 0
        Dim vTotalStradcomReprintAmount As Double = 0
        Dim vTotalStradcomInvalidCount As Double = 0
        Dim vTotalStradcomInvalidAmount As Double = 0
        Dim vTotalStradcomBalance As Double = 0
        Dim vTotalLtoCount As Double = 0
        Dim vTotalDotrCount As Double = 0

        Dim vTmpPetcCode As String = ""
        Dim vTmpPetcName As String = ""
        Dim vTmpPetcCount As Double = 0
        Dim vTmpPetcAmount As Double = 0
        Dim vPetcCodeFound As Boolean

        timerDataLoad.Enabled = False

        Try
            lblDate1.Text = ""
            lblDate2.Text = ""

            gSortingColumn = Nothing
            lsvItems.ListViewItemSorter = Nothing
            modModule.RemoveSortHeaderInColumns(lsvItems)
            lsvItems.Items.Clear()

            gSortingColumn = Nothing
            lsvPetcSummary.ListViewItemSorter = Nothing
            modModule.RemoveSortHeaderInColumns(lsvPetcSummary)
            lsvPetcSummary.Items.Clear()

            gSortingColumn = Nothing
            lsvPetcBalances.ListViewItemSorter = Nothing
            modModule.RemoveSortHeaderInColumns(lsvPetcBalances)
            lsvPetcBalances.Items.Clear()

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

                vFilter = vFilter & IIf(Trim(vFilter) = "", " WHERE ", " AND ") & "a.date_time_validated :: date >= '" & _
                    modModule.CorrectSqlString(txtDateFrom.Text) & "' AND a.date_time_validated :: date <= '" & _
                    modModule.CorrectSqlString(txtDateTo.Text) & "'"
            End If

            vSortBy = ""

            lblStatusPrompt.Text = "Opening database..."
            lblStatusPrompt.Visible = True
            lblStatusPrompt.Refresh()

            'open db connection
            vMyPgCon.ConnectionString = pConnectVox
            vMyPgCon.Open()

            lblStatusPrompt.Text = "Gathering PETC transmission total amount..."
            lblStatusPrompt.Visible = True
            lblStatusPrompt.Refresh()

            vQuery = "SELECT a.petc_code, b.petc_name, SUM(a.transmission_fee) AS f_sum, COUNT(a.transmission_fee) AS f_count " & _
                "FROM tb_petc_test AS a LEFT OUTER JOIN tb_petcs AS b ON a.petc_code = b.petc_code" & _
                vFilter & " " & IIf(vFilter = "", "WHERE", "AND") & " a.transmission_fee <> 0 " & _
                " GROUP BY a.petc_code, b.petc_name ORDER BY b.petc_name"

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
                    vTmpPetcCount = 0
                    vTmpPetcAmount = 0

                    If IsDBNull(vMyPgRd("f_sum")) = False Then
                        vTmpPetcAmount = vMyPgRd("f_sum")
                    End If

                    If IsDBNull(vMyPgRd("f_count")) = False Then
                        vTmpPetcCount = vMyPgRd("f_count")
                    End If

                    vTotalSalesAmount = vTotalSalesAmount + vTmpPetcAmount
                    vTotalSalesCount = vTotalSalesCount + vTmpPetcCount

                    If IsDBNull(vMyPgRd("petc_code")) = False Then
                        vTmpPetcCode = vMyPgRd("petc_code")
                    Else
                        vTmpPetcCode = ""
                    End If

                    If IsDBNull(vMyPgRd("petc_name")) = False Then
                        vTmpPetcName = vMyPgRd("petc_name")
                    Else
                        vTmpPetcName = ""
                    End If

                    vPetcCodeFound = False
                    For vCtr = 1 To lsvPetcSummary.Items.Count
                        If lsvPetcSummary.Items(vCtr - 1).Text = vTmpPetcCode Then
                            vPetcCodeFound = True
                            Exit For
                        End If
                    Next

                    If vPetcCodeFound = False Then
                        With lsvPetcSummary
                            .Items.Add(vTmpPetcCode)

                            vCtr = .Items.Count

                            .Items(vCtr - 1).SubItems.Add(vTmpPetcName)
                            .Items(vCtr - 1).SubItems.Add("0.00")
                            .Items(vCtr - 1).SubItems.Add("0.00")
                        End With
                    End If

                    With lsvPetcSummary.Items(vCtr - 1)
                        .SubItems(2).Text = (CDbl(.SubItems(2).Text) + vTmpPetcCount).ToString("###,###,###,##0.00")
                        .SubItems(3).Text = (CDbl(.SubItems(3).Text) + vTmpPetcAmount).ToString("###,###,###,##0.00")
                    End With

                    'read values
                    vFound = vMyPgRd.Read
                Loop
            End If

            'close and dispose to avoid memory leak
            vMyPgRd.Close()
            vMyPgCmd.Dispose()

            lblStatusPrompt.Text = "Gathering PETC reprint count..."
            lblStatusPrompt.Visible = True
            lblStatusPrompt.Refresh()

            vQuery = "SELECT SUM(a.transmission_fee) AS f_sum, COUNT(a.transmission_fee) AS f_count " & _
                "FROM tb_petc_test AS a " & vFilter & " " & IIf(vFilter = "", "WHERE", "AND") & _
                " a.reprint = '1' AND a.transmission_fee <> 0 " & vSortBy

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

                If IsDBNull(vMyPgRd("f_sum")) = False Then
                    vTotalReprintAmount = vMyPgRd("f_sum")
                End If

                If IsDBNull(vMyPgRd("f_count")) = False Then
                    vTotalReprintCount = vMyPgRd("f_count")
                End If
            End If

            'close and dispose to avoid memory leak
            vMyPgRd.Close()
            vMyPgCmd.Dispose()

            lblStatusPrompt.Text = "Gathering PETC reprint count..."
            lblStatusPrompt.Visible = True
            lblStatusPrompt.Refresh()

            vQuery = "SELECT SUM(a.transmission_fee) AS f_sum, COUNT(a.transmission_fee) AS f_count " & _
                "FROM tb_petc_test AS a " & vFilter & " " & IIf(vFilter = "", "WHERE", "AND") & _
                " a.retest = '1' AND a.transmission_fee <> 0 " & vSortBy

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

                If IsDBNull(vMyPgRd("f_sum")) = False Then
                    vTotalRetestAmount = vMyPgRd("f_sum")
                End If

                If IsDBNull(vMyPgRd("f_count")) = False Then
                    vTotalRetestCount = vMyPgRd("f_count")
                End If
            End If

            'close and dispose to avoid memory leak
            vMyPgRd.Close()
            vMyPgCmd.Dispose()

            lblStatusPrompt.Text = "Gathering PETC transmission diesel data..."
            lblStatusPrompt.Visible = True
            lblStatusPrompt.Refresh()

            vQuery = "SELECT SUM(a.transmission_fee) AS f_sum, COUNT(a.transmission_fee) AS f_count " & _
                "FROM tb_petc_test AS a " & vFilter & " " & IIf(vFilter = "", "WHERE", "AND") & _
                " a.transmission_fee <> 0 AND (LOWER(a.fuel_type) = 'd' OR LOWER(a.fuel_type) = 'diesel') " & vSortBy

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

                If IsDBNull(vMyPgRd("f_sum")) = False Then
                    vTotalSalesDieselAmount = vMyPgRd("f_sum")
                End If

                If IsDBNull(vMyPgRd("f_count")) = False Then
                    vTotalSalesDieselCount = vMyPgRd("f_count")
                End If
            End If

            'close and dispose to avoid memory leak
            vMyPgRd.Close()
            vMyPgCmd.Dispose()

            lblStatusPrompt.Text = "Gathering PETC transmission gas data..."
            lblStatusPrompt.Visible = True
            lblStatusPrompt.Refresh()

            vQuery = "SELECT SUM(a.transmission_fee) AS f_sum, COUNT(a.transmission_fee) AS f_count " & _
                "FROM tb_petc_test AS a " & vFilter & " " & IIf(vFilter = "", "WHERE", "AND") & _
                " a.transmission_fee <> 0 AND LOWER(a.fuel_type) <> 'd' AND LOWER(a.fuel_type) <> 'diesel' " & vSortBy

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

                If IsDBNull(vMyPgRd("f_sum")) = False Then
                    vTotalSalesGasAmount = vMyPgRd("f_sum")
                End If

                If IsDBNull(vMyPgRd("f_count")) = False Then
                    vTotalSalesGasCount = vMyPgRd("f_count")
                End If
            End If

            'close and dispose to avoid memory leak
            vMyPgRd.Close()
            vMyPgCmd.Dispose()

            lblStatusPrompt.Text = "Gathering Stradcom data..."
            lblStatusPrompt.Visible = True
            lblStatusPrompt.Refresh()

            vQuery = "SELECT SUM(a.stradcom_fee) AS f_sum, COUNT(a.stradcom_fee) AS f_count " & _
                "FROM tb_petc_test AS a " & vFilter & " " & IIf(vFilter = "", "WHERE", "AND") & _
                " a.stradcom_fee <> 0 " & vSortBy

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

                If IsDBNull(vMyPgRd("f_sum")) = False Then
                    vTotalStradcomFee = vMyPgRd("f_sum")
                End If

                If IsDBNull(vMyPgRd("f_count")) = False Then
                    vTotalStradcomCount = vMyPgRd("f_count")
                End If
            End If

            'close and dispose to avoid memory leak
            vMyPgRd.Close()
            vMyPgCmd.Dispose()

            lblStatusPrompt.Text = "Gathering Stradcom reprint data..."
            lblStatusPrompt.Visible = True
            lblStatusPrompt.Refresh()

            vQuery = "SELECT SUM(a.stradcom_fee) AS f_sum, COUNT(a.stradcom_fee) AS f_count " & _
                "FROM tb_petc_test AS a " & vFilter & " " & IIf(vFilter = "", "WHERE", "AND") & _
                " a.uploaded_stradcom = 1 AND a.statuscode = '1' AND a.reprint = '1'" & vSortBy

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

                If IsDBNull(vMyPgRd("f_sum")) = False Then
                    vTotalStradcomReprintAmount = vMyPgRd("f_sum")
                End If

                If IsDBNull(vMyPgRd("f_count")) = False Then
                    vTotalStradcomReprintCount = vMyPgRd("f_count")
                End If
            End If

            'close and dispose to avoid memory leak
            vMyPgRd.Close()
            vMyPgCmd.Dispose()

            lblStatusPrompt.Text = "Gathering Stradcom reprint data..."
            lblStatusPrompt.Visible = True
            lblStatusPrompt.Refresh()

            'vQuery = "SELECT SUM(a.stradcom_fee) AS f_sum, COUNT(a.stradcom_fee) AS f_count " &
            '    "FROM tb_petc_test AS a " & vFilter & " " & IIf(vFilter = "", "WHERE", "AND") &
            '    " a.uploaded_stradcom = 1 AND a.statuscode = '1' AND a.retest = '1'" & vSortBy

            vQuery = "SELECT SUM(a.stradcom_fee) AS f_sum, COUNT(a.stradcom_fee) AS f_count " &
                "FROM tb_petc_test AS a LEFT OUTER JOIN tb_petcs AS b ON a.petc_code = b.petc_code" & vFilter & " " & IIf(vFilter = "", "WHERE", "AND") &
                " a.uploaded_stradcom = 1 AND a.statuscode = '1' AND a.retest = '1' AND b.is_ltms_ready = 0" & vSortBy

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

                If IsDBNull(vMyPgRd("f_sum")) = False Then
                    vTotalStradcomRetestAmount = vMyPgRd("f_sum")
                End If

                If IsDBNull(vMyPgRd("f_count")) = False Then
                    vTotalStradcomRetestCount = vMyPgRd("f_count")
                End If
            End If

            'close and dispose to avoid memory leak
            vMyPgRd.Close()
            vMyPgCmd.Dispose()

            lblStatusPrompt.Text = "Gathering Stradcom reprint data..."
            lblStatusPrompt.Visible = True
            lblStatusPrompt.Refresh()

            vQuery = "SELECT SUM(a.stradcom_fee) AS f_sum, COUNT(a.stradcom_fee) AS f_count " & _
                "FROM tb_petc_test AS a " & vFilter & " " & IIf(vFilter = "", "WHERE", "AND") & _
                " a.uploaded_stradcom = 1 AND a.statuscode <> '1'" & vSortBy

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

                If IsDBNull(vMyPgRd("f_sum")) = False Then
                    vTotalStradcomInvalidAmount = vMyPgRd("f_sum")
                End If

                If IsDBNull(vMyPgRd("f_count")) = False Then
                    vTotalStradcomInvalidCount = vMyPgRd("f_count")
                End If
            End If

            'close and dispose to avoid memory leak
            vMyPgRd.Close()
            vMyPgCmd.Dispose()

            lblStatusPrompt.Text = "Gathering LTO sent data..."
            lblStatusPrompt.Visible = True
            lblStatusPrompt.Refresh()

            vQuery = "SELECT COUNT(a.recno) AS f_count " & _
                "FROM tb_petc_test AS a " & vFilter & " " & IIf(vFilter = "", "WHERE", "AND") & _
                " a.uploaded_lto = 1 " & vSortBy

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

                If IsDBNull(vMyPgRd("f_count")) = False Then
                    vTotalLtoCount = vMyPgRd("f_count")
                End If
            End If

            'close and dispose to avoid memory leak
            vMyPgRd.Close()
            vMyPgCmd.Dispose()

            'additional DOTr sent data
            lblStatusPrompt.Text = "Gathering DOTr sent data..."
            lblStatusPrompt.Visible = True
            lblStatusPrompt.Refresh()

            vQuery = "SELECT COUNT(a.recno) AS f_count " &
                "FROM tb_petc_test AS a " & vFilter & " " & IIf(vFilter = "", "WHERE", "AND") &
                " a.uploaded_lto_2 = 1 " & vSortBy

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

                If IsDBNull(vMyPgRd("f_count")) = False Then
                    vTotalDotrCount = vMyPgRd("f_count")
                End If
            End If

            'close and dispose to avoid memory leak
            vMyPgRd.Close()
            vMyPgCmd.Dispose()

            lblStatusPrompt.Text = "Gathering Stradcom balance..."
            lblStatusPrompt.Visible = True
            lblStatusPrompt.Refresh()

            vQuery = "SELECT balance FROM tb_stradcom_balance WHERE supp_id = 'stradcom' LIMIT 1"

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

                If IsDBNull(vMyPgRd("balance")) = False Then
                    vTotalStradcomBalance = vMyPgRd("balance")
                End If
            End If

            'close and dispose to avoid memory leak
            vMyPgRd.Close()
            vMyPgCmd.Dispose()

            'update petc balances

            lblStatusPrompt.Text = "Gathering PETC balances..."
            lblStatusPrompt.Visible = True
            lblStatusPrompt.Refresh()

            vFilter = ""

            If (txtPetcCode.Text <> "") Then
                vFilter = vFilter & IIf(vFilter = "", "WHERE ", " AND ") & "LOWER(a.petc_code) = '" & LCase(modModule.CorrectSqlString(txtPetcCode.Text)) & "'"
            End If

            If chkPetcBalancesActiveOnly.Checked = True Then
                vFilter = vFilter & IIf(vFilter = "", "WHERE ", " AND ") & "b.is_active = 1"
            End If

            If chkPetcBalancesWithBalance.Checked = True Then
                vFilter = vFilter & IIf(vFilter = "", "WHERE ", " AND ") & "a.balance <> 0"
            End If

            vQuery = "SELECT a.petc_code, b.petc_name, a.balance, a.max_credit, b.is_active " & _
                "FROM tb_petc_balance AS a LEFT OUTER JOIN tb_petcs AS b ON a.petc_code = b.petc_code " & _
                vFilter & " ORDER BY a.balance ASC, b.petc_name ASC"

            'create query
            vMyPgCmd = New NpgsqlCommand(vQuery, vMyPgCon)

            'execute query
            vMyPgRd = vMyPgCmd.ExecuteReader()

            'read values
            vFound = vMyPgRd.Read

            Do While vFound = True
                'get result

                pViewBackgroundCtr = pViewBackgroundCtr + 1
                If pViewBackgroundCtr > pViewBackgroundColorMax Then
                    pViewBackgroundCtr = 1
                End If

                If IsDBNull(vMyPgRd("petc_code")) = False Then
                    lsvPetcBalances.Items.Add(vMyPgRd("petc_code"))
                    lsvPetcBalances.Items(lsvPetcBalances.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)

                    If IsDBNull(vMyPgRd("petc_name")) = True Then
                        lsvPetcBalances.Items(lsvPetcBalances.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvPetcBalances.Items(lsvPetcBalances.Items.Count - 1).SubItems.Add(vMyPgRd("petc_name"))
                    End If

                    If IsDBNull(vMyPgRd("balance")) = True Then
                        lsvPetcBalances.Items(lsvPetcBalances.Items.Count - 1).SubItems.Add("0.00")
                    Else
                        lsvPetcBalances.Items(lsvPetcBalances.Items.Count - 1).SubItems.Add(CDbl(vMyPgRd("balance")).ToString("###,###,###,##0.00"))
                    End If

                    If IsDBNull(vMyPgRd("max_credit")) = True Then
                        lsvPetcBalances.Items(lsvPetcBalances.Items.Count - 1).SubItems.Add("0.00")
                    Else
                        lsvPetcBalances.Items(lsvPetcBalances.Items.Count - 1).SubItems.Add(CDbl(vMyPgRd("max_credit")).ToString("###,###,###,##0.00"))
                    End If

                    If IsDBNull(vMyPgRd("is_active")) = True Then
                        lsvPetcBalances.Items(lsvPetcBalances.Items.Count - 1).SubItems.Add("Unknown")
                    Else
                        Select Case vMyPgRd("is_active")
                            Case 0
                                lsvPetcBalances.Items(lsvPetcBalances.Items.Count - 1).SubItems.Add("Inactive")

                            Case 1
                                lsvPetcBalances.Items(lsvPetcBalances.Items.Count - 1).SubItems.Add("Active")

                            Case 2
                                lsvPetcBalances.Items(lsvPetcBalances.Items.Count - 1).SubItems.Add("Suspended")

                            Case 3
                                lsvPetcBalances.Items(lsvPetcBalances.Items.Count - 1).SubItems.Add("Expired")

                            Case 4
                                lsvPetcBalances.Items(lsvPetcBalances.Items.Count - 1).SubItems.Add("Revoked")

                            Case Else
                                lsvPetcBalances.Items(lsvPetcBalances.Items.Count - 1).SubItems.Add("Unknown")
                        End Select
                    End If
                End If

                'read next value
                vFound = vMyPgRd.Read
            Loop

            'close and dispose to avoid memory leak
            vMyPgRd.Close()
            vMyPgCmd.Dispose()

            lblStatusPrompt.Text = "Closing database..."
            lblStatusPrompt.Refresh()

            'close and dispose connection
            vMyPgCon.Close()
            vMyPgCon = Nothing

            'place data in list view
            With lsvItems
                pViewBackgroundCtr = pViewBackgroundCtr + 1
                If pViewBackgroundCtr > pViewBackgroundColorMax Then
                    pViewBackgroundCtr = 1
                End If

                lsvItems.Items.Add("VOX - NET SALES")
                lsvItems.Items(lsvItems.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)
                lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add( _
                    (vTotalSalesAmount - vTotalStradcomFee).ToString("###,###,###,##0.00"))

                pViewBackgroundCtr = pViewBackgroundCtr + 1
                If pViewBackgroundCtr > pViewBackgroundColorMax Then
                    pViewBackgroundCtr = 1
                End If

                lsvItems.Items.Add("VOX - Gross sales")
                lsvItems.Items(lsvItems.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)
                lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vTotalSalesCount.ToString("###,###,###,##0"))
                lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vTotalSalesAmount.ToString("###,###,###,##0.00"))

                pViewBackgroundCtr = pViewBackgroundCtr + 1
                If pViewBackgroundCtr > pViewBackgroundColorMax Then
                    pViewBackgroundCtr = 1
                End If

                lsvItems.Items.Add("VOX - Reprint sales")
                lsvItems.Items(lsvItems.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)
                lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vTotalReprintCount.ToString("###,###,###,##0"))
                lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vTotalReprintAmount.ToString("###,###,###,##0.00"))

                pViewBackgroundCtr = pViewBackgroundCtr + 1
                If pViewBackgroundCtr > pViewBackgroundColorMax Then
                    pViewBackgroundCtr = 1
                End If

                lsvItems.Items.Add("VOX - Retest sales")
                lsvItems.Items(lsvItems.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)
                lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vTotalRetestCount.ToString("###,###,###,##0"))
                lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vTotalRetestAmount.ToString("###,###,###,##0.00"))

                pViewBackgroundCtr = pViewBackgroundCtr + 1
                If pViewBackgroundCtr > pViewBackgroundColorMax Then
                    pViewBackgroundCtr = 1
                End If

                lsvItems.Items.Add("VOX - Diesel sales")
                lsvItems.Items(lsvItems.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)
                lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vTotalSalesDieselCount.ToString("###,###,###,##0"))
                lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vTotalSalesDieselAmount.ToString("###,###,###,##0.00"))

                pViewBackgroundCtr = pViewBackgroundCtr + 1
                If pViewBackgroundCtr > pViewBackgroundColorMax Then
                    pViewBackgroundCtr = 1
                End If

                lsvItems.Items.Add("VOX - Gas sales")
                lsvItems.Items(lsvItems.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)
                lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vTotalSalesGasCount.ToString("###,###,###,##0"))
                lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vTotalSalesGasAmount.ToString("###,###,###,##0.00"))

                pViewBackgroundCtr = pViewBackgroundCtr + 1
                If pViewBackgroundCtr > pViewBackgroundColorMax Then
                    pViewBackgroundCtr = 1
                End If

                lsvItems.Items.Add("Stradcom - Transmission fee")
                lsvItems.Items(lsvItems.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)
                lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vTotalStradcomCount.ToString("###,###,###,##0"))
                lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vTotalStradcomFee.ToString("###,###,###,##0.00"))

                pViewBackgroundCtr = pViewBackgroundCtr + 1
                If pViewBackgroundCtr > pViewBackgroundColorMax Then
                    pViewBackgroundCtr = 1
                End If

                lsvItems.Items.Add("Stradcom - Reprint")
                lsvItems.Items(lsvItems.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)
                lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vTotalStradcomReprintCount.ToString("###,###,###,##0"))
                lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vTotalStradcomReprintAmount.ToString("###,###,###,##0.00"))

                pViewBackgroundCtr = pViewBackgroundCtr + 1
                If pViewBackgroundCtr > pViewBackgroundColorMax Then
                    pViewBackgroundCtr = 1
                End If

                lsvItems.Items.Add("Stradcom - Retest")
                lsvItems.Items(lsvItems.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)
                lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vTotalStradcomRetestCount.ToString("###,###,###,##0"))
                'lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("0")
                lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vTotalStradcomRetestAmount.ToString("###,###,###,##0.00"))

                pViewBackgroundCtr = pViewBackgroundCtr + 1
                If pViewBackgroundCtr > pViewBackgroundColorMax Then
                    pViewBackgroundCtr = 1
                End If

                lsvItems.Items.Add("Stradcom - Invalid")
                lsvItems.Items(lsvItems.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)
                lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vTotalStradcomInvalidCount.ToString("###,###,###,##0"))
                lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vTotalStradcomInvalidAmount.ToString("###,###,###,##0.00"))

                pViewBackgroundCtr = pViewBackgroundCtr + 1
                If pViewBackgroundCtr > pViewBackgroundColorMax Then
                    pViewBackgroundCtr = 1
                End If

                lsvItems.Items.Add("LTO transmission")
                lsvItems.Items(lsvItems.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)
                lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vTotalLtoCount.ToString("###,###,###,##0"))
                lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")

                pViewBackgroundCtr = pViewBackgroundCtr + 1
                If pViewBackgroundCtr > pViewBackgroundColorMax Then
                    pViewBackgroundCtr = 1
                End If

                lsvItems.Items.Add("DOTr transmission")
                lsvItems.Items(lsvItems.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)
                lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vTotalDotrCount.ToString("###,###,###,##0"))
                lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")

                pViewBackgroundCtr = pViewBackgroundCtr + 1
                If pViewBackgroundCtr > pViewBackgroundColorMax Then
                    pViewBackgroundCtr = 1
                End If

                lsvItems.Items.Add("Stradcom balance (current)")
                lsvItems.Items(lsvItems.Items.Count - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)
                lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vTotalStradcomBalance.ToString("###,###,###,##0"))
            End With

            'update system messages
            Dim lblString As New Label
            Dim vSystemMessages As String

            vSystemMessages = modModule.GetSystemMessages(lblString)

            'load system messages
            txtSystemMessages.Text = vSystemMessages

            'log event
            vTmpStr = modModule.CreateLog(Me.Name, "Tools Monitoring", "Auto refresh values")

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

    Private Sub cmdClose_Click(sender As Object, e As EventArgs) Handles cmdClose.Click
        Dim vTmpStr As String

        'log event
        vTmpStr = modModule.CreateLog(Me.Name, "Reports - PETC Transmission Sales Summary - Close", "")

        If vTmpStr = "1" Then
            If timerDataLoad.Enabled = True Then timerDataLoad.Enabled = False
            If timerAutoRefresh.Enabled = True Then timerAutoRefresh.Enabled = False

            Me.Close()
        Else
            MsgBox("An error occurred while saving log. Operation aborted.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Operation cancelled")
        End If
    End Sub

    Private Sub cmdPrint_Click(sender As Object, e As EventArgs) Handles cmdPrint.Click

    End Sub

    Private Sub timerAutoRefresh_Tick(sender As Object, e As EventArgs) Handles timerAutoRefresh.Tick
        timerAutoRefresh.Enabled = False

        cmdRefresh_Click(sender, e)

        Me.Text = "Vox Dei - Tools - Monitoring Screen, Last update: " & DateTime.Now.ToString("MM/dd/yy HH:mm:ss")

        If chkAutoRefresh.Checked = True Then timerAutoRefresh.Enabled = True
    End Sub

    Private Sub chkAutoRefresh_CheckedChanged(sender As Object, e As EventArgs) Handles chkAutoRefresh.CheckedChanged
        If chkAutoRefresh.Checked = True Then
            EnableAutoRefresh()
        Else
            timerAutoRefresh.Enabled = False
        End If
    End Sub

    Private Sub EnableAutoRefresh()
        With timerAutoRefresh
            If IsNumeric(txtAutoRefreshInterval.Text) = True Then
                .Interval = CDbl(txtAutoRefreshInterval.Text) * 60 * 1000
            Else
                .Interval = (60 * 1) * 1000
            End If

            .Enabled = True
        End With
    End Sub

    Private Sub txtAutoRefreshInterval_GotFocus(sender As Object, e As EventArgs) Handles txtAutoRefreshInterval.GotFocus
        txtAutoRefreshInterval.SelectAll()
    End Sub

    Private Sub txtAutoRefreshInterval_LostFocus(sender As Object, e As EventArgs) Handles txtAutoRefreshInterval.LostFocus
        If IsNumeric(txtAutoRefreshInterval.Text) = False Then
            txtAutoRefreshInterval.Text = "1"
        Else
            txtAutoRefreshInterval.Text = CInt(txtAutoRefreshInterval.Text).ToString
        End If
    End Sub

    Private Sub txtAutoRefreshInterval_TextChanged(sender As Object, e As EventArgs) Handles txtAutoRefreshInterval.TextChanged

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

    Private Sub txtPetcCode_GotFocus(sender As Object, e As EventArgs) Handles txtPetcCode.GotFocus
        txtPetcCode.SelectAll()
    End Sub

    Private Sub txtPetcCode_LostFocus(sender As Object, e As EventArgs) Handles txtPetcCode.LostFocus
        txtPetcCode.Text = Trim(modModule.StripInvalidStringChars(txtPetcCode.Text))
    End Sub

    Private Sub txtPetcCode_TextChanged(sender As Object, e As EventArgs) Handles txtPetcCode.TextChanged

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

    Private Sub lsvPetcBalances_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles lsvPetcBalances.ColumnClick
        Dim vNewSortingColumn As ColumnHeader = lsvPetcBalances.Columns(e.Column)  ' Get the new sorting column.
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

        lsvPetcBalances.ListViewItemSorter = New modModule.ListViewItemComparer(e.Column, vSortOrder)  ' Create a comparer.

        lsvPetcBalances.Sort()                                                     ' Sort.

        modModule.RefreshAlternateViewColors(lsvPetcBalances)
    End Sub

    Private Sub lsvPetcBalances_KeyPress(sender As Object, e As KeyPressEventArgs) Handles lsvPetcBalances.KeyPress
        Select Case Asc(e.KeyChar)
            Case 3
                modModule.CopyListViewToClipboard(lsvPetcBalances)

            Case 1
                modModule.ListViewSelectAll(lsvPetcBalances)
        End Select
    End Sub

    Private Sub lsvPetcBalances_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsvPetcBalances.SelectedIndexChanged

    End Sub

    Private Sub lsvPetcSummary_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles lsvPetcSummary.ColumnClick
        Dim vNewSortingColumn As ColumnHeader = lsvPetcSummary.Columns(e.Column)  ' Get the new sorting column.
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

        lsvPetcSummary.ListViewItemSorter = New modModule.ListViewItemComparer(e.Column, vSortOrder)  ' Create a comparer.

        lsvPetcSummary.Sort()                                                     ' Sort.

        modModule.RefreshAlternateViewColors(lsvPetcSummary)
    End Sub

    Private Sub lsvPetcSummary_KeyPress(sender As Object, e As KeyPressEventArgs) Handles lsvPetcSummary.KeyPress
        Select Case Asc(e.KeyChar)
            Case 3
                modModule.CopyListViewToClipboard(lsvPetcSummary)

            Case 1
                modModule.ListViewSelectAll(lsvPetcSummary)
        End Select
    End Sub

    Private Sub lsvPetcSummary_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsvPetcSummary.SelectedIndexChanged

    End Sub

    Private Sub lsvItems_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsvItems.SelectedIndexChanged

    End Sub

    Private Sub txtSystemMessages_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSystemMessages.KeyPress
        Select Case Asc(e.KeyChar)
            Case 3
                txtSystemMessages.Copy()

            Case 1
                txtSystemMessages.SelectAll()
        End Select
    End Sub

    Private Sub txtSystemMessages_TextChanged(sender As Object, e As EventArgs) Handles txtSystemMessages.TextChanged

    End Sub
End Class