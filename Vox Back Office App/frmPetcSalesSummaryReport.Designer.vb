<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPetcSalesSummaryReport
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
        Me.lblDate2 = New System.Windows.Forms.Label()
        Me.lblDate1 = New System.Windows.Forms.Label()
        Me.txtDateTo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtPetcCode = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtDateFrom = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmdRefresh = New System.Windows.Forms.Button()
        Me.lsvItems = New System.Windows.Forms.ListView()
        Me.lblStatusPrompt = New System.Windows.Forms.Label()
        Me.timerDataLoad = New System.Windows.Forms.Timer(Me.components)
        Me.lsvPetcSummary = New System.Windows.Forms.ListView()
        Me.grpFilters.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdPrint
        '
        Me.cmdPrint.Enabled = False
        Me.cmdPrint.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPrint.Location = New System.Drawing.Point(502, 369)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(85, 40)
        Me.cmdPrint.TabIndex = 17
        Me.cmdPrint.Text = "PRINT"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'cmdOptions
        '
        Me.cmdOptions.Enabled = False
        Me.cmdOptions.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOptions.Location = New System.Drawing.Point(593, 323)
        Me.cmdOptions.Name = "cmdOptions"
        Me.cmdOptions.Size = New System.Drawing.Size(85, 40)
        Me.cmdOptions.TabIndex = 18
        Me.cmdOptions.Text = "OPTIONS"
        Me.cmdOptions.UseVisualStyleBackColor = True
        '
        'grpFilters
        '
        Me.grpFilters.Controls.Add(Me.lblDate2)
        Me.grpFilters.Controls.Add(Me.lblDate1)
        Me.grpFilters.Controls.Add(Me.txtDateTo)
        Me.grpFilters.Controls.Add(Me.Label2)
        Me.grpFilters.Controls.Add(Me.txtPetcCode)
        Me.grpFilters.Controls.Add(Me.Label7)
        Me.grpFilters.Controls.Add(Me.txtDateFrom)
        Me.grpFilters.Controls.Add(Me.Label1)
        Me.grpFilters.Location = New System.Drawing.Point(12, 323)
        Me.grpFilters.Name = "grpFilters"
        Me.grpFilters.Size = New System.Drawing.Size(484, 86)
        Me.grpFilters.TabIndex = 15
        Me.grpFilters.TabStop = False
        Me.grpFilters.Text = "Filters"
        '
        'lblDate2
        '
        Me.lblDate2.AutoSize = True
        Me.lblDate2.Location = New System.Drawing.Point(285, 46)
        Me.lblDate2.Name = "lblDate2"
        Me.lblDate2.Size = New System.Drawing.Size(53, 13)
        Me.lblDate2.TabIndex = 20
        Me.lblDate2.Text = "Date from"
        Me.lblDate2.Visible = False
        '
        'lblDate1
        '
        Me.lblDate1.AutoSize = True
        Me.lblDate1.Location = New System.Drawing.Point(285, 27)
        Me.lblDate1.Name = "lblDate1"
        Me.lblDate1.Size = New System.Drawing.Size(53, 13)
        Me.lblDate1.TabIndex = 19
        Me.lblDate1.Text = "Date from"
        Me.lblDate1.Visible = False
        '
        'txtDateTo
        '
        Me.txtDateTo.Location = New System.Drawing.Point(180, 24)
        Me.txtDateTo.Name = "txtDateTo"
        Me.txtDateTo.Size = New System.Drawing.Size(66, 20)
        Me.txtDateTo.TabIndex = 4
        Me.txtDateTo.Text = "mm/dd/yyyy"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(158, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(16, 13)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "to"
        '
        'txtPetcCode
        '
        Me.txtPetcCode.Location = New System.Drawing.Point(86, 50)
        Me.txtPetcCode.Name = "txtPetcCode"
        Me.txtPetcCode.Size = New System.Drawing.Size(66, 20)
        Me.txtPetcCode.TabIndex = 5
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(17, 53)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(63, 13)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "PETC Code"
        '
        'txtDateFrom
        '
        Me.txtDateFrom.Location = New System.Drawing.Point(86, 24)
        Me.txtDateFrom.Name = "txtDateFrom"
        Me.txtDateFrom.Size = New System.Drawing.Size(66, 20)
        Me.txtDateFrom.TabIndex = 3
        Me.txtDateFrom.Text = "mm/dd/yyyy"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Date from"
        '
        'cmdClose
        '
        Me.cmdClose.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClose.Location = New System.Drawing.Point(593, 369)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(85, 40)
        Me.cmdClose.TabIndex = 19
        Me.cmdClose.Text = "&CLOSE"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'cmdRefresh
        '
        Me.cmdRefresh.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdRefresh.Location = New System.Drawing.Point(502, 323)
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.Size = New System.Drawing.Size(85, 40)
        Me.cmdRefresh.TabIndex = 16
        Me.cmdRefresh.Text = "&REFRESH"
        Me.cmdRefresh.UseVisualStyleBackColor = True
        '
        'lsvItems
        '
        Me.lsvItems.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lsvItems.FullRowSelect = True
        Me.lsvItems.GridLines = True
        Me.lsvItems.Location = New System.Drawing.Point(12, 12)
        Me.lsvItems.Name = "lsvItems"
        Me.lsvItems.Size = New System.Drawing.Size(297, 305)
        Me.lsvItems.TabIndex = 20
        Me.lsvItems.UseCompatibleStateImageBehavior = False
        Me.lsvItems.View = System.Windows.Forms.View.Details
        '
        'lblStatusPrompt
        '
        Me.lblStatusPrompt.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblStatusPrompt.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatusPrompt.ForeColor = System.Drawing.Color.White
        Me.lblStatusPrompt.Location = New System.Drawing.Point(-1, 416)
        Me.lblStatusPrompt.Name = "lblStatusPrompt"
        Me.lblStatusPrompt.Padding = New System.Windows.Forms.Padding(3)
        Me.lblStatusPrompt.Size = New System.Drawing.Size(716, 23)
        Me.lblStatusPrompt.TabIndex = 28
        Me.lblStatusPrompt.Text = "OPTIONS:"
        Me.lblStatusPrompt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'timerDataLoad
        '
        Me.timerDataLoad.Interval = 1
        '
        'lsvPetcSummary
        '
        Me.lsvPetcSummary.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lsvPetcSummary.FullRowSelect = True
        Me.lsvPetcSummary.GridLines = True
        Me.lsvPetcSummary.Location = New System.Drawing.Point(315, 12)
        Me.lsvPetcSummary.Name = "lsvPetcSummary"
        Me.lsvPetcSummary.Size = New System.Drawing.Size(362, 305)
        Me.lsvPetcSummary.TabIndex = 29
        Me.lsvPetcSummary.UseCompatibleStateImageBehavior = False
        Me.lsvPetcSummary.View = System.Windows.Forms.View.Details
        Me.lsvPetcSummary.Visible = False
        '
        'frmPetcSalesSummaryReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(689, 439)
        Me.ControlBox = False
        Me.Controls.Add(Me.lsvPetcSummary)
        Me.Controls.Add(Me.lblStatusPrompt)
        Me.Controls.Add(Me.lsvItems)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdOptions)
        Me.Controls.Add(Me.grpFilters)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.cmdRefresh)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmPetcSalesSummaryReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PETC Transmission Sales - Summary Report"
        Me.grpFilters.ResumeLayout(False)
        Me.grpFilters.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdOptions As System.Windows.Forms.Button
    Friend WithEvents grpFilters As System.Windows.Forms.GroupBox
    Friend WithEvents txtDateTo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtPetcCode As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtDateFrom As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents cmdRefresh As System.Windows.Forms.Button
    Friend WithEvents lsvItems As System.Windows.Forms.ListView
    Friend WithEvents lblStatusPrompt As System.Windows.Forms.Label
    Friend WithEvents timerDataLoad As System.Windows.Forms.Timer
    Friend WithEvents lsvPetcSummary As System.Windows.Forms.ListView
    Friend WithEvents lblDate2 As System.Windows.Forms.Label
    Friend WithEvents lblDate1 As System.Windows.Forms.Label
End Class
