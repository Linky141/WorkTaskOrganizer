using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
    /// Logika interakcji dla klasy NewTaskForm.xaml
    /// </summary>
    public partial class NewTaskForm : Window
    {
        #region VARIABLES

        public TaskTemplate simpleTask = new TaskTemplate();
        public bool ApplyChanges = false;
        List<WorkProjectPrerioid> listTimeWorkToEdit = null;
        public int ID = -1;
        string configFileName = "Config.txt";
        private string defaultAnotherFormat = "?";
        private string defaultTaskName = "UNNAMED_TASK";
        private string defaultLinkToJira = "NO_LINK_TO_JIRA";
        private string defaultCatalogName = "NO_CATALOG_NAME";
        private string defaultCatalogPath = "NO_CATALOG_PATH";
        #endregion

        #region CONSTRUCTOR

        public NewTaskForm(int lastID)
        {
            InitializeComponent();
            this.window.Title = "Create task";
            rbTaskStatusNotStarted.IsChecked = true;
            rbTaskPriority3.IsChecked = true;
            calCreationDate.SelectedDate = DateTime.Now;
            calDeadline.SelectedDate = DateTime.Now;
            tbxFormatAnother.IsEnabled = false;
            this.ID = lastID+1;
            lblID.Content = this.ID;
        }

        public NewTaskForm(TaskTemplate taskToEdit)
        {
            InitializeComponent();
            this.window.Title = "Edit task";
            this.simpleTask = taskToEdit;
            this.listTimeWorkToEdit = taskToEdit.workTime;
            this.FillAllFields();
        }

        #endregion

        #region METHODS

        private void FillAllFields()
        {
            lblID.Content = simpleTask.id;
            this.ID = simpleTask.id;

            if (simpleTask.status.Equals("Not started"))
                rbTaskStatusNotStarted.IsChecked = true;
            else if (simpleTask.status.Equals("Open"))
                rbTaskStatusOpen.IsChecked = true;
            else if (simpleTask.status.Equals("Closed"))
                rbTaskStatusClosed.IsChecked = true;
            else if (simpleTask.status.Equals("Question to PM"))
                rbTaskStatusQuestionToPM.IsChecked = true;
            else if (simpleTask.status.Equals("On tests"))
                rbTaskStatusOnTests.IsChecked = true;
            else if (simpleTask.status.Equals("Reload on prod"))
                rbTaskStatusReloadOnProd.IsChecked = true;

            if (simpleTask.priority.Equals(1))
                rbTaskPriority1.IsChecked = true;
            else if (simpleTask.priority.Equals(2))
                rbTaskPriority2.IsChecked = true;
            else if (simpleTask.priority.Equals(3))
                rbTaskPriority3.IsChecked = true;
            else if (simpleTask.priority.Equals(4))
                rbTaskPriority4.IsChecked = true;
            else if (simpleTask.priority.Equals(5))
                rbTaskPriority5.IsChecked = true;

            if (simpleTask.format.Equals("E1"))
                rbTaskFormatE1.IsChecked = true;
            else if (simpleTask.format.Equals("E2"))
                rbTaskFormatE2.IsChecked = true;
            else
            {
                rbTaskFormatAnother.IsChecked = true;
                tbxFormatAnother.IsEnabled = true;
                tbxFormatAnother.Text = simpleTask.format;
            }

            tbxTaskName.Text = simpleTask.taskName;
            tbxLinkToJira.Text = simpleTask.linkToJira;
            tbxCatalogName.Text = simpleTask.catalogName;
            calCreationDate.SelectedDate = simpleTask.createdDate;
            calDeadline.SelectedDate = simpleTask.deadline;

            tbxComent.Text = simpleTask.comment;
            tbxCatalogPath.Text = simpleTask.catalogPath;

        }

        #endregion

        #region SLOTS

        #region SLOTS.BUTTON

        private void btnApply_Click(object sender, RoutedEventArgs e)
        {
            simpleTask = new TaskTemplate();
            ApplyChanges = true;

            if (listTimeWorkToEdit != null)
                simpleTask.workTime = listTimeWorkToEdit;

            #region Task status filling
            if (rbTaskStatusNotStarted.IsChecked.Equals(true))
                simpleTask.status = "Not started";
            else if (rbTaskStatusOpen.IsChecked.Equals(true))
                simpleTask.status = "Open";
            else if (rbTaskStatusClosed.IsChecked.Equals(true))
                simpleTask.status = "Closed";
            else if (rbTaskStatusQuestionToPM.IsChecked.Equals(true))
                simpleTask.status = "Question to PM";
            else if (rbTaskStatusOnTests.IsChecked.Equals(true))
                simpleTask.status = "On tests";
            else if (rbTaskStatusReloadOnProd.IsChecked.Equals(true))
                simpleTask.status = "Reload on prod";
            #endregion

            # region Priority filling
            if (rbTaskPriority1.IsChecked.Equals(true))
                simpleTask.priority = 1;
            else if (rbTaskPriority2.IsChecked.Equals(true))
                simpleTask.priority = 2;
            else if (rbTaskPriority3.IsChecked.Equals(true))
                simpleTask.priority = 3;
            else if (rbTaskPriority4.IsChecked.Equals(true))
                simpleTask.priority = 4;
            else if (rbTaskPriority5.IsChecked.Equals(true))
                simpleTask.priority = 5;
            #endregion

            #region Format filling
            if (rbTaskFormatE1.IsChecked.Equals(true))
                simpleTask.format = "E1";
            else if (rbTaskFormatE2.IsChecked.Equals(true))
                simpleTask.format = "E2";
            else
            {
                if (!String.IsNullOrEmpty(tbxFormatAnother.Text))
                {
                    simpleTask.format = tbxFormatAnother.Text;
                }
                else
                {
                    if (CustomMessageBox.Show(CustomMesageBoxTypes.Alert, $"Empty field:\nFormat -> Another\n\nFill with default value? ({defaultAnotherFormat})"))
                    {
                        tbxFormatAnother.Text = defaultAnotherFormat;
                        simpleTask.format = defaultAnotherFormat;
                    }
                    else
                        return;
                }
            }
            #endregion

            #region Task name filling
            if (!String.IsNullOrEmpty(tbxTaskName.Text))
                simpleTask.taskName = tbxTaskName.Text;
            else
            {
                if (CustomMessageBox.Show(CustomMesageBoxTypes.Alert, $"Empty field:\nTask name\n\nFill with default value? ({defaultTaskName})"))
                {
                    tbxTaskName.Text = defaultTaskName;
                    simpleTask.taskName = defaultTaskName;
                }
                else
                    return;
            }
            #endregion

            #region Link to jira filling
            if (!String.IsNullOrEmpty(tbxLinkToJira.Text))
                simpleTask.linkToJira = tbxLinkToJira.Text;
            else
            {
                if (CustomMessageBox.Show(CustomMesageBoxTypes.Alert, $"Empty field:\nLink to jira\n\nFill with default value? ({defaultLinkToJira})"))
                {
                    tbxLinkToJira.Text = defaultLinkToJira;
                    simpleTask.linkToJira = defaultLinkToJira;
                }
                else
                    return;
            }
            #endregion

            #region Catalog name filling
            if (!String.IsNullOrEmpty(tbxCatalogName.Text))
                simpleTask.catalogName = tbxCatalogName.Text;
            else
            {
                if (CustomMessageBox.Show(CustomMesageBoxTypes.Alert, $"Empty field:\nCatalog name\n\nFill with default value? ({defaultCatalogName})"))
                {
                    tbxCatalogName.Text = defaultCatalogName;
                    simpleTask.catalogName = defaultCatalogName;
                }
                else
                    return;
            }
            #endregion

            #region Creation date filling
            simpleTask.createdDate = calCreationDate.SelectedDate.GetValueOrDefault();
            #endregion

            #region Deadline filling
            simpleTask.deadline = calDeadline.SelectedDate.GetValueOrDefault();
            #endregion

            #region comment filling
            simpleTask.comment = tbxComent.Text;
            #endregion

            #region Catalog path filling
            if (!String.IsNullOrEmpty(tbxCatalogPath.Text))
                simpleTask.catalogPath = tbxCatalogPath.Text;
            else
            {
                if (CustomMessageBox.Show(CustomMesageBoxTypes.Alert, $"Empty field:\nCatalog path\n\nFill with default value? ({defaultCatalogPath})"))
                {
                    tbxCatalogPath.Text = defaultCatalogPath;
                    simpleTask.catalogPath = defaultCatalogPath;
                }
                else
                    return;
            }
            #endregion 


            simpleTask.id = ID;

            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            ApplyChanges = false;
            this.Close();
        }

        private void btnCatalogNameAuto_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(tbxTaskName.Text))
                tbxCatalogName.Text = DateTime.Now.ToString("yyyy-MM-dd") + " (" + tbxTaskName.Text + ")";
        }

        private void btnCatalogPathAuto_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(tbxCatalogName.Text))
            {
                tbxCatalogPath.Text = IOScripts.SearchInFile("Workspace path", configFileName);

                tbxCatalogPath.Text += "\\" + tbxCatalogName.Text;

                if (chkbxCreateCatalogInPath.IsChecked.Equals(true))
                {
                    try
                    {
                        if (!Directory.Exists(tbxCatalogPath.Text))
                        {
                            Directory.CreateDirectory(tbxCatalogPath.Text);
                        }
                        else
                        {
                            CustomMessageBox.Show(CustomMesageBoxTypes.Error, $"Catalog:\n{tbxCatalogPath.Text}\nalredy exists!");
                        }

                    }
                    catch (Exception ex)
                    {
                        CustomMessageBox.Show(CustomMesageBoxTypes.Error, $"Can not to create catalog\n\n{ex.Message}");
                    }
                }
            }
        }

        #endregion

        #region SLOTS.RADIOBUTTON

        private void rbTaskFormat_Checked(object sender, RoutedEventArgs e)
        {
            if (rbTaskFormatE1.IsChecked.Equals(true))
                tbxFormatAnother.IsEnabled = false;
            else if (rbTaskFormatE2.IsChecked.Equals(true))
                tbxFormatAnother.IsEnabled = false;
            else if (rbTaskFormatAnother.IsChecked.Equals(true))
                tbxFormatAnother.IsEnabled = true;
        }

        #endregion

        #region SLOTS.WINDOW

        private void window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            this.DragMove();
        }

        #endregion

        #region SLOTS.TEXTBOX

        private void tbxComent_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            string tmpValue = tbxComent.Text;
            CustomMessageBox.Show(CustomMesageBoxTypes.Edit, ref tmpValue);
            tbxComent.Text = tmpValue;
        }

        #endregion

        #endregion


    }
}
