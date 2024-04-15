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
        Me.Login1 = New ScadaComponentRedev.Login()
        Me.Numeric_Entry1 = New ScadaComponentRedev.Numeric_Entry()
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
        'Login1
        '
        Me.Login1.AdminstratorRightsLevel = ""
        Me.Login1.database_name = "ScadaNewDB"
        Me.Login1.Database_Password = "rmsview"
        Me.Login1.Database_UserID = "rmsview"
        Me.Login1.Location = New System.Drawing.Point(112, 407)
        Me.Login1.MinimumPasswordLength = 0
        Me.Login1.MinimumUseridLength = 0
        Me.Login1.Name = "Login1"
        Me.Login1.PasswordExpire = False
        Me.Login1.PasswordExpireday = 0
        Me.Login1.PasswordLowerCase = 0
        Me.Login1.PasswordNumericCharacter = 0
        Me.Login1.PasswordSpecialCharacter = 0
        Me.Login1.PasswordUpperCase = 0
        Me.Login1.Previous_password_Checkcount = 0
        Me.Login1.Server_Name = ".\SQLEXPRESS"
        Me.Login1.Size = New System.Drawing.Size(125, 55)
        Me.Login1.TabIndex = 3
        Me.Login1.Userlevel = New String() {"Default", "Operator", "Supervisor", "Manager", "Maintenance", "Oem1", "Oem2", "Admin", "Laber"}
        '
        'Numeric_Entry1
        '
        Me.Numeric_Entry1._RecordEvent = ScadaComponentRedev.Numeric_Entry.Record_Event.No
        Me.Numeric_Entry1.AutoSize = True
        Me.Numeric_Entry1.BackColor = System.Drawing.SystemColors.Control
        Me.Numeric_Entry1.BIT_TYPE = ScadaComponentRedev.Numeric_Entry.bittype.Bit32
        Me.Numeric_Entry1.Comparison = False
        Me.Numeric_Entry1.ComparisonType = ScadaComponentRedev.Numeric_Entry.Comparison_Type.InDirect
        Me.Numeric_Entry1.database = "ScadaNewDB"
        Me.Numeric_Entry1.Direct = False
        Me.Numeric_Entry1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Numeric_Entry1.Font_component = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Numeric_Entry1.Gain = 1.0R
        Me.Numeric_Entry1.HeaderText = ""
        Me.Numeric_Entry1.INDirect = True
        Me.Numeric_Entry1.LabelBackcolor = System.Drawing.SystemColors.Control
        Me.Numeric_Entry1.Location = New System.Drawing.Point(472, 46)
        Me.Numeric_Entry1.Maxvalue = 0.0R
        Me.Numeric_Entry1.MaxvalueD = Nothing
        Me.Numeric_Entry1.Minvalue = 0.0R
        Me.Numeric_Entry1.MinvalueD = Nothing
        Me.Numeric_Entry1.Name = "Numeric_Entry1"
        Me.Numeric_Entry1.No_of_DecimalValues = 0
        Me.Numeric_Entry1.PlcId = 0
        Me.Numeric_Entry1.Read_Only = False
        Me.Numeric_Entry1.ReadAddress = 0
        Me.Numeric_Entry1.Record_Encrypted_Data = ScadaComponentRedev.Numeric_Entry.Record_encyptedData.Yes
        Me.Numeric_Entry1.Record_time_interval_in_sec = 0
        Me.Numeric_Entry1.RecordActionMessage = ""
        Me.Numeric_Entry1.RecordData = ScadaComponentRedev.Numeric_Entry.Record_Data.InsertAlways
        Me.Numeric_Entry1.RecordMessage = Nothing
        Me.Numeric_Entry1.Recordvalue = False
        Me.Numeric_Entry1.Size = New System.Drawing.Size(13, 13)
        Me.Numeric_Entry1.TabIndex = 2
        Me.Numeric_Entry1.TagName = "graph_zoom(2)"
        Me.Numeric_Entry1.Text = "0"
        Me.Numeric_Entry1.text1 = "0"
        Me.Numeric_Entry1.TextProperty = "0"
        Me.Numeric_Entry1.ValuetoWrite = CType(0, Long)
        Me.Numeric_Entry1.Visible_Tag = ""
        Me.Numeric_Entry1.Write = 0
        Me.Numeric_Entry1.WriteAddress = 0
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(612, 504)
        Me.Controls.Add(Me.Login1)
        Me.Controls.Add(Me.Numeric_Entry1)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Numeric_Entry1 As ScadaComponentRedev.Numeric_Entry
    Friend WithEvents Login1 As ScadaComponentRedev.Login

End Class
