<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Kontrol = New System.Windows.Forms.WebBrowser()
        Me.Kontrol1 = New System.Windows.Forms.WebBrowser()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.drm1 = New System.Windows.Forms.TextBox()
        Me.drm2 = New System.Windows.Forms.TextBox()
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EeTmmToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.KapatToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Kontrol
        '
        Me.Kontrol.Dock = System.Windows.Forms.DockStyle.Top
        Me.Kontrol.Location = New System.Drawing.Point(0, 0)
        Me.Kontrol.MinimumSize = New System.Drawing.Size(20, 20)
        Me.Kontrol.Name = "Kontrol"
        Me.Kontrol.Size = New System.Drawing.Size(619, 252)
        Me.Kontrol.TabIndex = 0
        Me.Kontrol.Url = New System.Uri("http://www.bux.to/login.php", System.UriKind.Absolute)
        '
        'Kontrol1
        '
        Me.Kontrol1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Kontrol1.Location = New System.Drawing.Point(0, 250)
        Me.Kontrol1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.Kontrol1.Name = "Kontrol1"
        Me.Kontrol1.Size = New System.Drawing.Size(619, 264)
        Me.Kontrol1.TabIndex = 1
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'drm1
        '
        Me.drm1.BackColor = System.Drawing.Color.White
        Me.drm1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.drm1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.drm1.Location = New System.Drawing.Point(72, 225)
        Me.drm1.Name = "drm1"
        Me.drm1.Size = New System.Drawing.Size(397, 19)
        Me.drm1.TabIndex = 2
        '
        'drm2
        '
        Me.drm2.BackColor = System.Drawing.Color.White
        Me.drm2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.drm2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.drm2.Location = New System.Drawing.Point(72, 483)
        Me.drm2.Name = "drm2"
        Me.drm2.Size = New System.Drawing.Size(397, 19)
        Me.drm2.TabIndex = 3
        '
        'Timer2
        '
        Me.Timer2.Interval = 21600000
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.Label1.Location = New System.Drawing.Point(12, 225)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 20)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Durum:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.Label2.Location = New System.Drawing.Point(12, 483)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 20)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Durum:"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(514, 483)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "Geç"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.BalloonTipText = "gfgt"
        Me.NotifyIcon1.BalloonTipTitle = "ggg"
        Me.NotifyIcon1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "deneme"
        Me.NotifyIcon1.Visible = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EeTmmToolStripMenuItem, Me.KapatToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(105, 48)
        '
        'EeTmmToolStripMenuItem
        '
        Me.EeTmmToolStripMenuItem.Name = "EeTmmToolStripMenuItem"
        Me.EeTmmToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.EeTmmToolStripMenuItem.Text = "Aç"
        '
        'KapatToolStripMenuItem
        '
        Me.KapatToolStripMenuItem.Name = "KapatToolStripMenuItem"
        Me.KapatToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.KapatToolStripMenuItem.Text = "Kapat"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(619, 514)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.drm2)
        Me.Controls.Add(Me.drm1)
        Me.Controls.Add(Me.Kontrol1)
        Me.Controls.Add(Me.Kontrol)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Kontrol As System.Windows.Forms.WebBrowser
    Friend WithEvents Kontrol1 As System.Windows.Forms.WebBrowser
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents drm1 As System.Windows.Forms.TextBox
    Friend WithEvents drm2 As System.Windows.Forms.TextBox
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents EeTmmToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents KapatToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
