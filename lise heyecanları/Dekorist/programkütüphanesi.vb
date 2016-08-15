Imports System.Math
Imports Dekorist
Public Class programkütüphanesi
    Public Class serverkütüphanesi
        Dim i As Integer
        Public WithEvents veritabanı As System.Windows.Forms.TextBox
        Sub başla()
            Me.veritabanı = New System.Windows.Forms.TextBox
        End Sub
    End Class

    Public Class kodkütüphanesi
        Public Class birnoktayahareket
            Private Sub hazırlık()
                Dim xfark, yfark, sonuçy, tamy, sonuçx, tamx, x1, y1, x2, y2 As Integer
                yfark = y1 - y2
                xfark = x1 - x2
                If x1 < x2 And y1 > y2 Or x1 > x2 And y1 < y2 Then
                    sonuçy = yfark / xfark
                    tamy = Math.Abs(sonuçy)
                    ' -- buraya x'in kodu yapıştırılıcak -- ' 
                End If
                If x1 > x2 And y1 > y2 Or x1 < x2 And y1 < y2 Then
                    sonuçx = xfark / yfark
                    tamx = Math.Abs(sonuçx)
                    ' -- buraya y'nin kodu yapıştırılıcak -- '
                End If
            End Sub
        End Class


    End Class

    Public Class nesnekütüphanesi

        Public Class hazır_form_kütüphanesi

            Public Class yeni_değer

                WithEvents TextBox1 As System.Windows.Forms.TextBox
                WithEvents Label1 As New System.Windows.Forms.Label
                WithEvents Button1 As New System.Windows.Forms.Button
                WithEvents Button2 As New System.Windows.Forms.Button
                WithEvents DateTimePicker1 As New System.Windows.Forms.DateTimePicker
                WithEvents yeni_değer As System.Windows.Forms.Form
                Sub kur()
                    Me.TextBox1 = New System.Windows.Forms.TextBox
                    Me.Label1 = New System.Windows.Forms.Label
                    Me.Button1 = New System.Windows.Forms.Button
                    Me.Button2 = New System.Windows.Forms.Button
                    Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
                    '
                    'TextBox1
                    '
                    Me.TextBox1.Location = New System.Drawing.Point(45, 65)
                    Me.TextBox1.Name = "TextBox1"
                    Me.TextBox1.Size = New System.Drawing.Size(210, 20)
                    Me.TextBox1.TabIndex = 0
                    '
                    'Label1
                    '
                    Me.Label1.AutoSize = True
                    Me.Label1.BackColor = System.Drawing.Color.DeepSkyBlue
                    Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
                    Me.Label1.ForeColor = System.Drawing.Color.DarkRed
                    Me.Label1.Location = New System.Drawing.Point(42, 25)
                    Me.Label1.Name = "Label1"
                    Me.Label1.Size = New System.Drawing.Size(219, 16)
                    Me.Label1.TabIndex = 1
                    Me.Label1.Text = "Girmek İstediğiniz Değeri Giriniz:"
                    Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
                    '
                    'Button1
                    '
                    Me.Button1.BackColor = System.Drawing.Color.DarkOrange
                    Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.System
                    Me.Button1.Location = New System.Drawing.Point(157, 101)
                    Me.Button1.Name = "Button1"
                    Me.Button1.Size = New System.Drawing.Size(127, 32)
                    Me.Button1.TabIndex = 2
                    Me.Button1.Text = "İptal"
                    Me.Button1.UseVisualStyleBackColor = False
                    '
                    'Button2
                    '
                    Me.Button2.BackColor = System.Drawing.Color.DarkOrange
                    Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.System
                    Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
                    Me.Button2.Location = New System.Drawing.Point(12, 101)
                    Me.Button2.Name = "Button2"
                    Me.Button2.Size = New System.Drawing.Size(139, 32)
                    Me.Button2.TabIndex = 3
                    Me.Button2.Text = "Tamam"
                    Me.Button2.UseVisualStyleBackColor = False
                    '
                    'DateTimePicker1
                    '
                    Me.DateTimePicker1.Location = New System.Drawing.Point(62, 65)
                    Me.DateTimePicker1.Name = "DateTimePicker1"
                    Me.DateTimePicker1.Size = New System.Drawing.Size(175, 20)
                    Me.DateTimePicker1.TabIndex = 5
                    Me.DateTimePicker1.Value = New Date(2009, 8, 25, 0, 0, 0, 0)
                    Me.DateTimePicker1.Visible = False
                    '
                    'yeni_değer
                    '
                    yeni_değer = New System.Windows.Forms.Form
                    yeni_değer.AcceptButton = Button2
                    yeni_değer.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
                    yeni_değer.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
                    yeni_değer.BackColor = System.Drawing.Color.DeepSkyBlue
                    yeni_değer.ClientSize = New System.Drawing.Size(296, 145)
                    yeni_değer.Controls.Add(Me.DateTimePicker1)
                    yeni_değer.Controls.Add(Me.Button2)
                    yeni_değer.Controls.Add(Me.Button1)
                    yeni_değer.Controls.Add(Me.Label1)
                    yeni_değer.Controls.Add(Me.TextBox1)
                    yeni_değer.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
                    yeni_değer.MaximumSize = New System.Drawing.Size(312, 179)
                    yeni_değer.MinimumSize = New System.Drawing.Size(312, 179)
                    yeni_değer.Name = "yeni_değer"
                    yeni_değer.Text = "yeni_değer"

                    TextBox1.Parent = yeni_değer
                    Label1.Parent = yeni_değer
                    Button1.Parent = yeni_değer
                    Button2.Parent = yeni_değer
                    DateTimePicker1.Parent = yeni_değer

                    yeni_değer.Show()

                End Sub

                Dim öğe1 As Label
                Dim tarih1 As Boolean
                Public Sub yayınla(ByVal yenideğer As String, ByVal açıklama As String, ByVal konu As String, ByVal öğe As Control, ByVal tarih As Boolean)
                    kur()
                    Me.TextBox1.Text = yenideğer
                    Me.Label1.Text = açıklama
                    yeni_değer.Text = konu
                    yeni_değer.Show()
                    öğe1 = öğe
                    tarih1 = tarih
                    If tarih = True Then
                        TextBox1.Visible = False
                        DateTimePicker1.Visible = True
                    End If
                    If tarih = False Then
                        TextBox1.Visible = True
                        DateTimePicker1.Visible = False
                    End If

                End Sub

                Private Sub yeni_değer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles yeni_değer.Load

                End Sub

                Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
                    If tarih1 = True Then
                        TextBox1.Text = DateTimePicker1.Value
                    End If
                    öğe1.Text = TextBox1.Text
                    yeni_değer.Hide()
                End Sub

                Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
                    yeni_değer.Hide()
                End Sub
            End Class

        End Class

        Public Class ok
            Dim referansnok As Point
            WithEvents şekilkonumu As Microsoft.VisualBasic.PowerPacks.ShapeContainer
            WithEvents okunsapı, okunucu1, okunucu2 As Microsoft.VisualBasic.PowerPacks.LineShape
            Sub tanımla()
                Me.okunsapı = New Microsoft.VisualBasic.PowerPacks.LineShape
                Me.okunucu1 = New Microsoft.VisualBasic.PowerPacks.LineShape
                Me.okunucu2 = New Microsoft.VisualBasic.PowerPacks.LineShape
            End Sub
            Sub başla()
                Me.şekilkonumu = New Microsoft.VisualBasic.PowerPacks.ShapeContainer
            End Sub
            Public Sub yukarı(ByVal konum As System.Windows.Forms.Form, ByVal startnoktası As Point)
                referansnok = startnoktası
                With okunucu1
                    .X1 = referansnok.X + 5
                    .Y1 = referansnok.Y
                    .X2 = referansnok.X
                    .Y2 = referansnok.Y + 5
                    .Parent = şekilkonumu
                    .BorderWidth = 4
                    .Show()
                End With
                With okunucu2
                    .X1 = referansnok.X + 5
                    .Y1 = referansnok.Y
                    .X2 = referansnok.X + 10
                    .Y2 = referansnok.Y + 5
                    .Parent = şekilkonumu
                    .BorderWidth = 4
                    .Show()
                End With
                With okunsapı
                    .X1 = referansnok.X + 5
                    .Y1 = referansnok.Y
                    .X2 = referansnok.X + 5
                    .Y2 = referansnok.Y + 10
                    .Parent = şekilkonumu
                    .BorderWidth = 4
                    .Show()
                End With
                With şekilkonumu
                    .Parent = konum
                End With
            End Sub
            Public Sub sağa(ByVal konum As System.Windows.Forms.Form, ByVal startnoktası As Point)
                referansnok = startnoktası
                With okunucu1
                    .X1 = referansnok.X + 5
                    .Y1 = referansnok.Y
                    .X2 = referansnok.X + 10
                    .Y2 = referansnok.Y + 5
                    .Parent = şekilkonumu
                    .BorderWidth = 4
                    .Show()
                End With
                With okunucu2
                    .X1 = referansnok.X + 10
                    .Y1 = referansnok.Y + 5
                    .X2 = referansnok.X + 5
                    .Y2 = referansnok.Y + 10
                    .Parent = şekilkonumu
                    .BorderWidth = 4
                    .Show()
                End With
                With okunsapı
                    .X1 = referansnok.X
                    .Y1 = referansnok.Y + 5
                    .X2 = referansnok.X + 10
                    .Y2 = referansnok.Y + 5
                    .Parent = şekilkonumu
                    .BorderWidth = 4
                    .Show()
                End With
                With şekilkonumu
                    .Parent = konum
                End With
            End Sub
            Public Sub sola(ByVal konum As System.Windows.Forms.Form, ByVal startnoktası As Point)
                referansnok = startnoktası
                With okunucu1
                    .X1 = referansnok.X + 5
                    .Y1 = referansnok.Y
                    .X2 = referansnok.X
                    .Y2 = referansnok.Y + 5
                    .Parent = şekilkonumu
                    .BorderWidth = 4
                    .Show()
                End With
                With okunucu2
                    .X1 = referansnok.X
                    .Y1 = referansnok.Y + 5
                    .X2 = referansnok.X + 5
                    .Y2 = referansnok.Y + 10
                    .Parent = şekilkonumu
                    .BorderWidth = 4
                    .Show()
                End With
                With okunsapı
                    .X1 = referansnok.X
                    .Y1 = referansnok.Y + 5
                    .X2 = referansnok.X + 10
                    .Y2 = referansnok.Y + 5
                    .Parent = şekilkonumu
                    .BorderWidth = 4
                    .Show()
                End With
                With şekilkonumu
                    .Parent = konum
                End With
            End Sub
            Public Sub aşağı(ByVal konum As System.Windows.Forms.Form, ByVal startnoktası As Point)
                referansnok = startnoktası
                With okunucu1
                    .X1 = referansnok.X
                    .Y1 = referansnok.Y + 5
                    .X2 = referansnok.X + 5
                    .Y2 = referansnok.Y + 10
                    .Parent = şekilkonumu
                    .BorderWidth = 4
                    .Show()
                End With
                With okunucu2
                    .X1 = referansnok.X + 5
                    .Y1 = referansnok.Y + 10
                    .X2 = referansnok.X + 10
                    .Y2 = referansnok.Y + 5
                    .Parent = şekilkonumu
                    .BorderWidth = 4
                    .Show()
                End With
                With okunsapı
                    .X1 = referansnok.X + 5
                    .Y1 = referansnok.Y
                    .X2 = referansnok.X + 5
                    .Y2 = referansnok.Y + 10
                    .Parent = şekilkonumu
                    .BorderWidth = 4
                    .Show()
                End With
                With şekilkonumu
                    .Parent = konum
                End With
            End Sub
            Private Sub okunsapı_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles okunsapı.MouseEnter
                okunsapı.BorderColor = Color.Gold
                okunucu1.BorderColor = Color.Gold
                okunucu2.BorderColor = Color.Gold
            End Sub
            Private Sub okunsapı_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles okunsapı.MouseLeave
                okunsapı.BorderColor = Color.Black
                okunucu1.BorderColor = Color.Black
                okunucu2.BorderColor = Color.Black
            End Sub

        End Class

        Public Class dekorist_v2

            Public Class oda
                ' ---------------------------------- ÖZELLİKLER --------------------------------- '

                ' 4 Duvarlı
                ' 8 Kapılı 
                ' Serbest şekilli
                ' Kaydedilip açılabilir
                ' Kendi içinden kayıtlı/sunuculu/serververli
                ' Dış bağlantılı
                ' Kendi içinden şekillenebilir
                ' Kendi içinden hesaplamalı
                ' Kendi içinden ölçütlü
                ' Duvar başına 2 kapılı
                ' Özellikleri dışarıdan ayarlanabilir
                ' Kendi içinden menülü
                ' Sabit referans noktalı

                ' ----------------------------------- MENÜ TANIMLAMALARI ----------------------------------- '



                ' ----------------------------------- TANIMLAMALAR ----------------------------------- '

                ' - lineshapeler / çubuklar - '
                WithEvents duvar1, duvar2, duvar3, duvar4 As Microsoft.VisualBasic.PowerPacks.LineShape
                WithEvents d1kapı1, d1kapı2, d2kapı1, d2kapı2, d3kapı1, d3kapı2, d4kapı1, d4kapı2 As Microsoft.VisualBasic.PowerPacks.LineShape

                ' - ovalshapeler / merkezler - '
                WithEvents m1 As Microsoft.VisualBasic.PowerPacks.OvalShape     ' duvar1 başlangıç , duvar4 bitiş noktaları kesişimi
                WithEvents m2 As Microsoft.VisualBasic.PowerPacks.OvalShape     ' duvar2 başlangıç , duvar1 bitiş noktaları kesişimi
                WithEvents m3 As Microsoft.VisualBasic.PowerPacks.OvalShape     ' duvar3 başlangıç , duvar2 bitiş noktaları kesişimi
                WithEvents m4 As Microsoft.VisualBasic.PowerPacks.OvalShape     ' duvar4 başlangıç , duvar3 bitiş noktaları kesişimi

                ' - labeller / etiketler - ' 
                WithEvents duvar1u, duvar2u, duvar3u, duvar4u As System.Windows.Forms.Label
                WithEvents odaadı, odaölçütleri, odanınkapladığıalan, odanıntduvaralanı As System.Windows.Forms.Label

                ' - textboxlar / yazı kutuları , sunucular - '
                WithEvents duvar1ut, duvar2ut, duvar3ut, duvar4ut As System.Windows.Forms.TextBox
                WithEvents sunucu As System.Windows.Forms.RichTextBox

                ' - timerler / yineleyiciler - '
                WithEvents merkezbelirleyici, olayizleyici As System.Windows.Forms.Timer
                WithEvents m1y As System.Windows.Forms.Timer
                WithEvents m2y As System.Windows.Forms.Timer
                WithEvents m3y As System.Windows.Forms.Timer
                WithEvents m4y As System.Windows.Forms.Timer

                ' ----------------------------------- DEĞİŞKENLER ----------------------------------- '

                ' - özellik değişkenleri - '
                Dim duvarkalınlığı As Integer = 2
                Dim cetvel As Integer = 1
                Dim olaysırası As Integer

                ' - dışarıdan alınan diğer bilgiler - '
                Dim referansnoktası As Point
                Dim form2 As Form
                Dim container As Microsoft.VisualBasic.PowerPacks.ShapeContainer
                WithEvents olaykutucuğu As TextBox
                WithEvents cetveltext As TextBox

                ' - İÇ DEĞİŞKENLER - ' 

                ' - pointler / noktalar - '
                Dim m1p As Point
                Dim m2p As Point
                Dim m3p As Point
                Dim m4p As Point

                ' - değerler - '
                Dim d1açı, d2açı, d3açı, d4açı As Double
                Dim m1nok, m2nok, m3nok, m4nok As Point
                Dim d1k1bnu, d1k2bnu, d2k1bnu, d2k2bnu, d3k1bnu, d3k2bnu, d4k1bnu, d4k2bnu As Double   ' Örnek: d1k1bnu = birinci duvarın 1.kapısının 1.duvarın başlangıç noktasına uzaklığı
                Dim d1k1g, d1k2g, d2k1g, d2k2g, d3k1g, d3k2g, d4k1g, d4k2g As Double
                Dim d1u, d2u, d3u, d4u As Double
                Dim farex, farey As Integer
                ' - olaylar için yapay zeka değerleri - '
                Dim sürüklemekilidi As Integer

                ' ----------------------------------- KODLAMALAR (START POİNTS / BAŞLAMA NOKLATALARI) ----------------------------------- '

                Sub kurmaya_başla(ByVal zoom As TextBox, ByVal refnok As Point, ByVal form As Form, ByVal şekilalanı As Microsoft.VisualBasic.PowerPacks.ShapeContainer, ByVal olayyazısı As TextBox)
                    ' Burası kolay kod dizimi için parçalara bölünmüş kod dizimlerini içerir
                    ' Prosedürler sıraya konulmuştur
                    cetveltext = zoom
                    cetveltext.Text = zoom.Text
                    olaykutucuğu = olayyazısı
                    container = şekilalanı
                    referansnoktası = refnok
                    Form1 = form
                    değişkenleri_al()
                    değişkenleri_kur()
                    menüyü_hazırla()
                    oda_görünümü_için_nesneleri_hazırla()
                End Sub
                Private Sub değişkenleri_kur()
                    m1nok.X = 100
                    m1nok.Y = 100
                    m2nok.X = 100
                    m2nok.Y = 0
                    m3nok.X = 0
                    m3nok.Y = 0
                    m4nok.X = 0
                    m4nok.Y = 100
                    m1p.X = referansnoktası.X + m1nok.X
                    m1p.Y = referansnoktası.Y + m1nok.Y
                    m2p.X = referansnoktası.X + m2nok.X
                    m2p.Y = referansnoktası.Y + m2nok.Y
                    m3p.X = referansnoktası.X + m3nok.X
                    m3p.Y = referansnoktası.Y + m3nok.Y
                    m4p.X = referansnoktası.X + m4nok.X
                    m4p.Y = referansnoktası.Y + m4nok.Y
                End Sub

                Private Sub değişkenleri_al()

                End Sub

                Private Sub menüyü_hazırla()

                End Sub

                Private Sub oda_görünümü_için_nesneleri_hazırla()
                    ' !!!!!!!!!! OLUŞTUR !!!!!!!!!! '
