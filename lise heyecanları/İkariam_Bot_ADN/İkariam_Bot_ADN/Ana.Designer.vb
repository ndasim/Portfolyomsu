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
        Me.ToplamAlt�n = New System.Windows.Forms.Label
        Me.ToplamS�lf�r = New System.Windows.Forms.Label
        Me.ToplamKristal = New System.Windows.Forms.Label
        Me.Toplam�arap = New System.Windows.Forms.Label
        Me.ToplamMermer = New System.Windows.Forms.Label
        Me.ToplamOdun = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Ya�maS�lf�r = New System.Windows.Forms.Label
        Me.Ya�maKristal = New System.Windows.Forms.Label
        Me.Ya�ma�arap = New System.Windows.Forms.Label
        Me.Ya�maMermer = New System.Windows.Forms.Label
        Me.Ya�maOdun = New System.Windows.Forms.Label
        Me.G�venliS�lf�r = New System.Windows.Forms.Label
        Me.G�venliKristal = New System.Windows.Forms.Label
        Me.G�venli�arap = New System.Windows.Forms.Label
        Me.G�venliMermer = New System.Windows.Forms.Label
        Me.G�venliOdun = New System.Windows.Forms.Label
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
        Me.Button1.Text = "Listeye Yeni G�rev Ekle"
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
        Me.Label1.Text = "Yap�lacak Listesi:"
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
        Me.Label4.Text = "�arap:"
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
        Me.Label6.Text = "S�lf�r:"
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
        Me.Label7.Text = "�ehir:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(15, 168)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(64, 13)
        Me.Label9.TabIndex = 14
        Me.Label9.Text = "Alt�n Miktar�:"
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
        Me.Kaynaklar.Controls.Add(Me.ToplamAlt�n)
        Me.Kaynaklar.Controls.Add(Me.ToplamS�lf�r)
        Me.Kaynaklar.Controls.Add(Me.ToplamKristal)
        Me.Kaynaklar.Controls.Add(Me.Toplam�arap)
        Me.Kaynaklar.Controls.Add(Me.ToplamMermer)
        Me.Kaynaklar.Controls.Add(Me.ToplamOdun)
        Me.Kaynaklar.Controls.Add(Me.Label12)
        Me.Kaynaklar.Controls.Add(Me.Ya�maS�lf�r)
        Me.Kaynaklar.Controls.Add(Me.Ya�maKristal)
        Me.Kaynaklar.Controls.Add(Me.Ya�ma�arap)
        Me.Kaynaklar.Controls.Add(Me.Ya�maMermer)
        Me.Kaynaklar.Controls.Add(Me.Ya�maOdun)
        Me.Kaynaklar.Controls.Add(Me.G�venliS�lf�r)
        Me.Kaynaklar.Controls.Add(Me.G�venliKristal)
        Me.Kaynaklar.Controls.Add(Me.G�venli�arap)
        Me.Kaynaklar.Controls.Add(Me.G�venliMermer)
        Me.Kaynaklar.Controls.Add(Me.G�venliOdun)
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
        'ToplamAlt�n
        '
        Me.ToplamAlt�n.AutoSize = True
        Me.ToplamAlt�n.Location = New System.Drawing.Point(306, 168)
        Me.ToplamAlt�n.Name = "ToplamAlt�n"
        Me.ToplamAlt�n.Size = New System.Drawing.Size(42, 13)
        Me.ToplamAlt�n.TabIndex = 31
        Me.ToplamAlt�n.Text = "Toplam"
        '
        'ToplamS�lf�r
        '
        Me.ToplamS�lf�r.AutoSize = True
        Me.ToplamS�lf�r.Location = New System.Drawing.Point(306, 145)
        Me.ToplamS�lf�r.Name = "ToplamS�lf�r"
        Me.ToplamS�lf�r.Size = New System.Drawing.Size(42, 13)
        Me.ToplamS�lf�r.TabIndex = 30
        Me.ToplamS�lf�r.Text = "Toplam"
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
        'Toplam�arap
        '
        Me.Toplam�arap.AutoSize = True
        Me.Toplam�arap.Location = New System.Drawing.Point(306, 100)
        Me.Toplam�arap.Name = "Toplam�arap"
        Me.Toplam�arap.Size = New System.Drawing.Size(42, 13)
        Me.Toplam�arap.TabIndex = 28
        Me.Toplam�arap.Text = "Toplam"
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
        'Ya�maS�lf�r
        '
        Me.Ya�maS�lf�r.AutoSize = True
        Me.Ya�maS�lf�r.ForeColor = System.Drawing.Color.Red
        Me.Ya�maS�lf�r.Location = New System.Drawing.Point(188, 145)
        Me.Ya�maS�lf�r.Name = "Ya�maS�lf�r"
        Me.Ya�maS�lf�r.Size = New System.Drawing.Size(45, 13)
        Me.Ya�maS�lf�r.TabIndex = 23
        Me.Ya�maS�lf�r.Text = "Label12"
        '
        'Ya�maKristal
        '
        Me.Ya�maKristal.AutoSize = True
        Me.Ya�maKristal.ForeColor = System.Drawing.Color.Red
        Me.Ya�maKristal.Location = New System.Drawing.Point(188, 122)
        Me.Ya�maKristal.Name = "Ya�maKristal"
        Me.Ya�maKristal.Size = New System.Drawing.Size(45, 13)
        Me.Ya�maKristal.TabIndex = 25
        Me.Ya�maKristal.Text = "Label12"
        '
        'Ya�ma�arap
        '
        Me.Ya�ma�arap.AutoSize = True
        Me.Ya�ma�arap.ForeColor = System.Drawing.Color.Red
        Me.Ya�ma�arap.Location = New System.Drawing.Point(188, 100)
        Me.Ya�ma�arap.Name = "Ya�ma�arap"
        Me.Ya�ma�arap.Size = New System.Drawing.Size(45, 13)
        Me.Ya�ma�arap.TabIndex = 24
        Me.Ya�ma�arap.Text = "Label12"
        '
        'Ya�maMermer
        '
        Me.Ya�maMermer.AutoSize = True
        Me.Ya�maMermer.ForeColor = System.Drawing.Color.Red
        Me.Ya�maMermer.Location = New System.Drawing.Point(188, 77)
        Me.Ya�maMermer.Name = "Ya�maMermer"
        Me.Ya�maMermer.Size = New System.Drawing.Size(45, 13)
        Me.Ya�maMermer.TabIndex = 23
        Me.Ya�maMermer.Text = "Label13"
        '
        'Ya�maOdun
        '
        Me.Ya�maOdun.AutoSize = True
        Me.Ya�maOdun.ForeColor = System.Drawing.Color.Red
        Me.Ya�maOdun.Location = New System.Drawing.Point(188, 55)
        Me.Ya�maOdun.Name = "Ya�maOdun"
        Me.Ya�maOdun.Size = New System.Drawing.Size(45, 13)
        Me.Ya�maOdun.TabIndex = 22
        Me.Ya�maOdun.Text = "Label12"
        '
        'G�venliS�lf�r
        '
        Me.G�venliS�lf�r.AutoSize = True
        Me.G�venliS�lf�r.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.G�venliS�lf�r.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.G�venliS�lf�r.Location = New System.Drawing.Point(95, 145)
        Me.G�venliS�lf�r.Name = "G�venliS�lf�r"
        Me.G�venliS�lf�r.Size = New System.Drawing.Size(45, 13)
        Me.G�venliS�lf�r.TabIndex = 21
        Me.G�venliS�lf�r.Text = "Label12"
        '
        'G�venliKristal
        '
        Me.G�venliKristal.AutoSize = True
        Me.G�venliKristal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.G�venliKristal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.G�venliKristal.Location = New System.Drawing.Point(95, 122)
        Me.G�venliKristal.Name = "G�venliKristal"
        Me.G�venliKristal.Size = New System.Drawing.Size(45, 13)
        Me.G�venliKristal.TabIndex = 20
        Me.G�venliKristal.Text = "Label12"
        '
        'G�venli�arap
        '
        Me.G�venli�arap.AutoSize = True
        Me.G�venli�arap.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.G�venli�arap.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.G�venli�arap.Location = New System.Drawing.Point(95, 100)
        Me.G�venli�arap.Name = "G�venli�arap"
        Me.G�venli�arap.Size = New System.Drawing.Size(45, 13)
        Me.G�venli�arap.TabIndex = 19
        Me.G�venli�arap.Text = "Label12"
        '
        'G�venliMermer
        '
        Me.G�venliMermer.AutoSize = True
        Me.G�venliMermer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.G�venliMermer.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.G�venliMermer.Location = New System.Drawing.Point(96, 77)
        Me.G�venliMermer.Name = "G�venliMermer"
        Me.G�venliMermer.Size = New System.Drawing.Size(45, 13)
        Me.G�venliMermer.TabIndex = 18
        Me.G�venliMermer.Text = "Label12"
        '
        'G�venliOdun
        '
        Me.G�venliOdun.AutoSize = True
        Me.G�venliOdun.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.G�venliOdun.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.G�venliOdun.Location = New System.Drawing.Point(96, 55)
        Me.G�venliOdun.Name = "G�venliOdun"
        Me.G�venliOdun.Size = New System.Drawing.Size(45, 13)
        Me.G�venliOdun.TabIndex = 17
        Me.G�venliOdun.Text = "Label12"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(176, 27)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(78, 13)
        Me.Label11.TabIndex = 16
        Me.Label11.Text = "Ya�malanabilir:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(95, 27)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(46, 13)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "G�venli:"
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
    Friend WithEvents Ya�maOdun As System.Windows.Forms.Label
    Friend WithEvents G�venliS�lf�r As System.Windows.Forms.Label
    Friend WithEvents G�venliKristal As System.Windows.Forms.Label
    Friend WithEvents G�venli�arap As System.Windows.Forms.Label
    Friend WithEvents G�venliMermer As System.Windows.Forms.Label
    Friend WithEvents G�venliOdun As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Ya�maMermer As System.Windows.Forms.Label
    Friend WithEvents ToplamS�lf�r As System.Windows.Forms.Label
    Friend WithEvents ToplamKristal As System.Windows.Forms.Label
    Friend WithEvents Toplam�arap As System.Windows.Forms.Label
    Friend WithEvents ToplamMermer As System.Windows.Forms.Label
    Friend WithEvents ToplamOdun As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Ya�maS�lf�r As System.Windows.Forms.Label
    Friend WithEvents Ya�maKristal As System.Windows.Forms.Label
    Friend WithEvents Ya�ma�arap As System.Windows.Forms.Label
    Friend WithEvents ToplamAlt�n As System.Windows.Forms.Label

End Class
