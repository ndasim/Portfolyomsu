Public Class Kriptol1n



    Private Sub Kriptol1n_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Function kriptol1n()
        Dim donut As String

        'Dim bytlist = My.Computer.FileSystem.ReadAllBytes(TextBox1.Text)

        'girdi.CopyTo(bytlist)

        Dim maske As New ArrayList

        Dim i As Integer
        Dim k As Integer = 0

        Dim girdi As ArrayList
        Dim anahtar As ArrayList
        Dim alphNums As ArrayList

        Dim id, id1, id2 As Integer

        Dim harf As String

        girdi = parcala(TextBox1.Text)
        alphNums = parcala("_.,:;!?%&()[]{}<>|$*-@#+\'^/\\=0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzİı ŞşĞğÇçÜüÖö")
        anahtar = parcala("KADİFE")

        For i = 0 To i < girdi.Count

            maske.Add(anahtar(k))

            If k < anahtar.Count - 1 Then
                k += 1
            Else
                k = 0
            End If

        Next

        For i = 0 To i < maske.Count

            id1 = alphNums.IndexOf(girdi(i))
            id2 = alphNums.IndexOf(maske(i))

            id = id1 + id2

            If id > alphNums.Count - 1 Then
                id -= alphNums.Count
            End If

            If id > alphNums.Count - 1 Then
                id -= alphNums.Count
            End If

            harf = alphNums(id)

            ' $harf = mb_substr($alphNums,$id,1,'UTF-8');

            donut &= harf
            '/*
            'echo() ' // ** Döngü'.$i.' ** // <br /> 
            '	* Girdi Harf = '.$girdi[$i].' : '.$id1.'<br />
            '	* Maske Harf = '.$maske[$i].' : '.$id2.'<br />
            '	* Sonuç Harf = '.$harf.': '.$id.' <br /><br />';
            '*/	
        Next
        '//echo ' Dönüt:'.$donut;

        Return donut

    End Function

    Function kriptol1n_coz()
        Dim donut As String

        'Dim bytlist = My.Computer.FileSystem.ReadAllBytes(TextBox2.Text)

        'girdi.CopyTo(bytlist)

        Dim maske As New ArrayList

        Dim i As Integer
        Dim k As Integer = 0

        Dim girdi As ArrayList
        Dim anahtar As ArrayList
        Dim alphNums As ArrayList

        Dim id, id1, id2 As Integer

        Dim harf As String

        girdi = parcala(TextBox2.Text)
        alphNums = parcala("_.,:;!?%&()[]{}<>|$*-@#+\'^/\\=0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzİı ŞşĞğÇçÜüÖö")
        anahtar = parcala("KADİFE")

        For i = 0 To i < girdi.Count

            maske.Add(anahtar(k))

            If k < anahtar.Count - 1 Then
                k += 1
            Else
                k = 0
            End If

        Next

        For i = 0 To i < maske.Count

            id1 = alphNums.IndexOf(girdi(i))
            id2 = alphNums.IndexOf(maske(i))

			id = id1 - id2;

            If id < 0 Then
                id = alphNums.Count + id
            End If

            If id < 0 Then
                id = alphNums.Count + id
            End If

            harf = alphNums(id)

            ' $harf = mb_substr($alphNums,$id,1,'UTF-8');

            donut &= harf
            '/*
            'echo() ' // ** Döngü'.$i.' ** // <br /> 
            '	* Girdi Harf = '.$girdi[$i].' : '.$id1.'<br />
            '	* Maske Harf = '.$maske[$i].' : '.$id2.'<br />
            '	* Sonuç Harf = '.$harf.': '.$id.' <br /><br />';
            '*/	
        Next
        '//echo ' Dönüt:'.$donut;

        Return donut

    End Function

    Function parcala(ByVal girdi As String) As ArrayList
        Dim dönüt = New ArrayList
        Dim i As Integer

        For i = 0 To i < girdi.Length
            dönüt.Add(girdi.Substring(i, 1))
        Next

        Return dönüt
    End Function

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub TextBox1_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TextBox1.MouseClick, TextBox2.MouseClick
        OpenFileDialog1.Filter = "Bütün Dosya Tipleri | *.*"
        OpenFileDialog1.ShowDialog()
    End Sub

    Private Sub OpenFileDialog1_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        TextBox1.Text = OpenFileDialog1.FileName
    End Sub

End Class
