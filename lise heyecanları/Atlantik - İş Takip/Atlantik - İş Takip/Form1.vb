Public Class Form1

    WithEvents a As New Windows.Forms.Button
    Dim oto As New oto_list(Me)

    Public ilgili As Label

    Dim aa As String

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim v As New Dökümbirim()
        Dim v1 As New Dökümbirim()
        Dim v2 As New Dökümbirim()
        Dim v3 As New Dökümbirim()

        Giriþ.Visible = False

        Dim tasýyýcý As New Zaman_Görüntüleyici


    End Sub



    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Giriþ.KeyPress
        Dim a As New ArrayList
        a.Add("asým")
        a.Add("doðan")
        a.Add("namlý")

        oto.görüntüle(a, Me.Giriþ)

        If e.KeyChar = CChar(vbCrLf) Then
            Giriþ.Text = oto.kapat(True)
            ilgili.Text = Giriþ.Text
            Giriþ.Text = ""
            Giriþ.Visible = False
        End If

    End Sub

    Private Sub TextBox1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Giriþ.KeyDown
        If e.KeyCode = Keys.Up Then
            oto.item_kaydýr(-1)
        ElseIf e.KeyCode = Keys.Down Then
            oto.item_kaydýr(1)
        End If
    End Sub

    Private Sub Form1_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseClick
        Týklanma()
    End Sub
End Class
