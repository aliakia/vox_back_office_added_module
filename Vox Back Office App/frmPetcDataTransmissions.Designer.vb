<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPetcDataTransmissions
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
        Me.cmdRefresh = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.lblHeader = New System.Windows.Forms.Label()
        Me.lblStatusPrompt = New System.Windows.Forms.Label()
        Me.grpFilters = New System.Windows.Forms.GroupBox()
        Me.chkExcludeReTest = New System.Windows.Forms.CheckBox()
        Me.chkExcludeRePrint = New System.Windows.Forms.CheckBox()
        Me.chkExcludeUnprocessedLTO = New System.Windows.Forms.CheckBox()
        Me.chkExcludeUnprocessedStradcom = New System.Windows.Forms.CheckBox()
        Me.chkExcludeInvalid = New System.Windows.Forms.CheckBox()
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
        Me.cmdPrint = New System.Windows.Forms.Button()
        Me.cmdDetails = New System.Windows.Forms.Button()
        Me.grpImages = New System.Windows.Forms.GroupBox()
        Me.cmdEnlargeImage = New System.Windows.Forms.Button()
        Me.picImage5 = New System.Windows.Forms.PictureBox()
        Me.picImage4 = New System.Windows.Forms.PictureBox()
        Me.picImage3 = New System.Windows.Forms.PictureBox()
        Me.picImage2 = New System.Windows.Forms.PictureBox()
        Me.picImage1 = New System.Windows.Forms.PictureBox()
        Me.grpFilters.SuspendLayout()
        Me.grpImages.SuspendLayout()
        CType(Me.picImage5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picImage4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picImage3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picImage2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picImage1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.lsvItems.Size = New System.Drawing.Size(1340, 305)
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
        Me.cmdRefresh.Location = New System.Drawing.Point(1174, 600)
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.Size = New System.Drawing.Size(85, 40)
        Me.cmdRefresh.TabIndex = 16
        Me.cmdRefresh.Text = "&REFRESH"
        Me.cmdRefresh.UseVisualStyleBackColor = True
        '
        'cmdClose
        '
        Me.cmdClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClose.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClose.Location = New System.Drawing.Point(1267, 646)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(85, 40)
        Me.cmdClose.TabIndex = 19
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
        Me.lblHeader.Size = New System.Drawing.Size(1366, 29)
        Me.lblHeader.TabIndex = 3
        Me.lblHeader.Text = "PETC Data Transmissions"
        '
        'lblStatusPrompt
        '
        Me.lblStatusPrompt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblStatusPrompt.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblStatusPrompt.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblStatusPrompt.Location = New System.Drawing.Point(831, 2)
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
        Me.grpFilters.Controls.Add(Me.chkExcludeReTest)
        Me.grpFilters.Controls.Add(Me.chkExcludeRePrint)
        Me.grpFilters.Controls.Add(Me.chkExcludeUnprocessedLTO)
        Me.grpFilters.Controls.Add(Me.chkExcludeUnprocessedStradcom)
        Me.grpFilters.Controls.Add(Me.chkExcludeInvalid)
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
        Me.grpFilters.Location = New System.Drawing.Point(12, 600)
        Me.grpFilters.Name = "grpFilters"
        Me.grpFilters.Size = New System.Drawing.Size(1156, 86)
        Me.grpFilters.TabIndex = 3
        Me.grpFilters.TabStop = False
        Me.grpFilters.Text = "Filters:  Show                             records only"
        '
        'chkExcludeReTest
        '
        Me.chkExcludeReTest.AutoSize = True
        Me.chkExcludeReTest.Location = New System.Drawing.Point(420, 58)
        Me.chkExcludeReTest.Name = "chkExcludeReTest"
        Me.chkExcludeReTest.Size = New System.Drawing.Size(96, 17)
        Me.chkExcludeReTest.TabIndex = 11
        Me.chkExcludeReTest.Text = "Exclude re-test"
        Me.chkExcludeReTest.UseVisualStyleBackColor = True
        '
        'chkExcludeRePrint
        '
        Me.chkExcludeRePrint.AutoSize = True
        Me.chkExcludeRePrint.Location = New System.Drawing.Point(307, 58)
        Me.chkExcludeRePrint.Name = "chkExcludeRePrint"
        Me.chkExcludeRePrint.Size = New System.Drawing.Size(99, 17)
        Me.chkExcludeRePrint.TabIndex = 10
        Me.chkExcludeRePrint.Text = "Exclude re-print"
        Me.chkExcludeRePrint.UseVisualStyleBackColor = True
        '
        'chkExcludeUnprocessedLTO
        '
        Me.chkExcludeUnprocessedLTO.AutoSize = True
        Me.chkExcludeUnprocessedLTO.Location = New System.Drawing.Point(420, 31)
        Me.chkExcludeUnprocessedLTO.Name = "chkExcludeUnprocessedLTO"
        Me.chkExcludeUnprocessedLTO.Size = New System.Drawing.Size(166, 17)
        Me.chkExcludeUnprocessedLTO.TabIndex = 8
        Me.chkExcludeUnprocessedLTO.Text = "Exclude unprocessed by LTO"
        Me.chkExcludeUnprocessedLTO.UseVisualStyleBackColor = True
        '
        'chkExcludeUnprocessedStradcom
        '
        Me.chkExcludeUnprocessedStradcom.AutoSize = True
        Me.chkExcludeUnprocessedStradcom.Location = New System.Drawing.Point(192, 31)
        Me.chkExcludeUnprocessedStradcom.Name = "chkExcludeUnprocessedStradcom"
        Me.chkExcludeUnprocessedStradcom.Size = New System.Drawing.Size(190, 17)
        Me.chkExcludeUnprocessedStradcom.TabIndex = 7
        Me.chkExcludeUnprocessedStradcom.Text = "Exclude unprocessed by Stradcom"
        Me.chkExcludeUnprocessedStradcom.UseVisualStyleBackColor = True
        '
        'chkExcludeInvalid
        '
        Me.chkExcludeInvalid.AutoSize = True
        Me.chkExcludeInvalid.Location = New System.Drawing.Point(192, 58)
        Me.chkExcludeInvalid.Name = "chkExcludeInvalid"
        Me.chkExcludeInvalid.Size = New System.Drawing.Size(97, 17)
        Me.chkExcludeInvalid.TabIndex = 9
        Me.chkExcludeInvalid.Text = "Exclude invalid"
        Me.chkExcludeInvalid.UseVisualStyleBackColor = True
        '
        'txtRecs
        '
        Me.txtRecs.Location = New System.Drawing.Point(79, 0)
        Me.txtRecs.Name = "txtRecs"
        Me.txtRecs.Size = New System.Drawing.Size(75, 20)
        Me.txtRecs.TabIndex = 4
        Me.txtRecs.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDateTo
        '
        Me.txtDateTo.Location = New System.Drawing.Point(79, 55)
        Me.txtDateTo.Name = "txtDateTo"
        Me.txtDateTo.Size = New System.Drawing.Size(75, 20)
        Me.txtDateTo.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(57, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(16, 13)
        Me.Label2.TabIndex = 25
        Me.Label2.Text = "to"
        '
        'txtDateFrom
        '
        Me.txtDateFrom.Location = New System.Drawing.Point(79, 29)
        Me.txtDateFrom.Name = "txtDateFrom"
        Me.txtDateFrom.Size = New System.Drawing.Size(75, 20)
        Me.txtDateFrom.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(20, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 13)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "Date from"
        '
        'cmbFilter2
        '
        Me.cmbFilter2.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbFilter2.FormattingEnabled = True
        Me.cmbFilter2.Location = New System.Drawing.Point(678, 56)
        Me.cmbFilter2.Name = "cmbFilter2"
        Me.cmbFilter2.Size = New System.Drawing.Size(301, 21)
        Me.cmbFilter2.TabIndex = 14
        '
        'cmbFilter1
        '
        Me.cmbFilter1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbFilter1.FormattingEnabled = True
        Me.cmbFilter1.Location = New System.Drawing.Point(678, 29)
        Me.cmbFilter1.Name = "cmbFilter1"
        Me.cmbFilter1.Size = New System.Drawing.Size(301, 21)
        Me.cmbFilter1.TabIndex = 12
        '
        'txtValue2
        '
        Me.txtValue2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.txtValue2.Location = New System.Drawing.Point(1049, 55)
        Me.txtValue2.Name = "txtValue2"
        Me.txtValue2.Size = New System.Drawing.Size(91, 20)
        Me.txtValue2.TabIndex = 15
        '
        'txtValue1
        '
        Me.txtValue1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.txtValue1.Location = New System.Drawing.Point(1049, 29)
        Me.txtValue1.Name = "txtValue1"
        Me.txtValue1.Size = New System.Drawing.Size(91, 20)
        Me.txtValue1.TabIndex = 13
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(985, 58)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 13)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "Field value"
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(985, 32)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 13)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "Field value"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(621, 58)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(51, 13)
        Me.Label10.TabIndex = 19
        Me.Label10.Text = "Field filter"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(621, 32)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(51, 13)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "Field filter"
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Enabled = False
        Me.cmdPrint.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPrint.Location = New System.Drawing.Point(1174, 646)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(85, 40)
        Me.cmdPrint.TabIndex = 18
        Me.cmdPrint.Text = "PRINT"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'cmdDetails
        '
        Me.cmdDetails.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdDetails.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDetails.Location = New System.Drawing.Point(1267, 600)
        Me.cmdDetails.Name = "cmdDetails"
        Me.cmdDetails.Size = New System.Drawing.Size(85, 40)
        Me.cmdDetails.TabIndex = 17
        Me.cmdDetails.Text = "View all data"
        Me.cmdDetails.UseVisualStyleBackColor = True
        '
        'grpImages
        '
        Me.grpImages.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpImages.Controls.Add(Me.cmdEnlargeImage)
        Me.grpImages.Controls.Add(Me.picImage5)
        Me.grpImages.Controls.Add(Me.picImage4)
        Me.grpImages.Controls.Add(Me.picImage3)
        Me.grpImages.Controls.Add(Me.picImage2)
        Me.grpImages.Controls.Add(Me.picImage1)
        Me.grpImages.Location = New System.Drawing.Point(12, 339)
        Me.grpImages.Name = "grpImages"
        Me.grpImages.Size = New System.Drawing.Size(1340, 255)
        Me.grpImages.TabIndex = 1
        Me.grpImages.TabStop = False
        Me.grpImages.Text = "Images:"
        '
        'cmdEnlargeImage
        '
        Me.cmdEnlargeImage.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdEnlargeImage.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdEnlargeImage.Location = New System.Drawing.Point(1242, 5)
        Me.cmdEnlargeImage.Name = "cmdEnlargeImage"
        Me.cmdEnlargeImage.Size = New System.Drawing.Size(99, 27)
        Me.cmdEnlargeImage.TabIndex = 2
        Me.cmdEnlargeImage.Text = "&enlarge images"
        Me.cmdEnlargeImage.UseVisualStyleBackColor = True
        '
        'picImage5
        '
        Me.picImage5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picImage5.Location = New System.Drawing.Point(1014, 17)
        Me.picImage5.Name = "picImage5"
        Me.picImage5.Size = New System.Drawing.Size(330, 230)
        Me.picImage5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picImage5.TabIndex = 4
        Me.picImage5.TabStop = False
        '
        'picImage4
        '
        Me.picImage4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picImage4.Location = New System.Drawing.Point(678, 17)
        Me.picImage4.Name = "picImage4"
        Me.picImage4.Size = New System.Drawing.Size(330, 230)
        Me.picImage4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picImage4.TabIndex = 3
        Me.picImage4.TabStop = False
        '
        'picImage3
        '
        Me.picImage3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picImage3.Location = New System.Drawing.Point(342, 17)
        Me.picImage3.Name = "picImage3"
        Me.picImage3.Size = New System.Drawing.Size(330, 230)
        Me.picImage3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picImage3.TabIndex = 2
        Me.picImage3.TabStop = False
        '
        'picImage2
        '
        Me.picImage2.Location = New System.Drawing.Point(139, 102)
        Me.picImage2.Name = "picImage2"
        Me.picImage2.Size = New System.Drawing.Size(270, 189)
        Me.picImage2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picImage2.TabIndex = 1
        Me.picImage2.TabStop = False
        Me.picImage2.Visible = False
        '
        'picImage1
        '
        Me.picImage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picImage1.Location = New System.Drawing.Point(6, 17)
        Me.picImage1.Name = "picImage1"
        Me.picImage1.Size = New System.Drawing.Size(330, 230)
        Me.picImage1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picImage1.TabIndex = 0
        Me.picImage1.TabStop = False
        '
        'frmPetcDataTransmissions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1364, 698)
        Me.ControlBox = False
        Me.Controls.Add(Me.grpImages)
        Me.Controls.Add(Me.cmdDetails)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.grpFilters)
        Me.Controls.Add(Me.lblStatusPrompt)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.cmdRefresh)
        Me.Controls.Add(Me.lsvItems)
        Me.Controls.Add(Me.lblHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmPetcDataTransmissions"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.grpFilters.ResumeLayout(False)
        Me.grpFilters.PerformLayout()
        Me.grpImages.ResumeLayout(False)
        CType(Me.picImage5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picImage4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picImage3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picImage2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picImage1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

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
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents txtDateFrom As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdDetails As System.Windows.Forms.Button
    Friend WithEvents txtDateTo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtRecs As System.Windows.Forms.TextBox
    Friend WithEvents chkExcludeUnprocessedStradcom As System.Windows.Forms.CheckBox
    Friend WithEvents chkExcludeInvalid As System.Windows.Forms.CheckBox
    Friend WithEvents chkExcludeUnprocessedLTO As System.Windows.Forms.CheckBox
    Friend WithEvents chkExcludeReTest As System.Windows.Forms.CheckBox
    Friend WithEvents chkExcludeRePrint As System.Windows.Forms.CheckBox
    Friend WithEvents grpImages As System.Windows.Forms.GroupBox
    Friend WithEvents picImage2 As System.Windows.Forms.PictureBox
    Friend WithEvents picImage1 As System.Windows.Forms.PictureBox
    Friend WithEvents picImage5 As System.Windows.Forms.PictureBox
    Friend WithEvents picImage4 As System.Windows.Forms.PictureBox
    Friend WithEvents picImage3 As System.Windows.Forms.PictureBox
    Friend WithEvents cmdEnlargeImage As System.Windows.Forms.Button
End Class
