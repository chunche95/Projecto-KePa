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

    public partial class ConfirmacionDePago : Window
    {
        List<Disco> discosSeleccionados;
        private Usuario usuarioActual;
        double total = 0;

        public ConfirmacionDePago(List<Disco> discosCarrito)
        {
            InitializeComponent();
            discosSeleccionados =discosCarrito;
            MostrarDiscosEnCarrito();
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
            // Agregar los pedidos a la lista global de pedidos
            foreach (var disco in discosSeleccionados)
            {
                PedidoGlobal.AgregarPedido(new Pedido
                {
                    Titulo = disco.Titulo,
                    Precio = disco.Precio,
                    Cantidad = disco.Cantidad
                });
            }

            // Limpiar el carrito después de realizar la compra
            discosSeleccionados.Clear();

            // Mostrar la ventana de compra realizada
            CompraRealizada compraWindow = new CompraRealizada();
            compraWindow.Show();
            Close();
        }


        private void VaciarCarrito()
        {
            discosSeleccionados.Clear();
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
            
            ListaDeDiscos.ItemsSource = discosSeleccionados;
            // Mostrar el total u otras operaciones si es necesario
            MostrarTotal();
        }

        private void Volver(object sender, RoutedEventArgs e)
        {
            Principal mainWindow = new Principal(usuarioActual); 
            mainWindow.Show();
            Close(); // Cierra la ventana actual
        }

        private void Salir_Click(object sender, MouseButtonEventArgs e)
        {
            LoginView loginWindow = new LoginView(); // Crear una instancia de LoginView
            loginWindow.Show(); // Mostrar la ventana LoginView
            Close(); // Cerrar la ventana actual si es necesario
        }
    }
}

