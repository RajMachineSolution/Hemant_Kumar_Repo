Imports System.Data.SqlClient

Public Class ChangePassword
    Dim eventList As New EventList
    Dim x = 0, y = 0

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Dim sql As New SqlClass
        Try
            If Login_Register.passPrevoiusCheck = 0 Then

                VariableClass.datee = DateTime.Now.ToString("dd-MM-yy")
                ' Dim query As String = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 update  employeeinfo set password ='" & sqlclass.AES_Encrypt(TextBoxnewpass.Text, "r1m2s3") & "',passworddate= EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & variableclass.datee & "') ),active=1 where empid='" & Login_Register.empid & "'"
                Dim query As String = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 update  employeeinfo set password = EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & TextBoxnewpass.Text & "')),passworddate= EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & VariableClass.datee & "') ),active=1 where empid='" & Login_Register.empid & "'"
                sql.scon1()
                Dim sqlcmd As SqlCommand = New SqlCommand(query, sql.scn1)

                sqlcmd.ExecuteNonQuery()
                sqlcmd.Dispose()
                sql.scn1.Close()
                eventList.insertscadaevent(Login_Register.empid, "Password Changed", "", "", "", "", "", "", "", "", "", "", "Audittrail")
                MessageBox.Show("Password Successfully changed!!!", "ChangePassword")
                Me.Hide()
            Else
                Dim reg As New Register
                ' Dim tempreg = reg.changepasswordcondition(Login_Register.empid, sqlclass.AES_Encrypt(TextBoxnewpass.Text, "r1m2s3"))
                Dim tempreg = reg.changepasswordcondition(Login_Register.empid, TextBoxnewpass.Text)
                If tempreg = True Then
                    Dim query As String = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 update  employeeinfo set passworddate= EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & VariableClass.datee & "') ),active=1 where empid='" & Login_Register.empid & "'"
                    sql.scon1()
                    Dim sqlcmd As SqlCommand = New SqlCommand(query, sql.scn1)

                    sqlcmd.ExecuteNonQuery()
                    sqlcmd.Dispose()
                    sql.scn1.Close()
                    eventList.insertscadaevent(Login_Register.empid, "Password Changed", "", "", "", "", "", "", "", "", "", "", "Audittrail")

                    MessageBox.Show("Password Successfully changed!!!", "ChangePassword")

                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub TextBoxnewpass_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBoxnewpass.TextChanged
        If TextBoxnewpass.Text.Length < Login_Register.passLen Then
            Label18.ForeColor = Color.Red

        Else
            Dim reg As New Register
            If reg.IsAlphaNum(TextBoxnewpass.Text) = True Then
                Label18.ForeColor = Color.Silver
            Else
                Label18.ForeColor = Color.Red
            End If
        End If
    End Sub
End Class