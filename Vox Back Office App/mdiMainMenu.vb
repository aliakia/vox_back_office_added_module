Imports System.Windows.Forms

Public Class mdiMainMenu

    Private gSystemMessages As String

    Property SystemMessages() As String
        Get
            Return gSystemMessages
        End Get

        Set(ByVal value As String)
            gSystemMessages = value
        End Set
    End Property

    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub mdiMainMenu_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dim vTmpVar As Integer
        'Dim vLogResult As Byte

        vTmpVar = MsgBox("Are you sure you want to log-out " & pUserName & "?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "User confirmation")

        If vTmpVar = MsgBoxResult.No Then
            e.Cancel = True
        Else
            Dim vTmpStr As String

            'log event
            vTmpStr = modModule.CreateLog(Me.Name, "Main Menu - System Log-off", "")

            If vTmpStr = "1" Then
            Else
                e.Cancel = True

                MsgBox("An error occurred while saving log. " & vbCrLf & vbCrLf & _
                       "Error description: " & vTmpStr & vbCrLf & vbCrLf & _
                       "Operation aborted.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Operation cancelled")
            End If
        End If
    End Sub

    Private Sub mdiMainMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim vTmpStr As String

        Me.Text = "VOX DEI EMISSION - BACK OFFICE - MAIN MENU - User " & pUserName & " logged in as " & pUserGroup

        'log event
        vTmpStr = modModule.CreateLog(Me.Name, "Main Menu - Open", "")

        timerLoad.Enabled = True
    End Sub

    Private Sub PETCManagerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PETCManagerToolStripMenuItem.Click
        frmPetcManager.ShowDialog()
    End Sub

    Private Sub NewToolStripButton_Click(sender As Object, e As EventArgs) Handles NewToolStripButton.Click
        frmPetcManager.ShowDialog()
    End Sub

    Private Sub TerminalsManagerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TerminalsManagerToolStripMenuItem.Click
        frmTerminalsManager.ShowDialog()
    End Sub

    Private Sub UsersManagerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UsersManagerToolStripMenuItem.Click
        frmUsersManager.ShowDialog()
    End Sub

    Private Sub PETCBalanceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PETCBalanceToolStripMenuItem.Click
        frmAccountingPetcBalanceManager.ShowDialog()
    End Sub

    Private Sub BackupDatabaseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BackupDatabaseToolStripMenuItem.Click
        frmToolsDatabaseBackup.ShowDialog()
    End Sub

    Private Sub SalesSummaryReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalesSummaryReportToolStripMenuItem.Click
        frmPetcSalesSummaryReport.ShowDialog()
    End Sub

    Private Sub StradcomBalanceManagerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StradcomBalanceManagerToolStripMenuItem.Click
        frmAccountingStradcomBalanceManager.ShowDialog()
    End Sub

    Private Sub DataTransmissionsToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles DataTransmissionsToolStripMenuItem1.Click
        frmPetcDataTransmissions.ShowDialog()
    End Sub

    Private Sub timerLoad_Tick(sender As Object, e As EventArgs) Handles timerLoad.Tick
        timerLoad.Enabled = False

        DoGetSystemMessages()
    End Sub

    Private Sub SystemMessagesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SystemMessagesToolStripMenuItem.Click
        DoGetSystemMessages()
    End Sub

    Private Sub DoGetSystemMessages()
        Dim lblPrompt As New Label
        Dim vSystemMessages As String
        Dim vTmpStr As String

        vSystemMessages = modModule.GetSystemMessages(lblPrompt)

        'log event
        vTmpStr = modModule.CreateLog(Me.Name, "System messages", vSystemMessages)

        With frmViewSystemMessages
            .SystemMessages = vSystemMessages

            .ShowDialog()
        End With
    End Sub

    Private Sub MonthlyPerformanceReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MonthlyPerformanceReportToolStripMenuItem.Click
        frmPetcReportsPerformance.ShowDialog()
    End Sub

    Private Sub PETCBillingManagerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PETCBillingManagerToolStripMenuItem.Click
        frmAccountingPetcBillingManager.ShowDialog()
    End Sub

    Private Sub InitializeAndRebuiltMasterDBToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InitializeAndRebuiltMasterDBToolStripMenuItem.Click
        frmMasterDbRebuild.ShowDialog()
    End Sub

    Private Sub MasterDBManagerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MasterDBManagerToolStripMenuItem.Click
        frmMasterDbManager.ShowDialog()
    End Sub

    Private Sub PETCToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles PETCToolStripMenuItem2.Click
        frmMaintenanceEWalletPetc.ShowDialog()
    End Sub

    Private Sub UserActivitiesbackofficeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UserActivitiesbackofficeToolStripMenuItem.Click
        frmLogsUserActivities.ShowDialog()
    End Sub

    Private Sub SystemActivitiesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SystemActivitiesToolStripMenuItem.Click
        frmLogsSystemActivities.ShowDialog()
    End Sub

    Private Sub StradcomToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StradcomToolStripMenuItem.Click

    End Sub

    Private Sub CountriesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CountriesToolStripMenuItem.Click
        frmRegionsProvincesCities.ShowDialog()
    End Sub

    Private Sub HolidaysManagerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HolidaysManagerToolStripMenuItem.Click
        frmHolidaysManager.ShowDialog()
    End Sub

    Private Sub MonitoringToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MonitoringToolStripMenuItem.Click
        frmToolsMonitoringReport.ShowDialog()
    End Sub

    Private Sub ForUploadMonitoringToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ForUploadMonitoringToolStripMenuItem.Click
        frmPetcForUploadMonitoring.ShowDialog()
    End Sub

    Private Sub AddColorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddColorToolStripMenuItem.Click
        frmAddColorModule.ShowDialog()
    End Sub

    Private Sub AddMakeAndSeriesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddMakeAndSeriesToolStripMenuItem.Click
        frmAddMakeSeries.showDialog()
    End Sub

    Private Sub BodyTypesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BodyTypesToolStripMenuItem.Click
        frmBodyTypes.showDialog()
    End Sub
End Class
