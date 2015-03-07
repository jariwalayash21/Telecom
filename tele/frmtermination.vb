Imports System.Data.OleDb
Public Class frmtermination
    Dim conn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\tele\tele\telecom.accdb")
    Dim da As New OleDbDataAdapter()
    Dim cid As Integer

    Private Sub frmtermination_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = frmstaff
    End Sub

    Private Sub Button4_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Me.Close()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        clearAll()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        If TextBox1.Text = "" Then
            Exit Sub
        End If
        Dim dsCust, dsConn As New DataSet
        Dim cmd As New OleDbCommand("Select cid,ctype,reg_date from cust_conn where cnum=" & Val(TextBox1.Text), conn)
        da.SelectCommand = cmd
        da.Fill(dsConn)
        If dsConn.Tables(0).Rows.Count = 0 Then
            MsgBox("No connection with this number found.", 0, "Invalid number")
            TextBox1.Focus()
            Exit Sub
        End If
        cid = dsConn.Tables(0).Rows(0).Item(0)
        For i As Integer = 0 To dsConn.Tables(0).Rows.Count - 1
            ComboBox1.Items.Add(dsConn.Tables(0).Rows(i).Item(1))
            ComboBox2.Items.Add(dsConn.Tables(0).Rows(i).Item(2))
        Next
        ComboBox1.SelectedIndex = 0
        ComboBox1.SelectedIndex = 0
        cmd.CommandText = "Select cfname,cmname,clname,cpadd,cpcity,cpstate,cpzip,ccontact,cimage from customer where cid=" & cid
        da.SelectCommand = cmd
        da.Fill(dsCust)
        TextBox2.Text = dsCust.Tables(0).Rows(0).Item(0)
        TextBox3.Text = dsCust.Tables(0).Rows(0).Item(1)
        TextBox4.Text = dsCust.Tables(0).Rows(0).Item(2)
        TextBox5.Text = dsCust.Tables(0).Rows(0).Item(3)
        TextBox6.Text = dsCust.Tables(0).Rows(0).Item(4)
        TextBox7.Text = dsCust.Tables(0).Rows(0).Item(5)
        TextBox8.Text = dsCust.Tables(0).Rows(0).Item(6)
        TextBox9.Text = dsCust.Tables(0).Rows(0).Item(7)
        ComboBox1.Enabled = True
        ComboBox2.Enabled = True
        Button5.Visible = False
        Button6.Visible = True
        Button2.Enabled = True
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        ComboBox2.SelectedIndex = ComboBox1.SelectedIndex
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        ComboBox1.SelectedIndex = ComboBox2.SelectedIndex
    End Sub
    Private Sub clearAll()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        TextBox7.Clear()
        TextBox8.Clear()
        TextBox9.Clear()
        ComboBox1.Items.Clear()
        ComboBox2.Items.Clear()
        ComboBox1.Enabled = False
        ComboBox2.Enabled = False
        Button5.Visible = True
        Button6.Visible = False
        Button2.Enabled = False
        TextBox1.Focus()
    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If checkBillStatus() = 0 Then
            MsgBox("Cannot terminate the connection because the bill is unpaid", MsgBoxStyle.Critical, "UNPAID BILL!")
            Exit Sub
        End If
        If ComboBox1.SelectedItem = "Landline" Then
            If MessageBox.Show("Termination of a landline connection will result in termination of the broadband connection(if existant)as" & _
                               "well on the same line", "Do you want to continue", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, _
                               MessageBoxDefaultButton.Button2, MessageBoxOptions.DefaultDesktopOnly, False) = Windows.Forms.DialogResult.No Then
                Exit Sub
            End If
        End If
        conn.Open()
        If ComboBox1.SelectedItem = "Landline" And ComboBox1.Items.Contains("Broadband") Then
            copyAndDeleteRecord("Broadband")
            copyAndDeleteRecord("Landline")
        Else
            copyAndDeleteRecord(ComboBox1.SelectedItem)
        End If
        Dim dsConn, dsCust, dsConn_old, dsCust_old As New DataSet
        Dim cmdGet As New OleDbCommand
        cmdGet.Connection = conn
        cmdGet.CommandText = "Select * from cust_conn where cid=" & cid
        Dim dsFindMore As New DataSet
        da.SelectCommand = cmdGet
        da.Fill(dsFindMore)
        Dim more As Integer
        If dsFindMore.Tables(0).Rows.Count = 0 Then
            more = 0
        Else
            more = 1
        End If
        If more = 0 Then
            Dim dr As OleDbDataReader
            cmdGet.CommandText = "Select * from customer where cid=" & cid
            dr = cmdGet.ExecuteReader()
            dr.Read()
            Dim cmdPut2 As New OleDbCommand
            cmdPut2.CommandText = "Insert into cust_old values(" & dr.Item(0) & ",'" & dr.Item(1) & "','" & dr.Item(2) & "','" & dr.Item(3) & "','" & _
                                dr.Item(4) & "','" & dr.Item(5) & "','" & dr.Item(6) & "','" & dr.Item(7) & "','" & dr.Item(8) & "','" & dr.Item(9) & "','" & _
                                dr.Item(10) & "','" & dr.Item(11) & "','" & dr.Item(12) & "','" & dr.Item(13) & "','" & dr.Item(14) & "','" & dr.Item(15) & "','" & _
                                dr.Item(16) & "','" & dr.Item(17) & "','" & dr.Item(18) & "','" & dr.Item(19) & "','" & dr.Item(20) & "','" & dr.Item(21) & "','" & _
                                dr.Item(22) & "','" & dr.Item(23) & "','" & dr.Item(24) & "','" & dr.Item(25) & "','" & dr.Item(26) & "','" & dr.Item(27) & "','" & _
                                dr.Item(28) & "','" & dr.Item(29) & "','" & dr.Item(30) & "')"
            cmdPut2.Connection = conn
            cmdPut2.ExecuteReader()
            Dim cmddel3 As New OleDbCommand("Delete from customer where cid=" & cid, conn)
            cmddel3.ExecuteNonQuery()
        End If
        conn.Close()
        MsgBox("Terminated connection with number: " & TextBox1.Text, 0, "Done")
        clearAll()
    End Sub

    Private Sub copyAndDeleteRecord(ByVal c_type As String)
        Dim dsConn As New DataSet
        Dim cmdGet As New OleDbCommand("Select plan,special,reg_date,billstatus from cust_conn where cid=" & cid & " and cnum=" & Val(TextBox1.Text) & _
                                       " and ctype='" & c_type & "'", conn)
        da.SelectCommand = cmdGet
        da.Fill(dsConn)
        Dim cmdPut As New OleDbCommand("Insert into cust_conn_old values(" & Val(TextBox1.Text) & ",'" & c_type & "'," _
                                        & cid & ",'" & dsConn.Tables(0).Rows(0).Item(0) & "','" & dsConn.Tables(0).Rows(0).Item(3) & "','" & dsConn.Tables(0).Rows(0).Item(1) & "','" _
                                        & dsConn.Tables(0).Rows(0).Item(2) & "','" & Date.Today.Date.ToString("dd-MMM-yyyy") & "')", conn)
        cmdPut.ExecuteReader()
        Dim cmdRemove As New OleDbCommand("Delete from cust_conn where cnum=" & Val(TextBox1.Text) & " and ctype='" & c_type & "'", conn)
        cmdRemove.ExecuteNonQuery()
    End Sub


    Private Function checkBillStatus() As Integer
        Dim statusDa As New OleDbDataAdapter("Select billstatus,reg_date from cust_conn where cnum=" & Val(TextBox1.Text), conn)
        Dim statusDs As New DataSet
        statusDa.Fill(statusDs)
        If statusDs.Tables(0).Rows(0).Item(0) = "Paid" Then
            Return 1
        Else
            Return 0
        End If
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
        validationCheck(e.KeyChar, 4)
    End Sub
End Class