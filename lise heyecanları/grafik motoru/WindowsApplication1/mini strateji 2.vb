Public Class mini_strateji_2
    Dim komutan As komutan
    Private Sub mini_strateji_2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim nok() As Point = {New Point, New Point, New Point, New Point}
        nok(0).X = 0
        nok(0).Y = 0
        nok(1).X = 150
        nok(1).Y = 50
        nok(2).X = 10
        nok(2).Y = 10

        komutan = New komutan
        komutan.kur(TextBox1, "k1", PictureBox1, nok)
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        TextBox1.Text += 1
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click

    End Sub
End Class
Public Class komutan
    ' ---------- FİZİKSELLER ---------- '
    WithEvents tick As TextBox
    WithEvents bilgitexti As TextBox
    Dim asker1p, asker2p, asker3p, asker4p As Point
    Dim cihazcan As grafik_motor_v1.Motor
    Dim asker As grafik_motor_v1.Nesne
    'Dim asker1 As New er
    Dim asker2 As New er

    ' ---------- SANALLAR ----------'

    Dim res As Bitmap

    ' --- Hareket etmek için sanallar -->
    Dim yol() As Point = {New Point, New Point, New Point, New Point, New Point}

    Dim yürünenyol As Double
    Dim açı As Double
    Dim xhareketdeğeri As Double
    Dim x As Integer
    Dim y As Integer
    Dim yhareketdeğeri As Integer
    Dim xt As String
    Dim yt As String
    Dim boslukx As Integer
    Dim bosluky As Integer
    Dim sıradakiyol As Short = 1

    Sub kur(ByVal tik As TextBox, ByVal ip As String, ByVal çalışmaalanı As System.Windows.Forms.PictureBox, Optional ByVal noktalar() As Point = Nothing)

        res = New Bitmap("C:\Users\Ev Bilgisayarı\Desktop\grafik motoru\WindowsApplication1\ministrateji\komutan.png")

        cihazcan = New grafik_motor_v1.Motor(çalışmaalanı)

        asker = New grafik_motor_v1.Nesne(cihazcan, res)

        'asker.başla

        tick = New TextBox
        bilgitexti = New TextBox
        tick = tik
        'asker1 = New er
        asker2 = New er
        yol = noktalar
        x = 1
        y = 1

    End Sub
 
    Private Sub tick_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tick.TextChanged
        yönühesapla()
        yürü()

    End Sub
    Sub yönühesapla()
        açı = Math.Atan2(yol(sıradakiyol - 1).Y - yol(sıradakiyol).Y, yol(sıradakiyol - 1).X + yol(sıradakiyol).X)
        açı = açı * 180 / Math.PI
    End Sub
    Sub yürü()


        yürünenyol -= 1

        x = yol(sıradakiyol - 1).X - yürünenyol * Math.Cos(açı * Math.PI / 180)
        y = yol(sıradakiyol - 1).Y + yürünenyol * Math.Sin(açı * Math.PI / 180)


        asker.X = x
        asker.Y = y
        bilgitexti.Text = "kmtn x=" & Space(boslukx) & x & " y=" & Space(bosluky) & y & " v=f"

        ' asker1 
        'asker1p.X = x - 8 * Math.Cos((açı + 70) * Math.PI / 180)
        'asker1p.Y = y + 8 * Math.Sin((açı + 70) * Math.PI / 180)
        'xt = asker1p.X
        'yt = asker1p.Y
        'boslukx = 3 - xt.Length
        'bosluky = 3 - yt.Length

        ' asker2
        'asker2p.X = x - 8 * Math.Cos((açı - 70) * Math.PI / 180)
        'asker2p.Y = y + 8 * Math.Sin((açı - 70) * Math.PI / 180)
        'xt = asker2p.X
        'yt = asker2p.Y
        'boslukx = 3 - xt.Length
        'bosluky = 3 - yt.Length
        'bilgitexti.Text = "er x=" & Space(boslukx) & asker2p.X & " y=" & Space(bosluky) & asker2p.Y & " v=e"
        If x = yol(sıradakiyol).X And y = yol(sıradakiyol).Y Or x > yol(sıradakiyol).X And y > yol(sıradakiyol).Y Then
            sıradakiyol += 1
            yürünenyol = 0
        End If
    End Sub
End Class
Public Class er
    WithEvents tick As TextBox
    WithEvents bilgitexti As TextBox
    Dim xhareketdeğeri As Double
    Dim x As Integer
    Dim y As Integer
    Dim yhareketdeğeri As Double
    Dim xt As String
    Dim yt As String
    Dim boslukx As Integer
    Dim bosluky As Integer

    Sub kur(ByVal tik As TextBox, ByVal ip As String)
        tick = New TextBox
        bilgitexti = New TextBox
        tick = tik
        baslat()
    End Sub
    Sub baslat()
        bilgitexti.Text = "er x=00" & x & " y=00" & y & " v=e"
    End Sub
    Private Sub tick_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tick.TextChanged
        xhareketdeğeri += Rnd(3)
        x = xhareketdeğeri
        yhareketdeğeri += Rnd(6)
        y = yhareketdeğeri
        xt = x
        yt = y
        boslukx = 3 - xt.Length
        bosluky = 3 - yt.Length
        bilgitexti.Text = "er x=" & Space(boslukx) & x & " y=" & Space(bosluky) & y & " v=e"
    End Sub
End Class
