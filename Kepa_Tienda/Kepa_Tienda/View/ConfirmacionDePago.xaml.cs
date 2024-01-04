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


namespace Kepa_Tienda.View
{
    public partial class ConfirmacionDePago : Window
    {
        private List<Pedido> pedidos = new List<Pedido>();
        private List<Disco> discosCarrito;

        public ConfirmacionDePago(List<Pago> datosPago, List<Disco> discosCarrito)
        {
            InitializeComponent();
            this.DataContext = datosPago;
            this.discosCarrito = discosCarrito;
            ListaDiscos.ItemsSource = discosCarrito;
        }

        private void Comprar_Click(object sender, RoutedEventArgs e)
        {
            // Transferir los discos del carrito a la lista de pedidos
            List<Pedido> pedidos = new List<Pedido>(); // Crear la lista local para los pedidos de esta transacción

            foreach (var disco in discosCarrito)
            {
                pedidos.Add(new Pedido
                {
                    Titulo = disco.Titulo,
                    Precio = disco.Precio,
                    Cantidad = disco.Cantidad
                });
            }

            // Agregar los pedidos a la lista global de pedidos
            foreach (var pedido in pedidos)
            {
                ListaPedidos.AgregarPedido(pedido);
            }

            // Limpiar el carrito después de realizar la compra
            discosCarrito.Clear();

            // Mostrar la ventana de compra realizada
            CompraRealizada compraWindow = new CompraRealizada();
            compraWindow.Show();
        }
        private void Carrito_Click(object sender, MouseButtonEventArgs e)
        {
            // Lógica para manejar el evento del carrito
            // ...
        }
       

        private void ListaDeDiscos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

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
    }
}

