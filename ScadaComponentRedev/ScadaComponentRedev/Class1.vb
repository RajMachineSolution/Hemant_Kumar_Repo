Imports System.Data.SqlClient

Public Class Class1

    Public Shared is_encrypted = False
    Public Shared tag() As String 'array of tag

    Dim address As Integer
    Dim querystring As String
    Dim sqlcmd1 As SqlCommand
    Dim sql1 As New ScadaComponentRedev.SqlClass
    Dim var As String

    Dim tag_name_array() As String
    Public Sub get_tag_name()
        Try
            Dim sql1 As New SqlClass
            Dim sqlcmd1 As SqlCommand
            sql1.conn3()
            'query returns maximun value of tag id
            Dim querystring As String = " select Tag_id,Tag_name FROM Tag_data order by tag_id asc "
            sqlcmd1 = New SqlCommand(querystring, sql1.cn3)
            Using reader As SqlDataReader = sqlcmd1.ExecuteReader
                While reader.Read
                    'define size of tag array with maximum number of tag id in database tag table
                    If IsDBNull(reader.Item(0)) Then
                        tag_name_array(reader.Item(0)) = reader.Item(1)
                    Else
                        tag_name_array(reader.Item(0)) = reader.Item(1)
                    End If
                End While
            End Using
            sql1.cn3.Close()
        Catch ex As Exception
        End Try
    End Sub
    Sub Read_all_tag_Valuesfromdb()
        resizestringarray() 'resize tag array if new tag is insert then it will resize tag array at run time
        sql1.conn3()

        If sql1.cn3.State = ConnectionState.Open Then
            querystring = ""
            If is_encrypted Then
                querystring = " open symmetric key symmetrickey1 decryption by certificate certificate1 select Tag_id, convert(varchar, decryptbykey(Read_value)) as Read_value  from Tag_data   "
            Else
                querystring = " select Tag_id, Read_value  from Tag_data   "
            End If


            sqlcmd1 = New SqlCommand(querystring, sql1.cn3)
            Using reader As SqlDataReader = sqlcmd1.ExecuteReader
                While reader.Read
                    tag(reader.Item("Tag_id")) = reader.Item("Read_value")
                End While
            End Using
            sql1.cn3.Close()
        Else
        End If
    End Sub

    Dim readvalue As String = ""
    'this function return tag value given tag name
    

    'redim tag array
    Public Sub resizestringarray()
        Try
            Dim sql1 As New ScadaComponentRedev.SqlClass
            Dim sqlcmd1 As SqlCommand
            sql1.conn3()
            'query returns maximun value of tag id
            Dim querystring As String = "  select max(Tag_id) from Tag_data   "
            sqlcmd1 = New SqlCommand(querystring, sql1.cn3)
            Using reader As SqlDataReader = sqlcmd1.ExecuteReader
                If reader.Read = True Then
                    'define size of tag array with maximum number of tag id in database tag table
                    If IsDBNull(reader.Item(0)) Then
                        ReDim Class1.tag(1)
                        ReDim variableclass.tag(1)
                        ReDim tag_name_array(1)
                    Else
                        ReDim Class1.tag(reader.Item(0) + 1)
                        ReDim variableclass.tag(reader.Item(0) + 1)
                        ReDim tag_name_array(reader.Item(0) + 1)
                    End If
                End If
            End Using
            sql1.cn3.Close()
        Catch ex As Exception
        End Try
    End Sub
End Class
