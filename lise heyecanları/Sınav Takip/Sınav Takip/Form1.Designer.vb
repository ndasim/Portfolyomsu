<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class giri�
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
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.kullan�c� = New System.Windows.Forms.TextBox
        Me.�ifre = New System.Windows.Forms.MaskedTextBox
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(90, 71)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(182, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "G�R��"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Kullan�c� Ad�:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(48, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(31, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "�ifre:"
        '
        'kullan�c�
        '
        Me.kullan�c�.Location = New System.Drawing.Point(90, 18)
        Me.kullan�c�.Name = "kullan�c�"
        Me.kullan�c�.Size = New System.Drawing.Size(182, 20)
        Me.kullan�c�.TabIndex = 3
        '
        '�ifre
        '
        Me.�ifre.Location = New System.Drawing.Point(90, 42)
        Me.�ifre.Name = "�ifre"
        Me.�ifre.Size = New System.Drawing.Size(182, 20)
        Me.�ifre.TabIndex = 5
        '
        'giri�
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 102)
        Me.Controls.Add(Me.�ifre)
        Me.Controls.Add(Me.kullan�c�)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button1)
        Me.Name = "giri�"
        Me.Text = "Ho�geldiniz "
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents kullan�c� As System.Windows.Forms.TextBox
    Friend WithEvents �ifre As System.Windows.Forms.MaskedTextBox

End Class
