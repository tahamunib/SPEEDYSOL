using SPEEDYBLL;
using SPEEDYBLL.ViewModels.Purchase;
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

namespace SPEEDYSOL.Screens.Purchases
{
    /// <summary>
    /// Interaction logic for CreatePurRetChallan.xaml
    /// </summary>
    public partial class CreatePurRetChallan : Page
    {
        private VMCreatePurchaseRetChallan purchaseRCVM;
        public CreatePurRetChallan()
        {
            InitializeComponent();
        }

        private void cmbVendor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void purchaseRetCDetailGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            PurchaseRCDetail row = (PurchaseRCDetail)e.Row.Item;
            var totalCTN = 0;
            var totalPcs = 0;
            foreach (var item in purchaseRCVM.PurchaseRCDetails)
            {
                totalCTN = totalCTN + item.CTN;
                totalPcs = (int)(totalPcs + item.PC != null ? item.PC : 0);
            }
            tbCTNTotal.Text = Convert.ToString(totalCTN);
            tbPcsTotal.Text = Convert.ToString(totalPcs);
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SSPurchaseOrdersLINQ.CreatePurRetChallan(purchaseRCVM);
                MessageBox.Show("Purchase Return Challan Created.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            purchaseRCVM = new VMCreatePurchaseRetChallan();
            purchaseRCVM.PurchaseReturnChallan.Code = SSCommons.SSHelper.GenerateSystemCode();
            this.DataContext = purchaseRCVM;
        }

        
    }
}
