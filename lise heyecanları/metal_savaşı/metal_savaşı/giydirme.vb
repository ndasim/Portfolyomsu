Public Class giydirme

    Dim iletgeç As iletişim

    Dim matrix(10000) As Bitmap

    Dim gösteren As PictureBox

    Sub New(ByVal göstergeç As PictureBox)

        gösteren = göstergeç

        göstergeci_giydir()

    End Sub

    Sub göstergeci_giydir()

        Dim i As Integer

        Dim gr As Graphics
        Dim gr2 As Graphics
        Dim kalıp As New Bitmap(20, 20)

        gr = Graphics.FromHdc(gösteren.CreateGraphics.GetHdc)
        gr2 = Graphics.FromImage(kalıp)
        gr2.FillRectangle(Brushes.White, New Rectangle(0, 0, 20, 20))
        Dim x As Integer = 0
        Dim y As Integer = 0

        For i = 1 To 10000

            matrix(i) = kalıp
            gr.DrawImage(matrix(i), New Point(x * 20, y * 20))

            x += 1

            If x = 100 Then
                y += 1
                x = 0
            End If

        Next

    End Sub

    Sub uyar()
        'iletgeç.yenilenme()
    End Sub


End Class

Public Class resim

    Dim giydirgeç As giydirme

    Dim koor As Point
    Dim anarekoord As Point

    WithEvents yenileyici As iletişim

    Dim res As New Bitmap(40, 20)

    Dim anares As New Bitmap(60, 40)

    Dim anaresçizdir As Graphics

    Sub New(ByVal giydirici As giydirme)

        anaresçizdir = Graphics.FromImage(anares)

    End Sub

    Sub hareket_et()

        If koor.X / 20 = 0 Then

        ElseIf koor.X / 20 = 0 Then


            anaresçizdir.DrawImage(res, koor.X - anarekoord.X, koor.Y - anarekoord.Y)

        End If

        '---------------------------'

        If koor.Y / 20 = 0 Then

        ElseIf koor.Y / 20 = 0 Then

        End If

    End Sub

    Private Sub yenileyici_yenile() Handles yenileyici.yenile

    End Sub

    Public Property koordinat() As Point
        Get
            Return koor
        End Get
        Set(ByVal value As Point)

        End Set
    End Property

End Class

Public Class iletişim

    Public Event yenile()

    Sub New()

    End Sub

    Sub yenilenme()
        RaiseEvent yenile()
    End Sub

End Class