Imports System.Data.SqlClient

Public Class SqlClass
    Public Shared server = ".\SQLEXPRESS"
    Public Shared dbname = "APM_NEW"
    Public Shared dbid = "rmsview"
    Public Shared dbpass As String = "rmsview"
    Public Shared px As Boolean
    Public Shared sqlcon As New SqlConnection
    Public Shared cnn1 As SqlConnection
    Public Shared database As String = ""

    Public Sub con1()
        sqlcon = New SqlConnection With {.ConnectionString = "server=" & server & "; Database= " & dbname & ";user id= " & dbid & ";password=" & dbpass & ";"}

        Try
            cnn1 = sqlcon
        Catch ex As Exception
            MsgBox("Can not open connection ! -" & ex.Message)
        End Try

    End Sub
End Class
