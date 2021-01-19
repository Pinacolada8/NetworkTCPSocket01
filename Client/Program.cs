using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using SDK;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var hostname = args.Length >= 1 ? args[0] : ProjectConstants.DEFAULT_HOST;

            while (true)
            {
                var client = new TcpClient(hostname, ProjectConstants.PORT_NUMBER);

                var stream = client.GetStream();
                var outToServer = new BinaryWriter(stream);
                var inFromServer = new BinaryReader(stream);

                Console.WriteLine("Digite o texto a ser enviado para o servidor: ");
                var sentence = Console.ReadLine();

                if (!string.IsNullOrEmpty(sentence)) {
                    outToServer.Write(sentence);
                    var modifiedSentence = inFromServer.ReadString();

                    Console.WriteLine("FROM SERVER: " + modifiedSentence);
                }

                client.Close();
                Console.WriteLine();
                Console.WriteLine("--------------------------------");
                Console.WriteLine();
            }
        }
    }
}