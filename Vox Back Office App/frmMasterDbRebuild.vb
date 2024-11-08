Public Class frmMasterDbRebuild

    Private Sub frmMasterDbRebuilt_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblPrompt.Text = ""

        timerLoad.Enabled = True
    End Sub

    Private Sub timerLoad_Tick(sender As Object, e As EventArgs) Handles timerLoad.Tick
        timerLoad.Enabled = False
        Dim vTmpVar As Integer
        Dim vDateTime As DateTime
        Dim vDateTimeNow As DateTime

        lblPrompt.Text = ""

        vTmpVar = MsgBox("You are about to re-initinalize and re-build the Master Db from Host." & vbCrLf & vbCrLf & _
                       "This process may take too long depending on the size of the Host data." & vbCrLf & vbCrLf & _
                       "Are you sure you want to proceed?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "User confirmation")

        If vTmpVar <> vbYes Then
            Me.Close()

            Exit Sub
        End If

        vDateTime = DateTime.Now

        Dim vTmpStr As String = ""

        vTmpStr = modModule.MasterDbRebuilt(lblPrompt)

        vDateTimeNow = DateTime.Now

        If Mid(vTmpStr, 1, 2) = "ok" Then

            vTmpVar = MsgBox("Rebuilding of Master DB from Host is complete." & vbCrLf & vbCrLf & _
                             Mid(vTmpStr, 3) & vbCrLf & vbCrLf & _
                             "Elapsed time: " & vDateTimeNow.Subtract(vDateTime).Days.ToString & " days, " & _
                             vDateTimeNow.Subtract(vDateTime).Hours.ToString & " hours, " & _
                             vDateTimeNow.Subtract(vDateTime).Minutes.ToString & " minutes, " & _
                             vDateTimeNow.Subtract(vDateTime).Seconds.ToString & " seconds", _
                             MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Operation complete")

            vTmpStr = modModule.CreateLog(Me.Name, "Master DB - rebuilt", "complete")
        Else
            vTmpVar = MsgBox("Error encountered while rebuilding Master DB from Host." & vbCrLf & vbCrLf & _
                             "Error message: " & Mid(vTmpStr, 6), MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Operation failed")

            vTmpStr = modModule.CreateLog(Me.Name, "Master DB - rebuilt", "Failed. Error message: " & Mid(vTmpStr, 6))
        End If

        Me.Close()
    End Sub
End Class