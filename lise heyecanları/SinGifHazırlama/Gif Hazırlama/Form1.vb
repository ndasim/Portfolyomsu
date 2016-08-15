Imports Gif.Components

Public Class Form1

    Dim dönüþtürücü As New AnimatedGifEncoder()

    Dim b As Single

    Dim kresys = 61
    Dim gecikme = 10

    Dim gr As Graphics

    Dim bitt(300) As Bitmap

    Dim syç As Integer

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim i As Integer

        For i = 0 To kresys
            bitt(i) = Kare_oluþtur()
            Label2.Text = i
            PictureBox1.Image = bitt(i)
            Application.DoEvents()
        Next

        Timer1.Interval = gecikme
        Timer1.Enabled = True

    End Sub

    Function Kare_oluþtur() As Bitmap
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
        If Not syç = kresys Then
            syç += 1
        Else
            syç = 0
        End If

        PictureBox1.Image = bitt(syç)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim i As Integer

        dönüþtürücü.Start("C:\test.gif")
        dönüþtürücü.SetDelay(TextBox1.Text)
        dönüþtürücü.SetRepeat(0)
        dönüþtürücü.SetQuality(1)
        dönüþtürücü.SetDispose(1)

        Label2.Text = 0

        For i = 0 To kresys
            dönüþtürücü.AddFrame(bitt(i))
            Label2.Text = i
            Application.DoEvents()
        Next

        dönüþtürücü.Finish()
        PictureBox2.ImageLocation = "C:\test.gif"

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox1.Text = gecikme
    End Sub
End Class
