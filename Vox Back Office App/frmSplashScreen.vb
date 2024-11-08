Imports System.Security.Cryptography
Imports System.Threading

Public Class frmSplashScreen

    Private Sub frmSplashScreen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    End Sub

    Private Sub timerLoad_Tick(sender As Object, e As EventArgs) Handles timerLoad.Tick
        timerLoad.Enabled = False

        Me.Close()
    End Sub
End Class
