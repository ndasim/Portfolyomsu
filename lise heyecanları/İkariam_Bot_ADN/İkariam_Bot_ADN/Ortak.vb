Imports İkariam_Bot_ADN

Module Ortak

    Public WithEvents Kontrol As New System.Windows.Forms.WebBrowser

    Dim Adım As Integer = 0

    Dim gr As Graphics
    Dim a As Single
    Dim göstergeç As Ekran
    Dim yüklniyr As Bekle

    Public bitt(100) As Bitmap

    Sub Başla()

        göstergeç = New Ekran
        yüklniyr = New Bekle

        Dim i As Integer

        For i = 0 To 61
            bitt(i) = Kare_oluştur()
            Application.DoEvents()
        Next

        Kontrol.Parent = göstergeç
        Kontrol.Dock = DockStyle.Fill

        Kontrol.Navigate("http://tr.ikariam.com")

        göstergeç.Show()

    End Sub

    Function Kare_oluştur() As Bitmap ' bekleme esnasındaki animasyon için kare oluşturma
        Dim bit As Bitmap
        Dim ii, i As Integer
        Dim x, xx, y As Single

        bit = New Bitmap(336, 32)
        gr = Graphics.FromImage(bit)
        'gr.FillRectangle(Brushes.White, New Rectangle(0, 0, 336, 32))

        a += 0.1

        xx -= a

        For ii = 1 To 4800
            x += 0.01
            xx += 0.01
            y = 16 + Math.Cos(xx) * 8

            gr.FillEllipse(Brushes.Red, New Rectangle(x * 7, y, 2, 2))
        Next

        Return bit
    End Function

    Function Giriş()


    End Function

    Private Sub Kontrol_DocumentCompleted(ByVal sender As Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles Kontrol.DocumentCompleted
        If Adım = 0 Then

            Adım = 1



        ElseIf Adım = 1 Then



        End If
    End Sub

End Module
