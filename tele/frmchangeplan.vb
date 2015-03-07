Imports System.Data.OleDb
Public Class frmchangeplan
    Dim ds1, ds2 As New DataSet
    Dim conn As New oledbconnection("Provider=Microsoft.ACE.OLEDB.12.0.;Data Source=D:\tele\tele\telecom.accdb")
    Dim da As New OleDbDataAdapter()
    Dim cid As Integer
    Private Sub frmchangeplan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = frmstaff
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If TextBox2.Text = "" Then
            Exit Sub
        End If
        Dim cmd As New OleDbCommand("Select cid,ctype from cust_conn where cnum=" & Val(TextBox2.Text), conn)
        da.SelectCommand = cmd
        da.Fill(ds1)
        If ds1.Tables(0).Rows.Count = 0 Then
            MsgBox("No connection with this number found.", 0, "Invalid number")
            TextBox2.Focus()
            Exit Sub
        End If
        cid = ds1.Tables(0).Rows(0).Item(0)
        Dim cmd5 = New OleDbCommand("Select ctype,plan from cust_conn where cid=" & cid & " and cnum=" & Val(TextBox2.Text), conn)
        Dim dsctype As New DataSet
        da.SelectCommand = cmd5
        da.Fill(dsctype)
        ComboBox1.Items.Clear()
        ComboBox3.Items.Clear()
        For i As Integer = 0 To dsctype.Tables(0).Rows.Count - 1
            ComboBox1.Items.Add(dsctype.Tables(0).Rows(i).Item(0))
            ComboBox3.Items.Add(dsctype.Tables(0).Rows(i).Item(1))
        Next
        ComboBox1.SelectedIndex = 0
        ComboBox3.SelectedIndex = 0
        cmd.CommandText = "Select cfname, cmname, clname from customer where cid=" & cid
        da.SelectCommand = cmd
        da.Fill(ds2)
        TextBox1.Text = ds2.Tables(0).Rows(0).Item(0) & " " & ds2.Tables(0).Rows(0).Item(1) & " " & ds2.Tables(0).Rows(0).Item(2)
        TextBox1.Enabled = True
        ComboBox1.Enabled = True
        ComboBox2.Enabled = True
        Button3.Enabled = True
        Button4.Enabled = True
        Button5.Visible = False
        TextBox2.Enabled = False
        ComboBox3.Enabled = True
        ComboBox2.Focus()
        Button4.Visible = False
        Button5.Visible = True
        ds2.Clear()
        ds1.Clear()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If ComboBox2.SelectedIndex = -1 Then
            MsgBox("Select new plan please", 0, "Invalid Entry")
            Exit Sub
        End If
        conn.Open()
        Dim cmd As New OleDbCommand("Update cust_conn set plan='" & ComboBox2.SelectedItem & "' where cnum=" & Val(TextBox2.Text) & _
                                    " and ctype='" & ComboBox1.SelectedItem & "'", conn)
        cmd.ExecuteNonQuery()
        MsgBox("Changed plan for " & TextBox2.Text & "(" & ComboBox1.SelectedItem & ") to " & ComboBox2.SelectedItem, 0, "Sucessful")
        conn.Close()
        clearall()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        ComboBox3.SelectedIndex = ComboBox1.SelectedIndex
        Dim planDa = New OleDbDataAdapter()
        Dim planDs As New DataSet
        Dim cmd As New OleDbCommand
        cmd.Connection = conn
        If ComboBox1.SelectedItem = "Broadband" Then
            cmd.CommandText = "Select pname from plans where ctype='Broadband'"
        ElseIf ComboBox1.SelectedItem = "Landline" Then
            cmd.CommandText = "Select pname from plans where ctype ='Landline'"
        ElseIf ComboBox1.SelectedItem = "Prepaid" Then
            cmd.CommandText = "Select pname from plans where ctype ='Prepaid'"
        Else
            cmd.CommandText = "Select pname from plans where ctype ='Postpaid'"
        End If
        planDa.SelectCommand = cmd
        planDa.Fill(planDs)
        ComboBox2.Items.Clear()
        For i As Integer = 0 To planDs.Tables(0).Rows.Count - 1
            ComboBox2.Items.Add(planDs.Tables(0).Rows(i).Item(0))
        Next
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        clearall()
        Button5.Visible = False
        Button4.Visible = True
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox3.SelectedIndexChanged
        ComboBox1.SelectedIndex = ComboBox3.SelectedIndex
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        clearAll()
    End Sub
    Private Sub clearall()
        ComboBox1.Items.Clear()
        ComboBox2.Items.Clear()
        ComboBox3.Items.Clear()
        TextBox1.Clear()
        TextBox1.Enabled = False
        ComboBox1.Enabled = False
        ComboBox2.Enabled = False
        ComboBox3.Enabled = False
        Button4.Visible = True
        TextBox2.Enabled = True
        TextBox2.Focus()
        Button3.Enabled = False
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



    Private Sub TextBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
        validationCheck(e.KeyChar, 4)
    End Sub
End Class