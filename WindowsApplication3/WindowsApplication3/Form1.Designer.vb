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
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Login_Register1 = New scadacomponent.Login_Register()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(53, 371)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Label1"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 500
        '
        'Login_Register1
        '
        Me.Login_Register1.AdminstratorRightsLevel = "Operator"
        Me.Login_Register1.ALarmAction = New String(-1) {}
        Me.Login_Register1.Alarmlist = New String(-1) {}
        Me.Login_Register1.database = ""
        Me.Login_Register1.database_name = "APM_NEW"
        Me.Login_Register1.Database_Password = "rmsview"
        Me.Login_Register1.Database_UserID = "rmsview"
        Me.Login_Register1.EventName = New String(-1) {}
        Me.Login_Register1.IdealLogoutTimeOFScada = 0
        Me.Login_Register1.Location = New System.Drawing.Point(56, 24)
        Me.Login_Register1.MinimumPasswordLength = 0
        Me.Login_Register1.MinimumUseridLength = 0
        Me.Login_Register1.Name = "Login_Register1"
        Me.Login_Register1.PasswordExpire = False
        Me.Login_Register1.PasswordExpireday = 0
        Me.Login_Register1.PasswordLowerCase = 0
        Me.Login_Register1.PasswordNumericCharacter = 0
        Me.Login_Register1.PasswordSpecialCharacter = 0
        Me.Login_Register1.PasswordUpperCase = 0
        Me.Login_Register1.Previous_password_Checkcount = 0
        Me.Login_Register1.RecordloginAction = True
        Me.Login_Register1.Server_Name = ".\SQLEXPRESS"
        Me.Login_Register1.Size = New System.Drawing.Size(316, 344)
        Me.Login_Register1.TabIndex = 0
        Me.Login_Register1.Userlevel = New String(-1) {}
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(482, 458)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Login_Register1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Login_Register1 As scadacomponent.Login_Register
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer

End Class
