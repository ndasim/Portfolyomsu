
Option Strict Off
Option Explicit On
Imports System.Web.UI.WebControls
imports System.Collections.Generic

Partial Public Class _Default
    Inherits System.Web.UI.Page

    Dim gelenveri As String
    'Dim adressler(100) As site
    Dim adres_sayýsý As Integer
    Dim yol As String = Server.MapPath("arama_sayfalari.ayr")

    Dim i As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        gelenveri = Request.QueryString("arama")
    End Sub

    Protected Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ara.Click

        'baþlat(kelime.Text, form1.Page)

        Request.QueryString.Add("sayfa", "aa")
        Request.QueryString.Add("aaa", "aa")

        gelenveri = Request.QueryString.ToString

        'Response.Redirect("arama.aspx?arama=deneme")
    End Sub

    Sub kynk(ByVal hamveri As String)
        ' Burada amaç body içindeki etiketlerden arýndýrmaktýr
        Dim arýdýrýlmýs As String
        Dim i As Integer
        Dim tst As String
        Dim tmm As Boolean = False

        ' html etiketlerinden arýndýrma

        ' html arýndýrma
        i = hamveri.IndexOf("<html")
        'tst = etiketin_uzunluðunu_bul(i, hamveri)
        tst = hamveri.Substring(i, tst)
        hamveri = Replace(hamveri, tst, "")
        hamveri = Replace(hamveri, "</html>", "")

        ' head arýndýrma
        i = hamveri.IndexOf("<head")
        If Not i = -1 Then
            '   tst = etiketin_uzunluðunu_bul(i, hamveri)
            tst = hamveri.Substring(i, tst)
            hamveri = Replace(hamveri, tst, "")
            hamveri = Replace(hamveri, "</head>", "")
        End If

        ' title arýndýrma
        i = hamveri.IndexOf("<title")
        If Not i = -1 Then
            '  tst = etiketin_uzunluðunu_bul(i, hamveri)
            tst = hamveri.Substring(i, tst)
            hamveri = Replace(hamveri, tst, "")
            hamveri = Replace(hamveri, "</title>", "")
        End If

        ' body arýndýrma
        i = hamveri.IndexOf("<body")
        If Not i = -1 Then
            ' tst = etiketin_uzunluðunu_bul(i, hamveri)
            tst = hamveri.Substring(i, tst)
            hamveri = Replace(hamveri, tst, "")
            hamveri = Replace(hamveri, "</body>", "")
        End If

        ' table arýndýrma
        Do Until tmm
            i = hamveri.IndexOf("<table")
            If Not i = -1 Then
                '    tst = etiketin_uzunluðunu_bul(i, hamveri)
                tst = hamveri.Substring(i, tst)
                hamveri = Replace(hamveri, tst, "")
                hamveri = Replace(hamveri, "</table>", "")
            Else
                tmm = True
            End If
        Loop

        ' tr arýndýrma
        Do Until tmm
            i = hamveri.IndexOf("<tr")
            If Not i = -1 Then
                '   tst = etiketin_uzunluðunu_bul(i, hamveri)
                tst = hamveri.Substring(i, tst)
                hamveri = Replace(hamveri, tst, "")
                hamveri = Replace(hamveri, "</tr>", "")
            Else
                tmm = True
            End If
        Loop

        ' td arýndýrma
        Do Until tmm
            i = hamveri.IndexOf("<td")
            If Not i = -1 Then
                '  tst = etiketin_uzunluðunu_bul(i, hamveri)
                tst = hamveri.Substring(i, tst)
                hamveri = Replace(hamveri, tst, "")
                hamveri = Replace(hamveri, "</td>", "")
            Else
                tmm = True
            End If
        Loop

        ' ol arýndýrma
        Do Until tmm
            i = hamveri.IndexOf("<ol")
            If Not i = -1 Then
                ' tst = etiketin_uzunluðunu_bul(i, hamveri)
                tst = hamveri.Substring(i, tst)
                hamveri = Replace(hamveri, tst, "")
                hamveri = Replace(hamveri, "</ol>", "")
            Else
                tmm = True
            End If
        Loop

        ' ul arýndýrma
        Do Until tmm
            i = hamveri.IndexOf("<ul")
            If Not i = -1 Then
                'tst = etiketin_uzunluðunu_bul(i, hamveri)
                tst = hamveri.Substring(i, tst)
                hamveri = Replace(hamveri, tst, "")
                hamveri = Replace(hamveri, "</ul>", "")
            Else
                tmm = True
            End If
        Loop

        ' li arýndýrma
        Do Until tmm
            i = hamveri.IndexOf("<li")
            If Not i = -1 Then
                'tst = etiketin_uzunluðunu_bul(i, hamveri)
                tst = hamveri.Substring(i, tst)
                hamveri = Replace(hamveri, tst, "")
                hamveri = Replace(hamveri, "</li>", "")
            Else
                tmm = True
            End If
        Loop

        ' a arýndýrma
        Do Until tmm
            i = hamveri.IndexOf("<a")
            If Not i = -1 Then
                'tst = etiketin_uzunluðunu_bul(i, hamveri)
                tst = hamveri.Substring(i, tst)
                hamveri = Replace(hamveri, tst, "")
                hamveri = Replace(hamveri, "</a>", "")
            Else
                tmm = True
            End If
        Loop

        ' form arýndýrma
        Do Until tmm
            i = hamveri.IndexOf("<form")
            If Not i = -1 Then
                'tst = etiketin_uzunluðunu_bul(i, hamveri)
                tst = hamveri.Substring(i, tst)
                hamveri = Replace(hamveri, tst, "")
                hamveri = Replace(hamveri, "</form>", "")
            Else
                tmm = True
            End If
        Loop
    End Sub



End Class


