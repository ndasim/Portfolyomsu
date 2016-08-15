<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class inclare
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Kontrol1 = New System.Windows.Forms.WebBrowser()
        Me.Kontrol = New System.Windows.Forms.WebBrowser()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.drm2 = New System.Windows.Forms.TextBox()
        Me.drm1 = New System.Windows.Forms.TextBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'Kontrol1
        '
        Me.Kontrol1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Kontrol1.Location = New System.Drawing.Point(0, 244)
        Me.Kontrol1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.Kontrol1.Name = "Kontrol1"
        Me.Kontrol1.Size = New System.Drawing.Size(571, 264)
        Me.Kontrol1.TabIndex = 3
        '
        'Kontrol
        '
        Me.Kontrol.Dock = System.Windows.Forms.DockStyle.Top
        Me.Kontrol.Location = New System.Drawing.Point(0, 0)
        Me.Kontrol.MinimumSize = New System.Drawing.Size(20, 20)
        Me.Kontrol.Name = "Kontrol"
        Me.Kontrol.Size = New System.Drawing.Size(571, 252)
        Me.Kontrol.TabIndex = 2
        Me.Kontrol.Url = New System.Uri("http://incrasebux.com/", System.UriKind.Absolute)
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.Label2.Location = New System.Drawing.Point(12, 479)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 20)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Durum:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.Label1.Location = New System.Drawing.Point(12, 221)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 20)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Durum:"
        '
        'drm2
        '
        Me.drm2.BackColor = System.Drawing.Color.White
        Me.drm2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.drm2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.drm2.Location = New System.Drawing.Point(72, 479)
        Me.drm2.Name = "drm2"
        Me.drm2.Size = New System.Drawing.Size(397, 19)
        Me.drm2.TabIndex = 7
        '
        'drm1
        '
        Me.drm1.BackColor = System.Drawing.Color.White
        Me.drm1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.drm1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.drm1.Location = New System.Drawing.Point(72, 221)
        Me.drm1.Name = "drm1"
        Me.drm1.Size = New System.Drawing.Size(397, 19)
        Me.drm1.TabIndex = 6
        '
        'Timer1
        '
        Me.Timer1.Interval = 1
        '
        'Timer2
        '
        '
        'inclare
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(571, 508)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.drm2)
        Me.Controls.Add(Me.drm1)
        Me.Controls.Add(Me.Kontrol1)
        Me.Controls.Add(Me.Kontrol)
        Me.Name = "inclare"
        Me.Text = "inclare"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Kontrol1 As System.Windows.Forms.WebBrowser
    Friend WithEvents Kontrol As System.Windows.Forms.WebBrowser
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents drm2 As System.Windows.Forms.TextBox
    Friend WithEvents drm1 As System.Windows.Forms.TextBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
End Class
