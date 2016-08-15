Public Class trigo

    Dim gr As Graphics
    Dim ii As Single

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click

        Timer1.Enabled = True

    End Sub



    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim i As Integer
        Dim x, xx, y As Single

        ii += 0.1

        xx = 1.5 - ii

        gr = PictureBox1.CreateGraphics
        gr.FillRectangle(Brushes.White, New Rectangle(0, 0, 300, 400))

        For i = 1 To 300
            x += 0.01
            xx += 0.01
            y = 24 + Math.Cos(xx) * 25
            gr.FillEllipse(Brushes.Black, New Rectangle(x * 15, y, 5, 5))
        Next
    End Sub

End Class