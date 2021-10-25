﻿#pragma checksum "..\..\WorkTimeWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "220E5725FC42382B8F7B5B062430ABF4124F98D6A25DE5287A7B4E8673E99E31"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ten kod został wygenerowany przez narzędzie.
//     Wersja wykonawcza:4.0.30319.42000
//
//     Zmiany w tym pliku mogą spowodować nieprawidłowe zachowanie i zostaną utracone, jeśli
//     kod zostanie ponownie wygenerowany.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using WorkTaskOrganizer;


namespace WorkTaskOrganizer {
    
    
    /// <summary>
    /// WorkTimeWindow
    /// </summary>
    public partial class WorkTimeWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\WorkTimeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox lbxStartHour;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\WorkTimeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox lbxStartMinute;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\WorkTimeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnOk;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\WorkTimeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCancel;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\WorkTimeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox lbxEndHour;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\WorkTimeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox lbxEndMinute;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\WorkTimeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblPreview;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\WorkTimeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker calStartWork;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WorkTaskOrganizer;component/worktimewindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\WorkTimeWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 17 "..\..\WorkTimeWindow.xaml"
            ((WorkTaskOrganizer.WorkTimeWindow)(target)).AddHandler(System.Windows.Input.Mouse.MouseDownEvent, new System.Windows.Input.MouseButtonEventHandler(this.window_MouseDown));
            
            #line default
            #line hidden
            return;
            case 2:
            this.lbxStartHour = ((System.Windows.Controls.ListBox)(target));
            
            #line 21 "..\..\WorkTimeWindow.xaml"
            this.lbxStartHour.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.lbxStartHour_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.lbxStartMinute = ((System.Windows.Controls.ListBox)(target));
            
            #line 22 "..\..\WorkTimeWindow.xaml"
            this.lbxStartMinute.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.lbxStartMinute_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnOk = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\WorkTimeWindow.xaml"
            this.btnOk.Click += new System.Windows.RoutedEventHandler(this.btnOk_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnCancel = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\WorkTimeWindow.xaml"
            this.btnCancel.Click += new System.Windows.RoutedEventHandler(this.btnCancel_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.lbxEndHour = ((System.Windows.Controls.ListBox)(target));
            
            #line 27 "..\..\WorkTimeWindow.xaml"
            this.lbxEndHour.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.lbxEndHour_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.lbxEndMinute = ((System.Windows.Controls.ListBox)(target));
            
            #line 28 "..\..\WorkTimeWindow.xaml"
            this.lbxEndMinute.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.lbxEndMinute_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this.lblPreview = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            this.calStartWork = ((System.Windows.Controls.DatePicker)(target));
            
            #line 32 "..\..\WorkTimeWindow.xaml"
            this.calStartWork.SelectedDateChanged += new System.EventHandler<System.Windows.Controls.SelectionChangedEventArgs>(this.calStartWork_SelectedDateChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

