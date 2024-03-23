Imports ScadaComponentRedev
Public Class Form1

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
       
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Label1.Text = Login_Register.levelName
        Label2.Text = Login_Register.Fname
    End Sub

    Private Sub Login1_Load(sender As System.Object, e As System.EventArgs) Handles Login1.Load

    End Sub
End Class
