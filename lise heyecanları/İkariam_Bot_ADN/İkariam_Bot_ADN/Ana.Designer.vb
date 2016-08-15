<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Ana
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
        Me.Kontrol = New System.Windows.Forms.WebBrowser
        Me.Button1 = New System.Windows.Forms.Button
        Me.ListBox1 = New System.Windows.Forms.ListBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Kaynaklar = New System.Windows.Forms.GroupBox
        Me.ToplamAltýn = New System.Windows.Forms.Label
        Me.ToplamSülfür = New System.Windows.Forms.Label
        Me.ToplamKristal = New System.Windows.Forms.Label
        Me.ToplamÞarap = New System.Windows.Forms.Label
        Me.ToplamMermer = New System.Windows.Forms.Label
        Me.ToplamOdun = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.YaðmaSülfür = New System.Windows.Forms.Label
        Me.YaðmaKristal = New System.Windows.Forms.Label
        Me.YaðmaÞarap = New System.Windows.Forms.Label
        Me.YaðmaMermer = New System.Windows.Forms.Label
        Me.YaðmaOdun = New System.Windows.Forms.Label
        Me.GüvenliSülfür = New System.Windows.Forms.Label
        Me.GüvenliKristal = New System.Windows.Forms.Label
        Me.GüvenliÞarap = New System.Windows.Forms.Label
        Me.GüvenliMermer = New System.Windows.Forms.Label
        Me.GüvenliOdun = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Kaynaklar.SuspendLayout()
        Me.SuspendLayout()
        '
        'Kontrol
        '
        Me.Kontrol.Location = New System.Drawing.Point(2, 229)
        Me.Kontrol.MinimumSize = New System.Drawing.Size(20, 20)
        Me.Kontrol.Name = "Kontrol"
        Me.Kontrol.Size = New System.Drawing.Size(351, 338)
        Me.Kontrol.TabIndex = 0
        Me.Kontrol.Url = New System.Uri("http://tr.ikariam.com", System.UriKind.Absolute)
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(647, 444)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(163, 45)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Listeye Yeni Görev Ekle"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(647, 31)
        Me.ListBox1.MultiColumn = True
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(163, 407)
        Me.ListBox1.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(687, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Yapýlacak Listesi:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Odun:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 77)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Mermer:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(15, 100)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Þarap:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(15, 122)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Kristal:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(15, 145)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(37, 13)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Sülfür:"
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(12, 31)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(121, 21)
        Me.ComboBox1.TabIndex = 11
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(53, 12)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(34, 13)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Þehir:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(15, 168)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(64, 13)
        Me.Label9.TabIndex = 14
        Me.Label9.Text = "Altýn Miktarý:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(12, 67)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(45, 13)
        Me.Label10.TabIndex = 15
        Me.Label10.Text = "Label10"
        '
        'Kaynaklar
        '
        Me.Kaynaklar.Controls.Add(Me.ToplamAltýn)
        Me.Kaynaklar.Controls.Add(Me.ToplamSülfür)
        Me.Kaynaklar.Controls.Add(Me.ToplamKristal)
        Me.Kaynaklar.Controls.Add(Me.ToplamÞarap)
        Me.Kaynaklar.Controls.Add(Me.ToplamMermer)
        Me.Kaynaklar.Controls.Add(Me.ToplamOdun)
        Me.Kaynaklar.Controls.Add(Me.Label12)
        Me.Kaynaklar.Controls.Add(Me.YaðmaSülfür)
        Me.Kaynaklar.Controls.Add(Me.YaðmaKristal)
        Me.Kaynaklar.Controls.Add(Me.YaðmaÞarap)
        Me.Kaynaklar.Controls.Add(Me.YaðmaMermer)
        Me.Kaynaklar.Controls.Add(Me.YaðmaOdun)
        Me.Kaynaklar.Controls.Add(Me.GüvenliSülfür)
        Me.Kaynaklar.Controls.Add(Me.GüvenliKristal)
        Me.Kaynaklar.Controls.Add(Me.GüvenliÞarap)
        Me.Kaynaklar.Controls.Add(Me.GüvenliMermer)
        Me.Kaynaklar.Controls.Add(Me.GüvenliOdun)
        Me.Kaynaklar.Controls.Add(Me.Label11)
        Me.Kaynaklar.Controls.Add(Me.Label8)
        Me.Kaynaklar.Controls.Add(Me.Label2)
        Me.Kaynaklar.Controls.Add(Me.Label3)
        Me.Kaynaklar.Controls.Add(Me.Label9)
        Me.Kaynaklar.Controls.Add(Me.Label4)
        Me.Kaynaklar.Controls.Add(Me.Label5)
        Me.Kaynaklar.Controls.Add(Me.Label6)
        Me.Kaynaklar.Location = New System.Drawing.Point(193, 12)
        Me.Kaynaklar.Name = "Kaynaklar"
        Me.Kaynaklar.Size = New System.Drawing.Size(424, 211)
        Me.Kaynaklar.TabIndex = 16
        Me.Kaynaklar.TabStop = False
        Me.Kaynaklar.Text = "Kaynaklar:"
        '
        'ToplamAltýn
        '
        Me.ToplamAltýn.AutoSize = True
        Me.ToplamAltýn.Location = New System.Drawing.Point(306, 168)
        Me.ToplamAltýn.Name = "ToplamAltýn"
        Me.ToplamAltýn.Size = New System.Drawing.Size(42, 13)
        Me.ToplamAltýn.TabIndex = 31
        Me.ToplamAltýn.Text = "Toplam"
        '
        'ToplamSülfür
        '
        Me.ToplamSülfür.AutoSize = True
        Me.ToplamSülfür.Location = New System.Drawing.Point(306, 145)
        Me.ToplamSülfür.Name = "ToplamSülfür"
        Me.ToplamSülfür.Size = New System.Drawing.Size(42, 13)
        Me.ToplamSülfür.TabIndex = 30
        Me.ToplamSülfür.Text = "Toplam"
        '
        'ToplamKristal
        '
        Me.ToplamKristal.AutoSize = True
        Me.ToplamKristal.Location = New System.Drawing.Point(306, 122)
        Me.ToplamKristal.Name = "ToplamKristal"
        Me.ToplamKristal.Size = New System.Drawing.Size(42, 13)
        Me.ToplamKristal.TabIndex = 29
        Me.ToplamKristal.Text = "Toplam"
        '
        'ToplamÞarap
        '
        Me.ToplamÞarap.AutoSize = True
        Me.ToplamÞarap.Location = New System.Drawing.Point(306, 100)
        Me.ToplamÞarap.Name = "ToplamÞarap"
        Me.ToplamÞarap.Size = New System.Drawing.Size(42, 13)
        Me.ToplamÞarap.TabIndex = 28
        Me.ToplamÞarap.Text = "Toplam"
        '
        'ToplamMermer
        '
        Me.ToplamMermer.AutoSize = True
        Me.ToplamMermer.Location = New System.Drawing.Point(306, 77)
        Me.ToplamMermer.Name = "ToplamMermer"
        Me.ToplamMermer.Size = New System.Drawing.Size(42, 13)
        Me.ToplamMermer.TabIndex = 27
        Me.ToplamMermer.Text = "Toplam"
        '
        'ToplamOdun
        '
        Me.ToplamOdun.AutoSize = True
        Me.ToplamOdun.Location = New System.Drawing.Point(306, 55)
        Me.ToplamOdun.Name = "ToplamOdun"
        Me.ToplamOdun.Size = New System.Drawing.Size(42, 13)
        Me.ToplamOdun.TabIndex = 27
        Me.ToplamOdun.Text = "Toplam"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(306, 27)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(54, 13)
        Me.Label12.TabIndex = 26
        Me.Label12.Text = "Toplamda"
        '
        'YaðmaSülfür
        '
        Me.YaðmaSülfür.AutoSize = True
        Me.YaðmaSülfür.ForeColor = System.Drawing.Color.Red
        Me.YaðmaSülfür.Location = New System.Drawing.Point(188, 145)
        Me.YaðmaSülfür.Name = "YaðmaSülfür"
        Me.YaðmaSülfür.Size = New System.Drawing.Size(45, 13)
        Me.YaðmaSülfür.TabIndex = 23
        Me.YaðmaSülfür.Text = "Label12"
        '
        'YaðmaKristal
        '
        Me.YaðmaKristal.AutoSize = True
        Me.YaðmaKristal.ForeColor = System.Drawing.Color.Red
        Me.YaðmaKristal.Location = New System.Drawing.Point(188, 122)
        Me.YaðmaKristal.Name = "YaðmaKristal"
        Me.YaðmaKristal.Size = New System.Drawing.Size(45, 13)
        Me.YaðmaKristal.TabIndex = 25
        Me.YaðmaKristal.Text = "Label12"
        '
        'YaðmaÞarap
        '
        Me.YaðmaÞarap.AutoSize = True
        Me.YaðmaÞarap.ForeColor = System.Drawing.Color.Red
        Me.YaðmaÞarap.Location = New System.Drawing.Point(188, 100)
        Me.YaðmaÞarap.Name = "YaðmaÞarap"
        Me.YaðmaÞarap.Size = New System.Drawing.Size(45, 13)
        Me.YaðmaÞarap.TabIndex = 24
        Me.YaðmaÞarap.Text = "Label12"
        '
        'YaðmaMermer
        '
        Me.YaðmaMermer.AutoSize = True
        Me.YaðmaMermer.ForeColor = System.Drawing.Color.Red
        Me.YaðmaMermer.Location = New System.Drawing.Point(188, 77)
        Me.YaðmaMermer.Name = "YaðmaMermer"
        Me.YaðmaMermer.Size = New System.Drawing.Size(45, 13)
        Me.YaðmaMermer.TabIndex = 23
        Me.YaðmaMermer.Text = "Label13"
        '
        'YaðmaOdun
        '
        Me.YaðmaOdun.AutoSize = True
        Me.YaðmaOdun.ForeColor = System.Drawing.Color.Red
        Me.YaðmaOdun.Location = New System.Drawing.Point(188, 55)
        Me.YaðmaOdun.Name = "YaðmaOdun"
        Me.YaðmaOdun.Size = New System.Drawing.Size(45, 13)
        Me.YaðmaOdun.TabIndex = 22
        Me.YaðmaOdun.Text = "Label12"
        '
        'GüvenliSülfür
        '
        Me.GüvenliSülfür.AutoSize = True
        Me.GüvenliSülfür.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.GüvenliSülfür.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.GüvenliSülfür.Location = New System.Drawing.Point(95, 145)
        Me.GüvenliSülfür.Name = "GüvenliSülfür"
        Me.GüvenliSülfür.Size = New System.Drawing.Size(45, 13)
        Me.GüvenliSülfür.TabIndex = 21
        Me.GüvenliSülfür.Text = "Label12"
        '
        'GüvenliKristal
        '
        Me.GüvenliKristal.AutoSize = True
        Me.GüvenliKristal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.GüvenliKristal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.GüvenliKristal.Location = New System.Drawing.Point(95, 122)
        Me.GüvenliKristal.Name = "GüvenliKristal"
        Me.GüvenliKristal.Size = New System.Drawing.Size(45, 13)
        Me.GüvenliKristal.TabIndex = 20
        Me.GüvenliKristal.Text = "Label12"
        '
        'GüvenliÞarap
        '
        Me.GüvenliÞarap.AutoSize = True
        Me.GüvenliÞarap.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.GüvenliÞarap.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.GüvenliÞarap.Location = New System.Drawing.Point(95, 100)
        Me.GüvenliÞarap.Name = "GüvenliÞarap"
        Me.GüvenliÞarap.Size = New System.Drawing.Size(45, 13)
        Me.GüvenliÞarap.TabIndex = 19
        Me.GüvenliÞarap.Text = "Label12"
        '
        'GüvenliMermer
        '
        Me.GüvenliMermer.AutoSize = True
        Me.GüvenliMermer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.GüvenliMermer.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.GüvenliMermer.Location = New System.Drawing.Point(96, 77)
        Me.GüvenliMermer.Name = "GüvenliMermer"
        Me.GüvenliMermer.Size = New System.Drawing.Size(45, 13)
        Me.GüvenliMermer.TabIndex = 18
        Me.GüvenliMermer.Text = "Label12"
        '
        'GüvenliOdun
        '
        Me.GüvenliOdun.AutoSize = True
        Me.GüvenliOdun.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.GüvenliOdun.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.GüvenliOdun.Location = New System.Drawing.Point(96, 55)
        Me.GüvenliOdun.Name = "GüvenliOdun"
        Me.GüvenliOdun.Size = New System.Drawing.Size(45, 13)
        Me.GüvenliOdun.TabIndex = 17
        Me.GüvenliOdun.Text = "Label12"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(176, 27)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(78, 13)
        Me.Label11.TabIndex = 16
        Me.Label11.Text = "Yaðmalanabilir:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(95, 27)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(46, 13)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "Güvenli:"
        '
        'Ana
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(822, 566)
        Me.Controls.Add(Me.Kaynaklar)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Kontrol)
        Me.Name = "Ana"
        Me.Text = "Form1"
        Me.Kaynaklar.ResumeLayout(False)
        Me.Kaynaklar.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Kontrol As System.Windows.Forms.WebBrowser
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Kaynaklar As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents YaðmaOdun As System.Windows.Forms.Label
    Friend WithEvents GüvenliSülfür As System.Windows.Forms.Label
    Friend WithEvents GüvenliKristal As System.Windows.Forms.Label
    Friend WithEvents GüvenliÞarap As System.Windows.Forms.Label
    Friend WithEvents GüvenliMermer As System.Windows.Forms.Label
    Friend WithEvents GüvenliOdun As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents YaðmaMermer As System.Windows.Forms.Label
    Friend WithEvents ToplamSülfür As System.Windows.Forms.Label
    Friend WithEvents ToplamKristal As System.Windows.Forms.Label
    Friend WithEvents ToplamÞarap As System.Windows.Forms.Label
    Friend WithEvents ToplamMermer As System.Windows.Forms.Label
    Friend WithEvents ToplamOdun As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents YaðmaSülfür As System.Windows.Forms.Label
    Friend WithEvents YaðmaKristal As System.Windows.Forms.Label
    Friend WithEvents YaðmaÞarap As System.Windows.Forms.Label
    Friend WithEvents ToplamAltýn As System.Windows.Forms.Label

End Class
