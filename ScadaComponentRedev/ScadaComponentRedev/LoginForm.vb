Public Class LoginForm

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        AddHandler Login_Register1.Logon, AddressOf login_successfull
    End Sub
    Dim lgn = New Login
    Public Sub login_successfull(ByVal empid, ByVal fname, ByVal plevel)
        If empid = -1 Then
            Login_Register.plevel = 0
            Login_Register.levelId = 0
            Label1.Text = "Hello"
            Label2.Text = ""
            Label1.Text = "Hellow Guest User !"
            Label2.Text = "NA"
        Else
            Label1.Text = "Hello " & fname
            Label2.Text = "Level : " & Login_Register.levelName
        End If
        lgn.loginsuccess(empid, fname, plevel)
    End Sub

    Private Sub LoginForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class