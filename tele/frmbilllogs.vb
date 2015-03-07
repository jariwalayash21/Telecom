Imports System.Data.OleDb

Public Class frmbilllogs
    Dim connection As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\tele\tele\telecom.accdb")
    Dim da As New OleDbDataAdapter("select * from bill", connection)
    Dim ds As New DataSet

    Private Sub frmbilllogs_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        da.Fill(ds)
        DataGridView1.DataSource = ds
        DataGridView1.DataMember = ds.Tables(0).TableName
        DataGridView1.Columns(0).HeaderText = "Bill No."
        DataGridView1.Columns(1).HeaderText = "Bill Date"
        DataGridView1.Columns(2).HeaderText = "Contact No."
        DataGridView1.Columns(3).HeaderText = "Connection Type"
        DataGridView1.Columns(4).HeaderText = "Amount"
        DataGridView1.Columns(5).HeaderText = "Fine"
        DataGridView1.Columns(6).HeaderText = "Payment Mode"
        DataGridView1.Columns(7).HeaderText = "Cheque No."
        DataGridView1.Columns(8).HeaderText = "Cheque Date"
        DataGridView1.Columns(9).HeaderText = "Drawn Bank"
        'Button8.PerformClick()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim a As String
        Dim sql As String
        a = InputBox("Enter the Contact No.to be Searched", "Contact Number")
        Try
            sql = "select * from bill where cno = '" & a & "'"
            da = New OleDbDataAdapter(sql, connection)
            ds.Clear()
            da.Fill(ds)
            DataGridView1.DataSource = ds
            DataGridView1.DataMember = ds.Tables(0).TableName
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        GroupBox1.Visible = True
        CheckBox1.Checked = True
        CheckBox3.Checked = True
        CheckBox4.Checked = True
        Dim sql As String
        Try
            sql = "select * from bill "
            da = New OleDbDataAdapter(sql, connection)
            ds.Clear()
            da.Fill(ds)
            DataGridView1.DataSource = ds
            DataGridView1.DataMember = ds.Tables(0).TableName
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If GroupBox1.Visible = True Then
            GroupBox1.Visible = False
        Else
            GroupBox1.Visible = True
        End If
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        If GroupBox2.Visible = True Then
            GroupBox2.Visible = False
        Else
            GroupBox2.Visible = True
        End If

    End Sub

    Private Sub RadioButton3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton3.CheckedChanged
        If RadioButton3.Checked = False Then
            Exit Sub
        End If
        Dim sql As String
        Try
            sql = "select * from bill where pmode = 'Cash' "
            da = New OleDbDataAdapter(sql, connection)
            ds.Clear()
            da.Fill(ds)
            DataGridView1.DataSource = ds
            DataGridView1.DataMember = ds.Tables(0).TableName
        Catch ex As Exception
        End Try
    End Sub

    Private Sub RadioButton4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton4.CheckedChanged
        Dim sql As String
        If RadioButton4.Checked = False Then
            Exit Sub
        End If
        Try
            sql = "select * from bill where pmode = 'Cheque' "
            da = New OleDbDataAdapter(sql, connection)
            ds.Clear()
            da.Fill(ds)
            DataGridView1.DataSource = ds
            DataGridView1.DataMember = ds.Tables(0).TableName
        Catch ex As Exception
        End Try
    End Sub
    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        populate()
    End Sub
    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
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
            cmd.CommandText = "select * from bill where ctype = 'Landline'"
            da.SelectCommand = cmd
            da.Fill(ds)
        End If
        If CheckBox3.Checked Then
            cmd.CommandText = "select * from bill where ctype = 'Postpaid'"
            da.SelectCommand = cmd
            da.Fill(ds)
        End If
        If CheckBox4.Checked Then
            cmd.CommandText = "select * from bill where ctype = 'Landline and Broadband'"
            da.SelectCommand = cmd
            da.Fill(ds)
        End If
        DataGridView1.DataSource = ds
        DataGridView1.DataMember = ds.Tables(0).TableName
    End Sub
End Class