merkezler:
                    ' ----- merkezler ----- '
                    m1 = New Microsoft.VisualBasic.PowerPacks.OvalShape
                    m2 = New Microsoft.VisualBasic.PowerPacks.OvalShape
                    m3 = New Microsoft.VisualBasic.PowerPacks.OvalShape
                    m4 = New Microsoft.VisualBasic.PowerPacks.OvalShape
kapılar:
                    ' ----- kapılar ----- '
                    d1kapı1 = New Microsoft.VisualBasic.PowerPacks.LineShape
                    d1kapı2 = New Microsoft.VisualBasic.PowerPacks.LineShape
                    d2kapı1 = New Microsoft.VisualBasic.PowerPacks.LineShape
                    d2kapı2 = New Microsoft.VisualBasic.PowerPacks.LineShape
                    d3kapı1 = New Microsoft.VisualBasic.PowerPacks.LineShape
                    d3kapı2 = New Microsoft.VisualBasic.PowerPacks.LineShape
                    d4kapı1 = New Microsoft.VisualBasic.PowerPacks.LineShape
                    d4kapı2 = New Microsoft.VisualBasic.PowerPacks.LineShape
duvarlar:
                    ' ----- duvarlar ----- '
                    duvar1 = New Microsoft.VisualBasic.PowerPacks.LineShape
                    duvar2 = New Microsoft.VisualBasic.PowerPacks.LineShape
                    duvar3 = New Microsoft.VisualBasic.PowerPacks.LineShape
                    duvar4 = New Microsoft.VisualBasic.PowerPacks.LineShape

zamanlayıcılar:
                    ' ----- zamanlayıcılar ----- '
                    merkezbelirleyici = New System.Windows.Forms.Timer
                    olayizleyici = New System.Windows.Forms.Timer

                    m1y = New System.Windows.Forms.Timer
                    m2y = New System.Windows.Forms.Timer
                    m3y = New System.Windows.Forms.Timer
                    m4y = New System.Windows.Forms.Timer
etiketler:
                    ' ----- etiketler ----- '
                    duvar1u = New System.Windows.Forms.Label
                    duvar2u = New System.Windows.Forms.Label
                    duvar3u = New System.Windows.Forms.Label
                    duvar4u = New System.Windows.Forms.Label
yazıkutuları:
                    ' ----- yazı kutuları ----- '
                    duvar1ut = New System.Windows.Forms.TextBox
                    duvar2ut = New System.Windows.Forms.TextBox
                    duvar3ut = New System.Windows.Forms.TextBox
                    duvar4ut = New System.Windows.Forms.TextBox

                    ' !!!!!!!!!! ÖZELLİKLERİNİ AYARLA !!!!!!!!! '
merkezlerin:
                    ' merkezlerin standart özellikleri '
                    With m1
                        .Height = 8
                        .Width = 8
                        .BackColor = Color.White
                        .BackStyle = BackStyle.Opaque
                        .Top = m1p.Y - 4
                        .Left = m1p.X - 4
                        .Visible = True
                        .Show()
                        .Parent = container
                    End With
                    With m2
                        .Height = 8
                        .Width = 8
                        .BackColor = Color.White
                        .BackStyle = BackStyle.Opaque
                        .Top = m2p.Y - 4
                        .Left = m2p.X - 4
                        .Visible = True
                        .Show()
                        .Parent = container
                    End With
                    With m3
                        .Height = 8
                        .Width = 8
                        .BackColor = Color.White
                        .BackStyle = BackStyle.Opaque
                        .Top = m3p.Y - 4
                        .Left = m3p.X - 4
                        .Visible = True
                        .Show()
                        .Parent = container
                    End With
                    With m4
                        .Height = 8
                        .Width = 8
                        .BackColor = Color.White
                        .BackStyle = BackStyle.Opaque
                        .Top = m4p.Y - 4
                        .Left = m4p.X - 4
                        .Visible = True
                        .Show()
                        .Parent = container
                    End With
kapıların:
                    With d1kapı1
                        .BorderColor = Color.White
                        .BorderWidth += 5
                        .X1 = m1p.X + d1k1bnu * Cos(d1açı * PI / 360)
                        .Y1 = m1p.Y + d1k1bnu * Sin(d1açı * PI / 360)
                        .X2 = m1p.X + (d1k1bnu * +d1k1g) * Cos(d1açı * PI / 360)
                        .Y2 = m1p.Y + (d1k1bnu + d1k1g) * Sin(d1açı * PI / 360)
                        .Show()
                        .Parent = container
                    End With
                    With d1kapı2
                        .BorderColor = Color.White
                        .BorderWidth = 5
                        .X1 = m1p.X + d1k2bnu * Cos(d1açı * PI / 360)
                        .Y1 = m1p.Y + d1k2bnu * Sin(d1açı * PI / 360)
                        .X2 = m1p.X + (d1k2bnu + d1k2g) * Cos(d1açı * PI / 360)
                        .Y2 = m1p.Y + (d1k2bnu + d1k2g) * Sin(d1açı * PI / 360)
                        .Show()
                        .Parent = container
                    End With
                    With d2kapı1
                        .BorderColor = Color.White
                        .BorderWidth = 5
                        .X1 = m2p.X + d2k1bnu * Cos(d2açı * PI / 360)
                        .Y1 = m2p.Y + d2k1bnu * Sin(d2açı * PI / 360)
                        .X2 = m2p.X + (d2k1bnu + d2k1g) * Cos(d2açı * PI / 360)
                        .Y2 = m2p.Y + (d2k1bnu + d2k1g) * Sin(d2açı * PI / 360)
                        .Show()
                        .Parent = container
                    End With
                    With d2kapı2
                        .BorderColor = Color.White
                        .BorderWidth = 5
                        .X1 = m2p.X + d2k2bnu * Cos(d2açı * PI / 360)
                        .Y1 = m2p.Y + d2k2bnu * Sin(d2açı * PI / 360)
                        .X2 = m2p.X + (d2k2bnu + d2k2g) * Cos(d2açı * PI / 360)
                        .Y2 = m2p.Y + (d2k2bnu + d2k2g) * Sin(d2açı * PI / 360)
                        .Show()
                        .Parent = container
                    End With
                    With d3kapı1
                        .BorderColor = Color.White
                        .BorderWidth = 5
                        .X1 = m3p.X + d3k1bnu * Cos(d3açı * PI / 360)
                        .Y1 = m3p.Y + d3k1bnu * Sin(d3açı * PI / 360)
                        .X2 = m3p.X + (d3k1bnu + d3k1g) * Cos(d3açı * PI / 360)
                        .Y2 = m3p.Y + (d3k1bnu + d3k1g) * Sin(d3açı * PI / 360)
                        .Show()
                        .Parent = container
                    End With
                    With d3kapı2
                        .BorderColor = Color.White
                        .BorderWidth = 5
                        .X1 = m3p.X + d3k2bnu * Cos(d3açı * PI / 360)
                        .Y1 = m3p.Y + d3k2bnu * Sin(d3açı * PI / 360)
                        .X2 = m3p.X + (d3k2bnu + d3k2g) * Cos(d3açı * PI / 360)
                        .Y2 = m3p.Y + (d3k2bnu + d3k2g) * Sin(d3açı * PI / 360)
                        .Show()
                        .Parent = container
                    End With
                    With d4kapı1
                        .BorderColor = Color.White
                        .BorderWidth = 5
                        .X1 = m4p.X + d4k1bnu * Cos(d4açı * PI / 360)
                        .Y1 = m4p.Y + d4k1bnu * Sin(d4açı * PI / 360)
                        .X2 = m4p.X + (d4k1bnu + d4k1g) * Cos(d4açı * PI / 360)
                        .Y2 = m4p.Y + (d4k1bnu + d4k1g) * Sin(d4açı * PI / 360)
                        .Show()
                        .Parent = container
                    End With
                    With d4kapı2
                        .BorderColor = Color.White
                        .BorderWidth = 5
                        .X1 = m4p.X + d4k2bnu * Cos(d4açı * PI / 360)
                        .Y1 = m4p.Y + d4k2bnu * Sin(d4açı * PI / 360)
                        .X2 = m4p.X + (d4k2bnu + d4k2g) * Cos(d4açı * PI / 360)
                        .Y2 = m4p.Y + (d4k2bnu + d4k2g) * Sin(d4açı * PI / 360)
                        .Show()
                        .Parent = container
                    End With
