<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRegionsProvincesCitiesAddEntry
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
        Me.lblProvince = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblRegion = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtData = New System.Windows.Forms.TextBox()
        Me.lblLogisticDescription = New System.Windows.Forms.Label()
        Me.cmbRegion = New System.Windows.Forms.ComboBox()
        Me.cmbProvince = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(478, 24)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Please select Logicstic information"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(12, 60)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(478, 8)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        '
        'cmdProcess
        '
        Me.cmdProcess.Enabled = False
        Me.cmdProcess.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdProcess.Location = New System.Drawing.Point(255, 359)
        Me.cmdProcess.Name = "cmdProcess"
        Me.cmdProcess.Size = New System.Drawing.Size(111, 39)
        Me.cmdProcess.TabIndex = 6
        Me.cmdProcess.Text = "CREATE"
        Me.cmdProcess.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancel.Location = New System.Drawing.Point(372, 359)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(104, 39)
        Me.cmdCancel.TabIndex = 7
        Me.cmdCancel.Text = "&CANCEL"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'lblStatusPrompt
        '
        Me.lblStatusPrompt.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblStatusPrompt.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatusPrompt.ForeColor = System.Drawing.Color.White
        Me.lblStatusPrompt.Location = New System.Drawing.Point(0, 415)
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
        Me.cmdRefreshPredefinedData.Location = New System.Drawing.Point(25, 358)
        Me.cmdRefreshPredefinedData.Name = "cmdRefreshPredefinedData"
        Me.cmdRefreshPredefinedData.Size = New System.Drawing.Size(224, 39)
        Me.cmdRefreshPredefinedData.TabIndex = 5
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
        'lblProvince
        '
        Me.lblProvince.AutoSize = True
        Me.lblProvince.Location = New System.Drawing.Point(89, 131)
        Me.lblProvince.Name = "lblProvince"
        Me.lblProvince.Size = New System.Drawing.Size(49, 13)
        Me.lblProvince.TabIndex = 141
        Me.lblProvince.Text = "Province"
        '
        'GroupBox2
        '
        Me.GroupBox2.Location = New System.Drawing.Point(12, 331)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(478, 8)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        '
        'lblRegion
        '
        Me.lblRegion.AutoSize = True
        Me.lblRegion.Location = New System.Drawing.Point(89, 105)
        Me.lblRegion.Name = "lblRegion"
        Me.lblRegion.Size = New System.Drawing.Size(41, 13)
        Me.lblRegion.TabIndex = 149
        Me.lblRegion.Text = "Region"
        '
        'GroupBox3
        '
        Me.GroupBox3.Location = New System.Drawing.Point(10, 223)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(480, 8)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(12, 186)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(478, 24)
        Me.Label6.TabIndex = 151
        Me.Label6.Text = "Please enter new Logistic information"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtData
        '
        Me.txtData.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtData.Location = New System.Drawing.Point(61, 275)
        Me.txtData.Name = "txtData"
        Me.txtData.Size = New System.Drawing.Size(379, 26)
        Me.txtData.TabIndex = 3
        '
        'lblLogisticDescription
        '
        Me.lblLogisticDescription.AutoSize = True
        Me.lblLogisticDescription.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLogisticDescription.Location = New System.Drawing.Point(58, 256)
        Me.lblLogisticDescription.Name = "lblLogisticDescription"
        Me.lblLogisticDescription.Size = New System.Drawing.Size(121, 16)
        Me.lblLogisticDescription.TabIndex = 173
        Me.lblLogisticDescription.Text = "New logistic data:"
        '
        'cmbRegion
        '
        Me.cmbRegion.FormattingEnabled = True
        Me.cmbRegion.Location = New System.Drawing.Point(160, 102)
        Me.cmbRegion.Name = "cmbRegion"
        Me.cmbRegion.Size = New System.Drawing.Size(245, 21)
        Me.cmbRegion.TabIndex = 0
        '
        'cmbProvince
        '
        Me.cmbProvince.FormattingEnabled = True
        Me.cmbProvince.Location = New System.Drawing.Point(160, 128)
        Me.cmbProvince.Name = "cmbProvince"
        Me.cmbProvince.Size = New System.Drawing.Size(245, 21)
        Me.cmbProvince.TabIndex = 1
        '
        'frmRegionsProvincesCitiesAddEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(502, 437)
        Me.ControlBox = False
        Me.Controls.Add(Me.cmbProvince)
        Me.Controls.Add(Me.cmbRegion)
        Me.Controls.Add(Me.txtData)
        Me.Controls.Add(Me.lblLogisticDescription)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.lblRegion)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.lblProvince)
        Me.Controls.Add(Me.cmdRefreshPredefinedData)
        Me.Controls.Add(Me.lblStatusPrompt)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdProcess)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmRegionsProvincesCitiesAddEntry"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ADD/EDIT LOGISTIC ENTRY"
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
    Friend WithEvents lblProvince As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lblRegion As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtData As System.Windows.Forms.TextBox
    Friend WithEvents lblLogisticDescription As System.Windows.Forms.Label
    Friend WithEvents cmbRegion As System.Windows.Forms.ComboBox
    Friend WithEvents cmbProvince As System.Windows.Forms.ComboBox
End Class
