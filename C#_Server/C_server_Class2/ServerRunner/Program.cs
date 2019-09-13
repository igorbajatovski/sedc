using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ServerRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] bytes = new byte[1024];
            IPAddress localhost = IPAddress.Parse("127.0.0.1");

            TcpListener listener = new TcpListener(localhost, 13000);
            listener.Start();


            Console.WriteLine("Started listening");
            
            while (true)
            {
                Console.WriteLine("Before client");
                var client = listener.AcceptTcpClient();
                Console.WriteLine("After client");
                var socket = client.Client;

                var readCount = socket.Receive(bytes);
                StringBuilder data = new StringBuilder();
                while (readCount != 0)
                {
                    var readString = Encoding.ASCII.GetString(bytes, 0, readCount);
                    data.Append(readString);
                    string[] request = readString.Split("\r\n");
                    if (request[request.Length - 2] == "" && request[request.Length - 1] == "")
                        break;
                    readCount = socket.Receive(bytes);
                }

                Console.WriteLine(data.ToString());

                var message = @"HTTP/1.1 200 OK
Server: SEDC server

HODOR";
                var messageBytes = Encoding.ASCII.GetBytes(message);
                socket.Send(messageBytes, SocketFlags.None);
                socket.Close();
                client.Close();
            }
        }
    }
}