Public Class yeni_değer
    Dim öğe1 As Label
    Dim tarih1 As Boolean
    Public Sub yayınla(ByVal yenideğer As String, ByVal açıklama As String, ByVal konu As String, ByVal öğe As Label, ByVal tarih As Boolean)
        Me.TextBox1.Text = yenideğer
        Me.Label1.Text = açıklama
        Me.Text = konu
        Me.Show()
        öğe1 = öğe
        tarih1 = tarih
        If tarih = True Then
            TextBox1.Visible = False
            DateTimePicker1.Visible = True
        End If
        If tarih = False Then
            TextBox1.Visible = True
            DateTimePicker1.Visible = False
        End If

    End Sub

    Private Sub yeni_değer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If tarih1 = True Then
            TextBox1.Text = DateTimePicker1.Value

        End If
        öğe1.Text = TextBox1.Text
        Me.Hide()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Hide()
    End Sub
End Class