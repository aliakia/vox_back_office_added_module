<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMaintenanceEWalletPetc
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
        Me.lsvItems = New System.Windows.Forms.ListView()
        Me.cmdCheckBalance = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.lblHeader = New System.Windows.Forms.Label()
        Me.lblStatusPrompt = New System.Windows.Forms.Label()
        Me.grpFilters = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtPetcCode = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtDateFrom = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdReserved = New System.Windows.Forms.Button()
        Me.timerCheckPerTransBalance = New System.Windows.Forms.Timer(Me.components)
        Me.lsvPetc = New System.Windows.Forms.ListView()
        Me.chkCorrect = New System.Windows.Forms.CheckBox()
        Me.chkShowErrorOnly = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.grpFilters.SuspendLayout()
        Me.SuspendLayout()
        '
        'lsvItems
        '
        Me.lsvItems.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lsvItems.FullRowSelect = True
        Me.lsvItems.GridLines = True
        Me.lsvItems.Location = New System.Drawing.Point(15, 260)
        Me.lsvItems.Name = "lsvItems"
        Me.lsvItems.Size = New System.Drawing.Size(771, 234)
        Me.lsvItems.TabIndex = 0
        Me.lsvItems.UseCompatibleStateImageBehavior = False
        Me.lsvItems.View = System.Windows.Forms.View.Details
        '
        'cmdCheckBalance
        '
        Me.cmdCheckBalance.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCheckBalance.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCheckBalance.Location = New System.Drawing.Point(519, 500)
        Me.cmdCheckBalance.Name = "cmdCheckBalance"
        Me.cmdCheckBalance.Size = New System.Drawing.Size(267, 40)
        Me.cmdCheckBalance.TabIndex = 9
        Me.cmdCheckBalance.Text = "&CHECK PER TRANSACTION BALANCE"
        Me.cmdCheckBalance.UseVisualStyleBackColor = True
        '
        'cmdClose
        '
        Me.cmdClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClose.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClose.Location = New System.Drawing.Point(701, 546)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(85, 40)
        Me.cmdClose.TabIndex = 14
        Me.cmdClose.Text = "&CLOSE"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'lblHeader
        '
        Me.lblHeader.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblHeader.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblHeader.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeader.ForeColor = System.Drawing.Color.Cornsilk
        Me.lblHeader.Location = New System.Drawing.Point(0, 0)
        Me.lblHeader.Name = "lblHeader"
        Me.lblHeader.Padding = New System.Windows.Forms.Padding(5)
        Me.lblHeader.Size = New System.Drawing.Size(800, 29)
        Me.lblHeader.TabIndex = 3
        Me.lblHeader.Text = "PETC E-wallet Maintenance"
        '
        'lblStatusPrompt
        '
        Me.lblStatusPrompt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblStatusPrompt.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblStatusPrompt.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblStatusPrompt.Location = New System.Drawing.Point(265, 2)
        Me.lblStatusPrompt.Name = "lblStatusPrompt"
        Me.lblStatusPrompt.Size = New System.Drawing.Size(521, 23)
        Me.lblStatusPrompt.TabIndex = 4
        Me.lblStatusPrompt.Text = "Prompt"
        Me.lblStatusPrompt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblStatusPrompt.Visible = False
        '
        'grpFilters
        '
        Me.grpFilters.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpFilters.Controls.Add(Me.chkCorrect)
        Me.grpFilters.Controls.Add(Me.chkShowErrorOnly)
        Me.grpFilters.Controls.Add(Me.Button1)
        Me.grpFilters.Controls.Add(Me.txtPetcCode)
        Me.grpFilters.Controls.Add(Me.Label2)
        Me.grpFilters.Controls.Add(Me.txtDateFrom)
        Me.grpFilters.Controls.Add(Me.Label1)
        Me.grpFilters.Location = New System.Drawing.Point(12, 500)
        Me.grpFilters.Name = "grpFilters"
        Me.grpFilters.Size = New System.Drawing.Size(501, 86)
        Me.grpFilters.TabIndex = 1
        Me.grpFilters.TabStop = False
        Me.grpFilters.Text = "Processing options:"
        '
        'Button1
        '
        Me.Button1.Enabled = False
        Me.Button1.Location = New System.Drawing.Point(173, 51)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 20)
        Me.Button1.TabIndex = 30
        Me.Button1.Text = "browse"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtPetcCode
        '
        Me.txtPetcCode.Location = New System.Drawing.Point(92, 51)
        Me.txtPetcCode.Name = "txtPetcCode"
        Me.txtPetcCode.Size = New System.Drawing.Size(75, 20)
        Me.txtPetcCode.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(20, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 13)
        Me.Label2.TabIndex = 25
        Me.Label2.Text = "PETC Code"
        '
        'txtDateFrom
        '
        Me.txtDateFrom.Location = New System.Drawing.Point(92, 25)
        Me.txtDateFrom.Name = "txtDateFrom"
        Me.txtDateFrom.Size = New System.Drawing.Size(75, 20)
        Me.txtDateFrom.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(20, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 13)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "Date from"
        '
        'cmdReserved
        '
        Me.cmdReserved.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdReserved.Enabled = False
        Me.cmdReserved.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.cmdReserved.Location = New System.Drawing.Point(519, 546)
        Me.cmdReserved.Name = "cmdReserved"
        Me.cmdReserved.Size = New System.Drawing.Size(176, 40)
        Me.cmdReserved.TabIndex = 28
        Me.cmdReserved.Text = "Reserved"
        Me.cmdReserved.UseVisualStyleBackColor = True
        '
        'timerCheckPerTransBalance
        '
        Me.timerCheckPerTransBalance.Interval = 1
        '
        'lsvPetc
        '
        Me.lsvPetc.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lsvPetc.FullRowSelect = True
        Me.lsvPetc.GridLines = True
        Me.lsvPetc.Location = New System.Drawing.Point(15, 28)
        Me.lsvPetc.Name = "lsvPetc"
        Me.lsvPetc.Size = New System.Drawing.Size(771, 190)
        Me.lsvPetc.TabIndex = 29
        Me.lsvPetc.UseCompatibleStateImageBehavior = False
        Me.lsvPetc.View = System.Windows.Forms.View.Details
        '
        'chkCorrect
        '
        Me.chkCorrect.AutoSize = True
        Me.chkCorrect.Location = New System.Drawing.Point(357, 52)
        Me.chkCorrect.Name = "chkCorrect"
        Me.chkCorrect.Size = New System.Drawing.Size(119, 17)
        Me.chkCorrect.TabIndex = 33
        Me.chkCorrect.Text = "Correct errors found"
        Me.chkCorrect.UseVisualStyleBackColor = True
        '
        'chkShowErrorOnly
        '
        Me.chkShowErrorOnly.AutoSize = True
        Me.chkShowErrorOnly.Checked = True
        Me.chkShowErrorOnly.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkShowErrorOnly.Location = New System.Drawing.Point(357, 27)
        Me.chkShowErrorOnly.Name = "chkShowErrorOnly"
        Me.chkShowErrorOnly.Size = New System.Drawing.Size(121, 17)
        Me.chkShowErrorOnly.TabIndex = 32
        Me.chkShowErrorOnly.Text = "Show only with error"
        Me.chkShowErrorOnly.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Cornsilk
        Me.Label3.Location = New System.Drawing.Point(0, 232)
        Me.Label3.Name = "Label3"
        Me.Label3.Padding = New System.Windows.Forms.Padding(5)
        Me.Label3.Size = New System.Drawing.Size(800, 29)
        Me.Label3.TabIndex = 30
        Me.Label3.Text = "Details"
        '
        'frmMaintenanceEWalletPetc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(798, 598)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lsvPetc)
        Me.Controls.Add(Me.cmdReserved)
        Me.Controls.Add(Me.grpFilters)
        Me.Controls.Add(Me.lblStatusPrompt)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.cmdCheckBalance)
        Me.Controls.Add(Me.lsvItems)
        Me.Controls.Add(Me.lblHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmMaintenanceEWalletPetc"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.grpFilters.ResumeLayout(False)
        Me.grpFilters.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lsvItems As System.Windows.Forms.ListView
    Friend WithEvents cmdCheckBalance As System.Windows.Forms.Button
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents lblHeader As System.Windows.Forms.Label
    Friend WithEvents lblStatusPrompt As System.Windows.Forms.Label
    Friend WithEvents grpFilters As System.Windows.Forms.GroupBox
    Friend WithEvents txtDateFrom As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtPetcCode As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents cmdReserved As System.Windows.Forms.Button
    Friend WithEvents timerCheckPerTransBalance As System.Windows.Forms.Timer
    Friend WithEvents lsvPetc As System.Windows.Forms.ListView
    Friend WithEvents chkCorrect As System.Windows.Forms.CheckBox
    Friend WithEvents chkShowErrorOnly As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
