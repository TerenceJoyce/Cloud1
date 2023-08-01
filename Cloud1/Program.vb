Imports System.Net
Imports System.Net.Sockets
Imports System.Text

Module UdpReceiver

    Sub Main()
        Dim LocalPort As Integer = 12345 ' Porta UDP sulla quale ricevere i dati
        Dim RemotePort As Integer = 2010 ' Porta UDP sulla quale trasmettere i dati
        Dim udpClient As New UdpClient(LocalPort)

    Console.WriteLine("In attesa di messaggi UDP2...")

    Try
            While True
                ' Riceve dati UDP e ottiene l'indirizzo IP e la porta del mittente
                Dim remoteEP As IPEndPoint = New IPEndPoint(IPAddress.Any, LocalPort)
                Dim data As Byte() = udpClient.Receive(remoteEP)

                ' Decodifica i dati ricevuti in una stringa
                Dim message As String = Encoding.ASCII.GetString(data)

                ' Visualizza il messaggio ricevuto sulla console
                Console.WriteLine($"Messaggio ricevuto da {remoteEP}: {message}")

                ' Modifica il messaggio e lo rispedisce al mittente
                Dim replyMessage As String = "RX-" & message
                Dim replyData As Byte() = Encoding.ASCII.GetBytes(replyMessage)
                udpClient.Send(replyData, replyData.Length, remoteEP)
                'udpClient.Send(replyData, replyData.Length, remoteEP.Address.ToString, 2010)
            End While
        Catch ex As Exception
            Console.WriteLine($"Errore: {ex.Message}")
        Finally
            udpClient.Close()
        End Try
    End Sub

End Module
