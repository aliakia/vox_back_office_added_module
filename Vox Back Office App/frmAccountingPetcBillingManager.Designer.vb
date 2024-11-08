<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAccountingPetcBillingManager
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAccountingPetcBillingManager))
        Me.lsvItems = New System.Windows.Forms.ListView()
        Me.timerDataLoad = New System.Windows.Forms.Timer(Me.components)
        Me.cmdRefresh = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.lblHeader = New System.Windows.Forms.Label()
        Me.lblStatusPrompt = New System.Windows.Forms.Label()
        Me.grpFilters = New System.Windows.Forms.GroupBox()
        Me.chkDisplayActiveOnly = New System.Windows.Forms.CheckBox()
        Me.txtRecs = New System.Windows.Forms.TextBox()
        Me.txtDateTo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtDateFrom = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbFilter2 = New System.Windows.Forms.ComboBox()
        Me.cmbFilter1 = New System.Windows.Forms.ComboBox()
        Me.txtValue2 = New System.Windows.Forms.TextBox()
        Me.txtValue1 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cmdOptions = New System.Windows.Forms.Button()
        Me.cmdPrint = New System.Windows.Forms.Button()
        Me.cmdAdd = New System.Windows.Forms.Button()
        Me.PrintDialog = New System.Windows.Forms.PrintDialog()
        Me.PrintDocument = New System.Drawing.Printing.PrintDocument()
        Me.PrintPreviewDialog = New System.Windows.Forms.PrintPreviewDialog()
        Me.lblDate2 = New System.Windows.Forms.Label()
        Me.lblDate1 = New System.Windows.Forms.Label()
        Me.cmbPetcs = New System.Windows.Forms.ComboBox()
        Me.lsvDetails = New System.Windows.Forms.ListView()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.optShowAll = New System.Windows.Forms.RadioButton()
        Me.optShowCreditOnly = New System.Windows.Forms.RadioButton()
        Me.optShowDebitOnly = New System.Windows.Forms.RadioButton()
        Me.grpFilters.SuspendLayout()
        Me.SuspendLayout()
        '
        'lsvItems
        '
        Me.lsvItems.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lsvItems.FullRowSelect = True
        Me.lsvItems.GridLines = True
        Me.lsvItems.Location = New System.Drawing.Point(15, 28)
        Me.lsvItems.Name = "lsvItems"
        Me.lsvItems.Size = New System.Drawing.Size(769, 252)
        Me.lsvItems.TabIndex = 0
        Me.lsvItems.UseCompatibleStateImageBehavior = False
        Me.lsvItems.View = System.Windows.Forms.View.Details
        '
        'timerDataLoad
        '
        Me.timerDataLoad.Interval = 1
        '
        'cmdRefresh
        '
        Me.cmdRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdRefresh.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdRefresh.Location = New System.Drawing.Point(519, 500)
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.Size = New System.Drawing.Size(85, 40)
        Me.cmdRefresh.TabIndex = 14
        Me.cmdRefresh.Text = "&REFRESH"
        Me.cmdRefresh.UseVisualStyleBackColor = True
        '
        'cmdClose
        '
        Me.cmdClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClose.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClose.Location = New System.Drawing.Point(701, 546)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(85, 40)
        Me.cmdClose.TabIndex = 18
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
        Me.lblHeader.Text = "PETC Billing Manager"
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
        Me.grpFilters.Controls.Add(Me.chkDisplayActiveOnly)
        Me.grpFilters.Controls.Add(Me.txtRecs)
        Me.grpFilters.Controls.Add(Me.txtDateTo)
        Me.grpFilters.Controls.Add(Me.Label2)
        Me.grpFilters.Controls.Add(Me.txtDateFrom)
        Me.grpFilters.Controls.Add(Me.Label1)
        Me.grpFilters.Controls.Add(Me.cmbFilter2)
        Me.grpFilters.Controls.Add(Me.cmbFilter1)
        Me.grpFilters.Controls.Add(Me.txtValue2)
        Me.grpFilters.Controls.Add(Me.txtValue1)
        Me.grpFilters.Controls.Add(Me.Label3)
        Me.grpFilters.Controls.Add(Me.Label4)
        Me.grpFilters.Controls.Add(Me.Label10)
        Me.grpFilters.Controls.Add(Me.Label9)
        Me.grpFilters.Location = New System.Drawing.Point(12, 500)
        Me.grpFilters.Name = "grpFilters"
        Me.grpFilters.Size = New System.Drawing.Size(501, 86)
        Me.grpFilters.TabIndex = 5
        Me.grpFilters.TabStop = False
        Me.grpFilters.Text = "Filters:  Show                             records only"
        '
        'chkDisplayActiveOnly
        '
        Me.chkDisplayActiveOnly.AutoSize = True
        Me.chkDisplayActiveOnly.Location = New System.Drawing.Point(231, 0)
        Me.chkDisplayActiveOnly.Name = "chkDisplayActiveOnly"
        Me.chkDisplayActiveOnly.Size = New System.Drawing.Size(78, 17)
        Me.chkDisplayActiveOnly.TabIndex = 7
        Me.chkDisplayActiveOnly.Text = "Active only"
        Me.chkDisplayActiveOnly.UseVisualStyleBackColor = True
        '
        'txtRecs
        '
        Me.txtRecs.Location = New System.Drawing.Point(79, 0)
        Me.txtRecs.Name = "txtRecs"
        Me.txtRecs.Size = New System.Drawing.Size(75, 20)
        Me.txtRecs.TabIndex = 6
        Me.txtRecs.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDateTo
        '
        Me.txtDateTo.Location = New System.Drawing.Point(79, 51)
        Me.txtDateTo.Name = "txtDateTo"
        Me.txtDateTo.Size = New System.Drawing.Size(75, 20)
        Me.txtDateTo.TabIndex = 9
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(57, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(16, 13)
        Me.Label2.TabIndex = 25
        Me.Label2.Text = "to"
        '
        'txtDateFrom
        '
        Me.txtDateFrom.Location = New System.Drawing.Point(79, 25)
        Me.txtDateFrom.Name = "txtDateFrom"
        Me.txtDateFrom.Size = New System.Drawing.Size(75, 20)
        Me.txtDateFrom.TabIndex = 8
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
        'cmbFilter2
        '
        Me.cmbFilter2.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbFilter2.FormattingEnabled = True
        Me.cmbFilter2.Location = New System.Drawing.Point(231, 51)
        Me.cmbFilter2.Name = "cmbFilter2"
        Me.cmbFilter2.Size = New System.Drawing.Size(116, 21)
        Me.cmbFilter2.TabIndex = 12
        '
        'cmbFilter1
        '
        Me.cmbFilter1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbFilter1.FormattingEnabled = True
        Me.cmbFilter1.Location = New System.Drawing.Point(231, 24)
        Me.cmbFilter1.Name = "cmbFilter1"
        Me.cmbFilter1.Size = New System.Drawing.Size(116, 21)
        Me.cmbFilter1.TabIndex = 10
        '
        'txtValue2
        '
        Me.txtValue2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtValue2.Location = New System.Drawing.Point(417, 51)
        Me.txtValue2.Name = "txtValue2"
        Me.txtValue2.Size = New System.Drawing.Size(66, 20)
        Me.txtValue2.TabIndex = 13
        '
        'txtValue1
        '
        Me.txtValue1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtValue1.Location = New System.Drawing.Point(417, 25)
        Me.txtValue1.Name = "txtValue1"
        Me.txtValue1.Size = New System.Drawing.Size(66, 20)
        Me.txtValue1.TabIndex = 11
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(353, 54)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 13)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "Field value"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(353, 28)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 13)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "Field value"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(174, 54)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(51, 13)
        Me.Label10.TabIndex = 19
        Me.Label10.Text = "Field filter"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(174, 28)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(51, 13)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "Field filter"
        '
        'cmdOptions
        '
        Me.cmdOptions.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdOptions.Enabled = False
        Me.cmdOptions.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOptions.Location = New System.Drawing.Point(701, 500)
        Me.cmdOptions.Name = "cmdOptions"
        Me.cmdOptions.Size = New System.Drawing.Size(85, 40)
        Me.cmdOptions.TabIndex = 17
        Me.cmdOptions.Text = "OPTIONS"
        Me.cmdOptions.UseVisualStyleBackColor = True
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPrint.Location = New System.Drawing.Point(519, 546)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(85, 40)
        Me.cmdPrint.TabIndex = 15
        Me.cmdPrint.Text = "PRINT"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'cmdAdd
        '
        Me.cmdAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdAdd.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAdd.Location = New System.Drawing.Point(610, 500)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(85, 86)
        Me.cmdAdd.TabIndex = 16
        Me.cmdAdd.Text = "CREATE NEW BILLING"
        Me.cmdAdd.UseVisualStyleBackColor = True
        '
        'PrintDialog
        '
        Me.PrintDialog.Document = Me.PrintDocument
        Me.PrintDialog.UseEXDialog = True
        '
        'PrintDocument
        '
        '
        'PrintPreviewDialog
        '
        Me.PrintPreviewDialog.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewDialog.Enabled = True
        Me.PrintPreviewDialog.Icon = CType(resources.GetObject("PrintPreviewDialog.Icon"), System.Drawing.Icon)
        Me.PrintPreviewDialog.Name = "PrintPreviewDialog"
        Me.PrintPreviewDialog.Visible = False
        '
        'lblDate2
        '
        Me.lblDate2.AutoSize = True
        Me.lblDate2.Location = New System.Drawing.Point(501, 549)
        Me.lblDate2.Name = "lblDate2"
        Me.lblDate2.Size = New System.Drawing.Size(53, 13)
        Me.lblDate2.TabIndex = 27
        Me.lblDate2.Text = "Date from"
        Me.lblDate2.Visible = False
        '
        'lblDate1
        '
        Me.lblDate1.AutoSize = True
        Me.lblDate1.Location = New System.Drawing.Point(501, 530)
        Me.lblDate1.Name = "lblDate1"
        Me.lblDate1.Size = New System.Drawing.Size(53, 13)
        Me.lblDate1.TabIndex = 26
        Me.lblDate1.Text = "Date from"
        Me.lblDate1.Visible = False
        '
        'cmbPetcs
        '
        Me.cmbPetcs.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbPetcs.FormattingEnabled = True
        Me.cmbPetcs.Location = New System.Drawing.Point(718, 534)
        Me.cmbPetcs.Name = "cmbPetcs"
        Me.cmbPetcs.Size = New System.Drawing.Size(116, 21)
        Me.cmbPetcs.TabIndex = 28
        Me.cmbPetcs.Visible = False
        '
        'lsvDetails
        '
        Me.lsvDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lsvDetails.FullRowSelect = True
        Me.lsvDetails.GridLines = True
        Me.lsvDetails.Location = New System.Drawing.Point(15, 321)
        Me.lsvDetails.Name = "lsvDetails"
        Me.lsvDetails.Size = New System.Drawing.Size(769, 173)
        Me.lsvDetails.TabIndex = 4
        Me.lsvDetails.UseCompatibleStateImageBehavior = False
        Me.lsvDetails.View = System.Windows.Forms.View.Details
        '
        'Label5
        '
        Me.Label5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Cornsilk
        Me.Label5.Location = New System.Drawing.Point(0, 293)
        Me.Label5.Name = "Label5"
        Me.Label5.Padding = New System.Windows.Forms.Padding(5)
        Me.Label5.Size = New System.Drawing.Size(800, 29)
        Me.Label5.TabIndex = 30
        Me.Label5.Text = "Details - Billing transactions"
        '
        'optShowAll
        '
        Me.optShowAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.optShowAll.AutoSize = True
        Me.optShowAll.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.optShowAll.Checked = True
        Me.optShowAll.ForeColor = System.Drawing.Color.White
        Me.optShowAll.Location = New System.Drawing.Point(656, 299)
        Me.optShowAll.Name = "optShowAll"
        Me.optShowAll.Size = New System.Drawing.Size(128, 17)
        Me.optShowAll.TabIndex = 3
        Me.optShowAll.TabStop = True
        Me.optShowAll.Text = "Show debit and credit"
        Me.optShowAll.UseVisualStyleBackColor = False
        Me.optShowAll.Visible = False
        '
        'optShowCreditOnly
        '
        Me.optShowCreditOnly.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.optShowCreditOnly.AutoSize = True
        Me.optShowCreditOnly.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.optShowCreditOnly.ForeColor = System.Drawing.Color.White
        Me.optShowCreditOnly.Location = New System.Drawing.Point(543, 299)
        Me.optShowCreditOnly.Name = "optShowCreditOnly"
        Me.optShowCreditOnly.Size = New System.Drawing.Size(103, 17)
        Me.optShowCreditOnly.TabIndex = 2
        Me.optShowCreditOnly.Text = "Show credit only"
        Me.optShowCreditOnly.UseVisualStyleBackColor = False
        Me.optShowCreditOnly.Visible = False
        '
        'optShowDebitOnly
        '
        Me.optShowDebitOnly.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.optShowDebitOnly.AutoSize = True
        Me.optShowDebitOnly.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.optShowDebitOnly.ForeColor = System.Drawing.Color.White
        Me.optShowDebitOnly.Location = New System.Drawing.Point(429, 299)
        Me.optShowDebitOnly.Name = "optShowDebitOnly"
        Me.optShowDebitOnly.Size = New System.Drawing.Size(100, 17)
        Me.optShowDebitOnly.TabIndex = 1
        Me.optShowDebitOnly.Text = "Show debit only"
        Me.optShowDebitOnly.UseVisualStyleBackColor = False
        Me.optShowDebitOnly.Visible = False
        '
        'frmAccountingPetcBillingManager
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(798, 598)
        Me.ControlBox = False
        Me.Controls.Add(Me.optShowAll)
        Me.Controls.Add(Me.optShowCreditOnly)
        Me.Controls.Add(Me.optShowDebitOnly)
        Me.Controls.Add(Me.lsvDetails)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cmbPetcs)
        Me.Controls.Add(Me.lblDate2)
        Me.Controls.Add(Me.cmdAdd)
        Me.Controls.Add(Me.lblDate1)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdOptions)
        Me.Controls.Add(Me.grpFilters)
        Me.Controls.Add(Me.lblStatusPrompt)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.cmdRefresh)
        Me.Controls.Add(Me.lsvItems)
        Me.Controls.Add(Me.lblHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmAccountingPetcBillingManager"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.grpFilters.ResumeLayout(False)
        Me.grpFilters.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lsvItems As System.Windows.Forms.ListView
    Friend WithEvents timerDataLoad As System.Windows.Forms.Timer
    Friend WithEvents cmdRefresh As System.Windows.Forms.Button
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents lblHeader As System.Windows.Forms.Label
    Friend WithEvents lblStatusPrompt As System.Windows.Forms.Label
    Friend WithEvents grpFilters As System.Windows.Forms.GroupBox
    Friend WithEvents cmbFilter2 As System.Windows.Forms.ComboBox
    Friend WithEvents cmbFilter1 As System.Windows.Forms.ComboBox
    Friend WithEvents txtValue2 As System.Windows.Forms.TextBox
    Friend WithEvents txtValue1 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cmdOptions As System.Windows.Forms.Button
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents txtDateFrom As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdAdd As System.Windows.Forms.Button
    Friend WithEvents txtDateTo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtRecs As System.Windows.Forms.TextBox
    Friend WithEvents PrintDialog As System.Windows.Forms.PrintDialog
    Friend WithEvents PrintDocument As System.Drawing.Printing.PrintDocument
    Friend WithEvents PrintPreviewDialog As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents lblDate2 As System.Windows.Forms.Label
    Friend WithEvents lblDate1 As System.Windows.Forms.Label
    Friend WithEvents chkDisplayActiveOnly As System.Windows.Forms.CheckBox
    Friend WithEvents cmbPetcs As System.Windows.Forms.ComboBox
    Friend WithEvents lsvDetails As System.Windows.Forms.ListView
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents optShowAll As System.Windows.Forms.RadioButton
    Friend WithEvents optShowCreditOnly As System.Windows.Forms.RadioButton
    Friend WithEvents optShowDebitOnly As System.Windows.Forms.RadioButton
End Class
