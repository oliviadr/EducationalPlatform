﻿#pragma checksum "..\..\..\Views\ProfesoriAbsente.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "BE0A5A81296C95F43DB9679F9B9FDD65AB545CE9CD5CF9763E42E3353C6F6C95"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using PlatformaEducationala.Converters;
using PlatformaEducationala.ViewModels;
using PlatformaEducationala.Views;
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


namespace PlatformaEducationala.Views {
    
    
    /// <summary>
    /// ProfesoriAbsente
    /// </summary>
    public partial class ProfesoriAbsente : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 160 "..\..\..\Views\ProfesoriAbsente.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid absenteDG;
        
        #line default
        #line hidden
        
        
        #line 191 "..\..\..\Views\ProfesoriAbsente.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox txtIdSubject;
        
        #line default
        #line hidden
        
        
        #line 200 "..\..\..\Views\ProfesoriAbsente.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox txtIdStudent;
        
        #line default
        #line hidden
        
        
        #line 208 "..\..\..\Views\ProfesoriAbsente.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker txtDataAbsence;
        
        #line default
        #line hidden
        
        
        #line 213 "..\..\..\Views\ProfesoriAbsente.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox txtEsteMotivata;
        
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
            System.Uri resourceLocater = new System.Uri("/PlatformaEducationala;component/views/profesoriabsente.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\ProfesoriAbsente.xaml"
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
            this.absenteDG = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 2:
            this.txtIdSubject = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.txtIdStudent = ((System.Windows.Controls.ComboBox)(target));
            
            #line 202 "..\..\..\Views\ProfesoriAbsente.xaml"
            this.txtIdStudent.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.txtIdStudent_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.txtDataAbsence = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 5:
            this.txtEsteMotivata = ((System.Windows.Controls.CheckBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

