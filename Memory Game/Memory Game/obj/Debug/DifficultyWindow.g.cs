﻿#pragma checksum "..\..\DifficultyWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "81BC5D80B611EECF48F0999382CCF92766C577AFFE2D1915535EBBE654163312"
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
using System.Windows.Shell;


namespace Memory_Game {
    
    
    /// <summary>
    /// DifficultyWindow
    /// </summary>
    public partial class DifficultyWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 31 "..\..\DifficultyWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox Checkbox_Medium;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\DifficultyWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox Checkbox_Hard;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\DifficultyWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox Checkbox_Easy;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\DifficultyWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button1;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\DifficultyWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Closebutton;
        
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
            System.Uri resourceLocater = new System.Uri("/Memory Game;component/difficultywindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\DifficultyWindow.xaml"
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
            this.Checkbox_Medium = ((System.Windows.Controls.CheckBox)(target));
            
            #line 31 "..\..\DifficultyWindow.xaml"
            this.Checkbox_Medium.Checked += new System.Windows.RoutedEventHandler(this.CheckBox_Checked_Medium);
            
            #line default
            #line hidden
            
            #line 31 "..\..\DifficultyWindow.xaml"
            this.Checkbox_Medium.Unchecked += new System.Windows.RoutedEventHandler(this.Checkbox_Unchecked_Medium);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Checkbox_Hard = ((System.Windows.Controls.CheckBox)(target));
            
            #line 32 "..\..\DifficultyWindow.xaml"
            this.Checkbox_Hard.Checked += new System.Windows.RoutedEventHandler(this.CheckBox_Checked_Hard);
            
            #line default
            #line hidden
            
            #line 32 "..\..\DifficultyWindow.xaml"
            this.Checkbox_Hard.Unchecked += new System.Windows.RoutedEventHandler(this.Checkbox_Unchecked_Hard);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Checkbox_Easy = ((System.Windows.Controls.CheckBox)(target));
            
            #line 33 "..\..\DifficultyWindow.xaml"
            this.Checkbox_Easy.Checked += new System.Windows.RoutedEventHandler(this.CheckBox_Checked_Easy);
            
            #line default
            #line hidden
            
            #line 33 "..\..\DifficultyWindow.xaml"
            this.Checkbox_Easy.Unchecked += new System.Windows.RoutedEventHandler(this.Checkbox_Unchecked_Easy);
            
            #line default
            #line hidden
            return;
            case 4:
            this.button1 = ((System.Windows.Controls.Button)(target));
            
            #line 37 "..\..\DifficultyWindow.xaml"
            this.button1.Click += new System.Windows.RoutedEventHandler(this.Button_Click1);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Closebutton = ((System.Windows.Controls.Button)(target));
            
            #line 38 "..\..\DifficultyWindow.xaml"
            this.Closebutton.Click += new System.Windows.RoutedEventHandler(this.Closebutton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

