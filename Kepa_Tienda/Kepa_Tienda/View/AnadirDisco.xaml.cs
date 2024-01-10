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
    public partial class DatosDePago : Window
    {
        private List<Pago> datosDePago = new List<Pago>();
        private List<Disco> carrito = new List<Disco>(); // Lista de discos en el carrito

        public DatosDePago(List<Disco> discosEnCarrito) // Modifica el constructor para recibir la lista de discos en el carrito
        {
            InitializeComponent();
            carrito = discosEnCarrito; // Asigna la lista de discos al campo local carrito
        }


        private void Carrito_Click(object sender, MouseButtonEventArgs e)
        {
            // Lógica para manejar el evento del carrito
            // ...
        }
        private void confirmar_Click(object sender, RoutedEventArgs e)
        {
            Pago nuevoPago = new Pago
            {
                Nombre = txtUser.Text,
                NumeroTarjeta = txtUser_Copy.Text,
                FechaVencimiento = txtUser_Copy1.Text,
                CodigoSeguridad = txtUser_Copy2.Text
            };

            datosDePago.Add(nuevoPago);

            // Pasar ambas listas al constructor de ConfirmacionDePago
            ConfirmacionDePago confirmacionWindow = new ConfirmacionDePago(datosDePago, carrito);
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
        private void Volver(object sender, RoutedEventArgs e)
        {
            Principal mainWindow = new Principal(); // Reemplaza 'MainWindow' con el nombre de tu ventana principal
            mainWindow.Show();
            this.Close(); // Cierra la ventana actual
        }
        private void Salir_Click(object sender, MouseButtonEventArgs e)
        {
            LoginView loginWindow = new LoginView(); // Crear una instancia de LoginView
            loginWindow.Show(); // Mostrar la ventana LoginView
            Close(); // Cerrar la ventana actual si es necesario
        }
    }
}

