using SPEEDYBLL;
using SPEEDYBLL.ViewModels.Salesmen;
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

namespace SPEEDYSOL.Screens.SalesMen
{
    /// <summary>
    /// Interaction logic for SalesMen.xaml
    /// </summary>
    public partial class SalesMen : Page
    {
        MainWindow window;
        VMSalesmen vmSalesmen;
        public SalesMen(MainWindow _window)
        {
            window = _window;
            InitializeComponent();
        }

        private void salesmenGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "sysSerial":
                    e.Cancel = true;
                    break;
                case "Name":
                    e.Column.DisplayIndex = 0;
                    break;
                case "DSRCode":
                    e.Column.DisplayIndex = 1;
                    break;
                case "CreatedOn":
                    e.Column.DisplayIndex = 2;
                    break;
                case "UpdatedOn":
                    e.Column.DisplayIndex = 3;
                    break;
                case "SaleOrders":
                    e.Cancel = true;
                    break;
                case "DailySales":
                    e.Cancel = true;
                    break;

            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            vmSalesmen = new VMSalesmen();
            this.DataContext = vmSalesmen;
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedItem = (SPEEDYDAL.Salesman)salesmenGrid.SelectedItem;
                window.mainFrame.Navigate(new AddSalesman(selectedItem));
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
                var result = MessageBox.Show("Delete Salesman?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    var selectedItem = (SPEEDYDAL.Salesman)salesmenGrid.SelectedItem;
                    if (SSSalesManLINQ.DeleteItem(selectedItem))
                    {
                        vmSalesmen.Salesmen.Remove(selectedItem);
                        this.DataContext = vmSalesmen;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAddItem_Click(object sender, RoutedEventArgs e)
        {
            window.mainFrame.Navigate(new Screens.SalesMen.AddSalesman());
        }
    }
}
