Imports System.ComponentModel
Imports System.Data.SqlClient

Public Class Login

    Public Shared server = ".\SQLEXPRESS", dbname = "ScadaNewDB", dbid = "rmsview", dbpass = "rmsview"
    Public Shared PasswordExp As Boolean
    Dim PasswordExp1 As Boolean
    Dim evntlist As New EventList
   
    Public Shared useridlen As Integer
    <Browsable(True)>
    Property MinimumUseridLength As Integer
        Get
            Return useridlen
        End Get
        Set(ByVal value As Integer)
            useridlen = value

        End Set
    End Property
    Public Shared passlen As Integer
    <Browsable(True)>
    Property MinimumPasswordLength As Integer
        Get
            Return passlen
        End Get
        Set(ByVal value As Integer)
            passlen = value

        End Set
    End Property

    <Browsable(True), _
      EditorBrowsable(EditorBrowsableState.Always), _
      Category("_Database Credentials")> _
    Public Property Server_Name As String
        Get

            If SqlClass.server <> "" Then
                server = SqlClass.server
            End If
            Return server
        End Get
        Set(ByVal value As String)
            If value <> "" Then
                server = value
                SqlClass.server = value

            Else
                server = ""
                SqlClass.server = ""
            End If
        End Set
    End Property
    <Browsable(True), _
    EditorBrowsable(EditorBrowsableState.Always), _
    Category("_Database Credentials")> _
    Public Property database_name As String
        Get
            Return dbname
        End Get
        Set(ByVal value As String)
            If value <> "" Then
                dbname = value
                SqlClass.dbname = value
            Else
                SqlClass.dbname = ""
                dbname = ""
            End If
        End Set
    End Property
    <Browsable(True), _
    EditorBrowsable(EditorBrowsableState.Always), _
    Category("_Database Credentials")> _
    Public Property Database_UserID As String
        Get
            Return dbid
        End Get
        Set(ByVal value As String)
            If value <> "" Then
                dbid = value
                SqlClass.dbid = value
            Else
                dbid = ""
                SqlClass.dbid = ""
            End If
        End Set
    End Property
    <Browsable(True), _
    EditorBrowsable(EditorBrowsableState.Always), _
    Category("_Database Credentials")> _
    Public Property Database_Password As String
        Get
            Return dbpass
        End Get
        Set(ByVal value As String)
            If value <> "" Then
                dbpass = value
                SqlClass.dbpass = value
            Else
                dbpass = ""
                SqlClass.dbpass = ""
            End If
        End Set
    End Property
    <Browsable(True)>
    Public Property PasswordExpire As Boolean
        Get
            Return PasswordExp
        End Get
        Set(ByVal value As Boolean)
           
            SqlClass.px = value
            PasswordExp = value
            PasswordExp1 = value
           
        End Set
    End Property
    <Browsable(True)>
    Public Property PasswordExpireday As Integer
        Get
            Return PasswordExpday
        End Get
        Set(ByVal value As Integer)
         
            PasswordExpday = value
        
        End Set
    End Property



    Dim user_level As String() = {}
    Public Property Userlevel As String()
        Get
            Return user_level
        End Get
        Set(ByVal value As String())
            If value.Length <> 0 Then
                user_level = value
                userlevelinsert(user_level)

            Else
                user_level = New String() {}
            End If
        End Set
    End Property


    Public Shared passuppercase As Integer = 0
    <Browsable(True), _
Category("Password Complexcity")> _
    Property PasswordUpperCase As Integer
        Get
            Return passuppercase
        End Get
        Set(value As Integer)
            passuppercase = value
        End Set
    End Property
    Public Shared passlowercase As Integer = 0
    <Browsable(True), _
Category("Password Complexcity")> _
    Property PasswordLowerCase As Integer
        Get
            Return passlowercase
        End Get
        Set(value As Integer)
            passlowercase = value
        End Set
    End Property
    Public Shared passspecialchar As Integer = 0
    <Browsable(True), _
Category("Password Complexcity")> _
    Property PasswordSpecialCharacter As Integer
        Get
            Return passspecialchar
        End Get
        Set(value As Integer)
            passspecialchar = value
        End Set
    End Property
    Public Shared passnumericchar As Integer = 0
    <Browsable(True), _
Category("Password Complexcity")> _
    Property PasswordNumericCharacter As Integer
        Get
            Return passnumericchar
        End Get
        Set(value As Integer)
            passnumericchar = value
        End Set
    End Property
    Public Shared passprevoiuscheck As Integer = 0
    <Browsable(False), _
Category("Password Complexcity")> _
    Property Previous_password_Checkcount As Integer
        Get
            Return passprevoiuscheck
        End Get
        Set(value As Integer)
            passprevoiuscheck = value
        End Set
    End Property
    Dim tempadminrights = ""
    <Browsable(True), _
