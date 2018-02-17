using SPEEDYBLL.ViewModels.Sale;
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

namespace SPEEDYSOL.Screens.Sales
{
    /// <summary>
    /// Interaction logic for CreateOrder_Sales.xaml
    /// </summary>
    public partial class CreateOrder_Sales : Window
    {
        private VMSaleOrderDetail _viewModel;
        public CreateOrder_Sales()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _viewModel = new VMSaleOrderDetail();
            this.DataContext = _viewModel;
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {

        }

        private void sOrderDetailGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {

        }
    }
}
