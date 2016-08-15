<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class sunucu
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
        Me.veritabanı = New System.Windows.Forms.RichTextBox
        Me.SuspendLayout()
        '
        'veritabanı
        '
        Me.veritabanı.Location = New System.Drawing.Point(12, 12)
        Me.veritabanı.Name = "veritabanı"
        Me.veritabanı.Size = New System.Drawing.Size(636, 131)
        Me.veritabanı.TabIndex = 0
        Me.veritabanı.Text = ""
        '
        'sunucu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(660, 264)
        Me.Controls.Add(Me.veritabanı)
        Me.Name = "sunucu"
        Me.Text = "sunucu"
        Me.TopMost = True
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents veritabanı As System.Windows.Forms.RichTextBox
End Class
