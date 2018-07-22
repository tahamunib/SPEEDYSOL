using SPEEDYDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SSCommons.Enums.SSEnums;

namespace SPEEDYBLL
{
    public class SSVouchersLINQ
    {
        public static List<Vouchers> GetVouchers(VoucherType voucherType)
        {
            try
            {
                using (var ssContext = new SPEEDYSOLEntities())
                {
                    return ssContext.Vouchers.Include(nameof(SSAccounts)).Where(x => x.VoucherTypeID == (int)voucherType).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool SaveVoucher(ViewModels.Voucher.VMCreateVoucher vmVoucher)
        {
            try
            {
                var voucher = vmVoucher.Voucher;
                using (var ssContext = new SPEEDYSOLEntities())
                {
                    if (voucher.sysSerial > 0)
                    {
                        voucher.UpdatedOn = DateTime.UtcNow;
                        //ssContext.Entry(voucher).State = System.Data.Entity.EntityState.Modified;
                        //ssContext.SaveChanges();
                    }
                    else
                    {
                        HandleAccountTransactions(ssContext, vmVoucher.Voucher, vmVoucher.SelectedACHead, vmVoucher.SelectedAccount);
                        voucher.VoucherCode = SSCommons.SSHelper.GenerateSystemCode(nameof(Vouchers));
                        voucher.CreatedOn = DateTime.UtcNow;
                        voucher.AcHead = vmVoucher.SelectedACHead.sysSerial;
                        voucher.AccountID = vmVoucher.SelectedAccount.sysSerial;

                        ssContext.Vouchers.Add(voucher);
                        ssContext.SaveChanges();
                    }

                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        

        public static bool DeleteVoucher(Vouchers voucher)
        {
            try
            {
                using (var ssContext = new SPEEDYSOLEntities())
                {
                    if (voucher != null)
                    {
                        ssContext.Entry(voucher).State = System.Data.Entity.EntityState.Deleted;
                        ssContext.SaveChanges();
                        return true;
                    }
                    else
                        return false;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static bool HandleAccountTransactions(SPEEDYSOLEntities ssContext,Vouchers voucher, SSAccounts acHead,SSAccounts account)
        {
            bool transactionSuccess = false;
            try
            {
                if(acHead != null && account != null)
                {
                    switch (voucher.VoucherTypeID)
                    {
                        case (int)VoucherType.CashPayment:
                            acHead.Balance = acHead.Balance - voucher.Amount;
                            account.Balance = account.Balance + voucher.Amount;
                            break;
                        case (int)VoucherType.CashReciept:
                            acHead.Balance = acHead.Balance + voucher.Amount;
                            account.Balance = account.Balance - voucher.Amount;
                            break;
                        case (int)VoucherType.BankPayment:
                            acHead.Balance = acHead.Balance - voucher.Amount;
                            account.Balance = account.Balance + voucher.Amount;
                            break;
                        case (int)VoucherType.BankReciept:
                            acHead.Balance = acHead.Balance + voucher.Amount;
                            account.Balance = account.Balance - voucher.Amount;
                            break;
                        case (int)VoucherType.Journal:
                            acHead.Balance = acHead.Balance - voucher.Amount;
                            account.Balance = account.Balance + voucher.Amount;
                            break;
                    }
                    account.UpdatedOn = DateTime.UtcNow;
                    acHead.UpdatedOn = DateTime.UtcNow;
                    ssContext.Entry(acHead).State = System.Data.Entity.EntityState.Modified;
                    ssContext.Entry(account).State = System.Data.Entity.EntityState.Modified;
                    ssContext.SaveChanges();
                    transactionSuccess = true;
                }
                else
                {
                    transactionSuccess = false;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return transactionSuccess;
        }
    }
}
