﻿#pragma checksum "..\..\NewGame.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "D443A64D042D3F4E5FA203B2D36AEB625361E9C0FB34F724CFAA7BE31D7F1803"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Memory_Game;
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


namespace Memory_Game {
    
    
    /// <summary>
    /// NewGame
    /// </summary>
    public partial class NewGame : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 46 "..\..\NewGame.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SpBtn;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\NewGame.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button MpBtn;
        
        #line default
        #line hidden
        
        
        #line 73 "..\..\NewGame.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock P1Text;
        
        #line default
        #line hidden
        
        
        #line 82 "..\..\NewGame.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox P1Input;
        
        #line default
        #line hidden
        
        
        #line 92 "..\..\NewGame.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock P2Text;
        
        #line default
        #line hidden
        
        
        #line 101 "..\..\NewGame.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox P2Input;
        
        #line default
        #line hidden
        
        
        #line 113 "..\..\NewGame.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CardAmount;
        
        #line default
        #line hidden
        
        
        #line 135 "..\..\NewGame.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BackBtn;
        
        #line default
        #line hidden
        
        
        #line 146 "..\..\NewGame.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ProceedBtn;
        
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
            System.Uri resourceLocater = new System.Uri("/Memory Game;component/newgame.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\NewGame.xaml"
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
            this.SpBtn = ((System.Windows.Controls.Button)(target));
            
            #line 52 "..\..\NewGame.xaml"
            this.SpBtn.Click += new System.Windows.RoutedEventHandler(this.SpBtn_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.MpBtn = ((System.Windows.Controls.Button)(target));
            
            #line 62 "..\..\NewGame.xaml"
            this.MpBtn.Click += new System.Windows.RoutedEventHandler(this.MpBtn_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.P1Text = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.P1Input = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.P2Text = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.P2Input = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.CardAmount = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 8:
            this.BackBtn = ((System.Windows.Controls.Button)(target));
            
            #line 138 "..\..\NewGame.xaml"
            this.BackBtn.Click += new System.Windows.RoutedEventHandler(this.BackBtn_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.ProceedBtn = ((System.Windows.Controls.Button)(target));
            
            #line 149 "..\..\NewGame.xaml"
            this.ProceedBtn.Click += new System.Windows.RoutedEventHandler(this.ProceedBtn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

