Public Class Form2
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label1.Text = "TX->TX" & vbCrLf & "RX->RX" & vbCrLf & "GND->GND" & vbCrLf & "VCC->5V" & vbCrLf & "EN->3.3V"
        Label2.Text = "進到AT模式:先按著板子上的開關，" & vbCrLf & "再通電，" & vbCrLf & "即可讓此藍牙模組進入AT模式" & vbCrLf & "(通電之後，即可放開開關）。" & vbCrLf & "此時藍芽模組的燈會慢閃"
    End Sub
End Class