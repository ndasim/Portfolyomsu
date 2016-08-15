Public Class inclare


    Public Adım As Integer = 0

    Dim linkler_HTML As HtmlElementCollection
    Dim linkler As New ArrayList

    Dim bkleme As Single
    Dim syç As Integer


    Private Sub Kontrol_DocumentCompleted(ByVal sender As System.Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles Kontrol.DocumentCompleted
        Dim no As Integer
        If Adım = 0 Then
            Adım = 1

            no = Kontrol.Document.Body.OuterHtml.IndexOf("Logout")
            If no = -1 Then
                Adım = 1
                Kontrol.Navigate("http://incrasebux.com/login.php")
            Else
                Adım = 3
                Kontrol.Navigate("http://incrasebux.com/ads.php")
            End If


        ElseIf Adım = 1 Then
            Adım = 2

            Kontrol.Document.GetElementById("login_username").InnerText = "kriptol1n"
            Kontrol.Document.GetElementById("password").InnerText = "asmasm"            ' <= HATA BURADA

            drm1.Text = " Yükleniyor ...    Adım 2'ye Geçiş Yapılıyor"

        ElseIf Adım = 2 Then
            Adım = 3
            Kontrol.Navigate("http://incrasebux.com/ads.php")

            drm1.Text = " Yükleniyor ...    Adım 3'e Geçiş Yapılıyor"

        ElseIf Adım = 3 Then

            drm1.Text = " Beklemede ...   Bir sonraki reklam için bekleniliyor "

            ilgili_linkler()
            tıkla()

        End If
    End Sub

    Private Sub WebBrowser1_DocumentCompleted(ByVal sender As System.Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs)
       
    End Sub

    Sub ilgili_linkler()
        Dim i As Integer
        Dim kopya As New ArrayList

        linkler_HTML = Kontrol.Document.GetElementsByTagName("a")

        ' Çözümlenmemiş Html parçalarıı çözümlemek üzere bir arraylistê alıyoruz

        For i = 0 To linkler_HTML.Count - 1
            linkler.Add(linkler_HTML(i).OuterHtml)
        Next

        ' Çözümlüyoruz...

        ' Önce bir kopyasını alıyoruz
        For i = 0 To linkler.Count - 1
            kopya.Add(linkler(i))
        Next

        ' Temizliyoruz Çünkü: Çözümlenmiş Link adreslerimiz bu arraylistîn içinde  olacak
        linkler.Clear()

        ' Bir filtreye göre html parçalarını ayırıp içindeki link'i 
        ' linkler arraylist'esine koyuyoruz

        For i = 0 To kopya.Count - 1
            Dim dnek, dnek1 As String
            Dim no As Integer
            Dim uzunlk As Integer

            dnek = kopya(i)

            no = dnek.IndexOf("openad")

            If Not no = -1 Then

                uzunlk = link_uzunluğunu_bul(no + 8, dnek)

                linkler.Add(dnek.Substring(no + 8, uzunlk))

            End If

        Next
    End Sub

    Sub tıkla()
        If Not linkler.Count < 1 Then
            Kontrol1.Navigate(linkler(0))
            Kontrol.Document.InvokeScript("q()")

            drm2.Text = " Yükleniyor ...  Reklam sitesi yükleniyor"

        Else
            drm1.Text = " Beklemede ...    Sistemin yeni reklam vermesi bekleniliyor"

            Timer2.Enabled = True

        End If

    End Sub

    Function link_uzunluğunu_bul(ByVal link_blndğ_konm As Integer, ByVal hamvr As String) As Integer

        ' burada amaç verilen yazı koordinatından sonra gelen (') işareti ile verilen kkordinat arasındaki farkı bulmaktır

        Dim tamam As Boolean = False
        Dim i As Integer = link_blndğ_konm
        Dim sonuç As Integer
        Dim bulunan As String

        Do Until tamam ' döngü içinde aranan karaker bulunana kadar hamveri içinde 1'er 1'er tarama yapılıyor 

            i = i + 1
            bulunan = hamvr.Substring(i, 1)

            If AscW(bulunan.Chars(0)) = 39 Then ' (') işaretinin ascW kodu 39
                sonuç = i - link_blndğ_konm
                tamam = True
            Else

            End If
        Loop

        Return sonuç
    End Function

    Private Sub Kontrol1_DocumentCompleted(ByVal sender As Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs)
        bkleme = Rnd(Rnd(Rnd(10) * 100) * Rnd(100)) * 100
        syç = 0
        Timer1.Enabled = True
    End Sub

    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        syç += 1

        If syç = CInt(bkleme) + 30 Then

            Timer1.Enabled = False
            Kontrol.Refresh()

            drm2.Text = " Beklemede ... Yeni reklam sitesi bekleniyor"
            drm1.Text = " Yükleniyor ...    Bir sonraki reklam için yenileme yapılıyor"

        End If



        drm2.Text = " Süre Bekleniliyor ...  Durum: " & syç & "    Bekleme süresi " & (CInt(bkleme) + 30)

    End Sub

    Private Sub Timer2_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        ilgili_linkler()
        If Not linkler.Count < 1 Then
            Kontrol1.Navigate("http://www.bux.to/" & linkler(0))

            drm2.Text = " Yükleniyor ...  Reklam sitesi yükleniyor"

        Else
            drm1.Text = " Beklemede ...    Sistemin yeni reklam vermesi bekleniliyor"

            Timer2.Enabled = True

        End If
    End Sub

    Protected Overrides Sub Finalize()


        ' Çıkış işlemi
        Kontrol.Navigate("http://www.bux.to/" & "logout.php")


        MyBase.Finalize()
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Kontrol.ScriptErrorsSuppressed = True
        Kontrol1.ScriptErrorsSuppressed = True
    End Sub
End Class