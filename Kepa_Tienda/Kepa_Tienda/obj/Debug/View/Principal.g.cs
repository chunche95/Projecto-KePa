﻿#pragma checksum "..\..\..\View\Principal.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "FB60D87A9BFCF5C77EE1DEA36663E498F2FD44E65F5D36D80D9A69FAF6E30528"
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
    /// Principal
    /// </summary>
    public partial class Principal : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 48 "..\..\..\View\Principal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border SearchBorder;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\View\Principal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SearchTextBox;
        
        #line default
        #line hidden
        
        
        #line 81 "..\..\..\View\Principal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtUserName;
        
        #line default
        #line hidden
        
        
        #line 83 "..\..\..\View\Principal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image imgProfile;
        
        #line default
        #line hidden
        
        
        #line 85 "..\..\..\View\Principal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtUserType;
        
        #line default
        #line hidden
        
        
        #line 87 "..\..\..\View\Principal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtLastAccess;
        
        #line default
        #line hidden
        
        
        #line 99 "..\..\..\View\Principal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbIdiomas;
        
        #line default
        #line hidden
        
        
        #line 107 "..\..\..\View\Principal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBoxItem cbItem1;
        
        #line default
        #line hidden
        
        
        #line 108 "..\..\..\View\Principal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBoxItem cbItem2;
        
        #line default
        #line hidden
        
        
        #line 110 "..\..\..\View\Principal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnMinimize;
        
        #line default
        #line hidden
        
        
        #line 153 "..\..\..\View\Principal.xaml"
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
            System.Uri resourceLocater = new System.Uri("/Kepa_Tienda;component/view/principal.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\Principal.xaml"
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
            
            #line 33 "..\..\..\View\Principal.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.IrAListaDeDeseos_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 34 "..\..\..\View\Principal.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.IrAListaDePedidos);
            
            #line default
            #line hidden
            return;
            case 3:
            this.SearchBorder = ((System.Windows.Controls.Border)(target));
            return;
            case 4:
            this.SearchTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            
            #line 79 "..\..\..\View\Principal.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.txtUserName = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.imgProfile = ((System.Windows.Controls.Image)(target));
            return;
            case 8:
            this.txtUserType = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            this.txtLastAccess = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 10:
            
            #line 90 "..\..\..\View\Principal.xaml"
            ((System.Windows.Controls.TextBox)(target)).TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TextBox_TextChanged_1);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 96 "..\..\..\View\Principal.xaml"
            ((System.Windows.Controls.Image)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Carrito_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 98 "..\..\..\View\Principal.xaml"
            ((System.Windows.Controls.Image)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Carrito_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            this.cbIdiomas = ((System.Windows.Controls.ComboBox)(target));
            
            #line 104 "..\..\..\View\Principal.xaml"
            this.cbIdiomas.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cb_elementoSeleccionado);
            
            #line default
            #line hidden
            return;
            case 14:
            this.cbItem1 = ((System.Windows.Controls.ComboBoxItem)(target));
            return;
            case 15:
            this.cbItem2 = ((System.Windows.Controls.ComboBoxItem)(target));
            return;
            case 16:
            this.btnMinimize = ((System.Windows.Controls.Button)(target));
            
            #line 118 "..\..\..\View\Principal.xaml"
            this.btnMinimize.Click += new System.Windows.RoutedEventHandler(this.btnMinimize_Click);
            
            #line default
            #line hidden
            return;
            case 17:
            this.btnClose = ((System.Windows.Controls.Button)(target));
            
            #line 161 "..\..\..\View\Principal.xaml"
            this.btnClose.Click += new System.Windows.RoutedEventHandler(this.btnClose_Click);
            
            #line default
            #line hidden
            return;
            case 18:
            
            #line 193 "..\..\..\View\Principal.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.IrADetalles);
            
            #line default
            #line hidden
            return;
            case 19:
            
            #line 205 "..\..\..\View\Principal.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.IrADetallesQueens);
            
            #line default
            #line hidden
            return;
            case 20:
            
            #line 217 "..\..\..\View\Principal.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.IrADetalles);
            
            #line default
            #line hidden
            return;
            case 21:
            
            #line 229 "..\..\..\View\Principal.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.IrADetalles);
            
            #line default
            #line hidden
            return;
            case 22:
            
            #line 241 "..\..\..\View\Principal.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.IrADetalles);
            
            #line default
            #line hidden
            return;
            case 23:
            
            #line 253 "..\..\..\View\Principal.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.IrADetalles);
            
            #line default
            #line hidden
            return;
            case 24:
            
            #line 265 "..\..\..\View\Principal.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.IrADetalles);
            
            #line default
            #line hidden
            return;
            case 25:
            
            #line 277 "..\..\..\View\Principal.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.IrADetalles);
            
            #line default
            #line hidden
            return;
            case 26:
            
            #line 289 "..\..\..\View\Principal.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.IrADetalles);
            
            #line default
            #line hidden
            return;
            case 27:
            
            #line 311 "..\..\..\View\Principal.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.IrADetalles);
            
            #line default
            #line hidden
            return;
            case 28:
            
            #line 334 "..\..\..\View\Principal.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.IrADetalles);
            
            #line default
            #line hidden
            return;
            case 29:
            
            #line 357 "..\..\..\View\Principal.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.IrADetalles);
            
            #line default
            #line hidden
            return;
            case 30:
            
            #line 380 "..\..\..\View\Principal.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.IrADetalles);
            
            #line default
            #line hidden
            return;
            case 31:
            
            #line 403 "..\..\..\View\Principal.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.IrADetalles);
            
            #line default
            #line hidden
            return;
            case 32:
            
            #line 426 "..\..\..\View\Principal.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.IrADetalles);
            
            #line default
            #line hidden
            return;
            case 33:
            
            #line 449 "..\..\..\View\Principal.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.IrADetalles);
            
            #line default
            #line hidden
            return;
            case 34:
            
            #line 472 "..\..\..\View\Principal.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.IrADetalles);
            
            #line default
            #line hidden
            return;
            case 35:
            
            #line 495 "..\..\..\View\Principal.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.IrADetalles);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

