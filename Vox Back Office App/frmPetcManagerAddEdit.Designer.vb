<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPetcManagerAddEdit
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmdProcess = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.lblStatusPrompt = New System.Windows.Forms.Label()
        Me.cmdRefreshPredefinedData = New System.Windows.Forms.Button()
        Me.timerRefreshPredefinedData = New System.Windows.Forms.Timer(Me.components)
        Me.timerLoad = New System.Windows.Forms.Timer(Me.components)
        Me.tabData = New System.Windows.Forms.TabControl()
        Me.General = New System.Windows.Forms.TabPage()
        Me.chkGM16 = New System.Windows.Forms.CheckBox()
        Me.chkGM15 = New System.Windows.Forms.CheckBox()
        Me.chkGM14 = New System.Windows.Forms.CheckBox()
        Me.chkGM13 = New System.Windows.Forms.CheckBox()
        Me.txtMarketingCommission = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.cmbAccountManager = New System.Windows.Forms.ComboBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.cmbTechManager = New System.Windows.Forms.ComboBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.cmbMarketingAgent = New System.Windows.Forms.ComboBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.cmbOwner = New System.Windows.Forms.ComboBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.chkGM12 = New System.Windows.Forms.CheckBox()
        Me.chkGM11 = New System.Windows.Forms.CheckBox()
        Me.chkGM10 = New System.Windows.Forms.CheckBox()
        Me.chkGM9 = New System.Windows.Forms.CheckBox()
        Me.chkGM8 = New System.Windows.Forms.CheckBox()
        Me.chkGM7 = New System.Windows.Forms.CheckBox()
        Me.chkGM6 = New System.Windows.Forms.CheckBox()
        Me.chkGM5 = New System.Windows.Forms.CheckBox()
        Me.chkGM4 = New System.Windows.Forms.CheckBox()
        Me.chkGM3 = New System.Windows.Forms.CheckBox()
        Me.chkGM2 = New System.Windows.Forms.CheckBox()
        Me.chkGM1 = New System.Windows.Forms.CheckBox()
        Me.txtContact = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.cmbBusinessTypes = New System.Windows.Forms.ComboBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbStatus = New System.Windows.Forms.ComboBox()
        Me.cmbCategory = New System.Windows.Forms.ComboBox()
        Me.cmbLanes = New System.Windows.Forms.ComboBox()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.txtAddress = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtCode = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Accreditatons = New System.Windows.Forms.TabPage()
        Me.cmbLtoServiceArea = New System.Windows.Forms.ComboBox()
        Me.cmbProvince = New System.Windows.Forms.ComboBox()
        Me.cmbRegion = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtLtoAuthorizationNo = New System.Windows.Forms.TextBox()
        Me.txtDtiAccreditationNo = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Accounting = New System.Windows.Forms.TabPage()
        Me.txtMaxCredit = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtBalance = New System.Windows.Forms.TextBox()
        Me.lblBalance = New System.Windows.Forms.Label()
        Me.txtStradcomFee = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtTransmissionFee = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.cmbAccountType = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Schedules = New System.Windows.Forms.TabPage()
        Me.txtItDateRenewal = New System.Windows.Forms.TextBox()
        Me.txtItDateAccredited = New System.Windows.Forms.TextBox()
        Me.txtItDateStarted = New System.Windows.Forms.TextBox()
        Me.txtPetcDateAuthorized = New System.Windows.Forms.TextBox()
        Me.txtPetcDateAccredited = New System.Windows.Forms.TextBox()
        Me.txtPetcDateStarted = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.chkIsLTMSReady = New System.Windows.Forms.CheckBox()
        Me.txtMaxTransPerDay = New System.Windows.Forms.TextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.tabData.SuspendLayout()
        Me.General.SuspendLayout()
        Me.Accreditatons.SuspendLayout()
        Me.Accounting.SuspendLayout()
        Me.Schedules.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(33, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(318, 24)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Please enter P.E.T.C. information"
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(12, 60)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(668, 8)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        '
        'cmdProcess
        '
        Me.cmdProcess.Enabled = False
        Me.cmdProcess.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdProcess.Location = New System.Drawing.Point(363, 427)
        Me.cmdProcess.Name = "cmdProcess"
        Me.cmdProcess.Size = New System.Drawing.Size(142, 39)
        Me.cmdProcess.TabIndex = 38
        Me.cmdProcess.Text = "CREATE"
        Me.cmdProcess.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancel.Location = New System.Drawing.Point(511, 427)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(135, 39)
        Me.cmdCancel.TabIndex = 39
        Me.cmdCancel.Text = "&CANCEL"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'lblStatusPrompt
        '
        Me.lblStatusPrompt.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblStatusPrompt.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatusPrompt.ForeColor = System.Drawing.Color.White
        Me.lblStatusPrompt.Location = New System.Drawing.Point(0, 484)
        Me.lblStatusPrompt.Name = "lblStatusPrompt"
        Me.lblStatusPrompt.Padding = New System.Windows.Forms.Padding(3)
        Me.lblStatusPrompt.Size = New System.Drawing.Size(716, 23)
        Me.lblStatusPrompt.TabIndex = 27
        Me.lblStatusPrompt.Text = "OPTIONS:"
        Me.lblStatusPrompt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdRefreshPredefinedData
        '
        Me.cmdRefreshPredefinedData.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdRefreshPredefinedData.Location = New System.Drawing.Point(41, 426)
        Me.cmdRefreshPredefinedData.Name = "cmdRefreshPredefinedData"
        Me.cmdRefreshPredefinedData.Size = New System.Drawing.Size(244, 39)
        Me.cmdRefreshPredefinedData.TabIndex = 37
        Me.cmdRefreshPredefinedData.Text = "REFRESH PRE-DEFINED DATA"
        Me.cmdRefreshPredefinedData.UseVisualStyleBackColor = True
        Me.cmdRefreshPredefinedData.Visible = False
        '
        'timerRefreshPredefinedData
        '
        Me.timerRefreshPredefinedData.Interval = 1
        '
        'timerLoad
        '
        Me.timerLoad.Interval = 1
        '
        'tabData
        '
        Me.tabData.Controls.Add(Me.General)
        Me.tabData.Controls.Add(Me.Accreditatons)
        Me.tabData.Controls.Add(Me.Accounting)
        Me.tabData.Controls.Add(Me.Schedules)
        Me.tabData.Controls.Add(Me.TabPage1)
        Me.tabData.Location = New System.Drawing.Point(37, 82)
        Me.tabData.Name = "tabData"
        Me.tabData.SelectedIndex = 0
        Me.tabData.Size = New System.Drawing.Size(609, 324)
        Me.tabData.TabIndex = 40
        '
        'General
        '
        Me.General.BackColor = System.Drawing.Color.White
        Me.General.Controls.Add(Me.chkGM16)
        Me.General.Controls.Add(Me.chkGM15)
        Me.General.Controls.Add(Me.chkGM14)
        Me.General.Controls.Add(Me.chkGM13)
        Me.General.Controls.Add(Me.txtMarketingCommission)
        Me.General.Controls.Add(Me.Label29)
        Me.General.Controls.Add(Me.cmbAccountManager)
        Me.General.Controls.Add(Me.Label28)
        Me.General.Controls.Add(Me.cmbTechManager)
        Me.General.Controls.Add(Me.Label26)
        Me.General.Controls.Add(Me.cmbMarketingAgent)
        Me.General.Controls.Add(Me.Label27)
        Me.General.Controls.Add(Me.cmbOwner)
        Me.General.Controls.Add(Me.Label25)
        Me.General.Controls.Add(Me.chkGM12)
        Me.General.Controls.Add(Me.chkGM11)
        Me.General.Controls.Add(Me.chkGM10)
        Me.General.Controls.Add(Me.chkGM9)
        Me.General.Controls.Add(Me.chkGM8)
        Me.General.Controls.Add(Me.chkGM7)
        Me.General.Controls.Add(Me.chkGM6)
        Me.General.Controls.Add(Me.chkGM5)
        Me.General.Controls.Add(Me.chkGM4)
        Me.General.Controls.Add(Me.chkGM3)
        Me.General.Controls.Add(Me.chkGM2)
        Me.General.Controls.Add(Me.chkGM1)
        Me.General.Controls.Add(Me.txtContact)
        Me.General.Controls.Add(Me.Label24)
        Me.General.Controls.Add(Me.cmbBusinessTypes)
        Me.General.Controls.Add(Me.Label23)
        Me.General.Controls.Add(Me.Label21)
        Me.General.Controls.Add(Me.txtDescription)
        Me.General.Controls.Add(Me.Label7)
        Me.General.Controls.Add(Me.cmbStatus)
        Me.General.Controls.Add(Me.cmbCategory)
        Me.General.Controls.Add(Me.cmbLanes)
        Me.General.Controls.Add(Me.txtName)
        Me.General.Controls.Add(Me.txtAddress)
        Me.General.Controls.Add(Me.Label16)
        Me.General.Controls.Add(Me.Label5)
        Me.General.Controls.Add(Me.Label4)
        Me.General.Controls.Add(Me.Label3)
        Me.General.Controls.Add(Me.txtCode)
        Me.General.Controls.Add(Me.Label2)
        Me.General.Location = New System.Drawing.Point(4, 22)
        Me.General.Name = "General"
        Me.General.Padding = New System.Windows.Forms.Padding(3)
        Me.General.Size = New System.Drawing.Size(601, 298)
        Me.General.TabIndex = 0
        Me.General.Text = "General"
        '
        'chkGM16
        '
        Me.chkGM16.AutoSize = True
        Me.chkGM16.Location = New System.Drawing.Point(527, 224)
        Me.chkGM16.Name = "chkGM16"
        Me.chkGM16.Size = New System.Drawing.Size(53, 17)
        Me.chkGM16.TabIndex = 140
        Me.chkGM16.Text = "Bit 16"
        Me.chkGM16.UseVisualStyleBackColor = True
        '
        'chkGM15
        '
        Me.chkGM15.AutoSize = True
        Me.chkGM15.Location = New System.Drawing.Point(452, 224)
        Me.chkGM15.Name = "chkGM15"
        Me.chkGM15.Size = New System.Drawing.Size(53, 17)
        Me.chkGM15.TabIndex = 139
        Me.chkGM15.Text = "Bit 15"
        Me.chkGM15.UseVisualStyleBackColor = True
        '
        'chkGM14
        '
        Me.chkGM14.AutoSize = True
        Me.chkGM14.Location = New System.Drawing.Point(375, 224)
        Me.chkGM14.Name = "chkGM14"
        Me.chkGM14.Size = New System.Drawing.Size(53, 17)
        Me.chkGM14.TabIndex = 138
        Me.chkGM14.Text = "Bit 14"
        Me.chkGM14.UseVisualStyleBackColor = True
        '
        'chkGM13
        '
        Me.chkGM13.AutoSize = True
        Me.chkGM13.Location = New System.Drawing.Point(296, 224)
        Me.chkGM13.Name = "chkGM13"
        Me.chkGM13.Size = New System.Drawing.Size(53, 17)
        Me.chkGM13.TabIndex = 137
        Me.chkGM13.Text = "Bit 13"
        Me.chkGM13.UseVisualStyleBackColor = True
        '
        'txtMarketingCommission
        '
        Me.txtMarketingCommission.Location = New System.Drawing.Point(471, 259)
        Me.txtMarketingCommission.Name = "txtMarketingCommission"
        Me.txtMarketingCommission.Size = New System.Drawing.Size(70, 20)
        Me.txtMarketingCommission.TabIndex = 13
        Me.txtMarketingCommission.Text = "0.00"
        Me.txtMarketingCommission.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(293, 262)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(172, 13)
        Me.Label29.TabIndex = 122
        Me.Label29.Text = "Marketing commission (transaction)"
        '
        'cmbAccountManager
        '
        Me.cmbAccountManager.FormattingEnabled = True
        Me.cmbAccountManager.Location = New System.Drawing.Point(124, 205)
        Me.cmbAccountManager.Name = "cmbAccountManager"
        Me.cmbAccountManager.Size = New System.Drawing.Size(143, 21)
        Me.cmbAccountManager.TabIndex = 10
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(27, 208)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(91, 13)
        Me.Label28.TabIndex = 136
        Me.Label28.Text = "Account manager"
        '
        'cmbTechManager
        '
        Me.cmbTechManager.FormattingEnabled = True
        Me.cmbTechManager.Location = New System.Drawing.Point(124, 232)
        Me.cmbTechManager.Name = "cmbTechManager"
        Me.cmbTechManager.Size = New System.Drawing.Size(143, 21)
        Me.cmbTechManager.TabIndex = 11
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(27, 235)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(98, 13)
        Me.Label26.TabIndex = 135
        Me.Label26.Text = "Technical manager"
        '
        'cmbMarketingAgent
        '
        Me.cmbMarketingAgent.FormattingEnabled = True
        Me.cmbMarketingAgent.Location = New System.Drawing.Point(124, 259)
        Me.cmbMarketingAgent.Name = "cmbMarketingAgent"
        Me.cmbMarketingAgent.Size = New System.Drawing.Size(143, 21)
        Me.cmbMarketingAgent.TabIndex = 12
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(27, 262)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(84, 13)
        Me.Label27.TabIndex = 134
        Me.Label27.Text = "Marketing agent"
        '
        'cmbOwner
        '
        Me.cmbOwner.FormattingEnabled = True
        Me.cmbOwner.Location = New System.Drawing.Point(100, 178)
        Me.cmbOwner.Name = "cmbOwner"
        Me.cmbOwner.Size = New System.Drawing.Size(167, 21)
        Me.cmbOwner.TabIndex = 9
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(27, 181)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(38, 13)
        Me.Label25.TabIndex = 131
        Me.Label25.Text = "Owner"
        '
        'chkGM12
        '
        Me.chkGM12.AutoSize = True
        Me.chkGM12.Location = New System.Drawing.Point(527, 201)
        Me.chkGM12.Name = "chkGM12"
        Me.chkGM12.Size = New System.Drawing.Size(53, 17)
        Me.chkGM12.TabIndex = 25
        Me.chkGM12.Text = "Bit 12"
        Me.chkGM12.UseVisualStyleBackColor = True
        '
        'chkGM11
        '
        Me.chkGM11.AutoSize = True
        Me.chkGM11.Location = New System.Drawing.Point(527, 178)
        Me.chkGM11.Name = "chkGM11"
        Me.chkGM11.Size = New System.Drawing.Size(53, 17)
        Me.chkGM11.TabIndex = 24
        Me.chkGM11.Text = "Bit 11"
        Me.chkGM11.UseVisualStyleBackColor = True
        '
        'chkGM10
        '
        Me.chkGM10.AutoSize = True
        Me.chkGM10.Location = New System.Drawing.Point(527, 155)
        Me.chkGM10.Name = "chkGM10"
        Me.chkGM10.Size = New System.Drawing.Size(53, 17)
        Me.chkGM10.TabIndex = 23
        Me.chkGM10.Text = "Bit 10"
        Me.chkGM10.UseVisualStyleBackColor = True
        '
        'chkGM9
        '
        Me.chkGM9.AutoSize = True
        Me.chkGM9.Location = New System.Drawing.Point(452, 201)
        Me.chkGM9.Name = "chkGM9"
        Me.chkGM9.Size = New System.Drawing.Size(47, 17)
        Me.chkGM9.TabIndex = 22
        Me.chkGM9.Text = "Bit 9"
        Me.chkGM9.UseVisualStyleBackColor = True
        '
        'chkGM8
        '
        Me.chkGM8.AutoSize = True
        Me.chkGM8.Location = New System.Drawing.Point(452, 178)
        Me.chkGM8.Name = "chkGM8"
        Me.chkGM8.Size = New System.Drawing.Size(47, 17)
        Me.chkGM8.TabIndex = 21
        Me.chkGM8.Text = "Bit 8"
        Me.chkGM8.UseVisualStyleBackColor = True
        '
        'chkGM7
        '
        Me.chkGM7.AutoSize = True
        Me.chkGM7.Location = New System.Drawing.Point(452, 155)
        Me.chkGM7.Name = "chkGM7"
        Me.chkGM7.Size = New System.Drawing.Size(47, 17)
        Me.chkGM7.TabIndex = 20
        Me.chkGM7.Text = "Bit 7"
        Me.chkGM7.UseVisualStyleBackColor = True
        '
        'chkGM6
        '
        Me.chkGM6.AutoSize = True
        Me.chkGM6.Location = New System.Drawing.Point(375, 201)
        Me.chkGM6.Name = "chkGM6"
        Me.chkGM6.Size = New System.Drawing.Size(47, 17)
        Me.chkGM6.TabIndex = 19
        Me.chkGM6.Text = "Bit 6"
        Me.chkGM6.UseVisualStyleBackColor = True
        '
        'chkGM5
        '
        Me.chkGM5.AutoSize = True
        Me.chkGM5.Location = New System.Drawing.Point(375, 178)
        Me.chkGM5.Name = "chkGM5"
        Me.chkGM5.Size = New System.Drawing.Size(47, 17)
        Me.chkGM5.TabIndex = 18
        Me.chkGM5.Text = "Bit 5"
        Me.chkGM5.UseVisualStyleBackColor = True
        '
        'chkGM4
        '
        Me.chkGM4.AutoSize = True
        Me.chkGM4.Location = New System.Drawing.Point(375, 155)
        Me.chkGM4.Name = "chkGM4"
        Me.chkGM4.Size = New System.Drawing.Size(47, 17)
        Me.chkGM4.TabIndex = 17
        Me.chkGM4.Text = "Bit 4"
        Me.chkGM4.UseVisualStyleBackColor = True
        '
        'chkGM3
        '
        Me.chkGM3.AutoSize = True
        Me.chkGM3.Location = New System.Drawing.Point(296, 201)
        Me.chkGM3.Name = "chkGM3"
        Me.chkGM3.Size = New System.Drawing.Size(47, 17)
        Me.chkGM3.TabIndex = 16
        Me.chkGM3.Text = "Bit 3"
        Me.chkGM3.UseVisualStyleBackColor = True
        '
        'chkGM2
        '
        Me.chkGM2.AutoSize = True
        Me.chkGM2.Location = New System.Drawing.Point(296, 178)
        Me.chkGM2.Name = "chkGM2"
        Me.chkGM2.Size = New System.Drawing.Size(47, 17)
        Me.chkGM2.TabIndex = 15
        Me.chkGM2.Text = "Bit 2"
        Me.chkGM2.UseVisualStyleBackColor = True
        '
        'chkGM1
        '
        Me.chkGM1.AutoSize = True
        Me.chkGM1.Location = New System.Drawing.Point(296, 155)
        Me.chkGM1.Name = "chkGM1"
        Me.chkGM1.Size = New System.Drawing.Size(47, 17)
        Me.chkGM1.TabIndex = 14
        Me.chkGM1.Text = "Bit 1"
        Me.chkGM1.UseVisualStyleBackColor = True
        '
        'txtContact
        '
        Me.txtContact.Location = New System.Drawing.Point(100, 125)
        Me.txtContact.Name = "txtContact"
        Me.txtContact.Size = New System.Drawing.Size(475, 20)
        Me.txtContact.TabIndex = 7
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(27, 128)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(67, 13)
        Me.Label24.TabIndex = 129
        Me.Label24.Text = "Contact info."
        '
        'cmbBusinessTypes
        '
        Me.cmbBusinessTypes.FormattingEnabled = True
        Me.cmbBusinessTypes.Location = New System.Drawing.Point(443, 47)
        Me.cmbBusinessTypes.Name = "cmbBusinessTypes"
        Me.cmbBusinessTypes.Size = New System.Drawing.Size(132, 21)
        Me.cmbBusinessTypes.TabIndex = 4
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(365, 50)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(72, 13)
        Me.Label23.TabIndex = 127
        Me.Label23.Text = "Business type"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(27, 76)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(45, 13)
        Me.Label21.TabIndex = 125
        Me.Label21.Text = "Address"
        '
        'txtDescription
        '
        Me.txtDescription.Location = New System.Drawing.Point(100, 99)
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(475, 20)
        Me.txtDescription.TabIndex = 6
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(27, 102)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(60, 13)
        Me.Label7.TabIndex = 124
        Me.Label7.Text = "Description"
        '
        'cmbStatus
        '
        Me.cmbStatus.FormattingEnabled = True
        Me.cmbStatus.Location = New System.Drawing.Point(100, 151)
        Me.cmbStatus.Name = "cmbStatus"
        Me.cmbStatus.Size = New System.Drawing.Size(167, 21)
        Me.cmbStatus.TabIndex = 8
        '
        'cmbCategory
        '
        Me.cmbCategory.FormattingEnabled = True
        Me.cmbCategory.Location = New System.Drawing.Point(443, 21)
        Me.cmbCategory.Name = "cmbCategory"
        Me.cmbCategory.Size = New System.Drawing.Size(132, 21)
        Me.cmbCategory.TabIndex = 2
        '
        'cmbLanes
        '
        Me.cmbLanes.FormattingEnabled = True
        Me.cmbLanes.Location = New System.Drawing.Point(273, 21)
        Me.cmbLanes.Name = "cmbLanes"
        Me.cmbLanes.Size = New System.Drawing.Size(70, 21)
        Me.cmbLanes.TabIndex = 1
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(100, 47)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(243, 20)
        Me.txtName.TabIndex = 3
        '
        'txtAddress
        '
        Me.txtAddress.Location = New System.Drawing.Point(100, 73)
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.Size = New System.Drawing.Size(475, 20)
        Me.txtAddress.TabIndex = 5
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(27, 154)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(37, 13)
        Me.Label16.TabIndex = 122
        Me.Label16.Text = "Status"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(365, 24)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 13)
        Me.Label5.TabIndex = 121
        Me.Label5.Text = "Category"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(27, 50)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 13)
        Me.Label4.TabIndex = 120
        Me.Label4.Text = "Name"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(231, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(36, 13)
        Me.Label3.TabIndex = 119
        Me.Label3.Text = "Lanes"
        '
        'txtCode
        '
        Me.txtCode.Location = New System.Drawing.Point(100, 21)
        Me.txtCode.Name = "txtCode"
        Me.txtCode.Size = New System.Drawing.Size(103, 20)
        Me.txtCode.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(27, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(32, 13)
        Me.Label2.TabIndex = 117
        Me.Label2.Text = "Code"
        '
        'Accreditatons
        '
        Me.Accreditatons.BackColor = System.Drawing.Color.White
        Me.Accreditatons.Controls.Add(Me.cmbLtoServiceArea)
        Me.Accreditatons.Controls.Add(Me.cmbProvince)
        Me.Accreditatons.Controls.Add(Me.cmbRegion)
        Me.Accreditatons.Controls.Add(Me.Label13)
        Me.Accreditatons.Controls.Add(Me.Label10)
        Me.Accreditatons.Controls.Add(Me.txtLtoAuthorizationNo)
        Me.Accreditatons.Controls.Add(Me.txtDtiAccreditationNo)
        Me.Accreditatons.Controls.Add(Me.Label17)
        Me.Accreditatons.Controls.Add(Me.Label18)
        Me.Accreditatons.Controls.Add(Me.Label11)
        Me.Accreditatons.Location = New System.Drawing.Point(4, 22)
        Me.Accreditatons.Name = "Accreditatons"
        Me.Accreditatons.Size = New System.Drawing.Size(601, 298)
        Me.Accreditatons.TabIndex = 3
        Me.Accreditatons.Text = "Accreditatons"
        '
        'cmbLtoServiceArea
        '
        Me.cmbLtoServiceArea.FormattingEnabled = True
        Me.cmbLtoServiceArea.Location = New System.Drawing.Point(144, 79)
        Me.cmbLtoServiceArea.Name = "cmbLtoServiceArea"
        Me.cmbLtoServiceArea.Size = New System.Drawing.Size(350, 21)
        Me.cmbLtoServiceArea.TabIndex = 23
        '
        'cmbProvince
        '
        Me.cmbProvince.FormattingEnabled = True
        Me.cmbProvince.Location = New System.Drawing.Point(144, 52)
        Me.cmbProvince.Name = "cmbProvince"
        Me.cmbProvince.Size = New System.Drawing.Size(350, 21)
        Me.cmbProvince.TabIndex = 22
        '
        'cmbRegion
        '
        Me.cmbRegion.FormattingEnabled = True
        Me.cmbRegion.Location = New System.Drawing.Point(144, 25)
        Me.cmbRegion.Name = "cmbRegion"
        Me.cmbRegion.Size = New System.Drawing.Size(350, 21)
        Me.cmbRegion.TabIndex = 21
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(29, 28)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(41, 13)
        Me.Label13.TabIndex = 121
        Me.Label13.Text = "Region"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(29, 55)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(49, 13)
        Me.Label10.TabIndex = 119
        Me.Label10.Text = "Province"
        '
        'txtLtoAuthorizationNo
        '
        Me.txtLtoAuthorizationNo.Location = New System.Drawing.Point(144, 132)
        Me.txtLtoAuthorizationNo.Name = "txtLtoAuthorizationNo"
        Me.txtLtoAuthorizationNo.Size = New System.Drawing.Size(350, 20)
        Me.txtLtoAuthorizationNo.TabIndex = 25
        '
        'txtDtiAccreditationNo
        '
        Me.txtDtiAccreditationNo.Location = New System.Drawing.Point(144, 106)
        Me.txtDtiAccreditationNo.Name = "txtDtiAccreditationNo"
        Me.txtDtiAccreditationNo.Size = New System.Drawing.Size(350, 20)
        Me.txtDtiAccreditationNo.TabIndex = 24
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(29, 135)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(109, 13)
        Me.Label17.TabIndex = 117
        Me.Label17.Text = "LTO authorization no."
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(29, 109)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(107, 13)
        Me.Label18.TabIndex = 116
        Me.Label18.Text = "DTI accreditation no."
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(29, 82)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(89, 13)
        Me.Label11.TabIndex = 115
        Me.Label11.Text = "LTO service area"
        '
        'Accounting
        '
        Me.Accounting.BackColor = System.Drawing.Color.White
        Me.Accounting.Controls.Add(Me.txtMaxCredit)
        Me.Accounting.Controls.Add(Me.Label9)
        Me.Accounting.Controls.Add(Me.txtBalance)
        Me.Accounting.Controls.Add(Me.lblBalance)
        Me.Accounting.Controls.Add(Me.txtStradcomFee)
        Me.Accounting.Controls.Add(Me.Label22)
        Me.Accounting.Controls.Add(Me.txtTransmissionFee)
        Me.Accounting.Controls.Add(Me.Label19)
        Me.Accounting.Controls.Add(Me.cmbAccountType)
        Me.Accounting.Controls.Add(Me.Label6)
        Me.Accounting.Location = New System.Drawing.Point(4, 22)
        Me.Accounting.Name = "Accounting"
        Me.Accounting.Padding = New System.Windows.Forms.Padding(3)
        Me.Accounting.Size = New System.Drawing.Size(601, 298)
        Me.Accounting.TabIndex = 1
        Me.Accounting.Text = "Accounting"
        '
        'txtMaxCredit
        '
        Me.txtMaxCredit.Location = New System.Drawing.Point(127, 108)
        Me.txtMaxCredit.Name = "txtMaxCredit"
        Me.txtMaxCredit.Size = New System.Drawing.Size(103, 20)
        Me.txtMaxCredit.TabIndex = 29
        Me.txtMaxCredit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(35, 111)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(80, 13)
        Me.Label9.TabIndex = 117
        Me.Label9.Text = "Maximum credit"
        '
        'txtBalance
        '
        Me.txtBalance.Location = New System.Drawing.Point(127, 134)
        Me.txtBalance.Name = "txtBalance"
        Me.txtBalance.Size = New System.Drawing.Size(103, 20)
        Me.txtBalance.TabIndex = 30
        Me.txtBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblBalance
        '
        Me.lblBalance.AutoSize = True
        Me.lblBalance.Location = New System.Drawing.Point(35, 138)
        Me.lblBalance.Name = "lblBalance"
        Me.lblBalance.Size = New System.Drawing.Size(46, 13)
        Me.lblBalance.TabIndex = 115
        Me.lblBalance.Text = "Balance"
        '
        'txtStradcomFee
        '
        Me.txtStradcomFee.Location = New System.Drawing.Point(127, 82)
        Me.txtStradcomFee.Name = "txtStradcomFee"
        Me.txtStradcomFee.Size = New System.Drawing.Size(103, 20)
        Me.txtStradcomFee.TabIndex = 28
        Me.txtStradcomFee.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(35, 85)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(70, 13)
        Me.Label22.TabIndex = 113
        Me.Label22.Text = "Stradcom fee"
        '
        'txtTransmissionFee
        '
        Me.txtTransmissionFee.Location = New System.Drawing.Point(127, 56)
        Me.txtTransmissionFee.Name = "txtTransmissionFee"
        Me.txtTransmissionFee.Size = New System.Drawing.Size(103, 20)
        Me.txtTransmissionFee.TabIndex = 27
        Me.txtTransmissionFee.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(35, 59)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(86, 13)
        Me.Label19.TabIndex = 111
        Me.Label19.Text = "Transmission fee"
        '
        'cmbAccountType
        '
        Me.cmbAccountType.FormattingEnabled = True
        Me.cmbAccountType.Location = New System.Drawing.Point(127, 29)
        Me.cmbAccountType.Name = "cmbAccountType"
        Me.cmbAccountType.Size = New System.Drawing.Size(169, 21)
        Me.cmbAccountType.TabIndex = 26
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(35, 32)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(86, 13)
        Me.Label6.TabIndex = 109
        Me.Label6.Text = "Payment method"
        '
        'Schedules
        '
        Me.Schedules.BackColor = System.Drawing.Color.White
        Me.Schedules.Controls.Add(Me.txtItDateRenewal)
        Me.Schedules.Controls.Add(Me.txtItDateAccredited)
        Me.Schedules.Controls.Add(Me.txtItDateStarted)
        Me.Schedules.Controls.Add(Me.txtPetcDateAuthorized)
        Me.Schedules.Controls.Add(Me.txtPetcDateAccredited)
        Me.Schedules.Controls.Add(Me.txtPetcDateStarted)
        Me.Schedules.Controls.Add(Me.Label8)
        Me.Schedules.Controls.Add(Me.Label12)
        Me.Schedules.Controls.Add(Me.Label20)
        Me.Schedules.Controls.Add(Me.Label)
        Me.Schedules.Controls.Add(Me.Label14)
        Me.Schedules.Controls.Add(Me.Label15)
        Me.Schedules.Location = New System.Drawing.Point(4, 22)
        Me.Schedules.Name = "Schedules"
        Me.Schedules.Size = New System.Drawing.Size(601, 298)
        Me.Schedules.TabIndex = 2
        Me.Schedules.Text = "Schedules"
        '
        'txtItDateRenewal
        '
        Me.txtItDateRenewal.Location = New System.Drawing.Point(183, 176)
        Me.txtItDateRenewal.Name = "txtItDateRenewal"
        Me.txtItDateRenewal.Size = New System.Drawing.Size(125, 20)
        Me.txtItDateRenewal.TabIndex = 36
        '
        'txtItDateAccredited
        '
        Me.txtItDateAccredited.Location = New System.Drawing.Point(183, 150)
        Me.txtItDateAccredited.Name = "txtItDateAccredited"
        Me.txtItDateAccredited.Size = New System.Drawing.Size(125, 20)
        Me.txtItDateAccredited.TabIndex = 35
        '
        'txtItDateStarted
        '
        Me.txtItDateStarted.Location = New System.Drawing.Point(183, 124)
        Me.txtItDateStarted.Name = "txtItDateStarted"
        Me.txtItDateStarted.Size = New System.Drawing.Size(125, 20)
        Me.txtItDateStarted.TabIndex = 34
        '
        'txtPetcDateAuthorized
        '
        Me.txtPetcDateAuthorized.Location = New System.Drawing.Point(183, 80)
        Me.txtPetcDateAuthorized.Name = "txtPetcDateAuthorized"
        Me.txtPetcDateAuthorized.Size = New System.Drawing.Size(125, 20)
        Me.txtPetcDateAuthorized.TabIndex = 33
        '
        'txtPetcDateAccredited
        '
        Me.txtPetcDateAccredited.Location = New System.Drawing.Point(183, 54)
        Me.txtPetcDateAccredited.Name = "txtPetcDateAccredited"
        Me.txtPetcDateAccredited.Size = New System.Drawing.Size(125, 20)
        Me.txtPetcDateAccredited.TabIndex = 32
        '
        'txtPetcDateStarted
        '
        Me.txtPetcDateStarted.Location = New System.Drawing.Point(183, 28)
        Me.txtPetcDateStarted.Name = "txtPetcDateStarted"
        Me.txtPetcDateStarted.Size = New System.Drawing.Size(125, 20)
        Me.txtPetcDateStarted.TabIndex = 31
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(29, 57)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(137, 13)
        Me.Label8.TabIndex = 122
        Me.Label8.Text = "DTI accreditation expiration"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(29, 83)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(139, 13)
        Me.Label12.TabIndex = 121
        Me.Label12.Text = "LTO authorization expiration"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(29, 31)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(108, 13)
        Me.Label20.TabIndex = 120
        Me.Label20.Text = "Date P.E.T.C. started"
        '
        'Label
        '
        Me.Label.AutoSize = True
        Me.Label.Location = New System.Drawing.Point(29, 179)
        Me.Label.Name = "Label"
        Me.Label.Size = New System.Drawing.Size(114, 13)
        Me.Label.TabIndex = 119
        Me.Label.Text = "Renewal date with I.T."
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(29, 153)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(116, 13)
        Me.Label14.TabIndex = 118
        Me.Label14.Text = "Date accredited by I.T."
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(29, 127)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(106, 13)
        Me.Label15.TabIndex = 117
        Me.Label15.Text = "Date started with I.T."
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.txtMaxTransPerDay)
        Me.TabPage1.Controls.Add(Me.Label30)
        Me.TabPage1.Controls.Add(Me.chkIsLTMSReady)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(601, 298)
        Me.TabPage1.TabIndex = 4
        Me.TabPage1.Text = "Other Settings"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'chkIsLTMSReady
        '
        Me.chkIsLTMSReady.AutoSize = True
        Me.chkIsLTMSReady.Checked = True
        Me.chkIsLTMSReady.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkIsLTMSReady.Location = New System.Drawing.Point(22, 53)
        Me.chkIsLTMSReady.Name = "chkIsLTMSReady"
        Me.chkIsLTMSReady.Size = New System.Drawing.Size(90, 17)
        Me.chkIsLTMSReady.TabIndex = 15
        Me.chkIsLTMSReady.Text = "LTMS ready?"
        Me.chkIsLTMSReady.UseVisualStyleBackColor = True
        '
        'txtMaxTransPerDay
        '
        Me.txtMaxTransPerDay.Location = New System.Drawing.Point(175, 25)
        Me.txtMaxTransPerDay.Name = "txtMaxTransPerDay"
        Me.txtMaxTransPerDay.Size = New System.Drawing.Size(70, 20)
        Me.txtMaxTransPerDay.TabIndex = 123
        Me.txtMaxTransPerDay.Text = "0"
        Me.txtMaxTransPerDay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(19, 28)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(150, 13)
        Me.Label30.TabIndex = 124
        Me.Label30.Text = "Maximum Transaction per Day"
        '
        'frmPetcManagerAddEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(688, 506)
        Me.ControlBox = False
        Me.Controls.Add(Me.tabData)
        Me.Controls.Add(Me.cmdRefreshPredefinedData)
        Me.Controls.Add(Me.lblStatusPrompt)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdProcess)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmPetcManagerAddEdit"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ADD/EDIT P.E.T.C."
        Me.tabData.ResumeLayout(False)
        Me.General.ResumeLayout(False)
        Me.General.PerformLayout()
        Me.Accreditatons.ResumeLayout(False)
        Me.Accreditatons.PerformLayout()
        Me.Accounting.ResumeLayout(False)
        Me.Accounting.PerformLayout()
        Me.Schedules.ResumeLayout(False)
        Me.Schedules.PerformLayout()
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdProcess As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents lblStatusPrompt As System.Windows.Forms.Label
    Friend WithEvents cmdRefreshPredefinedData As System.Windows.Forms.Button
    Friend WithEvents timerRefreshPredefinedData As System.Windows.Forms.Timer
    Friend WithEvents timerLoad As System.Windows.Forms.Timer
    Friend WithEvents tabData As System.Windows.Forms.TabControl
    Friend WithEvents General As System.Windows.Forms.TabPage
    Friend WithEvents txtContact As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents cmbBusinessTypes As System.Windows.Forms.ComboBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmbStatus As System.Windows.Forms.ComboBox
    Friend WithEvents cmbCategory As System.Windows.Forms.ComboBox
    Friend WithEvents cmbLanes As System.Windows.Forms.ComboBox
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents txtAddress As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Accreditatons As System.Windows.Forms.TabPage
    Friend WithEvents txtLtoAuthorizationNo As System.Windows.Forms.TextBox
    Friend WithEvents txtDtiAccreditationNo As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Accounting As System.Windows.Forms.TabPage
    Friend WithEvents txtBalance As System.Windows.Forms.TextBox
    Friend WithEvents lblBalance As System.Windows.Forms.Label
    Friend WithEvents txtStradcomFee As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtTransmissionFee As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents cmbAccountType As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Schedules As System.Windows.Forms.TabPage
    Friend WithEvents txtItDateRenewal As System.Windows.Forms.TextBox
    Friend WithEvents txtItDateAccredited As System.Windows.Forms.TextBox
    Friend WithEvents txtItDateStarted As System.Windows.Forms.TextBox
    Friend WithEvents txtPetcDateAuthorized As System.Windows.Forms.TextBox
    Friend WithEvents txtPetcDateAccredited As System.Windows.Forms.TextBox
    Friend WithEvents txtPetcDateStarted As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtMaxCredit As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents chkGM1 As System.Windows.Forms.CheckBox
    Friend WithEvents chkGM2 As System.Windows.Forms.CheckBox
    Friend WithEvents chkGM6 As System.Windows.Forms.CheckBox
    Friend WithEvents chkGM5 As System.Windows.Forms.CheckBox
    Friend WithEvents chkGM4 As System.Windows.Forms.CheckBox
    Friend WithEvents chkGM3 As System.Windows.Forms.CheckBox
    Friend WithEvents chkGM12 As System.Windows.Forms.CheckBox
    Friend WithEvents chkGM11 As System.Windows.Forms.CheckBox
    Friend WithEvents chkGM10 As System.Windows.Forms.CheckBox
    Friend WithEvents chkGM9 As System.Windows.Forms.CheckBox
    Friend WithEvents chkGM8 As System.Windows.Forms.CheckBox
    Friend WithEvents chkGM7 As System.Windows.Forms.CheckBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cmbLtoServiceArea As System.Windows.Forms.ComboBox
    Friend WithEvents cmbProvince As System.Windows.Forms.ComboBox
    Friend WithEvents cmbRegion As System.Windows.Forms.ComboBox
    Friend WithEvents cmbOwner As System.Windows.Forms.ComboBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents cmbAccountManager As System.Windows.Forms.ComboBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents cmbTechManager As System.Windows.Forms.ComboBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents cmbMarketingAgent As System.Windows.Forms.ComboBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents txtMarketingCommission As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents chkGM16 As System.Windows.Forms.CheckBox
    Friend WithEvents chkGM15 As System.Windows.Forms.CheckBox
    Friend WithEvents chkGM14 As System.Windows.Forms.CheckBox
    Friend WithEvents chkGM13 As System.Windows.Forms.CheckBox
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents txtMaxTransPerDay As TextBox
    Friend WithEvents Label30 As Label
    Friend WithEvents chkIsLTMSReady As CheckBox
End Class
