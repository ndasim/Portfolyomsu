Public Class hazırlanıyor
    Dim form1 As Form
    Dim başnoku, tamnok, yol, değer1 As Integer
    Dim noktasay, yenile, kilit, açılış_kilidi As Integer
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If açılış_kilidi = 1 Then
            yenile = yenile + 1
            If Not değer1 > 100 Then
                ProgressBar1.Value = değer1
            End If

            If ProgressBar1.Value = 98 Then
                form1.Opacity = 1
                Timer1.Enabled = False
                Timer2.Enabled = False
                Me.Close()
            End If
            Label2.Text = "%" & ProgressBar1.Value
            If yenile = 1 Then
                yenile = 0
                Me.Text = TextBox1.Text & "  " & "(" & Label2.Text & ")"
            End If

        End If
    End Sub
    Sub başla(ByVal değer As Integer, ByVal form As Form)
        değer1 = değer
        form1 = form
        form.Opacity = 0.5
        açılış_kilidi = 1
    End Sub


    Private Sub hazırlanıyor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        başnoku = Label2.Left
        yol = 359 / 100
        Me.TopMost = True
        Me.Left = (My.Computer.Screen.WorkingArea.Width / 2) - (Me.Size.Width / 2)
        Me.Top = (My.Computer.Screen.WorkingArea.Height / 2) - (Me.Size.Height / 2)
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        noktasay = noktasay + 1
        If noktasay <= 5 Then
            If noktasay = 1 Then
                TextBox1.Text = "Hazırlanıyor" & "."
                Label1.Text = "Lütfen biraz sabır" & "."
            End If
            If noktasay = 2 Then
                TextBox1.Text = "Hazırlanıyor" & ".."
                Label1.Text = "Lütfen biraz sabır" & ".."
            End If
            If noktasay = 3 Then
                TextBox1.Text = "Hazırlanıyor" & "..."
                Label1.Text = "Lütfen biraz sabır" & "..."
            End If
            If noktasay = 4 Then
                TextBox1.Text = "Hazırlanıyor" & "...."
                Label1.Text = "Lütfen biraz sabır" & "...."
            End If
        Else
            noktasay = 0
            TextBox1.Text = "Hazırlanıyor"
            Label1.Text = "Lütfen biraz sabır"

        End If
    End Sub
End Class