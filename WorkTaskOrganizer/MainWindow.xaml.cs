using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace WorkTaskOrganizer
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Variables
        public List<TaskTemplate> tasks = new List<TaskTemplate>();
        private bool filtering = false;
        private string WindowName = "TaskWorkOrganizer v.1.2";
        scripts sc = new scripts();
        #endregion


        #region constructor
        public MainWindow()
        {
            InitializeComponent();
            DeSerialize();
            RefreshDataGrid();
            btnClearFiltr_Click(null, null);
            mainWindow.Title = WindowName;
            if (!File.Exists("Config.txt"))
            {
                File.WriteAllText("Config.txt", "Workspace path:\n\nDefault explorer:\nexplorer.exe");
                MessageBox.Show("Created config file, please edit this.");                
            }
        }

        #endregion

        #region serialozation
        public void Serialize()
        {
            XmlSerializer mySerializer = new XmlSerializer(typeof(List<TaskTemplate>));
            StreamWriter myWriter = new StreamWriter("TempName.xml");
            mySerializer.Serialize(myWriter, tasks);
            myWriter.Close();
        }
        public void DeSerialize()
        {
            try
            {
                var mySerializer = new XmlSerializer(typeof(List<TaskTemplate>));
                var myFileStream = new FileStream("TempName.xml", FileMode.Open);
                tasks = (List<TaskTemplate>)mySerializer.Deserialize(myFileStream);
                myFileStream.Close();
            }catch
            {
                MessageBox.Show("NoXaml");
            }
        }





        #endregion

        #region regular code
        private void RefreshDataGrid()
        {
            if (!filtering)
            {
                dgTasks.Items.Clear();
                foreach (TaskTemplate val in tasks)
                {
                    AddRowToDG(val);
                }
            }
            else
            {
                dgTasks.Items.Clear();
                foreach (TaskTemplate val in tasks)
                {
                    bool addToDG = true;

                    if (chkbxFiltrTaskName.IsChecked.Equals(true))
                        if (!val.taskName.ToUpper().Contains(tbxFiltrTaskName.Text.ToUpper()))
                            addToDG = false;
                    if (chkbxFiltrFormat.IsChecked.Equals(true))
                        if (!val.format.ToUpper().Contains(tbxFiltrFormat.Text.ToUpper()))
                            addToDG = false;

                    if (!(chkbxFiltrStatusClosed.IsChecked.Equals(true) && val.status.Equals("Closed")) &&
                        !(chkbxFiltrStatusNotStarted.IsChecked.Equals(true) && val.status.Equals("Not started")) &&
                        !(chkbxFiltrStatusOnTests.IsChecked.Equals(true) && val.status.Equals("On tests")) &&
                        !(chkbxFiltrStatusOpen.IsChecked.Equals(true) && val.status.Equals("Open")) &&
                        !(chkbxFiltrStatusQuestionToPM.IsChecked.Equals(true) && val.status.Equals("Question to PM")) &&
                        !(chkbxFiltrStatusReloadOnProd.IsChecked.Equals(true) && val.status.Equals("Reload on prod")))
                        addToDG = false;

                    if (!(chkbxFiltrPriority1.IsChecked.Equals(true) && val.priority.Equals(1)) &&
                        !(chkbxFiltrPriority2.IsChecked.Equals(true) && val.priority.Equals(2)) &&
                        !(chkbxFiltrPriority3.IsChecked.Equals(true) && val.priority.Equals(3)) &&
                        !(chkbxFiltrPriority4.IsChecked.Equals(true) && val.priority.Equals(4)) &&
                        !(chkbxFiltrPriority5.IsChecked.Equals(true) && val.priority.Equals(5)))
                        addToDG = false;

                    if ((calFilterCreationDateFinish.SelectedDate < calFilterCreationDateBegin.SelectedDate) ||
                        (calFiltrDaedlineFinish.SelectedDate < calFiltrDaedlineBegin.SelectedDate))
                    {
                        MessageBox.Show("incorrect dates in filter");
                        return;
                    }



                    if (chkbxFiltrCreationDate.IsChecked.Equals(true))
                        if (!(val.createdDate >= calFilterCreationDateBegin.SelectedDate && val.createdDate <= calFilterCreationDateFinish.SelectedDate))
                            addToDG = false;

                    if (chkbxFiltrDeadline.IsChecked.Equals(true))
                        if (!(val.deadline >= calFiltrDaedlineBegin.SelectedDate && val.deadline <= calFiltrDaedlineFinish.SelectedDate))
                            addToDG = false;



                    if (addToDG) AddRowToDG(val);
                }
            }
        }

        private void AddRowToDG(TaskTemplate tt)
        {
            DataGridRow row = new DataGridRow();
            row.Item = tt;
            //if (tt.status.Equals("Open")) row.Background = Brushes.DarkGoldenrod;
            //else if (tt.status.Equals("Closed")) row.Background = Brushes.Teal;
            ////else if (tt.status.Equals("Not started")) row.Background = Brushes.Maroon;
            //else if (tt.status.Equals("Not started")) row.Background = new SolidColorBrush(Color.FromRgb(64, 64, 0));
            //else if (tt.status.Equals("Question to PM")) row.Background = Brushes.Indigo;
            //else if (tt.status.Equals("On tests")) row.Background = Brushes.Navy;
            //else if (tt.status.Equals("Reload on prod")) row.Background = Brushes.Purple;

            int thickness = 5;
            if(tt.priority.Equals(1))
            {
                row.BorderThickness = new Thickness(thickness, 0,0,0);
                row.BorderBrush = Brushes.Red;
            }
            else if (tt.priority.Equals(2))
            {
                row.BorderThickness = new Thickness(thickness, 0, 0, 0);
                row.BorderBrush = Brushes.Magenta;
            }
            else if (tt.priority.Equals(3))
            {
                row.BorderThickness = new Thickness(thickness, 0, 0, 0);
                row.BorderBrush = Brushes.Yellow;
            }
            else if (tt.priority.Equals(4))
            {
                row.BorderThickness = new Thickness(thickness, 0, 0, 0);
                row.BorderBrush = Brushes.LightGreen;
            }
            else if (tt.priority.Equals(5))
            {
                row.BorderThickness = new Thickness(thickness, 0, 0, 0);
                row.BorderBrush = Brushes.LightBlue;
            }

          
            

            Color taskColor = Color.FromRgb(0,0,0);
            if (tt.status.Equals("Open")) taskColor = Color.FromRgb(64,0,0);
            else if (tt.status.Equals("Closed")) taskColor = Color.FromRgb(0,64,0);
            else if (tt.status.Equals("Not started")) taskColor = Color.FromRgb(64,64,64);
            else if (tt.status.Equals("Question to PM")) taskColor = Color.FromRgb(0,64,64);
            else if (tt.status.Equals("On tests")) taskColor = Color.FromRgb(0,0,64);
            else if (tt.status.Equals("Reload on prod")) taskColor = Color.FromRgb(64,64,0);
            Point startGradient = new Point(0, 0);
            Point endGradient = new Point(0.1, 0);

            if (tt.deadline < DateTime.Today && !tt.status.Equals("Closed"))
            {
                row.Background = new LinearGradientBrush(Color.FromRgb(190, 0, 0), taskColor, startGradient, endGradient);
            }
            else if (tt.deadline.AddDays(-2) < DateTime.Today && !tt.status.Equals("Closed"))
            {
                row.Background = new LinearGradientBrush(Color.FromRgb(190, 190, 0), taskColor, startGradient, endGradient);
            }
            else if (tt.deadline.AddDays(-5) < DateTime.Today && !tt.status.Equals("Closed"))
            {
                row.Background = new LinearGradientBrush(Color.FromRgb(0, 190, 0), taskColor, startGradient, endGradient);
            }
            else if ( !tt.status.Equals("Closed"))
            {
                row.Background = new LinearGradientBrush(Color.FromRgb(0, 0, 190), taskColor, startGradient, endGradient);
            }
            else
            {
                row.Background = new SolidColorBrush(taskColor);
            }

            //if (tt.priority.Equals(1))
            //{
            //    row.Foreground = Brushes.Red;
            //    row.FontStyle = FontStyles.Italic;
            //}
            //else if (tt.priority.Equals(2))
            //{
            //    row.Foreground = Brushes.Red;
            //}
            dgTasks.Items.Add(row);
        }
      
        private void RefreshWorkTime()
        {
            int selectedIndex = -2;
            if (dgTasks.SelectedItem != null)
            {
                int tmpSelectedIndexFromDG = dgTasks.SelectedIndex;
                selectedIndex = SearchIDFormDG(dgTasks.Columns[0].GetCellContent(dgTasks.Items[dgTasks.SelectedIndex]) as TextBlock);
                lbxWorkingTime.Items.Clear();
                SumTimeRound str = new SumTimeRound();
                foreach (WorkProjectPrerioid val in tasks[selectedIndex].workTime)
                {
                    lbxWorkingTime.Items.Add(val.ToString());
                    if (val.CheckCompletePrerioid())
                    {
                        str.AddHour(val.getPrerioidHours());
                        str.AddMin(val.getPrerioidMins());
                    }
                }
                lblSumTimeWork.Content = str.getDays() + "d" + str.getHours() + "h" + str.getMins() + "m";
            }
        }


        private int SearchIDFormDG(TextBlock info)
        {
            int clk = 0;
            foreach(TaskTemplate val in tasks){
                string id = info.Text;
                if (id.Equals(val.id.ToString())) return clk;
                clk++;
            }
            return -1;
        }
        #endregion

        #region slots

        private void btnAddNewTask_Click(object sender, RoutedEventArgs e)
        {
            NewTaskForm newTaskFormWindow = null;
            if(tasks.Count.Equals(0))
                newTaskFormWindow = new NewTaskForm(0);
            else
                newTaskFormWindow = new NewTaskForm(dgTasks.Items.Count);
            newTaskFormWindow.ShowDialog();
            if (newTaskFormWindow.ApplyChanges)
                tasks.Add(newTaskFormWindow.simpleTask);
            Serialize();
            RefreshDataGrid();
        }

        private void btnEditTask_Click(object sender, RoutedEventArgs e)
        {
            if (dgTasks.SelectedItem != null)
            {
                int selectedIndex = -2;
                try
                {
                    int tmpSelectedIndexFromDG = dgTasks.SelectedIndex;
                    selectedIndex = SearchIDFormDG(dgTasks.Columns[0].GetCellContent(dgTasks.Items[dgTasks.SelectedIndex]) as TextBlock);
                    NewTaskForm newTaskFormWindow = new NewTaskForm(tasks[selectedIndex]);
                    newTaskFormWindow.ShowDialog();
                    if (newTaskFormWindow.ApplyChanges)
                    {
                        tasks[selectedIndex] = newTaskFormWindow.simpleTask;
                    }
                    Serialize();
                    RefreshDataGrid();
                    dgTasks.SelectedIndex = tmpSelectedIndexFromDG;
                    //dgTasks_MouseDown(null, null);
                    tbxComment.Text = tasks[selectedIndex].comment;
                    tbxLinkToJira.Text = tasks[selectedIndex].linkToJira;
                    tbxcatalogPath.Text = tasks[selectedIndex].catalogPath;
                    RefreshWorkTime();
                }
                catch (Exception exc) { MessageBox.Show(exc.Message + "\n\n" + selectedIndex.ToString()); }
            }
        }

        private void dgTasks_MouseDown(object sender, MouseButtonEventArgs e)
        {
            int index = -2;
            try
            {
                index = SearchIDFormDG(dgTasks.Columns[0].GetCellContent(dgTasks.Items[dgTasks.SelectedIndex]) as TextBlock);
                tbxComment.Text = tasks[index].comment;
                tbxLinkToJira.Text = tasks[index].linkToJira;
                tbxcatalogPath.Text = tasks[index].catalogPath;
                mainWindow.Title = WindowName + " (" + tasks[index].taskName + ")";
                RefreshWorkTime();
            }
            catch(Exception exc)
            {
                MessageBox.Show("ID wiersza: " + index + " poza zakresem\n\n" + exc.Message);
            }
        }

        private void btnOpenLinkToJira_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(tbxLinkToJira.Text))
                    System.Diagnostics.Process.Start(tbxLinkToJira.Text);
            }
            catch
            {
                MessageBox.Show("Link is not correct");
            }
        }

        private void btnFiltrStatusSelectAll_Click(object sender, RoutedEventArgs e)
        {
            chkbxFiltrStatusClosed.IsChecked = true;
            chkbxFiltrStatusNotStarted.IsChecked = true;
            chkbxFiltrStatusOnTests.IsChecked = true;
            chkbxFiltrStatusOpen.IsChecked = true;
            chkbxFiltrStatusQuestionToPM.IsChecked = true;
            chkbxFiltrStatusReloadOnProd.IsChecked = true;
        }

        private void btnFiltrStatusClear_Click(object sender, RoutedEventArgs e)
        {
            chkbxFiltrStatusClosed.IsChecked = false;
            chkbxFiltrStatusNotStarted.IsChecked = false;
            chkbxFiltrStatusOnTests.IsChecked = false;
            chkbxFiltrStatusOpen.IsChecked = false;
            chkbxFiltrStatusQuestionToPM.IsChecked = false;
            chkbxFiltrStatusReloadOnProd.IsChecked = false;
        }

        private void btnFilterPrioritySelectAll_Click(object sender, RoutedEventArgs e)
        {
            chkbxFiltrPriority1.IsChecked = true;
            chkbxFiltrPriority2.IsChecked = true;
            chkbxFiltrPriority3.IsChecked = true;
            chkbxFiltrPriority4.IsChecked = true;
            chkbxFiltrPriority5.IsChecked = true;
        }

        private void btnFilterPriorityClear_Click(object sender, RoutedEventArgs e)
        {
            chkbxFiltrPriority1.IsChecked = false;
            chkbxFiltrPriority2.IsChecked = false;
            chkbxFiltrPriority3.IsChecked = false;
            chkbxFiltrPriority4.IsChecked = false;
            chkbxFiltrPriority5.IsChecked = false;
        }


        private void btnWorkTimeAdd_Click(object sender, RoutedEventArgs e)
        {
            if (dgTasks.SelectedItem != null)
            {
                WorkTimeWindow workTimeWindow = new WorkTimeWindow();
                workTimeWindow.ShowDialog();
                if (workTimeWindow.ApplyChanges)
                {
                    tasks[dgTasks.SelectedIndex].workTime.Add(workTimeWindow.prerioid);
                }
                Serialize();
                RefreshWorkTime();
            }
        }

        private void btnWorkTimeEdit_Click(object sender, RoutedEventArgs e)
        {
            if (dgTasks.SelectedItem != null && lbxWorkingTime.SelectedItem != null)
            {
                int lbxWorkingTimeIndex = lbxWorkingTime.SelectedIndex;
                WorkTimeWindow workTimeWindow = new WorkTimeWindow(tasks[dgTasks.SelectedIndex].workTime[lbxWorkingTimeIndex]);
                workTimeWindow.ShowDialog();
                if (workTimeWindow.ApplyChanges)
                {
                    tasks[dgTasks.SelectedIndex].workTime[lbxWorkingTimeIndex] = workTimeWindow.prerioid;
                }
                Serialize();
                RefreshWorkTime();
            }
        }

        private void btnWorkTimeRemove_Click(object sender, RoutedEventArgs e)
        {
            if (dgTasks.SelectedItem != null && lbxWorkingTime.SelectedItem != null)
            {
                tasks[dgTasks.SelectedIndex].workTime.RemoveAt(lbxWorkingTime.SelectedIndex);
                Serialize();
                RefreshWorkTime();
            }
        }

        private void btnFiltr_Click(object sender, RoutedEventArgs e)
        {
            filtering = true;
            RefreshDataGrid();
        }

        private void btnCancleFiltr_Click(object sender, RoutedEventArgs e)
        {
            filtering = false;
            RefreshDataGrid();
        }

        private void btnClearFiltr_Click(object sender, RoutedEventArgs e)
        {
            chkbxFiltrStatusNotStarted.IsChecked = false;
            chkbxFiltrStatusOpen.IsChecked = false;
            chkbxFiltrStatusClosed.IsChecked = false;
            chkbxFiltrStatusQuestionToPM.IsChecked = false;
            chkbxFiltrStatusOnTests.IsChecked = false;
            chkbxFiltrStatusReloadOnProd.IsChecked = false;
            chkbxFiltrPriority1.IsChecked = false;
            chkbxFiltrPriority2.IsChecked = false;
            chkbxFiltrPriority3.IsChecked = false;
            chkbxFiltrPriority4.IsChecked = false;
            chkbxFiltrPriority5.IsChecked = false;
            chkbxFiltrTaskName.IsChecked = false;
            chkbxFiltrFormat.IsChecked = false;
            chkbxFiltrCreationDate.IsChecked = false;
            chkbxFiltrDeadline.IsChecked = false;

            tbxFiltrFormat.Text = "";
            tbxFiltrTaskName.Text = "";
            calFilterCreationDateBegin.SelectedDate = DateTime.Today;
            calFilterCreationDateFinish.SelectedDate = DateTime.Today;
            calFiltrDaedlineBegin.SelectedDate = DateTime.Today;
            calFiltrDaedlineFinish.SelectedDate = DateTime.Today;
        }

        private void btnFiltrCreationDateFromMax_Click(object sender, RoutedEventArgs e)
        {
            calFilterCreationDateBegin.SelectedDate = DateTime.MaxValue;
        }

        private void btnFiltrCreationDateFromToday_Click(object sender, RoutedEventArgs e)
        {
            calFilterCreationDateBegin.SelectedDate = DateTime.Today;
        }

        private void btnFiltrCreationDateFromMin_Click(object sender, RoutedEventArgs e)
        {
            calFilterCreationDateBegin.SelectedDate = DateTime.MinValue;
        }

        private void btnFiltrCreationDateToMax_Click(object sender, RoutedEventArgs e)
        {
            calFilterCreationDateFinish.SelectedDate = DateTime.MaxValue;
        }

        private void btnFiltrCreationDateToToday_Click(object sender, RoutedEventArgs e)
        {
            calFilterCreationDateFinish.SelectedDate = DateTime.Today;
        }

        private void btnFiltrCreationDateToMin_Click(object sender, RoutedEventArgs e)
        {
            calFilterCreationDateFinish.SelectedDate = DateTime.MinValue;
        }

        private void btnFiltrDeadlineFromMax_Click(object sender, RoutedEventArgs e)
        {
            calFiltrDaedlineBegin.SelectedDate = DateTime.MaxValue;
        }

        private void btnFiltrDeadlineFromToday_Click(object sender, RoutedEventArgs e)
        {
            calFiltrDaedlineBegin.SelectedDate = DateTime.Today;
        }

        private void btnFiltrDeadlineFromMin_Click(object sender, RoutedEventArgs e)
        {
            calFiltrDaedlineBegin.SelectedDate = DateTime.MinValue;
        }

        private void btnFiltrDeadlineToMax_Click(object sender, RoutedEventArgs e)
        {
            calFiltrDaedlineFinish.SelectedDate = DateTime.MaxValue;
        }

        private void btnFiltrDeadlineToToday_Click(object sender, RoutedEventArgs e)
        {
            calFiltrDaedlineFinish.SelectedDate = DateTime.Today;
        }

        private void btnFiltrDeadlineToMin_Click(object sender, RoutedEventArgs e)
        {
            calFiltrDaedlineFinish.SelectedDate = DateTime.MinValue;
        }


        #endregion

        private void btnOpenCatalogPath_Click(object sender, RoutedEventArgs e)
        {
            if (Directory.Exists(tbxcatalogPath.Text))
            {
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    Arguments = tbxcatalogPath.Text,
                    FileName = sc.SearchInFile("Default explorer")
                };

            Process.Start(startInfo);
        }
    else
    {
        MessageBox.Show(string.Format("{0} Directory does not exist!", tbxcatalogPath.Text));
    }
}
    }
}
