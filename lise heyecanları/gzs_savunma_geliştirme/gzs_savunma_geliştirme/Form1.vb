Public Class Form1

    Dim nsne As Grafik.Nesne

    Dim çizg As Grafik.Çizgi

    Dim slah, slah1, slah2, slah3, slah4, slah5 As Silahlar.Ağır_Makineli
    Dim krktr As silahlı_karekter

    Dim res_yol As String = "C:\Users\Bilgisayar\Desktop\ADN Yazılım\gzs_savunma_geliştirme\gzs_savunma_geliştirme\res\tip1ss.png"

    Dim bit As Bitmap

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        gr = New Grafik.Toplayıcı(PictureBox1)

        gr.yenilenme_hızını_göster()

        slah = New Silahlar.Ağır_Makineli(New Point(200, 200))
        slah1 = New Silahlar.Ağır_Makineli(New Point(200, 250))
        slah2 = New Silahlar.Ağır_Makineli(New Point(200, 300))
        slah3 = New Silahlar.Ağır_Makineli(New Point(200, 350))
        slah4 = New Silahlar.Ağır_Makineli(New Point(200, 400))
        slah5 = New Silahlar.Ağır_Makineli(New Point(200, 450))

        krktr = New silahlı_karekter("B", New Point(400, 400))

        TextBox1 = gr.tikleyici
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub PictureBox1_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseMove
        slah.Döndür(e.Location)
        slah1.Döndür(e.Location)
        slah2.Döndür(e.Location)
        slah3.Döndür(e.Location)
        slah4.Döndür(e.Location)
        slah5.Döndür(e.Location)
    End Sub

    Private Sub PictureBox1_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseDown
        slah.Ateş_et()
        slah1.Ateş_et()
        slah2.Ateş_et()
        slah3.Ateş_et()
        slah4.Ateş_et()
        slah5.Ateş_et()
    End Sub

    Private Sub PictureBox1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseUp
        slah.Ateşi_kes()
        slah1.Ateşi_kes()
        slah2.Ateşi_kes()
        slah3.Ateşi_kes()
        slah4.Ateşi_kes()
        slah5.Ateşi_kes()
    End Sub

    Private Sub TextBox1_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

        Dim örnk_merm As mermi
        If Not mermlr.Count = 0 Then

            For i = 0 To mermlr.Count - 1

                Try
                    örnk_merm = mermlr(i)
                    örnk_merm.yürüt()
                Catch ex As Exception

                End Try

            Next

        End If
    End Sub

    Dim hızz As Boolean
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If hızz = False Then
            hızz = True
            gr.hıztest(hızz)
            Button1.BackColor = Color.Green
        Else
            hızz = False
            gr.hıztest(hızz)
            Button1.BackColor = Color.Red
        End If

    End Sub
End Class
