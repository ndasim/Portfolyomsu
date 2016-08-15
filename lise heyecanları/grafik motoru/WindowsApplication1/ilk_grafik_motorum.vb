


Public Class grafik_motor_v1


    Public Class Motor

        Public WithEvents tikleyici As New TextBox
        WithEvents textbox2 As New TextBox
        WithEvents textbox3 As New TextBox

        WithEvents timer1 As New Timer
        WithEvents timer3 As New Timer
        WithEvents timer2 As New Timer

        Dim kare_sayı As Integer
        Public nesne_Sayısı As Integer
        Dim i As Integer
        Dim anaçizici As Graphics
        Dim bit1gr As Graphics
        Dim bit2gr As Graphics
        Public WithEvents çizilen_nesneler As New TextBox

        Public gr As Graphics
        Public gr1 As Graphics
        Public gr2 As Graphics
        Public gr3 As Graphics
        Public gr4 As Graphics
        Public gr5 As Graphics

        Public Shared bit1 As New Bitmap(600, 600, Imaging.PixelFormat.Format32bppPArgb)
        Dim arkaplan As New Bitmap(1000, 1000)
        Dim bit2 As New Bitmap(1200, 800)
        Dim komutan2 As Nesne
        WithEvents gösterimalanı As PictureBox

        Public Sub New(ByVal alan As PictureBox)

            tikleyici = New TextBox
            textbox2 = New TextBox
            textbox3 = New TextBox

            timer1 = New Timer
            timer2 = New Timer
            timer3 = New Timer

            tikleyici.Top = 100

            textbox2.Left = 200

            textbox3.Left = 100

            timer1.Interval = 1

            timer2.Interval = 1000

            timer3.Interval = 1

            gösterimalanı = alan

            çizilen_nesneler = New TextBox

            çizilen_nesneler.Text = "0"

            tikleyici.Text = 0

            timer1.Enabled = True

            timer2.Enabled = True

            gr = Graphics.FromImage(bit1)
            gr1 = Graphics.FromImage(bit1)
            gr2 = Graphics.FromImage(bit1)
            gr3 = Graphics.FromImage(bit1)
            gr4 = Graphics.FromImage(bit1)
            gr5 = Graphics.FromImage(bit1)


        End Sub

        Public Sub çözünürlük(ByVal x As Integer, ByVal y As Integer)

            gr.ScaleTransform(x, y)

        End Sub

        Sub yenilenme_hızını_göster()
            tikleyici.Parent = gösterimalanı

            textbox2.Parent = gösterimalanı

            textbox3.Parent = gösterimalanı
        End Sub

        Public Sub yeni_nesne_oluştur()

        End Sub

        Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timer1.Tick

            i += 1

            If i = 2 Then
                timer3.Enabled = True
            End If

            textbox3.Text = i + 4

        End Sub

        Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timer2.Tick

            textbox2.Text = kare_sayı
            kare_sayı = 0


        End Sub

        Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles textbox2.TextChanged

        End Sub

        Private Sub Timer3_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timer3.Tick
            textbox3.Text = i + 1
        End Sub

        Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles textbox3.TextChanged

            If Not kare_sayı = 0 Then
                If çizilen_nesneler.Text = nesne_Sayısı Then

                    gösterimalanı.Image = bit1

                    gr.Clear(Color.Transparent)

                    ' gr.FillRectangle(Brushes.Wheat, New Rectangle(0, 0, 500, 500))

                    çizilen_nesneler.Text = 0

                    tikleyici.Text += 1

                End If
            End If
            kare_sayı += 1
        End Sub

        Sub kamera(ByVal konum As PointF, ByVal zoomx As Single)

        End Sub

    End Class

    Public Class Nesne

        Dim en, boy As Single

        Dim orjin As PointF
        Dim yerleştirme As PointF

        Dim aygıt As grafik_motor_v1.Motor

        Dim i As Integer

        Dim gr As Graphics

        Dim girdap As Bitmap
        Dim girdap1 As Bitmap
        Dim grdap As Graphics

        Dim matrix As New Drawing2D.Matrix

        WithEvents değişme As TextBox

        Dim onaylanma As Short

        Sub New(ByVal motor As grafik_motor_v1.Motor, ByVal resim As Bitmap)

            motor.nesne_Sayısı += 1

            motor.çizilen_nesneler.Text += 1

            aygıt = motor

            girdap = New Bitmap(resim)

            ortala()

            i = Rnd(5) * 5

            girdap1 = New Bitmap(100, 100)

            grdap = Graphics.FromImage(girdap1)

            değişme = motor.tikleyici

            If i = 1 Then
                gr = aygıt.gr1
            End If

            If i = 2 Then
                gr = aygıt.gr2
            End If

            If i = 3 Then
                gr = aygıt.gr3
            End If

            If i > 3 Then
                gr = aygıt.gr4
            End If

            If i = 0 Then
                gr = aygıt.gr5
            End If

        End Sub

        Private Sub ortala()
            If girdap.Height > girdap.Width Then
                en = girdap.Height
                boy = girdap.Height

                orjin.X = girdap.Height / 2
                orjin.Y = girdap.Height / 2

                yerleştirme.X = (girdap.Height / 2) - (girdap.Width / 2)
                yerleştirme.Y = 0

            ElseIf girdap.Height = girdap.Width Then
                en = girdap.Height
                boy = girdap.Height

                orjin.X = girdap.Height / 2
                orjin.Y = girdap.Height / 2

                yerleştirme.X = 0
                yerleştirme.Y = 0

            Else
                en = girdap.Width
                boy = girdap.Width

                orjin.X = girdap.Width / 2
                orjin.Y = girdap.Width / 2

                yerleştirme.X = 0
                yerleştirme.Y = (girdap.Height / 2) - (girdap.Width / 2)

            End If

        End Sub

        Sub döndür(ByVal derece As Single, ByVal merkeznoktası As Point)

            grdap.Clear(Color.Transparent)

            matrix.RotateAt(derece, orjin)

            grdap.Transform = matrix

        End Sub

        Sub transparantlık()

        End Sub

        Private sütun, satır As Single

        Public Property X() As Single
            Get
                Return sütun
            End Get
            Set(ByVal value As Single)
                sütun = value
            End Set
        End Property

        Public Property Y() As Single
            Get
                Return satır
            End Get
            Set(ByVal value As Single)
                satır = value
            End Set
        End Property

        Dim a As Single

        Private Sub değişme_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles değişme.TextChanged

            grdap.DrawImage(girdap, yerleştirme)



            aygıt.gr.DrawImage(girdap1, X - orjin.X, Y - orjin.Y)

            aygıt.çizilen_nesneler.Text += 1

        End Sub

    End Class

    Public Class Transparan_Nesne

        Dim en, boy As Single

        Dim orjin As PointF
        Dim yerleştirme As PointF

        Dim aygıt As grafik_motor_v1.Motor

        Dim i As Integer

        Dim res11 As New Bitmap("C:\Users\Ev Bilgisayarı\Desktop\füze.bmp")

        Dim girdap As Bitmap
        Dim girdap1 As Bitmap
        Dim grdap As Graphics

        Dim matrix As New Drawing2D.Matrix

        WithEvents değişme As TextBox

        Dim onaylanma As Short

        Sub başla(ByVal motor As grafik_motor_v1.Motor, ByVal resim As Bitmap)

            motor.nesne_Sayısı += 1

            motor.çizilen_nesneler.Text += 1

            aygıt = motor

            girdap = New Bitmap(resim)
            girdap1 = New Bitmap(500, 500)

            ortala()

            grdap = Graphics.FromImage(girdap1)

            değişme = motor.tikleyici


        End Sub

        Private Sub ortala()
            If girdap.Height > girdap.Width Then
                en = girdap.Height
                boy = girdap.Height

                orjin.X = girdap.Height / 2
                orjin.Y = girdap.Height / 2

                yerleştirme.X = (girdap.Height / 2) - (girdap.Width / 2)
                yerleştirme.Y = 0

            ElseIf girdap.Height = girdap.Width Then
                en = girdap.Height
                boy = girdap.Height

                orjin.X = girdap.Height / 2
                orjin.Y = girdap.Height / 2

                yerleştirme.X = 0
                yerleştirme.Y = 0

            Else
                en = girdap.Width
                boy = girdap.Width

                orjin.X = girdap.Width / 2
                orjin.Y = girdap.Width / 2

                yerleştirme.X = 0
                yerleştirme.Y = (girdap.Height / 2) - (girdap.Width / 2)

            End If

        End Sub

        Sub döndür(ByVal derece As Single, ByVal merkeznoktası As Point)

            grdap.Clear(Color.Transparent)

            matrix.RotateAt(derece, orjin)

            grdap.Transform = matrix

        End Sub

        Sub transparantlık()

        End Sub

        Private sütun, satır As Single

        Public Property X() As Single
            Get
                Return sütun
            End Get
            Set(ByVal value As Single)
                sütun = value
            End Set
        End Property

        Public Property Y() As Single
            Get
                Return satır
            End Get
            Set(ByVal value As Single)
                satır = value
            End Set
        End Property

        Dim a As Single

        Private Sub değişme_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles değişme.TextChanged

            grdap.Clear(Color.Transparent)

            grdap.DrawImage(girdap, X - orjin.X, Y - orjin.Y)

            aygıt.gr.DrawImage(girdap1, 0, 0)

            aygıt.çizilen_nesneler.Text += 1

        End Sub

    End Class ' deneme aşamasında

    Public Class Çizgi

        Dim xx1, xx2, yy1, yy2 As Single
        Dim çizgikalınlığı As Single
        Dim rengi As Color
        Dim başlamanoktası, bitişnoktası As PointF

        Dim aygıt As grafik_motor_v1.Motor

        WithEvents değişme As TextBox

        Sub New(ByVal motor As grafik_motor_v1.Motor)

            aygıt = motor

            renk = Color.Black

            çizgikalınlığı = 1

            motor.nesne_Sayısı += 1

            motor.çizilen_nesneler.Text += 1

            değişme = motor.tikleyici
        End Sub

        Public Property X1() As Single
            Get
                Return xx1
            End Get
            Set(ByVal value As Single)
                xx1 = value
            End Set
        End Property

        Public Property Y1() As Single
            Get
                Return yy1
            End Get
            Set(ByVal value As Single)
                yy1 = value
            End Set
        End Property

        Public Property X2() As Single
            Get
                Return xx2
            End Get
            Set(ByVal value As Single)
                xx2 = value
            End Set
        End Property

        Public Property Y2() As Single
            Get
                Return yy2
            End Get
            Set(ByVal value As Single)
                yy2 = value
            End Set
        End Property

        Public Property çizgi_kalınlığı() As Single
            Get
                Return çizgikalınlığı
            End Get
            Set(ByVal value As Single)
                çizgikalınlığı = value
            End Set
        End Property

        Public Property renk() As Color
            Get
                Return rengi
            End Get
            Set(ByVal value As Color)
                rengi = value
            End Set
        End Property

        Public Property başlama_noktası() As PointF
            Get
                Return başlamanoktası
                xx1 = başlamanoktası.X
                yy1 = başlamanoktası.Y
            End Get
            Set(ByVal value As PointF)
                başlamanoktası = value
                xx1 = başlamanoktası.X
                yy1 = başlamanoktası.Y
            End Set
        End Property

        Public Property bitiş_noktası() As PointF
            Get
                Return bitişnoktası
                xx2 = bitişnoktası.X
                yy2 = bitişnoktası.Y
            End Get
            Set(ByVal value As PointF)
                bitişnoktası = value
                xx2 = bitişnoktası.X
                yy2 = bitişnoktası.Y
            End Set
        End Property

        Private Sub değişme_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles değişme.TextChanged

            aygıt.gr.DrawLine(New Pen(renk, çizgikalınlığı), xx1, yy1, xx2, yy2)

            aygıt.çizilen_nesneler.Text += 1

        End Sub
    End Class

    Public Class Etiket
        Dim xx1, xx2, yy1, yy2 As Single
        Dim çizgikalınlığı As Single
        Dim rengi As Brush

        Dim yazı1 As String
        Dim yazıtipi As Font

        Dim aygıt As grafik_motor_v1.Motor

        WithEvents değişme As TextBox

        Sub New(ByVal motor As grafik_motor_v1.Motor, Optional ByVal yazı As String = "")
            aygıt = motor

            yazı1 = yazı

            çizgikalınlığı = 12

            yazıtipi = New Font("Courner New", çizgikalınlığı, FontStyle.Regular)

            renk = Brushes.Black

            çizgikalınlığı = 1

            motor.nesne_Sayısı += 1

            motor.çizilen_nesneler.Text += 1

            değişme = motor.tikleyici
        End Sub

        Public Property X1() As Single
            Get
                Return xx1
            End Get
            Set(ByVal value As Single)
                xx1 = value
            End Set
        End Property

        Public Property Y1() As Single
            Get
                Return yy1
            End Get
            Set(ByVal value As Single)
                yy1 = value
            End Set
        End Property

        Public Property X2() As Single
            Get
                Return xx2
            End Get
            Set(ByVal value As Single)
                xx2 = value
            End Set
        End Property

        Public Property Y2() As Single
            Get
                Return yy2
            End Get
            Set(ByVal value As Single)
                yy2 = value
            End Set
        End Property

        Public Property çizgi_kalınlığı() As Single
            Get
                Return çizgikalınlığı
            End Get
            Set(ByVal value As Single)
                çizgikalınlığı = value
                yazıtipi = New Font(yazı_tipi.FontFamily.Name, çizgikalınlığı, FontStyle.Regular)
            End Set
        End Property

        Public Property renk() As Brush
            Get
                Return rengi
            End Get
            Set(ByVal value As Brush)
                rengi = value
            End Set
        End Property

        Public Property yazı() As String
            Get
                Return yazı1
            End Get
            Set(ByVal value As String)
                yazı1 = value
            End Set
        End Property

        Public Property yazı_tipi() As Font
            Get
                Return yazıtipi
            End Get
            Set(ByVal value As Font)
                yazıtipi = value



            End Set
        End Property

        Private Sub değişme_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles değişme.TextChanged

            aygıt.gr.DrawString(yazı1, yazıtipi, renk, xx1, yy1)

            aygıt.çizilen_nesneler.Text += 1

        End Sub
    End Class

