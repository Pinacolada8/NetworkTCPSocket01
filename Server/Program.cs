using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using SDK;

namespace Server {
    class Program
    {
        public static void Main(string[] args) {
            var server = new TcpListener(IPAddress.Any, ProjectConstants.PORT_NUMBER);
            server.Start();

            while (true)
            {
                var connectionSocket = server.AcceptSocket();

                var stream = new NetworkStream(connectionSocket);
                var inFromClient = new BinaryReader(stream);
                var outToClient = new BinaryWriter(stream);

                Console.WriteLine("Connected");

                var clientSentence = inFromClient.ReadString();

                Console.WriteLine("Received From Client: " + clientSentence);

                var capitalizedSentence = clientSentence.ToUpper();

                Console.WriteLine("Sent to Client: " + capitalizedSentence);

                outToClient.Write(capitalizedSentence);

                Console.WriteLine("Successfully sent");

                connectionSocket.Close();
                Console.WriteLine();
                Console.WriteLine("--------------------------------");
                Console.WriteLine();
            }
        }
    }
}
