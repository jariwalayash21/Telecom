Imports CrystalDecisions.CrystalReports.Engine
Public Class frmcomplaintreport

    Private Sub frmcomplaintreport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim cryRpt As New ReportDocument
        cryRpt.Load("D:\tele\tele\CrystalReport4.rpt")
        CrystalReportViewer1.ReportSource = cryRpt
        CrystalReportViewer1.Refresh()

    End Sub
End Class