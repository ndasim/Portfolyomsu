Module kaydırma

    Sub aç(ByVal no As Integer)
        Dim nsne As Dökümbirim
        nsne = birimler(no)

        nsne.ayrınt_pnl_yönt()

    End Sub

    Sub Y_Kaydırma(ByVal no As Integer, ByVal yön As String)
        Dim i As Integer
        Dim nsne As Dökümbirim

        For i = no + 1 To birimler.Count - 1
            nsne = birimler(i)

            If yön = "Aç" Then
                nsne.y += 100
                nsne.Kay()
            Else
                nsne.y -= 100
                nsne.Kay()
            End If

        Next
    End Sub

End Module