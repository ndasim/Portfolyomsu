Module Rapor

    Public sıkışmayanbytelar As Long
    Public topsünsıksay As Long
    Public topbelirteçsay As Long
    Public topsünsıkılmışbyte As Long
    Public sıkışmadanöncekiboyut As Long
    Public sıkıştıktansonrboyut As Long

    Sub rapor_göster()
        MsgBox("Sıkışmadan Önceki Boyut: " & sıkışmadanöncekiboyut & vbCrLf & "Sıkıştıktan Sonraki Boyut: " & sıkıştıktansonrboyut & vbCrLf & vbCrLf & "Toplam Kullanılan Sünger Sıkıştırma Sayısı: " & topsünsıksay & vbCrLf & "Sünger Sıkıştırmanın Sıkıştırdığı Byte Sayısı: " & topsünsıkılmışbyte & vbCrLf & vbCrLf & " Toplam Kullanılmış Belirteç Sayısı: " & topbelirteçsay & vbCrLf & "Sıkıştırılmamış Byte Sayısı :" & sıkışmayanbytelar)
    End Sub

End Module
