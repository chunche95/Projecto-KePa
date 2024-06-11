using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WPF_LoginForm.View;

namespace Kepa_Tienda.View
{
    public static class CarritoGlobal
    {
        public static List<Disco> DiscosSeleccionados { get; } = new List<Disco>();
    }

    public partial class Carrito : Window
    {
        List<Disco> discosSeleccionados = CarritoGlobal.DiscosSeleccionados;
        private Usuario usuarioActual;
        double total = 0;

        public void VaciarCarrito()
        {
            discosSeleccionados.Clear();
        }

        public Carrito()
        {
            InitializeComponent();
        }

        public void MostrarTotal()
        {
            total = 0;

            foreach (var disco in discosSeleccionados)
            {
                total += disco.Precio * disco.Cantidad;
            }

            TotalTextBlock.Text = $"Total: {total:C2}";
            // Muestra el total en formato de moneda
        }

        private void RealizarCompra_Click(object sender, RoutedEventArgs e)
        {
            DatosDePago datosPago = new DatosDePago(discosSeleccionados, total); // Pasar la lista 'carrito' como argumento
            datosPago.Show(); // Mostrar la ventana de DatosDePago
            Hide();
        }

        private void Carrito_Click(object sender, MouseButtonEventArgs e)
        {
            Carrito carritoWindow = new Carrito();
            carritoWindow.Show();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        public void MostrarDiscosEnCarrito()
        {
            // Obtener los discos seleccionados desde la lista global
            // Mostrar los discos en el ListBox (o cualquier otro control que uses)
            ListaDeDiscos.ItemsSource = discosSeleccionados;
            // Mostrar el total u otras operaciones si es necesario
            MostrarTotal();
        }
        private void AbrirVentanaContacUs(object sender, RoutedEventArgs e)
        {
            Contaco contacUsWindow = new Contaco();
            contacUsWindow.Show();
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

        private void Salir_Click(object sender, MouseButtonEventArgs e)
        {
            LoginView loginWindow = new LoginView(); // Crear una instancia de LoginView
            loginWindow.Show(); // Mostrar la ventana LoginView
            Close(); // Cerrar la ventana actual si es necesario
        }
    }
}
