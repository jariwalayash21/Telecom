Imports System.Data.OleDb
Public Class frmnewuser
    Dim connection As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\tele\tele\telecom.accdb")
    Dim da As New OleDbDataAdapter("select * from login", connection)
    Dim ds As New DataSet
   
    Private Sub frmnewuser_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = frmadmin
        da.Fill(ds)
        DataGridView1.DataSource = ds
        DataGridView1.DataMember = ds.Tables(0).TableName
        DataGridView1.Columns(0).HeaderText = "User Name"
        DataGridView1.Columns(1).HeaderText = "Password"
        DataGridView1.Columns(2).HeaderText = "Type"
        DataGridView1.Columns(3).HeaderText = "Status"
        DataGridView1.Columns(4).HeaderText = "Last Login"
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim sql As String
        Try
            sql = "select * from login where utype = 'admin' "
            da = New OleDbDataAdapter(sql, connection)
            ds.Clear()
            da.Fill(ds)
            DataGridView1.DataSource = ds
            DataGridView1.DataMember = ds.Tables(0).TableName
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Dim sql As String
        Try
            sql = "select * from login "
            da = New OleDbDataAdapter(sql, connection)
            ds.Clear()
            da.Fill(ds)
            DataGridView1.DataSource = ds
            DataGridView1.DataMember = ds.Tables(0).TableName
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Dim sql As String
        Try
            sql = "select * from login where utype = 'staff' "
            da = New OleDbDataAdapter(sql, connection)
            ds.Clear()
            da.Fill(ds)
            DataGridView1.DataSource = ds
            DataGridView1.DataMember = ds.Tables(0).TableName
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If finalValidate() = 0 Then
            Exit Sub
        End If
        connection.Open()
        Dim command = New OleDbCommand("INSERT INTO login VALUES('" & TextBox1.Text & "','" & TextBox4.Text & "','" & ComboBox1.SelectedItem & "','Active','');", connection)
        command.ExecuteReader()
        MsgBox("Record Inserted", 0, "Sucessful")
        ds.Clear()
        da.Fill(ds)
        DataGridView1.DataSource = ds
        DataGridView1.DataMember = ds.Tables(0).TableName
        connection.Close()
    End Sub
    Private Function finalValidate() As Integer
        If TextBox1.Text.Trim = "" Or TextBox4.Text.Trim = "" Or ComboBox1.SelectedIndex = -1 Then
            MsgBox("Please enter all the values", 0, "Error")
            Return 0
        End If
        If TextBox4.Text.Length < 6 Then
            MsgBox("Password Should be 6 Characters or more", 0, "Error")
            Return 0
        End If
        Return 1

    End Function

    Private Sub Button10_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        If finalValidate() = 0 Then
            Exit Sub
        End If
        connection.Open()
        Dim command = New OleDbCommand("update login SET pass = '" & TextBox4.Text & "', utype = '" & ComboBox1.SelectedItem & "' WHERE id = '" & TextBox1.Text & "';", connection)
        command.ExecuteNonQuery()
        connection.Close()
        MsgBox("Update Successful", MsgBoxStyle.OkOnly, "Changes Accepted")
        TextBox1.Clear()
        TextBox4.Clear()
        ComboBox1.SelectedIndex = -1
        ds.Clear()
        da.Fill(ds)
        DataGridView1.DataSource = ds
        DataGridView1.DataMember = ds.Tables(0).TableName
    End Sub

    Private Sub DataGridView1_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        If e.Button = Windows.Forms.MouseButtons.Right And Not (e.RowIndex = -1 Or e.ColumnIndex = -1) Then
            DataGridView1.ClearSelection()
            DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Selected = True
            ContextMenuStrip1.Show()
            ContextMenuStrip1.SetBounds(MousePosition.X, MousePosition.Y, ContextMenuStrip1.Width, ContextMenuStrip1.Height)
        End If
    End Sub

    Private Sub ToggleStatusToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToggleStatusToolStripMenuItem.Click
        Dim x, y As Integer
        connection.Open()
        x = DataGridView1.SelectedCells(0).RowIndex
        y = DataGridView1.SelectedCells(0).ColumnIndex
        If DataGridView1.SelectedRows.Count = 1 Then
            If DataGridView1.SelectedRows(0).Cells(3).Value = "Active" Then
                Dim cmd = New OleDbCommand("update login set ustatus='Inactive' where id='" & DataGridView1.SelectedRows(0).Cells(0).Value & "';", connection)
                cmd.ExecuteNonQuery()
            Else
                Dim cmd = New OleDbCommand("update login set ustatus='Active' where id='" & DataGridView1.SelectedRows(0).Cells(0).Value & "';", connection)
                cmd.ExecuteNonQuery()
            End If
        ElseIf DataGridView1.SelectedCells.Count = 1 Then
            If DataGridView1.Rows(DataGridView1.SelectedCells(0).RowIndex).Cells(3).Value = "Active" Then
                Dim cmd = New OleDbCommand("update login set ustatus='Inactive' where id='" & DataGridView1.Rows(DataGridView1.SelectedCells(0).RowIndex).Cells(0).Value & "';", connection)
                cmd.ExecuteNonQuery()
            Else
                Dim cmd = New OleDbCommand("update login set ustatus='Active' where id='" & DataGridView1.Rows(DataGridView1.SelectedCells(0).RowIndex).Cells(0).Value & "';", connection)
                cmd.ExecuteNonQuery()
            End If
        Else
            MsgBox("Select a row or cell", MsgBoxStyle.OkOnly, "Invalid Selection")
        End If
        ds.Clear()
        da.Fill(ds)
        DataGridView1.DataSource = ds
        DataGridView1.DataMember = ds.Tables(0).TableName
        DataGridView1.ClearSelection()
        DataGridView1.Rows(x).Cells(y).Selected = True
        connection.Close()
    End Sub

    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click
        TextBox1.Text = DataGridView1.Rows(DataGridView1.SelectedCells(0).RowIndex).Cells(0).Value
        TextBox4.Text = DataGridView1.Rows(DataGridView1.SelectedCells(0).RowIndex).Cells(1).Value
        If DataGridView1.Rows(DataGridView1.SelectedCells(0).RowIndex).Cells(2).Value = "Admin" Then
            ComboBox1.SelectedIndex = 1
        Else
            ComboBox1.SelectedIndex = 0
        End If
        TabControl1.SelectedTab = TabControl1.TabPages(1)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

   
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        TextBox1.Clear()
        TextBox4.Clear()
        ComboBox1.SelectedIndex = -1
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

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        validationCheck(e.KeyChar, 2)
    End Sub
End Class