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
        public WorkProjectPrerioid prerioid = new WorkProjectPrerioid();
        public bool ApplyChanges = false;


        #region constructor
        public WorkTimeWindow()
        {
            InitializeComponent();
            FillAllHourListBox();
            calStartWork.SelectedDate = DateTime.Now;
        }
        public WorkTimeWindow(WorkProjectPrerioid wpp)
        {
            InitializeComponent();
            FillAllHourListBox();
            calStartWork.SelectedDate = wpp.startWork.Date;
            lbxStartHour.SelectedIndex = wpp.startWork.Hour;
            int sm = wpp.startWork.Minute;
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
            lbxEndHour.SelectedIndex = wpp.endWork.Hour;
            int em = wpp.endWork.Minute;
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
            MakeWorkindTimeDescription();
        }


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

        #endregion

        private string MakeWorkindTimeDescription()
        {
            string tmp = "";
            tmp += calStartWork.SelectedDate.Value.Day + "-"+calStartWork.SelectedDate.Value.Month+"-"+ calStartWork.SelectedDate.Value.Year + ": ";
            if (!lbxStartHour.SelectedIndex.Equals(-1) && !lbxStartMinute.SelectedIndex.Equals(-1))
            {
                tmp += lbxStartHour.SelectedItem.ToString() + ":" + lbxStartMinute.SelectedItem.ToString();
                prerioid.startWork = new DateTime(calStartWork.SelectedDate.Value.Year, calStartWork.SelectedDate.Value.Month, calStartWork.SelectedDate.Value.Day, Int32.Parse(lbxStartHour.SelectedItem.ToString()), Int32.Parse(lbxStartMinute.SelectedItem.ToString()), 0);
            }
            tmp += " - ";
            if (!lbxEndHour.SelectedIndex.Equals(-1) && !lbxEndMinute.SelectedIndex.Equals(-1))
            {
                tmp += lbxEndHour.SelectedItem.ToString() + ":" + lbxEndMinute.SelectedItem.ToString();
                prerioid.endWork = new DateTime(calStartWork.SelectedDate.Value.Year, calStartWork.SelectedDate.Value.Month, calStartWork.SelectedDate.Value.Day, Int32.Parse(lbxEndHour.SelectedItem.ToString()), Int32.Parse(lbxEndMinute.SelectedItem.ToString()), 0);
            }

            if(!lbxStartHour.SelectedIndex.Equals(-1) && !lbxStartMinute.SelectedIndex.Equals(-1) && !lbxEndHour.SelectedIndex.Equals(-1) && !lbxEndMinute.SelectedIndex.Equals(-1))
            {
                tmp += " "+WorkingHours(Int32.Parse(lbxStartHour.SelectedItem.ToString()), Int32.Parse(lbxStartMinute.SelectedItem.ToString()), Int32.Parse(lbxEndHour.SelectedItem.ToString()), Int32.Parse(lbxEndMinute.SelectedItem.ToString()));
            }
            else
            {
                tmp += " (--h--m)";
            }
            return tmp;
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
                MessageBox.Show(exc.Message);
            }
            return "";
        }

        #region slots
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

        private void window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            this.DragMove();
        }
        #endregion

        private void lbxStartHour_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lblPreview.Content =  MakeWorkindTimeDescription();
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

        private void calStartWork_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            lblPreview.Content = MakeWorkindTimeDescription();
        }
    }
}
