Imports System.Math

Public Class Silahlar

    Public Class Ağır_Makineli

        Dim taban As Grafik.Nesne
        Dim makine_gövde As Grafik.Nesne
        Dim namlu1, namlu2 As Grafik.Nesne

        Dim koord As Point
        Dim hedef_koord As PointF

        Dim açı As Single

        Dim res As Bitmap

        Dim ateşleyen_namlu As Integer = 1

        WithEvents ateşleyici As New Timer

        Sub New(ByVal koordinat As Point)

            koord = koordinat

            res = New Bitmap(resdizin & "\Taban.png")
            taban = New Grafik.Nesne(gr, res)

            res = New Bitmap(resdizin & "\Ağır Makineli\Gövde.png")
            makine_gövde = New Grafik.Nesne(gr, res)

            res = New Bitmap(resdizin & "\Ağır Makineli\Namlu1.png")
            namlu1 = New Grafik.Nesne(gr, res)

            res = New Bitmap(resdizin & "\Ağır Makineli\Namlu2.png")
            namlu2 = New Grafik.Nesne(gr, res)

            ateşleyici.Interval = 200

            taban.Koordinat = koordinat
            makine_gövde.Koordinat = koordinat
            namlu1.Koordinat = koordinat
            namlu2.Koordinat = koordinat

        End Sub

        Sub Döndür(ByVal Hdf_nok As PointF)
            açı = Math.Atan2(Hdf_nok.Y - koord.Y, Hdf_nok.X - koord.X) * 180 / Math.PI + 90

            makine_gövde.döndür(açı, New Point(0, 0))
            namlu1.döndür(açı, New Point(0, 0))
            namlu2.döndür(açı, New Point(0, 0))

            hedef_koord = Hdf_nok

        End Sub

        Sub Ateş_et()
            ateşleyici.Enabled = True
        End Sub

        Sub Ateşi_kes()
            ateşleyici.Enabled = False

            namlu1.Koordinat = koord
            namlu2.Koordinat = koord

        End Sub

        Private Sub ateşleyici_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ateşleyici.Tick

            Dim ateş_nok As PointF

            If ateşleyen_namlu = 1 Then
                ateşleyen_namlu = 2

                namlu2.X = koord.X
                namlu2.Y = koord.Y

                ' Geri tepme

                namlu1.X = koord.X + 3 * Cos((açı + 90) * PI / 180)
                namlu1.Y = koord.Y + 3 * Sin((açı + 90) * PI / 180)

                ateş_nok.X = koord.X - 10 * Cos((açı + 50) * PI / 180)
                ateş_nok.Y = koord.Y - 10 * Sin((açı + 50) * PI / 180)

                Dim mrmi As New mermi(ateş_nok, hedef_koord, "A", açı + 90, 2, 10)


            ElseIf ateşleyen_namlu = 2 Then

                ateşleyen_namlu = 1

                namlu1.X = koord.X
                namlu1.Y = koord.Y

                ' Geri tepme

                namlu2.X = koord.X + 3 * Cos((açı + 90) * PI / 180)
                namlu2.Y = koord.Y + 3 * Sin((açı + 90) * PI / 180)

                ateş_nok.X = koord.X - 10 * Cos((açı + 130) * PI / 180)
                ateş_nok.Y = koord.Y - 10 * Sin((açı + 130) * PI / 180)

                Dim mrmi As New mermi(ateş_nok, hedef_koord, "A", açı + 90, 2, 10)

            End If


        End Sub

    End Class

End Class

Public Class mermi

    Dim anahız, birimxhız, birimyhız As Single
    Dim açı As Single

    Dim gç As String
    Dim atşleyen As String

    Dim haritkoord As Point

    Dim gr As Grafik.Nesne

    Dim nk As PointF

    Sub New(ByVal nok As PointF, ByVal hedefnok As PointF, ByVal ateşlyn As String, Optional ByVal açıı As Single = 0, Optional ByVal hız As Single = 2, Optional ByVal vruş_gçü As Single = 1.0)

        gç = vruş_gçü
        atşleyen = ateşlyn

        mermlr.Add(Me)

        açı = Atan2(nok.Y - hedefnok.Y, nok.X - hedefnok.X)

        anahız = hız
        birimxhız = Cos(açı)
        birimyhız = Sin(açı)

        gr = New Grafik.Nesne(Ortak.gr, New Bitmap(resdizin & "\Ağır Makineli\Mermi\1.png"))

        nk.X = nok.X
        nk.Y = nok.Y

        gr.Koordinat = nk
        gr.döndür(açıı + 90, New Point(0, 0))

    End Sub

    Sub yürüt()
        nk.X -= birimxhız * anahız
        nk.Y -= birimyhız * anahız

        gr.Koordinat = nk

        haritkoord.X = nk.X
        haritkoord.Y = nk.Y

        If Not nk.X >= 500 Then
            If Not nk.Y >= 500 Then
                If Not nk.X <= 0 Then
                    If Not nk.Y <= 0 Then

                    Else
                        yıkım()
                    End If
                Else
                    yıkım()
                End If
            Else
                yıkım()
            End If
        Else
            yıkım()
        End If

        Dim i As Integer
        Dim örnk_krktr As silahlı_karekter

        ' bütün karekterler taratılıyor koordinatsal olarak üzerin gelme işlemi yapılıyor
        If Not krktrlrA.Count = 0 Then

            For i = 0 To krktrlrA.Count - 1
                örnk_krktr = krktrlrA(i)

                If örnk_krktr.koord_kontrl(nk, gç, atşleyen) = True Then
                    yıkım()
                End If

            Next

        End If

        If Not krktrlrB.Count = 0 Then

            For i = 0 To krktrlrB.Count - 1
                örnk_krktr = krktrlrB(i)

                If örnk_krktr.koord_kontrl(nk, gç, atşleyen) = True Then
                    yıkım()
                End If

            Next

        End If

    End Sub

    Sub kynk()
        nk.X += 10

        açı = Tan((nk.Y - 200) / (nk.X - 200))

        birimxhız = Cos(açı)
        birimyhız = Sin(açı)
    End Sub

    Sub yıkım()

        mermlr.Remove(Me)

        gr.görünürlük(False)

    End Sub

End Class
