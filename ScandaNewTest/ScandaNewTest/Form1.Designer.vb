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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Login1 = New ScadaComponentRedev.Login()
        Me.Login_Register1 = New ScadaComponentRedev.Login_Register()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(37, 25)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 17)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Label1"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(37, 69)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 17)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Label2"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 500
        '
        'Login1
        '
        Me.Login1.AdminstratorRightsLevel = ""
        Me.Login1.database_name = "ScadaNewDB"
        Me.Login1.Database_Password = "rmsview"
        Me.Login1.Database_UserID = "rmsview"
        Me.Login1.Location = New System.Drawing.Point(15, 658)
        Me.Login1.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.Login1.MinimumPasswordLength = 4
        Me.Login1.MinimumUseridLength = 4
        Me.Login1.Name = "Login1"
        Me.Login1.PasswordExpire = True
        Me.Login1.PasswordExpireday = 2
        Me.Login1.PasswordLowerCase = 1
        Me.Login1.PasswordNumericCharacter = 1
        Me.Login1.PasswordSpecialCharacter = 1
        Me.Login1.PasswordUpperCase = 1
        Me.Login1.Previous_password_Checkcount = 0
        Me.Login1.Server_Name = ".\SQLEXPRESS"
        Me.Login1.Size = New System.Drawing.Size(167, 68)
        Me.Login1.TabIndex = 3
        Me.Login1.Userlevel = New String() {"Operator", "Supervisor", "Manager", "Maintenance", "Oem1", "Oem2", "Admin"}
        '
        'Login_Register1
        '
        Me.Login_Register1.AdminstratorRightsLevel = ""
        Me.Login_Register1.database = ""
        Me.Login_Register1.database_name = "ScadaNewDB"
        Me.Login_Register1.Database_Password = "rmsview"
        Me.Login_Register1.Database_UserID = "rmsview"
        Me.Login_Register1.EventName = New String(-1) {}
        Me.Login_Register1.Location = New System.Drawing.Point(15, 150)
        Me.Login_Register1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Login_Register1.MinimumPasswordLength = 4
        Me.Login_Register1.MinimumUseridLength = 3
        Me.Login_Register1.Name = "Login_Register1"
        Me.Login_Register1.PasswordExpire = True
        Me.Login_Register1.PasswordExpireday = 2
        Me.Login_Register1.PasswordLowerCase = 1
        Me.Login_Register1.PasswordNumericCharacter = 1
        Me.Login_Register1.PasswordSpecialCharacter = 1
        Me.Login_Register1.PasswordUpperCase = 2
        Me.Login_Register1.Previous_password_Checkcount = 0
        Me.Login_Register1.RecordloginAction = False
        Me.Login_Register1.Server_Name = ".\SQLEXPRESS"
        Me.Login_Register1.Size = New System.Drawing.Size(404, 427)
        Me.Login_Register1.TabIndex = 0
        Me.Login_Register1.Userlevel = New String() {"Operator", "Supervisor", "Manager", "Maintenance", "Oem1", "Oem2", "Admin"}
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(41, 583)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(100, 28)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(475, 769)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Login1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Login_Register1)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Login_Register1 As ScadaComponentRedev.Login_Register
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Login1 As ScadaComponentRedev.Login
    Friend WithEvents Button1 As System.Windows.Forms.Button

End Class
