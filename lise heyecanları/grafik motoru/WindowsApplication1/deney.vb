Public Class deney
    Dim a As New Bitmap(100, 100)
    Dim b As Bitmap
    Dim kare As Short
    Dim gr As Graphics

    Private Sub deney_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click

        b = New Bitmap("C:\Users\Ev Bilgisayarı\Desktop\grafik motoru\WindowsApplication1\ministrateji\10-10 kare.bmp")
        Timer1.Enabled = True

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim i, i1 As Integer
        Dim x, y As Integer

        gr = Graphics.FromImage(a)
        gr.DrawImage(b, 0, 0)

        gr.FillRectangle(Brushes.Blue, 0, 0, 100, 100)



        PictureBox2.Image = a

        gr.Clear(Color.Transparent)

        kare += 1

    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        TextBox1.Text = kare
        kare = 0
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class