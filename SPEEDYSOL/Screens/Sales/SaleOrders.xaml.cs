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
    /// Interaction logic for SaleOrders.xaml
    /// </summary>
    public partial class SaleOrders : Page
    {
        MainWindow window;
        public SaleOrders(MainWindow _window)
        {
            window = _window;
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            saleOrderGrid.DataContext = SPEEDYBLL.SSSalesManLINQ.GetSalesMen();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCreateSOrder_Click(object sender, RoutedEventArgs e)
        {
            CreateOrder_Sales createSOrder = new CreateOrder_Sales();
            createSOrder.Show();
        }
    }
}
