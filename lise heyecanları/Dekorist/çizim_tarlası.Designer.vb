<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class çizim_tarlası
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.components = New System.ComponentModel.Container
        Me.konum_eşitleyici = New System.Windows.Forms.Timer(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.refy = New System.Windows.Forms.TextBox
        Me.refx = New System.Windows.Forms.TextBox
        Me.y = New System.Windows.Forms.TextBox
        Me.x = New System.Windows.Forms.TextBox
        Me.veri_tabanı = New System.Windows.Forms.RichTextBox
        Me.durum_yüzdesi = New System.Windows.Forms.TextBox
        Me.xaralığı = New System.Windows.Forms.PictureBox
        Me.yaralığı = New System.Windows.Forms.PictureBox
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.düzlem = New System.Windows.Forms.PictureBox
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer
        Me.LineShape1 = New Microsoft.VisualBasic.PowerPacks.LineShape
        Me.istemci = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1.SuspendLayout()
        CType(Me.xaralığı, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.yaralığı, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.düzlem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'konum_eşitleyici
        '
        Me.konum_eşitleyici.Interval = 1
        '
        'Timer2
        '
        Me.Timer2.Enabled = True
        Me.Timer2.Interval = 1
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.BlueViolet
        Me.Panel1.Controls.Add(Me.refy)
        Me.Panel1.Controls.Add(Me.refx)
        Me.Panel1.Controls.Add(Me.y)
        Me.Panel1.Controls.Add(Me.x)
        Me.Panel1.Controls.Add(Me.veri_tabanı)
        Me.Panel1.Controls.Add(Me.durum_yüzdesi)
        Me.Panel1.Controls.Add(Me.xaralığı)
        Me.Panel1.Controls.Add(Me.yaralığı)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.düzlem)
        Me.Panel1.Controls.Add(Me.ShapeContainer1)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1197, 797)
        Me.Panel1.TabIndex = 0
        '
        'refy
        '
        Me.refy.BackColor = System.Drawing.Color.OrangeRed
        Me.refy.Location = New System.Drawing.Point(659, 774)
        Me.refy.Name = "refy"
        Me.refy.Size = New System.Drawing.Size(100, 20)
        Me.refy.TabIndex = 19
        Me.refy.Text = "0"
        '
        'refx
        '
        Me.refx.BackColor = System.Drawing.Color.OrangeRed
        Me.refx.Location = New System.Drawing.Point(553, 774)
        Me.refx.Name = "refx"
        Me.refx.Size = New System.Drawing.Size(100, 20)
        Me.refx.TabIndex = 18
        Me.refx.Text = "0"
        '
        'y
        '
        Me.y.BackColor = System.Drawing.Color.Orange
        Me.y.Location = New System.Drawing.Point(438, 774)
        Me.y.Name = "y"
        Me.y.Size = New System.Drawing.Size(100, 20)
        Me.y.TabIndex = 17
        '
        'x
        '
        Me.x.BackColor = System.Drawing.Color.Orange
        Me.x.Location = New System.Drawing.Point(332, 774)
        Me.x.Name = "x"
        Me.x.Size = New System.Drawing.Size(100, 20)
        Me.x.TabIndex = 16
        '
        'veri_tabanı
        '
        Me.veri_tabanı.Location = New System.Drawing.Point(56, 598)
        Me.veri_tabanı.Name = "veri_tabanı"
        Me.veri_tabanı.Size = New System.Drawing.Size(277, 170)
        Me.veri_tabanı.TabIndex = 15
        Me.veri_tabanı.Text = ""
        '
        'durum_yüzdesi
        '
        Me.durum_yüzdesi.BackColor = System.Drawing.Color.GreenYellow
        Me.durum_yüzdesi.Location = New System.Drawing.Point(56, 774)
        Me.durum_yüzdesi.Name = "durum_yüzdesi"
        Me.durum_yüzdesi.Size = New System.Drawing.Size(100, 20)
        Me.durum_yüzdesi.TabIndex = 13
        '
        'xaralığı
        '
        Me.xaralığı.BackColor = System.Drawing.Color.Red
        Me.xaralığı.Location = New System.Drawing.Point(20, 0)
        Me.xaralığı.Name = "xaralığı"
        Me.xaralığı.Size = New System.Drawing.Size(1178, 20)
        Me.xaralığı.TabIndex = 6
        Me.xaralığı.TabStop = False
        '
        'yaralığı
        '
        Me.yaralığı.BackColor = System.Drawing.Color.Red
        Me.yaralığı.Location = New System.Drawing.Point(0, 20)
        Me.yaralığı.Name = "yaralığı"
        Me.yaralığı.Size = New System.Drawing.Size(22, 780)
        Me.yaralığı.TabIndex = 5
        Me.yaralığı.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.Button2)
        Me.Panel2.Controls.Add(Me.Button1)
        Me.Panel2.Location = New System.Drawing.Point(943, 20)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(254, 475)
        Me.Panel2.TabIndex = 4
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(22, 45)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(22, 16)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "yeni oda"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'düzlem
        '
        Me.düzlem.BackColor = System.Drawing.Color.GhostWhite
        Me.düzlem.Location = New System.Drawing.Point(20, 20)
        Me.düzlem.Name = "düzlem"
        Me.düzlem.Size = New System.Drawing.Size(1200, 800)
        Me.düzlem.TabIndex = 3
        Me.düzlem.TabStop = False
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.LineShape1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(1197, 797)
        Me.ShapeContainer1.TabIndex = 14
        Me.ShapeContainer1.TabStop = False
        '
        'LineShape1
        '
        Me.LineShape1.Name = "LineShape1"
        Me.LineShape1.X1 = 66
        Me.LineShape1.X2 = 150
        Me.LineShape1.Y1 = 49
        Me.LineShape1.Y2 = 39
        '
        'istemci
        '
        '
        'çizim_tarlası
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Panel1)
        Me.Name = "çizim_tarlası"
        Me.Size = New System.Drawing.Size(1200, 800)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.xaralığı, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.yaralığı, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        CType(Me.düzlem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents konum_eşitleyici As System.Windows.Forms.Timer
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents xaralığı As System.Windows.Forms.PictureBox
    Friend WithEvents yaralığı As System.Windows.Forms.PictureBox
    Friend WithEvents durum_yüzdesi As System.Windows.Forms.TextBox
    Friend WithEvents istemci As System.Windows.Forms.Timer
    Friend WithEvents düzlem As System.Windows.Forms.PictureBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents LineShape1 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents veri_tabanı As System.Windows.Forms.RichTextBox
    Friend WithEvents y As System.Windows.Forms.TextBox
    Friend WithEvents x As System.Windows.Forms.TextBox
    Friend WithEvents refy As System.Windows.Forms.TextBox
    Friend WithEvents refx As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button

End Class
