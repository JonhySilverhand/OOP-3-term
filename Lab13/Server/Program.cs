using System;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Lab13;
using System.Text;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            const string ip = "127.0.0.1";
            const int port = 8081;

            var tcpEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);
            var tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            ChocolateCandy choco = new ChocolateCandy("Алёнка", "Конфета");

            MemoryStream memoryStream = new MemoryStream();
            BinaryFormatter binform = new BinaryFormatter();
            binform.Serialize(memoryStream, choco);
            var message = memoryStream.ToArray();

            foreach (var i in message)
            {
                Console.WriteLine($"{i} ");
            }

            var data = message;
            tcpSocket.Connect(tcpEndPoint);
            tcpSocket.Send(data);

            var buffer = new byte[256];
            var size = 0;
            var answer = new StringBuilder();

            do
            {
                size = tcpSocket.Receive(buffer); // get buffer
                answer.Append(Encoding.UTF8.GetString(buffer, 0, size));

            } while (tcpSocket.Available > 0);

            Console.WriteLine(answer.ToString());

            tcpSocket.Shutdown(SocketShutdown.Both);
            tcpSocket.Close();

            Console.ReadLine();
        }
    }
}
