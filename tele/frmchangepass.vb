Imports System.Data.OleDb
Public Class frmchangepass

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub frmchangepass_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = frmstaff
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox3.Text <> TextBox2.Text Then
            MsgBox("Please enter same passwords in the last two feilds", 0, "Error")
            Exit Sub
        End If
        If TextBox2.Text.Length < 6 Then
            MsgBox("Password Length should be more than or equal to 6 characters minimum", MsgBoxStyle.Information, "Invalid Password")
            Exit Sub
        End If
        Dim conn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\tele\tele\telecom.accdb")
        Dim da As New OleDbDataAdapter
        Dim ds As New DataSet
        Dim cmd As New OleDbCommand("Select pass from login where id='" & frmstaff.curr_user & "'", conn)
        da.SelectCommand = cmd
        da.Fill(ds)
        If ds.Tables(0).Rows(0).Item(0) <> TextBox1.Text Then
            MsgBox("Incorrect Current Password", MsgBoxStyle.Exclamation, "Try Again")
            Exit Sub
        End If
        cmd.CommandText = "Update login set pass='" & TextBox2.Text & "' where id='" & frmstaff.curr_user & "'"
        conn.Open()
        cmd.ExecuteNonQuery()
        conn.Close()
        MsgBox("Password Sucessfully Changed", 0, "Sucess")
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        Me.Close()
    End Sub
End Class