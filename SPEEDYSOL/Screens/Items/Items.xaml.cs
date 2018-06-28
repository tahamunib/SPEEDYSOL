using SPEEDYBLL;
using SPEEDYBLL.ViewModels.Item;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace SPEEDYSOL.Screens.Items
{
    /// <summary>
    /// Interaction logic for Items.xaml
    /// </summary>
    public partial class Items : Page
    {
        MainWindow window;
        VMItems vmItems;
        BackgroundWorker worker = new BackgroundWorker();
        public Items(MainWindow _window)
        {
            window = _window;
            InitializeComponent();
            
            worker.DoWork += do_work;
            worker.RunWorkerCompleted += work_completed;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            worker.RunWorkerAsync();
            
        }

        private void do_work(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            vmItems = new VMItems();
            
            
        }

        private void work_completed(object sender, RunWorkerCompletedEventArgs e)
        {
            this.DataContext = vmItems;
            loadingIcon.Visibility = Visibility.Hidden;
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedItem = (SPEEDYDAL.Items)itemsGrid.SelectedItem;
                VMCreateItem item = new VMCreateItem();
                item.Item = selectedItem;
                window.mainFrame.Navigate(new AddItem(item));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var result = MessageBox.Show("Delete Item? This will delete item from Purchase, Sales Order and Godwon Items.", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    var selectedItem = (SPEEDYDAL.Items)itemsGrid.SelectedItem;
                    if (SSItemsLINQ.DeleteItem(selectedItem))
                    {
                        vmItems.Items.Remove(selectedItem);
                        this.DataContext = vmItems;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void itemsGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "sysSerial":
                    e.Cancel = true;
                    break;
                case "Name":
                    e.Column.DisplayIndex = 0;
                    break;
                case "PurchasePrice":
                    e.Column.DisplayIndex = 1;
                    e.Column.Width = 60;
                    e.Column.Header = "Purchase Price";
                    break;
                case "SalePrice":
                    e.Column.DisplayIndex = 2;
                    e.Column.Width = 50;
                    e.Column.Header = "Sale Price";
                    
                    break;
                case "Manufacturer":
                    e.Column.DisplayIndex = 3;
                    break;
                case "Remarks":
                    e.Column.DisplayIndex = 4;
                    break;
                case "PackUnit":
                    e.Column.DisplayIndex = 5;
                    e.Column.Width = 45;
                    e.Column.Header = "Pack Unit";
                    break;
                case "RecentPurchase":
                    e.Column.DisplayIndex = 6;
                    e.Column.Width = 60;
                    e.Column.Header = "Recent Purchase";
                    break;
                case "UnitWeight":
                    e.Column.DisplayIndex = 7;
                    e.Column.Width = 55;
                    e.Column.Header = "Unit Weight";

                    break;
                case "CreatedOn":
                    e.Column.DisplayIndex = 8;
                    break;
                case "UpdatedOn":
                    e.Column.DisplayIndex = 9;
                    break;
                case "PurchaseOrderDetails":
                    e.Cancel = true;
                    break;
                case "SaleOrderDetails":
                    e.Cancel = true;
                    break;
                case "GodownItems":
                    e.Cancel = true;
                    break;

            }
        }

        private void itemsGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {

        }

        private void itemsGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            switch (e.Column.DisplayIndex)
            {
                case 4:
                    break;
            }
        }

        private void btnAddItem_Click(object sender, RoutedEventArgs e)
        {
            window.mainFrame.Navigate(new Screens.Items.AddItem());
        }
    }
}
