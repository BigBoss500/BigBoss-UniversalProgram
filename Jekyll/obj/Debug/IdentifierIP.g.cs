﻿#pragma checksum "..\..\IdentifierIP.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "629E9D4482895CFCAEDDF6613B467D82A017906A5F573348BE73C8C1A75D8A2A"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Jekyll;
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


namespace Jekyll {
    
    
    /// <summary>
    /// IdentifierIP
    /// </summary>
    public partial class IdentifierIP : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\IdentifierIP.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border header;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\IdentifierIP.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CloseButton;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\IdentifierIP.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ParseXML;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\IdentifierIP.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox IDtext;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\IdentifierIP.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button RollupButton;
        
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
            System.Uri resourceLocater = new System.Uri("/Jekyll;component/identifierip.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\IdentifierIP.xaml"
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
            this.header = ((System.Windows.Controls.Border)(target));
            return;
            case 2:
            
            #line 24 "..\..\IdentifierIP.xaml"
            ((System.Windows.Controls.Border)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Drag);
            
            #line default
            #line hidden
            return;
            case 3:
            this.CloseButton = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\IdentifierIP.xaml"
            this.CloseButton.Click += new System.Windows.RoutedEventHandler(this.Close);
            
            #line default
            #line hidden
            return;
            case 4:
            this.ParseXML = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.IDtext = ((System.Windows.Controls.TextBox)(target));
            
            #line 47 "..\..\IdentifierIP.xaml"
            this.IDtext.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.IDtext_TextChanged);
            
            #line default
            #line hidden
            
            #line 47 "..\..\IdentifierIP.xaml"
            this.IDtext.KeyDown += new System.Windows.Input.KeyEventHandler(this.IDtext_KeyDown_1);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 57 "..\..\IdentifierIP.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.RollupButton = ((System.Windows.Controls.Button)(target));
            
            #line 64 "..\..\IdentifierIP.xaml"
            this.RollupButton.Click += new System.Windows.RoutedEventHandler(this.Rollup);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
