Imports System.Data.OleDb

Public Class frmregistercomplaint
    Dim connection As New OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\tele\tele\telecom.accdb")
    Dim con As New OleDbConnection
    Dim ds As New DataSet
    Dim da As OleDbDataAdapter
    Dim bs As BindingSource
    Dim sql As String
    Dim sql1 As String


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        connection.Open()
        Dim cno As Integer = getCno()
        Dim command = New OleDb.OleDbCommand("INSERT INTO complaint VALUES (" & cno & ",'" & ComboBox1.Text & "','" & TextBox1.Text & "','" & TextBox2.Text & "','" & DateTimePicker1.Value.ToString("dd-MMM-yy") & "','" & TextBox3.Text & "');", connection)
        command.ExecuteReader()
        MsgBox("Record Inserted")
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        ComboBox1.SelectedIndex = -1
        DateTimePicker1.Value = Today
        connection.Close()
    End Sub

    Private Sub frmregistercomplaint_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = frmstaff
        Label19.Text = Date.Today.Date.ToString("dd-MMM-yyyy")


    End Sub
    Private Function getCno() As Integer

        da = New OleDbDataAdapter("select max(cno) from complaint", connection)
        da.Fill(ds)
        Dim n As Integer
        n = ds.Tables(0).Rows.Count - 1
        Return (ds.Tables(0).Rows(n).Item(0) + 1)
    End Function

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        validationCheck(e.KeyChar, 2)
    End Sub
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




    Private Sub TextBox3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox3.KeyPress
        validationCheck(e.KeyChar, 3)
    End Sub

    Private Sub TextBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
        validationCheck(e.KeyChar, 4)
    End Sub

    Private Function finalValidate() As Integer
        If TextBox1.Text.Trim = "" Or _
        TextBox2.Text.Trim = "" Or _
        TextBox3.Text.Trim = "" Or _
        (TextBox2.Text.Length <> 8 And TextBox2.Text.Length <> 10) Or _
        ComboBox1.SelectedIndex = -1 Then
            MsgBox("Please enter all values correctly", MsgBoxStyle.Exclamation, "Invalid Entry")
            Return 0
        Else
            Return 1
        End If
    End Function
End Class