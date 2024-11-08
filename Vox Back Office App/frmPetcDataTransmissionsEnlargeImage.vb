Public Class frmPetcDataTransmissionsEnlargeImage

    Private gImage1 As Image
    Private gImage2 As Image
    Private gImage3 As Image
    Private gImage4 As Image
    Private gImage5 As Image
    Private gPlateNo As String

    Property PlateNo() As String
        Get
            Return gPlateNo
        End Get

        Set(ByVal value As String)
            gPlateNo = value
        End Set
    End Property

    Property Image1() As Image
        Get
            Return gImage1
        End Get

        Set(ByVal value As Image)
            gImage1 = value
        End Set
    End Property

    Property Image2() As Image
        Get
            Return gImage2
        End Get

        Set(ByVal value As Image)
            gImage2 = value
        End Set
    End Property

    Property Image3() As Image
        Get
            Return gImage3
        End Get

        Set(ByVal value As Image)
            gImage3 = value
        End Set
    End Property

    Property Image4() As Image
        Get
            Return gImage4
        End Get

        Set(ByVal value As Image)
            gImage4 = value
        End Set
    End Property

    Property Image5() As Image
        Get
            Return gImage5
        End Get

        Set(ByVal value As Image)
            gImage5 = value
        End Set
    End Property

    Private Sub frmPetcDataTransmissionsEnlargeImage_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then Me.Close()
    End Sub

    Private Sub frmPetcDataTransmissionsEnlargeImage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        picImage1.Visible = False
        picImage2.Visible = False
        picImage3.Visible = False
        picImage4.Visible = False
        picImage5.Visible = False

        picImage2.Size = picImage1.Size
        picImage2.Location = picImage1.Location

        picImage2.Size = picImage1.Size
        picImage2.Location = picImage1.Location

        picImage3.Size = picImage1.Size
        picImage3.Location = picImage1.Location

        picImage4.Size = picImage1.Size
        picImage4.Location = picImage1.Location

        picImage5.Size = picImage1.Size
        picImage5.Location = picImage1.Location

        optImage1.Checked = False
        optImage2.Checked = False
        optImage3.Checked = False
        optImage4.Checked = False
        optImage5.Checked = False

        Me.Text = "PETC Data Transmission - Image view"

        Me.KeyPreview = True

        timerLoad.Enabled = True
    End Sub

    Private Sub timerLoad_Tick(sender As Object, e As EventArgs) Handles timerLoad.Tick
        timerLoad.Enabled = False

        Try
            Me.Text = "PETC Data Transmission - Image view for MV with Plate No. " & Me.PlateNo

            optImage1.Checked = False
            optImage2.Checked = False
            optImage3.Checked = False
            optImage4.Checked = False
            optImage5.Checked = False

            picImage1.Visible = False
            picImage2.Visible = False
            picImage3.Visible = False
            picImage4.Visible = False
            picImage5.Visible = False

            picImage1.Image = Me.Image1
            picImage2.Image = Me.Image2
            picImage3.Image = Me.Image3
            picImage4.Image = Me.Image4
            picImage5.Image = Me.Image5

            optImage1.Checked = True

            picImage1.Visible = True

        Catch ex As Exception
            MsgBox("An error was encountered while loading Image data.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Error has occurred")
        End Try
    End Sub

    Private Sub optImage1_CheckedChanged(sender As Object, e As EventArgs) Handles optImage1.CheckedChanged
        If optImage1.Checked = True Then
            picImage1.Visible = True
            picImage2.Visible = False
            picImage3.Visible = False
            picImage4.Visible = False
            picImage5.Visible = False
        End If
    End Sub

    Private Sub optImage2_CheckedChanged(sender As Object, e As EventArgs) Handles optImage2.CheckedChanged
        If optImage2.Checked = True Then
            picImage1.Visible = False
            picImage2.Visible = True
            picImage3.Visible = False
            picImage4.Visible = False
            picImage5.Visible = False
        End If
    End Sub

    Private Sub optImage3_CheckedChanged(sender As Object, e As EventArgs) Handles optImage3.CheckedChanged
        If optImage3.Checked = True Then
            picImage1.Visible = False
            picImage2.Visible = False
            picImage3.Visible = True
            picImage4.Visible = False
            picImage5.Visible = False
        End If
    End Sub

    Private Sub optImage4_CheckedChanged(sender As Object, e As EventArgs) Handles optImage4.CheckedChanged
        If optImage4.Checked = True Then
            picImage1.Visible = False
            picImage2.Visible = False
            picImage3.Visible = False
            picImage4.Visible = True
            picImage5.Visible = False
        End If
    End Sub

    Private Sub optImage5_CheckedChanged(sender As Object, e As EventArgs) Handles optImage5.CheckedChanged
        If optImage5.Checked = True Then
            picImage1.Visible = False
            picImage2.Visible = False
            picImage3.Visible = False
            picImage4.Visible = False
            picImage5.Visible = True
        End If
    End Sub

    Private Sub cmdClose_Click(sender As Object, e As EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub
End Class