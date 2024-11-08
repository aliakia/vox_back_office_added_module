<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPetcManager
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
        Me.cmdExport = New System.Windows.Forms.Button()
        Me.cmdCreate = New System.Windows.Forms.Button()
        Me.cmdEdit = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmdRefresh = New System.Windows.Forms.Button()
        Me.chkDisplayActiveOnly = New System.Windows.Forms.CheckBox()
        Me.txtPetcName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtPetcCode = New System.Windows.Forms.TextBox()
        Me.lblFieldFilter = New System.Windows.Forms.Label()
        Me.cmdImport = New System.Windows.Forms.Button()
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
        Me.lsvItems.Size = New System.Drawing.Size(750, 312)
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
        Me.lblHeader.Text = "PETC Manager"
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
        Me.grpFilters.Controls.Add(Me.cmdImport)
        Me.grpFilters.Controls.Add(Me.cmdExport)
        Me.grpFilters.Controls.Add(Me.cmdCreate)
        Me.grpFilters.Controls.Add(Me.cmdEdit)
        Me.grpFilters.Controls.Add(Me.cmdClose)
        Me.grpFilters.Controls.Add(Me.cmdRefresh)
        Me.grpFilters.Controls.Add(Me.chkDisplayActiveOnly)
        Me.grpFilters.Controls.Add(Me.txtPetcName)
        Me.grpFilters.Controls.Add(Me.Label1)
        Me.grpFilters.Controls.Add(Me.txtPetcCode)
        Me.grpFilters.Controls.Add(Me.lblFieldFilter)
        Me.grpFilters.Location = New System.Drawing.Point(13, 346)
        Me.grpFilters.Name = "grpFilters"
        Me.grpFilters.Size = New System.Drawing.Size(749, 63)
        Me.grpFilters.TabIndex = 1
        Me.grpFilters.TabStop = False
        Me.grpFilters.Text = "Filters"
        '
        'cmdExport
        '
        Me.cmdExport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExport.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExport.Location = New System.Drawing.Point(527, 15)
        Me.cmdExport.Name = "cmdExport"
        Me.cmdExport.Size = New System.Drawing.Size(69, 40)
        Me.cmdExport.TabIndex = 8
        Me.cmdExport.Text = "EXPORT"
        Me.cmdExport.UseVisualStyleBackColor = True
        '
        'cmdCreate
        '
        Me.cmdCreate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCreate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCreate.Location = New System.Drawing.Point(281, 16)
        Me.cmdCreate.Name = "cmdCreate"
        Me.cmdCreate.Size = New System.Drawing.Size(73, 40)
        Me.cmdCreate.TabIndex = 5
        Me.cmdCreate.Text = "CREA&TE"
        Me.cmdCreate.UseVisualStyleBackColor = True
        '
        'cmdEdit
        '
        Me.cmdEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdEdit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdEdit.Location = New System.Drawing.Point(360, 16)
        Me.cmdEdit.Name = "cmdEdit"
        Me.cmdEdit.Size = New System.Drawing.Size(57, 40)
        Me.cmdEdit.TabIndex = 6
        Me.cmdEdit.Text = "&EDIT"
        Me.cmdEdit.UseVisualStyleBackColor = True
        '
        'cmdClose
        '
        Me.cmdClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClose.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClose.Location = New System.Drawing.Point(678, 16)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(64, 40)
        Me.cmdClose.TabIndex = 10
        Me.cmdClose.Text = "&CLOSE"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'cmdRefresh
        '
        Me.cmdRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdRefresh.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdRefresh.Location = New System.Drawing.Point(423, 16)
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.Size = New System.Drawing.Size(98, 40)
        Me.cmdRefresh.TabIndex = 7
        Me.cmdRefresh.Text = "&REFRESH"
        Me.cmdRefresh.UseVisualStyleBackColor = True
        '
        'chkDisplayActiveOnly
        '
        Me.chkDisplayActiveOnly.AutoSize = True
        Me.chkDisplayActiveOnly.Location = New System.Drawing.Point(53, 0)
        Me.chkDisplayActiveOnly.Name = "chkDisplayActiveOnly"
        Me.chkDisplayActiveOnly.Size = New System.Drawing.Size(78, 17)
        Me.chkDisplayActiveOnly.TabIndex = 2
        Me.chkDisplayActiveOnly.Text = "Active only"
        Me.chkDisplayActiveOnly.UseVisualStyleBackColor = True
        '
        'txtPetcName
        '
        Me.txtPetcName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPetcName.Location = New System.Drawing.Point(201, 28)
        Me.txtPetcName.Name = "txtPetcName"
        Me.txtPetcName.Size = New System.Drawing.Size(65, 20)
        Me.txtPetcName.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(160, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Name"
        '
        'txtPetcCode
        '
        Me.txtPetcCode.Location = New System.Drawing.Point(87, 28)
        Me.txtPetcCode.Name = "txtPetcCode"
        Me.txtPetcCode.Size = New System.Drawing.Size(57, 20)
        Me.txtPetcCode.TabIndex = 3
        '
        'lblFieldFilter
        '
        Me.lblFieldFilter.AutoSize = True
        Me.lblFieldFilter.Location = New System.Drawing.Point(18, 31)
        Me.lblFieldFilter.Name = "lblFieldFilter"
        Me.lblFieldFilter.Size = New System.Drawing.Size(63, 13)
        Me.lblFieldFilter.TabIndex = 10
        Me.lblFieldFilter.Text = "PETC Code"
        '
        'cmdImport
        '
        Me.cmdImport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdImport.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdImport.Location = New System.Drawing.Point(602, 15)
        Me.cmdImport.Name = "cmdImport"
        Me.cmdImport.Size = New System.Drawing.Size(70, 40)
        Me.cmdImport.TabIndex = 9
        Me.cmdImport.Text = "IMPORT"
        Me.cmdImport.UseVisualStyleBackColor = True
        '
        'frmPetcManager
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(774, 421)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblStatusPrompt)
        Me.Controls.Add(Me.grpFilters)
        Me.Controls.Add(Me.lsvItems)
        Me.Controls.Add(Me.lblHeader)
        Me.Name = "frmPetcManager"
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
    Friend WithEvents txtPetcCode As System.Windows.Forms.TextBox
    Friend WithEvents lblFieldFilter As System.Windows.Forms.Label
    Friend WithEvents txtPetcName As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdCreate As System.Windows.Forms.Button
    Friend WithEvents cmdEdit As System.Windows.Forms.Button
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents cmdRefresh As System.Windows.Forms.Button
    Friend WithEvents chkDisplayActiveOnly As System.Windows.Forms.CheckBox
    Friend WithEvents cmdExport As System.Windows.Forms.Button
    Friend WithEvents cmdImport As System.Windows.Forms.Button
End Class
