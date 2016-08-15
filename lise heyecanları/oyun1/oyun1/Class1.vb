Public Structure renk_bildirgesi

    Dim x As Integer
    Dim y As Integer
    Dim verilen_renk As renk
    Dim istenen As String
    Dim koordad As String

    Sub New(ByVal rengi As renk)
        verilen_renk = rengi
    End Sub

    Sub New(ByVal x As Integer, ByVal y As Integer, ByVal renk As renk)
        x = x
        y = y
        verilen_renk = renk
    End Sub

End Structure

Friend Class Nokta

    Public rengim As renk
    Public koord As String

    WithEvents bildirge As iletişim_kanalı

    Sub New(ByVal renkbildirisi As renk_bildirgesi, ByVal iletişim As iletişim_kanalı)

        rengim = renkbildirisi.verilen_renk

        koord = renkbildirisi.x & renkbildirisi.y

    End Sub

    Private Sub bildirge_bildiri(ByVal bildiri As renk_bildirgesi) Handles bildirge.bildiri

        If bildiri.koordad = koord Then

            If bildiri.istenen = "yazma" Then

                rengim = bildiri.verilen_renk

            ElseIf bildiri.istenen = "okuma" Then



            End If

        End If

    End Sub

End Class

Public Class nokta_haritası

    Dim noktalar(,) As Nokta

    Dim noktasayısı As Integer

    Dim yüksklik, genişlik As Integer

    Dim rengi As renk

    Dim bildir As renk_bildirgesi

    WithEvents iletişim As iletişim_kanalı

    WithEvents gösterim_yenlileyicisi As Windows.Forms.Timer

    Dim bit As Bitmap
    Dim form As New Form2()
    Dim gr As Graphics

    Sub New(ByVal genislik As Integer, ByVal yükseklik As Integer)

        noktasayısı = genislik & yükseklik
        yüksklik = yükseklik
        genişlik = genislik

        Dim yeninoktalar(genislik, yükseklik) As Nokta

        rengi = New renk()
        bildir = New renk_bildirgesi()
        bit = New Bitmap(genişlik, yükseklik)
        iletişim = New iletişim_kanalı

        noktalar = yeninoktalar

        gr = form.CreateGraphics()
        gr.FillRectangle(Brushes.Snow, New RectangleF(0, 0, genişlik, yüksklik))
        gr.DrawImage(bit, New Point(0, 0))

        noktaları_aktif_et()

    End Sub

    Sub fiziksel_haritayı_göster()

        gösterim_yenlileyicisi = New Windows.Forms.Timer
        gösterim_yenlileyicisi.Interval = 200
        gösterim_yenlileyicisi.Enabled = True

        form.Show()

    End Sub

    Sub noktaları_aktif_et()

        Dim x, y, i As Integer

        For i = 1 To noktasayısı
            If x > genişlik Then
                If Not y > yüksklik Then
                    x = 0
                    y += 1
                End If
            End If
            If Not y > yüksklik Then

                bildir.x = x
                bildir.y = y
                bildir.verilen_renk = New renk()

                noktalar(x, y) = New Nokta(bildir, iletişim)
            End If
            x += 1
        Next

    End Sub

    Public Sub noktaya_değer_Ata(ByVal x As Single, ByVal y As Single, ByRef renk As renk)

        If renk.değer_0_ = 1 Then
            gr.FillRectangle(Brushes.Blue, x, y, 5, 5)
        End If
        If renk.değer_0_ = 0 Then
            gr.FillRectangle(Brushes.Blue, x, y, 5, 5)
        End If

        Try
            noktalar(x, y).rengim = renk
        Catch ex As Exception
            ' MsgBox("Bir hata oluştu", MsgBoxStyle.Critical, "Fizik Motoru")
        End Try


    End Sub

    Public Function noktanın_değerin_oku(ByVal x As Single, ByVal y As Single) As renk

        Try
            rengi = noktalar(x, y).rengim
        Catch ex As Exception

        End Try


        Return rengi

    End Function

    Private Sub gösterim_yenlileyicisi_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gösterim_yenlileyicisi.Tick
        gr.DrawImage(bit, New Point(0, 0))
        form.TextBox1.Text += 1
    End Sub

End Class