Category("Adminstrator Rights")> _
    Public Property AdminstratorRightsLevel As String
        Get
            Return tempadminrights
        End Get
        Set(ByVal value As String)

            tempadminrights = value

        End Set
    End Property

    Public Shared PasswordExpday As Integer = 0

    Private Sub buttonrightclick_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        userlevelinsert(user_level)
    End Sub

    Sub New()

        InitializeComponent()
        PasswordExp1 = PasswordExpire

    End Sub
    Public Shared Event Logon1(ByVal empid As String, ByVal fname As String, ByVal plevel As String)

    Public Sub loginsuccess(ByVal empid As String, ByVal fname As String, ByVal plevel As String)
        RaiseEvent Logon1(empid, fname, plevel)



        Login_Register.useridlen = useridlen
        Login_Register.passLen = passlen
        Login_Register.passLowerCase = passlowercase
        Login_Register.passNumericChar = passnumericchar
        Login_Register.passPrevoiusCheck = passprevoiuscheck
        Login_Register.passSpecialChar = passspecialchar
        Login_Register.passUpperCase = passuppercase
        Login_Register.PasswordExpday = PasswordExpireday
        Login_Register.PasswordExp = PasswordExp

        Login_Register.user_level = user_level
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim lgn As New LoginForm
        lgn.TopMost = True
        lgn.StartPosition = FormStartPosition.CenterParent
        lgn.ShowDialog()
    End Sub

    Public Sub userlevelinsert(ByVal ulevel As String()) ' multiple functionality is done by this method
        Dim sql As New SqlClass
        Dim templevelname As String() = {}
       
        Try

            If SqlClass.server <> "" And SqlClass.dbname <> "" Then
                Dim query As String = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 Select CONVERT(varchar, DecryptByKey(levelname)) as levelname from leveldetails where levelid<>1 order by levelid asc "
                sql.scon1()
                Dim sqlcmd As SqlCommand = New SqlCommand(query, sql.scn1)

                Dim reader As SqlDataReader = sqlcmd.ExecuteReader
                Dim i = 0, j = 0
                While reader.Read
                    ReDim Preserve templevelname(i)
                    templevelname(i) = reader.Item(0)

                    i = i + 1
                End While
                sqlcmd.Dispose()
                reader.Close()
                Dim count = 0

                If i = 0 Then
                    For j = 0 To ulevel.Length - 1
                        If Userlevel(j).Length = 0 Or Userlevel(j) = Nothing Then

                        Else

                            query = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 insert into leveldetails(levelname) values(EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & Userlevel(j) & "') ))"
                            '        sql.con1()
                            Dim sqlcmd1 As SqlCommand = New SqlCommand(query, sql.scn1)
                            evntlist.insertscadaevent(-1, "NEW USERLEVEL", "", "LEVEL=" + Userlevel(j), "", "", "", "", "", "", "", "", "Audittrail")

                            sqlcmd1.ExecuteNonQuery()

                            sqlcmd1.Dispose()
                        End If
                       
                    Next
                    user_level = templevelname
                    Exit Sub
                End If
                If Userlevel.Length < i Then


                    For j = 0 To ulevel.Length - 1
                        If templevelname.Contains(Userlevel(j)) Then

                        Else

                        End If
                    Next
                End If
                If Userlevel.Length > i Then


                    For j = 0 To ulevel.Length - 1
                        If templevelname.Contains(Userlevel(j)) Then

                        Else
                            query = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 insert into leveldetails(levelname) values(EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & Userlevel(j) & "') ))"
                            '        sql.con1()
                            Dim sqlcmd1 As SqlCommand = New SqlCommand(query, sql.scn1)
                            evntlist.insertscadaevent(-1, "NEW USERLEVEL", "", "LEVEL=" + Userlevel(j), "", "", "", "", "", "", "", "", "Audittrail")

                            sqlcmd1.ExecuteNonQuery()
                            sqlcmd1.Dispose()

                        End If
                    Next
                End If

                If Userlevel.Length = i Then 'this condition is for  to rename the userlevel and suffle the userlevel


                    For j = 0 To ulevel.Length - 1
                        If templevelname(j) = Userlevel(j) Then

                        Else


                            query = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 update leveldetails set levelname=EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & Userlevel(j) & "') ) where CONVERT(varchar, DecryptByKey(levelname)) ='" & templevelname(j) & "' "

                            Dim sqlcmd1 As SqlCommand = New SqlCommand(query, sql.scn1)
                            evntlist.insertscadaevent(-1, "USERLEVEL CHANGED", "", "From=" + templevelname(j) & " To=" + Userlevel(j), "", "", "", "", "", "", "", "", "Audittrail")
                            sqlcmd1.ExecuteNonQuery()
                            sqlcmd1.Dispose()




                        End If
                    Next
                End If
                sql.scn1.Close()

                If Userlevel.Length = 0 Then ' to intailise the user property if database contain userlevel 

                    user_level = templevelname


                End If
            End If
        Catch ex As Exception
        End Try

    End Sub
End Class


