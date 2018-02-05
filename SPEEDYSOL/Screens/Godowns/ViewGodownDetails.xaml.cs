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
using SPEEDYBLL;

namespace SPEEDYSOL.Screens.Godowns
{
    /// <summary>
    /// Interaction logic for ViewGodownDetails.xaml
    /// </summary>
    public partial class ViewGodownDetails : Page
    {
        private static SPEEDYDAL.Godown _godown;
        public ViewGodownDetails(SPEEDYDAL.Godown godown)
        {
            _godown = godown;
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            godownDetailsGrid.DataContext = _godown.GodownItems;
        }

        
    }
}
