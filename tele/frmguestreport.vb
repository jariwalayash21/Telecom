Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.OleDb

Public Class frmguestreport
    Private Sub frmguestreport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim cryRpt As New ReportDocument
        cryRpt.Load("D:\tele\tele\CrystalReport1.rpt")
        CrystalReportViewer1.ReportSource = cryRpt
        CrystalReportViewer1.Refresh()

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim ds As New DataSet
        Dim cnn As New OleDbConnection("Provider=Microsoft.Ace.Oledb.12.0;Data Source=D:\tele\tele\telecom.accdb")

        Dim sql As String

        cnn.Open()
        sql = "SELECT * from guest where offers = True"
        Dim dscmd As New OleDbDataAdapter(sql, cnn)

        dscmd.Fill(ds)
        cnn.Close()

        Dim objRpt As New CrystalReport1
        objRpt.SetDataSource(ds.Tables(0))
        CrystalReportViewer1.ReportSource = objRpt
        CrystalReportViewer1.Refresh()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim ds As New DataSet
        Dim cnn As New OleDbConnection("Provider=Microsoft.Ace.Oledb.12.0;Data Source=D:\tele\tele\telecom.accdb")

        Dim sql As String

        cnn.Open()
        sql = "SELECT * from guest where offers = False"
        Dim dscmd As New OleDbDataAdapter(sql, cnn)

        dscmd.Fill(ds)
        cnn.Close()

        Dim objRpt As New CrystalReport1
        objRpt.SetDataSource(ds.Tables(0))
        CrystalReportViewer1.ReportSource = objRpt
        CrystalReportViewer1.Refresh()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim ds As New DataSet
        Dim cnn As New OleDbConnection("Provider=Microsoft.Ace.Oledb.12.0;Data Source=D:\tele\tele\telecom.accdb")

        Dim sql As String

        cnn.Open()
        sql = "SELECT * from guest"
        Dim dscmd As New OleDbDataAdapter(sql, cnn)

        dscmd.Fill(ds)
        cnn.Close()

        Dim objRpt As New CrystalReport1
        objRpt.SetDataSource(ds.Tables(0))
        CrystalReportViewer1.ReportSource = objRpt
        CrystalReportViewer1.Refresh()
    End Sub
End Class