Module modPrinting

    Public Sub PrintFormHeader(ByVal bLeftMargin As Integer, ByVal bRightMargin As Integer, e As Printing.PrintPageEventArgs, ByVal bFormName As String)
        Dim vLogo As String
        Dim vFound As Boolean
        Dim vFont As Font
        Dim vStringFormat As New StringFormat
        Dim vRect As Rectangle

        '--------------------- company logo ---------------------
        vLogo = Application.StartupPath & "\data\images\vox_logo.jpg"

        vFound = False
        If System.IO.File.Exists(vLogo) = True Then
            vFound = True
        End If

        Try
            e.Graphics.DrawImage(Image.FromFile(vLogo), bLeftMargin, bLeftMargin + 10, 44, 44)
        Catch ex As Exception
            e.Graphics.DrawString("LOGO", New Font("Arial", 12, FontStyle.Bold), Brushes.Black, bLeftMargin, bLeftMargin)
        End Try

        vFont = New Font("Arial", 10)
        vStringFormat.Alignment = StringAlignment.Near
        vStringFormat.LineAlignment = StringAlignment.Center

        vRect = New Rectangle(bLeftMargin + 44 + 5, bLeftMargin + 2 + 10, e.PageBounds.Width - (bLeftMargin + 44 + 5 + bRightMargin), 21)
        e.Graphics.DrawString("VOX DEI PROTOCOL SYSTEMS INC.", vFont, Brushes.Black, vRect, vStringFormat)

        vFont = New Font("Arial", 10, FontStyle.Bold)
        vRect = New Rectangle(bLeftMargin + 44 + 5, bLeftMargin + 2 + 10 + 21 + 1, e.PageBounds.Width - (bLeftMargin + 44 + 5 + bRightMargin), 21)
        e.Graphics.DrawString(bFormName, vFont, Brushes.Black, vRect, vStringFormat)
    End Sub

    Public Sub PrintFormHeader2(ByVal bLeftMargin As Integer, ByVal bRightMargin As Integer, e As Printing.PrintPageEventArgs, ByVal bFormName As String)
        Dim vLogo As String
        Dim vFound As Boolean
        Dim vFont As Font
        Dim vStringFormat As New StringFormat
        Dim vStringFormat1 As New StringFormat
        Dim vRect As Rectangle
        Dim vRect1 As Rectangle

        '--------------------- company logo ---------------------
        vLogo = Application.StartupPath & "\data\images\vox_logo.jpg"

        vFound = False
        If System.IO.File.Exists(vLogo) = True Then
            vFound = True
        End If

        Try
            e.Graphics.DrawImage(Image.FromFile(vLogo), CInt(e.PageBounds.Width / 2) - 33, bLeftMargin, 66, 66)
        Catch ex As Exception
            e.Graphics.DrawString("LOGO", New Font("Arial", 12, FontStyle.Bold), Brushes.Black, bLeftMargin, CInt(e.PageBounds.Width / 2) - 33)
        End Try

        vFont = New Font("Arial", 18, FontStyle.Bold)
        vStringFormat.Alignment = StringAlignment.Center
        vStringFormat.LineAlignment = StringAlignment.Near

        'vRect = New Rectangle(-33, bLeftMargin + 66 + 50, e.PageBounds.Width, vFont.Height)
        vRect = New Rectangle(bLeftMargin, 170, e.PageBounds.Width - (bLeftMargin * 2), vFont.Height)
        e.Graphics.DrawString(bFormName, vFont, Brushes.Black, vRect, vStringFormat)

        'footer of billing
        vStringFormat1.Alignment = StringAlignment.Near
        'vStringFormat1.LineAlignment = StringAlignment.Near

        vRect1 = New Rectangle(70, 1100, 1600, vFont.Height)
        e.Graphics.DrawString("ACC-FM-04 Effective Date 16 December 2019", New Font("Arial", 10, FontStyle.Bold), Brushes.Gray, vRect1, vStringFormat1)
    End Sub

    Public Sub PrintPetcPerformanceReport(ByRef bSeq As Integer, ByVal bLeftMargin As Integer, ByVal bRightMargin As Integer, ByVal bLineSpace As Integer, _
                            ByVal bDateStart As String, ByVal bDateEnd As String, ByVal bPageNo As Integer, ByVal bListView As ListView, e As Printing.PrintPageEventArgs)
        Dim vFont As Font
        Dim vStringFormat As New StringFormat
        Dim vRect As Rectangle
        Dim vCurrX As Integer = 0
        Dim vCurrY As Integer = 0
        Dim vWidth As Integer = 0
        Dim vCellPaddingTop As Integer = 0
        Dim vCellPaddingLeft As Integer = 0

        Dim vColLeft(18) As Long
        Dim vColWidth(18) As Long

        Dim vSaveYpos As Long

        Dim vCtr As Integer
        Dim vMaxRows As Integer = 0
        Dim vRowCtr As Integer = 0

        Dim vTotGasPassed As Double = 0
        Dim vTotGasFailed As Double = 0
        Dim vTotGasReprint As Double = 0
        Dim vTotGasRetest As Double = 0
        Dim vTotGasInvalid As Double = 0
        Dim vTotGasUploaded As Double = 0
        Dim vTotGasNotUploaded As Double = 0

        Dim vTotDieselPassed As Double = 0
        Dim vTotDieselFailed As Double = 0
        Dim vTotDieselReprint As Double = 0
        Dim vTotDieselRetest As Double = 0
        Dim vTotDieselInvalid As Double = 0
        Dim vTotDieselUploaded As Double = 0
        Dim vTotDieselNotUploaded As Double = 0

        Try
            vColLeft(1) = bLeftMargin
            vColWidth(1) = 200

            vColLeft(2) = vColLeft(1) + vColWidth(1)
            vColWidth(2) = 200

            vColLeft(3) = vColLeft(2) + vColWidth(2)
            vColWidth(3) = 50

            vColLeft(4) = vColLeft(3) + vColWidth(3)
            vColWidth(4) = 50

            vColLeft(5) = vColLeft(4) + vColWidth(4)
            vColWidth(5) = 50

            vColLeft(6) = vColLeft(5) + vColWidth(5)
            vColWidth(6) = 50

            vColLeft(7) = vColLeft(6) + vColWidth(6)
            vColWidth(7) = 50

            vColLeft(8) = vColLeft(7) + vColWidth(7)
            vColWidth(8) = 50

            vColLeft(9) = vColLeft(8) + vColWidth(8)
            vColWidth(9) = 50

            vColLeft(10) = vColLeft(9) + vColWidth(9)
            vColWidth(10) = 50

            vColLeft(11) = vColLeft(10) + vColWidth(10)
            vColWidth(11) = 50

            vColLeft(12) = vColLeft(11) + vColWidth(11)
            vColWidth(12) = 50

            vColLeft(13) = vColLeft(12) + vColWidth(12)
            vColWidth(13) = 50

            vColLeft(14) = vColLeft(13) + vColWidth(13)
            vColWidth(14) = 67

            vCellPaddingTop = 3
            vCellPaddingLeft = 3

            vMaxRows = 34

            vFont = New Font("Arial", 18, FontStyle.Bold)
            vStringFormat.Alignment = StringAlignment.Center
            vStringFormat.LineAlignment = StringAlignment.Center

            '--------------------- print logo header ---------------------

            modPrinting.PrintFormHeader(bLeftMargin, bRightMargin, e, "PETC PERFORMANCE REPORT")

            '--------------------- data ---------------------

            vFont = New Font("Arial", 8, FontStyle.Bold)

            vCurrX = bLeftMargin
            vCurrY = bLeftMargin + 75 + 2
            e.Graphics.DrawString("Data transmission from " & bDateStart & " to " & bDateEnd, vFont, Brushes.Black, vCurrX, vCurrY)

            '--------------------- row data header ---------------------

            vCurrY = vCurrY + vFont.Height + bLineSpace
            vSaveYpos = vCurrY

            'lines
            vCurrX = vColLeft(1)

            vWidth = vColLeft(1) + vColWidth(1) + vColWidth(2) + vColWidth(3) + vColWidth(4) + vColWidth(5) + vColWidth(6) + vColWidth(7) + _
                vColWidth(8) + vColWidth(9) + vColWidth(10) + vColWidth(11) + vColWidth(12) + vColWidth(13) + vColWidth(14)

            e.Graphics.DrawLine(Pens.Black, vCurrX, vCurrY, vWidth, vCurrY)

            'texts
            vFont = New Font("Arial narrow", 8, FontStyle.Bold)
            vStringFormat.Alignment = StringAlignment.Center

            vCurrX = vColLeft(1)
            vWidth = vColWidth(1)
            vRect = New Rectangle(vCurrX, vCurrY + 4, vWidth, vFont.Height)
            e.Graphics.DrawString("PETC Name", vFont, Brushes.Black, vRect, vStringFormat)
            'e.Graphics.DrawRectangle(Pens.Red, vRect)

            vCurrX = vColLeft(2)
            vWidth = vColWidth(2)
            vRect = New Rectangle(vCurrX, vCurrY + 4, vWidth, vFont.Height)
            e.Graphics.DrawString("PETC Address", vFont, Brushes.Black, vRect, vStringFormat)
            'e.Graphics.DrawRectangle(Pens.Red, vRect)

            vStringFormat.Alignment = StringAlignment.Center

            For vCtr = 3 To 7
                vCurrX = vColLeft(vCtr)
                vWidth = vColWidth(vCtr)
                vRect = New Rectangle(vCurrX, vCurrY + 4, vWidth, vFont.Height)

                Select Case vCtr
                    Case 3
                        e.Graphics.DrawString("Passed", vFont, Brushes.Black, vRect, vStringFormat)

                    Case 4
                        e.Graphics.DrawString("Failed", vFont, Brushes.Black, vRect, vStringFormat)

                    Case 5
                        e.Graphics.DrawString("Reprint", vFont, Brushes.Black, vRect, vStringFormat)

                    Case 6
                        e.Graphics.DrawString("Retest", vFont, Brushes.Black, vRect, vStringFormat)

                    Case 7
                        e.Graphics.DrawString("Invalid", vFont, Brushes.Red, vRect, vStringFormat)
                End Select
                'e.Graphics.DrawRectangle(Pens.Red, vRect)
            Next

            For vCtr = 10 To 14
                vCurrX = vColLeft(vCtr - 2)
                vWidth = vColWidth(vCtr - 2)
                vRect = New Rectangle(vCurrX, vCurrY + 4, vWidth, vFont.Height)

                Select Case vCtr
                    Case 10
                        e.Graphics.DrawString("Passed", vFont, Brushes.Black, vRect, vStringFormat)

                    Case 11
                        e.Graphics.DrawString("Failed", vFont, Brushes.Black, vRect, vStringFormat)

                    Case 12
                        e.Graphics.DrawString("Reprint", vFont, Brushes.Black, vRect, vStringFormat)

                    Case 13
                        e.Graphics.DrawString("Retest", vFont, Brushes.Black, vRect, vStringFormat)

                    Case 14
                        e.Graphics.DrawString("Invalid", vFont, Brushes.Red, vRect, vStringFormat)
                End Select
                'e.Graphics.DrawRectangle(Pens.Red, vRect)
            Next

            vCurrX = vColLeft(13)
            vWidth = vColWidth(13)
            vRect = New Rectangle(vCurrX, vCurrY + 4, vWidth, vFont.Height)
            e.Graphics.DrawString("Uploaded", vFont, Brushes.Black, vRect, vStringFormat)
            'e.Graphics.DrawRectangle(Pens.Red, vRect)

            vCurrX = vColLeft(14)
            vWidth = vColWidth(14)
            vRect = New Rectangle(vCurrX, vCurrY + 4, vWidth, vFont.Height)
            e.Graphics.DrawString("Not.Uploaded", vFont, Brushes.Red, vRect, vStringFormat)
            'e.Graphics.DrawRectangle(Pens.Red, vRect)

            'lines
            vCurrY = vCurrY + vFont.Height + bLineSpace

            For vCtr = 1 To 14
                vCurrX = vColLeft(vCtr)
                e.Graphics.DrawLine(Pens.Black, vCurrX, vSaveYpos, vCurrX, vCurrY)
            Next

            vCurrX = vColLeft(14) + vColWidth(14)
            e.Graphics.DrawLine(Pens.Black, vCurrX, vSaveYpos, vCurrX, vCurrY)

            vCurrX = vColLeft(1)
            vWidth = vColLeft(1) + vColWidth(1) + vColWidth(2) + vColWidth(3) + vColWidth(4) + vColWidth(5) + vColWidth(6) + vColWidth(7) + _
                vColWidth(8) + vColWidth(9) + vColWidth(10) + vColWidth(11) + vColWidth(12) + vColWidth(13) + vColWidth(14)

            e.Graphics.DrawLine(Pens.Black, vCurrX, vCurrY, vWidth, vCurrY)

            vCurrY = vCurrY - ((vFont.Height + bLineSpace) * 2)
            vSaveYpos = vCurrY

            e.Graphics.DrawLine(Pens.Black, vColLeft(3), vCurrY, vColLeft(13), vCurrY)

            vCurrX = vColLeft(3)
            vWidth = vColWidth(3) + vColWidth(4) + vColWidth(5) + vColWidth(6) + vColWidth(7)
            vRect = New Rectangle(vCurrX, vCurrY + 4, vWidth, vFont.Height)
            e.Graphics.DrawString("G A S", vFont, Brushes.Black, vRect, vStringFormat)
            'e.Graphics.DrawRectangle(Pens.Red, vRect)

            vCurrX = vColLeft(8)
            vWidth = vColWidth(8) + vColWidth(9) + vColWidth(10) + vColWidth(11) + vColWidth(12)
            vRect = New Rectangle(vCurrX, vCurrY + 4, vWidth, vFont.Height)
            e.Graphics.DrawString("D I E S E L", vFont, Brushes.Black, vRect, vStringFormat)
            'e.Graphics.DrawRectangle(Pens.Red, vRect)

            vCurrY = vCurrY + vFont.Height + bLineSpace
            e.Graphics.DrawLine(Pens.Black, vColLeft(3), vSaveYpos, vColLeft(3), vCurrY)
            e.Graphics.DrawLine(Pens.Black, vColLeft(8), vSaveYpos, vColLeft(8), vCurrY)
            e.Graphics.DrawLine(Pens.Black, vColLeft(13), vSaveYpos, vColLeft(13), vCurrY)

            vCurrY = vCurrY + vFont.Height + bLineSpace
            vSaveYpos = vCurrY

            For vCtr = 1 To vMaxRows
                vCurrY = vCurrY + vFont.Height + bLineSpace
            Next

            e.Graphics.DrawLine(Pens.LightGray, vColLeft(4), vSaveYpos, vColLeft(4), vCurrY)
            e.Graphics.DrawLine(Pens.LightGray, vColLeft(5), vSaveYpos, vColLeft(5), vCurrY)
            e.Graphics.DrawLine(Pens.LightGray, vColLeft(6), vSaveYpos, vColLeft(6), vCurrY)
            e.Graphics.DrawLine(Pens.LightGray, vColLeft(7), vSaveYpos, vColLeft(7), vCurrY)
            e.Graphics.DrawLine(Pens.LightGray, vColLeft(9), vSaveYpos, vColLeft(9), vCurrY)
            e.Graphics.DrawLine(Pens.LightGray, vColLeft(10), vSaveYpos, vColLeft(10), vCurrY)
            e.Graphics.DrawLine(Pens.LightGray, vColLeft(11), vSaveYpos, vColLeft(11), vCurrY)
            e.Graphics.DrawLine(Pens.LightGray, vColLeft(12), vSaveYpos, vColLeft(12), vCurrY)

            vCurrY = vSaveYpos

            vCurrX = vColLeft(1)
            vWidth = vColLeft(1) + vColWidth(1) + vColWidth(2) + vColWidth(3) + vColWidth(4) + vColWidth(5) + vColWidth(6) + vColWidth(7) + _
                vColWidth(8) + vColWidth(9) + vColWidth(10) + vColWidth(11) + vColWidth(12) + vColWidth(13) + vColWidth(14)

            For vCtr = 1 To vMaxRows
                vCurrY = vCurrY + vFont.Height + bLineSpace

                If vCtr Mod 3 = 0 Then e.Graphics.DrawLine(Pens.Black, vCurrX, vCurrY, vWidth, vCurrY)
            Next

            e.Graphics.DrawLine(Pens.Black, vCurrX, vCurrY, vWidth, vCurrY)
            e.Graphics.DrawLine(Pens.Black, vCurrX, vSaveYpos, vCurrX, vCurrY)
            e.Graphics.DrawLine(Pens.Black, vWidth, vSaveYpos, vWidth, vCurrY)

            e.Graphics.DrawLine(Pens.Black, vColLeft(2), vSaveYpos, vColLeft(2), vCurrY)
            e.Graphics.DrawLine(Pens.Black, vColLeft(3), vSaveYpos, vColLeft(3), vCurrY)
            e.Graphics.DrawLine(Pens.Black, vColLeft(8), vSaveYpos, vColLeft(8), vCurrY)
            e.Graphics.DrawLine(Pens.Black, vColLeft(13), vSaveYpos, vColLeft(13), vCurrY)
            e.Graphics.DrawLine(Pens.Black, vColLeft(14), vSaveYpos, vColLeft(14), vCurrY)

            '--------------------- row data (FROM) ---------------------

            vCurrY = vSaveYpos
            vCurrY = vCurrY - vFont.Height
            vSaveYpos = vCurrY

            vRowCtr = 0

            If bListView.Items.Count > 0 Then
                vRowCtr = 1

                vCurrY = vCurrY + vFont.Height + bLineSpace

                Do While vRowCtr <= vMaxRows
                    bSeq = bSeq + 1

                    With bListView.Items(bSeq - 1)
                        vFont = New Font("Arial narrow", 8)

                        vStringFormat.Alignment = StringAlignment.Near

                        vCurrY = vCurrY
                        vCurrX = vColLeft(1) + vCellPaddingLeft
                        vRect = New Rectangle(vCurrX, vCurrY, vColWidth(1) - (vCellPaddingLeft * 2), vFont.Height)
                        e.Graphics.DrawString(.SubItems(1).Text, vFont, Brushes.Black, vRect, vStringFormat)

                        vCurrX = vColLeft(2) + vCellPaddingLeft
                        vRect = New Rectangle(vCurrX, vCurrY, vColWidth(2) - (vCellPaddingLeft * 2), vFont.Height)
                        e.Graphics.DrawString(.SubItems(2).Text, vFont, Brushes.Black, vRect, vStringFormat)

                        vStringFormat.Alignment = StringAlignment.Center

                        For vCtr = 3 To 7
                            If vCtr <> 7 Then
                                vCurrX = vColLeft(vCtr) + vCellPaddingLeft
                                vRect = New Rectangle(vCurrX, vCurrY, vColWidth(vCtr) - (vCellPaddingLeft * 2), vFont.Height)
                                e.Graphics.DrawString(.SubItems(vCtr).Text, vFont, Brushes.Black, vRect, vStringFormat)
                            Else
                                vCurrX = vColLeft(vCtr) + vCellPaddingLeft
                                vRect = New Rectangle(vCurrX, vCurrY, vColWidth(vCtr) - (vCellPaddingLeft * 2), vFont.Height)
                                e.Graphics.DrawString(.SubItems(vCtr).Text, vFont, Brushes.Red, vRect, vStringFormat)
                            End If
                        Next

                        For vCtr = 10 To 14
                            If vCtr <> 14 Then
                                vCurrX = vColLeft(vCtr - 2) + vCellPaddingLeft
                                vRect = New Rectangle(vCurrX, vCurrY, vColWidth(vCtr - 2) - (vCellPaddingLeft * 2), vFont.Height)
                                e.Graphics.DrawString(.SubItems(vCtr).Text, vFont, Brushes.Black, vRect, vStringFormat)
                            Else
                                vCurrX = vColLeft(vCtr - 2) + vCellPaddingLeft
                                vRect = New Rectangle(vCurrX, vCurrY, vColWidth(vCtr - 2) - (vCellPaddingLeft * 2), vFont.Height)
                                e.Graphics.DrawString(.SubItems(vCtr).Text, vFont, Brushes.Red, vRect, vStringFormat)
                            End If
                        Next

                        vCurrX = vColLeft(13) + vCellPaddingLeft
                        vRect = New Rectangle(vCurrX, vCurrY, vColWidth(13) - (vCellPaddingLeft * 2), vFont.Height)
                        e.Graphics.DrawString(.SubItems(17).Text, vFont, Brushes.Black, vRect, vStringFormat)

                        vCurrX = vColLeft(14) + vCellPaddingLeft
                        vRect = New Rectangle(vCurrX, vCurrY, vColWidth(14) - (vCellPaddingLeft * 2), vFont.Height)
                        e.Graphics.DrawString(.SubItems(18).Text, vFont, Brushes.Red, vRect, vStringFormat)

                        vTotGasPassed = vTotGasPassed + CDbl(.SubItems(3).Text)
                        vTotGasFailed = vTotGasFailed + CDbl(.SubItems(4).Text)
                        vTotGasReprint = vTotGasReprint + CDbl(.SubItems(5).Text)
                        vTotGasRetest = vTotGasRetest + CDbl(.SubItems(6).Text)
                        vTotGasInvalid = vTotGasInvalid + CDbl(.SubItems(7).Text)
                        vTotGasUploaded = vTotGasUploaded + CDbl(.SubItems(8).Text)
                        vTotGasNotUploaded = vTotGasNotUploaded + CDbl(.SubItems(9).Text)

                        vTotDieselPassed = vTotDieselPassed + CDbl(.SubItems(10).Text)
                        vTotDieselFailed = vTotDieselFailed + CDbl(.SubItems(11).Text)
                        vTotDieselReprint = vTotDieselReprint + CDbl(.SubItems(12).Text)
                        vTotDieselRetest = vTotDieselRetest + CDbl(.SubItems(13).Text)
                        vTotDieselInvalid = vTotDieselInvalid + CDbl(.SubItems(14).Text)
                        vTotDieselUploaded = vTotDieselUploaded + CDbl(.SubItems(15).Text)
                        vTotDieselNotUploaded = vTotDieselNotUploaded + CDbl(.SubItems(16).Text)
                    End With

                    vRowCtr = vRowCtr + 1
                    vCurrY = vCurrY + vFont.Height + bLineSpace

                    If bSeq >= bListView.Items.Count Then Exit Do

                    If vRowCtr > vMaxRows Then
                        vRowCtr = vRowCtr - 1

                        Exit Do
                    End If
                Loop
            End If

            vFont = New Font("Arial", 8)

            'fill rest of columns with blanks
            If vRowCtr <> vMaxRows Then
                For vCtr = vRowCtr + 1 To vMaxRows
                    vCurrY = vCurrY + vFont.Height + bLineSpace

                    '                    For vCtr2 = 1 To 14
                    ' vCurrX = vColLeft(vCtr2)
                    ' vRect = New Rectangle(vCurrX, vCurrY, vColWidth(vCtr2) - (vCellPaddingLeft * 2), vFont.Height)
                    ' e.Graphics.DrawString("TEST", vFont, Brushes.Black, vRect, vStringFormat)
                    '                Next
                Next vCtr
            End If

            '--------------------- row data footer ---------------------

            vCurrY = vCurrY + vFont.Height

            If bSeq >= bListView.Items.Count Then
                vSaveYpos = vCurrY

                vStringFormat.Alignment = StringAlignment.Far

                vCurrX = vColLeft(2)
                vWidth = vColWidth(2) - (vCellPaddingLeft * 2)
                vRect = New Rectangle(vCurrX, vCurrY + 4, vWidth, vFont.Height)
                e.Graphics.DrawString("T O T A L S", vFont, Brushes.Black, vRect, vStringFormat)
                'e.Graphics.DrawRectangle(Pens.Red, vRect)

                vStringFormat.Alignment = StringAlignment.Center

                vCurrX = vColLeft(3)
                vWidth = vColWidth(3) - (vCellPaddingLeft * 2)
                vRect = New Rectangle(vCurrX, vCurrY + 4, vWidth, vFont.Height)
                e.Graphics.DrawString(vTotGasPassed.ToString("###,###,##0"), vFont, Brushes.Black, vRect, vStringFormat)
                'e.Graphics.DrawRectangle(Pens.Red, vRect)

                vCurrX = vColLeft(4)
                vWidth = vColWidth(4) - (vCellPaddingLeft * 2)
                vRect = New Rectangle(vCurrX, vCurrY + 4, vWidth, vFont.Height)
                e.Graphics.DrawString(vTotGasFailed.ToString("###,###,##0"), vFont, Brushes.Black, vRect, vStringFormat)
                'e.Graphics.DrawRectangle(Pens.Red, vRect)

                vCurrX = vColLeft(5)
                vWidth = vColWidth(5) - (vCellPaddingLeft * 2)
                vRect = New Rectangle(vCurrX, vCurrY + 4, vWidth, vFont.Height)
                e.Graphics.DrawString(vTotGasReprint.ToString("###,###,##0"), vFont, Brushes.Black, vRect, vStringFormat)
                'e.Graphics.DrawRectangle(Pens.Red, vRect)

                vCurrX = vColLeft(6)
                vWidth = vColWidth(6) - (vCellPaddingLeft * 2)
                vRect = New Rectangle(vCurrX, vCurrY + 4, vWidth, vFont.Height)
                e.Graphics.DrawString(vTotGasRetest.ToString("###,###,##0"), vFont, Brushes.Black, vRect, vStringFormat)
                'e.Graphics.DrawRectangle(Pens.Red, vRect)

                vCurrX = vColLeft(7)
                vWidth = vColWidth(7) - (vCellPaddingLeft * 2)
                vRect = New Rectangle(vCurrX, vCurrY + 4, vWidth, vFont.Height)
                e.Graphics.DrawString(vTotGasInvalid.ToString("###,###,##0"), vFont, Brushes.Red, vRect, vStringFormat)
                'e.Graphics.DrawRectangle(Pens.Red, vRect)

                vCurrX = vColLeft(8)
                vWidth = vColWidth(8) - (vCellPaddingLeft * 2)
                vRect = New Rectangle(vCurrX, vCurrY + 4, vWidth, vFont.Height)
                e.Graphics.DrawString(vTotDieselPassed.ToString("###,###,##0"), vFont, Brushes.Black, vRect, vStringFormat)
                'e.Graphics.DrawRectangle(Pens.Red, vRect)

                vCurrX = vColLeft(9)
                vWidth = vColWidth(9) - (vCellPaddingLeft * 2)
                vRect = New Rectangle(vCurrX, vCurrY + 4, vWidth, vFont.Height)
                e.Graphics.DrawString(vTotDieselFailed.ToString("###,###,##0"), vFont, Brushes.Black, vRect, vStringFormat)
                'e.Graphics.DrawRectangle(Pens.Red, vRect)

                vCurrX = vColLeft(10)
                vWidth = vColWidth(10) - (vCellPaddingLeft * 2)
                vRect = New Rectangle(vCurrX, vCurrY + 4, vWidth, vFont.Height)
                e.Graphics.DrawString(vTotDieselReprint.ToString("###,###,##0"), vFont, Brushes.Black, vRect, vStringFormat)
                'e.Graphics.DrawRectangle(Pens.Red, vRect)

                vCurrX = vColLeft(11)
                vWidth = vColWidth(11) - (vCellPaddingLeft * 2)
                vRect = New Rectangle(vCurrX, vCurrY + 4, vWidth, vFont.Height)
                e.Graphics.DrawString(vTotDieselRetest.ToString("###,###,##0"), vFont, Brushes.Black, vRect, vStringFormat)
                'e.Graphics.DrawRectangle(Pens.Red, vRect)

                vCurrX = vColLeft(12)
                vWidth = vColWidth(12) - (vCellPaddingLeft * 2)
                vRect = New Rectangle(vCurrX, vCurrY + 4, vWidth, vFont.Height)
                e.Graphics.DrawString(vTotDieselInvalid.ToString("###,###,##0"), vFont, Brushes.Red, vRect, vStringFormat)
                'e.Graphics.DrawRectangle(Pens.Red, vRect)

                vCurrX = vColLeft(13)
                vWidth = vColWidth(13) - (vCellPaddingLeft * 2)
                vRect = New Rectangle(vCurrX, vCurrY + 4, vWidth, vFont.Height)
                e.Graphics.DrawString((vTotGasUploaded + vTotDieselUploaded).ToString("###,###,##0"), vFont, Brushes.Black, vRect, vStringFormat)
                'e.Graphics.DrawRectangle(Pens.Red, vRect)

                vCurrX = vColLeft(14)
                vWidth = vColWidth(14) - (vCellPaddingLeft * 2)
                vRect = New Rectangle(vCurrX, vCurrY + 4, vWidth, vFont.Height)
                e.Graphics.DrawString((vTotGasNotUploaded + vTotDieselNotUploaded).ToString("###,###,##0"), vFont, Brushes.Red, vRect, vStringFormat)
                'e.Graphics.DrawRectangle(Pens.Red, vRect)

                vCurrY = vCurrY + vFont.Height + bLineSpace
                e.Graphics.DrawLine(Pens.LightGray, vColLeft(4), vSaveYpos, vColLeft(4), vCurrY)
                e.Graphics.DrawLine(Pens.LightGray, vColLeft(5), vSaveYpos, vColLeft(5), vCurrY)
                e.Graphics.DrawLine(Pens.LightGray, vColLeft(6), vSaveYpos, vColLeft(6), vCurrY)
                e.Graphics.DrawLine(Pens.LightGray, vColLeft(7), vSaveYpos, vColLeft(7), vCurrY)
                e.Graphics.DrawLine(Pens.LightGray, vColLeft(9), vSaveYpos, vColLeft(9), vCurrY)
                e.Graphics.DrawLine(Pens.LightGray, vColLeft(10), vSaveYpos, vColLeft(10), vCurrY)
                e.Graphics.DrawLine(Pens.LightGray, vColLeft(11), vSaveYpos, vColLeft(11), vCurrY)
                e.Graphics.DrawLine(Pens.LightGray, vColLeft(12), vSaveYpos, vColLeft(12), vCurrY)

                e.Graphics.DrawLine(Pens.Black, vColLeft(3), vCurrY, vColLeft(14) + vColWidth(14), vCurrY)
                e.Graphics.DrawLine(Pens.Black, vColLeft(3), vSaveYpos, vColLeft(3), vCurrY)
                e.Graphics.DrawLine(Pens.Black, vColLeft(8), vSaveYpos, vColLeft(8), vCurrY)
                e.Graphics.DrawLine(Pens.Black, vColLeft(13), vSaveYpos, vColLeft(13), vCurrY)
                e.Graphics.DrawLine(Pens.Black, vColLeft(14), vSaveYpos, vColLeft(14), vCurrY)
                e.Graphics.DrawLine(Pens.Black, vColLeft(14) + vColWidth(14), vSaveYpos, vColLeft(14) + vColWidth(14), vCurrY)
            Else
                vCurrY = vCurrY + vFont.Height + bLineSpace
            End If

            '--------------------- page footer ---------------------

            vSaveYpos = vCurrY

            vCurrX = vColLeft(1)
            e.Graphics.DrawLine(Pens.Black, vCurrX, vCurrY, vColLeft(14) + vColWidth(14), vCurrY)
            e.Graphics.DrawLine(Pens.Black, vCurrX, vCurrY + 1, vColLeft(14) + vColWidth(14), vCurrY + 1)

            vCurrY = vCurrY + 4

            vFont = New Font("Arial narrow", 6)
            e.Graphics.DrawString("VOX DEI - PETC PERFORMANCE REPORT" & Space(20) & _
                                  "Generated by: " & Trim(pUserID) & Space(10) & _
                                  "Date and time generated: " & CDate(DateTime.Now).ToString("MM/dd/yyyy HH:mm:ss"), vFont, Brushes.Black, vCurrX, vCurrY)

            vFont = New Font("Arial", 8)
            vStringFormat.Alignment = StringAlignment.Far

            vCurrX = vColLeft(13)
            vWidth = vColWidth(13) + vColWidth(14)
            vRect = New Rectangle(vCurrX, vCurrY + 4, vWidth, vFont.Height)
            e.Graphics.DrawString("Page " & Trim(Str(bPageNo)), vFont, Brushes.Black, vRect, vStringFormat)

            '--------------------- end of page ---------------------
        Catch ex As Exception
        End Try
    End Sub

    Public Sub PrintPetcBillingReport2(ByRef bSeq As Integer, ByVal bLeftMargin As Integer, ByVal bRightMargin As Integer, ByVal bLineSpace As Integer, _
                            ByVal bListView As ListView, e As Printing.PrintPageEventArgs)
        Dim vFont As Font
        Dim vStringFormat As New StringFormat
        Dim vRect As Rectangle
        Dim vCurrX As Integer = 0
        Dim vCurrY As Integer = 0
        Dim vWidth As Integer = 0
        Dim vCellPaddingTop As Integer = 0
        Dim vCellPaddingLeft As Integer = 0

        Dim vColLeft(5) As Long
        Dim vColWidth(5) As Long

        Try
            vColLeft(1) = bLeftMargin
            vColWidth(1) = 130

            vColLeft(2) = vColLeft(1) + vColWidth(1)
            vColWidth(2) = 180

            vColLeft(3) = vColLeft(2) + vColWidth(2)
            vColWidth(3) = 100

            vColLeft(4) = vColLeft(3) + vColWidth(3)
            vColWidth(4) = 100

            vColLeft(5) = vColLeft(4) + vColWidth(4)
            vColWidth(5) = 140

            vCellPaddingTop = 3
            vCellPaddingLeft = 3

            vFont = New Font("Arial", 18, FontStyle.Bold)
            vStringFormat.Alignment = StringAlignment.Center
            vStringFormat.LineAlignment = StringAlignment.Center

            '--------------------- print logo header ---------------------

            modPrinting.PrintFormHeader2(bLeftMargin, bRightMargin, e, "WEEKLY BILLING STATEMENT")

            '--------------------- data ---------------------

            bSeq = bSeq + 1

            vFont = New Font("Arial", 10)

            vCurrX = bLeftMargin
            vCurrY = bLeftMargin + 200
            e.Graphics.DrawString(bListView.Items(bSeq - 1).SubItems(4).Text & ":", vFont, Brushes.Black, vCurrX, vCurrY)

            vCurrY = vCurrY + vFont.Height + bLineSpace

            vCurrY = vCurrY + vFont.Height + bLineSpace
            e.Graphics.DrawString("Here is your data transmission bill for the period of " & bListView.Items(bSeq - 1).Text & " - " & _
                                  bListView.Items(bSeq - 1).SubItems(1).Text & ".,", vFont, Brushes.Black, vCurrX, vCurrY)

            vCurrY = vCurrY + vFont.Height + bLineSpace
            e.Graphics.DrawString("further details are indicated below. You can go to your nearest bank and pay the amount owed", vFont, Brushes.Black, vCurrX, vCurrY)

            vCurrY = vCurrY + vFont.Height + bLineSpace
            e.Graphics.DrawString("to us or you can drop by at our office from 8:00 AM to 5:00 PM during weekdays and from 12:00 PM - ", vFont, Brushes.Black, vCurrX, vCurrY)

            vCurrY = vCurrY + vFont.Height + bLineSpace
            e.Graphics.DrawString("5:00 PM on Saturdays and Sundays.", vFont, Brushes.Black, vCurrX, vCurrY)

            vCurrY = vCurrY + vFont.Height + bLineSpace

            vCurrY = vCurrY + vFont.Height + bLineSpace
            e.Graphics.DrawString("If you have any questions regarding this bill, please feel free to contact us at 02-423-0646 during office", vFont, Brushes.Black, vCurrX, vCurrY)

            vCurrY = vCurrY + vFont.Height + bLineSpace
            e.Graphics.DrawString("hours.", vFont, Brushes.Black, vCurrX, vCurrY)

            vCurrY = vCurrY + vFont.Height + bLineSpace

            vCurrY = vCurrY + vFont.Height + bLineSpace
            e.Graphics.DrawString("Thank you for your attention. Please disregard this statement if payment has already been made.", vFont, Brushes.Black, vCurrX, vCurrY)

            '--------------------- row data header ---------------------

            vCurrY = vCurrY + vFont.Height + bLineSpace
            vCurrY = vCurrY + vFont.Height + bLineSpace
            vCurrY = vCurrY + vFont.Height + bLineSpace

            vWidth = vColWidth(1) + vColWidth(2) + vColWidth(3) + vColWidth(4) + vColWidth(5)
            e.Graphics.DrawLine(Pens.Black, vColLeft(1), vCurrY, vColLeft(1) + vWidth, vCurrY)

            vCurrY = vCurrY + bLineSpace

            vFont = New Font("Arial", 9, FontStyle.Bold)
            vStringFormat.Alignment = StringAlignment.Center

            vCurrX = vColLeft(1)
            vWidth = vColWidth(1)
            vRect = New Rectangle(vCurrX, vCurrY, vWidth, vFont.Height)
            e.Graphics.DrawString("Account Number", vFont, Brushes.Black, vRect, vStringFormat)

            vCurrX = vColLeft(2)
            vWidth = vColWidth(2)
            vRect = New Rectangle(vCurrX, vCurrY, vWidth, vFont.Height)
            e.Graphics.DrawString("Number of Transactions", vFont, Brushes.Black, vRect, vStringFormat)

            vCurrX = vColLeft(3)
            vWidth = vColWidth(3)
            vRect = New Rectangle(vCurrX, vCurrY, vWidth, vFont.Height)
            e.Graphics.DrawString("Billing Period", vFont, Brushes.Black, vRect, vStringFormat)

            vCurrX = vColLeft(4)
            vWidth = vColWidth(4)
            vRect = New Rectangle(vCurrX, vCurrY, vWidth, vFont.Height)
            e.Graphics.DrawString("Due Date", vFont, Brushes.Black, vRect, vStringFormat)

            vCurrX = vColLeft(5)
            vWidth = vColWidth(5)
            vRect = New Rectangle(vCurrX, vCurrY, vWidth, vFont.Height)
            e.Graphics.DrawString("Amount Due", vFont, Brushes.Black, vRect, vStringFormat)

            vCurrY = vCurrY + vFont.Height + bLineSpace
            'vCurrY = vCurrY + bLineSpace

            vWidth = vColWidth(1) + vColWidth(2) + vColWidth(3) + vColWidth(4) + vColWidth(5)
            e.Graphics.DrawLine(Pens.Black, vColLeft(1), vCurrY, vColLeft(1) + vWidth, vCurrY)

            '--------------------- row data (FROM) ---------------------

            vCurrY = vCurrY + bLineSpace

            vFont = New Font("Arial", 9)
            vStringFormat.Alignment = StringAlignment.Center

            vCurrX = vColLeft(1)
            vWidth = vColWidth(1)
            vRect = New Rectangle(vCurrX, vCurrY, vWidth, vFont.Height)
            e.Graphics.DrawString(bListView.Items(bSeq - 1).SubItems(3).Text, vFont, Brushes.Black, vRect, vStringFormat)

            vCurrX = vColLeft(2)
            vWidth = vColWidth(2)
            vRect = New Rectangle(vCurrX, vCurrY, vWidth, vFont.Height)
            e.Graphics.DrawString(bListView.Items(bSeq - 1).SubItems(7).Text, vFont, Brushes.Black, vRect, vStringFormat)

            vCurrX = vColLeft(3)
            vWidth = vColWidth(3)
            vRect = New Rectangle(vCurrX, vCurrY, vWidth, vFont.Height)
            e.Graphics.DrawString(bListView.Items(bSeq - 1).Text, vFont, Brushes.Black, vRect, vStringFormat)

            vCurrX = vColLeft(4)
            vWidth = vColWidth(4)
            vRect = New Rectangle(vCurrX, vCurrY, vWidth, vFont.Height)
            e.Graphics.DrawString(bListView.Items(bSeq - 1).SubItems(2).Text, vFont, Brushes.Black, vRect, vStringFormat)

            vCurrX = vColLeft(5)
            vWidth = vColWidth(5)
            vRect = New Rectangle(vCurrX, vCurrY, vWidth, vFont.Height)
            e.Graphics.DrawString(bListView.Items(bSeq - 1).SubItems(5).Text, vFont, Brushes.Black, vRect, vStringFormat)

            '--------------------- row data footer ---------------------

            vCurrY = vCurrY + vFont.Height + bLineSpace
            'vCurrY = vCurrY + bLineSpace

            vWidth = vColWidth(1) + vColWidth(2) + vColWidth(3) + vColWidth(4) + vColWidth(5)
            e.Graphics.DrawLine(Pens.Black, vColLeft(1), vCurrY, vColLeft(1) + vWidth, vCurrY)

            vCurrY = vCurrY + bLineSpace
            vCurrY = vCurrY + bLineSpace

            vFont = New Font("Arial", 10, FontStyle.Bold)

            vCurrX = vColLeft(1)
            e.Graphics.DrawString("Total Amount Owed: " & bListView.Items(bSeq - 1).SubItems(6).Text, vFont, Brushes.Black, vCurrX, vCurrY)

            vCurrY = vCurrY + vFont.Height + bLineSpace
            vCurrY = vCurrY + bLineSpace

            vWidth = vColWidth(1) + vColWidth(2) + vColWidth(3) + vColWidth(4) + vColWidth(5)
            e.Graphics.DrawLine(Pens.Black, vColLeft(1), vCurrY, vColLeft(1) + vWidth, vCurrY)

            '--------------------- page footer ---------------------

            vFont = New Font("Arial", 9)

            vCurrY = vCurrY + vFont.Height + bLineSpace
            vCurrY = vCurrY + vFont.Height + bLineSpace
            vCurrY = vCurrY + vFont.Height + bLineSpace
            vCurrY = vCurrY + vFont.Height + bLineSpace
            vCurrY = vCurrY + vFont.Height + bLineSpace

            vCurrX = vColLeft(1)
            e.Graphics.DrawString("Sincerely,", vFont, Brushes.Black, vCurrX, vCurrY)

            vCurrY = vCurrY + vFont.Height + bLineSpace
            e.Graphics.DrawString("Finance & Billing Department", vFont, Brushes.Black, vCurrX, vCurrY)

            vCurrY = vCurrY + vFont.Height + bLineSpace
            e.Graphics.DrawString("Vox Dei Systems, Inc.", vFont, Brushes.Black, vCurrX, vCurrY)

            vCurrY = vCurrY + vFont.Height + bLineSpace
            vCurrY = vCurrY + vFont.Height + bLineSpace
            vCurrY = vCurrY + vFont.Height + bLineSpace
            vCurrY = vCurrY + vFont.Height + bLineSpace
            vCurrY = vCurrY + vFont.Height + bLineSpace
            vCurrY = vCurrY + vFont.Height + bLineSpace
            vCurrY = vCurrY + vFont.Height + bLineSpace
            vCurrY = vCurrY + vFont.Height + bLineSpace
            vCurrY = vCurrY + vFont.Height + bLineSpace
            vCurrY = vCurrY + vFont.Height + bLineSpace
            vCurrY = vCurrY + vFont.Height + bLineSpace
            vCurrY = vCurrY + vFont.Height + bLineSpace

            vFont = New Font("Arial", 8)

            vCurrX = vColLeft(1)
            e.Graphics.DrawString("This is a system generated report.", vFont, Brushes.Black, vCurrX, vCurrY)

            e.Graphics.DrawString("Page 1 of 1", vFont, Brushes.Black, 650, vCurrY)

            '--------------------- end of page ---------------------
        Catch ex As Exception
        End Try
    End Sub

    Public Sub PrintPetcBillingReport(ByRef bSeq As Integer, ByVal bLeftMargin As Integer, ByVal bRightMargin As Integer, ByVal bLineSpace As Integer, _
                            ByRef bFirstPage As Boolean, ByRef bDetailsSeq As Integer, ByRef bDetailsSeqPrint As Integer, ByRef bTotalCredit As Double, _
                            ByRef bPrintFooter As Boolean, ByRef bPrintDetails As Boolean, ByVal bAccountType As String, ByVal bPetcAddress As String, _
                            ByVal bDueDate As String, ByVal bListView As ListView, ByVal bListDetails As ListView, e As Printing.PrintPageEventArgs)
        Dim vFont As Font
        Dim vStringFormat As New StringFormat
        Dim vRect As Rectangle
        Dim vCurrX As Integer = 0
        Dim vCurrY As Integer = 0
        Dim vWidth As Integer = 0
        Dim vCellPaddingTop As Integer = 0
        Dim vCellPaddingLeft As Integer = 0

        Dim vColLeft(5) As Long
        Dim vColWidth(5) As Long
        Dim vCtr As Integer
        Dim vTmpStr As String

        Try
            vColLeft(1) = bLeftMargin
            vColWidth(1) = 100

            vColLeft(2) = vColLeft(1) + vColWidth(1)
            vColWidth(2) = 180

            vColLeft(3) = vColLeft(2) + vColWidth(2)
            vColWidth(3) = 230

            vColLeft(4) = vColLeft(3) + vColWidth(3)
            vColWidth(4) = 140

            vCellPaddingTop = 3
            vCellPaddingLeft = 3

            vFont = New Font("Arial", 18, FontStyle.Bold)
            vStringFormat.Alignment = StringAlignment.Center
            vStringFormat.LineAlignment = StringAlignment.Center

            '--------------------- print logo header ---------------------

            Select Case LCase(bAccountType)
                Case "post-paid"
                    modPrinting.PrintFormHeader2(bLeftMargin, bRightMargin, e, "BILLING STATEMENT")

                Case Else
                    'modPrinting.PrintFormHeader2(bLeftMargin, bRightMargin, e, "STATEMENT OF ACCOUNT")
                    modPrinting.PrintFormHeader2(bLeftMargin, bRightMargin, e, "BILLING STATEMENT")
            End Select

            '--------------------- data ---------------------

            vFont = New Font("Arial", 10)

            vCurrX = bLeftMargin
            vCurrY = 230

            If bFirstPage = True Then
                vFont = New Font("Arial", 10, FontStyle.Bold)
                e.Graphics.DrawString(bListView.Items(bSeq - 1).SubItems(3).Text & ":", vFont, Brushes.Black, vCurrX, vCurrY)

                vCurrY = vCurrY + vFont.Height + bLineSpace
                vFont = New Font("Arial", 8)
                e.Graphics.DrawString("(" & Trim(bPetcAddress) & ")", vFont, Brushes.Black, vCurrX, vCurrY)

                vFont = New Font("Arial", 10)

                vCurrY = vCurrY + vFont.Height + bLineSpace
                vCurrY = vCurrY + vFont.Height + bLineSpace

                Select Case LCase(bAccountType)
                    Case "post-paid"
                        e.Graphics.DrawString("Here is your data transmission bill for the period of " & bListView.Items(bSeq - 1).SubItems(4).Text & " to " & _
                                              bListView.Items(bSeq - 1).SubItems(5).Text & ", further details are", vFont, Brushes.Black, vCurrX, vCurrY)

                    Case Else
                        e.Graphics.DrawString("Here is your statement for the period of " & bListView.Items(bSeq - 1).SubItems(4).Text & " to " & _
                                              bListView.Items(bSeq - 1).SubItems(5).Text & ", further details are indicated below.", vFont, Brushes.Black, vCurrX, vCurrY)
                End Select

                Select Case LCase(bAccountType)
                    Case "post-paid"
                        vCurrY = vCurrY + vFont.Height + bLineSpace
                        e.Graphics.DrawString("indicated below. You can go to your nearest bank and pay the amount owed to us or you can drop by at", vFont, Brushes.Black, vCurrX, vCurrY)

                    Case Else
                End Select

                Select Case LCase(bAccountType)
                    Case "post-paid"
                        vCurrY = vCurrY + vFont.Height + bLineSpace
                        e.Graphics.DrawString("our office from 8:00 AM to 5:00 PM during weekdays and from 12:00 PM to 5:00 PM on Saturdays. ", vFont, Brushes.Black, vCurrX, vCurrY)

                    Case Else
                End Select

                vCurrY = vCurrY + vFont.Height + bLineSpace

                vCurrY = vCurrY + vFont.Height + bLineSpace
                Select Case LCase(bAccountType)
                    Case "post-paid"
                        e.Graphics.DrawString("If you have any questions regarding this bill, please feel free to contact us at 02-423-0646 during office", vFont, Brushes.Black, vCurrX, vCurrY)

                    Case Else
                        e.Graphics.DrawString("If you have any questions regarding this statement, please feel free to contact us at 02-423-0646 during office", vFont, Brushes.Black, vCurrX, vCurrY)
                End Select

                vCurrY = vCurrY + vFont.Height + bLineSpace
                e.Graphics.DrawString("hours.", vFont, Brushes.Black, vCurrX, vCurrY)

                vCurrY = vCurrY + vFont.Height + bLineSpace

                vCurrY = vCurrY + vFont.Height + bLineSpace
                e.Graphics.DrawString("Thank you for your attention. Please disregard this statement if payment has already been made.", vFont, Brushes.Black, vCurrX, vCurrY)

                vCurrY = vCurrY + vFont.Height + bLineSpace
                vCurrY = vCurrY + vFont.Height + bLineSpace

                '--------------------- row data header (charges) ---------------------

                vFont = New Font("Arial", 10, FontStyle.Bold)

                e.Graphics.DrawString("CHARGES: (Details attached seperately)", vFont, Brushes.Black, vCurrX, vCurrY)

                vFont = New Font("Arial", 10)

                vCurrY = vCurrY + vFont.Height + bLineSpace
                vWidth = vColWidth(1) + vColWidth(2) + vColWidth(3) + vColWidth(4)
                e.Graphics.DrawLine(Pens.Black, vColLeft(1), vCurrY, vColLeft(1) + vWidth, vCurrY)

                vCurrY = vCurrY + bLineSpace

                vFont = New Font("Arial", 9, FontStyle.Bold)
                vStringFormat.Alignment = StringAlignment.Center

                vCurrX = vColLeft(1)
                vWidth = vColWidth(1)
                vRect = New Rectangle(vCurrX, vCurrY, vWidth, vFont.Height)
                e.Graphics.DrawString("Account No.", vFont, Brushes.Black, vRect, vStringFormat)

                vCurrX = vColLeft(2)
                vWidth = vColWidth(2)
                vRect = New Rectangle(vCurrX, vCurrY, vWidth, vFont.Height)
                e.Graphics.DrawString("Number of Transactions", vFont, Brushes.Black, vRect, vStringFormat)

                vCurrX = vColLeft(3)
                vWidth = vColWidth(3)
                vRect = New Rectangle(vCurrX, vCurrY, vWidth, vFont.Height)
                e.Graphics.DrawString("Period", vFont, Brushes.Black, vRect, vStringFormat)

                vStringFormat.Alignment = StringAlignment.Far

                vCurrX = vColLeft(4)
                vWidth = vColWidth(4)
                vRect = New Rectangle(vCurrX, vCurrY, vWidth, vFont.Height)
                e.Graphics.DrawString("Amount", vFont, Brushes.Black, vRect, vStringFormat)

                vCurrY = vCurrY + vFont.Height + bLineSpace
                'vCurrY = vCurrY + bLineSpace

                vWidth = vColWidth(1) + vColWidth(2) + vColWidth(3) + vColWidth(4)
                e.Graphics.DrawLine(Pens.Black, vColLeft(1), vCurrY, vColLeft(1) + vWidth, vCurrY)

                '--------------------- row data (charges) ---------------------

                vCurrY = vCurrY + bLineSpace

                vFont = New Font("Arial", 9)
                vStringFormat.Alignment = StringAlignment.Center

                vCurrX = vColLeft(1)
                vWidth = vColWidth(1)
                vRect = New Rectangle(vCurrX, vCurrY, vWidth, vFont.Height)
                e.Graphics.DrawString(bListView.Items(bSeq - 1).SubItems(1).Text, vFont, Brushes.Black, vRect, vStringFormat)

                vCurrX = vColLeft(2)
                vWidth = vColWidth(2)
                vRect = New Rectangle(vCurrX, vCurrY, vWidth, vFont.Height)
                e.Graphics.DrawString(CInt(bListView.Items(bSeq - 1).SubItems(7).Text).ToString, vFont, Brushes.Black, vRect, vStringFormat)

                vCurrX = vColLeft(3)
                vWidth = vColWidth(3)
                vRect = New Rectangle(vCurrX, vCurrY, vWidth, vFont.Height)
                e.Graphics.DrawString(bListView.Items(bSeq - 1).SubItems(4).Text & " to " & bListView.Items(bSeq - 1).SubItems(5).Text, _
                                      vFont, Brushes.Black, vRect, vStringFormat)

                vStringFormat.Alignment = StringAlignment.Far

                vCurrX = vColLeft(4)
                vWidth = vColWidth(4)
                vRect = New Rectangle(vCurrX, vCurrY, vWidth, vFont.Height)
                e.Graphics.DrawString(bListView.Items(bSeq - 1).SubItems(9).Text, vFont, Brushes.Black, vRect, vStringFormat)

                vCurrY = vCurrY + vFont.Height + bLineSpace
                vCurrY = vCurrY + vFont.Height + bLineSpace
            End If

            If bPrintDetails = False Then
                '--------------------- row data header (payments) ---------------------

                vColLeft(1) = bLeftMargin
                vColWidth(1) = 100

                vColLeft(2) = vColLeft(1) + vColWidth(1)
                vColWidth(2) = 200

                vColLeft(3) = vColLeft(2) + vColWidth(2)
                vColWidth(3) = 210

                vColLeft(4) = vColLeft(3) + vColWidth(3)
                vColWidth(4) = 140

                vCurrX = vColLeft(1)

                Select Case LCase(bAccountType)
                    Case "post-paid"

                    Case Else
                        vFont = New Font("Arial", 10, FontStyle.Bold)

                        e.Graphics.DrawString("PAYMENTS:", vFont, Brushes.Black, vCurrX, vCurrY)

                        vFont = New Font("Arial", 10)
                        vCurrY = vCurrY + vFont.Height + bLineSpace

                        vWidth = vColWidth(1) + vColWidth(2) + vColWidth(3) + vColWidth(4)
                        e.Graphics.DrawLine(Pens.Black, vColLeft(1), vCurrY, vColLeft(1) + vWidth, vCurrY)

                        vCurrY = vCurrY + bLineSpace

                        vFont = New Font("Arial", 9, FontStyle.Bold)
                        vStringFormat.Alignment = StringAlignment.Center

                        vCurrX = vColLeft(1)
                        vWidth = vColWidth(1)
                        vRect = New Rectangle(vCurrX, vCurrY, vWidth, vFont.Height)
                        e.Graphics.DrawString("Period", vFont, Brushes.Black, vRect, vStringFormat)

                        vCurrX = vColLeft(2)
                        vWidth = vColWidth(2)
                        vRect = New Rectangle(vCurrX, vCurrY, vWidth, vFont.Height)
                        e.Graphics.DrawString("Bank / Account no.", vFont, Brushes.Black, vRect, vStringFormat)

                        vCurrX = vColLeft(3)
                        vWidth = vColWidth(3)
                        vRect = New Rectangle(vCurrX, vCurrY, vWidth, vFont.Height)
                        e.Graphics.DrawString("Details", vFont, Brushes.Black, vRect, vStringFormat)

                        vStringFormat.Alignment = StringAlignment.Far

                        vCurrX = vColLeft(4)
                        vWidth = vColWidth(4)
                        vRect = New Rectangle(vCurrX, vCurrY, vWidth, vFont.Height)
                        e.Graphics.DrawString("Amount", vFont, Brushes.Black, vRect, vStringFormat)

                        vCurrY = vCurrY + vFont.Height + bLineSpace
                        'vCurrY = vCurrY + bLineSpace

                        vWidth = vColWidth(1) + vColWidth(2) + vColWidth(3) + vColWidth(4)
                        e.Graphics.DrawLine(Pens.Black, vColLeft(1), vCurrY, vColLeft(1) + vWidth, vCurrY)

                        '--------------------- row data (payments) ---------------------

                        vCurrY = vCurrY + bLineSpace

                        bDetailsSeq = bDetailsSeq + 1

                        For vCtr = bDetailsSeq To bListDetails.Items.Count
                            If CDbl(bListDetails.Items(vCtr - 1).SubItems(4).Text) <> 0 Then
                                bDetailsSeqPrint = bDetailsSeqPrint + 1

                                vFont = New Font("Arial", 9)
                                vStringFormat.Alignment = StringAlignment.Center

                                vCurrX = vColLeft(1)
                                vWidth = vColWidth(1)
                                vRect = New Rectangle(vCurrX, vCurrY, vWidth, vFont.Height)
                                e.Graphics.DrawString(CDate(bListDetails.Items(vCtr - 1).Text).ToString("MM/dd/yyyy"), vFont, Brushes.Black, vRect, vStringFormat)

                                Dim vTmpBank As String = ""
                                Dim vTmpAccountNo As String = ""
                                Dim vTmpType As String = ""
                                Dim vTmpDetails As String = ""

                                vTmpStr = bListDetails.Items(vCtr - 1).SubItems(6).Text
                                vTmpBank = Mid(vTmpStr, 7)
                                vTmpBank = Mid(vTmpBank, 1, InStr(vTmpBank, "Account no.:") - 3)

                                vTmpStr = bListDetails.Items(vCtr - 1).SubItems(6).Text
                                vTmpAccountNo = Mid(vTmpStr, InStr(vTmpStr, "Account no.:") + 13)
                                vTmpAccountNo = Mid(vTmpAccountNo, 1, InStr(vTmpAccountNo, "Type:") - 3)

                                vCurrX = vColLeft(2)
                                vWidth = vColWidth(2)
                                vRect = New Rectangle(vCurrX, vCurrY, vWidth, vFont.Height)
                                e.Graphics.DrawString(vTmpBank & " " & vTmpAccountNo, vFont, Brushes.Black, vRect, vStringFormat)

                                vTmpStr = bListDetails.Items(vCtr - 1).SubItems(6).Text
                                vTmpType = Mid(vTmpStr, InStr(vTmpStr, "Type:") + 6)
                                vTmpType = Mid(vTmpType, 1, InStr(vTmpType, "Payment details:") - 3)

                                vTmpStr = bListDetails.Items(vCtr - 1).SubItems(6).Text
                                vTmpDetails = Mid(vTmpStr, InStr(vTmpStr, "Payment details:") + 17)
                                vTmpDetails = Mid(vTmpDetails, 1, InStr(vTmpDetails, "Period:") - 3)

                                vCurrX = vColLeft(3)
                                vWidth = vColWidth(3)
                                vRect = New Rectangle(vCurrX, vCurrY, vWidth, vFont.Height)
                                e.Graphics.DrawString(vTmpType & " " & vTmpDetails, vFont, Brushes.Black, vRect, vStringFormat)

                                vStringFormat.Alignment = StringAlignment.Far

                                vCurrX = vColLeft(4)
                                vWidth = vColWidth(4)
                                vRect = New Rectangle(vCurrX, vCurrY, vWidth, vFont.Height)
                                e.Graphics.DrawString(bListDetails.Items(vCtr - 1).SubItems(4).Text, vFont, Brushes.Black, vRect, vStringFormat)

                                bTotalCredit = bTotalCredit + CDbl(bListDetails.Items(vCtr - 1).SubItems(4).Text)

                                vCurrY = vCurrY + vFont.Height + bLineSpace

                                If bFirstPage = True Then
                                    If bDetailsSeqPrint >= 22 Then
                                        bDetailsSeqPrint = 0
                                        bFirstPage = False

                                        Exit Sub
                                    End If
                                Else
                                    If bDetailsSeqPrint >= 40 Then
                                        bDetailsSeqPrint = 0
                                        bFirstPage = False

                                        Exit Sub
                                    End If
                                End If
                            End If

                            bDetailsSeq = bDetailsSeq + 1
                        Next

                        vStringFormat.Alignment = StringAlignment.Far

                        vCurrX = vColLeft(4)
                        vWidth = vColWidth(4)
                        vRect = New Rectangle(vCurrX, vCurrY, vWidth, vFont.Height)
                        e.Graphics.DrawString("----------------------------", vFont, Brushes.Black, vRect, vStringFormat)

                        vCurrY = vCurrY + vFont.Height

                        vFont = New Font("Arial", 9, FontStyle.Bold)

                        vCurrX = vColLeft(3)
                        vWidth = vColWidth(3)
                        vRect = New Rectangle(vCurrX, vCurrY, vWidth, vFont.Height)
                        e.Graphics.DrawString("T O T A L", vFont, Brushes.Black, vRect, vStringFormat)

                        vCurrX = vColLeft(4)
                        vWidth = vColWidth(4)
                        vRect = New Rectangle(vCurrX, vCurrY, vWidth, vFont.Height)
                        e.Graphics.DrawString(bTotalCredit.ToString("###,###,###,##0.00"), vFont, Brushes.Black, vRect, vStringFormat)

                        vFont = New Font("Arial", 9)

                        vCurrY = vCurrY + vFont.Height + bLineSpace
                End Select

                '--------------------- row data footer ---------------------

                vCurrY = vCurrY + bLineSpace

                vWidth = vColWidth(1) + vColWidth(2) + vColWidth(3) + vColWidth(4)
                e.Graphics.DrawLine(Pens.Black, vColLeft(1), vCurrY, vColLeft(1) + vWidth, vCurrY)

                vCurrY = vCurrY + bLineSpace
                vCurrY = vCurrY + bLineSpace

                vFont = New Font("Arial", 10, FontStyle.Bold)

                vCurrX = vColLeft(1)
                Select Case LCase(bAccountType)
                    Case "post-paid"
                        vCurrX = vColLeft(1)
                        e.Graphics.DrawString("TOTAL AMOUNT DUE:" & Space(5) & bListView.Items(bSeq - 1).SubItems(9).Text, vFont, Brushes.Black, vCurrX, vCurrY)

                        vWidth = vColWidth(4)

                        vCurrX = vColLeft(1) + 375
                        vRect = New Rectangle(vCurrX, vCurrY, vWidth * 1.5, vFont.Height)
                        e.Graphics.DrawString("DUE DATE: " & bDueDate, vFont, Brushes.Black, vRect, vStringFormat)

                    Case Else
                        e.Graphics.DrawString("Beginning balance", vFont, Brushes.Black, vCurrX, vCurrY)

                        vCurrX = vColLeft(1) + 150
                        vWidth = vColWidth(4)
                        vRect = New Rectangle(vCurrX, vCurrY, vWidth, vFont.Height)
                        'e.Graphics.DrawString((CDbl(bListView.Items(bSeq - 1).SubItems(8).Text) * -1).ToString("###,###,###,##0.00"), vFont, Brushes.Black, vRect, vStringFormat)
                        e.Graphics.DrawString(CDbl(bListView.Items(bSeq - 1).SubItems(8).Text).ToString("###,###,###,##0.00"), vFont, Brushes.Black, vRect, vStringFormat)

                        vCurrY = vCurrY + vFont.Height + bLineSpace
                        vCurrY = vCurrY + bLineSpace

                        vCurrX = vColLeft(1)
                        'e.Graphics.DrawString("(plus) Charges", vFont, Brushes.Black, vCurrX, vCurrY)
                        e.Graphics.DrawString("(less) Charges", vFont, Brushes.Black, vCurrX, vCurrY)

                        vCurrX = vColLeft(1) + 150
                        vWidth = vColWidth(4)
                        vRect = New Rectangle(vCurrX, vCurrY, vWidth, vFont.Height)
                        e.Graphics.DrawString(bListView.Items(bSeq - 1).SubItems(9).Text, vFont, Brushes.Black, vRect, vStringFormat)

                        vCurrY = vCurrY + vFont.Height + bLineSpace

                        vCurrX = vColLeft(1)
                        'e.Graphics.DrawString("(less) Payments", vFont, Brushes.Black, vCurrX, vCurrY)
                        e.Graphics.DrawString("(plus) Payments", vFont, Brushes.Black, vCurrX, vCurrY)

                        vCurrX = vColLeft(1) + 150
                        vWidth = vColWidth(4)
                        vRect = New Rectangle(vCurrX, vCurrY, vWidth, vFont.Height)
                        e.Graphics.DrawString(bListView.Items(bSeq - 1).SubItems(10).Text, vFont, Brushes.Black, vRect, vStringFormat)

                        vCurrY = vCurrY + vFont.Height + bLineSpace
                        vCurrY = vCurrY + bLineSpace

                        vCurrX = vColLeft(1)
                        'e.Graphics.DrawString("TOTAL AMOUNT DUE", vFont, Brushes.Black, vCurrX, vCurrY)
                        e.Graphics.DrawString("Total Remaining Balance", vFont, Brushes.Black, vCurrX, vCurrY)

                        vCurrX = vColLeft(1) + 150
                        vWidth = vColWidth(4)
                        vRect = New Rectangle(vCurrX, vCurrY, vWidth, vFont.Height)

                        e.Graphics.DrawString(CDbl(bListView.Items(bSeq - 1).SubItems(11).Text).ToString("###,###,###,##0.00"), _
                                              vFont, Brushes.Black, vRect, vStringFormat)

                        'vCurrX = vColLeft(1) + 375
                        'vRect = New Rectangle(vCurrX, vCurrY, vWidth * 1.5, vFont.Height)
                        'e.Graphics.DrawString("DUE DATE: " & bDueDate, vFont, Brushes.Black, vRect, vStringFormat)
                End Select

                vCurrY = vCurrY + vFont.Height + bLineSpace
                vCurrY = vCurrY + bLineSpace

                vWidth = vColWidth(1) + vColWidth(2) + vColWidth(3) + vColWidth(4) + vColWidth(5)
                e.Graphics.DrawLine(Pens.Black, vColLeft(1), vCurrY, vColLeft(1) + vWidth, vCurrY)

                '--------------------- page footer ---------------------

                vFont = New Font("Arial", 9)

                vCurrY = vCurrY + vFont.Height + bLineSpace

                vCurrX = vColLeft(1)
                e.Graphics.DrawString("Sincerely,", vFont, Brushes.Black, vCurrX, vCurrY)

                vCurrY = vCurrY + vFont.Height + bLineSpace
                e.Graphics.DrawString("Finance & Billing Department", vFont, Brushes.Black, vCurrX, vCurrY)

                vCurrY = vCurrY + vFont.Height + bLineSpace
                e.Graphics.DrawString("Vox Dei Protocol Systems, Inc.", vFont, Brushes.Black, vCurrX, vCurrY)

                vCurrY = vCurrY + vFont.Height + bLineSpace
                vCurrY = vCurrY + vFont.Height + bLineSpace

                vFont = New Font("Arial", 8)

                vCurrX = vColLeft(1)
                e.Graphics.DrawString("This is a system generated report.", vFont, Brushes.Black, vCurrX, vCurrY)

                bPrintFooter = True
                bPrintDetails = True
                bFirstPage = False

                bDetailsSeq = 0
                bDetailsSeqPrint = 0
            Else
                '---------------------------------------- print details --------------------------------------------------------------

                vColLeft(1) = bLeftMargin
                vColWidth(1) = 75

                vColLeft(2) = vColLeft(1) + vColWidth(1)
                vColWidth(2) = 125

                vColLeft(3) = vColLeft(2) + vColWidth(2)
                vColWidth(3) = 75

                vColLeft(4) = vColLeft(3) + vColWidth(3)
                vColWidth(4) = 375

                vColLeft(5) = vColLeft(4) + vColWidth(4)
                vColWidth(5) = 0

                vWidth = vColWidth(1) + vColWidth(2) + vColWidth(3) + vColWidth(4) + vColWidth(5)

                vFont = New Font("Arial", 10, FontStyle.Bold)

                e.Graphics.DrawString("DATA TRANSMISSION CHARGES:", vFont, Brushes.Black, vCurrX, vCurrY)

                vFont = New Font("Arial", 10)
                vCurrY = vCurrY + vFont.Height + bLineSpace

                vWidth = vColWidth(1) + vColWidth(2) + vColWidth(3) + vColWidth(4) + vColWidth(5)
                e.Graphics.DrawLine(Pens.Black, vColLeft(1), vCurrY, vColLeft(1) + vWidth, vCurrY)

                vCurrY = vCurrY + bLineSpace

                vFont = New Font("Arial", 9, FontStyle.Bold)
                vStringFormat.Alignment = StringAlignment.Center

                vCurrX = vColLeft(1)
                vWidth = vColWidth(1)
                vRect = New Rectangle(vCurrX, vCurrY, vWidth, vFont.Height)
                e.Graphics.DrawString("No.", vFont, Brushes.Black, vRect, vStringFormat)

                vStringFormat.Alignment = StringAlignment.Near

                vCurrX = vColLeft(2)
                vWidth = vColWidth(2)
                vRect = New Rectangle(vCurrX, vCurrY, vWidth, vFont.Height)
                e.Graphics.DrawString("Period", vFont, Brushes.Black, vRect, vStringFormat)

                vStringFormat.Alignment = StringAlignment.Center

                vCurrX = vColLeft(3)
                vWidth = vColWidth(3)
                vRect = New Rectangle(vCurrX, vCurrY, vWidth, vFont.Height)
                e.Graphics.DrawString("Amount", vFont, Brushes.Black, vRect, vStringFormat)

                vStringFormat.Alignment = StringAlignment.Near

                'vCurrX = vColLeft(4)
                'vWidth = vColWidth(4)
                'vRect = New Rectangle(vCurrX, vCurrY, vWidth, vFont.Height)
                'e.Graphics.DrawString("Description", vFont, Brushes.Black, vRect, vStringFormat)

                vCurrX = vColLeft(4)
                vWidth = vColWidth(4)
                vRect = New Rectangle(vCurrX, vCurrY, vWidth, vFont.Height)
                e.Graphics.DrawString("Details", vFont, Brushes.Black, vRect, vStringFormat)

                vCurrY = vCurrY + vFont.Height + bLineSpace

                vWidth = vColWidth(1) + vColWidth(2) + vColWidth(3) + vColWidth(4) + vColWidth(5)
                e.Graphics.DrawLine(Pens.Black, vColLeft(1), vCurrY, vColLeft(1) + vWidth, vCurrY)

                vCurrY = vCurrY + bLineSpace

                bDetailsSeq = bDetailsSeq + 1

                For vCtr = bDetailsSeq To bListDetails.Items.Count
                    If CDbl(bListDetails.Items(vCtr - 1).SubItems(3).Text) <> 0 Then
                        bDetailsSeqPrint = bDetailsSeqPrint + 1

                        vFont = New Font("Arial", 9)
                        vStringFormat.Alignment = StringAlignment.Center

                        vCurrX = vColLeft(1)
                        vWidth = vColWidth(1)
                        vRect = New Rectangle(vCurrX, vCurrY, vWidth, vFont.Height)
                        e.Graphics.DrawString(bDetailsSeqPrint.ToString, vFont, Brushes.Black, vRect, vStringFormat)

                        vStringFormat.Alignment = StringAlignment.Near

                        vCurrX = vColLeft(2)
                        vWidth = vColWidth(2)
                        vRect = New Rectangle(vCurrX, vCurrY, vWidth, vFont.Height)
                        e.Graphics.DrawString(CDate(bListDetails.Items(vCtr - 1).Text).ToString("MM/dd/yyyy HH:mm:ss"), vFont, Brushes.Black, vRect, vStringFormat)

                        vStringFormat.Alignment = StringAlignment.Center

                        vCurrX = vColLeft(3)
                        vWidth = vColWidth(3)
                        vRect = New Rectangle(vCurrX, vCurrY, vWidth, vFont.Height)
                        e.Graphics.DrawString(CDbl(bListDetails.Items(vCtr - 1).SubItems(3).Text).ToString("###,###,###,##0.00"), vFont, Brushes.Black, vRect, vStringFormat)

                        vStringFormat.Alignment = StringAlignment.Near

                        'vCurrX = vColLeft(4)
                        'vWidth = vColWidth(4)
                        'vRect = New Rectangle(vCurrX, vCurrY, vWidth, vFont.Height)
                        'e.Graphics.DrawString(bListDetails.Items(vCtr - 1).SubItems(2).Text, vFont, Brushes.Black, vRect, vStringFormat)

                        vCurrX = vColLeft(4)
                        vWidth = vColWidth(4)
                        vRect = New Rectangle(vCurrX, vCurrY, vWidth, vFont.Height)

                        vTmpStr = bListDetails.Items(vCtr - 1).SubItems(6).Text

                        If InStr(vTmpStr, ", TYPE:") > 0 Then
                            vTmpStr = Mid(vTmpStr, 1, InStr(vTmpStr, ", TYPE:") - 1)
                        End If

                        e.Graphics.DrawString(vTmpStr, vFont, Brushes.Black, vRect, vStringFormat)

                        vCurrY = vCurrY + vFont.Height + bLineSpace

                        If bDetailsSeqPrint Mod 40 = 0 Then
                            'bDetailsSeqPrint = 0

                            Exit Sub
                        End If
                    End If

                    bDetailsSeq = bDetailsSeq + 1
                Next
            End If

            '--------------------- end of page ---------------------
        Catch ex As Exception
        End Try
    End Sub

End Module
