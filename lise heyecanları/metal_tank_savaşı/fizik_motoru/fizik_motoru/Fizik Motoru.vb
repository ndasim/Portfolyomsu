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
    Dim form As New Form1()
    Dim gr As Graphics

    Sub New(ByVal genislik As Integer, ByVal yükseklik As Integer)

        noktasayısı = genişlik & yüksklik
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

        noktalar(x, y).rengim = renk

    End Sub

    Public Function noktanın_değerin_oku(ByVal x As Single, ByVal y As Single) As renk

        rengi = noktalar(x, y).rengim

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