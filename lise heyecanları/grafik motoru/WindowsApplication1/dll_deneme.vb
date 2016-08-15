Public Class dll_deneme

    Dim motor As grafik_motor_v2.Motor
    Dim nesne As grafik_motor_v2.Nesne
    Dim x1, y1 As Integer
    Dim gr As Graphics
    Dim bit As New Bitmap(100, 100)

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click

        bit = New Bitmap("C:\Users\Ev Bilgisayarı\Desktop\grafik motoru\WindowsApplication1\ministrateji\100-100 kare.bmp")

        motor = New grafik_motor_v2.Motor(PictureBox1)

        motor.yenilenme_hızını_göster()



        For Me.y1 = 0 To 10
            For Me.x1 = 0 To 10
                nesne = New grafik_motor_v2.Nesne(motor, bit)
                nesne.X = x1 * 100
                nesne.Y = y1 * 100
            Next x1
        Next y1

    End Sub

    Private Sub dll_deneme_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class