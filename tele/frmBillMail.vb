Imports System.Data.OleDb
Public Class frmBillMail
    Dim conn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\tele\tele\telecom.accdb")

    Private Sub frmBillMail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = frmadmin
        CheckBox1.Checked = True
        CheckBox2.Checked = True
        End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged, CheckBox2.CheckedChanged
        populate()
    End Sub
    Private Sub populate()
        Dim da As New OleDbDataAdapter
        Dim ds As New DataSet
        Dim cmd As New OleDbCommand
        cmd.Connection = conn
        ds.Clear()
        If CheckBox1.Checked Then
            cmd.CommandText = "Select cfname+' '+cmname+' '+clname,cnum,ctype,cemail,ccontact from customer,cust_conn where customer.cid=cust_conn.cid and billstatus='Unpaid' and ctype='Landline'"
            da.SelectCommand = cmd
            da.Fill(ds)
        End If
        If CheckBox2.Checked Then
            cmd.CommandText = "Select cfname+' '+cmname+' '+clname,cnum,ctype,cemail,ccontact from customer,cust_conn where customer.cid=cust_conn.cid and billstatus='Unpaid' and ctype='Postpaid'"
            da.SelectCommand = cmd
            da.Fill(ds)
        End If
        
        If CheckBox1.Checked OrElse CheckBox2.Checked Then
            DataGridView1.DataSource = ds
            DataGridView1.DataMember = ds.Tables(0).TableName
            DataGridView1.Columns(0).HeaderText = "Name"
            DataGridView1.Columns(1).HeaderText = "Number"
            DataGridView1.Columns(2).HeaderText = "Connection Type"
            DataGridView1.Columns(3).HeaderText = "E-mail"
            DataGridView1.Columns(4).HeaderText = "Alternate Contact"
        Else
            ds.Clear()
            DataGridView1.DataSource = ds
            DataGridView1.Refresh()
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        CheckBox1.Checked = True
        CheckBox2.Checked = True
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim str As String = ""
        For i As Integer = 0 To DataGridView1.RowCount - 1
            str = str & DataGridView1.Rows(i).Cells(3).Value & ", "
        Next
        If str <> "" Then
            System.Diagnostics.Process.Start("mailto:" & str)
        End If
    End Sub

  
End Class