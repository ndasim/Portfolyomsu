<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ana_server
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
        Me.çizim_tarlası = New System.Windows.Forms.GroupBox
        Me.y = New System.Windows.Forms.TextBox
        Me.x = New System.Windows.Forms.TextBox
        Me.kontrol = New System.Windows.Forms.TextBox
        Me.çizim_tarlası.SuspendLayout()
        Me.SuspendLayout()
        '
        'çizim_tarlası
        '
        Me.çizim_tarlası.Controls.Add(Me.kontrol)
        Me.çizim_tarlası.Controls.Add(Me.y)
        Me.çizim_tarlası.Controls.Add(Me.x)
        Me.çizim_tarlası.Location = New System.Drawing.Point(20, 20)
        Me.çizim_tarlası.Name = "çizim_tarlası"
        Me.çizim_tarlası.Size = New System.Drawing.Size(236, 170)
        Me.çizim_tarlası.TabIndex = 0
        Me.çizim_tarlası.TabStop = False
        Me.çizim_tarlası.Text = "çizim_tarlası"
        '
        'y
        '
        Me.y.Location = New System.Drawing.Point(28, 60)
        Me.y.Name = "y"
        Me.y.Size = New System.Drawing.Size(100, 20)
        Me.y.TabIndex = 1
        '
        'x
        '
        Me.x.Location = New System.Drawing.Point(28, 34)
        Me.x.Name = "x"
        Me.x.Size = New System.Drawing.Size(100, 20)
        Me.x.TabIndex = 0
        '
        'kontrol
        '
        Me.kontrol.Location = New System.Drawing.Point(28, 86)
        Me.kontrol.Name = "kontrol"
        Me.kontrol.Size = New System.Drawing.Size(100, 20)
        Me.kontrol.TabIndex = 2
        '
        'ana_server
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(359, 264)
        Me.Controls.Add(Me.çizim_tarlası)
        Me.Name = "ana_server"
        Me.Text = "aç1"
        Me.çizim_tarlası.ResumeLayout(False)
        Me.çizim_tarlası.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents çizim_tarlası As System.Windows.Forms.GroupBox
    Friend WithEvents y As System.Windows.Forms.TextBox
    Friend WithEvents x As System.Windows.Forms.TextBox
    Friend WithEvents kontrol As System.Windows.Forms.TextBox
End Class
