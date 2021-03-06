﻿using SPEEDYBLL;
using SPEEDYSOL.Screens;
using SPEEDYSOL.Screens.Accounts;
using SPEEDYSOL.Screens.Bookers;
using SPEEDYSOL.Screens.Items;
using SPEEDYSOL.Screens.Purchases;
using SPEEDYSOL.Screens.Sales;
using SPEEDYSOL.Screens.SalesMen;
using SPEEDYSOL.Screens.Vendor;
using SSCommons.Enums;
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

namespace SPEEDYSOL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static SPEEDYDAL.SSUsers currentlyLoggedInUser;
        
        public MainWindow()
        {
            InitializeComponent();
            windowButtons.Visibility = Visibility.Hidden;
            mainMenu.Visibility = Visibility.Hidden;
            date.Content = DateTime.UtcNow.Date.ToString("MM/dd/yyyy");
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            
            string username = txtbxUsername.Text;
            string password = txtbxPassword.Password;
            currentlyLoggedInUser = SSUsersLINQ.AuthenticateUser(username, password);
            if (currentlyLoggedInUser != null)
            {
                mainFrame.Navigate(new Screens.Dashboard(this));
                mainMenu.Visibility = Visibility.Visible;

            }
            else
            {
                MessageBox.Show(this, "User cannot be authenticated, credentials not correct !", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Main_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                mainFrame.GoBack();
            }
            catch
            {
                MessageBox.Show("Cant navigate backwards.");
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void MI_BankPay_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new Screens.Vouchers.Vouchers(this, SSEnums.VoucherType.BankPayment));
        }

        private void MI_BankRec_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new Screens.Vouchers.Vouchers(this, SSEnums.VoucherType.BankReciept));
        }

        private void MI_CashPay_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new Screens.Vouchers.Vouchers(this,SSEnums.VoucherType.CashPayment));
        }

        private void MI_CashRec_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new Screens.Vouchers.Vouchers(this, SSEnums.VoucherType.CashReciept));
        }

        private void MI_PurInv_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new PurchaseOrder(this));
        }

        private void MI_PurDamC_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MI_PurRetC_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new PurchaseRetChallans(this));
        }

        private void MI_PurRecC_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new PurchaseRecChallans(this));
        }

        private void MI_SalesInv_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new Screens.Sales.Reports.DailySales());
        }

        private void MI_SalesDamC_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new CreateSalesDamChallan());
        }

        private void MI_SalesRC_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new SalesRetChallans(this));
        }

        private void MI_SalesDC_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new SalesDelChallans(this));
        }

        private void MI_Accounts_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new Accounts(this));
        }

        private void MI_AccGrp_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new AccGroups(this));
        }

        private void MI_AccCat_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new AccCategories(this));
        }

        private void MI_Items_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new Items(this));
        }

        private void MI_ItemsGrp_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new ItemGroups(this));
        }

        private void MI_Godowns_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new Screens.Godowns.GodownList(this));
        }

        private void MI_ItemsMfc_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new ItemManufacturers(this));
        }

        private void MI_ItemsBrand_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new ItemBrands(this));
        }

        private void MI_Salesmen_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new SalesMen(this));
        }

        private void MI_Booker_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new Bookers(this));
        }

        private void MI_Vendors_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new Vendors(this));
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MI_Journal_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new Screens.Vouchers.Vouchers(this, SSEnums.VoucherType.Journal));
        }

        private void MI_Slips_Cash_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new Screens.Slips.CreateCashSlip());
        }

        private void MI_Slips_Cheque_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MI_Slips_Credit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MI_Slips_Recovery_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
