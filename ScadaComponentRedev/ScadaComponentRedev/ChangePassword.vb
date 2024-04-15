﻿Imports System.Data.SqlClient

Public Class ChangePassword
    Dim eventList As New EventList
    Dim x = 0, y = 0

    Sub New(tempx, tempy)
        x = tempx
        y = tempy

        InitializeComponent()
    End Sub

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Dim sql As New SqlClass
        Try

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

    Private Function IsAlphaNum(ByVal strInputText As String) As Boolean
        ' Return System.Text.RegularExpressions.Regex.IsMatch(strInputText, "(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{" & Login_Register.passlen & ",50})$")
        Return System.Text.RegularExpressions.Regex.IsMatch(strInputText, "^.*(?=.*[a-zA-Z])(?=.*\d)(?=.*[\.@_-`~!@#$%^&*()_+={}\[\]\\|:;""'<>,.?/-]){" & Login_Register.passlen & ",50}.*$")
    End Function

    Private Sub ChangePassword_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.StartPosition = FormStartPosition.CenterParent
        Label18.Text = "*Password- Alphanumeric and Special and Minimum " & Login_Register.passLen & " characters"
    End Sub

    Private Sub TextBoxconfirmnewpass_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBoxconfirmnewpass.TextChanged
        If TextBoxnewpass.Text = TextBoxconfirmnewpass.Text Then
            Label19.Text = ""
        Else
            Label19.Text = "Password and Confirm Password do not match"
        End If
    End Sub
End Class