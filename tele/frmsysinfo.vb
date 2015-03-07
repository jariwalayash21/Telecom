Public Class frmsysinfo

    Private Sub frmsysinfo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox1.Text = System.Environment.MachineName
        TextBox2.Text = System.Environment.UserName
        TextBox3.Text = My.Computer.Info.OSFullName
        TextBox4.Text = My.Computer.Info.OSPlatform
        TextBox5.Text = My.Computer.Info.OSVersion
        TextBox5.Text = My.Computer.Info.OSVersion
        TextBox6.Text = My.Computer.Info.InstalledUICulture.ToString
    End Sub
End Class