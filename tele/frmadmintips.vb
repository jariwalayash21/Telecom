Public Class frmadmintips
    Private Sub TreeView1_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView1.AfterSelect
        If e.Node.Text = "Administrator" Then
            Panel5.Visible = True
            Panel4.Visible = False
            Panel3.Visible = False
            Panel2.Visible = False
            Panel1.Visible = False
        ElseIf e.Node.Text = "Add/Edit" Then
            Panel4.Visible = True
            Panel5.Visible = False
            Panel3.Visible = False
            Panel2.Visible = False
            Panel1.Visible = False
        ElseIf e.Node.Text = "View" Then
            Panel3.Visible = True
            Panel5.Visible = False
            Panel4.Visible = False
            Panel2.Visible = False
            Panel1.Visible = False
        ElseIf e.Node.Text = "Users " Then
            Panel3.Visible = False
            Panel5.Visible = False
            Panel4.Visible = False
            Panel2.Visible = True
            Panel1.Visible = False
        ElseIf e.Node.Text = "Help" Then
            Panel3.Visible = False
            Panel5.Visible = False
            Panel4.Visible = False
            Panel2.Visible = False
            Panel1.Visible = True
        End If
    End Sub

    Private Sub frmadmintips_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = frmadmin
        TreeView1.ExpandAll()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked

        System.Diagnostics.Process.Start("msinfo32.exe")
    End Sub
End Class