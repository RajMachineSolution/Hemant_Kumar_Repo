<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class login
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
        Me.Login_Register1 = New ScadaComponentRedev.Login_Register()
        Me.SuspendLayout()
        '
        'Login_Register1
        '
        Me.Login_Register1.AdminstratorRightsLevel = ""
        Me.Login_Register1.database = ""
        Me.Login_Register1.database_name = "ScadaNewDB"
        Me.Login_Register1.Database_Password = "rmsview"
        Me.Login_Register1.Database_UserID = "rmsview"
        Me.Login_Register1.EventName = New String(-1) {}
        Me.Login_Register1.Location = New System.Drawing.Point(20, 89)
        Me.Login_Register1.Margin = New System.Windows.Forms.Padding(2)
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
        Me.Login_Register1.Size = New System.Drawing.Size(303, 347)
        Me.Login_Register1.TabIndex = 0
        Me.Login_Register1.Userlevel = New String() {"Operator", "Supervisor", "Manager", "Maintenance", "Oem1", "Oem2", "Admin"}
        '
        'login
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(358, 479)
        Me.Controls.Add(Me.Login_Register1)
        Me.Name = "login"
        Me.Text = "login"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Login_Register1 As ScadaComponentRedev.Login_Register
End Class
