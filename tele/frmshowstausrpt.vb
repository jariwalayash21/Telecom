Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.OleDb
Public Class frmshowstausrpt

    Private Sub frmshowstausrpt_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        showall()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim ds As New DataSet
        Dim cnn As New OleDbConnection("Provider=Microsoft.Ace.Oledb.12.0;Data Source=D:\tele\tele\telecom.accdb")

        Dim sql As String

        cnn.Open()
        sql = " SELECT `cust_conn`.`cnum`, `cust_conn`.`ctype`, `cust_conn`.`billstatus`, `customer`.`cid`, `customer`.`cfname`, `customer`.`cmname`, `customer`.`clname` FROM   `cust_conn` `cust_conn` INNER JOIN `customer` `customer` ON `cust_conn`.`cid`=`customer`.`cid` where billstatus='Paid' and ctype<>'Prepaid'"


        Dim dscmd As New OleDbDataAdapter(sql, cnn)

        dscmd.Fill(ds)
        cnn.Close()

        Dim objRpt As New CrystalReport2
        objRpt.SetDataSource(ds.Tables(0))
        CrystalReportViewer1.ReportSource = objRpt
        CrystalReportViewer1.Refresh()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim ds As New DataSet
        Dim cnn As New OleDbConnection("Provider=Microsoft.Ace.Oledb.12.0;Data Source=D:\tele\tele\telecom.accdb")

        Dim sql As String

        cnn.Open()
        sql = " SELECT `cust_conn`.`cnum`, `cust_conn`.`ctype`, `cust_conn`.`billstatus`, `customer`.`cid`, `customer`.`cfname`, `customer`.`cmname`, `customer`.`clname` FROM   `cust_conn` `cust_conn` INNER JOIN `customer` `customer` ON `cust_conn`.`cid`=`customer`.`cid` where billstatus='Unpaid' and ctype<>'Prepaid'"
        Dim dscmd As New OleDbDataAdapter(sql, cnn)

        dscmd.Fill(ds)
        cnn.Close()

        Dim objRpt As New CrystalReport2
        objRpt.SetDataSource(ds.Tables(0))
        CrystalReportViewer1.ReportSource = objRpt
        CrystalReportViewer1.Refresh()
    End Sub

    Private Sub showAll()
        Dim cryRpt As New ReportDocument
        cryRpt.Load("D:\tele\tele\CrystalReport2.rpt")
        CrystalReportViewer1.ReportSource = cryRpt
        CrystalReportViewer1.Refresh()
        Dim ds As New DataSet
        Dim cnn As New OleDbConnection("Provider=Microsoft.Ace.Oledb.12.0;Data Source=D:\tele\tele\telecom.accdb")

        Dim sql As String

        cnn.Open()
        sql = " SELECT `cust_conn`.`cnum`, `cust_conn`.`ctype`, `cust_conn`.`billstatus`, `customer`.`cid`, `customer`.`cfname`, `customer`.`cmname`, `customer`.`clname` FROM   `cust_conn` `cust_conn` INNER JOIN `customer` `customer` ON `cust_conn`.`cid`=`customer`.`cid` where ctype<>'Prepaid'"
        Dim dscmd As New OleDbDataAdapter(sql, cnn)

        dscmd.Fill(ds)
        cnn.Close()

        Dim objRpt As New CrystalReport2
        objRpt.SetDataSource(ds.Tables(0))
        CrystalReportViewer1.ReportSource = objRpt
        CrystalReportViewer1.Refresh()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        showAll()
    End Sub
End Class