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

                var clientSentence = inFromClient.ReadString();

                var capitalizedSentence = clientSentence.ToUpper();
                outToClient.Write(capitalizedSentence);

                connectionSocket.Close();
            }
        }
    }
}
