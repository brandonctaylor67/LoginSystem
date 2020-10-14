Imports System.Net
Imports System.IO
Imports System.Management
Public Class Register
    Dim Error404
    Dim Info As String
    Dim hostName As String = "localhost"
    Private Sub Register_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Interval = 500 '3 seconds
        Timer1.Enabled = True
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        CheckServer()
    End Sub
    Function CheckServer()
        Try
            Dim address As String = "http://" + hostName + "/online.html"
            Dim client As WebClient = New WebClient()
            Dim reply As String = client.DownloadString(address)
            If reply = "Online" Then
                FlatLabel6.Show()
                FlatLabel5.Hide()
                Error404 = False
            Else
                FlatLabel5.Hide()
                FlatLabel6.Show()
            End If
            Return address
        Catch ex As Exception
            FlatLabel6.Hide()
            FlatLabel5.Show()
            Return Error404 = True
        End Try
    End Function
    Function GetID()
        Dim mc As New ManagementClass("win32_processor")
        Dim moc As ManagementObjectCollection = mc.GetInstances
        For Each mo As ManagementObject In moc
            If Info = "" Then
                Info = mo.Properties("processorID").Value.ToString
                Exit For
            End If
        Next
        Return Info
    End Function

    Private Sub FlatButton1_Click(sender As Object, e As EventArgs) Handles FlatButton1.Click
        Me.Hide()
        Login.Show()
    End Sub
    Private Sub FlatButton2_Click(sender As Object, e As EventArgs) Handles FlatButton2.Click
        If FlatTextBox1.Text = "" Or FlatTextBox2.Text = "" Then
            MsgBox("You must enter something!")
        Else
            Try
                Dim address As String = "http://" + hostName + "/licenseusers/" + FlatTextBox1.Text + ".html"
                Dim client As WebClient = New WebClient()
                Dim reply As String = client.DownloadString(address)
                If reply = Info Then
                    MsgBox("Account Taken")
                ElseIf reply = "Banned" Then
                    MsgBox("Account Taken")
                ElseIf reply = "Wait" Then
                    MsgBox("Account Taken")
                Else
                    MsgBox("Unknown Error")
                End If
            Catch ex As Exception

            End Try
        End If
    End Sub
End Class