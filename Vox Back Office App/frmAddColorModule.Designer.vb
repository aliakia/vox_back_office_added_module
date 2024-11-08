<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddColorModule
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
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.timerDataLoad = New System.Windows.Forms.Timer(Me.components)
        Me.lblHeader = New System.Windows.Forms.Label()
        Me.cmdRefresh = New System.Windows.Forms.Button()
        Me.lblStatusPrompt = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.grpFilters = New System.Windows.Forms.GroupBox()
        Me.txtValue2 = New System.Windows.Forms.TextBox()
        Me.txtValue1 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmdExportXml = New System.Windows.Forms.Button()
        Me.cmdAdd = New System.Windows.Forms.Button()
        Me.cmItems = New System.Windows.Forms.ListView()
        Me.grpFilters.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdClose
        '
        Me.cmdClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClose.AutoSize = True
        Me.cmdClose.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClose.Location = New System.Drawing.Point(645, 196)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(138, 34)
        Me.cmdClose.TabIndex = 43
        Me.cmdClose.Text = "&CLOSE"
        Me.cmdClose.UseVisualStyleBackColor = True
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
        Me.lblHeader.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.lblHeader.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeader.ForeColor = System.Drawing.Color.Cornsilk
        Me.lblHeader.Location = New System.Drawing.Point(0, 0)
        Me.lblHeader.Name = "lblHeader"
        Me.lblHeader.Padding = New System.Windows.Forms.Padding(5)
        Me.lblHeader.Size = New System.Drawing.Size(799, 29)
        Me.lblHeader.TabIndex = 37
        Me.lblHeader.Text = "Add Color"
        '
        'cmdRefresh
        '
        Me.cmdRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdRefresh.AutoSize = True
        Me.cmdRefresh.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdRefresh.Location = New System.Drawing.Point(645, 149)
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.Size = New System.Drawing.Size(138, 34)
        Me.cmdRefresh.TabIndex = 40
        Me.cmdRefresh.Text = "&REFRESH"
        Me.cmdRefresh.UseVisualStyleBackColor = True
        '
        'lblStatusPrompt
        '
        Me.lblStatusPrompt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblStatusPrompt.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblStatusPrompt.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblStatusPrompt.Location = New System.Drawing.Point(262, 1)
        Me.lblStatusPrompt.Name = "lblStatusPrompt"
        Me.lblStatusPrompt.Size = New System.Drawing.Size(521, 23)
        Me.lblStatusPrompt.TabIndex = 38
        Me.lblStatusPrompt.Text = "Prompt"
        Me.lblStatusPrompt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblStatusPrompt.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(174, 89)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(0, 13)
        Me.Label9.TabIndex = 18
        '
        'grpFilters
        '
        Me.grpFilters.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpFilters.Controls.Add(Me.txtValue2)
        Me.grpFilters.Controls.Add(Me.txtValue1)
        Me.grpFilters.Controls.Add(Me.Label3)
        Me.grpFilters.Controls.Add(Me.Label4)
        Me.grpFilters.Controls.Add(Me.Label9)
        Me.grpFilters.Location = New System.Drawing.Point(501, 36)
        Me.grpFilters.Name = "grpFilters"
        Me.grpFilters.Size = New System.Drawing.Size(282, 106)
        Me.grpFilters.TabIndex = 39
        Me.grpFilters.TabStop = False
        Me.grpFilters.Text = "Colors"
        '
        'txtValue2
        '
        Me.txtValue2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtValue2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtValue2.Location = New System.Drawing.Point(68, 53)
        Me.txtValue2.Name = "txtValue2"
        Me.txtValue2.Size = New System.Drawing.Size(202, 20)
        Me.txtValue2.TabIndex = 12
        '
        'txtValue1
        '
        Me.txtValue1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtValue1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtValue1.Location = New System.Drawing.Point(68, 27)
        Me.txtValue1.Name = "txtValue1"
        Me.txtValue1.Size = New System.Drawing.Size(202, 20)
        Me.txtValue1.TabIndex = 10
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 13)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "Color"
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(10, 30)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(32, 13)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "Code"
        '
        'cmdExportXml
        '
        Me.cmdExportXml.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExportXml.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExportXml.Location = New System.Drawing.Point(501, 196)
        Me.cmdExportXml.Name = "cmdExportXml"
        Me.cmdExportXml.Size = New System.Drawing.Size(138, 34)
        Me.cmdExportXml.TabIndex = 41
        Me.cmdExportXml.Text = "EXPORT XML"
        Me.cmdExportXml.UseVisualStyleBackColor = True
        '
        'cmdAdd
        '
        Me.cmdAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdAdd.AutoSize = True
        Me.cmdAdd.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAdd.Location = New System.Drawing.Point(501, 150)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(138, 34)
        Me.cmdAdd.TabIndex = 42
        Me.cmdAdd.Text = "ADD"
        Me.cmdAdd.UseVisualStyleBackColor = True
        '
        'cmItems
        '
        Me.cmItems.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmItems.FullRowSelect = True
        Me.cmItems.GridLines = True
        Me.cmItems.HideSelection = False
        Me.cmItems.Location = New System.Drawing.Point(15, 36)
        Me.cmItems.Name = "cmItems"
        Me.cmItems.Size = New System.Drawing.Size(480, 560)
        Me.cmItems.TabIndex = 44
        Me.cmItems.UseCompatibleStateImageBehavior = False
        Me.cmItems.View = System.Windows.Forms.View.Details
        '
        'frmAddColorModule
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(798, 598)
        Me.ControlBox = False
        Me.Controls.Add(Me.cmItems)
        Me.Controls.Add(Me.cmdAdd)
        Me.Controls.Add(Me.cmdExportXml)
        Me.Controls.Add(Me.grpFilters)
        Me.Controls.Add(Me.lblStatusPrompt)
        Me.Controls.Add(Me.cmdRefresh)
        Me.Controls.Add(Me.lblHeader)
        Me.Controls.Add(Me.cmdClose)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAddColorModule"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.grpFilters.ResumeLayout(False)
        Me.grpFilters.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmdClose As Button
    Friend WithEvents timerDataLoad As Timer
    Friend WithEvents lblHeader As Label
    Friend WithEvents cmdRefresh As Button
    Friend WithEvents lblStatusPrompt As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents grpFilters As GroupBox
    Friend WithEvents txtValue2 As TextBox
    Friend WithEvents txtValue1 As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents cmdExportXml As Button
    Friend WithEvents cmdAdd As Button
    Friend WithEvents cmItems As ListView
End Class