duvarların:
                    ' duvarların standart özellikleri '
                    With duvar1
                        .BorderWidth = 2
                        .StartPoint = m1p
                        .EndPoint = m2p
                        .Visible = True
                        .Show()
                        .Parent = container
                    End With
                    With duvar2
                        .BorderWidth = 2
                        .StartPoint = m2p
                        .EndPoint = m3p
                        .Visible = True
                        .Show()
                        .Parent = container
                    End With
                    With duvar3
                        .BorderWidth = 2
                        .StartPoint = m3p
                        .EndPoint = m4p
                        .Visible = True
                        .Show()
                        .Parent = container
                    End With
                    With duvar4
                        .BorderWidth = 2
                        .StartPoint = m4p
                        .EndPoint = m1p
                        .Visible = True
                        .Show()
                        .Parent = container
                    End With
                End Sub

                Private Sub oda_içi_nesneleri_yerleştir()
                    ' Değişkenler burada tekrar kurulur
                    m1p.X = m1nok.X
                    m1p.Y = m1nok.Y
                    m2p.X = m2nok.X
                    m2p.Y = m2nok.Y
                    m3p.X = m3nok.X
                    m3p.Y = m3nok.Y
                    m4p.X = m4nok.X
                    m4p.Y = m4nok.Y
                    ' kapıların özellikleri '
                    d1açı = -(Atan2(m2p.Y - m1p.Y, m2p.X - m1p.X) * 180 / PI)
                    d2açı = -(Atan2(m3p.Y - m2p.Y, m3p.X - m2p.X) * 180 / PI)
                    d3açı = -(Atan2(m4p.Y - m3p.Y, m4p.X - m3p.X) * 180 / PI)
                    d4açı = -(Atan2(m1p.Y - m4p.Y, m1p.X - m4p.X) * 180 / PI)
                    d1k1g = 10
                    d1k2g = 10
                    d2k1g = 10
                    d2k2g = 10
                    d3k1g = 10
                    d3k2g = 10
                    d4k1g = 10
                    d4k2g = 10

merkezlerin:
                    ' merkezlerin standart özellikleri '
                    With m1
                        .Height = (cetvel * 8)
                        .Width = (cetvel * 8)
                        .BackColor = Color.White
                        .BackStyle = BackStyle.Opaque
                        .Top = m1p.Y - ((cetvel * 8) / 2)
                        .Left = m1p.X - ((cetvel * 8) / 2)
                        .Visible = True
                        .Show()
                        .Parent = container
                    End With
                    With m2
                        .Height = (cetvel * 8)
                        .Width = (cetvel * 8)
                        .BackColor = Color.White
                        .BackStyle = BackStyle.Opaque
                        .Top = m2p.Y - ((cetvel * 8) / 2)
                        .Left = m2p.X - ((cetvel * 8) / 2)
                        .Visible = True
                        .Show()
                        .Parent = container
                    End With
                    With m3
                        .Height = (cetvel * 8)
                        .Width = (cetvel * 8)
                        .BackColor = Color.White
                        .BackStyle = BackStyle.Opaque
                        .Top = m3p.Y - ((cetvel * 8) / 2)
                        .Left = m3p.X - ((cetvel * 8) / 2)
                        .Visible = True
                        .Show()
                        .Parent = container
                    End With
                    With m4
                        .Height = (cetvel * 8)
                        .Width = (cetvel * 8)
                        .BackColor = Color.White
                        .BackStyle = BackStyle.Opaque
                        .Top = m4p.Y - ((cetvel * 8) / 2)
                        .Left = m4p.X - ((cetvel * 8) / 2)
                        .Visible = True
                        .Show()
                        .Parent = container
                    End With
duvarların:
                    ' duvarların standart özellikleri '
                    With duvar1
                        .BorderWidth = duvarkalınlığı
                        .StartPoint = m1p
                        .EndPoint = m2p
                        .Visible = True
                        .Show()
                        .Parent = container
                    End With
                    With duvar2
                        .BorderWidth = duvarkalınlığı
                        .StartPoint = m2p
                        .EndPoint = m3p
                        .Visible = True
                        .Show()
                        .Parent = container
                    End With
                    With duvar3
                        .BorderWidth = duvarkalınlığı
                        .StartPoint = m3p
                        .EndPoint = m4p
                        .Visible = True
                        .Show()
                        .Parent = container
                    End With
                    With duvar4
                        .BorderWidth = duvarkalınlığı
                        .StartPoint = m4p
                        .EndPoint = m1p
                        .Visible = True
                        .Show()
                        .Parent = container
                    End With
kapıların:
                    With d1kapı1
                        .BorderColor = Color.White
                        .BorderWidth = duvarkalınlığı + 5
                        .X1 = m1p.X + (d1k1bnu * cetvel) * Cos(d1açı * PI / 180)
                        .Y1 = m1p.Y + (d1k1bnu * cetvel) * Sin(d1açı * PI / 180)
                        .X2 = m1p.X + ((d1k1bnu * cetvel) + d1k1g) * Cos(d1açı * PI / 180)
                        .Y2 = m1p.Y + ((d1k1bnu * cetvel) + d1k1g) * Sin(d1açı * PI / 180)
                        .Visible = True
                        .Show()
                        .Parent = container
                    End With
                    With d1kapı2
                        .BorderColor = Color.White
                        .BorderWidth = duvarkalınlığı + 5
                        .X1 = m1p.X + (d1k2bnu * cetvel) * Cos(d1açı * PI / 180)
                        .Y1 = m1p.Y + (d1k2bnu * cetvel) * Sin(d1açı * PI / 180)
                        .X2 = m1p.X + ((d1k2bnu * cetvel) + d1k2g) * Cos(d1açı * PI / 180)
                        .Y2 = m1p.Y + ((d1k2bnu * cetvel) + d1k2g) * Sin(d1açı * PI / 180)
                        .Show()
                        .Parent = container
                    End With
                    With d2kapı1
                        .BorderColor = Color.White
                        .BorderWidth = duvarkalınlığı + 5
                        .X1 = m2p.X + (d2k1bnu * cetvel) * Cos(d2açı * PI / 180)
                        .Y1 = m2p.Y + (d2k1bnu * cetvel) * Sin(d2açı * PI / 180)
                        .X2 = m2p.X + ((d2k1bnu * cetvel) + d2k1g) * Cos(d2açı * PI / 180)
                        .Y2 = m2p.Y + ((d2k1bnu * cetvel) + d2k1g) * Sin(d2açı * PI / 180)
                        .Show()
                        .Parent = container
                    End With
                    With d2kapı2
                        .BorderColor = Color.White
                        .BorderWidth = duvarkalınlığı + 5
                        .X1 = m2p.X + (d2k2bnu * cetvel) * Cos(d2açı * PI / 180)
                        .Y1 = m2p.Y + (d2k2bnu * cetvel) * Sin(d2açı * PI / 180)
                        .X2 = m2p.X + ((d2k2bnu * cetvel) + d2k2g) * Cos(d2açı * PI / 180)
                        .Y2 = m2p.Y + ((d2k2bnu * cetvel) + d2k2g) * Sin(d2açı * PI / 180)
                        .Show()
                        .Parent = container
                    End With
                    With d3kapı1
                        .BorderColor = Color.White
                        .BorderWidth = duvarkalınlığı + 5
                        .X1 = m3p.X + (d3k1bnu * cetvel) * Cos(d3açı * PI / 180)
                        .Y1 = m3p.Y + (d3k1bnu * cetvel) * Sin(d3açı * PI / 180)
                        .X2 = m3p.X + ((d3k1bnu * cetvel) + d3k1g) * Cos(d3açı * PI / 180)
                        .Y2 = m3p.Y + ((d3k1bnu * cetvel) + d3k1g) * Sin(d3açı * PI / 180)
                        .Show()
                        .Parent = container
                    End With
                    With d3kapı2
                        .BorderColor = Color.White
                        .BorderWidth = duvarkalınlığı + 5
                        .X1 = m3p.X + (d3k2bnu * cetvel) * Cos(d3açı * PI / 180)
                        .Y1 = m3p.Y + (d3k2bnu * cetvel) * Sin(d3açı * PI / 180)
                        .X2 = m3p.X + ((d3k2bnu * cetvel) + d3k2g) * Cos(d3açı * PI / 180)
                        .Y2 = m3p.Y + ((d3k2bnu * cetvel) + d3k2g) * Sin(d3açı * PI / 180)
                        .Show()
                        .Parent = container
                    End With
                    With d4kapı1
                        .BorderColor = Color.White
                        .BorderWidth = duvarkalınlığı + 5
                        .X1 = m4p.X + (d4k1bnu * cetvel) * Cos(d4açı * PI / 180)
                        .Y1 = m4p.Y + (d4k1bnu * cetvel) * Sin(d4açı * PI / 180)
                        .X2 = m4p.X + ((d4k1bnu * cetvel) + d4k1g) * Cos(d4açı * PI / 180)
                        .Y2 = m4p.Y + ((d4k1bnu * cetvel) + d4k1g) * Sin(d4açı * PI / 180)
                        .Show()
                        .Parent = container
                    End With
                    With d4kapı2
                        .BorderColor = Color.White
                        .BorderWidth = duvarkalınlığı + 5
                        .X1 = m4p.X + (d4k2bnu * cetvel) * Cos(d4açı * PI / 180)
                        .Y1 = m4p.Y + (d4k2bnu * cetvel) * Sin(d4açı * PI / 180)
                        .X2 = m4p.X + ((d4k2bnu * cetvel) + d4k2g) * Cos(d4açı * PI / 180)
                        .Y2 = m4p.Y + ((d4k2bnu * cetvel) + d4k2g) * Sin(d4açı * PI / 180)
                        .Show()
                        .Parent = container
                    End With
                End Sub

                Sub şeklideğiştir()
                    ' merkezlerin yeni konumlarını belirliyoz
                    d1açı = -(Atan2(m2p.Y - m1p.Y, m2p.X - m1p.X) * 180 / PI)
                    d2açı = -(Atan2(m3p.Y - m2p.Y, m3p.X - m2p.X) * 180 / PI)
                    d3açı = -(Atan2(m4p.Y - m3p.Y, m4p.X - m3p.X) * 180 / PI)
                    d4açı = -(Atan2(m1p.Y - m4p.Y, m1p.X - m4p.X) * 180 / PI)

                End Sub

                Sub sürükle(ByVal genelmi As Boolean)
                    If genelmi = False Then
                        ' Değişkenler burada tekrar kurulur
                        duvarkalınlığı = cetvel * 2

                        ' kapıların özellikleri '
                        d1açı = -(Atan2(m2p.Y - m1p.Y, m2p.X - m1p.X) * 180 / PI)
                        d2açı = -(Atan2(m3p.Y - m2p.Y, m3p.X - m2p.X) * 180 / PI)
                        d3açı = -(Atan2(m4p.Y - m3p.Y, m4p.X - m3p.X) * 180 / PI)
                        d4açı = -(Atan2(m1p.Y - m4p.Y, m1p.X - m4p.X) * 180 / PI)
                        d1k1g = (cetvel * 10)
                        d1k2g = (cetvel * 10)
                        d2k1g = (cetvel * 10)
                        d2k2g = (cetvel * 10)
                        d3k1g = (cetvel * 10)
                        d3k2g = (cetvel * 10)
                        d4k1g = (cetvel * 10)
                        d4k2g = (cetvel * 10)

