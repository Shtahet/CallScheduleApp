using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CallScheduleApp
{
    class Day:INotifyPropertyChanged
    {
        private DateTime _d;
        private bool _isWorkDay;
        private bool _isCurrDay;
        private bool _isCurrMonth;

        public int NumDay => _d.Day;

        public bool IsWorkingDay
        {
            get { return _isWorkDay; }
            set
            {
                _isWorkDay = value;
                OnPropertyChanged();
            }
        }

        public bool IsCurrentDay
        {
            get { return _isCurrDay; }
            set
            {
                _isCurrDay = value;
                OnPropertyChanged();
            }
        }

        public bool IsCurrentMonth
        {
            get { return _isCurrMonth; }
            set
            {
                _isCurrMonth = value;
                OnPropertyChanged();
            }
        }

        public DateTime Date {
            get { return _d; }
            set { _d = value;
                OnPropertyChanged("NumDay");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
