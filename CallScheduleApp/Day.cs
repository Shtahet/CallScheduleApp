using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallScheduleApp
{
    class Day
    {
        private DateTime _d;

        public Day(DateTime date)
        {
            _d = date;
        }

        public int NumDay => _d.Day;

    }
}
