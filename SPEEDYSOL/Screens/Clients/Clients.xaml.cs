using SPEEDYBLL;
using SPEEDYBLL.ViewModels.Client;
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
    /// Interaction logic for Clients.xaml
    /// </summary>
    public partial class Clients : Page
    {
        MainWindow window;
        VMClient vmClient;
        public Clients(MainWindow _window)
        {
            window = _window;
            InitializeComponent();
        }

        private void clientsGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "sysSerial":
                    e.Cancel = true;
                    break;
                case "Name":
                    e.Column.DisplayIndex = 0;
                    e.Column.Width = 150;
                    break;
                case "ContactPerson":
                    e.Column.DisplayIndex = 1;
                    e.Column.Width = 150;
                    e.Column.Header = "Contact Person";
                    break;
                case "Address":
                    e.Column.DisplayIndex = 2;
                    e.Column.Width = 150;
                    e.Column.Header = "Address";

                    break;
                case "ContactNumber":
                    e.Column.DisplayIndex = 3;
                    e.Column.Width = 100;
                    e.Column.Header = "Contact Number";
                    break;

                case "Email":
                    e.Column.DisplayIndex = 4;
                    e.Column.Width = 50;
                    e.Column.Header = "Email";
                    break;
                case "Fax":
                    e.Column.DisplayIndex = 5;
                    e.Column.Width = 50;
                    e.Column.Header = "Fax";
                    break;
                case "NIC":
                    e.Column.DisplayIndex = 6;
                    e.Column.Width = 60;
                    e.Column.Header = "NIC";
                    break;
                case "City":
                    e.Column.DisplayIndex = 7;
                    e.Column.Width = 50;
                    e.Column.Header = "City";
                    break;
                case "NTN":
                    e.Column.DisplayIndex = 8;
                    e.Column.Width = 100;
                    e.Column.Header = "NTN";
                    break;
                case "SalesTaxNo":
                    e.Column.DisplayIndex = 9;
                    e.Column.Width = 100;
                    e.Column.Header = "Sales Tax No";
                    break;
                case "CreatedOn":
                    e.Column.DisplayIndex = 9;
                    e.Column.Width = 60;
                    e.Column.Header = "Created On";
                    break;
                case "UpdatedOn":
                    e.Column.DisplayIndex = 9;
                    e.Column.Width = 60;
                    e.Column.Header = "Updated On";
                    break;
                case "PurchaseOrders":
                    e.Cancel = true;
                    break;
                case "SaleOrders":
                    e.Cancel = true;
                    break;
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            vmClient = new VMClient();
            this.DataContext = vmClient;
        }

        private void btnAddClient_Click(object sender, RoutedEventArgs e)
        {
            window.mainFrame.Navigate(new CreateClient());
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedItem = (SPEEDYDAL.SSClients)clientsGrid.SelectedItem;
                window.mainFrame.Navigate(new CreateClient(selectedItem));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedItem = (SPEEDYDAL.SSClients)clientsGrid.SelectedItem;
                var result = MessageBox.Show(string.Format("Delete Client: Name {0} ?", selectedItem.Name), "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {

                    if (SSClientLINQ.DeleteClient(selectedItem))
                    {
                        vmClient.Clients.Remove(selectedItem);
                        this.DataContext = vmClient;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
