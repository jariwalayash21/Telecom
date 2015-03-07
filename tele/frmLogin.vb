Imports System.Data.OleDb
Public Class frmLogin
    Dim con As New OleDbConnection("provider=Microsoft.ACE.OLEDB.12.0;data source=D:/tele/tele/telecom.accdb")
    Dim ds As New DataSet
    Dim ds2 As New DataSet
    Dim da As New OleDbDataAdapter
    Dim sql As String
    Dim staff(10) As String
    Dim admin(5) As String


    Private Sub frmLogin_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Button1.Image = Label10.Image
        Dim i As Integer
        TextBox1.Clear()
        ComboBox1.SelectedIndex = 1
        ComboBox2.Text = "     "
        sql = "Select id from login where utype='admin'"
        da = New OleDbDataAdapter(sql, con)
        da.Fill(ds)
        For i = 0 To ds.Tables(0).Rows.Count - 1
            admin(i) = ds.Tables(0).Rows(i).Item(0).ToString
        Next
        sql = "Select id from login where utype='staff'"
        da = New OleDbDataAdapter(sql, con)
        ds.Clear()
        da.Fill(ds)
        For i = 0 To ds.Tables(0).Rows.Count - 1
            staff(i) = ds.Tables(0).Rows(i).Item(0).ToString
        Next
        Try
            ComboBox2.Items.AddRange(staff)
        Catch ex As Exception
        End Try
        ComboBox1.Focus()
        Dim checkDa As New OleDbDataAdapter("Select * from bill_status_update", con)
        Dim checkDs As New DataSet
        checkDa.Fill(checkDs)
        If checkDs.Tables(0).Rows(0).Item(0).ToString.Substring(3, 3) <> Date.Today.Date.ToString("dd-MMM-yyyy").Substring(3, 3) Then
            con.Open()
            Dim setBillStatusAsUnpaid = New OleDbCommand("Update cust_conn set billstatus='Unpaid'", con)
            setBillStatusAsUnpaid.ExecuteNonQuery()
            Dim checkCmd As New OleDbCommand("Update bill_status_update set last_updated='" & Date.Today.Date.ToString("dd-MMM-yyyy") & "' where last_updated='" & checkDs.Tables(0).Rows(0).Item(0) & "'", con)
            checkCmd.ExecuteNonQuery()
            con.Close()
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If finalValidate() = 0 Then
            Exit Sub
        End If
        Dim da2 As New OleDbDataAdapter
        Dim ds3 As New DataSet
        Dim cmd As OleDbCommand
        sql = "select pass,utype,ustatus from login where id='" & ComboBox2.SelectedItem & "'"
        da = New OleDbDataAdapter(sql, con)
        ds2.Clear()
        da.Fill(ds2)
        If ds2.Tables(0).Rows(0).Item(2) = "Inactive" Then
            MsgBox("The account is de-activated. Please Contact the Administrator", MsgBoxStyle.Exclamation, "Invalid User")
            Exit Sub
        End If
        If ds2.Tables(0).Rows(0).Item(0) = TextBox1.Text Then
            con.Open()
            cmd = New OleDbCommand("Insert into sys_log Values('" & ComboBox2.Text & "','" & Date.Today.ToString("dd-MMM-yyyy") & "','" & TimeOfDay & "');", con)
            cmd.ExecuteReader()
            cmd = New OleDbCommand("Update login set last_login='" & Date.Today.ToString("dd-MMM-yyyy") & " " & TimeOfDay & "' where id='" & ComboBox2.Text & "';", con)
            cmd.ExecuteNonQuery()
            con.Close()
            If ds2.Tables(0).Rows(0).Item(1) = "Admin" Then
                Me.Hide()
                frmadmin.Show(ComboBox2.SelectedItem)
                ComboBox1.SelectedIndex = 1
                ComboBox2.SelectedIndex = -1
                TextBox1.Clear()

            Else
                frmstaff.Show(ComboBox2.SelectedItem)
                ComboBox1.SelectedIndex = 1
                ComboBox2.SelectedIndex = -1
                TextBox1.Clear()
                Me.Hide()
            End If
        Else
            MsgBox("Incorrect Password", MsgBoxStyle.Critical, "Error")
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Try
            ComboBox2.Items.Clear()
            ComboBox2.Text = ""
            If ComboBox1.SelectedIndex = 0 Then
                ComboBox2.Items.AddRange(admin)
            Else
                ComboBox2.Items.AddRange(staff)
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        End
    End Sub

    Private Function finalValidate() As Integer
        If ComboBox1.SelectedIndex = -1 Then
            MsgBox("Please select a user type", MsgBoxStyle.Critical, "Invalid Password")
            Return 0
        End If
        If ComboBox2.SelectedIndex = -1 Then
            MsgBox("Please select a user", MsgBoxStyle.Critical, "Invalid Password")
            Return 0
        End If
        If TextBox1.Text = "" Then
            MsgBox("Please enter a password", MsgBoxStyle.Critical, "Invalid Password")
            Return 0
        End If
        Return 1
    End Function
End Class