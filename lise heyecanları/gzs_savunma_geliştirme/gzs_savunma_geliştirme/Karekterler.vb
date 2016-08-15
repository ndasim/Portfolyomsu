Imports System.Math

Public Class silahlı_karekter

    WithEvents add As TextBox
    WithEvents scmetik As TextBox
    WithEvents oyunalanı As PictureBox
    WithEvents kilitlenici As New Timer
    WithEvents hareketlendirici As New Timer

    Public takımm As String

    Dim düşman As silahlı_karekter
    Dim thmn_atş_sys As Integer

    Dim silah_kilit As Boolean = False
    Dim silah_hızı As Integer = 300
    Dim menzil As Integer = 100

    Dim sağlık_puanı As Single = 100
    Dim vuruş_gücü As Integer = 1

    Dim boyut As Size
    Dim harita_konum As PointF
    Dim esk_konum As PointF

    Dim krktrno As Integer

    Dim gr As Grafik.Nesne

    Dim krktr As Bitmap
    Dim sçlkrktr As Bitmap

    Dim fareaktivesi As Boolean
    Dim hareket As Boolean

    Dim krktr_adı As String

    Dim hedef_nok As Point

    Dim gidişaçısı As Single
    Dim birimxhız, birimyhız As Single
    Dim anahız As Single
    Dim hedefe_uzaklık As Single

    Sub New(ByVal takım As String, ByVal koord As PointF)

        oyunalanı = Form1.PictureBox1

        If takım = "A" Then
            krktrno = krktrlrA.Add(Me)
        ElseIf takım = "B" Then
            krktrno = krktrlrB.Add(Me)
        End If


        krktr_adı = takım & krktrno
        takımm = takım

        harita_konum = koord

        tanımlamalar()

    End Sub

    Sub tanımlamalar()

        krktr = New Bitmap(resdizin & "\tip1.png")
        sçlkrktr = New Bitmap(resdizin & "\tip1s.png")

        anahız = 1

        boyut.Height = 10
        boyut.Width = 10

        gr = New Grafik.Nesne(Ortak.gr, krktr)
        gr.X = harita_konum.X
        gr.Y = harita_konum.X
        gr.görüntü_ekle(sçlkrktr)

        kilitlenici.Interval = silah_hızı

    End Sub

    Sub vurulma(ByVal vrn_gcü As Single)


        sağlık_puanı -= vrn_gcü


        If sağlık_puanı < 0 Then

            yıkım()

        End If
    End Sub

    Sub yıkım()

        krktrlrA.Remove(Me)
        gr.görünürlük(False)
        kilitlenici.Enabled = False

        '
        '
        '
        ' YIKIM OLAYLARI ....
        '
        '
        '

    End Sub

    Function koord_kontrl(ByVal koord As PointF, ByVal gç As Single, ByVal ateşleyen As String)

        Dim dönüt As Boolean = False
        Dim r As Integer

        If Not ateşleyen = krktr_adı Then
            r = ((koord.X - harita_konum.X) ^ 2 + (koord.Y - harita_konum.Y) ^ 2) ^ 0.5

            If r < 20 Then
                dönüt = True
                vurulma(gç)
            End If
        End If

        Return dönüt
    End Function

    Sub yürüt()

        Dim r As Integer
        Dim i As Integer
        Dim örnk_krktr As silahlı_karekter
        Dim koord As PointF

        ' Karekteri ilerletme işlemleri

        If hareket = True Then

            esk_konum = harita_konum   ' Eski konum belirtiliyor

            hedefe_uzaklık = Abs((gr.X - hedef_nok.X) ^ 2 + (gr.Y - hedef_nok.Y) ^ 2) ^ 0.5  ' Hedef noktaya olan uzaklık belirtiliyor

            ' Doğru konuma sağlıklı ulaşabilmek için yavaşlatma koşulları uygulanıyor

            If hedefe_uzaklık < anahız + 1 Then
                If Not anahız = 1 Then
                    anahız -= 1
                End If
            End If
            If hedefe_uzaklık < anahız - 1 Then
                If Not anahız = 1 Then
                    anahız -= 1
                End If
            End If
            If hedefe_uzaklık < anahız - 2 Then
                If Not anahız = 1 Then
                    anahız -= 1
                End If
            End If

            If hedefe_uzaklık < 2 Then
                hareket = False
            End If

            harita_konum.X -= birimxhız * anahız
            harita_konum.Y -= birimyhız * anahız

            gr.X = harita_konum.X
            gr.Y = harita_konum.Y

        End If

        ' Etrafta düşman tarama işlemi

        If Not silah_kilit = True Then
            If takımm = "A" Then
                If Not krktrlrB.Count = 0 Then

                    For i = 0 To krktrlrB.Count - 1

                        örnk_krktr = krktrlrB(i)

                        koord = örnk_krktr.harita_konum ' örnekleme
                        r = ((koord.X - harita_konum.X) ^ 2 + (koord.Y - harita_konum.Y) ^ 2) ^ 0.5 ' Yarı çap alma

                        If r < menzil Then ' menzil => karekterin görüş mesafesi
                            düşman = örnk_krktr
                            silah_kilit = True
                            kilitlenici.Enabled = True
                        End If
                    Next

                End If
            End If

            If takımm = "B" Then
                If Not krktrlrA.Count = 0 Then

                    For i = 0 To krktrlrA.Count - 1

                        örnk_krktr = krktrlrA(i)

                        koord = örnk_krktr.harita_konum ' örnekleme
                        r = ((koord.X - harita_konum.X) ^ 2 + (koord.Y - harita_konum.Y) ^ 2) ^ 0.5 ' Yarı çap alma

                        If r < menzil Then ' menzil => karekterin görüş mesafesi
                            düşman = örnk_krktr
                            silah_kilit = True
                            kilitlenici.Enabled = True
                        End If
                    Next

                End If
            End If
        End If


    End Sub

    Private Sub oyunalanı_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles oyunalanı.MouseClick

        If e.Button = MouseButtons.Right Then
            If fareaktivesi = True Then

                gidişaçısı = Atan2(harita_konum.Y - (e.Y - Ortak.gr.kameraref.Y), harita_konum.X - (e.X - Ortak.gr.kameraref.X))

                birimxhız = Cos(gidişaçısı)
                birimyhız = Sin(gidişaçısı)

                hedef_nok.X = e.X - Ortak.gr.kameraref.X
                hedef_nok.Y = e.Y - Ortak.gr.kameraref.Y
                hareket = True

            End If
        End If

        If e.Button = MouseButtons.Left Then
            fareaktivesi = False
            gr.görüntüyü_değiştir(0)

            If e.X > harita_konum.X - boyut.Width / 2 Then
                If e.Y > harita_konum.Y - boyut.Height / 2 Then
                    If e.X < harita_konum.X + boyut.Width / 2 Then
                        If e.Y < harita_konum.Y + boyut.Height / 2 Then

                            gr.görüntüyü_değiştir(1)

                            fareaktivesi = True

                            '
                            '
                            ' Farenin üzerine tıklama olayı
                            '
                            '

                        End If
                    End If
                End If
            End If
        End If

    End Sub

    Function arada_olma_durumu(ByVal sayı1 As Integer, ByVal sayı2 As Integer, ByVal srgulanan As Integer) As Boolean

        ' srgulanan sayının sayı1 ile sayı iki arasında olup olmadığını sorgular

        Dim dönen As Boolean = False

        If sayı1 > sayı2 Then
            If srgulanan < sayı1 Then
                If srgulanan > sayı2 Then
                    dönen = True
                End If
            End If
        End If

        If sayı2 > sayı1 Then
            If srgulanan < sayı2 Then
                If srgulanan > sayı1 Then
                    dönen = True
                End If
            End If
        End If

        Return dönen
    End Function

End Class

Public Class Basit_düşman

    Dim gr As Grafik.Toplayıcı
    Dim nsne As Grafik.Birden_Çok_Çizgi

    Dim fiziksel_noktalar As ArrayList
    Dim noktalar_kümesi() As PointF


    Sub New()

    End Sub

    Sub noktaları_yenile()

    End Sub

End Class