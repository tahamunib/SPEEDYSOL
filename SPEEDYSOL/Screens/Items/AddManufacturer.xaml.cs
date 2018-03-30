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

namespace SPEEDYSOL.Screens.Items
{
    /// <summary>
    /// Interaction logic for AddManufacturer.xaml
    /// </summary>
    public partial class AddManufacturer : Page
    {
        ItemManufacturer itemManufacturer;
        string _header = "";
        int _Visibilty = 0;
        public AddManufacturer(ItemManufacturer _itemManufacturer = null)
        {
            if (_itemManufacturer != null)
            {
                itemManufacturer = _itemManufacturer;
                _header = "EDIT ITEM MANUFACTURER";
                _Visibilty = (int)Visibility.Visible;
            }
            else
            {
                _Visibilty = (int)Visibility.Hidden;
                itemManufacturer = new ItemManufacturer();
                _header = "CREATE ITEM MANUFACTURER";
            }
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = itemManufacturer;
            this.header.Text = _header;
            var visibilityEnumVal = (Visibility)Enum.Parse(typeof(Visibility), Convert.ToString(_Visibilty));
            this.lblCode.Visibility = visibilityEnumVal;
            this.txtCode.Visibility = visibilityEnumVal;
        }

        private void btnCreateManufacturer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SSItemsLINQ.SaveItemManufacturer(itemManufacturer))
                    MessageBox.Show("Item Manufacturer Saved!");
                else
                    MessageBox.Show("Error Occured: Could not save Item Manufacturer.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
