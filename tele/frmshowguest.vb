Imports System.Data.OleDb

Public Class frmshowguest
    Dim connection As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\tele\tele\telecom.accdb")
    Dim da As New OleDbDataAdapter("select * from guest", connection)
    Dim ds As New DataSet
    Private Sub frmshowguest_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = frmadmin
        da.Fill(ds)
        DataGridView1.DataSource = ds
        DataGridView1.DataMember = ds.Tables(0).TableName
        DataGridView1.Columns(0).HeaderText = "No."
        DataGridView1.Columns(1).HeaderText = "Guest Name"
        DataGridView1.Columns(2).HeaderText = "Email Id"
        DataGridView1.Columns(3).HeaderText = "Contact No."
        DataGridView1.Columns(4).HeaderText = "Purpose"
        DataGridView1.Columns(5).HeaderText = "Future Offers"
        DataGridView1.Refresh()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        populate()
    End Sub
    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged
        populate()
    End Sub
    Private Sub CheckBox3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox3.CheckedChanged
        populate()
    End Sub
    Private Sub CheckBox4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox4.CheckedChanged
        populate()
    End Sub
    Private Sub populate()
        Dim cmd As New OleDbCommand
        cmd.Connection = connection
        ds.Clear()
        If CheckBox1.Checked Then
            cmd.CommandText = "select * from guest where purpose = 'landline' "
            da.SelectCommand = cmd
            da.Fill(ds)
        End If
        If CheckBox2.Checked Then
            cmd.CommandText = "select * from guest where purpose = 'prepaid' "
            da.SelectCommand = cmd
            da.Fill(ds)
        End If
        If CheckBox3.Checked Then
            cmd.CommandText = "select * from guest where purpose = 'postpaid' "
            da.SelectCommand = cmd
            da.Fill(ds)
        End If
        If CheckBox4.Checked Then
            cmd.CommandText = "select * from guest where purpose = 'broadband' "
            da.SelectCommand = cmd
            da.Fill(ds)
        End If
        DataGridView1.DataSource = ds
        DataGridView1.DataMember = ds.Tables(0).TableName
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        CheckBox1.Checked = True
        CheckBox2.Checked = True
        CheckBox3.Checked = True
        CheckBox4.Checked = True
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim str As String = ""
        For i As Integer = 0 To DataGridView1.RowCount - 1
            If DataGridView1.Rows(i).Cells(5).Value = True Then
                str = str & DataGridView1.Rows(i).Cells(2).Value & ", "
            End If
        Next
        If str <> "" Then
            System.Diagnostics.Process.Start("mailto:" & str)
        End If
    End Sub
End Class
