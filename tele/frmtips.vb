Public Class frmtips

    Private Sub TreeView1_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView1.AfterSelect
        If e.Node.Text = "Staff" Then
            Panel1.Visible = True
            Panel2.Visible = False
            Panel3.Visible = False
            Panel4.Visible = False
            Panel6.Visible = False
            Panel5.Visible = False
            Panel7.Visible = False
        ElseIf e.Node.Text = "Connection" Then
            Panel2.Visible = True
            Panel1.Visible = False
            Panel3.Visible = False
            Panel4.Visible = False
            Panel6.Visible = False
            Panel5.Visible = False
            Panel7.Visible = False
        ElseIf e.Node.Text = "Edit" Then
            Panel2.Visible = False
            Panel1.Visible = False
            Panel3.Visible = True
            Panel4.Visible = False
            Panel6.Visible = False
            Panel5.Visible = False
            Panel7.Visible = False
        ElseIf e.Node.Text = "Payments" Then
            Panel2.Visible = False
            Panel1.Visible = False
            Panel3.Visible = False
            Panel4.Visible = True
            Panel6.Visible = False
            Panel5.Visible = False
            Panel7.Visible = False
        ElseIf e.Node.Text = "Support" Then
            Panel2.Visible = False
            Panel1.Visible = False
            Panel3.Visible = False
            Panel4.Visible = False
            Panel6.Visible = True
            Panel5.Visible = False
            Panel7.Visible = False
        ElseIf e.Node.Text = "Manage Account" Then
            Panel2.Visible = False
            Panel1.Visible = False
            Panel3.Visible = False
            Panel4.Visible = False
            Panel6.Visible = False
            Panel5.Visible = True
            Panel7.Visible = False
        ElseIf e.Node.Text = "Help" Then
            Panel2.Visible = False
            Panel1.Visible = False
            Panel3.Visible = False
            Panel4.Visible = False
            Panel6.Visible = False
            Panel5.Visible = False
            Panel7.Visible = True
        End If
    End Sub

    Private Sub frmtips_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TreeView1.ExpandAll()
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        'frmsysinfo.Show()
        System.Diagnostics.Process.Start("msinfo32.exe")
    End Sub
End Class