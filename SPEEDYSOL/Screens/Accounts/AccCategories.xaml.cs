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
    /// Interaction logic for AccCategories.xaml
    /// </summary>
    public partial class AccCategories : Page
    {
        MainWindow window;
        VMAccCategory vmAccCategory;
        public AccCategories(MainWindow _window)
        {
            window = _window;
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            vmAccCategory = new VMAccCategory();
            this.DataContext = vmAccCategory;
        }

        private void btnAddAccCatgeory_Click(object sender, RoutedEventArgs e)
        {
            window.mainFrame.Navigate(new CreateAccCategory());
        }
        
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedItem = (SPEEDYDAL.AccountCategory)accCategoryGrid.SelectedItem;
                VMCreateAccCategory accCategoryToEdit = new VMCreateAccCategory { AccCategory = selectedItem };
                window.mainFrame.Navigate(new CreateAccCategory(accCategoryToEdit));
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
                var selectedItem = (SPEEDYDAL.AccountCategory)accCategoryGrid.SelectedItem;
                var result = MessageBox.Show(string.Format("Delete Account Group: {0} ?", selectedItem.Name), "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {

                    if (SSAccountsLINQ.DeleteAccCategory(selectedItem))
                    {
                        vmAccCategory.AccCategories.Remove(selectedItem);
                        this.DataContext = vmAccCategory;
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
