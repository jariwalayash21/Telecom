Imports System.Data.OleDb

Public Class frmnewplan
    Dim connection As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\tele\tele\telecom.accdb")
    Dim da As New OleDbDataAdapter("select * from plans", connection)
    Dim ds As New DataSet

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub frmnewplan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = frmadmin
        fillDataGrid()
        DataGridView1.Columns(0).HeaderText = "Plan Name"
        DataGridView1.Columns(1).HeaderText = "     Description      "
        DataGridView1.Columns(2).HeaderText = "Connection Type"
        DataGridView1.Columns(3).HeaderText = "Status"
      End Sub



    Private Sub Button15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button15.Click
        If TextBox1.Text.Trim = "" Or TextBox4.Text.Trim = "" Or ComboBox1.SelectedIndex = -1 Then
            MsgBox("Please Enter all the values", 0, "Error")
            Exit Sub
        End If
        Dim connection As New OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\tele\tele\telecom.accdb")
        connection.Open()
        Dim command = New OleDb.OleDbCommand("INSERT INTO plans VALUES('" & TextBox1.Text & "','" & TextBox4.Text & "','" & ComboBox1.SelectedItem & "','Active');", connection)
        command.ExecuteReader()
        MsgBox("Added new plan", 0, "Success")
        connection.Close()
        populate()
    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim x, y As Integer
        If DataGridView1.SelectedCells.Count = 0 Then
            Exit Sub
        End If
        connection.Open()
        x = DataGridView1.SelectedCells(0).RowIndex
        y = DataGridView1.SelectedCells(0).ColumnIndex
        If DataGridView1.SelectedRows.Count = 1 Then
            If DataGridView1.SelectedRows(0).Cells(3).Value = "Active" Then
                Dim cmd = New OleDbCommand("update plans set pstatus='Inactive' where pname='" & DataGridView1.SelectedRows(0).Cells(0).Value & "';", connection)
                cmd.ExecuteNonQuery()
            Else
                Dim cmd = New OleDbCommand("update plans set pstatus='Active' where pname='" & DataGridView1.SelectedRows(0).Cells(0).Value & "';", connection)
                cmd.ExecuteNonQuery()
            End If
        ElseIf DataGridView1.SelectedCells.Count = 1 Then
            If DataGridView1.Rows(DataGridView1.SelectedCells(0).RowIndex).Cells(3).Value = "Active" Then
                Dim cmd = New OleDbCommand("update plans set pstatus='Inactive' where pname='" & DataGridView1.Rows(DataGridView1.SelectedCells(0).RowIndex).Cells(0).Value & "';", connection)
                cmd.ExecuteNonQuery()
            Else
                Dim cmd = New OleDbCommand("update plans set pstatus='Active' where pname='" & DataGridView1.Rows(DataGridView1.SelectedCells(0).RowIndex).Cells(0).Value & "';", connection)
                cmd.ExecuteNonQuery()
            End If
        Else
            MsgBox("Select a row or cell", MsgBoxStyle.OkOnly, "Invalid Selection")
        End If
        ds.Clear()
        populate()
        DataGridView1.DataSource = ds
        DataGridView1.DataMember = ds.Tables(0).TableName
        DataGridView1.ClearSelection()
        connection.Close()
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
            cmd.CommandText = "select * from plans where ctype = 'Landline'"
            da.SelectCommand = cmd
            da.Fill(ds)
        End If
        If CheckBox2.Checked Then
            cmd.CommandText = "select * from plans where ctype = 'Prepaid'"
            da.SelectCommand = cmd
            da.Fill(ds)
        End If
        If CheckBox3.Checked Then
            cmd.CommandText = "select * from plans where ctype = 'Postpaid'"
            da.SelectCommand = cmd
            da.Fill(ds)
        End If
        If CheckBox4.Checked Then
            cmd.CommandText = "select * from plans where ctype = 'Broadband'"
            da.SelectCommand = cmd
            da.Fill(ds)
        End If
        DataGridView1.DataSource = ds
        DataGridView1.DataMember = ds.Tables(0).TableName
    End Sub

    Private Sub Button3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        CheckBox1.Checked = True
        CheckBox2.Checked = True
        CheckBox3.Checked = True
        CheckBox4.Checked = True
    End Sub

    Private Sub Button4_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Me.Close()
    End Sub
    Private Sub fillDataGrid()
        Dim cmd = New OleDbCommand("Select * from plans", connection)
        Dim tempda = New OleDbDataAdapter()
        Dim tempds = New DataSet
        tempda.SelectCommand = cmd
        tempda.Fill(tempds)
        DataGridView1.DataSource = Nothing
        DataGridView1.DataMember = Nothing
        DataGridView1.DataSource = tempds
        DataGridView1.DataMember = tempds.Tables(0).TableName
    End Sub

    Private Sub Button5_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        TextBox1.Clear()
        TextBox4.Clear()
        ComboBox1.SelectedIndex = -1
    End Sub

    Private Sub TabPage1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage1.Click

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

    
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        validationCheck(e.KeyChar, 3)
    End Sub

    Private Sub TextBox4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox4.KeyPress
        validationCheck(e.KeyChar, 3)
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub
End Class
