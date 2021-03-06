﻿using SPEEDYBLL;
using SPEEDYBLL.ViewModels.Voucher;
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

namespace SPEEDYSOL.Screens.Vouchers
{
    /// <summary>
    /// Interaction logic for CreateVoucher.xaml
    /// </summary>
    public partial class CreateVoucher : Page
    {
        VMCreateVoucher vmVoucher;
        string _header = "";
        int _Visibilty = 0;
        string message = "";
        public CreateVoucher(SSCommons.Enums.SSEnums.VoucherType voucherType,SPEEDYDAL.Vouchers _voucher = null)
        {
            if (_voucher != null)
            {   
                _header = "EDIT " + voucherType.ToString().Insert(4," ").ToUpper() + " VOUCHER";
                _Visibilty = (int)Visibility.Visible;
                message = "Voucher Saved";
            }
            else
            {
                _Visibilty = (int)Visibility.Hidden;
                _header = "ISSUE " + voucherType.ToString().Insert(4, " ").ToUpper() + " VOUCHER";
                message = "Voucher Saved";
            }
            vmVoucher = new VMCreateVoucher(voucherType, _voucher);
            InitializeComponent();
        }

        private void btnCreateVoucher_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SSVouchersLINQ.SaveVoucher(vmVoucher))
                    MessageBox.Show(message,"Confirmation",MessageBoxButton.OK);
                else
                    MessageBox.Show("Error Occured: Could not save voucher.","ERROR",MessageBoxButton.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = vmVoucher;
            this.header.Text = _header;
            var visibilityEnumVal = (Visibility)Enum.Parse(typeof(Visibility), Convert.ToString(_Visibilty));
            this.lblVoucherCode.Visibility = visibilityEnumVal;
            this.txtVoucherCode.Visibility = visibilityEnumVal;
            //this.cmbAccounts.DataContext = SSAccountsLINQ.GetAccounts();
            //if (_Visibilty == 0)
            //    this.cmbAccounts.SelectedValue = Voucher.AccountID;
        }

        

        private void cmbAccounts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if(cmbAccounts.SelectedValue != null)
            //    Voucher.AccountID = (long)cmbAccounts.SelectedValue;
        }
    }
}
