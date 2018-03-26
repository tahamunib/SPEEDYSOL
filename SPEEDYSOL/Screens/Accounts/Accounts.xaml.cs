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
    /// Interaction logic for Accounts.xaml
    /// </summary>
    public partial class Accounts : Page
    {
        MainWindow window;
        VMAccount vmAccount;
        public Accounts(MainWindow _window)
        {
            window = _window;
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            vmAccount = new VMAccount();
            this.DataContext = vmAccount;
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedItem = (SPEEDYDAL.SSAccount)accountsGrid.SelectedItem;
                VMCreateAccount accToEdit = new VMCreateAccount { Account = selectedItem };
                window.mainFrame.Navigate(new CreateAccount(accToEdit));
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
                var selectedItem = (SPEEDYDAL.SSAccount)accountsGrid.SelectedItem;
                var result = MessageBox.Show(string.Format("Delete Account: AccNo {0} ?",selectedItem.AccNo), "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    
                    if (SSAccountsLINQ.DeleteAccount(selectedItem))
                    {
                        vmAccount.Accounts.Remove(selectedItem);
                        this.DataContext = vmAccount;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void accountsGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "sysSerial":
                    e.Cancel = true;
                    break;
                case "AccNo":
                    e.Column.DisplayIndex = 0;
                    e.Column.Width = 300;
                    break;
                case "Name":
                    e.Column.DisplayIndex = 1;
                    e.Column.Width = 120;
                    e.Column.Header = "Name";
                    break;
                case "BalanceLimit":
                    e.Column.DisplayIndex = 2;
                    e.Column.Width = 40;
                    e.Column.Header = "Bal Limit";
                    break;
                case "DiscountInPercentage":
                    e.Cancel = true;
                    break;
                case "Remarks":
                    e.Column.DisplayIndex = 3;
                    break;
                case "CreatedOn":
                    e.Column.DisplayIndex = 4;
                    e.Column.Width = 60;
                    e.Column.Header = "Created On";
                    break;
                case "UpdatedOn":
                    e.Column.DisplayIndex = 5;
                    e.Column.Width = 60;
                    e.Column.Header = "Updated On";
                    break;
                case "VoucherDetails":
                    e.Cancel = true;
                    break;
                case "Vouchers":
                    e.Cancel = true;
                    break;
                case "CategoryID":
                    e.Cancel = true;
                    break;
                case "AccountCategory":
                    e.Column.DisplayIndex = 6;
                    e.Column.Width = 60;
                    e.Column.Header = "Category";
                    break;
            }
        }

        private void btnAddAccount_Click(object sender, RoutedEventArgs e)
        {
            window.mainFrame.Navigate(new Screens.Accounts.CreateAccount());
        }
    }
}
