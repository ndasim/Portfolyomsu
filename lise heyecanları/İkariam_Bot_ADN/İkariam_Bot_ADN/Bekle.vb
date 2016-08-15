Public Class Bekle

    Dim gr As Graphics

    Dim yüzde As Integer
    Dim syç As Integer
    Dim komut As String

    Private Sub Bekle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        gr = Me.CreateGraphics
        Başla()

        Me.Top = (My.Computer.Screen.WorkingArea.Height / 2) - (Me.Height / 2)
        Me.Left = (My.Computer.Screen.WorkingArea.Width / 2) - (Me.Width / 2)

    End Sub

    Sub Çıktı(ByVal s As String)

    End Sub

    Sub açma_komutu(ByVal kmt As String)

    End Sub

    Private Sub zamanlayıcı_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles zamanlayıcı.Tick
        Dim drm As String
        Dim Form As Form

        If Not syç = 61 Then
            syç += 1
        Else
            syç = 0
        End If

        PictureBox1.Image = bitt(syç)

        drm = Ortak.Kontrol.ReadyState

        Select Case drm
            Case 1
                PictureBox2.Width = 75
            Case 2
                PictureBox2.Width = 150
            Case 3
                PictureBox2.Width = 225
            Case 4
                PictureBox2.Width = 300

                If komut = "Adn" Then
                    Form = New Adn
                    Form.Show()
                ElseIf komut = "Ana" Then
                    Form = New Ana
                    Form.Show()
                ElseIf komut = "Ekran" Then
                    Form = New Ekran
                    Form.Show()
                End If

        End Select

    End Sub

End Class