merkezlerin:
                        ' merkezlerin standart özellikleri '
                        With m1
                            .Height = (cetvel * 8)
                            .Width = (cetvel * 8)
                            .BackColor = Color.White
                            .BackStyle = BackStyle.Opaque
                            .Top = m1p.Y
                            .Left = m1p.X
                            .Visible = True
                            .Show()
                            .Parent = container
                        End With
                        With m2
                            .Height = (cetvel * 8)
                            .Width = (cetvel * 8)
                            .BackColor = Color.White
                            .BackStyle = BackStyle.Opaque
                            .Top = m2p.Y
                            .Left = m2p.X
                            .Visible = True
                            .Show()
                            .Parent = container
                        End With
                        With m3
                            .Height = (cetvel * 8)
                            .Width = (cetvel * 8)
                            .BackColor = Color.White
                            .BackStyle = BackStyle.Opaque
                            .Top = m3p.Y
                            .Left = m3p.X
                            .Visible = True
                            .Show()
                            .Parent = container
                        End With
                        With m4
                            .Height = (cetvel * 8)
                            .Width = (cetvel * 8)
                            .BackColor = Color.White
                            .BackStyle = BackStyle.Opaque
                            .Top = m4p.Y
                            .Left = m4p.X
                            .Visible = True
                            .Show()
                            .Parent = container
                        End With
duvarların:
                        ' duvarların standart özellikleri '
                        With duvar1
                            .BorderWidth = duvarkalınlığı
                            .StartPoint = m1p
                            .EndPoint = m2p
                            .Visible = True
                            .Show()
                            .Parent = container
                        End With
                        With duvar2
                            .BorderWidth = duvarkalınlığı
                            .StartPoint = m2p
                            .EndPoint = m3p
                            .Visible = True
                            .Show()
                            .Parent = container
                        End With
                        With duvar3
                            .BorderWidth = duvarkalınlığı
                            .StartPoint = m3p
                            .EndPoint = m4p
                            .Visible = True
                            .Show()
                            .Parent = container
                        End With
                        With duvar4
                            .BorderWidth = duvarkalınlığı
                            .StartPoint = m4p
                            .EndPoint = m1p
                            .Visible = True
                            .Show()
                            .Parent = container
                        End With
