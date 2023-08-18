using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ChatClient;

namespace ChatClient
{
    public class Client:IDisposable
    {
        public Socket client;
        public Communicator communication { get; set; }
        

        

        public Client(string ip, int port)
        {
            // 1. создать сокет клиента
            client = new Socket(AddressFamily.InterNetwork,
                    SocketType.Stream, ProtocolType.IP);

            // 2. подключится к серверу
            IPAddress serverIp = IPAddress.Parse(ip);
            IPEndPoint serverEndPoint = new IPEndPoint(serverIp, port);
            client.Connect(serverEndPoint); // подключение к серверу
            // 3.
            communication = new Communicator(client);
        }

        public Client()
        {
        }

        public void Dispose()
        {
            client?.Dispose();
        }
    }
}
