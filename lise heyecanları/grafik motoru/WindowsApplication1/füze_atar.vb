

Imports WindowsApplication1.füze_atar
Public Class füze_atar
    Dim kare_sayı As Integer
    Dim nesne_Sayısı As Integer
    Dim i As Integer
    Dim anaçizici As Graphics
    Dim bit1gr As Graphics
    Dim bit2gr As Graphics
    Public Shared WithEvents çizilen_nesneler As New TextBox
    Public Shared gr As Graphics
    Public Shared bit1 As New Bitmap(1200, 800)
    Dim arkaplan As New Bitmap(1000, 1000)
    Dim bit2 As New Bitmap(1200, 800)
    Dim komutan2 As aygıt1


    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        i += 1

        If i = 2 Then
            Timer3.Enabled = True
        End If

        TextBox3.Text = i + 4

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        çizilen_nesneler.Text = "0"

        anaçizici = Graphics.FromHwnd(Me.Handle)

        gr = Graphics.FromImage(bit1)
        TextBox1.Text = 0

        Timer1.Enabled = True



    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick

        TextBox2.Text = kare_sayı

        kare_sayı = 0


    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub Timer3_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer3.Tick
        TextBox3.Text = i + 1
    End Sub

    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.TextChanged

        If Not kare_sayı = 0 Then
            If çizilen_nesneler.Text = nesne_Sayısı Then
                PictureBox1.Image = bit1

                gr.FillRectangle(Brushes.White, New Rectangle(0, 0, 1200, 800))

                çizilen_nesneler.Text = 0

                TextBox1.Text += 1
            End If
        End If
        kare_sayı += 1
    End Sub

    Private Sub füze_atar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        çizilen_nesneler = New TextBox

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim ns As Integer


        For ns = 0 To 100
            komutan2 = New aygıt1
            komutan2.başla(TextBox1)
        Next ns

        nesne_Sayısı = 101
    End Sub
End Class

Public Class aygıt1

    Dim i As Integer

    Dim res11 As New Bitmap("C:\Users\Ev Bilgisayarı\Desktop\füze.bmp")

    Dim res As New Bitmap(2, 2)

    Dim res1, res2, res3 As New Bitmap(20, 20)

    Dim girdap As New Bitmap(20, 20)
    Dim girdap1 As New Bitmap(20, 20)
    Dim grdap As Graphics

    Dim renk As Color

    Dim kırmızı, mavi, yeşil As Integer

    Dim x, y As Single
    Dim hız, süre, sürtünme As Single
    Dim kx, ky As Single

    Dim matrix As New Drawing2D.Matrix

    WithEvents değişme As TextBox

    Sub başla(ByVal değişikliklik_durumu As TextBox)

        grdap = Graphics.FromImage(girdap)
        grdap.FillRectangle(Brushes.Blue, New RectangleF(0, 0, 6, 6))

        girdap.MakeTransparent(Color.White)

        değişme = değişikliklik_durumu

        hız = 3.9

        sürtünme = 0.01

        kx = 2 * Rnd(10)
        ky = 2 * Rnd(10)

        y = 400

        gr.ScaleTransform(1, 1, Drawing2D.MatrixOrder.Prepend)

        grdap = Graphics.FromImage(girdap1)

        grdap.FillRectangle(Brushes.White, New Rectangle(0, 0, 20, 20))
        grdap.DrawImage(girdap, 5, 5, 10, 10)

        girdap1.MakeTransparent(Color.White)
    End Sub


    Private Sub değişme_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles değişme.TextChanged

        süre += 0.01



        x += kx
        y -= ky

        gr.DrawImage(girdap1, x, y)

        çizilen_nesneler.Text += 1

    End Sub


End Class
