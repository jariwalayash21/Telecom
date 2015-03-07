Imports System.Data.OleDb
Public Class frmshowsys_logs
    Dim connection As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\tele\tele\telecom.accdb")
    Dim da As New OleDbDataAdapter("select * from  sys_log", connection)
    Dim ds As New DataSet
    Private Sub frmshowsys_logs_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = frmadmin
        da.Fill(ds)
        DataGridView1.DataSource = ds
        DataGridView1.DataMember = ds.Tables(0).TableName
        DataGridView1.Columns(0).HeaderText = "User Name"
        DataGridView1.Columns(1).HeaderText = "Login Date"
        DataGridView1.Columns(2).HeaderText = "Login Time"
        
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim str As String
        str = InputBox("Enter User Name to be Searched", "User Name")
        Dim sql As String
        Try
            sql = "select * from sys_log where uname='" & str & "'"
            da = New OleDbDataAdapter(sql, connection)
            ds.Clear()
            da.Fill(ds)
            DataGridView1.DataSource = ds
            DataGridView1.DataMember = ds.Tables(0).TableName
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MonthCalendar1.Visible = True
        Dim str As String
        str = MonthCalendar1.SelectionRange.Start
        Dim sql As String
        Try
            sql = "select * from sys_log where uname='" & str & "'"
            da = New OleDbDataAdapter(sql, connection)
            ds.Clear()
            da.Fill(ds)
            DataGridView1.DataSource = ds
            DataGridView1.DataMember = ds.Tables(0).TableName
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If MonthCalendar1.Visible = True Then
            MonthCalendar1.Visible = False
        Else
            MonthCalendar1.Visible = True
        End If
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim sql As String
        Try
            sql = "select * from sys_log"
            da = New OleDbDataAdapter(sql, connection)
            ds.Clear()
            da.Fill(ds)
            DataGridView1.DataSource = ds
            DataGridView1.DataMember = ds.Tables(0).TableName
        Catch ex As Exception

        End Try
    End Sub

    

    Private Sub MonthCalendar1_DateChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DateRangeEventArgs) Handles MonthCalendar1.DateChanged
        Dim strt, sql As String
        strt = MonthCalendar1.SelectionRange.Start.ToString("dd-MMM-yyyy")
        sql = "select * from sys_log where login_date='" & strt & "'"
        da = New OleDbDataAdapter(sql, connection)
        ds.Clear()
        da.Fill(ds)
        DataGridView1.DataSource = ds
        DataGridView1.DataMember = ds.Tables(0).TableName
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class