Module Yöntemler

    Public sıkışcak_byte() As Byte
    Dim sıkışmış_byte As Array
    Dim sıkışmış_byte_sayısı As Long
    Dim eklenck_yeni_bitno As Long

    Dim uygulnmış_yntmler As ArrayList

    Structure gelen_yanıt

        Dim olumlu As Boolean
        Dim değer() As Byte
        Dim sıkışmış_no As Long

    End Structure

    Structure yöntem
        Dim no As Integer
        Dim veri1, veri2, veri3, veri4 As Byte
        Dim uzunveri1(), uzunveri2() As Byte

        Sub New(ByVal yöntm_no As Integer)
            no = yöntm_no
        End Sub

    End Structure

    Function sünger(ByVal sıkma As Boolean, ByVal başlama_dizno As Long) As gelen_yanıt
        Dim a As New gelen_yanıt
        Dim sıkışan As Long
        Dim veri(2) As Byte
        Dim sıkışanbyte As Byte
        Dim döngü As Boolean
        Dim doskalanbyte As Long

        ' Amaç: Dosya içinde var olan 3 veya 4 den fazla ard arda gelen 225 den büyük 
        '       olamamak şartı ile ard arda gelen aynı byte'ları 3 byte'lık pakete sıkıştırmaktır 

        If sıkma = True Then

            ' dosyada kalan byte sayısı hesaplanıyor

            doskalanbyte = (sıkışcak_byte.Length - 1) - başlama_dizno

            If doskalanbyte > 3 Then  ' Dosyada kalan byte sayısının 3 den büyük olması gerekiyor 

                If sıkışcak_byte(başlama_dizno) = sıkışcak_byte(başlama_dizno + 1) Then         ' başlama dizinnodan beriye doğru ilk 3 hatta 4 byte'ın birbirine eşit olması gerekmektedir ki paket uzunuluğu zarara uğratmasın
                    If sıkışcak_byte(başlama_dizno + 1) = sıkışcak_byte(başlama_dizno + 2) Then ' 3.byte'n kontrolü 

                        a.olumlu = True  ' Çıkan paketin olumlu olduğu belirtiliyor

                        sıkışanbyte = sıkışcak_byte(başlama_dizno) ' sıkıştırılan byte: başlma dizininde bulunan byte dır 

                        döngü = True

                        Do While döngü                      ' başlama dizininden başlanarak birer birer bütün bitler taratılır
                            If sıkışan < doskalanbyte Then  ' dosyada kalan byte sayısının sıkışan byte sayısından büyük olması gerekmektedir
                                If sıkışcak_byte(başlama_dizno + sıkışan) = sıkışcak_byte(başlama_dizno + sıkışan + 1) Then  ' taranan yeni bytelerin önceki bytle aynı olup olmadığı -taratılan byte'la- kontrol ediliyor
                                    If sıkışan < 254 Then   ' eğer sıkışan byte sayısı 254 'den küçük ise sıkışan sayısı 1 artırılır - Nedeni: Sıkışan 1 byte olarak pakete ekleneceğinden sıkışan byte sayısının 255 den küçük olması gerekmektedir-   
                                        sıkışan += 1
                                    Else
                                        döngü = False
                                    End If
                                Else
                                    döngü = False
                                End If
                            Else
                                döngü = False
                            End If

                        Loop

                        a.sıkışmış_no = sıkışan + 1         ' dönüte sıkışmış olan byte sayısı eklenyor - !! + 1 kısmı kaldırılabliir deney sonuçları gerek duydurtmuyor !! - 

                        ' paket oluşturma
                        '
                        ' Paketleme kuralı: - Paket no - Sıkıştırılmaya çalışılan byte - Sıkışan byte sayısı -
                        '

                        veri(0) = CByte(1)                  ' sıkıştırma türno: 1 sünger sıkıştırmanın temsil etdiği sayıdır
                        veri(1) = sıkışanbyte               ' sıkıştırılan byte giriliyor : sıkıştırma boyunca kullanılan byte
                        veri(2) = CByte(sıkışan + 1)        ' pakete sıkışmış olan byte sayısı ekleniyor - !! + 1 kısmı kaldırılabliir deney sonuçları gerek duydurtmuyor !! - 

                        topsünsıkılmışbyte += sıkışan + 1   ' ortak sıkıştırılmış byte sayısı giriliyor - !! + 1 kısmı kaldırılabliir deney sonuçları gerek duydurtmuyor !! -
                        topsünsıksay += 1                   ' istatiksel bilgilere toplam kullanılmış sünger sıkıştırma sayısı artırılıyor

                        a.değer = veri                      ' son olarak dönüte paket veri ekleniyor
                    Else
                        a.olumlu = False
                    End If
                Else
                    a.olumlu = False
                End If

            End If
        End If

        Return a
    End Function

    Function sünger_sıkıştırma()

    End Function

    Function paketlere_ayır(ByVal okunacak() As Byte) As ArrayList
        '
        ' Amaç: Okumaya yardımcı olamak için dosya içindeki paketleri ayırır
        '

        Dim başlama_no As Long
        Dim yöntm_no As Long
        Dim yöntm As yöntem
        Dim yöntm_list As New ArrayList

        ' Ayrıştırma

        başlama_no = 0

        Do While başlama_no < okunacak.Length

            yöntm_no = okunacak(başlama_no)   ' Dosya içindeki bir sonraki Paketin yntm nosu belirleniyor

            ' Belirlenen yöntem numarasının ilgilendiği yöntem tespit ediliyor

            If yöntm_no = 0 Then
                Dim vri_uznlğu, i As Integer

                yöntm = New yöntem(0)
                yöntm.veri1 = okunacak(başlama_no + 1)
                yöntm.veri2 = okunacak(başlama_no + 2)

                vri_uznlğu = yöntm.veri1 + yöntm.veri2

                ReDim yöntm.uzunveri1(vri_uznlğu - 1) ' -1'n nedeni 0 tabanına çeviri yapmak için

                For i = 0 To vri_uznlğu - 1
                    yöntm.uzunveri1(i) = okunacak(başlama_no + 3 + i)
                Next

                '
                '
                '
                ' Hatalar çıkabilir deneylere devam
                '
                '
                '

                başlama_no += 3

                yöntm_list.Add(yöntm)

            ElseIf yöntm_no = 1 Then

                yöntm = New yöntem(1)
                yöntm.veri1 = okunacak(başlama_no + 1)
                yöntm.veri2 = okunacak(başlama_no + 2)
                başlama_no += 3

                yöntm_list.Add(yöntm)

            ElseIf yöntm_no = 2 Then

            End If

            Application.DoEvents()

        Loop

        Return yöntm_list

    End Function

    Function paketleri_göster()

        Dim i As Integer
        Dim yntmad, veri As String
        Dim yntm As yöntem

        For i = 0 To uygulnmış_yntmler.Count  ' hata verebilir
            yntm = uygulnmış_yntmler(i)

            Select Case yntm.no
                Case 0
                    ' Ayraç verinin geniş listesi anlaşılır hale getiriliyor
                    Dim ii, bosluk As Integer
                    Dim bytee As String

                    For ii = 0 To yntm.uzunveri1.Length ' Array listesinden Byte'lar teker teker okunuyor ve işleniyor

                        bytee = yntm.uzunveri1(ii)      ' İlgili Byte okunuyor
                        bosluk = 4 - bytee.Length       ' 4 den okunan byte değerinin genişliği çıkarılıyor ki görüntülenirken rakamların bir dizi görüntülemek için
                        veri += bytee & Space(bosluk)   ' Okunan byte veri ye ekleniyor ve araya çıkarmaisleminden kalan sayı kadar bosluk ekleniyor

                    Next

                    ' Ayraç verileri görüntüleniyor

                    Form1.Göstergec.Text += vbCrLf & "  ***  ***  Ayraç  ***  ***  "
                    Form1.Göstergec.Text += vbCrLf & "    1. Veri Uzunluğu: " & yntm.veri1
                    Form1.Göstergec.Text += vbCrLf & "    2. Veri Uzunluğu: " & yntm.veri2
                    Form1.Göstergec.Text += vbCrLf & "    Veri            : " & veri
                Case 1

                    ' Sünger sıkıştırma verileri görüntüleniyor

                    Form1.Göstergec.Text += vbCrLf & "  ***  ***  Sünger Sıkıştırma  ***  ***  "
                    Form1.Göstergec.Text += vbCrLf & "    Sıkıştırılan : " & yntm.veri1
                    Form1.Göstergec.Text += vbCrLf & "    Sıkıştırılmış: " & yntm.veri2
            End Select



        Next

    End Function

    Sub yazdır(ByVal bitler() As Byte)
        Dim i As Long
        Dim boşluk As Short
        Dim bytdeğeri As String
        Dim x As Long = 0
        Dim a As ArrayList

        a = paketlere_ayır(bitler)


        For i = 0 To bitler.Length - 1

            bytdeğeri = CStr(bitler(i))

            If bytdeğeri.Length < 2 Then
                boşluk = 4
            ElseIf bytdeğeri.Length < 3 Then
                boşluk = 3
            ElseIf bytdeğeri.Length = 3 Then
                boşluk = 2
            End If

            x += 1

            If x = 39 Then
                Form1.Göstergec.Text += vbCrLf & Space(boşluk) & bytdeğeri
                x = 0
            Else
                Form1.Göstergec.Text += Space(boşluk) & bytdeğeri
            End If

        Next i

        Form1.Göstergec.Text += vbCrLf & vbCrLf

        For i = 0 To 39
            Form1.Göstergec.Text += "*"
        Next

        Form1.Göstergec.Text += vbCrLf & vbCrLf

        MsgBox("tmm")
    End Sub

    Function belirteç(ByVal başlama As Long, ByVal uzunluk As Byte) As gelen_yanıt
        Dim a As New gelen_yanıt




    End Function

    Sub aç(ByVal dosya_yolu As String)
        sıkışcak_byte = My.Computer.FileSystem.ReadAllBytes(dosya_yolu)
        sıkışmadanöncekiboyut = sıkışcak_byte.Length
    End Sub

End Module
