Imports System.Data.SqlClient

Public Class RegisterDetails
    Dim sql As New SqlClass
    Public tempregister As RegisterDetails

    'call gilldata sub on TegisterDettails form load
    Private Sub RegisterDetails_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        filldata()
    End Sub

    'this sub is used to get all user details from levelDetails and employeeinfo exclude impid 2 and login with current impid
    'fetched data assign to datagridview (detailsgrid)
    Sub filldata()
        Dim query = ""
        
        Try
            Dim da As SqlDataAdapter
            Dim ds As New DataSet
            sql.conn1()
            If Login_Register.levelId = 1 Then
                query = "  OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 Select CONVERT(varchar, DecryptByKey(fname)) as 'Full Name',CONVERT(varchar, DecryptByKey(userid)) as UserId,(select CONVERT(varchar, DecryptByKey(levelname)) from leveldetails where levelid=e.plevel) as level,CASE active WHEN 2 THEN 'Deactivated' WHEN 1 THEN 'Activated' end as Status from employeeinfo as e where empid<>1 and empid<>2 order by 'full name' "

            Else
                query = "  OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 Select CONVERT(varchar, DecryptByKey(fname)) as 'Full Name',CONVERT(varchar, DecryptByKey(userid)) as UserId,(select CONVERT(varchar, DecryptByKey(levelname)) from leveldetails where levelid=e.plevel) as level,CASE active WHEN 2 THEN 'Deactivated' WHEN 1 THEN 'Activated' end as Status from employeeinfo as e where empid<>1 and empid<>2 and plevel <>'" & Login_Register.levelId & "' order by 'full name' "

            End If
            Dim cmd = New SqlCommand(query, sql.cn1)
            cmd.CommandTimeout = 60
            da = New SqlDataAdapter(cmd)
            da.Fill(ds)
            detailsgrid.DataSource = ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        sql.cn1.Close()
    End Sub

    'cellContentclick Event handler for detailsgrid
    'get userid from datagrid cell, pass this userid to RegDetails constructor as argument
    'open RegDetails form
    Private Sub detailsgrid_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles detailsgrid.CellContentClick
        If e.RowIndex < 0 Then
            For Each column As DataGridViewColumn In detailsgrid.Columns
                column.SortMode = DataGridViewColumnSortMode.NotSortable
            Next
            Exit Sub
        End If

        If e.ColumnIndex = 0 Then
            Dim t = detailsgrid.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
            Dim userid = detailsgrid.Rows(e.RowIndex).Cells(1).Value.ToString.Trim
            Dim regdetail As New RegDetails(userid)
            regdetail.TopMost = True
            regdetail.StartPosition = FormStartPosition.CenterParent
            regdetail.ShowDialog()

        End If
    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        filldata()
    End Sub
End Class