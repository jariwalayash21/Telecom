<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmadmin
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.ConnectionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AddNewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.ManageAccountToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ChangePasswordToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CustomerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ConnectionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.LandlineToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrepaidToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PostpaidToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.BroadbandToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ShowAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.GuestsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.BillStautsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ComplaintsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ViewLogsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.GuestEntriesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TerminatedConnectionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.BillToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ViewStaffLogsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.LogOotToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.GeneralTipsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AboutUsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ConnectionToolStripMenuItem, Me.ManageAccountToolStripMenuItem, Me.ExitToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1248, 27)
        Me.MenuStrip1.TabIndex = 3
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ConnectionToolStripMenuItem
        '
        Me.ConnectionToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddNewToolStripMenuItem, Me.ToolStripMenuItem1})
        Me.ConnectionToolStripMenuItem.Name = "ConnectionToolStripMenuItem"
        Me.ConnectionToolStripMenuItem.Size = New System.Drawing.Size(77, 23)
        Me.ConnectionToolStripMenuItem.Text = "Add/Edit"
        '
        'AddNewToolStripMenuItem
        '
        Me.AddNewToolStripMenuItem.Name = "AddNewToolStripMenuItem"
        Me.AddNewToolStripMenuItem.Size = New System.Drawing.Size(115, 24)
        Me.AddNewToolStripMenuItem.Text = "Users"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(115, 24)
        Me.ToolStripMenuItem1.Text = "Plans"
        '
        'ManageAccountToolStripMenuItem
        '
        Me.ManageAccountToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ChangePasswordToolStripMenuItem, Me.ViewLogsToolStripMenuItem, Me.GuestEntriesToolStripMenuItem, Me.TerminatedConnectionsToolStripMenuItem, Me.BillToolStripMenuItem})
        Me.ManageAccountToolStripMenuItem.Name = "ManageAccountToolStripMenuItem"
        Me.ManageAccountToolStripMenuItem.Size = New System.Drawing.Size(53, 23)
        Me.ManageAccountToolStripMenuItem.Text = "View"
        '
        'ChangePasswordToolStripMenuItem
        '
        Me.ChangePasswordToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CustomerToolStripMenuItem, Me.ConnectionsToolStripMenuItem, Me.GuestsToolStripMenuItem, Me.BillStautsToolStripMenuItem, Me.ComplaintsToolStripMenuItem})
        Me.ChangePasswordToolStripMenuItem.Name = "ChangePasswordToolStripMenuItem"
        Me.ChangePasswordToolStripMenuItem.Size = New System.Drawing.Size(235, 24)
        Me.ChangePasswordToolStripMenuItem.Text = "Reports"
        '
        'CustomerToolStripMenuItem
        '
        Me.CustomerToolStripMenuItem.Name = "CustomerToolStripMenuItem"
        Me.CustomerToolStripMenuItem.Size = New System.Drawing.Size(158, 24)
        Me.CustomerToolStripMenuItem.Text = "Customers"
        '
        'ConnectionsToolStripMenuItem
        '
        Me.ConnectionsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LandlineToolStripMenuItem, Me.PrepaidToolStripMenuItem, Me.PostpaidToolStripMenuItem, Me.BroadbandToolStripMenuItem, Me.ShowAllToolStripMenuItem})
        Me.ConnectionsToolStripMenuItem.Name = "ConnectionsToolStripMenuItem"
        Me.ConnectionsToolStripMenuItem.Size = New System.Drawing.Size(158, 24)
        Me.ConnectionsToolStripMenuItem.Text = "Connections"
        '
        'LandlineToolStripMenuItem
        '
        Me.LandlineToolStripMenuItem.Name = "LandlineToolStripMenuItem"
        Me.LandlineToolStripMenuItem.Size = New System.Drawing.Size(148, 24)
        Me.LandlineToolStripMenuItem.Text = "Landline"
        '
        'PrepaidToolStripMenuItem
        '
        Me.PrepaidToolStripMenuItem.Name = "PrepaidToolStripMenuItem"
        Me.PrepaidToolStripMenuItem.Size = New System.Drawing.Size(148, 24)
        Me.PrepaidToolStripMenuItem.Text = "Prepaid"
        '
        'PostpaidToolStripMenuItem
        '
        Me.PostpaidToolStripMenuItem.Name = "PostpaidToolStripMenuItem"
        Me.PostpaidToolStripMenuItem.Size = New System.Drawing.Size(148, 24)
        Me.PostpaidToolStripMenuItem.Text = "Postpaid"
        '
        'BroadbandToolStripMenuItem
        '
        Me.BroadbandToolStripMenuItem.Name = "BroadbandToolStripMenuItem"
        Me.BroadbandToolStripMenuItem.Size = New System.Drawing.Size(148, 24)
        Me.BroadbandToolStripMenuItem.Text = "Broadband"
        '
        'ShowAllToolStripMenuItem
        '
        Me.ShowAllToolStripMenuItem.Name = "ShowAllToolStripMenuItem"
        Me.ShowAllToolStripMenuItem.Size = New System.Drawing.Size(148, 24)
        Me.ShowAllToolStripMenuItem.Text = "Show all"
        '
        'GuestsToolStripMenuItem
        '
        Me.GuestsToolStripMenuItem.Name = "GuestsToolStripMenuItem"
        Me.GuestsToolStripMenuItem.Size = New System.Drawing.Size(158, 24)
        Me.GuestsToolStripMenuItem.Text = "Guests"
        '
        'BillStautsToolStripMenuItem
        '
        Me.BillStautsToolStripMenuItem.Name = "BillStautsToolStripMenuItem"
        Me.BillStautsToolStripMenuItem.Size = New System.Drawing.Size(158, 24)
        Me.BillStautsToolStripMenuItem.Text = "Bill Status"
        '
        'ComplaintsToolStripMenuItem
        '
        Me.ComplaintsToolStripMenuItem.Name = "ComplaintsToolStripMenuItem"
        Me.ComplaintsToolStripMenuItem.Size = New System.Drawing.Size(158, 24)
        Me.ComplaintsToolStripMenuItem.Text = "Complaints"
        '
        'ViewLogsToolStripMenuItem
        '
        Me.ViewLogsToolStripMenuItem.Name = "ViewLogsToolStripMenuItem"
        Me.ViewLogsToolStripMenuItem.Size = New System.Drawing.Size(235, 24)
        Me.ViewLogsToolStripMenuItem.Text = "Complaints"
        '
        'GuestEntriesToolStripMenuItem
        '
        Me.GuestEntriesToolStripMenuItem.Name = "GuestEntriesToolStripMenuItem"
        Me.GuestEntriesToolStripMenuItem.Size = New System.Drawing.Size(235, 24)
        Me.GuestEntriesToolStripMenuItem.Text = "Guest Entries"
        '
        'TerminatedConnectionsToolStripMenuItem
        '
        Me.TerminatedConnectionsToolStripMenuItem.Name = "TerminatedConnectionsToolStripMenuItem"
        Me.TerminatedConnectionsToolStripMenuItem.Size = New System.Drawing.Size(235, 24)
        Me.TerminatedConnectionsToolStripMenuItem.Text = "Terminated Connections"
        '
        'BillToolStripMenuItem
        '
        Me.BillToolStripMenuItem.Name = "BillToolStripMenuItem"
        Me.BillToolStripMenuItem.Size = New System.Drawing.Size(235, 24)
        Me.BillToolStripMenuItem.Text = "Unpaid Bills"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ViewStaffLogsToolStripMenuItem, Me.LogOotToolStripMenuItem})
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(51, 23)
        Me.ExitToolStripMenuItem.Text = "User"
        '
        'ViewStaffLogsToolStripMenuItem
        '
        Me.ViewStaffLogsToolStripMenuItem.Name = "ViewStaffLogsToolStripMenuItem"
        Me.ViewStaffLogsToolStripMenuItem.Size = New System.Drawing.Size(177, 24)
        Me.ViewStaffLogsToolStripMenuItem.Text = "View Staff Logs"
        '
        'LogOotToolStripMenuItem
        '
        Me.LogOotToolStripMenuItem.Name = "LogOotToolStripMenuItem"
        Me.LogOotToolStripMenuItem.Size = New System.Drawing.Size(177, 24)
        Me.LogOotToolStripMenuItem.Text = "Log Off"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GeneralTipsToolStripMenuItem, Me.AboutUsToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(51, 23)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'GeneralTipsToolStripMenuItem
        '
        Me.GeneralTipsToolStripMenuItem.Name = "GeneralTipsToolStripMenuItem"
        Me.GeneralTipsToolStripMenuItem.Size = New System.Drawing.Size(160, 24)
        Me.GeneralTipsToolStripMenuItem.Text = "General Tips"
        '
        'AboutUsToolStripMenuItem
        '
        Me.AboutUsToolStripMenuItem.Name = "AboutUsToolStripMenuItem"
        Me.AboutUsToolStripMenuItem.Size = New System.Drawing.Size(160, 24)
        Me.AboutUsToolStripMenuItem.Text = "About Us"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 660)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1248, 25)
        Me.StatusStrip1.TabIndex = 5
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel1.ForeColor = System.Drawing.Color.Red
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(616, 20)
        Me.ToolStripStatusLabel1.Spring = True
        Me.ToolStripStatusLabel1.Text = "1"
        Me.ToolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel2.ForeColor = System.Drawing.Color.Red
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(616, 20)
        Me.ToolStripStatusLabel2.Spring = True
        Me.ToolStripStatusLabel2.Text = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmadmin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.tele.My.Resources.Resources.background1
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1248, 685)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.IsMdiContainer = True
        Me.Name = "frmadmin"
        Me.Text = "Administrator"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ConnectionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddNewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ManageAccountToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ChangePasswordToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewLogsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GeneralTipsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutUsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LogOotToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewStaffLogsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GuestEntriesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CustomerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConnectionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GuestsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents LandlineToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrepaidToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PostpaidToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BroadbandToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BillStautsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TerminatedConnectionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ComplaintsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BillToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShowAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
