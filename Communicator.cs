using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient
{
    public class Communicator
    {
        private Socket socket;
        public Communicator(Socket socket)
        {
            this.socket = socket;
        }
        public void SendMessage(string message)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(message);
            socket.Send(buffer);
        }
        public string ReceiveMessage()
        {
                byte[] buffer = new byte[1024];
                int received_bytes_count = socket.Receive(buffer);
                return Encoding.UTF8.GetString(buffer, 0, received_bytes_count);
        }
    }
}
