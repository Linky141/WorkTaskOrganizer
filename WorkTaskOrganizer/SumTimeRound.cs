using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkTaskOrganizer
{
    class SumTimeRound
    {
        int min=0;
        public void AddMin(int val) { this.min += val; }
        public void AddHour(int val) { this.min += (val*60); }

        public int getDays()
        {
            return (int)(min / 60) / 8;
        }

        public int getHours()
        {
            int days = (int)(min / 60) / 8;
            return (int)((min / 60) - (days*8)); 
        }

        public int getMins()
        {
            int hours = (int)min / 60;
            return (int)(min - (hours*60));
        }


    }
}
