Public Class Dökümbirim

    Public yapılan_iş As String

    Dim no As Integer

    Public x, y As Integer

    WithEvents kydırma As Birimkydırma

    WithEvents ana_p As New Windows.Forms.Panel
    WithEvents ayrınt_p As New Panel

    WithEvents ad As New Windows.Forms.Label
    WithEvents yapan As New Label
    WithEvents brmfiyat As New Label
    WithEvents toptutar As New Label
    WithEvents bslmatar As New Label
    WithEvents btistar As New Label
    WithEvents aksama As New Label

    WithEvents b As New Button

    WithEvents oto As oto_list

    Sub New()

        Dim nsne As Dökümbirim
        no = birimler.Add(Me)

        Try
            nsne = birimler(no - 1)
            y = nsne.y + 22
        Catch ex As Exception
            y = 0
        End Try

        kur()

    End Sub

    Sub kur()

        With ana_p
            .Parent = Form1
            .Height = 22
            .Width = 900
            .Left = x
            .Top = y
            .Show()
        End With

        With ayrınt_p
            .Parent = Form1
            .Top = y + 22
            .Visible = False
        End With

        With ad
            .Parent = ana_p
            .Top = 1
            .Left = 1
            .Font = yazıtipi
            .Show()
        End With

        With yapan
            .Parent = ana_p
            .Top = 1
            .Left = 100
            .Font = yazıtipi
            .Show()
        End With

        With bslmatar
            .Parent = ana_p
            .Top = 1
            .Left = 200
            .Font = yazıtipi
            .Show()
        End With

        With btistar
            .Parent = ana_p
            .Top = 1
            .Left = 300
            .Font = yazıtipi
            .Show()
        End With

        With toptutar
            .Parent = ana_p
            .Top = 1
            .Left = 400
            .Font = yazıtipi
            .Show()
        End With

        ad.Text = "aass"
        yapan.Text = "asım"
        bslmatar.Text = "doğan"

    End Sub

    Sub ayrınt_pnl_yönt()

        If ayrınt_p.Visible = True Then
            ayrınt_p.Width = 0
            ayrınt_p.Visible = False
            Y_Kaydırma(no, "Kapat")
        Else
            ayrınt_p.Width = 100
            ayrınt_p.Visible = True
            Y_Kaydırma(no, "Aç")
        End If

    End Sub

    Sub Kay()
        ana_p.Top = y
        ayrınt_p.Top = y + 22
    End Sub

    '' Fare Tıklama

    Private Sub Tıklama(ByVal sender As Object, ByVal e As System.EventArgs) Handles ana_p.Click, ad.Click, bslmatar.Click, btistar.Click, toptutar.Click, yapan.Click
        aç(no)
        Tıklanma()
    End Sub

    '' Fare Çift Tıklama 

    Private Sub Çift_Tıklama(ByVal sender As Object, ByVal e As System.EventArgs) Handles ana_p.DoubleClick, ad.DoubleClick, bslmatar.DoubleClick, btistar.DoubleClick, toptutar.DoubleClick, yapan.DoubleClick

        Dim nesne As Label = sender

        Dim nok As Point

        nok = nesne.Location

        nok.Y = nesne.Parent.Location.Y + nesne.Location.Y

        Form1.ilgili = sender

        Form1.Giriş.Location = nok
        Form1.Giriş.Visible = True

    End Sub

    '' Fare Giriş ''

    Private Sub Üstüne_gelme(ByVal sender As Object, ByVal e As System.EventArgs) Handles ana_p.MouseEnter, ad.MouseEnter, bslmatar.MouseEnter, btistar.MouseEnter, toptutar.MouseEnter, yapan.MouseEnter
        ana_p.BackColor = Color.Cornsilk
    End Sub

    '' Fare Ayrılma ''

    Private Sub Üstünden_Ayrılma(ByVal sender As Object, ByVal e As System.EventArgs) Handles ana_p.MouseLeave, ad.MouseLeave, brmfiyat.MouseLeave, bslmatar.MouseLeave, btistar.MouseLeave, toptutar.MouseLeave, yapan.MouseLeave
        ana_p.BackColor = Color.White
    End Sub

End Class