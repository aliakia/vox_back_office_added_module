<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddMakeSeries
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
        Me.cmdExportXmlMake = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.timerDataLoad = New System.Windows.Forms.Timer(Me.components)
        Me.lblStatusPrompt = New System.Windows.Forms.Label()
        Me.cmdRefresh = New System.Windows.Forms.Button()
        Me.lblHeader = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.grpFilters = New System.Windows.Forms.GroupBox()
        Me.ckb_newMake = New System.Windows.Forms.CheckBox()
        Me.cbb_make = New System.Windows.Forms.ComboBox()
        Me.txt_series = New System.Windows.Forms.TextBox()
        Me.txt_newMake = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lb_newMake = New System.Windows.Forms.Label()
        Me.cmItems = New System.Windows.Forms.ListView()
        Me.cmdExportXmlSeries = New System.Windows.Forms.Button()
        Me.cmdAdd = New System.Windows.Forms.Button()
        Me.grpFilters.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdExportXmlMake
        '
        Me.cmdExportXmlMake.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExportXmlMake.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExportXmlMake.Location = New System.Drawing.Point(500, 193)
        Me.cmdExportXmlMake.Name = "cmdExportXmlMake"
        Me.cmdExportXmlMake.Size = New System.Drawing.Size(141, 36)
        Me.cmdExportXmlMake.TabIndex = 49
        Me.cmdExportXmlMake.Text = "EXPORT XML"
        Me.cmdExportXmlMake.UseVisualStyleBackColor = True
        '
        'cmdClose
        '
        Me.cmdClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClose.AutoSize = True
        Me.cmdClose.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClose.Location = New System.Drawing.Point(644, 193)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(141, 36)
        Me.cmdClose.TabIndex = 51
        Me.cmdClose.Text = "&CLOSE"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'timerDataLoad
        '
        Me.timerDataLoad.Interval = 1
        '
        'lblStatusPrompt
        '
        Me.lblStatusPrompt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblStatusPrompt.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblStatusPrompt.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblStatusPrompt.Location = New System.Drawing.Point(262, 2)
        Me.lblStatusPrompt.Name = "lblStatusPrompt"
        Me.lblStatusPrompt.Size = New System.Drawing.Size(521, 23)
        Me.lblStatusPrompt.TabIndex = 46
        Me.lblStatusPrompt.Text = "Prompt"
        Me.lblStatusPrompt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblStatusPrompt.Visible = False
        '
        'cmdRefresh
        '
        Me.cmdRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdRefresh.AutoSize = True
        Me.cmdRefresh.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdRefresh.Location = New System.Drawing.Point(644, 151)
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.Size = New System.Drawing.Size(141, 36)
        Me.cmdRefresh.TabIndex = 48
        Me.cmdRefresh.Text = "&REFRESH"
        Me.cmdRefresh.UseVisualStyleBackColor = True
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
        Me.lblHeader.Size = New System.Drawing.Size(798, 29)
        Me.lblHeader.TabIndex = 45
        Me.lblHeader.Text = "Add Make and Series"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(174, 83)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(0, 13)
        Me.Label9.TabIndex = 18
        '
        'grpFilters
        '
        Me.grpFilters.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpFilters.Controls.Add(Me.ckb_newMake)
        Me.grpFilters.Controls.Add(Me.cbb_make)
        Me.grpFilters.Controls.Add(Me.txt_series)
        Me.grpFilters.Controls.Add(Me.txt_newMake)
        Me.grpFilters.Controls.Add(Me.Label3)
        Me.grpFilters.Controls.Add(Me.lb_newMake)
        Me.grpFilters.Controls.Add(Me.Label9)
        Me.grpFilters.Location = New System.Drawing.Point(500, 35)
        Me.grpFilters.Name = "grpFilters"
        Me.grpFilters.Size = New System.Drawing.Size(285, 105)
        Me.grpFilters.TabIndex = 47
        Me.grpFilters.TabStop = False
        Me.grpFilters.Text = "Make and Series"
        '
        'ckb_newMake
        '
        Me.ckb_newMake.AutoSize = True
        Me.ckb_newMake.Location = New System.Drawing.Point(200, 19)
        Me.ckb_newMake.Name = "ckb_newMake"
        Me.ckb_newMake.Size = New System.Drawing.Size(84, 17)
        Me.ckb_newMake.TabIndex = 24
        Me.ckb_newMake.Text = "New Make?"
        Me.ckb_newMake.UseVisualStyleBackColor = True
        '
        'cbb_make
        '
        Me.cbb_make.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cbb_make.FormattingEnabled = True
        Me.cbb_make.Location = New System.Drawing.Point(64, 41)
        Me.cbb_make.Name = "cbb_make"
        Me.cbb_make.Size = New System.Drawing.Size(213, 21)
        Me.cbb_make.TabIndex = 1
        '
        'txt_series
        '
        Me.txt_series.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_series.Location = New System.Drawing.Point(64, 70)
        Me.txt_series.Name = "txt_series"
        Me.txt_series.Size = New System.Drawing.Size(213, 20)
        Me.txt_series.TabIndex = 2
        '
        'txt_newMake
        '
        Me.txt_newMake.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_newMake.Location = New System.Drawing.Point(64, 41)
        Me.txt_newMake.Name = "txt_newMake"
        Me.txt_newMake.Size = New System.Drawing.Size(213, 20)
        Me.txt_newMake.TabIndex = 10
        Me.txt_newMake.Visible = False
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 73)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(36, 13)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "Series"
        '
        'lb_newMake
        '
        Me.lb_newMake.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lb_newMake.AutoSize = True
        Me.lb_newMake.Location = New System.Drawing.Point(14, 43)
        Me.lb_newMake.Name = "lb_newMake"
        Me.lb_newMake.Size = New System.Drawing.Size(34, 13)
        Me.lb_newMake.TabIndex = 20
        Me.lb_newMake.Text = "Make"
        '
        'cmItems
        '
        Me.cmItems.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmItems.FullRowSelect = True
        Me.cmItems.GridLines = True
        Me.cmItems.HideSelection = False
        Me.cmItems.Location = New System.Drawing.Point(15, 35)
        Me.cmItems.Name = "cmItems"
        Me.cmItems.Size = New System.Drawing.Size(479, 562)
        Me.cmItems.TabIndex = 52
        Me.cmItems.UseCompatibleStateImageBehavior = False
        Me.cmItems.View = System.Windows.Forms.View.Details
        '
        'cmdExportXmlSeries
        '
        Me.cmdExportXmlSeries.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExportXmlSeries.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExportXmlSeries.Location = New System.Drawing.Point(644, 193)
        Me.cmdExportXmlSeries.Name = "cmdExportXmlSeries"
        Me.cmdExportXmlSeries.Size = New System.Drawing.Size(141, 36)
        Me.cmdExportXmlSeries.TabIndex = 53
        Me.cmdExportXmlSeries.Text = "EXPORT XML SERIES"
        Me.cmdExportXmlSeries.UseVisualStyleBackColor = True
        Me.cmdExportXmlSeries.Visible = False
        '
        'cmdAdd
        '
        Me.cmdAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdAdd.AutoSize = True
        Me.cmdAdd.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAdd.Location = New System.Drawing.Point(500, 151)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(141, 36)
        Me.cmdAdd.TabIndex = 54
        Me.cmdAdd.Text = "ADD"
        Me.cmdAdd.UseVisualStyleBackColor = True
        '
        'frmAddMakeSeries
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(798, 598)
        Me.ControlBox = False
        Me.Controls.Add(Me.cmdAdd)
        Me.Controls.Add(Me.cmdExportXmlSeries)
        Me.Controls.Add(Me.cmdExportXmlMake)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.lblStatusPrompt)
        Me.Controls.Add(Me.cmdRefresh)
        Me.Controls.Add(Me.lblHeader)
        Me.Controls.Add(Me.grpFilters)
        Me.Controls.Add(Me.cmItems)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAddMakeSeries"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.grpFilters.ResumeLayout(False)
        Me.grpFilters.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmdExportXmlMake As Button
    Friend WithEvents cmdClose As Button
    Friend WithEvents timerDataLoad As Timer
    Friend WithEvents lblStatusPrompt As Label
    Friend WithEvents cmdRefresh As Button
    Friend WithEvents lblHeader As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents grpFilters As GroupBox
    Friend WithEvents cbb_make As ComboBox
    Friend WithEvents txt_series As TextBox
    Friend WithEvents txt_newMake As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cmItems As ListView
    Friend WithEvents ckb_newMake As CheckBox
    Friend WithEvents cmdExportXmlSeries As Button
    Friend WithEvents cmdAdd As Button
    Friend WithEvents lb_newMake As Label
End Class
