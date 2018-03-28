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
    /// Interaction logic for ItemBrands.xaml
    /// </summary>
    public partial class ItemBrands : Page
    {
        MainWindow window;
        VMBrands vmBrands;
        public ItemBrands(MainWindow _window)
        {
            window = _window;
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            vmBrands = new VMBrands();
            this.DataContext = vmBrands;
        }

        private void btnAddItemBrand_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedItem = (SPEEDYDAL.ItemBrand)brandsGrid.SelectedItem;
                
                window.mainFrame.Navigate(new AddBrand(selectedItem));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
