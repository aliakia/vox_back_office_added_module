<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmToolsMonitoringReport
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
        Me.cmdPrint = New System.Windows.Forms.Button()
        Me.cmdOptions = New System.Windows.Forms.Button()
        Me.grpFilters = New System.Windows.Forms.GroupBox()
        Me.lsvPetcSummary = New System.Windows.Forms.ListView()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmdRefresh = New System.Windows.Forms.Button()
        Me.lblStatusPrompt = New System.Windows.Forms.Label()
        Me.timerDataLoad = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lsvItems = New System.Windows.Forms.ListView()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.chkPetcBalancesWithBalance = New System.Windows.Forms.CheckBox()
        Me.chkPetcBalancesActiveOnly = New System.Windows.Forms.CheckBox()
        Me.lsvPetcBalances = New System.Windows.Forms.ListView()
        Me.txtPetcCode = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.lblDate2 = New System.Windows.Forms.Label()
        Me.lblDate1 = New System.Windows.Forms.Label()
        Me.txtDateFrom = New System.Windows.Forms.TextBox()
        Me.txtDateTo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtAutoRefreshInterval = New System.Windows.Forms.TextBox()
        Me.chkAutoRefresh = New System.Windows.Forms.CheckBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.txtSystemMessages = New System.Windows.Forms.TextBox()
        Me.timerAutoRefresh = New System.Windows.Forms.Timer(Me.components)
        Me.grpFilters.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Enabled = False
        Me.cmdPrint.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPrint.Location = New System.Drawing.Point(710, 14)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(85, 40)
        Me.cmdPrint.TabIndex = 17
        Me.cmdPrint.Text = "PRINT"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'cmdOptions
        '
        Me.cmdOptions.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdOptions.Enabled = False
        Me.cmdOptions.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOptions.Location = New System.Drawing.Point(801, 14)
        Me.cmdOptions.Name = "cmdOptions"
        Me.cmdOptions.Size = New System.Drawing.Size(85, 40)
        Me.cmdOptions.TabIndex = 18
        Me.cmdOptions.Text = "OPTIONS"
        Me.cmdOptions.UseVisualStyleBackColor = True
        '
        'grpFilters
        '
        Me.grpFilters.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpFilters.Controls.Add(Me.lsvPetcSummary)
        Me.grpFilters.Location = New System.Drawing.Point(12, 12)
        Me.grpFilters.Name = "grpFilters"
        Me.grpFilters.Size = New System.Drawing.Size(532, 552)
        Me.grpFilters.TabIndex = 15
        Me.grpFilters.TabStop = False
        Me.grpFilters.Text = "PETC Uploads"
        '
        'lsvPetcSummary
        '
        Me.lsvPetcSummary.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lsvPetcSummary.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lsvPetcSummary.FullRowSelect = True
        Me.lsvPetcSummary.GridLines = True
        Me.lsvPetcSummary.Location = New System.Drawing.Point(14, 21)
        Me.lsvPetcSummary.Name = "lsvPetcSummary"
        Me.lsvPetcSummary.Size = New System.Drawing.Size(505, 519)
        Me.lsvPetcSummary.TabIndex = 31
        Me.lsvPetcSummary.UseCompatibleStateImageBehavior = False
        Me.lsvPetcSummary.View = System.Windows.Forms.View.Details
        Me.lsvPetcSummary.Visible = False
        '
        'cmdClose
        '
        Me.cmdClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClose.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClose.Location = New System.Drawing.Point(892, 14)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(85, 40)
        Me.cmdClose.TabIndex = 19
        Me.cmdClose.Text = "&CLOSE"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'cmdRefresh
        '
        Me.cmdRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdRefresh.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdRefresh.Location = New System.Drawing.Point(407, 14)
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.Size = New System.Drawing.Size(85, 40)
        Me.cmdRefresh.TabIndex = 16
        Me.cmdRefresh.Text = "&REFRESH"
        Me.cmdRefresh.UseVisualStyleBackColor = True
        '
        'lblStatusPrompt
        '
        Me.lblStatusPrompt.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblStatusPrompt.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblStatusPrompt.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatusPrompt.ForeColor = System.Drawing.Color.White
        Me.lblStatusPrompt.Location = New System.Drawing.Point(-1, 640)
        Me.lblStatusPrompt.Name = "lblStatusPrompt"
        Me.lblStatusPrompt.Padding = New System.Windows.Forms.Padding(3)
        Me.lblStatusPrompt.Size = New System.Drawing.Size(1011, 23)
        Me.lblStatusPrompt.TabIndex = 28
        Me.lblStatusPrompt.Text = "OPTIONS:"
        Me.lblStatusPrompt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'timerDataLoad
        '
        Me.timerDataLoad.Interval = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.lsvItems)
        Me.GroupBox1.Location = New System.Drawing.Point(550, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(446, 296)
        Me.GroupBox1.TabIndex = 29
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Totals"
        '
        'lsvItems
        '
        Me.lsvItems.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lsvItems.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lsvItems.FullRowSelect = True
        Me.lsvItems.GridLines = True
        Me.lsvItems.Location = New System.Drawing.Point(14, 21)
        Me.lsvItems.Name = "lsvItems"
        Me.lsvItems.Size = New System.Drawing.Size(419, 261)
        Me.lsvItems.TabIndex = 31
        Me.lsvItems.UseCompatibleStateImageBehavior = False
        Me.lsvItems.View = System.Windows.Forms.View.Details
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.chkPetcBalancesWithBalance)
        Me.GroupBox2.Controls.Add(Me.chkPetcBalancesActiveOnly)
        Me.GroupBox2.Controls.Add(Me.lsvPetcBalances)
        Me.GroupBox2.Location = New System.Drawing.Point(550, 467)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(446, 97)
        Me.GroupBox2.TabIndex = 34
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "PETC Balance (current)"
        '
        'chkPetcBalancesWithBalance
        '
        Me.chkPetcBalancesWithBalance.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkPetcBalancesWithBalance.AutoSize = True
        Me.chkPetcBalancesWithBalance.Location = New System.Drawing.Point(263, 0)
        Me.chkPetcBalancesWithBalance.Name = "chkPetcBalancesWithBalance"
        Me.chkPetcBalancesWithBalance.Size = New System.Drawing.Size(111, 17)
        Me.chkPetcBalancesWithBalance.TabIndex = 34
        Me.chkPetcBalancesWithBalance.Text = "With balance only"
        Me.chkPetcBalancesWithBalance.UseVisualStyleBackColor = True
        '
        'chkPetcBalancesActiveOnly
        '
        Me.chkPetcBalancesActiveOnly.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkPetcBalancesActiveOnly.AutoSize = True
        Me.chkPetcBalancesActiveOnly.Location = New System.Drawing.Point(172, 0)
        Me.chkPetcBalancesActiveOnly.Name = "chkPetcBalancesActiveOnly"
        Me.chkPetcBalancesActiveOnly.Size = New System.Drawing.Size(78, 17)
        Me.chkPetcBalancesActiveOnly.TabIndex = 33
        Me.chkPetcBalancesActiveOnly.Text = "Active only"
        Me.chkPetcBalancesActiveOnly.UseVisualStyleBackColor = True
        '
        'lsvPetcBalances
        '
        Me.lsvPetcBalances.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lsvPetcBalances.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lsvPetcBalances.FullRowSelect = True
        Me.lsvPetcBalances.GridLines = True
        Me.lsvPetcBalances.Location = New System.Drawing.Point(13, 21)
        Me.lsvPetcBalances.Name = "lsvPetcBalances"
        Me.lsvPetcBalances.Size = New System.Drawing.Size(420, 64)
        Me.lsvPetcBalances.TabIndex = 32
        Me.lsvPetcBalances.UseCompatibleStateImageBehavior = False
        Me.lsvPetcBalances.View = System.Windows.Forms.View.Details
        '
        'txtPetcCode
        '
        Me.txtPetcCode.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtPetcCode.Location = New System.Drawing.Point(324, 25)
        Me.txtPetcCode.Name = "txtPetcCode"
        Me.txtPetcCode.Size = New System.Drawing.Size(66, 20)
        Me.txtPetcCode.TabIndex = 39
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(252, 28)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(63, 13)
        Me.Label7.TabIndex = 40
        Me.Label7.Text = "PETC Code"
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.lblDate2)
        Me.GroupBox3.Controls.Add(Me.lblDate1)
        Me.GroupBox3.Controls.Add(Me.txtDateFrom)
        Me.GroupBox3.Controls.Add(Me.txtDateTo)
        Me.GroupBox3.Controls.Add(Me.cmdPrint)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.cmdOptions)
        Me.GroupBox3.Controls.Add(Me.txtPetcCode)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.cmdClose)
        Me.GroupBox3.Controls.Add(Me.cmdRefresh)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.txtAutoRefreshInterval)
        Me.GroupBox3.Controls.Add(Me.chkAutoRefresh)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 570)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(984, 62)
        Me.GroupBox3.TabIndex = 33
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Filters / Options"
        '
        'lblDate2
        '
        Me.lblDate2.AutoSize = True
        Me.lblDate2.Location = New System.Drawing.Point(190, 0)
        Me.lblDate2.Name = "lblDate2"
        Me.lblDate2.Size = New System.Drawing.Size(53, 13)
        Me.lblDate2.TabIndex = 47
        Me.lblDate2.Text = "Date from"
        Me.lblDate2.Visible = False
        '
        'lblDate1
        '
        Me.lblDate1.AutoSize = True
        Me.lblDate1.Location = New System.Drawing.Point(131, 0)
        Me.lblDate1.Name = "lblDate1"
        Me.lblDate1.Size = New System.Drawing.Size(53, 13)
        Me.lblDate1.TabIndex = 46
        Me.lblDate1.Text = "Date from"
        Me.lblDate1.Visible = False
        '
        'txtDateFrom
        '
        Me.txtDateFrom.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtDateFrom.Location = New System.Drawing.Point(75, 25)
        Me.txtDateFrom.Name = "txtDateFrom"
        Me.txtDateFrom.Size = New System.Drawing.Size(66, 20)
        Me.txtDateFrom.TabIndex = 43
        Me.txtDateFrom.Text = "mm/dd/yyyy"
        '
        'txtDateTo
        '
        Me.txtDateTo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtDateTo.Location = New System.Drawing.Point(169, 25)
        Me.txtDateTo.Name = "txtDateTo"
        Me.txtDateTo.Size = New System.Drawing.Size(66, 20)
        Me.txtDateTo.TabIndex = 44
        Me.txtDateTo.Text = "mm/dd/yyyy"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(147, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(16, 13)
        Me.Label2.TabIndex = 45
        Me.Label2.Text = "to"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 13)
        Me.Label1.TabIndex = 42
        Me.Label1.Text = "Date from"
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(646, 28)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 13)
        Me.Label5.TabIndex = 34
        Me.Label5.Text = "minute(s)"
        '
        'txtAutoRefreshInterval
        '
        Me.txtAutoRefreshInterval.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAutoRefreshInterval.Location = New System.Drawing.Point(622, 25)
        Me.txtAutoRefreshInterval.Name = "txtAutoRefreshInterval"
        Me.txtAutoRefreshInterval.Size = New System.Drawing.Size(22, 20)
        Me.txtAutoRefreshInterval.TabIndex = 33
        '
        'chkAutoRefresh
        '
        Me.chkAutoRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkAutoRefresh.AutoSize = True
        Me.chkAutoRefresh.Location = New System.Drawing.Point(511, 27)
        Me.chkAutoRefresh.Name = "chkAutoRefresh"
        Me.chkAutoRefresh.Size = New System.Drawing.Size(112, 17)
        Me.chkAutoRefresh.TabIndex = 32
        Me.chkAutoRefresh.Text = "Auto refresh every"
        Me.chkAutoRefresh.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.txtSystemMessages)
        Me.GroupBox4.Location = New System.Drawing.Point(550, 301)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(446, 171)
        Me.GroupBox4.TabIndex = 35
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "System Messages"
        '
        'txtSystemMessages
        '
        Me.txtSystemMessages.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSystemMessages.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSystemMessages.Location = New System.Drawing.Point(14, 19)
        Me.txtSystemMessages.Multiline = True
        Me.txtSystemMessages.Name = "txtSystemMessages"
        Me.txtSystemMessages.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtSystemMessages.Size = New System.Drawing.Size(419, 140)
        Me.txtSystemMessages.TabIndex = 2
        '
        'timerAutoRefresh
        '
        Me.timerAutoRefresh.Interval = 2500
        '
        'frmToolsMonitoringReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 661)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lblStatusPrompt)
        Me.Controls.Add(Me.grpFilters)
        Me.Name = "frmToolsMonitoringReport"
        Me.Text = "Vox Dei - Tools - Monitoring Screen"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.grpFilters.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdOptions As System.Windows.Forms.Button
    Friend WithEvents grpFilters As System.Windows.Forms.GroupBox
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents cmdRefresh As System.Windows.Forms.Button
    Friend WithEvents lblStatusPrompt As System.Windows.Forms.Label
    Friend WithEvents timerDataLoad As System.Windows.Forms.Timer
    Friend WithEvents lsvPetcSummary As System.Windows.Forms.ListView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lsvItems As System.Windows.Forms.ListView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lsvPetcBalances As System.Windows.Forms.ListView
    Friend WithEvents txtPetcCode As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents lblDate2 As System.Windows.Forms.Label
    Friend WithEvents lblDate1 As System.Windows.Forms.Label
    Friend WithEvents txtDateFrom As System.Windows.Forms.TextBox
    Friend WithEvents txtDateTo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtAutoRefreshInterval As System.Windows.Forms.TextBox
    Friend WithEvents chkAutoRefresh As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents txtSystemMessages As System.Windows.Forms.TextBox
    Friend WithEvents timerAutoRefresh As System.Windows.Forms.Timer
    Friend WithEvents chkPetcBalancesActiveOnly As System.Windows.Forms.CheckBox
    Friend WithEvents chkPetcBalancesWithBalance As System.Windows.Forms.CheckBox
End Class
