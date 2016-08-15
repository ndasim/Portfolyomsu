Public Class oto_list

    WithEvents listeleyici As New ListBox
    WithEvents yazı_kutusu As New TextBox

    Dim eskindex, index As Integer

    Dim açık As Boolean

    Sub New(ByVal konum As Control)
        listeleyici.Parent = konum
        listeleyici.Visible = False
    End Sub

    Sub görüntüle(ByVal liste As ArrayList, ByRef kutu As TextBox)
        Dim i As Integer

        If açık = False Then
            yazı_kutusu = kutu

            For i = 0 To liste.Count - 1
                listeleyici.Items.Add(liste(i))
            Next

            With listeleyici
                .Top = kutu.Top + kutu.Height
                .Left = kutu.Left
                .Height = (liste.Count + 3) * 11
                .Visible = True
            End With

            açık = True

        End If

    End Sub

    Function kapat(ByVal göster As Boolean) As String
        Dim dönüt As String

        If göster = True Then
            dönüt = listeleyici.SelectedItem
        End If

        listeleyici.Visible = False
        açık = False
        listeleyici.Items.Clear()

        Return dönüt
    End Function

    Sub item_kaydır(ByVal yön As Short)
        Try
            index += yön
            listeleyici.SetSelected(index, True)
            eskindex = index

        Catch ex As Exception

        End Try
    End Sub

    Private Sub yazı_kutusu_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles yazı_kutusu.TextChanged

        index = listeleyici.FindString(yazı_kutusu.Text)

        If Not index = -1 Then

            listeleyici.SetSelected(index, True)
            eskindex = index

        Else

        End If

        If yazı_kutusu.Text = "" Then
            kapat(False)
        End If

    End Sub

    Private Sub listeleyici_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles listeleyici.DoubleClick
        yazı_kutusu.Text = listeleyici.SelectedItem
        kapat(False)
    End Sub
End Class

Public Class Taşıyıcı

    Public WithEvents zemin As Panel
    WithEvents zamnlyıcı As New Timer
    WithEvents ana As Control

    Dim farkx, farky As Integer
    Dim X, Y, X1, Y1 As Integer
    Dim refx, refy As Integer

    Dim üstünde As Boolean


    Sub New(ByVal anazemin As Control, ByVal açan As Object, Optional ByVal x As Integer = 0, Optional ByVal y As Integer = 0, Optional ByVal yükseklik As Integer = 100, Optional ByVal genişlik As Integer = 100)
        zemin = New Panel()

        zemin.Parent = anazemin

        zemin.Top = y
        zemin.Left = x
        zemin.Height = yükseklik
        zemin.Width = genişlik

        zamnlyıcı.Interval = 1

        ana = anazemin

    End Sub


    Private Sub zemin_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles zemin.MouseDown

        farkx = e.X
        farky = e.Y

        zamnlyıcı.Enabled = True
        üstünde = True
    End Sub

    Private Sub zemin_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles zemin.MouseMove

        X1 = e.X
        Y1 = e.Y

    End Sub

    Private Sub zemin_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles zemin.MouseUp
        üstünde = False
    End Sub

    Private Sub zamnlyıcı_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles zamnlyıcı.Tick

        If üstünde = True Then

            X = zemin.Location.X + X1
            Y = zemin.Location.Y + Y1

            zemin.Left = X - farkx
            zemin.Top = Y - farky

        End If

    End Sub

    Private Sub ana_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ana.MouseMove
        X = e.X
        Y = e.Y

    End Sub
End Class

Public Class Zaman_Görüntüleyici

    WithEvents taşıt As Taşıyıcı
    WithEvents zamanlayıcı As New Timer

    Dim göstergeç As New Label

    Dim zaman As Date

    Sub New()

        taşıt = New Taşıyıcı(Form1, Me, 300, 300)

        taşıt.zemin.BackColor = Color.Wheat

        zamanlayıcı.Interval = 1000
        zamanlayıcı.Enabled = True

        göstergeç.Parent = taşıt.zemin

    End Sub

    Private Sub zamanlayıcı_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles zamanlayıcı.Tick

        zaman = My.Computer.Clock.LocalTime
        göstergeç.Text = zaman.ToLongTimeString

    End Sub

End Class

Public Class İşçiler

End Class

Public Class Rapor

End Class

Public Class Notlar

End Class

Public Class Ajanda

End Class
