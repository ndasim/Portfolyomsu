Public Class araçlar
    Dim dosyaadı As String
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        ColorDialog1.ShowDialog()
        Panel2.BackColor = ColorDialog1.Color
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        ColorDialog1.ShowDialog()
        Panel3.BackColor = ColorDialog1.Color
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        ColorDialog1.ShowDialog()
        Label4.ForeColor = ColorDialog1.Color
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub araçlar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Panel2.BackColor = Me.BackColor
        Panel3.BackColor = Color.DarkOrange
        Label4.ForeColor = Color.DarkRed
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        dosyaadı = CurDir() & "\ayarlar.öpd"
        FileOpen(1, dosyaadı, OpenMode.Output)

        FileClose(1)
        MsgBox(dosyaadı)
    End Sub
End Class