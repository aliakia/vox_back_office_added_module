Public Class frmViewSystemMessages

    Private gSystemMessages As String

    Property SystemMessages() As String
        Get
            Return gSystemMessages
        End Get

        Set(ByVal value As String)
            gSystemMessages = value
        End Set
    End Property

    Private Sub frmViewSystemMessages_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then Me.Close()
    End Sub

    Private Sub frmViewSystemMessages_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True

        Me.Text = "Attention " & pUserName

        txtMessages.Text = ""
        txtMessages.ReadOnly = True

        timerLoad.Enabled = True
    End Sub

    Private Sub timerLoad_Tick(sender As Object, e As EventArgs) Handles timerLoad.Tick
        timerLoad.Enabled = False

        txtMessages.Text = Me.SystemMessages
    End Sub

    Private Sub cmdClose_Click(sender As Object, e As EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub
End Class