kapıların:
                        With d1kapı1
                            .BorderColor = Color.White
                            .BorderWidth = duvarkalınlığı + 5
                            .X1 = m1p.X + (d1k1bnu * cetvel) * Cos(d1açı * PI / 180)
                            .Y1 = m1p.Y + (d1k1bnu * cetvel) * Sin(d1açı * PI / 180)
                            .X2 = m1p.X + ((d1k1bnu * cetvel) + d1k1g) * Cos(d1açı * PI / 180)
                            .Y2 = m1p.Y + ((d1k1bnu * cetvel) + d1k1g) * Sin(d1açı * PI / 180)
                            .Visible = True
                            .Show()
                            .Parent = container
                        End With
                        With d1kapı2
                            .BorderColor = Color.White
                            .BorderWidth = duvarkalınlığı + 5
                            .X1 = m1p.X + (d1k2bnu * cetvel) * Cos(d1açı * PI / 180)
                            .Y1 = m1p.Y + (d1k2bnu * cetvel) * Sin(d1açı * PI / 180)
                            .X2 = m1p.X + ((d1k2bnu * cetvel) + d1k2g) * Cos(d1açı * PI / 180)
                            .Y2 = m1p.Y + ((d1k2bnu * cetvel) + d1k2g) * Sin(d1açı * PI / 180)
                            .Show()
                            .Parent = container
                        End With
                        With d2kapı1
                            .BorderColor = Color.White
                            .BorderWidth = duvarkalınlığı + 5
                            .X1 = m2p.X + (d2k1bnu * cetvel) * Cos(d2açı * PI / 180)
                            .Y1 = m2p.Y + (d2k1bnu * cetvel) * Sin(d2açı * PI / 180)
                            .X2 = m2p.X + ((d2k1bnu * cetvel) + d2k1g) * Cos(d2açı * PI / 180)
                            .Y2 = m2p.Y + ((d2k1bnu * cetvel) + d2k1g) * Sin(d2açı * PI / 180)
                            .Show()
                            .Parent = container
                        End With
                        With d2kapı2
                            .BorderColor = Color.White
                            .BorderWidth = duvarkalınlığı + 5
                            .X1 = m2p.X + (d2k2bnu * cetvel) * Cos(d2açı * PI / 180)
                            .Y1 = m2p.Y + (d2k2bnu * cetvel) * Sin(d2açı * PI / 180)
                            .X2 = m2p.X + ((d2k2bnu * cetvel) + d2k2g) * Cos(d2açı * PI / 180)
                            .Y2 = m2p.Y + ((d2k2bnu * cetvel) + d2k2g) * Sin(d2açı * PI / 180)
                            .Show()
                            .Parent = container
                        End With
                        With d3kapı1
                            .BorderColor = Color.White
                            .BorderWidth = duvarkalınlığı + 5
                            .X1 = m3p.X + (d3k1bnu * cetvel) * Cos(d3açı * PI / 180)
                            .Y1 = m3p.Y + (d3k1bnu * cetvel) * Sin(d3açı * PI / 180)
                            .X2 = m3p.X + ((d3k1bnu * cetvel) + d3k1g) * Cos(d3açı * PI / 180)
                            .Y2 = m3p.Y + ((d3k1bnu * cetvel) + d3k1g) * Sin(d3açı * PI / 180)
                            .Show()
                            .Parent = container
                        End With
                        With d3kapı2
                            .BorderColor = Color.White
                            .BorderWidth = duvarkalınlığı + 5
                            .X1 = m3p.X + (d3k2bnu * cetvel) * Cos(d3açı * PI / 180)
                            .Y1 = m3p.Y + (d3k2bnu * cetvel) * Sin(d3açı * PI / 180)
                            .X2 = m3p.X + ((d3k2bnu * cetvel) + d3k2g) * Cos(d3açı * PI / 180)
                            .Y2 = m3p.Y + ((d3k2bnu * cetvel) + d3k2g) * Sin(d3açı * PI / 180)
                            .Show()
                            .Parent = container
                        End With
                        With d4kapı1
                            .BorderColor = Color.White
                            .BorderWidth = duvarkalınlığı + 5
                            .X1 = m4p.X + (d4k1bnu * cetvel) * Cos(d4açı * PI / 180)
                            .Y1 = m4p.Y + (d4k1bnu * cetvel) * Sin(d4açı * PI / 180)
                            .X2 = m4p.X + ((d4k1bnu * cetvel) + d4k1g) * Cos(d4açı * PI / 180)
                            .Y2 = m4p.Y + ((d4k1bnu * cetvel) + d4k1g) * Sin(d4açı * PI / 180)
                            .Show()
                            .Parent = container
                        End With
                        With d4kapı2
                            .BorderColor = Color.White
                            .BorderWidth = duvarkalınlığı + 5
                            .X1 = m4p.X + (d4k2bnu * cetvel) * Cos(d4açı * PI / 180)
                            .Y1 = m4p.Y + (d4k2bnu * cetvel) * Sin(d4açı * PI / 180)
                            .X2 = m4p.X + ((d4k2bnu * cetvel) + d4k2g) * Cos(d4açı * PI / 180)
                            .Y2 = m4p.Y + ((d4k2bnu * cetvel) + d4k2g) * Sin(d4açı * PI / 180)
                            .Show()
                            .Parent = container
                        End With
                    End If
                End Sub
                ' ----------------------------------- KODLAMALAR (OLAYLAR) ----------------------------------- '


                Private Sub m1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles m1.MouseDown
                    m1y.Enabled = True
                    m1y.Interval = 1

                End Sub

                Private Sub m1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles m1.MouseUp
                    m1y.Enabled = False
                End Sub

                Private Sub m1y_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles m1y.Tick
                    m1.Left = Form1.TextBox2.Text - 4
                    m1.Top = Form1.TextBox3.Text - 4
                End Sub
            End Class
        End Class


        Public Class dekorist_v1
            Public Class oda
                ' basit şekilli
                ' direk ekleyebilme
                ' alan,çevre vs ölçümü
                ' kendi içinden serverli
                ' dört duvarlı
                ' görsel arayüzlü

                ' ---------- fiziksel değişkenler ---------- '
                Dim duvar1, duvar2, duvar3, duvar4 As duvar

                WithEvents d1 As System.Windows.Forms.TextBox
                WithEvents d2 As System.Windows.Forms.TextBox
                WithEvents d3 As System.Windows.Forms.TextBox
                WithEvents d4 As System.Windows.Forms.TextBox

                WithEvents x As TextBox
                WithEvents y As TextBox

                WithEvents referansx As System.Windows.Forms.TextBox
                WithEvents referansy As System.Windows.Forms.TextBox

                WithEvents parent As Control
                WithEvents parent_zemini As Control

                WithEvents ek_alan As System.Windows.Forms.TextBox

                WithEvents yüksekliği As System.Windows.Forms.TextBox
                WithEvents tabanı As System.Windows.Forms.TextBox
                WithEvents sağı As System.Windows.Forms.TextBox
                WithEvents solu As System.Windows.Forms.TextBox

                WithEvents panel As Panel
                WithEvents odaalanı As System.Windows.Forms.Label
                WithEvents boyanacakalan As System.Windows.Forms.TextBox
                WithEvents duvarların_yüz_ölçümü As System.Windows.Forms.Label
                WithEvents veritabanı As System.Windows.Forms.RichTextBox

                WithEvents denemetext As System.Windows.Forms.TextBox

                ' ---------- sanal değişkenler ---------- '
                Dim ilkaçılış As Boolean
                Dim ref_ilkaçılış As Boolean

                ' --- açılış değişkenleri --- '
                Dim açılış As Boolean
                Dim oto_şekil As Boolean
                Dim şekil_parent As Microsoft.VisualBasic.PowerPacks.ShapeContainer


                Dim soy_ağacı As String
                Dim farkx, farky As Double
                Dim çıkarma_modu As Boolean

                Sub yanoda_kurulum(ByVal yanduvar As System.Windows.Forms.TextBox, ByVal kapıyönü As String, ByVal açma As Boolean, ByVal otoşek As Boolean, ByVal aile As Control, ByVal değişkenfarex As TextBox, ByVal değişkenfarey As TextBox, ByVal şekil_ailesi As Microsoft.VisualBasic.PowerPacks.ShapeContainer, ByVal soyağacı As String, ByVal veri_tabanı As Object, ByVal formbaşlıkkalınlığı As Double, ByVal formçerçevekalınlığı As Double, ByVal refx As System.Windows.Forms.TextBox, ByVal refy As Windows.Forms.TextBox)

                    yüksekliği = New System.Windows.Forms.TextBox
                    tabanı = New System.Windows.Forms.TextBox
                    sağı = New System.Windows.Forms.TextBox
                    solu = New System.Windows.Forms.TextBox

                    denemetext = New System.Windows.Forms.TextBox

                    denemetext = yanduvar

                    If kapıyönü = "yüksekliği" Then
                        yüksekliği = yanduvar
                    End If
                    If kapıyönü = "tabanı" Then
                        tabanı = yanduvar
                    End If
                    If kapıyönü = "sağı" Then
                        sağı = yanduvar
                    End If
                    If kapıyönü = "solu" Then
                        solu = yanduvar
                    End If

                    yanodakurulum(açma, otoşek, aile, değişkenfarex, değişkenfarey, şekil_ailesi, soyağacı, veri_tabanı, Form1.farky, Form1.farky, refx, refy)

                End Sub

                Sub kur(ByVal açma As Boolean, ByVal otoşek As Boolean, ByVal aile As Control, ByVal değişkenfarex As System.Windows.Forms.TextBox, ByVal değişkenfarey As System.Windows.Forms.TextBox, ByVal şekil_ailesi As Microsoft.VisualBasic.PowerPacks.ShapeContainer, ByVal soyağacı As String, ByVal veri_tabanı As Object, ByVal formbaşlıkkalınlığı As Double, ByVal formçerçevekalınlığı As Double, ByVal refx As System.Windows.Forms.TextBox, ByVal refy As Windows.Forms.TextBox)

                    x = değişkenfarex
                    y = değişkenfarey

                    referansx = refx
                    referansy = refy

                    ref_ilkaçılış = True
                    çıkarma_modu = False
                    oto_şekil = otoşek

                    parent = aile

                    şekil_parent = şekil_ailesi

                    veritabanı = veri_tabanı
                    veri_tabanı = veritabanı

                    soy_ağacı = soyağacı

                    farkx = formçerçevekalınlığı
                    farky = formbaşlıkkalınlığı

                    yüksekliği = New System.Windows.Forms.TextBox
                    tabanı = New System.Windows.Forms.TextBox
                    sağı = New System.Windows.Forms.TextBox
                    solu = New System.Windows.Forms.TextBox

                    değişkenleri_tanımla()

                    If açma = True Then
                        aç(soyağacı)
                    End If

                    değişkenleri_kur()
                    hesapla()


                End Sub

                Sub yanodakurulum(ByVal açma As Boolean, ByVal otoşek As Boolean, ByVal aile As Control, ByVal değişkenfarex As System.Windows.Forms.TextBox, ByVal değişkenfarey As System.Windows.Forms.TextBox, ByVal şekil_ailesi As Microsoft.VisualBasic.PowerPacks.ShapeContainer, ByVal soyağacı As String, ByVal veri_tabanı As Object, ByVal formbaşlıkkalınlığı As Double, ByVal formçerçevekalınlığı As Double, ByVal refx As System.Windows.Forms.TextBox, ByVal refy As Windows.Forms.TextBox)

                    x = değişkenfarex
                    y = değişkenfarey

                    referansx = refx
                    referansy = refy

                    ref_ilkaçılış = True
                    çıkarma_modu = False
                    oto_şekil = otoşek

                    parent = aile

                    şekil_parent = şekil_ailesi

                    veritabanı = veri_tabanı
                    veri_tabanı = veritabanı

                    soy_ağacı = soyağacı

                    farkx = formçerçevekalınlığı
                    farky = formbaşlıkkalınlığı
                    değişkenleri_tanımla()

                    If açma = True Then
                        aç(soyağacı)
                    End If

                    değişkenleri_kur()
                    hesapla()


                End Sub

                Sub veritabanı_oku(ByVal veri_tabanı As RichTextBox)

                End Sub

                Sub değişkenleri_tanımla()

                    duvar1 = New duvar
                    duvar2 = New duvar
                    duvar3 = New duvar
                    duvar4 = New duvar

                    d1 = New System.Windows.Forms.TextBox
                    d2 = New System.Windows.Forms.TextBox
                    d3 = New System.Windows.Forms.TextBox
                    d4 = New System.Windows.Forms.TextBox

                    ek_alan = New System.Windows.Forms.TextBox

                    odaalanı = New System.Windows.Forms.Label
                    boyanacakalan = New System.Windows.Forms.TextBox
                    duvarların_yüz_ölçümü = New System.Windows.Forms.Label

                    panel = New System.Windows.Forms.Panel

                End Sub

                Sub değişkenleri_kur()
                    ilkaçılış = True
                    If çıkarma_modu = False Then
                        If açılış = False Then
                            yüksekliği.Text = referansy.Text
                            solu.Text = referansx.Text
                            sağı.Text = referansx.Text + 300
                            tabanı.Text = referansy.Text + 300
                            d1.Text = "300"
                            d2.Text = "300"
                            d3.Text = "300"
                            d4.Text = "300"
                        End If
                    Else

                    End If
                    '
                    duvar1.kur(şekil_parent, parent, parent_zemini, referansx, referansy, x, y, "1", "1", yüksekliği, solu, sağı, soy_ağacı & "d1", veritabanı, d1, ek_alan, farkx, farky)
                    '

                    '
                    duvar2.kur(şekil_parent, parent, parent_zemini, referansx, referansy, x, y, "1", "2", tabanı, solu, sağı, soy_ağacı & "d2", veritabanı, d2, ek_alan, farkx, farky)
                    '

                    '
                    duvar3.kur(şekil_parent, parent, parent_zemini, referansx, referansy, x, y, "2", "2", sağı, yüksekliği, tabanı, soy_ağacı & "d3", veritabanı, d3, ek_alan, farkx, farky)
                    '

                    '
                    duvar4.kur(şekil_parent, parent, parent_zemini, referansx, referansy, x, y, "2", "1", solu, yüksekliği, tabanı, soy_ağacı & "d4", veritabanı, d4, ek_alan, farkx, farky)
                    '
                    ilkaçılış = False
                    '

                    '

                    With panel
                        .BackColor = Color.White
                        .Left = solu.Text + (((sağı.Text - solu.Text) / 2) - (.Width / 2))
                        .Top = yüksekliği.Text + ((tabanı.Text - yüksekliği.Text) / 2 - (.Height / 2))
                        .Parent = parent
                        .Show()
                    End With

                    '
                    With odaalanı
                        .Text = "Odanızın Alanı:"
                        .BackColor = Color.White
                        .Left = 5
                        .Top = 0
                        .Parent = panel
                        .Show()
                    End With

                    '

                    With duvarların_yüz_ölçümü
                        .Text = "boyanacak alan:"
                        .BackColor = Color.White
                        .Left = 5
                        .Top = 25
                        .Parent = panel
                        .Show()
                    End With

                    '


                    '

                    kaydet(sağı.Text, solu.Text, yüksekliği.Text, tabanı.Text, soy_ağacı)

                    ''
                End Sub

                Sub kur1(ByVal soyağacı As String, ByVal dünya As System.Windows.Forms.RichTextBox, ByVal form As Control, ByVal sekil_parent As Microsoft.VisualBasic.PowerPacks.ShapeContainer, ByVal refx As System.Windows.Forms.TextBox, ByVal refy As System.Windows.Forms.TextBox, ByVal değişkenfarex As TextBox, ByVal değişkenfarey As TextBox)

                    x = değişkenfarex
                    y = değişkenfarey

                    referansx = refx
                    referansy = refy

                    ref_ilkaçılış = True
                    çıkarma_modu = False

                    şekil_parent = sekil_parent

                    parent = form

                    soy_ağacı = soyağacı

                    çıkarma_modu = True
                    veritabanı = dünya
                    dünya = veritabanı

                    değişkenleri_tanımla()

                    aç(soyağacı)

                    değişkenleri_kur()
                    çıkarma_modu = False

                End Sub

                Sub hesapla()

                End Sub

                Sub kaydet(ByVal sağa As String, ByVal sola As String, ByVal yukarıya As String, ByVal aşağıya As String, ByVal soybaşlangıcı As String)
                    Dim sağayt, solayt, aşağıyayt, yukarıyayt, uzunlukyt, soyağacıyt, refnokxyt, refnokyyt As String
                    Dim c As Integer
                    Dim yazılacakbilgi As String

                    If sağa.Length <= 4 Then
                        c = 4 - sağa.Length
                        sağayt = sağa & Space(c)
                    End If

                    If sola.Length <= 4 Then
                        c = 4 - sola.Length
                        solayt = sola & Space(c)
                    End If

                    If yukarıya.Length <= 4 Then
                        c = 4 - yukarıya.Length
                        yukarıyayt = yukarıya & Space(c)
                    End If

                    If aşağıya.Length <= 4 Then
                        c = 4 - aşağıya.Length
                        aşağıyayt = aşağıya & Space(c)
                    End If


                    If soybaşlangıcı.Length <= 10 Then
                        c = 10 - soybaşlangıcı.Length
                        soyağacıyt = soybaşlangıcı & Space(c)
                        '
                    End If

                    refnokxyt = "    "

                    refnokyyt = "    "

                    Dim i As Integer

                    i = veritabanı.Find(soybaşlangıcı)
                    If i = -1 Then
                        veritabanı.Text &= vbCrLf & soyağacıyt & " " & refnokxyt & " " & refnokyyt & " " & sağayt & " " & solayt & " " & yukarıyayt & " " & aşağıyayt
                    End If
                    If Not i = -1 Then
                        veritabanı.Select(i, 39)
                        yazılacakbilgi = soyağacıyt & " " & refnokxyt & " " & refnokyyt & " " & sağayt & " " & solayt & " " & yukarıyayt & " " & aşağıyayt
                        veritabanı.SelectedText = yazılacakbilgi
                    End If
                End Sub

                Sub aç(ByVal soyağacı As String)

                    Dim i As Integer
                    i = veritabanı.Find(soyağacı)
                    If i = -1 Then
                        MsgBox("Dosya bozulmuş yada türü desteklenmiyor", MsgBoxStyle.Critical, "HATA")
                    End If
                    If Not i = -1 Then

                        ' referans noktasının x ve y'lerini buluyoruz
                        Try
                            veritabanı.Select(i + 11, 3)

                        Catch
                            MsgBox("Dosya bozulmuş yada türü desteklenmiyor", MsgBoxStyle.Critical, "HATA")
                        End Try

                        Try
                            veritabanı.Select(i + 16, 3)

                        Catch
                            MsgBox("Dosya bozulmuş yada türü desteklenmiyor", MsgBoxStyle.Critical, "HATA")
                        End Try

                        ' sağı,solu,üstünü,tabanını buluyoruz
                        ' hata bulmayı kolaylaştırmak için integer türünde değişken tanımlıyoruz
                        Dim sayı As Integer
                        Try
                            veritabanı.Select(i + 21, 3)
                            sayı = veritabanı.SelectedText
                            sağı.Text = sayı
                        Catch
                            MsgBox("Dosya bozulmuş yada türü desteklenmiyor", MsgBoxStyle.Critical, "HATA")
                        End Try


                        Try
                            veritabanı.Select(i + 26, 3)
                            sayı = veritabanı.SelectedText
                            solu.Text = sayı
                        Catch
                            MsgBox("Dosya bozulmuş yada türü desteklenmiyor", MsgBoxStyle.Critical, "HATA")
                        End Try


                        Try
                            veritabanı.Select(i + 31, 3)
                            sayı = veritabanı.SelectedText
                            yüksekliği.Text = sayı
                        Catch
                            MsgBox("Dosya bozulmuş yada türü desteklenmiyor", MsgBoxStyle.Critical, "HATA")
                        End Try


                        Try
                            veritabanı.Select(i + 36, 3)
                            sayı = veritabanı.SelectedText
                            tabanı.Text = sayı
                        Catch
                            MsgBox("Dosya bozulmuş yada türü desteklenmiyor", MsgBoxStyle.Critical, "HATA1")
                        End Try


                    End If
                End Sub

                Sub duvarları_aç()

                End Sub

                ' ---------- Olaylar --------- '

                Private Sub veritabanı_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles veritabanı.TextChanged
                    ' çarpışma olayları
                    panel.Refresh()
                End Sub

                Private Sub yüksekliği_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles yüksekliği.TextChanged
                    ' nesne yeniden biçimlendirilecek (filtrelere göre)
                    If ilkaçılış = False Then
                        If çıkarma_modu = False Then
                            duvar1.yenileme(yüksekliği, solu, sağı)
                            duvar2.yenileme(tabanı, solu, sağı)
                            duvar3.yenileme(sağı, yüksekliği, tabanı)
                            duvar4.yenileme(solu, yüksekliği, tabanı)
                            panel.Top = yüksekliği.Text + ((tabanı.Text - yüksekliği.Text) / 2 - (panel.Height / 2))
                            panel.Refresh()
                            kaydet(sağı.Text, solu.Text, yüksekliği.Text, tabanı.Text, soy_ağacı)

                        End If
                    End If

                End Sub

                Private Sub tabanı_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabanı.TextChanged
                    If ilkaçılış = False Then
                        If çıkarma_modu = False Then
                            duvar2.yenileme(tabanı, solu, sağı)
                            duvar3.yenileme(sağı, yüksekliği, tabanı)
                            duvar4.yenileme(solu, yüksekliği, tabanı)
                            panel.Top = yüksekliği.Text + ((tabanı.Text - yüksekliği.Text) / 2 - (panel.Height / 2))
                            panel.Refresh()
                            kaydet(sağı.Text, solu.Text, yüksekliği.Text, tabanı.Text, soy_ağacı)
                        End If
                    End If

                End Sub

                Private Sub sağı_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles sağı.TextChanged
                    If ilkaçılış = False Then
                        If çıkarma_modu = False Then
                            duvar1.yenileme(yüksekliği, solu, sağı)
                            duvar2.yenileme(tabanı, solu, sağı)
                            duvar4.yenileme(solu, yüksekliği, tabanı)
                            panel.Left = solu.Text + (((sağı.Text - solu.Text) / 2) - (panel.Width / 2))
                            panel.Refresh()
                            kaydet(sağı.Text, solu.Text, yüksekliği.Text, tabanı.Text, soy_ağacı)
                        End If
                    End If

                End Sub

                Private Sub solu_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles solu.TextChanged
                    If ilkaçılış = False Then
                        If çıkarma_modu = False Then
                            duvar1.yenileme(yüksekliği, solu, sağı)
                            duvar2.yenileme(tabanı, solu, sağı)
                            duvar4.yenileme(solu, yüksekliği, tabanı)
                            panel.Left = solu.Text + (((sağı.Text - solu.Text) / 2) - (panel.Width / 2))
                            panel.Refresh()
                            kaydet(sağı.Text, solu.Text, yüksekliği.Text, tabanı.Text, soy_ağacı)
                        End If
                    End If

                End Sub

                Private Sub d1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles d1.TextChanged

                End Sub

                Dim ifk As Integer

                Private Sub denemetext_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles denemetext.TextChanged
                    If ifk = 1 Then
                        odaalanı.BackColor = Color.Black
                    End If

                    If ifk = 3 Then
                        odaalanı.BackColor = Color.Red
                        ifk = 0
                    End If
                    ifk += 1
                End Sub
            End Class

            Public Class duvar
                ' boyutlandırıla bilir
                ' görselleştirilmiş yapı
                ' menülü

                ' ---------- fiziksel değişkenler ---------- '
                WithEvents duvar As Microsoft.VisualBasic.PowerPacks.LineShape

                WithEvents yönegöre_genişlik As System.Windows.Forms.TextBox
                WithEvents x1x As System.Windows.Forms.TextBox
                WithEvents x2x As System.Windows.Forms.TextBox
                WithEvents boyut As System.Windows.Forms.TextBox

                WithEvents ölçücigisi_uzaklık1 As System.Windows.Forms.TextBox
                WithEvents oluşan_alan As System.Windows.Forms.TextBox

                WithEvents x As System.Windows.Forms.TextBox
                WithEvents y As System.Windows.Forms.TextBox

                WithEvents referansx As System.Windows.Forms.TextBox
                WithEvents referansy As System.Windows.Forms.TextBox

                WithEvents harita As Control
                WithEvents harita_zemini As Control
                WithEvents parent As Microsoft.VisualBasic.PowerPacks.ShapeContainer

                WithEvents menü_tickleyici As System.Windows.Forms.Timer
                WithEvents konum_eşitleyici As System.Windows.Forms.Timer

                WithEvents menü As System.Windows.Forms.PictureBox
                WithEvents ekleme_butonu As System.Windows.Forms.Button


                Dim soy_ağacı As String
                WithEvents dünya As System.Windows.Forms.RichTextBox
                Dim formbaşlık As Double
                Dim formçerçeve As Double

                ' ------- APİLER ------ '

                Structure POINTAPI
                    Dim X As Integer
                    Dim Y As Integer
                End Structure
                Private Declare Function GetCursorPos Lib "user32.dll" (ByRef lpPoint As POINTAPI) As Long
                Public fareyeri As POINTAPI

                ' ---------- sanal değişkenler ---------- '
                Dim ölçüçizgisi As boyutlandırıcı
                WithEvents şekil_ailesi As Microsoft.VisualBasic.PowerPacks.ShapeContainer
                Dim şekil_yönü As String
                Dim şekil_ikincil_yönü As String
                Dim menü_aç_kapa As Boolean
                Dim ref As Point
                Dim eski_ref As Point
                Dim kapısayısı As Integer


                Sub kur(ByVal parent1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer, ByVal zemin As Control, ByVal zemin_parent As Control, ByVal refx As System.Windows.Forms.TextBox, ByVal refy As Windows.Forms.TextBox, ByVal değişkenx As System.Windows.Forms.TextBox, ByVal değişkeny As System.Windows.Forms.TextBox, ByVal yön1 As String, ByVal yön2 As String, ByVal yönegöre_uzaklık As System.Windows.Forms.TextBox, ByVal x1 As System.Windows.Forms.TextBox, ByVal x2 As System.Windows.Forms.TextBox, ByVal soyağacı As String, ByVal veri_tabanı As RichTextBox, ByVal uzunluk As System.Windows.Forms.TextBox, ByVal ek_alan As System.Windows.Forms.TextBox, ByVal farkx As Double, ByVal farky As Double)

                    x = değişkenx
                    y = değişkeny

                    referansx = refx
                    referansy = refy

                    eski_ref.X = refx.Text
                    eski_ref.Y = refy.Text

                    şekil_yönü = yön1
                    şekil_ikincil_yönü = yön2

                    harita = zemin
                    harita_zemini = zemin_parent

                    yönegöre_genişlik = yönegöre_uzaklık
                    yönegöre_uzaklık = yönegöre_genişlik

                    x1x = x1
                    x1 = x1x

                    x2x = x2
                    x2 = x2x

                    menüyü_kur()

                    duvar = New Microsoft.VisualBasic.PowerPacks.LineShape



                    duvarı_yapılandır()

                    dünya = veri_tabanı
                    veri_tabanı = dünya


                    formbaşlık = farky
                    formçerçeve = farkx



                    soy_ağacı = soyağacı


                    şekil_ailesi = parent1

                    boyut.Text = uzunluk.Text
                    uzunluk.Text = boyut.Text

                    oluşan_alan = ek_alan
                    ek_alan = oluşan_alan

                    yerleştir()
                End Sub

                Sub kur1()

                End Sub

                Sub aç(ByVal yönü As String, ByVal ikinci_yönü As String)

                End Sub

                Sub menüyü_kur()
                    menü_tickleyici = New System.Windows.Forms.Timer
                    menü = New System.Windows.Forms.PictureBox
                    ekleme_butonu = New System.Windows.Forms.Button
                    If şekil_yönü = "1" Then
                        If şekil_ikincil_yönü = "1" Then
                            With menü
                                .Height = 100
                                .Width = 100
                                .Location = New Point(((x1x.Text + 1 - 1 + x2x.Text) / 2) - menü.Width / 2, yönegöre_genişlik.Text + 20)
                                .BackColor = Color.Black
                                .Height = 0
                                .Parent = harita
                                .Visible = False
                                .Show()
                            End With
                        End If
                        If şekil_ikincil_yönü = "2" Then
                            With menü
                                .Height = 0
                                .Width = 100
                                .Location = New Point(((x1x.Text + 1 - 1 + x2x.Text) / 2) - menü.Width / 2, yönegöre_genişlik.Text - 120)
                                .BackColor = Color.Black
                                .Height = 0
                                .Parent = harita
                                .Visible = False
                                .Show()
                            End With
                        End If
                    End If
                    If şekil_yönü = "2" Then
                        If şekil_ikincil_yönü = "1" Then
                            With menü
                                .Height = 0
                                .Width = 100
                                .Location = New Point(yönegöre_genişlik.Text + 20, ((x1x.Text + 1 - 1 + x2x.Text) / 2) - 50)
                                .BackColor = Color.Black
                                .Height = 0
                                .Parent = harita
                                .Visible = False
                                .Show()
                            End With
                        End If
                        If şekil_ikincil_yönü = "2" Then
                            With menü
                                .Height = 0
                                .Width = 100
                                .Location = New Point(yönegöre_genişlik.Text - .Height - 20, ((x1x.Text + 1 - 1 + x2x.Text) / 2) - 50)
                                .BackColor = Color.Black
                                .Height = 0
                                .Parent = harita
                                .Visible = False
                                .Show()
                            End With
                        End If
                    End If
                    With ekleme_butonu
                        .Height = 23
                        .Width = 75
                        .FlatStyle = FlatStyle.Flat
                        .ForeColor = Color.White
                        .Text = "Ekle -->"
                        .Location = New Point(4, 4)
                        .Parent = menü
                        .Visible = True
                        .Show()
                    End With
                End Sub

                Sub menüyü_yenile()
                    With menü
                        .Height = 100
                        .Width = 100
                        .Location = New Point(((x1x.Text + 1 - 1 + x2x.Text) / 2) - menü.Width / 2, yönegöre_genişlik.Text + 20)
                        .BackColor = Color.Black
                        .Parent = harita
                        .Visible = True
                        .Show()
                    End With
                End Sub

                Sub yenileme(ByVal yönegöre_uzaklık As System.Windows.Forms.TextBox, ByVal x1 As System.Windows.Forms.TextBox, ByVal x2 As System.Windows.Forms.TextBox)
                    If şekil_yönü = "1" Then
                        With duvar
                            .Y1 = yönegöre_genişlik.Text
                            .Y2 = yönegöre_genişlik.Text
                            .X1 = x1x.Text
                            .X2 = x2x.Text
                        End With
                    End If
                    If şekil_yönü = "2" Then
                        With duvar
                            .X1 = yönegöre_genişlik.Text
                            .X2 = yönegöre_genişlik.Text
                            .Y1 = x1x.Text
                            .Y2 = x2x.Text
                        End With
                    End If
                End Sub

                Sub class_içi_oto_yerleştirme()
                    Dim ref_fark As Point
                    ref.X = referansx.Text
                    ref.Y = referansy.Text

                    ref_fark.X = ref.X - eski_ref.X
                    ref_fark.Y = ref.Y - eski_ref.Y

                    If şekil_yönü = "1" Then
                        yönegöre_genişlik.Text += ref_fark.Y
                        With duvar
                            .Y1 = yönegöre_genişlik.Text
                            .Y2 = yönegöre_genişlik.Text
                            .X1 = x1x.Text
                            .X2 = x2x.Text
                        End With
                    End If
                    If şekil_yönü = "2" Then
                        yönegöre_genişlik.Text += ref_fark.X
                        With duvar
                            .X1 = yönegöre_genişlik.Text
                            .X2 = yönegöre_genişlik.Text
                            .Y1 = x1x.Text
                            .Y2 = x2x.Text
                        End With
                    End If
                    eski_ref = ref
                End Sub

                Sub duvarı_yapılandır()
                    şekil_ailesi = New Microsoft.VisualBasic.PowerPacks.ShapeContainer
                    duvar = New Microsoft.VisualBasic.PowerPacks.LineShape
                    dünya = New System.Windows.Forms.RichTextBox
                    boyut = New System.Windows.Forms.TextBox
                    konum_eşitleyici = New System.Windows.Forms.Timer
                    ölçüçizgisi = New boyutlandırıcı
                    ölçücigisi_uzaklık1 = New System.Windows.Forms.TextBox
                End Sub

                Sub yerleştir()
                    If şekil_yönü = "1" Then
                        With duvar
                            .Y1 = yönegöre_genişlik.Text
                            .Y2 = yönegöre_genişlik.Text
                            .X1 = x1x.Text
                            .X2 = x2x.Text
                            .BorderWidth = 4
                            .Parent = şekil_ailesi
                            .Cursor = Cursors.Hand
                            .Visible = True
                            .Show()
                        End With
                        ölçüçizgisi = New boyutlandırıcı
                        ölçüçizgisi.kur(x1x, x2x, yönegöre_genişlik, Color.Blue, şekil_yönü, şekil_ikincil_yönü, boyut, şekil_ailesi, harita)
                    End If
                    If şekil_yönü = "2" Then
                        With duvar
                            .X1 = yönegöre_genişlik.Text
                            .X2 = yönegöre_genişlik.Text
                            .Y1 = x1x.Text
                            .Y2 = x2x.Text
                            .BorderWidth = 4
                            .Parent = şekil_ailesi
                            .Cursor = Cursors.Hand
                            .Visible = True
                            .Show()
                        End With
                        ölçüçizgisi = New boyutlandırıcı
                        ölçüçizgisi.kur(x1x, x2x, yönegöre_genişlik, Color.Blue, şekil_yönü, şekil_ikincil_yönü, boyut, şekil_ailesi, harita)
                    End If

                End Sub

                Sub kaydet1(ByVal yön As String, ByVal yönegöre_uzaklık As System.Windows.Forms.TextBox, ByVal x1 As System.Windows.Forms.TextBox, ByVal x2 As System.Windows.Forms.TextBox, ByVal soyağacı As String, ByVal uzunluk As System.Windows.Forms.TextBox)
                    Dim yönyt, yönegöre_uzaklıkyt, x1yt, x2yt, uzunlukyt, soyağacıyt As String
                    Dim c As Integer

                    If yön.Length <= 3 Then
                        c = 3 - yön.Length
                        yönyt = yön & Space(c)
                    End If


                    If yönegöre_uzaklık.TextLength <= 3 Then
                        c = 3 - yönegöre_uzaklık.TextLength
                        yönegöre_uzaklıkyt = yönegöre_uzaklık.Text & Space(c)
                    End If


                    If x1.TextLength <= 3 Then
                        c = 3 - x1.TextLength
                        x1yt = x1.Text & Space(c)
                    End If

                    If x2.TextLength <= 3 Then
                        c = 3 - x2.TextLength
                        x2yt = x2.Text & Space(c)
                    End If


                    If uzunluk.TextLength <= 3 Then
                        c = 3 - uzunluk.TextLength
                        uzunlukyt = uzunluk.Text & Space(c)
                    End If


                    If soyağacı.Length <= 18 Then
                        c = 18 - soyağacı.Length
                        soyağacıyt = soyağacı & Space(c)
                    End If


                    Dim i As Integer
                    i = dünya.Find(soyağacı)
                    If i = -1 Then
                        dünya.Text &= vbCrLf & soyağacıyt & " " & yönyt & " " & yönegöre_uzaklıkyt & " " & x1yt & " " & x2yt & " " & uzunlukyt
                    End If
                    If Not i = -1 Then

                    End If
                End Sub

                Sub olayara()

                End Sub

                ' ---------- Olaylar ---------- '
                ' olay değişkenleri

                Dim fark As Point
                Dim hareketdoğrulama As Boolean
                Dim lostfocus_canlandırma As Boolean
                Dim şekilmousex, şekilmousey As String
                Dim mousemenüdoğrulama As Boolean

                Private Sub x1x_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles x1x.TextChanged
                    ' duvar genişletilecek veya daraltılacak
                End Sub

                Private Sub duvar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles duvar.Click
                    ' menü açılacak
                    If şekil_yönü = "1" Then
                        If şekil_ikincil_yönü = "1" Then
                            With menü
                                .Location = New Point(((x1x.Text + 1 - 1 + x2x.Text) / 2) - menü.Width / 2, yönegöre_genişlik.Text + 20)
                            End With
                        End If
                        If şekil_ikincil_yönü = "2" Then
                            With menü
                                .Location = New Point(((x1x.Text + 1 - 1 + x2x.Text) / 2) - menü.Width / 2, yönegöre_genişlik.Text - 120)
                            End With
                        End If
                    End If
                    If şekil_yönü = "2" Then
                        If şekil_ikincil_yönü = "1" Then
                            With menü
                                .Location = New Point(yönegöre_genişlik.Text + 20, ((x1x.Text + 1 - 1 + x2x.Text) / 2) - 50)
                            End With
                        End If
                        If şekil_ikincil_yönü = "2" Then
                            With menü
                                .Location = New Point(yönegöre_genişlik.Text - .Width - 20, ((x1x.Text + 1 - 1 + x2x.Text) / 2) - 50)
                            End With
                        End If
                    End If
                    menü_aç_kapa = True
                    menü_tickleyici.Interval = 1
                    menü_tickleyici.Enabled = True
                End Sub

                Private Sub duvar_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles duvar.MouseDown
                    hareketdoğrulama = True
                    fark.X = e.X
                    fark.Y = e.Y
                End Sub

                Private Sub duvar_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles duvar.MouseUp
                    hareketdoğrulama = False
                    konum_eşitleyici.Enabled = False
                End Sub

                Private Sub duvar_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles duvar.MouseMove
                    If hareketdoğrulama = True Then
                        konum_eşitleyici.Interval = 1
                        konum_eşitleyici.Enabled = True
                    End If
                    If hareketdoğrulama = False Then
                        konum_eşitleyici.Interval = 1
                        konum_eşitleyici.Enabled = False
                    End If
                End Sub

                Private Sub konum_eşitleyici_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles konum_eşitleyici.Tick
                    GetCursorPos(fareyeri)
                    If şekil_yönü = "1" Then
                        yönegöre_genişlik.Text = y.text
                        duvar.Y1 = yönegöre_genişlik.Text
                        duvar.Y2 = yönegöre_genişlik.Text
                    End If
                    If şekil_yönü = "2" Then
                        yönegöre_genişlik.Text = x.Text
                        duvar.X1 = yönegöre_genişlik.Text
                        duvar.X2 = yönegöre_genişlik.Text
                    End If

                End Sub

                Private Sub şekil_ailesi_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles şekil_ailesi.MouseMove

                End Sub

                Private Sub harita_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles harita.MouseMove
                    If hareketdoğrulama = True Then
                        konum_eşitleyici.Interval = 1
                        konum_eşitleyici.Enabled = True
                    End If
                    Form1.TextBox5.Text = e.Y
                End Sub

                Private Sub menü_tickleyici_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles menü_tickleyici.Tick
                    If menü_aç_kapa = True Then
                        If Not menü.Height = 100 Then
                            menü.Height += 1
                        End If
                        If menü.Height = 100 Then
                            menü_tickleyici.Enabled = False
                        End If
                    End If
                    If menü_aç_kapa = False Then
                        If Not menü.Height = 0 Then
                            menü.Height -= 1
                        End If
                        If menü.Height = 0 Then
                            menü_tickleyici.Enabled = False
                        End If
                    End If
                End Sub

                Private Sub menü_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles menü.Leave
                    menü_tickleyici.Interval = 1
                    menü_aç_kapa = False
                    menü_tickleyici.Enabled = True
                End Sub

                Private Sub ekleme_butonu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ekleme_butonu.Click
                    kapısayısı += 1
                    Dim kapıcı As kapı
                    kapıcı = New kapı
                    kapıcı.kur(şekil_ailesi, harita, yönegöre_genişlik, "yükseklik", False, False, x, y, soy_ağacı & "k" & kapısayısı, dünya, referansx, referansy)
                End Sub

                Private Sub ekleme_butonu_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ekleme_butonu.MouseMove

                End Sub

                Private Sub duvar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles duvar.LostFocus
                    If mousemenüdoğrulama = False Then
                        menü_aç_kapa = False
                        menü_tickleyici.Interval = 1
                        menü_tickleyici.Enabled = True
                    Else
                        lostfocus_canlandırma = True
                    End If
                End Sub

                Private Sub menü_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles menü.MouseLeave
                    If lostfocus_canlandırma = True Then
                        menü_aç_kapa = False
                        menü_tickleyici.Interval = 1
                        menü_tickleyici.Enabled = False
                        lostfocus_canlandırma = False
                    End If
                    mousemenüdoğrulama = False
                End Sub

                Private Sub menü_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles menü.MouseMove
                    mousemenüdoğrulama = True
                End Sub

                Private Sub referansx_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles referansx.TextChanged
                    class_içi_oto_yerleştirme()
                End Sub

                Private Sub referansy_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles referansy.TextChanged
                    class_içi_oto_yerleştirme()
                End Sub

                Private Sub yönegöre_genişlik_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles yönegöre_genişlik.TextChanged

                End Sub

                Private Sub dünya_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dünya.TextChanged
                    ölçüçizgisi.boyuttexti.Refresh()
                End Sub
            End Class

            Public Class kapı
                ' görselleştirilmiş yapı
                ' _

                ' ---------- fiziksel değişkenler ---------- '

                WithEvents kapı As Microsoft.VisualBasic.PowerPacks.LineShape

                WithEvents x1 As System.Windows.Forms.TextBox
                WithEvents x2 As System.Windows.Forms.TextBox

                WithEvents bağlayan As System.Windows.Forms.TextBox
                WithEvents bağlanan As System.Windows.Forms.TextBox

                WithEvents şekil_par As Microsoft.VisualBasic.PowerPacks.ShapeContainer

                WithEvents aile As Control

                WithEvents x As System.Windows.Forms.TextBox
                WithEvents y As System.Windows.Forms.TextBox

                WithEvents referansx As System.Windows.Forms.TextBox
                WithEvents referansy As System.Windows.Forms.TextBox

                WithEvents veritabanı As System.Windows.Forms.RichTextBox

                Dim soyadı As String

                Dim otomatikşekil As Boolean

                Dim eşitleme As eşitleyici
                Dim yenioda As oda
                Dim yönü As String
                Dim açmak As Boolean



                Sub kur(ByVal şekil_parent As Microsoft.VisualBasic.PowerPacks.ShapeContainer, ByVal parent As Control, ByVal konumtexti As System.Windows.Forms.TextBox, ByVal yön As String, ByVal açma As Boolean, ByVal otoşek As Boolean, ByVal değişkenfarex As System.Windows.Forms.TextBox, ByVal değişkenfarey As System.Windows.Forms.TextBox, ByVal soyağacı As String, ByVal veri_tabanı As Object, ByVal refx As System.Windows.Forms.TextBox, ByVal refy As Windows.Forms.TextBox)

                    veritabanı = veri_tabanı

                    otomatikşekil = otoşek

                    soyadı = soyağacı

                    referansx = refx
                    referansy = refy

                    yönü = yön

                    açmak = açma

                    şekil_par = şekil_parent

                    aile = parent

                    x = değişkenfarex
                    y = değişkenfarey



                    bağlayan = konumtexti

                    değişkenleri_tanımla()

                    eşitleme.kur1(bağlayan, bağlanan)

                    konumtexti = bağlanan

                    değişkenleri_kur()

                End Sub

                Sub değişkenleri_tanımla()

                    yenioda = New oda

                    kapı = New Microsoft.VisualBasic.PowerPacks.LineShape

                    bağlanan = New System.Windows.Forms.TextBox

                    x1 = New System.Windows.Forms.TextBox
                    x2 = New System.Windows.Forms.TextBox
                    eşitleme = New eşitleyici

                End Sub

                Sub değişkenleri_kur()
                    '  
                    If yönü = "yükseklik" Then
                        yenioda.yanoda_kurulum(bağlanan, "tabanı", açmak, otomatikşekil, aile, x, y, şekil_par, soyadı, veritabanı, Form1.farkx, Form1.farky, referansx, referansy)
                    End If


                End Sub

            End Class

            Public Class yan_odacık
                ' bir oda class'ının içerdiği tüm özellikleri içerir
                ' sadece oda class'ına bağlıdır ve 3 duvarlıdır

                ' ---------- fiziksel değişkenler ---------- '

            End Class

            Public Class boyutlandırıcı
                ' farklı renklerde hoş görünüm
                ' ölçüt yazma yerli

                ' ---------- FİZİKSEL DEĞİŞKENLER ----------- '
                WithEvents ölçütçizgisi As Microsoft.VisualBasic.PowerPacks.LineShape
                WithEvents başlangıççizgisi As Microsoft.VisualBasic.PowerPacks.LineShape
                WithEvents bitişçizgisi As Microsoft.VisualBasic.PowerPacks.LineShape

                Public WithEvents boyuttexti As System.Windows.Forms.Label
                WithEvents yeniboyuttexti As System.Windows.Forms.TextBox

                WithEvents duvardanuzaklık As System.Windows.Forms.TextBox
                WithEvents başlamanoktası As System.Windows.Forms.TextBox
                WithEvents bitmenoktası As System.Windows.Forms.TextBox

                Dim yeni_değer As programkütüphanesi.nesnekütüphanesi.hazır_form_kütüphanesi.yeni_değer
                Dim renk As Color
                Dim şekil_yönü As String
                Dim şekil_ikincil_yönü As String
                Dim şekilyüzeyi As Microsoft.VisualBasic.PowerPacks.ShapeContainer
                Dim nesneyüzeyi As Control
                ' --------- SANL DEĞİŞKENELR ----------- '
                Dim boyutlandırmaposthatası As Short

                Sub kur(ByVal başlangıçnok As System.Windows.Forms.TextBox, ByVal bitişnoktası As System.Windows.Forms.TextBox, ByVal duvardan_uzaklık As System.Windows.Forms.TextBox, ByVal rengi As Color, ByVal yön1 As String, ByVal yön2 As String, ByVal boyut As System.Windows.Forms.TextBox, ByVal şekilparent As Microsoft.VisualBasic.PowerPacks.ShapeContainer, ByVal parent As Control)

                    boyutlandırmaposthatası = 0

                    tanımla()

                    duvardanuzaklık = duvardan_uzaklık
                    başlamanoktası = başlangıçnok
                    bitmenoktası = bitişnoktası


                    yeniboyuttexti = boyut
                    boyuttexti.Text = yeniboyuttexti.Text
                    boyut = yeniboyuttexti

                    şekil_yönü = yön1
                    şekil_ikincil_yönü = yön2

                    renk = rengi

                    şekilyüzeyi = şekilparent
                    nesneyüzeyi = parent

                    yerleştir()
                End Sub

                Sub tanımla()
                    ölçütçizgisi = New Microsoft.VisualBasic.PowerPacks.LineShape
                    başlangıççizgisi = New Microsoft.VisualBasic.PowerPacks.LineShape
                    bitişçizgisi = New Microsoft.VisualBasic.PowerPacks.LineShape
                    boyuttexti = New System.Windows.Forms.Label
                    yeni_değer = New programkütüphanesi.nesnekütüphanesi.hazır_form_kütüphanesi.yeni_değer
                End Sub

                Sub yenile()
                    If şekil_yönü = "1" Then
                        If şekil_ikincil_yönü = "1" Then
                            With başlangıççizgisi
                                .X1 = başlamanoktası.Text + 15
                                .X2 = başlamanoktası.Text + 15
                                .Y1 = (duvardanuzaklık.Text + 10) - 3
                                .Y2 = (duvardanuzaklık.Text + 10) + 3
                            End With

                            With bitişçizgisi
                                .X1 = bitmenoktası.Text - 15
                                .X2 = bitmenoktası.Text - 15
                                .Y1 = (duvardanuzaklık.Text + 10) - 3
                                .Y2 = (duvardanuzaklık.Text + 10) + 3
                            End With

                            With ölçütçizgisi
                                .X1 = bitmenoktası.Text - 15
                                .X2 = başlamanoktası.Text + 15
                                .Y1 = duvardanuzaklık.Text + 10
                                .Y2 = duvardanuzaklık.Text + 10
                            End With

                            With boyuttexti
                                .Width = 50
                                .Height = 12
                                .Top = duvardanuzaklık.Text + 20
                                .Left = başlamanoktası.Text + ((bitmenoktası.Text - başlamanoktası.Text) / 2) - (.Width / 2)
                                .Refresh()
                            End With
                        End If
                        If şekil_ikincil_yönü = "2" Then
                            With başlangıççizgisi
                                .X1 = başlamanoktası.Text + 15
                                .X2 = başlamanoktası.Text + 15
                                .Y1 = (duvardanuzaklık.Text - 10) - 3
                                .Y2 = (duvardanuzaklık.Text - 10) + 3
                            End With

                            With bitişçizgisi
                                .X1 = bitmenoktası.Text - 15
                                .X2 = bitmenoktası.Text - 15
                                .Y1 = (duvardanuzaklık.Text - 10) - 3
                                .Y2 = (duvardanuzaklık.Text - 10) + 3
                            End With

                            With ölçütçizgisi
                                .X1 = bitmenoktası.Text - 15
                                .X2 = başlamanoktası.Text + 15
                                .Y1 = duvardanuzaklık.Text - 10
                                .Y2 = duvardanuzaklık.Text - 10
                            End With

                            With boyuttexti
                                .Width = 50
                                .Height = 12
                                .Top = duvardanuzaklık.Text - 25
                                .Left = başlamanoktası.Text + ((bitmenoktası.Text - başlamanoktası.Text) / 2) - (.Width / 2)
                                .Refresh()
                            End With
                        End If


                    End If
                    If şekil_yönü = "2" Then
                        If şekil_ikincil_yönü = "1" Then
                            With başlangıççizgisi
                                .Y1 = başlamanoktası.Text + 15
                                .Y2 = başlamanoktası.Text + 15
                                .X1 = (duvardanuzaklık.Text + 10) - 3
                                .X2 = (duvardanuzaklık.Text + 10) + 3
                            End With

                            With bitişçizgisi
                                .Y1 = bitmenoktası.Text - 15
                                .Y2 = bitmenoktası.Text - 15
                                .X1 = (duvardanuzaklık.Text + 10) - 3
                                .X2 = (duvardanuzaklık.Text + 10) + 3
                            End With

                            With ölçütçizgisi
                                .Y1 = bitmenoktası.Text - 15
                                .Y2 = başlamanoktası.Text + 15
                                .X1 = (duvardanuzaklık.Text + 10)
                                .X2 = (duvardanuzaklık.Text + 10)
                            End With

                            With boyuttexti
                                .Width = 50
                                .Height = 12
                                .Top = başlamanoktası.Text + ((bitmenoktası.Text - başlamanoktası.Text) / 2) - (.Height / 2)
                                .Left = duvardanuzaklık.Text + 15
                                .Refresh()
                            End With
                        End If
                        If şekil_ikincil_yönü = "2" Then
                            With başlangıççizgisi
                                .Y1 = başlamanoktası.Text + 15
                                .Y2 = başlamanoktası.Text + 15
                                .X1 = (duvardanuzaklık.Text - 10) - 3
                                .X2 = (duvardanuzaklık.Text - 10) + 3
                            End With

                            With bitişçizgisi
                                .Y1 = bitmenoktası.Text - 15
                                .Y2 = bitmenoktası.Text - 15
                                .X1 = (duvardanuzaklık.Text - 10) - 3
                                .X2 = (duvardanuzaklık.Text - 10) + 3
                            End With

                            With ölçütçizgisi
                                .Y1 = bitmenoktası.Text - 15
                                .Y2 = başlamanoktası.Text + 15
                                .X1 = (duvardanuzaklık.Text - 10)
                                .X2 = (duvardanuzaklık.Text - 10)
                            End With
                            With boyuttexti
                                .Width = 50
                                .Height = 12
                                .Top = başlamanoktası.Text + ((bitmenoktası.Text - başlamanoktası.Text) / 2) - (.Height / 2)
                                .Left = duvardanuzaklık.Text - 55
                                .Refresh()
                            End With
                        End If
                    End If
                End Sub

                Sub yerleştir()
                    boyutlandırmaposthatası = 0
                    If şekil_yönü = "1" Then
                        If şekil_ikincil_yönü = "1" Then
                            With başlangıççizgisi
                                .X1 = başlamanoktası.Text + 15
                                .X2 = başlamanoktası.Text + 15
                                .Y1 = (duvardanuzaklık.Text + 10) - 3
                                .Y2 = (duvardanuzaklık.Text + 10) + 3
                                .Visible = True
                                .BorderColor = renk
                                .BorderWidth = 1
                                .Parent = şekilyüzeyi
                                .Show()
                            End With

                            With bitişçizgisi
                                .X1 = bitmenoktası.Text - 15
                                .X2 = bitmenoktası.Text - 15
                                .Y1 = (duvardanuzaklık.Text + 10) - 3
                                .Y2 = (duvardanuzaklık.Text + 10) + 3
                                .Visible = True
                                .BorderColor = renk
                                .BorderWidth = 1
                                .Parent = şekilyüzeyi
                                .Show()
                            End With

                            With ölçütçizgisi
                                .X1 = bitmenoktası.Text - 15
                                .X2 = başlamanoktası.Text + 15
                                .Y1 = duvardanuzaklık.Text + 10
                                .Y2 = duvardanuzaklık.Text + 10
                                .Visible = True
                                .BorderColor = renk
                                .BorderWidth = 1
                                .Parent = şekilyüzeyi
                                .Show()
                            End With

                            With boyuttexti
                                .Width = 50
                                .Height = 12
                                .Top = duvardanuzaklık.Text + 20
                                .Left = başlamanoktası.Text + ((bitmenoktası.Text - başlamanoktası.Text) / 2) - (.Width / 2)
                                .BackColor = Color.White
                                .Text &= " cm"
                                .ForeColor = renk
                                .Parent = nesneyüzeyi
                                .Visible = True
                                .Show()
                            End With
                        End If
                        If şekil_ikincil_yönü = "2" Then
                            With başlangıççizgisi
                                .X1 = başlamanoktası.Text + 15
                                .X2 = başlamanoktası.Text + 15
                                .Y1 = (duvardanuzaklık.Text - 10) - 3
                                .Y2 = (duvardanuzaklık.Text - 10) + 3
                                .Visible = True
                                .BorderColor = renk
                                .BorderWidth = 1
                                .Parent = şekilyüzeyi
                                .Show()
                            End With

                            With bitişçizgisi
                                .X1 = bitmenoktası.Text - 15
                                .X2 = bitmenoktası.Text - 15
                                .Y1 = (duvardanuzaklık.Text - 10) - 3
                                .Y2 = (duvardanuzaklık.Text - 10) + 3
                                .Visible = True
                                .BorderColor = renk
                                .BorderWidth = 1
                                .Parent = şekilyüzeyi
                                .Show()
                            End With

                            With ölçütçizgisi
                                .X1 = bitmenoktası.Text - 15
                                .X2 = başlamanoktası.Text + 15
                                .Y1 = duvardanuzaklık.Text - 10
                                .Y2 = duvardanuzaklık.Text - 10
                                .Visible = True
                                .BorderColor = renk
                                .BorderWidth = 1
                                .Parent = şekilyüzeyi
                                .Show()
                            End With

                            With boyuttexti
                                .Width = 50
                                .Height = 12
                                .Top = duvardanuzaklık.Text - 25
                                .Left = başlamanoktası.Text + ((bitmenoktası.Text - başlamanoktası.Text) / 2) - (.Width / 2)
                                .BackColor = Color.White
                                .Text &= " cm"
                                .ForeColor = renk
                                .Parent = nesneyüzeyi
                                .Visible = True
                                .Show()
                            End With
                        End If


                    End If
                    If şekil_yönü = "2" Then
                        If şekil_ikincil_yönü = "1" Then
                            With başlangıççizgisi
                                .Y1 = başlamanoktası.Text + 15
                                .Y2 = başlamanoktası.Text + 15
                                .X1 = (duvardanuzaklık.Text + 10) - 3
                                .X2 = (duvardanuzaklık.Text + 10) + 3
                                .Visible = True
                                .BorderColor = renk
                                .BorderWidth = 1
                                .Parent = şekilyüzeyi
                                .Show()
                            End With

                            With bitişçizgisi
                                .Y1 = bitmenoktası.Text - 15
                                .Y2 = bitmenoktası.Text - 15
                                .X1 = (duvardanuzaklık.Text + 10) - 3
                                .X2 = (duvardanuzaklık.Text + 10) + 3
                                .Visible = True
                                .BorderColor = renk
                                .BorderWidth = 1
                                .Parent = şekilyüzeyi
                                .Show()
                            End With

                            With ölçütçizgisi
                                .Y1 = bitmenoktası.Text - 15
                                .Y2 = başlamanoktası.Text + 15
                                .X1 = (duvardanuzaklık.Text + 10)
                                .X2 = (duvardanuzaklık.Text + 10)
                                .Visible = True
                                .BorderColor = renk
                                .BorderWidth = 1
                                .Parent = şekilyüzeyi
                                .Show()
                            End With

                            With boyuttexti
                                .Width = 50
                                .Height = 12
                                .Top = başlamanoktası.Text + ((bitmenoktası.Text - başlamanoktası.Text) / 2) - (.Height / 2)
                                .Left = duvardanuzaklık.Text + 15
                                .BackColor = Color.White
                                .Text &= " cm"
                                .ForeColor = renk
                                .Parent = nesneyüzeyi
                                .Visible = True
                                .Show()
                            End With
                        End If
                        If şekil_ikincil_yönü = "2" Then
                            With başlangıççizgisi
                                .Y1 = başlamanoktası.Text + 15
                                .Y2 = başlamanoktası.Text + 15
                                .X1 = (duvardanuzaklık.Text - 10) - 3
                                .X2 = (duvardanuzaklık.Text - 10) + 3
                                .Visible = True
                                .BorderColor = renk
                                .BorderWidth = 1
                                .Parent = şekilyüzeyi
                                .Show()
                            End With

                            With bitişçizgisi
                                .Y1 = bitmenoktası.Text - 15
                                .Y2 = bitmenoktası.Text - 15
                                .X1 = (duvardanuzaklık.Text - 10) - 3
                                .X2 = (duvardanuzaklık.Text - 10) + 3
                                .Visible = True
                                .BorderColor = renk
                                .BorderWidth = 1
                                .Parent = şekilyüzeyi
                                .Show()
                            End With

                            With ölçütçizgisi
                                .Y1 = bitmenoktası.Text - 15
                                .Y2 = başlamanoktası.Text + 15
                                .X1 = (duvardanuzaklık.Text - 10)
                                .X2 = (duvardanuzaklık.Text - 10)
                                .Visible = True
                                .BorderColor = renk
                                .BorderWidth = 1
                                .Parent = şekilyüzeyi
                                .Show()
                            End With
                            With boyuttexti
                                .Width = 45
                                .Height = 12
                                .Top = başlamanoktası.Text + ((bitmenoktası.Text - başlamanoktası.Text) / 2) - (.Height / 2)
                                .Left = duvardanuzaklık.Text - 55
                                .BackColor = Color.White
                                .Text &= " cm"
                                .ForeColor = renk
                                .Parent = nesneyüzeyi
                                .Visible = True
                                .Show()
                            End With
                        End If
                    End If
                End Sub

                ' olaylar 


                Private Sub başlamanoktası_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles başlamanoktası.TextChanged
                    yenile()
                    Dim a As String
                    a = duvardanuzaklık.Text
                End Sub

                Private Sub duvardanuzaklık_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles duvardanuzaklık.TextChanged
                    yenile()
                End Sub

                Private Sub bitmenoktası_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles bitmenoktası.TextChanged
                    yenile()
                End Sub

                Private Sub boyuttexti_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles boyuttexti.Click
                    yeni_değer.yayınla(boyuttexti.Text, "Lütfen yeni ölçünüzü giriniz", "yeni ölçü", boyuttexti, False)
                End Sub

                Private Sub boyuttexti_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles boyuttexti.TextChanged
                    Dim hatadentelmekobayı As Integer
                    Dim i As Integer
                    yeniboyuttexti.Text = boyuttexti.Text
                    Try
                        i = InStr(1, yeniboyuttexti.Text, "cm")
                        If i > 0 Then
                            yeniboyuttexti.Select(i - 1, 2)
                            yeniboyuttexti.SelectedText = ""
                        End If
                        Dim a, b As String
                        If Not boyutlandırmaposthatası = 0 Then
                            hatadentelmekobayı = boyuttexti.Text * 3
                        End If
                    Catch
                        MsgBox("Lütfen sayısal bir değer giriniz", MsgBoxStyle.Critical, "HATA")
                    End Try
                    boyutlandırmaposthatası = 2
                End Sub
            End Class

            Public Class eşitleyici
                WithEvents text1 As TextBox
                WithEvents text2 As TextBox
                Sub kur1(ByVal bağlayan As TextBox, ByVal bağlanan As TextBox)
                    text1 = bağlayan
                    text2 = New TextBox
                    bağlanan = text2
                End Sub

                Private Sub text1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles text1.TextChanged
                    text2.Text = text1.Text
                End Sub

                Private Sub text2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles text2.TextChanged
                    text1.Text = text2.Text
                End Sub
            End Class
        End Class

    End Class

End Class
