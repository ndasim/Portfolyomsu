Public Class hoşgeldiniz
    Dim b As New UserControl
    Dim i As Integer
    Dim p1 As Integer = 0
    Dim p2 As Integer = 300
    Dim a As TextBox
    Private Sub hoşgeldiniz_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim a As Point
        a.X = 500
        a.Y = 300
        Me.Location = a
        Timer1.Enabled = True
        profil.Show()
        yeni_proje.Show()
    End Sub

    Private Sub hoşgeldiniz_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate

    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click
        Me.b = New Dekorist.çizim_tarlası
        b.Parent = Me
        b.Show()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim a, b, c, d As Point
        p1 = p1 - 1
        p2 = p2 - 1
        If p1 = -300 Then
            p1 = 300
        End If
        If p2 = -300 Then
            p2 = 300
        End If
        ' panel 1
        a.X = 0
        a.Y = p1
        Panel1.Location = a
        ' panel 2
        b.X = 0
        b.Y = p2
        Panel2.Location = b
        ' panel 3
        c.X = 315
        c.Y = p2
        Panel3.Location = c
        ' panel 4
        d.X = 315
        d.Y = p1
        Panel4.Location = d
        TextBox1.Text = p1
        TextBox2.Text = p2
    End Sub
End Class


