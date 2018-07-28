using SPEEDYBLL;
using SPEEDYBLL.ViewModels.Slips;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace SPEEDYSOL.Screens.Slips
{
    /// <summary>
    /// Interaction logic for CreateCashSlip.xaml
    /// </summary>
    public partial class CreateCashSlip : Page
    {
        VMCreateCashSlip VMCreateCashSlip;
        public CreateCashSlip()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void txtDSR_LostFocus(object sender, RoutedEventArgs e)
        {
            var textDSR = txtDSR.Text;
            if (textDSR.Length > 6 && Regex.Match(textDSR, @"^[a-zA-Z]{3}-[0-9]{5,}").Success)
            {
                VMCreateCashSlip = new VMCreateCashSlip();
                VMCreateCashSlip.DSRNumber = textDSR;
                this.DataContext = VMCreateCashSlip;
            }
        }

        private void btnCreateSlip_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SSSlipsLINQ.CreateCashSlip(VMCreateCashSlip))
                {
                    MessageBox.Show("Cash Slip Saved Successfully !", "SUCCESS", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Error saving Cash Slip", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CashDenomination_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            var totalCount = 0;
            long totalAmount = 0;
            foreach (var item in CashDenomination.Items)
            {
                var cashDetail = (CashDetail)item;
                totalCount = totalCount + cashDetail.Count;
                totalAmount = (long)(totalAmount + cashDetail.Amount);
            }
            txtCountTotal.Text = Convert.ToString(totalCount);
            txtAmountTotal.Text = Convert.ToString(totalAmount);

            VMCreateCashSlip.TotaCount = totalCount;
            VMCreateCashSlip.TotalAmount = totalAmount;

        }
    }
}
