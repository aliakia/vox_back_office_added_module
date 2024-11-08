<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPetcDataTransmissionsEnlargeImage
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
        Me.picImage5 = New System.Windows.Forms.PictureBox()
        Me.picImage4 = New System.Windows.Forms.PictureBox()
        Me.picImage3 = New System.Windows.Forms.PictureBox()
        Me.picImage2 = New System.Windows.Forms.PictureBox()
        Me.picImage1 = New System.Windows.Forms.PictureBox()
        Me.optImage1 = New System.Windows.Forms.RadioButton()
        Me.optImage2 = New System.Windows.Forms.RadioButton()
        Me.optImage3 = New System.Windows.Forms.RadioButton()
        Me.optImage4 = New System.Windows.Forms.RadioButton()
        Me.optImage5 = New System.Windows.Forms.RadioButton()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.timerLoad = New System.Windows.Forms.Timer(Me.components)
        CType(Me.picImage5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picImage4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picImage3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picImage2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picImage1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'picImage5
        '
        Me.picImage5.Location = New System.Drawing.Point(561, 210)
        Me.picImage5.Name = "picImage5"
        Me.picImage5.Size = New System.Drawing.Size(256, 192)
        Me.picImage5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picImage5.TabIndex = 9
        Me.picImage5.TabStop = False
        '
        'picImage4
        '
        Me.picImage4.Location = New System.Drawing.Point(299, 210)
        Me.picImage4.Name = "picImage4"
        Me.picImage4.Size = New System.Drawing.Size(256, 192)
        Me.picImage4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picImage4.TabIndex = 8
        Me.picImage4.TabStop = False
        '
        'picImage3
        '
        Me.picImage3.Location = New System.Drawing.Point(561, 12)
        Me.picImage3.Name = "picImage3"
        Me.picImage3.Size = New System.Drawing.Size(256, 192)
        Me.picImage3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picImage3.TabIndex = 7
        Me.picImage3.TabStop = False
        '
        'picImage2
        '
        Me.picImage2.Location = New System.Drawing.Point(299, 12)
        Me.picImage2.Name = "picImage2"
        Me.picImage2.Size = New System.Drawing.Size(256, 192)
        Me.picImage2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picImage2.TabIndex = 6
        Me.picImage2.TabStop = False
        '
        'picImage1
        '
        Me.picImage1.Location = New System.Drawing.Point(12, 12)
        Me.picImage1.Name = "picImage1"
        Me.picImage1.Size = New System.Drawing.Size(768, 576)
        Me.picImage1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picImage1.TabIndex = 5
        Me.picImage1.TabStop = False
        '
        'optImage1
        '
        Me.optImage1.AutoSize = True
        Me.optImage1.Location = New System.Drawing.Point(44, 613)
        Me.optImage1.Name = "optImage1"
        Me.optImage1.Size = New System.Drawing.Size(63, 17)
        Me.optImage1.TabIndex = 0
        Me.optImage1.TabStop = True
        Me.optImage1.Text = "Image 1"
        Me.optImage1.UseVisualStyleBackColor = True
        '
        'optImage2
        '
        Me.optImage2.AutoSize = True
        Me.optImage2.Location = New System.Drawing.Point(137, 613)
        Me.optImage2.Name = "optImage2"
        Me.optImage2.Size = New System.Drawing.Size(63, 17)
        Me.optImage2.TabIndex = 1
        Me.optImage2.TabStop = True
        Me.optImage2.Text = "Image 2"
        Me.optImage2.UseVisualStyleBackColor = True
        '
        'optImage3
        '
        Me.optImage3.AutoSize = True
        Me.optImage3.Location = New System.Drawing.Point(230, 613)
        Me.optImage3.Name = "optImage3"
        Me.optImage3.Size = New System.Drawing.Size(63, 17)
        Me.optImage3.TabIndex = 2
        Me.optImage3.TabStop = True
        Me.optImage3.Text = "Image 3"
        Me.optImage3.UseVisualStyleBackColor = True
        '
        'optImage4
        '
        Me.optImage4.AutoSize = True
        Me.optImage4.Location = New System.Drawing.Point(323, 613)
        Me.optImage4.Name = "optImage4"
        Me.optImage4.Size = New System.Drawing.Size(63, 17)
        Me.optImage4.TabIndex = 3
        Me.optImage4.TabStop = True
        Me.optImage4.Text = "Image 4"
        Me.optImage4.UseVisualStyleBackColor = True
        '
        'optImage5
        '
        Me.optImage5.AutoSize = True
        Me.optImage5.Location = New System.Drawing.Point(416, 613)
        Me.optImage5.Name = "optImage5"
        Me.optImage5.Size = New System.Drawing.Size(63, 17)
        Me.optImage5.TabIndex = 4
        Me.optImage5.TabStop = True
        Me.optImage5.Text = "Image 5"
        Me.optImage5.UseVisualStyleBackColor = True
        '
        'cmdClose
        '
        Me.cmdClose.Location = New System.Drawing.Point(674, 604)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(105, 41)
        Me.cmdClose.TabIndex = 5
        Me.cmdClose.Text = "&CLOSE"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'timerLoad
        '
        Me.timerLoad.Interval = 1
        '
        'frmPetcDataTransmissionsEnlargeImage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(791, 656)
        Me.ControlBox = False
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.optImage5)
        Me.Controls.Add(Me.optImage4)
        Me.Controls.Add(Me.optImage3)
        Me.Controls.Add(Me.optImage2)
        Me.Controls.Add(Me.optImage1)
        Me.Controls.Add(Me.picImage5)
        Me.Controls.Add(Me.picImage4)
        Me.Controls.Add(Me.picImage3)
        Me.Controls.Add(Me.picImage2)
        Me.Controls.Add(Me.picImage1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmPetcDataTransmissionsEnlargeImage"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PETC Data Transmission - Image view"
        CType(Me.picImage5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picImage4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picImage3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picImage2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picImage1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents picImage5 As System.Windows.Forms.PictureBox
    Friend WithEvents picImage4 As System.Windows.Forms.PictureBox
    Friend WithEvents picImage3 As System.Windows.Forms.PictureBox
    Friend WithEvents picImage2 As System.Windows.Forms.PictureBox
    Friend WithEvents picImage1 As System.Windows.Forms.PictureBox
    Friend WithEvents optImage1 As System.Windows.Forms.RadioButton
    Friend WithEvents optImage2 As System.Windows.Forms.RadioButton
    Friend WithEvents optImage3 As System.Windows.Forms.RadioButton
    Friend WithEvents optImage4 As System.Windows.Forms.RadioButton
    Friend WithEvents optImage5 As System.Windows.Forms.RadioButton
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents timerLoad As System.Windows.Forms.Timer
End Class
