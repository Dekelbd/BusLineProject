#pragma checksum "..\..\..\OtherWindows\AddDriverWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "57A568EB5E42B8426BD66A87A12424A0856DB8EF904F120E03ED10E8000EC487"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Model.Interfaces;
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
using UiClient.ViewModels;
using UiClient.Views;


namespace UiClient.OtherWindows {
    
    
    /// <summary>
    /// AddDriverWindow
    /// </summary>
    public partial class AddDriverWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 33 "..\..\..\OtherWindows\AddDriverWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox DriverFirstName;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\OtherWindows\AddDriverWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox DriverLastName;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\OtherWindows\AddDriverWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox DriverPhoneNumber;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\OtherWindows\AddDriverWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox DriverAddress;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\OtherWindows\AddDriverWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CreateDriverButton;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\OtherWindows\AddDriverWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Exit;
        
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
            System.Uri resourceLocater = new System.Uri("/UiClient;component/otherwindows/adddriverwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\OtherWindows\AddDriverWindow.xaml"
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
            this.DriverFirstName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.DriverLastName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.DriverPhoneNumber = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.DriverAddress = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.CreateDriverButton = ((System.Windows.Controls.Button)(target));
            return;
            case 6:
            this.Exit = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

