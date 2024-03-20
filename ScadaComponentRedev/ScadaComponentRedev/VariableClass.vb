Imports System.ComponentModel

Public Class VariableClass
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


End Class
