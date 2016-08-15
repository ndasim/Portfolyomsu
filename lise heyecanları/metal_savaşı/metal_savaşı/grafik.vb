
Public Class Grafik

    Public Class Toplayıcı


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

        Public katman_0 As New iletgeç
        Public katman_1 As iletgeç
        Public katman_2 As iletgeç
        Public katman_3 As iletgeç

        Public Shared bit1 As New Bitmap(700, 700, Imaging.PixelFormat.Format32bppPArgb)
        Dim arkaplan As New Bitmap(1000, 1000)
        WithEvents gösterimalanı As PictureBox

        Public Sub New(ByVal alan As PictureBox)

            textbox2 = New TextBox
            textbox3 = New TextBox

            timer1 = New Timer
            timer2 = New Timer
            timer3 = New Timer

            textbox2.Left = 200

            textbox3.Left = 100

            timer1.Interval = 1

            timer2.Interval = 1000

            timer3.Interval = 1

            gösterimalanı = alan

            çizilen_nesneler = New TextBox

            çizilen_nesneler.Text = "0"

            timer1.Enabled = True

            timer2.Enabled = True

            gr = Graphics.FromImage(bit1)

            katman_1 = New iletgeç
            katman_2 = New iletgeç
            katman_3 = New iletgeç

        End Sub

        Public Sub çözünürlük(ByVal x As Integer, ByVal y As Integer)

            gr.ScaleTransform(x, y)

        End Sub

        Sub yenilenme_hızını_göster()

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

                    ' gr.Clear(Color.Transparent)

                    ' gr.FillRectangle(Brushes.Wheat, New Rectangle(0, 0, 500, 500))

                    çizilen_nesneler.Text = 0

                    katman_0.ileti_yolla()
                    katman_1.ileti_yolla()
                    katman_2.ileti_yolla()
                    katman_3.ileti_yolla()

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

        Dim aygıt As Grafik.Toplayıcı

        Dim katman_değeri As Integer

        Dim girdap As Bitmap
        Dim girdap1 As Bitmap
        Dim grdap As Graphics

        Dim matrix As New Drawing2D.Matrix

        WithEvents değişme As iletgeç

        Dim onaylanma As Short

        Sub New(ByVal motor As Grafik.Toplayıcı, ByVal resim As Bitmap)

            motor.nesne_Sayısı += 1

            motor.çizilen_nesneler.Text += 1

            aygıt = motor

            girdap = New Bitmap(resim)

            ortala()

            girdap1 = New Bitmap(100, 100)

            grdap = Graphics.FromImage(girdap1)

            değişme = motor.katman_0

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

        Sub katman(ByVal değer As Short)

            If değer < 4 Then

                Select Case değer
                    Case 0
                        değişme = aygıt.katman_0
                    Case 1
                        değişme = aygıt.katman_1
                    Case 2
                        değişme = aygıt.katman_2
                    Case 3
                        değişme = aygıt.katman_3
                End Select

                katman_değeri = değer

            Else
                MsgBox("Hata : Katman Değeri 0 ile 3 Arasında Bir Değerini Alır", MsgBoxStyle.Critical, "HATA")
            End If

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

        Public Sub görünürlük(ByVal değer As Boolean)
            If değer = False Then

                aygıt.nesne_Sayısı -= 1
                aygıt.çizilen_nesneler.Text -= 1
                değişme = New iletgeç

                'MsgBox("bir nesne daha silindi")
            End If
            If değer = True Then

                Select Case katman_değeri
                    Case 0
                        değişme = aygıt.katman_0
                    Case 1
                        değişme = aygıt.katman_1
                    Case 2
                        değişme = aygıt.katman_2
                    Case 3
                        değişme = aygıt.katman_3
                End Select

            End If
        End Sub

        Dim a As Single

        Private Sub değişme_TextChanged() Handles değişme.ileti

            grdap.DrawImage(girdap, yerleştirme)

            aygıt.gr.DrawImage(girdap1, X - orjin.X, Y - orjin.Y)

            aygıt.çizilen_nesneler.Text += 1

        End Sub

    End Class

    Public Class Çizgi

        Dim xx1, xx2, yy1, yy2 As Single
        Dim çizgikalınlığı As Single
        Dim rengi As Color
        Dim başlamanoktası, bitişnoktası As PointF

        Dim aygıt As Grafik.Toplayıcı

        Dim katman_değeri As Integer

        WithEvents değişme As iletgeç

        Sub New(ByVal motor As Grafik.Toplayıcı)

            aygıt = motor

            renk = Color.Black

            çizgikalınlığı = 1

            motor.nesne_Sayısı += 1

            motor.çizilen_nesneler.Text += 1

            değişme = motor.katman_0
        End Sub

        Public Sub görünürlük(ByVal değer As Boolean)
            If değer = False Then

                aygıt.nesne_Sayısı -= 1
                aygıt.çizilen_nesneler.Text -= 1
                değişme = New iletgeç

                'MsgBox("bir nesne daha silindi")
            End If
            If değer = True Then

                Select Case katman_değeri
                    Case 0
                        değişme = aygıt.katman_0
                    Case 1
                        değişme = aygıt.katman_1
                    Case 2
                        değişme = aygıt.katman_2
                    Case 3
                        değişme = aygıt.katman_3
                End Select

            End If
        End Sub

        Sub katman(ByVal değer As Short)

            If değer < 4 Then

                Select Case değer
                    Case 0
                        değişme = aygıt.katman_0
                    Case 1
                        değişme = aygıt.katman_1
                    Case 2
                        değişme = aygıt.katman_2
                    Case 3
                        değişme = aygıt.katman_3
                End Select

                katman_değeri = değer

            Else
                MsgBox("Hata : Katman Değeri 0 ile 3 Arasında Bir Değerini Alır", MsgBoxStyle.Critical, "HATA")
            End If

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

        Private Sub değişme_TextChanged() Handles değişme.ileti

            aygıt.gr.DrawLine(New Pen(renk, çizgikalınlığı), xx1, yy1, xx2, yy2)

            aygıt.çizilen_nesneler.Text += 1

        End Sub
    End Class

    Public Class Etiket

        Dim xx1, yy1 As Single
        Dim çizgikalınlığı As Single
        Dim rengi As Brush

        Dim yazı1 As String
        Dim yazıtipi As Font

        Dim katman_değeri As Integer

        Dim aygıt As Grafik.Toplayıcı

        WithEvents değişme As iletgeç

        Sub New(ByVal motor As Grafik.Toplayıcı, Optional ByVal yazı As String = "")
            aygıt = motor

            yazı1 = yazı

            çizgikalınlığı = 12

            yazıtipi = New Font("Courner New", çizgikalınlığı, FontStyle.Regular)

            renk = Brushes.Black

            çizgikalınlığı = 1

            motor.nesne_Sayısı += 1

            motor.çizilen_nesneler.Text += 1

            değişme = motor.katman_0
        End Sub

        Public Sub görünürlük(ByVal değer As Boolean)
            If değer = False Then

                aygıt.nesne_Sayısı -= 1
                aygıt.çizilen_nesneler.Text -= 1
                değişme = New iletgeç

                'MsgBox("bir nesne daha silindi")
            End If
            If değer = True Then
                Select Case katman_değeri
                    Case 0
                        değişme = aygıt.katman_0
                    Case 1
                        değişme = aygıt.katman_1
                    Case 2
                        değişme = aygıt.katman_2
                    Case 3
                        değişme = aygıt.katman_3
                End Select
            End If
        End Sub

        Sub katman(ByVal değer As Short)

            If değer < 4 Then

                Select Case değer
                    Case 0
                        değişme = aygıt.katman_0
                    Case 1
                        değişme = aygıt.katman_1
                    Case 2
                        değişme = aygıt.katman_2
                    Case 3
                        değişme = aygıt.katman_3
                End Select

                katman_değeri = değer

            Else
                MsgBox("Hata : Katman Değeri 0 ile 3 Arasında Bir Değerini Alır", MsgBoxStyle.Critical, "HATA")
            End If

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

        Private Sub değişme_TextChanged() Handles değişme.ileti

            aygıt.gr.DrawString(yazı1, yazıtipi, renk, xx1, yy1)

            aygıt.çizilen_nesneler.Text += 1

        End Sub
    End Class

    Public Class Birden_Çok_Çizgi

        Public yol_haritası() As PointF

        Dim çizgikalınlığı As Single

        Dim rengi As Color

        Dim aygıt As Grafik.Toplayıcı

        Dim katman_değeri As Integer

        WithEvents değişme As iletgeç

        Sub New(ByVal motor As Grafik.Toplayıcı, ByVal çizgi_noktaları() As PointF)

            yol_haritası = çizgi_noktaları

            aygıt = motor

            renk = Color.Black

            çizgikalınlığı = 1

            motor.nesne_Sayısı += 1

            motor.çizilen_nesneler.Text += 1

            değişme = motor.katman_0
        End Sub

        Public Sub görünürlük(ByVal değer As Boolean)
            If değer = False Then

                aygıt.nesne_Sayısı -= 1
                aygıt.çizilen_nesneler.Text -= 1
                değişme = New iletgeç

                'MsgBox("bir nesne daha silindi")
            End If
            If değer = True Then
                Select Case katman_değeri
                    Case 0
                        değişme = aygıt.katman_0
                    Case 1
                        değişme = aygıt.katman_1
                    Case 2
                        değişme = aygıt.katman_2
                    Case 3
                        değişme = aygıt.katman_3
                End Select
            End If
        End Sub

        Sub katman(ByVal değer As Short)

            If değer < 4 Then

                Select Case değer
                    Case 0
                        değişme = aygıt.katman_0
                    Case 1
                        değişme = aygıt.katman_1
                    Case 2
                        değişme = aygıt.katman_2
                    Case 3
                        değişme = aygıt.katman_3
                End Select

                katman_değeri = değer

            Else
                MsgBox("Hata : Katman Değeri 0 ile 3 Arasında Bir Değerini Alır", MsgBoxStyle.Critical, "HATA")
            End If

        End Sub

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

        Private Sub değişme_TextChanged() Handles değişme.ileti

            aygıt.gr.DrawLines(New Pen(renk, çizgikalınlığı), yol_haritası)

            aygıt.çizilen_nesneler.Text += 1

        End Sub

    End Class

    Public Class çember

        Public çember_karesi As RectangleF

        Dim xx1, xx2, yy1, yy2 As Single

        Dim çizgikalınlığı As Single
        Dim rengi As Color
        Dim başlamanoktası, bitişnoktası As PointF

        Dim orjin As Point

        Dim yarçap As Single

        Dim katman_değeri As Integer

        Dim aygıt As Grafik.Toplayıcı

        WithEvents değişme As iletgeç

        Sub New(ByVal motor As Grafik.Toplayıcı, ByVal yarıçap As Single)

            aygıt = motor

            renk = Color.Black

            çizgikalınlığı = 1

            yarçap = yarıçap

            motor.nesne_Sayısı += 1

            motor.çizilen_nesneler.Text += 1

            değişme = motor.katman_0
        End Sub

        Public Sub görünürlük(ByVal değer As Boolean)
            If değer = False Then

                aygıt.nesne_Sayısı -= 1
                aygıt.çizilen_nesneler.Text -= 1
                değişme = New iletgeç

                'MsgBox("bir nesne daha silindi")
            End If
            If değer = True Then
                Select Case katman_değeri
                    Case 0
                        değişme = aygıt.katman_0
                    Case 1
                        değişme = aygıt.katman_1
                    Case 2
                        değişme = aygıt.katman_2
                    Case 3
                        değişme = aygıt.katman_3
                End Select
            End If
        End Sub

        Sub katman(ByVal değer As Short)

            If değer < 4 Then

                Select Case değer
                    Case 0
                        değişme = aygıt.katman_0
                    Case 1
                        değişme = aygıt.katman_1
                    Case 2
                        değişme = aygıt.katman_2
                    Case 3
                        değişme = aygıt.katman_3
                End Select

                katman_değeri = değer

            Else
                MsgBox("Hata : Katman Değeri 0 ile 3 Arasında Bir Değerini Alır", MsgBoxStyle.Critical, "HATA")
            End If

        End Sub

        Private Sub değişme_TextChanged() Handles değişme.ileti

            aygıt.gr.DrawEllipse(New Pen(rengi, çizgikalınlığı), çember_karesi)

            aygıt.çizilen_nesneler.Text += 1

        End Sub

        Private Sub yarıçapı_kareye_dönüştür()

            çember_karesi.X = orjin.X - yarçap
            çember_karesi.Y = orjin.Y - yarçap

            çember_karesi.Height = yarçap * 2
            çember_karesi.Width = yarçap * 2

        End Sub

        Private Sub yarıçap_çizgisini_ölç()

            Dim xuzunluğu, yuzunluğu As Single

            xuzunluğu = xx2 - xx1

            yuzunluğu = yy2 - yy1

            yarçap = ((xuzunluğu ^ 2) + (yuzunluğu ^ 2)) ^ 0.5

        End Sub

        Public Property X1() As Single
            Get
                Return xx1
            End Get
            Set(ByVal value As Single)
                xx1 = value
                yarıçap_çizgisini_ölç()

                orjin.X = xx1
                orjin.Y = xx2

                yarıçapı_kareye_dönüştür()
            End Set
        End Property

        Public Property Y1() As Single
            Get
                Return yy1
            End Get
            Set(ByVal value As Single)
                yy1 = value

                yarıçap_çizgisini_ölç()

                orjin.X = xx1
                orjin.Y = xx2

                yarıçapı_kareye_dönüştür()
            End Set
        End Property

        Public Property X2() As Single
            Get
                Return xx2
            End Get
            Set(ByVal value As Single)
                xx2 = value


                yarıçap_çizgisini_ölç()

                orjin.X = xx1
                orjin.Y = xx2

                yarıçapı_kareye_dönüştür()
            End Set
        End Property

        Public Property Y2() As Single
            Get
                Return yy2
            End Get
            Set(ByVal value As Single)
                yy2 = value

                yarıçap_çizgisini_ölç()

                orjin.X = xx1
                orjin.Y = xx2

                yarıçapı_kareye_dönüştür()

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
            End Get

            Set(ByVal value As PointF)
                bitişnoktası = value
                xx2 = bitişnoktası.X
                yy2 = bitişnoktası.Y
            End Set
        End Property

        Public Property merkez() As Point
            Get
                Return orjin
            End Get
            Set(ByVal value As Point)

                orjin = value

                yarıçapı_kareye_dönüştür()

            End Set
        End Property

        Public Property yarıçap() As Single
            Get
                Return yarçap
            End Get
            Set(ByVal value As Single)

                yarçap = value

                yarıçapı_kareye_dönüştür()

            End Set
        End Property

    End Class

    Public Class kare

        Dim xx1, yy1 As Single
        Dim çizgikalınlığı As Single
        Dim rengi As Brush

        Public kare As Rectangle

        Dim boyut As SizeF

        Dim aygıt As Grafik.Toplayıcı

        Dim katman_değeri As Integer

        WithEvents değişme As iletgeç

        Sub New(ByVal motor As Grafik.Toplayıcı, Optional ByVal genişlik As Single = 10, Optional ByVal yükseklik As Single = 10)
            aygıt = motor

            çizgikalınlığı = 12

            renk = Brushes.Black

            boyut = New SizeF(genişlik, yükseklik)

            kare.Height = yükseklik
            kare.Width = genişlik

            çizgikalınlığı = 1



            motor.nesne_Sayısı += 1

            motor.çizilen_nesneler.Text += 1

            değişme = motor.katman_0
        End Sub

        Public Sub görünürlük(ByVal değer As Boolean)
            If değer = False Then

                aygıt.nesne_Sayısı -= 1
                aygıt.çizilen_nesneler.Text -= 1
                değişme = New iletgeç
                'MsgBox("bir nesne daha silindi")
            End If
            If değer = True Then

                Select Case katman_değeri
                    Case 0
                        değişme = aygıt.katman_0
                    Case 1
                        değişme = aygıt.katman_1
                    Case 2
                        değişme = aygıt.katman_2
                    Case 3
                        değişme = aygıt.katman_3
                End Select
            End If
        End Sub

        Sub katman(ByVal değer As Short)

            If değer < 4 Then

                Select Case değer
                    Case 0
                        değişme = aygıt.katman_0
                    Case 1
                        değişme = aygıt.katman_1
                    Case 2
                        değişme = aygıt.katman_2
                    Case 3
                        değişme = aygıt.katman_3
                End Select

                katman_değeri = değer

            Else
                MsgBox("Hata : Katman Değeri 0 ile 3 Arasında Bir Değerini Alır", MsgBoxStyle.Critical, "HATA")
            End If

        End Sub

        Public Property X() As Single
            Get
                Return xx1
            End Get
            Set(ByVal value As Single)
                xx1 = value
                kare.X = xx1
            End Set
        End Property

        Public Property Y() As Single
            Get
                Return yy1
            End Get
            Set(ByVal value As Single)
                yy1 = value
                kare.Y = yy1
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

        Public Property renk() As Brush
            Get
                Return rengi
            End Get
            Set(ByVal value As Brush)
                rengi = value
            End Set
        End Property

        Public Property ölçüt() As SizeF
            Get
                Return boyut
            End Get
            Set(ByVal value As SizeF)
                boyut = value
            End Set
        End Property

        Public Property genişlik() As Single
            Get
                Return boyut.Width
            End Get
            Set(ByVal value As Single)
                boyut.Width = value
                kare.Width = value
            End Set
        End Property

        Public Property yükseklik() As Single
            Get
                Return boyut.Height
            End Get
            Set(ByVal value As Single)
                boyut.Height = value
                kare.Height = value
            End Set
        End Property

        Private Sub değişme_TextChanged() Handles değişme.ileti

            aygıt.gr.DrawRectangle(New Pen(rengi, çizgikalınlığı), xx1, yy1, boyut.Width, boyut.Height)

            aygıt.çizilen_nesneler.Text += 1

        End Sub

    End Class

End Class

Public Class iletgeç

    Public Event ileti()

    Sub ileti_yolla()
        RaiseEvent ileti()
    End Sub

End Class
