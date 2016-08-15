Imports Microsoft.Win32

Public Class Form1

    Public Adım As Integer = 1

    Dim linkler_HTML As HtmlElementCollection
    Dim linkler As New ArrayList

    Dim bkleme As Single
    Dim syç As Integer

    Dim reklamda As Boolean

    Dim kyt_dfteri As RegistryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", True)

    Private Sub WebBrowser1_DocumentCompleted(ByVal sender As System.Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles Kontrol.DocumentCompleted
        Dim no As Integer
        If Adım = 1 Then
            Adım = 2
            Kontrol.Document.GetElementById("COOKIEusername").InnerText = "kriptol1n"
            Kontrol.Document.GetElementById("COOKIEpass").InnerText = "asmasm"

            no = Kontrol.Document.Body.OuterHtml.IndexOf("Logged")
            If Not no = -1 Then
                Adım = 3
                Kontrol.Navigate("http://www.bux.to/surf.php")
            End If

            drm1.Text = " Yükleniyor ...    Adım 2'ye Geçiş Yapılıyor"

            Me.Hide()

        ElseIf Adım = 2 Then
            Adım = 3
            Kontrol.Navigate("http://www.bux.to/surf.php")

            drm1.Text = " Yükleniyor ...    Adım 3'e Geçiş Yapılıyor"

        ElseIf Adım = 3 Then
            drm1.Text = " Beklemede ...   Bir sonraki reklam için bekleniliyor "

            ilgili_linkler()
            tıkla()

        ElseIf Adım = 4 Then
            Adım = 1
        ElseIf Adım = 5 Then
            Me.Close()
        End If

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

            no = dnek.IndexOf("class=")

            If Not no = -1 Then
                no = dnek.IndexOf("al4")

                If Not no = -1 Then
                    no = dnek.IndexOf("href=")
                    If Not no = -1 Then
                        uzunlk = link_uzunluğunu_bul(no + 6, dnek)

                        linkler.Add(dnek.Substring(no + 6, uzunlk))

                    End If
                End If

            End If

        Next
    End Sub

    Sub tıkla()
        If Not linkler.Count < 1 Then
            Kontrol1.Navigate("http://www.bux.to/" & linkler(0))

            drm2.Text = " Yükleniyor ...  Reklam sitesi yükleniyor"

        Else
            Adım = 4
            Kontrol.Navigate("http://www.bux.to/logout.php")

            drm1.Text = " Beklemede ...    Sistemin yeni reklam vermesi bekleniliyor"

            Timer2.Enabled = True

        End If

    End Sub

    Function link_uzunluğunu_bul(ByVal link_blndğ_konm As Integer, ByVal hamvr As String) As Integer

        ' burada amaç verilen yazı koordinatından sonra gelen ' " ' işareti ile verilen kkordinat arasındaki farkı bulmaktır

        Dim tamam As Boolean = False
        Dim i As Integer = link_blndğ_konm
        Dim sonuç As Integer
        Dim bulunan As String

        Do Until tamam ' döngü içinde aranan karaker bulunana kadar hamveri içinde 1'er 1'er tarama yapılıyor 

            i = i + 1
            bulunan = hamvr.Substring(i, 1)

            If AscW(bulunan.Chars(0)) = 34 Then '  " işaretinin ascW kodu 34
                sonuç = i - link_blndğ_konm
                tamam = True
            Else

            End If
        Loop

        Return sonuç
    End Function

    Private Sub Kontrol1_DocumentCompleted(ByVal sender As Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles Kontrol1.DocumentCompleted
        If reklamda = False Then
            bkleme = Rnd(Rnd(Rnd(10) * 100) * Rnd(100)) * 300
            syç = 0
            Timer1.Enabled = True
            Kontrol1.Stop()
            reklamda = True
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        syç += 1

        If syç = CInt(bkleme) + 30 Then

            reklamda = False

            Timer1.Enabled = False
            Kontrol.Refresh()

            drm2.Text = " Beklemede ... Yeni reklam sitesi bekleniyor"
            drm1.Text = " Yükleniyor ...    Bir sonraki reklam için yenileme yapılıyor"

        End If



        drm2.Text = " Süre Bekleniliyor ...  Durum: " & syç & "    Bekleme süresi " & (CInt(bkleme) + 30)

    End Sub

    Private Sub Timer2_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer2.Tick

        Adım = 1
        Kontrol.Navigate("http://www.bux.to/login.php")

        Timer2.Enabled = False


    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        Kontrol.ScriptErrorsSuppressed = True
        Kontrol1.ScriptErrorsSuppressed = True

        If kyt_dfteri.GetValue("MyApp") Is Nothing Then

            kyt_dfteri.SetValue("MyApp", Application.ExecutablePath.ToString())

        End If


    End Sub

    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        If Not Adım = 5 Then
            e.Cancel = True
            Me.Hide()
        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Timer1.Enabled = False
        Kontrol.Refresh()

        drm2.Text = " Beklemede ... Yeni reklam sitesi bekleniyor"
        drm1.Text = " Yükleniyor ...    Bir sonraki reklam için yenileme yapılıyor"

    End Sub

    Private Sub NotifyIcon1_BalloonTipClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NotifyIcon1.BalloonTipClicked
        Me.Show()
    End Sub

    Private Sub NotifyIcon1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NotifyIcon1.Click
        Me.Show()
    End Sub

    Private Sub EeTmmToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EeTmmToolStripMenuItem.Click
        Me.Show()
    End Sub

    Private Sub Form1_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        If Me.WindowState = Windows.Forms.FormWindowState.Minimized Then
            Me.Hide()
        End If
    End Sub

    Private Sub KapatToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KapatToolStripMenuItem.Click
        Adım = 5
        Kontrol.Navigate("http://www.bux.to/logout.php")
    End Sub

End Class
