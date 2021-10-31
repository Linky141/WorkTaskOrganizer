using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WorkTaskOrganizer
{
    /// <summary>
    /// Logika interakcji dla klasy WorkTimeWindow.xaml
    /// </summary>
    public partial class WorkTimeWindow : Window
    {
        #region VARIABLES

        public WorkProjectPrerioid prerioid = new WorkProjectPrerioid();
        public bool ApplyChanges = false;

        #endregion

        #region CONSTRUCTOR

        public WorkTimeWindow()
        {
            InitializeComponent();
            FillAllHourListBox();
            SetActualDate();
            MakeWorkindTimeDescription();
        }

        public WorkTimeWindow(WorkProjectPrerioid wpp)
        {
            InitializeComponent();
            FillAllHourListBox();

            calStartWork.SelectedDate = wpp.GetDate().Date;

            if (CheckStartValueContainsValue(wpp))
            {
                lbxStartHour.SelectedIndex = wpp.GetStartDate().Hour;
                int sm = wpp.GetStartDate().Minute;
                if (sm.Equals(0)) lbxStartMinute.SelectedIndex = 0;
                else if (sm.Equals(5)) lbxStartMinute.SelectedIndex = 1;
                else if (sm.Equals(10)) lbxStartMinute.SelectedIndex = 2;
                else if (sm.Equals(15)) lbxStartMinute.SelectedIndex = 3;
                else if (sm.Equals(20)) lbxStartMinute.SelectedIndex = 4;
                else if (sm.Equals(25)) lbxStartMinute.SelectedIndex = 5;
                else if (sm.Equals(30)) lbxStartMinute.SelectedIndex = 6;
                else if (sm.Equals(35)) lbxStartMinute.SelectedIndex = 7;
                else if (sm.Equals(40)) lbxStartMinute.SelectedIndex = 8;
                else if (sm.Equals(45)) lbxStartMinute.SelectedIndex = 9;
                else if (sm.Equals(50)) lbxStartMinute.SelectedIndex = 10;
                else if (sm.Equals(55)) lbxStartMinute.SelectedIndex = 11;
            }

            if (CheckEndValueContainsValue(wpp))
            {
                lbxEndHour.SelectedIndex = wpp.GetEndDate().Hour;
                int em = wpp.GetEndDate().Minute;
                if (em.Equals(0)) lbxEndMinute.SelectedIndex = 0;
                else if (em.Equals(5)) lbxEndMinute.SelectedIndex = 1;
                else if (em.Equals(10)) lbxEndMinute.SelectedIndex = 2;
                else if (em.Equals(15)) lbxEndMinute.SelectedIndex = 3;
                else if (em.Equals(20)) lbxEndMinute.SelectedIndex = 4;
                else if (em.Equals(25)) lbxEndMinute.SelectedIndex = 5;
                else if (em.Equals(30)) lbxEndMinute.SelectedIndex = 6;
                else if (em.Equals(35)) lbxEndMinute.SelectedIndex = 7;
                else if (em.Equals(40)) lbxEndMinute.SelectedIndex = 8;
                else if (em.Equals(45)) lbxEndMinute.SelectedIndex = 9;
                else if (em.Equals(50)) lbxEndMinute.SelectedIndex = 10;
                else if (em.Equals(55)) lbxEndMinute.SelectedIndex = 11;
            }

            MakeWorkindTimeDescription();

        
        }

        #endregion

        #region METHODS

        private void FillAllHourListBox()
        {
            for(int clk = 0; clk < 24; clk++)
            {
                lbxStartHour.Items.Add(clk.ToString());
                lbxEndHour.Items.Add(clk.ToString());
            }
            for (int clk = 0; clk <= 55; clk+=5)
            {
                lbxStartMinute.Items.Add(clk.ToString());
                lbxEndMinute.Items.Add(clk.ToString());
            }         
        }        

        private string MakeWorkindTimeDescription()
        {
            string tmp = String.Empty;

            tmp += $"{calStartWork.SelectedDate.Value.Day}-{calStartWork.SelectedDate.Value.Month}-{calStartWork.SelectedDate.Value.Year}: ";
            prerioid.SetWorkDate(new DateTime(calStartWork.SelectedDate.Value.Year, calStartWork.SelectedDate.Value.Month, calStartWork.SelectedDate.Value.Day));

            if (!lbxStartHour.SelectedIndex.Equals(-1) && !lbxStartMinute.SelectedIndex.Equals(-1))
            {
                tmp += $"{lbxStartHour.SelectedItem.ToString()}:{lbxStartMinute.SelectedItem.ToString()}";
                prerioid.SetStartDate(new DateTime(calStartWork.SelectedDate.Value.Year, calStartWork.SelectedDate.Value.Month, calStartWork.SelectedDate.Value.Day, Int32.Parse(lbxStartHour.SelectedItem.ToString()), Int32.Parse(lbxStartMinute.SelectedItem.ToString()), 0));
            
            }
            else if(CheckStartValueContainsValue(prerioid))
            {
                tmp += "--:--";
            }
            
            tmp += " - ";

            if (!lbxEndHour.SelectedIndex.Equals(-1) && !lbxEndMinute.SelectedIndex.Equals(-1))
            {
                tmp += $"{lbxEndHour.SelectedItem.ToString()}:{lbxEndMinute.SelectedItem.ToString()}";
                prerioid.SetEndDate(new DateTime(calStartWork.SelectedDate.Value.Year, calStartWork.SelectedDate.Value.Month, calStartWork.SelectedDate.Value.Day, Int32.Parse(lbxEndHour.SelectedItem.ToString()), Int32.Parse(lbxEndMinute.SelectedItem.ToString()), 0));
            }
            else if (CheckEndValueContainsValue(prerioid))
            {
                tmp += "--:--";
            }

            if (!lbxStartHour.SelectedIndex.Equals(-1) && !lbxStartMinute.SelectedIndex.Equals(-1) && !lbxEndHour.SelectedIndex.Equals(-1) && !lbxEndMinute.SelectedIndex.Equals(-1))
            {
                tmp += $" {WorkingHours(Int32.Parse(lbxStartHour.SelectedItem.ToString()), Int32.Parse(lbxStartMinute.SelectedItem.ToString()), Int32.Parse(lbxEndHour.SelectedItem.ToString()), Int32.Parse(lbxEndMinute.SelectedItem.ToString()))}";
            }
            else
            {
                tmp += " (--h--m)";
            }
            
            return tmp;
        }

        private bool CheckStartValueContainsValue(WorkProjectPrerioid wpp)
        {
            if (wpp.GetStartWorkHourHasValue() && wpp.GetStartWorkMinsHasValue())
                return true;
            else
                return false;
        }

        private bool CheckEndValueContainsValue(WorkProjectPrerioid wpp)
        {
            if (wpp.GetEndWorkHourHasValue() && wpp.GetEndWorkMinsHasValue())
                return true;
            else
                return false;
        }

        public string WorkingHours(int sh, int sm, int eh, int em)
        {
          
            try
            {
                DateTime sd = new DateTime(2000, 1, 1, sh, sm, 0);
                DateTime ed = new DateTime(2000, 1, 1, eh, em, 0);
                TimeSpan ts = ed - sd;
                return "(" + ts.Hours.ToString() + "h" + ts.Minutes.ToString() + "m)";
            }
            catch(Exception exc)
            {
                CustomMessageBox.Show(CustomMesageBoxTypes.Error, exc.Message);
            }
            return "";
        }

        private void SetActualDate()
        {
            calStartWork.SelectedDate = DateTime.Now;
        }

        #endregion

        #region SLOTS

        #region SLOTS.BUTTON

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            ApplyChanges = true;
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            ApplyChanges = false;
            this.Close();
        }

        private void btnStartClear_Click(object sender, RoutedEventArgs e)
        {
            lbxStartHour.SelectedItem = null;
            lbxStartMinute.SelectedItem = null;
            prerioid.ClearStartDate();
            MakeWorkindTimeDescription();
        }

        private void btnEndClear_Click(object sender, RoutedEventArgs e)
        {
            lbxEndHour.SelectedItem = null;
            lbxEndMinute.SelectedItem = null;
            prerioid.ClearEndDate();
            MakeWorkindTimeDescription();
        }

        #endregion

        #region SLOTS.WINDOW

        private void window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            this.DragMove();
        }

        #endregion

        #region SLOTS.LISTBOX

        private void lbxStartHour_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lblPreview.Content = MakeWorkindTimeDescription();
        }

        private void lbxStartMinute_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lblPreview.Content = MakeWorkindTimeDescription();
        }

        private void lbxEndHour_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lblPreview.Content = MakeWorkindTimeDescription();
        }

        private void lbxEndMinute_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lblPreview.Content = MakeWorkindTimeDescription();
        }

        #endregion

        #region SLOTS.CALENDAR

        private void calStartWork_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            lblPreview.Content = MakeWorkindTimeDescription();
        }

        #endregion

        #endregion


    }
}
