Public Class frmstaff
    Public curr_user As String
    Public sl As Integer = 0
    Public Overloads Sub Show(ByVal str As String)
        ToolStripStatusLabel1.Text = "Welcome User: " & str
        ToolStripStatusLabel2.Text = "Date: " & Date.Today.ToString("dd-MMM-yyyy")
        curr_user = str
        MyBase.Show()
    End Sub
    Private Sub AddNewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddNewToolStripMenuItem.Click
        'CenterInParent(frmnewcust)
        frmnewcust.Left = 0
        frmnewcust.Top = 0
        frmnewcust.Show()
    End Sub

    Private Sub TerminateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TerminateToolStripMenuItem.Click
        CenterInParent(frmtermination)
        frmtermination.Top = 0
        frmtermination.Show()
    End Sub

    Private Sub TransferConnectionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TransferConnectionToolStripMenuItem.Click
        CenterInParent(frmtransfer)
        frmtransfer.Show()
    End Sub

    Private Sub ChangePasswordToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangePasswordToolStripMenuItem.Click
        frmchangepass.Show()
    End Sub

    Private Sub RegisterComplaintsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RegisterComplaintsToolStripMenuItem.Click
        frmregistercomplaint.Show()
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        frmaddnewconn.Show()
    End Sub

    Private Sub LogOffToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogOffToolStripMenuItem.Click
        frmLogin.Show()
        sl = 1
        Me.Close()
    End Sub

    Private Sub ChangeBillingPlanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangeBillingPlanToolStripMenuItem.Click
        frmchangeplan.Show()
    End Sub

    Private Sub GeneralTipsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GeneralTipsToolStripMenuItem.Click
        frmtips.Show()
    End Sub

    Private Sub AboutUsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutUsToolStripMenuItem.Click
        frmaboutus.Show()
    End Sub

    Private Sub SearchToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchToolStripMenuItem.Click
        frmsearch.Show()
    End Sub

    Private Sub BillPaymentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BillPaymentToolStripMenuItem.Click
        frmbillpayment.Show()

    End Sub

    Private Sub frmstaff_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If sl = 0 Then
            End
        End If

    End Sub
    Private Sub GuestEntryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GuestEntryToolStripMenuItem.Click
        frmguestentry.Show()
    End Sub

    Private Sub BillsLogToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BillsLogToolStripMenuItem.Click
        frmbilllogs.Show()
    End Sub
    Sub CenterInParent(ByRef frm As Object)
        frm.Left = Higher((Me.ClientSize.Width - frm.Width) / 2, 0)
        frm.Top = Higher((Me.ClientSize.Height - frm.Height) / 2, 0)
    End Sub

    Function Higher(ByRef x, ByRef y)
        Higher = IIf(x, x, y)
    End Function

End Class