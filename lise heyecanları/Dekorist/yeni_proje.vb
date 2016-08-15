Public Class yeni_proje
    ' prje seçimi
    Dim n As Point
    Dim ok As New programkütüphanesi.nesnekütüphanesi.ok
    Dim x, y, k, i, x1, y1, donanımkontrol As Integer
    Dim a, b, c As Point
    ' rproje açıklaması
    Dim k1 As Integer
    Dim d, f As Point
    Private Sub yeni_proje_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub oto_yer_bulucu_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles oto_yer_bulucu.Tick
        i = i + 1
        a = oto_yer.Location
        If Not a.X = x Then
            If a.X < x Then
                donanımkontrol = 1
                k = 1
                b.X = oto_yer.Location.X + 10
                b.Y = oto_yer.Location.Y
            ElseIf a.X > x Then
                donanımkontrol = 2
                k = 1
                b.X = oto_yer.Location.X - 10
                b.Y = oto_yer.Location.Y
            ElseIf a.X = x Then
                oto_yer_bulucu.Enabled = False
                k = 0
            End If
        End If
        If Not a.Y = y Then
            If a.Y < y Then
                donanımkontrol = 3
                b.X = oto_yer.Location.X
                b.Y = oto_yer.Location.Y + 10
            ElseIf a.Y > y Then
                donanımkontrol = 4
                b.X = oto_yer.Location.X
                b.Y = oto_yer.Location.Y - 10
            ElseIf a.Y = y Then
                oto_yer_bulucu.Enabled = False
                k = 0
            End If
        End If
        oto_yer.Location = b
    End Sub

    Private Sub PictureBox3_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.MouseEnter
        x = PictureBox3.Location.X - 4
        y = PictureBox3.Location.Y - 8
        oto_yer_bulucu.Enabled = True
    End Sub

    Private Sub PictureBox1_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.MouseEnter
        x = PictureBox1.Location.X - 4
        y = PictureBox1.Location.Y - 8
        oto_yer_bulucu.Enabled = True

    End Sub

    Private Sub PictureBox4_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox4.MouseEnter
        x = PictureBox4.Location.X - 4
        y = PictureBox4.Location.Y - 8
        oto_yer_bulucu.Enabled = True
    End Sub

    Private Sub PictureBox5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox5.Click
        x1 = PictureBox5.Location.X - 4
        y1 = PictureBox5.Location.Y - 8
        kalıcı.Enabled = True
        alt_çizgi.Enabled = True
    End Sub

    Private Sub PictureBox6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox6.Click
        x1 = PictureBox6.Location.X - 4
        y1 = PictureBox6.Location.Y - 8
        kalıcı.Enabled = True
        alt_çizgi.Enabled = True
    End Sub

    Private Sub PictureBox2_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.MouseEnter
        x = PictureBox2.Location.X - 4
        y = PictureBox2.Location.Y - 8
        oto_yer_bulucu.Enabled = True
    End Sub

    Private Sub PictureBox5_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox5.MouseEnter
        x = PictureBox5.Location.X - 4
        y = PictureBox5.Location.Y - 8
        oto_yer_bulucu.Enabled = True
    End Sub

    Private Sub PictureBox6_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox6.MouseEnter
        x = PictureBox6.Location.X - 4
        y = PictureBox6.Location.Y - 8
        oto_yer_bulucu.Enabled = True
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles kalıcı.Tick
        a = tamam.Location
        If Not a.X = x1 Then
            If a.X < x1 Then
                donanımkontrol = 1
                k = 1
                c.X = tamam.Location.X + 1
                c.Y = tamam.Location.Y
            ElseIf a.X > x1 Then
                donanımkontrol = 2
                k = 1
                c.X = tamam.Location.X - 1
                c.Y = tamam.Location.Y
            ElseIf a.X = x1 Then
                kalıcı.Enabled = False
                k = 0
            End If
        End If
        If Not a.Y = y1 Then
            If a.Y < y1 Then
                donanımkontrol = 3
                c.X = tamam.Location.X
                c.Y = tamam.Location.Y + 1
            ElseIf a.Y > y1 Then
                donanımkontrol = 4
                c.X = tamam.Location.X
                c.Y = tamam.Location.Y - 1
            ElseIf a.Y = y1 Then
                kalıcı.Enabled = False
                k = 0
            End If
        End If
        tamam.Location = c
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        x1 = PictureBox1.Location.X - 4
        y1 = PictureBox1.Location.Y - 8
        kalıcı.Enabled = True
        alt_çizgi.Enabled = True
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        x1 = PictureBox2.Location.X - 4
        y1 = PictureBox2.Location.Y - 8
        kalıcı.Enabled = True
        alt_çizgi.Enabled = True
    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        x1 = PictureBox3.Location.X - 4
        y1 = PictureBox3.Location.Y - 8
        kalıcı.Enabled = True
        alt_çizgi.Enabled = True
    End Sub

    Private Sub PictureBox4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox4.Click
        x1 = PictureBox4.Location.X - 4
        y1 = PictureBox4.Location.Y - 8
        kalıcı.Enabled = True
        alt_çizgi.Enabled = True
    End Sub

    Private Sub alt_çizgi_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles alt_çizgi.Tick
        d = Label10.Location
        If Not d.X = 100 Then
            f.X = Label10.Location.X - 10
            k1 = 1
        End If
        If d.X = 100 Then
            If k1 = 1 Then
                alt_çizgi.Enabled = False
                k1 = 0
            End If
            If Not d.Y = 322 Then
                f.Y = Label10.Location.Y + 2
                f.X = Label10.Location.X
            End If
            If d.Y = 322 Then
                f.X = 400
                f.Y = 300
            End If
        End If
        Label10.Location = f
    End Sub
End Class