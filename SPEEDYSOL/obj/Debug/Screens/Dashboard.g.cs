﻿#pragma checksum "..\..\..\Screens\Dashboard.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "87F7A66722B10A3015565132F07B6CEC6E290795"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using SPEEDYSOL.Screens;
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


namespace SPEEDYSOL.Screens {
    
    
    /// <summary>
    /// Dashboard
    /// </summary>
    public partial class Dashboard : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 28 "..\..\..\Screens\Dashboard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSales;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\Screens\Dashboard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnPurchase;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\Screens\Dashboard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnVouchers;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\Screens\Dashboard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnGodowns;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\Screens\Dashboard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnItems;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\Screens\Dashboard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnUsers;
        
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
            System.Uri resourceLocater = new System.Uri("/SPEEDYSOL;component/screens/dashboard.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Screens\Dashboard.xaml"
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
            this.btnSales = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\..\Screens\Dashboard.xaml"
            this.btnSales.Click += new System.Windows.RoutedEventHandler(this.btnSales_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btnPurchase = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\..\Screens\Dashboard.xaml"
            this.btnPurchase.Click += new System.Windows.RoutedEventHandler(this.btnPurchase_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnVouchers = ((System.Windows.Controls.Button)(target));
            
            #line 38 "..\..\..\Screens\Dashboard.xaml"
            this.btnVouchers.Click += new System.Windows.RoutedEventHandler(this.btnVouchers_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnGodowns = ((System.Windows.Controls.Button)(target));
            
            #line 43 "..\..\..\Screens\Dashboard.xaml"
            this.btnGodowns.Click += new System.Windows.RoutedEventHandler(this.btnGodowns_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnItems = ((System.Windows.Controls.Button)(target));
            
            #line 48 "..\..\..\Screens\Dashboard.xaml"
            this.btnItems.Click += new System.Windows.RoutedEventHandler(this.btnItems_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnUsers = ((System.Windows.Controls.Button)(target));
            
            #line 53 "..\..\..\Screens\Dashboard.xaml"
            this.btnUsers.Click += new System.Windows.RoutedEventHandler(this.btnUsers_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

