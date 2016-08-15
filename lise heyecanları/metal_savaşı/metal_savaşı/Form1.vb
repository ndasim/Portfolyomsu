Public Class Form1

    Dim aygıt As Grafik.Toplayıcı

    Dim nesne(2) As Grafik.Nesne

    Dim res As Bitmap

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click

        res = New Bitmap("C:\Users\Ev Bilgisayarı\Desktop\ADN Yazılım\grafik motoru\WindowsApplication1\ministrateji\100-100 kare.bmp")

        aygıt = New Grafik.Toplayıcı(PictureBox1)

        Dim i As Integer



        For i = 0 To 2
            nesne(i) = New Grafik.Nesne(aygıt, res)
            nesne(i).X = i * 50
            nesne(i).Y = i * 50
            nesne(i).katman(i)
        Next

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        nesne(1).katman(2)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        nesne(1).katman(1)
        nesne(2).katman(0)
    End Sub
End Class
