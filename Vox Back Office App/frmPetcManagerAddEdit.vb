Imports Npgsql

Public Class frmPetcManagerAddEdit

    Private gMode As String
    Private gPetcCode As String
    Private gFirstLoad As Boolean

    Private gOldLanes As String
    Private gOldCategory As String
    Private gOldName As String
    Private gOldBusinessType As String
    Private gOldAddress As String
    Private gOldDescription As String
    Private gOldContact As String
    Private gOldStatus As String
    Private gOldRegion As String
    Private gOldProvince As String
    Private gOldLtoServiceArea As String
    Private gOldDtiAccreditationNo As String
    Private gOldLtoAuthorizationNo As String
    Private gOldAccountType As String
    Private gOldTransmissionFee As String
    Private gOldStradcomFee As String
    Private gOldMaxCredit As String
    Private gOldPetcDateStart As String
    Private gOldPetcDateAccredit As String
    Private gOldPetcDateAuthorized As String
    Private gOldItDateStart As String
    Private gOldItDateAccredit As String
    Private gOldItDateRenewal As String
    Private gOldGM As String
    Private gOldAccountID As String
    Private gOldAccountManager As String
    Private gOldTechManager As String
    Private gOldMarketingAgent As String
    Private gOldMarketingCommission As String

    Private gOldMaxTransPerDay As String
    Private gOldLtmsReady As String

    Property Mode() As String
        Get
            Return gMode
        End Get

        Set(ByVal value As String)
            gMode = value
        End Set
    End Property

    Property PetcCode() As String
        Get
            Return gPetcCode
        End Get

        Set(ByVal value As String)
            gPetcCode = value
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
        vTmpStr = modModule.CreateLog(Me.Name, "PETC Manager - Add/Edit - Close", "")

        If vTmpStr = "1" Then
            Me.Close()
        Else
            MsgBox("An error occurred while saving log. Operation aborted.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Operation cancelled")
        End If
    End Sub

    Private Sub InitializeValues()
        txtCode.Text = ""
        txtName.Text = ""
        txtAddress.Text = ""
        cmbLanes.Text = ""
        cmbCategory.Text = ""
        cmbBusinessTypes.Text = ""
        txtDescription.Text = ""
        txtContact.Text = ""
        cmbStatus.Text = ""
        cmbOwner.Text = ""
        cmbAccountManager.Text = ""
        cmbTechManager.Text = ""
        cmbMarketingAgent.Text = ""
        txtMarketingCommission.Text = "0.00"

        cmbRegion.Items.Clear()
        cmbRegion.Text = ""

        cmbProvince.Items.Clear()
        cmbProvince.Text = ""

        cmbLtoServiceArea.Items.Clear()
        cmbLtoServiceArea.Text = ""

        txtDtiAccreditationNo.Text = ""
        txtLtoAuthorizationNo.Text = ""

        cmbAccountType.Text = ""
        txtTransmissionFee.Text = "0.00"
        txtStradcomFee.Text = "0.00"
        txtMaxCredit.Text = "0.00"
        txtBalance.Text = "0.00"

        txtPetcDateStarted.Text = ""
        txtPetcDateAccredited.Text = ""
        txtPetcDateAuthorized.Text = ""

        txtItDateStarted.Text = ""
        txtItDateAccredited.Text = ""
        txtItDateRenewal.Text = ""

        chkGM1.Checked = False
        chkGM2.Checked = False
        chkGM3.Checked = False
        chkGM4.Checked = False
        chkGM5.Checked = False
        chkGM6.Checked = False
        chkGM7.Checked = False
        chkGM8.Checked = False
        chkGM9.Checked = False
        chkGM10.Checked = False
        chkGM11.Checked = False
        chkGM12.Checked = False
        chkGM13.Checked = False
        chkGM14.Checked = False
        chkGM15.Checked = False
        chkGM16.Checked = False

        gOldLanes = ""
        gOldCategory = ""
        gOldName = ""
        gOldBusinessType = ""
        gOldAddress = ""
        gOldDescription = ""
        gOldContact = ""
        gOldStatus = ""
        gOldRegion = ""
        gOldProvince = ""
        gOldLtoServiceArea = ""
        gOldDtiAccreditationNo = ""
        gOldLtoAuthorizationNo = ""
        gOldAccountType = ""
        gOldTransmissionFee = ""
        gOldStradcomFee = ""
        gOldMaxCredit = ""
        gOldPetcDateStart = ""
        gOldPetcDateAccredit = ""
        gOldPetcDateAuthorized = ""
        gOldItDateStart = ""
        gOldItDateAccredit = ""
        gOldItDateRenewal = ""
        gOldGM = ""
        gOldAccountID = ""
        gOldAccountManager = ""
        gOldTechManager = ""
        gOldMarketingAgent = ""
        gOldMarketingCommission = ""

        gOldMaxTransPerDay = "80"
        gOldLtmsReady = ""
    End Sub

    Private Sub SaveOldValues()
        gOldLanes = cmbLanes.Text
        gOldCategory = cmbCategory.Text
        gOldName = txtName.Text
        gOldBusinessType = cmbBusinessTypes.Text
        gOldAddress = txtAddress.Text
        gOldDescription = txtDescription.Text
        gOldContact = txtContact.Text
        gOldStatus = cmbStatus.Text
        gOldRegion = cmbRegion.Text
        gOldProvince = cmbProvince.Text
        gOldLtoServiceArea = cmbLtoServiceArea.Text
        gOldDtiAccreditationNo = txtDtiAccreditationNo.Text
        gOldLtoAuthorizationNo = txtLtoAuthorizationNo.Text
        gOldAccountType = cmbAccountType.Text
        gOldTransmissionFee = txtTransmissionFee.Text
        gOldStradcomFee = txtStradcomFee.Text
        gOldMaxCredit = txtMaxCredit.Text
        gOldPetcDateStart = txtPetcDateStarted.Text
        gOldPetcDateAccredit = txtPetcDateAccredited.Text
        gOldPetcDateAuthorized = txtPetcDateAuthorized.Text
        gOldItDateStart = txtItDateStarted.Text
        gOldItDateAccredit = txtItDateAccredited.Text
        gOldItDateRenewal = txtItDateRenewal.Text
        gOldGM = IIf(chkGM1.Checked = True, "1", "0") & _
            IIf(chkGM2.Checked = True, "1", "0") & _
            IIf(chkGM3.Checked = True, "1", "0") & _
            IIf(chkGM4.Checked = True, "1", "0") & _
            IIf(chkGM5.Checked = True, "1", "0") & _
            IIf(chkGM6.Checked = True, "1", "0") & _
            IIf(chkGM7.Checked = True, "1", "0") & _
            IIf(chkGM8.Checked = True, "1", "0") & _
            IIf(chkGM9.Checked = True, "1", "0") & _
            IIf(chkGM10.Checked = True, "1", "0") & _
            IIf(chkGM11.Checked = True, "1", "0") & _
            IIf(chkGM12.Checked = True, "1", "0") & _
            IIf(chkGM13.Checked = True, "1", "0") & _
            IIf(chkGM14.Checked = True, "1", "0") & _
            IIf(chkGM15.Checked = True, "1", "0") & _
            IIf(chkGM16.Checked = True, "1", "0")

        If Trim(cmbOwner.Text) = "" Then
            gOldAccountID = ""
        Else
            gOldAccountID = Microsoft.VisualBasic.Right(cmbOwner.Text, 12)
        End If

        If Trim(cmbAccountManager.Text) = "" Then
            gOldAccountManager = ""
        Else
            gOldAccountManager = Microsoft.VisualBasic.Right(cmbAccountManager.Text, 12)
        End If

        If Trim(cmbTechManager.Text) = "" Then
            gOldTechManager = ""
        Else
            gOldTechManager = Microsoft.VisualBasic.Right(cmbTechManager.Text, 12)
        End If

        If Trim(cmbMarketingAgent.Text) = "" Then
            gOldMarketingAgent = ""
        Else
            gOldMarketingAgent = Microsoft.VisualBasic.Right(cmbMarketingAgent.Text, 12)
        End If

        gOldMarketingCommission = txtMarketingCommission.Text

        gOldLtmsReady = IIf(chkIsLTMSReady.Checked = True, "1", "0")
        gOldMaxTransPerDay = txtMaxTransPerDay.Text

    End Sub

    Private Function ChangesMade(Optional ByRef bChanges As String = "", Optional ByVal bPutCrLf As Boolean = False) As Boolean
        ChangesMade = False
        bChanges = ""

        If gOldLanes <> cmbLanes.Text Then
            ChangesMade = True
            bChanges = bChanges & IIf(bChanges <> "", IIf(bPutCrLf = True, vbCrLf, ", "), "") & _
                "Lanes from " & gOldLanes & " to " & cmbLanes.Text
        End If

        If gOldCategory <> cmbCategory.Text Then
            ChangesMade = True
            bChanges = bChanges & IIf(bChanges <> "", IIf(bPutCrLf = True, vbCrLf, ", "), "") & _
                "Category from " & gOldCategory & " to " & cmbCategory.Text
        End If

        If gOldName <> txtName.Text Then
            ChangesMade = True
            bChanges = bChanges & IIf(bChanges <> "", IIf(bPutCrLf = True, vbCrLf, ", "), "") & _
                "Name from " & gOldName & " to " & txtName.Text
        End If

        If gOldBusinessType <> cmbBusinessTypes.Text Then
            ChangesMade = True
            bChanges = bChanges & IIf(bChanges <> "", IIf(bPutCrLf = True, vbCrLf, ", "), "") & _
                "Business type from " & gOldBusinessType & " to " & cmbBusinessTypes.Text
        End If

        If gOldAddress <> txtAddress.Text Then
            ChangesMade = True
            bChanges = bChanges & IIf(bChanges <> "", IIf(bPutCrLf = True, vbCrLf, ", "), "") & _
                "Address from " & gOldAddress & " to " & txtAddress.Text
        End If

        If gOldDescription <> txtDescription.Text Then
            ChangesMade = True
            bChanges = bChanges & IIf(bChanges <> "", IIf(bPutCrLf = True, vbCrLf, ", "), "") & _
                "Description from " & gOldDescription & " to " & txtDescription.Text
        End If

        If gOldContact <> txtContact.Text Then
            ChangesMade = True
            bChanges = bChanges & IIf(bChanges <> "", IIf(bPutCrLf = True, vbCrLf, ", "), "") & _
                "Contact from " & gOldContact & " to " & txtContact.Text
        End If

        If gOldStatus <> cmbStatus.Text Then
            ChangesMade = True
            bChanges = bChanges & IIf(bChanges <> "", IIf(bPutCrLf = True, vbCrLf, ", "), "") & _
                "Status from " & gOldStatus & " to " & cmbStatus.Text
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

        If gOldLtoServiceArea <> cmbLtoServiceArea.Text Then
            ChangesMade = True
            bChanges = bChanges & IIf(bChanges <> "", IIf(bPutCrLf = True, vbCrLf, ", "), "") & _
                "LTO service area from " & gOldLtoServiceArea & " to " & cmbLtoServiceArea.Text
        End If

        If gOldDtiAccreditationNo <> txtDtiAccreditationNo.Text Then
            ChangesMade = True
            bChanges = bChanges & IIf(bChanges <> "", IIf(bPutCrLf = True, vbCrLf, ", "), "") & _
                "DTI acrreditation no. from " & gOldDtiAccreditationNo & " to " & txtDtiAccreditationNo.Text
        End If

        If gOldLtoAuthorizationNo <> txtLtoAuthorizationNo.Text Then
            ChangesMade = True
            bChanges = bChanges & IIf(bChanges <> "", IIf(bPutCrLf = True, vbCrLf, ", "), "") & _
                "LTO authorization no. from " & gOldLtoAuthorizationNo & " to " & txtLtoAuthorizationNo.Text
        End If

        If gOldAccountType <> cmbAccountType.Text Then
            ChangesMade = True
            bChanges = bChanges & IIf(bChanges <> "", IIf(bPutCrLf = True, vbCrLf, ", "), "") & _
                "Account type from " & gOldAccountType & " to " & cmbAccountType.Text
        End If

        If gOldTransmissionFee <> txtTransmissionFee.Text Then
            ChangesMade = True
            bChanges = bChanges & IIf(bChanges <> "", IIf(bPutCrLf = True, vbCrLf, ", "), "") & _
                "Transmission fee from " & gOldTransmissionFee & " to " & txtTransmissionFee.Text
        End If

        If gOldStradcomFee <> txtStradcomFee.Text Then
            ChangesMade = True
            bChanges = bChanges & IIf(bChanges <> "", IIf(bPutCrLf = True, vbCrLf, ", "), "") & _
                "Stradcom fee from " & gOldStradcomFee & " to " & txtStradcomFee.Text
        End If

        If gOldMaxCredit <> txtMaxCredit.Text Then
            ChangesMade = True
            bChanges = bChanges & IIf(bChanges <> "", IIf(bPutCrLf = True, vbCrLf, ", "), "") & _
                "Maximum credit from " & gOldMaxCredit & " to " & txtMaxCredit.Text
        End If

        If gOldPetcDateStart <> txtPetcDateStarted.Text Then
            ChangesMade = True
            bChanges = bChanges & IIf(bChanges <> "", IIf(bPutCrLf = True, vbCrLf, ", "), "") & _
                "Date PETC started from " & gOldPetcDateStart & " to " & txtPetcDateStarted.Text
        End If

        If gOldPetcDateAccredit <> txtPetcDateAccredited.Text Then
            ChangesMade = True
            bChanges = bChanges & IIf(bChanges <> "", IIf(bPutCrLf = True, vbCrLf, ", "), "") & _
                "Date PETC accredited from " & gOldPetcDateAccredit & " to " & txtPetcDateAccredited.Text
        End If

        If gOldPetcDateAuthorized <> txtPetcDateAuthorized.Text Then
            ChangesMade = True
            bChanges = bChanges & IIf(bChanges <> "", IIf(bPutCrLf = True, vbCrLf, ", "), "") & _
                "Date of PETC authorized from " & gOldPetcDateAuthorized & " to " & txtPetcDateAuthorized.Text
        End If

        If gOldItDateStart <> txtItDateStarted.Text Then
            ChangesMade = True
            bChanges = bChanges & IIf(bChanges <> "", IIf(bPutCrLf = True, vbCrLf, ", "), "") & _
                "Date started with I.T. from " & gOldItDateStart & " to " & txtItDateStarted.Text
        End If

        If gOldItDateAccredit <> txtItDateAccredited.Text Then
            ChangesMade = True
            bChanges = bChanges & IIf(bChanges <> "", IIf(bPutCrLf = True, vbCrLf, ", "), "") & _
                "Date accredited with I.T. from " & gOldItDateAccredit & " to " & txtItDateAccredited.Text
        End If

        If gOldItDateRenewal <> txtItDateRenewal.Text Then
            ChangesMade = True
            bChanges = bChanges & IIf(bChanges <> "", IIf(bPutCrLf = True, vbCrLf, ", "), "") & _
                "Date of I.T. renewal from " & gOldItDateRenewal & " to " & txtItDateRenewal.Text
        End If

        If gOldGM <> (IIf(chkGM1.Checked = True, "1", "0") & IIf(chkGM2.Checked = True, "1", "0") & IIf(chkGM3.Checked = True, "1", "0") & _
                      IIf(chkGM4.Checked = True, "1", "0") & IIf(chkGM5.Checked = True, "1", "0") & IIf(chkGM6.Checked = True, "1", "0") & _
                      IIf(chkGM7.Checked = True, "1", "0") & IIf(chkGM8.Checked = True, "1", "0") & IIf(chkGM9.Checked = True, "1", "0") & _
                      IIf(chkGM10.Checked = True, "1", "0") & IIf(chkGM11.Checked = True, "1", "0") & IIf(chkGM12.Checked = True, "1", "0") & _
                      IIf(chkGM13.Checked = True, "1", "0") & IIf(chkGM14.Checked = True, "1", "0") & IIf(chkGM15.Checked = True, "1", "0") & _
                      IIf(chkGM16.Checked = True, "1", "0")) Then
            ChangesMade = True
            bChanges = bChanges & IIf(bChanges <> "", IIf(bPutCrLf = True, vbCrLf, ", "), "") & _
                "GM from " & gOldGM & " to " & IIf(chkGM1.Checked = True, "1", "0") & _
                IIf(chkGM2.Checked = True, "1", "0") & _
                IIf(chkGM3.Checked = True, "1", "0") & _
                IIf(chkGM4.Checked = True, "1", "0") & _
                IIf(chkGM5.Checked = True, "1", "0") & _
                IIf(chkGM6.Checked = True, "1", "0") & _
                IIf(chkGM7.Checked = True, "1", "0") & _
                IIf(chkGM8.Checked = True, "1", "0") & _
                IIf(chkGM9.Checked = True, "1", "0") & _
                IIf(chkGM10.Checked = True, "1", "0") & _
                IIf(chkGM11.Checked = True, "1", "0") & _
                IIf(chkGM12.Checked = True, "1", "0") & _
                IIf(chkGM13.Checked = True, "1", "0") & _
                IIf(chkGM14.Checked = True, "1", "0") & _
                IIf(chkGM15.Checked = True, "1", "0") & _
                IIf(chkGM16.Checked = True, "1", "0")
        End If

        If Trim(cmbOwner.Text) = "" Then
            If gOldAccountID <> "" Then
                ChangesMade = True
                bChanges = bChanges & IIf(bChanges <> "", IIf(bPutCrLf = True, vbCrLf, ", "), "") & _
                    "Owner account ID from " & gOldAccountID & " to " & ""
            End If
        Else
            If gOldAccountID <> Microsoft.VisualBasic.Right(cmbOwner.Text, 12) Then
                ChangesMade = True
                bChanges = bChanges & IIf(bChanges <> "", IIf(bPutCrLf = True, vbCrLf, ", "), "") & _
                    "Owner account ID from " & gOldAccountID & " to " & Microsoft.VisualBasic.Right(cmbOwner.Text, 12)
            End If
        End If

        If Trim(cmbAccountManager.Text) = "" Then
            If gOldAccountManager <> "" Then
                ChangesMade = True
                bChanges = bChanges & IIf(bChanges <> "", IIf(bPutCrLf = True, vbCrLf, ", "), "") & _
                    "Account manager from " & gOldAccountManager & " to " & ""
            End If
        Else
            If gOldAccountManager <> Microsoft.VisualBasic.Right(cmbAccountManager.Text, 12) Then
                ChangesMade = True
                bChanges = bChanges & IIf(bChanges <> "", IIf(bPutCrLf = True, vbCrLf, ", "), "") & _
                    "Account manager from " & gOldAccountManager & " to " & Microsoft.VisualBasic.Right(cmbAccountManager.Text, 12)
            End If
        End If

        If Trim(cmbTechManager.Text) = "" Then
            If gOldTechManager <> "" Then
                ChangesMade = True
                bChanges = bChanges & IIf(bChanges <> "", IIf(bPutCrLf = True, vbCrLf, ", "), "") & _
                    "Technical manager from " & gOldTechManager & " to " & ""
            End If
        Else
            If gOldTechManager <> Microsoft.VisualBasic.Right(cmbTechManager.Text, 12) Then
                ChangesMade = True
                bChanges = bChanges & IIf(bChanges <> "", IIf(bPutCrLf = True, vbCrLf, ", "), "") & _
                    "Technical manager from " & gOldTechManager & " to " & Microsoft.VisualBasic.Right(cmbTechManager.Text, 12)
            End If
        End If

        If Trim(cmbMarketingAgent.Text) = "" Then
            If gOldMarketingAgent <> "" Then
                ChangesMade = True
                bChanges = bChanges & IIf(bChanges <> "", IIf(bPutCrLf = True, vbCrLf, ", "), "") & _
                    "Marketing agent from " & gOldMarketingAgent & " to " & ""
            End If
        Else
            If gOldMarketingAgent <> Microsoft.VisualBasic.Right(cmbMarketingAgent.Text, 12) Then
                ChangesMade = True
                bChanges = bChanges & IIf(bChanges <> "", IIf(bPutCrLf = True, vbCrLf, ", "), "") & _
                    "Marketing agent from " & gOldMarketingAgent & " to " & Microsoft.VisualBasic.Right(cmbMarketingAgent.Text, 12)
            End If
        End If

        If gOldMarketingCommission <> txtMarketingCommission.Text Then
            ChangesMade = True
            bChanges = bChanges & IIf(bChanges <> "", IIf(bPutCrLf = True, vbCrLf, ", "), "") &
                "Marketing commission from " & gOldMarketingCommission & " to " & txtMarketingCommission.Text
        End If

        If gOldLtmsReady <> IIf(chkIsLTMSReady.Checked = True, "1", "0") Then
            ChangesMade = True
            bChanges = bChanges & IIf(bChanges <> "", IIf(bPutCrLf = True, vbCrLf, ", "), "") &
                "LTMS ready from " & gOldLtmsReady & " to " & IIf(chkIsLTMSReady.Checked = True, "1", "0")
        End If

        If gOldMaxTransPerDay <> txtMaxTransPerDay.Text Then
            ChangesMade = True
            bChanges = bChanges & IIf(bChanges <> "", IIf(bPutCrLf = True, vbCrLf, ", "), "") &
                "Maximum Transactions per Day from " & gOldMaxTransPerDay & " to " & txtMaxTransPerDay.Text
        End If
    End Function

    Private Sub frmLocationsManagerAddEdit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        gFirstLoad = True

        Select Case Me.Mode
            Case "new"
                Me.Text = "ADD NEW P.E.T.C. DATA"

                txtCode.ReadOnly = False

                cmdProcess.Text = "CREATE"

            Case "edit"
                Me.Text = "EDIT P.E.T.C. DATA"

                txtCode.ReadOnly = True

                cmdProcess.Text = "SAVE"
        End Select

        lblStatusPrompt.Visible = True
        lblStatusPrompt.Text = "Ready"

        'initialize controls

        txtCode.MaxLength = 5
        txtName.MaxLength = 100
        txtAddress.MaxLength = 0
        txtContact.MaxLength = 0

        txtDtiAccreditationNo.MaxLength = 32
        txtLtoAuthorizationNo.MaxLength = 32

        txtTransmissionFee.MaxLength = 6
        txtStradcomFee.MaxLength = 6

        txtBalance.MaxLength = 0
        txtBalance.ReadOnly = True

        txtPetcDateStarted.MaxLength = 0
        txtPetcDateAccredited.MaxLength = 0
        txtPetcDateAuthorized.MaxLength = 0

        txtItDateStarted.MaxLength = 0
        txtItDateAccredited.MaxLength = 0
        txtItDateRenewal.MaxLength = 0

        With cmbLanes
            .Items.Clear()

            .Items.Add("1")
            .Items.Add("2")
            .Items.Add("3")
            .Items.Add("4")
            .Items.Add("5")
            .Items.Add("6")
            .Items.Add("7")
            .Items.Add("8")
            .Items.Add("9")
            .Items.Add("10")

            .Text = ""
        End With

        With cmbCategory
            .Items.Clear()

            .Items.Add("Small")
            .Items.Add("Medium")
            .Items.Add("Large")
        End With

        With cmbBusinessTypes
            .Items.Clear()

            .Items.Add("Corporation")
            .Items.Add("Partnership")
            .Items.Add("Sole proprietorship")
            .Items.Add("Cooperative")
        End With

        With cmbStatus
            .Items.Clear()

            .Items.Add("Active")
            .Items.Add("Inactive")
            .Items.Add("Suspended")
            .Items.Add("Expired")
        End With

        With cmbAccountType
            .Items.Clear()

            .Items.Add("Pre-paid")
            .Items.Add("Post-paid")
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

        modModule.LoadTableFieldInComboBox(cmbRegion, "region", "tb_region_province_city", _
                                               "", "region ASC", lblStatusPrompt, True)

        modModule.LoadTableFieldInComboBox(cmbOwner, "account_name || ' - ' || account_id", "tb_client_accounts", _
                                               "is_active = 1", "account_name || ' - ' || account_id", lblStatusPrompt, True)

        modModule.LoadTableFieldInComboBox(cmbAccountManager, "account_name || ' - ' || account_id", "tb_managing_accounts", _
                                               "account_type = 'account manager' AND is_active = 1", "account_name || ' - ' || account_id", lblStatusPrompt, True)

        modModule.LoadTableFieldInComboBox(cmbTechManager, "account_name || ' - ' || account_id", "tb_managing_accounts", _
                                               "account_type = 'technical manager' AND is_active = 1", "account_name || ' - ' || account_id", lblStatusPrompt, True)

        modModule.LoadTableFieldInComboBox(cmbMarketingAgent, "account_name || ' - ' || account_id", "tb_managing_accounts", _
                                               "account_type = 'marketing agent' AND is_active = 1", "account_name || ' - ' || account_id", lblStatusPrompt, True)

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
        Dim vTmpAccountType As String = ""
        Dim vTmpGM As String = ""

        Try

            If Trim(txtCode.Text) = "" Then
                vTmpVar = MsgBox("PETC Code is required." & vbCrLf & vbCrLf & _
                               "Please enter PETC Code.", vbOKOnly + vbEmpty, "Incomplete data")

                txtCode.Select()
                txtCode.Focus()

                Exit Sub
            End If

            If cmbLanes.Text = "" Or cmbLanes.Text = "0" Then
                vTmpVar = MsgBox("Number of lanes for this PETC is required." & vbCrLf & vbCrLf & _
                               "Please select number of PETC lanes.", vbOKOnly + vbEmpty, "Incomplete data")

                cmbLanes.Select()
                cmbLanes.Focus()

                Exit Sub
            End If

            If cmbCategory.Text = "" Then
                vTmpVar = MsgBox("PETC category is required." & vbCrLf & vbCrLf & _
                               "Please select PETC category.", vbOKOnly + vbEmpty, "Incomplete data")

                cmbCategory.Select()
                cmbCategory.Focus()

                Exit Sub
            End If

            If cmbBusinessTypes.Text = "" Then
                vTmpVar = MsgBox("Business type is required." & vbCrLf & vbCrLf & _
                               "Please select business type.", vbOKOnly + vbEmpty, "Incomplete data")

                cmbBusinessTypes.Select()
                cmbBusinessTypes.Focus()

                Exit Sub
            End If

            If txtName.Text = "" Then
                vTmpVar = MsgBox("PETC name is required." & vbCrLf & vbCrLf & _
                               "Please enter the business name of the PETC.", vbOKOnly + vbEmpty, "Incomplete data")

                txtName.Select()
                txtName.Focus()

                Exit Sub
            End If

            If txtAddress.Text = "" Then
                vTmpVar = MsgBox("PETC address is required." & vbCrLf & vbCrLf & _
                               "Please enter the address of the PETC.", vbOKOnly + vbEmpty, "Incomplete data")

                txtAddress.Select()
                txtAddress.Focus()

                Exit Sub
            End If

            If cmbStatus.Text = "" Then
                vTmpVar = MsgBox("PETC status is required." & vbCrLf & vbCrLf & _
                               "Please select the current status of the PETC.", vbOKOnly + vbEmpty, "Incomplete data")

                cmbStatus.Select()
                cmbStatus.Focus()

                Exit Sub
            End If

            If cmbOwner.Text = "" Then
                vTmpVar = MsgBox("PETC owner is required." & vbCrLf & vbCrLf & _
                               "Please select the current owner of the PETC.", vbOKOnly + vbEmpty, "Incomplete data")

                cmbOwner.Select()
                cmbOwner.Focus()

                Exit Sub
            End If

            If cmbRegion.Text = "" Then
                vTmpVar = MsgBox("Region is required." & vbCrLf & vbCrLf & _
                               "Please enter the Region wherein this PETC is located.", vbOKOnly + vbEmpty, "Incomplete data")

                cmbRegion.Select()
                cmbRegion.Focus()

                Exit Sub
            End If

            If cmbProvince.Text = "" Then
                vTmpVar = MsgBox("Province is required." & vbCrLf & vbCrLf & _
                               "Please enter the Province wherein this PETC is located.", vbOKOnly + vbEmpty, "Incomplete data")

                cmbProvince.Select()
                cmbProvince.Focus()

                Exit Sub
            End If

            If cmbLtoServiceArea.Text = "" Then
                vTmpVar = MsgBox("LTO service area is required." & vbCrLf & vbCrLf & _
                               "Please enter the LTO branch that handles the PETC.", vbOKOnly + vbEmpty, "Incomplete data")

                cmbLtoServiceArea.Select()
                cmbLtoServiceArea.Focus()

                Exit Sub
            End If

            If txtDtiAccreditationNo.Text = "" Then
                vTmpVar = MsgBox("DTI accreditation number of the PETC is required." & vbCrLf & vbCrLf & _
                               "Please enter the DTI accredititation number.", vbOKOnly + vbEmpty, "Incomplete data")

                txtDtiAccreditationNo.Select()
                txtDtiAccreditationNo.Focus()

                Exit Sub
            End If

            If txtLtoAuthorizationNo.Text = "" Then
                vTmpVar = MsgBox("LTO authorization number of the PETC is required." & vbCrLf & vbCrLf & _
                               "Please enter the LTO authorization number.", vbOKOnly + vbEmpty, "Incomplete data")

                txtLtoAuthorizationNo.Select()
                txtLtoAuthorizationNo.Focus()

                Exit Sub
            End If

            If cmbAccountType.Text = "" Then
                vTmpVar = MsgBox("PETC payment method is required." & vbCrLf & vbCrLf & _
                               "Please select the payment method of the PETC.", vbOKOnly + vbEmpty, "Incomplete data")

                cmbAccountType.Select()
                cmbAccountType.Focus()

                Exit Sub
            End If

            If txtTransmissionFee.Text = "" Or txtTransmissionFee.Text = "0" Then
                vTmpVar = MsgBox("Transmission fee is required." & vbCrLf & vbCrLf & _
                               "Please enter the amount of transmission fee to charge the PETC for every completed transmission.", vbOKOnly + vbEmpty, "Incomplete data")

                txtTransmissionFee.Select()
                txtTransmissionFee.Focus()

                Exit Sub
            End If

            If txtStradcomFee.Text = "" Then
                vTmpVar = MsgBox("Stradcom fee is required." & vbCrLf & vbCrLf &
                               "Please enter the amount of fee being charged by Stradcom for every completed transmission.", vbOKOnly + vbEmpty, "Incomplete data")

                txtStradcomFee.Select()
                txtStradcomFee.Focus()

                Exit Sub
            End If

            If txtMaxTransPerDay.Text = "" Then
                vTmpVar = MsgBox("Maximum Transaction per Day is required." & vbCrLf & vbCrLf &
                               "Please enter the maximum transaction per day for every completed transmission.", vbOKOnly + vbEmpty, "Incomplete data")

                txtMaxTransPerDay.Select()
                txtMaxTransPerDay.Focus()

                Exit Sub
            End If

            'require account manager, technical manager, marketing agent

            Select Case LCase(cmbAccountType.Text)
                '                Case "post-paid"
                '                    If CDbl(txtMaxCredit.Text) <= 0 Then
                '                        vTmpVar = MsgBox("Maximum credit must be above zero if payment method is post-paid." & vbCrLf & vbCrLf & _
                '                                       "Please enter the correct maximum credit allowed.", vbOKOnly + vbEmpty, "Incomplete data")
                '
                '                        txtMaxCredit.Select()
                '                        txtMaxCredit.Focus()
                '
                '                        Exit Sub
                '                End If
                '
                '                Case "pre-paid"
                '                    If CDbl(txtMaxCredit.Text) > 0 Then
                '                        vTmpVar = MsgBox("Maximum credit must be below or equal to zero if payment method is pre-paid." & vbCrLf & vbCrLf & _
                '                                       "Please enter the correct maximum credit allowed.", vbOKOnly + vbEmpty, "Incomplete data")
                '
                '                        txtMaxCredit.Select()
                '                        txtMaxCredit.Focus()
                '
                '                        Exit Sub
                '                End If
            End Select

            Select Case Me.Mode
                Case "new"
                    vTmpVar = MsgBox("You are about to create a new PETC with the following info.:" & vbCrLf & vbCrLf & _
                                     "PETC Code: " & txtCode.Text & vbCrLf & _
                                     IIf(txtName.Text = "", "", "Name: " & txtName.Text & vbCrLf) & _
                                     IIf(cmbLanes.Text = "", "", "Lanes: " & cmbLanes.Text & vbCrLf) & _
                                     IIf(txtAddress.Text = "", "", "Address: " & txtAddress.Text & vbCrLf) & _
                                     IIf(txtDescription.Text = "", "", "Description: " & txtDescription.Text & vbCrLf) & _
                                     IIf(txtContact.Text = "", "", "Contact: " & txtContact.Text & vbCrLf) & _
                                     IIf(cmbStatus.Text = "", "", "Status: " & cmbStatus.Text & vbCrLf) & _
                                     IIf(cmbOwner.Text = "", "", "Owner: " & cmbOwner.Text & vbCrLf) & _
                                     IIf(cmbAccountManager.Text = "", "", "Account manager: " & cmbAccountManager.Text & vbCrLf) & _
                                     IIf(cmbTechManager.Text = "", "", "Technical manager: " & cmbTechManager.Text & vbCrLf) & _
                                     IIf(cmbMarketingAgent.Text = "", "", "Marketing agent: " & cmbOwner.Text & vbCrLf) & _
                                     IIf(txtMarketingCommission.Text = "", "", "Marketing commission: " & txtMarketingCommission.Text & vbCrLf) & _
                                     "GM: " & IIf(chkGM1.Checked = True, "1", "0") & _
                                        IIf(chkGM2.Checked = True, "1", "0") & _
                                        IIf(chkGM3.Checked = True, "1", "0") & _
                                        IIf(chkGM4.Checked = True, "1", "0") & _
                                        IIf(chkGM5.Checked = True, "1", "0") & _
                                        IIf(chkGM6.Checked = True, "1", "0") & _
                                        IIf(chkGM7.Checked = True, "1", "0") & _
                                        IIf(chkGM8.Checked = True, "1", "0") & _
                                        IIf(chkGM9.Checked = True, "1", "0") & _
                                        IIf(chkGM10.Checked = True, "1", "0") & _
                                        IIf(chkGM11.Checked = True, "1", "0") & _
                                        IIf(chkGM12.Checked = True, "1", "0") & _
                                        IIf(chkGM13.Checked = True, "1", "0") & _
                                        IIf(chkGM14.Checked = True, "1", "0") & _
                                        IIf(chkGM15.Checked = True, "1", "0") & _
                                        IIf(chkGM16.Checked = True, "1", "0") & vbCrLf & _
                                     IIf(cmbCategory.Text = "", "", "Category: " & cmbCategory.Text & vbCrLf) & _
                                     IIf(cmbBusinessTypes.Text = "", "", "Business type: " & cmbBusinessTypes.Text & vbCrLf) & _
                                     IIf(cmbRegion.Text = "", "", "Region: " & cmbRegion.Text & vbCrLf) & _
                                     IIf(cmbProvince.Text = "", "", "Province: " & cmbProvince.Text & vbCrLf) & _
                                     IIf(cmbLtoServiceArea.Text = "", "", "LTO service area: " & cmbLtoServiceArea.Text & vbCrLf) & _
                                     IIf(txtDtiAccreditationNo.Text = "", "", "DTI accreditation no.: " & txtDtiAccreditationNo.Text & vbCrLf) & _
                                     IIf(txtLtoAuthorizationNo.Text = "", "", "LTO authorization no.: " & txtLtoAuthorizationNo.Text & vbCrLf) & _
                                     IIf(cmbAccountType.Text = "", "", "Payment method: " & cmbAccountType.Text & vbCrLf) & _
                                     IIf(txtTransmissionFee.Text = "", "", "Transmission fee: " & txtTransmissionFee.Text & vbCrLf) & _
                                     IIf(txtStradcomFee.Text = "", "", "Stradcom fee: " & txtStradcomFee.Text & vbCrLf) & _
                                     IIf(txtMaxCredit.Text = "", "", "Maximum credit allowed: " & txtMaxCredit.Text & vbCrLf) & _
                                     IIf(txtPetcDateStarted.Text = "", "", "PETC date started: " & txtPetcDateStarted.Text & vbCrLf) & _
                                     IIf(txtPetcDateAccredited.Text = "", "", "PETC accreditation expiration: " & txtPetcDateAccredited.Text & vbCrLf) & _
                                     IIf(txtPetcDateAuthorized.Text = "", "", "PETC authorization expiration: " & txtPetcDateAuthorized.Text & vbCrLf) & _
                                     IIf(txtItDateStarted.Text = "", "", "Date with IT started: " & txtItDateStarted.Text & vbCrLf) & _
                                     IIf(txtItDateAccredited.Text = "", "", "Date with IT accredited: " & txtItDateAccredited.Text & vbCrLf) & _
                                     IIf(txtItDateRenewal.Text = "", "", "Renewal date with IT: " & txtItDateRenewal.Text & vbCrLf) & vbCrLf & _
                                     "LTMS Ready?: " & IIf(chkIsLTMSReady.Checked = True, "1", "0") & _
                                     IIf(txtMaxTransPerDay.Text = "", "", "Maximum Transaction per Day: " & txtMaxTransPerDay.Text & vbCrLf) & vbCrLf & _
                                     "Please make sure the above information are true and correct." & vbCrLf & vbCrLf & _
                                     "Are you sure you want to create the new PETC?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "User confirmation")

                Case "edit"
                    If ChangesMade(vTmpStr, True) = False Then
                        MsgBox("Nothing to save. No changes haved been made.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Operation cancelled")

                        Exit Sub
                    Else
                        vTmpVar = MsgBox("You are about to update PETC with the following changes:" & vbCrLf & vbCrLf & _
                                         vTmpStr & vbCrLf & _
                                         "Please make sure the above information are true and correct." & vbCrLf & vbCrLf & _
                                         "Are you sure you want to update the PETC record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "User confirmation")
                    End If
            End Select

            If vTmpVar = MsgBoxResult.No Then Exit Sub

            Select Case LCase(cmbStatus.Text)
                Case "active"
                    vTmpStatus = "1"

                Case "inactive"
                    vTmpStatus = "0"

                Case "suspended"
                    vTmpStatus = "2"

                Case "expired"
                    vTmpStatus = "3"

                Case Else
                    MsgBox("Invalid PETC status. Please select in the list the current status of PETC.", _
                           MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Validation failed")

                    Exit Sub
            End Select

            Select Case LCase(cmbAccountType.Text)
                Case "post-paid"
                    vTmpAccountType = "1"

                Case "pre-paid"
                    vTmpAccountType = "2"

                Case Else
                    MsgBox("Invalid PETC payment method. Please select in the list the the payment method to use.", _
                           MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Validation failed")

                    Exit Sub
            End Select

            vTmpGM = IIf(chkGM1.Checked = True, "1", "0") &
                IIf(chkGM2.Checked = True, "1", "0") &
                IIf(chkGM3.Checked = True, "1", "0") &
                IIf(chkGM4.Checked = True, "1", "0") &
                IIf(chkGM5.Checked = True, "1", "0") &
                IIf(chkGM6.Checked = True, "1", "0") &
                IIf(chkGM7.Checked = True, "1", "0") &
                IIf(chkGM8.Checked = True, "1", "0") &
                IIf(chkGM9.Checked = True, "1", "0") &
                IIf(chkGM10.Checked = True, "1", "0") &
                IIf(chkGM11.Checked = True, "1", "0") &
                IIf(chkGM12.Checked = True, "1", "0") &
                IIf(chkGM13.Checked = True, "1", "0") &
                IIf(chkGM14.Checked = True, "1", "0") &
                IIf(chkGM15.Checked = True, "1", "0") &
                IIf(chkGM16.Checked = True, "1", "0")

            lblStatusPrompt.Text = "Opening database..."
            lblStatusPrompt.Refresh()

            'open db connection
            vMyPgCon.ConnectionString = pConnectVox
            vMyPgCon.Open()

            Select Case Me.Mode
                Case "new"
                    lblStatusPrompt.Text = "Validating in database..."
                    lblStatusPrompt.Refresh()

                    'check if already exist
                    vQuery = "SELECT petc_code FROM tb_petcs WHERE petc_code = '" & modModule.CorrectSqlString(txtCode.Text) & "'"

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
                        vTmpVar = MsgBox("PETC with code " & modModule.CorrectSqlString(txtCode.Text) & " already exist in record." & vbCrLf & vbCrLf & _
                                        "Please assign another PETC Code or double check records.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Validation failed")
                        Exit Sub
                    Else
                        'close and dispose to avoid memory leak
                        vMyPgRd.Close()
                        vMyPgCmd.Dispose()

                        'check if accounting data already exist
                        vQuery = "SELECT petc_code FROM tb_petc_balance_details WHERE petc_code = '" & modModule.CorrectSqlString(txtCode.Text) & "'"

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
                            vTmpVar = MsgBox("PETC with code " & modModule.CorrectSqlString(txtCode.Text) & " already exist in accounting record." & vbCrLf & vbCrLf & _
                                            "Please assign another PETC Code or double check records.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Validation failed")
                            Exit Sub
                        End If

                        'close and dispose to avoid memory leak
                        vMyPgRd.Close()
                        vMyPgCmd.Dispose()
                    End If

                Case "edit"
                    lblStatusPrompt.Text = "Validating in database..."
                    lblStatusPrompt.Refresh()

                    'check if already exist
                    vQuery = "SELECT petc_code FROM tb_petcs WHERE petc_code = '" & modModule.CorrectSqlString(txtCode.Text) & "'"

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
                        vTmpVar = MsgBox("PETC with code " & modModule.CorrectSqlString(txtCode.Text) & " no longer exist in record." & vbCrLf & vbCrLf & _
                                        "Please make sure the record was not deleted.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Validation failed")
                        Exit Sub
                    Else
                        'close and dispose to avoid memory leak
                        vMyPgRd.Close()
                        vMyPgCmd.Dispose()

                        'check if accounting data already exist
                        vQuery = "SELECT petc_code FROM tb_petc_balance_details WHERE petc_code = '" & modModule.CorrectSqlString(txtCode.Text) & "'"

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
                            vTmpVar = MsgBox("PETC with code " & modModule.CorrectSqlString(txtCode.Text) & " no longer exist in accounting record." & vbCrLf & vbCrLf & _
                                            "Please make sure the record was not deleted.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Validation failed")
                            Exit Sub
                        End If

                        'close and dispose to avoid memory leak
                        vMyPgRd.Close()
                        vMyPgCmd.Dispose()
                    End If
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
                    'insert in tb_petc table
                    vQuery = "INSERT INTO tb_petcs (petc_code, petc_lanes, petc_category, petc_name, petc_address, contact_no, business_type, description, is_active, " &
                        "lto_service_area, dti_accreditation_no, lto_authorization_no, " &
                        "date_it_started, date_it_accredited, date_it_renewal, " &
                        "date_petc_started, date_petc_accredited, date_petc_authorized, gm, region, province, " &
                        "account_id, account_manager, tech_manager, marketing_agent, marketing_commission, is_ltms_ready, max_trans_limit_per_day) " &
                        "VALUES ('" & modModule.CorrectSqlString(txtCode.Text) & "', '" & modModule.CorrectSqlString(cmbLanes.Text) & "', " &
                            "'" & modModule.CorrectSqlString(cmbCategory.Text) & "', '" & modModule.CorrectSqlString(txtName.Text) & "', " &
                            "'" & modModule.CorrectSqlString(txtAddress.Text) & "', '" & modModule.CorrectSqlString(txtContact.Text) & "', " &
                            "'" & modModule.CorrectSqlString(cmbBusinessTypes.Text) & "', '" & modModule.CorrectSqlString(txtDescription.Text) & "', " &
                             modModule.CorrectSqlString(vTmpStatus) & ", " &
                            "'" & modModule.CorrectSqlString(cmbLtoServiceArea.Text) & "', '" & modModule.CorrectSqlString(txtDtiAccreditationNo.Text) & "', " &
                            "'" & modModule.CorrectSqlString(txtLtoAuthorizationNo.Text) & "', " &
                             IIf(txtItDateStarted.Text = "", "NULL, ", "'" & txtItDateStarted.Text & "', ") &
                             IIf(txtItDateAccredited.Text = "", "NULL, ", "'" & txtItDateAccredited.Text & "', ") &
                             IIf(txtItDateRenewal.Text = "", "NULL, ", "'" & txtItDateRenewal.Text & "', ") &
                             IIf(txtPetcDateStarted.Text = "", "NULL, ", "'" & txtPetcDateStarted.Text & "', ") &
                             IIf(txtPetcDateAccredited.Text = "", "NULL, ", "'" & txtPetcDateAccredited.Text & "', ") &
                             IIf(txtPetcDateAuthorized.Text = "", "NULL", "'" & txtPetcDateAuthorized.Text & "'") & ", " &
                             "'" & modModule.CorrectSqlString(vTmpGM) & "', '" & modModule.CorrectSqlString(cmbRegion.Text) & "', " &
                             "'" & modModule.CorrectSqlString(cmbProvince.Text) & "', " &
                             "'" & modModule.CorrectSqlString(Microsoft.VisualBasic.Right(cmbOwner.Text, 12)) & "', " &
                             "'" & modModule.CorrectSqlString(Microsoft.VisualBasic.Right(cmbAccountManager.Text, 12)) & "', " &
                             "'" & modModule.CorrectSqlString(Microsoft.VisualBasic.Right(cmbTechManager.Text, 12)) & "', " &
                             "'" & modModule.CorrectSqlString(Microsoft.VisualBasic.Right(cmbMarketingAgent.Text, 12)) & "', " &
                             modModule.CorrectSqlString(Trim(Str(CDbl(txtMarketingCommission.Text)))) & ", " &
                             IIf(chkIsLTMSReady.Checked = True, "1", "0") & ", " & modModule.CorrectSqlString(txtMaxTransPerDay.Text) & ")"

                Case "edit"
                    'update in tb_petc table
                    vQuery = "UPDATE tb_petcs SET petc_lanes = '" & modModule.CorrectSqlString(cmbLanes.Text) & "', " &
                        "petc_category = '" & modModule.CorrectSqlString(cmbCategory.Text) & "', " &
                        "petc_name = '" & modModule.CorrectSqlString(txtName.Text) & "', " &
                        "petc_address = '" & modModule.CorrectSqlString(txtAddress.Text) & "', " &
                        "contact_no = '" & modModule.CorrectSqlString(txtContact.Text) & "', " &
                        "business_type = '" & modModule.CorrectSqlString(cmbBusinessTypes.Text) & "', " &
                        "description = '" & modModule.CorrectSqlString(txtDescription.Text) & "', " &
                        "is_active = " & vTmpStatus & ", " &
                        "account_id = '" & modModule.CorrectSqlString(Microsoft.VisualBasic.Right(cmbOwner.Text, 12)) & "', " &
                        "account_manager = '" & modModule.CorrectSqlString(Microsoft.VisualBasic.Right(cmbAccountManager.Text, 12)) & "', " &
                        "tech_manager = '" & modModule.CorrectSqlString(Microsoft.VisualBasic.Right(cmbTechManager.Text, 12)) & "', " &
                        "marketing_agent = '" & modModule.CorrectSqlString(Microsoft.VisualBasic.Right(cmbMarketingAgent.Text, 12)) & "', " &
                        "marketing_commission = " & modModule.CorrectSqlString(Trim(Str(CDbl(txtMarketingCommission.Text)))) & ", " &
                        "lto_service_area = '" & modModule.CorrectSqlString(cmbLtoServiceArea.Text) & "', " &
                        "dti_accreditation_no = '" & modModule.CorrectSqlString(txtDtiAccreditationNo.Text) & "', " &
                        "lto_authorization_no = '" & modModule.CorrectSqlString(txtLtoAuthorizationNo.Text) & "', " &
                        "date_petc_started = " & IIf(txtPetcDateStarted.Text = "", "NULL, ", "'" & txtPetcDateStarted.Text & "', ") &
                        "date_petc_accredited = " & IIf(txtPetcDateAccredited.Text = "", "NULL, ", "'" & txtPetcDateAccredited.Text & "', ") &
                        "date_petc_authorized = " & IIf(txtPetcDateAuthorized.Text = "", "NULL, ", "'" & txtPetcDateAuthorized.Text & "', ") &
                        "date_it_started = " & IIf(txtItDateStarted.Text = "", "NULL, ", "'" & txtItDateStarted.Text & "', ") &
                        "date_it_accredited = " & IIf(txtItDateAccredited.Text = "", "NULL, ", "'" & txtItDateAccredited.Text & "', ") &
                        "date_it_renewal = " & IIf(txtItDateRenewal.Text = "", "NULL", "'" & txtItDateRenewal.Text & "'") & ", " &
                        "gm = '" & modModule.CorrectSqlString(vTmpGM) & "', " &
                        "region = '" & modModule.CorrectSqlString(cmbRegion.Text) & "', " &
                        "province = '" & modModule.CorrectSqlString(cmbProvince.Text) & "', " &
                        "is_ltms_ready = " & IIf(chkIsLTMSReady.Checked = True, "1", "0") & ", " &
                        "max_trans_limit_per_day = " & modModule.CorrectSqlString(txtMaxTransPerDay.Text) & " " &
                        "WHERE petc_code = '" & modModule.CorrectSqlString(txtCode.Text) & "'"
            End Select

            'create query
            vMyPgCmd = New NpgsqlCommand(vQuery, vMyPgCon)

            'execute query
            vMyPgCmd.ExecuteNonQuery()

            'close and dispose to avoid memory leak
            vMyPgCmd.Dispose()

            Select Case LCase(Me.Mode)
                Case "new"
                    'insert in tb_petc_balance table
                    vQuery = "INSERT INTO tb_petc_balance (petc_code, transmission_fee, account_type, balance, remarks, stradcom_fee, max_credit) " & _
                        "VALUES ('" & modModule.CorrectSqlString(txtCode.Text) & "', " & Trim(Str(CDbl(txtTransmissionFee.Text))) & ", " & _
                            "'" & modModule.CorrectSqlString(vTmpAccountType) & "', 0, '', " & Trim(Str(CDbl(txtStradcomFee.Text))) & ", " & _
                            Trim(Str(CDbl(txtMaxCredit.Text))) & ")"

                Case "edit"
                    'update in tb_petc table
                    vQuery = "UPDATE tb_petc_balance SET transmission_fee = " & Trim(Str(CDbl(txtTransmissionFee.Text))) & ", " & _
                            "account_type = '" & modModule.CorrectSqlString(vTmpAccountType) & "', " & _
                            "stradcom_fee = " & Trim(Str(CDbl(txtStradcomFee.Text))) & ", " & _
                            "max_credit = " & Trim(Str(CDbl(txtMaxCredit.Text))) & " " & _
                            "WHERE petc_code = '" & modModule.CorrectSqlString(txtCode.Text) & "'"

            End Select

            'create query
            vMyPgCmd = New NpgsqlCommand(vQuery, vMyPgCon)

            'execute query
            vMyPgCmd.ExecuteNonQuery()

            'close and dispose to avoid memory leak
            vMyPgCmd.Dispose()

            If LCase(Me.Mode) = "new" Then
                'insert int tb_petc_balance_details
                vQuery = "INSERT INTO tb_petc_balance_details (trans_date, petc_code, ledger_code, ledger_description, debit, credit, balance, remarks) " & _
                    "VALUES (CURRENT_timestamp AT TIME ZONE 'Hongkong', '" & modModule.CorrectSqlString(txtCode.Text) & _
                    "', '', 'Beginning balance', 0, 0, 0, 'First record')"

                'create query
                vMyPgCmd = New NpgsqlCommand(vQuery, vMyPgCon)

                'execute query
                vMyPgCmd.ExecuteNonQuery()

                'close and dispose to avoid memory leak
                vMyPgCmd.Dispose()
            End If

            'create log
            Select Case LCase(Me.Mode)
                Case "new"
                    vTmpStr = ""

                Case "edit"
                    'changes made
                    vFound = ChangesMade(vTmpStr, False)
            End Select

            vQuery = modModule.CreateLogCn(vMyPgCon, Me.Name, LCase(Me.Mode) & " petc " & txtCode.Text, vTmpStr)

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

            MsgBox("Successfull in " & IIf(LCase(Me.Mode) = "new", " creating new ", " updating ") & " PETC " & txtCode.Text & ".", _
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
        If Trim(Me.PetcCode) = "" Then Exit Sub

        Try
            DisableButtons()

            InitializeValues()

            vQuery = "SELECT a.petc_code, a.petc_lanes, a.petc_category, a.petc_name, a.petc_address, a.contact_no, a.business_type, a.lto_service_area," & _
                "a.dti_accreditation_no, a.lto_authorization_no, a.date_it_started, a.date_it_accredited, a.date_it_renewal, a.date_petc_started, " & _
                "a.date_petc_accredited, a.date_petc_authorized, a.is_active, a.description, b.account_type, b.balance, b.transmission_fee, b.stradcom_fee, " & _
                "b.max_credit, a.gm, a.region, a.province, a.account_id, c.account_name, " & _
                "a.account_manager, d.account_name AS account_manager_name, " & _
                "a.tech_manager, e.account_name AS tech_manager_name, " & _
                "a.marketing_agent, f.account_name AS marketing_agent_name, a.marketing_commission, a.is_ltms_ready, a.max_trans_limit_per_day  " & _
                "FROM tb_petcs AS a LEFT OUTER JOIN tb_petc_balance AS b ON a.petc_code = b.petc_code " & _
                "LEFT OUTER JOIN tb_client_accounts AS c ON a.account_id = c.account_id " & _
                "LEFT OUTER JOIN tb_managing_accounts AS d ON a.account_manager = d.account_id " & _
                "LEFT OUTER JOIN tb_managing_accounts AS e ON a.tech_manager = e.account_id " & _
                "LEFT OUTER JOIN tb_managing_accounts AS f ON a.marketing_agent = f.account_id " & _
                "WHERE a.petc_code = '" & modModule.CorrectSqlString(Me.PetcCode) & "'"

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
                vTmpVar = MsgBox("PETC record no longer exist." & vbCrLf & vbCrLf & _
                                "Please make sure the record was not deleted.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Unexpected error")

                Me.Close()

                Exit Sub
            Else
                'get result

                txtCode.Text = Me.PetcCode

                If IsDBNull(vMyPgRd("petc_name")) = False Then
                    txtName.Text = vMyPgRd("petc_name")
                End If

                If IsDBNull(vMyPgRd("petc_address")) = False Then
                    txtAddress.Text = vMyPgRd("petc_address")
                End If

                If IsDBNull(vMyPgRd("description")) = False Then
                    txtDescription.Text = vMyPgRd("description")
                End If

                If IsDBNull(vMyPgRd("contact_no")) = False Then
                    txtContact.Text = vMyPgRd("contact_no")
                End If

                If IsDBNull(vMyPgRd("is_active")) = False Then
                    Select Case vMyPgRd("is_active")
                        Case 0
                            cmbStatus.Text = "Inactive"

                        Case 1
                            cmbStatus.Text = "Active"

                        Case 2
                            cmbStatus.Text = "Suspended"

                        Case 3
                            cmbStatus.Text = "Expired"

                        Case Else
                            cmbStatus.Text = "Unknown"
                    End Select
                End If

                modModule.LoadTableFieldInComboBox(cmbOwner, "account_name || ' - ' || account_id", "tb_client_accounts", _
                                       "", "account_name || ' - ' || account_id", lblStatusPrompt, True)

                If IsDBNull(vMyPgRd("account_id")) = False Then
                    If IsDBNull(vMyPgRd("account_name")) = False Then
                        cmbOwner.Text = vMyPgRd("account_name") & " - " & vMyPgRd("account_id")
                    End If
                End If

                modModule.LoadTableFieldInComboBox(cmbAccountManager, "account_name || ' - ' || account_id", "tb_managing_accounts", _
                                       "account_type = 'account manager' AND is_active = 1", "account_name || ' - ' || account_id", lblStatusPrompt, True)

                If IsDBNull(vMyPgRd("account_manager")) = False Then
                    If IsDBNull(vMyPgRd("account_manager_name")) = False Then
                        cmbAccountManager.Text = vMyPgRd("account_manager_name") & " - " & vMyPgRd("account_manager")
                    End If
                End If

                modModule.LoadTableFieldInComboBox(cmbTechManager, "account_name || ' - ' || account_id", "tb_managing_accounts", _
                                                       "account_type = 'technical manager' AND is_active = 1", "account_name || ' - ' || account_id", lblStatusPrompt, True)

                If IsDBNull(vMyPgRd("tech_manager")) = False Then
                    If IsDBNull(vMyPgRd("tech_manager_name")) = False Then
                        cmbTechManager.Text = vMyPgRd("tech_manager_name") & " - " & vMyPgRd("tech_manager")
                    End If
                End If

                modModule.LoadTableFieldInComboBox(cmbMarketingAgent, "account_name || ' - ' || account_id", "tb_managing_accounts", _
                                                       "account_type = 'marketing agent' AND is_active = 1", "account_name || ' - ' || account_id", lblStatusPrompt, True)

                If IsDBNull(vMyPgRd("marketing_agent")) = False Then
                    If IsDBNull(vMyPgRd("marketing_agent_name")) = False Then
                        cmbMarketingAgent.Text = vMyPgRd("marketing_agent_name") & " - " & vMyPgRd("marketing_agent")
                    End If
                End If

                If IsDBNull(vMyPgRd("marketing_commission")) = False Then
                    txtMarketingCommission.Text = Format(CDbl(vMyPgRd("marketing_commission")), "###,###,###,##0.00")
                End If

                If IsDBNull(vMyPgRd("petc_lanes")) = False Then
                    cmbLanes.Text = vMyPgRd("petc_lanes")
                End If

                If IsDBNull(vMyPgRd("petc_category")) = False Then
                    cmbCategory.Text = vMyPgRd("petc_category")
                End If

                If IsDBNull(vMyPgRd("business_type")) = False Then
                    cmbBusinessTypes.Text = vMyPgRd("business_type")
                End If

                modModule.LoadTableFieldInComboBox(cmbRegion, "region", "tb_region_province_city", _
                                       "", "region ASC", lblStatusPrompt, True)

                If IsDBNull(vMyPgRd("region")) = False Then
                    cmbRegion.Text = vMyPgRd("region")
                End If

                If IsDBNull(vMyPgRd("province")) = False Then
                    cmbProvince.Text = vMyPgRd("province")
                End If

                If IsDBNull(vMyPgRd("lto_service_area")) = False Then
                    cmbLtoServiceArea.Text = vMyPgRd("lto_service_area")
                End If

                cmbRegion_SelectedIndexChanged(sender, e)
                cmbProvince_SelectedIndexChanged(sender, e)

                If IsDBNull(vMyPgRd("dti_accreditation_no")) = False Then
                    txtDtiAccreditationNo.Text = vMyPgRd("dti_accreditation_no")
                End If

                If IsDBNull(vMyPgRd("lto_authorization_no")) = False Then
                    txtLtoAuthorizationNo.Text = vMyPgRd("lto_authorization_no")
                End If

                If IsDBNull(vMyPgRd("account_type")) = False Then
                    Select Case vMyPgRd("account_type")
                        Case 1
                            cmbAccountType.Text = "Post-paid"

                        Case 2
                            cmbAccountType.Text = "Pre-paid"

                        Case Else
                            cmbAccountType.Text = "Unknown"
                    End Select
                End If

                If IsDBNull(vMyPgRd("transmission_fee")) = False Then
                    txtTransmissionFee.Text = Format(vMyPgRd("transmission_fee"), "###,###,###,##0.00")
                End If

                If IsDBNull(vMyPgRd("stradcom_fee")) = False Then
                    txtStradcomFee.Text = Format(vMyPgRd("stradcom_fee"), "###,###,###,##0.00")
                End If

                If IsDBNull(vMyPgRd("max_credit")) = False Then
                    txtMaxCredit.Text = Format(vMyPgRd("max_credit"), "###,###,###,##0.00")
                End If

                If IsDBNull(vMyPgRd("balance")) = False Then
                    txtBalance.Text = Format(vMyPgRd("balance"), "###,###,###,##0.00")
                End If

                If IsDBNull(vMyPgRd("date_it_started")) = False Then
                    txtItDateStarted.Text = Format(CDate(vMyPgRd("date_it_started").ToString), "yyyy-MM-dd")
                End If

                If IsDBNull(vMyPgRd("date_it_accredited")) = False Then
                    txtItDateAccredited.Text = Format(CDate(vMyPgRd("date_it_accredited").ToString), "yyyy-MM-dd")
                End If

                If IsDBNull(vMyPgRd("date_it_renewal")) = False Then
                    txtItDateRenewal.Text = Format(CDate(vMyPgRd("date_it_renewal").ToString), "yyyy-MM-dd")
                End If

                If IsDBNull(vMyPgRd("date_petc_started")) = False Then
                    txtPetcDateStarted.Text = Format(CDate(vMyPgRd("date_petc_started").ToString), "yyyy-MM-dd")
                End If

                If IsDBNull(vMyPgRd("date_petc_accredited")) = False Then
                    txtPetcDateAccredited.Text = Format(CDate(vMyPgRd("date_petc_accredited").ToString), "yyyy-MM-dd")
                End If

                If IsDBNull(vMyPgRd("date_petc_authorized")) = False Then
                    txtPetcDateAuthorized.Text = Format(CDate(vMyPgRd("date_petc_authorized").ToString), "yyyy-MM-dd")
                End If

                If IsDBNull(vMyPgRd("is_ltms_ready")) = False Then
                    If vMyPgRd("is_ltms_ready") = 1 Then
                        chkIsLTMSReady.Checked = True
                    Else
                        chkIsLTMSReady.Checked = False
                    End If
                End If

                If IsDBNull(vMyPgRd("max_trans_limit_per_day")) = False Then
                    txtMaxTransPerDay.Text = vMyPgRd("max_trans_limit_per_day")
                End If

                If IsDBNull(vMyPgRd("gm")) = True Then
                    chkGM1.Checked = False
                    chkGM2.Checked = False
                    chkGM3.Checked = False
                    chkGM4.Checked = False
                    chkGM5.Checked = False
                    chkGM6.Checked = False
                    chkGM7.Checked = False
                    chkGM8.Checked = False
                    chkGM9.Checked = False
                    chkGM10.Checked = False
                    chkGM11.Checked = False
                    chkGM12.Checked = False
                    chkGM13.Checked = False
                    chkGM14.Checked = False
                    chkGM15.Checked = False
                    chkGM16.Checked = False
                Else
                    Select Case Mid(vMyPgRd("gm"), 1, 1)
                        Case "1"
                            chkGM1.Checked = True

                        Case Else
                            chkGM1.Checked = False
                    End Select

                    Select Case Mid(vMyPgRd("gm"), 2, 1)
                        Case "1"
                            chkGM2.Checked = True

                        Case Else
                            chkGM2.Checked = False
                    End Select

                    Select Case Mid(vMyPgRd("gm"), 3, 1)
                        Case "1"
                            chkGM3.Checked = True

                        Case Else
                            chkGM3.Checked = False
                    End Select

                    Select Case Mid(vMyPgRd("gm"), 4, 1)
                        Case "1"
                            chkGM4.Checked = True

                        Case Else
                            chkGM4.Checked = False
                    End Select

                    Select Case Mid(vMyPgRd("gm"), 5, 1)
                        Case "1"
                            chkGM5.Checked = True

                        Case Else
                            chkGM5.Checked = False
                    End Select

                    Select Case Mid(vMyPgRd("gm"), 6, 1)
                        Case "1"
                            chkGM6.Checked = True

                        Case Else
                            chkGM6.Checked = False
                    End Select

                    Select Case Mid(vMyPgRd("gm"), 7, 1)
                        Case "1"
                            chkGM7.Checked = True

                        Case Else
                            chkGM7.Checked = False
                    End Select

                    Select Case Mid(vMyPgRd("gm"), 8, 1)
                        Case "1"
                            chkGM8.Checked = True

                        Case Else
                            chkGM8.Checked = False
                    End Select

                    Select Case Mid(vMyPgRd("gm"), 9, 1)
                        Case "1"
                            chkGM9.Checked = True

                        Case Else
                            chkGM9.Checked = False
                    End Select

                    Select Case Mid(vMyPgRd("gm"), 10, 1)
                        Case "1"
                            chkGM10.Checked = True

                        Case Else
                            chkGM10.Checked = False
                    End Select

                    Select Case Mid(vMyPgRd("gm"), 11, 1)
                        Case "1"
                            chkGM11.Checked = True

                        Case Else
                            chkGM11.Checked = False
                    End Select

                    Select Case Mid(vMyPgRd("gm"), 12, 1)
                        Case "1"
                            chkGM12.Checked = True

                        Case Else
                            chkGM12.Checked = False
                    End Select

                    Select Case Mid(vMyPgRd("gm"), 13, 1)
                        Case "1"
                            chkGM13.Checked = True

                        Case Else
                            chkGM13.Checked = False
                    End Select

                    Select Case Mid(vMyPgRd("gm"), 14, 1)
                        Case "1"
                            chkGM14.Checked = True

                        Case Else
                            chkGM14.Checked = False
                    End Select

                    Select Case Mid(vMyPgRd("gm"), 15, 1)
                        Case "1"
                            chkGM15.Checked = True

                        Case Else
                            chkGM15.Checked = False
                    End Select

                    Select Case Mid(vMyPgRd("gm"), 16, 1)
                        Case "1"
                            chkGM16.Checked = True

                        Case Else
                            chkGM16.Checked = False
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

    Private Sub txtCode_GotFocus(sender As Object, e As EventArgs) Handles txtCode.GotFocus
        txtCode.SelectAll()
    End Sub

    Private Sub txtCode_LostFocus(sender As Object, e As EventArgs) Handles txtCode.LostFocus
        txtCode.Text = UCase(modModule.StripInvalidStringChars(txtCode.Text))
    End Sub

    Private Sub txtCode_TextChanged(sender As Object, e As EventArgs) Handles txtCode.TextChanged

    End Sub

    Private Sub cmbLanes_GotFocus(sender As Object, e As EventArgs) Handles cmbLanes.GotFocus
        cmbLanes.SelectAll()
    End Sub

    Private Sub cmbLanes_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbLanes.KeyPress
        e.Handled = True
    End Sub

    Private Sub cmbLanes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbLanes.SelectedIndexChanged

    End Sub

    Private Sub cmbCategory_GotFocus(sender As Object, e As EventArgs) Handles cmbCategory.GotFocus
        cmbCategory.SelectAll()
    End Sub

    Private Sub cmbCategory_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbCategory.KeyPress
        e.Handled = True
    End Sub

    Private Sub cmbCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCategory.SelectedIndexChanged

    End Sub

    Private Sub txtName_GotFocus(sender As Object, e As EventArgs) Handles txtName.GotFocus
        txtName.SelectAll()
    End Sub

    Private Sub txtName_LostFocus(sender As Object, e As EventArgs) Handles txtName.LostFocus
        txtName.Text = UCase(modModule.StripInvalidStringChars(txtName.Text))
    End Sub

    Private Sub txtName_TextChanged(sender As Object, e As EventArgs) Handles txtName.TextChanged

    End Sub

    Private Sub cmbBusinessTypes_GotFocus(sender As Object, e As EventArgs) Handles cmbBusinessTypes.GotFocus
        cmbBusinessTypes.SelectAll()
    End Sub

    Private Sub cmbBusinessTypes_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbBusinessTypes.KeyPress
        e.Handled = True
    End Sub

    Private Sub cmbBusinessTypes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbBusinessTypes.SelectedIndexChanged

    End Sub

    Private Sub txtAddress_GotFocus(sender As Object, e As EventArgs) Handles txtAddress.GotFocus
        txtAddress.SelectAll()
    End Sub

    Private Sub txtAddress_LostFocus(sender As Object, e As EventArgs) Handles txtAddress.LostFocus
        txtAddress.Text = UCase(modModule.StripInvalidStringChars(txtAddress.Text))
    End Sub

    Private Sub txtAddress_TextChanged(sender As Object, e As EventArgs) Handles txtAddress.TextChanged

    End Sub

    Private Sub txtDescription_GotFocus(sender As Object, e As EventArgs) Handles txtDescription.GotFocus
        txtDescription.SelectAll()
    End Sub

    Private Sub txtDescription_LostFocus(sender As Object, e As EventArgs) Handles txtDescription.LostFocus
        txtDescription.Text = UCase(modModule.StripInvalidStringChars(txtDescription.Text))
    End Sub

    Private Sub txtDescription_TextChanged(sender As Object, e As EventArgs) Handles txtDescription.TextChanged

    End Sub

    Private Sub txtContact_GotFocus(sender As Object, e As EventArgs) Handles txtContact.GotFocus
        txtContact.SelectAll()
    End Sub

    Private Sub txtContact_LostFocus(sender As Object, e As EventArgs) Handles txtContact.LostFocus
        txtContact.Text = UCase(modModule.StripInvalidStringChars(txtContact.Text))
    End Sub

    Private Sub txtContact_TextChanged(sender As Object, e As EventArgs) Handles txtContact.TextChanged

    End Sub

    Private Sub cmbStatus_GotFocus(sender As Object, e As EventArgs) Handles cmbStatus.GotFocus
        cmbStatus.SelectAll()
    End Sub

    Private Sub cmbStatus_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbStatus.KeyPress
        e.Handled = True
    End Sub

    Private Sub cmbStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbStatus.SelectedIndexChanged

    End Sub

    Private Sub txtDtiAccreditationNo_GotFocus(sender As Object, e As EventArgs) Handles txtDtiAccreditationNo.GotFocus
        txtDtiAccreditationNo.SelectAll()
    End Sub

    Private Sub txtDtiAccreditationNo_LostFocus(sender As Object, e As EventArgs) Handles txtDtiAccreditationNo.LostFocus
        txtDtiAccreditationNo.Text = UCase(modModule.StripInvalidStringChars(txtDtiAccreditationNo.Text))
    End Sub

    Private Sub txtDtiAccreditationNo_TextChanged(sender As Object, e As EventArgs) Handles txtDtiAccreditationNo.TextChanged

    End Sub

    Private Sub txtLtoAuthorizationNo_GotFocus(sender As Object, e As EventArgs) Handles txtLtoAuthorizationNo.GotFocus
        txtLtoAuthorizationNo.SelectAll()
    End Sub

    Private Sub txtLtoAuthorizationNo_LostFocus(sender As Object, e As EventArgs) Handles txtLtoAuthorizationNo.LostFocus
        txtLtoAuthorizationNo.Text = UCase(modModule.StripInvalidStringChars(txtLtoAuthorizationNo.Text))
    End Sub

    Private Sub txtLtoAuthorizationNo_TextChanged(sender As Object, e As EventArgs) Handles txtLtoAuthorizationNo.TextChanged

    End Sub

    Private Sub cmbAccountType_GotFocus(sender As Object, e As EventArgs) Handles cmbAccountType.GotFocus
        cmbAccountType.SelectAll()
    End Sub

    Private Sub cmbAccountType_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbAccountType.KeyPress
        e.Handled = True
    End Sub

    Private Sub cmbAccountType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbAccountType.SelectedIndexChanged

    End Sub

    Private Sub txtTransmissionFee_GotFocus(sender As Object, e As EventArgs) Handles txtTransmissionFee.GotFocus
        txtTransmissionFee.SelectAll()
    End Sub

    Private Sub txtTransmissionFee_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTransmissionFee.KeyPress
        Select Case e.KeyChar
            Case "0" To "9"
            Case ","
            Case "."
            Case Else
                e.Handled = True
        End Select
    End Sub

    Private Sub txtTransmissionFee_LostFocus(sender As Object, e As EventArgs) Handles txtTransmissionFee.LostFocus
        If IsNumeric(txtTransmissionFee.Text) = True Then
            txtTransmissionFee.Text = Format(CDbl(txtTransmissionFee.Text), "###,###,###,##0.00")
        Else
            txtTransmissionFee.Text = "0.00"
        End If
    End Sub

    Private Sub txtTransmissionFee_TextChanged(sender As Object, e As EventArgs) Handles txtTransmissionFee.TextChanged

    End Sub

    Private Sub txtStradcomFee_GotFocus(sender As Object, e As EventArgs) Handles txtStradcomFee.GotFocus
        txtStradcomFee.SelectAll()
    End Sub

    Private Sub txtStradcomFee_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtStradcomFee.KeyPress
        Select Case e.KeyChar
            Case "0" To "9"
            Case ","
            Case "."
            Case Else
                e.Handled = True
        End Select
    End Sub

    Private Sub txtStradcomFee_LostFocus(sender As Object, e As EventArgs) Handles txtStradcomFee.LostFocus
        If IsNumeric(txtStradcomFee.Text) = True Then
            txtStradcomFee.Text = Format(CDbl(txtStradcomFee.Text), "###,###,###,##0.00")
        Else
            txtStradcomFee.Text = "0.00"
        End If
    End Sub

    Private Sub txtStradcomFee_TextChanged(sender As Object, e As EventArgs) Handles txtStradcomFee.TextChanged

    End Sub

    Private Sub txtBalance_TextChanged(sender As Object, e As EventArgs) Handles txtBalance.TextChanged

    End Sub

    Private Sub txtPetcDateStarted_GotFocus(sender As Object, e As EventArgs) Handles txtPetcDateStarted.GotFocus
        txtPetcDateStarted.SelectAll()
    End Sub

    Private Sub txtPetcDateStarted_LostFocus(sender As Object, e As EventArgs) Handles txtPetcDateStarted.LostFocus
        If IsDate(txtPetcDateStarted.Text) = True Then
            txtPetcDateStarted.Text = Format(CDate(txtPetcDateStarted.Text), "yyyy-MM-dd")
        Else
            txtPetcDateStarted.Text = ""
        End If
    End Sub

    Private Sub txtPetcDateStarted_TextChanged(sender As Object, e As EventArgs) Handles txtPetcDateStarted.TextChanged

    End Sub

    Private Sub txtPetcDateAccredited_GotFocus(sender As Object, e As EventArgs) Handles txtPetcDateAccredited.GotFocus
        txtPetcDateAccredited.SelectAll()
    End Sub

    Private Sub txtPetcDateAccredited_LostFocus(sender As Object, e As EventArgs) Handles txtPetcDateAccredited.LostFocus
        If IsDate(txtPetcDateAccredited.Text) = True Then
            txtPetcDateAccredited.Text = Format(CDate(txtPetcDateAccredited.Text), "yyyy-MM-dd")
        Else
            txtPetcDateAccredited.Text = ""
        End If
    End Sub

    Private Sub txtPetcDateAccredited_TextChanged(sender As Object, e As EventArgs) Handles txtPetcDateAccredited.TextChanged

    End Sub

    Private Sub txtPetcDateAuthorized_GotFocus(sender As Object, e As EventArgs) Handles txtPetcDateAuthorized.GotFocus
        txtPetcDateAuthorized.SelectAll()
    End Sub

    Private Sub txtPetcDateAuthorized_LostFocus(sender As Object, e As EventArgs) Handles txtPetcDateAuthorized.LostFocus
        If IsDate(txtPetcDateAuthorized.Text) = True Then
            txtPetcDateAuthorized.Text = Format(CDate(txtPetcDateAuthorized.Text), "yyyy-MM-dd")
        Else
            txtPetcDateAuthorized.Text = ""
        End If
    End Sub

    Private Sub txtPetcDateAuthorized_TextChanged(sender As Object, e As EventArgs) Handles txtPetcDateAuthorized.TextChanged

    End Sub

    Private Sub txtItDateStarted_GotFocus(sender As Object, e As EventArgs) Handles txtItDateStarted.GotFocus
        txtItDateStarted.SelectAll()
    End Sub

    Private Sub txtItDateStarted_LostFocus(sender As Object, e As EventArgs) Handles txtItDateStarted.LostFocus
        If IsDate(txtItDateStarted.Text) = True Then
            txtItDateStarted.Text = Format(CDate(txtItDateStarted.Text), "yyyy-MM-dd")
        Else
            txtItDateStarted.Text = ""
        End If
    End Sub

    Private Sub txtItDateStarted_TextChanged(sender As Object, e As EventArgs) Handles txtItDateStarted.TextChanged

    End Sub

    Private Sub txtItDateAccredited_GotFocus(sender As Object, e As EventArgs) Handles txtItDateAccredited.GotFocus
        txtItDateAccredited.SelectAll()
    End Sub

    Private Sub txtItDateAccredited_LostFocus(sender As Object, e As EventArgs) Handles txtItDateAccredited.LostFocus
        If IsDate(txtItDateAccredited.Text) = True Then
            txtItDateAccredited.Text = Format(CDate(txtItDateAccredited.Text), "yyyy-MM-dd")
        Else
            txtItDateAccredited.Text = ""
        End If
    End Sub

    Private Sub txtItDateAccredited_TextChanged(sender As Object, e As EventArgs) Handles txtItDateAccredited.TextChanged

    End Sub

    Private Sub txtItDateRenewal_GotFocus(sender As Object, e As EventArgs) Handles txtItDateRenewal.GotFocus
        txtItDateRenewal.SelectAll()
    End Sub

    Private Sub txtItDateRenewal_LostFocus(sender As Object, e As EventArgs) Handles txtItDateRenewal.LostFocus
        If IsDate(txtItDateRenewal.Text) = True Then
            txtItDateRenewal.Text = Format(CDate(txtItDateRenewal.Text), "yyyy-MM-dd")
        Else
            txtItDateRenewal.Text = ""
        End If
    End Sub

    Private Sub txtItDateRenewal_TextChanged(sender As Object, e As EventArgs) Handles txtItDateRenewal.TextChanged

    End Sub

    Private Sub txtMaxCredit_GotFocus(sender As Object, e As EventArgs) Handles txtMaxCredit.GotFocus
        txtMaxCredit.SelectAll()
    End Sub

    Private Sub txtMaxCredit_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMaxCredit.KeyPress
        Select Case e.KeyChar
            Case "0" To "9"
            Case ","
            Case "."
            Case "-"
            Case Else
                '                If LCase(cmbAccountType.Text) = "pre-paid" Then
                ' If e.KeyChar <> "-" Then e.Handled = True
                ' Else
                ' e.Handled = True
                ' End If
        End Select
    End Sub

    Private Sub txtMaxCredit_LostFocus(sender As Object, e As EventArgs) Handles txtMaxCredit.LostFocus
        If IsNumeric(txtMaxCredit.Text) = True Then
            txtMaxCredit.Text = Format(CDbl(txtMaxCredit.Text), "###,###,###,##0.00")
        Else
            txtMaxCredit.Text = "0.00"
        End If
    End Sub

    Private Sub txtMaxCredit_TextChanged(sender As Object, e As EventArgs) Handles txtMaxCredit.TextChanged

    End Sub

    Private Sub chkGM1_CheckedChanged(sender As Object, e As EventArgs) Handles chkGM1.CheckedChanged

    End Sub

    Private Sub cmbRegion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbRegion.KeyPress
        e.Handled = True
    End Sub

    Private Sub cmbRegion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbRegion.SelectedIndexChanged
        Dim vOldProvince As String = ""
        Dim vOldCity As String = ""
        Dim vCtr As Long

        vOldProvince = cmbProvince.Text
        vOldCity = cmbLtoServiceArea.Text

        cmbProvince.Items.Clear()
        cmbLtoServiceArea.Items.Clear()

        cmbProvince.Text = ""
        cmbLtoServiceArea.Text = ""

        If Trim(cmbRegion.Text) = "" Then
        Else
            modModule.LoadTableFieldInComboBox(cmbProvince, "province", "tb_region_province_city", _
                                               "region = '" & modModule.CorrectSqlString(cmbRegion.Text) & "'", "province ASC", lblStatusPrompt, True)

            cmbProvince.Text = ""
            For vCtr = 1 To cmbProvince.Items.Count
                If cmbProvince.Items(vCtr - 1).ToString = vOldProvince Then
                    cmbProvince.Text = vOldProvince

                    Exit For
                End If
            Next

            If Trim(cmbProvince.Text) <> "" Then
                modModule.LoadTableFieldInComboBox(cmbLtoServiceArea, "town_city", "tb_region_province_city", _
                                                   "province = '" & modModule.CorrectSqlString(cmbProvince.Text) & "' AND town_city <> ''", "town_city ASC", lblStatusPrompt, True)

                cmbLtoServiceArea.Text = ""
                For vCtr = 1 To cmbLtoServiceArea.Items.Count
                    If cmbLtoServiceArea.Items(vCtr - 1).ToString = vOldCity Then
                        cmbLtoServiceArea.Text = vOldCity

                        Exit For
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub cmbProvince_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbProvince.KeyPress
        e.Handled = True
    End Sub

    Private Sub cmbProvince_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbProvince.SelectedIndexChanged
        Dim vOldCity As String = ""
        Dim vCtr As Long

        vOldCity = cmbLtoServiceArea.Text

        cmbLtoServiceArea.Items.Clear()
        cmbLtoServiceArea.Text = ""

        If Trim(cmbProvince.Text) = "" Then
        Else

            modModule.LoadTableFieldInComboBox(cmbLtoServiceArea, "town_city", "tb_region_province_city", _
                                               "province = '" & modModule.CorrectSqlString(cmbProvince.Text) & "' AND town_city <> ''", "town_city ASC", lblStatusPrompt, True)

            cmbLtoServiceArea.Text = ""
            For vCtr = 1 To cmbLtoServiceArea.Items.Count
                If cmbLtoServiceArea.Items(vCtr - 1).ToString = vOldCity Then
                    cmbLtoServiceArea.Text = vOldCity

                    Exit For
                End If
            Next
        End If
    End Sub

    Private Sub cmbLtoServiceArea_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbLtoServiceArea.KeyPress
        e.Handled = True
    End Sub

    Private Sub cmbLtoServiceArea_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbLtoServiceArea.SelectedIndexChanged

    End Sub

    Private Sub cmbOwner_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbOwner.KeyPress
        e.Handled = True
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub
    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub
    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub cmbOwner_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbOwner.SelectedIndexChanged

    End Sub

    Private Sub cmbAccountManager_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbAccountManager.KeyPress
        e.Handled = True
    End Sub

    Private Sub cmbAccountManager_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbAccountManager.SelectedIndexChanged

    End Sub

    Private Sub cmbMarketingAgent_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbMarketingAgent.KeyPress
        e.Handled = True
    End Sub

    Private Sub cmbMarketingAgent_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMarketingAgent.SelectedIndexChanged

    End Sub

    Private Sub cmbTechManager_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbTechManager.KeyPress
        e.Handled = True
    End Sub

    Private Sub cmbTechManager_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTechManager.SelectedIndexChanged

    End Sub

    Private Sub txtMarketingCommission_GotFocus(sender As Object, e As EventArgs) Handles txtMarketingCommission.GotFocus
        txtMarketingCommission.SelectAll()
    End Sub

    Private Sub txtMarketingCommission_LostFocus(sender As Object, e As EventArgs) Handles txtMarketingCommission.LostFocus
        If IsNumeric(txtMarketingCommission.Text) = True Then
            txtMarketingCommission.Text = Format(CDbl(txtMarketingCommission.Text), "###,###,###,##0.00")
        Else
            txtMarketingCommission.Text = "0.00"
        End If
    End Sub

    Private Sub txtMarketingCommission_TextChanged(sender As Object, e As EventArgs) Handles txtMarketingCommission.TextChanged

    End Sub
End Class