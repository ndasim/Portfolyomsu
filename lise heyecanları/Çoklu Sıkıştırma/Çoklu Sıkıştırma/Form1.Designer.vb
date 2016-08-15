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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Göstergec = New System.Windows.Forms.RichTextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(70, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(134, 76)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Sünger Oluştur"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(358, 12)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(129, 76)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "Sünger Sıkıştır"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Göstergec
        '
        Me.Göstergec.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.Göstergec.Location = New System.Drawing.Point(13, 120)
        Me.Göstergec.Name = "Göstergec"
        Me.Göstergec.Size = New System.Drawing.Size(538, 419)
        Me.Göstergec.TabIndex = 2
        Me.Göstergec.Text = ""
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.Cornsilk
        Me.TextBox1.Location = New System.Drawing.Point(284, 94)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(266, 20)
        Me.TextBox1.TabIndex = 3
        Me.TextBox1.Text = "C:\Users\Ev Bilgisayarı\Desktop\Süngerdenek.çsd"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'TextBox2
        '
        Me.TextBox2.BackColor = System.Drawing.Color.Gold
        Me.TextBox2.Location = New System.Drawing.Point(12, 94)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(266, 20)
        Me.TextBox2.TabIndex = 3
        Me.TextBox2.Text = "C:\Users\Ev Bilgisayarı\Desktop\Süngerdenek.çsd"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(563, 551)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Göstergec)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Göstergec As System.Windows.Forms.RichTextBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox

End Class
