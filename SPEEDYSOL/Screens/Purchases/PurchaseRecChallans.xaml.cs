﻿using SPEEDYBLL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace SPEEDYSOL.Screens.Purchases
{
    /// <summary>
    /// Interaction logic for PurchaseRecChallans.xaml
    /// </summary>
    public partial class PurchaseRecChallans : Page
    {
        MainWindow window;
        ObservableCollection<SPEEDYDAL.PurchaseRecievingChallan> uiList;
        public PurchaseRecChallans(MainWindow _window)
        {
            window = _window;
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            uiList = new ObservableCollection<SPEEDYDAL.PurchaseRecievingChallan>(SSPurchaseOrdersLINQ.GetPurchaseRecChallans());
            challanGrid.DataContext = uiList;
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedItem = (SPEEDYDAL.PurchaseRecievingChallan)challanGrid.SelectedItem;
                window.mainFrame.Navigate(new CreatePurchaseRecChallan(selectedItem));
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
                var selectedItem = (SPEEDYDAL.PurchaseRecievingChallan)challanGrid.SelectedItem;
                var result = MessageBox.Show(string.Format("Delete Challan: Code {0} ?", selectedItem.Code), "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {

                    if (SSPurchaseOrdersLINQ.DeletePurRecChallan(selectedItem))
                    {
                        uiList.Remove(selectedItem);
                        challanGrid.DataContext = uiList;
                        this.DataContext = uiList;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCreateChallan_Click(object sender, RoutedEventArgs e)
        {
            window.mainFrame.Navigate(new CreatePurchaseRecChallan());
        }
    }
}
