Imports System.Data.SqlClient

Public Class EventList
    Dim sql As New SqlClass
    Dim connetionString As String = "Data Source=.\sqlexpress;DataBase=Pharma;user id=rmsview;password=rmsview"
    Dim cnn As SqlConnection
    Public Shared eventname(100) As String
    Public Shared var1(100), var2(100), var3(100), var4(100), var5(100), action(100) As String 'status is used to record   the action taken by like plc action,user action , alarm action etc
    Public Shared selectvar(100) As Boolean
    'Public Shared SQL As String
    Sub New()
        connetionString = "Data Source=.\sqlexpress;DataBase=phrencrydecry;user id=rmsview;password=rmsview"
    End Sub

    Public Sub insertscadaevent(ByVal empid As Integer, ByVal eventname As String, ByVal var1 As String, ByVal var2 As String, ByVal var3 As String, ByVal var4 As String, ByVal var5 As String, ByVal var6 As String, ByVal var7 As String, ByVal var8 As String, ByVal var9 As String, ByVal var10 As String, ByVal action As String) ' this method is used in scada to record action of scada
        Try
            Dim t = variableclass.timee
            variableclass.timee = DateTime.Now.ToString("HH:mm:ss")
            variableclass.datee = DateTime.Now.ToString("d-M-yy")
          
            sql.scon1()
            If variableclass.datee <> "" Then
                Dim sqlquery = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 insert into eventlist (empid,date,time,eventname,var1,var2,var3,var4,var5,var6,var7,var8,var9,var10,action)values('" & empid & "',EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & variableclass.datee & "') ),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & variableclass.timee & "') ) ,EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar(max),'" & eventname & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar(max),'" & var1 & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar(max),'" & var2 & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar(max),'" & var3 & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar(max),'" & var4 & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar(max),'" & var5 & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar(max),'" & var6 & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar(max),'" & var7 & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar(max),'" & var8 & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar(max),'" & var9 & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar(max),'" & var10 & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar(max),'" & action & "')))"
                Dim cmd = New SqlCommand(sqlquery, sql.scn1)
                cmd.CommandTimeout = 60
                cmd.ExecuteNonQuery()
            End If
            ' cnn1.Open()
            sql.scn1.Close()
        Catch ex As Exception
            MsgBox(ex.Message)

            ' MsgBox("Can not open connection  insertscadaevent! ")
        End Try
    End Sub
End Class
