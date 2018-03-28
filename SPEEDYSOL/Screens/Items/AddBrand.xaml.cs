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
    /// Interaction logic for AddBrand.xaml
    /// </summary>
    public partial class AddBrand : Page
    {
        ItemBrand itemBrand;
        string _header = "";
        int _Visibilty = 0;
        public AddBrand(ItemBrand _itemBrand = null)
        {
            if (_itemBrand != null)
            {
                itemBrand = _itemBrand;
                _header = "EDIT ITEM BRAND";
                _Visibilty = (int)Visibility.Visible;
            }
            else
            {
                _Visibilty = (int)Visibility.Hidden;
                itemBrand = new ItemBrand();
                _header = "CREATE ITEM BRAND";
            }
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = itemBrand;
            this.header.Text = _header;
            var visibilityEnumVal = (Visibility)Enum.Parse(typeof(Visibility), Convert.ToString(_Visibilty));
            this.lblCode.Visibility = visibilityEnumVal;
            this.txtCode.Visibility = visibilityEnumVal;
        }

        private void btnCreateBrand_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SSItemsLINQ.SaveItemBrand(itemBrand))
                    MessageBox.Show("Item Brand Saved!");
                else
                    MessageBox.Show("Error Occured: Could not save Item Brand.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
