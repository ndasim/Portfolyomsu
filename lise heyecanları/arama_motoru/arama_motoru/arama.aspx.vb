Public Partial Class WebForm1
    Inherits System.Web.UI.Page

    Dim syfno As String
    Dim aranan As String
    Dim panel As New Web.UI.WebControls.Panel

    Dim aramayd, sayfayd As Boolean

    Dim i As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        aranan = Request.QueryString("arama")
        sayfa_no = Request.QueryString("sayfa_no")

        detay.Text = "Arama Detayları:    Yaklaşık " & bulunmuşlar.Count & " Sonuç Arasından " & (sayfa_no * 5) - 5 & "-" & (sayfa_no * 5) & " arasındaki sonuçlar görüntülenmektedir"

        If sayfa_no = 1 Then
            geri.Enabled = False
        Else
            geri.Enabled = True
        End If
        If sayfa_no > (bulunmuşlar.Count / 5) Then
            ileri.Enabled = False
        End If

        If bulunmuşlar.Count = 1 Then
            MsgBox("tmm")
            aktiviteleri_kapat()
        Else
            yerleştir()
        End If

    End Sub

    Sub aktiviteleri_kapat()
        HyperLink1.Visible = False
        HyperLink2.Visible = False
        HyperLink3.Visible = False
        HyperLink4.Visible = False
        HyperLink5.Visible = False

        Label1.Visible = False
        Label2.Visible = False
        Label3.Visible = False
        Label4.Visible = False
        Label5.Visible = False
        Label6.Visible = False
        Label7.Visible = False
        Label8.Visible = False
        Label9.Visible = False
        Label10.Visible = False
    End Sub

    Sub yerleştir()

        Dim i As Integer
        i = sayfa_no * 5 - 5

        Try
            HyperLink1.NavigateUrl = bulunmuşlar(i).bağlantı
            HyperLink1.Text = bulunmuşlar(i).başlık_etiketi
            Label1.Text = bulunmuşlar(i).sayfa_içeriği
            Label2.Text = bulunmuşlar(i).bağlantı
        Catch ex As Exception
            HyperLink1.Visible = False
            Label1.Visible = False
            Label2.Visible = False
        End Try
        Try
            HyperLink2.NavigateUrl = bulunmuşlar(i + 1).bağlantı
            HyperLink2.Text = bulunmuşlar(i + 1).başlık_etiketi
            Label3.Text = bulunmuşlar(i + 1).sayfa_içeriği
            Label4.Text = bulunmuşlar(i + 1).bağlantı
        Catch ex As Exception
            HyperLink2.Visible = False
            Label3.Visible = False
            Label4.Visible = False
        End Try


        Try
            HyperLink3.NavigateUrl = bulunmuşlar(i + 2).bağlantı
            HyperLink3.Text = bulunmuşlar(i + 2).başlık_etiketi
            Label5.Text = bulunmuşlar(i + 2).sayfa_içeriği
            Label6.Text = bulunmuşlar(i + 2).bağlantı
        Catch ex As Exception
            HyperLink3.Visible = False
            Label5.Visible = False
            Label6.Visible = False
        End Try

        Try
            HyperLink4.NavigateUrl = bulunmuşlar(i + 3).bağlantı
            HyperLink4.Text = bulunmuşlar(i + 3).başlık_etiketi
            Label7.Text = bulunmuşlar(i + 3).sayfa_içeriği
            Label8.Text = bulunmuşlar(i + 3).bağlantı
        Catch ex As Exception
            HyperLink4.Visible = False
            Label7.Visible = False
            Label8.Visible = False
        End Try

        Try
            HyperLink5.NavigateUrl = bulunmuşlar(i + 4).bağlantı
            HyperLink5.Text = bulunmuşlar(i + 4).başlık_etiketi
            Label9.Text = bulunmuşlar(i + 4).sayfa_içeriği
            Label10.Text = bulunmuşlar(i + 4).bağlantı
        Catch ex As Exception
            HyperLink5.Visible = False
            Label9.Visible = False
            Label10.Visible = False
        End Try

    End Sub

    Private Sub ARA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ARA.Click

        başlat(kelime.Text, form1.Page)

    End Sub

    Protected Sub kelime_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles kelime.TextChanged
        aramayd = True
    End Sub

    Protected Sub ileri_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ileri.Click
        Response.Redirect("arama.aspx?arama=" & aranan & "&sayfa_no=" & sayfa_no + 1)
    End Sub

    Protected Sub geri_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles geri.Click
        Response.Redirect("arama.aspx?arama=" & aranan & "&sayfa_no=" & sayfa_no - 1)
    End Sub

    Protected Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Not syf.Text = "" Then
            Response.Redirect("arama.aspx?arama=" & aranan & "&sayfa_no=" & syf.Text)
        End If
    End Sub
End Class