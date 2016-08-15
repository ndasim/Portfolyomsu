Public Class çoklu_motor

    Dim kareler As hareketlikareler
    Dim motor As grafik_motor_v1.Motor
    Dim nesne As grafik_motor_v1.Nesne
    Dim bit As New Bitmap(10, 10)
    Dim gr As Graphics

    Private Sub çoklu_motor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        gr = Graphics.FromImage(bit)
        gr.FillRectangle(Brushes.White, New Rectangle(0, 0, 10, 10))

        motor = New grafik_motor_v1.Motor(PictureBox1)
        motor.yenilenme_hızını_göster()

    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        Dim i, ı As Integer

        For i = 0 To 100

            nesne = New grafik_motor_v1.Nesne(motor, bit)
            kareler = New hareketlikareler(nesne)

        Next

    End Sub
End Class

Public Class hareketlikareler

    Dim kare As grafik_motor_v1.Nesne

    WithEvents zamanlayıcı As Timer

    Dim rastx, rasty As Single

    Sub New(ByVal nesne As grafik_motor_v1.Nesne)

        kare = nesne

        zamanlayıcı = New Timer
        rastx = 5 * Rnd(10)
        rasty = 5 * Rnd(10)

        zamanlayıcı.Interval = 1
        zamanlayıcı.Enabled = True

    End Sub

    Private Sub zamanlayıcı_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles zamanlayıcı.Tick

        kare.X += rastx
        kare.Y += rasty

    End Sub
End Class