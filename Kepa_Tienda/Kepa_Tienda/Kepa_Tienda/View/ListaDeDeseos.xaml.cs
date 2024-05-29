using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPF_LoginForm.View;

namespace Kepa_Tienda.View
{
    public static class ListaGlobal
    {
        public static List<Disco> DiscosSeleccionados { get; } = new List<Disco>();
    }
    /// <summary>
    /// Lógica de interacción para Carrito.xaml
    /// </summary>
    public partial class ListaDeDeseos : Window
    {
        List<Disco> discosDeseos = ListaGlobal.DiscosSeleccionados;


        public ListaDeDeseos()
        {
            InitializeComponent();
        }

        private void Carrito_Click(object sender, MouseButtonEventArgs e)
        {
            Carrito carritoWindow = new Carrito();
            carritoWindow.Show();
        }
        private void Volver(object sender, RoutedEventArgs e)
        {
            if (WindowManager.MainWindow != null)
            {
                // Muestra y activa la ventana principal
                WindowManager.MainWindow.Show();
                WindowManager.MainWindow.Activate();
            }

            // Oculta la ventana actual en lugar de cerrarla
            this.Hide();
        }
        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        public void MostrarDiscosEnLista()
        {
            // Mostrar los discos en la ListBox (o cualquier otro control que uses)
            ListaDeDiscos.ItemsSource = discosDeseos;
        }

        private void Salir_Click(object sender, MouseButtonEventArgs e)
        {
            LoginView loginWindow = new LoginView(); // Crear una instancia de LoginView
            loginWindow.Show(); // Mostrar la ventana LoginView
            Close(); // Cerrar la ventana actual si es necesario
        }
    }



}



