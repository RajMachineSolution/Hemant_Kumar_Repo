Imports System.Data.SqlClient

'provide sql server connection
Public Class SqlClass
    Public Shared server = ".\SQLEXPRESS"
    Public Shared dbname = "ScadaNewDB"
    Public Shared dbid = "rmsview"
    Public Shared dbpass As String = "rmsview"
    Public Shared px As Boolean
    Public Shared sqlcon As New SqlConnection
    Public cn1, cn2, cn3, cn4, cn5, cnb As SqlConnection
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

    Public Sub conn1()
      
        Try
            sqlcon = New SqlConnection With {.ConnectionString = "server=" & server & "; Database= " & dbname & ";user id= " & dbid & ";password=" & dbpass & ";"}

            cn1 = sqlcon
            cn1.Open()

        Catch ex As Exception
            MsgBox("Can not open connection ! -" & ex.Message)
        End Try

    End Sub
    Public Shared Function AES_Encrypt(ByVal input As String, ByVal pass As String) As String
        Dim AES As New System.Security.Cryptography.RijndaelManaged
        Dim Hash_AES As New System.Security.Cryptography.MD5CryptoServiceProvider
        Dim encrypted As String = ""
        Try
            Dim hash(31) As Byte
            Dim temp As Byte() = Hash_AES.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(pass))
            Array.Copy(temp, 0, hash, 0, 16)
            Array.Copy(temp, 0, hash, 15, 16)
            AES.Key = hash
            AES.Mode = Security.Cryptography.CipherMode.ECB
            Dim DESEncrypter As System.Security.Cryptography.ICryptoTransform = AES.CreateEncryptor
            Dim Buffer As Byte() = System.Text.ASCIIEncoding.ASCII.GetBytes(input)
            encrypted = Convert.ToBase64String(DESEncrypter.TransformFinalBlock(Buffer, 0, Buffer.Length))
            Return encrypted
        Catch ex As Exception
        End Try
        Return encrypted
    End Function
End Class
