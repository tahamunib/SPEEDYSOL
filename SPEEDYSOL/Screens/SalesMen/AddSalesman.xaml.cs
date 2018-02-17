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

namespace SPEEDYSOL.Screens.SalesMen
{
    /// <summary>
    /// Interaction logic for AddSalesman.xaml
    /// </summary>
    public partial class AddSalesman : Page
    {
        public SPEEDYDAL.Salesman _salesman;
        public string _header = "ADD SALESMAN";
        public AddSalesman(SPEEDYDAL.Salesman salesman = null)
        {
            if (salesman != null)
            {
                _salesman = salesman;
                _header = "EDIT SALESMAN";
            }
            else
            {

                _salesman = new SPEEDYDAL.Salesman();
            }
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = _salesman;
            this.header.Text = _header;
        }

        private void btnAddItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SSSalesManLINQ.SaveSalesman(_salesman))
                    MessageBox.Show("Salesman Saved!");
                else
                    MessageBox.Show("Error Ocuured: Could not save salesman.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
