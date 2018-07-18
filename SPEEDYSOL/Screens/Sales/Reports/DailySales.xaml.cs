using SPEEDYBLL.ViewModels.Sale.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace SPEEDYSOL.Screens.Sales.Reports
{
    /// <summary>
    /// Interaction logic for DailySales.xaml
    /// </summary>
    public partial class DailySales : Page
    {
        VMDailySalesReport report;
        public DailySales()
        {
            
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //this.DataContext = report;
        }

        private void IssueDetail_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {

        }

        private void ReturnDetail_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {

        }

        private void txtDSR_TextChanged(object sender, TextChangedEventArgs e)
        {
            //var textDSR = txtDSR.Text;
            //if(textDSR.Length > 6 && Regex.Match(textDSR, @"^[a-zA-Z]{3}-[0-9]{5,}").Success)
            //{
            //    report = new VMDailySalesReport(textDSR);
            //}
            //this.DataContext = report;
        }
    }
}
