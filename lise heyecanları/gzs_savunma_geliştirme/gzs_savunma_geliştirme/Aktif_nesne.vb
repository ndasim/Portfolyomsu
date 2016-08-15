Imports System.Math

Public Class Aktif_nesne

    Dim gr As Graphics

    Public nokta_haritası As New ArrayList
    Dim işaretlenenler As New ArrayList

    Dim nk As nokta

    Dim ilk_açı, son_açı As Single

    Private Sub Aktif_nesne_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim i As Integer


    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim açı As Integer

        Dim x, y As Single

        'For y = 1 To 50
        'For x = 1 To 50
        'nk = New nokta(New Point(300 + x, 100 + (y)), Me)
        'nokta_haritası.Add(nk)
        'Next
        'Next

        For açı = 0 To 360 Step +5

            x = 300 - 100 * Cos(açı * PI / 180)
            y = 100 - 100 * Sin(açı * PI / 180)

            nk = New nokta(New Point(x, y), Me)
            nokta_haritası.Add(nk)

        Next

        Çıktı("Noktalar Oluşturuldu")
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        oyuk_oluştur(TextBox1.Text)

    End Sub

    Sub oyuk_oluştur(ByVal nereye As Integer)

        Dim dnk_nk As nokta

        Dim mrkz As Point
        Dim açı As Single
        Dim uzaklk As Single

        Dim bşlma_dizno As Integer


        Dim i As Integer

        dnk_nk = nokta_haritası(nereye)

        ' Merkez Alınıyor

        mrkz.X = dnk_nk.x
        mrkz.Y = dnk_nk.y

        Çıktı("Noktalar Alındı")

        ' Merkeze göre belli uzunluktaki noktalar taratılıyor

        Dim a As Integer
        For i = 0 To nokta_haritası.Count - 1
            dnk_nk = nokta_haritası(i)

            uzaklk = ((dnk_nk.x - mrkz.X) ^ 2 + (dnk_nk.y - mrkz.Y) ^ 2) ^ 0.5

            If uzaklk < 30 Then
                a += 1
                işaretlenenler.Add(dnk_nk)


            End If
        Next

        bşlma_dizno = nokta_haritası.IndexOf(işaretlenenler(0))

        For i = 0 To işaretlenenler.Count - 1

            dnk_nk = işaretlenenler(i)
            dnk_nk.sil()

            nokta_haritası.Remove(dnk_nk)
            '
            ' YIKIM
            '
        Next

        Çıktı("Noktalar İşaretlendi")                                            ' Açıları Hesaplamada
        Çıktı("Noktalar Silindi")                                                '
        '
        Çıktı("İlk Noktanın Açısı Alınıyor")                                     ' Büyük Eksiklikler Var

        dnk_nk = işaretlenenler(0)
        ilk_açı = Atan2(mrkz.Y - dnk_nk.y, mrkz.X - dnk_nk.x) * 180 / Math.PI

        Çıktı("Son Noktanın Açısı Alınıyor")

        dnk_nk = işaretlenenler(işaretlenenler.Count - 1)
        son_açı = Atan2(mrkz.Y - dnk_nk.y, mrkz.X - dnk_nk.x) * 180 / Math.PI

        Obeb(son_açı - ilk_açı)

        If ilk_açı < 0 Then
            ilk_açı += 360
        End If
        If son_açı < 0 Then
            son_açı += 360
        End If

        Çıktı("Yeni Noktalar Oluşturuluyor")

        Dim x, y As Single
        Dim dönüt As Boolean
        Dim yenilr As New ArrayList

        Dim oto_tmmlma As Integer = 20
        Dim dnk_nk2 As nokta

        açı = ilk_açı

        Do Until dönüt
            açı += 15

            x = mrkz.X - 30 * Cos(açı * PI / 180)
            y = mrkz.Y - 30 * Sin(açı * PI / 180)

            ' Arada açılan büyük boşlukları tamam lamak için aşağıdaki yol uygulanıyor

            nk = New nokta(New PointF(x, y), Me)
            yenilr.Add(nk)

            dnk_nk = işaretlenenler(işaretlenenler.Count - 1)
            uzaklk = ((dnk_nk.x - x) ^ 2 + (dnk_nk.y - y) ^ 2) ^ 0.5

            If uzaklk < oto_tmmlma Then
                dnk_nk2 = işaretlenenler(işaretlenenler.Count - 1)


                x = (dnk_nk.x - dnk_nk2.x) / 2
                y = (dnk_nk.y - dnk_nk2.y) / 2

                dönüt = True
            End If



        Loop

        Araya_Ekle(yenilr, bşlma_dizno)
    End Sub

    Function Obeb(ByVal sayı As String) As Single

        '//////////////////////////////////////////////////////////////////////////////////////////////////
        '
        ' Sayımız ondalıklı ise bu sayıyı önce ondalıklı kısmı tamlanacak kadar 10'un katlarıyla çarpıyoruz
        ' Sonra elde etdiğimiz yeni sayının Ortak Bölenlerin En Büyüğü(obeb)'ni alıyoruz
        ' Elde etdiğimiz sayıyı başta çarptığımız sayıya bölüyoruz 
        '
        '\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

        Dim dönüt As Boolean

        Dim çarpılacaküs As Integer

        Dim dnk_sayı As String
        Dim çrpln As Integer
        Dim bölüneblrlistsi As New ArrayList
        Dim dngüdn_çkan As Integer

        Dim sonuç As Single = 1
        Dim tstkpy As Single = sayı

        çarpılacaküs = sayı.Substring(sayı.IndexOf(",")).Length - 1

        sayı = sayı * (10 ^ çarpılacaküs)


        Do Until dönüt

            çrpln = 17
            dnk_sayı = sayı / çrpln

            If Not dnk_sayı.IndexOf(",") = -1 Then
                dngüdn_çkan = çrpln
            End If

            ' ------------------------------------------

            çrpln = 13
            dnk_sayı = sayı / çrpln

            If Not dnk_sayı.IndexOf(",") = -1 Then
                dngüdn_çkan = çrpln
            End If

            ' ------------------------------------------

            çrpln = 11
            dnk_sayı = sayı / çrpln

            If Not dnk_sayı.IndexOf(",") = -1 Then
                dngüdn_çkan = çrpln
            End If

            ' ------------------------------------------

            çrpln = 7
            dnk_sayı = sayı / çrpln

            If Not dnk_sayı.IndexOf(",") = -1 Then
                dngüdn_çkan = çrpln
            End If

            ' ------------------------------------------

            çrpln = 5
            dnk_sayı = sayı / çrpln

            If Not dnk_sayı.IndexOf(",") = -1 Then
                dngüdn_çkan = çrpln
            End If

            ' ------------------------------------------

            çrpln = 3
            dnk_sayı = sayı / çrpln

            If Not dnk_sayı.IndexOf(",") = -1 Then
                dngüdn_çkan = çrpln
            End If

            ' ------------------------------------------

            çrpln = 2
            dnk_sayı = sayı / çrpln

            If Not dnk_sayı.IndexOf(",") = -1 Then
                dngüdn_çkan = çrpln
            End If

            ' ------------------------------------------

            If dngüdn_çkan = -1 Then
                ' Elimizdeki sayı bir asal sayıdır ve tek dir o yüzden +1 ekleyip 2 ye bölüyoruz

                dngüdn_çkan = 2

            End If

            bölüneblrlistsi.Add(dngüdn_çkan)

            sayı /= dngüdn_çkan
            dngüdn_çkan = -1

            If sayı = 1 Or sayı = 0 Then
                dönüt = True
            End If
        Loop

        ' obeb sonucumuzun fazla büyük olaması gerekmektedir o yüzden sınırı 20 olarak ayarlıyoruz

        ' obeb'in son işlemleri: çıkanları çarpıyoruz

        Dim i As Integer

        For i = 0 To bölüneblrlistsi.Count - 1
            sonuç *= bölüneblrlistsi(i)
            If sonuç > 20 Then
                i = bölüneblrlistsi.Count
            End If
        Next

        sonuç /= çarpılacaküs
        MsgBox(sonuç & " " & tstkpy / sonuç)

        ' ARADA BUG VAR

        Return sonuç
    End Function

    Sub test_sonuclari(ByVal mrkz As PointF)
        Dim dnk_nk As nokta
        Dim uzaklk As Single
        Dim işaretlenenler As New ArrayList

        For i = 0 To nokta_haritası.Count - 1
            dnk_nk = nokta_haritası(i)

            uzaklk = ((dnk_nk.x - mrkz.X) ^ 2 + (dnk_nk.y - mrkz.Y) ^ 2) ^ 0.5

            If uzaklk < 30 Then
                işaretlenenler.Add(dnk_nk)
            End If
        Next


        'Çıktı("Noktalar İşaretlendi")                                            ' Açıları Hesaplamada
        'Çıktı("Noktalar Silindi")                                                '
        '
        'Çıktı("İlk Noktanın Açısı Alınıyor")                                     ' Büyük Eksiklikler Var

        dnk_nk = işaretlenenler(0)
        ilk_açı = Atan2(mrkz.Y - dnk_nk.y, mrkz.X - dnk_nk.x) * 180 \ Math.PI

        'Çıktı("Son Noktanın Açısı Alınıyor")

        dnk_nk = işaretlenenler(işaretlenenler.Count - 1)
        son_açı = Atan2(mrkz.Y - dnk_nk.y, mrkz.X - dnk_nk.x) * 180 / Math.PI

        If ilk_açı < 0 Then
            ilk_açı += 360
        End If
        If son_açı < 0 Then
            son_açı += 360
        End If

        TextBox2.Text = "ilk açı : " & ilk_açı & " son açı: " & son_açı
    End Sub


    Sub Araya_Ekle(ByVal eklneck_olan As ArrayList, ByVal nereye As Integer)
        Dim i, ii As Integer

        Dim kopya As New ArrayList

        For i = 0 To nokta_haritası.Count - 1
            kopya.Add(nokta_haritası(i))
        Next

        nokta_haritası.Clear()

        Dim nksys As Integer = kopya.Count

        For i = 0 To nksys - 1

            If i = nereye Then
                For ii = 0 To eklneck_olan.Count - 1
                    nokta_haritası.Add(eklneck_olan(ii))
                Next
            End If

            nokta_haritası.Add(kopya(i))
        Next

    End Sub

    Private Sub Aktif_nesne_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseMove

        Dim dnk As nokta
        Dim i As Integer

        For i = 0 To nokta_haritası.Count - 1
            dnk = nokta_haritası(i)
            dnk.Test(e.Location)
        Next

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        TextBox2.Text = "ilk açı : " & ilk_açı & " son açı: " & son_açı
    End Sub

    Private Sub Aktif_nesne_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseDown
        Dim dnk As nokta
        Dim i As Integer

        For i = 0 To nokta_haritası.Count - 1
            dnk = nokta_haritası(i)
            dnk.çarpma(e.Location)
        Next

    End Sub
