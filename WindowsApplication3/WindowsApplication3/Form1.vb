Imports scadacomponent

Public Class Form1

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
      

    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        If Login_Register.levelname <> "" Then
            Label1.Text = Login_Register.levelname
        End If
    End Sub


End Class
