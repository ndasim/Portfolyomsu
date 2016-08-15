Public Class Form1

    Dim dsybyutu As Integer
    Dim dsyyolu As String

    Dim bytee() As Byte
    Dim i As Integer = 0

    Dim boşta_kalan As Short

    Dim pxlsyısı As Integer
    Dim genişlik, yükseklik As Integer

    Dim gr As Graphics

    Dim bitt As Bitmap

    Dim sonrenk As Color

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        dsyyolu = TextBox1.Text

        bytee = My.Computer.FileSystem.ReadAllBytes(dsyyolu)

        dsybyutu = bytee.Length
        pxlsyısı = (bytee.Length / 4)

        pxlsyısı += 2 ' +1 boşta kalan sayısı, +1 4'e bölümden arta kalan byte ların sayılması için

        Label1.Text = "Dosya Boyutu:" & bytee.Length

        Label3.Text = "Piksel Sayısı:" & pxlsyısı

        Label2.Text = "Resim Boyutu:" & pxlsyısı / 2 & " : " & (bytee.Length / 4) / 2

        işle()
    End Sub

    Private Sub Aç_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Aç.FileOk
        TextBox1.Text = Aç.FileName

    End Sub

    Function pixelle() As Color
        Dim renk As Color

        Return renk
    End Function

    Function işle()

        Dim i As Long
        Dim kalan As Short
        Dim bytlar As New ArrayList
        Dim artanlar(4) As Byte
        Dim pxlsys As Long
        Dim pxller As New ArrayList

        Dim x, y As Integer

        kalan = bytee.Length Mod 3

        bytlar.Add(CByte(kalan))

        For i = 0 To bytee.Length - 1
            bytlar.Add(bytee(i))
        Next

        i = 0

        For i = 0 To 2
            If i < kalan Then
                artanlar(i) = bytee(bytee.Length - (3 - i))
            Else
                artanlar(i) = CByte(0)
            End If
        Next

        sonrenk = Color.FromArgb(artanlar(1), artanlar(2), artanlar(3), artanlar(4))

        bytlar.Add(sonrenk)

        pxlsys = (bytee.Count - kalan)

        yükseklik = pxlsys / 600

        If yükseklik = 0 Then
            yükseklik = 1
        End If

        bitt = New Bitmap(600, yükseklik, Imaging.PixelFormat.Format48bppRgb)

        Dim ktsyı As Integer

        For i = 1 To pxlsys
            pxller.Add(Color.FromArgb(10, bytlar(ktsyı), 10))
            ktsyı += 1
        Next

        ktsyı = 0

        For y = 0 To yükseklik - 1
            For x = 0 To 599
                If ktsyı < pxller.Count Then
                    bitt.SetPixel(x, y, pxller(ktsyı))
                Else
                    bitt.SetPixel(x, y, Color.White)
                End If

                ktsyı += 1
            Next
        Next

        gr = PictureBox1.CreateGraphics

        gr.DrawImage(bitt, 0, 0)

        PictureBox1.Image = bitt

        Clipboard.SetImage(bitt)

        Label4.Text = "Sonuç:" & bytlar.Count & "     kalan:" & kalan
    End Function

    Function pxlayrıştır()

    End Function

    Sub deneme()

        Dim ii As Integer = 1
        Dim pxdizisi(pxlsyısı + 1) As Color

        Do Until ii = pxlsyısı

            pxdizisi(ii) = pixelle()

            ii += 1

            Label3.Text = "Piksel Sayısı:" & pxlsyısı & "/" & ii

            Application.DoEvents()
        Loop

        pxdizisi(0) = Color.FromArgb(boşta_kalan)

        Label4.Text = "Boşta kalan:" & boşta_kalan


    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim süngerbitler As New ArrayList()

        Dim i As Integer

        For i = 1 To 11
            süngerbitler.Add(CByte(10))
        Next

        Dim a(süngerbitler.Count - 1) As Byte

        süngerbitler.CopyTo(a)

        My.Computer.FileSystem.WriteAllBytes("C:\Users\Bilgisayar\Desktop\a.skıstırma", a, False)

    End Sub

    Sub yaz()

    End Sub

    Private Sub TextBox1_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TextBox1.MouseClick
        Aç.ShowDialog()
    End Sub

    Private Sub TrackBar1_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar1.Scroll

        Dim oran As Single

        oran = 1 + (TrackBar1.Value * 0.5)
        gr.ScaleTransform(oran, oran)
        gr.Clear(Color.White)
        gr.DrawImage(bitt, 0, 0)

    End Sub
End Class
