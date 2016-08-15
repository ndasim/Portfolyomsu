Imports System.Runtime.InteropServices

Public Class geliştirici
    Dim i As Integer = 1
    Dim fark As Point
    Dim farkx, farky As Double
    Dim b As New Bitmap(600, 600)
    'API Tanımlamaları
    Structure POINTAPI
        Dim X As Integer
        Dim Y As Integer
    End Structure

    Dim sıradakinok As New Point(1, 1)
    Dim renk As Color

    Private Declare Function GetCursorPos Lib "user32.dll" (ByRef lpPoint As POINTAPI) As Long
    Private Declare Function HPALETTE_UserSize Lib "ole32.dll" (ByRef pLong As Long, ByVal lLong As Long, ByRef pHpalette As Long) As Long
    Private Declare Function Beep Lib "kernel32" (ByVal dwFreq As Long, ByVal dwDuration As Long) As Long
    Declare Function SetCursorPos Lib "user32" (ByVal X As Long, ByVal Y As Long) As Long
    Public fareyeri As POINTAPI


    Public Class API

        Public Shared Sub Beep(ByVal toner As Int32, ByVal sure As Int32)

        End Sub

    End Class
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Timer1.Start()
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim a As Graphics
        Dim c() As Point = {New Point(2, 2), _
                             New Point(2 + 100 * Math.Cos(-20 * Math.PI / 180), 10), _
                             New Point(2, 2)}
        a = Graphics.FromImage(b)
        ' Create solid brush.
        Dim blueBrush As New SolidBrush(Color.Blue)
        ' Create points that define polygon.
        Dim point1 As New PointF(2, 2)
        Dim point2 As New PointF(2 + 20 * Math.Cos(90 * Math.PI / 180), 2 + 20 * Math.Sin(90 * Math.PI / 180))
        Dim point3 As New PointF(point2.X + 100 * Math.Cos(0 * Math.PI / 180), point2.Y + 100 * Math.Sin(0 * Math.PI / 180))
        Dim point4 As New PointF(point3.X + 100 * Math.Cos(-90 * Math.PI / 180), point3.Y + 100 * Math.Sin(-90 * Math.PI / 180))
        Dim curvePoints As PointF() = {point1, point2, point3, point4}
        ' Define fill mode.
        ' Fill polygon to screen.
        a.FillPolygon(blueBrush, curvePoints, Drawing2D.FillMode.Winding)


        a.FillPolygon(Brushes.Blue, c)
        PictureBox1.Image = b
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        renk = b.GetPixel(sıradakinok.X, sıradakinok.Y)
        If sıradakinok.X = 1 Then
            If sıradakinok.Y = 110 Then
                Timer1.Enabled = False
            End If
        End If
        If renk.ToArgb = Color.Blue.ToArgb Then
            TextBox1.Text += 1
        End If
        If sıradakinok.X = 110 Then
            sıradakinok.X = 1
            sıradakinok.Y += 1
        End If
        sıradakinok.X += 1
        TextBox2.Text = sıradakinok.X
    End Sub

    Private Sub Panel1_BackgroundImageChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel1.LostFocus

    End Sub

    Private Sub OvalShape1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OvalShape1.Click

    End Sub
End Class