using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using WPF_LoginForm.View;

namespace Kepa_Tienda.View
{
    public static class PedidoGlobal
    {
        public static List<Pedido> PedidosRealizados { get; } = new List<Pedido>();
    }

    /// <summary>
    /// Lógica de interacción para ListaPedidos.xaml
    /// </summary>
    public partial class ListaPedidos : Window
    {
        private List<Pedido> pedidosRealizados = PedidoGlobal.PedidosRealizados;

        public ListaPedidos(List<Pedido> pedidosRealizados)
        {
            InitializeComponent();
            MostrarPedidos();
        }

        private void MostrarPedidos()
        {
            ListBoxPedidos.ItemsSource = pedidosRealizados;
        }

        // Otros métodos y lógica que puedas necesitar...

        // Por ejemplo, un método para agregar un pedido a la lista global
        public static void AgregarPedido(Pedido nuevoPedido)
        {
            PedidoGlobal.PedidosRealizados.Add(nuevoPedido);
        }

        private void Volver(object sender, RoutedEventArgs e)
        {
            Principal mainWindow = new Principal(); // Reemplaza 'MainWindow' con el nombre de tu ventana principal
            mainWindow.Show();
            this.Close(); // Cierra la ventana actual
        }
        private void Carrito_Click(object sender, MouseButtonEventArgs e)
        {
            Carrito carritoWindow = new Carrito();

            // Pasar la lista de discos seleccionados al carrito
            carritoWindow.MostrarDiscosEnCarrito();

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
        private void Salir_Click(object sender, MouseButtonEventArgs e)
        {
            LoginView loginWindow = new LoginView(); // Crear una instancia de LoginView
            loginWindow.Show(); // Mostrar la ventana LoginView
            Close(); // Cerrar la ventana actual si es necesario
        }
    }
}
