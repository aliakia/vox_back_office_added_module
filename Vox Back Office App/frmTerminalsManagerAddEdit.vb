Imports Npgsql

Public Class frmTerminalsManagerAddEdit

    Private gMode As String
    Private gTerminalID As String
    Private gFirstLoad As Boolean

    Private gOldTerminalID As String
    Private gOldTerminalType As String
    Private gOldPetcCode As String
    Private gOldTerminalDescription As String
    Private gOldTerminalMac As String
    Private gOldTerminalSerial As String
    Private gOldTerminalIP As String
    Private gOldTerminalLane As String
    Private gOldStatus As String
    Private gOldMachineDescription As String
    Private gOldMachineSerial As String
    Private gOldDateCalibrated As String
    Private gOldLockStatus As String
    Private gOldMachineDLL As String
    Private gOldMachinePort As String
    Private gOldMachineBaud As String
    Private gOldMachineParity As String
    Private gOldMachineBits As String
    Private gOldMachineStopBits As String
    Private gOldIsScsi As String

    Property Mode() As String
        Get
            Return gMode
        End Get

        Set(ByVal value As String)
            gMode = value
        End Set
    End Property

    Property TerminalID() As String
        Get
            Return gTerminalID
        End Get

        Set(ByVal value As String)
            gTerminalID = value
        End Set
    End Property

    Private Sub ImplementPrivileges()
        '        If Mid(pUserPrivilege, 34, 1) = "1" Or Mid(pUserPrivilege, 34, 1) = "2" Then
        ' cmdCountries.Enabled = True
        ' Else
        ' cmdCountries.Enabled = False
        ' End If
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        If timerRefreshPredefinedData.Enabled = True Then timerRefreshPredefinedData.Enabled = False
        If timerLoad.Enabled = True Then timerLoad.Enabled = False

        Dim vTmpStr As String

        'log event
        vTmpStr = modModule.CreateLog(Me.Name, "Terminals Manager - Add/Edit - Close", "")

        If vTmpStr = "1" Then
            Me.Close()
        Else
            MsgBox("An error occurred while saving log. Operation aborted.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Operation cancelled")
        End If
    End Sub

    Private Sub InitializeValues()
        txtTerminalID.Text = ""
        cmbType.Text = ""
        txtPetcCode.Text = ""
        txtTerminalDescription.Text = ""
        txtTerminalMac.Text = ""
        txtTerminalSerial.Text = ""
        txtTerminalIP.Text = ""
        txtTerminalLane.Text = ""
        cmbStatus.Text = ""
        txtMachineDescription.Text = ""
        txtMachineSerial.Text = ""
        txtDateCalibrated.Text = ""
        chkLocked.Checked = True
        chkScsiSas.Checked = False

        txtMachineDLL.Text = ""
        cmbMachinePort.Text = "1"
        cmbMachineBaud.Text = "9600"
        cmbMachineParity.Text = "None"
        cmbMachineBits.Text = "8"
        cmbMachineStopBits.Text = "One"

        gOldTerminalID = ""
        gOldTerminalType = ""
        gOldPetcCode = ""
        gOldTerminalDescription = ""
        gOldTerminalMac = ""
        gOldTerminalSerial = ""
        gOldTerminalIP = ""
        gOldTerminalLane = ""
        gOldStatus = ""
        gOldMachineDescription = ""
        gOldMachineSerial = ""
        gOldDateCalibrated = ""
        gOldLockStatus = "0"

        gOldMachineDLL = txtMachineDLL.Text
        gOldMachinePort = cmbMachinePort.Text
        gOldMachineBaud = cmbMachineBaud.Text
        gOldMachineParity = cmbMachineParity.Text
        gOldMachineBits = cmbMachineBits.Text
        gOldMachineStopBits = cmbMachineStopBits.Text

        txtMachineDLL.Enabled = False
        cmbMachinePort.Enabled = False
        cmbMachineBaud.Enabled = False
        cmbMachineParity.Enabled = False
        cmbMachineBits.Enabled = False
        cmbMachineStopBits.Enabled = False

        gOldIsScsi = IIf(chkScsiSas.Checked = True, "1", "0")
    End Sub

    Private Sub SaveOldValues()
        gOldTerminalID = txtTerminalID.Text
        gOldTerminalType = cmbType.Text
        gOldPetcCode = txtPetcCode.Text
        gOldTerminalDescription = txtTerminalDescription.Text
        gOldTerminalMac = txtTerminalMac.Text
        gOldTerminalSerial = txtTerminalSerial.Text
        gOldTerminalIP = txtTerminalIP.Text
        gOldTerminalLane = txtTerminalLane.Text
        gOldStatus = cmbStatus.Text
        gOldMachineDescription = txtMachineDescription.Text
        gOldMachineSerial = txtMachineSerial.Text
        gOldDateCalibrated = txtDateCalibrated.Text
        gOldLockStatus = IIf(chkLocked.Checked = True, "1", "0")

        gOldMachineDLL = txtMachineDLL.Text
        gOldMachinePort = cmbMachinePort.Text
        gOldMachineBaud = cmbMachineBaud.Text
        gOldMachineParity = cmbMachineParity.Text
        gOldMachineBits = cmbMachineBits.Text
        gOldMachineStopBits = cmbMachineStopBits.Text

        gOldIsScsi = IIf(chkScsiSas.Checked = True, "1", "0")
    End Sub

    Private Function ChangesMade(Optional ByRef bChanges As String = "", Optional ByVal bPutCrLf As Boolean = False) As Boolean
        ChangesMade = False
        bChanges = ""

        If gOldTerminalType <> cmbType.Text Then
            ChangesMade = True
            bChanges = bChanges & IIf(bChanges <> "", IIf(bPutCrLf = True, vbCrLf, ", "), "") & _
                "Terminal type from " & gOldTerminalType & " to " & cmbType.Text
        End If

        If gOldPetcCode <> txtPetcCode.Text Then
            ChangesMade = True
            bChanges = bChanges & IIf(bChanges <> "", IIf(bPutCrLf = True, vbCrLf, ", "), "") & _
                "PETC Code from " & gOldPetcCode & " to " & txtPetcCode.Text
        End If

        If gOldTerminalDescription <> txtTerminalDescription.Text Then
            ChangesMade = True
            bChanges = bChanges & IIf(bChanges <> "", IIf(bPutCrLf = True, vbCrLf, ", "), "") & _
                "Terminal description from " & gOldTerminalDescription & " to " & txtTerminalDescription.Text
        End If

        If gOldTerminalMac <> txtTerminalMac.Text Then
            ChangesMade = True
            bChanges = bChanges & IIf(bChanges <> "", IIf(bPutCrLf = True, vbCrLf, ", "), "") & _
                "Terminal MAC from " & gOldTerminalMac & " to " & txtTerminalMac.Text
        End If

        If gOldTerminalSerial <> txtTerminalSerial.Text Then
            ChangesMade = True
            bChanges = bChanges & IIf(bChanges <> "", IIf(bPutCrLf = True, vbCrLf, ", "), "") & _
                "Terminal serial from " & gOldTerminalSerial & " to " & txtTerminalSerial.Text
        End If

        If gOldIsScsi <> IIf(chkScsiSas.Checked = True, "1", "0") Then
            ChangesMade = True
            bChanges = bChanges & IIf(bChanges <> "", IIf(bPutCrLf = True, vbCrLf, ", "), "") & _
                "HDD type SCSI/SAS from " & gOldIsScsi & " to " & IIf(chkScsiSas.Checked = True, "1", "0")
        End If

        If gOldTerminalIP <> txtTerminalIP.Text Then
            ChangesMade = True
            bChanges = bChanges & IIf(bChanges <> "", IIf(bPutCrLf = True, vbCrLf, ", "), "") & _
                "Terminal IP from " & gOldTerminalIP & " to " & txtTerminalIP.Text
        End If

        If gOldTerminalLane <> txtTerminalLane.Text Then
            ChangesMade = True
            bChanges = bChanges & IIf(bChanges <> "", IIf(bPutCrLf = True, vbCrLf, ", "), "") & _
                "Terminal lane from " & gOldTerminalLane & " to " & txtTerminalLane.Text
        End If

        If gOldStatus <> cmbStatus.Text Then
            ChangesMade = True
            bChanges = bChanges & IIf(bChanges <> "", IIf(bPutCrLf = True, vbCrLf, ", "), "") & _
                "Terminal status from " & gOldStatus & " to " & cmbStatus.Text
        End If

        If gOldMachineDescription <> txtMachineDescription.Text Then
            ChangesMade = True
            bChanges = bChanges & IIf(bChanges <> "", IIf(bPutCrLf = True, vbCrLf, ", "), "") & _
                "Machine description from " & gOldMachineDescription & " to " & txtMachineDescription.Text
        End If

        If gOldMachineSerial <> txtMachineSerial.Text Then
            ChangesMade = True
            bChanges = bChanges & IIf(bChanges <> "", IIf(bPutCrLf = True, vbCrLf, ", "), "") & _
                "Machine serial from " & gOldMachineSerial & " to " & txtMachineSerial.Text
        End If

        If gOldDateCalibrated <> txtDateCalibrated.Text Then
            ChangesMade = True
            bChanges = bChanges & IIf(bChanges <> "", IIf(bPutCrLf = True, vbCrLf, ", "), "") & _
                "Date calibrated from " & gOldDateCalibrated & " to " & txtDateCalibrated.Text
        End If

        If gOldLockStatus <> IIf(chkLocked.Checked = True, "1", "0") Then
            ChangesMade = True
            bChanges = bChanges & IIf(bChanges <> "", IIf(bPutCrLf = True, vbCrLf, ", "), "") & _
                "Terminal lock status from " & gOldLockStatus & " to " & IIf(chkLocked.Checked = True, "1", "0")
        End If

        If gOldMachineDLL <> txtMachineDLL.Text Then
            ChangesMade = True
            bChanges = bChanges & IIf(bChanges <> "", IIf(bPutCrLf = True, vbCrLf, ", "), "") & _
                "Machine DLL file from " & gOldMachineDLL & " to " & txtMachineDLL.Text
        End If

        If gOldMachinePort <> cmbMachinePort.Text Then
            ChangesMade = True
            bChanges = bChanges & IIf(bChanges <> "", IIf(bPutCrLf = True, vbCrLf, ", "), "") & _
                "Machine COM port from " & gOldMachinePort & " to " & cmbMachinePort.Text
        End If

        If gOldMachineBaud <> cmbMachineBaud.Text Then
            ChangesMade = True
            bChanges = bChanges & IIf(bChanges <> "", IIf(bPutCrLf = True, vbCrLf, ", "), "") & _
                "Machine baud rate from " & gOldMachineBaud & " to " & cmbMachineBaud.Text
        End If

        If gOldMachineParity <> cmbMachineParity.Text Then
            ChangesMade = True
            bChanges = bChanges & IIf(bChanges <> "", IIf(bPutCrLf = True, vbCrLf, ", "), "") & _
                "Machine parity from " & gOldMachineParity & " to " & cmbMachineParity.Text
        End If

        If gOldMachineBits <> cmbMachineBits.Text Then
            ChangesMade = True
            bChanges = bChanges & IIf(bChanges <> "", IIf(bPutCrLf = True, vbCrLf, ", "), "") & _
                "Machine bits from " & gOldMachineBits & " to " & cmbMachineBits.Text
        End If

        If gOldMachineStopBits <> cmbMachineStopBits.Text Then
            ChangesMade = True
            bChanges = bChanges & IIf(bChanges <> "", IIf(bPutCrLf = True, vbCrLf, ", "), "") & _
                "Machine stop bits from " & gOldMachineStopBits & " to " & cmbMachineStopBits.Text
        End If
    End Function

    Private Sub frmTerminalsManagerAddEdit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        gFirstLoad = True

        Select Case Me.Mode
            Case "new"
                Me.Text = "ADD NEW TERMINAL DATA"

                txtTerminalID.ReadOnly = False
                txtPetcCode.ReadOnly = False
                cmbType.Enabled = True
                cmdBrowsePetc.Visible = True

                txtPetcCode.Size = New Size(74, 20)

                cmdProcess.Text = "CREATE"

            Case "edit"
                Me.Text = "EDIT TERMINAL DATA"

                txtTerminalID.ReadOnly = True
                txtPetcCode.ReadOnly = True
                cmbType.Enabled = False
                cmdBrowsePetc.Visible = False

                txtPetcCode.Size = New Size(138, 20)

                cmdProcess.Text = "SAVE"
        End Select

        lblStatusPrompt.Visible = True
        lblStatusPrompt.Text = "Ready"

        'initialize controls

        txtTerminalID.MaxLength = 32
        txtTerminalSerial.MaxLength = 128
        txtTerminalMac.MaxLength = 16
        txtTerminalIP.MaxLength = 32
        txtTerminalDescription.MaxLength = 0
        txtTerminalLane.MaxLength = 8

        txtMachineDescription.MaxLength = 128
        txtMachineSerial.MaxLength = 32
        txtDateCalibrated.MaxLength = 0

        txtPetcCode.MaxLength = 16

        txtMachineDLL.MaxLength = 128

        With cmbType
            .Items.Clear()

            .Items.Add("gas")
            .Items.Add("diesel")
            .Items.Add("any")
        End With

        With cmbStatus
            .Items.Clear()

            .Items.Add("Active")
            .Items.Add("Inactive")
        End With

        With cmbMachinePort
            .Items.Clear()

            .Items.Add("1")
            .Items.Add("2")
            .Items.Add("3")
            .Items.Add("4")
            .Items.Add("5")
            .Items.Add("6")
            .Items.Add("7")
            .Items.Add("8")
            .Items.Add("9")
            .Items.Add("10")
            .Items.Add("11")
            .Items.Add("12")
            .Items.Add("13")
            .Items.Add("14")
            .Items.Add("15")
            .Items.Add("16")
            .Items.Add("17")
            .Items.Add("18")
            .Items.Add("19")
            .Items.Add("20")
        End With

        With cmbMachineBaud
            .Items.Clear()

            .Items.Add("75")
            .Items.Add("110")
            .Items.Add("134")
            .Items.Add("150")
            .Items.Add("300")
            .Items.Add("600")
            .Items.Add("1200")
            .Items.Add("1800")
            .Items.Add("2400")
            .Items.Add("4800")
            .Items.Add("7200")
            .Items.Add("9600")
            .Items.Add("14400")
            .Items.Add("19200")
            .Items.Add("38400")
            .Items.Add("57600")
            .Items.Add("115200")
            .Items.Add("128000")
        End With

        With cmbMachineParity
            .Items.Clear()

            .Items.Add("Even")
            .Items.Add("Odd")
            .Items.Add("None")
            .Items.Add("Mark")
            .Items.Add("Space")
        End With

        With cmbMachineBits
            .Items.Clear()

            .Items.Add("4")
            .Items.Add("5")
            .Items.Add("6")
            .Items.Add("7")
            .Items.Add("8")
        End With

        With cmbMachineStopBits
            .Items.Clear()

            .Items.Add("One")
            .Items.Add("Two")
        End With

        InitializeValues()

        ImplementPrivileges()

        timerRefreshPredefinedData.Enabled = True
    End Sub

    Private Sub cmdRefreshPredefinedData_Click(sender As Object, e As EventArgs) Handles cmdRefreshPredefinedData.Click
        If timerRefreshPredefinedData.Enabled = False Then
            timerRefreshPredefinedData.Enabled = True
        End If
    End Sub

    Private Sub timerRefreshPredefinedData_Tick(sender As Object, e As EventArgs) Handles timerRefreshPredefinedData.Tick
        lblStatusPrompt.Text = "Ready"
        lblStatusPrompt.Visible = True

        If gFirstLoad = True Then
            If LCase(Me.Mode) = "edit" Then
                If timerLoad.Enabled = False Then timerLoad.Enabled = True
            Else
                EnableButtons()
            End If
        End If

        gFirstLoad = False
    End Sub

    Private Sub DisableButtons()
        cmdBrowsePetc.Enabled = False
        cmdRefreshPredefinedData.Enabled = False
        cmdProcess.Enabled = False
        cmdCancel.Enabled = False
    End Sub

    Private Sub EnableButtons()
        cmdBrowsePetc.Enabled = True
        cmdRefreshPredefinedData.Enabled = True
        cmdProcess.Enabled = True
        cmdCancel.Enabled = True

        ImplementPrivileges()
    End Sub

    Private Sub cmdProcess_Click(sender As Object, e As EventArgs) Handles cmdProcess.Click
        'open postgres connection
        Dim vMyPgCon As New NpgsqlConnection
        Dim vMyPgCmd = New NpgsqlCommand
        Dim vMyPgRd As NpgsqlDataReader
        Dim vFound As Boolean

        Dim vQuery As String = ""
        Dim vTmpStr As String = ""

        Dim vTmpVar As Integer
        Dim vTmpStatus As String = ""
        Dim vTmpScsi As String = ""

        Try

            If Trim(txtTerminalID.Text) = "" Then
                vTmpVar = MsgBox("Terminal ID is required." & vbCrLf & vbCrLf & _
                               "Please enter Terminal ID.", vbOKOnly + vbEmpty, "Incomplete data")

                txtTerminalID.Select()
                txtTerminalID.Focus()

                Exit Sub
            End If

            If txtPetcCode.Text = "" Then
                vTmpVar = MsgBox("PETC code is required." & vbCrLf & vbCrLf & _
                               "Please enter PETC code.", vbOKOnly + vbEmpty, "Incomplete data")

                txtPetcCode.Select()
                txtPetcCode.Focus()

                Exit Sub
            End If

            If cmbType.Text = "" Then
                vTmpVar = MsgBox("Terminal type is required." & vbCrLf & vbCrLf & _
                               "Please select terminal type.", vbOKOnly + vbEmpty, "Incomplete data")

                cmbType.Select()
                cmbType.Focus()

                Exit Sub
            Else
                Select Case LCase(cmbType.Text)
                    Case "gas", "diesel"
                        If Mid(txtTerminalID.Text, 1, 5) <> "PETC:" Then
                            vTmpVar = MsgBox("Terminal ID format should be 'PETC:xxxxx'." & vbCrLf & vbCrLf & _
                                           "Please enter correct PETC format.", vbOKOnly + vbEmpty, "Invalid data")

                            txtTerminalID.Select()
                            txtTerminalID.Focus()

                            Exit Sub
                        End If

                        If txtTerminalLane.Text = "" Or txtTerminalLane.Text = "0" Then
                            vTmpVar = MsgBox("Number of lanes for this terminal is required." & vbCrLf & vbCrLf & _
                                           "Please select number of PETC lanes.", vbOKOnly + vbEmpty, "Incomplete data")

                            txtTerminalLane.Select()
                            txtTerminalLane.Focus()

                            Exit Sub
                        End If

                        If LCase(txtPetcCode.Text) = "tech.support" Then
                            vTmpVar = MsgBox("This terminal is configured as a PETC terminal. PETC Code value cannot be 'tech.support'." & vbCrLf & vbCrLf & _
                                           "Please enter the correct PETC Code.", vbOKOnly + vbEmpty, "Invalid data")

                            txtPetcCode.Select()
                            txtPetcCode.Focus()

                            Exit Sub
                        End If

                    Case "any"
                        If Mid(txtTerminalID.Text, 1, 10) <> "SERVERAPP:" Then
                            vTmpVar = MsgBox("Terminal ID format should be 'SERVERAPP:xxxxx'." & vbCrLf & vbCrLf & _
                                           "Please enter correct PETC format.", vbOKOnly + vbEmpty, "Invalid data")

                            txtTerminalID.Select()
                            txtTerminalID.Focus()

                            Exit Sub
                        End If

                        If txtTerminalLane.Text <> "0" Then
                            vTmpVar = MsgBox("This terminal is configured as an office terminal. Terminal lane does not apply." & vbCrLf & vbCrLf & _
                                           "Please put zero (0) in Terminal lane.", vbOKOnly + vbEmpty, "Invalid data")

                            txtTerminalLane.Select()
                            txtTerminalLane.Focus()

                            Exit Sub
                        End If

                        If txtPetcCode.Text <> "tech.support" Then
                            vTmpVar = MsgBox("This terminal is configured as an office terminal. PETC Code does not apply." & vbCrLf & vbCrLf & _
                                           "Please put 'tech.support' in PETC Code.", vbOKOnly + vbEmpty, "Invalid data")

                            txtPetcCode.Select()
                            txtPetcCode.Focus()

                            Exit Sub
                        End If
                End Select
            End If

            '            If txtTerminalDescription.Text = "" Then
            ' vTmpVar = MsgBox("Terminal description is required." & vbCrLf & vbCrLf & _
            '                "Please enter description for this terminal.", vbOKOnly + vbEmpty, "Incomplete data")
            '
            '            txtTerminalDescription.Select()
            '            txtTerminalDescription.Focus()
            '
            '           Exit Sub
            '          End If

            If txtTerminalSerial.Text = "" Then
                vTmpVar = MsgBox("Terminal serial is required." & vbCrLf & vbCrLf & _
                               "Please enter serial of this terminal.", vbOKOnly + vbEmpty, "Incomplete data")

                txtTerminalSerial.Select()
                txtTerminalSerial.Focus()

                Exit Sub
            End If

            'If txtTerminalMac.Text = "" Then
            ' vTmpVar = MsgBox("Terminal MAC is required." & vbCrLf & vbCrLf & _
            '                "Please enter MAC Address of this terminal.", vbOKOnly + vbEmpty, "Incomplete data")
            '
            '            txtTerminalMac.Select()
            '            txtTerminalMac.Focus()
            '
            '            Exit Sub
            '            End If

            If txtTerminalIP.Text <> "" Then
                'check if valid ip address
            End If

            If cmbStatus.Text = "" Then
                vTmpVar = MsgBox("Terminal status is required." & vbCrLf & vbCrLf & _
                               "Please select the current status of this terminal.", vbOKOnly + vbEmpty, "Incomplete data")

                cmbStatus.Select()
                cmbStatus.Focus()

                Exit Sub
            End If

            If txtMachineDescription.Text = "" Then
                vTmpVar = MsgBox("Machine description is required." & vbCrLf & vbCrLf & _
                               "Please enter machine description assigned to this terminal.", vbOKOnly + vbEmpty, "Incomplete data")

                txtMachineDescription.Select()
                txtMachineDescription.Focus()

                Exit Sub
            End If

            If txtMachineSerial.Text = "" Then
                vTmpVar = MsgBox("Machine serial is required." & vbCrLf & vbCrLf & _
                               "Please enter machine serial number assigned to this terminal.", vbOKOnly + vbEmpty, "Incomplete data")

                txtMachineSerial.Select()
                txtMachineSerial.Focus()

                Exit Sub
            End If

            If txtDateCalibrated.Text <> "" Then
                If IsDate(txtDateCalibrated.Text) = False Then
                    vTmpVar = MsgBox("Machine calibration date entered is not a valid date." & vbCrLf & vbCrLf & _
                                   "Please enter the correct date when the machine was calibrated.", vbOKOnly + vbEmpty, "Invalid data")

                    txtDateCalibrated.Select()
                    txtDateCalibrated.Focus()

                    Exit Sub
                End If
            End If

            Select Case Me.Mode
                Case "new"
                    vTmpVar = MsgBox("You are about to create a new Terminal with the following info.:" & vbCrLf & vbCrLf & _
                                     "Terminal ID: " & txtTerminalID.Text & vbCrLf & _
                                     IIf(cmbType.Text = "", "", "Type: " & cmbType.Text & vbCrLf) & _
                                     IIf(txtPetcCode.Text = "", "", "PETC Code: " & txtPetcCode.Text & vbCrLf) & _
                                     IIf(txtTerminalDescription.Text = "", "", "Terminal description: " & txtTerminalDescription.Text & vbCrLf) & _
                                     IIf(txtTerminalSerial.Text = "", "", "Terminal serial: " & txtTerminalSerial.Text & vbCrLf) & _
                                     IIf(chkScsiSas.Checked = False, "", "HDD type SCSI/SAS: " & IIf(chkScsiSas.Checked = True, "Yes", "No") & vbCrLf) & _
                                     IIf(txtTerminalMac.Text = "", "", "MAC address: " & txtTerminalMac.Text & vbCrLf) & _
                                     IIf(txtTerminalIP.Text = "", "", "IP address: " & txtTerminalIP.Text & vbCrLf) & _
                                     IIf(cmbStatus.Text = "", "", "Status: " & cmbStatus.Text & vbCrLf) & _
                                     IIf(chkLocked.Checked = False, "", "Lock status: " & IIf(chkLocked.Checked = True, "Yes", "No") & vbCrLf) & _
                                     IIf(txtMachineDescription.Text = "", "", "Machine description: " & txtMachineDescription.Text & vbCrLf) & _
                                     IIf(txtDateCalibrated.Text = "", "", "Date machine calibration: " & txtDateCalibrated.Text & vbCrLf) & _
                                     IIf(txtMachineDLL.Text = "", "", "Machine DLL file: " & txtMachineDLL.Text & vbCrLf) & _
                                     IIf(cmbMachinePort.Text = "", "", "Machine COM port: " & cmbMachinePort.Text & vbCrLf) & _
                                     IIf(cmbMachineBaud.Text = "", "", "Machine baud rate: " & cmbMachineBaud.Text & vbCrLf) & _
                                     IIf(cmbMachineParity.Text = "", "", "Machine parity: " & cmbMachineParity.Text & vbCrLf) & _
                                     IIf(cmbMachineBits.Text = "", "", "Machine data bits: " & cmbMachineBits.Text & vbCrLf) & _
                                     IIf(cmbMachineStopBits.Text = "", "", "Machine stop bits: " & cmbMachineStopBits.Text & vbCrLf) & vbCrLf & _
                                     "Please make sure the above information are true and correct." & vbCrLf & vbCrLf & _
                                     "Are you sure you want to create the new Terminal?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "User confirmation")

                Case "edit"
                    If ChangesMade(vTmpStr, True) = False Then
                        MsgBox("Nothing to save. No changes haved been made.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Operation cancelled")

                        Exit Sub
                    Else
                        vTmpVar = MsgBox("You are about to update Terminal with the following changes:" & vbCrLf & vbCrLf & _
                                         vTmpStr & vbCrLf & vbCrLf & _
                                         "Please make sure the above information are true and correct." & vbCrLf & vbCrLf & _
                                         "Are you sure you want to update the Terminal record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "User confirmation")
                    End If
            End Select

            If vTmpVar = MsgBoxResult.No Then Exit Sub

            Select Case LCase(cmbStatus.Text)
                Case "active"
                    vTmpStatus = "1"

                Case "inactive"
                    vTmpStatus = "0"

                Case Else
                    MsgBox("Invalid terminal status. Please select in the list the current status of terminal.", _
                           MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Validation failed")
            End Select

            lblStatusPrompt.Text = "Opening database..."
            lblStatusPrompt.Refresh()

            'open db connection
            vMyPgCon.ConnectionString = pConnectVox
            vMyPgCon.Open()

            lblStatusPrompt.Text = "Validating in database..."
            lblStatusPrompt.Refresh()

            Select Case Me.Mode
                Case "new"
                    'check if already exist
                    vQuery = "SELECT terminal_id FROM tb_stations WHERE terminal_id = '" & modModule.CorrectSqlString(txtTerminalID.Text) & "'"

                    'create query
                    vMyPgCmd = New NpgsqlCommand(vQuery, vMyPgCon)

                    'execute query
                    vMyPgRd = vMyPgCmd.ExecuteReader()

                    'read values
                    vFound = vMyPgRd.Read

                    If vFound = True Then
                        'close and dispose to avoid memory leak
                        vMyPgRd.Close()
                        vMyPgCmd.Dispose()

                        lblStatusPrompt.Text = "Closing database..."
                        lblStatusPrompt.Refresh()

                        'close and dispose connection
                        vMyPgCon.Close()
                        vMyPgCon = Nothing

                        lblStatusPrompt.Text = "Ready"
                        lblStatusPrompt.Visible = True

                        'record found
                        vTmpVar = MsgBox("Terminal with code " & modModule.CorrectSqlString(txtTerminalID.Text) & " already exist in record." & vbCrLf & vbCrLf & _
                                        "Please assign another Terminal ID or double check records.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Validation failed")
                        Exit Sub
                    End If

                    'close and dispose to avoid memory leak
                    vMyPgRd.Close()
                    vMyPgCmd.Dispose()

                Case "edit"
                    'check if already exist
                    vQuery = "SELECT terminal_id FROM tb_stations WHERE terminal_id = '" & modModule.CorrectSqlString(txtTerminalID.Text) & "'"

                    'create query
                    vMyPgCmd = New NpgsqlCommand(vQuery, vMyPgCon)

                    'execute query
                    vMyPgRd = vMyPgCmd.ExecuteReader()

                    'read values
                    vFound = vMyPgRd.Read

                    If vFound = False Then
                        'close and dispose to avoid memory leak
                        vMyPgRd.Close()
                        vMyPgCmd.Dispose()

                        lblStatusPrompt.Text = "Closing database..."
                        lblStatusPrompt.Refresh()

                        'close and dispose connection
                        vMyPgCon.Close()
                        vMyPgCon = Nothing

                        lblStatusPrompt.Text = "Ready"
                        lblStatusPrompt.Visible = True

                        'record found
                        vTmpVar = MsgBox("Terminal with ID " & modModule.CorrectSqlString(txtTerminalID.Text) & " no longer exist in record." & vbCrLf & vbCrLf & _
                                        "Please make sure the record was not deleted.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Validation failed")
                        Exit Sub
                    End If

                    'close and dispose to avoid memory leak
                    vMyPgRd.Close()
                    vMyPgCmd.Dispose()
            End Select

            If LCase(cmbType.Text) <> "any" Then
                If (gOldTerminalLane <> txtTerminalLane.Text) Or (gOldPetcCode <> txtPetcCode.Text) Then
                    'check if already exist
                    vQuery = "SELECT terminal_id FROM tb_stations WHERE petc_code = '" & modModule.CorrectSqlString(txtPetcCode.Text) & "' AND " & _
                        "petc_lane = '" & modModule.CorrectSqlString(txtTerminalLane.Text) & "' AND is_active = 1"

                    'create query
                    vMyPgCmd = New NpgsqlCommand(vQuery, vMyPgCon)

                    'execute query
                    vMyPgRd = vMyPgCmd.ExecuteReader()

                    'read values
                    vFound = vMyPgRd.Read

                    If vFound = True Then
                        'record found
                        vTmpVar = MsgBox("Lane is already used by Terminal with ID " & modModule.CorrectSqlString(vMyPgRd("terminal_id")) & "." & vbCrLf & vbCrLf & _
                                        "Please re-check your data.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Validation failed")

                        'close and dispose to avoid memory leak
                        vMyPgRd.Close()
                        vMyPgCmd.Dispose()

                        lblStatusPrompt.Text = "Closing database..."
                        lblStatusPrompt.Refresh()

                        'close and dispose connection
                        vMyPgCon.Close()
                        vMyPgCon = Nothing

                        lblStatusPrompt.Text = "Ready"
                        lblStatusPrompt.Visible = True

                        Exit Sub
                    End If

                    'close and dispose to avoid memory leak
                    vMyPgRd.Close()
                    vMyPgCmd.Dispose()
                End If
            End If


            If LCase(txtPetcCode.Text) <> "tech.support" Then
                'check if petc does exist
                vQuery = "SELECT petc_lanes FROM tb_petcs WHERE petc_code = '" & modModule.CorrectSqlString(txtPetcCode.Text) & "'"

                'create query
                vMyPgCmd = New NpgsqlCommand(vQuery, vMyPgCon)

                'execute query
                vMyPgRd = vMyPgCmd.ExecuteReader()

                'read values
                vFound = vMyPgRd.Read

                If vFound = False Then
                    'close and dispose to avoid memory leak
                    vMyPgRd.Close()
                    vMyPgCmd.Dispose()

                    lblStatusPrompt.Text = "Closing database..."
                    lblStatusPrompt.Refresh()

                    'close and dispose connection
                    vMyPgCon.Close()
                    vMyPgCon = Nothing

                    lblStatusPrompt.Text = "Ready"
                    lblStatusPrompt.Visible = True

                    'record found
                    vTmpVar = MsgBox("PETC with code " & modModule.CorrectSqlString(txtPetcCode.Text) & " does not exist exist in record." & vbCrLf & vbCrLf & _
                                    "Please re-check the PETC Code.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Validation failed")

                    txtPetcCode.Select()
                    txtPetcCode.Focus()

                    Exit Sub
                Else
                    'check if lane number is valid
                    If IsDBNull(vMyPgRd("petc_lanes")) = True Then
                        'close and dispose to avoid memory leak
                        vMyPgRd.Close()
                        vMyPgCmd.Dispose()

                        lblStatusPrompt.Text = "Closing database..."
                        lblStatusPrompt.Refresh()

                        'close and dispose connection
                        vMyPgCon.Close()
                        vMyPgCon = Nothing

                        lblStatusPrompt.Text = "Ready"
                        lblStatusPrompt.Visible = True

                        'record found
                        vTmpVar = MsgBox("PETC with code " & modModule.CorrectSqlString(txtPetcCode.Text) & " does not have a valid number of lanes." & vbCrLf & vbCrLf & _
                                        "Please re-check the PETC record.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Validation failed")

                        txtPetcCode.Select()
                        txtPetcCode.Focus()

                        Exit Sub
                    Else
                        Dim vTmpMaxLanes As Integer = 0

                        vTmpMaxLanes = vMyPgRd("petc_lanes") * 2

                        If CDbl(txtTerminalLane.Text) > vTmpMaxLanes Then
                            'close and dispose to avoid memory leak
                            vMyPgRd.Close()
                            vMyPgCmd.Dispose()

                            lblStatusPrompt.Text = "Closing database..."
                            lblStatusPrompt.Refresh()

                            'close and dispose connection
                            vMyPgCon.Close()
                            vMyPgCon = Nothing

                            lblStatusPrompt.Text = "Ready"
                            lblStatusPrompt.Visible = True

                            'record found
                            vTmpVar = MsgBox("Maximum number of lanes allowed are " & modModule.CorrectSqlString(vTmpMaxLanes) & ".", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Validation failed")

                            txtTerminalLane.Select()
                            txtTerminalLane.Focus()

                            Exit Sub
                        End If
                    End If
                End If

                'close and dispose to avoid memory leak
                vMyPgRd.Close()
                vMyPgCmd.Dispose()
            End If

            lblStatusPrompt.Text = "Initializing transaction..."
            lblStatusPrompt.Refresh()

            vQuery = "BEGIN TRANSACTION"

            'create query
            vMyPgCmd = New NpgsqlCommand(vQuery, vMyPgCon)

            'execute query
            vMyPgCmd.ExecuteNonQuery()

            'close and dispose to avoid memory leak
            vMyPgCmd.Dispose()

            lblStatusPrompt.Text = "Creating record in database..."
            lblStatusPrompt.Refresh()

            Select Case LCase(Me.Mode)
                Case "new"
                    'insert in tb_stations table
                    vQuery = "INSERT INTO tb_stations (terminal_id, terminal_type, terminal_serial, terminal_mac, terminal_ip, " & _
                        "terminal_machine_description, terminal_machine_serial, terminal_machine_calibrated, petc_code, petc_lane, is_active, " & _
                        "description, lock_status, dll_file, machine_port, machine_baud_rate, machine_parity, machine_bits, machine_stop_bits, is_scsi) " & _
                        "VALUES ('" & modModule.CorrectSqlString(txtTerminalID.Text) & "', '" & modModule.CorrectSqlString(cmbType.Text) & "', " & _
                            "'" & modModule.CorrectSqlString(txtTerminalSerial.Text) & "', '" & modModule.CorrectSqlString(txtTerminalMac.Text) & "', " & _
                            "'" & modModule.CorrectSqlString(txtTerminalIP.Text) & "', '" & modModule.CorrectSqlString(txtMachineDescription.Text) & "', " & _
                            "'" & modModule.CorrectSqlString(txtMachineSerial.Text) & "', " & _
                             IIf(txtDateCalibrated.Text = "", "NULL, ", "'" & txtDateCalibrated.Text & "', ") & _
                             "'" & modModule.CorrectSqlString(txtPetcCode.Text) & "', '" & modModule.CorrectSqlString(txtTerminalLane.Text) & "', " & _
                             modModule.CorrectSqlString(vTmpStatus) & ", '" & modModule.CorrectSqlString(txtTerminalDescription.Text) & "', " & _
                             modModule.CorrectSqlString(IIf(chkLocked.Checked = True, "1", "0")) & ", " & _
                             "'" & modModule.CorrectSqlString(txtMachineDLL.Text) & "', '" & modModule.CorrectSqlString(cmbMachinePort.Text) & "', " & _
                             "'" & modModule.CorrectSqlString(cmbMachineBaud.Text) & "', '" & modModule.CorrectSqlString(cmbMachineParity.Text) & "', " & _
                             "'" & modModule.CorrectSqlString(cmbMachineBits.Text) & "', '" & modModule.CorrectSqlString(cmbMachineStopBits.Text) & "', " & _
                             modModule.CorrectSqlString(IIf(chkScsiSas.Checked = True, "1", "0")) & ")"

                Case "edit"
                    'update in tb_petc table
                    vQuery = "UPDATE tb_stations SET terminal_type = '" & modModule.CorrectSqlString(cmbType.Text) & "', " & _
                        "terminal_serial = '" & modModule.CorrectSqlString(txtTerminalSerial.Text) & "', " & _
                        "terminal_mac = '" & modModule.CorrectSqlString(txtTerminalMac.Text) & "', " & _
                        "terminal_ip = '" & modModule.CorrectSqlString(txtTerminalIP.Text) & "', " & _
                        "terminal_machine_description = '" & modModule.CorrectSqlString(txtMachineDescription.Text) & "', " & _
                        "terminal_machine_serial = '" & modModule.CorrectSqlString(txtMachineSerial.Text) & "', " & _
                        "is_scsi = " & modModule.CorrectSqlString(IIf(chkScsiSas.Checked = True, "1", "0")) & ", " & _
                        "terminal_machine_calibrated = " & IIf(txtDateCalibrated.Text = "", "NULL, ", "'" & txtDateCalibrated.Text & "', ") & _
                        "petc_code = '" & modModule.CorrectSqlString(txtPetcCode.Text) & "', " & _
                        "petc_lane = '" & modModule.CorrectSqlString(txtTerminalLane.Text) & "', " & _
                        "is_active = " & vTmpStatus & ", " & _
                        "description = '" & modModule.CorrectSqlString(txtTerminalDescription.Text) & "', " & _
                        "lock_status = " & modModule.CorrectSqlString(IIf(chkLocked.Checked = True, "1", "0")) & ", " & _
                        "dll_file = '" & modModule.CorrectSqlString(txtMachineDLL.Text) & "', " & _
                        "machine_port = '" & modModule.CorrectSqlString(cmbMachinePort.Text) & "', " & _
                        "machine_baud_rate = '" & modModule.CorrectSqlString(cmbMachineBaud.Text) & "', " & _
                        "machine_parity = '" & modModule.CorrectSqlString(cmbMachineParity.Text) & "', " & _
                        "machine_bits = '" & modModule.CorrectSqlString(cmbMachineBits.Text) & "', " & _
                        "machine_stop_bits = '" & modModule.CorrectSqlString(cmbMachineStopBits.Text) & "' " & _
                        "WHERE terminal_id = '" & modModule.CorrectSqlString(txtTerminalID.Text) & "'"
            End Select

            'create query
            vMyPgCmd = New NpgsqlCommand(vQuery, vMyPgCon)

            'execute query
            vMyPgCmd.ExecuteNonQuery()

            'close and dispose to avoid memory leak
            vMyPgCmd.Dispose()

            'create log
            Select Case LCase(Me.Mode)
                Case "new"
                    vTmpStr = ""

                Case "edit"
                    'changes made
                    vFound = ChangesMade(vTmpStr, False)
            End Select

            vQuery = modModule.CreateLogCn(vMyPgCon, Me.Name, LCase(Me.Mode) & " terminal " & txtTerminalID.Text, vTmpStr)

            If vQuery <> "1" Then
                lblStatusPrompt.Text = "An error has occurred"

                MsgBox("An error occurred while saving log. Operation aborted.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Operation cancelled")

                'close and dispose to avoid memory leak
                vMyPgCon.Close()
                vMyPgCon = Nothing

                Exit Sub
            End If

            lblStatusPrompt.Text = "Finalizing transaction..."
            lblStatusPrompt.Refresh()

            vQuery = "COMMIT TRANSACTION"

            'create query
            vMyPgCmd = New NpgsqlCommand(vQuery, vMyPgCon)

            'execute query
            vMyPgCmd.ExecuteNonQuery()

            'close and dispose to avoid memory leak
            vMyPgCmd.Dispose()

            'Create log

            lblStatusPrompt.Text = "Closing database..."
            lblStatusPrompt.Refresh()

            'close and dispose connection
            vMyPgCon.Close()
            vMyPgCon = Nothing

            lblStatusPrompt.Text = "Ready"
            lblStatusPrompt.Visible = True

            MsgBox("Successful in " & IIf(LCase(Me.Mode) = "new", " creating new ", " updating ") & " Terminal " & txtTerminalID.Text & ".", _
                   MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Operation complete")

            Me.Close()

            Exit Sub

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
            vQuery = modModule.CreateLog(Me.Name, "Error:cmdProcess", ex.Message)

            lblStatusPrompt.Text = "An error has occurred"
            lblStatusPrompt.Visible = True
            lblStatusPrompt.Refresh()

            EnableButtons()
        End Try
    End Sub

    Private Sub timerLoad_Tick(sender As Object, e As EventArgs) Handles timerLoad.Tick
        'open postgres connection
        Dim vMyPgCon As New NpgsqlConnection
        Dim vMyPgCmd = New NpgsqlCommand
        Dim vMyPgRd As NpgsqlDataReader
        Dim vFound As Boolean

        Dim vQuery As String

        Dim vTmpVar As Integer

        timerLoad.Enabled = False

        If LCase(Me.Mode) <> "edit" Then Exit Sub
        If Trim(Me.TerminalID) = "" Then Exit Sub

        Try
            DisableButtons()

            InitializeValues()

            vQuery = "SELECT terminal_id, terminal_type, terminal_serial, terminal_mac, terminal_ip, terminal_machine_description, terminal_machine_serial, " & _
                "terminal_machine_calibrated, petc_code, petc_lane, is_active, description, lock_status, " & _
                "dll_file, machine_port, machine_baud_rate, machine_parity, machine_bits, machine_stop_bits, is_scsi " & _
                "FROM tb_stations WHERE terminal_id = '" & modModule.CorrectSqlString(Me.TerminalID) & "'"

            lblStatusPrompt.Text = "Opening database..."
            lblStatusPrompt.Visible = True
            lblStatusPrompt.Refresh()

            'open db connection
            vMyPgCon.ConnectionString = pConnectVox
            vMyPgCon.Open()

            'create query
            vMyPgCmd = New NpgsqlCommand(vQuery, vMyPgCon)

            'execute query
            vMyPgRd = vMyPgCmd.ExecuteReader()

            'read values
            vFound = vMyPgRd.Read

            If vFound = False Then
                'no record found
                vTmpVar = MsgBox("Terminal record no longer exist." & vbCrLf & vbCrLf & _
                                "Please make sure the record was not deleted.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Unexpected error")

                Me.Close()

                Exit Sub
            Else
                'get result

                txtTerminalID.Text = Me.TerminalID

                If IsDBNull(vMyPgRd("terminal_type")) = False Then
                    cmbType.Text = vMyPgRd("terminal_type")
                End If

                If IsDBNull(vMyPgRd("petc_lane")) = False Then
                    txtTerminalLane.Text = vMyPgRd("petc_lane")
                End If

                If IsDBNull(vMyPgRd("petc_code")) = False Then
                    txtPetcCode.Text = vMyPgRd("petc_code")
                End If

                If IsDBNull(vMyPgRd("description")) = False Then
                    txtTerminalDescription.Text = vMyPgRd("description")
                End If

                If IsDBNull(vMyPgRd("terminal_serial")) = False Then
                    txtTerminalSerial.Text = vMyPgRd("terminal_serial")
                End If

                If IsDBNull(vMyPgRd("is_scsi")) = True Then
                    chkScsiSas.Checked = False
                Else
                    Select Case vMyPgRd("is_scsi")
                        Case "1"
                            chkScsiSas.Checked = True

                        Case "0"
                            chkScsiSas.Checked = False

                        Case Else
                            chkScsiSas.Checked = False
                    End Select
                End If

                If IsDBNull(vMyPgRd("terminal_ip")) = False Then
                    txtTerminalIP.Text = vMyPgRd("terminal_ip")
                End If

                If IsDBNull(vMyPgRd("terminal_mac")) = False Then
                    txtTerminalMac.Text = vMyPgRd("terminal_mac")
                End If

                If IsDBNull(vMyPgRd("is_active")) = False Then
                    Select Case vMyPgRd("is_active")
                        Case 0
                            cmbStatus.Text = "Inactive"

                        Case 1
                            cmbStatus.Text = "Active"

                        Case Else
                            cmbStatus.Text = "Unknown"
                    End Select
                End If

                If IsDBNull(vMyPgRd("terminal_machine_description")) = False Then
                    txtMachineDescription.Text = vMyPgRd("terminal_machine_description")
                End If

                If IsDBNull(vMyPgRd("terminal_machine_serial")) = False Then
                    txtMachineSerial.Text = vMyPgRd("terminal_machine_serial")
                End If

                If IsDBNull(vMyPgRd("terminal_machine_calibrated")) = False Then
                    txtDateCalibrated.Text = Format(CDate(vMyPgRd("terminal_machine_calibrated").ToString), "MM/dd/yyyy")
                End If

                If IsDBNull(vMyPgRd("lock_status")) = False Then
                    Select Case vMyPgRd("lock_status")
                        Case 0
                            chkLocked.Checked = False

                        Case 1
                            chkLocked.Checked = True

                        Case Else
                            chkLocked.Checked = False
                    End Select
                End If

                If IsDBNull(vMyPgRd("dll_file")) = False Then
                    txtMachineDLL.Text = vMyPgRd("dll_file")
                End If

                If IsDBNull(vMyPgRd("machine_port")) = False Then
                    cmbMachinePort.Text = vMyPgRd("machine_port")
                End If

                If IsDBNull(vMyPgRd("machine_baud_rate")) = False Then
                    cmbMachineBaud.Text = vMyPgRd("machine_baud_rate")
                End If

                If IsDBNull(vMyPgRd("machine_parity")) = False Then
                    cmbMachineParity.Text = vMyPgRd("machine_parity")
                End If

                If IsDBNull(vMyPgRd("machine_bits")) = False Then
                    cmbMachineBits.Text = vMyPgRd("machine_bits")
                End If

                If IsDBNull(vMyPgRd("machine_stop_bits")) = False Then
                    cmbMachineStopBits.Text = vMyPgRd("machine_stop_bits")
                End If

                Select Case LCase(Trim(cmbType.Text))
                    Case "gas", "diesel"
                        txtMachineDLL.Enabled = True
                        cmbMachinePort.Enabled = True
                        cmbMachineBaud.Enabled = True
                        cmbMachineParity.Enabled = True
                        cmbMachineBits.Enabled = True
                        cmbMachineStopBits.Enabled = True

                    Case Else
                        txtMachineDLL.Enabled = False
                        cmbMachinePort.Enabled = False
                        cmbMachineBaud.Enabled = False
                        cmbMachineParity.Enabled = False
                        cmbMachineBits.Enabled = False
                        cmbMachineStopBits.Enabled = False
                End Select
            End If

            lblStatusPrompt.Text = "Closing database..."
            lblStatusPrompt.Refresh()

            'close and dispose to avoid memory leak
            vMyPgRd.Close()
            vMyPgCmd.Dispose()

            'close and dispose connection
            vMyPgCon.Close()
            vMyPgCon = Nothing

            'save old values for later comparison
            SaveOldValues()

            'cmbType_SelectedIndexChanged(sender, e)

            lblStatusPrompt.Text = "Ready"
            lblStatusPrompt.Visible = True
            lblStatusPrompt.Refresh()

            EnableButtons()

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
            vQuery = modModule.CreateLog(Me.Name, "Error:timerLoad", ex.Message)

            lblStatusPrompt.Text = "An error has occurred"
            lblStatusPrompt.Visible = True
            lblStatusPrompt.Refresh()

            Me.Close()

            Exit Sub
        End Try
    End Sub

    Private Sub txtTerminalID_GotFocus(sender As Object, e As EventArgs) Handles txtTerminalID.GotFocus
        txtTerminalID.SelectAll()
    End Sub

    Private Sub txtTerminalID_LostFocus(sender As Object, e As EventArgs) Handles txtTerminalID.LostFocus
        txtTerminalID.Text = UCase(Trim(modModule.StripInvalidStringChars(txtTerminalID.Text)))
    End Sub

    Private Sub txtTerminalID_TextChanged(sender As Object, e As EventArgs) Handles txtTerminalID.TextChanged

    End Sub

    Private Sub cmbType_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbType.KeyPress
        e.Handled = True
    End Sub

    Private Sub cmbType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbType.SelectedIndexChanged
        If LCase(Me.Mode) = "edit" Then Exit Sub

        Select Case LCase(cmbType.Text)
            Case "gas", "diesel"
                txtPetcCode.ReadOnly = False

                cmdBrowsePetc.Enabled = True

                If Me.Mode = "edit" Then
                    txtPetcCode.Text = gOldPetcCode
                    txtTerminalLane.Text = gOldTerminalLane

                    If Trim(txtPetcCode.Text = "tech.support") Then txtPetcCode.Text = ""
                End If

                txtTerminalLane.ReadOnly = False

                If IsNumeric(txtTerminalLane.Text) = False Then
                    txtTerminalLane.Text = "0"
                End If

                txtMachineDLL.Enabled = True
                cmbMachinePort.Enabled = True
                cmbMachineBaud.Enabled = True
                cmbMachineParity.Enabled = True
                cmbMachineBits.Enabled = True
                cmbMachineStopBits.Enabled = True

            Case "any"
                txtPetcCode.Text = "tech.support"
                txtPetcCode.ReadOnly = True

                cmdBrowsePetc.Enabled = False

                txtTerminalLane.Text = "0"
                txtTerminalLane.ReadOnly = True

                txtMachineDLL.Enabled = False
                cmbMachinePort.Enabled = False
                cmbMachineBaud.Enabled = False
                cmbMachineParity.Enabled = False
                cmbMachineBits.Enabled = False
                cmbMachineStopBits.Enabled = False

            Case Else
                txtPetcCode.ReadOnly = False
                cmdBrowsePetc.Enabled = True
                txtTerminalLane.ReadOnly = False

                If Me.Mode = "edit" Then
                    txtPetcCode.Text = gOldPetcCode
                    txtTerminalLane.Text = gOldTerminalLane

                    If IsNumeric(txtTerminalLane.Text) = False Then
                        txtTerminalLane.Text = "0"
                    End If
                End If

                txtMachineDLL.Enabled = False
                cmbMachinePort.Enabled = False
                cmbMachineBaud.Enabled = False
                cmbMachineParity.Enabled = False
                cmbMachineBits.Enabled = False
                cmbMachineStopBits.Enabled = False
        End Select
    End Sub

    Private Sub txtPetcCode_GotFocus(sender As Object, e As EventArgs) Handles txtPetcCode.GotFocus
        txtPetcCode.SelectAll()
    End Sub

    Private Sub txtPetcCode_Invalidated(sender As Object, e As InvalidateEventArgs) Handles txtPetcCode.Invalidated

    End Sub

    Private Sub txtPetcCode_LostFocus(sender As Object, e As EventArgs) Handles txtPetcCode.LostFocus
        If LCase(txtPetcCode.Text) = "tech.support" Then
            If LCase(cmbType.Text) <> "any" Then
                txtPetcCode.Text = ""
            Else
                txtPetcCode.Text = "tech.support"
            End If
        Else
            txtPetcCode.Text = UCase(Trim(modModule.StripInvalidStringChars(txtPetcCode.Text)))
        End If
    End Sub

    Private Sub txtPetcCode_TextChanged(sender As Object, e As EventArgs) Handles txtPetcCode.TextChanged

    End Sub

    Private Sub txtTerminalDescription_GotFocus(sender As Object, e As EventArgs) Handles txtTerminalDescription.GotFocus
        txtTerminalDescription.SelectAll()
    End Sub

    Private Sub txtTerminalDescription_LostFocus(sender As Object, e As EventArgs) Handles txtTerminalDescription.LostFocus
        txtTerminalDescription.Text = UCase(Trim(modModule.StripInvalidStringChars(txtTerminalDescription.Text)))
    End Sub

    Private Sub txtTerminalDescription_TextChanged(sender As Object, e As EventArgs) Handles txtTerminalDescription.TextChanged

    End Sub

    Private Sub txtTerminalSerial_GotFocus(sender As Object, e As EventArgs) Handles txtTerminalSerial.GotFocus
        txtTerminalSerial.SelectAll()
    End Sub

    Private Sub txtTerminalSerial_LostFocus(sender As Object, e As EventArgs) Handles txtTerminalSerial.LostFocus
        txtTerminalSerial.Text = LCase(Trim(modModule.StripInvalidStringChars(txtTerminalSerial.Text)))
    End Sub

    Private Sub txtTerminalSerial_TextChanged(sender As Object, e As EventArgs) Handles txtTerminalSerial.TextChanged

    End Sub

    Private Sub cmbStatus_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbStatus.KeyPress
        e.Handled = True
    End Sub

    Private Sub cmbStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbStatus.SelectedIndexChanged

    End Sub

    Private Sub txtTerminalMac_GotFocus(sender As Object, e As EventArgs) Handles txtTerminalMac.GotFocus
        txtTerminalMac.SelectAll()
    End Sub

    Private Sub txtTerminalMac_LostFocus(sender As Object, e As EventArgs) Handles txtTerminalMac.LostFocus
        txtTerminalMac.Text = LCase(Trim(modModule.StripInvalidStringChars(txtTerminalMac.Text)))
    End Sub

    Private Sub txtTerminalMac_TextChanged(sender As Object, e As EventArgs) Handles txtTerminalMac.TextChanged

    End Sub

    Private Sub txtTerminalIP_GotFocus(sender As Object, e As EventArgs) Handles txtTerminalIP.GotFocus
        txtTerminalIP.SelectAll()
    End Sub

    Private Sub txtTerminalIP_LostFocus(sender As Object, e As EventArgs) Handles txtTerminalIP.LostFocus
        txtTerminalIP.Text = UCase(Trim(modModule.StripInvalidStringChars(txtTerminalIP.Text)))
    End Sub

    Private Sub txtTerminalIP_TextChanged(sender As Object, e As EventArgs) Handles txtTerminalIP.TextChanged

    End Sub

    Private Sub txtTerminalLane_GotFocus(sender As Object, e As EventArgs) Handles txtTerminalLane.GotFocus
        txtTerminalLane.SelectAll()
    End Sub

    Private Sub txtTerminalLane_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTerminalLane.KeyPress
        Select Case e.KeyChar
            Case "0" To "9"
            Case Else
                e.Handled = True
        End Select
    End Sub

    Private Sub txtTerminalLane_LostFocus(sender As Object, e As EventArgs) Handles txtTerminalLane.LostFocus
        If IsNumeric(txtTerminalLane.Text) = True Then
            txtTerminalLane.Text = Trim(Str(CDbl(txtTerminalLane.Text)))
        Else
            txtTerminalLane.Text = "0"
        End If
    End Sub

    Private Sub txtTerminalLane_TextChanged(sender As Object, e As EventArgs) Handles txtTerminalLane.TextChanged

    End Sub

    Private Sub txtMachineDescription_GotFocus(sender As Object, e As EventArgs) Handles txtMachineDescription.GotFocus
        txtMachineDescription.SelectAll()
    End Sub

    Private Sub txtMachineDescription_LostFocus(sender As Object, e As EventArgs) Handles txtMachineDescription.LostFocus
        txtMachineDescription.Text = UCase(Trim(modModule.StripInvalidStringChars(txtMachineDescription.Text)))
    End Sub

    Private Sub txtMachineDescription_TextChanged(sender As Object, e As EventArgs) Handles txtMachineDescription.TextChanged

    End Sub

    Private Sub txtMachineSerial_GotFocus(sender As Object, e As EventArgs) Handles txtMachineSerial.GotFocus
        txtMachineSerial.SelectAll()
    End Sub

    Private Sub txtMachineSerial_LostFocus(sender As Object, e As EventArgs) Handles txtMachineSerial.LostFocus
        txtMachineSerial.Text = UCase(Trim(modModule.StripInvalidStringChars(txtMachineSerial.Text)))
    End Sub

    Private Sub txtMachineSerial_TextChanged(sender As Object, e As EventArgs) Handles txtMachineSerial.TextChanged

    End Sub

    Private Sub txtDateCalibrated_GotFocus(sender As Object, e As EventArgs) Handles txtDateCalibrated.GotFocus
        txtDateCalibrated.SelectAll()
    End Sub

    Private Sub txtDateCalibrated_LostFocus(sender As Object, e As EventArgs) Handles txtDateCalibrated.LostFocus
        If IsDate(txtDateCalibrated.Text) = True Then
            txtDateCalibrated.Text = Format(CDate(txtDateCalibrated.Text), "yyyy-MM-dd")
        Else
            txtDateCalibrated.Text = ""
        End If
    End Sub

    Private Sub txtDateCalibrated_TextChanged(sender As Object, e As EventArgs) Handles txtDateCalibrated.TextChanged

    End Sub

    Private Sub cmdBrowsePetc_Click(sender As Object, e As EventArgs) Handles cmdBrowsePetc.Click
        MsgBox("This option is currently unavailable", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Option unavailable")
    End Sub

    Private Sub cmbMachinePort_GotFocus(sender As Object, e As EventArgs) Handles cmbMachinePort.GotFocus
        cmbMachinePort.SelectAll()
    End Sub

    Private Sub cmbMachinePort_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbMachinePort.KeyPress
        e.Handled = True
    End Sub

    Private Sub cmbMachinePort_LostFocus(sender As Object, e As EventArgs) Handles cmbMachinePort.LostFocus
        cmbMachinePort.Text = modModule.StripInvalidStringChars(Trim(cmbMachinePort.Text))
    End Sub

    Private Sub cmbMachinePort_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMachinePort.SelectedIndexChanged

    End Sub

    Private Sub cmbMachineBaud_GotFocus(sender As Object, e As EventArgs) Handles cmbMachineBaud.GotFocus
        cmbMachineBaud.SelectAll()
    End Sub

    Private Sub cmbMachineBaud_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbMachineBaud.KeyPress
        e.Handled = True
    End Sub

    Private Sub cmbMachineBaud_LostFocus(sender As Object, e As EventArgs) Handles cmbMachineBaud.LostFocus
        cmbMachineBaud.Text = modModule.StripInvalidStringChars(Trim(cmbMachineBaud.Text))
    End Sub

    Private Sub cmbMachineBaud_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMachineBaud.SelectedIndexChanged

    End Sub

    Private Sub cmbMachineParity_GotFocus(sender As Object, e As EventArgs) Handles cmbMachineParity.GotFocus
        cmbMachineParity.SelectAll()
    End Sub

    Private Sub cmbMachineParity_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbMachineParity.KeyPress
        e.Handled = True
    End Sub

    Private Sub cmbMachineParity_LostFocus(sender As Object, e As EventArgs) Handles cmbMachineParity.LostFocus
        cmbMachineParity.Text = modModule.StripInvalidStringChars(Trim(cmbMachineParity.Text))
    End Sub

    Private Sub cmbMachineParity_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMachineParity.SelectedIndexChanged

    End Sub

    Private Sub txtMachineDLL_GotFocus(sender As Object, e As EventArgs) Handles txtMachineDLL.GotFocus
        txtMachineDLL.SelectAll()
    End Sub

    Private Sub txtMachineDLL_LostFocus(sender As Object, e As EventArgs) Handles txtMachineDLL.LostFocus
        txtMachineDLL.Text = modModule.StripInvalidStringChars(Trim(txtMachineDLL.Text))
    End Sub

    Private Sub txtMachineDLL_TextChanged(sender As Object, e As EventArgs) Handles txtMachineDLL.TextChanged

    End Sub

    Private Sub cmbMachineBits_GotFocus(sender As Object, e As EventArgs) Handles cmbMachineBits.GotFocus
        cmbMachineBits.SelectAll()
    End Sub

    Private Sub cmbMachineBits_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbMachineBits.KeyPress
        e.Handled = True
    End Sub

    Private Sub cmbMachineBits_LostFocus(sender As Object, e As EventArgs) Handles cmbMachineBits.LostFocus
        cmbMachineBits.Text = modModule.StripInvalidStringChars(Trim(cmbMachineBits.Text))
    End Sub

    Private Sub cmbMachineBits_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMachineBits.SelectedIndexChanged

    End Sub

    Private Sub cmbMachineStopBits_GotFocus(sender As Object, e As EventArgs) Handles cmbMachineStopBits.GotFocus
        cmbMachineStopBits.SelectAll()
    End Sub

    Private Sub cmbMachineStopBits_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbMachineStopBits.KeyPress
        e.Handled = True
    End Sub

    Private Sub cmbMachineStopBits_LostFocus(sender As Object, e As EventArgs) Handles cmbMachineStopBits.LostFocus
        cmbMachineStopBits.Text = modModule.StripInvalidStringChars(Trim(cmbMachineStopBits.Text))
    End Sub

    Private Sub cmbMachineStopBits_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMachineStopBits.SelectedIndexChanged

    End Sub
End Class