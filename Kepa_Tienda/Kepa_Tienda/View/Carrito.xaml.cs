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
    public static class CarritoGlobal
    {
        public static List<Disco> DiscosSeleccionados { get; } = new List<Disco>();
    }
    /// <summary>
    /// Lógica de interacción para Carrito.xaml
    /// </summary>
    public partial class Carrito : Window
    {
        List<Disco> discosSeleccionados = CarritoGlobal.DiscosSeleccionados;
       

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
            double total = 0;

            foreach (var disco in discosSeleccionados)
            {
                total += disco.Precio * disco.Cantidad;
            }

            TotalTextBlock.Text = $"Total: {total:C2}"; // Muestra el total en formato de moneda
        }



 
 
        private void Carrito_Click(object sender, MouseButtonEventArgs e)
        {
            Carrito carritoWindow = new Carrito();
            carritoWindow.Show();
        }

   

        private void RealizarCompra_Click(object sender, RoutedEventArgs e)
        {
            DatosDePago datosPago = new DatosDePago(discosSeleccionados); // Pasar la lista 'carrito' como argumento
            datosPago.Show(); // Mostrar la ventana de DatosDePago
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

