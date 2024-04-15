

Public Class Form1

    

    Public Shared logincontrol As Boolean = True ' if logincontrol included make it true else false
    Public Shared defaultloginExist As Boolean = True 'if default user given make it true else false
    Private objMutex As System.Threading.Mutex

    Public Shared frmobj(10) As Form ' object of form used as popup


    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load


    End Sub

    



End Class
