using SPEEDYBLL;
using SPEEDYBLL.ViewModels.Account;
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

namespace SPEEDYSOL.Screens.Accounts
{
    /// <summary>
    /// Interaction logic for AccGroups.xaml
    /// </summary>
    public partial class AccGroups : Page
    {
        MainWindow window;
        VMAccGroup vmAccGroup;
        public AccGroups(MainWindow _window)
        {
            window = _window;
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            vmAccGroup = new VMAccGroup();
            this.DataContext = vmAccGroup;
        }

        private void btnAddAccGroup_Click(object sender, RoutedEventArgs e)
        {
            window.mainFrame.Navigate(new CreateAccGroup());
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedItem = (SPEEDYDAL.AccountGroup)accGroupGrid.SelectedItem;
                window.mainFrame.Navigate(new CreateAccGroup(selectedItem));
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
                var selectedItem = (SPEEDYDAL.AccountGroup)accGroupGrid.SelectedItem;
                var result = MessageBox.Show(string.Format("Delete Account Group: {0} ?", selectedItem.Name), "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {

                    if (SSAccountsLINQ.DeleteAccGroup(selectedItem))
                    {
                        vmAccGroup.AccGroups.Remove(selectedItem);
                        this.DataContext = vmAccGroup;
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
