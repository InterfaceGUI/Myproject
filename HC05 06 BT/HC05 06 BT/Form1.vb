Public Class Form1
    Dim com As New IO.Ports.SerialPort

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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Button1.Text = "開啟通訊埠" Then

            com.ReadTimeout = 2000
            With com
                .PortName = ComboBox1.SelectedItem
                .BaudRate = ComboBox2.SelectedItem

            End With
            Try
                com.Open()
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

                    com.Close()
                Catch eax As Exception
                    ListBox1.Items.Add(Date.Now + " 錯誤" + eax.Message)
                End Try
            End Try
        Else

            Button3.Enabled = False
            com.Close()
            ComboBox1.Enabled = True
            ComboBox2.Enabled = True
        End If
        Button1.Text = IIf(Button1.Text = "開啟通訊埠", "關閉通訊埠", "開啟通訊埠")
    End Sub
    Dim laststr As String
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click


        Button3.Enabled = False
        If RadioButton3.Checked Or RadioButton4.Checked Then
            Dim PIN As Int16 = Val(TextBox2.Text)
line1:
            com.Write("AT")
            com.Write(vbCrLf)
            ListBox1.Items.Add(Date.Now + " 發送'AT'")
            Try
                Do
                    Dim Incoming As String = com.ReadLine()
                    laststr = Incoming
                    If Incoming Is Nothing Then

                    Else
                        If Incoming.Contains("OK") Then 'Mid(Incoming, 1, 2) = "OK" Then
                            ListBox1.Items.Add(Date.Now + " 接收到" + Incoming)
                            Exit Do
                        ElseIf Incoming.Contains("ERROR") Then
                            ListBox1.Items.Add(Date.Now + " 接收到" + Incoming)
                            ListBox1.Items.Add(Date.Now + " 重新嘗試")

                            GoTo line1
                            Exit Do
                        End If
                    End If

                Loop
                ProgressBar1.Value = 17
                If RadioButton3.Checked Then
                    com.Write("AT+NAME:" & TextBox1.Text)
                    ListBox1.Items.Add(Date.Now + " 發送'AT+NAME:'")
                Else
                    com.Write("AT+NAME" & TextBox1.Text)
                    ListBox1.Items.Add(Date.Now + " 發送'AT+NAME'")
                End If
                com.Write(vbCrLf)
                Do
                    Dim Incoming As String = com.ReadLine()
                    laststr = Incoming
                    If Incoming Is Nothing Then
                        Exit Do
                    Else
                        If Incoming.Contains("OK") = True Then
                            ListBox1.Items.Add(Date.Now + " 接收到" + Incoming)
                            Exit Do
                        End If
                    End If
                Loop
                ProgressBar1.Value += 17
                If RadioButton2.Checked Then
                    com.Write("AT+ROLE=0")
                    com.Write(vbCrLf)
                    ListBox1.Items.Add(Date.Now + " 發送'AT+ROLE=0'")
                    Do
                        Dim Incoming As String = com.ReadLine()

                        If Incoming Is Nothing Then

                        Else
                            If Incoming.Contains("OK") Then
                                ListBox1.Items.Add(Date.Now + " 接收到" + Incoming)
                                Exit Do
                            End If
                        End If
                    Loop
                End If
                ProgressBar1.Value += 17
                If RadioButton4.Checked Then
                    com.Write("AT+PIN" & PIN)
                    ListBox1.Items.Add(Date.Now + " 發送'AT+PIN'")
                Else
                    com.Write("AT+PSWD:" & PIN)
                    ListBox1.Items.Add(Date.Now + " 發送'AT+PSWD:'")
                End If
                com.Write(vbCrLf)

                Do
                    Dim Incoming As String = com.ReadLine()

                    If Incoming Is Nothing Then
                        Exit Do
                    Else
                        If Incoming.Contains("OK") Then
                            ListBox1.Items.Add(Date.Now + " 接收到" + Incoming)
                            Exit Do
                        End If
                    End If
                Loop
                ProgressBar1.Value += 17
                If RadioButton2.Checked Then
                    com.Write("AT+ADDR?")
                    com.Write(vbCrLf)
                    ListBox1.Items.Add(Date.Now + " 發送'AT+ADDR?'")
                    Do
                        Dim Incoming As String = com.ReadLine()

                        If Incoming Is Nothing Then
                            Exit Do
                        Else
                            If Mid(Incoming, 1, 6) = "+ADDR:" Then
                                TextBox3.Text = Mid(Incoming, 7, Len(Incoming))
                                ListBox1.Items.Add(Date.Now + " 接收到'" + Incoming + "'")
                                Exit Do
                            End If
                        End If
                    Loop
                    ProgressBar1.Value += 17
                End If
                If RadioButton3.Checked And RadioButton1.Checked Then
                    com.Write("AT+ROLE=1")
                    com.Write(vbCrLf)
                    ListBox1.Items.Add(Date.Now + " 發送'AT+ROLE=1'")
                    Do
                        Dim Incoming As String = com.ReadLine()

                        If Incoming Is Nothing Then

                        Else
                            If Incoming.Contains("OK") Then
                                ListBox1.Items.Add(Date.Now + " 接收到" + Incoming)
                                Exit Do
                            End If
                        End If
                    Loop

                End If
                ProgressBar1.Value = 100
                MsgBox("Done.  完成。",, "藍芽設定")
                ProgressBar1.Value = 0
            Catch ex As TimeoutException
                ListBox1.Items.Add(Date.Now + " " + ex.Message)
                ListBox1.Items.Add(Date.Now + " 最後收到的字元:" + "'" + " " + laststr + "'")
                MsgBox("連結超時",, "錯誤")
                Button3.Enabled = True
            Catch ex2 As Exception
                ListBox1.Items.Add(Date.Now + " " + ex2.Message)
            End Try
            Button3.Enabled = True


        Else
            MsgBox("請選擇藍芽版本")
            Button3.Enabled = True
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

    Dim st As Boolean = False
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If st Then
            Me.Height = 285
            st = False
        Else
            st = True
            Me.Height = 520
        End If
    End Sub



End Class
