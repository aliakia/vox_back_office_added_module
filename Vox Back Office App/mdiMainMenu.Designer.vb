<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class mdiMainMenu
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(mdiMainMenu))
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.FileMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.UsersManagerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ManagingAccountsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TerminalsManagerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PETCManagerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripSeparator()
        Me.CountriesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HolidaysManagerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.MasterDBToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.InitializeAndRebuiltMasterDBToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UpdateMasterDBFromEmissionDBToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator()
        Me.MasterDBManagerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AccountingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PETCBalanceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StradcomBalanceManagerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PETCBillingManagerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PETCToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalesSummaryReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MonthlyPerformanceReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VIewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PETCToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.DataTransmissionsToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ForUploadMonitoringToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UserActivityLogsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UserActivitiesbackofficeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SystemActivitiesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SystemMessagesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MaintenanceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EWalletToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PETCToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.StradcomToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolsMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.BackupDatabaseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.OptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MonitoringToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddColorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddMakeAndSeriesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BodyTypesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.IndexToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SearchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.NewToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.HelpToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.timerLoad = New System.Windows.Forms.Timer(Me.components)
        Me.MenuStrip.SuspendLayout()
        Me.ToolStrip.SuspendLayout()
        Me.StatusStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip
        '
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileMenu, Me.AccountingToolStripMenuItem, Me.SalesToolStripMenuItem, Me.VIewToolStripMenuItem, Me.MaintenanceToolStripMenuItem, Me.ToolsMenu, Me.HelpMenu})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(1155, 24)
        Me.MenuStrip.TabIndex = 5
        Me.MenuStrip.Text = "MenuStrip"
        '
        'FileMenu
        '
        Me.FileMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UsersManagerToolStripMenuItem, Me.ManagingAccountsToolStripMenuItem, Me.TerminalsManagerToolStripMenuItem, Me.PETCManagerToolStripMenuItem, Me.ToolStripMenuItem4, Me.CountriesToolStripMenuItem, Me.HolidaysManagerToolStripMenuItem, Me.ToolStripSeparator3, Me.MasterDBToolStripMenuItem1, Me.ToolStripMenuItem2, Me.ExitToolStripMenuItem})
        Me.FileMenu.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder
        Me.FileMenu.Name = "FileMenu"
        Me.FileMenu.Size = New System.Drawing.Size(37, 20)
        Me.FileMenu.Text = "&File"
        '
        'UsersManagerToolStripMenuItem
        '
        Me.UsersManagerToolStripMenuItem.Name = "UsersManagerToolStripMenuItem"
        Me.UsersManagerToolStripMenuItem.Size = New System.Drawing.Size(302, 22)
        Me.UsersManagerToolStripMenuItem.Text = "Users Manager"
        '
        'ManagingAccountsToolStripMenuItem
        '
        Me.ManagingAccountsToolStripMenuItem.Name = "ManagingAccountsToolStripMenuItem"
        Me.ManagingAccountsToolStripMenuItem.Size = New System.Drawing.Size(302, 22)
        Me.ManagingAccountsToolStripMenuItem.Text = "Managing accounts"
        '
        'TerminalsManagerToolStripMenuItem
        '
        Me.TerminalsManagerToolStripMenuItem.Name = "TerminalsManagerToolStripMenuItem"
        Me.TerminalsManagerToolStripMenuItem.Size = New System.Drawing.Size(302, 22)
        Me.TerminalsManagerToolStripMenuItem.Text = "Terminals Manager"
        '
        'PETCManagerToolStripMenuItem
        '
        Me.PETCManagerToolStripMenuItem.Name = "PETCManagerToolStripMenuItem"
        Me.PETCManagerToolStripMenuItem.Size = New System.Drawing.Size(302, 22)
        Me.PETCManagerToolStripMenuItem.Text = "P.E.T.C. Manager"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(299, 6)
        '
        'CountriesToolStripMenuItem
        '
        Me.CountriesToolStripMenuItem.Name = "CountriesToolStripMenuItem"
        Me.CountriesToolStripMenuItem.Size = New System.Drawing.Size(302, 22)
        Me.CountriesToolStripMenuItem.Text = "Regions, Provinces, Towns / Cities Manager"
        '
        'HolidaysManagerToolStripMenuItem
        '
        Me.HolidaysManagerToolStripMenuItem.Name = "HolidaysManagerToolStripMenuItem"
        Me.HolidaysManagerToolStripMenuItem.Size = New System.Drawing.Size(302, 22)
        Me.HolidaysManagerToolStripMenuItem.Text = "Holidays Manager"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(299, 6)
        '
        'MasterDBToolStripMenuItem1
        '
        Me.MasterDBToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.InitializeAndRebuiltMasterDBToolStripMenuItem, Me.UpdateMasterDBFromEmissionDBToolStripMenuItem, Me.ToolStripMenuItem3, Me.MasterDBManagerToolStripMenuItem})
        Me.MasterDBToolStripMenuItem1.Name = "MasterDBToolStripMenuItem1"
        Me.MasterDBToolStripMenuItem1.Size = New System.Drawing.Size(302, 22)
        Me.MasterDBToolStripMenuItem1.Text = "Master DB Manager"
        '
        'InitializeAndRebuiltMasterDBToolStripMenuItem
        '
        Me.InitializeAndRebuiltMasterDBToolStripMenuItem.Enabled = False
        Me.InitializeAndRebuiltMasterDBToolStripMenuItem.Name = "InitializeAndRebuiltMasterDBToolStripMenuItem"
        Me.InitializeAndRebuiltMasterDBToolStripMenuItem.Size = New System.Drawing.Size(290, 22)
        Me.InitializeAndRebuiltMasterDBToolStripMenuItem.Text = "Initialize and rebuilt Emission Master DB"
        '
        'UpdateMasterDBFromEmissionDBToolStripMenuItem
        '
        Me.UpdateMasterDBFromEmissionDBToolStripMenuItem.Name = "UpdateMasterDBFromEmissionDBToolStripMenuItem"
        Me.UpdateMasterDBFromEmissionDBToolStripMenuItem.Size = New System.Drawing.Size(290, 22)
        Me.UpdateMasterDBFromEmissionDBToolStripMenuItem.Text = "Update Emission Master DB from Live DB"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(287, 6)
        '
        'MasterDBManagerToolStripMenuItem
        '
        Me.MasterDBManagerToolStripMenuItem.Name = "MasterDBManagerToolStripMenuItem"
        Me.MasterDBManagerToolStripMenuItem.Size = New System.Drawing.Size(290, 22)
        Me.MasterDBManagerToolStripMenuItem.Text = "Emission Master DB Manager"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(299, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(302, 22)
        Me.ExitToolStripMenuItem.Text = "Log-&out"
        '
        'AccountingToolStripMenuItem
        '
        Me.AccountingToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PETCBalanceToolStripMenuItem, Me.StradcomBalanceManagerToolStripMenuItem, Me.PETCBillingManagerToolStripMenuItem})
        Me.AccountingToolStripMenuItem.Name = "AccountingToolStripMenuItem"
        Me.AccountingToolStripMenuItem.Size = New System.Drawing.Size(81, 20)
        Me.AccountingToolStripMenuItem.Text = "Accounting"
        '
        'PETCBalanceToolStripMenuItem
        '
        Me.PETCBalanceToolStripMenuItem.Name = "PETCBalanceToolStripMenuItem"
        Me.PETCBalanceToolStripMenuItem.Size = New System.Drawing.Size(219, 22)
        Me.PETCBalanceToolStripMenuItem.Text = "PETC Balance Manager"
        '
        'StradcomBalanceManagerToolStripMenuItem
        '
        Me.StradcomBalanceManagerToolStripMenuItem.Name = "StradcomBalanceManagerToolStripMenuItem"
        Me.StradcomBalanceManagerToolStripMenuItem.Size = New System.Drawing.Size(219, 22)
        Me.StradcomBalanceManagerToolStripMenuItem.Text = "Stradcom Balance Manager"
        '
        'PETCBillingManagerToolStripMenuItem
        '
        Me.PETCBillingManagerToolStripMenuItem.Name = "PETCBillingManagerToolStripMenuItem"
        Me.PETCBillingManagerToolStripMenuItem.Size = New System.Drawing.Size(219, 22)
        Me.PETCBillingManagerToolStripMenuItem.Text = "PETC Billing Manager"
        '
        'SalesToolStripMenuItem
        '
        Me.SalesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PETCToolStripMenuItem})
        Me.SalesToolStripMenuItem.Name = "SalesToolStripMenuItem"
        Me.SalesToolStripMenuItem.Size = New System.Drawing.Size(59, 20)
        Me.SalesToolStripMenuItem.Text = "Reports"
        '
        'PETCToolStripMenuItem
        '
        Me.PETCToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SalesSummaryReportToolStripMenuItem, Me.MonthlyPerformanceReportToolStripMenuItem})
        Me.PETCToolStripMenuItem.Name = "PETCToolStripMenuItem"
        Me.PETCToolStripMenuItem.Size = New System.Drawing.Size(100, 22)
        Me.PETCToolStripMenuItem.Text = "PETC"
        '
        'SalesSummaryReportToolStripMenuItem
        '
        Me.SalesSummaryReportToolStripMenuItem.Name = "SalesSummaryReportToolStripMenuItem"
        Me.SalesSummaryReportToolStripMenuItem.Size = New System.Drawing.Size(258, 22)
        Me.SalesSummaryReportToolStripMenuItem.Text = "Transmission sales summary report"
        '
        'MonthlyPerformanceReportToolStripMenuItem
        '
        Me.MonthlyPerformanceReportToolStripMenuItem.Name = "MonthlyPerformanceReportToolStripMenuItem"
        Me.MonthlyPerformanceReportToolStripMenuItem.Size = New System.Drawing.Size(258, 22)
        Me.MonthlyPerformanceReportToolStripMenuItem.Text = "Performance report"
        '
        'VIewToolStripMenuItem
        '
        Me.VIewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PETCToolStripMenuItem1, Me.UserActivityLogsToolStripMenuItem, Me.SystemMessagesToolStripMenuItem})
        Me.VIewToolStripMenuItem.Name = "VIewToolStripMenuItem"
        Me.VIewToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.VIewToolStripMenuItem.Text = "View"
        '
        'PETCToolStripMenuItem1
        '
        Me.PETCToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DataTransmissionsToolStripMenuItem1, Me.ForUploadMonitoringToolStripMenuItem})
        Me.PETCToolStripMenuItem1.Name = "PETCToolStripMenuItem1"
        Me.PETCToolStripMenuItem1.Size = New System.Drawing.Size(230, 22)
        Me.PETCToolStripMenuItem1.Text = "PETC"
        '
        'DataTransmissionsToolStripMenuItem1
        '
        Me.DataTransmissionsToolStripMenuItem1.Name = "DataTransmissionsToolStripMenuItem1"
        Me.DataTransmissionsToolStripMenuItem1.Size = New System.Drawing.Size(194, 22)
        Me.DataTransmissionsToolStripMenuItem1.Text = "Data transmissions"
        '
        'ForUploadMonitoringToolStripMenuItem
        '
        Me.ForUploadMonitoringToolStripMenuItem.Name = "ForUploadMonitoringToolStripMenuItem"
        Me.ForUploadMonitoringToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.ForUploadMonitoringToolStripMenuItem.Text = "For upload monitoring"
        '
        'UserActivityLogsToolStripMenuItem
        '
        Me.UserActivityLogsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UserActivitiesbackofficeToolStripMenuItem, Me.SystemActivitiesToolStripMenuItem})
        Me.UserActivityLogsToolStripMenuItem.Name = "UserActivityLogsToolStripMenuItem"
        Me.UserActivityLogsToolStripMenuItem.Size = New System.Drawing.Size(230, 22)
        Me.UserActivityLogsToolStripMenuItem.Text = "Logs"
        '
        'UserActivitiesbackofficeToolStripMenuItem
        '
        Me.UserActivitiesbackofficeToolStripMenuItem.Name = "UserActivitiesbackofficeToolStripMenuItem"
        Me.UserActivitiesbackofficeToolStripMenuItem.Size = New System.Drawing.Size(217, 22)
        Me.UserActivitiesbackofficeToolStripMenuItem.Text = "User activities (back-office)"
        '
        'SystemActivitiesToolStripMenuItem
        '
        Me.SystemActivitiesToolStripMenuItem.Name = "SystemActivitiesToolStripMenuItem"
        Me.SystemActivitiesToolStripMenuItem.Size = New System.Drawing.Size(217, 22)
        Me.SystemActivitiesToolStripMenuItem.Text = "System activities"
        '
        'SystemMessagesToolStripMenuItem
        '
        Me.SystemMessagesToolStripMenuItem.Name = "SystemMessagesToolStripMenuItem"
        Me.SystemMessagesToolStripMenuItem.Size = New System.Drawing.Size(230, 22)
        Me.SystemMessagesToolStripMenuItem.Text = "System notification messages"
        '
        'MaintenanceToolStripMenuItem
        '
        Me.MaintenanceToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EWalletToolStripMenuItem})
        Me.MaintenanceToolStripMenuItem.Name = "MaintenanceToolStripMenuItem"
        Me.MaintenanceToolStripMenuItem.Size = New System.Drawing.Size(88, 20)
        Me.MaintenanceToolStripMenuItem.Text = "&Maintenance"
        '
        'EWalletToolStripMenuItem
        '
        Me.EWalletToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PETCToolStripMenuItem2, Me.StradcomToolStripMenuItem})
        Me.EWalletToolStripMenuItem.Name = "EWalletToolStripMenuItem"
        Me.EWalletToolStripMenuItem.Size = New System.Drawing.Size(122, 22)
        Me.EWalletToolStripMenuItem.Text = "E - &wallet"
        '
        'PETCToolStripMenuItem2
        '
        Me.PETCToolStripMenuItem2.Name = "PETCToolStripMenuItem2"
        Me.PETCToolStripMenuItem2.Size = New System.Drawing.Size(125, 22)
        Me.PETCToolStripMenuItem2.Text = "&PETC"
        '
        'StradcomToolStripMenuItem
        '
        Me.StradcomToolStripMenuItem.Enabled = False
        Me.StradcomToolStripMenuItem.Name = "StradcomToolStripMenuItem"
        Me.StradcomToolStripMenuItem.Size = New System.Drawing.Size(125, 22)
        Me.StradcomToolStripMenuItem.Text = "&Stradcom"
        '
        'ToolsMenu
        '
        Me.ToolsMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BackupDatabaseToolStripMenuItem, Me.ToolStripMenuItem1, Me.OptionsToolStripMenuItem, Me.MonitoringToolStripMenuItem, Me.AddColorToolStripMenuItem, Me.AddMakeAndSeriesToolStripMenuItem, Me.BodyTypesToolStripMenuItem})
        Me.ToolsMenu.Name = "ToolsMenu"
        Me.ToolsMenu.Size = New System.Drawing.Size(46, 20)
        Me.ToolsMenu.Text = "&Tools"
        '
        'BackupDatabaseToolStripMenuItem
        '
        Me.BackupDatabaseToolStripMenuItem.Name = "BackupDatabaseToolStripMenuItem"
        Me.BackupDatabaseToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
        Me.BackupDatabaseToolStripMenuItem.Text = "Backup database"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(225, 6)
        '
        'OptionsToolStripMenuItem
        '
        Me.OptionsToolStripMenuItem.Enabled = False
        Me.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem"
        Me.OptionsToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
        Me.OptionsToolStripMenuItem.Text = "&Options"
        '
        'MonitoringToolStripMenuItem
        '
        Me.MonitoringToolStripMenuItem.Name = "MonitoringToolStripMenuItem"
        Me.MonitoringToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
        Me.MonitoringToolStripMenuItem.Text = "Monitoring"
        '
        'AddColorToolStripMenuItem
        '
        Me.AddColorToolStripMenuItem.Name = "AddColorToolStripMenuItem"
        Me.AddColorToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
        Me.AddColorToolStripMenuItem.Text = "Add Color Module"
        '
        'AddMakeAndSeriesToolStripMenuItem
        '
        Me.AddMakeAndSeriesToolStripMenuItem.Name = "AddMakeAndSeriesToolStripMenuItem"
        Me.AddMakeAndSeriesToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
        Me.AddMakeAndSeriesToolStripMenuItem.Text = "Add Make and Series Module"
        '
        'BodyTypesToolStripMenuItem
        '
        Me.BodyTypesToolStripMenuItem.Name = "BodyTypesToolStripMenuItem"
        Me.BodyTypesToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
        Me.BodyTypesToolStripMenuItem.Text = "Add Body Type Module"
        '
        'HelpMenu
        '
        Me.HelpMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.IndexToolStripMenuItem, Me.SearchToolStripMenuItem, Me.ToolStripSeparator8, Me.AboutToolStripMenuItem})
        Me.HelpMenu.Name = "HelpMenu"
        Me.HelpMenu.Size = New System.Drawing.Size(44, 20)
        Me.HelpMenu.Text = "&Help"
        '
        'IndexToolStripMenuItem
        '
        Me.IndexToolStripMenuItem.Enabled = False
        Me.IndexToolStripMenuItem.Image = CType(resources.GetObject("IndexToolStripMenuItem.Image"), System.Drawing.Image)
        Me.IndexToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black
        Me.IndexToolStripMenuItem.Name = "IndexToolStripMenuItem"
        Me.IndexToolStripMenuItem.Size = New System.Drawing.Size(119, 22)
        Me.IndexToolStripMenuItem.Text = "&Index"
        '
        'SearchToolStripMenuItem
        '
        Me.SearchToolStripMenuItem.Enabled = False
        Me.SearchToolStripMenuItem.Image = CType(resources.GetObject("SearchToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SearchToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black
        Me.SearchToolStripMenuItem.Name = "SearchToolStripMenuItem"
        Me.SearchToolStripMenuItem.Size = New System.Drawing.Size(119, 22)
        Me.SearchToolStripMenuItem.Text = "&Search"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(116, 6)
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Enabled = False
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(119, 22)
        Me.AboutToolStripMenuItem.Text = "&About ..."
        '
        'ToolStrip
        '
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripButton, Me.ToolStripSeparator1, Me.ToolStripSeparator2, Me.HelpToolStripButton})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 24)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(1155, 25)
        Me.ToolStrip.TabIndex = 6
        Me.ToolStrip.Text = "ToolStrip"
        '
        'NewToolStripButton
        '
        Me.NewToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.NewToolStripButton.Image = CType(resources.GetObject("NewToolStripButton.Image"), System.Drawing.Image)
        Me.NewToolStripButton.ImageTransparentColor = System.Drawing.Color.Black
        Me.NewToolStripButton.Name = "NewToolStripButton"
        Me.NewToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.NewToolStripButton.Text = "New"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'HelpToolStripButton
        '
        Me.HelpToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.HelpToolStripButton.Enabled = False
        Me.HelpToolStripButton.Image = CType(resources.GetObject("HelpToolStripButton.Image"), System.Drawing.Image)
        Me.HelpToolStripButton.ImageTransparentColor = System.Drawing.Color.Black
        Me.HelpToolStripButton.Name = "HelpToolStripButton"
        Me.HelpToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.HelpToolStripButton.Text = "Help"
        '
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 601)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(1155, 22)
        Me.StatusStrip.TabIndex = 7
        Me.StatusStrip.Text = "StatusStrip"
        '
        'ToolStripStatusLabel
        '
        Me.ToolStripStatusLabel.Name = "ToolStripStatusLabel"
        Me.ToolStripStatusLabel.Size = New System.Drawing.Size(39, 17)
        Me.ToolStripStatusLabel.Text = "Status"
        '
        'timerLoad
        '
        Me.timerLoad.Interval = 1
        '
        'mdiMainMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1155, 623)
        Me.Controls.Add(Me.ToolStrip)
        Me.Controls.Add(Me.MenuStrip)
        Me.Controls.Add(Me.StatusStrip)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip
        Me.Name = "mdiMainMenu"
        Me.Text = "VOX DEI EMISSION - BACK OFFICE - MAIN MENU"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents HelpMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SearchToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OptionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents ToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents NewToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FileMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents ToolsMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents IndexToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PETCManagerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VIewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UserActivityLogsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UsersManagerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TerminalsManagerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AccountingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PETCBalanceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BackupDatabaseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SalesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PETCToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SalesSummaryReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StradcomBalanceManagerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PETCToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DataTransmissionsToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents timerLoad As System.Windows.Forms.Timer
    Friend WithEvents SystemMessagesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MonthlyPerformanceReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PETCBillingManagerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MasterDBToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InitializeAndRebuiltMasterDBToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UpdateMasterDBFromEmissionDBToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MasterDBManagerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ManagingAccountsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MaintenanceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EWalletToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PETCToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StradcomToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UserActivitiesbackofficeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SystemActivitiesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CountriesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents HolidaysManagerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MonitoringToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ForUploadMonitoringToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddColorToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AddMakeAndSeriesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BodyTypesToolStripMenuItem As ToolStripMenuItem
End Class
