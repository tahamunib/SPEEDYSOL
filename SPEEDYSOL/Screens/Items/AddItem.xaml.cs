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
    /// Interaction logic for AddItem.xaml
    /// </summary>
    public partial class AddItem : Page
    {
        public VMCreateItem _item;
        public string _header = "ADD ITEM";
        public AddItem(VMCreateItem item = null)
        {
            if (item != null)
            {
                _item = item;
                _header = "EDIT ITEM";
            }
            else
            {

                _item = new VMCreateItem();
            }
            InitializeComponent();
        }

        private void btnAddItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SSItemsLINQ.SaveItem(_item.Item))
                    MessageBox.Show("Item Saved!");
                else
                    MessageBox.Show("Error Ocuured: Could not save item.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = _item;
            this.header.Text = _header;
        }
    }
}
