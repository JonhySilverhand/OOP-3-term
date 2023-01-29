using System;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Lab13;
using System.Text;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            const string ip = "127.0.0.1";
            const int port = 8081;

            var tcpEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);

            var tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            tcpSocket.Bind(tcpEndPoint);
            tcpSocket.Listen(5);

            var listener = tcpSocket.Accept();
            var buffer = new byte[256];
            var size = 0;
            var data = new ChocolateCandy();

            do
            {
                size = listener.Receive(buffer); // get buffer
                byte[] b = buffer;
                using(var stream = new MemoryStream(b))
                {
                    var formatter = new BinaryFormatter();
                    stream.Seek(0, SeekOrigin.Begin);
                    data = formatter.Deserialize(stream) as ChocolateCandy;
                }
            } while (listener.Available > 0);

            Console.WriteLine(data.ToString());
            listener.Send(Encoding.UTF8.GetBytes("\nОтвет клиента: Сообщение принято\n"));

            listener.Shutdown(SocketShutdown.Both);
            listener.Close();

            Console.ReadLine();
        }
    }
}
