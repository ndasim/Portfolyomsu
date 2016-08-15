Imports System.Web.UI.Page

Module arama_işlemleri

    Public Structure site

        Dim bağlantı As String
        Dim başlık_etiketi As String
        Dim sayfa_içeriği As String

        Dim b As System.Net.HttpListenerContext

        Sub New(ByVal url As String)
            bağlantı = url
        End Sub

    End Structure

    Dim aranan As String
    Dim b As System.Web.UI.Page
    Dim yol, yol1 As String
    Dim adres_sayısı As Integer
    Dim adressler() As site
    Public bulunmuşlar As New ArrayList()
    Public blunmuşlari As Integer

    Public sayfa_no As String = "1"

    Sub başlat(ByVal aratılan As String, ByVal aratan As System.Web.UI.Page)

        bulunmuşlar.Clear()
        b = aratan
        aranan = aratılan
        aranacak_adresleri_cıkar()

    End Sub

    Sub aranacak_adresleri_cıkar()

        yol1 = b.Server.MapPath("arama_sayfalari.ayr")
        Dim islenmemis_veri As String
        Dim pkt1 As String
        Dim pkt2 As String
        Dim pkt3 As String
        Dim a As Integer
        Dim sitee As site

        b.Response.Write(yol)
        b.Response.Write("<br>")

        islenmemis_veri = FileIO.FileSystem.ReadAllText(yol1)

        b.Response.Write(islenmemis_veri)
        b.Response.Write("<br>")

        pkt1 = islenmemis_veri.Substring(islenmemis_veri.IndexOf("sayfa sayisi:") + 13, 2)
        adres_sayısı = pkt1

        b.Response.Write(pkt1)
        b.Response.Write("<br>")

        ReDim adressler(pkt1)

        For a = 1 To CInt(pkt1)   ' hata verebilir index ayarlamadan

            pkt2 = islenmemis_veri.Substring(islenmemis_veri.IndexOf("Syfuznlk" & a) + 11, 4)
            pkt3 = islenmemis_veri.Substring(islenmemis_veri.IndexOf("Syf" & a) + 6, CInt(pkt2))
            sitee = New site(pkt3)

            pkt2 = islenmemis_veri.Substring(islenmemis_veri.IndexOf("bslketktuznluk" & a) + 17, 2)
            pkt3 = islenmemis_veri.Substring(islenmemis_veri.IndexOf("bslk_etiketi" & a) + 15, CInt(pkt2))
            sitee.başlık_etiketi = pkt3

            b.Response.Write(pkt2)
            b.Response.Write("<br>")
            b.Response.Write(pkt3)
            b.Response.Write("<br>")

            adressler(a - 1) = sitee
        Next

        adresleri_ayrı_ayrı_tara()

    End Sub

    Function farklı_Adresden_veri_çek(ByVal değer As String) As String

        Dim strurl, strhtml As String

        strurl = "http://finans.mynet.com/"

        Dim objxmlhttp

        objxmlhttp = b.Server.CreateObject("MSXML2.ServerXMLHTTP")

        objxmlhttp.open("GET", strurl, False)

        objxmlhttp.send()

        strhtml = objxmlhttp.responsetext

        objxmlhttp = Nothing

        b.Response.Write(strhtml)

    End Function

    Sub adresleri_ayrı_ayrı_tara()
        Dim i As Integer
        Dim tmm As Boolean

        For i = 0 To adres_sayısı - 1
            yol = b.Server.MapPath(adressler(i).bağlantı)
            arındır(FileIO.FileSystem.ReadAllText(yol), i)
            sayfayı_tara(i, aranan)
        Next

        b.Response.Redirect("arama.aspx?arama=" & aranan & "&sayfa_no=1")

    End Sub

    Sub arındır(ByVal hamveri As String, ByVal adresno As Integer)
        ' Burada amaç body içindeki etiketlerden arındırmaktır
        Dim arındırılmıs As String
        Dim i As Integer
        Dim tst As String
        Dim tmm As Boolean = False
        Dim tmm1 As Boolean = False
        Dim tmm2 As Boolean = False

        ' script arındırma

        i = hamveri.IndexOf("<script")
        If Not i = -1 Then

        End If

        ' bütün etiketleri arındırma

        Do Until tmm
            i = hamveri.IndexOf("<")
            If Not i = -1 Then
                tst = etiketin_uzunluğunu_bul(i, hamveri) ' etiket uzunluğunu bulduk
                tst = hamveri.Substring(i, tst)           ' ilgili etiketi seçtik
                hamveri = Replace(hamveri, tst, "")       ' seçili etiketi sildik
            Else
                tmm = True                                ' ve son olarak taranacak etiket kalmayınca döngüyü bitiriyoruz
            End If
        Loop

        tmm = False

        ' boşluk arındırma
        Do Until tmm
            If Not i + 1 = hamveri.Length Then
                i = i + 1
            Else
                tmm = True
            End If

            tst = hamveri.Substring(i, 1)
            If tst = vbTab Then
                If tmm2 = True Then
                    tmm1 = True
                    tmm2 = False
                End If
            Else
                If tmm1 = True Then
                    arındırılmıs = arındırılmıs & Space(1)
                    tmm1 = False
                End If
                arındırılmıs = arındırılmıs & tst

                Dim ii As Integer

                ii = Asc(tst)

                If Not ii = 13 Then
                    If Not ii = 10 Then
                        tmm2 = True
                    End If
                End If
            End If
        Loop

        i = hamveri.IndexOf("as")
        tst = hamveri.Substring(i, 4)

        adressler(adresno).sayfa_içeriği = arındırılmıs

    End Sub

    Sub sayfayı_tara(ByVal adresno As Integer, ByVal aranacak_kelime As String)

        Dim icerik As String
        Dim bulunan As Integer
        Dim tmm As Boolean = False
        Dim sitee As New site

        Do Until tmm
            bulunan = adressler(adresno).sayfa_içeriği.IndexOf(aranacak_kelime, bulunan)

            If bulunan >= 0 Then
                icerik = adressler(adresno).sayfa_içeriği.Substring(bulunan, aranacak_kelime.Length)
                If bulunan > 20 Then
                    icerik = adressler(adresno).sayfa_içeriği.Substring(bulunan - 15, aranacak_kelime.Length + 15)
                    If bulunan < adressler(adresno).sayfa_içeriği.Length - 205 Then
                        icerik = adressler(adresno).sayfa_içeriği.Substring(bulunan - 15, aranacak_kelime.Length + 200)
                    End If
                End If

                bulunan += aranacak_kelime.Length

                blunmuşlari += 1

                sitee.başlık_etiketi = adressler(adresno).başlık_etiketi
                sitee.sayfa_içeriği = icerik
                sitee.bağlantı = adressler(adresno).bağlantı

                bulunmuşlar.Add(sitee)

            End If

            If bulunan = -1 Then
                tmm = True
            End If
        Loop

    End Sub

    Function etiketin_uzunluğunu_bul(ByVal etiketinkonumu As Integer, ByVal hamvr As String) As Integer

        ' burada amaç verilen yazı koordinatından sonra gelen '>' işareti ile verilen kkordinat arasındaki farkı bulmaktır

        Dim tamam As Boolean = False
        Dim i As Integer = etiketinkonumu
        Dim sonuç As Integer
        Dim bulunan As String

        Do Until tamam ' döngü içinde aranan karaker bulunana kadar hamveri içinde 1'er 1'er tarama yapılıyor 

            i = i + 1
            bulunan = hamvr.Substring(i, 1)

            If bulunan = ">" Then
                sonuç = i - etiketinkonumu
                tamam = True
            Else

            End If
        Loop

        Return sonuç + 1
    End Function

