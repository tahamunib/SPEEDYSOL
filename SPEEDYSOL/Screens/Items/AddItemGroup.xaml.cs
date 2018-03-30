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
    /// Interaction logic for AddItemGroup.xaml
    /// </summary>
    public partial class AddItemGroup : Page
    {
        ItemGroup itemGroup;
        string _header = "";
        int _Visibilty = 0;
        public AddItemGroup(ItemGroup _itemGroup = null)
        {
            if (_itemGroup != null)
            {
                itemGroup = _itemGroup;
                _header = "EDIT ITEM GROUP";
                _Visibilty = (int)Visibility.Visible;
            }
            else
            {
                _Visibilty = (int)Visibility.Hidden;
                itemGroup = new ItemGroup();
                _header = "CREATE ITEM GROUP";
            }
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = itemGroup;
            this.header.Text = _header;
            var visibilityEnumVal = (Visibility)Enum.Parse(typeof(Visibility), Convert.ToString(_Visibilty));
            this.lblCode.Visibility = visibilityEnumVal;
            this.txtCode.Visibility = visibilityEnumVal;
        }

        private void btnCreateGroup_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SSItemsLINQ.SaveItemGroup(itemGroup))
                    MessageBox.Show("Item Group Saved!");
                else
                    MessageBox.Show("Error Occured: Could not save Item Group.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
