Public Class fiz

    Dim sanalharit(40, 40) As renk
    Dim krlm As Boolean
    Dim başlamax, başlamay As Integer
    Dim gr As Graphics

    Private Sub PictureBox1_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseMove
        Dim xx, yy As Integer

        X.Text = e.X
        Y.Text = e.Y

        xx = e.X / 10
        yy = e.Y / 10

        If krlm = True Then

            Try
                Adı.Text = xx & yy
                ddeğer0.Text = sanalharit(e.X / 10, e.Y / 10).değer_0_
                ddeğer1.Text = sanalharit(e.X / 10, e.Y / 10).değer_1_
                ddeğer2.Text = sanalharit(e.X / 10, e.Y / 10).değer_2_
                ddeğer3.Text = sanalharit(e.X / 10, e.Y / 10).değer_3_
            Catch ex As Exception

            End Try

        End If


    End Sub

    Sub renklendir()
        Dim i As Integer
        Dim x, y As Integer
        Dim dönüt As Boolean = True

            Do While dönüt
                If x = 40 Then
                    y += 1
                    x = 0
                Else
                    x += 1
                End If
                If y = 40 Then
                    dönüt = False
                End If
            Try
                If RadioButton1.Checked = True Then
                    If Not sanalharit(x, y).değer_0_ = 0 Then
                        gr.FillRectangle(Brushes.Blue, New Rectangle((x * 10 + 1), (y * 10 + 1), 9, 9))
                    Else
                        gr.FillRectangle(Brushes.Snow, New Rectangle((x * 10 + 1), (y * 10 + 1), 9, 9))
                    End If
                End If

                If RadioButton2.Checked = True Then
                    If Not sanalharit(x, y).değer_1_ = 0 Then
                        gr.FillRectangle(Brushes.Blue, New Rectangle((x * 10 + 1), (y * 10 + 1), 9, 9))
                    Else
                        gr.FillRectangle(Brushes.Snow, New Rectangle((x * 10 + 1), (y * 10 + 1), 9, 9))
                    End If
                End If

                If RadioButton3.Checked = True Then
                    If Not sanalharit(x, y).değer_2_ = 0 Then
                        gr.FillRectangle(Brushes.Blue, New Rectangle((x * 10 + 1), (y * 10 + 1), 9, 9))
                    Else
                        gr.FillRectangle(Brushes.Snow, New Rectangle((x * 10 + 1), (y * 10 + 1), 9, 9))
                    End If
                End If

                If RadioButton4.Checked = True Then
                    If Not sanalharit(x, y).değer_3_ = 0 Then
                        gr.FillRectangle(Brushes.Blue, New Rectangle((x * 10 + 1), (y * 10 + 1), 9, 9))
                    Else
                        gr.FillRectangle(Brushes.Snow, New Rectangle((x * 10 + 1), (y * 10 + 1), 9, 9))
                    End If
                End If
            Catch ex As Exception
                dönüt = False
                MsgBox("hata")
            End Try
            Loop

    End Sub

    Sub sanalharitkur()
        Dim x, y As Integer
        Dim dönüt As Boolean = True

        Do While dönüt
            If x = 40 Then
                y += 1
                x = 0
            Else
                x += 1
            End If
            If y = 40 Then
                dönüt = False
            End If
            Try
                sanalharit(x, y) = fiziksharit.noktanın_değerin_oku(başlamax + x, başlamay + y)
            Catch ex As Exception
                dönüt = False
                MsgBox("hata")
            End Try
        Loop

        krlm = True

    End Sub

    Sub bölmeleri_doldur()

    End Sub

    Sub bölmelere_ayır()

        Dim i As Integer

        ' Dikeyler

        For i = 1 To 40
            gr.DrawLine(Pens.Black, i * 10, 0, i * 10, 400)
        Next

        i = 0

        ' Yataylar

        For i = 1 To 40
            gr.DrawLine(Pens.Black, 0, i * 10, 400, i * 10)
        Next



    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click

        bölmelere_ayır()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        başlamax = hedefx.Text
        başlamay = hedefy.Text
        sanalharitkur()
        renklendir()
    End Sub

    Private Sub fiz_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        aktive_et()

        gr = PictureBox1.CreateGraphics

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        fiziksharit.noktaya_değer_Ata(hedefxx.Text, hedefyy.Text, New renk(d0.Text, d1.Text, d2.Text, d3.Text))
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        Label6.Enabled = True
        süre.Enabled = True
        Timer1.Interval = süre.Text
        Timer1.Enabled = True
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        başlamax = hedefx.Text
        başlamay = hedefy.Text
        sanalharitkur()
        renklendir()
    End Sub

    Private Sub süre_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles süre.TextChanged
        Timer1.Interval = süre.Text
    End Sub
End Class