Imports System.Data.OleDb

Public Class frmguestentry
    Dim connection As New OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\tele\tele\telecom.accdb")
    Dim ds As New DataSet
    Dim da As OleDbDataAdapter

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If finalValidate() = 0 Then
            MsgBox("Please enter all values Correctly", MsgBoxStyle.Exclamation, "Invalid Entry")
            Exit Sub
        End If
        Try
            connection.Open()
            Dim gno As Integer = getGno()
            Dim cmd = New OleDbCommand("INSERT INTO guest VALUES(" & gno & ",'" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & ComboBox1.SelectedItem & "','" & CheckBox1.CheckState & "');", connection)
            cmd.ExecuteReader()
            MsgBox("Record Inserted")
            TextBox1.Clear()
            TextBox2.Clear()
            TextBox3.Clear()
            ComboBox1.SelectedIndex = -1
            CheckBox1.Checked = False
            connection.Close()
        Catch ex As Exception

        End Try
        
    End Sub

    Private Sub frmguestentry_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = frmstaff
    End Sub

    Private Function getGno() As Integer
        Dim gno As Integer
        Dim da2 = New OleDbDataAdapter("select max(gno) from guest", connection)
        da2.Fill(ds)
        Dim n As Integer
        n = ds.Tables(0).Rows.Count - 1
        gno = ds.Tables(0).Rows(n).Item(0) + 1
        Return gno
    End Function
    Private Sub validationCheck(ByRef key As Char, ByVal mode As Integer)
        If mode = 1 Then
            If Not (key >= "A" And key <= "Z") And Not (key >= "a" And key <= "z") And Not key = Chr(8) Then
                key = ""
            End If
        End If
        If mode = 2 Then
            If Not (key >= "A" And key <= "Z") And Not (key >= "a" And key <= "z") And Not key = Chr(8) And Not key = " " Then
                key = ""
            End If
        End If
        If mode = 3 Then
            If Not (key >= "A" And key <= "Z") And Not (key >= "a" And key <= "z") And Not key = Chr(8) And Not key = " " And Not key = "," And Not key = Chr(13) And Not (key >= "0" And key <= "9") Then
                key = ""
            End If
        End If
        If mode = 4 Then
            If Not key = Chr(8) And Not (key >= "0" And key <= "9") Then
                key = ""
            End If
        End If
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        validationCheck(e.KeyChar, 2)
    End Sub

    Private Sub TextBox3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox3.KeyPress
        validationCheck(e.KeyChar, 4)
    End Sub

    Private Function finalValidate() As Integer
        If TextBox1.Text.Trim = "" Or _
        TextBox2.Text.Trim = "" Or _
        TextBox3.Text.Trim = "" Or _
        ComboBox1.SelectedIndex = -1 Or _
        (TextBox3.Text.Length <> 8 And TextBox3.Text.Length <> 10) Or _
        (Not TextBox2.Text.Trim.Contains("@") OrElse TextBox2.Text.Trim.Contains(".")) Then
            Return 0
        Else
            Return 1
        End If
    End Function
End Class