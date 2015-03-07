<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmstaff
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmstaff))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.ConnectionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AddNewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.TerminateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TransferConnectionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ChangeBillingPlanToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SearchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PaymentsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.BillPaymentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.BillsLogToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ManageAccountToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ChangePasswordToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.LogOffToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SupportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.RegisterComplaintsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.GuestEntryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
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
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ConnectionToolStripMenuItem, Me.EditToolStripMenuItem, Me.PaymentsToolStripMenuItem, Me.ManageAccountToolStripMenuItem, Me.SupportToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(962, 27)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ConnectionToolStripMenuItem
        '
        Me.ConnectionToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddNewToolStripMenuItem, Me.ToolStripMenuItem1, Me.TerminateToolStripMenuItem})
        Me.ConnectionToolStripMenuItem.Name = "ConnectionToolStripMenuItem"
        Me.ConnectionToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.ConnectionToolStripMenuItem.Size = New System.Drawing.Size(94, 23)
        Me.ConnectionToolStripMenuItem.Text = "&Connection"
        '
        'AddNewToolStripMenuItem
        '
        Me.AddNewToolStripMenuItem.Name = "AddNewToolStripMenuItem"
        Me.AddNewToolStripMenuItem.Size = New System.Drawing.Size(213, 24)
        Me.AddNewToolStripMenuItem.Text = "&Add New "
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(213, 24)
        Me.ToolStripMenuItem1.Text = "Add &New Connection"
        '
        'TerminateToolStripMenuItem
        '
        Me.TerminateToolStripMenuItem.Name = "TerminateToolStripMenuItem"
        Me.TerminateToolStripMenuItem.Size = New System.Drawing.Size(213, 24)
        Me.TerminateToolStripMenuItem.Text = "&Terminate"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TransferConnectionToolStripMenuItem, Me.ChangeBillingPlanToolStripMenuItem, Me.SearchToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(46, 23)
        Me.EditToolStripMenuItem.Text = "&Edit"
        '
        'TransferConnectionToolStripMenuItem
        '
        Me.TransferConnectionToolStripMenuItem.Name = "TransferConnectionToolStripMenuItem"
        Me.TransferConnectionToolStripMenuItem.Size = New System.Drawing.Size(208, 24)
        Me.TransferConnectionToolStripMenuItem.Text = "&Transfer Connection"
        '
        'ChangeBillingPlanToolStripMenuItem
        '
        Me.ChangeBillingPlanToolStripMenuItem.Name = "ChangeBillingPlanToolStripMenuItem"
        Me.ChangeBillingPlanToolStripMenuItem.Size = New System.Drawing.Size(208, 24)
        Me.ChangeBillingPlanToolStripMenuItem.Text = "&Change Billing Plan"
        '
        'SearchToolStripMenuItem
        '
        Me.SearchToolStripMenuItem.Name = "SearchToolStripMenuItem"
        Me.SearchToolStripMenuItem.Size = New System.Drawing.Size(208, 24)
        Me.SearchToolStripMenuItem.Text = "S&earch"
        '
        'PaymentsToolStripMenuItem
        '
        Me.PaymentsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BillPaymentToolStripMenuItem, Me.BillsLogToolStripMenuItem})
        Me.PaymentsToolStripMenuItem.Name = "PaymentsToolStripMenuItem"
        Me.PaymentsToolStripMenuItem.Size = New System.Drawing.Size(84, 23)
        Me.PaymentsToolStripMenuItem.Text = "&Payments"
        '
        'BillPaymentToolStripMenuItem
        '
        Me.BillPaymentToolStripMenuItem.Name = "BillPaymentToolStripMenuItem"
        Me.BillPaymentToolStripMenuItem.Size = New System.Drawing.Size(159, 24)
        Me.BillPaymentToolStripMenuItem.Text = "&Bill Payment"
        '
        'BillsLogToolStripMenuItem
        '
        Me.BillsLogToolStripMenuItem.Name = "BillsLogToolStripMenuItem"
        Me.BillsLogToolStripMenuItem.Size = New System.Drawing.Size(159, 24)
        Me.BillsLogToolStripMenuItem.Text = "Bills &Logs"
        '
        'ManageAccountToolStripMenuItem
        '
        Me.ManageAccountToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ChangePasswordToolStripMenuItem, Me.LogOffToolStripMenuItem})
        Me.ManageAccountToolStripMenuItem.Name = "ManageAccountToolStripMenuItem"
        Me.ManageAccountToolStripMenuItem.Size = New System.Drawing.Size(130, 23)
        Me.ManageAccountToolStripMenuItem.Text = "&Manage Account"
        '
        'ChangePasswordToolStripMenuItem
        '
        Me.ChangePasswordToolStripMenuItem.Name = "ChangePasswordToolStripMenuItem"
        Me.ChangePasswordToolStripMenuItem.Size = New System.Drawing.Size(193, 24)
        Me.ChangePasswordToolStripMenuItem.Text = "C&hange Password"
        '
        'LogOffToolStripMenuItem
        '
        Me.LogOffToolStripMenuItem.Name = "LogOffToolStripMenuItem"
        Me.LogOffToolStripMenuItem.Size = New System.Drawing.Size(193, 24)
        Me.LogOffToolStripMenuItem.Text = "&Log Off"
        '
        'SupportToolStripMenuItem
        '
        Me.SupportToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RegisterComplaintsToolStripMenuItem, Me.GuestEntryToolStripMenuItem})
        Me.SupportToolStripMenuItem.Name = "SupportToolStripMenuItem"
        Me.SupportToolStripMenuItem.Size = New System.Drawing.Size(70, 23)
        Me.SupportToolStripMenuItem.Text = "&Support"
        '
        'RegisterComplaintsToolStripMenuItem
        '
        Me.RegisterComplaintsToolStripMenuItem.Name = "RegisterComplaintsToolStripMenuItem"
        Me.RegisterComplaintsToolStripMenuItem.Size = New System.Drawing.Size(209, 24)
        Me.RegisterComplaintsToolStripMenuItem.Text = "&Register Complaints"
        '
        'GuestEntryToolStripMenuItem
        '
        Me.GuestEntryToolStripMenuItem.Name = "GuestEntryToolStripMenuItem"
        Me.GuestEntryToolStripMenuItem.Size = New System.Drawing.Size(209, 24)
        Me.GuestEntryToolStripMenuItem.Text = "&Guest Entry"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GeneralTipsToolStripMenuItem, Me.AboutUsToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(51, 23)
        Me.HelpToolStripMenuItem.Text = "&Help"
        '
        'GeneralTipsToolStripMenuItem
        '
        Me.GeneralTipsToolStripMenuItem.Name = "GeneralTipsToolStripMenuItem"
        Me.GeneralTipsToolStripMenuItem.Size = New System.Drawing.Size(160, 24)
        Me.GeneralTipsToolStripMenuItem.Text = "General &Tips"
        '
        'AboutUsToolStripMenuItem
        '
        Me.AboutUsToolStripMenuItem.Name = "AboutUsToolStripMenuItem"
        Me.AboutUsToolStripMenuItem.Size = New System.Drawing.Size(160, 24)
        Me.AboutUsToolStripMenuItem.Text = "About &Us"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 632)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(962, 25)
        Me.StatusStrip1.TabIndex = 2
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel1.ForeColor = System.Drawing.Color.Red
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(473, 20)
        Me.ToolStripStatusLabel1.Spring = True
        Me.ToolStripStatusLabel1.Text = "1"
        Me.ToolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel2.ForeColor = System.Drawing.Color.Red
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(473, 20)
        Me.ToolStripStatusLabel2.Spring = True
        Me.ToolStripStatusLabel2.Text = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmstaff
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(962, 657)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmstaff"
        Me.Text = "Staff"
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
    Friend WithEvents TerminateToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TransferConnectionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ChangeBillingPlanToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SearchToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PaymentsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BillPaymentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BillsLogToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ManageAccountToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ChangePasswordToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LogOffToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GeneralTipsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutUsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SupportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RegisterComplaintsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GuestEntryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
End Class
