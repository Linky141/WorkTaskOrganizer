using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WorkTaskOrganizer
{
    public class WorkProjectPrerioid
    {
        public WorkProjectPrerioid()
        {
            this.startWork = DateTime.MinValue;
            this.endWork = DateTime.MinValue;
        }



        public DateTime startWork { get; set; }
        public DateTime endWork { get; set; }


        public int getPrerioidHours()
        {
            int timePreriod = 0;
            try
            {
                TimeSpan ts = endWork - startWork;
                timePreriod = ts.Hours;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
                timePreriod = 0;
            }
            return timePreriod;
        }

        public int getPrerioidMins()
        {
            int timePreriod = 0;
            try
            {
                TimeSpan ts = endWork - startWork;
                timePreriod = ts.Minutes;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
                timePreriod = 0;
            }
            return timePreriod;
        }

        public bool CheckCompletePrerioid()
        {
            if (!startWork.Equals(DateTime.MinValue) && !endWork.Equals(DateTime.MinValue)) return true;
            else return false;
        }

        public override string ToString()
        {
            string date = startWork.ToString("dd-MM-yyyy");
            string time1 = "";
            string time2 = "";

            if (!startWork.Equals(DateTime.MinValue))
                time1 = startWork.Hour.ToString() + ":" + startWork.Minute.ToString();
            else
                time1 = "--:--";

            if (!endWork.Equals(DateTime.MinValue))
                time2 = endWork.Hour.ToString() + ":" + endWork.Minute.ToString();
            else
                time2 = "--:--";

            string timePreriod = "";
            if (!startWork.Equals(DateTime.MinValue) && !endWork.Equals(DateTime.MinValue))
            {
                try
                {
                    TimeSpan ts = endWork - startWork;
                    timePreriod = " (" + ts.Hours.ToString() + "h" + ts.Minutes.ToString() + "m)";
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message);
                    timePreriod = " (ERR)";
                }
            }
            else
                timePreriod = " (--h--m)";

            return date +": "+ time1 + " - " + time2 + timePreriod;
        }
    }
}
