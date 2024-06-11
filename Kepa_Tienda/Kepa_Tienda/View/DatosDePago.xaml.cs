using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using WPF_LoginForm.View;

namespace Kepa_Tienda.View
{
    public partial class DatosDePago : Window
    {
        private List<Disco> carrito; // Lista de discos en el carrito

        public DatosDePago(List<Disco> discosEnCarrito, double total) // Modifica el constructor para recibir la lista de discos en el carrito y el total
        {
            InitializeComponent();
            carrito = discosEnCarrito; // Asigna la lista de discos al campo local carrito
            MostrarTotal(total); // Muestra el total en la interfaz de usuario
        }

        private void MostrarTotal(double total)
        {
            PagarTextBox.Text = $"Total a pagar: {total:C2}";
           
        }

        private void Carrito_Click(object sender, MouseButtonEventArgs e)
        {
        }
            

        private void Guardar_Click(object sender, RoutedEventArgs e)
        {
            Pago nuevoPago = new Pago
            {
                Nombre = TitularTextBox.Text,
                NumeroTarjeta = TarjetaTextBox.Text,
                FechaVencimiento = FechaTextBox.Text,
                CodigoSeguridad = CVVTextBox.Text
            };

            // Crear una instancia de la lista de pagos
            List<Pago> datosDePago = new List<Pago>();
            datosDePago.Add(nuevoPago);

            // Pasar ambas listas al constructor de ConfirmacionDePago
            ConfirmacionDePago confirmacionWindow = new ConfirmacionDePago(carrito);
            confirmacionWindow.Show();
            Close();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Volver_Click(object sender, RoutedEventArgs e)
        {
            if (WindowManager.MainWindow != null)
            {
                // Muestra y activa la ventana principal
                WindowManager.MainWindow.Show();
                WindowManager.MainWindow.Activate();
            }

            // Oculta la ventana actual en lugar de cerrarla
            Hide();
        }

        private void Salir_Click(object sender, MouseButtonEventArgs e)
        {
            LoginView loginWindow = new LoginView(); // Crear una instancia de LoginView
            loginWindow.Show(); // Mostrar la ventana LoginView
            Close(); // Cerrar la ventana actual si es necesario
        }
    }
}
