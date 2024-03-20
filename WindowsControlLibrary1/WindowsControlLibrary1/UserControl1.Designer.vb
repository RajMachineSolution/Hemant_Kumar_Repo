<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserControl1
    Inherits System.Windows.Forms.UserControl

    'UserControl1 overrides dispose to clean up the component list.
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
        Me.username1 = New System.Windows.Forms.TextBox()
        Me.pass1 = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'username1
        '
        Me.username1.Location = New System.Drawing.Point(3, 3)
        Me.username1.Name = "username1"
        Me.username1.Size = New System.Drawing.Size(100, 20)
        Me.username1.TabIndex = 0
        Me.username1.Text = "name"
        '
        'pass1
        '
        Me.pass1.Location = New System.Drawing.Point(3, 38)
        Me.pass1.Name = "pass1"
        Me.pass1.Size = New System.Drawing.Size(100, 20)
        Me.pass1.TabIndex = 1
        Me.pass1.Text = "pass"
        '
        'UserControl1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.pass1)
        Me.Controls.Add(Me.username1)
        Me.Name = "UserControl1"
        Me.Size = New System.Drawing.Size(163, 115)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents username1 As System.Windows.Forms.TextBox
    Friend WithEvents pass1 As System.Windows.Forms.TextBox

End Class
