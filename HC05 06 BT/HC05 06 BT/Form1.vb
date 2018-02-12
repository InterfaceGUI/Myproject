Public Class Form1
    Dim com As IO.Ports.SerialPort

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For i = 0 To com.GetPortNames().GetUpperBound(0)
            ComboBox1.Items.Add(com.GetPortNames(i))
        Next
        ComboBox1.SelectedIndex = com.GetPortNames().GetUpperBound(0)
        Button3.Enabled = False
        TextBox3.Enabled = False
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ComboBox1.Items.Clear()
        For i = 0 To com.GetPortNames().GetUpperBound(0)
            ComboBox1.Items.Add(com.GetPortNames(i))
        Next
        ComboBox1.SelectedIndex = com.GetPortNames().GetUpperBound(0)
    End Sub
    Dim comSelsct As IO.Ports.SerialPort = Nothing
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Button1.Text = "開啟通訊埠" Then
            Try
                comSelsct = My.Computer.Ports.OpenSerialPort(ComboBox1.SelectedItem, ComboBox2.SelectedItem)
                Button3.Enabled = True
                ComboBox1.Enabled = False
                ComboBox2.Enabled = False
            Catch ex As Exception
                MsgBox(ex.Message)
                Button1.Text = "開啟通訊埠"
                ComboBox1.Enabled = True
                ComboBox2.Enabled = True
                Exit Sub
                Try
                    comSelsct.Close()
                Catch eax As Exception
                End Try
            End Try
                Else
            comSelsct.Close()
            ComboBox1.Enabled = True
            ComboBox2.Enabled = True
        End If
        Button1.Text = IIf(Button1.Text = "開啟通訊埠", "關閉通訊埠", "開啟通訊埠")
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If RadioButton3.Checked Or RadioButton4.Checked Then
            Dim PIN As Int16 = Val(TextBox2.Text)
            comSelsct.Write("AT")
            comSelsct.Write(vbCrLf)
            comSelsct.ReadTimeout = 2000
            Try
                Do
                    Dim Incoming As String = comSelsct.ReadLine()

                    If Incoming Is Nothing Then

                    Else
                        If Mid(Incoming, 1, 2) = "OK" Then
                            Exit Do
                        End If
                    End If
                Loop
                If RadioButton3.Checked Then
                    comSelsct.Write("AT+NAME:" & TextBox1.Text)
                Else
                    comSelsct.Write("AT+NAME" & TextBox1.Text)
                End If
                comSelsct.Write(vbCrLf)
                Do
                    Dim Incoming As String = comSelsct.ReadLine()

                    If Incoming Is Nothing Then
                        Exit Do
                    Else
                        If Mid(Incoming, 1, 9) = "OKsetname" Or Mid(Incoming, 1, 2) = "OK" Then
                            Exit Do
                        End If
                    End If
                Loop

                If RadioButton2.Checked Then
                    comSelsct.Write("AT+ROLE=0")
                    comSelsct.Write(vbCrLf)
                    Do
                        Dim Incoming As String = comSelsct.ReadLine()

                        If Incoming Is Nothing Then

                        Else
                            If Mid(Incoming, 1, 2) = "OK" Then
                                Exit Do
                            End If
                        End If
                    Loop
                End If

                If RadioButton4.Checked Then
                    comSelsct.Write("AT+PIN" & PIN)
                Else
                    comSelsct.Write("AT+PSWD:" & PIN)
                End If
                comSelsct.Write(vbCrLf)

                Do
                    Dim Incoming As String = comSelsct.ReadLine()

                    If Incoming Is Nothing Then
                        Exit Do
                    Else
                        If Mid(Incoming, 1, 9) = "OKsetPIN" Or Mid(Incoming, 1, 2) = "OK" Then
                            Exit Do
                        End If
                    End If
                Loop
                If RadioButton2.Checked Then
                    comSelsct.Write("AT+ADDR?")
                    comSelsct.Write(vbCrLf)
                    Do
                        Dim Incoming As String = comSelsct.ReadLine()

                        If Incoming Is Nothing Then
                            Exit Do
                        Else
                            If Mid(Incoming, 1, 6) = "+ADDR:" Then
                                TextBox3.Text = Mid(Incoming, 7, Len(Incoming))
                                Exit Do
                            End If
                        End If
                    Loop
                End If
                If RadioButton3.Checked And RadioButton1.Checked Then
                    comSelsct.Write("AT+ROLE=1")
                    comSelsct.Write(vbCrLf)
                    Do
                        Dim Incoming As String = comSelsct.ReadLine()

                        If Incoming Is Nothing Then

                        Else
                            If Mid(Incoming, 1, 2) = "OK" Then
                                Exit Do
                            End If
                        End If
                    Loop
                End If
                MsgBox("Done.  完成。",, "藍芽設定")
            Catch ex As TimeoutException
                MsgBox("連結超時",, "錯誤")
            End Try
        Else
            MsgBox("請選擇藍芽版本")
        End If
    End Sub

    Private Sub RadioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton4.CheckedChanged
        If RadioButton4.Checked Then
            RadioButton1.Enabled = False
            RadioButton2.Checked = True
        Else
            RadioButton1.Enabled = True
            RadioButton2.Checked = True
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Form2.Show()
    End Sub
End Class
