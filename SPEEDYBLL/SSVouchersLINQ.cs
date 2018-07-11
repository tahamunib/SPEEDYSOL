﻿using SPEEDYDAL;
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
                        HandleAccountTransactions(ssContext, voucher);
                        voucher.VoucherCode = GenerateUniqueVoucherCode();
                        voucher.CreatedOn = DateTime.UtcNow;

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
        private static string GenerateUniqueVoucherCode()
        {
            var voucherCOde = string.Format("{0}", Guid.NewGuid().ToString());
            return voucherCOde;
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

        private static bool HandleAccountTransactions(SPEEDYSOLEntities ssContext,Vouchers voucher)
        {
            bool transactionSuccess = false;
            try
            {
                var acHead = ssContext.SSAccounts.Where(x => x.sysSerial == voucher.AcHead).FirstOrDefault();
                var account = ssContext.SSAccounts.Where(x => x.sysSerial == voucher.AccountID).FirstOrDefault();

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
                    }
                    account.UpdatedOn = DateTime.UtcNow;
                    acHead.UpdatedOn = DateTime.UtcNow;
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
