﻿Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Globalization

'This is User Control type component 
'Used to Authentication, by Authentication process, getting Level Name and UserName
'Scada Uses this Level Name to give verios component to Access and restricted
Public Class Login_Register
    Implements IMessageFilter
    Public Shared SecondsCount As Integer = 0
    Public Shared server = ".\SQLEXPRESS", dbname = "ScadaNewDB", dbid = "rmsview", dbpass = "rmsview"
    Public Shared empid, Fname, plevel As String

    'Try to Login by given UserId
    Public Shared tryLoginUserId As String = "first"

    'for Count unsuccess login
    Public Shared tryLoginCount As Integer
    Public Shared lotNo = "", batchNo = ""
    Public Shared levelId, levelName As String

    'Declare Logon Event with three Perameter
    Public Event Logon(ByVal empid As String, ByVal fname As String, ByVal plevel As String)

    'declare Event regon() with no perameter
    Public Event regon()
    Dim loginDetailsFlag As Boolean = False

    Public Shared PasswordExp As Boolean
    Dim PasswordExp1 As Boolean
    Dim evntlist As New EventList
    Public Shared PasswordExpday As Integer = 0

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
    <Browsable(False)>
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

    'for Enable Password Expire ficility
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

    'gives new LevelName as Array of String
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

    'this property is used to insert every ectivity or Action done by user into 'EventList' table
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

    'Number of Uppercase Charactor in Password 
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

    'Number of Lowercase Charactor in Password 
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

    ''Number of Special Charactor in Password 
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

    ''Number of Numeric Charactor in Password 
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
    <Browsable(False), _
