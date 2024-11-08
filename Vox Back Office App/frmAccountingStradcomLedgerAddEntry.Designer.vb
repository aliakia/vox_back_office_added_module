<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAccountingStradcomLedgerAddEntry
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
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtLedgerCode = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtRemarks = New System.Windows.Forms.TextBox()
        Me.txtLedgerDescription = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtPaymentDetails = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtDateDeposited = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtAmount = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cmbType = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtSuppID = New System.Windows.Forms.TextBox()
        Me.txtAccountNo = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbBank = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(33, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(345, 24)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Please enter Accounting information"
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
        Me.cmdProcess.Location = New System.Drawing.Point(363, 396)
        Me.cmdProcess.Name = "cmdProcess"
        Me.cmdProcess.Size = New System.Drawing.Size(142, 39)
        Me.cmdProcess.TabIndex = 11
        Me.cmdProcess.Text = "CREATE"
        Me.cmdProcess.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancel.Location = New System.Drawing.Point(511, 396)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(135, 39)
        Me.cmdCancel.TabIndex = 12
        Me.cmdCancel.Text = "&CANCEL"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'lblStatusPrompt
        '
        Me.lblStatusPrompt.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblStatusPrompt.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatusPrompt.ForeColor = System.Drawing.Color.White
        Me.lblStatusPrompt.Location = New System.Drawing.Point(0, 453)
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
        Me.cmdRefreshPredefinedData.Location = New System.Drawing.Point(61, 395)
        Me.cmdRefreshPredefinedData.Name = "cmdRefreshPredefinedData"
        Me.cmdRefreshPredefinedData.Size = New System.Drawing.Size(224, 39)
        Me.cmdRefreshPredefinedData.TabIndex = 10
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
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(215, 157)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(60, 13)
        Me.Label21.TabIndex = 145
        Me.Label21.Text = "Description"
        '
        'txtLedgerCode
        '
        Me.txtLedgerCode.Location = New System.Drawing.Point(129, 154)
        Me.txtLedgerCode.Name = "txtLedgerCode"
        Me.txtLedgerCode.Size = New System.Drawing.Size(83, 20)
        Me.txtLedgerCode.TabIndex = 2
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(58, 157)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(67, 13)
        Me.Label7.TabIndex = 144
        Me.Label7.Text = "Ledger code"
        '
        'txtRemarks
        '
        Me.txtRemarks.Location = New System.Drawing.Point(129, 128)
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(517, 20)
        Me.txtRemarks.TabIndex = 1
        '
        'txtLedgerDescription
        '
        Me.txtLedgerDescription.Location = New System.Drawing.Point(281, 154)
        Me.txtLedgerDescription.Name = "txtLedgerDescription"
        Me.txtLedgerDescription.Size = New System.Drawing.Size(365, 20)
        Me.txtLedgerDescription.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(58, 131)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 13)
        Me.Label4.TabIndex = 141
        Me.Label4.Text = "Remarks"
        '
        'GroupBox2
        '
        Me.GroupBox2.Location = New System.Drawing.Point(12, 369)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(668, 8)
        Me.GroupBox2.TabIndex = 11
        Me.GroupBox2.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(58, 105)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 13)
        Me.Label5.TabIndex = 149
        Me.Label5.Text = "Supplier ID"
        '
        'GroupBox3
        '
        Me.GroupBox3.Location = New System.Drawing.Point(10, 252)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(668, 8)
        Me.GroupBox3.TabIndex = 152
        Me.GroupBox3.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(31, 215)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(326, 24)
        Me.Label6.TabIndex = 151
        Me.Label6.Text = "Please enter Payment information"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(399, 309)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(58, 13)
        Me.Label8.TabIndex = 156
        Me.Label8.Text = "Pay details"
        '
        'txtPaymentDetails
        '
        Me.txtPaymentDetails.Location = New System.Drawing.Point(511, 306)
        Me.txtPaymentDetails.Name = "txtPaymentDetails"
        Me.txtPaymentDetails.Size = New System.Drawing.Size(135, 20)
        Me.txtPaymentDetails.TabIndex = 8
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(58, 309)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(32, 13)
        Me.Label9.TabIndex = 155
        Me.Label9.Text = "Bank"
        '
        'txtDateDeposited
        '
        Me.txtDateDeposited.Location = New System.Drawing.Point(173, 280)
        Me.txtDateDeposited.Name = "txtDateDeposited"
        Me.txtDateDeposited.Size = New System.Drawing.Size(201, 20)
        Me.txtDateDeposited.TabIndex = 4
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(58, 283)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(109, 13)
        Me.Label10.TabIndex = 158
        Me.Label10.Text = "Date/time of payment"
        '
        'txtAmount
        '
        Me.txtAmount.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAmount.Location = New System.Drawing.Point(511, 332)
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.Size = New System.Drawing.Size(135, 26)
        Me.txtAmount.TabIndex = 9
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(399, 338)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(103, 15)
        Me.Label11.TabIndex = 160
        Me.Label11.Text = "Payment amount"
        '
        'cmbType
        '
        Me.cmbType.FormattingEnabled = True
        Me.cmbType.Location = New System.Drawing.Point(511, 280)
        Me.cmbType.Name = "cmbType"
        Me.cmbType.Size = New System.Drawing.Size(135, 21)
        Me.cmbType.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(399, 283)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 13)
        Me.Label2.TabIndex = 162
        Me.Label2.Text = "Pay type"
        '
        'txtSuppID
        '
        Me.txtSuppID.Location = New System.Drawing.Point(129, 102)
        Me.txtSuppID.Name = "txtSuppID"
        Me.txtSuppID.Size = New System.Drawing.Size(83, 20)
        Me.txtSuppID.TabIndex = 0
        '
        'txtAccountNo
        '
        Me.txtAccountNo.Location = New System.Drawing.Point(129, 332)
        Me.txtAccountNo.Name = "txtAccountNo"
        Me.txtAccountNo.Size = New System.Drawing.Size(245, 20)
        Me.txtAccountNo.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(58, 335)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 13)
        Me.Label3.TabIndex = 164
        Me.Label3.Text = "Account no."
        '
        'cmbBank
        '
        Me.cmbBank.FormattingEnabled = True
        Me.cmbBank.Location = New System.Drawing.Point(129, 306)
        Me.cmbBank.Name = "cmbBank"
        Me.cmbBank.Size = New System.Drawing.Size(245, 21)
        Me.cmbBank.TabIndex = 5
        '
        'frmAccountingStradcomLedgerAddEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(688, 475)
        Me.ControlBox = False
        Me.Controls.Add(Me.cmbBank)
        Me.Controls.Add(Me.txtAccountNo)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtSuppID)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmbType)
        Me.Controls.Add(Me.txtAmount)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtDateDeposited)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtPaymentDetails)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.txtLedgerCode)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtRemarks)
        Me.Controls.Add(Me.txtLedgerDescription)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cmdRefreshPredefinedData)
        Me.Controls.Add(Me.lblStatusPrompt)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdProcess)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmAccountingStradcomLedgerAddEntry"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ADD/EDIT ACCOUNTING ENTRY"
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
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtLedgerCode As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtRemarks As System.Windows.Forms.TextBox
    Friend WithEvents txtLedgerDescription As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtPaymentDetails As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtDateDeposited As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cmbType As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtSuppID As System.Windows.Forms.TextBox
    Friend WithEvents txtAccountNo As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbBank As System.Windows.Forms.ComboBox
End Class
