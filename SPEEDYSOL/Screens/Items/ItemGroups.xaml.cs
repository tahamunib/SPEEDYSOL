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
    /// Interaction logic for ItemGroups.xaml
    /// </summary>
    public partial class ItemGroups : Page
    {
        MainWindow window;
        VMItemGroups vmGroups;
        public ItemGroups(MainWindow _window)
        {
            window = _window;
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            vmGroups = new VMItemGroups();
            this.DataContext = vmGroups;
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedItem = (SPEEDYDAL.ItemGroup)groupsGrid.SelectedItem;

                window.mainFrame.Navigate(new AddItemGroup(selectedItem));
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
                var result = MessageBox.Show("Delete Item Group?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    var selectedItem = (SPEEDYDAL.ItemGroup)groupsGrid.SelectedItem;
                    if (SSItemsLINQ.DeleteItemGroup(selectedItem))
                    {
                        vmGroups.Groups.Remove(selectedItem);
                        this.DataContext = vmGroups;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAddItemGroup_Click(object sender, RoutedEventArgs e)
        {
            window.mainFrame.Navigate(new AddItemGroup());
        }
    }
}
