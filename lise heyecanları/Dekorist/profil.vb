Imports System.Text

Public Class profil
    Dim a As Integer
    Private Function kayıt(ByVal cümle As String, ByVal cümleninsahibi As String)
        Dim a As Integer
        Dim at As String
        Dim au As Integer
        a = RichTextBox1.Find(cümleninsahibi)
        If a = -1 Then
            RichTextBox1.Text = RichTextBox1.Text & vbCrLf & cümleninsahibi & ":"
            a = RichTextBox1.Find(cümleninsahibi)
        End If
        at = cümleninsahibi
        au = at.Length + 1
        RichTextBox1.Select(a + au, 99)
        RichTextBox1.SelectedText = cümle
        TextBox3.Text = a
        TextBox4.Text = au
        TextBox5.Text = at
        Return a
    End Function
    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        Dim aç As New OpenFileDialog
        aç.Filter = "Resim Dosyası(*.jpg;*.png;*.bmp;*.tif;*.tiff)|*.jpg;*.png;*.bmp;*.tif;*.tiff"
        If (aç.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            a = aç.FileName
            PictureBox1.Load(a)
            resimkayıt(a)
        End If
    End Sub
    Sub resimkayıt(ByVal yol As String)
        Kill("C:\ADN Yazılım\Dekorist\Dekorist\Firma Amblebi.png")
        FileCopy(a, "C:\ADN Yazılım\Dekorist\Dekorist\Firma Amblebi.png")
    End Sub

    Private Sub profil_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        PictureBox1.Load("C:\ADN Yazılım\Dekorist\Dekorist\Firma Amblebi.png")
        FileOpen(1, "C:\ADN Yazılım\Dekorist\Dekorist\profil.dkb", OpenMode.Input)
        Input(1, RichTextBox1.Text)
        FileClose(1)
    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click
        yeni_değer.yayınla(Label3.Text, "Lütfen şirketinizin adını giriniz:", "Profil işlemleri", Label3, False)
    End Sub

    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click
        yeni_değer.yayınla(Label4.Text, "   Lütfen şirketinizin çalışmakda " & vbCrLf & "olduğu alanı giriniz:", "Profil işlemleri", Label4, False)
    End Sub

    Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label6.Click
        yeni_değer.yayınla(Label6.Text, "Lütfen şirketinizin kuruluş tarihini" & vbCrLf & " giriniz:", "Profil işlemleri", Label6, True)
    End Sub

    Private Sub Label8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label8.Click
        yeni_değer.yayınla(Label8.Text, "Lütfen şirketinizin kurucusunun adını" & vbCrLf & " giriniz:", "Profil işlemleri", Label8, False)
    End Sub

    Private Sub Label10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label10.Click
        yeni_değer.yayınla(Label10.Text, "    Lütfen kendi adınızı giriniz:", "Profil işlemleri", Label10, False)
    End Sub

    Private Sub Label12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label12.Click
        yeni_değer.yayınla(Label12.Text, "  Lütfen kendi soyadınızı giriniz", "Profil işlemleri", Label12, False)
    End Sub

    Private Sub Label14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label14.Click
        yeni_değer.yayınla(Label14.Text, "    Lütfen çalışmakda olduğunuz " & vbCrLf & " şirketdeki yerinizi giriniz", "Profil işlemleri", Label14, False)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

    End Sub

    Private Sub Label3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.TextChanged
        kayıt(Label3.Text, "label3")
    End Sub

    Private Sub Label4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.TextChanged
        kayıt(Label4.Text, "label4")
    End Sub

    Private Sub Label6_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label6.TextChanged
        kayıt(Label6.Text, "label6")
    End Sub

    Private Sub Label8_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label8.TextChanged
        kayıt(Label8.Text, "label8")
    End Sub

    Private Sub Label10_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label10.TextChanged
        kayıt(Label10.Text, "label10")
    End Sub

    Private Sub Label12_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label12.TextChanged
        kayıt(Label12.Text, "label12")
    End Sub

    Private Sub Label14_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label14.TextChanged
        kayıt(Label14.Text, "label14")
    End Sub

    Private Sub profil_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        FileOpen(1, "C:\ADN Yazılım\Dekorist\Dekorist\profil.dkb", OpenMode.Output)
        Write(1, RichTextBox1.Text)
        WriteLine(1, TextBox1.Text)
        FileClose(1)
    End Sub

    Private Sub açılış()

    End Sub
End Class