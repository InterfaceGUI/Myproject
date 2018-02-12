Imports System.IO
Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports System.Text.RegularExpressions
Namespace eMZi.Gaming.Minecraft

    Public NotInheritable Class MinecraftServerInfo

        Public Property ServerMotd As String

        Public Property ServerMotdHtml As String
            Get
                Return Me.MotdHtml()
            End Get

            Set
            End Set
        End Property

        Public Property MaxPlayerCount As Int64

        Public Property CurrentPlayerCount As Int64

        Public Property MinecraftVersion As Version

        Private Shared Property MinecraftColors As Dictionary(Of Char, String)
            Get
                Return New Dictionary(Of Char, String)() From {{"0"c, "#000000"}, {"1"c, "#0000AA"}, {"2"c, "#00AA00"}, {"3"c, "#00AAAA"}, {"4"c, "#AA0000"}, {"5"c, "#AA00AA"}, {"6"c, "#FFAA00"}, {"7"c, "#AAAAAA"}, {"8"c, "#555555"}, {"9"c, "#5555FF"}, {"a"c, "#55FF55"}, {"b"c, "#55FFFF"}, {"c"c, "#FF5555"}, {"d"c, "#FF55FF"}, {"e"c, "#FFFF55"}, {"f"c, "#FFFFFF"}}
            End Get

            Set
            End Set
        End Property

        Private Shared Property MinecraftStyles As Dictionary(Of Char, String)
            Get
                Return New Dictionary(Of Char, String)() From {{"k"c, "none;font-weight:normal;font-style:normal"}, {"m"c, "line-through;font-weight:normal;font-style:normal"}, {"l"c, "none;font-weight:900;font-style:normal"}, {"n"c, "underline;font-weight:normal;font-style:normal;"}, {"o"c, "none;font-weight:normal;font-style:italic;"}, {"r"c, "none;font-weight:normal;font-style:normal;color:#FFFFFF;"}}
            End Get
            Set
            End Set
        End Property

        Private Sub New(ByVal motd As String, ByVal maxplayers As Int64, ByVal playercount As Int64)
            Me.ServerMotd = motd
            Me.MaxPlayerCount = maxplayers
            Me.CurrentPlayerCount = playercount

        End Sub

        Private Function MotdHtml() As String
            Dim regex As Regex = New Regex("§([k-oK-O])(.*?)(§[0-9a-fA-Fk-oK-OrR]|$)")
            Dim s As String = Me.ServerMotd
            While regex.IsMatch(s)
                s = regex.Replace(s, Function(m)
                                         Dim ast As String = "text-decoration:" & MinecraftStyles(m.Groups(1).Value(0))
                                         Dim html As String = "<span style=""" & ast & """>" + m.Groups(2).Value & "</span>" + m.Groups(3).Value
                                         Return html
                                     End Function)
            End While

            regex = New Regex("§([0-9a-fA-F])(.*?)(§[0-9a-fA-FrR]|$)")
            While regex.IsMatch(s)
                s = regex.Replace(s, Function(m)
                                         Dim ast As String = "color:" & MinecraftColors(m.Groups(1).Value(0))
                                         Dim html As String = "<span style=""" & ast & """>" + m.Groups(2).Value & "</span>" + m.Groups(3).Value
                                         Return html
                                     End Function)
            End While

            Return s
        End Function

        Public Shared Function GetServerInformation(ByVal endpoint As IPEndPoint) As MinecraftServerInfo
            If endpoint Is Nothing Then Throw New ArgumentNullException("endpoint")
            Try
                Dim packetdat As String() = Nothing
                Using client As TcpClient = New TcpClient()
                    client.Connect(endpoint)
                    Using ns As NetworkStream = client.GetStream()
                        ns.Write(New Byte() {254, 1}, 0, 2)
                        Dim buff As Byte() = New Byte(2047) {}
                        Dim br As Integer = ns.Read(buff, 0, buff.Length)
                        If buff(0) <> 255 Then Throw New InvalidDataException("Received invalid packet")
                        Dim packet As String = Encoding.BigEndianUnicode.GetString(buff, 3, br - 3)
                        If Not packet.StartsWith("§") Then Throw New InvalidDataException("Received invalid data")
                        packetdat = packet.Split(vbNullChar)
                        ns.Close()
                    End Using

                    client.Close()
                End Using

                Return New MinecraftServerInfo(packetdat(3), Integer.Parse(packetdat(5)), Integer.Parse(packetdat(4)))
            Catch ex As SocketException
                MsgBox(ex.Message)
                Exit Function
            Catch ex As InvalidDataException
                MsgBox(ex.Message)
                Exit Function
            Catch ex As Exception
                MsgBox(ex.Message)
                Exit Function
            End Try
        End Function

        Public Shared Function GetServerInformation(ByVal ip As IPAddress, ByVal port As Integer) As MinecraftServerInfo
            Return GetServerInformation(New IPEndPoint(ip, port))
        End Function
    End Class
End Namespace