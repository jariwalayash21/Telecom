Imports System.Data.OleDb

Public Class frmtransfer
    Dim connection As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\tele\tele\telecom.accdb")
    Dim cid As Integer
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub frmtransfer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = frmstaff
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        validationCheck(e.KeyChar, 4)
    End Sub
    
    Private Sub TextBox1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.Leave
        Dim ds2, ds3 As New DataSet
        Dim caddtype As String
        If TextBox1.Text = "" Then
            Exit Sub
        End If
        Dim cmd As New OleDbCommand("Select cid from cust_conn where cnum=" & TextBox1.Text, connection)
        Dim connDa As New OleDbDataAdapter
        connDa.SelectCommand = cmd
        connDa.Fill(ds2)
        If ds2.Tables(0).Rows.Count = 0 Then
            MsgBox("No record found", 0, "Invalid number")
            TextBox1.Focus()
            Exit Sub
        End If
        cid = ds2.Tables(0).Rows(0).Item(0)
        cmd.CommandText = "Select ccontact, cemail, ctadd, ctcity, ctstate, ctzip, cpadd, cpcity, cpstate, cpzip, cbadd, cbcity, cbstate, cbzip," & _
                            " caddtype, caddno from customer where cid=" & cid
        connDa.SelectCommand = cmd
        connDa.Fill(ds3)
        caddtype = ds3.Tables(0).Rows(0).Item("caddtype")
        If caddtype = "Ration Card" Then
            RadioButton1.Checked = True
        ElseIf caddtype = "Telephone Bill" Then
            RadioButton2.Checked = True
        ElseIf caddtype = "Electricity Bill" Then
            RadioButton3.Checked = True
        ElseIf caddtype = "Credit Card / Bank Statement" Then
            RadioButton4.Checked = True
        ElseIf caddtype = "Rent/Lease Agreement" Then
            RadioButton5.Checked = True
        Else
            RadioButton6.Checked = True
            TextBox4.Text = caddtype
        End If
        TextBox2.Text = ds3.Tables(0).Rows(0).Item(0)
        TextBox3.Text = ds3.Tables(0).Rows(0).Item(1)
        TextBox8.Text = ds3.Tables(0).Rows(0).Item(2)
        TextBox9.Text = ds3.Tables(0).Rows(0).Item(3)
        TextBox10.Text = ds3.Tables(0).Rows(0).Item(4)
        TextBox11.Text = ds3.Tables(0).Rows(0).Item(5)
        TextBox12.Text = ds3.Tables(0).Rows(0).Item(6)
        TextBox13.Text = ds3.Tables(0).Rows(0).Item(7)
        TextBox14.Text = ds3.Tables(0).Rows(0).Item(8)
        TextBox15.Text = ds3.Tables(0).Rows(0).Item(9)
        TextBox16.Text = ds3.Tables(0).Rows(0).Item(10)
        TextBox17.Text = ds3.Tables(0).Rows(0).Item(11)
        TextBox18.Text = ds3.Tables(0).Rows(0).Item(12)
        TextBox19.Text = ds3.Tables(0).Rows(0).Item(13)
        TextBox6.Text = ds3.Tables(0).Rows(0).Item(15)
    End Sub

    Private Sub Button3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If finalValidate() = 0 Then
            Exit Sub
        End If
        Dim ds As New DataSet
        Dim da As New OleDbDataAdapter
        Dim add_id As String
        If RadioButton1.Checked Then
            add_id = "Ration Card"
        ElseIf RadioButton2.Checked Then
            add_id = "Telephone Bill"
        ElseIf RadioButton3.Checked Then
            add_id = "Electricity Bill"
        ElseIf RadioButton4.Checked Then
            add_id = "Credit Card / Bank Statement"
        ElseIf RadioButton5.Checked Then
            add_id = "Rent/Lease Agreement"
        Else
            add_id = TextBox4.Text
        End If
        connection.Open()
        Dim cmd As New OleDbCommand("Update customer set ccontact='" & TextBox2.Text & "', cemail='" & TextBox3.Text & "', ctadd='" & TextBox8.Text & _
                                    "', ctcity='" & TextBox9.Text & "', ctstate='" & TextBox10.Text & "', ctzip='" & TextBox11.Text & "', cpadd='" & _
                                    TextBox12.Text & "', cpcity='" & TextBox13.Text & "', cpstate='" & TextBox14.Text & "', cpzip='" & TextBox15.Text & _
                                    "', cbadd='" & TextBox16.Text & "', cbcity='" & TextBox17.Text & "', cbstate='" & TextBox18.Text & "', cbzip='" & _
                                    TextBox19.Text & "', caddno='" & TextBox6.Text & "', caddtype='" & add_id & "' where cid=" & cid, connection)
        cmd.ExecuteNonQuery()
        connection.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox6.Clear()
        TextBox8.Clear()
        TextBox9.Clear()
        TextBox10.Clear()
        TextBox11.Clear()
        TextBox12.Clear()
        TextBox13.Clear()
        TextBox14.Clear()
        TextBox15.Clear()
        TextBox16.Clear()
        TextBox17.Clear()
        TextBox18.Clear()
        TextBox19.Clear()
        RadioButton1.Checked = False
        RadioButton2.Checked = False
        RadioButton3.Checked = False
        RadioButton4.Checked = False
        RadioButton5.Checked = False
        RadioButton6.Checked = False

    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        TextBox12.Text = TextBox8.Text
        TextBox13.Text = TextBox9.Text
        TextBox14.Text = TextBox10.Text
        TextBox15.Text = TextBox11.Text
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

    Private Sub TextBox6_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox6.KeyPress
        validationCheck(e.KeyChar, 4)
    End Sub

    Private Sub TextBox11_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox11.KeyPress
        validationCheck(e.KeyChar, 4)
    End Sub

    Private Sub TextBox15_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox15.KeyPress
        validationCheck(e.KeyChar, 4)
    End Sub

    Private Sub TextBox19_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox19.KeyPress
        validationCheck(e.KeyChar, 4)
    End Sub

    Private Sub TextBox9_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox9.KeyPress
        validationCheck(e.KeyChar, 1)
    End Sub

    Private Sub TextBox10_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox10.KeyPress
        validationCheck(e.KeyChar, 1)
    End Sub

    Private Sub TextBox13_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox13.KeyPress
        validationCheck(e.KeyChar, 1)
    End Sub

    Private Sub TextBox14_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox14.KeyPress
        validationCheck(e.KeyChar, 1)
    End Sub

    Private Sub TextBox17_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox17.KeyPress
        validationCheck(e.KeyChar, 1)
    End Sub

    Private Sub TextBox18_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox18.KeyPress
        validationCheck(e.KeyChar, 1)
    End Sub

    Private Sub TextBox4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox4.KeyPress
        validationCheck(e.KeyChar, 2)
    End Sub
    Private Function finalValidate() As Integer
        If TextBox1.Text.Trim = "" Or _
        TextBox2.Text.Trim = "" Or _
        TextBox3.Text.Trim = "" Or _
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
        TextBox6.Text.Trim = "" Or _
        (RadioButton6.Checked And TextBox4.Text.Trim = "") Or _
        (Not RadioButton1.Checked And Not RadioButton2.Checked And Not RadioButton3.Checked And Not RadioButton4.Checked And Not RadioButton5.Checked And Not RadioButton6.Checked) Or _
        (Not TextBox3.Text.Contains("@") Or TextBox3.Text.Contains(".")) Then
            MsgBox("Please Enter all the values Correctly", MsgBoxStyle.Exclamation, "Invalid Entry")
            Return 0
        Else
            Return 1

        End If
    End Function
End Class