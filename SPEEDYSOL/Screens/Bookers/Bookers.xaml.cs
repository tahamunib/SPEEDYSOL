using SPEEDYBLL;
using SPEEDYBLL.ViewModels.Booker;
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

namespace SPEEDYSOL.Screens.Bookers
{
    /// <summary>
    /// Interaction logic for Bookers.xaml
    /// </summary>
    public partial class Bookers : Page
    {
        MainWindow window;
        VMBooker vmBooker; 
        public Bookers(MainWindow _window)
        {
            window = _window;
            InitializeComponent();
        }

        private void bookerGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "sysSerial":
                    e.Cancel = true;
                    break;
                case "Name":
                    e.Column.DisplayIndex = 0;
                    break;
                case "Address":
                    e.Column.DisplayIndex = 1;
                    break;
                case "Type":
                    e.Column.DisplayIndex = 2;
                    break;
                case "ContactNum":
                    e.Column.DisplayIndex = 3;
                    break;
                case "CreatedOn":
                    e.Column.DisplayIndex = 4;
                    break;
                case "UpdatedOn":
                    e.Column.DisplayIndex = 5;
                    break;
                case "SaleOrders":
                    e.Cancel = true;
                    break;

            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedItem = (SPEEDYDAL.OrderBooker)bookerGrid.SelectedItem;
                window.mainFrame.Navigate(new AddBooker(selectedItem));
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
                var result = MessageBox.Show("Delete Order Booker?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    var selectedItem = (SPEEDYDAL.OrderBooker)bookerGrid.SelectedItem;
                    if (SSOrderBookersLINQ.DeleteItem(selectedItem))
                    {
                        vmBooker.Bookers.Remove(selectedItem);
                        this.DataContext = vmBooker;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            vmBooker = new VMBooker();
            this.DataContext = vmBooker;
        }

        private void btnAddItem_Click(object sender, RoutedEventArgs e)
        {
            window.mainFrame.Navigate(new Screens.Bookers.AddBooker());
        }
    }
}
