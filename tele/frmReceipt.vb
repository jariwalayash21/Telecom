Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.OleDb

Public Class frmReceipt
    Dim ds As New DataSet
    Dim conn As New OleDbConnection("Provider=Microsoft.Ace.Oledb.12.0;Data Source=D:\tele\tele\telecom.accdb")

    Private Sub frmReceipt_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim cryRpt As New ReportDocument
        cryRpt.Load("D:\tele\tele\newcustreceipt.rpt")
        CrystalReportViewer1.ReportSource = cryRpt
        CrystalReportViewer1.Refresh()

        conn.Open()
        Dim sql = New OleDbDataAdapter("select * from receipt where rcnt=(select max(rcnt) from receipt)", conn)
        sql.Fill(ds)
        conn.Close()
        Dim objRpt As New newcustreceipt
        objRpt.SetDataSource(ds.Tables(0))
        CrystalReportViewer1.ReportSource = objRpt
        CrystalReportViewer1.Refresh()
    End Sub
End Class