Imports Npgsql
Imports System.Security.Cryptography

Public Class frmLogin

    Private Sub InitializeValues()
        pViewBackgroundCtr = 2
        pViewBackgroundColorMax = 2
        pViewBackgroundColor(1) = Color.White
        pViewBackgroundColor(2) = Color.FromArgb(240, 240, 240)

        pViewScreenSummaryHeight = 0.6
        pViewScreenDetailsHeight = 0.4

        '----------------------------------------------------------------------------------------------------

        pUserID = ""
        pUserName = ""
        pUserGroup = ""

        'pPostgresPath = ""
        'pPostgresPassword=""
        'pPostgresPort=""
        'pBackupDir = ""

        pPostgresServer = "localhost"
        'pPostgresServer = "192.168.60.214"
        pPostgresUserID = "postgres"
        pPostgresDbName = "db_vox_dei_emission"

        '----------------------------------------------------------------------------------------------------

        pPostgresPath = "C:\Program Files\PostgreSQL\9.2"   'db server
        'pPostgresPath = "E:\PostgreSQL\9.2"                'offsite db server
        pPostgresPassword = "vox032623731454vox"
        pPostgresPort = "5943"
        pWorkDirectory = "D:\Vox Data"
        pBackupDir = pWorkDirectory & "\Database backup"

        'pPostgresPath = "c:\program files\postgresql\9.2"   'db_file server
        ''ppostgrespath = "e:\postgresql\9.2"                'offsite db server
        'pPostgresPassword = "v0xd31v0xd31"
        'pPostgresPort = "5432"
        'pWorkDirectory = "d:\vox data"
        'pBackupDir = pWorkDirectory & "\database backup"

        'pPostgresPath = "C:\Program Files (x86)\PostgreSQL\9.2"
        'pPostgresPassword = "032623731454"
        'pPostgresPort = "5432"
        ''pWorkDirectory = "C:\Vox Data"     'sony laptop
        'pWorkDirectory = "E:\Vox Data"      'naths desktop
        'pBackupDir = pWorkDirectory & "\Database backup"

        'pPostgresPath = "C:\Program Files\PostgreSQL\9.2" '--------------test server
        'pPostgresPassword = "postgres"
        'pPostgresPort = "5432"
        'pWorkDirectory = "C:\Vox Data"
        'pBackupDir = pWorkDirectory & "\Database backup"

        pConnectVox = "server=" & pPostgresServer & ";" & _
            "user id='" & pPostgresUserID & "';" & _
            "password='" & pPostgresPassword & "';" & _
            "database='" & pPostgresDbName & "';" & _
            "port=" & pPostgresPort & ";CommandTimeout=0;"

        pConnectMasterDb = "server=" & "192.168.10.16" & ";" & _
            "user id='" & "postgres" & "';" & _
            "password='" & "vox032623731454vox" & "';" & _
            "database='" & "master_db" & "';" & _
            "port=" & "5944" & ";CommandTimeout=0;"

        '------------------------------------------------------------------------------------------------------------------------------------
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Private Sub cmdLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLogin.Click
        'open postgres connection
        Dim vMyPgCon As New NpgsqlConnection
        Dim vMyPgCmd = New NpgsqlCommand
        Dim vMyPgRd As NpgsqlDataReader
        Dim vFound As Boolean

        Dim vQuery As String
        Dim vTmpVar As Integer

        Dim vTmpUserID As String = ""
        Dim vTmpPassword As String = ""
        Dim vTmpStatus As String = ""
        Dim vTmpUserName As String = ""
        Dim vTmpUserGroup As String = ""

        If Trim(txtUserID.Text) = "" Then
            MessageBox.Show("User ID is required." & vbCrLf & vbCrLf & _
                            "Please enter your Account ID to login.", "ACCESS DENIED")

            txtUserID.Select()
            txtUserID.Focus()

            Exit Sub
        End If

        If Trim(txtPassword.Text) = "" Then
            MessageBox.Show("Your Password is required." & vbCrLf & vbCrLf & _
                            "Please enter your Password to login.", "ACCESS DENIED")

            txtPassword.Select()
            txtPassword.Focus()

            Exit Sub
        End If

        Try
            lblPrompt.Text = "Opening database..."
            lblPrompt.Visible = True
            lblPrompt.Refresh()

            'open db connection
            vMyPgCon.ConnectionString = pConnectVox
            vMyPgCon.Open()

            vQuery = "SELECT password, is_active, user_name FROM tb_users WHERE user_id = '" & modModule.CorrectSqlString(txtUserID.Text) & "' AND " & _
                "petc_code = 'tech.support' AND user_type = 'tech_support'"

            lblPrompt.Text = "Searching database..."
            lblPrompt.Refresh()

            'create query
            vMyPgCmd = New NpgsqlCommand(vQuery, vMyPgCon)

            'execute query
            vMyPgRd = vMyPgCmd.ExecuteReader()

            'read values
            vFound = vMyPgRd.Read

            If vFound = False Then
                'no record found

                lblPrompt.Text = "Closing database..."
                lblPrompt.Refresh()

                'close and dispose to avoid memory leak
                vMyPgRd.Close()
                vMyPgCmd.Dispose()

                'close and dispose connection
                vMyPgCon.Close()
                vMyPgCon = Nothing

                lblPrompt.Text = ""
                lblPrompt.Visible = False

                MessageBox.Show("User not found." & vbCrLf & vbCrLf & _
                                "Please make sure the login account you entered is correct.", "ACCESS DENIED")

                Exit Sub
            Else
                'get result

                vTmpUserID = txtUserID.Text
                vTmpUserGroup = "TECHNICAL GROUP"

                If IsDBNull(vMyPgRd("user_name")) = True Then
                    vTmpUserName = ""
                Else
                    vTmpUserName = vMyPgRd("user_name")
                End If

                If IsDBNull(vMyPgRd("password")) = True Then
                    vTmpPassword = ""
                Else
                    vTmpPassword = vMyPgRd("password")
                End If

                If IsDBNull(vMyPgRd("is_active")) = True Then
                    vTmpStatus = "0"
                Else
                    vTmpStatus = Trim(Str(vMyPgRd("is_active")))
                End If

                lblPrompt.Text = "Closing database..."
                lblPrompt.Refresh()

                'close and dispose to avoid memory leak
                vMyPgRd.Close()
                vMyPgCmd.Dispose()

                'close and dispose connection
                vMyPgCon.Close()
                vMyPgCon = Nothing

                'check password
                lblPrompt.Text = "Validating access..."
                lblPrompt.Refresh()

                Using md5Hash As MD5 = MD5.Create()
                    Dim vHash As String = LCase(GetMd5Hash(md5Hash, txtPassword.Text))

                    If vTmpPassword <> vHash Then
                        lblPrompt.Text = ""
                        lblPrompt.Visible = False

                        MessageBox.Show("User or Password validation failed." & vbCrLf & vbCrLf & _
                                        "Please make sure the login credentials you entered are correct.", "ACCESS DENIED")

                        Exit Sub
                    End If
                End Using

                'check status
                lblPrompt.Text = "Validating account status..."
                lblPrompt.Refresh()

                Select Case vTmpStatus
                    Case "1"    'active

                    Case "0"    'inactive
                        lblPrompt.Text = ""
                        lblPrompt.Visible = False

                        MessageBox.Show("Account currently has no access to the system." & vbCrLf & vbCrLf & _
                                        "Please check with your System Administrator or try again.", "ACCESS DENIED")

                        Exit Sub

                    Case Else   'unknown
                        lblPrompt.Text = ""
                        lblPrompt.Visible = False

                        MessageBox.Show("Cannot determine the status of your account." & vbCrLf & vbCrLf & _
                                        "Please check with your System Administrator or try again.", "ACCESS DENIED")

                        Exit Sub
                End Select
            End If

            Dim vTmpStr As String

            pUserID = vTmpUserID
            pUserName = vTmpUserName
            pUserGroup = vTmpUserGroup

            txtUserID.Text = ""
            txtPassword.Text = ""

            txtUserID.Select()
            txtUserID.Focus()

            lblPrompt.Text = "Please wait... checking for system warning messages..."

            lblPrompt.Text = "Loading main menu..."
            lblPrompt.Visible = False

            Me.Visible = False

            'log event
            vTmpStr = modModule.CreateLog(Me.Name, "Back Office - System Login", "User ID " & pUserID & "(" & pUserName & ") logged in as " & pUserGroup)

            With mdiMainMenu
                .ShowDialog()
            End With

            Me.InitializeValues()

            Me.Visible = True

        Catch ex As Exception
            'an error has occured

            'close connections that might be open
            If IsNothing(vMyPgCon) = False Then
                If vMyPgCon.State <> ConnectionState.Closed Then
                    vMyPgCon.Close()
                    vMyPgCon = Nothing
                End If
            End If

            vTmpVar = MsgBox("An error has occured." & vbCrLf & vbCr & _
                           "Error number: " & Trim(Str(Err.Number)) & vbCrLf & _
                           "Error description: " & Err.Description, MsgBoxStyle.OkOnly, "Error warning")

            'log event
            vQuery = modModule.CreateLog(Me.Name, "Error:cmdLogin", ex.Message)

            lblPrompt.Visible = False
        End Try
    End Sub

    Private Sub frmLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With cmbServer
            .Items.Clear()

            .Items.Add("localhost")

            .Text = "localhost"
        End With

        Me.InitializeValues()

        txtUserID.Text = ""
        txtPassword.Text = ""

        frmSplashScreen.ShowDialog()
    End Sub

    Private Sub txtUserID_GotFocus(sender As Object, e As EventArgs) Handles txtUserID.GotFocus
        txtUserID.SelectAll()
    End Sub

    Private Sub txtUserID_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUserID.KeyPress
        If Microsoft.VisualBasic.Asc(e.KeyChar) = Keys.Enter Then
            cmdLogin_Click(sender, e)
        End If
    End Sub

    Private Sub txtPassword_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPassword.KeyPress
        If Microsoft.VisualBasic.Asc(e.KeyChar) = Keys.Enter Then
            cmdLogin_Click(sender, e)
        End If
    End Sub

    Private Sub txtUserID_LostFocus(sender As Object, e As EventArgs) Handles txtUserID.LostFocus
        txtUserID.Text = modModule.StripInvalidStringChars(Trim(txtUserID.Text))
    End Sub

    Private Sub txtUserID_TextChanged(sender As Object, e As EventArgs) Handles txtUserID.TextChanged

    End Sub

    Private Sub txtPassword_LostFocus(sender As Object, e As EventArgs) Handles txtPassword.LostFocus
        txtPassword.Text = modModule.StripInvalidStringChars(txtPassword.Text)
    End Sub

    Private Sub txtPassword_TextChanged(sender As Object, e As EventArgs) Handles txtPassword.TextChanged

    End Sub

    Private Sub cmdServers_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub cmbServer_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbServer.KeyPress
        e.Handled = True
    End Sub

    Private Sub cmbServer_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbServer.SelectedIndexChanged

    End Sub

    Private Sub cmdTest_Click(sender As Object, e As EventArgs) Handles cmdTest.Click
        'MsgBox(ChangeXmlKey(pWorkDirectory & "\Export - Gas.config", "/configuration/appSettings", "Test", "ekek2"))
    End Sub

End Class