End Class

Public Class grafik_motor_v2

    Public Class Motor

        Public WithEvents tikleyici As New TextBox
        WithEvents textbox2 As New TextBox
        WithEvents textbox3 As New TextBox

        WithEvents timer1 As New Timer
        WithEvents timer3 As New Timer
        WithEvents timer2 As New Timer

        Dim kare_sayı As Integer
        Public nesne_Sayısı As Integer
        Dim i As Integer
        Dim anaçizici As Graphics
        Dim bit1gr As Graphics
        Dim bit2gr As Graphics
        Public WithEvents çizilen_nesneler As New TextBox

        Public gr As Graphics
        Public gr1 As Graphics
        Public gr2 As Graphics
        Public gr3 As Graphics
        Public gr4 As Graphics
        Public gr5 As Graphics

        Dim kare As Integer

        Public Shared bit1 As New Bitmap(600, 600, Imaging.PixelFormat.Format32bppPArgb)
        Dim arkaplan As New Bitmap(1000, 1000)
        Dim bit2 As New Bitmap(1200, 800)
        Dim komutan2 As Nesne
        WithEvents gösterimalanı As PictureBox

        Dim çizdiricisırası As Integer

        Public Sub New(ByVal alan As PictureBox)

            tikleyici = New TextBox
            textbox2 = New TextBox
            textbox3 = New TextBox

            timer1 = New Timer
            timer2 = New Timer
            timer3 = New Timer

            tikleyici.Top = 100

            textbox2.Left = 200

            textbox3.Left = 100

            timer1.Interval = 1

            timer2.Interval = 1000

            timer3.Interval = 1

            gösterimalanı = alan

            çizilen_nesneler = New TextBox

            çizilen_nesneler.Text = "0"



            tikleyici.Text = 0

            timer1.Enabled = True

            timer2.Enabled = True

            gr = Graphics.FromImage(bit1)
            gr1 = Graphics.FromImage(bit1)
            gr2 = Graphics.FromImage(bit1)
            gr3 = Graphics.FromImage(bit1)
            gr4 = Graphics.FromImage(bit1)
            gr5 = Graphics.FromImage(bit1)

        End Sub

        Sub yenilenme_hızını_göster()
            tikleyici.Parent = gösterimalanı

            textbox2.Parent = gösterimalanı

            textbox3.Parent = gösterimalanı
        End Sub

        Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timer1.Tick

            i += 1

            If i = 2 Then
                timer3.Enabled = True
            End If

            textbox3.Text = i + 4

        End Sub

        Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timer2.Tick

            textbox2.Text = kare & " ; " & kare_sayı
            kare = 0
            kare_sayı = 0

        End Sub

        Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles textbox2.TextChanged

        End Sub

        Private Sub Timer3_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timer3.Tick
            textbox3.Text = i + 1
        End Sub

        Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles textbox3.TextChanged

            If Not kare_sayı = 0 Then
                If çizilen_nesneler.Text = nesne_Sayısı Then

                    gösterimalanı.Image = bit1

                    gr.Clear(Color.Transparent)

                    ' gr.FillRectangle(Brushes.Wheat, New Rectangle(0, 0, 500, 500))

                    çizilen_nesneler.Text = 0

                    tikleyici.Text += 1

                    kare += 1

                End If
            End If
            kare_sayı += 1
        End Sub

        Sub resimçiz(ByVal resim As Bitmap)

        End Sub

        Sub kamera(ByVal konum As PointF, ByVal zoomx As Single)

        End Sub

    End Class

    Public Class Nesne

        Dim en, boy As Single

        Dim orjin As PointF
        Dim yerleştirme As PointF

        Dim aygıt As grafik_motor_v2.Motor

        Dim i As Integer

        Dim res11 As New Bitmap("C:\Users\Ev Bilgisayarı\Desktop\füze.bmp")

        Dim girdap As Bitmap
        Dim girdap1 As Bitmap
        Dim grdap As Graphics
        Dim anagrdap As Graphics

        Dim matrix As New Drawing2D.Matrix

        WithEvents değişme As TextBox

        Dim onaylanma As Short

        Sub New(ByVal motor As grafik_motor_v2.Motor, ByVal resim As Bitmap)

            anagrdap = Graphics.FromImage(motor.bit1)

            motor.nesne_Sayısı += 1

            motor.çizilen_nesneler.Text += 1

            aygıt = motor

            girdap = New Bitmap(resim)

            ortala()

            girdap1 = New Bitmap(100, 100)

            grdap = Graphics.FromImage(girdap1)

            değişme = motor.tikleyici


        End Sub

        Private Sub ortala()
            If girdap.Height > girdap.Width Then
                en = girdap.Height
                boy = girdap.Height

                orjin.X = girdap.Height / 2
                orjin.Y = girdap.Height / 2

                yerleştirme.X = (girdap.Height / 2) - (girdap.Width / 2)
                yerleştirme.Y = 0

            ElseIf girdap.Height = girdap.Width Then
                en = girdap.Height
                boy = girdap.Height

                orjin.X = girdap.Height / 2
                orjin.Y = girdap.Height / 2

                yerleştirme.X = 0
                yerleştirme.Y = 0

            Else
                en = girdap.Width
                boy = girdap.Width

                orjin.X = girdap.Width / 2
                orjin.Y = girdap.Width / 2

                yerleştirme.X = 0
                yerleştirme.Y = (girdap.Height / 2) - (girdap.Width / 2)

            End If

        End Sub

        Sub döndür(ByVal derece As Single, ByVal merkeznoktası As Point)

            grdap.Clear(Color.Transparent)

            matrix.RotateAt(derece, orjin)

            grdap.Transform = matrix

        End Sub

        Sub transparantlık()

        End Sub

        Private sütun, satır As Single

        Public Property X() As Single
            Get
                Return sütun
            End Get
            Set(ByVal value As Single)
                sütun = value
            End Set
        End Property

        Public Property Y() As Single
            Get
                Return satır
            End Get
            Set(ByVal value As Single)
                satır = value
            End Set
        End Property

        Dim a As Single

        Private Sub değişme_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles değişme.TextChanged

            grdap.Clear(Color.Transparent)

            grdap.DrawImage(girdap, yerleştirme)

            anagrdap.DrawImage(girdap1, X - orjin.X, Y - orjin.Y)

            aygıt.çizilen_nesneler.Text += 1

        End Sub

    End Class

    Public Class Transparan_Nesne

        Dim en, boy As Single

        Dim orjin As PointF
        Dim yerleştirme As PointF

        Dim aygıt As grafik_motor_v1.Motor

        Dim i As Integer

        Dim res11 As New Bitmap("C:\Users\Ev Bilgisayarı\Desktop\füze.bmp")

        Dim girdap As Bitmap
        Dim girdap1 As Bitmap
        Dim grdap As Graphics

        Dim matrix As New Drawing2D.Matrix

        WithEvents değişme As TextBox

        Dim onaylanma As Short

        Sub başla(ByVal motor As grafik_motor_v1.Motor, ByVal resim As Bitmap)

            motor.nesne_Sayısı += 1

            motor.çizilen_nesneler.Text += 1

            aygıt = motor

            girdap = New Bitmap(resim)
            girdap1 = New Bitmap(500, 500)

            ortala()

            grdap = Graphics.FromImage(girdap1)

            değişme = motor.tikleyici


        End Sub

        Private Sub ortala()
            If girdap.Height > girdap.Width Then
                en = girdap.Height
                boy = girdap.Height

                orjin.X = girdap.Height / 2
                orjin.Y = girdap.Height / 2

                yerleştirme.X = (girdap.Height / 2) - (girdap.Width / 2)
                yerleştirme.Y = 0

            ElseIf girdap.Height = girdap.Width Then
                en = girdap.Height
                boy = girdap.Height

                orjin.X = girdap.Height / 2
                orjin.Y = girdap.Height / 2

                yerleştirme.X = 0
                yerleştirme.Y = 0

            Else
                en = girdap.Width
                boy = girdap.Width

                orjin.X = girdap.Width / 2
                orjin.Y = girdap.Width / 2

                yerleştirme.X = 0
                yerleştirme.Y = (girdap.Height / 2) - (girdap.Width / 2)

            End If

        End Sub

        Sub döndür(ByVal derece As Single, ByVal merkeznoktası As Point)

            grdap.Clear(Color.Transparent)

            matrix.RotateAt(derece, orjin)

            grdap.Transform = matrix

        End Sub

        Sub transparantlık()

        End Sub

        Private sütun, satır As Single

        Public Property X() As Single
            Get
                Return sütun
            End Get
            Set(ByVal value As Single)
                sütun = value
            End Set
        End Property

        Public Property Y() As Single
            Get
                Return satır
            End Get
            Set(ByVal value As Single)
                satır = value
            End Set
        End Property

        Dim a As Single

        Private Sub değişme_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles değişme.TextChanged

            grdap.Clear(Color.Transparent)

            grdap.DrawImage(girdap, X - orjin.X, Y - orjin.Y)

            aygıt.gr.DrawImage(girdap1, 0, 0)

            aygıt.çizilen_nesneler.Text += 1

        End Sub

    End Class ' deneme aşamasında

    Public Class Çizgi

        Dim xx1, xx2, yy1, yy2 As Single
        Dim çizgikalınlığı As Single
        Dim rengi As Color
        Dim başlamanoktası, bitişnoktası As PointF

        Dim aygıt As grafik_motor_v1.Motor

        WithEvents değişme As TextBox

        Sub New(ByVal motor As grafik_motor_v1.Motor)

            aygıt = motor

            renk = Color.Black

            çizgikalınlığı = 1

            motor.nesne_Sayısı += 1

            motor.çizilen_nesneler.Text += 1

            değişme = motor.tikleyici
        End Sub

        Public Property X1() As Single
            Get
                Return xx1
            End Get
            Set(ByVal value As Single)
                xx1 = value
            End Set
        End Property

        Public Property Y1() As Single
            Get
                Return yy1
            End Get
            Set(ByVal value As Single)
                yy1 = value
            End Set
        End Property

        Public Property X2() As Single
            Get
                Return xx2
            End Get
            Set(ByVal value As Single)
                xx2 = value
            End Set
        End Property

        Public Property Y2() As Single
            Get
                Return yy2
            End Get
            Set(ByVal value As Single)
                yy2 = value
            End Set
        End Property

        Public Property çizgi_kalınlığı() As Single
            Get
                Return çizgikalınlığı
            End Get
            Set(ByVal value As Single)
                çizgikalınlığı = value
            End Set
        End Property

        Public Property renk() As Color
            Get
                Return rengi
            End Get
            Set(ByVal value As Color)
                rengi = value
            End Set
        End Property

        Public Property başlama_noktası() As PointF
            Get
                Return başlamanoktası
                xx1 = başlamanoktası.X
                yy1 = başlamanoktası.Y
            End Get
            Set(ByVal value As PointF)
                başlamanoktası = value
                xx1 = başlamanoktası.X
                yy1 = başlamanoktası.Y
            End Set
        End Property

        Public Property bitiş_noktası() As PointF
            Get
                Return bitişnoktası
                xx2 = bitişnoktası.X
                yy2 = bitişnoktası.Y
            End Get
            Set(ByVal value As PointF)
                bitişnoktası = value
                xx2 = bitişnoktası.X
                yy2 = bitişnoktası.Y
            End Set
        End Property

        Private Sub değişme_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles değişme.TextChanged

            aygıt.gr.DrawLine(New Pen(renk, çizgikalınlığı), xx1, yy1, xx2, yy2)

            aygıt.çizilen_nesneler.Text += 1

        End Sub
    End Class

    Public Class Etiket
        Dim xx1, xx2, yy1, yy2 As Single
        Dim çizgikalınlığı As Single
        Dim rengi As Brush

        Dim yazı1 As String
        Dim yazıtipi As Font

        Dim aygıt As grafik_motor_v1.Motor

        WithEvents değişme As TextBox

        Sub New(ByVal motor As grafik_motor_v1.Motor, Optional ByVal yazı As String = "")
            aygıt = motor

            yazı1 = yazı

            çizgikalınlığı = 12

            yazıtipi = New Font("Courner New", çizgikalınlığı, FontStyle.Regular)

            renk = Brushes.Black

            çizgikalınlığı = 1

            motor.nesne_Sayısı += 1

            motor.çizilen_nesneler.Text += 1

            değişme = motor.tikleyici
        End Sub

        Public Property X1() As Single
            Get
                Return xx1
            End Get
            Set(ByVal value As Single)
                xx1 = value
            End Set
        End Property

        Public Property Y1() As Single
            Get
                Return yy1
            End Get
            Set(ByVal value As Single)
                yy1 = value
            End Set
        End Property

        Public Property X2() As Single
            Get
                Return xx2
            End Get
            Set(ByVal value As Single)
                xx2 = value
            End Set
        End Property

        Public Property Y2() As Single
            Get
                Return yy2
            End Get
            Set(ByVal value As Single)
                yy2 = value
            End Set
        End Property

        Public Property çizgi_kalınlığı() As Single
            Get
                Return çizgikalınlığı
            End Get
            Set(ByVal value As Single)
                çizgikalınlığı = value
                yazıtipi = New Font(yazı_tipi.FontFamily.Name, çizgikalınlığı, FontStyle.Regular)
            End Set
        End Property

        Public Property renk() As Brush
            Get
                Return rengi
            End Get
            Set(ByVal value As Brush)
                rengi = value
            End Set
        End Property

        Public Property yazı() As String
            Get
                Return yazı1
            End Get
            Set(ByVal value As String)
                yazı1 = value
            End Set
        End Property

        Public Property yazı_tipi() As Font
            Get
                Return yazıtipi
            End Get
            Set(ByVal value As Font)
                yazıtipi = value



            End Set
        End Property

        Private Sub değişme_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles değişme.TextChanged

            aygıt.gr.DrawString(yazı1, yazıtipi, renk, xx1, yy1)

            aygıt.çizilen_nesneler.Text += 1

        End Sub
    End Class

