Imports Gif.Components

Public Class Form1

    Dim d�n��t�r�c� As New AnimatedGifEncoder()

    Dim b As Single

    Dim kresys = 61
    Dim gecikme = 10

    Dim gr As Graphics

    Dim bitt(300) As Bitmap

    Dim sy� As Integer

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim i As Integer

        For i = 0 To kresys
            bitt(i) = Kare_olu�tur()
            Label2.Text = i
            PictureBox1.Image = bitt(i)
            Application.DoEvents()
        Next

        Timer1.Interval = gecikme
        Timer1.Enabled = True

    End Sub

    Function Kare_olu�tur() As Bitmap
        Dim bit As Bitmap
        Dim ii, i As Integer
        Dim x, xx, y As Single

        bit = New Bitmap(336, 32)
        gr = Graphics.FromImage(bit)
        gr.FillRectangle(Brushes.White, New Rectangle(0, 0, 336, 32))

        b += 0.1

        xx -= b

        For ii = 1 To 4800
            x += 0.01
            xx += 0.01
            y = 16 + Math.Cos(xx) * 8

            gr.FillEllipse(Brushes.Black, New Rectangle(x * 7, y, 2, 2))
        Next

        Return bit
    End Function

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If Not sy� = kresys Then
            sy� += 1
        Else
            sy� = 0
        End If

        PictureBox1.Image = bitt(sy�)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim i As Integer

        d�n��t�r�c�.Start("C:\test.gif")
        d�n��t�r�c�.SetDelay(TextBox1.Text)
        d�n��t�r�c�.SetRepeat(0)
        d�n��t�r�c�.SetQuality(1)
        d�n��t�r�c�.SetDispose(1)

        Label2.Text = 0

        For i = 0 To kresys
            d�n��t�r�c�.AddFrame(bitt(i))
            Label2.Text = i
            Application.DoEvents()
        Next

        d�n��t�r�c�.Finish()
        PictureBox2.ImageLocation = "C:\test.gif"

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox1.Text = gecikme
    End Sub
End Class
