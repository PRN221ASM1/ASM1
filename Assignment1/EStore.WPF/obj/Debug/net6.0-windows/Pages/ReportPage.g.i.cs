﻿#pragma checksum "..\..\..\..\Pages\ReportPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6A7A6F917F33F697C98C8E5FE51D82FE3C15D7C5"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using EStore.WPF.Pages;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace EStore.WPF.Pages {
    
    
    /// <summary>
    /// ReportPage
    /// </summary>
    public partial class ReportPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 31 "..\..\..\..\Pages\ReportPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView orderDetailsListView;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\..\Pages\ReportPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtTotalPriceDetail;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\..\Pages\ReportPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Menu menuFilterOrders;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\..\Pages\ReportPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem Date;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\..\Pages\ReportPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker StartDate;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\..\Pages\ReportPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker EndtDate;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\..\Pages\ReportPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDateFilter;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\..\Pages\ReportPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem Staff;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\..\Pages\ReportPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cobStaffs;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\..\Pages\ReportPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView orderListView;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.4.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/EStore.WPF;component/pages/reportpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\ReportPage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.4.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.orderDetailsListView = ((System.Windows.Controls.ListView)(target));
            return;
            case 2:
            this.txtTotalPriceDetail = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.menuFilterOrders = ((System.Windows.Controls.Menu)(target));
            return;
            case 4:
            this.Date = ((System.Windows.Controls.MenuItem)(target));
            return;
            case 5:
            this.StartDate = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 6:
            this.EndtDate = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 7:
            this.btnDateFilter = ((System.Windows.Controls.Button)(target));
            return;
            case 8:
            this.Staff = ((System.Windows.Controls.MenuItem)(target));
            return;
            case 9:
            this.cobStaffs = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 10:
            this.orderListView = ((System.Windows.Controls.ListView)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

