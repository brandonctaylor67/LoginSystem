Imports System.Net
Imports System.IO
Imports System.Management
Public Class Web
    Dim Info1 As String
    Dim hostname As String = "localhost"
    Dim Url As String = "http://" + hostname + "/licenseusers/registerid.php?id=" + Login.GetID + "&user=" + Login.FlatTextBox1.Text
    Private Sub Web_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetID1()
        Me.Visible = False
        Me.Hide()
        Me.Refresh()
        WebBrowser1.Url = New Uri(Url)
    End Sub
    Function GetID1()
        Dim mc As New ManagementClass("win32_processor")
        Dim moc As ManagementObjectCollection = mc.GetInstances
        For Each mo As ManagementObject In moc
            If Info1 = "" Then
                Info1 = mo.Properties("processorID").Value.ToString
                Exit For
            End If
        Next
        Return Info1
    End Function

    Function UpdateInfo()
        Url = "http://" + hostname + "/licenseusers/registerid.php?id=" + Login.GetID + "&user=" + Login.FlatTextBox1.Text
        WebBrowser1.Url = New Uri(Url)
        WebBrowser1.Refresh()
        Return Url
    End Function
End Class