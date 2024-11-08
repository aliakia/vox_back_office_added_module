<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRegionsProvincesCities
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
        Me.timerDataLoad = New System.Windows.Forms.Timer(Me.components)
        Me.lblHeader = New System.Windows.Forms.Label()
        Me.lblStatusPrompt = New System.Windows.Forms.Label()
        Me.grpFilters = New System.Windows.Forms.GroupBox()
        Me.cmdCreateCity = New System.Windows.Forms.Button()
        Me.cmdCreateProvince = New System.Windows.Forms.Button()
        Me.cmdCreateRegion = New System.Windows.Forms.Button()
        Me.txtCity = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmdRefresh = New System.Windows.Forms.Button()
        Me.chkDisplayActiveOnly = New System.Windows.Forms.CheckBox()
        Me.txtProvince = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtRegion = New System.Windows.Forms.TextBox()
        Me.lblFieldFilter = New System.Windows.Forms.Label()
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
        Me.lsvItems.Location = New System.Drawing.Point(12, 28)
        Me.lsvItems.Name = "lsvItems"
        Me.lsvItems.Size = New System.Drawing.Size(750, 333)
        Me.lsvItems.TabIndex = 0
        Me.lsvItems.UseCompatibleStateImageBehavior = False
        Me.lsvItems.View = System.Windows.Forms.View.Details
        '
        'timerDataLoad
        '
        Me.timerDataLoad.Interval = 1
        '
        'lblHeader
        '
        Me.lblHeader.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblHeader.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblHeader.Cursor = System.Windows.Forms.Cursors.SizeAll
        Me.lblHeader.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeader.ForeColor = System.Drawing.Color.Cornsilk
        Me.lblHeader.Location = New System.Drawing.Point(0, 0)
        Me.lblHeader.Name = "lblHeader"
        Me.lblHeader.Padding = New System.Windows.Forms.Padding(5)
        Me.lblHeader.Size = New System.Drawing.Size(776, 29)
        Me.lblHeader.TabIndex = 3
        Me.lblHeader.Text = "Regions, Provinces, Towns / Cities Manager"
        '
        'lblStatusPrompt
        '
        Me.lblStatusPrompt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblStatusPrompt.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblStatusPrompt.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblStatusPrompt.Location = New System.Drawing.Point(337, 3)
        Me.lblStatusPrompt.Name = "lblStatusPrompt"
        Me.lblStatusPrompt.Size = New System.Drawing.Size(425, 23)
        Me.lblStatusPrompt.TabIndex = 4
        Me.lblStatusPrompt.Text = "Prompt"
        Me.lblStatusPrompt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblStatusPrompt.Visible = False
        '
        'grpFilters
        '
        Me.grpFilters.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpFilters.Controls.Add(Me.cmdCreateCity)
        Me.grpFilters.Controls.Add(Me.cmdCreateProvince)
        Me.grpFilters.Controls.Add(Me.cmdCreateRegion)
        Me.grpFilters.Controls.Add(Me.txtCity)
        Me.grpFilters.Controls.Add(Me.Label2)
        Me.grpFilters.Controls.Add(Me.cmdClose)
        Me.grpFilters.Controls.Add(Me.cmdRefresh)
        Me.grpFilters.Controls.Add(Me.chkDisplayActiveOnly)
        Me.grpFilters.Controls.Add(Me.txtProvince)
        Me.grpFilters.Controls.Add(Me.Label1)
        Me.grpFilters.Controls.Add(Me.txtRegion)
        Me.grpFilters.Controls.Add(Me.lblFieldFilter)
        Me.grpFilters.Location = New System.Drawing.Point(13, 367)
        Me.grpFilters.Name = "grpFilters"
        Me.grpFilters.Size = New System.Drawing.Size(749, 112)
        Me.grpFilters.TabIndex = 1
        Me.grpFilters.TabStop = False
        Me.grpFilters.Text = "Filters"
        '
        'cmdCreateCity
        '
        Me.cmdCreateCity.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCreateCity.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCreateCity.Location = New System.Drawing.Point(480, 65)
        Me.cmdCreateCity.Name = "cmdCreateCity"
        Me.cmdCreateCity.Size = New System.Drawing.Size(164, 33)
        Me.cmdCreateCity.TabIndex = 9
        Me.cmdCreateCity.Text = "CREATE TOWN / CITY"
        Me.cmdCreateCity.UseVisualStyleBackColor = True
        '
        'cmdCreateProvince
        '
        Me.cmdCreateProvince.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCreateProvince.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCreateProvince.Location = New System.Drawing.Point(611, 26)
        Me.cmdCreateProvince.Name = "cmdCreateProvince"
        Me.cmdCreateProvince.Size = New System.Drawing.Size(125, 33)
        Me.cmdCreateProvince.TabIndex = 8
        Me.cmdCreateProvince.Text = "CREATE PROVINCE"
        Me.cmdCreateProvince.UseVisualStyleBackColor = True
        '
        'cmdCreateRegion
        '
        Me.cmdCreateRegion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCreateRegion.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCreateRegion.Location = New System.Drawing.Point(480, 26)
        Me.cmdCreateRegion.Name = "cmdCreateRegion"
        Me.cmdCreateRegion.Size = New System.Drawing.Size(125, 33)
        Me.cmdCreateRegion.TabIndex = 7
        Me.cmdCreateRegion.Text = "CREATE REGION"
        Me.cmdCreateRegion.UseVisualStyleBackColor = True
        '
        'txtCity
        '
        Me.txtCity.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCity.Location = New System.Drawing.Point(86, 78)
        Me.txtCity.Name = "txtCity"
        Me.txtCity.Size = New System.Drawing.Size(255, 20)
        Me.txtCity.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 81)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 13)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Town / City"
        '
        'cmdClose
        '
        Me.cmdClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClose.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClose.Location = New System.Drawing.Point(650, 65)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(86, 34)
        Me.cmdClose.TabIndex = 10
        Me.cmdClose.Text = "&CLOSE"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'cmdRefresh
        '
        Me.cmdRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdRefresh.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdRefresh.Location = New System.Drawing.Point(360, 26)
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.Size = New System.Drawing.Size(114, 72)
        Me.cmdRefresh.TabIndex = 6
        Me.cmdRefresh.Text = "&REFRESH"
        Me.cmdRefresh.UseVisualStyleBackColor = True
        '
        'chkDisplayActiveOnly
        '
        Me.chkDisplayActiveOnly.AutoSize = True
        Me.chkDisplayActiveOnly.Enabled = False
        Me.chkDisplayActiveOnly.Location = New System.Drawing.Point(263, 28)
        Me.chkDisplayActiveOnly.Name = "chkDisplayActiveOnly"
        Me.chkDisplayActiveOnly.Size = New System.Drawing.Size(78, 17)
        Me.chkDisplayActiveOnly.TabIndex = 3
        Me.chkDisplayActiveOnly.Text = "Active only"
        Me.chkDisplayActiveOnly.UseVisualStyleBackColor = True
        '
        'txtProvince
        '
        Me.txtProvince.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtProvince.Location = New System.Drawing.Point(86, 52)
        Me.txtProvince.Name = "txtProvince"
        Me.txtProvince.Size = New System.Drawing.Size(255, 20)
        Me.txtProvince.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 55)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 13)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Province"
        '
        'txtRegion
        '
        Me.txtRegion.Location = New System.Drawing.Point(86, 26)
        Me.txtRegion.Name = "txtRegion"
        Me.txtRegion.Size = New System.Drawing.Size(158, 20)
        Me.txtRegion.TabIndex = 2
        '
        'lblFieldFilter
        '
        Me.lblFieldFilter.AutoSize = True
        Me.lblFieldFilter.Location = New System.Drawing.Point(18, 29)
        Me.lblFieldFilter.Name = "lblFieldFilter"
        Me.lblFieldFilter.Size = New System.Drawing.Size(41, 13)
        Me.lblFieldFilter.TabIndex = 10
        Me.lblFieldFilter.Text = "Region"
        '
        'frmRegionsProvincesCities
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(774, 491)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblStatusPrompt)
        Me.Controls.Add(Me.grpFilters)
        Me.Controls.Add(Me.lsvItems)
        Me.Controls.Add(Me.lblHeader)
        Me.Name = "frmRegionsProvincesCities"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.grpFilters.ResumeLayout(False)
        Me.grpFilters.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lsvItems As System.Windows.Forms.ListView
    Friend WithEvents timerDataLoad As System.Windows.Forms.Timer
    Friend WithEvents lblHeader As System.Windows.Forms.Label
    Friend WithEvents lblStatusPrompt As System.Windows.Forms.Label
    Friend WithEvents grpFilters As System.Windows.Forms.GroupBox
    Friend WithEvents txtRegion As System.Windows.Forms.TextBox
    Friend WithEvents lblFieldFilter As System.Windows.Forms.Label
    Friend WithEvents txtProvince As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents cmdRefresh As System.Windows.Forms.Button
    Friend WithEvents chkDisplayActiveOnly As System.Windows.Forms.CheckBox
    Friend WithEvents txtCity As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmdCreateRegion As System.Windows.Forms.Button
    Friend WithEvents cmdCreateCity As System.Windows.Forms.Button
    Friend WithEvents cmdCreateProvince As System.Windows.Forms.Button
End Class
