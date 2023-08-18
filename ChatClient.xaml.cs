using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ChatClient
{
    /// <summary>
    /// Логика взаимодействия для ChatClient.xaml
    /// </summary>
    public partial class ChatClients : Window
    {
        
        Communicator communicator;
        
        public ChatClients(Communicator cm)
        {
            InitializeComponent();
            communicator = cm;
            Thread th = new Thread(new ThreadStart(() => 
            { 
                Recive(); 
            }));
            th.Start();
        }

        private void Send_Click(object sender, RoutedEventArgs e)
        {
            communicator.SendMessage(Send_TB.Text);
            Chat_LB.Items.Add(Send_TB.Text);
            Send_TB.Clear();
        }
     
        private void Recive() 
        {
            while (true)
            {
                string message = communicator.ReceiveMessage();
                if (message != string.Empty)
                {
                    Chat_LB.Items.Add(message);
                }
                Thread.Sleep(100);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();

        }
    }
}
