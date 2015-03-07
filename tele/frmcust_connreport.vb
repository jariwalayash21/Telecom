Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.OleDb
Public Class frmcust_connreport
    Dim ds As New DataSet
    Dim cnn As New OleDbConnection("Provider=Microsoft.Ace.Oledb.12.0;Data Source=D:\tele\tele\telecom.accdb")
    Dim mode As Integer
    Public Overloads Sub Show(ByVal mode2 As Integer)
        mode = mode2
        MyBase.Show()
    End Sub

    Private Sub frmcust_connreport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim cryRpt As New ReportDocument
        cryRpt.Load("D:\tele\tele\CrystalReport5.rpt")
        CrystalReportViewer1.ReportSource = cryRpt
        CrystalReportViewer1.Refresh()
        If mode = 1 Then
            Dim sql As String
            cnn.Open()
            sql = " SELECT `cust_conn`.`cnum`, `cust_conn`.`ctype`, `cust_conn`.`plan`, `customer`.`cid`, `customer`.`cfname`, `customer`.`cmname`, `customer`.`clname`FROM   `cust_conn` `cust_conn` INNER JOIN `customer` `customer` ON `cust_conn`.`cid`=`customer`.`cid` where ctype='Landline'"
            Dim dscmd As New OleDbDataAdapter(sql, cnn)
            dscmd.Fill(ds)
            cnn.Close()
            Dim objRpt As New CrystalReport5
            objRpt.SetDataSource(ds.Tables(0))
            CrystalReportViewer1.ReportSource = objRpt
            CrystalReportViewer1.Refresh()
        ElseIf mode = 2 Then
            Dim sql As String
            cnn.Open()
            sql = " SELECT `cust_conn`.`cnum`, `cust_conn`.`ctype`, `cust_conn`.`plan`, `customer`.`cid`, `customer`.`cfname`, `customer`.`cmname`, `customer`.`clname`FROM   `cust_conn` `cust_conn` INNER JOIN `customer` `customer` ON `cust_conn`.`cid`=`customer`.`cid` where ctype='Prepaid'"
            Dim dscmd As New OleDbDataAdapter(sql, cnn)
            dscmd.Fill(ds)
            cnn.Close()
            Dim objRpt As New CrystalReport5
            objRpt.SetDataSource(ds.Tables(0))
            CrystalReportViewer1.ReportSource = objRpt
            CrystalReportViewer1.Refresh()
        ElseIf mode = 3 Then
            Dim sql As String
            cnn.Open()
            sql = " SELECT `cust_conn`.`cnum`, `cust_conn`.`ctype`, `cust_conn`.`plan`, `customer`.`cid`, `customer`.`cfname`, `customer`.`cmname`, `customer`.`clname`FROM   `cust_conn` `cust_conn` INNER JOIN `customer` `customer` ON `cust_conn`.`cid`=`customer`.`cid` where ctype='Postpaid'"
            Dim dscmd As New OleDbDataAdapter(sql, cnn)
            dscmd.Fill(ds)
            cnn.Close()
            Dim objRpt As New CrystalReport5
            objRpt.SetDataSource(ds.Tables(0))
            CrystalReportViewer1.ReportSource = objRpt
            CrystalReportViewer1.Refresh()
        ElseIf mode = 4 Then
            Dim sql As String
            cnn.Open()
            sql = " SELECT `cust_conn`.`cnum`, `cust_conn`.`ctype`, `cust_conn`.`plan`, `customer`.`cid`, `customer`.`cfname`, `customer`.`cmname`, `customer`.`clname`FROM   `cust_conn` `cust_conn` INNER JOIN `customer` `customer` ON `cust_conn`.`cid`=`customer`.`cid` where ctype='Broadband'"
            Dim dscmd As New OleDbDataAdapter(sql, cnn)
            dscmd.Fill(ds)
            cnn.Close()
            Dim objRpt As New CrystalReport5
            objRpt.SetDataSource(ds.Tables(0))
            CrystalReportViewer1.ReportSource = objRpt
            CrystalReportViewer1.Refresh()
        End If
    End Sub
End Class