Public Class iletişim_kanalı

    Public Event bildiri(ByVal bildiri As renk_bildirgesi)

    Public Event dönüt(ByVal renkk As renk)

    Sub New()

    End Sub

    Sub bildiri_yayınla(ByVal bildiri As renk_bildirgesi)
        RaiseEvent bildiri(bildiri)
    End Sub

    Sub dönüt_yolla(ByVal renkk As renk)
        RaiseEvent dönüt(renkk)
    End Sub

End Class

Public Class renk

    Dim değer_0 As Integer
    Dim değer_1 As Integer
    Dim değer_2 As Integer
    Dim değer_3 As Integer

    Public Event değer_0_değişimi(ByVal değer As Integer)
    Public Event değer_1_değişimi(ByVal değer As Integer)
    Public Event değer_2_değişimi(ByVal değer As Integer)
    Public Event değer_3_değişimi(ByVal değer As Integer)

    Dim asılrenk As Color

    Public Property değer_0_() As Integer
        Get
            Return değer_0
        End Get
        Set(ByVal değer As Integer)
            değer_0 = değer
            RaiseEvent değer_0_değişimi(değer)
        End Set
    End Property

    Public Property değer_1_() As Integer
        Get
            Return değer_1
        End Get
        Set(ByVal değer As Integer)
            değer_1 = değer
            RaiseEvent değer_1_değişimi(değer)
        End Set
    End Property

    Public Property değer_2_() As Integer
        Get
            Return değer_2
        End Get
        Set(ByVal değer As Integer)
            değer_2 = değer
            RaiseEvent değer_2_değişimi(değer)
        End Set
    End Property

    Public Property değer_3_() As Integer
        Get
            Return değer_3
        End Get
        Set(ByVal değer As Integer)
            değer_3 = değer
            RaiseEvent değer_3_değişimi(değer)
        End Set
    End Property

    Sub New()

    End Sub

    Sub New(ByVal değer As Integer)
        değer_0 = değer
    End Sub

    Sub New(ByVal değer As Integer, ByVal değer1 As Integer, _
            ByVal değer2 As Integer, _
            ByVal değer3 As Integer)
        değer_0 = değer
        değer_1 = değer1
        değer_2 = değer2
        değer_3 = değer3

    End Sub

    Public Function renge_çevir() As Color

        asılrenk = Color.FromArgb(değer_0, değer_1, değer_2, değer_3)

        Return asılrenk

    End Function


End Class

Public Class vektör

    Sub New()
        ' Fizik motorunun yeni öğesi vektörler profesyonel işlemler vektörlerle yapılacak
    End Sub

End Class

Public Class obje ' Fizik motorunu Fizk motoru olmasını saylayacak asıl özellik objelerin yönetimidir

    Dim köşeler() As köşe

    Sub New()

    End Sub

    Public Class köşe ' Köşeler objeleri yönetecek olan vektölerin objeyi yönlendirmesini sağlayacak

        Dim vektr As New vektör
        Dim konum As Point

        Sub New()

        End Sub

    End Class

End Class



