Imports System.Math

Public Class çizim_tarlası

    Dim odai As Integer
    Dim oda As New programkütüphanesi.nesnekütüphanesi.dekorist_v1.oda
    Dim orjin As Point

    Dim istemci_tik As Integer = 1
    Dim istemci_değeri As Integer
    Dim gr As Graphics
    Dim cetvelgr As Graphics
    Dim cetvelgr1 As Graphics
    Dim döşenmişsayfa As New Bitmap(1400, 1000)
    Dim döşeneceksayfa As New Bitmap(1200, 600)
    Dim hareketdoğrulama As Integer
    Dim fark As Point
    Dim sabitfark As Point
    Dim kameragorusbaslamanoktası As Point
    Dim konum As Point
    Dim cetvelgörüsbaslamanoktası As Point
    Dim sıfırlama As Boolean
    Dim ilknok As Point
    Dim ilkilesonfark As Point

    Dim xcetvel As New Bitmap(20000, 20)
    Dim ycetvel As New Bitmap(20, 20000)
    Dim xcetvelhareket As New Bitmap(1200, 20)
    Dim ycetvelhareket As New Bitmap(20, 800)

    Dim odano As Integer

    Dim cetvelbirimi As String


    Structure POINTAPI
        Dim X As Integer
        Dim Y As Integer
    End Structure

    Private Declare Function GetCursorPos Lib "user32.dll" (ByRef lpPoint As POINTAPI) As Long
    Public fareyeri As POINTAPI

    Sub kur(ByVal yüzdebildirici As System.Windows.Forms.TextBox)
        ortamı_hazırla()
    End Sub


    Private Sub çizim_tarlası_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Sub kuruluma_başla()
        istemci.Enabled = True
    End Sub

    Sub ortamı_hazırla()

        durum_yüzdesi.Text = "0"

        gr = Graphics.FromImage(döşenmişsayfa)

        Dim i As Long

        For i = 0 To 33
            gr.DrawLine(Pens.Black, 100 * i, 0, 100 * i, 2000)
            gr.DrawLine(Pens.Black, 0, 100 * i, 2000, 100 * i)
        Next i
        düzlem.Image = döşenmişsayfa
        cetvelbirimi = "metre"
    End Sub

    Sub xcetvelini_hazırla()

        Dim i As Single
        Dim arauzunluk As Integer
        Dim yazı As String
        Dim yazıstili As New System.Drawing.FontFamily("Courier New")

        cetvelgr = Graphics.FromImage(xcetvel)
        If cetvelbirimi = "metre" Then
            For i = 0 To 200
                yazı = i - 100 & "m"
                cetvelgr.DrawString(yazı, New System.Drawing.Font(yazıstili, 15, FontStyle.Regular, GraphicsUnit.World), Brushes.White, (i * 100) + 2, 2)
                cetvelgr.DrawLine(New Pen(Color.White, 3), (i * 100), 0, (i * 100), 15)
                cetvelgr.DrawLine(New Pen(Color.White, 2), (i * 100) + 50, 0, (i * 100) + 50, 10)
            Next i
        End If

        cetvelgr = Graphics.FromImage(xcetvelhareket)
        cetvelgr.DrawImage(xcetvel, -10000, 0)
        xaralığı.Image = xcetvelhareket

    End Sub

    Sub ycetvelini_hazırla()

        Dim yazıbitmap As New Bitmap(50, 20)
        Dim yazı As String
        Dim yazıstili As New System.Drawing.FontFamily("Courier New")
        Dim a As New System.Drawing.Drawing2D.Matrix
        Dim c As New Bitmap(100, 100, Imaging.PixelFormat.Format32bppArgb)
        a.RotateAt(90, New Point(10, 10))


        If cetvelbirimi = "metre" Then
            For i = 0 To 200
                durum_yüzdesi.Text += (33 / 40000)
                yazı = i - 100 & "m"

                yazıbitmap = New Bitmap(50, 20)
                gr = Graphics.FromImage(yazıbitmap)
                gr.DrawString(yazı, New System.Drawing.Font(yazıstili, 15, FontStyle.Regular, GraphicsUnit.World), Brushes.White, 2, 2)

                c = New Bitmap(100, 100, Imaging.PixelFormat.Format32bppArgb)
                gr = Graphics.FromImage(c)
                gr.Transform = a
                gr.DrawImage(yazıbitmap, New Point(0, 0))

                cetvelgr = Graphics.FromImage(ycetvel)
                cetvelgr.DrawImage(c, 2, (i * 100) + 2)
                cetvelgr.DrawLine(New Pen(Color.White, 3), 0, (i * 100), 15, (i * 100))
                cetvelgr.DrawLine(New Pen(Color.White, 2), 0, (i * 100) + 50, 10, (i * 100) + 50)
            Next i
        End If


        cetvelgr = Graphics.FromImage(ycetvelhareket)
        cetvelgr.DrawImage(ycetvel, 0, 0)
        yaralığı.Image = ycetvelhareket

        ' -- burada isim war

        cetvelgörüsbaslamanoktası.X = -10000
        cetvelgörüsbaslamanoktası.Y = -10000

    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub düzlem_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles düzlem.MouseMove
        If hareketdoğrulama = True Then
            konum_eşitleyici.Interval = 1
            konum_eşitleyici.Enabled = True

        End If
        If hareketdoğrulama = False Then
            konum_eşitleyici.Interval = 1
            konum_eşitleyici.Enabled = False
        End If
        x.Text = e.X
        y.Text = e.Y
    End Sub

    Sub kaynakkodlar()

        ' ------- 1

        düzlem.Location = New Point(-1, -1)


        gr = Graphics.FromImage(döşenmişsayfa)

        Dim i As Long

        For i = 0 To 20
            gr.DrawLine(Pens.Black, 100 * i, 0, 100 * i, 1000)
            gr.DrawLine(Pens.Black, 0, 100 * i, 1000, 100 * i)
        Next i
        düzlem.Image = döşenmişsayfa

        ' ------   2

        gr = Graphics.FromImage(döşenmişsayfa)
        For i = 0 To 20

            gr.DrawLine(Pens.Black, 100 * i, 0, 100 * i, 2000)
            gr.DrawLine(Pens.Black, 0, 100 * i, 2000, 100 * i)
        Next i
        düzlem.Image = döşenmişsayfa

        Dim yazı As String
        Dim yazıstili As New System.Drawing.FontFamily("Courier New")

        If cetvelbirimi = "metre" Then
            For i = 0 To 40000
                yazı = i - 100 & "m"
                cetvelgr.DrawString(yazı, New System.Drawing.Font(yazıstili, 15, FontStyle.Regular, GraphicsUnit.World), Brushes.White, -2, (i * 100) + 2)
                cetvelgr.DrawLine(New Pen(Color.White, 3), 0, (i * 100), 15, (i * 100))
                cetvelgr.DrawLine(New Pen(Color.White, 2), 0, (i * 100) + 50, 10, (i * 100) + 50)
            Next i
        End If


        kameragorusbaslamanoktası.Y = fareyeri.Y - Form1.Location.Y - Form1.farky - Me.Location.Y - düzlem.Location.Y - fark.Y
        kameragorusbaslamanoktası.X = fareyeri.X - Form1.Location.X - Form1.farkx - Me.Location.X - düzlem.Location.X - fark.X

        döşeneceksayfa = New Bitmap(1200, 800)

        gr = Graphics.FromImage(döşeneceksayfa)

        Dim x, y As Integer
        x = kameragorusbaslamanoktası.X / 100
        y = kameragorusbaslamanoktası.Y / 100

        Dim desennok As PointF
        If kameragorusbaslamanoktası.X > 100 Then
            fark.X += 100
        End If
        If kameragorusbaslamanoktası.X < -100 Then
            fark.X -= 100
        End If
        If kameragorusbaslamanoktası.Y > 100 Then
            fark.Y += 100
        End If
        If kameragorusbaslamanoktası.Y < -100 Then
            fark.Y -= 100
        End If

        desennok = New System.Drawing.PointF(kameragorusbaslamanoktası.X - 100, kameragorusbaslamanoktası.Y - 100)

        gr.DrawImage(döşenmişsayfa, desennok)

        düzlem.Image = döşeneceksayfa




    End Sub

    Private Sub konum_eşitleyici_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles konum_eşitleyici.Tick

        GetCursorPos(fareyeri)
        
        cetvelgörüsbaslamanoktası.Y = fareyeri.Y - Form1.Location.Y - Form1.farky - Me.Location.Y - düzlem.Location.Y - sabitfark.Y
        cetvelgörüsbaslamanoktası.X = fareyeri.X - Form1.Location.X - Form1.farkx - Me.Location.X - düzlem.Location.X - sabitfark.X

        xcetvelhareket = New Bitmap(1200, 20)
        cetvelgr = Graphics.FromImage(xcetvelhareket)
        cetvelgr.DrawImage(xcetvel, cetvelgörüsbaslamanoktası.X, 0)
        xaralığı.Image = xcetvelhareket

        ycetvelhareket = New Bitmap(20, 800)
        cetvelgr = Graphics.FromImage(ycetvelhareket)
        cetvelgr.DrawImage(ycetvel, 0, cetvelgörüsbaslamanoktası.Y)
        yaralığı.Image = ycetvelhareket

        refx.Text = cetvelgörüsbaslamanoktası.X + 10000
        refy.Text = cetvelgörüsbaslamanoktası.Y + 10000

        kaydet()

    End Sub

    Private Sub kaydet()
        Dim i As Integer
        Dim bosluk As Integer
        Dim boslukbelirlemetext As String

        i = veri_tabanı.Find("orjin : ")

        If Not i = -1 Then
            boslukbelirlemetext = orjin.X
            bosluk = 6 - boslukbelirlemetext.Length
            veri_tabanı.Select(i + 8, 6)
            veri_tabanı.SelectedText = orjin.X & Space(bosluk)

            boslukbelirlemetext = orjin.Y
            bosluk = 6 - boslukbelirlemetext.Length
            veri_tabanı.Select(i + 8 + 6 + 1, 6)
            veri_tabanı.SelectedText = orjin.Y & Space(bosluk)
        End If
    End Sub

    Private Sub düzlem_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles düzlem.MouseUp
        hareketdoğrulama = False
        konum_eşitleyici.Enabled = False
        konum = cetvelgörüsbaslamanoktası
    End Sub

    Private Sub düzlem_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles düzlem.MouseDown
        hareketdoğrulama = True
        fark.X = e.X - kameragorusbaslamanoktası.X
        fark.Y = e.Y - kameragorusbaslamanoktası.Y
        sabitfark.X = e.X - cetvelgörüsbaslamanoktası.X
        sabitfark.Y = e.Y - cetvelgörüsbaslamanoktası.Y

    End Sub

    Private Sub düzlem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles düzlem.Click

    End Sub

    Private Sub TextBox7_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles durum_yüzdesi.TextChanged

    End Sub

    Private Sub istemci_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles istemci.Tick
        istemci_tik += 5
        Form1.açılma_yüzdesi.Text = istemci_tik
        If istemci_tik = 36 Then
            ortamı_hazırla()
        End If
        If istemci_tik = 66 Then
            xcetvelini_hazırla()
        End If
        If istemci_tik = 96 Then
            ycetvelini_hazırla()
        End If
        If istemci_tik > 100 Then
            istemci.Enabled = False
            Form1.Opacity = 1
        End If
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim boslukbelirlemetext As String
        Dim boslukx, bosluky As Integer

        odano += 1

        ShapeContainer1.Parent = düzlem
        Dim refnok As Point
        refnok.X = odai + 100
        refnok.Y = odai + 100
        odai += 100

        boslukbelirlemetext = orjin.X
        boslukx = 6 - boslukbelirlemetext.Length

        boslukbelirlemetext = orjin.Y
        bosluky = 6 - boslukbelirlemetext.Length

        Dim i As Integer
        Dim bosluk As Integer
        bosluk = 3 - odano.ToString.Length

        i = veri_tabanı.Find("oda sayısı : ")

        If Not i = -1 Then
            veri_tabanı.Select(i + 13, 3)
            veri_tabanı.SelectedText = Space(bosluk) & odano
        Else
            veri_tabanı.Text &= vbCrLf & "oda sayısı : " & Space(bosluk) & odano
        End If

        sunucu.veritabanı.Text &= vbCrLf & "orjin : " & orjin.X & Space(boslukx) & " " & orjin.Y & Space(bosluky)
        oda = New programkütüphanesi.nesnekütüphanesi.dekorist_v1.oda
        oda.kur(False, False, düzlem, x, y, ShapeContainer1, "oda" & odano, veri_tabanı, Form1.farky, Form1.farkx, refx, refy)
    End Sub

    Private Sub veri_tabanı_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles veri_tabanı.TextChanged
        '
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        oda = New programkütüphanesi.nesnekütüphanesi.dekorist_v1.oda
        Dim i As Integer
        Dim odasayısı As String
        Dim a As Integer

        ShapeContainer1.Parent = düzlem

        i = veri_tabanı.Find("oda sayısı : ")
        Dim refnok As Point
        refnok.X = odai + 100
        refnok.Y = odai + 100

        If Not i = -1 Then
            veri_tabanı.Select(i + 13, 3)
            odasayısı = veri_tabanı.SelectedText

            For a = 1 To odasayısı
                oda = New programkütüphanesi.nesnekütüphanesi.dekorist_v1.oda
                oda.kur(True, False, düzlem, x, y, ShapeContainer1, "oda" & a, veri_tabanı, Form1.farky, Form1.farkx, refx, refy)
            Next a

        Else
            '
        End If

    End Sub
End Class
