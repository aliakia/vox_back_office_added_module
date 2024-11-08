Imports System.Text
Imports System.Security.Cryptography
Imports Npgsql
Imports System.Reflection
Imports System.IO
Imports System.Data.SqlClient
Imports System.Xml


Module modModule

    Public pResultFrom As String = ""
    Public pResultStr As String = ""
    Public pResultStr0 As String = ""
    Public pResultStr1 As String = ""
    Public pResultStr2 As String = ""
    Public pResultStr3 As String = ""
    Public pResultStr4 As String = ""
    Public pResultStr5 As String = ""
    Public pResultStr6 As String = ""
    Public pResultStr7 As String = ""
    Public pResultStr8 As String = ""
    Public pResultStr9 As String = ""

    Public pUserID As String = ""
    Public pUserName As String = ""
    Public pUserGroup As String = ""

    Public pTerminalSerial As String = ""

    Public pConnectVox As String = ""
    Public pConnectMasterDb As String = ""
    Public pPostgresPath As String = ""
    Public pPostgresServer As String = ""
    Public pPostgresUserID As String = ""
    Public pPostgresPassword As String = ""
    Public pPostgresPort As String = ""
    Public pPostgresDbName As String = ""
    Public pBackupDir As String = ""
    Public pWorkDirectory As String = ""

    Public pViewBackgroundColorMax As Byte
    Public pViewBackgroundCtr As Byte
    Public pViewBackgroundColor(2) As System.Drawing.Color

    Public pViewScreenSummaryHeight As Single = 0.6
    Public pViewScreenDetailsHeight As Single = 0.4

    Private Const INFINITE = &HFFFFFFFF
    Private Const SYNCHRONIZE = &H100000
    Private Const PROCESS_QUERY_INFORMATION = &H400&

    Private Declare Function OpenProcess Lib "kernel32" ( _
        ByVal dwDesiredAccess As Integer, _
        ByVal bInheritHandle As Boolean, _
        ByVal dwProcessId As Integer) As IntPtr

    Private Declare Function WaitForSingleObject Lib "kernel32" ( _
        ByVal hHandle As Integer, _
        ByVal dwMilliseconds As Integer) As IntPtr

    Private Declare Function CloseHandle Lib "kernel32" ( _
        ByVal hObject As Integer) As IntPtr

    Class ListViewItemComparer
        Implements IComparer

        Private m_ColumnNumber As Integer
        Private m_SortOrder As System.Windows.Forms.SortOrder

        Public Sub New(ByVal column_number As Integer, ByVal _
            sort_order As System.Windows.Forms.SortOrder)
            m_ColumnNumber = column_number
            m_SortOrder = sort_order
        End Sub

        ' Compare the items in the appropriate column
        ' for objects x and y.
        Public Function Compare(ByVal x As Object, ByVal y As _
            Object) As Integer Implements _
            System.Collections.IComparer.Compare
            Dim item_x As ListViewItem = DirectCast(x,  _
                ListViewItem)
            Dim item_y As ListViewItem = DirectCast(y,  _
                ListViewItem)

            ' Get the sub-item values.
            Dim string_x As String
            If item_x.SubItems.Count <= m_ColumnNumber Then
                string_x = ""
            Else
                string_x = item_x.SubItems(m_ColumnNumber).Text
            End If

            Dim string_y As String
            If item_y.SubItems.Count <= m_ColumnNumber Then
                string_y = ""
            Else
                string_y = item_y.SubItems(m_ColumnNumber).Text
            End If

            ' Compare them.
            If m_SortOrder = System.Windows.Forms.SortOrder.Ascending Then
                If IsNumeric(string_x) And IsNumeric(string_y) _
                    Then
                    Return Val(string_x).CompareTo(Val(string_y))
                ElseIf IsDate(string_x) And IsDate(string_y) _
                    Then
                    Return DateTime.Parse(string_x).CompareTo(DateTime.Parse(string_y))
                Else
                    Return String.Compare(string_x, string_y)
                End If
            Else
                If IsNumeric(string_x) And IsNumeric(string_y) _
                    Then
                    Return Val(string_y).CompareTo(Val(string_x))
                ElseIf IsDate(string_x) And IsDate(string_y) _
                    Then
                    Return DateTime.Parse(string_y).CompareTo(DateTime.Parse(string_x))
                Else
                    Return String.Compare(string_y, string_x)
                End If
            End If
        End Function
    End Class

    Function GetMd5Hash(ByVal md5Hash As MD5, ByVal input As String) As String

        ' Convert the input string to a byte array and compute the hash. 
        Dim data As Byte() = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input))

        ' Create a new Stringbuilder to collect the bytes 
        ' and create a string. 
        Dim sBuilder As New StringBuilder()

        ' Loop through each byte of the hashed data  
        ' and format each one as a hexadecimal string. 
        Dim i As Integer
        For i = 0 To data.Length - 1
            sBuilder.Append(data(i).ToString("x2"))
        Next i

        ' Return the hexadecimal string. 
        Return sBuilder.ToString()

    End Function 'GetMd5Hash

    Public Function StripInvalidStringChars(ByVal bString As String) As String
        Dim vCtr As Long
        Dim vChar As String
        Dim vTmpStr As String

        StripInvalidStringChars = ""
        vTmpStr = ""

        For vCtr = 1 To Len(bString)
            vChar = Mid(bString, vCtr, 1)

            Select Case vChar
                Case "|"

                Case Else
                    vTmpStr = vTmpStr & vChar
            End Select
        Next vCtr

        StripInvalidStringChars = vTmpStr
    End Function

    Public Sub RemoveSortHeaderInColumns(ByRef bListview As ListView)
        Dim vCtr As Integer

        For vCtr = 1 To bListview.Columns.Count
            With bListview.Columns(vCtr - 1)
                Select Case Left(.Text, 2)
                    Case "< "
                        .Text = Mid(.Text, 3, Len(.Text))

                    Case "> "
                        .Text = Mid(.Text, 3, Len(.Text))
                End Select
            End With
        Next vCtr
    End Sub

    Public Function EscapeChars(ByVal bString As String) As String
        Dim vCtr As Long
        Dim vChar As String
        Dim vTmpStr As String

        EscapeChars = ""
        vTmpStr = ""

        For vCtr = 1 To Len(bString)
            vChar = Mid(bString, vCtr, 1)

            Select Case vChar
                Case "'"
                    vTmpStr = vTmpStr & vChar & vChar

                Case Else
                    vTmpStr = vTmpStr & vChar
            End Select
        Next vCtr

        EscapeChars = vTmpStr
    End Function

    Public Function CorrectSqlString(ByVal bString As String) As String
        Dim vCtr As Long
        Dim vChar As String
        Dim vTmpStr As String

        CorrectSqlString = ""
        vTmpStr = ""

        For vCtr = 1 To Len(bString)
            vChar = Mid(bString, vCtr, 1)

            Select Case vChar
                Case "'"
                    vTmpStr = vTmpStr & "''"

                Case Else
                    vTmpStr = vTmpStr & vChar
            End Select
        Next vCtr

        CorrectSqlString = vTmpStr
    End Function

    Public Sub RefreshAlternateViewColors(ByRef bListview As ListView)
        Dim vCtr As Integer

        pViewBackgroundCtr = 2

        For vCtr = 1 To bListview.Items.Count
            pViewBackgroundCtr = pViewBackgroundCtr + 1
            If pViewBackgroundCtr > pViewBackgroundColorMax Then
                pViewBackgroundCtr = 1
            End If

            If bListview.Items(vCtr - 1).BackColor <> pViewBackgroundColor(pViewBackgroundCtr) Then
                bListview.Items(vCtr - 1).BackColor = pViewBackgroundColor(pViewBackgroundCtr)
            End If
        Next vCtr
    End Sub

    Public Sub CopyListViewToClipboard(ByVal bListView As ListView)
        Dim vRowCtr As Integer
        Dim vColCtr As Integer
        Dim vRows As Long
        Dim vCols As Long
        Dim vTmpStr As String
        Dim vSelected As Long

        vRows = bListView.Items.Count
        vCols = bListView.Columns.Count

        vTmpStr = ""

        If vRows > 0 Then
            vSelected = 0
            For vRowCtr = 1 To vRows
                If bListView.Items(vRowCtr - 1).Selected = True Then vSelected = vSelected + 1
            Next vRowCtr

            If vSelected = 0 Then modModule.ListViewSelectAll(bListView)

            For vColCtr = 1 To vCols
                If vColCtr = 1 Then
                    vTmpStr = vTmpStr & bListView.Columns(vColCtr - 1).Text
                Else
                    vTmpStr = vTmpStr & Chr(9) & bListView.Columns(vColCtr - 1).Text
                End If
            Next vColCtr

            vTmpStr = vTmpStr & Chr(13)

            For vRowCtr = 1 To vRows
                If bListView.Items(vRowCtr - 1).Selected = True Then
                    For vColCtr = 1 To vCols
                        If vColCtr = 1 Then
                            vTmpStr = vTmpStr & """" & bListView.Items(vRowCtr - 1).Text & """"
                        Else
                            vTmpStr = vTmpStr & Chr(9) & """" & bListView.Items(vRowCtr - 1).SubItems(vColCtr - 1).Text & """"
                        End If
                    Next vColCtr

                    vTmpStr = vTmpStr & Chr(13)
                End If
            Next vRowCtr
        End If

        Clipboard.Clear()
        Clipboard.SetText(vTmpStr)
    End Sub

    Public Function GetListViewSelected(ByVal bListView As ListView) As Long
        Dim vRowCtr As Integer

        GetListViewSelected = 0

        For vRowCtr = 1 To bListView.Items.Count
            If bListView.Items(vRowCtr - 1).Selected = True Then GetListViewSelected = GetListViewSelected + 1
        Next
    End Function

    Public Sub ListViewSelectAll(ByVal bListView As ListView)
        Dim vRowCtr As Integer
        Dim vRows As Long

        vRows = bListView.Items.Count

        If vRows > 0 Then
            For vRowCtr = 1 To vRows
                bListView.Items(vRowCtr - 1).Selected = True
            Next vRowCtr
        End If
    End Sub

    Public Function LoadTableFieldInComboBox(ByRef bComboBox As ComboBox, ByVal bField As String, ByVal bTable As String, ByVal bFilter As String, _
                                             ByVal bSortBy As String, ByRef bPrompt As Label, ByVal bClearList As Boolean) As Byte
        'declare postgres connectivity
        Dim vMyPgCon As New NpgsqlConnection
        Dim vMyPgCmd = New NpgsqlCommand
        Dim vMyPgRd As NpgsqlDataReader
        Dim vOldPromptVisible As Boolean
        Dim vOldPromptText As String
        Dim vCtr As Long = 0

        LoadTableFieldInComboBox = 0

        vOldPromptVisible = bPrompt.Visible
        vOldPromptText = bPrompt.Text

        Try
            Dim vFound As Boolean = False
            Dim vQuery As String = ""

            If bClearList = True Then
                bComboBox.Items.Clear()
            End If

            bPrompt.Text = "Please wait... opening database..."

            'open postgres connection
            vMyPgCon.ConnectionString = pConnectVox
            vMyPgCon.Open()

            bPrompt.Text = "Please wait... gathering records..."
            vQuery = "SELECT DISTINCT " & bField & " AS f_item FROM " & bTable & IIf(bFilter = "", "", " WHERE " & bFilter) & IIf(bSortBy = "", "", " ORDER BY " & bSortBy)

            'create query
            vMyPgCmd = New NpgsqlCommand(vQuery, vMyPgCon)

            'execute query
            vMyPgRd = vMyPgCmd.ExecuteReader()

            'read values
            vFound = vMyPgRd.Read

            vCtr = 0
            Do While vFound = True
                With bComboBox
                    If IsDBNull(vMyPgRd("f_item")) = False Then
                        .Items.Add(vMyPgRd("f_item"))
                    End If
                End With

                bPrompt.Text = "Please wait... " & vCtr.ToString("###,###,###,##0") & "records found"

                vFound = vMyPgRd.Read
            Loop

            bPrompt.Text = "Please wait... closing database..."

            'close connections and release
            vMyPgRd.Close()
            vMyPgCmd.Dispose()

            vMyPgCon.Close()
            vMyPgCon = Nothing

            'restore prompt original form
            bPrompt.Visible = vOldPromptVisible
            bPrompt.Text = vOldPromptText

            'return result
            LoadTableFieldInComboBox = 1

        Catch ex As Exception
            'restore prompt original form
            bPrompt.Visible = vOldPromptVisible
            bPrompt.Text = vOldPromptText

            'check if possible unhandled connections
            If IsNothing(vMyPgCon) = False Then
                If vMyPgCon.State <> ConnectionState.Closed Then
                    vMyPgCon.Close()
                    vMyPgCon = Nothing
                End If
            End If

            'return result
            LoadTableFieldInComboBox = 0
        End Try
    End Function

    Public Function CreateLog(ByVal bModule As String, ByVal bDescription As String, ByVal bRemarks As String) As String
        'declare postgres connectivity
        Dim vMyPgCon As New NpgsqlConnection
        Dim vMyPgCmd = New NpgsqlCommand

        CreateLog = ""

        Try
            Dim vFound As Boolean = False
            Dim vQuery As String = ""

            'open postgres connection

            vMyPgCon.ConnectionString = pConnectVox
            vMyPgCon.Open()

            vQuery = "INSERT INTO tb_back_office_logs (module, description, remarks, processed_by, terminal_used, terminal_serial, period) VALUES ('" & _
                           modModule.CorrectSqlString(bModule) & "', '" & modModule.CorrectSqlString(bDescription) & "', '" & _
                           modModule.CorrectSqlString(bRemarks) & "', '" & modModule.CorrectSqlString(pUserID) & "', '" & _
                           modModule.CorrectSqlString(Environ("COMPUTERNAME")) & "', '" & modModule.CorrectSqlString(pTerminalSerial) & "', " & _
                           "CURRENT_timestamp AT TIME ZONE 'Hongkong')"

            'create query
            vMyPgCmd = New NpgsqlCommand(vQuery, vMyPgCon)

            'execute query
            vMyPgCmd.ExecuteNonQuery()

            'close connections and release
            vMyPgCmd.Dispose()

            vMyPgCon.Close()
            vMyPgCon = Nothing

            'return result
            CreateLog = "1"

        Catch ex As Exception
            'check if possible unhandled connections
            If IsNothing(vMyPgCon) = False Then
                If vMyPgCon.State <> ConnectionState.Closed Then
                    vMyPgCon.Close()
                    vMyPgCon = Nothing
                End If
            End If

            'return result
            CreateLog = ex.Message
        End Try
    End Function

    Public Function CreateLogCn(ByRef bPgCon As NpgsqlConnection, ByVal bModule As String, ByVal bDescription As String, ByVal bRemarks As String) As String
        'declare postgres connectivity
        Dim vMyPgCmd = New NpgsqlCommand

        CreateLogCn = ""

        Try
            Dim vFound As Boolean = False
            Dim vQuery As String = ""

            'open postgres connection

            vQuery = "INSERT INTO tb_back_office_logs (module, description, remarks, processed_by, terminal_used, terminal_serial, period) VALUES ('" & _
                           modModule.CorrectSqlString(bModule) & "', '" & modModule.CorrectSqlString(bDescription) & "', '" & _
                           modModule.CorrectSqlString(bRemarks) & "', '" & modModule.CorrectSqlString(pUserID) & "', '" & _
                           modModule.CorrectSqlString(Environ("COMPUTERNAME")) & "', '" & modModule.CorrectSqlString(pTerminalSerial) & "', " & _
                           "CURRENT_timestamp AT TIME ZONE 'Hongkong')"

            'create query
            vMyPgCmd = New NpgsqlCommand(vQuery, bPgCon)

            'execute query
            vMyPgCmd.ExecuteNonQuery()

            'close connections and release
            vMyPgCmd.Dispose()


            'return result
            CreateLogCn = "1"

        Catch ex As Exception
            'return result
            CreateLogCn = ex.Message
        End Try
    End Function

    Public Function ValidComboBoxData(ByVal bString As String, ByVal bComboBox As ComboBox) As Boolean
        Dim vCtr As Long
        Dim vFound As Boolean

        ValidComboBoxData = False

        vFound = False
        For vCtr = 1 To bComboBox.Items.Count
            'If DirectCast(bComboBox.Items(vCtr - 1), DataRowView).Item(0) = bString Then
            If bComboBox.Items(vCtr - 1) = bString Then
                vFound = True
                Exit For
            End If
        Next vCtr

        ValidComboBoxData = vFound
    End Function

    Public Function ValidComboBoxData2(ByVal bString As String, ByVal bComboBox As ComboBox) As Boolean
        Dim vCtr As Long
        Dim vFound As Boolean

        ValidComboBoxData2 = False

        vFound = False
        For vCtr = 1 To bComboBox.Items.Count
            If DirectCast(bComboBox.Items(vCtr - 1), DataRowView).Item(0) = bString Then
                vFound = True
                Exit For
            End If
        Next vCtr

        ValidComboBoxData2 = vFound
    End Function

    Public Function BackupVoxDatabase(ByRef bPrompt As Label) As String
        Dim vProcessID As Long
        Dim vProcessHandle As Long
        Dim vTempFileName As String
        Dim vDateTime As String

        BackupVoxDatabase = ""

        Try
            bPrompt.Text = "Please wait... preparing for backup"
            bPrompt.Refresh()

            vDateTime = Format(Now, "yyyy-MM-dd HH.mm.ss")
            vTempFileName = Environ("WINDIR") & "\TEMP\(" & vDateTime & ")"

            Environment.SetEnvironmentVariable("PGPASSWORD", pPostgresPassword)

            bPrompt.Text = "Please wait... backing-up databases"
            bPrompt.Refresh()

            vProcessID = Shell(pPostgresPath & "\bin\pg_dump.exe -i -h " & pPostgresServer & " -p " & pPostgresPort & " -U postgres -F c -b -v -f """ & _
                vTempFileName & " " & pPostgresDbName & ".vox"" " & pPostgresDbName, vbNormalFocus)

            vProcessHandle = OpenProcess(SYNCHRONIZE, False, vProcessID)
            If vProcessHandle <> 0 Then
                WaitForSingleObject(vProcessHandle, INFINITE)
                CloseHandle(vProcessHandle)
            End If

            bPrompt.Text = "Please wait... finalizing files"
            bPrompt.Refresh()

            Dim location = Assembly.GetEntryAssembly().Location
            Dim appPath = Path.GetDirectoryName(location)       ' C:\Some\Directory
            Dim appName = Path.GetFileName(location)

            vProcessID = Shell(appPath & "\RAR_x64.EXE m -ep1 -p" & pPostgresPassword & " -idq """ & pBackupDir & "\" & pPostgresDbName & " database (" & vDateTime & ").vox""" & " " & _
                """" & vTempFileName & " " & pPostgresDbName & ".vox""", vbHide)

            vProcessHandle = OpenProcess(SYNCHRONIZE, False, vProcessID)
            If vProcessHandle <> 0 Then
                WaitForSingleObject(vProcessHandle, INFINITE)
                CloseHandle(vProcessHandle)
            End If

            Environment.SetEnvironmentVariable("PGPASSWORD", "")

            bPrompt.Text = "Backup operation complete."
            bPrompt.Refresh()

            BackupVoxDatabase = "ok"

        Catch ex As Exception

            BackupVoxDatabase = "error:" & ex.Message

        End Try
    End Function

    Public Function GetSystemMessages(ByRef bPrompt As Label) As String
        Dim vMyPgCon As New NpgsqlConnection
        Dim vMyPgCmd = New NpgsqlCommand
        Dim vMyPgRd As NpgsqlDataReader
        Dim vFound As Boolean

        Dim vQuery As String
        Dim vFilterStr As String

        Dim vRecs As Long = 0
        Dim vTmpMessage As String = ""
        Dim vSystemMessage As String = ""
        Dim vCurMessage As Integer = 0
        Dim vMaxMessage As Integer = 12
        Dim vLineNo As Long = 0

        Dim vOldPromptVisible As Boolean
        Dim vOldPromptText As String

        Dim vTmpStr1 As String = ""
        Dim vTmpNumber1 As Double = 0
        Dim vTmpNumber2 As Double = 0
        Dim vTmpNumber3 As Double = 0
        Dim vTmpNumber4 As Double = 0
        Dim vTmpNumber5 As Double = 0

        'default counters
        Dim vDaysStradcomBalance As Integer = 3
        Dim vDaysPetcBalance As Integer = 3
        Dim vDaysItRenewal As Integer = 60
        Dim vDaysMachineCalibration As Integer = 30

        'Dim vDaysLtoRenewal As Integer = 60     '90
        'Dim vDaysDtiRenewal As Integer = 60     '180
        'Dim vDaysTesdaRenewal As Integer = 60   '90

        Dim vDaysLtoRenewal As Integer = 90
        Dim vDaysDtiRenewal As Integer = 180
        Dim vDaysTesdaRenewal As Integer = 90

        vOldPromptVisible = bPrompt.Visible
        vOldPromptText = bPrompt.Text

        Try
            bPrompt.Text = "Please wait... checking for system warning messages..."
            bPrompt.Visible = True

            GetSystemMessages = ""
            vSystemMessage = ""

            vFilterStr = ""

            'open db connection
            vMyPgCon.ConnectionString = pConnectVox
            vMyPgCon.Open()

            'back-office:
            ' 1. check transactions pending in stradcom
            ' 2. check pending transactions not sent to LTO
            ' 3. check stradcom balance
            ' 4. check petc balance
            ' 5. check petc it contract renewal
            ' 6. check petc lto authorization renewal
            ' 7. check petc dti accreditation renewal
            ' 8. check petc business papers
            ' 9. check terminals not locked
            '10. check terminals machine calibration
            '11. check if terminal not active/inactive
            '12. check user tesda expiration

            'Message 1: check transactions pending in stradcom --------------------------------------------------------------------------------------------------------
            '            vCurMessage = vCurMessage + 1
            '            bPrompt.Text = "Please wait... checking system message " & Trim(Str(vCurMessage)) & "/" & Trim(Str(vMaxMessage)) & "..."
            '            bPrompt.Refresh()
            '
            '            vQuery = "SELECT a.plate_no, a.cec_number, a.fuel_type, a.datetime_tested, a.petc_code, b.petc_name FROM tb_petc_test AS a " & _
            '                "LEFT OUTER JOIN tb_petcs AS b ON a.petc_code = b.petc_code " & _
            '                "WHERE a.uploaded_stradcom <> 1 " & IIf(vFilterStr = "", "", "AND a.petc_code = '" & modModule.CorrectSqlString(vFilterStr) & "'") & _
            '                " ORDER BY a.petc_code, a.datetime_tested"
            '
            '            'create query
            '            vMyPgCmd = New NpgsqlCommand(vQuery, vMyPgCon)
            '
            '            'execute query
            '            vMyPgRd = vMyPgCmd.ExecuteReader()
            '
            '            'read values
            '            vFound = vMyPgRd.Read
            '
            '            vRecs = 0
            '            If vFound = False Then
            ' 'no record found
            ' Else
            ' 'get result
            '
            '            Do While vFound = True
            ' vLineNo = vLineNo + 1
            '
            '            vTmpMessage = Trim(Str(vLineNo)) & ". Pending in Stradcom. "
            '
            '            vTmpMessage = vTmpMessage & "PETC: "
            '            If IsDBNull(vMyPgRd("petc_code")) = True Then
            ' vTmpMessage = vTmpMessage & ""
            ' Else
            ' vTmpMessage = vTmpMessage & vMyPgRd("petc_code")
            ' End If
            '
            '            If IsDBNull(vMyPgRd("petc_name")) = True Then
            ' vTmpMessage = vTmpMessage & ""
            ' Else
            ' vTmpMessage = vTmpMessage & " (" & vMyPgRd("petc_name") & ")"
            ' End If
            '
            '            vTmpMessage = vTmpMessage & ", Plate no.: "
            '            If IsDBNull(vMyPgRd("plate_no")) = True Then
            ' vTmpMessage = vTmpMessage & ""
            ' Else
            ' vTmpMessage = vTmpMessage & vMyPgRd("plate_no")
            ' End If
            '
            '            vTmpMessage = vTmpMessage & ", CEC no.: "
            '            If IsDBNull(vMyPgRd("cec_number")) = True Then
            ' vTmpMessage = vTmpMessage & ""
            ' Else
            ' vTmpMessage = vTmpMessage & vMyPgRd("cec_number")
            ' End If
            '
            '            vTmpMessage = vTmpMessage & ", Fuel: "
            '            If IsDBNull(vMyPgRd("fuel_type")) = True Then
            ' vTmpMessage = vTmpMessage & ""
            ' Else
            ' vTmpMessage = vTmpMessage & vMyPgRd("fuel_type")
            ' End If
            '
            '            vTmpMessage = vTmpMessage & ", Date/Time tested: "
            '            If IsDBNull(vMyPgRd("datetime_tested")) = True Then
            ' vTmpMessage = vTmpMessage & ""
            ' Else
            ' vTmpMessage = vTmpMessage & CDate(vMyPgRd("datetime_tested")).ToString("yyyy-MM-dd HH:mm:ss")
            ' End If
            '
            '            If Trim(vSystemMessage) <> "" Then
            ' vSystemMessage = vSystemMessage & vbCrLf & vbCrLf
            ' End If
            '
            '            If Trim(vTmpMessage) <> "" Then
            ' vSystemMessage = vSystemMessage & vTmpMessage
            ' End If
            '
            '            vRecs = vRecs + 1
            '
            '            'read values
            '            vFound = vMyPgRd.Read
            '            Loop
            '            End If
            '
            '            bPrompt.Text = "Closing database..."
            '            bPrompt.Refresh()
            '
            '            'close and dispose to avoid memory leak
            '            vMyPgRd.Close()
            '            vMyPgCmd.Dispose()

            vCurMessage = vCurMessage + 1
            bPrompt.Text = "Please wait... checking system message " & Trim(Str(vCurMessage)) & "/" & Trim(Str(vMaxMessage)) & "..."
            bPrompt.Refresh()

            vQuery = "SELECT COUNT(a.recno) AS f_total, a.petc_code, b.petc_name FROM tb_petc_test AS a " & _
                "LEFT OUTER JOIN tb_petcs AS b ON a.petc_code = b.petc_code " & _
                "WHERE a.uploaded_stradcom = 0 " & _
                IIf(vFilterStr = "", "", "AND petc_code = '" & modModule.CorrectSqlString(vFilterStr) & "' ") & _
                "GROUP BY a.petc_code, b.petc_name ORDER BY b.petc_name"

            'create query
            vMyPgCmd = New NpgsqlCommand(vQuery, vMyPgCon)

            'execute query
            vMyPgRd = vMyPgCmd.ExecuteReader()

            'read values
            vFound = vMyPgRd.Read

            vRecs = 0
            If vFound = False Then
                'no record found
            Else
                'get result

                Do While vFound = True
                    If IsDBNull(vMyPgRd("f_total")) = True Then
                        vTmpMessage = ""
                    Else
                        If vMyPgRd("f_total") <> 0 Then
                            vLineNo = vLineNo + 1

                            vTmpMessage = Trim(Str(vLineNo)) & ". " & CDbl(vMyPgRd("f_total")).ToString("###,###,###,##0") & " records pending in Stradcom by PETC: "

                            If IsDBNull(vMyPgRd("petc_code")) = True Then
                                vTmpMessage = vTmpMessage & ""
                            Else
                                vTmpMessage = vTmpMessage & vMyPgRd("petc_code")
                            End If

                            If IsDBNull(vMyPgRd("petc_name")) = True Then
                                vTmpMessage = vTmpMessage & ""
                            Else
                                vTmpMessage = vTmpMessage & " (" & vMyPgRd("petc_name") & ")"
                            End If

                            If Trim(vSystemMessage) <> "" Then
                                vSystemMessage = vSystemMessage & vbCrLf & vbCrLf
                            End If

                            If Trim(vTmpMessage) <> "" Then
                                vSystemMessage = vSystemMessage & vTmpMessage
                            End If

                            vRecs = vRecs + 1
                        End If
                    End If

                    'read values
                    vFound = vMyPgRd.Read
                Loop
            End If

            bPrompt.Text = "Closing database..."
            bPrompt.Refresh()

            'close and dispose to avoid memory leak
            vMyPgRd.Close()
            vMyPgCmd.Dispose()

            'Message 2: check pending transactions not sent to LTO --------------------------------------------------------------------------------------------------------
            vCurMessage = vCurMessage + 1
            bPrompt.Text = "Please wait... checking system message " & Trim(Str(vCurMessage)) & "/" & Trim(Str(vMaxMessage)) & "..."
            bPrompt.Refresh()

            vQuery = "SELECT COUNT(recno) AS f_total FROM tb_petc_test " & _
                "WHERE uploaded_stradcom = 1 AND statuscode = '1' AND uploaded_lto <> 1 " & _
                IIf(vFilterStr = "", "", "AND petc_code = '" & modModule.CorrectSqlString(vFilterStr) & "'")

            'create query
            vMyPgCmd = New NpgsqlCommand(vQuery, vMyPgCon)

            'execute query
            vMyPgRd = vMyPgCmd.ExecuteReader()

            'read values
            vFound = vMyPgRd.Read

            vRecs = 0
            If vFound = False Then
                'no record found
            Else
                'get result

                Do While vFound = True
                    If IsDBNull(vMyPgRd("f_total")) = True Then
                        vTmpMessage = ""
                    Else
                        If vMyPgRd("f_total") <> 0 Then
                            vLineNo = vLineNo + 1

                            vTmpMessage = Trim(Str(vLineNo)) & ". Records not yet sent to LTO found. "
                            vTmpMessage = vTmpMessage & "Records: " & CDbl(vMyPgRd("f_total")).ToString("###,###,###,##0")

                            If Trim(vSystemMessage) <> "" Then
                                vSystemMessage = vSystemMessage & vbCrLf & vbCrLf
                            End If

                            If Trim(vTmpMessage) <> "" Then
                                vSystemMessage = vSystemMessage & vTmpMessage
                            End If

                            vRecs = vRecs + 1
                        End If
                    End If

                    'read values
                    vFound = vMyPgRd.Read
                Loop
            End If

            bPrompt.Text = "Closing database..."
            bPrompt.Refresh()

            'close and dispose to avoid memory leak
            vMyPgRd.Close()
            vMyPgCmd.Dispose()

            'Message 3: check stradcom balance --------------------------------------------------------------------------------------------------------
            vTmpNumber1 = 0     'stradcom balance
            vTmpNumber2 = 0     'stradcom fee
            vTmpNumber3 = 0     'number of active petcs
            vTmpNumber4 = vDaysStradcomBalance     'number of days to check

            vCurMessage = vCurMessage + 1
            bPrompt.Text = "Please wait... checking system message " & Trim(Str(vCurMessage)) & "/" & Trim(Str(vMaxMessage)) & "..."
            bPrompt.Refresh()

            'check stradcom balance amount
            vQuery = "SELECT stradcom_fee, balance FROM tb_stradcom_balance"

            'create query
            vMyPgCmd = New NpgsqlCommand(vQuery, vMyPgCon)

            'execute query
            vMyPgRd = vMyPgCmd.ExecuteReader()

            'read values
            vFound = vMyPgRd.Read

            vRecs = 0
            If vFound = False Then
                'no record found
                'stradcom balance
                vTmpNumber1 = 0
                vTmpNumber2 = 0
            Else
                'get result

                If IsDBNull(vMyPgRd("balance")) = True Then
                    'stradcom balance
                    vTmpNumber1 = 0
                Else
                    'stradcom balance
                    vTmpNumber1 = vMyPgRd("balance")
                End If

                If IsDBNull(vMyPgRd("stradcom_fee")) = True Then
                    'stradcom fee
                    vTmpNumber2 = 0
                Else
                    'stradcom fee
                    vTmpNumber2 = vMyPgRd("stradcom_fee")
                End If
            End If

            bPrompt.Text = "Closing database..."
            bPrompt.Refresh()

            'close and dispose to avoid memory leak
            vMyPgRd.Close()
            vMyPgCmd.Dispose()

            'check number of petcs active
            vQuery = "SELECT COUNT(petc_code) AS f_count FROM tb_petcs WHERE is_active = 1"

            'create query
            vMyPgCmd = New NpgsqlCommand(vQuery, vMyPgCon)

            'execute query
            vMyPgRd = vMyPgCmd.ExecuteReader()

            'read values
            vFound = vMyPgRd.Read

            vRecs = 0
            If vFound = False Then
                'no record found
                'active petcs
                vTmpNumber3 = 0
            Else
                'get result

                If IsDBNull(vMyPgRd("f_count")) = True Then
                    'active petcs
                    vTmpNumber3 = 0
                Else
                    'active petcs
                    vTmpNumber3 = vMyPgRd("f_count")
                End If
            End If

            bPrompt.Text = "Closing database..."
            bPrompt.Refresh()

            'close and dispose to avoid memory leak
            vMyPgRd.Close()
            vMyPgCmd.Dispose()

            'estimate if stradcom balance for x days based on: stradcom_fee x active_petcs x max_cap x  num_days
            'vTmpNumber1 = stradcom balance
            'vTmpNumber2 = stradcom fee
            'vTmpNumber3 = number of active petcs
            'vTmpNumber4 = number of days to check

            vTmpNumber5 = vTmpNumber2 * vTmpNumber3 * 80 * vTmpNumber4

            'if estimate is less than then report warning
            If vTmpNumber1 < vTmpNumber5 Then
                vLineNo = vLineNo + 1

                vTmpMessage = Trim(Str(vLineNo)) & ". Stradcom balance check. Stradcom balance is " & vTmpNumber1.ToString("###,###,###,##0.00") & _
                    " and target balance should be atleast " & vTmpNumber5.ToString("###,###,###,##0.00")

                If Trim(vSystemMessage) <> "" Then
                    vSystemMessage = vSystemMessage & vbCrLf & vbCrLf
                End If

                If Trim(vTmpMessage) <> "" Then
                    vSystemMessage = vSystemMessage & vTmpMessage
                End If
            End If

            'Message 4: check petc balance --------------------------------------------------------------------------------------------------------
            vTmpNumber1 = vDaysPetcBalance     'number of days to check

            vCurMessage = vCurMessage + 1
            bPrompt.Text = "Please wait... checking system message " & Trim(Str(vCurMessage)) & "/" & Trim(Str(vMaxMessage)) & "..."
            bPrompt.Refresh()

            'check petc balance below desired balance of max cap x num of days
            vQuery = "SELECT a.petc_code, b.petc_name, a.transmission_fee, a.balance, a.max_credit, a.account_type FROM tb_petc_balance AS a " & _
                "LEFT OUTER JOIN tb_petcs AS b ON a.petc_code = b.petc_code " & _
                "WHERE (((a.balance <= (80 * " & Trim(Str(vTmpNumber1)) & " * a.transmission_fee)) AND a.account_type = 2) OR " & _
                "(((a.max_credit * -1) <= (80 * " & Trim(Str(vTmpNumber1)) & " * a.transmission_fee)) AND a.account_type = 1)) AND " & _
                "b.is_active = 1 " & IIf(vFilterStr = "", "", "AND " & vFilterStr) & " ORDER BY b.petc_name"

            'create query
            vMyPgCmd = New NpgsqlCommand(vQuery, vMyPgCon)

            'execute query
            vMyPgRd = vMyPgCmd.ExecuteReader()

            'read values
            vFound = vMyPgRd.Read

            vRecs = 0
            If vFound = False Then
                'no record found
            Else
                'get result

                Do While vFound = True
                    vLineNo = vLineNo + 1

                    vTmpMessage = Trim(Str(vLineNo)) & ". PETC credit balance check. "

                    vTmpMessage = vTmpMessage & "PETC: "
                    If IsDBNull(vMyPgRd("petc_code")) = True Then
                        vTmpMessage = vTmpMessage & ""
                    Else
                        vTmpMessage = vTmpMessage & vMyPgRd("petc_code")
                    End If

                    If IsDBNull(vMyPgRd("petc_name")) = True Then
                        vTmpMessage = vTmpMessage & ""
                    Else
                        vTmpMessage = vTmpMessage & " (" & vMyPgRd("petc_name") & ")"
                    End If

                    vTmpMessage = vTmpMessage & ", Transmission fee: "
                    If IsDBNull(vMyPgRd("transmission_fee")) = True Then
                        vTmpMessage = vTmpMessage & "0.00"
                    Else
                        vTmpMessage = vTmpMessage & CDbl(vMyPgRd("transmission_fee")).ToString("###,###,###,##0.00")
                    End If

                    vTmpMessage = vTmpMessage & ", Type: "
                    If IsDBNull(vMyPgRd("account_type")) = True Then
                        vTmpMessage = vTmpMessage & "Unknown"
                    Else
                        Select Case vMyPgRd("account_type")
                            Case 1      'post-paid
                                vTmpMessage = vTmpMessage & "Post-paid"

                            Case 2      'pre-paid
                                vTmpMessage = vTmpMessage & "Pre-paid"

                            Case Else
                                vTmpMessage = vTmpMessage & "Unknown"
                        End Select
                    End If

                    vTmpMessage = vTmpMessage & ", Balance: "
                    If IsDBNull(vMyPgRd("balance")) = True Then
                        vTmpMessage = vTmpMessage & "0.00"
                    Else
                        vTmpMessage = vTmpMessage & CDbl(vMyPgRd("balance")).ToString("###,###,###,##0.00")
                    End If

                    vTmpMessage = vTmpMessage & ", Max credit: "
                    If IsDBNull(vMyPgRd("max_credit")) = True Then
                        vTmpMessage = vTmpMessage & "0.00"
                    Else
                        vTmpMessage = vTmpMessage & CDbl(vMyPgRd("max_credit")).ToString("###,###,###,##0.00")
                    End If

                    If Trim(vSystemMessage) <> "" Then
                        vSystemMessage = vSystemMessage & vbCrLf & vbCrLf
                    End If

                    If Trim(vTmpMessage) <> "" Then
                        vSystemMessage = vSystemMessage & vTmpMessage
                    End If

                    vRecs = vRecs + 1

                    'read values
                    vFound = vMyPgRd.Read
                Loop
            End If

            bPrompt.Text = "Closing database..."
            bPrompt.Refresh()

            'close and dispose to avoid memory leak
            vMyPgRd.Close()
            vMyPgCmd.Dispose()

            'Message 5: check petc it contact renewal date --------------------------------------------------------------------------------------------------------
            vCurMessage = vCurMessage + 1
            bPrompt.Text = "Please wait... checking system message " & Trim(Str(vCurMessage)) & "/" & Trim(Str(vMaxMessage)) & "..."
            bPrompt.Refresh()

            '            vQuery = "SELECT date_it_renewal, petc_code, petc_name FROM tb_petcs " & _
            '                "WHERE date_it_renewal <= '" & CDate(DateTime.Now).AddDays(vDaysItRenewal).ToString("yyyy-MM-dd") & "' AND is_active = 1 " & _
            '                IIf(vFilterStr = "", "", "AND " & vFilterStr) & " ORDER BY date_it_renewal ASC, petc_name"

            vQuery = "SELECT date_it_renewal, petc_code, petc_name FROM tb_petcs " & _
                "WHERE (date_it_renewal) - INTERVAL '" & Trim(Str(vDaysItRenewal)) & " days' <= '" & _
                    CDate(DateTime.Now).ToString("yyyy-MM-dd") & "' AND is_active = 1 " & _
                IIf(vFilterStr = "", "", "AND " & vFilterStr) & " ORDER BY date_it_renewal ASC, petc_name"

            'create query
            vMyPgCmd = New NpgsqlCommand(vQuery, vMyPgCon)

            'execute query
            vMyPgRd = vMyPgCmd.ExecuteReader()

            'read values
            vFound = vMyPgRd.Read

            vRecs = 0
            If vFound = False Then
                'no record found
            Else
                'get result

                Do While vFound = True
                    vLineNo = vLineNo + 1

                    Dim vExpired As Boolean

                    If IsDBNull(vMyPgRd("date_it_renewal")) = True Then
                        vTmpMessage = Trim(Str(vLineNo)) & ". No or invalid IT contact renewal date. "
                        vExpired = False
                    Else
                        If CDate(vMyPgRd("date_it_renewal")) < CDate(DateTime.Now) Then
                            vTmpMessage = Trim(Str(vLineNo)) & ". IT contact renewal date already lapsed! "
                            vExpired = True
                        Else
                            vTmpMessage = Trim(Str(vLineNo)) & ". IT contact renewal date is near. "
                            vExpired = False
                        End If
                    End If

                    vTmpMessage = vTmpMessage & "PETC: "
                    If IsDBNull(vMyPgRd("petc_code")) = True Then
                        vTmpMessage = vTmpMessage & ""
                    Else
                        vTmpMessage = vTmpMessage & vMyPgRd("petc_code")
                    End If

                    If IsDBNull(vMyPgRd("petc_name")) = True Then
                        vTmpMessage = vTmpMessage & ""
                    Else
                        vTmpMessage = vTmpMessage & " (" & vMyPgRd("petc_name") & ")"
                    End If

                    vTmpMessage = vTmpMessage & ", Renewal expiration date: "
                    If IsDBNull(vMyPgRd("date_it_renewal")) = True Then
                        vTmpMessage = vTmpMessage & "Unknown"
                    Else
                        vTmpMessage = vTmpMessage & CDate(vMyPgRd("date_it_renewal")).ToString("MM/dd/yyyy")
                    End If

                    vTmpMessage = vTmpMessage & ", Days before expiration: "
                    If IsDBNull(vMyPgRd("date_it_renewal")) = True Then
                        vTmpMessage = vTmpMessage & "Unknown"
                    Else
                        vTmpMessage = vTmpMessage & CDate(vMyPgRd("date_it_renewal")).Subtract(DateTime.Now).TotalDays.ToString("###,###,###,##0.00")
                    End If

                    If Trim(vSystemMessage) <> "" Then
                        vSystemMessage = vSystemMessage & vbCrLf & vbCrLf
                    End If

                    If Trim(vTmpMessage) <> "" Then
                        vSystemMessage = vSystemMessage & vTmpMessage
                    End If

                    vRecs = vRecs + 1

                    'read values
                    vFound = vMyPgRd.Read
                Loop
            End If

            bPrompt.Text = "Closing database..."
            bPrompt.Refresh()

            'close and dispose to avoid memory leak
            vMyPgRd.Close()
            vMyPgCmd.Dispose()

            'Message 6: check petc lto authorization renewal --------------------------------------------------------------------------------------------------------
            vCurMessage = vCurMessage + 1
            bPrompt.Text = "Please wait... checking system message " & Trim(Str(vCurMessage)) & "/" & Trim(Str(vMaxMessage)) & "..."
            bPrompt.Refresh()

            '            vQuery = "SELECT date_petc_authorized, petc_code, petc_name FROM tb_petcs " & _
            '                "WHERE (date_petc_authorized + INTERVAL '1 year') - INTERVAL '" & Trim(Str(vDaysLtoRenewal)) & " days' <= '" & _
            '                    CDate(DateTime.Now).ToString("yyyy-MM-dd") & "' AND is_active = 1 " & _
            '                    IIf(vFilterStr = "", "", "AND " & vFilterStr) & " ORDER BY date_petc_authorized ASC, petc_name"

            vQuery = "SELECT date_petc_authorized, petc_code, petc_name FROM tb_petcs " & _
                "WHERE (date_petc_authorized) - INTERVAL '" & Trim(Str(vDaysLtoRenewal)) & " days' <= '" & _
                    CDate(DateTime.Now).ToString("yyyy-MM-dd") & "' AND is_active = 1 " & _
                    IIf(vFilterStr = "", "", "AND " & vFilterStr) & " ORDER BY date_petc_authorized ASC, petc_name"

            'create query
            vMyPgCmd = New NpgsqlCommand(vQuery, vMyPgCon)

            'execute query
            vMyPgRd = vMyPgCmd.ExecuteReader()

            'read values
            vFound = vMyPgRd.Read

            vRecs = 0
            If vFound = False Then
                'no record found
            Else
                'get result

                Do While vFound = True
                    vLineNo = vLineNo + 1

                    Dim vExpired As Boolean

                    If IsDBNull(vMyPgRd("date_petc_authorized")) = True Then
                        vTmpMessage = Trim(Str(vLineNo)) & ". No or invalid PETC LTO authorization date. "
                        vExpired = False
                    Else
                        If CDate(vMyPgRd("date_petc_authorized")) < CDate(DateTime.Now) Then
                            vTmpMessage = Trim(Str(vLineNo)) & ". PETC LTO authorization date already lapsed! "
                            vExpired = True
                        Else
                            vTmpMessage = Trim(Str(vLineNo)) & ". PETC LTO authorization renewal date is near. "
                            vExpired = False
                        End If
                    End If

                    vTmpMessage = vTmpMessage & "PETC: "
                    If IsDBNull(vMyPgRd("petc_code")) = True Then
                        vTmpMessage = vTmpMessage & ""
                    Else
                        vTmpMessage = vTmpMessage & vMyPgRd("petc_code")
                    End If

                    If IsDBNull(vMyPgRd("petc_name")) = True Then
                        vTmpMessage = vTmpMessage & ""
                    Else
                        vTmpMessage = vTmpMessage & " (" & vMyPgRd("petc_name") & ")"
                    End If

                    vTmpMessage = vTmpMessage & ", Renewal expiration date: "
                    If IsDBNull(vMyPgRd("date_petc_authorized")) = True Then
                        vTmpMessage = vTmpMessage & "Unknown"
                    Else
                        vTmpMessage = vTmpMessage & CDate(vMyPgRd("date_petc_authorized")).ToString("MM/dd/yyyy")
                    End If

                    vTmpMessage = vTmpMessage & ", Days before expiration: "
                    If IsDBNull(vMyPgRd("date_petc_authorized")) = True Then
                        vTmpMessage = vTmpMessage & "Unknown"
                    Else
                        vTmpMessage = vTmpMessage & CDate(vMyPgRd("date_petc_authorized")).Subtract(DateTime.Now).TotalDays.ToString("###,###,###,##0.00")
                    End If

                    If Trim(vSystemMessage) <> "" Then
                        vSystemMessage = vSystemMessage & vbCrLf & vbCrLf
                    End If

                    If Trim(vTmpMessage) <> "" Then
                        vSystemMessage = vSystemMessage & vTmpMessage
                    End If

                    vRecs = vRecs + 1

                    'read values
                    vFound = vMyPgRd.Read
                Loop
            End If

            bPrompt.Text = "Closing database..."
            bPrompt.Refresh()

            'close and dispose to avoid memory leak
            vMyPgRd.Close()
            vMyPgCmd.Dispose()

            'Message 7: check petc dti accreditation renewal --------------------------------------------------------------------------------------------------------
            vCurMessage = vCurMessage + 1
            bPrompt.Text = "Please wait... checking system message " & Trim(Str(vCurMessage)) & "/" & Trim(Str(vMaxMessage)) & "..."
            bPrompt.Refresh()

            '            vQuery = "SELECT date_petc_accredited, petc_code, petc_name FROM tb_petcs " & _
            '                "WHERE (date_petc_accredited + INTERVAL '3 years') - INTERVAL '" & Trim(Str(vDaysDtiRenewal)) & " days' <= '" & _
            '                    CDate(DateTime.Now).ToString("yyyy-MM-dd") & "' AND is_active = 1 " & _
            '                    IIf(vFilterStr = "", "", "AND " & vFilterStr) & " ORDER BY date_petc_accredited ASC, petc_name"

            vQuery = "SELECT date_petc_accredited, petc_code, petc_name FROM tb_petcs " & _
                "WHERE (date_petc_accredited) - INTERVAL '" & Trim(Str(vDaysDtiRenewal)) & " days' <= '" & _
                    CDate(DateTime.Now).ToString("yyyy-MM-dd") & "' AND is_active = 1 " & _
                    IIf(vFilterStr = "", "", "AND " & vFilterStr) & " ORDER BY date_petc_accredited ASC, petc_name"

            'create query
            vMyPgCmd = New NpgsqlCommand(vQuery, vMyPgCon)

            'execute query
            vMyPgRd = vMyPgCmd.ExecuteReader()

            'read values
            vFound = vMyPgRd.Read

            vRecs = 0
            If vFound = False Then
                'no record found
            Else
                'get result

                Do While vFound = True
                    vLineNo = vLineNo + 1

                    Dim vExpired As Boolean

                    If IsDBNull(vMyPgRd("date_petc_accredited")) = True Then
                        vTmpMessage = Trim(Str(vLineNo)) & ". No or invalid PETC DTI accreditation date. "
                        vExpired = False
                    Else
                        If CDate(vMyPgRd("date_petc_accredited")) < CDate(DateTime.Now) Then
                            vTmpMessage = Trim(Str(vLineNo)) & ". PETC DTI accreditation date already lapsed! "
                            vExpired = True
                        Else
                            vTmpMessage = Trim(Str(vLineNo)) & ". PETC DTI accreditation renewal date is near. "
                            vExpired = False
                        End If
                    End If

                    vTmpMessage = vTmpMessage & "PETC: "
                    If IsDBNull(vMyPgRd("petc_code")) = True Then
                        vTmpMessage = vTmpMessage & ""
                    Else
                        vTmpMessage = vTmpMessage & vMyPgRd("petc_code")
                    End If

                    If IsDBNull(vMyPgRd("petc_name")) = True Then
                        vTmpMessage = vTmpMessage & ""
                    Else
                        vTmpMessage = vTmpMessage & " (" & vMyPgRd("petc_name") & ")"
                    End If

                    vTmpMessage = vTmpMessage & ", Renewal expiration date: "
                    If IsDBNull(vMyPgRd("date_petc_accredited")) = True Then
                        vTmpMessage = vTmpMessage & "Unknown"
                    Else
                        vTmpMessage = vTmpMessage & CDate(vMyPgRd("date_petc_accredited")).ToString("MM/dd/yyyy")
                    End If

                    vTmpMessage = vTmpMessage & ", Days before expiration: "
                    If IsDBNull(vMyPgRd("date_petc_accredited")) = True Then
                        vTmpMessage = vTmpMessage & "Unknown"
                    Else
                        vTmpMessage = vTmpMessage & CDate(vMyPgRd("date_petc_accredited")).Subtract(DateTime.Now).TotalDays.ToString("###,###,###,##0.00")
                    End If

                    If Trim(vSystemMessage) <> "" Then
                        vSystemMessage = vSystemMessage & vbCrLf & vbCrLf
                    End If

                    If Trim(vTmpMessage) <> "" Then
                        vSystemMessage = vSystemMessage & vTmpMessage
                    End If

                    vRecs = vRecs + 1

                    'read values
                    vFound = vMyPgRd.Read
                Loop
            End If

            bPrompt.Text = "Closing database..."
            bPrompt.Refresh()

            'close and dispose to avoid memory leak
            vMyPgRd.Close()
            vMyPgCmd.Dispose()

            'Message 8: check business papers --------------------------------------------------------------------------------------------------------
            vCurMessage = vCurMessage + 1
            bPrompt.Text = "Please wait... checking system message " & Trim(Str(vCurMessage)) & "/" & Trim(Str(vMaxMessage)) & "..."
            bPrompt.Refresh()

            If CDate(DateTime.Now) >= CDate(Trim(Str(CDate(DateTime.Now).Year)) & "-01-01") And CDate(DateTime.Now) <= CDate(Trim(Str(CDate(DateTime.Now).Year)) & "-01-31") Then
                vLineNo = vLineNo + 1

                vTmpMessage = Trim(Str(vLineNo)) & ". Reminder! This month is the scheduled renewal of Mayors Permit and other yearly documents required by government " & _
                    "depending on your business classification."

                If Trim(vSystemMessage) <> "" Then
                    vSystemMessage = vSystemMessage & vbCrLf & vbCrLf
                End If

                If Trim(vTmpMessage) <> "" Then
                    vSystemMessage = vSystemMessage & vTmpMessage
                End If
            End If

            'Message 9: check terminals not locked --------------------------------------------------------------------------------------------------------
            vCurMessage = vCurMessage + 1
            bPrompt.Text = "Please wait... checking system message " & Trim(Str(vCurMessage)) & "/" & Trim(Str(vMaxMessage)) & "..."
            bPrompt.Refresh()

            vQuery = "SELECT a.terminal_id, a.terminal_type, a.petc_code, b.petc_name FROM tb_stations AS a " & _
                "LEFT OUTER JOIN tb_petcs AS b ON a.petc_code = b.petc_code " & _
                "WHERE LOWER(a.terminal_type) <> 'any' AND a.is_active <> 0 AND a.lock_status <> 1 " & _
                IIf(vFilterStr = "", "", "AND " & vFilterStr) & " ORDER BY b.petc_name"

            'create query
            vMyPgCmd = New NpgsqlCommand(vQuery, vMyPgCon)

            'execute query
            vMyPgRd = vMyPgCmd.ExecuteReader()

            'read values
            vFound = vMyPgRd.Read

            vRecs = 0
            If vFound = False Then
                'no record found
            Else
                'get result

                Do While vFound = True
                    vLineNo = vLineNo + 1

                    vTmpMessage = Trim(Str(vLineNo)) & ". Terminal un-locked! "

                    vTmpMessage = vTmpMessage & "PETC: "
                    If IsDBNull(vMyPgRd("petc_code")) = True Then
                        vTmpMessage = vTmpMessage & ""
                    Else
                        vTmpMessage = vTmpMessage & vMyPgRd("petc_code")
                    End If

                    If IsDBNull(vMyPgRd("petc_name")) = True Then
                        vTmpMessage = vTmpMessage & ""
                    Else
                        vTmpMessage = vTmpMessage & " (" & vMyPgRd("petc_name") & ")"
                    End If

                    vTmpMessage = vTmpMessage & ", Terminal ID: "
                    If IsDBNull(vMyPgRd("terminal_id")) = True Then
                        vTmpMessage = vTmpMessage & ""
                    Else
                        vTmpMessage = vTmpMessage & vMyPgRd("terminal_id")
                    End If

                    vTmpMessage = vTmpMessage & ", Type: "
                    If IsDBNull(vMyPgRd("terminal_type")) = True Then
                        vTmpMessage = vTmpMessage & ""
                    Else
                        vTmpMessage = vTmpMessage & vMyPgRd("terminal_type")
                    End If

                    If Trim(vSystemMessage) <> "" Then
                        vSystemMessage = vSystemMessage & vbCrLf & vbCrLf
                    End If

                    If Trim(vTmpMessage) <> "" Then
                        vSystemMessage = vSystemMessage & vTmpMessage
                    End If

                    vRecs = vRecs + 1

                    'read values
                    vFound = vMyPgRd.Read
                Loop
            End If

            bPrompt.Text = "Closing database..."
            bPrompt.Refresh()

            'close and dispose to avoid memory leak
            vMyPgRd.Close()
            vMyPgCmd.Dispose()

            'Message 10: check terminals machine calibration --------------------------------------------------------------------------------------------------------
            vCurMessage = vCurMessage + 1
            bPrompt.Text = "Please wait... checking system message " & Trim(Str(vCurMessage)) & "/" & Trim(Str(vMaxMessage)) & "..."
            bPrompt.Refresh()

            '            vQuery = "SELECT a.terminal_id, a.terminal_type, a.terminal_machine_description, a.terminal_machine_serial, " & _
            '                "a.terminal_machine_calibrated, a.petc_code, b.petc_name FROM tb_stations AS a " & _
            '                "LEFT OUTER JOIN tb_petcs AS b ON a.petc_code = b.petc_code " & _
            '                "WHERE (a.terminal_machine_calibrated + INTERVAL '6 months') - INTERVAL '" & Trim(Str(vDaysMachineCalibration)) & " days' <= '" & _
            '                    CDate(DateTime.Now).ToString("yyyy-MM-dd") & "' AND a.is_active = 1 " & _
            '                    IIf(vFilterStr = "", "", "AND " & vFilterStr) & " ORDER BY a.terminal_machine_calibrated ASC, b.petc_name"

            vQuery = "SELECT a.terminal_id, a.terminal_type, a.terminal_machine_description, a.terminal_machine_serial, " & _
                "a.terminal_machine_calibrated, a.petc_code, b.petc_name FROM tb_stations AS a " & _
                "LEFT OUTER JOIN tb_petcs AS b ON a.petc_code = b.petc_code " & _
                "WHERE (a.terminal_machine_calibrated) - INTERVAL '" & Trim(Str(vDaysMachineCalibration)) & " days' <= '" & _
                    CDate(DateTime.Now).ToString("yyyy-MM-dd") & "' AND a.is_active = 1 " & _
                    IIf(vFilterStr = "", "", "AND " & vFilterStr) & " ORDER BY a.terminal_machine_calibrated ASC, b.petc_name"

            'create query
            vMyPgCmd = New NpgsqlCommand(vQuery, vMyPgCon)

            'execute query
            vMyPgRd = vMyPgCmd.ExecuteReader()

            'read values
            vFound = vMyPgRd.Read

            vRecs = 0
            If vFound = False Then
                'no record found
            Else
                'get result

                Do While vFound = True
                    vLineNo = vLineNo + 1

                    Dim vExpired As Boolean

                    If IsDBNull(vMyPgRd("terminal_machine_calibrated")) = True Then
                        vTmpMessage = Trim(Str(vLineNo)) & ". No or invalid Machine calibration date. "
                        vExpired = False
                    Else
                        If CDate(vMyPgRd("terminal_machine_calibrated")) < CDate(DateTime.Now) Then
                            vTmpMessage = Trim(Str(vLineNo)) & ". Machine calibration date already lapsed! "
                            vExpired = True
                        Else
                            vTmpMessage = Trim(Str(vLineNo)) & ". Machine calibration date is near. "
                            vExpired = False
                        End If
                    End If

                    vTmpMessage = vTmpMessage & "PETC: "
                    If IsDBNull(vMyPgRd("petc_code")) = True Then
                        vTmpMessage = vTmpMessage & ""
                    Else
                        vTmpMessage = vTmpMessage & vMyPgRd("petc_code")
                    End If

                    If IsDBNull(vMyPgRd("petc_name")) = True Then
                        vTmpMessage = vTmpMessage & ""
                    Else
                        vTmpMessage = vTmpMessage & " (" & vMyPgRd("petc_name") & ")"
                    End If

                    vTmpMessage = vTmpMessage & ", Terminal ID: "
                    If IsDBNull(vMyPgRd("terminal_id")) = True Then
                        vTmpMessage = vTmpMessage & ""
                    Else
                        vTmpMessage = vTmpMessage & vMyPgRd("terminal_id")
                    End If

                    vTmpMessage = vTmpMessage & ", Type: "
                    If IsDBNull(vMyPgRd("terminal_type")) = True Then
                        vTmpMessage = vTmpMessage & ""
                    Else
                        vTmpMessage = vTmpMessage & vMyPgRd("terminal_type")
                    End If

                    vTmpMessage = vTmpMessage & ", Machine: "
                    If IsDBNull(vMyPgRd("terminal_machine_description")) = True Then
                        vTmpMessage = vTmpMessage & ""
                    Else
                        vTmpMessage = vTmpMessage & vMyPgRd("terminal_machine_description")
                    End If

                    vTmpMessage = vTmpMessage & ", Serial: "
                    If IsDBNull(vMyPgRd("terminal_machine_serial")) = True Then
                        vTmpMessage = vTmpMessage & ""
                    Else
                        vTmpMessage = vTmpMessage & vMyPgRd("terminal_machine_serial")
                    End If

                    vTmpMessage = vTmpMessage & ", Calibration expiration date: "
                    If IsDBNull(vMyPgRd("terminal_machine_calibrated")) = True Then
                        vTmpMessage = vTmpMessage & "Unknown"
                    Else
                        vTmpMessage = vTmpMessage & CDate(vMyPgRd("terminal_machine_calibrated")).ToString("MM/dd/yyyy")
                    End If

                    vTmpMessage = vTmpMessage & ", Days before expiration: "
                    If IsDBNull(vMyPgRd("terminal_machine_calibrated")) = True Then
                        vTmpMessage = vTmpMessage & "Unknown"
                    Else
                        vTmpMessage = vTmpMessage & CDate(vMyPgRd("terminal_machine_calibrated")).Subtract(DateTime.Now).TotalDays.ToString("###,###,###,##0.00")
                    End If

                    If Trim(vSystemMessage) <> "" Then
                        vSystemMessage = vSystemMessage & vbCrLf & vbCrLf
                    End If

                    If Trim(vTmpMessage) <> "" Then
                        vSystemMessage = vSystemMessage & vTmpMessage
                    End If

                    vRecs = vRecs + 1

                    'read values
                    vFound = vMyPgRd.Read
                Loop
            End If

            bPrompt.Text = "Closing database..."
            bPrompt.Refresh()

            'close and dispose to avoid memory leak
            vMyPgRd.Close()
            vMyPgCmd.Dispose()

            'Message 11: check if terminal not active/inactive --------------------------------------------------------------------------------------------------------
            vCurMessage = vCurMessage + 1
            bPrompt.Text = "Please wait... checking system message " & Trim(Str(vCurMessage)) & "/" & Trim(Str(vMaxMessage)) & "..."
            bPrompt.Refresh()

            vQuery = "SELECT a.terminal_id, a.terminal_type, a.petc_code, b.petc_name FROM tb_stations AS a " & _
                "LEFT OUTER JOIN tb_petcs AS b ON a.petc_code = b.petc_code " & _
                "WHERE a.is_active <> 0 AND a.is_active <> 1 " & _
                    IIf(vFilterStr = "", "", "AND " & vFilterStr) & " ORDER BY b.petc_name"

            'create query
            vMyPgCmd = New NpgsqlCommand(vQuery, vMyPgCon)

            'execute query
            vMyPgRd = vMyPgCmd.ExecuteReader()

            'read values
            vFound = vMyPgRd.Read

            vRecs = 0
            If vFound = False Then
                'no record found
            Else
                'get result

                Do While vFound = True
                    vLineNo = vLineNo + 1

                    vTmpMessage = Trim(Str(vLineNo)) & ". Terminal is neither active or inactive. "

                    vTmpMessage = vTmpMessage & "PETC: "
                    If IsDBNull(vMyPgRd("petc_code")) = True Then
                        vTmpMessage = vTmpMessage & ""
                    Else
                        vTmpMessage = vTmpMessage & vMyPgRd("petc_code")
                    End If

                    If IsDBNull(vMyPgRd("petc_name")) = True Then
                        vTmpMessage = vTmpMessage & ""
                    Else
                        vTmpMessage = vTmpMessage & " (" & vMyPgRd("petc_name") & ")"
                    End If

                    vTmpMessage = vTmpMessage & ", Terminal ID: "
                    If IsDBNull(vMyPgRd("terminal_id")) = True Then
                        vTmpMessage = vTmpMessage & ""
                    Else
                        vTmpMessage = vTmpMessage & vMyPgRd("terminal_id")
                    End If

                    vTmpMessage = vTmpMessage & ", Type: "
                    If IsDBNull(vMyPgRd("terminal_type")) = True Then
                        vTmpMessage = vTmpMessage & ""
                    Else
                        vTmpMessage = vTmpMessage & vMyPgRd("terminal_type")
                    End If

                    If Trim(vSystemMessage) <> "" Then
                        vSystemMessage = vSystemMessage & vbCrLf & vbCrLf
                    End If

                    If Trim(vTmpMessage) <> "" Then
                        vSystemMessage = vSystemMessage & vTmpMessage
                    End If

                    vRecs = vRecs + 1

                    'read values
                    vFound = vMyPgRd.Read
                Loop
            End If

            bPrompt.Text = "Closing database..."
            bPrompt.Refresh()

            'close and dispose to avoid memory leak
            vMyPgRd.Close()
            vMyPgCmd.Dispose()

            'Message 12: check user tesda expiration --------------------------------------------------------------------------------------------------------
            vCurMessage = vCurMessage + 1
            bPrompt.Text = "Please wait... checking system message " & Trim(Str(vCurMessage)) & "/" & Trim(Str(vMaxMessage)) & "..."
            bPrompt.Refresh()

            vQuery = "SELECT a.first_name, a.middle_name, a.last_name, a.petc_code, b.petc_name, " & _
                "a.certificate_tesda, a.certificate_tesda_expiration FROM tb_users AS a " & _
                "LEFT OUTER JOIN tb_petcs AS b ON a.petc_code = b.petc_code " & _
                "WHERE (a.certificate_tesda_expiration) - INTERVAL '" & Trim(Str(vDaysTesdaRenewal)) & " days' <= '" & _
                    CDate(DateTime.Now).ToString("yyyy-MM-dd") & "' AND a.is_active = 1 AND LOWER(a.user_type) = 'petc_technician' " & _
                    IIf(vFilterStr = "", "", "AND " & vFilterStr) & " ORDER BY a.certificate_tesda_expiration ASC, b.petc_name"

            'create query
            vMyPgCmd = New NpgsqlCommand(vQuery, vMyPgCon)

            'execute query
            vMyPgRd = vMyPgCmd.ExecuteReader()

            'read values
            vFound = vMyPgRd.Read

            vRecs = 0
            If vFound = False Then
                'no record found
            Else
                'get result

                Do While vFound = True
                    vLineNo = vLineNo + 1

                    Dim vExpired As Boolean

                    If IsDBNull(vMyPgRd("certificate_tesda_expiration")) = True Then
                        vTmpMessage = Trim(Str(vLineNo)) & ". No or invalid technician TESDA expiration date. "
                        vExpired = False
                    Else
                        If CDate(vMyPgRd("certificate_tesda_expiration")) < CDate(DateTime.Now) Then
                            vTmpMessage = Trim(Str(vLineNo)) & ". Technician TESDA expiration already lapsed! "
                            vExpired = True
                        Else
                            vTmpMessage = Trim(Str(vLineNo)) & ". Technician TESDA expiration date is near. "
                            vExpired = False
                        End If
                    End If

                    vTmpMessage = vTmpMessage & "PETC: "
                    If IsDBNull(vMyPgRd("petc_code")) = True Then
                        vTmpMessage = vTmpMessage & ""
                    Else
                        vTmpMessage = vTmpMessage & vMyPgRd("petc_code")
                    End If

                    If IsDBNull(vMyPgRd("petc_name")) = True Then
                        vTmpMessage = vTmpMessage & ""
                    Else
                        vTmpMessage = vTmpMessage & " (" & vMyPgRd("petc_name") & ")"
                    End If

                    vTmpMessage = vTmpMessage & ", Name: "
                    If IsDBNull(vMyPgRd("first_name")) = True Then
                        vTmpMessage = vTmpMessage & ""
                    Else
                        vTmpMessage = vTmpMessage & vMyPgRd("first_name")
                    End If

                    If IsDBNull(vMyPgRd("middle_name")) = True Then
                        vTmpMessage = vTmpMessage & ""
                    Else
                        vTmpMessage = vTmpMessage & " " & vMyPgRd("middle_name")
                    End If

                    If IsDBNull(vMyPgRd("last_name")) = True Then
                        vTmpMessage = vTmpMessage & ""
                    Else
                        vTmpMessage = vTmpMessage & " " & vMyPgRd("last_name")
                    End If

                    vTmpMessage = vTmpMessage & ", TESDA No.: "
                    If IsDBNull(vMyPgRd("certificate_tesda")) = True Then
                        vTmpMessage = vTmpMessage & ""
                    Else
                        vTmpMessage = vTmpMessage & vMyPgRd("certificate_tesda")
                    End If

                    vTmpMessage = vTmpMessage & ", Expiration: "
                    If IsDBNull(vMyPgRd("certificate_tesda_expiration")) = True Then
                        vTmpMessage = vTmpMessage & "Unknown"
                    Else
                        vTmpMessage = vTmpMessage & CDate(vMyPgRd("certificate_tesda_expiration")).ToString("MM/dd/yyyy")
                    End If

                    vTmpMessage = vTmpMessage & ", Days before expiration: "
                    If IsDBNull(vMyPgRd("certificate_tesda_expiration")) = True Then
                        vTmpMessage = vTmpMessage & "Unknown"
                    Else
                        vTmpMessage = vTmpMessage & CDate(vMyPgRd("certificate_tesda_expiration")).Subtract(DateTime.Now).TotalDays.ToString("###,###,###,##0.00")
                    End If

                    If Trim(vSystemMessage) <> "" Then
                        vSystemMessage = vSystemMessage & vbCrLf & vbCrLf
                    End If

                    If Trim(vTmpMessage) <> "" Then
                        vSystemMessage = vSystemMessage & vTmpMessage
                    End If

                    vRecs = vRecs + 1

                    'read values
                    vFound = vMyPgRd.Read
                Loop
            End If

            bPrompt.Text = "Closing database..."
            bPrompt.Refresh()

            'close and dispose to avoid memory leak
            vMyPgRd.Close()
            vMyPgCmd.Dispose()


            'petc:
            ' 1. check transactions pending in stradcom
            ' 2. check petc balance
            ' 3. check petc it contract renewal
            ' 4. check petc lto authorization renewal
            ' 5. check petc dti accreditation renewal
            ' 6. check petc business papers
            ' 7. check terminals machine calibration
            ' 8. check user tesda expiration

            'close and dispose connection ----------------------------------------------------------------------------------------------------------------------

            vMyPgCon.Close()
            vMyPgCon = Nothing

            'revert to old visible settings of prompt control
            bPrompt.Visible = vOldPromptVisible
            bPrompt.Text = vOldPromptText

            'return values
            GetSystemMessages = vSystemMessage

        Catch ex As Exception
            'an error has occured

            'close connections that might be open
            If IsNothing(vMyPgCon) = False Then
                If vMyPgCon.State <> ConnectionState.Closed Then
                    vMyPgCon.Close()
                    vMyPgCon = Nothing
                End If
            End If

            vLineNo = vLineNo + 1
            vTmpMessage = Trim(Str(vLineNo)) & ". Critical! An error has occured. Error number: " & Trim(Str(Err.Number)) & ", Error description: " & Err.Description

            'If Trim(vSystemMessage) & "" Then
            ' vSystemMessage = vSystemMessage & vbCrLf & vbCrLf
            ' End If
            '
            '            If Trim(vTmpMessage) <> "" Then
            ' vSystemMessage = vSystemMessage & vTmpMessage
            ' End If

            GetSystemMessages = vTmpMessage

            'log event
            vQuery = modModule.CreateLog("modModule.GetSystemMessages", "Error:RefreshDetails", ex.Message)

            'revert to old visible settings of prompt control
            bPrompt.Visible = vOldPromptVisible
            bPrompt.Text = vOldPromptText
        End Try
    End Function

    Public Function HashData(ByVal bHashCode As Byte, ByVal bString As String) As String
        Dim vCtr As Long
        Dim vHashString As String = ""
        Dim vHashDataOrg As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890`-=[];\,./~!@#$%^&*()_+{}:<>? "
        Dim vHashData1 As String = ".@eU#R%D^Kmy!_NgzpjZL+;Q1u5:]\n`/*{oWO0,IfJ$qckw)=7a9xF-GC d2&vXlM<4S>sAYTh}?t[6iH~V8E(B3brP"
        Dim vHashData As String = ""
        Dim vPos As Long
        Dim vCurrChar As String
        Dim vHashChar As String

        'cMe5tS3VOXcMe5tS3

        HashData = ""

        'Select hashing method to use based on seed
        Select Case bHashCode
            Case 1
                vHashData = vHashData1

            Case Else
                'abort

                Exit Function
        End Select

        For vCtr = 1 To Len(bString)
            vCurrChar = Mid(bString, vCtr, 1)

            vPos = InStr(vHashDataOrg, vCurrChar)
            If vPos > 0 Then
                vHashChar = Mid(vHashData, vPos, 1)

                vHashString = vHashString & vHashChar
            Else
                vHashString = vHashString & vCurrChar
            End If
        Next vCtr

        HashData = vHashString
    End Function

    Public Function UnHashData(ByVal bHashCode As Byte, ByVal bString As String) As String
        Dim vCtr As Long
        Dim vHashString As String = ""
        Dim vHashDataOrg As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890`-=[];\,./~!@#$%^&*()_+{}:<>? "
        Dim vHashData1 As String = ".@eU#R%D^Kmy!_NgzpjZL+;Q1u5:]\n`/*{oWO0,IfJ$qckw)=7a9xF-GC d2&vXlM<4S>sAYTh}?t[6iH~V8E(B3brP"
        Dim vHashData As String = ""
        Dim vPos As Long
        Dim vCurrChar As String
        Dim vHashChar As String

        UnHashData = ""

        'Select hashing method to use based on seed
        Select Case bHashCode
            Case 1
                vHashData = vHashData1

            Case Else
                'abort

                Exit Function
        End Select

        For vCtr = 1 To Len(bString)
            vCurrChar = Mid(bString, vCtr, 1)

            vPos = InStr(vHashData, vCurrChar)
            If vPos > 0 Then
                vHashChar = Mid(vHashDataOrg, vPos, 1)

                vHashString = vHashString & vHashChar
            Else
                vHashString = vHashString & vCurrChar
            End If
        Next vCtr

        UnHashData = vHashString
    End Function

    Public Function MasterDbRebuilt(ByRef bPrompt As Label) As String
        'host connections
        Dim vSqlCn As New SqlConnection
        Dim vSqlRs As SqlDataReader
        Dim vSqlCmd As SqlCommand
        Dim vDbConnectStrHost As String = ""
        Dim vHostTable As String

        'master db connections
        Dim vMyPgCon2 As New NpgsqlConnection
        Dim vMyPgCmd2 = New NpgsqlCommand
        Dim vMyPgRd2 As NpgsqlDataReader

        Dim vMyPgCon As New NpgsqlConnection
        Dim vMyPgCmd = New NpgsqlCommand
        Dim vMyPgRd As NpgsqlDataReader
        Dim vDbConnectStrMasterDB As String = ""
        Dim vMasterDbTable As String

        Dim vQuery As String = ""
        Dim vFound As Boolean
        Dim vFirst As Boolean

        'Dim vDateTime As String
        Dim vUpdated As Double = 0
        Dim vCreated As Double = 0

        Dim vField_name As String = ""
        Dim vField_lname As String = ""
        Dim vField_mname As String = ""
        Dim vField_fname As String = ""
        Dim vField_organization As String = ""
        Dim vField_plate_no As String = ""
        Dim vField_mv_file_no As String = ""
        Dim vField_chassis_no As String = ""
        Dim vField_engine_no As String = ""
        Dim vField_mv_type As String = ""
        Dim vField_make As String = ""
        Dim vField_fuel_type As String = ""
        Dim vField_color As String = ""
        Dim vField_classification As String = ""
        Dim vField_vehicle_model As String = ""
        Dim vField_vehicle_series As String = ""
        Dim vField_date_first_reg As String = ""
        Dim vField_cr_no As String = ""
        Dim vField_owner_address As String = ""
        Dim vField_body_type As String = ""
        Dim vField_diesel_type As String = ""
        Dim vField_cylinder As String = ""
        Dim vField_gross_mv_weight As String = ""
        Dim vField_engine_type As String = ""
        Dim vField_transmission_type As String = ""
        Dim vField_net_cap As String = ""
        Dim vField_rebuilt As String = ""
        Dim vField_cat_conv As String = ""
        Dim vField_turbo As String = ""
        Dim vField_non_turbo As String = ""
        Dim vField_elevation As String = ""
        Dim vField_n_aspirated As String = ""
        Dim vField_span As String = ""
        Dim vField_denomination As String = ""
        Dim vField_displacement As String = ""
        Dim vField_net_weight As String = ""
        Dim vField_ship_weight As String = ""
        Dim vField_cap_weight As String = ""
        Dim vField_status As String = ""

        'initialize
        MasterDbRebuilt = ""

        'connection string to Host data
        vDbConnectStrHost = "User ID=" & "sa" & ";" & _
            "Password=" & "protocol_01" & ";" & _
            "Server=" & "SERVERBACKUP-PC" & ";" & _
            "Database=" & "partial" & ";"

        vHostTable = "partial"

        vDbConnectStrHost = "User ID=" & "sa" & ";" & _
            "Password=" & "protocol_01" & ";" & _
            "Server=" & "SERVERXEON-PC" & ";" & _
            "Database=" & "DataVI" & ";"

        vHostTable = "SASAKYAN"

        vMasterDbTable = "lto.from_host"

        'connection string to Master DB
        vDbConnectStrMasterDB = pConnectMasterDb

        Try
            'get period upon operation start
            'vDateTime = Format(Now, "yyyy-MM-dd HH.mm.ss")

            bPrompt.Text = "Connecting to host data..."
            bPrompt.Refresh()

            'connect to host
            vSqlCn.ConnectionString = vDbConnectStrHost
            vSqlCn.Open()

            bPrompt.Text = "Connecting to Master DB..."
            bPrompt.Refresh()

            'connect to master db
            vMyPgCon.ConnectionString = vDbConnectStrMasterDB
            vMyPgCon.Open()

            bPrompt.Text = "Connecting to Emission DB..."
            bPrompt.Refresh()

            'connect to master db
            vMyPgCon2.ConnectionString = pConnectVox
            vMyPgCon2.Open()

            bPrompt.Text = "Gathering host data..."
            bPrompt.Refresh()

            'get host data
            vQuery = "SELECT * FROM " & vHostTable

            vSqlCmd = New SqlCommand(vQuery, vSqlCn)
            vSqlRs = vSqlCmd.ExecuteReader()

            'extract first data from host
            vFound = vSqlRs.Read()

            'mark as first record
            vFirst = True

            'if found then process rest
            Do While vFound = True
                'create a transaction before processing
                If vFirst = True Then
                    'mark atleast one record is processed
                    vFirst = False

                    bPrompt.Text = "Creating a transaction..."
                    bPrompt.Refresh()

                    vQuery = "BEGIN TRANSACTION"

                    'create query
                    vMyPgCmd = New NpgsqlCommand(vQuery, vMyPgCon)

                    'execute query
                    vMyPgCmd.ExecuteNonQuery()

                    'close connection
                    vMyPgCmd.Dispose()

                    bPrompt.Text = "Initializing Master DB..."
                    bPrompt.Refresh()

                    vQuery = "TRUNCATE " & vMasterDbTable

                    'create query
                    vMyPgCmd = New NpgsqlCommand(vQuery, vMyPgCon)

                    'execute query
                    vMyPgCmd.ExecuteNonQuery()

                    'close connection
                    vMyPgCmd.Dispose()

                    bPrompt.Text = "Rebuilding Master DB. " & _
                        vCreated.ToString & " created, " & vUpdated.ToString & " updated..."
                    bPrompt.Refresh()

                    Application.DoEvents()
                End If

                'get data
                If IsDBNull(vSqlRs("CustName")) = True Then
                    vField_name = ""
                Else
                    vField_name = vSqlRs("CustName").ToString
                End If

                vField_lname = ""
                vField_mname = ""
                vField_fname = ""
                vField_organization = ""

                If IsDBNull(vSqlRs("plateno")) = True Then
                    vField_plate_no = ""
                Else
                    vField_plate_no = vSqlRs("plateno").ToString
                End If

                If IsDBNull(vSqlRs("fileno")) = True Then
                    vField_mv_file_no = ""
                Else
                    vField_mv_file_no = vSqlRs("fileno").ToString
                End If

                If IsDBNull(vSqlRs("chassisno")) = True Then
                    vField_chassis_no = ""
                Else
                    vField_chassis_no = vSqlRs("chassisno").ToString
                End If

                If IsDBNull(vSqlRs("engineno")) = True Then
                    vField_engine_no = ""
                Else
                    vField_engine_no = vSqlRs("engineno").ToString
                End If

                If IsDBNull(vSqlRs("type")) = True Then
                    vField_mv_type = ""
                Else
                    vField_mv_type = vSqlRs("type").ToString
                End If

                If IsDBNull(vSqlRs("make")) = True Then
                    vField_make = ""
                Else
                    vField_make = vSqlRs("make").ToString
                End If

                If IsDBNull(vSqlRs("fuel")) = True Then
                    vField_fuel_type = ""
                Else
                    vField_fuel_type = vSqlRs("fuel").ToString
                End If

                If IsDBNull(vSqlRs("color")) = True Then
                    vField_color = ""
                Else
                    vField_color = vSqlRs("color").ToString
                End If

                If IsDBNull(vSqlRs("class")) = True Then
                    vField_classification = ""
                Else
                    vField_classification = vSqlRs("class").ToString
                End If

                If IsDBNull(vSqlRs("model")) = True Then
                    vField_vehicle_model = ""
                Else
                    vField_vehicle_model = vSqlRs("model").ToString
                End If

                If IsDBNull(vSqlRs("series")) = True Then
                    vField_vehicle_series = ""
                Else
                    vField_vehicle_series = vSqlRs("series").ToString
                End If

                If IsDBNull(vSqlRs("first")) = True Then
                    vField_date_first_reg = ""
                Else
                    vField_date_first_reg = vSqlRs("first").ToString
                End If

                vField_cr_no = ""

                If IsDBNull(vSqlRs("Address")) = True Then
                    vField_owner_address = ""
                Else
                    vField_owner_address = vSqlRs("Address").ToString
                End If

                vField_body_type = ""
                vField_diesel_type = ""

                If IsDBNull(vSqlRs("cylinder")) = True Then
                    vField_cylinder = ""
                Else
                    vField_cylinder = vSqlRs("cylinder").ToString
                End If

                If IsDBNull(vSqlRs("grosswt")) = True Then
                    vField_gross_mv_weight = ""
                Else
                    vField_gross_mv_weight = vSqlRs("grosswt").ToString
                End If

                vField_engine_type = ""
                vField_transmission_type = ""
                vField_net_cap = ""
                vField_rebuilt = ""
                vField_cat_conv = ""
                vField_turbo = ""
                vField_non_turbo = ""
                vField_elevation = ""
                vField_n_aspirated = ""
                vField_span = ""

                If IsDBNull(vSqlRs("denom")) = True Then
                    vField_denomination = ""
                Else
                    vField_denomination = vSqlRs("denom").ToString
                End If

                If IsDBNull(vSqlRs("pd")) = True Then
                    vField_displacement = ""
                Else
                    vField_displacement = vSqlRs("pd").ToString
                End If

                If IsDBNull(vSqlRs("netwt")) = True Then
                    vField_net_weight = ""
                Else
                    vField_net_weight = vSqlRs("netwt").ToString
                End If

                If IsDBNull(vSqlRs("shipwt")) = True Then
                    vField_ship_weight = ""
                Else
                    vField_ship_weight = vSqlRs("shipwt").ToString
                End If

                If IsDBNull(vSqlRs("capwt")) = True Then
                    vField_cap_weight = ""
                Else
                    vField_cap_weight = vSqlRs("capwt").ToString
                End If

                If IsDBNull(vSqlRs("Status")) = True Then
                    vField_status = ""
                Else
                    vField_status = vSqlRs("Status").ToString
                End If

                '                'search codes from look-up tables
                '                If vField_mv_type <> "" Then
                ' 'search codes from look-up tables - mv_type
                ' vQuery = "SELECT class_code FROM tb_mv_types " & _
                '     "WHERE UPPER(class_name) = '" & UCase(modModule.CorrectSqlString(vField_mv_type)) & "' " & _
                '     "ORDER BY is_active DESC LIMIT 1"
                '
                '                'create query
                '                vMyPgCmd2 = New NpgsqlCommand(vQuery, vMyPgCon2)
                '
                '                'execute query
                '                vMyPgRd2 = vMyPgCmd2.ExecuteReader()
                '
                '                'read values
                '                vFound = vMyPgRd2.Read
                '
                '                If vFound = True Then
                ' vField_mv_type = vMyPgRd2("class_code")
                ' Else
                ' vField_mv_type = ""
                ' End If
                '
                '                'close connection
                '                vMyPgRd2.Close()
                '                vMyPgCmd2.Dispose()
                '                End If
                '
                '                If vField_make <> "" Then
                ' 'search codes from look-up tables - make
                ' vQuery = "SELECT make FROM tb_mv_make_series " & _
                '     "WHERE UPPER(make_description) = '" & UCase(modModule.CorrectSqlString(vField_make)) & "' " & _
                '     "ORDER BY is_active DESC LIMIT 1"
                '
                '                'create query
                '                vMyPgCmd2 = New NpgsqlCommand(vQuery, vMyPgCon2)
                '
                '                'execute query
                '                vMyPgRd2 = vMyPgCmd2.ExecuteReader()
                '
                '                'read values
                '                vFound = vMyPgRd2.Read
                '
                '                If vFound = True Then
                ' vField_make = vMyPgRd2("make")
                ' Else
                ' vField_make = ""
                ' End If
                '
                '                'close connection
                '                vMyPgRd2.Close()
                '                vMyPgCmd2.Dispose()
                '                End If
                '
                '                If vField_color <> "" Then
                ' 'search codes from look-up tables - color
                ' vQuery = "SELECT color_code FROM tb_colors " & _
                '     "WHERE UPPER(color_description) = '" & UCase(modModule.CorrectSqlString(vField_color)) & "' " & _
                '     "ORDER BY is_active DESC LIMIT 1"
                '
                '                'create query
                '                vMyPgCmd2 = New NpgsqlCommand(vQuery, vMyPgCon2)
                '
                '                'execute query
                '                vMyPgRd2 = vMyPgCmd2.ExecuteReader()
                '
                '                'read values
                '                vFound = vMyPgRd2.Read
                '
                '                If vFound = True Then
                ' vField_color = vMyPgRd2("color_code")
                ' Else
                ' vField_color = ""
                ' End If
                '
                '                'close connection
                '                vMyPgRd2.Close()
                '                vMyPgCmd2.Dispose()
                '                End If
                '
                '                If vField_classification <> "" Then
                ' 'search codes from look-up tables - classification
                ' vQuery = "SELECT class_code FROM tb_classifications " & _
                '     "WHERE UPPER(class_name) = '" & UCase(modModule.CorrectSqlString(vField_classification)) & "' " & _
                '     "ORDER BY is_active DESC LIMIT 1"
                '
                '                'create query
                '                vMyPgCmd2 = New NpgsqlCommand(vQuery, vMyPgCon2)
                '
                '                'execute query
                '                vMyPgRd2 = vMyPgCmd2.ExecuteReader()
                '
                '                'read values
                '                vFound = vMyPgRd2.Read
                '
                '                If vFound = True Then
                ' vField_classification = vMyPgRd2("class_code")
                ' Else
                ' vField_classification = ""
                ' End If
                '
                '                'close connection
                '                vMyPgRd2.Close()
                '                vMyPgCmd2.Dispose()
                '                End If
                '
                '                If vField_body_type <> "" Then
                ' 'search codes from look-up tables - body_type
                ' vQuery = "SELECT body_type_code FROM tb_body_types " & _
                '     "WHERE UPPER(body_type_name) = '" & UCase(modModule.CorrectSqlString(vField_body_type)) & "' " & _
                '     "ORDER BY is_active DESC LIMIT 1"
                '
                '                'create query
                '                vMyPgCmd2 = New NpgsqlCommand(vQuery, vMyPgCon2)
                '
                '                'execute query
                '                vMyPgRd2 = vMyPgCmd2.ExecuteReader()
                '
                '                'read values
                '                vFound = vMyPgRd2.Read
                '
                '                If vFound = True Then
                ' vField_body_type = vMyPgRd2("body_type_code")
                ' Else
                ' vField_body_type = ""
                ' End If
                '
                '                'close connection
                '                vMyPgRd2.Close()
                '                vMyPgCmd2.Dispose()
                '                End If
                '
                '                'validate values of selected fields
                '                If vField_fuel_type <> "" Then
                ' 'validate - fuel_type
                ' vQuery = "SELECT fuel_code FROM tb_fuel_types " & _
                '     "WHERE UPPER(fuel_code) = '" & UCase(modModule.CorrectSqlString(vField_fuel_type)) & "' " & _
                '     "ORDER BY is_active DESC LIMIT 1"
                '
                '                'create query
                '                vMyPgCmd2 = New NpgsqlCommand(vQuery, vMyPgCon2)
                '
                '                'execute query
                '                vMyPgRd2 = vMyPgCmd2.ExecuteReader()
                '
                '                'read values
                '                vFound = vMyPgRd2.Read
                '
                '                If vFound = True Then
                ' vField_fuel_type = vField_fuel_type
                ' Else
                ' vField_fuel_type = ""
                ' End If
                '
                '                'close connection
                '                vMyPgRd2.Close()
                '                vMyPgCmd2.Dispose()
                '                End If
                '
                '                If vField_date_first_reg <> "" Then
                ' 'validate - date_first_reg
                '
                '                If IsDate(vField_date_first_reg) = True Then
                ' vField_date_first_reg = CDate(vField_date_first_reg).ToString("yyyy-MM-dd")
                ' Else
                ' vField_date_first_reg = ""
                ' End If
                ' End If
                '
                '                'encrypt data
                '                vField_name = modModule.HashData(1, vField_name)
                '                vField_lname = modModule.HashData(1, vField_lname)
                '                vField_mname = modModule.HashData(1, vField_mname)
                '                vField_fname = modModule.HashData(1, vField_fname)
                '                vField_organization = modModule.HashData(1, vField_organization)
                '                vField_plate_no = modModule.HashData(1, vField_plate_no)
                '                vField_mv_file_no = modModule.HashData(1, vField_mv_file_no)
                '                vField_chassis_no = modModule.HashData(1, vField_chassis_no)
                '                vField_engine_no = modModule.HashData(1, vField_engine_no)
                '                vField_mv_type = modModule.HashData(1, vField_mv_type)
                '                vField_make = modModule.HashData(1, vField_make)
                '                vField_fuel_type = modModule.HashData(1, vField_fuel_type)
                '                vField_color = modModule.HashData(1, vField_color)
                '                vField_classification = modModule.HashData(1, vField_classification)
                '                vField_vehicle_model = modModule.HashData(1, vField_vehicle_model)
                '                vField_vehicle_series = modModule.HashData(1, vField_vehicle_series)
                '                vField_date_first_reg = modModule.HashData(1, vField_date_first_reg)
                '                vField_cr_no = modModule.HashData(1, vField_cr_no)
                '                vField_owner_address = modModule.HashData(1, vField_owner_address)
                '                vField_body_type = modModule.HashData(1, vField_body_type)
                '                vField_diesel_type = modModule.HashData(1, vField_diesel_type)
                '                vField_cylinder = modModule.HashData(1, vField_cylinder)
                '                vField_gross_mv_weight = modModule.HashData(1, vField_gross_mv_weight)
                '                vField_engine_type = modModule.HashData(1, vField_engine_type)
                '                vField_transmission_type = modModule.HashData(1, vField_transmission_type)
                '                vField_net_cap = modModule.HashData(1, vField_net_cap)
                '                vField_rebuilt = modModule.HashData(1, vField_rebuilt)
                '                vField_cat_conv = modModule.HashData(1, vField_cat_conv)
                '                vField_turbo = modModule.HashData(1, vField_turbo)
                '                vField_non_turbo = modModule.HashData(1, vField_non_turbo)
                '                vField_elevation = modModule.HashData(1, vField_elevation)
                '                vField_n_aspirated = modModule.HashData(1, vField_n_aspirated)
                '                vField_span = modModule.HashData(1, vField_span)
                '                vField_denomination = modModule.HashData(1, vField_denomination)
                '                vField_displacement = modModule.HashData(1, vField_displacement)
                '                vField_net_weight = modModule.HashData(1, vField_net_weight)
                '                vField_ship_weight = modModule.HashData(1, vField_ship_weight)
                '                vField_cap_weight = modModule.HashData(1, vField_cap_weight)
                '                vField_status = modModule.HashData(1, vField_status)

                'check if existing in master db
                vQuery = "SELECT recno FROM " & vMasterDbTable & " " & _
                    "WHERE plate_no = '" & modModule.CorrectSqlString(vField_plate_no) & "'"

                'create query
                vMyPgCmd = New NpgsqlCommand(vQuery, vMyPgCon)

                'execute query
                vMyPgRd = vMyPgCmd.ExecuteReader()

                'read values
                vFound = vMyPgRd.Read

                If vFound = True Then
                    'data already exist, overwrite
                    vMyPgRd.Close()
                    vMyPgCmd.Dispose()

                    'update record
                    vQuery = "UPDATE " & vMasterDbTable & " SET " & _
                        "name = '" & modModule.CorrectSqlString(vField_name) & "', " & _
                        "lname = '" & modModule.CorrectSqlString(vField_lname) & "', " & _
                        "mname = '" & modModule.CorrectSqlString(vField_mname) & "', " & _
                        "fname = '" & modModule.CorrectSqlString(vField_fname) & "', " & _
                        "organization = '" & modModule.CorrectSqlString(vField_organization) & "', " & _
                        "mv_file_no = '" & modModule.CorrectSqlString(vField_mv_file_no) & "', " & _
                        "chassis_no = '" & modModule.CorrectSqlString(vField_chassis_no) & "', " & _
                        "engine_no = '" & modModule.CorrectSqlString(vField_engine_no) & "', " & _
                        "mv_type = '" & modModule.CorrectSqlString(vField_mv_type) & "', " & _
                        "make = '" & modModule.CorrectSqlString(vField_make) & "', " & _
                        "fuel_type = '" & modModule.CorrectSqlString(vField_fuel_type) & "', " & _
                        "color = '" & modModule.CorrectSqlString(vField_color) & "', " & _
                        "classification = '" & modModule.CorrectSqlString(vField_classification) & "', " & _
                        "vehicle_model = '" & modModule.CorrectSqlString(vField_vehicle_model) & "', " & _
                        "vehicle_series = '" & modModule.CorrectSqlString(vField_vehicle_series) & "', " & _
                        "date_first_reg = '" & modModule.CorrectSqlString(vField_date_first_reg) & "', " & _
                        "cr_no = '" & modModule.CorrectSqlString(vField_cr_no) & "', " & _
                        "owner_address = '" & modModule.CorrectSqlString(vField_owner_address) & "', " & _
                        "body_type = '" & modModule.CorrectSqlString(vField_body_type) & "', " & _
                        "diesel_type = '" & modModule.CorrectSqlString(vField_diesel_type) & "', " & _
                        "cylinder = '" & modModule.CorrectSqlString(vField_cylinder) & "', " & _
                        "gross_mv_weight = '" & modModule.CorrectSqlString(vField_gross_mv_weight) & "', " & _
                        "engine_type = '" & modModule.CorrectSqlString(vField_engine_type) & "', " & _
                        "transmission_type = '" & modModule.CorrectSqlString(vField_transmission_type) & "', " & _
                        "net_cap = '" & modModule.CorrectSqlString(vField_net_cap) & "', " & _
                        "rebuilt = '" & modModule.CorrectSqlString(vField_rebuilt) & "', " & _
                        "cat_conv = '" & modModule.CorrectSqlString(vField_cat_conv) & "', " & _
                        "turbo = '" & modModule.CorrectSqlString(vField_turbo) & "', " & _
                        "non_turbo = '" & modModule.CorrectSqlString(vField_non_turbo) & "', " & _
                        "elevation = '" & modModule.CorrectSqlString(vField_elevation) & "', " & _
                        "n_aspirated = '" & modModule.CorrectSqlString(vField_n_aspirated) & "', " & _
                        "span = '" & modModule.CorrectSqlString(vField_span) & "', " & _
                        "denomination = '" & modModule.CorrectSqlString(vField_denomination) & "', " & _
                        "displacement = '" & modModule.CorrectSqlString(vField_displacement) & "', " & _
                        "net_weight = '" & modModule.CorrectSqlString(vField_net_weight) & "', " & _
                        "ship_weight = '" & modModule.CorrectSqlString(vField_ship_weight) & "', " & _
                        "cap_weight = '" & modModule.CorrectSqlString(vField_cap_weight) & "', " & _
                        "status = '" & modModule.CorrectSqlString(vField_status) & "' " & _
                        "WHERE plate_no = '" & modModule.CorrectSqlString(vField_plate_no) & "'"

                    vQuery = "UPDATE " & vMasterDbTable & " SET " & _
                        "name = '" & modModule.CorrectSqlString(vField_name) & "', " & _
                        "mv_file_no = '" & modModule.CorrectSqlString(vField_mv_file_no) & "', " & _
                        "chassis_no = '" & modModule.CorrectSqlString(vField_chassis_no) & "', " & _
                        "engine_no = '" & modModule.CorrectSqlString(vField_engine_no) & "', " & _
                        "mv_type = '" & modModule.CorrectSqlString(vField_mv_type) & "', " & _
                        "make = '" & modModule.CorrectSqlString(vField_make) & "', " & _
                        "fuel_type = '" & modModule.CorrectSqlString(vField_fuel_type) & "', " & _
                        "color = '" & modModule.CorrectSqlString(vField_color) & "', " & _
                        "classification = '" & modModule.CorrectSqlString(vField_classification) & "', " & _
                        "vehicle_model = '" & modModule.CorrectSqlString(vField_vehicle_model) & "', " & _
                        "vehicle_series = '" & modModule.CorrectSqlString(vField_vehicle_series) & "', " & _
                        "date_first_reg = '" & modModule.CorrectSqlString(vField_date_first_reg) & "', " & _
                        "owner_address = '" & modModule.CorrectSqlString(vField_owner_address) & "', " & _
                        "body_type = '" & modModule.CorrectSqlString(vField_body_type) & "', " & _
                        "cylinder = '" & modModule.CorrectSqlString(vField_cylinder) & "', " & _
                        "gross_mv_weight = '" & modModule.CorrectSqlString(vField_gross_mv_weight) & "', " & _
                        "denomination = '" & modModule.CorrectSqlString(vField_denomination) & "', " & _
                        "displacement = '" & modModule.CorrectSqlString(vField_displacement) & "', " & _
                        "net_weight = '" & modModule.CorrectSqlString(vField_net_weight) & "', " & _
                        "ship_weight = '" & modModule.CorrectSqlString(vField_ship_weight) & "', " & _
                        "cap_weight = '" & modModule.CorrectSqlString(vField_cap_weight) & "', " & _
                        "status = '" & modModule.CorrectSqlString(vField_status) & "', " & _
                        "recs = recs + 1 " & _
                        "WHERE plate_no = '" & modModule.CorrectSqlString(vField_plate_no) & "'"

                    'create query
                    vMyPgCmd = New NpgsqlCommand(vQuery, vMyPgCon)

                    'execute query
                    vMyPgCmd.ExecuteNonQuery()

                    'close connection
                    vMyPgCmd.Dispose()

                    'increase counter
                    vUpdated = vUpdated + 1
                Else
                    'data does not exist, insert
                    vMyPgRd.Close()
                    vMyPgCmd.Dispose()

                    'insert record
                    vQuery = "INSERT INTO " & vMasterDbTable & " (name, lname, mname, fname, organization, plate_no, mv_file_no, chassis_no, " & _
                        "engine_no, mv_type, make, fuel_type, color, classification, vehicle_model, vehicle_series, date_first_reg, " & _
                        "cr_no, owner_address, body_type, diesel_type, cylinder, gross_mv_weight, engine_type, transmission_type, " & _
                        "net_cap, rebuilt, cat_conv, turbo, non_turbo, elevation, n_aspirated, span, denomination, displacement, " & _
                        "net_weight, ship_weight, cap_weight, status) " & _
                        "VALUES ('" & modModule.CorrectSqlString(vField_name) & "','" & modModule.CorrectSqlString(vField_lname) & "'," & _
                        "'" & modModule.CorrectSqlString(vField_mname) & "','" & modModule.CorrectSqlString(vField_fname) & "'," & _
                        "'" & modModule.CorrectSqlString(vField_organization) & "','" & modModule.CorrectSqlString(vField_plate_no) & "'," & _
                        "'" & modModule.CorrectSqlString(vField_mv_file_no) & "','" & modModule.CorrectSqlString(vField_chassis_no) & "'," & _
                        "'" & modModule.CorrectSqlString(vField_engine_no) & "','" & modModule.CorrectSqlString(vField_mv_type) & "'," & _
                        "'" & modModule.CorrectSqlString(vField_make) & "','" & modModule.CorrectSqlString(vField_fuel_type) & "'," & _
                        "'" & modModule.CorrectSqlString(vField_color) & "','" & modModule.CorrectSqlString(vField_classification) & "'," & _
                        "'" & modModule.CorrectSqlString(vField_vehicle_model) & "','" & modModule.CorrectSqlString(vField_vehicle_series) & "'," & _
                        "'" & modModule.CorrectSqlString(vField_date_first_reg) & "','" & modModule.CorrectSqlString(vField_cr_no) & "'," & _
                        "'" & modModule.CorrectSqlString(vField_owner_address) & "','" & modModule.CorrectSqlString(vField_body_type) & "'," & _
                        "'" & modModule.CorrectSqlString(vField_diesel_type) & "','" & modModule.CorrectSqlString(vField_cylinder) & "'," & _
                        "'" & modModule.CorrectSqlString(vField_gross_mv_weight) & "','" & modModule.CorrectSqlString(vField_engine_type) & "'," & _
                        "'" & modModule.CorrectSqlString(vField_transmission_type) & "','" & modModule.CorrectSqlString(vField_net_cap) & "'," & _
                        "'" & modModule.CorrectSqlString(vField_rebuilt) & "','" & modModule.CorrectSqlString(vField_cat_conv) & "'," & _
                        "'" & modModule.CorrectSqlString(vField_turbo) & "','" & modModule.CorrectSqlString(vField_non_turbo) & "'," & _
                        "'" & modModule.CorrectSqlString(vField_elevation) & "','" & modModule.CorrectSqlString(vField_n_aspirated) & "'," & _
                        "'" & modModule.CorrectSqlString(vField_span) & "','" & modModule.CorrectSqlString(vField_denomination) & "'," & _
                        "'" & modModule.CorrectSqlString(vField_displacement) & "','" & modModule.CorrectSqlString(vField_net_weight) & "'," & _
                        "'" & modModule.CorrectSqlString(vField_ship_weight) & "','" & modModule.CorrectSqlString(vField_cap_weight) & "'," & _
                        "'" & modModule.CorrectSqlString(vField_status) & "')"

                    vQuery = "INSERT INTO " & vMasterDbTable & " (name, plate_no, mv_file_no, chassis_no, " & _
                        "engine_no, mv_type, make, fuel_type, color, classification, vehicle_model, vehicle_series, date_first_reg, " & _
                        "owner_address, body_type, cylinder, gross_mv_weight, " & _
                        "denomination, displacement, " & _
                        "net_weight, ship_weight, cap_weight, status, recs) " & _
                        "VALUES ('" & modModule.CorrectSqlString(vField_name) & "','" & modModule.CorrectSqlString(vField_plate_no) & "'," & _
                        "'" & modModule.CorrectSqlString(vField_mv_file_no) & "','" & modModule.CorrectSqlString(vField_chassis_no) & "'," & _
                        "'" & modModule.CorrectSqlString(vField_engine_no) & "','" & modModule.CorrectSqlString(vField_mv_type) & "'," & _
                        "'" & modModule.CorrectSqlString(vField_make) & "','" & modModule.CorrectSqlString(vField_fuel_type) & "'," & _
                        "'" & modModule.CorrectSqlString(vField_color) & "','" & modModule.CorrectSqlString(vField_classification) & "'," & _
                        "'" & modModule.CorrectSqlString(vField_vehicle_model) & "','" & modModule.CorrectSqlString(vField_vehicle_series) & "'," & _
                        "'" & modModule.CorrectSqlString(vField_date_first_reg) & "','" & modModule.CorrectSqlString(vField_owner_address) & "'," & _
                        "'" & modModule.CorrectSqlString(vField_body_type) & "','" & modModule.CorrectSqlString(vField_cylinder) & "'," & _
                        "'" & modModule.CorrectSqlString(vField_gross_mv_weight) & "','" & modModule.CorrectSqlString(vField_denomination) & "'," & _
                        "'" & modModule.CorrectSqlString(vField_displacement) & "','" & modModule.CorrectSqlString(vField_net_weight) & "'," & _
                        "'" & modModule.CorrectSqlString(vField_ship_weight) & "','" & modModule.CorrectSqlString(vField_cap_weight) & "'," & _
                        "'" & modModule.CorrectSqlString(vField_status) & "', 1)"

                    'create query
                    vMyPgCmd = New NpgsqlCommand(vQuery, vMyPgCon)

                    'execute query
                    vMyPgCmd.ExecuteNonQuery()

                    'close connection
                    vMyPgCmd.Dispose()

                    'increase counter
                    vCreated = vCreated + 1
                End If

                If (vCreated Mod 1000) = 0 Then
                    'update display
                    bPrompt.Text = "Rebuilding Master DB. " & _
                        vCreated.ToString("###,###,###,###,##0") & " created, " & _
                        vUpdated.ToString("###,###,###,###,##0") & " updated..."
                    bPrompt.Refresh()

                    'process background
                    Application.DoEvents()
                End If

                'extract next row from host
                vFound = vSqlRs.Read()
            Loop

            'update display
            bPrompt.Text = "Rebuilding Master DB. " & _
                vCreated.ToString("###,###,###,###,##0") & " created, " & _
                vUpdated.ToString("###,###,###,###,##0") & " updated..."
            bPrompt.Refresh()

            'save transaction if a transaction was created
            If vFirst = False Then
                bPrompt.Text = "Reflecting changes..."
                bPrompt.Refresh()

                vQuery = "COMMIT TRANSACTION"

                'create query
                vMyPgCmd = New NpgsqlCommand(vQuery, vMyPgCon)

                'execute query
                vMyPgCmd.ExecuteNonQuery()

                'close connection
                vMyPgCmd.Dispose()
            End If

            bPrompt.Text = "Closing connection to host data..."
            bPrompt.Refresh()

            'close connections from host
            vSqlRs.Close()
            vSqlCmd.Dispose()
            vSqlCn.Close()
            vSqlCn = Nothing

            bPrompt.Text = "Closing connection to Master DB..."
            bPrompt.Refresh()

            'close connection from master db
            vMyPgCon2.Close()
            vMyPgCon2 = Nothing

            vMyPgCon.Close()
            vMyPgCon = Nothing

            bPrompt.Text = "Rebuilding of Master DB complete."
            bPrompt.Refresh()

            MasterDbRebuilt = "ok" & "Created: " & vCreated.ToString("###,###,###,##0") & " recs " & vbCrLf & _
                "Updated: " & vUpdated.ToString("###,###,###,##0") & " recs"

        Catch ex As Exception

            'an error has occured

            'close connections that might be open
            If IsNothing(vMyPgCon) = False Then
                If vMyPgCon.State <> ConnectionState.Closed Then
                    vMyPgCon.Close()
                    vMyPgCon = Nothing
                End If
            End If

            If IsNothing(vMyPgCon2) = False Then
                If vMyPgCon2.State <> ConnectionState.Closed Then
                    vMyPgCon2.Close()
                    vMyPgCon2 = Nothing
                End If
            End If

            If IsNothing(vSqlCn) = False Then
                If vSqlCn.State <> ConnectionState.Closed Then
                    vSqlCn.Close()
                    vSqlCn = Nothing
                End If
            End If

            MasterDbRebuilt = "error:" & ex.Message

            'log event
            vQuery = modModule.CreateLog("modModule.MasterDbRebuilt", "Error:timerDataLoad", ex.Message)
        End Try
    End Function

    Public Function ChangeXmlKey(ByVal bXmlFilename As String, ByVal bXmlPath As String, ByVal bKey As String, ByVal bNewValue As String) As String
        Dim vXmlFile = New XmlDocument
        Dim vXmlAttr As XmlAttribute

        ChangeXmlKey = ""

        Try
            vXmlFile.Load(bXmlFilename)                     'open xml file

            vXmlAttr = vXmlFile.SelectSingleNode(bXmlPath & "/add[@key = '" & bKey & "']/@value")   'select node
            vXmlAttr.Value = bNewValue                                                              'set new value

            vXmlFile.Save(bXmlFilename)                     'update xml file

            ChangeXmlKey = "ok"                             'return successful

        Catch ex As Exception
            ChangeXmlKey = "error: " & ex.Message           'return error
        End Try
    End Function

    Public Sub GotoTextBoxLastLine(ByRef bTextBox As TextBox)
        bTextBox.SelectionStart = bTextBox.Text.Length
        bTextBox.ScrollToCaret()
        bTextBox.Refresh()
    End Sub

End Module
