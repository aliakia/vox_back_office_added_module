Public Class frmToolsDatabaseBackup

    Private Sub frmToolsDatabaseBackup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblPrompt.Text = ""

        timerLoad.Enabled = True
    End Sub

    Private Sub timerLoad_Tick(sender As Object, e As EventArgs) Handles timerLoad.Tick
        timerLoad.Enabled = False
        Dim vTmpVar As Integer

        lblPrompt.Text = ""

        Dim vTmpStr As String = ""

        vTmpStr = modModule.BackupVoxDatabase(lblPrompt)

        If vTmpStr = "ok" Then
            vTmpVar = MsgBox("Database backup complete.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Operation complete")

            vTmpStr = modModule.CreateLog(Me.Name, "Database backup", "complete")
        Else
            vTmpVar = MsgBox("Error encountered while performing database backup." & vbCrLf & vbCrLf & _
                             "Error message: " & Mid(vTmpStr, 6), MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Operation failed")

            vTmpStr = modModule.CreateLog(Me.Name, "Database backup", "Failed. Error message: " & Mid(vTmpStr, 6))
        End If

        Me.Close()
    End Sub
End Class