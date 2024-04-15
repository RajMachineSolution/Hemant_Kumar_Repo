<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class componentTest
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.Numeric_Entry1 = New ScadaComponentRedev.Numeric_Entry()
        Me.SuspendLayout()
        '
        'Numeric_Entry1
        '
        Me.Numeric_Entry1._RecordEvent = ScadaComponentRedev.Numeric_Entry.Record_Event.No
        Me.Numeric_Entry1.AutoSize = True
        Me.Numeric_Entry1.BackColor = System.Drawing.Color.Yellow
        Me.Numeric_Entry1.BIT_TYPE = ScadaComponentRedev.Numeric_Entry.bittype.Bit16
        Me.Numeric_Entry1.Comparison = True
        Me.Numeric_Entry1.ComparisonType = ScadaComponentRedev.Numeric_Entry.Comparison_Type.Direct
        Me.Numeric_Entry1.database = "ScadaNewDB"
        Me.Numeric_Entry1.Direct = True
        Me.Numeric_Entry1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Numeric_Entry1.Font_component = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Numeric_Entry1.Gain = 1.0R
        Me.Numeric_Entry1.HeaderText = ""
        Me.Numeric_Entry1.INDirect = False
        Me.Numeric_Entry1.LabelBackcolor = System.Drawing.Color.Yellow
        Me.Numeric_Entry1.Location = New System.Drawing.Point(20, 16)
        Me.Numeric_Entry1.Maxvalue = 0.0R
        Me.Numeric_Entry1.MaxvalueD = "speed(5)"
        Me.Numeric_Entry1.Minvalue = 0.0R
        Me.Numeric_Entry1.MinvalueD = "speed(0)"
        Me.Numeric_Entry1.Name = "Numeric_Entry1"
        Me.Numeric_Entry1.No_of_DecimalValues = 0
        Me.Numeric_Entry1.PlcId = 0
        Me.Numeric_Entry1.Read_Only = False
        Me.Numeric_Entry1.ReadAddress = 0
        Me.Numeric_Entry1.Record_Encrypted_Data = ScadaComponentRedev.Numeric_Entry.Record_encyptedData.Yes
        Me.Numeric_Entry1.Record_time_interval_in_sec = 0
        Me.Numeric_Entry1.RecordActionMessage = ""
        Me.Numeric_Entry1.RecordData = ScadaComponentRedev.Numeric_Entry.Record_Data.UpdataAlways
        Me.Numeric_Entry1.RecordMessage = Nothing
        Me.Numeric_Entry1.Recordvalue = False
        Me.Numeric_Entry1.Size = New System.Drawing.Size(13, 13)
        Me.Numeric_Entry1.TabIndex = 0
        Me.Numeric_Entry1.TagName = "speed(3)"
        Me.Numeric_Entry1.Text = "0"
        Me.Numeric_Entry1.text1 = "0"
        Me.Numeric_Entry1.TextProperty = "0"
        Me.Numeric_Entry1.ValuetoWrite = CType(0, Long)
        Me.Numeric_Entry1.Visible_Tag = ""
        Me.Numeric_Entry1.Write = 0
        Me.Numeric_Entry1.WriteAddress = 0
        '
        'componentTest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Numeric_Entry1)
        Me.Name = "componentTest"
        Me.Size = New System.Drawing.Size(249, 241)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Numeric_Entry1 As ScadaComponentRedev.Numeric_Entry

End Class
