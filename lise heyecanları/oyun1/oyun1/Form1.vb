
Imports WindowsApplication1.Grafik

Public Class Form1

    ' Grafik;

    Public gr As Toplayıcı

    Dim anaçizg As Çizgi
    Dim silah As Nesne

    Dim slh As New Bitmap("C:\Users\Bilgisayar\Desktop\ADN Yazılım\silah.jpg")

    ' Karekterler;

    Public mermi As New ArrayList ' Belirli bir miktar mermi sayısı bulunmadığında arraylist ideal
    Public krktr() As düşman

    ' Değişkenler;

    Public fx, fy As Integer ' Fare konum değişkenleri
    Public x, y As Integer   ' Nesne konum değişkenleri

    Dim hız As Double = 1    ' Araç hızı

    Public açı As Double     ' Silah döndürme açısı
    Dim eskaçı As Double

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        kur()

        gr.yenilenme_hızını_göster()

    End Sub

    Sub kur()

        aktive_et() ' fizik motorunun çalıştırılması

        ' Standart veriler oturtulması; 
        fy = 100
        fx = 100

        x = 200
        y = 250

        ' Grafik kurulumu;
        gr = New Toplayıcı(PictureBox1)
        anaçizg = New Çizgi(gr)
        silah = New Nesne(gr, slh)

        anaçizg.renk = Color.White

        ' Aracın koordinat düzlemine oturtulması;

        anaçizg.çizgi_kalınlığı = 5

        anaçizg.Y1 = 300
        anaçizg.Y2 = 300
        anaçizg.X1 = 110
        anaçizg.X2 = 110

        silah.X = 200
        silah.Y = 250

        ' Karekterlerin oluşturulması;

        ReDim krktr(1) ' 1 = karekter sayısı

        Dim i As Integer

        For i = 0 To krktr.Length - 1
            krktr(i) = New düşman((i * 150) + 100, Me) ' (i * 150) + 100 : karekterlerin konumlandırılması
        Next

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        Dim i As Integer
        Dim snlmermi As mermi ' hareketlendirilen mermilerin sanallaştırıldığı değişken

        ' Mermilerin hareketlendirilmesi;

        For i = 1 To mermi.Count
            Try
                snlmermi = mermi(i - 1)    ' Sanallaştırma
                snlmermi.işlem_bloğu() ' işlem bloğuyla nesne uyarma
            Catch ex As Exception

            End Try
        Next

        ' Karekterlerin hareketleştirilmesi;

        For i = 0 To krktr.Length - 1

            If krktr(i).aktiflik = True Then
                krktr(i).işlem_bloğu() ' nesne uyarma
            End If

        Next

        ' Aracın Fareye göre konumlandırılması;

        If Not x = fx Then  ' nesne konumuyla fare konumunun x ekseninde karşılaştırılması

            ' Durumlar;

            If x < fx Then
                x += hız ' Belirli hızda nesnenin konumu değiştirliyor

                ' Taşıyıcının konumu ;
                anaçizg.X1 = x - 50
                anaçizg.X2 = x + 50

                ' Silahın konumu ;
                silah.X = x

            End If
            If x > fx Then
                x -= hız

                anaçizg.X1 = x - 50
                anaçizg.X2 = x + 50

                silah.X = x
            End If
        End If


        açı = Math.Atan2(fy - y - 43, fx - x) * 180 / Math.PI + 90

        silah.döndür(açı, New Point(0, 43))

        ' Test değerlerinin görüntülenmesi ;

        TextBox2.Text += 1
        TextBox1.Text = açı

    End Sub

    Private Sub PictureBox1_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseMove

        fx = e.X
        fy = e.Y

        TextBox1.Text = fx & " ; " & fy & " --- "


    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        mermi.Add(New mermi(Me))
    End Sub

End Class


Public Class mermi
    Dim kurşun As Çizgi
    Dim hız, xhız, yhız As Single

    Public knm As PointF
    Dim frm As Form1

    Dim açı As Single

    Sub New(ByVal ateşleyen As Form1)
        kurşun = New Çizgi(ateşleyen.gr)
        kurşun.renk = Color.White

        frm = ateşleyen

        açı = Math.Atan2(ateşleyen.y - ateşleyen.fy + 43, ateşleyen.x - ateşleyen.fx)

        xhız = Math.Cos(açı)
        yhız = Math.Sin(açı)

        kurşun.X1 = ateşleyen.x
        kurşun.Y1 += ateşleyen.y + 43
        kurşun.Y2 += ateşleyen.y + 43
        kurşun.X2 += ateşleyen.x

        knm.X = ateşleyen.x
        knm.Y = ateşleyen.y

        hız = 2

    End Sub

    Sub işlem_bloğu()

        kurşun.X1 = kurşun.X2 - 5 * xhız
        kurşun.Y1 = kurşun.Y2 - 5 * yhız
        kurşun.Y2 -= yhız * hız
        kurşun.X2 -= xhız * hız

        knm.X = kurşun.X1
        knm.Y = kurşun.Y1

        If knm.X < 0 Then
            bitir()
        End If
        If knm.Y < 0 Then
            bitir()
        End If

    End Sub

    Sub bitir()
        frm.mermi.Remove(Me)
        kurşun.görünürlük(False)
    End Sub

End Class

Public Class düşman

    Dim krktr As çember
    Dim knm As Point
    Dim xx, yy As Single
    Dim frm As Form1

    Public aktiflik As Boolean = True

    Sub New(ByVal x As Single, ByVal ortam As Form1)
        krktr = New çember(ortam.gr, 5)
        krktr.renk = Color.White

        yy = 50
        xx = x

        knm.Y = yy
        knm.X = xx

        frm = ortam

    End Sub

    Sub dnmn()
        Dim açı, r As Integer
        Dim x, y As Integer
        Dim çıkan As Boolean
        Dim dönüt As Boolean = True

        Do While dönüt
            açı += 10

            x = knm.X + r * Math.Cos(açı)
            y = knm.Y + r * Math.Sin(açı)
            If fiziksharit.noktanın_değerin_oku(x, y).değer_1_ > 0 Then
                çıkan = True
            End If

            If r = 5 Then
                dönüt = False
            End If

            If açı = 360 Then
                r += 1
                açı = 0
            End If

        Loop
    End Sub

    Function ortamtesti() As Boolean
        Dim r As Integer
        Dim snlmermi As mermi ' örneklencek değişken
        Dim çıkan As Boolean
        Dim i As Integer
        Dim a As Integer ' mermi arrayında olası bir azalma durumunda kullanılacak 

        Dim ux, uy As Single

        For i = 1 To frm.mermi.Count
            snlmermi = frm.mermi(i - 1 - a)

            ux = snlmermi.knm.X - xx
            uy = snlmermi.knm.Y - yy

            r = ((ux ^ 2) + (uy ^ 2)) ^ 0.5 ' Belirlenen merminin krktrin merkezine uzklığı

            If r < 10 Then

                çıkan = True
                snlmermi.bitir()  ' ilgili mermi siliniyor
                a = 1             ' mermi arrayında eksilme olduğu bildiriliyor

            End If

        Next

        Return çıkan
    End Function

    Sub işlem_bloğu()

        If ortamtesti() = True Then
            ' Krkter siliniyor;
            krktr.görünürlük(False)
            aktiflik = False
        End If

        yy += 0.5 ' 0.5 hızdır

        krktr.merkez = New PointF(xx, yy)

    End Sub

End Class
