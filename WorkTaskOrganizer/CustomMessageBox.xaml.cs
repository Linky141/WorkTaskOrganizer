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
    /// Logika interakcji dla klasy CustomMessageBox.xaml
    /// </summary>
    public partial class CustomMessageBox : Window
    {
        #region VARIABLES

        private bool exitState = false;
        private string outputText = String.Empty;
        private CustomMesageBoxTypes windowType;

        #endregion

        #region CONSTRUCTOR

        public CustomMessageBox(CustomMesageBoxTypes type, string text)
        {
            InitializeComponent();
            windowType = type;

            switch (type)
            {
                case CustomMesageBoxTypes.Alert:
                    InitAsAlert(text);
                    break;
                case CustomMesageBoxTypes.Edit:
                    InitAsEdit(text);
                    break;
                case CustomMesageBoxTypes.Error:
                    InitAsError(text);
                    break;
                case CustomMesageBoxTypes.Message:
                    InitAsMessage(text);
                    break;
                default:
                    throw new Exception("No CustomMessageBox type selected!!!");
            }
        }

        private void InitAsAlert(string message)
        {
            SetBtnNO(true, "No");
            SetBtnOK(true, "Yes");
            SetTextbox(true, message);
            SetFrame(CustomMesageBoxTypes.Alert);
        }

        private void InitAsEdit(string message)
        {
            this.outputText = message;
            SetBtnNO(true, "Cancel");
            SetBtnOK(true, "Save");
            SetTextbox(false, message);
            SetFrame(CustomMesageBoxTypes.Edit);
        }

        private void InitAsError(string message)
        {
            SetBtnNO(false);
            SetBtnOK(true, "OK");
            SetTextbox(true, message);
            SetFrame(CustomMesageBoxTypes.Error);
        }

        private void InitAsMessage(string message)
        {
            SetBtnNO(false);
            SetBtnOK(true, "OK");
            SetTextbox(true, message);
            SetFrame(CustomMesageBoxTypes.Message);
        }

        #endregion

        #region METHODS

        public static bool Show(CustomMesageBoxTypes type, string text)
        {
            if (type == CustomMesageBoxTypes.Edit)
                throw new Exception("CustomMessageBoxType Edit must have reference value!!!");
            CustomMessageBox mb = new CustomMessageBox(type, text);
            mb.ShowDialog();
            return mb.GetExitState();
        }

        public static bool Show(CustomMesageBoxTypes type, ref string text)
        {
            CustomMessageBox mb = new CustomMessageBox(type, text);
            mb.ShowDialog();
            text = mb.GetEditedText();
            return mb.GetExitState();
        }

        private void SetBtnOK(bool active, string message = "")
        {
            btnOK.IsEnabled = active;
            btnOK.Content = message;
        }

        private void SetBtnNO(bool active, string message = "")
        {
            btnNO.IsEnabled = active;
            btnNO.Content = message;
        }

        private void SetTextbox(bool isReadOnly, string message)
        {
            tbxMessage.IsReadOnly = isReadOnly;
            tbxMessage.Text = message;
        }

        public void SetFrame(CustomMesageBoxTypes type)
        {
            switch (type)
            {
                case CustomMesageBoxTypes.Alert:
                    windowBorder.BorderThickness = new Thickness(1);
                    windowBorder.BorderBrush = Brushes.Yellow;
                    break;
                case CustomMesageBoxTypes.Edit:
                    break;
                case CustomMesageBoxTypes.Error:
                    windowBorder.BorderThickness = new Thickness(1);
                    windowBorder.BorderBrush = Brushes.Red;
                    break;
                case CustomMesageBoxTypes.Message:
                    break;
                default:
                    throw new Exception("No CustomMessageBox type selected!!!");
            }
        }
        #endregion

        #region GET/SET

        public bool GetExitState()
        {
            return exitState;
        }      
        
        public string GetEditedText()
        {
            return outputText;
        }

        #endregion

        #region SLOTS

        #region SLOTS.WINDOW

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            this.DragMove();
        }




        #endregion

        #region SLOTS.BUTTON

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            switch (windowType)
            {
                case CustomMesageBoxTypes.Alert:
                    exitState = true;
                    this.Close();
                    break;
                case CustomMesageBoxTypes.Edit:
                    outputText = tbxMessage.Text;
                    exitState = true;
                    this.Close();
                    break;
                case CustomMesageBoxTypes.Error:
                    this.Close();
                    break;
                case CustomMesageBoxTypes.Message:
                    this.Close();
                    break;
                default:
                    throw new Exception("No CustomMessageBox type selected!!!");
            }
        }

        private void btnNO_Click(object sender, RoutedEventArgs e)
        {
            switch (windowType)
            {
                case CustomMesageBoxTypes.Alert:
                    exitState = false;
                    this.Close();
                    break;
                case CustomMesageBoxTypes.Edit:                    
                    exitState = false;
                    this.Close();
                    break;
                case CustomMesageBoxTypes.Error:
                    this.Close();
                    break;
                case CustomMesageBoxTypes.Message:
                    this.Close();
                    break;
                default:
                    throw new Exception("No CustomMessageBox type selected!!!");
            }
        }

        #endregion

        #endregion

    }
}
