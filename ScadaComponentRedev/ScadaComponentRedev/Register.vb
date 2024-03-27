Imports System.Data.SqlClient

'this Resiter Class is used to insert new user
Public Class Register
    Dim ev As New EventList
    Public Event regon()
    Dim sql As New SqlClass

    ' sub Event handler
    'insert New User into employeeinfo
    Private Sub btnRRegister_Click(sender As System.Object, e As System.EventArgs) Handles btnRRegister.Click
        'Validate user detail userId, confirmUserId,password, confirmpassword by predefined rules
        'if any fileds are empty then print message on Resister form
        If txtname.Text <> "" And txtid.Text.Length >= Login_Register.useridlen And txtpass.Text.Length >= Login_Register.passLen And (txtid.Text = txtcid.Text) And (IsAlphaNum(txtpass.Text) = True) Then
            Dim selectid As String = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 Select CONVERT(varchar, DecryptByKey(userid)) from employeeinfo where CONVERT(varchar, DecryptByKey(userid)) ='" & Trim(txtid.Text) & "'"
            Try
                sql.scon1()
                Dim sqlcmd1 As SqlCommand = New SqlCommand(selectid, sql.scn1)
                Dim reader2 As SqlDataReader = sqlcmd1.ExecuteReader
                If reader2.Read Then
                    MsgBox("UserID already registered, Kindly enter a different 'UserID'!", MsgBoxStyle.Exclamation)
                Else
                    Label7.Text = ""

                    Dim name As String = txtname.Text
                    Dim userid As String = txtid.Text
                    Dim pass As String = txtpass.Text
                    Dim encryptpass As String = pass

                    'insert new user Record into employeeinfo table
                    Try
                        VariableClass.datee = DateTime.Now.ToString("dd-MM-yy")
                        Dim query As String = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 insert into employeeinfo output INSERTED.empid values( EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & name & "') ), EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & userid & "') ), EncryptByKey( Key_GUID('SymmetricKey1'),CONVERT(varchar,'" & encryptpass & "')), '" & ComboBox1.SelectedValue & "','0', EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & VariableClass.datee & "') ))"

                        sql.scon2()
                        Dim sqlcmd As SqlCommand = New SqlCommand(query, sql.scn2)
                        Dim tempempid = DirectCast(sqlcmd.ExecuteScalar(), Integer)

                        changepasswordcondition(tempempid, encryptpass)
                        sqlcmd.Dispose()
                        sql.scn2.Close()
                        MessageBox.Show("Successfully registered!!!", "Register")
                        Dim ev As New EventList

                        ev.insertscadaevent(Login_Register.empid, "NEW REGISTRACTION", "", "NAME: " & name, "Level: " & ComboBox1.Text, "", "", "", "", "", "", "", "Audittrail")
                        txtname.Text = ""
                        txtid.Text = ""
                        txtcid.Text = ""
                        txtpass.Text = ""
                        txtcpass.Text = ""

                        RaiseEvent regon()
                    Catch ex As Exception
                        sql.scn2.Close()
                        MsgBox("Error - " & ex.Message)
                    End Try
                End If
                reader2.Close()
                sqlcmd1.Dispose()
            Catch ex As Exception
            Finally
                sql.scn1.Close()
            End Try
        Else
            If Not (txtname.Text <> "" And txtid.Text <> "" And txtpass.Text <> "" And txtcid.Text <> "" And txtcpass.Text <> "") Then
                Label12.Text = "All Fields are Mandatory"
            ElseIf Label5.Text <> "" Or Label6.Text <> "" Then
                Label12.Text = "Confirm(s) fields dont match"
            Else
                Label12.Text = "Something is not right"
            End If
        End If
    End Sub

    'TextChanged Event handler for txtcPass 
    'if password and confirm password not match then print message on form
    Private Sub txtcpass_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtcpass.TextChanged
        If txtpass.Text = txtcpass.Text Then
            Label11.Text = ""
        Else
            Label11.ForeColor = Color.Red
            Label11.Text = "Password and Confirm Password do not match"
        End If
    End Sub

    Private Sub txtcid_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtcid.TextChanged
        If txtid.Text = txtcid.Text Then
            Label10.Text = ""
        Else
            Label10.ForeColor = Color.Red
            Label10.Text = "UserId and Confirm UserId do not match"
        End If
    End Sub

    'if length of Userid set then check typed user id according to Userid length
    Private Sub txtid_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtid.TextChanged
        If txtid.Text.Length < Login_Register.useridlen Then
            Label3.ForeColor = Color.Red

        Else
            Label3.ForeColor = Color.Silver
        End If
    End Sub

    Private Sub txtpass_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtpass.TextChanged
        If txtpass.Text.Length < Login_Register.passLen Or IsAlphaNum(txtpass.Text) = False Then
            Label9.ForeColor = Color.Red

        Else
            If IsAlphaNum(txtpass.Text) = True Then
                Label9.ForeColor = Color.Silver
            End If
        End If



    End Sub

    'this function is used to validate String that is passed as Parameter and return boolean according to validating String
    Public Function IsAlphaNum(strInputText As String) As Boolean
        Dim loginreg As New Login_Register
        'validate number of Capital Charector in strinputText
        Dim t1 = System.Text.RegularExpressions.Regex.IsMatch(strInputText, "^(.*?[A-Z]){" & loginreg.passUpperCase & ",}.*$")

        'validate numeric charactor in strinputText 
        Dim t2 = System.Text.RegularExpressions.Regex.IsMatch(strInputText, "^(.*?[0-9]){" & loginreg.passNumericChar & ",}.*$")
        'validate number of lower charector in strinputText
        Dim t3 = System.Text.RegularExpressions.Regex.IsMatch(strInputText, "^(.*?[a-z]){" & loginreg.passLowerCase & ",}.*$")
        'valide number of speciel charector in strinputText
        Dim t4 = System.Text.RegularExpressions.Regex.IsMatch(strInputText, "^(.*?[\.@_-`~!@#$%^&*()_+={}\[\]\\|:;""'<>,.?/-]){" & loginreg.passspecialchar & ",}.*$")
        If t1 = True And t2 = True And t3 = True And t4 = True And strInputText.Length >= Login_Register.passLen Then
            Return True
        Else
            Return False
        End If
    End Function

    ' this Event Handler Call When Resister Forn is load
    Private Sub Register_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.StartPosition = FormStartPosition.CenterParent

        Label3.Text = "*User ID should have minimum " & Login_Register.useridlen & " characters"
        Label9.Text = "*Password- Alphanumeric and Special and minimum " & Login_Register.passLen & " characters"
        Dim query2 As String

        'Retrieve all levelname from levelDetails table exclude levelid is greater than 2 or greater than 2 and levelid is equal to mngr
        If Login_Register.plevel = Login_Register.mngr Then
            query2 = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 Select levelid,CONVERT(varchar, DecryptByKey(levelname)) as levelname from leveldetails where levelid >2 and levelid<>" & Login_Register.mngr
        Else
            query2 = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 Select levelid,CONVERT(varchar, DecryptByKey(levelname)) as levelname from leveldetails where levelid >2"
        End If
        sql.scon3()
        Dim sqlcmd1 As SqlCommand = New SqlCommand(query2, sql.scn3)
    
        sqlcmd1.ExecuteNonQuery()
        Dim DA = New SqlDataAdapter
        DA.SelectCommand = sqlcmd1
        Dim DataSet = New DataSet
        DA.Fill(DataSet)
        'insert all levename and levelid in ComboBox1 that has retrieve from Query2
        ComboBox1.DataSource = DataSet.Tables(0)
        ComboBox1.ValueMember = "levelid"
        ComboBox1.DisplayMember = "levelname"
        sql.scn3.Close()
    End Sub

    Private Sub btnRLogin_Click(sender As System.Object, e As System.EventArgs) Handles btnRLogin.Click
        Me.Close()
    End Sub

    Function changepasswordcondition(empid As String, temp_pass As String) As Object
        If Login_Register.passPrevoiusCheck = 0 Then
            Exit Function
        End If
        Dim query = "select count(*) from passwordlist where empid='" & empid & "' "
        sql.scon2()
        Dim sqlcmd As SqlCommand = New SqlCommand(query, sql.scn2)
        Dim reader As SqlDataReader = sqlcmd.ExecuteReader
        Dim temp_pass_count = 0
        If reader.Read Then
            temp_pass_count = reader.Item(0)
        End If
        reader.Close()
        If temp_pass_count < Login_Register.passPrevoiusCheck Then
            Dim temppre = previous_password_check(temp_pass, empid)
            If temppre = True Then
                Return True
            End If
        Else
            Dim temppre = previous_password_check(temp_pass, empid)
            If temppre = True Then
                Dim q2 = "delete from passwordlist where empid='" & empid & "' and sno=(select top 1 sno from passwordlist where empid='" & empid & "' order by  CONVERT(varchar, DecryptByKey(date)),sno asc)"
                sql.scon3()
                Dim sqlcmd1 As SqlCommand = New SqlCommand(q2, sql.scn3)
                sqlcmd1.ExecuteNonQuery()
                sql.scn3.Close()
                Return True
                '     MessageBox.Show("Password Successfully changed!!!", "ChangePassword")
            End If
        End If
        sql.scn2.Close()
    End Function

    Public Function previous_password_check(ByVal temp_pass As String, ByVal empid As Integer) As Boolean
        sql.scon4()
        Dim q1 = "select empid from passwordlist where password='" & temp_pass & "' and empid='" & empid & "'"
        Dim sqlcmd As SqlCommand = New SqlCommand(q1, sql.scn4)
        Dim reader As SqlDataReader = sqlcmd.ExecuteReader
        If reader.Read Then
            MsgBox("Please enter different password can't use previously " & Login_Register.passprevoiuscheck & " used password")
            Return False
        Else
            q1 = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 insert into passwordlist(empid,password,date) values('" & empid & "','" & temp_pass & "', EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & variableclass.datee & "') ))"
            sql.scon3()
            Dim sqlcmd1 As SqlCommand = New SqlCommand(q1, sql.scn3)
            sqlcmd1.ExecuteNonQuery()
            q1 = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 update employeeinfo set password='" & temp_pass & "' where empid='" & empid & "'"
            sql.scon3()
            sqlcmd1 = New SqlCommand(q1, sql.scn3)
            sqlcmd1.ExecuteNonQuery()
            sql.scn3.Close()
            Return True
        End If
        sql.scn4.Close()
    End Function

   

End Class