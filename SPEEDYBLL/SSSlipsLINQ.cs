using SPEEDYBLL.ViewModels.Slips;
using SPEEDYDAL;
using SSCommons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPEEDYBLL
{
    public class SSSlipsLINQ
    {
        public static bool CreateCashSlip(VMCreateCashSlip cashSlip)
        {
            try
            {
                using (var ssContext = new SPEEDYSOLEntities())
                {
                    SPEEDYDAL.CashSlip slip = new CashSlip();
                    slip.Amount = cashSlip.TotalAmount;
                    slip.Code = SSHelper.GenerateSystemCode(nameof(CashSlip));
                    slip.CreatedOn = DateTime.UtcNow.Date;
                    slip.DSRNumber = SSDailySalesLINQ.GetDSRID(cashSlip.DSRNumber);
                    foreach(var den in cashSlip.CashDetails)
                    {
                        switch (den.Denomination)
                        {
                            case 5000:
                                slip.Den5000 = den.Count;
                                break;
                            case 500:
                                slip.Den500 = den.Count;
                                break;
                            case 50:
                                slip.Den50 = den.Count;
                                break;
                            case 5:
                                slip.Den5 = den.Count;
                                break;
                            case 20:
                                slip.Den20 = den.Count;
                                break;
                            case 2:
                                slip.Den2 = den.Count;
                                break;
                            case 1:
                                slip.Den1 = den.Count;
                                break;
                            case 1000:
                                slip.Den1000 = den.Count;
                                break;
                            case 100:
                                slip.Den100 = den.Count;
                                break;
                            case 10:
                                slip.Den10 = den.Count;
                                break;
                            
                        }
                    }
                    ssContext.CashSlip.Add(slip);
                    return ssContext.SaveChanges() > 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
