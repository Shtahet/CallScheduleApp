using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallScheduleApp
{
    class ComboItem
    {
        public ComboItem(int id, string name)
        {
            Id = id;
            DisplayName = name;
        }
        public int Id { get; set; }
        public string DisplayName { get; set; }
    }
}
