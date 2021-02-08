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
        #region variables
        public TaskTemplate simpleTask = new TaskTemplate();
        public bool ApplyChanges = false;
        List<WorkProjectPrerioid> listTimeWorkToEdit = null;
        public int ID = -1;
        scripts sc = new scripts();
        #endregion

        #region constructor
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


        #region regular methods
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


        #region slots
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
            else if (rbTaskFormatAnother.IsChecked.Equals(true))
                if(!String.IsNullOrEmpty(tbxFormatAnother.Text))
                {
                    simpleTask.format = tbxFormatAnother.Text;
                }
                else
                {
                    MessageBox.Show("Empty field:\nFormat -> Another");
                    return;
                }
            #endregion

            #region Task name filling
            if (!String.IsNullOrEmpty(tbxTaskName.Text))
                simpleTask.taskName = tbxTaskName.Text;
            else
            {
                MessageBox.Show("Empty field:\nTask name");
                return;
            }
            #endregion

            #region Link to jira filling
            if (!String.IsNullOrEmpty(tbxLinkToJira.Text))
                simpleTask.linkToJira = tbxLinkToJira.Text;
            else
            {
                MessageBox.Show("Empty field:\nLink to jira");
                return;
            }
            #endregion

            #region Catalog name filling
            if (!String.IsNullOrEmpty(tbxCatalogName.Text))
                simpleTask.catalogName = tbxCatalogName.Text;
            else
            {
                MessageBox.Show("Empty field:\nCatalog name");
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
                MessageBox.Show("Empty field:\nCatalog path");
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


      

        private void btnCatalogPathAuto_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(tbxCatalogName.Text))
            {
                tbxCatalogPath.Text = sc.SearchInFile("Workspace path");

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
                            MessageBox.Show("Catalog:\n" + tbxCatalogPath.Text + "\nalredy exists!");
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Can not to create catalog\n\n" + ex.Message);
                    }
                }
            }
        }
    }
}
