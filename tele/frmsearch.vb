Imports System.Data.OleDb
Public Class frmsearch
    Dim conn As New OleDbConnection("Provider=Microsoft.Ace.Oledb.12.0;Data Source=D:\tele\tele\telecom.accdb")
    Dim ds As New DataSet

    Private Sub frmsearch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = frmstaff
        populate(1)
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked Then
            TextBox29.Visible = True
            TextBox29.Focus()
        End If
    End Sub

    Private Sub RadioButton3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton3.CheckedChanged
        If RadioButton3.Checked Then
            TextBox29.Visible = True
            TextBox29.Focus()
        End If
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked Then
            TextBox29.Visible = True
            TextBox29.Focus()
        End If
    End Sub

    Private Sub RadioButton4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton4.CheckedChanged
        TextBox29.Visible = False
        TextBox29.Clear()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        populate()
    End Sub

    Private Sub populate(Optional ByVal mode As Integer = 0)
        Dim da As New OleDbDataAdapter()
        Dim cmd As New OleDbCommand()
        cmd.Connection = conn
        ds.Clear()
        Try
            If mode = 1 Then
                cmd.CommandText = "Select * from customer order by cid"
                da.SelectCommand = cmd
                da.Fill(ds)
                fillDataGrid(ds)
                If DataGridView1.SelectedCells.Count > 0 Then
                    gotClick(DataGridView1.SelectedCells(0).RowIndex)
                Else
                    clearAll()
                End If
            Else
                If RadioButton2.Checked Then
                    cmd.CommandText = "Select * from customer where cid=" & CInt(TextBox29.Text)
                    da.SelectCommand = cmd
                    da.Fill(ds)
                    fillDataGrid(ds)
                ElseIf RadioButton3.Checked Then
                    Dim da2 As New OleDbDataAdapter
                    Dim cmd2 As New OleDbCommand("Select cid from cust_conn where cnum=" & Val(TextBox29.Text), conn)
                    Dim ds2 As New DataSet
                    da2.SelectCommand = cmd2
                    da2.Fill(ds2)
                    cmd.CommandText = "Select * from customer where cid=" & ds2.Tables(0).Rows(0).Item(0)
                    da.SelectCommand = cmd
                    da.Fill(ds)
                    fillDataGrid(ds)
                ElseIf RadioButton1.Checked Then
                    Dim cname As String = TextBox29.Text
                    cmd.CommandText = "Select * from customer where cfname='" & cname & "' or cmname='" & cname & "' or clname='" & cname & "'"
                    da.SelectCommand = cmd
                    da.Fill(ds)
                    fillDataGrid(ds)
                Else
                    cmd.CommandText = "Select * from customer where cid in (Select cid from cust_conn where billstatus='Unpaid')"
                    da.SelectCommand = cmd
                    da.Fill(ds)
                    fillDataGrid(ds)
                End If
                If DataGridView1.SelectedCells.Count > 0 Then
                    gotClick(DataGridView1.SelectedCells(0).RowIndex)
                Else
                    clearAll()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        RadioButton1.Checked = False
        RadioButton2.Checked = False
        RadioButton3.Checked = False
        RadioButton4.Checked = False
        TextBox29.Visible = False
        TextBox29.Clear()
        populate(1)
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
    
    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim r_index As Integer = e.RowIndex
        If r_index <> -1 Then
            gotClick(r_index)
        End If

    End Sub

    Public Sub fillDataGrid(ByVal ds As DataSet)
        DataGridView1.DataSource = ds
        DataGridView1.DataMember = ds.Tables(0).TableName
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        ComboBox2.SelectedIndex = ComboBox1.SelectedIndex
        ComboBox3.SelectedIndex = ComboBox1.SelectedIndex
        ComboBox4.SelectedIndex = ComboBox1.SelectedIndex
        ComboBox5.SelectedIndex = ComboBox1.SelectedIndex
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        ComboBox1.SelectedIndex = ComboBox2.SelectedIndex
        ComboBox3.SelectedIndex = ComboBox2.SelectedIndex
        ComboBox4.SelectedIndex = ComboBox2.SelectedIndex
        ComboBox5.SelectedIndex = ComboBox2.SelectedIndex
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox3.SelectedIndexChanged
        ComboBox2.SelectedIndex = ComboBox3.SelectedIndex
        ComboBox1.SelectedIndex = ComboBox3.SelectedIndex
        ComboBox4.SelectedIndex = ComboBox3.SelectedIndex
        ComboBox5.SelectedIndex = ComboBox3.SelectedIndex
    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox4.SelectedIndexChanged
        ComboBox2.SelectedIndex = ComboBox4.SelectedIndex
        ComboBox1.SelectedIndex = ComboBox4.SelectedIndex
        ComboBox3.SelectedIndex = ComboBox4.SelectedIndex
        ComboBox5.SelectedIndex = ComboBox4.SelectedIndex
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        TabControl1.SelectedTab = TabControl1.TabPages(1)
    End Sub
    Private Sub gotClick(ByVal r_index As Integer)
        Label1.Text = DataGridView1.Rows(r_index).Cells(0).Value
        Label8.Text = DataGridView1.Rows(r_index).Cells(1).Value
        TextBox1.Text = DataGridView1.Rows(r_index).Cells(2).Value
        TextBox2.Text = DataGridView1.Rows(r_index).Cells(3).Value
        TextBox3.Text = DataGridView1.Rows(r_index).Cells(4).Value
        PictureBox2.ImageLocation = DataGridView1.Rows(r_index).Cells(5).Value
        TextBox4.Text = DataGridView1.Rows(r_index).Cells(6).Value
        TextBox5.Text = DataGridView1.Rows(r_index).Cells(7).Value
        TextBox6.Text = DataGridView1.Rows(r_index).Cells(8).Value
        TextBox7.Text = DataGridView1.Rows(r_index).Cells(9).Value
        TextBox30.Text = DataGridView1.Rows(r_index).Cells(10).Value
        TextBox8.Text = DataGridView1.Rows(r_index).Cells(11).Value
        TextBox9.Text = DataGridView1.Rows(r_index).Cells(12).Value
        TextBox10.Text = DataGridView1.Rows(r_index).Cells(13).Value
        TextBox11.Text = DataGridView1.Rows(r_index).Cells(14).Value
        TextBox12.Text = DataGridView1.Rows(r_index).Cells(15).Value
        TextBox13.Text = DataGridView1.Rows(r_index).Cells(16).Value
        TextBox14.Text = DataGridView1.Rows(r_index).Cells(17).Value
        TextBox15.Text = DataGridView1.Rows(r_index).Cells(18).Value
        TextBox16.Text = DataGridView1.Rows(r_index).Cells(19).Value
        TextBox31.Text = DataGridView1.Rows(r_index).Cells(20).Value
        TextBox20.Text = DataGridView1.Rows(r_index).Cells(21).Value
        TextBox19.Text = DataGridView1.Rows(r_index).Cells(22).Value
        TextBox18.Text = DataGridView1.Rows(r_index).Cells(23).Value
        TextBox17.Text = DataGridView1.Rows(r_index).Cells(24).Value
        TextBox21.Text = DataGridView1.Rows(r_index).Cells(25).Value
        TextBox22.Text = DataGridView1.Rows(r_index).Cells(26).Value
        TextBox25.Text = DataGridView1.Rows(r_index).Cells(27).Value
        TextBox26.Text = DataGridView1.Rows(r_index).Cells(28).Value
        TextBox28.Text = DataGridView1.Rows(r_index).Cells(29).Value
        TextBox27.Text = DataGridView1.Rows(r_index).Cells(30).Value
        Dim da10 As New OleDbDataAdapter("Select ctype,cnum,plan,billstatus,reg_date from cust_conn where cid=" & CInt(Label1.Text), conn)
        Dim ds10 As New DataSet
        da10.Fill(ds10)
        ComboBox1.Items.Clear()
        ComboBox2.Items.Clear()
        ComboBox3.Items.Clear()
        ComboBox4.Items.Clear()
        ComboBox5.Items.Clear()
        For i As Integer = 0 To ds10.Tables(0).Rows.Count - 1
            ComboBox1.Items.Add(ds10.Tables(0).Rows(i).Item(0))
            ComboBox2.Items.Add(ds10.Tables(0).Rows(i).Item(1))
            ComboBox3.Items.Add(ds10.Tables(0).Rows(i).Item(2))
            ComboBox4.Items.Add(ds10.Tables(0).Rows(i).Item(3))
            ComboBox5.Items.Add(ds10.Tables(0).Rows(i).Item(4))
        Next
        ComboBox1.SelectedIndex = 0
    End Sub

    Private Sub clearAll()
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        TextBox7.Clear()
        TextBox8.Clear()
        TextBox9.Clear()
        TextBox10.Clear()
        TextBox11.Clear()
        TextBox12.Clear()
        TextBox13.Clear()
        TextBox14.Clear()
        TextBox15.Clear()
        TextBox16.Clear()
        TextBox31.Clear()
        Label1.Text = "    "
        Label8.Text = "    "
        PictureBox2.ImageLocation = Nothing
        TextBox17.Clear()
        TextBox18.Clear()
        TextBox19.Clear()
        TextBox20.Clear()
        TextBox21.Clear()
        TextBox22.Clear()
        TextBox25.Clear()
        TextBox26.Clear()
        TextBox27.Clear()
        TextBox28.Clear()
        ComboBox1.Items.Clear()
        ComboBox2.Items.Clear()
        ComboBox3.Items.Clear()
        ComboBox4.Items.Clear()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        TabPage1.Show()
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        clearAll()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        TabPage2.Show()
    End Sub

    Private Sub Button4_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        clearAll()
    End Sub

    Private Sub ComboBox5_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox5.SelectedIndexChanged
        ComboBox2.SelectedIndex = ComboBox5.SelectedIndex
        ComboBox1.SelectedIndex = ComboBox5.SelectedIndex
        ComboBox4.SelectedIndex = ComboBox5.SelectedIndex
        ComboBox3.SelectedIndex = ComboBox5.SelectedIndex
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        TabControl1.SelectedTab = TabControl1.TabPages(2)
    End Sub

    Private Sub Button6_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        TabControl1.SelectedTab = TabControl1.TabPages(0)
    End Sub

    Private Sub Button7_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        clearAll()
    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        TabControl1.SelectedTab = TabControl1.TabPages(2)
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        TabControl1.SelectedTab = TabControl1.TabPages(1)
    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        TabControl1.SelectedTab = TabControl1.TabPages(0)
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        clearAll()
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



    Private Sub TextBox29_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox29.KeyPress
        
    End Sub
End Class