<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTerminalsManagerAddEdit
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
        Me.txtTerminalIP = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtTerminalMac = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbStatus = New System.Windows.Forms.ComboBox()
        Me.cmbType = New System.Windows.Forms.ComboBox()
        Me.txtTerminalDescription = New System.Windows.Forms.TextBox()
        Me.txtTerminalSerial = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtTerminalID = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtPetcCode = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmdBrowsePetc = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtMachineDescription = New System.Windows.Forms.TextBox()
        Me.txtMachineSerial = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtDateCalibrated = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtTerminalLane = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.chkLocked = New System.Windows.Forms.CheckBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.txtMachineDLL = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.cmbMachineStopBits = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.cmbMachineParity = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cmbMachineBaud = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.cmbMachinePort = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cmbMachineBits = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.chkScsiSas = New System.Windows.Forms.CheckBox()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(33, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(321, 24)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Please enter Terminal information"
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
        Me.cmdProcess.Location = New System.Drawing.Point(416, 500)
        Me.cmdProcess.Name = "cmdProcess"
        Me.cmdProcess.Size = New System.Drawing.Size(112, 39)
        Me.cmdProcess.TabIndex = 23
        Me.cmdProcess.Text = "CREATE"
        Me.cmdProcess.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancel.Location = New System.Drawing.Point(534, 500)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(112, 39)
        Me.cmdCancel.TabIndex = 24
        Me.cmdCancel.Text = "&CANCEL"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'lblStatusPrompt
        '
        Me.lblStatusPrompt.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblStatusPrompt.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatusPrompt.ForeColor = System.Drawing.Color.White
        Me.lblStatusPrompt.Location = New System.Drawing.Point(0, 557)
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
        Me.cmdRefreshPredefinedData.Location = New System.Drawing.Point(37, 499)
        Me.cmdRefreshPredefinedData.Name = "cmdRefreshPredefinedData"
        Me.cmdRefreshPredefinedData.Size = New System.Drawing.Size(224, 39)
        Me.cmdRefreshPredefinedData.TabIndex = 22
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
        'txtTerminalIP
        '
        Me.txtTerminalIP.Location = New System.Drawing.Point(480, 149)
        Me.txtTerminalIP.Name = "txtTerminalIP"
        Me.txtTerminalIP.Size = New System.Drawing.Size(138, 20)
        Me.txtTerminalIP.TabIndex = 9
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(411, 152)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(57, 13)
        Me.Label24.TabIndex = 147
        Me.Label24.Text = "IP address"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(58, 152)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(74, 13)
        Me.Label21.TabIndex = 145
        Me.Label21.Text = "Terminal serial"
        '
        'txtTerminalMac
        '
        Me.txtTerminalMac.Location = New System.Drawing.Point(480, 123)
        Me.txtTerminalMac.Name = "txtTerminalMac"
        Me.txtTerminalMac.Size = New System.Drawing.Size(138, 20)
        Me.txtTerminalMac.TabIndex = 8
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(411, 126)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(30, 13)
        Me.Label7.TabIndex = 144
        Me.Label7.Text = "MAC"
        '
        'cmbStatus
        '
        Me.cmbStatus.FormattingEnabled = True
        Me.cmbStatus.Location = New System.Drawing.Point(138, 175)
        Me.cmbStatus.Name = "cmbStatus"
        Me.cmbStatus.Size = New System.Drawing.Size(236, 21)
        Me.cmbStatus.TabIndex = 5
        '
        'cmbType
        '
        Me.cmbType.FormattingEnabled = True
        Me.cmbType.Location = New System.Drawing.Point(304, 97)
        Me.cmbType.Name = "cmbType"
        Me.cmbType.Size = New System.Drawing.Size(70, 21)
        Me.cmbType.TabIndex = 1
        '
        'txtTerminalDescription
        '
        Me.txtTerminalDescription.Location = New System.Drawing.Point(138, 123)
        Me.txtTerminalDescription.Name = "txtTerminalDescription"
        Me.txtTerminalDescription.Size = New System.Drawing.Size(236, 20)
        Me.txtTerminalDescription.TabIndex = 2
        '
        'txtTerminalSerial
        '
        Me.txtTerminalSerial.Location = New System.Drawing.Point(138, 149)
        Me.txtTerminalSerial.Name = "txtTerminalSerial"
        Me.txtTerminalSerial.Size = New System.Drawing.Size(160, 20)
        Me.txtTerminalSerial.TabIndex = 3
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(58, 178)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(37, 13)
        Me.Label16.TabIndex = 143
        Me.Label16.Text = "Status"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(58, 126)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 13)
        Me.Label4.TabIndex = 141
        Me.Label4.Text = "Description"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(267, 100)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 13)
        Me.Label3.TabIndex = 140
        Me.Label3.Text = "Type"
        '
        'txtTerminalID
        '
        Me.txtTerminalID.Location = New System.Drawing.Point(138, 97)
        Me.txtTerminalID.Name = "txtTerminalID"
        Me.txtTerminalID.Size = New System.Drawing.Size(96, 20)
        Me.txtTerminalID.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(58, 100)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 13)
        Me.Label2.TabIndex = 139
        Me.Label2.Text = "Terminal ID"
        '
        'GroupBox2
        '
        Me.GroupBox2.Location = New System.Drawing.Point(12, 473)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(668, 8)
        Me.GroupBox2.TabIndex = 11
        Me.GroupBox2.TabStop = False
        '
        'txtPetcCode
        '
        Me.txtPetcCode.Location = New System.Drawing.Point(480, 97)
        Me.txtPetcCode.Name = "txtPetcCode"
        Me.txtPetcCode.Size = New System.Drawing.Size(74, 20)
        Me.txtPetcCode.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(411, 100)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 13)
        Me.Label5.TabIndex = 149
        Me.Label5.Text = "PETC Code"
        '
        'cmdBrowsePetc
        '
        Me.cmdBrowsePetc.Location = New System.Drawing.Point(560, 97)
        Me.cmdBrowsePetc.Name = "cmdBrowsePetc"
        Me.cmdBrowsePetc.Size = New System.Drawing.Size(58, 20)
        Me.cmdBrowsePetc.TabIndex = 7
        Me.cmdBrowsePetc.Text = "browse"
        Me.cmdBrowsePetc.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Location = New System.Drawing.Point(10, 264)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(668, 8)
        Me.GroupBox3.TabIndex = 152
        Me.GroupBox3.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(31, 227)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(323, 24)
        Me.Label6.TabIndex = 151
        Me.Label6.Text = "Please enter Machine information"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(58, 321)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(75, 13)
        Me.Label8.TabIndex = 156
        Me.Label8.Text = "Machine serial"
        '
        'txtMachineDescription
        '
        Me.txtMachineDescription.Location = New System.Drawing.Point(138, 292)
        Me.txtMachineDescription.Name = "txtMachineDescription"
        Me.txtMachineDescription.Size = New System.Drawing.Size(236, 20)
        Me.txtMachineDescription.TabIndex = 12
        '
        'txtMachineSerial
        '
        Me.txtMachineSerial.Location = New System.Drawing.Point(138, 318)
        Me.txtMachineSerial.Name = "txtMachineSerial"
        Me.txtMachineSerial.Size = New System.Drawing.Size(236, 20)
        Me.txtMachineSerial.TabIndex = 13
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(58, 295)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(60, 13)
        Me.Label9.TabIndex = 155
        Me.Label9.Text = "Description"
        '
        'txtDateCalibrated
        '
        Me.txtDateCalibrated.Location = New System.Drawing.Point(521, 292)
        Me.txtDateCalibrated.Name = "txtDateCalibrated"
        Me.txtDateCalibrated.Size = New System.Drawing.Size(97, 20)
        Me.txtDateCalibrated.TabIndex = 14
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(411, 295)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(104, 13)
        Me.Label10.TabIndex = 158
        Me.Label10.Text = "Calibration expiration"
        '
        'txtTerminalLane
        '
        Me.txtTerminalLane.Location = New System.Drawing.Point(480, 175)
        Me.txtTerminalLane.Name = "txtTerminalLane"
        Me.txtTerminalLane.Size = New System.Drawing.Size(138, 20)
        Me.txtTerminalLane.TabIndex = 10
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(411, 178)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(49, 13)
        Me.Label11.TabIndex = 160
        Me.Label11.Text = "Lane no."
        '
        'chkLocked
        '
        Me.chkLocked.AutoSize = True
        Me.chkLocked.Location = New System.Drawing.Point(480, 201)
        Me.chkLocked.Name = "chkLocked"
        Me.chkLocked.Size = New System.Drawing.Size(62, 17)
        Me.chkLocked.TabIndex = 11
        Me.chkLocked.Text = "Locked"
        Me.chkLocked.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.txtMachineDLL)
        Me.GroupBox4.Controls.Add(Me.Label18)
        Me.GroupBox4.Controls.Add(Me.cmbMachineStopBits)
        Me.GroupBox4.Controls.Add(Me.Label17)
        Me.GroupBox4.Controls.Add(Me.cmbMachineParity)
        Me.GroupBox4.Controls.Add(Me.Label15)
        Me.GroupBox4.Controls.Add(Me.cmbMachineBaud)
        Me.GroupBox4.Controls.Add(Me.Label14)
        Me.GroupBox4.Controls.Add(Me.cmbMachinePort)
        Me.GroupBox4.Controls.Add(Me.Label12)
        Me.GroupBox4.Controls.Add(Me.cmbMachineBits)
        Me.GroupBox4.Controls.Add(Me.Label13)
        Me.GroupBox4.Location = New System.Drawing.Point(37, 356)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(609, 95)
        Me.GroupBox4.TabIndex = 15
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Machine Settings:"
        '
        'txtMachineDLL
        '
        Me.txtMachineDLL.Location = New System.Drawing.Point(89, 56)
        Me.txtMachineDLL.Name = "txtMachineDLL"
        Me.txtMachineDLL.Size = New System.Drawing.Size(73, 20)
        Me.txtMachineDLL.TabIndex = 17
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(21, 59)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(43, 13)
        Me.Label18.TabIndex = 176
        Me.Label18.Text = "DLL file"
        '
        'cmbMachineStopBits
        '
        Me.cmbMachineStopBits.FormattingEnabled = True
        Me.cmbMachineStopBits.Location = New System.Drawing.Point(459, 56)
        Me.cmbMachineStopBits.Name = "cmbMachineStopBits"
        Me.cmbMachineStopBits.Size = New System.Drawing.Size(122, 21)
        Me.cmbMachineStopBits.TabIndex = 21
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(405, 59)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(48, 13)
        Me.Label17.TabIndex = 174
        Me.Label17.Text = "Stop bits"
        '
        'cmbMachineParity
        '
        Me.cmbMachineParity.FormattingEnabled = True
        Me.cmbMachineParity.Location = New System.Drawing.Point(459, 29)
        Me.cmbMachineParity.Name = "cmbMachineParity"
        Me.cmbMachineParity.Size = New System.Drawing.Size(122, 21)
        Me.cmbMachineParity.TabIndex = 20
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(405, 32)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(33, 13)
        Me.Label15.TabIndex = 172
        Me.Label15.Text = "Pairty"
        '
        'cmbMachineBaud
        '
        Me.cmbMachineBaud.FormattingEnabled = True
        Me.cmbMachineBaud.Location = New System.Drawing.Point(254, 29)
        Me.cmbMachineBaud.Name = "cmbMachineBaud"
        Me.cmbMachineBaud.Size = New System.Drawing.Size(122, 21)
        Me.cmbMachineBaud.TabIndex = 18
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(195, 32)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(53, 13)
        Me.Label14.TabIndex = 170
        Me.Label14.Text = "Baud rate"
        '
        'cmbMachinePort
        '
        Me.cmbMachinePort.FormattingEnabled = True
        Me.cmbMachinePort.Location = New System.Drawing.Point(89, 29)
        Me.cmbMachinePort.Name = "cmbMachinePort"
        Me.cmbMachinePort.Size = New System.Drawing.Size(73, 21)
        Me.cmbMachinePort.TabIndex = 16
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(21, 32)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(52, 13)
        Me.Label12.TabIndex = 168
        Me.Label12.Text = "COM port"
        '
        'cmbMachineBits
        '
        Me.cmbMachineBits.FormattingEnabled = True
        Me.cmbMachineBits.Location = New System.Drawing.Point(254, 56)
        Me.cmbMachineBits.Name = "cmbMachineBits"
        Me.cmbMachineBits.Size = New System.Drawing.Size(122, 21)
        Me.cmbMachineBits.TabIndex = 19
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(195, 59)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(49, 13)
        Me.Label13.TabIndex = 166
        Me.Label13.Text = "Data bits"
        '
        'chkScsiSas
        '
        Me.chkScsiSas.AutoSize = True
        Me.chkScsiSas.Location = New System.Drawing.Point(304, 151)
        Me.chkScsiSas.Name = "chkScsiSas"
        Me.chkScsiSas.Size = New System.Drawing.Size(76, 17)
        Me.chkScsiSas.TabIndex = 4
        Me.chkScsiSas.Text = "SCSI/SAS"
        Me.chkScsiSas.UseVisualStyleBackColor = True
        '
        'frmTerminalsManagerAddEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(688, 579)
        Me.ControlBox = False
        Me.Controls.Add(Me.chkScsiSas)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.chkLocked)
        Me.Controls.Add(Me.txtTerminalLane)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtDateCalibrated)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtMachineDescription)
        Me.Controls.Add(Me.txtMachineSerial)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cmdBrowsePetc)
        Me.Controls.Add(Me.txtPetcCode)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.txtTerminalIP)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.txtTerminalMac)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.cmbStatus)
        Me.Controls.Add(Me.cmbType)
        Me.Controls.Add(Me.txtTerminalDescription)
        Me.Controls.Add(Me.txtTerminalSerial)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtTerminalID)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmdRefreshPredefinedData)
        Me.Controls.Add(Me.lblStatusPrompt)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdProcess)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmTerminalsManagerAddEdit"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ADD/EDIT TERMINAL"
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
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
    Friend WithEvents txtTerminalIP As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtTerminalMac As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmbStatus As System.Windows.Forms.ComboBox
    Friend WithEvents cmbType As System.Windows.Forms.ComboBox
    Friend WithEvents txtTerminalDescription As System.Windows.Forms.TextBox
    Friend WithEvents txtTerminalSerial As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtTerminalID As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtPetcCode As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmdBrowsePetc As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtMachineDescription As System.Windows.Forms.TextBox
    Friend WithEvents txtMachineSerial As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtDateCalibrated As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtTerminalLane As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents chkLocked As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbMachineStopBits As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cmbMachineParity As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cmbMachineBaud As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cmbMachinePort As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cmbMachineBits As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtMachineDLL As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents chkScsiSas As System.Windows.Forms.CheckBox
End Class