Category("Password Complexcity")> _
    Property Previous_password_Checkcount As Integer
        Get
            Return passPrevoiusCheck
        End Get
        Set(value As Integer)
            passPrevoiusCheck = value
        End Set
    End Property

    'give Admistrator rigth to other Lower Level
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

    'This is click Event handler, On Button click Call Login sub
    Private Sub btnLlogin_Click(sender As System.Object, e As System.EventArgs) Handles btnLlogin.Click
        login()
    End Sub

    ' on click btnReg ('Add User') pop up Register form
    Private Sub btnLReg_Click(sender As System.Object, e As System.EventArgs) Handles btnLReg.Click
        If empid = -1 Then
            MsgBox("Please login again to continue")
            Exit Sub
        End If
        Dim reg As New Register
        reg.TopMost = True
        reg.StartPosition = FormStartPosition.CenterParent
        reg.ShowDialog()
    End Sub

    ' function takes String as perameter and return boolean
    ' this function check given String contains atleast one number and cherector in specified length
    Private Function IsAlphaNum(ByVal strInputText As String) As Boolean
        Return System.Text.RegularExpressions.Regex.IsMatch(strInputText, "(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{8,50})$")
    End Function

    Public Shared mngr As Integer

    'An Event Handler, Call on Login_Control on Load
    Private Sub RegistrationControl_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        checkvalueforlogincheckbox()
        txtLid.Text = ""
        txtLpass.Text = ""

        'Initially bitnLeg(Add User) button, Button3(Edit User) button and Label11(New User ?) is visisblility false 
        btnLReg.Visible = False
        Button3.Visible = False
        Label11.Visible = False
        Dim sql As New SqlClass
        SqlClass.database = dbname


        ' if  AdminstratorRightsLevel property is not empty then give right to given User as a Adminstrator, assign level id to mngr
        If SqlClass.database <> "" And SqlClass.server <> "" Then
            Dim query1 As String = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 Select levelid from leveldetails where CONVERT(varchar, DecryptByKey(levelname))='" & tempAdminRights & "'"
            sql.scon1()
            Dim sqlcmd1 As SqlCommand = New SqlCommand(query1, sql.scn1)

            Dim reader As SqlDataReader = sqlcmd1.ExecuteReader

            If reader.Read Then
                mngr = reader.Item(0)
            End If
            reader.Close()
            sqlcmd1.Dispose()
            sql.scn1.Close()
        End If
    End Sub

    'sub with paramenter empid is Iteger
    'if more then 4 attemp for login is fail then this sub is called, Deactivate the user that is passed their id
    ' set deactivated in table 'employeeinfo'
    'Insert user that is deactivate, detail in 'Eventlist' table with empid 
    Private Sub deactivate(ByVal id As Integer)
        Dim sql As New SqlClass

        Try

            Dim query As String = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 update  employeeinfo set active=2 where empid='" & id & "'"
            sql.scon1()
            Using sqlcmd As SqlCommand = New SqlCommand(query, sql.scn1)

                sqlcmd.ExecuteNonQuery()
            End Using
            sql.scn1.Close()
            evntlist.insertscadaevent(empid, "USER DEACTIVATED", "", "", "", "", "", "", "", "", "", "", "Audittrail")

        Catch ex As Exception

        End Try
    End Sub

    Public Function PreFilterMessage(ByRef m As System.Windows.Forms.Message) As Boolean Implements System.Windows.Forms.IMessageFilter.PreFilterMessage

        'Check for mouse movements and / or clicks
        Dim mouse As Boolean = (m.Msg >= &H200 And m.Msg <= &H20D) Or (m.Msg >= &HA0 And m.Msg <= &HAD)

        'Check for keyboard button presses
        Dim kbd As Boolean = (m.Msg >= &H100 And m.Msg <= &H109)

        If mouse Or kbd Then 'if any of these events occur
            '  If Not Timer1.Enabled Then MessageBox.Show("Waking up") 'wake up

            Timer1.Stop()
            SecondsCount = 0
            Timer1.Start()

        End If
    End Function

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        SecondsCount += 1 'Increment

        If SecondsCount > 30 Then 'Two minutes have passed since being active
            Timer1.Stop()
            MessageBox.Show("Program has been inactive for 2 minutes…. Exiting Now…. Cheers!")
            Application.Exit()
        End If
    End Sub

    Public Sub userlevelinsert(ByVal ulevel As String()) ' multiple functionality is done by this method
        Dim sql As New sqlclass
        Dim templevelname As String() = {}
        Try
            If sqlclass.server <> "" And sqlclass.dbname <> "" Then
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

                If Userlevel.Length = i Then


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

                If Userlevel.Length = 0 Then 
                    user_level = templevelname
                
                End If
            End If
        Catch ex As Exception
        End Try

    End Sub

    'Event Handler sub for Button3('Edit User')

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        If empid = -1 Then
            MsgBox("Please login again to continue!")
            Exit Sub
        End If
        'if User login first time then open ChangePassword form
        'if levelId(plevel) or Adminstrator assign its previlege to mngr then open RegisterDetails form,
        If plevel = 1 Or plevel = mngr Then
            Dim tempregdetails As New RegisterDetails
            tempregdetails.TopMost = True
            tempregdetails.StartPosition = FormStartPosition.CenterParent

            tempregdetails.tempregister = tempregdetails
            tempregdetails.filldata()
            tempregdetails.ShowDialog()
        Else
            Dim chang As New ChangePassword(Me.Location.X, Me.Location.Y)
            chang.TopMost = True
            chang.TextBoxconfirmnewpass.Text = ""
            chang.TextBoxnewpass.Text = ""
            chang.Label19.Text = ""
            chang.Label18.ForeColor = Color.Silver
            chang.StartPosition = FormStartPosition.CenterParent
            chang.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            chang.ShowDialog()

        End If

    End Sub

    'login() for Authentication process
    Sub login()
        Try
            Dim uid As String = txtLid.Text 'User ID
            Dim pass As String = txtLpass.Text 'Password
            Dim query As String = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 Select empid,CONVERT(varchar, DecryptByKey(fname)),plevel,active,CONVERT(varchar, DecryptByKey(passworddate)),(select CONVERT(varchar, DecryptByKey(levelname)) from leveldetails where levelid=e.plevel) as levelname from employeeinfo as e where DecryptByKey(UserID)='" & uid & "' and DecryptByKey(password)= '" & pass & "' COLLATE SQL_Latin1_General_CP1_CS_AS and active<2"
            Dim sql As New SqlClass()
            Dim daycount
            sql.con1()
            Dim sqlcon As New SqlConnection
            Dim activeindex = 0
            sqlcon = New SqlConnection With {.ConnectionString = "server=" & server & "; Database= " & dbname & ";user id= " & dbid & ";password=" & dbpass & ";"}

            sqlcon.Open()
            Dim sqlcmd As SqlCommand = New SqlCommand(query, sqlcon)
            Using reader As SqlDataReader = sqlcmd.ExecuteReader

                'if User Try to login First time uid assign to tryLoginUserId
                If tryLoginUserId <> uid Then
                    tryLoginUserId = uid
                    tryLoginCount = 0
                End If
                If reader.Read Then

                    empid = reader(0)
                    Fname = reader(1)
                    plevel = reader(2)
                    activeindex = reader(3)
                    levelName = reader.Item(5)

                    'Registration date
                    Dim dt As Date
                    dt = DateTime.ParseExact(reader(4), "d-M-yy", CultureInfo.InvariantCulture)

                    'current date
                    Dim dt11 As Date
                    VariableClass.datee = DateTime.Now.ToString("d-M-yy")
                    dt11 = DateTime.ParseExact(VariableClass.datee, "d-M-yy", CultureInfo.InvariantCulture)
                    daycount = dt11.Subtract(dt).Days
                    daycount = daycount + 1

                    'If Password Expired or Account is Deactivate pop up 'ChangePassword' form
                    If PasswordExp1 = True Or activeindex = 0 Then
                        If empid <> 1 Then
                            If daycount >= PasswordExpday Or activeindex = 0 Or daycount < 0 Then

                                txtLid.Text = ""
                                txtLpass.Text = ""
                                Dim Chang As New ChangePassword(Me.Location.X, Me.Location.Y)
                                Chang.TopMost = True
                                Chang.TextBoxconfirmnewpass.Text = ""
                                Chang.TextBoxnewpass.Text = ""
                                Chang.Label19.Text = ""
                                Chang.Label18.ForeColor = Color.Silver
                                Chang.StartPosition = FormStartPosition.CenterParent
                                Chang.FormBorderStyle = Windows.Forms.FormBorderStyle.None
                                Chang.ShowDialog()
                                Chang.TopMost = True

                                Exit Sub
                            End If
                        End If
                    End If

                    btnLReg.Visible = False
                    Button3.Visible = False
                    Label11.Visible = False

                    '1 mean Adminstrator that have full previledge
                    If plevel = 1 Or plevel = mngr Then

                        btnLReg.Visible = True
                        Button3.Visible = True
                        Label11.Visible = True

                    Else
                        btnLReg.Visible = False
                        Button3.Visible = True
                        Label11.Visible = False
                    End If
                    levelId = plevel
                    If RecordloginAction = True Then
                        evntlist.insertscadaevent(empid, "LOGINBY USER", "", "", "", "", "", "", "", "", "", "", "Audittrail")
                    End If
                    txtLid.Text = ""
                    txtLpass.Text = ""
                    MessageBox.Show("Login Successful ! " & Fname & "", "Login")
                    If CheckBox1.Checked = True Then
                        Me.Parent.Hide()
                    End If
                    'Raise Event Logon with  parameter Userid, Fist Name Level Name on successfull Login
                    RaiseEvent Logon(empid, Fname, plevel)
                Else

                    ' if user Attempt login fail more then 4 time then User with empId is Deactivate
                    If tryLoginCount >= 4 Then
                        deactivate(empid)
                        MessageBox.Show("Deactivate", uid)
                        tryLoginCount = 0
                        Exit Sub
                    End If

                    tryLoginCount = tryLoginCount + 1
                    'insert Action in "EventList' database table on Unsucessfull Login
                    evntlist.insertscadaevent(-1, "INVALID LOGIN", "USER ID+" + uid, "USER ID+" + uid, "", "", "", "", "", "", "", "", "Audittrail")
                    RaiseEvent Logon(2, "Default Login", 2)
                    btnLReg.Visible = False
                    Button3.Visible = False
                    Label11.Visible = False

                    MessageBox.Show("UserID and Password do not match! TRY Again!", "Login")

                End If
            End Using
            sqlcmd.Dispose()
            sqlcon.Close()

        Catch ex As Exception

            MsgBox("Cant Connect:Login_click" & ex.Message)
        End Try


    End Sub

    'this sub Maintain visibility of 'Login_Control' if checkbox is clicked then After succesful login this 'Login_Control' UI is disappiar other wise not 
    Private Sub checkvalueforlogincheckbox()
        'Maintain text file on Local computer in given Path
        'Create a file name with chk.txt
        'check first to Exist of given file, If not Exist then Create One
        If (Not System.IO.Directory.Exists("c:\Chkdetail\")) Then

            System.IO.Directory.CreateDirectory("c:\Chkdetail\")

        End If
        Dim FILE_NAME As String = "c:\Chkdetail\chk.txt"


        'read the file if there is 1 then checkbox si checked

        If System.IO.File.Exists("c:\Chkdetail\chk.txt") = True Then
            Dim b As New System.IO.StreamReader(FILE_NAME)
            Dim temp = b.ReadToEnd
            If temp = "1" Then
                CheckBox1.Checked = True
            Else
                CheckBox1.Checked = False
            End If
            b.Close()

        Else
            Dim w As New System.IO.StreamWriter(FILE_NAME, True)

            w.Write("1")


            w.Close()
            CheckBox1.Checked = True

        End If



    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox1.Click
        Dim FILE_NAME As String = "c:\Chkdetail\chk.txt"

        If System.IO.File.Exists("c:\Chkdetail\chk.txt") = True Then

            Dim b As New System.IO.StreamReader(FILE_NAME)

            'if Checked box is checked then write 1 in cht.txt file otheriwse 0

            Dim temp = b.ReadToEnd
            b.Close()
            Dim w As New System.IO.StreamWriter(FILE_NAME)
            If temp = "1" Then
                w.Write("0")
                CheckBox1.Checked = False
            Else
                w.Write("1")

                CheckBox1.Checked = True
            End If

            w.Close()

        Else
            MsgBox(FILE_NAME)
            Dim w As New System.IO.StreamWriter(FILE_NAME, True)
            '-- 1 means checkbox selected 0 means not selected
            w.WriteLine("1")
            CheckBox1.Checked = True

            w.Close()

        End If
    End Sub

    Private Sub Panel1_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class