#Region "dosya_işlemleri"

    Sub yaz(ByVal yazılan() As site, ByVal yazılan_etiket As String)

        Dim dosya As String

        Dim ana As String
        Dim dizin As String
        Dim pkt1, pkt2 As String
        Dim i As Integer

        dosya = b.Server.MapPath("arama_verileri.ayr")
        Microsoft.VisualBasic.FileSystem.FileOpen(1, dosya, OpenMode.Input)

        Microsoft.VisualBasic.FileSystem.Input(1, ana)
        ' etiket önceden kaydedilmişmi kaydedilmemişmişmi diye kontrol et

        pkt1 = ana.IndexOf(yazılan_etiket)

        If Not pkt1 = "-1" Then
            pkt1 = ana.IndexOf("dizin:")
            dizin = ana.Substring(pkt1 + 6, 5)
            dizin = dizin + 1

            ana.Remove(pkt1 + 6, 5)
            ana.Insert(pkt1 + 6, dizin & Space(5 - dizin.Length))
            ana = ana & vbCrLf & vbCrLf & yazılan_etiket & "5211atl" & ":" & dizin & Space(5 - dizin.Length)

            dizin = dizin - 1

            For i = 1 To yazılan.Length - 1 ' çıkan site bilgilerini birer birer ekler
                ana = ana & vbCrLf & "site" & (dizin - 1) & Space(2 - dizin.Length.ToString.Length) & ":" & yazılan.Length & Space(2 - yazılan.Length.ToString.Length) ' burası eklenen arama bilgileri sayısını ekler formatı "site & dökumanno & boşluk(eğer dökumanno'nun genişliği 2 den küçükse aradaki fark kadar) & bulunan site bilgileri "

                ana = ana & vbCrLf & "baslik" & (dizin - 1) & Space(2 - dizin.Length.ToString.Length) & i & ":" & yazılan(i).başlık_etiketi & Space(50 - yazılan(i).başlık_etiketi.Length) ' burası çıkan sonuçlar arasından i'ninci site'nin başlık bilgilerini ekler formatı "baslik & dökumanno & boşluk(eğer dökumanno'nun genişliği 2 den küçükse aradaki fark kadar)&site no : & başlık bilgileri & boşluk(eğer baslik bilgilerinin genişliği 20 den küçükse aradaki fark kadar)"
                ana = ana & vbCrLf & "icerik" & (dizin - 1) & Space(2 - dizin.Length.ToString.Length) & i & ":" & yazılan(i).sayfa_içeriği & Space(50 - yazılan(i).sayfa_içeriği.Length) ' burası çıkan sonuçlar arasından i'ninci site'nin icerik bilgilerini ekler formatı "icerik & dökumanno & boşluk(eğer dökumanno'nun genişliği 2 den küçükse aradaki fark kadar)&site no : & içerik bilgileri & boşluk(eğer icerik bilgilerinin genişliği 50 den küçükse aradaki fark kadar)"
                ana = ana & vbCrLf & "url" & (dizin - 1) & Space(2 - dizin.Length.ToString.Length) & i & ":" & yazılan(i).başlık_etiketi & Space(50 - yazılan(i).başlık_etiketi.Length)
            Next

            Microsoft.VisualBasic.FileSystem.FileClose(1)
            Microsoft.VisualBasic.FileSystem.FileOpen(1, dosya, OpenMode.Output)
            Microsoft.VisualBasic.FileSystem.Write(1, ana)

        Else

        End If

    End Sub

    Function oku(ByVal aranan As String) As site()
        Dim dosya As String
        Dim bulunan() As site
        Dim başlık, içerik, url As String
        Dim ana, pkt1, pkt2, pkt3 As String
        Dim i As Integer

        dosya = b.Server.MapPath("arama_verileri.ayr")

        ana = FileIO.FileSystem.ReadAllText(dosya)

        aranan = aranan & "5211atl"

        pkt1 = ana.IndexOf(aranan)

        If Not pkt1 = "-1" Then
            pkt1 = ana.Substring(pkt1 + aranan.Length + 1, 2)

            pkt2 = ana.IndexOf("site" & pkt1)
            pkt2 = ana.Substring(pkt2 + 7, 2)

            ReDim bulunan(pkt2)

            For i = 1 To pkt2
                pkt3 = ana.IndexOf("baslik" & pkt1 & i)
                başlık = ana.Substring(pkt3 + 9 + i.ToString.Length, 50)

                pkt3 = ana.IndexOf("icerik" & pkt1 & i)
                içerik = ana.Substring(pkt3 + 9 + i.ToString.Length, 100)

                pkt3 = ana.IndexOf("url" & pkt1 & i)
                url = ana.Substring(pkt3 + 6 + i.ToString.Length, 50)

                bulunan(i).başlık_etiketi = başlık
                bulunan(i).sayfa_içeriği = içerik
                bulunan(i).bağlantı = url
            Next
        Else
            ReDim bulunan(0)
            bulunan(0) = New site
        End If

        Return bulunan
    End Function

#End Region

End Module
