Imports scadacomponent
Public Class Form1

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'APM_NEWDataSet3.Grid_for_graph1' table. You can move, or remove it, as needed.
        Me.Grid_for_graph1TableAdapter.Fill(Me.APM_NEWDataSet3.Grid_for_graph1)
        'TODO: This line of code loads data into the 'APM_NEWDataSet2.batchproduct' table. You can move, or remove it, as needed.



    End Sub

    Private Sub AlarmControl1_Load(sender As System.Object, e As System.EventArgs)

    End Sub


    Private Sub Login_Register1_Load(sender As System.Object, e As System.EventArgs) Handles Login_Register1.Load

    End Sub
End Class
