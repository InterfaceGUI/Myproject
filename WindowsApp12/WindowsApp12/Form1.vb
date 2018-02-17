Imports Discord
Imports Discord.WebSocket
Imports System.ComponentModel
Imports System.Net.Sockets
Imports System.Net
Imports DGSS.eMZi.Gaming.Minecraft




Public Class Form1
    Public token As String
    Public servername As String
    Public botChannel
    Dim discord As DiscordSocketClient
    Dim con1 As Int16 = 0

    Private Async Sub Form1_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Await discord.LogoutAsync()
    End Sub

    Dim sinf As String
    Private Function IsPortOpen(ByVal Host As String, ByVal PortNumber As Integer) As Boolean
        Dim Client As TcpClient = Nothing
        Try
            Client = New TcpClient(Host, PortNumber)
            Return True
        Catch ex As SocketException
            Return False
        Finally
            If Not Client Is Nothing Then
                Client.Close()
            End If
        End Try
    End Function

    Private Async Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Button1.Text = IIf(Button1.Text = "啟動", "停止", "啟動")
        If Button1.Text <> "啟動" Then
            Try
                Await discord.LoginAsync(TokenType.Bot, token)
                Await discord.StartAsync()
                Label4.Text = "已啟動"
                Label4.ForeColor = Drawing.Color.Green
                Button4.Enabled = True


                If CheckBox2.Checked Then
                    Timer1.Enabled = True
                    Timer2.Enabled = True
                    Timer1.Interval = (Val(TextBox1.Text) * 60) * 1000
                    tim = (Timer1.Interval / 60) / 1000
                    Label7.Text = "剩餘" & tim & "分鐘"
                End If

            Catch ex As Exception
                Button1.Text = "啟動"
                Label4.Text = "錯誤"
                Label4.ForeColor = Drawing.Color.Red
                MsgBox(ex.Message, 0 + 16, "無法連接BOT")
                Button4.Enabled = False
                Timer1.Enabled = False
                Timer2.Enabled = False
            End Try
            discord.SetGameAsync("遊戲伺服器狀態BOT")
        Else

            Await discord.LogoutAsync()
            Label4.Text = "停止"
            Label4.ForeColor = Drawing.Color.Black
            Button4.Enabled = False
            Timer1.Enabled = False
            Timer2.Enabled = False
            con1 = 0
        End If
    End Sub

    Private Async Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        discord = New DiscordSocketClient(New DiscordSocketConfig With {
                                          .WebSocketProvider = Net.Providers.WS4Net.WS4NetProvider.Instance,
                                          .UdpSocketProvider = Net.Providers.UDPClient.UDPClientProvider.Instance,
                                          .MessageCacheSize = 50
        })
        AddHandler discord.MessageReceived, AddressOf onMsg
        CheckBox1.Text = "開啟手動查詢" & vbCrLf & "Discord命令:,info"
        Module1.form3 = True
        Module1.form2 = True
        Form2.Show()
        Form3.Show()
        Module1.form2 = False
        Module1.form3 = False
        Panel1.Enabled = False
    End Sub


    Dim color1 As Color

    Private Async Function onMsg(message As SocketMessage) As Task

        If CheckBox1.Checked = True Then
            If message.Source = MessageSource.Bot Then
            Else
                If message.Content.StartsWith(trigger) Then

                    Dim cmd As String = message.Content.Split(Convert.ToChar(trigger))(1).Split(Convert.ToChar(" "))(0)

                    Select Case cmd.ToLower

                        Case "info"
                            serino()
                            Dim embed As New EmbedBuilder With {
                                                .Title = "各伺服器狀態",
                                                .Description = info,
                                                .Color = New Color(0, 255, 0)
                                                }
                            Await message.Channel.SendMessageAsync("", False, embed)

                        Case "test"
                            Dim embed As New EmbedBuilder With {
                        .Title = message.Author.Username,
                        .Description = "測試",
                        .Color = New Color(255, 0, 0),
                        .ThumbnailUrl = message.Author.GetAvatarUrl
                        }
                            Await message.Channel.SendMessageAsync("", False, embed)
                    End Select

                End If
            End If
        End If
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form2.Show()
    End Sub

    Dim info As String
    Dim serif(8) ' 伺服器的on off狀態
    Dim player(8) '伺服器玩家人數
    Dim MAXplayer(8)
    Function serino()
        Try
            For T = 0 To servern - 1
                Dim temp, tempp As String
                temp = ""
                tempp = ""
                temp = Mid(serverip(T), 1, InStr(serverip(T), ":") - 1)
                tempp = Mid(serverip(T), InStr(serverip(T), ":") + 1, Len(serverip(T)) - InStr(serverip(T), ":"))
                Dim Port As Integer = tempp
                Dim Hostname As String = temp
                Dim PortOpen As Boolean = IsPortOpen(Hostname, Port)

                If PortOpen = True Then
                    serif(T) = " **線上** "
                Else
                    serif(T) = "__離線__"
                End If

                Try
                    If mch(T) And serif(T) = " **線上** " Then
                        Dim ip As String = Dns.GetHostAddresses(temp)(0).ToString
                        Dim Minfo As MinecraftServerInfo = MinecraftServerInfo.GetServerInformation(IPAddress.Parse(ip), tempp)

                        player(T) = Minfo.CurrentPlayerCount
                        MAXplayer(T) = Minfo.MaxPlayerCount

                    End If
                Catch ex As Exception
                    player(T) = "unknown"
                    MAXplayer(T) = " "
                End Try

            Next
        Catch ex As Exception
            MsgBox(ex.Message & vbCrLf & "通常是IP打錯!",, "錯誤")
        End Try
        info = ""
        For i = 0 To servern - 1
            info &= "========================"
            info &= vbCrLf
            info &= "伺服器名稱: " & serverinfo(i) & vbCrLf & "伺服器IP: " & serverip(i) & vbCrLf & "狀態: " & serif(i)
            If mch(i) And serif(i) = " **線上** " Then
                info &= vbCrLf
                info &= "玩家人數: " & player(i) & "/" & MAXplayer(i)
            End If
            info &= vbCrLf
        Next
    End Function
    Dim Messa As Rest.RestUserMessage
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Form3.Show()
    End Sub
    Private Async Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        serino()
        Dim embed As New EmbedBuilder With {
                                                .Title = "各伺服器狀態",
                                                .Description = info,
                                                .Color = New Color(0, 255, 0)
                                                }
        Try
            If con1 = 0 Then
                Messa = Await discord.GetGuild(BServerID).GetTextChannel(BchannlID).SendMessageAsync("", False, embed)
            Else
                Await Messa.DeleteAsync()
                Messa = Await discord.GetGuild(BServerID).GetTextChannel(BchannlID).SendMessageAsync("", False, embed)



            End If

        Catch ex As Exception
            MsgBox(ex.Message & vbCrLf & vbCrLf & "通常是伺服器或頻道ID填寫錯誤",, "錯誤")
        End Try
        con1 = 1

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        serino()
        Dim embed As New EmbedBuilder With {
                                                .Title = "各伺服器狀態",
                                                .Description = info,
                                                .Color = New Color(0, 255, 0)
                                                }
        discord.GetGuild(BServerID).GetTextChannel(BchannlID).SendMessageAsync("", False, embed)
        tim = (Timer1.Interval / 60) / 1000
        Label7.Text = "剩餘" & tim & "分鐘"
    End Sub
    Dim tim As Int16
    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        tim -= 1
        Label7.Text = "剩餘" & tim & "分鐘"
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs)
        Module1.form3 = True
        Module1.form2 = True
        Form2.Show()
        Form3.Show()
        Module1.form2 = False
        Module1.form3 = False
    End Sub

    Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox3.CheckedChanged
        Panel1.Enabled = IIf(CheckBox3.Checked, True, False)

    End Sub

    Private Sub Button5_Click_1(sender As Object, e As EventArgs) Handles Button5.Click
        Timer3.Enabled = Not Timer3.Enabled
        Button5.Text = IIf(Timer3.Enabled, "停止", "啟動")
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        ListBox1.Items.Add(TextBox3.Text)
    End Sub
End Class
