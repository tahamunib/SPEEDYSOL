using SPEEDYBLL;
using SPEEDYBLL.ViewModels.Sale;
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

namespace SPEEDYSOL.Screens.Sales
{
    /// <summary>
    /// Interaction logic for CreateSalesRetChallan.xaml
    /// </summary>
    public partial class CreateSalesRetChallan : Page
    {
        private VMCreateSalesRetChallan salesrcVM;
        string headerText = "";
        public CreateSalesRetChallan(SPEEDYDAL.SalesReturnChallan challan = null)
        {
            if (challan != null)
            {
                salesrcVM = new VMCreateSalesRetChallan();
                headerText = "EDIT SALES RETURN CHALLAN";
            }
            else
            {
                salesrcVM = new VMCreateSalesRetChallan();
                headerText = "CREATE SALES RETURN CHALLAN";
            }
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            
            salesrcVM.SalesReturnChallan.Code = salesrcVM.SalesReturnChallan.Code != null ? salesrcVM.SalesReturnChallan.Code : SSCommons.SSHelper.GenerateSystemCode();
            this.DataContext = salesrcVM;
            sOrderHeader.Text = headerText;
        }

        
        private void salesRCDetailGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            SaleRCDetail row = (SaleRCDetail)e.Row.Item;
            var totalCTN = 0;
            var totalPcs = 0;
            foreach (var item in salesrcVM.SaleRCDetails)
            {
                totalCTN = totalCTN + item.CTN;
                totalPcs = (int)(totalPcs + item.PC != null ? item.PC : 0);
            }
            tbCTNTotal.Text = Convert.ToString(totalCTN);
            tbPcsTotal.Text = Convert.ToString(totalPcs);
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SSDailySalesLINQ.CreateSalesRetChallan(salesrcVM);
                MessageBox.Show("Sales RC Created.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                
            }
        }

        private void cmbSalesMan_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Salesman salesman = (Salesman)cmbSalesMan.SelectedValue;
            var dsrNumber = SSSalesManLINQ.isDSRCreated(salesman.sysSerial,salesman.DSRCode);
            salesrcVM.DailySale.DSRNumber = dsrNumber;
            txtDSR.Text = dsrNumber.ToString();
            salesrcVM.SelectedSalesMan = salesman;
            salesrcVM.DailySale.SalesManID = salesman.sysSerial;
        }
    }
}
