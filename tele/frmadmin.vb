Imports CrystalDecisions.CrystalReports.Engine
Public Class frmadmin
    Public curr_user As String
    Public sl As Integer = 0
    Public Overloads Sub Show(ByVal str As String)
        ToolStripStatusLabel1.Text = "Welcome User: " & str
        ToolStripStatusLabel2.Text = "Date: " & Date.Today.ToString("dd-MMM-yyyy")
        curr_user = str
        MyBase.Show()
    End Sub

    Private Sub AddNewToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddNewToolStripMenuItem.Click
        'setPos(frmnewuser)
        CenterInParent(frmnewuser)
        frmnewuser.Show()
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        'setPos(frmnewplan)
        CenterInParent(frmnewplan)
        frmnewplan.Show()
    End Sub

    Private Sub LogOotToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogOotToolStripMenuItem.Click
        frmLogin.Show()
        sl = 1
        Me.Close()
    End Sub

    Private Sub ViewLogsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewLogsToolStripMenuItem.Click
        'setPos(frmshowcomplaint)
        CenterInParent(frmshowcomplaint)
        frmshowcomplaint.Show()
    End Sub

    Private Sub GuestEntriesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GuestEntriesToolStripMenuItem.Click
        'setPos(frmshowguest)
        CenterInParent(frmshowguest)
        frmshowguest.Show()
    End Sub

    Private Sub ViewStaffLogsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewStaffLogsToolStripMenuItem.Click
        'setPos(frmshowsys_logs)
        CenterInParent(frmshowsys_logs)
        frmshowsys_logs.Show()
    End Sub

    Private Sub GeneralTipsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GeneralTipsToolStripMenuItem.Click
        CenterInParent(frmadmintips)
        'setPos(frmadmintips)
        frmadmintips.Show()
    End Sub

    Private Sub CustomerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomerToolStripMenuItem.Click
        frmShowCustReport.Show()
    End Sub

    Private Sub frmadmin_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If sl = 0 Then
            End
        End If
    End Sub
    '  Private Sub setPos(ByRef frm As Object)
    '  Me.Top = 0
    '  Me.Left = 0
    'End Sub

    Sub CenterInParent(ByRef frm As Object)
        frm.Left = Higher((Me.ClientSize.Width - frm.Width) / 2, 0)
        frm.Top = Higher((Me.ClientSize.Height - frm.Height) / 2, 0)
    End Sub

    Function Higher(ByRef x, ByRef y)
        Higher = IIf(x, x, y)
    End Function

    Private Sub GuestsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GuestsToolStripMenuItem.Click
        frmguestreport.Show()
    End Sub

    Private Sub LogOffToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub LandlineToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LandlineToolStripMenuItem.Click
       
        frmcust_connreport.Show(1)
    End Sub

    Private Sub BillStautsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BillStautsToolStripMenuItem.Click
        frmshowstausrpt.Show()
    End Sub

    Private Sub TerminatedConnectionsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TerminatedConnectionsToolStripMenuItem.Click
        frmsearchold.Show()
    End Sub

    Private Sub ComplaintsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComplaintsToolStripMenuItem.Click
        frmcomplaintreport.Show()
    End Sub

    Private Sub PrepaidToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrepaidToolStripMenuItem.Click
        frmcust_connreport.Show(2)
    End Sub

    Private Sub PostpaidToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PostpaidToolStripMenuItem.Click
        frmcust_connreport.Show(3)
    End Sub

    Private Sub BroadbandToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BroadbandToolStripMenuItem.Click
        frmcust_connreport.Show(4)
    End Sub

    Private Sub ShowAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowAllToolStripMenuItem.Click
        frmcust_connreport.Show()
    End Sub

    Private Sub AboutUsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutUsToolStripMenuItem.Click
        frmaboutus.Show()
    End Sub

    Private Sub BillToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BillToolStripMenuItem.Click
        CenterInParent(frmBillMail)
        frmBillMail.Show()
    End Sub
End Class