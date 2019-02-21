Imports System.ComponentModel
Imports System.Net
Imports System.IO
Public Class Form1
    Dim var1 As String = "\resources\ps3proxy.exe"
    Dim var2 As String = Application.StartupPath + "\resources\ps3-updatelist.txt"
    Dim var3 As String = My.Settings.SVR_RESPONSE
    Public myProcess As Process
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ToolTip1.SetToolTip(Label2, "PS3 Proxy " + Application.ProductVersion + vbCrLf + vbCrLf + "This GUI was designed by psykosis based on proxy work by mondul." + vbCrLf + "It is designed for one thing, to be Simple." + vbCrLf + "Please make sure you setup your proxy in network settings on your ps3." + vbCrLf + vbCrLf + vbCrLf + "The hosting address is: " + localipp() + " and port: 8080" + vbCrLf + vbCrLf + "You can modify your your ps3-updatelist.txt by accessing: " + Application.StartupPath + "\resources\" + vbCrLf + vbCrLf + "Special thanks to:  pink1")
        Label1.Text = localipp() + ":8080"
        Me.Text = Me.Text + " " + Application.ProductVersion.ToString + " [BETA]"
        If File.Exists(var2) = False Then
            Dim file As StreamWriter = My.Computer.FileSystem.OpenTextFileWriter(var2, False)
            file.WriteLine(var3)
            file.Close()
        End If
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
    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        Dim FILE_NAME As String = Application.StartupPath + "\resources\ps3-updatelist.txt" '"C:\FileName.txt"
        If File.Exists(FILE_NAME) = True Then
            Process.Start(FILE_NAME)
        Else
            MsgBox("File Does Not Exist")
        End If
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
End Class
