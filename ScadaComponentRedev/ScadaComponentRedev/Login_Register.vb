Imports System.ComponentModel

Public Class Login_Register
    Public Shared SecondsCount As Integer = 0
    Public Shared server = ".\SQLEXPRESS", dbname = "APM_NEW", dbid = "rmsview", dbpass = "rmsview"
    Public Shared empid, Fname, plevel As String
    Public Shared tryLoginUserId As String = "first"
    Public Shared tryLoginCount As Integer
    Public Shared lotNo = "", batchNo = ""
    Public Shared levelId, levelName As String
    Public Event Logon(ByVal empid As String, ByVal fname As String, ByVal plevel As String)
    Public Shared actionname() As String = {"Aduittrail", "EventList", "Alarm"}
    Public Event regon()
    Dim loginDetailsFlag As Boolean = False

    Public Shared PasswordExp As Boolean
    Dim PasswordExp1 As Boolean
    Dim evntlist As New EventList
    Public Shared PasswordExpday As Integer = 0
    'time for logout when system is ideal form given time In seconds
    Public Shared idealLogoutTime As Integer = 0
    <Browsable(True)>
    Property IdealLogoutTimeOFScada As Integer
        Get
            Return idealLogoutTime
        End Get
        Set(ByVal value As Integer)
            idealLogoutTime = value
        End Set
    End Property

    Public Shared db As String = ""
    Property database As String
        Get
            Return db
        End Get
        Set(ByVal value As String)
            db = value
        End Set
    End Property

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

    Public Shared passLen As Integer
    <Browsable(True)>
    Property MinimumPasswordLength As Integer
        Get
            Return passLen
        End Get
        Set(ByVal value As Integer)
            passLen = value
        End Set
    End Property

    <Browsable(True), _
      EditorBrowsable(EditorBrowsableState.Always), _
      Category("SQL"), _
      Description("The items with sub items that should be displayed")> _
    Public Property Server_Name As String
        Get

            Return server
        End Get
        Set(ByVal value As String)
            If value <> "" Then
                server = value
            Else
                server = ""
            End If
        End Set
    End Property

    Public Property database_name As String
        Get
            Return dbname
        End Get
        Set(ByVal value As String)
            If value <> "" Then
                dbname = value
            Else
                dbname = ""
            End If
        End Set
    End Property

    Public Property Database_UserID As String
        Get
            Return dbid
        End Get
        Set(ByVal value As String)
            If value <> "" Then
                dbid = value
            Else
                dbid = ""
            End If
        End Set
    End Property

    Public Property Database_Password As String
        Get
            Return dbpass
        End Get
        Set(ByVal value As String)
            If value <> "" Then
                dbpass = value
            Else
                dbpass = ""
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

    Public Shared user_level As String() = {}
    Public Property Userlevel As String()
        Get
            Return user_level
        End Get
        Set(ByVal value As String())
            If value.Length <> 0 Then
                user_level = value
            Else
                user_level = New String() {}
            End If
        End Set
    End Property

    Public Shared Alarm_list As String() = {}
    <Browsable(True), _
    EditorBrowsable(EditorBrowsableState.Always), _
    Category("Define Levels"), _
    Description("The items with sub items that should be displayed")> _
    Public Property Alarmlist As String()
        Get
            Return Alarm_list
        End Get
        Set(ByVal value As String())
            If value.Length <> 0 Then
                Alarm_list = value
            Else
                Alarm_list = New String() {}
            End If
        End Set
    End Property

    Public Shared Alarm_Action As String() = {}
    <Browsable(True), _
     EditorBrowsable(EditorBrowsableState.Always), _
     Category("Define Levels"), _
     Description("The items with sub items that should be displayed")> _
    Public Property ALarmAction As String()
        Get
            Return Alarm_Action
        End Get
        Set(ByVal value As String())
            If value.Length <> 0 Then
                Alarm_Action = value
            Else
                Alarm_Action = New String() {}
            End If
        End Set
    End Property

    Public Shared Event_Name As String() = {}
    <Browsable(True), _
     EditorBrowsable(EditorBrowsableState.Always), _
     Category("Define Levels"), _
     Description("The items with sub items that should be displayed")> _
    Public Property EventName As String()
        Get
            Return Event_Name
        End Get
        Set(ByVal value As String())
            If value.Length <> 0 Then
                Event_Name = value
            Else
                Event_Name = New String() {}
            End If
        End Set
    End Property

    <Browsable(True), _
   EditorBrowsable(EditorBrowsableState.Always), _
   Category("Define Levels"), _
   Description("The items with sub items that should be displayed")> _
    Public Property RecordloginAction As Boolean
        Get
            Return loginDetailsFlag
        End Get
        Set(ByVal value As Boolean)
            loginDetailsFlag = value
        End Set
    End Property

    Public Shared passUpperCase As Integer = 0
    <Browsable(True), _
Category("Password Complexcity")> _
    Property PasswordUpperCase As Integer
        Get
            Return passUpperCase
        End Get
        Set(value As Integer)
            passUpperCase = value
        End Set
    End Property

    Public Shared passLowerCase As Integer = 0
    <Browsable(True), _
Category("Password Complexcity")> _
    Property PasswordLowerCase As Integer
        Get
            Return passLowerCase
        End Get
        Set(value As Integer)
            passLowerCase = value
        End Set
    End Property

    Public Shared passSpecialChar As Integer = 0
    <Browsable(True), _
Category("Password Complexcity")> _
    Property PasswordSpecialCharacter As Integer
        Get
            Return passSpecialChar
        End Get
        Set(value As Integer)
            passSpecialChar = value
        End Set
    End Property

    Public Shared passNumericChar As Integer = 0
    <Browsable(True), _
Category("Password Complexcity")> _
    Property PasswordNumericCharacter As Integer
        Get
            Return passNumericChar
        End Get
        Set(value As Integer)
            passNumericChar = value
        End Set
    End Property

    Public Shared passPrevoiusCheck As Integer = 0
    <Browsable(True), _
Category("Password Complexcity")> _
    Property Previous_password_Checkcount As Integer
        Get
            Return passPrevoiusCheck
        End Get
        Set(value As Integer)
            passPrevoiusCheck = value
        End Set
    End Property

    Dim tempAdminRights = ""
    <Browsable(True), _
Category("Adminstrator Rights")> _
    Public Property AdminstratorRightsLevel As String
        Get
            Return tempAdminRights
        End Get
        Set(ByVal value As String)
            tempAdminRights = value
        End Set
    End Property

    Private Sub LoginBtn_Click(sender As System.Object, e As System.EventArgs) Handles LoginBtn.Click
        login()
    End Sub

    Sub login()
        Dim uid As String = UidTxt.Text
        Dim pass As String = PassTxt.Text

        Dim sql As New SqlClass()
        sql.con1()
        SqlClass.cnn1.Open()
        Debug.WriteLine("connected ! ......")
        SqlClass.cnn1.Close()

    End Sub
End Class
