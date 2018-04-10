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
        public CreateSalesDelChallan()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            salesdcVM = new VMCreateSalesDelChallan();
            salesdcVM.SalesDeliveryChallan.Code = SSCommons.SSHelper.GenerateSystemCode();
            this.DataContext = salesdcVM;
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
            tbCTNTotal.Text = string.IsNullOrEmpty(tbCTNTotal.Text) ? Convert.ToString(row.CTN) : Convert.ToString(long.Parse(tbCTNTotal.Text) + row.CTN);
            tbPcsTotal.Text = string.IsNullOrEmpty(tbPcsTotal.Text) ? Convert.ToString(row.PC) : Convert.ToString(long.Parse(tbPcsTotal.Text) + row.PC);


        }
    }
}
