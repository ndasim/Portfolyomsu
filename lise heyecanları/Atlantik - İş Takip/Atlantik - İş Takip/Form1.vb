Public Class Form1

    WithEvents a As New Windows.Forms.Button
    Dim oto As New oto_list(Me)

    Public ilgili As Label

    Dim aa As String

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim v As New D�k�mbirim()
        Dim v1 As New D�k�mbirim()
        Dim v2 As New D�k�mbirim()
        Dim v3 As New D�k�mbirim()

        Giri�.Visible = False

        Dim tas�y�c� As New Zaman_G�r�nt�leyici


    End Sub



    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Giri�.KeyPress
        Dim a As New ArrayList
        a.Add("as�m")
        a.Add("do�an")
        a.Add("naml�")

        oto.g�r�nt�le(a, Me.Giri�)

        If e.KeyChar = CChar(vbCrLf) Then
            Giri�.Text = oto.kapat(True)
            ilgili.Text = Giri�.Text
            Giri�.Text = ""
            Giri�.Visible = False
        End If

    End Sub

    Private Sub TextBox1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Giri�.KeyDown
        If e.KeyCode = Keys.Up Then
            oto.item_kayd�r(-1)
        ElseIf e.KeyCode = Keys.Down Then
            oto.item_kayd�r(1)
        End If
    End Sub

    Private Sub Form1_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseClick
        T�klanma()
    End Sub
End Class
