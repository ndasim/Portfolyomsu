Imports System.Math

Public Class araba

    Dim motor As grafik_motor_v1.Motor
    Dim araban As grafik_motor_v1.Nesne
    Dim arabares As Bitmap
    Dim hedef As grafik_motor_v1.Çizgi
    Dim resyazı As grafik_motor_v1.etiket

    Dim açı1, ilkaçı, cos1, açı As Double

    Dim araçaçı, hedefaçı As Single

    Dim nok As Point

    Dim hız As Short

    Private Sub araba_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        motor = New grafik_motor_v1.Motor(PictureBox1)

        resyazı = New grafik_motor_v1.Etiket(motor, "asım")

        nok.X = 5
        nok.Y = 20

        araçaçı = -45

        dönme = 2

        motor.yenilenme_hızını_göster()

        arabares = New Bitmap(20, 20)

        Dim gr As Graphics

        gr = Graphics.FromImage(arabares)

        gr.FillRectangle(Brushes.White, New Rectangle(0, 0, 10, 20))

        hedef = New grafik_motor_v1.Çizgi(motor)

        araban = New grafik_motor_v1.Nesne(motor, arabares)


    End Sub

    Dim öncekiaçı As Single

    Sub döndür()

        ' ARACIN DÖNME AÇISI :

        Dim a, b, c As Double

        a = 100 ^ 2  ' 100 ; aracın merkezden uzaklığı

        b = 100 ^ 2

        c = 20 ^ 2    ' 20; nesnenin yükseliği

        cos1 = (a + b - c)

        cos1 = cos1 / (2 * 100 ^ 2) ' kosinüs değerinin bulunması

        açı1 = Math.Acos(cos1)  ' kosinüs değerinin radyana dönüştürülmesi

        açı1 = açı1 * 180 / Math.PI ' radyanın açıya dönüştüreülmesi

        açı = ((180 - açı1) / 2) + ilkaçı  ' aracın arka kısmında yapacak olacağı açının hesapalanması. ilkaçı; aracın merkeze yaptığı açı  

        açı += 90

        Dim nok As Point

        nok.X = 5
        nok.Y = 20


        araban.döndür(-açı - öncekiaçı, nok)

        öncekiaçı = -açı
    End Sub

    Private Sub TrackBar1_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar1.Scroll
        If TrackBar1.Value < -5 Then
            yön = 1

            merkez.X = araban.X
            merkez.Y = araban.Y

            dönüş_uzaklığı = 20

            merkez.X = araban.X + dönüş_uzaklığı * Cos((araçaçı + 90) * PI / 180)
            merkez.Y = araban.Y - dönüş_uzaklığı * Sin((araçaçı + 90) * PI / 180)

            hedefaçı = 180 + (araçaçı - 90)

            hedef.X1 = araban.X
            hedef.Y1 = araban.Y

            hedef.bitiş_noktası = merkez

            dönme = 1

            Label1.Text = dönüş_uzaklığı

            Label2.Text = merkez.X
            Label3.Text = merkez.Y

        End If
        If TrackBar1.Value > 5 Then
            yön = -1

            merkez.X = araban.X
            merkez.Y = araban.Y

            dönüş_uzaklığı = 20

            merkez.X = araban.X + dönüş_uzaklığı * Cos((araçaçı - 90) * PI / 180)
            merkez.Y = araban.Y - dönüş_uzaklığı * Sin((araçaçı - 90) * PI / 180)

            hedefaçı = 180 + (araçaçı - 90)

            hedef.X1 = araban.X
            hedef.Y1 = araban.Y

            hedef.bitiş_noktası = merkez

            dönme = 1

            Label1.Text = dönüş_uzaklığı

            Label2.Text = merkez.X
            Label3.Text = merkez.Y

        End If
        If TrackBar1.Value = 0 Then

            merkez.X = araban.X
            merkez.Y = araban.Y

            konumb = 0
            dönme = 2
        End If
    End Sub

    Dim konuma1, konumb As Single
    Dim konum As Point
    Dim dönme As Short

    Dim yön As Short

    Dim merkez As Point
    Dim dönüş_uzaklığı As Single


    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        If dönme = 2 Then
            konumb += 1

            araban.X = merkez.X + konumb * Math.Cos(araçaçı * Math.PI / 180)
            araban.Y = merkez.Y - konumb * Math.Sin(araçaçı * Math.PI / 180)

            dönme = 2

        End If
        If dönme = 1 Then
            If yön = 1 Then
                hedefaçı -= 1

                araban.X = merkez.X + dönüş_uzaklığı * Math.Cos(hedefaçı * Math.PI / 180)
                araban.Y = merkez.Y - dönüş_uzaklığı * Math.Sin(hedefaçı * Math.PI / 180)

                araçaçı = 180 - (hedefaçı + 90)

                araçaçı = -araçaçı

                hedef.X1 = araban.X
                hedef.Y1 = araban.Y
            End If
            If yön = -1 Then
                hedefaçı -= 1

                araban.X = merkez.X + dönüş_uzaklığı * Math.Cos(hedefaçı * Math.PI / 180)
                araban.Y = merkez.Y - dönüş_uzaklığı * Math.Sin(hedefaçı * Math.PI / 180)

                araçaçı = 180 - (hedefaçı + 90)

                araçaçı = -araçaçı

                hedef.X1 = araban.X
                hedef.Y1 = araban.Y

            End If

            araban.döndür((-araçaçı + 90) - öncekiaçı, nok)

            dönme = 1

            öncekiaçı = (-araçaçı + 90)

        End If

        If dönme = 3 Then

        End If

        resyazı.X1 = araban.X + 10
        resyazı.Y1 = araban.Y + 10
        resyazı.çizgi_kalınlığı = konumb + 1

    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        dönme = 1
    End Sub
End Class