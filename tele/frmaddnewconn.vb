Imports System.Data.OleDb
Public Class frmaddnewconn
    Dim conn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\tele\tele\telecom.accdb")
    Dim ds1, ds2 As New DataSet
    Dim da As New OleDbDataAdapter
    Dim cid As Integer

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub frmaddnewconn_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = frmstaff
        Label6.Text = Date.Today.ToString("dd-MMM-yyyy")
    End Sub

    Private Function getNumber(ByVal mode As Integer) As Double
        Dim cmd As New OleDbCommand()
        Dim cmd2 As New OleDbCommand()
        Dim cnumDa As New OleDbDataAdapter()
        Dim cnumDs As New DataSet
        Dim specialDs As New DataSet
        Dim teststr As Double
        Dim i As Integer = 0
        cmd.Connection = conn
        cmd2.Connection = conn
        If mode = 2 Then
            cmd.CommandText = "Select cnum from cust_conn where special='No' and (ctype='Prepaid' or ctype='Postpaid') order by cnum desc"
            cmd2.CommandText = "Select cnum from cust_conn where special='Yes' and (ctype='Prepaid' or ctype='Postpaid')"
        Else
            cmd.CommandText = "Select cnum from cust_conn where special='No' and (ctype='Broadband' or ctype='Landline') order by cnum desc"
            cmd2.CommandText = "Select cnum from cust_conn where special='Yes' and (ctype='Broadband' or ctype='Landline')"
        End If
        cnumDa.SelectCommand = cmd
        cnumDa.Fill(cnumDs)
        cnumDa.SelectCommand = cmd2
        cnumDa.Fill(specialDs)
        If mode = 2 Then
            If cnumDs.Tables(0).Rows.Count <> 0 Then
                teststr = cnumDs.Tables(0).Rows(0).Item(0) + 1
            Else
                teststr = 7705051585
            End If
        Else
            If cnumDs.Tables(0).Rows.Count <> 0 Then
                teststr = cnumDs.Tables(0).Rows(0).Item(0) + 1
            Else
                teststr = 24205158
            End If
        End If
        Do
            If Not specialDs.Tables(0).Rows.Count = 0 Then
                For j As Integer = 0 To specialDs.Tables(0).Rows.Count - 1
                    If specialDs.Tables(0).Rows(j).Item(0) = teststr Then
                        teststr = teststr + 1
                        Exit For
                    End If
                    If j = specialDs.Tables(0).Rows.Count - 1 Then
                        Return teststr
                    End If
                Next
            Else
                Return teststr
            End If
        Loop
    End Function

    Private Sub Button3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If finalValidate() = 0 Then
            Exit Sub
        End If
        Dim cno As Double = Val(TextBox2.Text)
        Dim spcl As String = "No"
        If CheckBox1.Checked Then
            cno = Val(TextBox30.Text)
            spcl = "Yes"
        Else
            If ComboBox2.SelectedItem = "Prepaid" Or ComboBox2.SelectedItem = "Postpaid" Then
                cno = getNumber(2)
                spcl = "No"
            ElseIf ComboBox2.SelectedItem = "Landline" Then
                cno = getNumber(1)
                spcl = "No"
            Else
                ' cno = Val(TextBox1.Text)
                Dim cdgetspcl = New OleDbCommand("Select special from cust_conn where cnum=" & cno, conn)
                Dim ds44 As New DataSet
                Dim da44 As New OleDbDataAdapter
                da44.SelectCommand = cdgetspcl
                da44.Fill(ds44)
                spcl = ds44.Tables(0).Rows(0).Item(0)

            End If
        End If
        conn.Open()
        Dim cmd As New OleDbCommand("Insert into cust_conn values(" & cno & ",'" & ComboBox2.SelectedItem & "'," & cid & _
                                ",'Unpaid','" & ComboBox3.SelectedItem & "', '" & spcl & "', '" & Label6.Text & "');", conn)
        cmd.ExecuteReader()
        conn.Close()
        MsgBox("Sucessfully registered " & cno & " to " & TextBox1.Text, 0, "Registration Complete")
        Button2.PerformClick()
        Button6.PerformClick()
        ComboBox1.Focus()
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        Dim planDa = New OleDbDataAdapter()
        Dim planDs As New DataSet
        Dim cmd As New OleDbCommand
        cmd.Connection = conn
        If ComboBox2.SelectedIndex = 0 Then
            cmd.CommandText = "Select pname from plans where ctype='Landline'"
            CheckBox1.Enabled = True
        ElseIf ComboBox2.SelectedIndex = 1 Then
            cmd.CommandText = "Select pname from plans where ctype ='Prepaid'"
            CheckBox1.Enabled = True
        ElseIf ComboBox2.SelectedIndex = 2 Then
            cmd.CommandText = "Select pname from plans where ctype ='Postpaid'"
            CheckBox1.Enabled = True
        Else
            cmd.CommandText = "Select pname from plans where ctype ='Broadband'"
            CheckBox1.Enabled = False
        End If
        planDa.SelectCommand = cmd
        planDa.Fill(planDs)
        ComboBox3.Items.Clear()
        For i As Integer = 0 To planDs.Tables(0).Rows.Count - 1
            ComboBox3.Items.Add(planDs.Tables(0).Rows(i).Item(0))
        Next
        ComboBox3.SelectedIndex = 0
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        If TextBox2.Text = "" Then
            Exit Sub
        End If
        Dim cmd As New OleDbCommand("Select cid from cust_conn where cnum=" & Val(TextBox2.Text), conn)
        da.SelectCommand = cmd
        da.Fill(ds1)
        If ds1.Tables(0).Rows.Count = 0 Then
            MsgBox("No connection with this number found.", 0, "Invalid number")
            TextBox2.Focus()
            Exit Sub
        End If
        cid = ds1.Tables(0).Rows(0).Item(0)
        Dim dsctype As New DataSet
        Dim cmd5 = New OleDbCommand("Select ctype from cust_conn where cnum=" & Val(TextBox2.Text), conn)
        da.SelectCommand = cmd5
        da.Fill(dsctype)
        ComboBox1.Items.Clear()
        For i As Integer = 0 To dsctype.Tables(0).Rows.Count - 1
            ComboBox1.Items.Add(dsctype.Tables(0).Rows(i).Item(0))
        Next
        If dsctype.Tables(0).Rows.Count = 1 Then
            TextBox3.Text = dsctype.Tables(0).Rows(0).Item(0)
        Else
            TextBox3.Text = dsctype.Tables(0).Rows(0).Item(0) & " and Broadband"
        End If
        ComboBox1.SelectedIndex = 0
        If ComboBox1.Items.Contains("Landline") And Not ComboBox1.Items.Contains("Broadband") Then
            ComboBox2.Items.Add("Broadband")
        End If
        cmd.CommandText = "Select cfname, cmname, clname from customer where cid=" & cid
        da.SelectCommand = cmd
        da.Fill(ds2)
        TextBox1.Text = ds2.Tables(0).Rows(0).Item(0) & " " & ds2.Tables(0).Rows(0).Item(1) & " " & ds2.Tables(0).Rows(0).Item(2)
        TextBox1.Enabled = True
        TextBox3.Enabled = True
        ComboBox1.Enabled = True
        ComboBox2.Enabled = True
        ComboBox3.Enabled = True
        CheckBox1.Enabled = True
        If CheckBox1.Checked Then
            TextBox30.Enabled = True
        Else
            Button3.Enabled = True
        End If
        Button4.Enabled = True
        Button5.Visible = False
        Button6.Visible = True
        TextBox2.Enabled = False
        PictureBox3.ImageLocation = Nothing
        ComboBox2.SelectedIndex = 0
        ComboBox3.SelectedIndex = 0
        ComboBox2.Focus()
        ds2.Clear()
        ds1.Clear()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        TextBox1.Enabled = False
        TextBox3.Enabled = False
        ComboBox1.Enabled = False
        ComboBox2.Enabled = False
        ComboBox3.Enabled = False
        TextBox30.Enabled = False
        CheckBox1.Enabled = False
        Button4.Enabled = False
        Button3.Enabled = False
        Button5.Visible = True
        Button6.Visible = False
        PictureBox3.ImageLocation = Nothing
        TextBox2.Enabled = True
        TextBox2.Focus()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim cmd As New OleDbCommand("Select * from cust_conn where cnum=" & Val(TextBox30.Text), conn)
        Dim cnumDa As New OleDbDataAdapter()
        Dim cnumDs As New DataSet
        cnumDa.SelectCommand = cmd
        cnumDa.Fill(cnumDs)
        If cnumDs.Tables(0).Rows.Count = 0 Then
            PictureBox3.ImageLocation = "D:\tele\tele\Resources\tick.jpg"
            Button3.Enabled = True
        Else
            PictureBox3.ImageLocation = "D:\tele\tele\Resources\Cancel.png"
            Button3.Enabled = False
        End If
    End Sub

    Private Sub TextBox30_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox30.Enter
        Button3.Enabled = False
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            TextBox30.Enabled = True
            Button3.Enabled = False
            PictureBox3.ImageLocation = Nothing
        Else
            TextBox30.Enabled = False
            TextBox30.Clear()
            PictureBox3.ImageLocation = Nothing
            Button3.Enabled = True
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        ComboBox1.SelectedItem = -1
        ComboBox1.Items.Clear()
        TextBox2.Clear()
        TextBox1.Clear()
        ComboBox2.SelectedIndex = -1
        ComboBox3.Items.Clear()
        TextBox30.Clear()
        CheckBox1.Checked = False
        PictureBox3.ImageLocation = Nothing
        ComboBox1.Text = ""
        ComboBox2.Text = ""
        ComboBox3.Text = ""
        ComboBox1.Focus()
        ComboBox2.Items.Remove("Broadband")
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
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

    Private Sub TextBox30_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox30.KeyPress
        validationCheck(e.KeyChar, 4)
    End Sub
    Private Function finalValidate() As Integer
        If ComboBox2.SelectedIndex = -1 Or ComboBox3.SelectedIndex = -1 Or _
        (CheckBox1.Checked And ((ComboBox2.SelectedItem = "Postpaid" Or ComboBox2.SelectedItem = "Prepaid") And TextBox30.Text.Length <> 10)) Or _
        (CheckBox1.Checked And (ComboBox2.SelectedItem = "Landline" And TextBox30.Text.Length <> 8)) Or _
        (CheckBox1.Checked And (PictureBox3.ImageLocation = Nothing Or PictureBox3.ImageLocation = "D:\tele\tele\Resources\Cancel.png")) Then
            MsgBox("Please enter all values correctly", MsgBoxStyle.Exclamation, "Invalid Entry")
            Return 0
        Else
            Return 1
        End If
    End Function
End Class