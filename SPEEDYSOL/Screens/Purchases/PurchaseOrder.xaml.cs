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

namespace SPEEDYSOL.Screens.Purchases
{
    /// <summary>
    /// Interaction logic for PurchaseOrder.xaml
    /// </summary>
    public partial class PurchaseOrder : Page
    {
        MainWindow window;
        public PurchaseOrder(MainWindow _window)
        {
            window = _window;
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            purchaseOrderGrid.DataContext = SSPurchaseOrdersLINQ.GetPurchaseOrders();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        

        private void btnCreatePOrder_Click(object sender, RoutedEventArgs e)
        {
            CreatePOrder createPOrder = new CreatePOrder();
            createPOrder.Show();
            
        }

        private void DataGridHyperlinkColumn_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {

        }

        private void OrderID_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {

        }
    }
}
