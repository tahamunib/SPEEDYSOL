using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SPEEDYBLL.ViewModels.Slips
{
    public class VMCreateCashSlip
    {
        public VMCreateCashSlip()
        {
            _cashDetails = new ObservableCollection<Slips.CashDetail>();
            for(int i = 0; i < 10; i++)
            {
                int denomination = 0;
                switch (i)
                {
                    case 0:
                        denomination = 5000;
                        break;
                    case 1:
                        denomination = 1000;
                        break;
                    case 2:
                        denomination = 500;
                        break;
                    case 3:
                        denomination = 100;
                        break;
                    case 4:
                        denomination = 50;
                        break;
                    case 5:
                        denomination = 20;
                        break;
                    case 6:
                        denomination = 10;
                        break;
                    case 7:
                        denomination = 5;
                        break;
                    case 8:
                        denomination = 2;
                        break;
                    case 9:
                        denomination = 1;
                        break;
                }
                CashDetail cashDen = new Slips.CashDetail();
                cashDen.Denomination = denomination;
                _cashDetails.Add(cashDen);
            }
            
        }
        private string _dsrNumber;
        public string DSRNumber { get { return _dsrNumber; } set { _dsrNumber = value; } }
        private ObservableCollection<CashDetail> _cashDetails;
        public ObservableCollection<CashDetail> CashDetails { get { return _cashDetails; } set { _cashDetails = value; } }
        private long _totalCount;
        public long TotaCount { get { return _totalCount; } set { _totalCount = value; } }
        private long _totalAmount;
        public long TotalAmount { get { return _totalAmount; } set { _totalAmount = value; } }

        //private void UpdateTotal()
        //{
        //    this._cashDetails
        //}

    }
    public class CashDetail : INotifyPropertyChanged
    {
        private int _denomination;
        public int Denomination { get { return _denomination; } set { _denomination = value; } }
        private int _count;
        public int Count {
            get { return _count; }
            set {
                _count = value;
                _amount = _count * Convert.ToInt32(_denomination);
                NotifyPropertyChanged("Amount");
            }
        }
        private long _amount;
        public long Amount {
            get
            { return _amount; }
            set
            { _amount = value; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        

    }

    
}
