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
    /// Interaction logic for CreateSalesDelChallan.xaml
    /// </summary>
    public partial class CreateSalesDelChallan : Page
    {
        private VMCreateSalesDelChallan salesdcVM;
        string headerText = "";
        public CreateSalesDelChallan(SPEEDYDAL.SalesDeliveryChallan challan = null)
        {
            if (challan != null)
            {
                salesdcVM = new VMCreateSalesDelChallan();
                headerText = "EDIT SALES DELIVERY CHALLAN";
            }
            else
            {
                salesdcVM = new VMCreateSalesDelChallan();
                headerText = "CREATE SALES DELIVERY CHALLAN";
            }

            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            salesdcVM.SalesDeliveryChallan.Code = SSCommons.SSHelper.GenerateSystemCode();
            this.DataContext = salesdcVM;
            sOrderHeader.Text = headerText;
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SSDailySalesLINQ.CreateSalesDelChallan(salesdcVM);
                MessageBox.Show("Sales DC Created.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cmbSalesMan_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Salesman salesman = (Salesman)cmbSalesMan.SelectedValue;
            var dsrNumber = SSSalesManLINQ.isDSRCreated(salesman.sysSerial);
            salesdcVM.SalesDeliveryChallan.DSRNumber = dsrNumber;
            txtDSR.Text = dsrNumber.ToString();
            salesdcVM.SelectedSalesMan = salesman;
            salesdcVM.DailySale.SalesManID = salesman.sysSerial;
        }

        private void sOrderDetailGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {

        }

        private void salesDCDetailGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            SaleDCDetail row = (SaleDCDetail)e.Row.Item;
            var totalCTN = 0;
            var totalPcs = 0;
            foreach (var item in salesdcVM.SaleDCDetails)
            {
                totalCTN = totalCTN + item.CTN;
                totalPcs = (int)(totalPcs + item.PC != null ? item.PC : 0);
            }
            tbCTNTotal.Text = Convert.ToString(totalCTN);
            tbPcsTotal.Text = Convert.ToString(totalPcs);

        }
    }
}
