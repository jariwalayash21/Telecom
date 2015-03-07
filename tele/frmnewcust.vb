
Imports System.Data.OleDb
Public Class frmnewcust
    Dim connection As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\tele\tele\telecom.accdb")
    Dim da As OleDbDataAdapter
    Dim ds As New DataSet
    Dim spc As Integer = 0
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmstaff.Show()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmnewplan.Show()
    End Sub

    Private Sub frmnewcust_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ds2, ds5 As New DataSet
        Me.MdiParent = frmstaff
        da = New OleDbDataAdapter("select cid from customer order by cid desc", connection)
        da.Fill(ds2)
        If ds2.Tables(0).Rows.Count = 0 Then
            Label2.Text = "1"
        Else
            Label2.Text = Str(CInt(ds2.Tables(0).Rows(0).Item(0)) + 1)
        End If
        Label19.Text = Date.Today.Date.ToString("dd-MMM-yyyy")
        Dim cmd As New OleDbCommand("Select pname from plans where ctype='Landline'", connection)
        da.SelectCommand = cmd
        da.Fill(ds5)
        For i As Integer = 0 To ds5.Tables(0).Rows.Count - 1
            ListBox2.Items.Add(ds5.Tables(0).Rows(i).Item(0))
        Next
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        TabControl1.SelectedTab = TabControl1.TabPages(2)
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        TabControl1.SelectedTab = TabControl1.TabPages(1)
    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        TabControl1.SelectedTab = TabControl1.TabPages(1)
    End Sub

    Private Sub Button4_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Me.Close()
    End Sub

    Private Sub Button5_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        TabControl1.SelectedTab = TabControl1.TabPages(1)
    End Sub

    Private Sub Button8_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        TabControl1.SelectedTab = TabControl1.TabPages(0)
    End Sub

    Private Sub Button7_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        TabControl1.SelectedTab = TabControl1.TabPages(2)
    End Sub

    Private Sub Button12_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        TabControl1.SelectedTab = TabControl1.TabPages(1)
    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        If finalValidate() = 0 Then
            Exit Sub
        End If
        connection.Open()
        Dim sex, purpose, photo_id, add_id, golden As String
        Dim cnum As Double
        If RadioButton3.Checked = True Then
            sex = "Male"
        Else
            sex = "Female"
        End If
        If RadioButton5.Checked = True Then
            purpose = "Business"
        Else
            purpose = "Resedential"
        End If
        If RadioButton13.Checked Then
            photo_id = "Institute Id"
        ElseIf RadioButton12.Checked Then
            photo_id = "Driving License"
        ElseIf RadioButton11.Checked Then
            photo_id = "Passport"
        ElseIf RadioButton10.Checked Then
            photo_id = "PAN Card"
        ElseIf RadioButton9.Checked Then
            photo_id = "Voting Card"
        ElseIf RadioButton8.Checked Then
            photo_id = "Company Certified"
        Else
            photo_id = TextBox22.Text
        End If
        If RadioButton17.Checked Then
            add_id = "Ration Card"
        ElseIf RadioButton16.Checked Then
            add_id = "Telephone Bill"
        ElseIf RadioButton15.Checked Then
            add_id = "Electricity Bill"
        ElseIf RadioButton14.Checked Then
            add_id = "Credit Card / Bank Statement"
        ElseIf RadioButton2.Checked Then
            add_id = "Rent/Lease Agreement"
        Else
            add_id = TextBox24.Text
        End If
        If CheckBox1.Checked Then
            golden = "Yes"
            cnum = Val(TextBox30.Text)
        Else
            golden = "No"
            If ComboBox1.SelectedItem = "Landline" Or ComboBox1.SelectedItem = "Broadband" Then
                cnum = getNumber(1)
            Else
                cnum = getNumber(2)
            End If
        End If
        Dim cmd = New OleDbCommand("INSERT INTO customer VALUES(" & Label2.Text & ",'" & Date.Today.ToString("dd-MMM-yyyy") & "','" & TextBox1.Text & _
              "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & OpenFileDialog1.FileName & "','" & TextBox4.Text & _
              "','" & TextBox5.Text & "','" & TextBox6.Text & "','" & TextBox7.Text & "','" & sex & "','" & DateTimePicker1.Value.ToString("dd-MMM-yyyy") & _
              "','" & TextBox8.Text & "','" & TextBox9.Text & "','" & TextBox10.Text & "','" & TextBox11.Text & "','" & TextBox12.Text & _
              "','" & TextBox13.Text & "','" & TextBox14.Text & "','" & TextBox15.Text & "','" & purpose & "','" & TextBox16.Text & _
              "','" & TextBox17.Text & "','" & TextBox18.Text & "','" & TextBox19.Text & "','" & TextBox20.Text & "','" & TextBox21.Text & _
              "','" & photo_id & "','" & TextBox23.Text & "','" & add_id & "','" & TextBox29.Text & "');", connection)
        Dim cmd2 = New OleDbCommand("Insert into cust_conn values(" & cnum & ",'" & ComboBox1.SelectedItem & "'," & CInt(Label2.Text) & _
             ",'Unpaid','" & ListBox1.SelectedItem & "','" & golden & "','" & Date.Today.ToString("dd-MMM-yyyy") & "');", connection)
        If ComboBox1.SelectedItem = "Broadband" Then
            Dim cmd3 = New OleDbCommand("Insert into cust_conn values(" & cnum & ",'Landline'," & CInt(Label2.Text) & _
             ",'Unpaid','" & ListBox2.SelectedItem & "','" & golden & "','" & Date.Today.ToString("dd-MMM-yyyy") & "');", connection)
            cmd3.ExecuteReader()
        End If
        Dim ctypeforreceipt As String = ComboBox1.SelectedItem
        If ctypeforreceipt = "Broadband" Then
            ctypeforreceipt = "Landline and Broadband"
        End If
        Dim pmode As String
        If RadioButton18.Checked Then
            pmode = "Cheque"
        Else
            pmode = "Cash"
        End If
        Dim cqno, cqdate, cqbranch As String
        If pmode = "Cash" Then
            cqno = "N/A"
            cqdate = "N/A"
            cqbranch = "N/A"
        Else
            cqno = TextBox26.Text
            cqdate = TextBox27.Text
            cqbranch = TextBox28.Text
        End If
        Dim ds99 As New DataSet
        Dim rcnt As Integer
        Dim da99 = New OleDbDataAdapter("select rcnt from receipt order by rcnt desc", connection)
        da99.Fill(ds99)
        If ds99.Tables(0).Rows.Count = 0 Then
            rcnt = 1
        Else
            rcnt = ds99.Tables(0).Rows(0).Item(0) + 1
        End If
        Dim cmdReciept = New OleDbCommand("Insert into receipt values(" & Label2.Text & ",'" & TextBox1.Text & " " & TextBox2.Text & _
            " " & TextBox3.Text & "','" & TextBox12.Text & " " & TextBox13.Text & " " & TextBox14.Text & " " & TextBox15.Text & "','" & _
            Str(Int(TextBox25.Text) - spc) & "','" & ctypeforreceipt & "','" & Str(cnum) & "','" & pmode & "','" & cqno & "','" & cqdate & "','" & _
            cqbranch & "','" & Label19.Text & "','" & Str(spc) & "'," & rcnt & ")", connection)
        cmdReciept.executereader()

        cmd.ExecuteReader()
        cmd2.ExecuteReader()
        da.Fill(ds)
        MsgBox("Registered " & cnum & " to " & TextBox1.Text & " " & TextBox2.Text & " " & TextBox3.Text, 0, "Sucessful")
        connection.Close()
        frmReceipt.Show()
        Me.Close()
    End Sub
    Private Function finalValidate() As Integer
        If TextBox1.Text.Trim = "" Or _
        TextBox2.Text.Trim = "" Or _
        TextBox3.Text.Trim = "" Or _
        TextBox4.Text.Trim = "" Or _
        TextBox5.Text.Trim = "" Or _
        TextBox6.Text.Trim = "" Or _
        TextBox7.Text.Trim = "" Or _
        TextBox8.Text.Trim = "" Or _
        TextBox9.Text.Trim = "" Or _
        TextBox10.Text.Trim = "" Or _
        TextBox11.Text.Trim = "" Or _
        TextBox12.Text.Trim = "" Or _
        TextBox13.Text.Trim = "" Or _
        TextBox14.Text.Trim = "" Or _
        TextBox15.Text.Trim = "" Or _
        TextBox16.Text.Trim = "" Or _
        TextBox17.Text.Trim = "" Or _
        TextBox18.Text.Trim = "" Or _
        TextBox19.Text.Trim = "" Or _
        TextBox20.Text.Trim = "" Or _
        TextBox21.Text.Trim = "" Or _
        TextBox23.Text.Trim = "" Or _
        TextBox29.Text.Trim = "" Or _
        (Not RadioButton4.Checked And Not RadioButton3.Checked) Or _
        (Not RadioButton5.Checked And Not RadioButton6.Checked) Or _
        PictureBox1.ImageLocation = Nothing Or _
        ComboBox1.SelectedIndex = -1 Or _
        ListBox1.SelectedIndex = -1 Or _
        (ComboBox1.SelectedItem = "Broadband" And ListBox2.SelectedIndex = -1) Or _
        (Not RadioButton7.Checked And Not RadioButton8.Checked And Not RadioButton9.Checked And Not RadioButton10.Checked And Not RadioButton11.Checked And Not RadioButton12.Checked And Not RadioButton13.Checked) Or _
        (RadioButton7.Checked And TextBox22.Text.Trim = "") Or _
        (Not RadioButton1.Checked And Not RadioButton2.Checked And Not RadioButton14.Checked And Not RadioButton15.Checked And Not RadioButton16.Checked And Not RadioButton17.Checked) Or _
        (RadioButton1.Checked And TextBox24.Text.Trim = "") Or _
        (Not RadioButton18.Checked And Not RadioButton19.Checked) Or _
        (RadioButton18.Checked And (TextBox26.Text.Trim = "" Or TextBox27.Text.Trim = "" Or TextBox28.Text.Trim = "")) Or _
        (CheckBox1.Checked And (TextBox30.Text.Trim = "" Or PictureBox3.ImageLocation = Nothing Or PictureBox3.ImageLocation = "D:\tele\tele\Resources\Cancel.png")) Or _
        (CheckBox1.Checked And ((ComboBox1.SelectedItem = "Postpaid" Or ComboBox1.SelectedItem = "Prepaid") And TextBox30.Text.Length <> 10)) Or _
        (CheckBox1.Checked And ((ComboBox1.SelectedItem = "Broadband" Or ComboBox1.SelectedItem = "Landline") And TextBox30.Text.Length <> 8)) Then
            MsgBox("Please enter all values correctly", MsgBoxStyle.Exclamation, "Invalid Entry")
            Return 0
        Else
            Return 1
        End If
    End Function

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            TextBox30.Enabled = True
            Button3.Enabled = True
            PictureBox3.Enabled = True
            PictureBox3.Image = Nothing
        Else
            TextBox30.Enabled = False
            Button3.Enabled = False
            PictureBox3.Enabled = False
            PictureBox3.Image = Nothing
            TextBox30.Clear()
            spc = 0
        End If
        calcamt()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            PictureBox1.ImageLocation = OpenFileDialog1.FileName
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim planDa = New OleDbDataAdapter()
        Dim planDs As New DataSet
        Dim cmd As New OleDbCommand
        cmd.Connection = connection
        If ComboBox1.SelectedIndex = 0 Then
            cmd.CommandText = "Select pname from plans where ctype='Landline'"
            ComboBox2.Visible = False
            ListBox2.Visible = False
        ElseIf ComboBox1.SelectedIndex = 1 Then
            cmd.CommandText = "Select pname from plans where ctype ='Prepaid'"
            ComboBox2.Visible = False
            ListBox2.Visible = False
        ElseIf ComboBox1.SelectedIndex = 2 Then
            cmd.CommandText = "Select pname from plans where ctype ='Postpaid'"
            ComboBox2.Visible = False
            ListBox2.Visible = False
        Else
            cmd.CommandText = "Select pname from plans where ctype ='Broadband'"
            ComboBox2.Visible = True
            ListBox2.Visible = True
            ComboBox2.SelectedIndex = 0
        End If
        planDa.SelectCommand = cmd
        planDa.Fill(planDs)
        ListBox1.Items.Clear()
        For i As Integer = 0 To planDs.Tables(0).Rows.Count - 1
            ListBox1.Items.Add(planDs.Tables(0).Rows(i).Item(0))
        Next
        calcamt()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim cmd As New OleDbCommand("Select * from cust_conn where cnum=" & Val(TextBox30.Text), connection)
        Dim cnumDa As New OleDbDataAdapter()
        Dim cnumDs As New DataSet
        cnumDa.SelectCommand = cmd
        cnumDa.Fill(cnumDs)
        If cnumDs.Tables(0).Rows.Count = 0 Then
            PictureBox3.ImageLocation = "D:\tele\tele\Resources\tick.jpg"
        Else
            PictureBox3.ImageLocation = "D:\tele\tele\Resources\Cancel.png"
        End If
    End Sub
    Private Function getNumber(ByVal mode As Integer) As Double
        Dim cmd As New OleDbCommand()
        Dim cmd2 As New OleDbCommand()
        Dim cnumDa As New OleDbDataAdapter()
        Dim cnumDs As New DataSet
        Dim specialDs As New DataSet
        Dim teststr As Double
        Dim i As Integer = 0
        cmd.Connection = connection
        cmd2.Connection = connection
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
            If cnumDs.Tables(0).Rows.Count = 0 And specialDs.Tables(0).Rows.Count Then
                Return 7705051585
            End If
            If cnumDs.Tables(0).Rows.Count <> 0 Then
                teststr = cnumDs.Tables(0).Rows(0).Item(0) + 1
            Else
                teststr = 7705051585
            End If
        Else
            If cnumDs.Tables(0).Rows.Count = 0 And specialDs.Tables(0).Rows.Count Then
                Return 24205158
            End If
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

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        TextBox7.Clear()
        RadioButton3.Checked = False
        RadioButton4.Checked = False
        DateTimePicker1.Value = Date.Now
        TextBox8.Clear()
        TextBox9.Clear()
        TextBox10.Clear()
        TextBox11.Clear()
        TextBox12.Clear()
        TextBox13.Clear()
        TextBox14.Clear()
        TextBox15.Clear()
        RadioButton5.Checked = False
        RadioButton6.Checked = False
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        TextBox16.Clear()
        TextBox17.Clear()
        TextBox18.Clear()
        TextBox19.Clear()
        TextBox20.Clear()
        TextBox22.Clear()
        TextBox23.Clear()
        TextBox24.Clear()
        TextBox29.Clear()
        RadioButton7.Checked = False
        RadioButton8.Checked = False
        RadioButton9.Checked = False
        RadioButton10.Checked = False
        RadioButton11.Checked = False
        RadioButton12.Checked = False
        RadioButton13.Checked = False
        RadioButton14.Checked = False
        RadioButton15.Checked = False
        RadioButton16.Checked = False
        RadioButton17.Checked = False
        RadioButton1.Checked = False
        RadioButton2.Checked = False
        ComboBox1.Text = "   "
        ListBox1.Items.Clear()


    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        RadioButton18.Checked = False
        RadioButton19.Checked = False
        TextBox25.Clear()
        TextBox26.Clear()
        TextBox27.Clear()
        TextBox28.Clear()
        TextBox30.Clear()
        CheckBox1.Checked = False
    End Sub

    Private Sub Button6_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Me.Close()
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        TextBox12.Text = TextBox8.Text
        TextBox13.Text = TextBox9.Text
        TextBox14.Text = TextBox10.Text
        TextBox15.Text = TextBox11.Text
    End Sub

    Private Sub LinkLabel2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        TextBox16.Text = TextBox8.Text
        TextBox17.Text = TextBox9.Text
        TextBox18.Text = TextBox10.Text
        TextBox19.Text = TextBox11.Text
    End Sub

    Private Sub calcamt()
        Dim amt As Integer = 0
        If ComboBox1.SelectedItem = "Landline" Then
            amt = 200
            If CheckBox1.Checked Then
                amt = amt + 100
                spc = 100
            End If
        ElseIf ComboBox1.SelectedItem = "Prepaid" Then
            amt = 100
            If CheckBox1.Checked Then
                amt = amt + 75
                spc = 75
            End If
        ElseIf ComboBox1.SelectedItem = "Postpaid" Then
            amt = 150
            If CheckBox1.Checked Then
                amt = amt + 100
                spc = 100
            End If
        ElseIf ComboBox1.SelectedItem = "Broadband" Then
            amt = 700
            If CheckBox1.Checked Then
                amt = amt + 100
                spc = 100
            End If
        End If
        TextBox25.Text = amt

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


    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        validationCheck(e.KeyChar, 1)
    End Sub

    Private Sub TextBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
        validationCheck(e.KeyChar, 1)
    End Sub

    Private Sub TextBox3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox3.KeyPress
        validationCheck(e.KeyChar, 1)
    End Sub

    Private Sub TextBox4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox4.KeyPress
        validationCheck(e.KeyChar, 1)
    End Sub

    Private Sub TextBox5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox5.KeyPress
        validationCheck(e.KeyChar, 1)
    End Sub

    Private Sub TextBox6_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox6.KeyPress
        validationCheck(e.KeyChar, 1)
    End Sub

    Private Sub TextBox7_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox7.KeyPress
        validationCheck(e.KeyChar, 1)
    End Sub

    Private Sub TextBox9_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox9.KeyPress
        validationCheck(e.KeyChar, 1)
    End Sub

    Private Sub TextBox10_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox10.KeyPress
        validationCheck(e.KeyChar, 1)
    End Sub

    Private Sub TextBox11_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox11.KeyPress
        validationCheck(e.KeyChar, 4)
    End Sub

    Private Sub TextBox13_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox13.KeyPress
        validationCheck(e.KeyChar, 1)
    End Sub

    Private Sub TextBox14_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox14.KeyPress
        validationCheck(e.KeyChar, 1)
    End Sub

    Private Sub TextBox15_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox15.KeyPress
        validationCheck(e.KeyChar, 4)
    End Sub

   
    Private Sub TextBox17_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox17.KeyPress
        validationCheck(e.KeyChar, 1)
    End Sub

    Private Sub TextBox18_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox18.KeyPress
        validationCheck(e.KeyChar, 1)
    End Sub

    Private Sub TextBox22_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox22.KeyPress
        validationCheck(e.KeyChar, 2)
    End Sub

    Private Sub TextBox24_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox24.KeyPress
        validationCheck(e.KeyChar, 2)
    End Sub

    Private Sub TextBox28_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox28.KeyPress
        validationCheck(e.KeyChar, 2)
    End Sub

    Private Sub TextBox19_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox19.KeyPress
        validationCheck(e.KeyChar, 4)
    End Sub

    Private Sub TextBox20_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox20.KeyPress
        validationCheck(e.KeyChar, 4)
    End Sub

    Private Sub TextBox23_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox23.KeyPress
        validationCheck(e.KeyChar, 4)
    End Sub

    Private Sub TextBox29_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox29.KeyPress
        validationCheck(e.KeyChar, 4)
    End Sub

    Private Sub TextBox25_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox25.KeyPress
        validationCheck(e.KeyChar, 4)
    End Sub

    Private Sub TextBox26_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox26.KeyPress
        validationCheck(e.KeyChar, 4)
    End Sub

    Private Sub TextBox27_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox27.KeyPress
        validationCheck(e.KeyChar, 4)
    End Sub

    Private Sub TextBox30_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox30.KeyPress
        validationCheck(e.KeyChar, 4)
    End Sub

    Private Sub RadioButton18_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton18.CheckedChanged
        TextBox26.Enabled = True
        TextBox28.Enabled = True
        DateTimePicker2.Enabled = True
    End Sub

    Private Sub RadioButton19_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton19.CheckedChanged
        TextBox26.Enabled = False
        TextBox28.Enabled = False
        DateTimePicker2.Enabled = False
    End Sub

    Private Sub TabPage2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage2.Click

    End Sub

    Private Sub DateTimePicker2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker2.ValueChanged
        TextBox27.Text = DateTimePicker2.Value.ToString("dd-MMM-yy")
    End Sub

    Private Sub TabPage3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage3.Click

    End Sub
End Class
