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
        #region VARIABLES

        public List<TaskTemplate> tasks = new List<TaskTemplate>();
        private bool searchingInDataGrid = false;
        private string WindowName = "TaskWorkOrganizer v.2.3";
        private string configFileName = "Config.txt";
        private string tasksDataFile = "TempName.xml";
        int dataGridSelectedItemIndex = -1;

        #endregion

        #region CONSTRUCTOR

        public MainWindow()
        {
            InitializeComponent();
            mainWindow.Title = WindowName;
            tasks = IOScripts.DeserializeTaskTemplate(tasksDataFile);
            RefreshDataGrid();
            btnClearFiltr_Click(null, null);
            IOScripts.CheckExistsConfigFile(configFileName);
        }

        #endregion

        #region METHODS

        private void RefreshDataGrid()
        {
            if (!searchingInDataGrid)
                RefreshDataGridNotSearching();
            else
                RefreshDataGridSearching();
        }

        private void RefreshDataGridNotSearching()
        {
            ClearDataGrid();
            foreach (var val in tasks)
                AddRowToDG(val);
            MoveDataGridToLastRow();
        }

        private void RefreshDataGridSearching()
        {
            ClearDataGrid();
            foreach (var val in tasks)
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
                    CustomMessageBox.Show(CustomMesageBoxTypes.Error, "incorrect dates in filter");
                    return;
                }

                if (chkbxFiltrCreationDate.IsChecked.Equals(true))
                    if (!(val.createdDate >= calFilterCreationDateBegin.SelectedDate && val.createdDate <= calFilterCreationDateFinish.SelectedDate))
                        addToDG = false;

                if (chkbxFiltrDeadline.IsChecked.Equals(true))
                    if (!(val.deadline >= calFiltrDaedlineBegin.SelectedDate && val.deadline <= calFiltrDaedlineFinish.SelectedDate))
                        addToDG = false;

                if (addToDG) AddRowToDG(val);
                MoveDataGridToLastRow();
            }
        }

        private void RefreshWorkTime()
        {
            if (DataGridHasSelectedItem())
            {
                lbxWorkingTime.Items.Clear();
                SumTimeRound str = new SumTimeRound();
                foreach (WorkProjectPrerioid val in tasks[dataGridSelectedItemIndex].workTime)
                {
                    lbxWorkingTime.Items.Add(val.ToString());
                    if (val.CheckCompletePrerioid())
                    {
                        str.AddHour(val.getPrerioidHours());
                        str.AddMin(val.getPrerioidMins());
                    }
                }
                ChangeTimeLabelValue(str.getDays(), str.getHours(), str.getMins());
            }
        }

        private void ChangeTimeLabelValue(int days, int hours, int mins)
        {
            lblSumTimeWork.Content = $"{days}d {hours}h {mins}m";
        }

        private void AddRowToDG(TaskTemplate tt)
        {
            DataGridRow row = new DataGridRow();
            row.Item = tt;

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

            dgTasks.Items.Add(row);
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

        private bool DataGridHasSelectedItem()
        {
            if (dgTasks.SelectedItem != null)
                return true;
            else
                return false;
        }

        private void MoveDataGridToLastRow()
        {
            if(dgTasks.Items.Count>0)
                dgTasks.ScrollIntoView(dgTasks.Items.GetItemAt(dgTasks.Items.Count-1));
        }

        private void ClearDataGrid()
        {
            dgTasks.Items.Clear();
        }

        #endregion

        #region SLOTS

        #region SLOTS.BUTTON

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
            IOScripts.SerializeTaskTemplate(tasks, tasksDataFile);
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
                    IOScripts.SerializeTaskTemplate(tasks, tasksDataFile);
                    RefreshDataGrid();
                    dgTasks.SelectedIndex = tmpSelectedIndexFromDG;
                    //dgTasks_MouseDown(null, null);
                    tbxComment.Text = tasks[selectedIndex].comment;
                    tbxLinkToJira.Text = tasks[selectedIndex].linkToJira;
                    tbxcatalogPath.Text = tasks[selectedIndex].catalogPath;
                    RefreshWorkTime();
                }
                catch (Exception exc) { 
                    CustomMessageBox.Show(CustomMesageBoxTypes.Error, $"{exc.Message}\n\n{selectedIndex.ToString()}");
                }
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
                CustomMessageBox.Show(CustomMesageBoxTypes.Error, "Link is not correct");
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
            if (dataGridSelectedItemIndex != -1)
            {
                WorkTimeWindow workTimeWindow = new WorkTimeWindow();
                workTimeWindow.ShowDialog();
                if (workTimeWindow.ApplyChanges)
                {
                    tasks[dataGridSelectedItemIndex].workTime.Add(workTimeWindow.prerioid);
                }
                IOScripts.SerializeTaskTemplate(tasks, tasksDataFile);
                RefreshWorkTime();
            }
        }

        private void btnWorkTimeEdit_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridSelectedItemIndex != -1 && lbxWorkingTime.SelectedItem != null)
            {
                int lbxWorkingTimeIndex = lbxWorkingTime.SelectedIndex;
                WorkTimeWindow workTimeWindow = new WorkTimeWindow(tasks[dataGridSelectedItemIndex].workTime[lbxWorkingTimeIndex]);
                workTimeWindow.ShowDialog();
                if (workTimeWindow.ApplyChanges)
                {
                    tasks[dataGridSelectedItemIndex].workTime[lbxWorkingTimeIndex] = workTimeWindow.prerioid;
                }
                IOScripts.SerializeTaskTemplate(tasks, tasksDataFile);
                RefreshWorkTime();
            }
        }

        private void btnWorkTimeRemove_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridSelectedItemIndex != -1 && lbxWorkingTime.SelectedItem != null)
            {
                tasks[dataGridSelectedItemIndex].workTime.RemoveAt(lbxWorkingTime.SelectedIndex);
                IOScripts.SerializeTaskTemplate(tasks, tasksDataFile);
                RefreshWorkTime();
            }
        }

        private void btnFiltr_Click(object sender, RoutedEventArgs e)
        {
            searchingInDataGrid = true;
            RefreshDataGrid();
        }

        private void btnCancleFiltr_Click(object sender, RoutedEventArgs e)
        {
            searchingInDataGrid = false;
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

        private void btnOpenCatalogPath_Click(object sender, RoutedEventArgs e)
        {
            if (Directory.Exists(tbxcatalogPath.Text))
            {
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    Arguments = $"\"{tbxcatalogPath.Text}\"",
                    FileName = IOScripts.SearchInFile("Default explorer", configFileName)
                };

                Process.Start(startInfo);
            }
            else
            {
                CustomMessageBox.Show(CustomMesageBoxTypes.Error, string.Format("{0} Directory does not exist!", tbxcatalogPath.Text));
            }
        }

        private void btnSearchByName_Click(object sender, RoutedEventArgs e)
        {
            chkbxFiltrStatusNotStarted.IsChecked = true;
            chkbxFiltrStatusOpen.IsChecked = true;
            chkbxFiltrStatusClosed.IsChecked = true;
            chkbxFiltrStatusQuestionToPM.IsChecked = true;
            chkbxFiltrStatusOnTests.IsChecked = true;
            chkbxFiltrStatusReloadOnProd.IsChecked = true;
            chkbxFiltrPriority1.IsChecked = true;
            chkbxFiltrPriority2.IsChecked = true;
            chkbxFiltrPriority3.IsChecked = true;
            chkbxFiltrPriority4.IsChecked = true;
            chkbxFiltrPriority5.IsChecked = true;
            chkbxFiltrTaskName.IsChecked = true;
            chkbxFiltrFormat.IsChecked = false;
            chkbxFiltrCreationDate.IsChecked = false;
            chkbxFiltrDeadline.IsChecked = false;

            string taskName = Clipboard.GetText();
            if(String.IsNullOrEmpty(taskName))
            {
                tbxFiltrTaskName.Focus();
            }
            else
            {
                tbxFiltrTaskName.Text = taskName;
                btnFiltr_Click(sender, e);
            }
            //tbxFiltrTaskName
        }

        private void btnShowAllNotClosed_Click(object sender, RoutedEventArgs e)
        {
            chkbxFiltrStatusNotStarted.IsChecked = true;
            chkbxFiltrStatusOpen.IsChecked = true;
            chkbxFiltrStatusClosed.IsChecked = false;
            chkbxFiltrStatusQuestionToPM.IsChecked = true;
            chkbxFiltrStatusOnTests.IsChecked = true;
            chkbxFiltrStatusReloadOnProd.IsChecked = true;
            chkbxFiltrPriority1.IsChecked = true;
            chkbxFiltrPriority2.IsChecked = true;
            chkbxFiltrPriority3.IsChecked = true;
            chkbxFiltrPriority4.IsChecked = true;
            chkbxFiltrPriority5.IsChecked = true;
            chkbxFiltrTaskName.IsChecked = false;
            chkbxFiltrFormat.IsChecked = false;
            chkbxFiltrCreationDate.IsChecked = false;
            chkbxFiltrDeadline.IsChecked = false;
            btnFiltr_Click(sender, e);
        }

        private void btnMakeBackup_Click(object sender, RoutedEventArgs e)
        {
            DateTime now = DateTime.Now;
            string backupPath = IOScripts.SearchInFile("Backup folder", configFileName);
            string fileName = "BACKUP_" + now.Year + " - " + now.Month + " - " + now.Day + "T" + now.Hour + " - " + now.Minute + " - " + now.Second + ".XML";
            backupPath += "\\" + fileName;
            IOScripts.SerializeTaskTemplate(tasks, backupPath);
            CustomMessageBox.Show(CustomMesageBoxTypes.Message, "Backup \"" + fileName + "\" was created in \n" + backupPath);
        }

        #endregion

        #region SLOTS.DATAGRID

        private void dgTasks_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                dataGridSelectedItemIndex = SearchIDFormDG(dgTasks.Columns[0].GetCellContent(dgTasks.Items[dgTasks.SelectedIndex]) as TextBlock);
                tbxComment.Text = tasks[dataGridSelectedItemIndex].comment;
                tbxLinkToJira.Text = tasks[dataGridSelectedItemIndex].linkToJira;
                tbxcatalogPath.Text = tasks[dataGridSelectedItemIndex].catalogPath;
                mainWindow.Title = $"{WindowName} ({tasks[dataGridSelectedItemIndex].id}. {tasks[dataGridSelectedItemIndex].taskName})";
                RefreshWorkTime();
            }
            catch(Exception exc)
            {
                CustomMessageBox.Show(CustomMesageBoxTypes.Error, $"ID wiersza: {dataGridSelectedItemIndex} poza zakresem\n\n{exc.Message}");
            }
        }

        #endregion

        #region SLOTS.TEXTBOX

        private void tbxComment_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            CustomMessageBox.Show(CustomMesageBoxTypes.Message, tbxComment.Text);
        }



        #endregion

        #endregion

      
    }
}
