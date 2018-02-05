using Newtonsoft.Json;
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

namespace SPEEDYSOL.Screens.Godowns
{
    /// <summary>
    /// Interaction logic for GodownList.xaml
    /// </summary>
    public partial class GodownList : Page
    {
        MainWindow window;

        private static SPEEDYDAL.Godown godownObj;
        public GodownList(MainWindow _window)
        {
            window = _window;
            InitializeComponent();
            
        }
        
        private void btnAddGodown_Click(object sender, RoutedEventArgs e)
        {
            window.mainFrame.Navigate(new Screens.Godowns.Create_Godown(window));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            godownGrid.DataContext = SSGodownsLINQ.ListGodowns().Select(x=> new {x.Name,x.CreatedOn,x.UpdatedOn });
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            var godownToUpdate = SSGodownsLINQ.GetGodownByName(godownObj.Name);
            window.mainFrame.Navigate(new Screens.Godowns.Create_Godown(godownToUpdate));
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            string message = "";
            try
            {
                var godownToDel = SSGodownsLINQ.GetGodownByName(godownObj.Name);
                var isDel = SSGodownsLINQ.DeleteGodown(godownToDel.sysSerial);
                if (isDel)
                {
                    godownGrid.DataContext = SSGodownsLINQ.ListGodowns().Select(x => new { x.Name, x.CreatedOn, x.UpdatedOn });
                    message = "Godown Deleted.";
                }
                else
                {
                    message = "Godown cannot be found in database.";
                }
            }
            catch(Exception ex)
            {
                message = ex.Message;
            }

            MessageBox.Show(message);

        }

        private void godownGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var obj = JsonConvert.SerializeObject(godownGrid.SelectedItem);
            
            godownObj = JsonConvert.DeserializeObject<SPEEDYDAL.Godown>(obj);
        }

        private void godownGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "sysSerial":
                    e.Cancel = true;
                    break;
                case "Name":
                    e.Column.DisplayIndex = 0;
                    break;
                case "CreatedOn":
                    e.Column.DisplayIndex = 1;
                    break;
                case "UpdatedOn":
                    e.Column.DisplayIndex = 2;
                    break;
                
            }
        }

        private void btnViewDetails_Click(object sender, RoutedEventArgs e)
        {
            var selectedGodown = SSGodownsLINQ.GetGodownByName(godownObj.Name);
            window.mainFrame.Navigate(new Screens.Godowns.ViewGodownDetails(selectedGodown));
        }
    }
}
