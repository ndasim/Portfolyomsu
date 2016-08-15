Public Class Form1

    Dim döngü As Boolean = True
    Dim başlama_biti As Long     ' yöntemlerde kullanmak üzere sıkıştırılmaya başlanaca byte'n dizin nosu

    Dim sıkıştırlmış_bytelar As New ArrayList
    Dim sıkışmayan_bytelar As New ArrayList      ' hiç bir yöntem tarafından kullanılamamış olan byte dizileridir

    Dim sınanmışbitler As Long
    Dim yazılacakbyte() As Byte


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim süngerbitler As New ArrayList()

        Dim i As Integer

        For i = 0 To 5000
            süngerbitler.Add(10)
        Next

        Dim a(süngerbitler.Count - 1) As Byte

        süngerbitler.CopyTo(a)

        My.Computer.FileSystem.WriteAllBytes(TextBox2.Text, a, False)

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        döngü = True

        aç(TextBox1.Text)

        yöntemleri_dene()

    End Sub

    Sub parçala()

    End Sub

    Sub harita_çıkar()  ' Amaç: dosyaya bir harita gözüyle bakıp genel olarak kullanılan byte'ları guruplandırmaktır

        Dim parça_sayısı As Integer
        Dim parça_dizisi As New ArrayList
        Dim kalan_byte As Integer

        Dim döngü As Boolean = False

        Dim başlama_nok As Integer
        Dim i As Integer

        parça_sayısı = sıkışcak_byte.Length / 1000

        Do While True
            ' bir parça alınıyor
            Do While döngü
                i += 1

                If Not (başlama_nok + i) < sıkışcak_byte.Length Then
                    parça_dizisi(i) = sıkışcak_byte(başlama_nok + i)
                Else
                    döngü = False
                End If

                If i = 1000 Then
                    döngü = False
                End If

            Loop

            ' Alınan parça işlemlerden geçiriliyor
            ' 5 bytlık en çok kullanılan parça aratılıyor

            Do While True
                Dim refnok As Integer
                Dim byte5(4) As Byte
                Dim byte5i(4) As Byte

                ' baştan 5 byte alınımı
                For i = 0 To 4
                    byte5(i) = parça_dizisi(refnok + i)
                Next

                ' Parça dizisinde taratılma

                For i = 0 To (parça_dizisi.Count / 5)
                    Dim ii As Integer

                    ' 5 byte alınımı
                    For ii = 0 To 4
                        byte5i(ii) = parça_dizisi(ii + i)
                    Next
                    ' Alınan 5 byte ile önceden belirlenen 5 bytın eşitliği kontrol edilmesi

                    If byte5 = byte5i Then

                    End If

                Next

            Loop
        Loop
    End Sub

    Sub yöntemleri_dene()

        Dim bytetip As Type

        Do While döngü

            Dim i As Long
            Dim a As New gelen_yanıt
            Dim işlemdengeçti As Boolean
            Dim sıradaki_byte As Byte

            sıradaki_byte = sıkışcak_byte(başlama_biti)

            '
            ' Amaç: bütün yöntemleri kullanarak bir dosya içindeki fuzuli byteları veya 
            '       bir kurala göre sıralanımış byte'ları tespit edip küçük paketlere sığdırmaktır
            '
            ' Paketleme kuralı şöyledir:
            ' Hepsi byte değeri olmak üzere;
            ' - Yöntem no - Yöntem verileri -
            '

            ' 1. Yöntem Sünger Sıkıştırma

            a = sünger(True, başlama_biti)

            If a.olumlu = True Then

                sıkışmayanları_paketle() ' Eğer bu yöntemden önce sıkıştırılamamış byte lar varsa bunları paketler    

                For i = 0 To 2
                    sıkıştırlmış_bytelar.Add(a.değer(i)) ' Paket değerleri sıkıştırılmış bytelar dizinine kopyalanıyor
                Next
                i = 0

                sınanmışbitler += a.sıkışmış_no   ' yöntemlerden geçirilmiş byte sayısı sünger sıkıştırmadan sıkışan byte kadar artırılıyor
                başlama_biti = sınanmışbitler     ' Bir sonraki yöntem denemesinde başlanacak byte dizi nosu belirleniyor
                işlemdengeçti = True              ' Bir önceki başlama dizin nosunun herhangi bir işlemden geçtiği belirtiliyor
            End If

            '
            '
            ' Yöntemler ...
            '
            '

            ' Eğer hiç bir yöntem tutmaz ise başlama dizin nosundaki byte sıkıştırılamamışlar listesine alınır ve bir sonraki dizine geçilir

            If işlemdengeçti = False Then
                sıkışmayan_byte_ekle(sıkışcak_byte(başlama_biti)) ' kullanılamayan byte listeye ekleniyor

                sınanmışbitler += 1
                başlama_biti = sınanmışbitler    ' bir sonraki dizine geçiliyor
            End If

            ' döngünün devam edebilirliği ve bazı değerlerin sıfırlanma işlemleri gerçekleştiliyor

            If (sıkışcak_byte.Length) - sınanmışbitler > 0 Then
                döngü = True
                işlemdengeçti = False

                '
                '
                ' Sıfırlanacak değerler
                '
                '

            Else
                sıkışmayanları_paketle()  ' eğer sıkışmamış kalmışsa paketler
                bitir()
            End If

        Loop

    End Sub

    Sub sıkışmayan_byte_ekle(ByVal bytee As Byte)
        sıkışmayan_bytelar.Add(bytee)
        sıkışmayanbytelar += 1
    End Sub

    Sub sıkışmayanları_paketle()

        '
        ' Amaç: Herhangi bir kurala sığmadan paketlenememiş byte dizisini bir belirteçle
        '       dosyaya eklemektir
        '       
        '     • iki byte lık veri uzunluğu belirme kapasitesine sahiptir ki sıkıştırılamayan bytlar 225'den büyük olduğu zaman ayriyetden belirtme verileriyle boyut büyümesin   


        Dim testdeğeri As Long
        Dim i As Long
        Dim sıkışmamış As Long
        Dim paket1değeri, paket2değeri As Short

        ' güvenlik amaçlı olarak sıkışmayan byte sayısı kontrol ediliyor

        If Not sıkışmayan_bytelar.Count = 0 Then

            sıkışmamış = sıkışmayan_bytelar.Count - 1  ' bir tabalı uzunluk verisini 0 tabanlı uzunluk verisine dönüştürme
            '                                            !! -- hata verebilir -- !! 

            Do While sıkışmamış > 0           ' döngüye basit bir kuralla başlanıyor

                If sıkışmamış > 255 Then      ' kontrol1: sıkışmamış değerinin 255'den büyüklüğü denetleniyor
                    paket1değeri = 255        ' Eğer 255'den büyükse birinci byte dizi uzunluğu 255 olarak belirleniyor 
                    sıkışmamış -= 255         ' sıkışmamış olarak belirlenen  birinci byte dizi uzunluğu 255 birim azaltılıyor 
                Else
                    paket1değeri = sıkışmamış ' Eğer kurala uymuyorsa birinci byte dizi uzunluğu belirleniyor
                    sıkışmamış = 0            ' sıkışpmayan veri uzunluğu sıfırlanıyor
                End If

                If sıkışmamış > 255 Then      ' kontrol2: sıkışmamış değerinin 255'den büyüklüğü denetleniyor
                    paket2değeri = 255        ' Eğer 255'den büyükse ikinci byte dizi uzunluğu 255 olarak belirleniyor 
                    sıkışmamış -= 255         ' sıkışmamış olarak belirlenen ikinci byte dizi uzunluğu 255 birim azaltılıyor 
                Else
                    paket2değeri = sıkışmamış ' Eğer kurala uymuyorsa ikinci byte dizi uzunluğu belirleniyor
                    sıkışmamış = 0            ' sıkışmayan veri uzunluğu sıfırlanıyor
                End If

                '
                ' Veriler paketleniyor:
                ' Kural: - 0 - birinci byte dizi uzunluğu - ikinci byte dizi uzunluğu - veri içeriği - 

                sıkıştırlmış_bytelar.Add(CByte(0))
                sıkıştırlmış_bytelar.Add(CByte(paket1değeri))
                sıkıştırlmış_bytelar.Add(CByte(paket2değeri))

                ' veri içeriği ekleniyor

                For i = 0 To paket1değeri + paket2değeri
                    sıkıştırlmış_bytelar.Add(sıkışmayan_bytelar(i))
                Next

                testdeğeri += paket1değeri + paket2değeri

                paket1değeri = 0
                paket2değeri = 0

                topbelirteçsay += 1

            Loop



            testdeğeri = 0

            sıkışmayan_bytelar.Clear()

        End If

    End Sub

    Sub bitir()

        ReDim yazılacakbyte(sıkıştırlmış_bytelar.Count - 1)
        sıkıştırlmış_bytelar.CopyTo(yazılacakbyte, 0)

        My.Computer.FileSystem.WriteAllBytes("C:\Users\Ev Bilgisayarı\Desktop\sünger.çsd", yazılacakbyte, False)

        yazdır(yazılacakbyte)

        sıkıştıktansonrboyut = yazılacakbyte.Length

        döngü = False

        rapor_göster()

    End Sub

    Private Sub TextBox1_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TextBox1.MouseClick, TextBox2.MouseClick
        OpenFileDialog1.Filter = "Bütün Dosya Tipleri | *.*"
        OpenFileDialog1.ShowDialog()
    End Sub

    Private Sub OpenFileDialog1_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        TextBox1.Text = OpenFileDialog1.FileName
    End Sub

    Private Sub Form1_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        Göstergec.Height = Me.Height - 155

    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub
End Class

Public Structure harita_parçası

    Public veri() As Byte

    Sub New(ByVal veri_parçası() As Byte)

    End Sub

End Structure
