Imports System.Data.OleDb

Public Class frmshowcomplaint
    Dim connection As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\tele\tele\telecom.accdb")
    Dim da As New OleDbDataAdapter("select * from complaint", connection)
    Dim ds As New DataSet



    Private Sub frmshowcomplaint_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = frmadmin
        da.Fill(ds)
        DataGridView1.DataSource = ds
        DataGridView1.DataMember = ds.Tables(0).TableName
        DataGridView1.Columns(0).HeaderText = "No."
        DataGridView1.Columns(1).HeaderText = "Complaint Type"
        DataGridView1.Columns(2).HeaderText = "Customer Name"
        DataGridView1.Columns(3).HeaderText = "Contact No."
        DataGridView1.Columns(4).HeaderText = "Date"
        DataGridView1.Columns(5).HeaderText = "Complaint Description."
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim sql As String
        Try
            sql = "select * from complaint where ctype = 'Technical' "
            da = New OleDbDataAdapter(sql, connection)
            ds.Clear()
            da.Fill(ds)
            DataGridView1.DataSource = ds
            DataGridView1.DataMember = ds.Tables(0).TableName
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim sql As String
        Try
            sql = "select * from complaint where ctype = 'Billing' "
            da = New OleDbDataAdapter(sql, connection)
            ds.Clear()
            da.Fill(ds)
            DataGridView1.DataSource = ds
            DataGridView1.DataMember = ds.Tables(0).TableName
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim sql As String
        Try
            sql = "select * from complaint"
            da = New OleDbDataAdapter(sql, connection)
            ds.Clear()
            da.Fill(ds)
            DataGridView1.DataSource = ds
            DataGridView1.DataMember = ds.Tables(0).TableName
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class