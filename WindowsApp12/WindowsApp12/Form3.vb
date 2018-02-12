Imports System.ComponentModel
Imports System.IO
Public Class Form3
    Dim sw As StreamWriter ' = New StreamWriter(CurDir() & "\data\serverinfo.inf")
    Dim sr As StreamReader
    Dim n = 1
    Dim la(8) As Label
    Dim te(8) As TextBox
    Dim te2(8) As TextBox
    Dim ch(8) As CheckBox


    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pa()
        te(0).Text = "A Minecraft Server"
        te2(0).Text = "127.0.0.1:25565"


        Try
            If File.Exists(CurDir() & "\data\serverinfo.inf") = False Then

                If Directory.Exists(CurDir() & "\data\") = False Then

                    Directory.CreateDirectory(CurDir() & "\data\")

                End If

                sw = File.CreateText(CurDir() & "\data\serverinfo.inf")
                sw.Close()

            ElseIf File.Exists(CurDir() & "\data\serverinfo.inf") = True Then


                sr = New StreamReader(CurDir() & "\data\serverinfo.inf")
                Dim temp = sr.ReadToEnd()
                Dim tempn As Int16

                If InStr(temp, "sinfo") = 0 Or InStr(temp, "servern:") = 0 Or InStr(temp, "sinend") = 0 Then
                    MsgBox("紀錄讀取錯誤", 0 + 16, "錯誤")
                    sr.Close()

                Else
                    tempn = Mid(temp, InStr(temp, "servern:") + 8, 1)
                    te(0).Text = ""
                    te2(0).Text = ""

                    te(0).Text = Mid(temp, InStr(temp, "sinfo0" & ":") + 7, (InStr(temp, "sinend0") - 7) - (InStr(temp, "sinfo0" & ":")))
                    te2(0).Text = Mid(temp, InStr(temp, "sip0" & ":") + 5, (InStr(temp, "sipend0") - 5) - (InStr(temp, "sip0" & ":")))
                    ch(0).Checked = IIf(Mid(temp, InStr(temp, "chs0" & ":") + 5, (InStr(temp, "chsend0") - 5) - (InStr(temp, "chs0" & ":"))) = "True", True, False)

                    If tempn <> 1 Then
                        For v = 1 To tempn - 1
                            n += 1
                            pa()
                            te(v).Text = Mid(temp, InStr(temp, "sinfo" & v & ":") + 7, (InStr(temp, "sinend" & v) - 7) - (InStr(temp, "sinfo" & v & ":")))
                            te2(v).Text = Mid(temp, InStr(temp, "sip" & v & ":") + 5, (InStr(temp, "sipend" & v) - 5) - (InStr(temp, "sip" & v & ":")))
                            ch(v).Checked = IIf(Mid(temp, InStr(temp, "chs" & v & ":") + 5, (InStr(temp, "chsend" & v) - 5) - (InStr(temp, "chs" & v & ":"))) = "True", True, False)

                        Next
                    End If
                End If
                sr.Close()
            Else
                MsgBox("關閉後可能無法儲存目前設定值", 0 + 16, "未知錯誤")
            End If

        Catch ex As Exception
            MsgBox(ex.Message, 0 + 16, "錯誤")
            Try
                sr.Close()
            Catch ex2 As Exception

            End Try
        End Try
        If Module1.form3 Then
            For ct = 0 To n - 1
                If te(ct).Text = "" Or te2(ct).Text = "" Then
                    MsgBox("伺服器名稱或IP不能為空")
                    te(ct).Text = "A Minecraft Server"
                    te2(ct).Text = "127.0.0.1:25565"
                    Exit Sub
                Else
                    For v = 0 To n - 1
                        serverinfo(v) = te(v).Text
                        serverip(v) = te2(v).Text
                        mch(v) = ch(v).Checked
                    Next
                    servern = n

                End If
            Next
            Close()
        End If
    End Sub

    Public Function pa()

        Dim i = n - 1

        la(i) = New Label
        te(i) = New TextBox
        te2(i) = New TextBox
        ch(i) = New CheckBox

        With la(i)
            .Text = "伺服器" & i + 1
            .Top = 11 + 155 * i
            .Left = 14
            .Parent = Panel1
        End With

        With te(i)
            .Top = la(i).Top + 30
            .Left = la(i).Left
            .Parent = Panel1
            .Width = 200
        End With
        With te2(i)
            .Top = te(i).Top + 35
            .Left = la(i).Left
            .Parent = Panel1
            .Width = 200
        End With
        With ch(i)
            .Top = te2(i).Top + 35
            .Left = la(i).Left
            .Parent = Panel1
            .Text = "Minecraft"
        End With

    End Function
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If n < 9 Then
            n += 1
            pa()
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If n <> 1 Then

            la(n - 1).Parent = Panel2
            te(n - 1).Parent = Panel2
            te2(n - 1).Parent = Panel2
            ch(n - 1).Parent = Panel2
            n -= 1
            Panel2.Controls.Clear()
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            sr.Close()
            sw.Close()
        Catch
        End Try
        Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        For ct = 0 To n - 1
            If te(ct).Text = "" Or te2(ct).Text = "" Then
                MsgBox("伺服器名稱或IP不能為空")
                te(ct).Text = "A Minecraft Server"
                te2(ct).Text = "127.0.0.1:25565"
                Exit Sub
            Else
                For v = 0 To n - 1
                    serverinfo(v) = te(v).Text
                    serverip(v) = te2(v).Text
                    mch(v) = ch(v).Checked
                Next
                servern = n

            End If
        Next
        Close()
    End Sub

    Private Sub Form3_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Try
            sw = New StreamWriter(CurDir() & "\data\serverinfo.inf")
            sw.Write("")
            sw.WriteLine("servern:" & servern & "snend")

            For v = 0 To n - 1
                sw.WriteLine("sinfo" & v & ":" & serverinfo(v) & "sinend" & v)
                sw.WriteLine("sip" & v & ":" & serverip(v) & "sipend" & v)
                sw.WriteLine("chs" & v & ":" & ch(v).Checked & "chsend" & v)
            Next

            sw.Close()

        Catch ex As Exception
            MsgBox(ex.Message)

            Exit Sub
        End Try
    End Sub

End Class