Public Class Grafik

    Public Class Kesik_Çizgi

        Dim xx1, xx2, yy1, yy2 As Single
        Dim çizgikalınlığı As Single
        Dim rengi As Color
        Dim başlamanoktası, bitişnoktası As PointF

        Dim kalem As Pen

        Dim aygıt As Grafik.Toplayıcı

        WithEvents değişme As TextBox

        Sub New(ByVal motor As Grafik.Toplayıcı, ByVal kesik_sayısı As Integer)

            aygıt = motor

            renk = Color.Black

            çizgikalınlığı = 1

            motor.nesne_Sayısı += 1

            motor.çizilen_nesneler.Text += 1

            kalem.DashStyle = Drawing2D.DashStyle.Dot

            değişme = motor.tikleyici
        End Sub

        Sub çizgiyi_kes()

        End Sub

        Public Sub görünürlük(ByVal değer As Boolean)
            If değer = False Then

                aygıt.nesne_Sayısı -= 1
                aygıt.çizilen_nesneler.Text -= 1
                değişme = New TextBox

                'MsgBox("bir nesne daha silindi")
            End If
            If değer = True Then
                değişme = aygıt.tikleyici
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

        Private Sub değişme_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles değişme.TextChanged

            kalem.Color = renk
            kalem.Width = çizgi_kalınlığı
            kalem.DashStyle = Drawing2D.DashStyle.Dot

            aygıt.gr.DrawLine(New Pen(renk, çizgikalınlığı), xx1, yy1, xx2, yy2)

            aygıt.çizilen_nesneler.Text += 1

        End Sub

    End Class

    Public Class Toplayıcı

        Public WithEvents tikleyici As New TextBox
        WithEvents textbox2 As New TextBox
        WithEvents textbox3 As New TextBox

        Public WithEvents kmra_tick As New TextBox

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

        Dim kameraknm As PointF

        Public gr As Graphics

        Public Shared bit1 As New Bitmap(700, 700, Imaging.PixelFormat.Format32bppPArgb)
        Dim arkaplan As New Bitmap(1000, 1000)

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
            tikleyici.Text = "0"
            kmra_tick.Text = "0"

            timer1.Enabled = True
            timer2.Enabled = True

            gr = Graphics.FromImage(bit1)

        End Sub

        Public Sub çözünürlük(ByVal x As Single, ByVal y As Single)

            gr.ScaleTransform(x, y)

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

            textbox2.Text = kare_sayı & " - " & nesne_Sayısı & " - " & çizilen_nesneler.Text
            kare_sayı = 0

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

        Public Property kameraref As PointF
            Get
                Return kameraknm
            End Get
            Set(ByVal value As PointF)
                kameraknm = value
                kmra_tick.Text += 1
            End Set
        End Property

    End Class

    Public Class Nesne

        Dim en, boy As Single

        Dim orjin As PointF
        Public yerleştirme As PointF

        Dim aygıt As Grafik.Toplayıcı

        Dim gr As Graphics

        Dim girdap As Bitmap
        Dim girdap1 As Bitmap
        Dim grdap As Graphics

        Dim matrix As New Drawing2D.Matrix
        Dim eski_açı As Single

        WithEvents değişme As TextBox

        Dim onaylanma As Short

        Dim grnrlk As Boolean = True

        Dim i As Integer = 2

        Dim reslist As New ArrayList


        Sub New(ByVal motor As Grafik.Toplayıcı, ByVal resim As Bitmap)

            motor.nesne_Sayısı += 1

            motor.çizilen_nesneler.Text += 1

            aygıt = motor

            reslist.Add(resim)

            en = (((resim.Height ^ 2) + (resim.Width ^ 2)) ^ 0.5) * 2
            boy = (((resim.Height ^ 2) + (resim.Width ^ 2)) ^ 0.5)

            görüntüyü_değiştir(0)

            değişme = motor.tikleyici

        End Sub

        Private Sub ortala()

            orjin.X = en / 2
            orjin.Y = boy / 2

            yerleştirme.X = (en / 2) - girdap.Width / 2
            yerleştirme.Y = (boy / 2) - girdap.Height / 2

        End Sub

        Sub döndür(ByVal derece As Single, ByVal merkeznoktası As Point)

            Dim eksen As Point = merkeznoktası

            eksen.X += orjin.X
            eksen.Y += orjin.Y

            grdap.Clear(Color.Transparent)

            matrix.RotateAt(eski_açı, eksen)
            grdap.Transform = matrix

            matrix.RotateAt(derece, eksen)
            grdap.Transform = matrix

            eski_açı = -(derece)

        End Sub

        Sub transparantlık()

        End Sub

        Function görüntü_ekle(ByVal görüntü As Bitmap)

            Dim ii As Integer
            ii = reslist.Add(görüntü)

            Return ii
        End Function

        Sub görüntüyü_değiştir(ByVal görüntü_no As Integer)
            Dim bit As Bitmap
            Try
                bit = reslist(görüntü_no)
                girdap = New Bitmap(bit)
                girdap1 = New Bitmap(CInt(en), CInt(boy))
                grdap = Graphics.FromImage(girdap1)
                'grdap.Clear(Color.Tomato)
                ortala()
            Catch ex As Exception
                MsgBox("Görüntü Değiştirme Hatası", MsgBoxStyle.Critical, "ADN Grafik Hata")
            End Try
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

                If Not grnrlk = False Then
                    aygıt.nesne_Sayısı -= 1
                    aygıt.çizilen_nesneler.Text -= 1
                    değişme = New TextBox

                    'MsgBox("bir nesne daha silindi")
                End If

            End If
            If değer = True Then
                değişme = aygıt.tikleyici
                grnrlk = False
            End If
        End Sub

        Dim a As Single

        Private Sub değişme_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles değişme.TextChanged

            grdap.DrawImage(girdap, yerleştirme)

            aygıt.gr.DrawImage(girdap1, aygıt.kameraref.X + (X - orjin.X), aygıt.kameraref.Y + (Y - orjin.Y), en, boy)

            aygıt.çizilen_nesneler.Text += 1

        End Sub

    End Class

    Public Class Transparan_Nesne

        Dim en, boy As Single

        Dim orjin As PointF
        Dim yerleştirme As PointF

        Dim aygıt As Grafik.Toplayıcı

        Dim i As Integer

        Dim res11 As New Bitmap("C:\Users\Ev Bilgisayarı\Desktop\füze.bmp")

        Dim girdap As Bitmap
        Dim girdap1 As Bitmap
        Dim grdap As Graphics

        Dim matrix As New Drawing2D.Matrix

        WithEvents değişme As TextBox

        Dim onaylanma As Short

        Sub başla(ByVal motor As Grafik.Toplayıcı, ByVal resim As Bitmap)

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

        Dim aygıt As Grafik.Toplayıcı

        WithEvents değişme As TextBox

        Sub New(ByVal motor As Grafik.Toplayıcı)

            aygıt = motor

            renk = Color.Black

            çizgikalınlığı = 1

            motor.nesne_Sayısı += 1

            motor.çizilen_nesneler.Text += 1

            değişme = motor.tikleyici
        End Sub

        Public Sub görünürlük(ByVal değer As Boolean)
            If değer = False Then

                aygıt.nesne_Sayısı -= 1
                aygıt.çizilen_nesneler.Text -= 1
                değişme = New TextBox

                'MsgBox("bir nesne daha silindi")
            End If
            If değer = True Then
                değişme = aygıt.tikleyici
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

        Private Sub değişme_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles değişme.TextChanged

            aygıt.gr.DrawLine(New Pen(renk, çizgikalınlığı), xx1 + aygıt.kameraref.X, yy1 + aygıt.kameraref.Y, xx2 + aygıt.kameraref.X, yy2 + aygıt.kameraref.Y)

            aygıt.çizilen_nesneler.Text += 1

        End Sub

    End Class

    Public Class Etiket

        Dim xx1, yy1 As Single
        Dim çizgikalınlığı As Single
        Dim rengi As Brush

        Dim yazı1 As String
        Dim yazıtipi As Font

        Dim aygıt As Grafik.Toplayıcı

        WithEvents değişme As TextBox

        Sub New(ByVal motor As Grafik.Toplayıcı, Optional ByVal yazı As String = "")
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

        Public Sub görünürlük(ByVal değer As Boolean)
            If değer = False Then

                aygıt.nesne_Sayısı -= 1
                aygıt.çizilen_nesneler.Text -= 1
                değişme = New TextBox

                'MsgBox("bir nesne daha silindi")
            End If
            If değer = True Then
                değişme = aygıt.tikleyici
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

        Private Sub değişme_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles değişme.TextChanged

            aygıt.gr.DrawString(yazı1, yazıtipi, renk, xx1 + aygıt.kameraref.X, yy1 + aygıt.kameraref.Y)

            aygıt.çizilen_nesneler.Text += 1

        End Sub

    End Class

    Public Class Birden_Çok_Çizgi

        Public yol_haritası() As PointF
        Public maske_harita() As PointF

        Dim çizgikalınlığı As Single

        Dim rengi As Color
        Dim aygıt As Grafik.Toplayıcı

        WithEvents değişme As TextBox
        WithEvents kmra_değisim As TextBox

        Sub New(ByVal motor As Grafik.Toplayıcı, ByVal çizgi_noktaları() As PointF)

            maske_harita = çizgi_noktaları
            yol_haritası = çizgi_noktaları

            aygıt = motor

            renk = Color.Black

            çizgikalınlığı = 1
            motor.nesne_Sayısı += 1
            motor.çizilen_nesneler.Text += 1

            yol_haritasını_kaydır()

            değişme = motor.tikleyici
            kmra_değisim = motor.kmra_tick

        End Sub

        Public Sub görünürlük(ByVal değer As Boolean)
            If değer = False Then

                aygıt.nesne_Sayısı -= 1
                aygıt.çizilen_nesneler.Text -= 1
                değişme = New TextBox

                'MsgBox("bir nesne daha silindi")
            End If
            If değer = True Then
                değişme = aygıt.tikleyici
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

        Sub yol_haritasını_kaydır()

            Dim i As Integer

            For i = 0 To yol_haritası.Length - 1 '' !! HATA AYIKLAMASI YAPILMADII !! '' 

                yol_haritası(i).X = maske_harita(i).X + aygıt.kameraref.X
                yol_haritası(i).Y = maske_harita(i).X + aygıt.kameraref.Y

            Next

        End Sub

        Private Sub değişme_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles değişme.TextChanged

            aygıt.gr.DrawLines(New Pen(renk, çizgikalınlığı), yol_haritası)

            aygıt.çizilen_nesneler.Text += 1

        End Sub

        Private Sub kmra_değisim_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles kmra_değisim.TextChanged
            yol_haritasını_kaydır()
        End Sub

    End Class

    Public Class çember

        Public çember_karesi As RectangleF

        Dim xx1, xx2, yy1, yy2 As Single

        Dim çizgikalınlığı As Single
        Dim rengi As Color
        Dim başlamanoktası, bitişnoktası As PointF

        Dim orjin As PointF

        Dim yarçap As Single

        Dim aygıt As Grafik.Toplayıcı

        WithEvents değişme As TextBox

        Sub New(ByVal motor As Grafik.Toplayıcı, ByVal yarıçap As Single)

            aygıt = motor

            renk = Color.Black

            çizgikalınlığı = 1

            yarçap = yarıçap

            motor.nesne_Sayısı += 1

            motor.çizilen_nesneler.Text += 1

            değişme = motor.tikleyici
        End Sub

        Public Sub görünürlük(ByVal değer As Boolean)
            If değer = False Then

                aygıt.nesne_Sayısı -= 1
                aygıt.çizilen_nesneler.Text -= 1
                değişme = New TextBox

                'MsgBox("bir nesne daha silindi")
            End If
            If değer = True Then
                değişme = aygıt.tikleyici
            End If
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

        Public Property merkez() As PointF
            Get
                Return orjin
            End Get
            Set(ByVal value As PointF)

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

        Private Sub değişme_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles değişme.TextChanged

            aygıt.gr.DrawEllipse(New Pen(rengi, çizgikalınlığı), New RectangleF(New PointF(çember_karesi.X + aygıt.kameraref.X, çember_karesi.Y + aygıt.kameraref.Y), çember_karesi.Size))
            aygıt.çizilen_nesneler.Text += 1

        End Sub

    End Class

    Public Class kare

        Dim xx1, yy1 As Single
        Dim çizgikalınlığı As Single

        Dim rengi As Brush
        Dim kalem As Pen

        Public kare As Rectangle

        Dim boyut As SizeF

        Dim aygıt As Grafik.Toplayıcı

        WithEvents değişme As TextBox

        Dim grnürlk As Boolean = True

        Sub New(ByVal motor As Grafik.Toplayıcı, Optional ByVal genişlik As Single = 10, Optional ByVal yükseklik As Single = 10)

            aygıt = motor

            çizgikalınlığı = 12

            kalem = New Pen(Color.Black)
            renk = Brushes.Black

            boyut = New SizeF(genişlik, yükseklik)

            kare.Height = yükseklik
            kare.Width = genişlik

            çizgikalınlığı = 1

            motor.nesne_Sayısı += 1

            motor.çizilen_nesneler.Text += 1

            değişme = motor.tikleyici
        End Sub

        Public Sub görünürlük(ByVal değer As Boolean)
            If değer = False Then

                aygıt.nesne_Sayısı -= 1
                aygıt.çizilen_nesneler.Text -= 1
                değişme = New TextBox

                grnürlk = False

                'MsgBox("bir nesne daha silindi")
            End If
            If değer = True Then
                If grnürlk = False Then
                    değişme = aygıt.tikleyici
                    aygıt.nesne_Sayısı += 1
                    aygıt.çizilen_nesneler.Text += 1

                    grnürlk = True

                End If
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
                kalem.Width = value
            End Set
        End Property

        Public Property renk() As Brush
            Get
                Return rengi
            End Get
            Set(ByVal value As Brush)
                rengi = value
                kalem.Brush = value
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

        Sub çizgi_tipini_değiştir(ByVal stil As Drawing2D.DashStyle)
            kalem.DashStyle = stil
        End Sub

        Private Sub değişme_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles değişme.TextChanged

            aygıt.gr.DrawRectangle(kalem, xx1 + aygıt.kameraref.X, yy1 + aygıt.kameraref.Y, boyut.Width, boyut.Height)
            aygıt.çizilen_nesneler.Text += 1

        End Sub

    End Class

End Class





