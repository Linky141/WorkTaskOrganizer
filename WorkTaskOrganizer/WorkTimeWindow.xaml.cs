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
            lbxStartHour.Items.Add("0");
            lbxStartHour.Items.Add("1");
            lbxStartHour.Items.Add("2");
            lbxStartHour.Items.Add("3");
            lbxStartHour.Items.Add("4");
            lbxStartHour.Items.Add("5");
            lbxStartHour.Items.Add("6");
            lbxStartHour.Items.Add("7");
            lbxStartHour.Items.Add("8");
            lbxStartHour.Items.Add("9");
            lbxStartHour.Items.Add("10");
            lbxStartHour.Items.Add("11");
            lbxStartHour.Items.Add("12");
            lbxStartHour.Items.Add("13");
            lbxStartHour.Items.Add("14");
            lbxStartHour.Items.Add("15");
            lbxStartHour.Items.Add("16");
            lbxStartHour.Items.Add("17");
            lbxStartHour.Items.Add("18");
            lbxStartHour.Items.Add("19");
            lbxStartHour.Items.Add("20");
            lbxStartHour.Items.Add("21");
            lbxStartHour.Items.Add("22");
            lbxStartHour.Items.Add("23");

            lbxEndHour.Items.Add("0");
            lbxEndHour.Items.Add("1");
            lbxEndHour.Items.Add("2");
            lbxEndHour.Items.Add("3");
            lbxEndHour.Items.Add("4");
            lbxEndHour.Items.Add("5");
            lbxEndHour.Items.Add("6");
            lbxEndHour.Items.Add("7");
            lbxEndHour.Items.Add("8");
            lbxEndHour.Items.Add("9");
            lbxEndHour.Items.Add("10");
            lbxEndHour.Items.Add("11");
            lbxEndHour.Items.Add("12");
            lbxEndHour.Items.Add("13");
            lbxEndHour.Items.Add("14");
            lbxEndHour.Items.Add("15");
            lbxEndHour.Items.Add("16");
            lbxEndHour.Items.Add("17");
            lbxEndHour.Items.Add("18");
            lbxEndHour.Items.Add("19");
            lbxEndHour.Items.Add("20");
            lbxEndHour.Items.Add("21");
            lbxEndHour.Items.Add("22");
            lbxEndHour.Items.Add("23");

            lbxStartMinute.Items.Add("0");
            lbxStartMinute.Items.Add("5");
            lbxStartMinute.Items.Add("10");
            lbxStartMinute.Items.Add("15");
            lbxStartMinute.Items.Add("20");
            lbxStartMinute.Items.Add("25");
            lbxStartMinute.Items.Add("30");
            lbxStartMinute.Items.Add("35");
            lbxStartMinute.Items.Add("40");
            lbxStartMinute.Items.Add("45");
            lbxStartMinute.Items.Add("50");
            lbxStartMinute.Items.Add("55");

            lbxEndMinute.Items.Add("0");
            lbxEndMinute.Items.Add("5");
            lbxEndMinute.Items.Add("10");
            lbxEndMinute.Items.Add("15");
            lbxEndMinute.Items.Add("20");
            lbxEndMinute.Items.Add("25");
            lbxEndMinute.Items.Add("30");
            lbxEndMinute.Items.Add("35");
            lbxEndMinute.Items.Add("40");
            lbxEndMinute.Items.Add("45");
            lbxEndMinute.Items.Add("50");
            lbxEndMinute.Items.Add("55");
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
