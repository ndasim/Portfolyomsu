Module Ortak

    Public mermlr As New ArrayList

    Public krktrlrA As New ArrayList
    Public krktrlrB As New ArrayList

    Public gr As Grafik.Toplayıcı

    Public resdizin As String = AppDomain.CurrentDomain.BaseDirectory & "\res"

    Sub Çıktı(ByVal s As String)

        Aktif_nesne.ListBox1.Items.Add(s)

    End Sub

End Module
