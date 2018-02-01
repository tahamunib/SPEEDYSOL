using SPEEDYBLL;
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
using System.Windows.Shapes;
using SSCommons.Enums;
using System.Data;
using SPEEDYBLL.ViewModels.Purchase;

namespace SPEEDYSOL.Screens.Purchases
{
    /// <summary>
    /// Interaction logic for CreatePOrder.xaml
    /// </summary>
    public partial class CreatePOrder : Window
    {
        private VMPurchaseOrderDetail _viewModel;
        public CreatePOrder()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _viewModel = new VMPurchaseOrderDetail();
            this.DataContext = _viewModel;

            //pOrderDetailGrid.DataContext = viewModel.PurchaseOrderDetails;
            //pOrderDetailGrid.Items.Add(new SPEEDYDAL.PurchaseOrderDetail());

            //pOrderDetailGrid.DataContext = new List<String>();

            //#region Populating Comboboxes
            //cmbGodown.ItemsSource = SSGodownsLINQ.ListGodowns();
            //cmbGodown.DisplayMemberPath = "Name";
            //cmbGodown.SelectedValuePath = "sysSerial";
            //cmbGodown.SelectedIndex = 0;

            //cmbClient.ItemsSource = SSClientLINQ.GetClients();
            //cmbClient.DisplayMemberPath = "Name";
            //cmbClient.SelectedValuePath = "sysSerial";
            //cmbClient.SelectedIndex = 0;

            //cmbInvType.ItemsSource = Enum.GetValues(typeof(SSEnums.InvType)).Cast<SSEnums.InvType>();
            //cmbInvType.SelectedIndex = 0;

            //cmbPosted.ItemsSource = new List<string> { "Yes","No"};
            //cmbPosted.SelectedIndex = 0;

            //cmbItems.ItemsSource = SSItemsLINQ.GetItems();
            //cmbItems.DisplayMemberPath = "Name";
            //cmbItems.SelectedValuePath = "sysSerial";
            
            //#endregion
        }

        private void pOrderDetailGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = e.Row.GetIndex().ToString();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _viewModel.pOrder.Remarks = tbRemarks.Text;
                _viewModel.pOrder.TotalDiscountPercentage = Convert.ToInt32(tbDiscPerc.Text);
                _viewModel.pOrder.TotalExclTax = Convert.ToInt32(tbExclTax.Text);
                _viewModel.pOrder.TotalFlatDiscount = Convert.ToInt32(tbFlatDisc.Text);
                _viewModel.pOrder.TotalGST = Convert.ToInt32(tbGst.Text);
                _viewModel.pOrder.TotalInclTax = Convert.ToInt32(tbInclTax.Text);
                _viewModel.pOrder.TotalQty = Convert.ToInt32(tbQty.Text);
                _viewModel.pOrder.TotalQtyBonus = Convert.ToInt32(tbQtyBonus.Text);
                _viewModel.pOrder.TotalQtyPack = Convert.ToInt32(tbQtyPack.Text);
                _viewModel.pOrder.TotalQtyLoose = Convert.ToInt32(tbQtyLoose.Text);
                _viewModel.pOrder.GrandTotal = Convert.ToInt64(tbGrandTotal.Text);
                if (_viewModel.SelectedGodown != null && _viewModel.SelectedInvType != null && _viewModel.SelectedPosted != null && _viewModel.SelectedSSClient != null)
                {
                    if (_viewModel.PurchaseOrderDetails.Count > 0)
                    {
                        SSPurchaseOrdersLINQ.CreatePurchaseOrder(_viewModel);
                    }
                    else
                    {
                        MessageBox.Show("Please enter atleast one item for order.");
                    }
                }
                else
                {
                    MessageBox.Show("Please select required values for purchase order.");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void pOrderDetailGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {

        }

        //private void cmbItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    _viewModel.PurchaseOrderDetails.Add(new PurchaseOrderDetailVM());
        //}
    }
}
