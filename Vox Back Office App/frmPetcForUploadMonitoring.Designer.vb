<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPetcForUploadMonitoring
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
        Me.txtAutoRefreshInterval = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.chkAutoRefresh = New System.Windows.Forms.CheckBox()
        Me.txtRecs = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtPetcCode = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.chkShowForCheckingOnly = New System.Windows.Forms.CheckBox()
        Me.txtDateTo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtDateFrom = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdPrint = New System.Windows.Forms.Button()
        Me.cmdDetails = New System.Windows.Forms.Button()
        Me.grpImages = New System.Windows.Forms.GroupBox()
        Me.cmdEnlargeImage = New System.Windows.Forms.Button()
        Me.picImage5 = New System.Windows.Forms.PictureBox()
        Me.picImage4 = New System.Windows.Forms.PictureBox()
        Me.picImage3 = New System.Windows.Forms.PictureBox()
        Me.picImage2 = New System.Windows.Forms.PictureBox()
        Me.picImage1 = New System.Windows.Forms.PictureBox()
        Me.cmdClear = New System.Windows.Forms.Button()
        Me.timerAutoRefresh = New System.Windows.Forms.Timer(Me.components)
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
        Me.lsvItems.Size = New System.Drawing.Size(1340, 338)
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
        Me.cmdRefresh.Location = New System.Drawing.Point(794, 633)
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.Size = New System.Drawing.Size(102, 53)
        Me.cmdRefresh.TabIndex = 11
        Me.cmdRefresh.Text = "&Refresh"
        Me.cmdRefresh.UseVisualStyleBackColor = True
        '
        'cmdClose
        '
        Me.cmdClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClose.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClose.Location = New System.Drawing.Point(1267, 633)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(85, 53)
        Me.cmdClose.TabIndex = 15
        Me.cmdClose.Text = "&Close"
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
        Me.lblHeader.Text = "PETC DATA - For Upload Monitoring"
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
        Me.grpFilters.Controls.Add(Me.txtAutoRefreshInterval)
        Me.grpFilters.Controls.Add(Me.Label6)
        Me.grpFilters.Controls.Add(Me.chkAutoRefresh)
        Me.grpFilters.Controls.Add(Me.txtRecs)
        Me.grpFilters.Controls.Add(Me.Label4)
        Me.grpFilters.Controls.Add(Me.Label3)
        Me.grpFilters.Controls.Add(Me.txtPetcCode)
        Me.grpFilters.Controls.Add(Me.Label5)
        Me.grpFilters.Controls.Add(Me.chkShowForCheckingOnly)
        Me.grpFilters.Controls.Add(Me.txtDateTo)
        Me.grpFilters.Controls.Add(Me.Label2)
        Me.grpFilters.Controls.Add(Me.txtDateFrom)
        Me.grpFilters.Controls.Add(Me.Label1)
        Me.grpFilters.Location = New System.Drawing.Point(12, 633)
        Me.grpFilters.Name = "grpFilters"
        Me.grpFilters.Size = New System.Drawing.Size(776, 53)
        Me.grpFilters.TabIndex = 3
        Me.grpFilters.TabStop = False
        Me.grpFilters.Text = "Filters: "
        '
        'txtAutoRefreshInterval
        '
        Me.txtAutoRefreshInterval.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAutoRefreshInterval.Location = New System.Drawing.Point(543, 24)
        Me.txtAutoRefreshInterval.Name = "txtAutoRefreshInterval"
        Me.txtAutoRefreshInterval.Size = New System.Drawing.Size(22, 20)
        Me.txtAutoRefreshInterval.TabIndex = 9
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(568, 27)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 13)
        Me.Label6.TabIndex = 36
        Me.Label6.Text = "minute(s)"
        '
        'chkAutoRefresh
        '
        Me.chkAutoRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkAutoRefresh.AutoSize = True
        Me.chkAutoRefresh.Location = New System.Drawing.Point(433, 26)
        Me.chkAutoRefresh.Name = "chkAutoRefresh"
        Me.chkAutoRefresh.Size = New System.Drawing.Size(112, 17)
        Me.chkAutoRefresh.TabIndex = 8
        Me.chkAutoRefresh.Text = "Auto refresh every"
        Me.chkAutoRefresh.UseVisualStyleBackColor = True
        '
        'txtRecs
        '
        Me.txtRecs.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtRecs.Location = New System.Drawing.Point(122, 0)
        Me.txtRecs.Name = "txtRecs"
        Me.txtRecs.Size = New System.Drawing.Size(46, 20)
        Me.txtRecs.TabIndex = 4
        Me.txtRecs.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(169, 3)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 13)
        Me.Label4.TabIndex = 29
        Me.Label4.Text = "records only"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(68, 3)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 13)
        Me.Label3.TabIndex = 28
        Me.Label3.Text = "Show first"
        '
        'txtPetcCode
        '
        Me.txtPetcCode.Location = New System.Drawing.Point(335, 24)
        Me.txtPetcCode.Name = "txtPetcCode"
        Me.txtPetcCode.Size = New System.Drawing.Size(75, 20)
        Me.txtPetcCode.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(266, 27)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 13)
        Me.Label5.TabIndex = 27
        Me.Label5.Text = "PETC Code"
        '
        'chkShowForCheckingOnly
        '
        Me.chkShowForCheckingOnly.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkShowForCheckingOnly.AutoSize = True
        Me.chkShowForCheckingOnly.Checked = True
        Me.chkShowForCheckingOnly.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkShowForCheckingOnly.Location = New System.Drawing.Point(632, 26)
        Me.chkShowForCheckingOnly.Name = "chkShowForCheckingOnly"
        Me.chkShowForCheckingOnly.Size = New System.Drawing.Size(137, 17)
        Me.chkShowForCheckingOnly.TabIndex = 10
        Me.chkShowForCheckingOnly.Text = "Show for checking only"
        Me.chkShowForCheckingOnly.UseVisualStyleBackColor = True
        '
        'txtDateTo
        '
        Me.txtDateTo.Location = New System.Drawing.Point(172, 24)
        Me.txtDateTo.Name = "txtDateTo"
        Me.txtDateTo.Size = New System.Drawing.Size(75, 20)
        Me.txtDateTo.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(152, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(16, 13)
        Me.Label2.TabIndex = 25
        Me.Label2.Text = "to"
        '
        'txtDateFrom
        '
        Me.txtDateFrom.Location = New System.Drawing.Point(71, 24)
        Me.txtDateFrom.Name = "txtDateFrom"
        Me.txtDateFrom.Size = New System.Drawing.Size(75, 20)
        Me.txtDateFrom.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 13)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "Date from"
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Enabled = False
        Me.cmdPrint.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPrint.Location = New System.Drawing.Point(1189, 633)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(72, 53)
        Me.cmdPrint.TabIndex = 14
        Me.cmdPrint.Text = "Print"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'cmdDetails
        '
        Me.cmdDetails.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdDetails.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.cmdDetails.Location = New System.Drawing.Point(1069, 633)
        Me.cmdDetails.Name = "cmdDetails"
        Me.cmdDetails.Size = New System.Drawing.Size(114, 53)
        Me.cmdDetails.TabIndex = 13
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
        Me.grpImages.Location = New System.Drawing.Point(12, 372)
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
        'cmdClear
        '
        Me.cmdClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClear.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClear.Location = New System.Drawing.Point(902, 633)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(161, 53)
        Me.cmdClear.TabIndex = 12
        Me.cmdClear.Text = "C&lear for uploading"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'timerAutoRefresh
        '
        Me.timerAutoRefresh.Interval = 1000
        '
        'frmPetcForUploadMonitoring
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1364, 698)
        Me.ControlBox = False
        Me.Controls.Add(Me.cmdClear)
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
        Me.Name = "frmPetcForUploadMonitoring"
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
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents txtDateFrom As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdDetails As System.Windows.Forms.Button
    Friend WithEvents txtDateTo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtRecs As System.Windows.Forms.TextBox
    Friend WithEvents chkShowForCheckingOnly As System.Windows.Forms.CheckBox
    Friend WithEvents grpImages As System.Windows.Forms.GroupBox
    Friend WithEvents picImage2 As System.Windows.Forms.PictureBox
    Friend WithEvents picImage1 As System.Windows.Forms.PictureBox
    Friend WithEvents picImage5 As System.Windows.Forms.PictureBox
    Friend WithEvents picImage4 As System.Windows.Forms.PictureBox
    Friend WithEvents picImage3 As System.Windows.Forms.PictureBox
    Friend WithEvents cmdEnlargeImage As System.Windows.Forms.Button
    Friend WithEvents txtPetcCode As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents timerAutoRefresh As System.Windows.Forms.Timer
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents chkAutoRefresh As System.Windows.Forms.CheckBox
    Friend WithEvents txtAutoRefreshInterval As System.Windows.Forms.TextBox
End Class
