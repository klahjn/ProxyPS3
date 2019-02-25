Imports System.ComponentModel
Imports System.Net
Public Class Form1
    Dim var1 As String = "\resources\ps3proxy.exe"
    Dim var2 As String = "\resources\ps3help.pdf"
    Dim var3 As String = "netsh advfirewall firewall add rule name=""Open Port 8080"" dir=in action=allow protocol=TCP localport=8080"
    Public myProcess As Process
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'My.Settings.FirstRun = 0
        If My.Settings.FirstRun = "0" Then
            MsgBox("Since this is your first time running this application, we need to open a port on your firewall.  Please click yes to the administrator prompt that follows.", vbOKOnly, "PS3 Proxy")
            firewallrule()
            My.Settings.FirstRun = "1"
            My.Settings.Save()
        End If
        ToolTip1.SetToolTip(Label2, "PS3 Proxy " + Application.ProductVersion + vbCrLf + vbCrLf + "This GUI was designed by psykosis." + vbCrLf + "It is designed for one thing, to be Simple." + vbCrLf + "Please make sure you setup your proxy in network settings on your ps3." + vbCrLf + vbCrLf + "The hosting address is: " + localipp() + " and port: 8080" + vbCrLf + vbCrLf + "Special thanks to:  mondul, pink1, Cypher_CG89")
        Label1.Text = localipp() + ":8080"
        Me.Text = Me.Text + " " + Application.ProductVersion.ToString
        Me.Width = 260
    End Sub
    Private Sub firewallrule()
        Dim psi As New ProcessStartInfo()
        psi.Verb = "runas"
        psi.WindowStyle = ProcessWindowStyle.Hidden
        psi.FileName = "cmd.exe"
        psi.Arguments = " /c " + var3
        Try
            Process.Start(psi)
        Catch
            MsgBox("You have cancelled the firewall rule installation.  The program may not operate properly unless you disable your firewall.", 16, "PS3 Proxy")
        End Try
        MsgBox("The firewall rule has been installed.  This has opened port 8080 on your firewall so that this proxy will work properly.", vbOKOnly, "PS3 Proxy")
    End Sub
    Function localipp() As String
        Dim tmpHostName As String = Dns.GetHostName()
        Return Dns.GetHostByName(tmpHostName).AddressList(0).ToString()
    End Function
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        myProcess = Process.Start(Application.StartupPath + var1)
        Label1.Text = localipp() + ":8080" : Label3.Text = "Running."
        Button2.Enabled = True : Button1.Enabled = False
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If myProcess.HasExited = False Then myProcess.Kill()
        Label1.Text = localipp() + ":8080" : Label3.Text = "Stopped"
        Button1.Enabled = True : Button2.Enabled = False
    End Sub
    Private Sub Form1_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        On Error Resume Next
        NotifyIcon1.Dispose()
        If myProcess.HasExited Then Exit Sub
        myProcess.Kill()
    End Sub
    Private Sub NotifyIcon1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick
        Me.Show() : Me.WindowState = FormWindowState.Normal
    End Sub
    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If Me.WindowState = FormWindowState.Minimized Then
            Me.Visible = False
            Me.NotifyIcon1.Visible = True
        Else
            Me.NotifyIcon1.Visible = False
        End If
    End Sub
    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        Process.Start(Application.StartupPath + var2)
    End Sub
End Class
