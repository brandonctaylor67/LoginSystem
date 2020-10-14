Imports System.Net
Imports System.IO
Imports System.Management
Public Class Login
    Dim Info As String
    Dim hostName As String = "localhost"
    Dim Error404 As String
    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
                FlatLabel4.Show()
                FlatLabel5.Hide()
                Error404 = False
            Else
                FlatLabel4.Hide()
                FlatLabel5.Show()
            End If
            Return address
        Catch ex As Exception
            FlatLabel4.Hide()
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
        If FlatTextBox1.Text = "" Then
            MsgBox("You must enter something!")
        Else
Retry1:     Try
                Dim address As String = "http://" + hostName + "/licenseusers/" + FlatTextBox1.Text + ".html"
                Dim client As WebClient = New WebClient()
                Dim reply As String = client.DownloadString(address)
                If reply = Info Then
                    MsgBox("Account Found!")
                ElseIf reply = "Banned" Then
                    MsgBox("You Are Banned!")
                ElseIf reply = "Wait" Then
                    Web.Show()
                    Web.UpdateInfo()
                    GoTo Retry1
                ElseIf reply IsNot Info Then
                    MsgBox("You have the wrong ID")
                End If
            Catch ex As Exception
                If Error404 = True Then
                    MsgBox("The Server Is Offline.")
                Else
                    MsgBox("No User Found.")
                End If
            End Try
        End If
    End Sub

    Private Sub FlatButton2_Click(sender As Object, e As EventArgs) Handles FlatButton2.Click
        Me.Hide()
        Register.Show()
    End Sub
End Class