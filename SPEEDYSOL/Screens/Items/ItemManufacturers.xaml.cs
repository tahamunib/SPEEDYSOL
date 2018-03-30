using SPEEDYBLL;
using SPEEDYBLL.ViewModels.Item;
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

namespace SPEEDYSOL.Screens.Items
{
    /// <summary>
    /// Interaction logic for ItemManufacturers.xaml
    /// </summary>
    public partial class ItemManufacturers : Page
    {
        MainWindow window;
        VMManufacturer vmManufacturers;
        public ItemManufacturers(MainWindow _window)
        {
            window = _window;
            InitializeComponent();
        }

        private void btnAddItemManufacturer_Click(object sender, RoutedEventArgs e)
        {
            window.mainFrame.Navigate(new AddManufacturer());
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedItem = (SPEEDYDAL.ItemManufacturer)manufacturersGrid.SelectedItem;

                window.mainFrame.Navigate(new AddManufacturer(selectedItem));
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
                var result = MessageBox.Show("Delete Item Manufacturer?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    var selectedItem = (SPEEDYDAL.ItemManufacturer)manufacturersGrid.SelectedItem;
                    if (SSItemsLINQ.DeleteItemManufacturer(selectedItem))
                    {
                        vmManufacturers.Manufacturers.Remove(selectedItem);
                        this.DataContext = vmManufacturers;
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
            vmManufacturers = new VMManufacturer();
            this.DataContext = vmManufacturers;
        }
    }
}
