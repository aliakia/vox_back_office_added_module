Imports Npgsql

Public Class frmPetcManager

    Private gPrevPos As New Point
    Private gSortingColumn As ColumnHeader

    Private Sub ImplementPrivileges()
        '        If Mid(pUserPrivilege, 17, 1) = "2" Then
        ' cmdCreate.Enabled = True
        ' cmdEdit.Enabled = True
        ' Else
        ' cmdCreate.Enabled = False
        ' cmdEdit.Enabled = False
        'End If
    End Sub

    Private Sub frmLocationsManager_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MinimumSize = Me.Size

        ' 0 .Add("Petc code", 100, HorizontalAlignment.Left)
        ' 1 .Add("Name", 200, HorizontalAlignment.Left)
        ' 2 .Add("Description", 200, HorizontalAlignment.Left)
        ' 3 .Add("Status", 100, HorizontalAlignment.Left)
        ' 4 .Add("Lanes", 100, HorizontalAlignment.Right)
        ' 5 .Add("Pay type", 100, HorizontalAlignment.Left)
        ' 6 .Add("Balance", 0, HorizontalAlignment.Right)
        ' 7 .Add("Transmission fee", 100, HorizontalAlignment.Right)
        ' 8 .Add("Stradcom fee", 100, HorizontalAlignment.Right)
        ' 9 .Add("Category", 100, HorizontalAlignment.Left)
        '10 .Add("Address", 200, HorizontalAlignment.Left)
        '11 .Add("Contact", 100, HorizontalAlignment.Left)
        '12 .Add("Business type", 100, HorizontalAlignment.Left)
        '13 .Add("LTO service area", 100, HorizontalAlignment.Left)
        '14 .Add("DTI accreditation no.", 100, HorizontalAlignment.Left)
        '15 .Add("LTO authorization no.", 100, HorizontalAlignment.Left)
        '16 .Add("I.T. started", 100, HorizontalAlignment.Left)
        '17 .Add("I.T. accredited", 100, HorizontalAlignment.Left)
        '18 .Add("I.T. renewal", 100, HorizontalAlignment.Left)
        '19 .Add("PETC started", 100, HorizontalAlignment.Left)
        '20 .Add("PETC accredited", 100, HorizontalAlignment.Left)
        '21 .Add("PETC authorized", 100, HorizontalAlignment.Left)
        '22 .Add("GM", 0, HorizontalAlignment.Left)
        '23 .Add("Province", 100, HorizontalAlignment.Left)
        '24 .Add("Region", 100, HorizontalAlignment.Left)
        '25 Account ID
        '26 Account name
        '26 Account manager
        '26 Tech. manager
        '26 Marketing agent
        '27 Marketing commission

        With lsvItems.Columns
            .Clear()

            .Add("Petc code", 100, HorizontalAlignment.Left)
            .Add("Name", 200, HorizontalAlignment.Left)
            .Add("Description", 200, HorizontalAlignment.Left)
            .Add("Status", 100, HorizontalAlignment.Left)
            .Add("Lanes", 100, HorizontalAlignment.Right)
            .Add("Pay type", 100, HorizontalAlignment.Left)
            .Add("Balance", 0, HorizontalAlignment.Right)
            .Add("Transmission fee", 100, HorizontalAlignment.Right)
            .Add("Stradcom fee", 100, HorizontalAlignment.Right)
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
            .Add("Account ID", 0, HorizontalAlignment.Left)
            .Add("Account name", 0, HorizontalAlignment.Left)
            .Add("Account manager", 0, HorizontalAlignment.Left)
            .Add("Tech. manager", 0, HorizontalAlignment.Left)
            .Add("Marketing agent", 0, HorizontalAlignment.Left)
            .Add("Marketing commission", 0, HorizontalAlignment.Right)
        End With

        lsvItems.Items.Clear()

        txtPetcCode.Text = ""
        txtPetcName.Text = ""

        chkDisplayActiveOnly.Checked = True

        ImplementPrivileges()

        Dim vTmpStr As String

        'log event
        vTmpStr = modModule.CreateLog(Me.Name, "PETC Manager - Open", "")

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

        timerDataLoad.Enabled = False

        Try
            gSortingColumn = Nothing
            lsvItems.ListViewItemSorter = Nothing
            modModule.RemoveSortHeaderInColumns(lsvItems)
            lsvItems.Items.Clear()

            vFilter = ""

            If txtPetcCode.Text <> "" Then
                vFilter = vFilter & " WHERE LOWER(a.petc_code) = '" & LCase(modModule.CorrectSqlString(txtPetcCode.Text)) & "'"
            End If

            If txtPetcName.Text <> "" Then
                vFilter = vFilter & IIf(Trim(vFilter) = "", " WHERE ", " AND ") & "LOWER(a.petc_name) LIKE '%" & LCase(txtPetcName.Text) & "%'"
            End If

            If chkDisplayActiveOnly.Checked = True Then
                vFilter = vFilter & IIf(Trim(vFilter) = "", " WHERE ", " AND ") & "a.is_active = 1"
            End If

            vSortBy = "ORDER BY a.petc_name, a.petc_code ASC"

            vQuery = "SELECT a.petc_code, a.petc_lanes, a.petc_category, a.petc_name, a.petc_address, a.contact_no, a.business_type, a.lto_service_area," & _
                "a.dti_accreditation_no, a.lto_authorization_no, a.date_it_started, a.date_it_accredited, a.date_it_renewal, a.date_petc_started, " & _
                "a.date_petc_accredited, a.date_petc_authorized, a.is_active, a.description, b.account_type, b.balance, b.transmission_fee, b.stradcom_fee, a.gm, " & _
                "a.province, a.region, a.account_id, c.account_name, a.account_manager, a.tech_manager, a.marketing_agent, a.marketing_commission " & _
                "FROM tb_petcs AS a LEFT OUTER JOIN tb_petc_balance AS b ON a.petc_code = b.petc_code " & _
                "LEFT OUTER JOIN tb_client_accounts AS c ON a.account_id = c.account_id " & vFilter & " " & vSortBy

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

                    If IsDBNull(vMyPgRd("petc_code")) = True Then
                        lsvItems.Items.Add("")
                    Else
                        lsvItems.Items.Add(vMyPgRd("petc_code"))
                    End If

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

                    If IsDBNull(vMyPgRd("account_type")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("Unknown")
                    Else
                        Select Case vMyPgRd("account_type")
                            Case 1
                                lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("Post-paid")

                            Case 2
                                lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("Pre-paid")

                            Case Else
                                lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("Unknown")
                        End Select
                    End If

                    If IsDBNull(vMyPgRd("balance")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("Unknown")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(Format(vMyPgRd("balance"), "###,###,###,##0.00"))
                    End If

                    If IsDBNull(vMyPgRd("transmission_fee")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("Unknown")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(Format(vMyPgRd("transmission_fee"), "###,###,###,##0.00"))
                    End If

                    If IsDBNull(vMyPgRd("stradcom_fee")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("Unknown")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(Format(vMyPgRd("stradcom_fee"), "###,###,###,##0.00"))
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

                    If IsDBNull(vMyPgRd("account_name")) = True Then
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add("")
                    Else
                        lsvItems.Items(lsvItems.Items.Count - 1).SubItems.Add(vMyPgRd("account_name"))
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
            vQuery = modModule.CreateLog(Me.Name, "Error:timerDataLoad", ex.Message)

            lblStatusPrompt.Visible = False
        End Try
    End Sub

    Private Sub lblHeader_MouseMove(sender As Object, e As MouseEventArgs) Handles lblHeader.MouseMove
        Dim vDelta As New Size(e.X - gPrevPos.X, e.Y - gPrevPos.Y)

        If (e.Button = MouseButtons.Left) Then
            Me.Location += vDelta
            gPrevPos = e.Location - vDelta
        Else
            gPrevPos = e.Location
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

    Private Sub lsvItems_DoubleClick(sender As Object, e As EventArgs) Handles lsvItems.DoubleClick
        If (cmdEdit.Visible = True And cmdEdit.Enabled = True) Then cmdEdit_Click(sender, e)
    End Sub

    Private Sub lsvItems_KeyPress(sender As Object, e As KeyPressEventArgs) Handles lsvItems.KeyPress
        Select Case Asc(e.KeyChar)
            Case 3
                modModule.CopyListViewToClipboard(lsvItems)

            Case 1
                modModule.ListViewSelectAll(lsvItems)
        End Select
    End Sub

    Private Sub cmdClose_Click(sender As Object, e As EventArgs) Handles cmdClose.Click
        Dim vTmpStr As String

        'log event
        vTmpStr = modModule.CreateLog(Me.Name, "PETC Manager - Close", "")

        If vTmpStr = "1" Then
            Me.Close()
        Else
            MsgBox("An error occurred while saving log. Operation aborted.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Operation cancelled")
        End If
    End Sub

    Private Sub cmdCreate_Click(sender As Object, e As EventArgs) Handles cmdCreate.Click
        With frmPetcManagerAddEdit
            .Mode = "new"
            .PetcCode = ""

            .ShowDialog()
        End With
    End Sub

    Private Sub cmdEdit_Click(sender As Object, e As EventArgs) Handles cmdEdit.Click
        Dim vPetcCode As String

        If lsvItems.Items.Count <= 0 Then Exit Sub

        If lsvItems.FocusedItem Is Nothing Then
            lsvItems.Items(0).Focused = True
        End If

        vPetcCode = lsvItems.Items(lsvItems.FocusedItem.Index).Text

        With frmPetcManagerAddEdit
            .Mode = "edit"
            .PetcCode = vPetcCode

            .ShowDialog()
        End With
    End Sub

    Private Sub cmdRefresh_Click(sender As Object, e As EventArgs) Handles cmdRefresh.Click
        'lsvItems.Items.Clear()

        txtPetcCode_LostFocus(sender, e)
        txtPetcName_LostFocus(sender, e)

        If timerDataLoad.Enabled = False Then timerDataLoad.Enabled = True
    End Sub

    Private Sub txtPetcCode_GotFocus(sender As Object, e As EventArgs) Handles txtPetcCode.GotFocus
        txtPetcCode.SelectAll()
    End Sub

    Private Sub txtPetcCode_LostFocus(sender As Object, e As EventArgs) Handles txtPetcCode.LostFocus
        txtPetcCode.Text = modModule.StripInvalidStringChars(Trim(txtPetcCode.Text))
    End Sub

    Private Sub txtPetcName_GotFocus(sender As Object, e As EventArgs) Handles txtPetcName.GotFocus
        txtPetcName.SelectAll()
    End Sub

    Private Sub txtPetcName_LostFocus(sender As Object, e As EventArgs) Handles txtPetcName.LostFocus
        txtPetcName.Text = Trim(modModule.StripInvalidStringChars(txtPetcName.Text))
    End Sub

    Private Sub lsvItems_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsvItems.SelectedIndexChanged

    End Sub

    Private Sub cmdExport_Click(sender As Object, e As EventArgs) Handles cmdExport.Click
        Dim vTmpVar As Integer

        If lsvItems.Items.Count <= 0 Then Exit Sub

        If lsvItems.FocusedItem Is Nothing Then
            MsgBox("Please select from the list a PETC to export data.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "No record selected")

            Exit Sub
        Else
            If modModule.GetListViewSelected(lsvItems) > 1 Then
                MsgBox("You can only export PETC data one at a time." & vbCrLf & vbCrLf & _
                       "Please select a single PETC record to export.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Multi-selection not allowed")

                Exit Sub
            Else
                vTmpVar = MsgBox("You are about to export data of selected PETC." & vbCrLf & vbCrLf & _
                               "Are you sure of this?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "User confirmation")

                If vTmpVar <> MsgBoxResult.Yes Then Exit Sub
            End If
        End If

        Dim vFilename As String = ""
        Dim vResult As String = ""

        'PETC values
        Dim vPetcCode As String = ""
        Dim vPetcName As String = ""
        Dim vPetcDescription As String = ""
        Dim vPetcLanes As String = ""
        Dim vPetcCategory As String = ""
        Dim vPetcAddress As String = ""
        Dim vPetcContact As String = ""
        Dim vPetcBusinessType As String = ""
        Dim vPetcLtoServiceArea As String = ""
        Dim vPetcDtiAccreditation As String = ""
        Dim vPetcLtoAuthorization As String = ""
        Dim vPetcExiration As String = ""
        Dim vPetcRegion As String = ""

        'if want to change PETC Code
        Dim vNewPetcCode As String = ""

        'Terminal values
        Dim vTerminalId As String = ""
        Dim vTerminalLane As String = ""
        Dim vTerminalDescription As String = ""
        Dim vTerminalType As String = ""
        Dim vTerminalSerial As String = ""
        Dim vTerminalMac As String = ""
        Dim vTerminalIP As String = ""
        Dim vTerminalMachineDescription As String = ""
        Dim vTerminalMachineSerial As String = ""
        Dim vTerminalDateCalibrated As String = ""
        Dim vTerminalLastTestDateTime As String = ""
        Dim vTerminalMachineDLL As String = ""
        Dim vTerminalMachinePort As String = ""
        Dim vTerminalMachineBaud As String = ""
        Dim vTerminalMachineParity As String = ""
        Dim vTerminalMachineBits As String = ""
        Dim vTerminalMachineStopBits As String = ""

        'open postgres connection
        Dim vMyPgCon As New NpgsqlConnection
        Dim vMyPgCmd = New NpgsqlCommand
        Dim vMyPgRd As NpgsqlDataReader
        Dim vFound As Boolean
        Dim vQuery As String
        Dim vRecs As Long = 0

        Try
            'get PETC data
            vPetcCode = lsvItems.Items(lsvItems.FocusedItem.Index).Text
            vPetcName = lsvItems.Items(lsvItems.FocusedItem.Index).SubItems(1).Text
            vPetcDescription = lsvItems.Items(lsvItems.FocusedItem.Index).SubItems(2).Text
            vPetcLanes = lsvItems.Items(lsvItems.FocusedItem.Index).SubItems(4).Text
            vPetcCategory = lsvItems.Items(lsvItems.FocusedItem.Index).SubItems(9).Text
            vPetcAddress = lsvItems.Items(lsvItems.FocusedItem.Index).SubItems(10).Text
            vPetcContact = lsvItems.Items(lsvItems.FocusedItem.Index).SubItems(11).Text
            vPetcBusinessType = lsvItems.Items(lsvItems.FocusedItem.Index).SubItems(12).Text
            vPetcLtoServiceArea = lsvItems.Items(lsvItems.FocusedItem.Index).SubItems(13).Text
            vPetcDtiAccreditation = lsvItems.Items(lsvItems.FocusedItem.Index).SubItems(14).Text
            vPetcLtoAuthorization = lsvItems.Items(lsvItems.FocusedItem.Index).SubItems(15).Text
            vPetcRegion = lsvItems.Items(lsvItems.FocusedItem.Index).SubItems(24).Text
            vPetcExiration = lsvItems.Items(lsvItems.FocusedItem.Index).SubItems(21).Text

            '            If IsDate(vPetcExiration) = False Then
            ' vPetcExiration = ""
            ' Else
            ' vPetcExiration = CDate(vPetcExiration).AddYears(1).ToString("MM/dd/yyyy")
            ' End If

            'get PETC Code

            vResult = ""
            vResult = UCase(Trim(InputBox("Should you wish to export it with different PETC Code, please change it to desired PETC Code." & vbCrLf & vbCrLf & _
                             "Please enter desired PETC Code to export to:", "Export PETC with Code:" & vPetcCode, vPetcCode)))

            vNewPetcCode = vPetcCode
            If vResult = vPetcCode Then
            Else
                If vResult = "" Then
                    vTmpVar = MsgBox("User cancelled or no PETC Code entered. No changes were made.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Operation cancelled")

                    lblStatusPrompt.Visible = False

                    Exit Sub
                Else
                    vTmpVar = MsgBox("You are about to export PETC with Code " & vPetcCode & _
                                     " to PETC with new Code " & vResult & "." & vbCrLf & vbCrLf & _
                                     "Are you sure of this?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "User confirmation")

                    If vTmpVar = MsgBoxResult.Yes Then
                        vNewPetcCode = vResult
                    Else
                        vTmpVar = MsgBox("User cancelled. No changes were made.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Operation cancelled")

                        lblStatusPrompt.Visible = False

                        Exit Sub
                    End If
                End If
            End If

            lblStatusPrompt.Text = "Opening database..."
            lblStatusPrompt.Visible = True
            lblStatusPrompt.Refresh()

            'open db connection
            vMyPgCon.ConnectionString = pConnectVox
            vMyPgCon.Open()

            'create export config for PETC terminals

            'create query
            vQuery = "SELECT terminal_id, terminal_type, terminal_serial, terminal_mac, terminal_ip, terminal_machine_description, " & _
                "terminal_machine_serial, terminal_machine_calibrated, petc_code, petc_lane, is_active, description, lock_status, " & _
                "dll_file, machine_port, machine_baud_rate, machine_parity, machine_bits, machine_stop_bits " & _
                "FROM tb_stations WHERE is_active = 1 AND petc_code = '" & modModule.CorrectSqlString(vPetcCode) & "'"

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
                    vTerminalId = ""
                    vTerminalLane = ""
                    vTerminalDescription = ""
                    vTerminalType = ""
                    vTerminalSerial = ""
                    vTerminalMac = ""
                    vTerminalIP = ""
                    vTerminalMachineDescription = ""
                    vTerminalMachineSerial = ""
                    vTerminalDateCalibrated = ""
                    vTerminalLastTestDateTime = "01/01/2000 00:00:00"
                    vTerminalMachineDLL = ""
                    vTerminalMachinePort = ""
                    vTerminalMachineBaud = ""
                    vTerminalMachineParity = ""
                    vTerminalMachineBits = ""
                    vTerminalMachineStopBits = ""

                    If IsDBNull(vMyPgRd("terminal_id")) = False Then
                        vTerminalId = vMyPgRd("terminal_id")
                    End If

                    If IsDBNull(vMyPgRd("petc_lane")) = False Then
                        vTerminalLane = vMyPgRd("petc_lane")
                    End If

                    If IsDBNull(vMyPgRd("description")) = False Then
                        vTerminalDescription = vMyPgRd("description")
                    End If

                    If IsDBNull(vMyPgRd("terminal_type")) = False Then
                        vTerminalType = vMyPgRd("terminal_type")
                    End If

                    If IsDBNull(vMyPgRd("terminal_serial")) = False Then
                        vTerminalSerial = vMyPgRd("terminal_serial")
                    End If

                    If IsDBNull(vMyPgRd("terminal_mac")) = False Then
                        vTerminalMac = vMyPgRd("terminal_mac")
                    End If

                    If IsDBNull(vMyPgRd("terminal_ip")) = False Then
                        vTerminalIP = vMyPgRd("terminal_ip")
                    End If

                    If IsDBNull(vMyPgRd("terminal_machine_description")) = False Then
                        vTerminalMachineDescription = vMyPgRd("terminal_machine_description")
                    End If

                    If IsDBNull(vMyPgRd("terminal_machine_serial")) = False Then
                        vTerminalMachineSerial = vMyPgRd("terminal_machine_serial")
                    End If

                    If IsDBNull(vMyPgRd("terminal_machine_calibrated")) = False Then
                        vTerminalDateCalibrated = vMyPgRd("terminal_machine_calibrated")
                    End If

                    If IsDBNull(vMyPgRd("dll_file")) = False Then
                        vTerminalMachineDLL = vMyPgRd("dll_file")
                    End If

                    If IsDBNull(vMyPgRd("machine_port")) = False Then
                        vTerminalMachinePort = vMyPgRd("machine_port")
                    End If

                    If IsDBNull(vMyPgRd("machine_baud_rate")) = False Then
                        vTerminalMachineBaud = vMyPgRd("machine_baud_rate")
                    End If

                    If IsDBNull(vMyPgRd("machine_parity")) = False Then
                        vTerminalMachineParity = vMyPgRd("machine_parity")
                    End If

                    If IsDBNull(vMyPgRd("machine_bits")) = False Then
                        vTerminalMachineBits = vMyPgRd("machine_bits")
                    End If

                    If IsDBNull(vMyPgRd("machine_stop_bits")) = False Then
                        vTerminalMachineStopBits = vMyPgRd("machine_stop_bits")
                    End If

                    'create file
                    FileCopy(pWorkDirectory & "\Temp\Org Settings.config", pWorkDirectory & "\Export - " & vNewPetcCode & " - " & _
                             vTerminalLane & " - " & vTerminalType & ".config")

                    'get filename to process
                    vFilename = pWorkDirectory & "\Export - " & vNewPetcCode & " - " & vTerminalLane & " - " & vTerminalType & ".config"

                    vResult = ChangeXmlKey(vFilename, "/configuration/appSettings", "Auth_PetcCode", vNewPetcCode)

                    If vResult = "ok" Then vResult = ChangeXmlKey(vFilename, "/configuration/appSettings", "Auth_PetcName", vPetcName)
                    If vResult = "ok" Then vResult = ChangeXmlKey(vFilename, "/configuration/appSettings", "Auth_PetcDescription", vPetcDescription)
                    If vResult = "ok" Then vResult = ChangeXmlKey(vFilename, "/configuration/appSettings", "Auth_PetcLanes", vPetcLanes)
                    If vResult = "ok" Then vResult = ChangeXmlKey(vFilename, "/configuration/appSettings", "Auth_PetcCategory", vPetcCategory)
                    If vResult = "ok" Then vResult = ChangeXmlKey(vFilename, "/configuration/appSettings", "Auth_PetcAddress", vPetcAddress)
                    If vResult = "ok" Then vResult = ChangeXmlKey(vFilename, "/configuration/appSettings", "Auth_PetcContactNos", vPetcContact)
                    If vResult = "ok" Then vResult = ChangeXmlKey(vFilename, "/configuration/appSettings", "Auth_PetcBusinessType", vPetcBusinessType)
                    If vResult = "ok" Then vResult = ChangeXmlKey(vFilename, "/configuration/appSettings", "Auth_PetcLtoServiceArea", vPetcLtoServiceArea)
                    If vResult = "ok" Then vResult = ChangeXmlKey(vFilename, "/configuration/appSettings", "Auth_PetcDtiNo", vPetcDtiAccreditation)
                    If vResult = "ok" Then vResult = ChangeXmlKey(vFilename, "/configuration/appSettings", "Auth_PetcLtoNo", vPetcLtoAuthorization)
                    If vResult = "ok" Then vResult = ChangeXmlKey(vFilename, "/configuration/appSettings", "ExpiryDate", vPetcExiration)
                    If vResult = "ok" Then vResult = ChangeXmlKey(vFilename, "/configuration/appSettings", "RegionCode", vPetcRegion)

                    If vResult = "ok" Then vResult = ChangeXmlKey(vFilename, "/configuration/appSettings", "TerminalId", vTerminalId)
                    If vResult = "ok" Then vResult = ChangeXmlKey(vFilename, "/configuration/appSettings", "Auth_PetcLane", vTerminalLane)
                    If vResult = "ok" Then vResult = ChangeXmlKey(vFilename, "/configuration/appSettings", "Auth_PetcTerminalType", vTerminalType)
                    If vResult = "ok" Then vResult = ChangeXmlKey(vFilename, "/configuration/appSettings", "Auth_PetcTerminalSerial", vTerminalSerial)
                    If vResult = "ok" Then vResult = ChangeXmlKey(vFilename, "/configuration/appSettings", "Auth_PetcTerminalMac", vTerminalMac)
                    If vResult = "ok" Then vResult = ChangeXmlKey(vFilename, "/configuration/appSettings", "Auth_PetcTerminalIP", vTerminalIP)
                    If vResult = "ok" Then vResult = ChangeXmlKey(vFilename, "/configuration/appSettings", "Auth_PetcTerminalMachineDescription", vTerminalMachineDescription)
                    If vResult = "ok" Then vResult = ChangeXmlKey(vFilename, "/configuration/appSettings", "Auth_PetcTerminalMachineSerial", vTerminalMachineSerial)
                    If vResult = "ok" Then vResult = ChangeXmlKey(vFilename, "/configuration/appSettings", "Auth_PetcTerminalDateCalibrated", vTerminalDateCalibrated)
                    If vResult = "ok" Then vResult = ChangeXmlKey(vFilename, "/configuration/appSettings", "Auth_PetcTerminalDescription", vTerminalDescription)
                    If vResult = "ok" Then vResult = ChangeXmlKey(vFilename, "/configuration/appSettings", "LastTestDateTime", vTerminalLastTestDateTime)

                    If vResult = "ok" Then vResult = ChangeXmlKey(vFilename, "/configuration/appSettings", "DLLFile", vTerminalMachineDLL)
                    If vResult = "ok" Then vResult = ChangeXmlKey(vFilename, "/configuration/appSettings", "PortName", "COM" & vTerminalMachinePort)
                    If vResult = "ok" Then vResult = ChangeXmlKey(vFilename, "/configuration/appSettings", "Baud", vTerminalMachineBaud)
                    If vResult = "ok" Then vResult = ChangeXmlKey(vFilename, "/configuration/appSettings", "Parity", vTerminalMachineParity)
                    If vResult = "ok" Then vResult = ChangeXmlKey(vFilename, "/configuration/appSettings", "Bits", vTerminalMachineBits)
                    If vResult = "ok" Then vResult = ChangeXmlKey(vFilename, "/configuration/appSettings", "StopBits", vTerminalMachineStopBits)

                    If vResult = "ok" Then vResult = ChangeXmlKey(vFilename, "/configuration/appSettings", "Test", "true")
                    If vResult = "ok" Then vResult = ChangeXmlKey(vFilename, "/configuration/appSettings", "GasCap", "48")
                    If vResult = "ok" Then vResult = ChangeXmlKey(vFilename, "/configuration/appSettings", "DieselCap", "32")
                    If vResult = "ok" Then vResult = ChangeXmlKey(vFilename, "/configuration/appSettings", "Interval", "true")

                    Select Case LCase(Trim(vTerminalType))
                        Case "gas"
                            If vResult = "ok" Then vResult = ChangeXmlKey(vFilename, "/configuration/appSettings", "Span", "10")

                        Case "diesel"
                            If vResult = "ok" Then vResult = ChangeXmlKey(vFilename, "/configuration/appSettings", "Span", "15")
                    End Select

                    If vResult = "ok" Then vResult = ChangeXmlKey(vFilename, "/configuration/appSettings", "Auth_FirstName", "")
                    If vResult = "ok" Then vResult = ChangeXmlKey(vFilename, "/configuration/appSettings", "Auth_MiddleName", "")
                    If vResult = "ok" Then vResult = ChangeXmlKey(vFilename, "/configuration/appSettings", "Auth_LastName", "")
                    If vResult = "ok" Then vResult = ChangeXmlKey(vFilename, "/configuration/appSettings", "Auth_UserTesdaCert", "")
                    If vResult = "ok" Then vResult = ChangeXmlKey(vFilename, "/configuration/appSettings", "Auth_UserDescription", "")
                    If vResult = "ok" Then vResult = ChangeXmlKey(vFilename, "/configuration/appSettings", "LastCECNo", "")
                    If vResult = "ok" Then vResult = ChangeXmlKey(vFilename, "/configuration/appSettings", "LastORNo", "")

                    If vResult <> "ok" Then

                    End If

                    vRecs = vRecs + 1

                    lblStatusPrompt.Text = "Exporting data... " & Trim(Str(vRecs)) & " records exported"
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

            'create export tables - PETC DATA

            'get filename to process
            vFilename = pWorkDirectory & "\Export - " & vNewPetcCode & " - PETC DATA.csv"

            ' 5 .Add("Pay type", 100, HorizontalAlignment.Left)
            ' 6 .Add("Balance", 0, HorizontalAlignment.Right)
            ' 7 .Add("Transmission fee", 100, HorizontalAlignment.Right)
            ' 8 .Add("Stradcom fee", 100, HorizontalAlignment.Right)

            vQuery = "COPY (SELECT a.petc_code, a.petc_lanes, a.petc_category, a.petc_name, a.petc_address, a.contact_no, a.business_type, " & _
                "a.lto_service_area, a.dti_accreditation_no, a.lto_authorization_no, a.date_it_started, a.date_it_accredited, a.date_it_renewal date, " & _
                "a.date_petc_started, a.date_petc_accredited, a.date_petc_authorized, a.is_active, a.description, a.gm, a.province, a.region, " & _
                "a.account_id, a.account_manager, a.tech_manager, a.marketing_agent, a.marketing_commission, " & _
                "b.transmission_fee, b.account_type, b.remarks, b.stradcom_fee, b.max_credit " & _
                "FROM tb_petcs AS a LEFT OUTER JOIN tb_petc_balance AS b ON a.petc_code = b.petc_code " & _
                "WHERE a.petc_code = '" & modModule.CorrectSqlString(vPetcCode) & "' AND a.is_active = 1) TO " & _
                "'" & vFilename & "' HEADER CSV"

            'create query
            vMyPgCmd = New NpgsqlCommand(vQuery, vMyPgCon)

            'execute query
            vMyPgCmd.ExecuteNonQuery()

            'close and dispose to avoid memory leak
            vMyPgCmd.Dispose()

            'create export tables - PETC STATIONS DATA

            'get filename to process
            vFilename = pWorkDirectory & "\Export - " & vNewPetcCode & " - STATIONS DATA.csv"

            vQuery = "COPY (SELECT terminal_id, terminal_type, terminal_serial, terminal_mac, terminal_ip, terminal_machine_description, " & _
                "terminal_machine_serial, terminal_machine_calibrated, petc_code, petc_lane, is_active, description, lock_status, " & _
                "dll_file, machine_parity, machine_bits, machine_port, machine_baud_rate, machine_stop_bits, is_scsi " & _
                "FROM tb_stations WHERE petc_code = '" & modModule.CorrectSqlString(vPetcCode) & "' AND is_active = 1) TO " & _
                "'" & vFilename & "' HEADER CSV"

            'create query
            vMyPgCmd = New NpgsqlCommand(vQuery, vMyPgCon)

            'execute query
            vMyPgCmd.ExecuteNonQuery()

            'close and dispose to avoid memory leak
            vMyPgCmd.Dispose()

            'create export tables - PETC USERS DATA

            'get filename to process
            vFilename = pWorkDirectory & "\Export - " & vNewPetcCode & " - USERS DATA.csv"

            vQuery = "COPY (SELECT recno, user_id, employee_id, password, first_name, middle_name, last_name, gender, " & _
                "petc_code, certificate_tesda, certificate_tesda_expiration, is_active, description, user_type, user_name " & _
                "FROM tb_users WHERE petc_code = '" & modModule.CorrectSqlString(vPetcCode) & "' AND is_active = 1) TO " & _
                "'" & vFilename & "' HEADER CSV"

            'create query
            vMyPgCmd = New NpgsqlCommand(vQuery, vMyPgCon)

            'execute query
            vMyPgCmd.ExecuteNonQuery()

            'close and dispose to avoid memory leak
            vMyPgCmd.Dispose()

            'close and dispose connection
            vMyPgCon.Close()
            vMyPgCon = Nothing

            lblStatusPrompt.Visible = False

            Dim vTmpStr As String

            'log event
            vTmpStr = modModule.CreateLog(Me.Name, "PETC Manager - Export", "Exported PETC:" & modModule.CorrectSqlString(vPetcCode) & _
                                          " to PETC:" & vNewPetcCode)

            MsgBox("Finished exporting PETC data." & vbCrLf & vbCrLf & _
                   "Location: " & pWorkDirectory & "\" & vbCrLf & _
                   "Number of records exported: " & vRecs.ToString, MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Operation complete")

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
            vQuery = modModule.CreateLog(Me.Name, "Error:CmdExport", ex.Message)

            lblStatusPrompt.Visible = False
        End Try
    End Sub

    Private Sub cmdImport_Click(sender As Object, e As EventArgs) Handles cmdImport.Click
        frmPetcManagerImport.ShowDialog()
    End Sub
End Class