<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPetcDataTransmissionViewAllFields
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
        Me.timerLoad = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'lsvItems
        '
        Me.lsvItems.FullRowSelect = True
        Me.lsvItems.GridLines = True
        Me.lsvItems.Location = New System.Drawing.Point(23, 23)
        Me.lsvItems.Name = "lsvItems"
        Me.lsvItems.Size = New System.Drawing.Size(658, 504)
        Me.lsvItems.TabIndex = 1
        Me.lsvItems.UseCompatibleStateImageBehavior = False
        Me.lsvItems.View = System.Windows.Forms.View.Details
        '
        'timerLoad
        '
        Me.timerLoad.Interval = 1
        '
        'frmPetcDataTransmissionViewAllFields
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(704, 550)
        Me.Controls.Add(Me.lsvItems)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPetcDataTransmissionViewAllFields"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PETC Data Transmission - View all data"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lsvItems As System.Windows.Forms.ListView
    Friend WithEvents timerLoad As System.Windows.Forms.Timer
End Class
