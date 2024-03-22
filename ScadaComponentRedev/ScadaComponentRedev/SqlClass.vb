Imports System.Data.SqlClient

Public Class SqlClass
    Public Shared server = ".\SQLEXPRESS"
    Public Shared dbname = "ScadaNewDB"
    Public Shared dbid = "rmsview"
    Public Shared dbpass As String = "rmsview"
    Public Shared px As Boolean
    Public Shared sqlcon As New SqlConnection
    Public Shared cnn1 As SqlConnection
    Public scn1, scn2, scn3, scn4, scn5 As SqlConnection
    Public Shared database As String = ""

    Public Sub con1()
        sqlcon = New SqlConnection With {.ConnectionString = "server=" & server & "; Database= " & dbname & ";user id= " & dbid & ";password=" & dbpass & ";"}

        Try
            cnn1 = sqlcon
        Catch ex As Exception
            MsgBox("Can not open connection ! -" & ex.Message)
        End Try

    End Sub
   

    Public Sub scon1()
       
        sqlcon = New SqlConnection With {.ConnectionString = "server=" & server & "; Database= " & dbname & ";user id= " & dbid & ";password=" & dbpass & ";"}

        Try
            scn1 = sqlcon
            scn1.Open()

        Catch ex As Exception

        End Try

    End Sub
    Public Sub scon2()
       
        sqlcon = New SqlConnection With {.ConnectionString = "server=" & server & "; Database= " & dbname & ";user id= " & dbid & ";password=" & dbpass & ";"}

        Try
            scn2 = sqlcon
            scn2.Open()
        Catch ex As Exception
            MsgBox("Can not open connection ! -" & ex.Message)
        End Try

    End Sub

    Sub scon3()
        sqlcon = New SqlConnection With {.ConnectionString = "server=" & server & "; Database= " & dbname & ";user id= " & dbid & ";password=" & dbpass & ";"}

        scn3 = sqlcon
        scn3.Open()
    End Sub

    Public Sub scon4()

        dbname = database
        dbid = "rmsview"
        dbpass = "rmsview"

        sqlcon = New SqlConnection With {.ConnectionString = "server=" & server & "; Database= " & dbname & ";user id= " & dbid & ";password=" & dbpass & ";"}
        Try
            scn4 = sqlcon
            scn4.Open()
        Catch ex As Exception
            MsgBox("Can not open connection ! -" & ex.Message)
        End Try

    End Sub

End Class
