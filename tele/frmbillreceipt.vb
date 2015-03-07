Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.OleDb


Public Class frmbillreceipt
    Dim ds As New DataSet
    Dim conn As New OleDbConnection("Provider=Microsoft.Ace.Oledb.12.0;Data Source=D:\tele\tele\telecom.accdb")
    Dim billno As Integer

    Public Overloads Sub Show(ByVal b As Integer)
        billno = b
        MyBase.Show()

    End Sub
    Private Sub frmReceipt_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim cryRpt As New ReportDocument
        cryRpt.Load("D:\tele\tele\billreceipt.rpt")
        CrystalReportViewer1.ReportSource = cryRpt
        CrystalReportViewer1.Refresh()

        conn.Open()
        Dim sql = New OleDbDataAdapter("select * from bill where billno=" & billno, conn)
        sql.Fill(ds)
        conn.Close()
        Dim objRpt As New billreceipt
        objRpt.SetDataSource(ds.Tables(0))
        CrystalReportViewer1.ReportSource = objRpt
        CrystalReportViewer1.Refresh()
    End Sub
End Class