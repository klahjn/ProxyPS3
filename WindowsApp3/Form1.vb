Imports System.ComponentModel
Imports System.Net
Imports System.IO
Public Class Form1
    Dim Bastard As String = "\resources\ps3proxy.exe"
    Public myProcess As Process
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label1.Text = localipp() + ":8080"
        Button2.Enabled = False
        Dim monkey As String = Application.StartupPath + "\resources\ps3-updatelist.txt"
        Dim banana As String = My.Settings.SVR_RESPONSE
        If File.Exists(monkey) Then
            Exit Sub
        Else
            Dim file As StreamWriter
            file = My.Computer.FileSystem.OpenTextFileWriter(monkey, False)
            file.WriteLine(banana)
            file.Close()
        End If
    End Sub
    Function Localip()
        Dim hostname As String = Dns.GetHostName()
        Dim iPAddress1 As IPAddress = CType(Dns.GetHostEntry(hostname).AddressList.GetValue(0), IPAddress)
        Dim ipaddress As String = iPAddress1.ToString
        Return ipaddress
    End Function
    Function localipp() As String
        Dim tmpHostName As String = Dns.GetHostName()
        Return Dns.GetHostByName(tmpHostName).AddressList(0).ToString()
    End Function
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        myProcess = Process.Start(Application.StartupPath + Bastard$)
        Label1.Text = "Starting Proxy..."
        Label1.Text = localipp() + ":8080"
        Button2.Enabled = True
        Button1.Enabled = False
        Label3.Text = "Running."
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Label1.Text = "Stopping Proxy..."
        If myProcess.HasExited = False Then myProcess.Kill()
        Label1.Text = localipp() + ":8080"
        Button1.Enabled = True
        Button2.Enabled = False
        Label3.Text = "Stopped"
    End Sub
    Private Sub Form1_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        On Error Resume Next
        If myProcess.HasExited Then Exit Sub
        myProcess.Kill()
    End Sub
    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        MsgBox("This GUI was designed by psykosis based on proxy work by mondul." + vbCrLf + "It is designed for one thing, to make the proxy situation Simple." + vbCrLf + "Please make sure you setup your proxy in network settings on your ps3." + vbCrLf + "The hosting address is: " + Localip() + " and port: 8080" + vbCrLf + "You can modify your your ps3-updatelist.txt by accessing: " + Application.StartupPath + "\resources\")
    End Sub
End Class
