using SPEEDYBLL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace SPEEDYSOL.Screens.Purchases
{
    /// <summary>
    /// Interaction logic for PurchaseDamChallans.xaml
    /// </summary>
    public partial class PurchaseDamChallans : Page
    {
        MainWindow window;
        ObservableCollection<SPEEDYDAL.PurchaseDamageChallan> uiList;
        public PurchaseDamChallans(MainWindow _window)
        {
            window = _window;
            InitializeComponent();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedItem = (SPEEDYDAL.PurchaseDamageChallan)challanGrid.SelectedItem;
                window.mainFrame.Navigate(new CreatePurchaseDamChallan(selectedItem));
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
                var selectedItem = (SPEEDYDAL.PurchaseDamageChallan)challanGrid.SelectedItem;
                var result = MessageBox.Show(string.Format("Delete Challan: Code {0} ?", selectedItem.Code), "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {

                    if (SSPurchaseOrdersLINQ.DeletePurDamChallan(selectedItem))
                    {
                        uiList.Remove(selectedItem);
                        challanGrid.DataContext = uiList;
                        this.DataContext = uiList;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCreateChallan_Click(object sender, RoutedEventArgs e)
        {
            window.mainFrame.Navigate(new CreatePurchaseDamChallan());
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            uiList = new ObservableCollection<SPEEDYDAL.PurchaseDamageChallan>(SSPurchaseOrdersLINQ.GetPurchaseDamChallans());
            challanGrid.DataContext = uiList;
        }
    }
}
