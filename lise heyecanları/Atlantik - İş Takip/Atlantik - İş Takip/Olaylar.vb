Public Class Birimkydırma

    Public Event Tick(ByVal no As Integer, ByVal yön As String)
    Public Event knm_tazele()

    Sub New()

    End Sub

    Sub Tickled(ByVal no As Integer, ByVal yön As String)
        RaiseEvent Tick(no, yön)
    End Sub

    Sub konum_tazele()
        RaiseEvent knm_tazele()
    End Sub

End Class