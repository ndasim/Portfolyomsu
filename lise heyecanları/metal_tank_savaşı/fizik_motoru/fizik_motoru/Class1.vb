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

    Dim yükseklik, genişlik As Integer

    Dim rengi As renk

    Dim bildir As renk_bildirgesi

    WithEvents iletişim As iletişim_kanalı

    WithEvents gösterim_yenlileyicisi As Windows.Forms.Timer

    Dim bit As Bitmap

    Dim gr As Graphics

    Sub New(ByVal x As Integer, ByVal y As Integer)

        noktasayısı = x & y

        yükseklik = y

        genişlik = x

        Dim yeninoktalar(x, y) As Nokta

        rengi = New renk()

        bildir = New renk_bildirgesi(rengi)

        noktalar = yeninoktalar

        bit = New Bitmap(genişlik, yükseklik)

        noktaları_aktif_et()

        iletişim = New iletişim_kanalı



    End Sub

    Sub fiziksel_haritayı_göster()

        Dim form As New Form1()

        gr = Graphics.FromImage(bit)

        gr.FillRectangle(Brushes.Snow, New RectangleF(0, 0, genişlik, yükseklik))

        gr = form.CreateGraphics()

        gr.ScaleTransform(50, 50)

        gr.DrawImage(bit, New Point(0, 0))

        gösterim_yenlileyicisi = New Windows.Forms.Timer

        gösterim_yenlileyicisi.Interval = 200

        gösterim_yenlileyicisi.Enabled = True

        form.Show()

    End Sub

    Sub noktaları_aktif_et()

        Dim x, y, i, a As Integer

        For i = 1 To noktasayısı
            If x > genişlik Then
                If Not y > yükseklik Then
                    x = 0
                    y += 1
                End If
            End If
            If Not y > yükseklik Then

                bildir.x = x
                bildir.y = y

                noktalar(x, y) = New Nokta(bildir, iletişim)
            End If
            x += 1
        Next

    End Sub

    Public Sub noktaya_değer_Ata(ByVal x As Single, ByVal y As Single, ByVal renk As renk)

        If renk.değer_0_ = 1 Then
            bit.SetPixel(x, y, Color.DarkRed)
        End If
        If renk.değer_0_ = 0 Then
            bit.SetPixel(x, y, Color.Snow)
        End If

        noktalar(x, y).rengim = renk

    End Sub

    Public Function noktanın_değerin_oku(ByVal x As Single, ByVal y As Single) As renk

        Dim i As Integer

        rengi = noktalar(x, y).rengim

        Return rengi

    End Function

    Private Sub gösterim_yenlileyicisi_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gösterim_yenlileyicisi.Tick
        gr.DrawImage(bit, New Point(0, 0))
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