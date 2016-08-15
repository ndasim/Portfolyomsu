
Public Class Form1
    Dim oda As programkütüphanesi.nesnekütüphanesi.dekorist_v1.oda
    Dim çizim_tarlası As çizim_tarlası

    Dim yazdırdöküman As System.Drawing.Printing.PrintDocument

    Dim i As Integer = 1

    Dim x, x1, x2, x3, x4 As Integer
    ' menü fonksiyonları için ...
    Dim mx1, mx2, mx3, mx4, k, kilit, kilit1 As Integer
    ' menü fonksiyonları için ...
    Dim menüanimasyonu, menüilerigeri As Integer
    Dim doğan As Integer = -30
    Dim x5 As Integer = 86
    Dim x6 As Integer = 86
    Dim x7 As Integer = -30
    Dim x8 As Integer = -30
    Dim y, y1, y2, y3 As Integer
    Dim a, b, d As System.Drawing.Size ' a = form açılış animasyonu, b = menü açılış animasyonu d = menü aşağı çekme animasyonu
    Dim c, f, g, h, j, l As System.Drawing.Point ' c =aşağı yukarı çekme buton animasyonu , yazı geçiş için yazının pozisyonu, g = giriş tıklama animasyonu, h = ayarlar tıklama animasyonu. j = hoşgeldiz formunun başlama pozisyonu

    Public farkx, farky As Double
    Structure POINTAPI
        Dim X As Integer
        Dim Y As Integer
    End Structure
    Private Declare Function GetCursorPos Lib "user32.dll" (ByRef lpPoint As POINTAPI) As Long
    Private Declare Function HPALETTE_UserSize Lib "ole32.dll" (ByRef pLong As Long, ByVal lLong As Long, ByRef pHpalette As Long) As Long

    Declare Function SetCursorPos Lib "user32" (ByVal X As Long, ByVal Y As Long) As Long

    Public fareyeri As POINTAPI
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If Not y = 1000 Then
            y = y + 50
            If y = 1000 Then
                x = 900
            End If
            If x = 900 And y = 1000 Then
                Timer1.Enabled = False
                Timer2.Enabled = True
                TextBox1.Text = "tamam"
            End If
        End If
        a.Height = x
        a.Width = y
        Me.Size = a
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        c.X = 134
        c.Y = x1
        GroupBox1.Location = c
        TextBox1.Text = x1
        If Not x1 = -8 Then
            x1 = x1 + 2
        End If
        If x1 = -8 Then
            Timer2.Enabled = False
        End If
    End Sub

    Private Sub asagı_cek_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles açılır_menü1.Tick

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        çizim_tarlası = New çizim_tarlası
        With çizim_tarlası
            .Top = 100
            .Left = 100
        End With

        hazırlanıyor.Show()
        hazırlanıyor.Hide()
    End Sub



    Private Sub proje_aç_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles proje_aç.Tick
        If alt_çizgi.Enabled = True Then
            TextBox4.Text = "yürüyor"
        End If
        If Not alt_çizgi.Enabled = True Then
            TextBox4.Text = "durdu"
        End If
    End Sub

    Private Sub PictureBox5_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        TextBox5.Text = "içerii"
    End Sub

    Private Sub Form1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        ' ------ !!! '-_ BU BAŞARIYI SAKIN UNUTMA _-' !!! ------ '
        Dim ilknok, sonrakinok As Point
        i += 1
        If i = 100 Then
            ilknok = e.Location
            GetCursorPos(fareyeri)
            sonrakinok.X = fareyeri.X
            sonrakinok.Y = fareyeri.Y
            farkx = sonrakinok.X - Me.Location.X - ilknok.X
            farky = sonrakinok.Y - Me.Location.Y - ilknok.Y
            MsgBox(farkx & "," & farky)
        End If
    End Sub

    Private Sub Form1_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        ' genel
        Dim c As Size
        c = Me.Size
        ' menü 
        Dim x1 As Drawing.Point
        Dim x2 As Size
        x1.Y = -10
        x1.X = c.Width / 7.5
        GroupBox1.Location = x1
        x2.Height = GroupBox1.Size.Height
        x2.Width = c.Width / 1.4
        GroupBox1.Size = x2
        ' dosya menüsü
        Dim x As Drawing.Point
        x.Y = 16
        x.X = x2.Width / 15
        Label8.Location = x
        ' araçlar menüsü
        Dim x3 As Drawing.Point
        x3.Y = 16
        x3.X = x2.Width / 3.4
        Label7.Location = x3
        ' görünüm menüsü
        Dim x4 As Drawing.Point
        x4.Y = 16
        x4.X = x2.Width / 1.8
        Label6.Location = x4
        ' yardım menüsü
        Dim x5 As Drawing.Point
        x5.Y = 16
        x5.X = x2.Width / 1.2
        Label5.Location = x5
        TextBox1.Text = Me.Size.Width
    End Sub


    Private Sub yazdır_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles yazdır.Tick
        TextBox2.Text = RectangleShape2.Location.X
    End Sub

    Private Sub TableLayoutPanel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs)

    End Sub

    Private Sub Label2_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub alt_çizgi_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles alt_çizgi.Tick
        Dim asım As System.Drawing.Point
        If menüilerigeri = 0 Then
            If Not doğan = -9 Then
                doğan = doğan + 1
            End If
            If doğan = -9 Then
                alt_çizgi.Enabled = False
            End If
            TextBox1.Text = x2
            asım.X = x2
            asım.Y = doğan
            RectangleShape2.Location = asım
        End If
        If menüilerigeri = 1 Then
            If Not doğan = -30 Then
                doğan = doğan - 1
            End If
            If doğan = -30 Then
                alt_çizgi.Enabled = False
            End If
            TextBox1.Text = x2
            asım.X = x2
            asım.Y = doğan
            RectangleShape2.Location = asım
        End If
    End Sub

    Private Sub Label8_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label8.MouseHover

    End Sub

    Private Sub Label8_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label8.MouseEnter
        Dim a As Size
        a.Height = RectangleShape2.Size.Height
        a.Width = Label8.Size.Width + 10
        alt_çizgi.Enabled = True
        x2 = Label8.Location.X - 20
        menüilerigeri = 0
    End Sub

    Private Sub Label8_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label8.MouseLeave
        alt_çizgi.Enabled = True
        x2 = Label8.Location.X - 20
        menüilerigeri = 1
    End Sub

    Private Sub Label7_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label7.MouseEnter
        alt_çizgi.Enabled = True
        x2 = Label7.Location.X - 18
        menüilerigeri = 0
    End Sub

    Private Sub Label7_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label7.MouseLeave
        alt_çizgi.Enabled = True
        x2 = Label7.Location.X - 18
        menüilerigeri = 1
    End Sub

    Private Sub Label6_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label6.MouseEnter
        alt_çizgi.Enabled = True
        x2 = Label6.Location.X - 10
        menüilerigeri = 0
    End Sub

    Private Sub Label6_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label6.MouseLeave
        alt_çizgi.Enabled = True
        x2 = Label6.Location.X - 10
        menüilerigeri = 1
    End Sub

    Private Sub Label5_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.MouseEnter
        alt_çizgi.Enabled = True
        x2 = Label5.Location.X - 18
        menüilerigeri = 0
    End Sub

    Private Sub Label5_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.MouseLeave
        alt_çizgi.Enabled = True
        x2 = Label5.Location.X - 18
        menüilerigeri = 1
    End Sub


    Private Sub açılır_menü_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles açılır_menü.Tick
        Dim c As Size
        Dim a As Point
        If mx1 = 1 Then
            If Not kilit1 = 0 Then
                If Not kilit1 = 1 Then
                    If Not GroupBox1.Size.Height = 39 And GroupBox1.Size.Height = 70 Then
                        kilit = 1
                    End If
                    If GroupBox1.Size.Height = 39 And Not GroupBox1.Size.Height = 70 Then
                        kilit = 0
                        kilit1 = 1
                    End If
                End If
            End If
            If kilit = 0 Then
                If Not GroupBox1.Size.Height = 70 Then
                    c.Height = k
                    c.Width = GroupBox1.Size.Width
                    GroupBox1.Size = c
                    k = k + 1
                    a.X = Label8.Location.X - 12
                    a.Y = Label8.Location.Y + 20
                    Panel1.Location = a
                    Panel1.Visible = True
                    Panel2.Visible = False
                End If
                If GroupBox1.Size.Height = 70 Then
                    kilit = 1
                    kilit1 = 1
                    açılır_menü.Enabled = False
                End If
            End If
            If kilit = 1 Then
                If Not GroupBox1.Size.Height = 38 Then
                    c.Height = k
                    c.Width = GroupBox1.Size.Width
                    GroupBox1.Size = c
                    k = k - 1
                End If
                If GroupBox1.Size.Height = 38 Then
                    kilit = 0
                    açılır_menü.Enabled = False
                End If
            End If
        End If
        If mx1 = 2 Then
            If Not kilit1 = 0 Then
                If Not kilit1 = 2 Then
                    If Not GroupBox1.Size.Height = 39 And GroupBox1.Size.Height = 70 Then
                        kilit = 1
                    End If
                    If GroupBox1.Size.Height = 39 And Not GroupBox1.Size.Height = 70 Then
                        kilit = 0
                        kilit1 = 2
                    End If
                End If
            End If
            If kilit = 0 Then
                TextBox2.Text = "düüüüüt"
                If Not GroupBox1.Size.Height = 70 Then
                    c.Height = k
                    c.Width = GroupBox1.Size.Width
                    GroupBox1.Size = c
                    k = k + 1
                    a.X = Label7.Location.X - 12
                    a.Y = Label7.Location.Y + 20
                    Panel2.Location = a
                    Panel1.Visible = False
                    Panel2.Visible = True
                End If
                If GroupBox1.Size.Height = 70 Then
                    kilit = 1
                    kilit1 = 2
                    açılır_menü.Enabled = False
                End If
            End If
            If kilit = 1 Then
                If Not GroupBox1.Size.Height = 38 Then
                    c.Height = k
                    c.Width = GroupBox1.Size.Width
                    GroupBox1.Size = c
                    k = k - 1
                End If
                If GroupBox1.Size.Height = 38 Then
                    açılır_menü.Enabled = False
                    kilit = 0
                End If
            End If
        End If
        If mx1 = 3 Then
            If Not kilit1 = 0 Then
                If Not kilit1 = 3 Then
                    If Not GroupBox1.Size.Height = 39 And GroupBox1.Size.Height = 70 Then
                        kilit = 1
                    End If
                    If GroupBox1.Size.Height = 39 And Not GroupBox1.Size.Height = 70 Then
                        kilit = 0
                        kilit1 = 3
                    End If
                End If
            End If
            If kilit = 0 Then
                TextBox2.Text = "düüüüüt"
                If Not GroupBox1.Size.Height = 70 Then
                    c.Height = k
                    c.Width = GroupBox1.Size.Width
                    GroupBox1.Size = c
                    k = k + 1
                    a.X = Label7.Location.X - 12
                    a.Y = Label7.Location.Y + 20
                    Panel2.Location = a
                    Panel1.Visible = False
                    Panel2.Visible = True
                End If
                If GroupBox1.Size.Height = 70 Then
                    kilit = 1
                    kilit1 = 3
                    açılır_menü.Enabled = False
                End If
            End If
            If kilit = 1 Then
                If Not GroupBox1.Size.Height = 38 Then
                    c.Height = k
                    c.Width = GroupBox1.Size.Width
                    GroupBox1.Size = c
                    k = k - 1
                End If
                If GroupBox1.Size.Height = 38 Then
                    açılır_menü.Enabled = False
                    kilit = 0
                End If
            End If
        End If
        If mx1 = 4 Then
            If Not kilit1 = 0 Then
                If Not kilit1 = 4 Then
                    If Not GroupBox1.Size.Height = 39 And GroupBox1.Size.Height = 70 Then
                        kilit = 1
                    End If
                    If GroupBox1.Size.Height = 39 And Not GroupBox1.Size.Height = 70 Then
                        kilit = 0
                        kilit1 = 4
                    End If
                End If
            End If
            If kilit = 0 Then
                TextBox2.Text = "düüüüüt"
                If Not GroupBox1.Size.Height = 70 Then
                    c.Height = k
                    c.Width = GroupBox1.Size.Width
                    GroupBox1.Size = c
                    k = k + 1
                    a.X = Label7.Location.X - 12
                    a.Y = Label7.Location.Y + 20
                    Panel2.Location = a
                    Panel1.Visible = False
                    Panel2.Visible = True
                End If
                If GroupBox1.Size.Height = 70 Then
                    kilit = 1
                    kilit1 = 4
                    açılır_menü.Enabled = False
                End If
            End If
            If kilit = 1 Then
                If Not GroupBox1.Size.Height = 38 Then
                    c.Height = k
                    c.Width = GroupBox1.Size.Width
                    GroupBox1.Size = c
                    k = k - 1
                End If
                If GroupBox1.Size.Height = 38 Then
                    açılır_menü.Enabled = False
                    kilit = 0
                End If
            End If
        End If
        TextBox3.Text = GroupBox1.Size.Height
    End Sub

    Private Sub Label8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label8.Click
        mx1 = 1
        açılır_menü.Enabled = True
        PrintForm1.Print(rapor, PrintForm.PrintOption.Scrollable)
    End Sub

    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label7.Click
        mx1 = 2
        açılır_menü.Enabled = True

        açılma_yüzdesi.Text = "0"

        hazırlanıyor.başla(açılma_yüzdesi.Text, Me)
        hazırlanıyor.Show()

        çizim_tarlası.kuruluma_başla()

    End Sub

    Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label6.Click
        mx1 = 3
        açılır_menü.Enabled = True
    End Sub

    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.Click
        mx1 = 4
        açılır_menü.Enabled = True
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        oda = New programkütüphanesi.nesnekütüphanesi.dekorist_v1.oda
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim a As Point
        a.X = 300
        a.Y = 300
        oda = New programkütüphanesi.nesnekütüphanesi.dekorist_v1.oda
    End Sub

    Private Sub açılma_yüzdesi_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles açılma_yüzdesi.TextChanged
        If açılma_yüzdesi.Text > 100 Then
            çizim_tarlası.Parent = Me
            Me.Opacity = 1
        End If
        hazırlanıyor.başla(açılma_yüzdesi.Text, Me)
    End Sub

    Private Sub Timer3_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles çizim_tarlası_açma_istemcisi.Tick

    End Sub
End Class
