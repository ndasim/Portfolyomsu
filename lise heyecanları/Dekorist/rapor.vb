Public Class rapor
    Dim listereferansnoktası, listesayfaebatları, listeikisayfaarası, hız, belgesayısı1 As Double

    Private Sub rapor_MouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseWheel
        If e.Delta < 0 And VScrollBar2.Value < VScrollBar2.Maximum Then
            VScrollBar2.Value = VScrollBar2.Value + 1
            listereferansnoktası = listereferansnoktası - hız
        End If
        If e.Delta > 0 And VScrollBar2.Value > VScrollBar2.Minimum Then
            VScrollBar2.Value = VScrollBar2.Value - 1
            listereferansnoktası = listereferansnoktası + hız
        End If
        PrintPreviewControl1.Top = listereferansnoktası
        PrintPreviewControl2.Top = PrintPreviewControl1.Top + PrintPreviewControl1.Size.Height + 44
        PrintPreviewControl3.Top = PrintPreviewControl2.Top + PrintPreviewControl1.Size.Height + 44
        PrintPreviewControl4.Top = PrintPreviewControl3.Top + PrintPreviewControl1.Size.Height + 44
        PrintPreviewControl5.Top = PrintPreviewControl4.Top + PrintPreviewControl1.Size.Height + 44
        PrintPreviewControl6.Top = PrintPreviewControl5.Top + PrintPreviewControl1.Size.Height + 44
    End Sub

    Private Sub rapor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        hazırla(3, ListBox1)
    End Sub
    Sub hazırla(ByVal belgesayısı As Integer, ByVal liste As ListBox)
        listereferansnoktası = 50
1:
        ' -- dosyaları açma -- '
2:
        ' -- değişkenleri yükleme -- '

3:
        ' -- otomatik tasarım düzenleme -- '

        PrintPreviewControl1.Top = listereferansnoktası
        PrintPreviewControl2.Top = PrintPreviewControl1.Top + PrintPreviewControl1.Size.Height + listereferansnoktası
        PrintPreviewControl3.Top = PrintPreviewControl2.Top + PrintPreviewControl1.Size.Height + listereferansnoktası
        PrintPreviewControl4.Top = PrintPreviewControl3.Top + PrintPreviewControl1.Size.Height + listereferansnoktası
        PrintPreviewControl5.Top = PrintPreviewControl4.Top + PrintPreviewControl1.Size.Height + listereferansnoktası
        PrintPreviewControl6.Top = PrintPreviewControl5.Top + PrintPreviewControl1.Size.Height + listereferansnoktası

        If belgesayısı = 2 Then
            PrintPreviewControl2.Top = PrintPreviewControl1.Top + PrintPreviewControl1.Size.Height + listereferansnoktası
            PrintPreviewControl2.Visible = True
            hız = (listereferansnoktası + PrintPreviewControl2.Top - 100) / 100
        ElseIf belgesayısı = 3 Then
            PrintPreviewControl3.Visible = True
            PrintPreviewControl2.Visible = True
            hız = (listereferansnoktası + PrintPreviewControl3.Top - 100) / 100
        ElseIf belgesayısı = 4 Then
            hız = (listereferansnoktası + PrintPreviewControl4.Top - 100) / 100
            PrintPreviewControl4.Visible = True
            PrintPreviewControl3.Visible = True
            PrintPreviewControl2.Visible = True
        ElseIf belgesayısı = 5 Then
            hız = (listereferansnoktası + PrintPreviewControl5.Top - 100) / 100
            PrintPreviewControl5.Visible = True
            PrintPreviewControl4.Visible = True
            PrintPreviewControl3.Visible = True
            PrintPreviewControl2.Visible = True
        ElseIf belgesayısı = 6 Then
            hız = (listereferansnoktası + PrintPreviewControl6.Top - 100) / 100
            PrintPreviewControl6.Visible = True
            PrintPreviewControl5.Visible = True
            PrintPreviewControl4.Visible = True
            PrintPreviewControl3.Visible = True
            PrintPreviewControl2.Visible = True
        End If


    End Sub

    Private Sub VScrollBar2_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles VScrollBar2.Scroll
        listereferansnoktası = -(hız * VScrollBar2.Value) + 50
        TextBox1.Text = hız * VScrollBar2.Value
        TextBox2.Text = PrintPreviewControl6.Top
        PrintPreviewControl1.Top = listereferansnoktası
        PrintPreviewControl2.Top = PrintPreviewControl1.Top + PrintPreviewControl1.Size.Height + 50
        PrintPreviewControl3.Top = PrintPreviewControl2.Top + PrintPreviewControl1.Size.Height + 50
        PrintPreviewControl4.Top = PrintPreviewControl3.Top + PrintPreviewControl1.Size.Height + 50
        PrintPreviewControl5.Top = PrintPreviewControl4.Top + PrintPreviewControl1.Size.Height + 50
        PrintPreviewControl6.Top = PrintPreviewControl5.Top + PrintPreviewControl1.Size.Height + 50
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

    End Sub
End Class