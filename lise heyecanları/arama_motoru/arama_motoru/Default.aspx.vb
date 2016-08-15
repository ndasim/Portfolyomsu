
Option Strict Off
Option Explicit On
Imports System.Web.UI.WebControls
imports System.Collections.Generic

Partial Public Class _Default
    Inherits System.Web.UI.Page

    Dim gelenveri As String
    'Dim adressler(100) As site
    Dim adres_say�s� As Integer
    Dim yol As String = Server.MapPath("arama_sayfalari.ayr")

    Dim i As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        gelenveri = Request.QueryString("arama")
    End Sub

    Protected Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ara.Click

        'ba�lat(kelime.Text, form1.Page)

        Request.QueryString.Add("sayfa", "aa")
        Request.QueryString.Add("aaa", "aa")

        gelenveri = Request.QueryString.ToString

        'Response.Redirect("arama.aspx?arama=deneme")
    End Sub

    Sub kynk(ByVal hamveri As String)
        ' Burada ama� body i�indeki etiketlerden ar�nd�rmakt�r
        Dim ar�d�r�lm�s As String
        Dim i As Integer
        Dim tst As String
        Dim tmm As Boolean = False

        ' html etiketlerinden ar�nd�rma

        ' html ar�nd�rma
        i = hamveri.IndexOf("<html")
        'tst = etiketin_uzunlu�unu_bul(i, hamveri)
        tst = hamveri.Substring(i, tst)
        hamveri = Replace(hamveri, tst, "")
        hamveri = Replace(hamveri, "</html>", "")

        ' head ar�nd�rma
        i = hamveri.IndexOf("<head")
        If Not i = -1 Then
            '   tst = etiketin_uzunlu�unu_bul(i, hamveri)
            tst = hamveri.Substring(i, tst)
            hamveri = Replace(hamveri, tst, "")
            hamveri = Replace(hamveri, "</head>", "")
        End If

        ' title ar�nd�rma
        i = hamveri.IndexOf("<title")
        If Not i = -1 Then
            '  tst = etiketin_uzunlu�unu_bul(i, hamveri)
            tst = hamveri.Substring(i, tst)
            hamveri = Replace(hamveri, tst, "")
            hamveri = Replace(hamveri, "</title>", "")
        End If

        ' body ar�nd�rma
        i = hamveri.IndexOf("<body")
        If Not i = -1 Then
            ' tst = etiketin_uzunlu�unu_bul(i, hamveri)
            tst = hamveri.Substring(i, tst)
            hamveri = Replace(hamveri, tst, "")
            hamveri = Replace(hamveri, "</body>", "")
        End If

        ' table ar�nd�rma
        Do Until tmm
            i = hamveri.IndexOf("<table")
            If Not i = -1 Then
                '    tst = etiketin_uzunlu�unu_bul(i, hamveri)
                tst = hamveri.Substring(i, tst)
                hamveri = Replace(hamveri, tst, "")
                hamveri = Replace(hamveri, "</table>", "")
            Else
                tmm = True
            End If
        Loop

        ' tr ar�nd�rma
        Do Until tmm
            i = hamveri.IndexOf("<tr")
            If Not i = -1 Then
                '   tst = etiketin_uzunlu�unu_bul(i, hamveri)
                tst = hamveri.Substring(i, tst)
                hamveri = Replace(hamveri, tst, "")
                hamveri = Replace(hamveri, "</tr>", "")
            Else
                tmm = True
            End If
        Loop

        ' td ar�nd�rma
        Do Until tmm
            i = hamveri.IndexOf("<td")
            If Not i = -1 Then
                '  tst = etiketin_uzunlu�unu_bul(i, hamveri)
                tst = hamveri.Substring(i, tst)
                hamveri = Replace(hamveri, tst, "")
                hamveri = Replace(hamveri, "</td>", "")
            Else
                tmm = True
            End If
        Loop

        ' ol ar�nd�rma
        Do Until tmm
            i = hamveri.IndexOf("<ol")
            If Not i = -1 Then
                ' tst = etiketin_uzunlu�unu_bul(i, hamveri)
                tst = hamveri.Substring(i, tst)
                hamveri = Replace(hamveri, tst, "")
                hamveri = Replace(hamveri, "</ol>", "")
            Else
                tmm = True
            End If
        Loop

        ' ul ar�nd�rma
        Do Until tmm
            i = hamveri.IndexOf("<ul")
            If Not i = -1 Then
                'tst = etiketin_uzunlu�unu_bul(i, hamveri)
                tst = hamveri.Substring(i, tst)
                hamveri = Replace(hamveri, tst, "")
                hamveri = Replace(hamveri, "</ul>", "")
            Else
                tmm = True
            End If
        Loop

        ' li ar�nd�rma
        Do Until tmm
            i = hamveri.IndexOf("<li")
            If Not i = -1 Then
                'tst = etiketin_uzunlu�unu_bul(i, hamveri)
                tst = hamveri.Substring(i, tst)
                hamveri = Replace(hamveri, tst, "")
                hamveri = Replace(hamveri, "</li>", "")
            Else
                tmm = True
            End If
        Loop

        ' a ar�nd�rma
        Do Until tmm
            i = hamveri.IndexOf("<a")
            If Not i = -1 Then
                'tst = etiketin_uzunlu�unu_bul(i, hamveri)
                tst = hamveri.Substring(i, tst)
                hamveri = Replace(hamveri, tst, "")
                hamveri = Replace(hamveri, "</a>", "")
            Else
                tmm = True
            End If
        Loop

        ' form ar�nd�rma
        Do Until tmm
            i = hamveri.IndexOf("<form")
            If Not i = -1 Then
                'tst = etiketin_uzunlu�unu_bul(i, hamveri)
                tst = hamveri.Substring(i, tst)
                hamveri = Replace(hamveri, tst, "")
                hamveri = Replace(hamveri, "</form>", "")
            Else
                tmm = True
            End If
        Loop
    End Sub



End Class


