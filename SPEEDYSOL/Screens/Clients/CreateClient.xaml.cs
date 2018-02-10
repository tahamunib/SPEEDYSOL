using SPEEDYBLL;
using SPEEDYDAL;
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

namespace SPEEDYSOL.Screens.Clients
{
    /// <summary>
    /// Interaction logic for CreateClient.xaml
    /// </summary>
    public partial class CreateClient : Page
    {
        SSClient client;
        string _header = "";
        int _Visibilty = 0;
        public CreateClient(SSClient _client = null)
        {
            if (_client != null)
            {
                client = _client;
                _header = "EDIT CLIENT";
            }
            else
            {
                client = new SSClient();
                _header = "CREATE CLIENT";
            }
            InitializeComponent();
        }

        private void btnCreateClient_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SSClientLINQ.SaveClient(client))
                    MessageBox.Show("Client Saved!");
                else
                    MessageBox.Show("Error Ocuured: Could not save client.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

            this.DataContext = client;
            this.header.Text = _header;
        }
    }
}
