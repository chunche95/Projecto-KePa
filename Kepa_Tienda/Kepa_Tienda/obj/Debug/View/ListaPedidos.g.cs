﻿#pragma checksum "..\..\..\View\ListaPedidos.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "84F0F4863EB769EB7D89CE0C945711E1C272BACA90BAF2F6FEF604AE369896D6"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using Kepa_Tienda.View;
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


namespace Kepa_Tienda.View {
    
    
    /// <summary>
    /// ListaPedidos
    /// </summary>
    public partial class ListaPedidos : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 80 "..\..\..\View\ListaPedidos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AgregarDisco;
        
        #line default
        #line hidden
        
        
        #line 84 "..\..\..\View\ListaPedidos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtUserName;
        
        #line default
        #line hidden
        
        
        #line 86 "..\..\..\View\ListaPedidos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image imgProfile;
        
        #line default
        #line hidden
        
        
        #line 88 "..\..\..\View\ListaPedidos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtUserType;
        
        #line default
        #line hidden
        
        
        #line 90 "..\..\..\View\ListaPedidos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtLastAccess;
        
        #line default
        #line hidden
        
        
        #line 117 "..\..\..\View\ListaPedidos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox ListBoxPedidos;
        
        #line default
        #line hidden
        
        
        #line 131 "..\..\..\View\ListaPedidos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border SearchBorder;
        
        #line default
        #line hidden
        
        
        #line 159 "..\..\..\View\ListaPedidos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SearchTextBox;
        
        #line default
        #line hidden
        
        
        #line 183 "..\..\..\View\ListaPedidos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnMinimize;
        
        #line default
        #line hidden
        
        
        #line 221 "..\..\..\View\ListaPedidos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnClose;
        
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
            System.Uri resourceLocater = new System.Uri("/Kepa_Tienda;component/view/listapedidos.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\ListaPedidos.xaml"
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
            
            #line 75 "..\..\..\View\ListaPedidos.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.IrInicio);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 76 "..\..\..\View\ListaPedidos.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_1);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 77 "..\..\..\View\ListaPedidos.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.IrOfertas);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 78 "..\..\..\View\ListaPedidos.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.IrAListaDeDeseos_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 79 "..\..\..\View\ListaPedidos.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.IrAListaDePedidos);
            
            #line default
            #line hidden
            return;
            case 6:
            this.AgregarDisco = ((System.Windows.Controls.Button)(target));
            
            #line 80 "..\..\..\View\ListaPedidos.xaml"
            this.AgregarDisco.Click += new System.Windows.RoutedEventHandler(this.AgregarDisco_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.txtUserName = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.imgProfile = ((System.Windows.Controls.Image)(target));
            return;
            case 9:
            this.txtUserType = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 10:
            this.txtLastAccess = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 11:
            
            #line 102 "..\..\..\View\ListaPedidos.xaml"
            ((System.Windows.Controls.Image)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Salir_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 103 "..\..\..\View\ListaPedidos.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Volver);
            
            #line default
            #line hidden
            return;
            case 13:
            this.ListBoxPedidos = ((System.Windows.Controls.ListBox)(target));
            return;
            case 14:
            this.SearchBorder = ((System.Windows.Controls.Border)(target));
            return;
            case 15:
            this.SearchTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 16:
            this.btnMinimize = ((System.Windows.Controls.Button)(target));
            
            #line 190 "..\..\..\View\ListaPedidos.xaml"
            this.btnMinimize.Click += new System.Windows.RoutedEventHandler(this.btnMinimize_Click);
            
            #line default
            #line hidden
            return;
            case 17:
            this.btnClose = ((System.Windows.Controls.Button)(target));
            
            #line 228 "..\..\..\View\ListaPedidos.xaml"
            this.btnClose.Click += new System.Windows.RoutedEventHandler(this.btnClose_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

