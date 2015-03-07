Imports System.Data.OleDb
Public Class frmbillpayment

    Dim conn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\tele\tele\telecom.accdb")
    Dim ds As New DataSet
    Dim da As OleDbDataAdapter
    Private Sub frmbillpayment_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = frmstaff
        Label6.Text = Date.Today.ToString("dd-MMM-yyyy")
        da = New OleDbDataAdapter("select billno from bill order by billno desc", conn)
        da.Fill(ds)
        If ds.Tables(0).Rows.Count = 0 Then
            Label5.Text = "1"
        Else
            Label5.Text = Str(CInt(ds.Tables(0).Rows(0).Item(0)) + 1)
        End If
    End Sub

    Private Sub Button15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button15.Click
        If finalValidate() = 0 Then
            Exit Sub
        End If
        conn.Open()

        Dim daGetName As New OleDbDataAdapter("Select cfname,cmname,clname from customer where cid=(select min(cid) from cust_conn where cnum=" & Val(TextBox1.Text) & ")", conn)
        Dim dsGetName As New DataSet
        daGetName.Fill(dsGetName)
        Dim cname As String = dsGetName.Tables(0).Rows(0).Item(0) & " " & dsGetName.Tables(0).Rows(0).Item(1) & " " & dsGetName.Tables(0).Rows(0).Item(2)
        Dim mode As String
        If RadioButton1.Checked Then
            mode = "Cash"
        Else
            mode = "Cheque"
        End If
        Dim cmd = New OleDbCommand("INSERT INTO bill VALUES('" & Label5.Text & "','" & Label6.Text & "','" & TextBox1.Text & "','" & TextBox14.Text & "','" & TextBox2.Text & "','" & Str(Val(TextBox3.Text) - Val(TextBox2.Text)) & "','" & mode & "','" & TextBox6.Text & "','" & DateTimePicker1.Value.ToString("dd-MMM-yyyy") & "','" & TextBox8.Text & "','" & cname & "');", conn)
        cmd.ExecuteReader()
        MsgBox("Record Inserted")
        Dim cmd2 As New OleDbCommand("update cust_conn set billstatus='Paid' where cnum=" & Val(TextBox1.Text), conn)
        cmd2.ExecuteNonQuery()
        conn.Close()
        DateTimePicker1.Value = Today
        frmbillreceipt.Show(CInt(Label5.Text))
        Me.Close()
    End Sub

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        Me.Close()
    End Sub

    Private Sub TextBox3_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox3.GotFocus
        Dim cur_date As Integer = CInt(Label6.Text.Substring(0, 2))
        If cur_date <= 15 Then
            TextBox3.Text = TextBox2.Text
            Exit Sub
        End If
        Dim fine As Double
        Dim amt As Double = Val(TextBox2.Text)
        If amt >= 100 And amt < 500 Then
            fine = 20
        ElseIf amt >= 500 And amt < 1000 Then
            fine = 30
        ElseIf amt >= 1000 And amt <= 1500 Then
            fine = 40
        Else
            fine = 60
        End If
        TextBox3.Text = Str(Val(TextBox2.Text) + fine)
    End Sub

    Private Sub TabPage2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage2.Click

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        TextBox2.Text = TextBox11.Text
        TextBox14.Text = TextBox12.Text
        TextBox1.Text = TextBox4.Text
        TabPage1.Show()
        TextBox3.Focus()
    End Sub

    Private Sub TextBox10_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox10.GotFocus, TextBox12.GotFocus

        Dim cmd = New OleDbCommand("select * from tech_bill where cnum=" & Val(TextBox4.Text), conn)
        Dim ds100 As New DataSet
        Dim da100 As New OleDbDataAdapter
        da100.SelectCommand = cmd
        da100.Fill(ds100)
        If ds100.Tables(0).Rows.Count = 0 Then
            MsgBox("No such phone number", 0, "Error")
            TextBox4.Focus()
            Exit Sub
        End If
        TextBox10.Text = ds100.Tables(0).Rows(0).Item(3)
        TextBox9.Text = ds100.Tables(0).Rows(0).Item(4)
        TextBox7.Text = ds100.Tables(0).Rows(0).Item(5)
        TextBox13.Text = ds100.Tables(0).Rows(0).Item(0)
        TextBox12.Text = ds100.Tables(0).Rows(0).Item(2)
        TextBox11.Text = ds100.Tables(0).Rows(0).Item(6)
        If ds100.Tables(0).Rows.Count = 2 Then
            TextBox12.Text = TextBox12.Text & " and Broadband"
            TextBox11.Text = Str(Val(TextBox11.Text) + ds100.Tables(0).Rows(1).Item(6))
        End If
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        validationCheck(e.KeyChar, 4)
    End Sub

    Private Sub TextBox1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.Leave
        If TextBox1.Text = "" Then
            Exit Sub
        End If
        Dim dsCust As New DataSet
        Dim cmd As New OleDbCommand("Select ctype from cust_conn where cnum=" & Val(TextBox1.Text), conn)
        da.SelectCommand = cmd
        da.Fill(dsCust)
        If dsCust.Tables(0).Rows.Count = 0 Then
            MsgBox("No connection with this number found.", 0, "Invalid number")
            TextBox1.Focus()
            Exit Sub
        End If
        TextBox14.Text = dsCust.Tables(0).Rows(0).Item(0)
        If dsCust.Tables(0).Rows.Count = 2 Then
            TextBox14.Text = TextBox14.Text + " and " + dsCust.Tables(0).Rows(1).Item(0)
        End If
    End Sub

    Private Sub TextBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
        validationCheck(e.KeyChar, 4)
    End Sub

    Private Sub TextBox2_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox2.Leave
        Dim cmd As New OleDbCommand("Select * from tech_bill where amt='" & TextBox2.Text & "'", conn)
        Dim cnumDa As New OleDbDataAdapter()
        Dim cnumDs As New DataSet
        cnumDa.SelectCommand = cmd
        cnumDa.Fill(cnumDs)
        If cnumDs.Tables(0).Rows.Count = 0 Then
            'PictureBox3.ImageLocation = "D:\tele\tele\Resources\tick.jpg"
        Else
            'PictureBox3.ImageLocation = "D:\tele\tele\Resources\Cancel.png"
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox14.Clear()
        TextBox6.Clear()
        TextBox8.Clear()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        TextBox4.Clear()
        TextBox13.Clear()
        TextBox10.Clear()
        TextBox9.Clear()
        TextBox7.Clear()
        TextBox12.Clear()
        TextBox11.Clear()
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
        If mode = 5 Then
            If Not (key >= "A" And key <= "Z") And Not (key >= "a" And key <= "z") And Not key = Chr(8) And Not (key >= "0" And key <= "9") Then
                key = ""
            End If
        End If
    End Sub



    Private Sub TextBox6_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox6.KeyPress
        validationCheck(e.KeyChar, 5)
    End Sub

    Private Sub TextBox8_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox8.KeyPress
        validationCheck(e.KeyChar, 2)
    End Sub

    Private Sub TextBox4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox4.KeyPress
        validationCheck(e.KeyChar, 4)
    End Sub
    Private Function finalValidate() As Integer
        If TextBox1.Text.Trim = "" Or _
        TextBox2.Text.Trim = "" Or _
        TextBox3.Text.Trim = "" Or _
         TextBox14.Text.Trim = "" Or _
        (TextBox1.Text.Length <> 8 And TextBox2.Text.Length <> 10) Or _
        (Not RadioButton1.Checked And Not RadioButton2.Checked) Or _
        (RadioButton2.Checked And (TextBox6.Text.Trim = "" Or TextBox8.Text.Trim = "")) Or _
            MsgBox("Please enter all values correctly", MsgBoxStyle.Exclamation, "Invalid Entry") Then
            Return 0
        Else
            Return 1
        End If
    End Function

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        TextBox6.Enabled = True
        TextBox8.Enabled = True
        DateTimePicker1.Enabled = True
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        TextBox6.Enabled = False
        TextBox8.Enabled = False
        DateTimePicker1.Enabled = False
    End Sub

    Private Sub TabPage1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage1.Click

    End Sub
End Class