End Class

Public Class grafik_motor_v3


    Public Class Motor

        Public WithEvents tikleyici As New TextBox
        WithEvents textbox2 As New TextBox
        WithEvents textbox3 As New TextBox

        WithEvents timer1 As New Timer
        WithEvents timer3 As New Timer
        WithEvents timer2 As New Timer

        Dim kare_sayı As Integer
        Public nesne_Sayısı As Integer
        Dim i As Integer
        Dim anaçizici As Graphics
        Dim bit1gr As Graphics
        Dim bit2gr As Graphics
        Public WithEvents çizilen_nesneler As New TextBox

        Public gr As Graphics
        Public gr1 As Graphics
        Public gr2 As Graphics
        Public gr3 As Graphics
        Public gr4 As Graphics
        Public gr5 As Graphics

        Public Shared bit1 As New Bitmap(600, 600, Imaging.PixelFormat.Format32bppPArgb)
        Dim arkaplan As New Bitmap(1000, 1000)
        Dim bit2 As New Bitmap(1200, 800)
        Dim komutan2 As Nesne
        WithEvents gösterimalanı As PictureBox

        Public Sub New(ByVal alan As PictureBox)

            tikleyici = New TextBox
            textbox2 = New TextBox
            textbox3 = New TextBox

            timer1 = New Timer
            timer2 = New Timer
            timer3 = New Timer

            tikleyici.Top = 100

            textbox2.Left = 200

            textbox3.Left = 100

            timer1.Interval = 1

            timer2.Interval = 1000

            timer3.Interval = 1

            gösterimalanı = alan

            çizilen_nesneler = New TextBox

            çizilen_nesneler.Text = "0"

            tikleyici.Text = 0

            timer1.Enabled = True

            timer2.Enabled = True

            gr = Graphics.FromImage(bit1)
            gr1 = Graphics.FromImage(bit1)
            gr2 = Graphics.FromImage(bit1)
            gr3 = Graphics.FromImage(bit1)
            gr4 = Graphics.FromImage(bit1)
            gr5 = Graphics.FromImage(bit1)


        End Sub

        Public Sub çözünürlük(ByVal x As Integer, ByVal y As Integer)

            gr.ScaleTransform(x, y)

        End Sub

        Sub yenilenme_hızını_göster()
            tikleyici.Parent = gösterimalanı

            textbox2.Parent = gösterimalanı

            textbox3.Parent = gösterimalanı
        End Sub

        Public Sub yeni_nesne_oluştur()

        End Sub

        Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timer1.Tick

            i += 1

            If i = 2 Then
                timer3.Enabled = True
            End If

            textbox3.Text = i + 4

        End Sub

        Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timer2.Tick

            textbox2.Text = kare_sayı
            kare_sayı = 0


        End Sub

        Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles textbox2.TextChanged

        End Sub

        Private Sub Timer3_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timer3.Tick
            textbox3.Text = i + 1
        End Sub

        Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles textbox3.TextChanged

            If Not kare_sayı = 0 Then
                If çizilen_nesneler.Text = nesne_Sayısı Then

                    gösterimalanı.Image = bit1

                    gr.Clear(Color.Transparent)

                    ' gr.FillRectangle(Brushes.Wheat, New Rectangle(0, 0, 500, 500))

                    çizilen_nesneler.Text = 0

                    tikleyici.Text += 1

                End If
            End If
            kare_sayı += 1
        End Sub

        Sub kamera(ByVal konum As PointF, ByVal zoomx As Single)

        End Sub

    End Class

    Public Class Nesne

        Dim en, boy As Single

        Dim orjin As PointF
        Dim yerleştirme As PointF

        Dim aygıt As grafik_motor_v1.Motor

        Dim i As Integer

        Dim gr As Graphics

        Dim girdap As Bitmap
        Dim girdap1 As Bitmap
        Dim grdap As Graphics

        Dim matrix As New Drawing2D.Matrix

        WithEvents değişme As TextBox

        Dim onaylanma As Short

        Sub New(ByVal motor As grafik_motor_v1.Motor, ByVal resim As Bitmap)

            motor.nesne_Sayısı += 1

            motor.çizilen_nesneler.Text += 1

            aygıt = motor

            girdap = New Bitmap(resim)

            ortala()

            i = Rnd(5) * 5

            girdap1 = New Bitmap(100, 100)

            grdap = Graphics.FromImage(girdap1)

            değişme = motor.tikleyici

            If i = 1 Then
                gr = aygıt.gr1
            End If

            If i = 2 Then
                gr = aygıt.gr2
            End If

            If i = 3 Then
                gr = aygıt.gr3
            End If

            If i > 3 Then
                gr = aygıt.gr4
            End If

            If i = 0 Then
                gr = aygıt.gr5
            End If

        End Sub

        Private Sub ortala()
            If girdap.Height > girdap.Width Then
                en = girdap.Height
                boy = girdap.Height

                orjin.X = girdap.Height / 2
                orjin.Y = girdap.Height / 2

                yerleştirme.X = (girdap.Height / 2) - (girdap.Width / 2)
                yerleştirme.Y = 0

            ElseIf girdap.Height = girdap.Width Then
                en = girdap.Height
                boy = girdap.Height

                orjin.X = girdap.Height / 2
                orjin.Y = girdap.Height / 2

                yerleştirme.X = 0
                yerleştirme.Y = 0

            Else
                en = girdap.Width
                boy = girdap.Width

                orjin.X = girdap.Width / 2
                orjin.Y = girdap.Width / 2

                yerleştirme.X = 0
                yerleştirme.Y = (girdap.Height / 2) - (girdap.Width / 2)

            End If

        End Sub

        Sub döndür(ByVal derece As Single, ByVal merkeznoktası As Point)

            grdap.Clear(Color.Transparent)

            matrix.RotateAt(derece, orjin)

            grdap.Transform = matrix

        End Sub

        Sub transparantlık()

        End Sub

        Private sütun, satır As Single

        Public Property X() As Single
            Get
                Return sütun
            End Get
            Set(ByVal value As Single)
                sütun = value
            End Set
        End Property

        Public Property Y() As Single
            Get
                Return satır
            End Get
            Set(ByVal value As Single)
                satır = value
            End Set
        End Property

        Dim a As Single

        Private Sub değişme_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles değişme.TextChanged

            grdap.DrawImage(girdap, yerleştirme)



            aygıt.gr.DrawImage(girdap1, X - orjin.X, Y - orjin.Y)

            aygıt.çizilen_nesneler.Text += 1

        End Sub

    End Class

    Public Class Transparan_Nesne

        Dim en, boy As Single

        Dim orjin As PointF
        Dim yerleştirme As PointF

        Dim aygıt As grafik_motor_v1.Motor

        Dim i As Integer

        Dim res11 As New Bitmap("C:\Users\Ev Bilgisayarı\Desktop\füze.bmp")

        Dim girdap As Bitmap
        Dim girdap1 As Bitmap
        Dim grdap As Graphics

        Dim matrix As New Drawing2D.Matrix

        WithEvents değişme As TextBox

        Dim onaylanma As Short

        Sub başla(ByVal motor As grafik_motor_v1.Motor, ByVal resim As Bitmap)

            motor.nesne_Sayısı += 1

            motor.çizilen_nesneler.Text += 1

            aygıt = motor

            girdap = New Bitmap(resim)
            girdap1 = New Bitmap(500, 500)

            ortala()

            grdap = Graphics.FromImage(girdap1)

            değişme = motor.tikleyici


        End Sub

        Private Sub ortala()
            If girdap.Height > girdap.Width Then
                en = girdap.Height
                boy = girdap.Height

                orjin.X = girdap.Height / 2
                orjin.Y = girdap.Height / 2

                yerleştirme.X = (girdap.Height / 2) - (girdap.Width / 2)
                yerleştirme.Y = 0

            ElseIf girdap.Height = girdap.Width Then
                en = girdap.Height
                boy = girdap.Height

                orjin.X = girdap.Height / 2
                orjin.Y = girdap.Height / 2

                yerleştirme.X = 0
                yerleştirme.Y = 0

            Else
                en = girdap.Width
                boy = girdap.Width

                orjin.X = girdap.Width / 2
                orjin.Y = girdap.Width / 2

                yerleştirme.X = 0
                yerleştirme.Y = (girdap.Height / 2) - (girdap.Width / 2)

            End If

        End Sub

        Sub döndür(ByVal derece As Single, ByVal merkeznoktası As Point)

            grdap.Clear(Color.Transparent)

            matrix.RotateAt(derece, orjin)

            grdap.Transform = matrix

        End Sub

        Sub transparantlık()

        End Sub

        Private sütun, satır As Single

        Public Property X() As Single
            Get
                Return sütun
            End Get
            Set(ByVal value As Single)
                sütun = value
            End Set
        End Property

        Public Property Y() As Single
            Get
                Return satır
            End Get
            Set(ByVal value As Single)
                satır = value
            End Set
        End Property

        Dim a As Single

        Private Sub değişme_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles değişme.TextChanged

            grdap.Clear(Color.Transparent)

            grdap.DrawImage(girdap, X - orjin.X, Y - orjin.Y)

            aygıt.gr.DrawImage(girdap1, 0, 0)

            aygıt.çizilen_nesneler.Text += 1

        End Sub

    End Class ' deneme aşamasında

    Public Class Çizgi

        Dim xx1, xx2, yy1, yy2 As Single
        Dim çizgikalınlığı As Single
        Dim rengi As Color
        Dim başlamanoktası, bitişnoktası As PointF

        Dim aygıt As grafik_motor_v1.Motor

        WithEvents değişme As TextBox

        Sub New(ByVal motor As grafik_motor_v1.Motor)

            aygıt = motor

            renk = Color.Black

            çizgikalınlığı = 1

            motor.nesne_Sayısı += 1

            motor.çizilen_nesneler.Text += 1

            değişme = motor.tikleyici
        End Sub

        Public Property X1() As Single
            Get
                Return xx1
            End Get
            Set(ByVal value As Single)
                xx1 = value
            End Set
        End Property

        Public Property Y1() As Single
            Get
                Return yy1
            End Get
            Set(ByVal value As Single)
                yy1 = value
            End Set
        End Property

        Public Property X2() As Single
            Get
                Return xx2
            End Get
            Set(ByVal value As Single)
                xx2 = value
            End Set
        End Property

        Public Property Y2() As Single
            Get
                Return yy2
            End Get
            Set(ByVal value As Single)
                yy2 = value
            End Set
        End Property

        Public Property çizgi_kalınlığı() As Single
            Get
                Return çizgikalınlığı
            End Get
            Set(ByVal value As Single)
                çizgikalınlığı = value
            End Set
        End Property

        Public Property renk() As Color
            Get
                Return rengi
            End Get
            Set(ByVal value As Color)
                rengi = value
            End Set
        End Property

        Public Property başlama_noktası() As PointF
            Get
                Return başlamanoktası
                xx1 = başlamanoktası.X
                yy1 = başlamanoktası.Y
            End Get
            Set(ByVal value As PointF)
                başlamanoktası = value
                xx1 = başlamanoktası.X
                yy1 = başlamanoktası.Y
            End Set
        End Property

        Public Property bitiş_noktası() As PointF
            Get
                Return bitişnoktası
                xx2 = bitişnoktası.X
                yy2 = bitişnoktası.Y
            End Get
            Set(ByVal value As PointF)
                bitişnoktası = value
                xx2 = bitişnoktası.X
                yy2 = bitişnoktası.Y
            End Set
        End Property

        Private Sub değişme_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles değişme.TextChanged

            aygıt.gr.DrawLine(New Pen(renk, çizgikalınlığı), xx1, yy1, xx2, yy2)

            aygıt.çizilen_nesneler.Text += 1

        End Sub
    End Class

    Public Class Etiket
        Dim xx1, xx2, yy1, yy2 As Single
        Dim çizgikalınlığı As Single
        Dim rengi As Brush

        Dim yazı1 As String
        Dim yazıtipi As Font

        Dim aygıt As grafik_motor_v1.Motor

        WithEvents değişme As TextBox

        Sub New(ByVal motor As grafik_motor_v1.Motor, Optional ByVal yazı As String = "")
            aygıt = motor

            yazı1 = yazı

            çizgikalınlığı = 12

            yazıtipi = New Font("Courner New", çizgikalınlığı, FontStyle.Regular)

            renk = Brushes.Black

            çizgikalınlığı = 1

            motor.nesne_Sayısı += 1

            motor.çizilen_nesneler.Text += 1

            değişme = motor.tikleyici
        End Sub

        Public Property X1() As Single
            Get
                Return xx1
            End Get
            Set(ByVal value As Single)
                xx1 = value
            End Set
        End Property

        Public Property Y1() As Single
            Get
                Return yy1
            End Get
            Set(ByVal value As Single)
                yy1 = value
            End Set
        End Property

        Public Property X2() As Single
            Get
                Return xx2
            End Get
            Set(ByVal value As Single)
                xx2 = value
            End Set
        End Property

        Public Property Y2() As Single
            Get
                Return yy2
            End Get
            Set(ByVal value As Single)
                yy2 = value
            End Set
        End Property

        Public Property çizgi_kalınlığı() As Single
            Get
                Return çizgikalınlığı
            End Get
            Set(ByVal value As Single)
                çizgikalınlığı = value
                yazıtipi = New Font(yazı_tipi.FontFamily.Name, çizgikalınlığı, FontStyle.Regular)
            End Set
        End Property

        Public Property renk() As Brush
            Get
                Return rengi
            End Get
            Set(ByVal value As Brush)
                rengi = value
            End Set
        End Property

        Public Property yazı() As String
            Get
                Return yazı1
            End Get
            Set(ByVal value As String)
                yazı1 = value
            End Set
        End Property

        Public Property yazı_tipi() As Font
            Get
                Return yazıtipi
            End Get
            Set(ByVal value As Font)
                yazıtipi = value



            End Set
        End Property

        Private Sub değişme_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles değişme.TextChanged

            aygıt.gr.DrawString(yazı1, yazıtipi, renk, xx1, yy1)

            aygıt.çizilen_nesneler.Text += 1

        End Sub
    End Class

End Class ' --- Grafik motoru_v1 ile aynı ---' ' --- Denektir ---' 


'  ╔════════════════════════════════════╗  '
'  ║ --- SeRBeST YaZıLıM iDeaLiMDiR --- ║  '
'  ╠════════════════════════════════════╣  '
'  ║        --- ADN YAZILIM ---         ║  '
'  ╚════════════════════════════════════╝  '