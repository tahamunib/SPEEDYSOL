using SPEEDYBLL;
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

namespace SPEEDYSOL.Screens.Godowns
{
    /// <summary>
    /// Interaction logic for Create_Godown.xaml
    /// </summary>
    public partial class Create_Godown : Page
    {
        MainWindow window;
        static Godown _godown;
        public Create_Godown(MainWindow _window)
        {
            window = _window;
            if (!window.mainFrame.CanGoBack)
            {
                window.btnBack.Visibility = Visibility.Hidden;
            }
            else
            {
                window.btnBack.Visibility = Visibility.Visible;
            }
            InitializeComponent();
            
        }

        public Create_Godown(Godown godown)
        {
            InitializeComponent();
            txtGodown.Text = godown.Name;
            _godown = godown;
            btnAddGodown.Content = "Update";
        }

        
        private void btnAddGodown_Click(object sender, RoutedEventArgs e)
        {
            string message = "";
            try
            {
                var godownName = txtGodown.Text;
                
                if (string.IsNullOrEmpty(godownName))
                    message = "Godown name is empty, please specify a name.";
                else
                {
                    if (SSGodownsLINQ.isGodownExists(godownName))
                    {
                        message = "Godown already exists with this name, please enter a new name.";
                    }
                    else
                    {
                        if (btnAddGodown.Content.ToString() == "Update")
                        {
                            SSGodownsLINQ.UpdateGodown(_godown.sysSerial, godownName);
                            message = "Godown Updated.";
                        }
                        else
                        {
                            SSGodownsLINQ.AddGodown(godownName);
                            message = "Godown Added Successfully.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }

            MessageBox.Show(message);
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            window.mainFrame.NavigationService.GoBack();
        }
    }
}
