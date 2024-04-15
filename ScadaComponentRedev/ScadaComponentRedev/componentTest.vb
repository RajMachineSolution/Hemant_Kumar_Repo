Public Class componentTest

    Private Sub componentTest_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim c1 As New Class1()
        c1.get_tag_name()
        c1.Read_all_tag_Valuesfromdb()
        Numeric_Entry1.Text = Numeric_Entry1.readval()
        Numeric_Entry1.readval()
    End Sub
End Class
