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
        #region VARIABLES

        public DateTime dateWork { get; set; }
        public DateTime startWork { get; set; }
        public DateTime endWork { get; set; }

        public bool startWorkHourHasValue;
        public bool startWorkMinsHasValue;
        public bool endWorkHourHasValue;
        public bool endWorkMinsHasValue;

        #endregion

        #region CONSTRUCTOR

        public WorkProjectPrerioid()
        {
            this.dateWork = DateTime.MinValue;
            this.startWork = DateTime.MinValue;
            this.endWork = DateTime.MinValue;

            this.startWorkHourHasValue = false;
            this.startWorkMinsHasValue = false;
            this.endWorkHourHasValue = false;
            this.endWorkMinsHasValue = false;
        }

        #endregion

        #region METHODS

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
                CustomMessageBox.Show(CustomMesageBoxTypes.Error, exc.Message);
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
                CustomMessageBox.Show(CustomMesageBoxTypes.Error, exc.Message);
                timePreriod = 0;
            }
            return timePreriod;
        }

        public bool CheckCompletePrerioid()
        {
            if (!startWork.Equals(DateTime.MinValue) && !endWork.Equals(DateTime.MinValue)) return true;
            else return false;
        }

        public bool CheckPrerioidHasValue()
        {
            if (!startWork.Equals(DateTime.MinValue) || !endWork.Equals(DateTime.MinValue)) return true;
            else return false;
        }

        public override string ToString()
        {
            string date = dateWork.ToString("dd-MM-yyyy");
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
                    CustomMessageBox.Show(CustomMesageBoxTypes.Error, exc.Message);
                    timePreriod = " (ERR)";
                }
            }
            else
                timePreriod = " (--h--m)";

            return date +": "+ time1 + " - " + time2 + timePreriod;
        }

        #region GET/SET

        public void SetStartDate(DateTime date)
        {
            this.startWork = date;
                this.startWorkHourHasValue = true;
                this.startWorkMinsHasValue = true;

        }

        public void ClearStartDate()
        {
            this.startWork = new DateTime();
            this.startWorkHourHasValue = false;
            this.startWorkMinsHasValue = false;
        }

        public void SetEndDate(DateTime date)
        {
            this.endWork = date;
                this.endWorkHourHasValue = true;
                this.endWorkMinsHasValue = true;
        }

        public void ClearEndDate()
        {
            this.endWork = new DateTime();
            this.endWorkHourHasValue = false;
            this.endWorkMinsHasValue = false;
        }

        public void SetWorkDate(DateTime date)
        {
            this.dateWork = date;
        }

        public DateTime GetStartDate()
        {
            return this.startWork;
        }

        public DateTime GetEndDate()
        {
            return this.endWork;
        }

        public DateTime GetDate()
        {
            return this.dateWork;
        }

        public bool GetStartWorkHourHasValue()
        {
            return startWorkHourHasValue;
        }

        public bool GetStartWorkMinsHasValue()
        {
            return startWorkMinsHasValue;
        }

        public bool GetEndWorkHourHasValue()
        {
            return endWorkHourHasValue;
        }

        public bool GetEndWorkMinsHasValue()
        {
            return endWorkMinsHasValue;
        }

        #endregion

        #endregion
    }
}
