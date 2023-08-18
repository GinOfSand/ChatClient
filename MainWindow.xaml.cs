using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ChatClient
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {

            InitializeComponent();


        }

        private void Connect_BTN_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Client client = new Client(IP_TB.Text, Convert.ToInt32(PORT_TB.Text));
                ChatClients window = new ChatClients(client.communication);

                this.Visibility = Visibility.Hidden;
                window.ShowDialog();
                


                //192.168.31.12
                //1024

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);    
            }
        }

        private void EXIT_BTN_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
