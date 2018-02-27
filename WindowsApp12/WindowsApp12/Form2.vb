Imports System.ComponentModel
Imports System.IO

Public Class Form2
    Dim sw As StreamWriter
    Dim sr As StreamReader
    Dim list As String

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        '儲存兼設定
        Try
            BServerID = TextBox2.Text
            BchannlID = TextBox3.Text
            If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Then
                MsgBox("Bot Token,Discord伺服器名稱,Discord頻道名稱" & vbCrLf & "上述3值不可為空白", 0 + 48,)
                Exit Sub
            End If

            Form1.token = TextBox1.Text
            Form1.servername = TextBox2.Text
            Form1.botChannel = TextBox3.Text
            list = TextBox1.Text & ";" & TextBox2.Text & "[" & TextBox3.Text
        Catch ex As Exception
            MsgBox("填入正確的字元",, "錯誤")
            Exit Sub
        End Try
        Try '讀檔部分
            sw = New StreamWriter(CurDir() & "\data\BotToken.inf")
            sw.Write("")
            sw.Write(list)
            sw.Close()

        Catch ex As Exception

            MsgBox(ex.Message,, "錯誤")

            Exit Sub
        End Try
        Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Close()
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            If File.Exists(CurDir() & "\data\BotToken.inf") = False Then

                If Directory.Exists(CurDir() & "\data\") = False Then
                    Directory.CreateDirectory(CurDir() & "\data\")
                End If

                sw = File.CreateText(CurDir() & "\data\BotToken.inf")
                sw.Close()

            ElseIf File.Exists(CurDir() & "\data\BotToken.inf") = True Then

                sr = New StreamReader(CurDir() & "\data\BotToken.inf")
                Dim temp = sr.ReadToEnd()
                TextBox1.Text = Mid(temp, 1, InStr(temp, ";") - 1)
                TextBox2.Text = Mid(temp, InStr(temp, ";") + 1, InStr(temp, "[") - InStr(temp, ";") - 1)
                TextBox3.Text = Mid(temp, InStr(temp, "[") + 1, Len(temp) - InStr(temp, "["))
                sr.Close()

            Else
                MsgBox("關閉後可能無法儲存目前設定值", 0 + 16, "未知錯誤")
            End If

        Catch ex As Exception
            MsgBox("填入正確的字元後持續跳出請告知開發者;錯誤內容:" & vbCrLf & ex.Message, 0 + 16, "錯誤")
            Try
                sr.Close()
            Catch ex2 As Exception

            End Try
        End Try
        If Module1.form2 Then
            Try
                BServerID = TextBox2.Text
                BchannlID = TextBox3.Text
                If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Then
                    MsgBox("Bot Token,Discord伺服器名稱,Discord頻道名稱" & vbCrLf & "上述3值不可為空白", 0 + 48,)
                    Exit Sub
                End If

                Form1.token = TextBox1.Text
                Form1.servername = TextBox2.Text
                Form1.botChannel = TextBox3.Text
                list = TextBox1.Text & ";" & TextBox2.Text & "[" & TextBox3.Text
            Catch ex As Exception
                MsgBox("填入正確的字元",, "錯誤")
                Exit Sub
            End Try
            Try
                sw = New StreamWriter(CurDir() & "\data\BotToken.inf")
                sw.Write("")
                sw.Write(list)
                sw.Close()

            Catch ex As Exception

                MsgBox(ex.Message,, "錯誤")

                Exit Sub
            End Try
            Close()
        End If
    End Sub

    Private Sub Form2_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Try
            sr.Close()
            sw.Close()
        Catch ex As Exception

        End Try
    End Sub


End Class