End Class

Public Class nokta

    Dim gr As Graphics

    Public x As Single
    Public y As Single

    Public ebeveyn As String

    Sub New(ByVal knm As PointF, ByVal aln As Control)

        x = knm.X
        y = knm.Y

        gr = aln.CreateGraphics

        gr.FillEllipse(Brushes.Green, New Rectangle(x, y, 5, 5))

    End Sub

    Sub Test(ByVal knm As Point)

        Dim uzaklk As Single

        If knm.X > x Then
            If knm.Y > y Then
                If knm.X < x + 5 Then
                    If knm.Y < y + 5 Then
                        'Aktif_nesne.göstergeç.Left = x + 5
                        'Aktif_nesne.göstergeç.Top = y
                        Aktif_nesne.göstergeç.Text = Aktif_nesne.nokta_haritası.IndexOf(Me)
                        gr.FillEllipse(Brushes.Green, New Rectangle(x, y, 5, 5))
                        Aktif_nesne.test_sonuclari(New PointF(x, y))
                    End If
                End If
            End If
        End If

        gr.FillEllipse(Brushes.Green, New Rectangle(x, y, 5, 5))

        uzaklk = ((x - knm.X) ^ 2 + (y - knm.Y) ^ 2) ^ 0.5

        If uzaklk < 30 Then
            gr.FillEllipse(Brushes.Red, New Rectangle(x, y, 5, 5))
        Else
            gr.FillEllipse(Brushes.Green, New Rectangle(x, y, 5, 5))
        End If

    End Sub

    Sub çarpma(ByVal knm As Point)
        If knm.X > x Then
            If knm.Y > y Then
                If knm.X < x + 5 Then
                    If knm.Y < y + 5 Then
                        Aktif_nesne.oyuk_oluştur(Aktif_nesne.nokta_haritası.IndexOf(Me))
                    End If
                End If
            End If
        End If

    End Sub

    Sub sil()
        gr.FillEllipse(Brushes.White, New Rectangle(x, y, 5, 5))
    End Sub
End Class

Public Class top

    Sub New()

    End Sub

    Sub tara()

    End Sub

End Class

Public Class Köşe

    Dim gr As Graphics

    Public koord As Point

    Public sıra_no As Integer

    Sub New(ByVal koordinat As Point, ByVal no As Integer)

        koord = koordinat
        sıra_no = no

        gr = Graphics.FromHwnd(Aktif_nesne.Handle.ToInt32)
        gr.DrawRectangle(Pens.DarkRed, New Rectangle(New Point(koord.X - 2, koord.Y - 2), New Size(4, 4)))

    End Sub

    Public Sub pasifleştir()
        Me.Finalize()
    End Sub

End Class
