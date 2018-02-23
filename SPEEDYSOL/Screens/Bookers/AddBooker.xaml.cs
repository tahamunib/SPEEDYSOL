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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SPEEDYSOL.Screens.Bookers
{
    /// <summary>
    /// Interaction logic for AddBooker.xaml
    /// </summary>
    public partial class AddBooker : Page
    {
        public SPEEDYDAL.OrderBooker _booker;
        public string _header = "ADD ORDER BOOKER";
        public string _btnText = "ADD";
        public AddBooker(SPEEDYDAL.OrderBooker booker = null)
        {
            if (booker != null)
            {
                _booker = booker;
                _header = "EDIT SALESMAN";
                _btnText = "SAVE";
            }
            else
            {

                _booker = new SPEEDYDAL.OrderBooker();
            }
            InitializeComponent();
        }

        private void btnAddItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SSOrderBookersLINQ.SaveBooker(_booker))
                    MessageBox.Show("Order Booker Saved!");
                else
                    MessageBox.Show("Error Occured: Could not save booker.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = _booker;
            this.header.Text = _header;
            this.btnAddItem.Content = _btnText;
        }
    }
}
