Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.OleDb
Public Class frmShowCustReport

    Dim conn As New OleDbConnection("Provider=Microsoft.Ace.Oledb.12.0;Data Source=D:\tele\tele\telecom.accdb")

    Private Sub frmShowCustReport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim cryRpt As New ReportDocument
        cryRpt.Load("D:\tele\tele\custReport.rpt")
        CrystalReportViewer1.ReportSource = cryRpt
        CrystalReportViewer1.Refresh()
        Dim da2 As New OleDbDataAdapter("Select cid from customer order by cid", conn)
        Dim ds2 As New DataSet
        da2.Fill(ds2)
        For i As Integer = 0 To ds2.Tables(0).Rows.Count - 1
            ComboBox1.Items.Add(ds2.Tables(0).Rows(i).Item(0))
        Next
        ComboBox1.SelectedIndex = 0
    End Sub
    Private Sub setCust(ByVal cid As Integer)
        Dim ds As New DataSet
        conn.Open()
        Dim sql1 = New OleDbDataAdapter("select * from customer where cid=" & cid, conn)
        sql1.Fill(ds)
        PictureBox1.ImageLocation = ds.Tables(0).Rows(0).Item("cimage")
        conn.Close()
        Dim objRpt As New custReport
        objRpt.SetDataSource(ds.Tables(0))
        CrystalReportViewer1.ReportSource = objRpt
        CrystalReportViewer1.Refresh()

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        setCust(CInt(ComboBox1.SelectedItem))
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim da2 As New OleDbDataAdapter("Select cimage from customer where cid=" & ComboBox1.SelectedItem, conn)
        Dim ds2 As New DataSet
        da2.Fill(ds2)

        System.Diagnostics.Process.Start(ds2.Tables(0).Rows(0).Item(0))




    End Sub
End Class