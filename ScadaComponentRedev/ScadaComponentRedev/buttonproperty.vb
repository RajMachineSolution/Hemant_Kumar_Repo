﻿Imports System.Data.SqlClient

Public Class buttonproperty
    Dim sql As New SqlClass
    Dim ev As New EventList
    Dim parentt As String
    Dim mename As String
    Dim x = 0, y = 0
    Sub New(ByVal p As String, ByVal m As String, ByVal x1 As Integer, ByVal y1 As Integer)

        ' This call is required by the designer.
        InitializeComponent()
        filllevels()
        parentt = p
        Debug.WriteLine(p)
        mename = m
        Debug.WriteLine(m)
        x = x1
        y = y1

    End Sub

    'This sub is user to render level names , that is fetch from leveldetails table
    Sub filllevels()
        ListBox1.Items.Clear()
        ListBox2.Items.Clear()
        Dim query As String = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select CONVERT(varchar, DecryptByKey(levelname)) as levelname from leveldetails where levelid<>1 "
        sql.scon2()
        Dim sqlcmd As SqlCommand = New SqlCommand(query, sql.scn2)
        Using reader As SqlDataReader = sqlcmd.ExecuteReader

            While reader.Read
                ListBox1.Items.Add(reader.Item(0))
            End While
        End Using
        'copy Listbox2 item to LIstBox1
        ListBox2.Items.AddRange(ListBox1.Items)
        sqlcmd.Dispose()
        sql.scn2.Close()
    End Sub


    Private Sub buttonproperty_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub
    Public Sub showselected(ByVal btn As Control, ByVal frm As Form)
        Try
            If Login_Register.levelId Is Nothing Then
                Login_Register.levelId = 0
            End If
            Dim query As String = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select CONVERT(varchar, DecryptByKey(controlproperty)),controlstatus,(select CONVERT(varchar, DecryptByKey(levelname)) from leveldetails where levelid=c.levelid) as levelname from controlrights as c  where  CONVERT(varchar, DecryptByKey(formname))='" & frm.Name & "' and CONVERT(varchar, DecryptByKey(controlname))='" & btn.Name & "' order by levelid"

            sql.con3()
            Dim sqlcmd As SqlCommand = New SqlCommand(query, SqlClass.sqlcon)
            Using reader As SqlDataReader = sqlcmd.ExecuteReader
                While reader.Read

                    If reader.Item(1) = 1 Then
                        Dim index As Integer
                        index = ListBox1.FindString(reader.Item(2))
                        If reader.Item(0) = True Then
                            If index > -1 Then
                                Me.ListBox1.SetSelected((index), True)
                            End If
                        Else
                            Me.ListBox1.SetSelected((index), False)

                        End If
                    Else
                        Dim index As Integer
                        index = ListBox2.FindString(reader.Item(2))
                        If reader.Item(0) = True Then
                            If index > -1 Then
                                Me.ListBox2.SetSelected((index), True)
                            End If
                        Else
                            Me.ListBox2.SetSelected((index), False)

                        End If
                    End If
                End While
            End Using
            sqlcmd.Dispose()
            SqlClass.sqlcon.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        deleteEntries() 'Deleting old properties of control
        InsertEntries()
    End Sub

    Private Sub deleteEntries()
        Dim query As String = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 delete from controlrights where CONVERT(varchar, DecryptByKey(formname))='" & parentt & "' and CONVERT(varchar, DecryptByKey(controlname))='" & mename & "'"
        sql.con2()
        Dim sqlcmd As SqlCommand = New SqlCommand(query, SqlClass.sqlcon)
        sqlcmd.ExecuteNonQuery()
        sqlcmd.Dispose()
        SqlClass.sqlcon.Close()
    End Sub

    Private Sub InsertEntries()
        Dim query As String
        For i = 0 To ListBox1.Items.Count - 1

            If ListBox1.SelectedItems.Contains(ListBox1.Items(i)) Then

                query = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 insert into controlrights values ((select levelid from leveldetails where CONVERT(varchar, DecryptByKey(levelname))='" & ListBox1.Items(i) & "'),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & parentt & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & mename & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'True')),1)"
                sqlqueryexecute(query)
            Else
                query = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 insert into controlrights values ((select levelid from leveldetails where CONVERT(varchar, DecryptByKey(levelname))='" & ListBox1.Items(i) & "'),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & parentt & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & mename & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'False')),1)"
                sqlqueryexecute(query)
            End If


        Next
        For i = 0 To ListBox2.Items.Count - 1

            If ListBox2.SelectedItems.Contains(ListBox2.Items(i)) Then

                query = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 insert into controlrights values ((select levelid from leveldetails where CONVERT(varchar, DecryptByKey(levelname))='" & ListBox2.Items(i) & "'),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & parentt & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & mename & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'True')),2)"
                sqlqueryexecute(query)
            Else
                query = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 insert into controlrights values ( (select levelid from leveldetails where CONVERT(varchar, DecryptByKey(levelname))='" & ListBox2.Items(i) & "'),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & parentt & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & mename & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'False')),2)"
                sqlqueryexecute(query)
            End If


        Next
    End Sub
    Private Sub sqlqueryexecute(ByVal query As String)
        ' Dim query As String = "Delete from controlrights where formname='" & Me.ParentForm.Name & "' and controlname='" & Me.Name & "'"
        sql.con2()
        Dim sqlcmd As SqlCommand = New SqlCommand(query, sqlclass.sqlcon)
        sqlcmd.ExecuteNonQuery()
        sqlcmd.Dispose()

        sqlclass.sqlcon.Close()


    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        deleteEntries()
        MsgBox("Property cleared")
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            For i = 0 To ListBox1.Items.Count - 1
                Me.ListBox1.SetSelected(i, True)
            Next
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As System.EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked Then
            For i = 0 To ListBox2.Items.Count - 1
                Me.ListBox2.SetSelected(i, True)
            Next
        End If
    End Sub
    Dim temselected = 0 'if all item of listbox  is selected then it is 0 else 1
    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        For i = 0 To ListBox1.Items.Count - 1
            If ListBox1.SelectedItems.Contains(ListBox1.Items(i)) Then
                temselected = 0
            Else
                temselected = 1
                Exit For
            End If
        Next
        'if all item is sekected check the checkbox else uncheck
        If temselected = 0 Then
            If CheckBox1.Checked Then
            Else
                CheckBox1.Checked = True
            End If
        Else
            If CheckBox1.Checked Then
                CheckBox1.Checked = False
            Else
            End If
        End If
    End Sub

    Private Sub ListBox2_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ListBox2.SelectedIndexChanged
        For i = 0 To ListBox2.Items.Count - 1
            If ListBox2.SelectedItems.Contains(ListBox2.Items(i)) Then
                temselected = 0
            Else
                temselected = 1
                Exit For
            End If
        Next
        If temselected = 0 Then
            If CheckBox2.Checked Then
            Else
                CheckBox2.Checked = True
            End If
        Else
            If CheckBox2.Checked Then
                CheckBox2.Checked = False
            Else

            End If
        End If
    End Sub
End Class