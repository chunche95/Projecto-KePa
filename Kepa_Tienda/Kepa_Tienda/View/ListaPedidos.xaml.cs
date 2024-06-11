using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using WPF_LoginForm.View;

namespace Kepa_Tienda.View
{
    public static class PedidoGlobal
    {
        public static List<Pedido> PedidosRealizados { get; } = new List<Pedido>();

        public static void AgregarPedido(Pedido nuevoPedido)
        {
            PedidosRealizados.Add(nuevoPedido);
        }
    }

    public partial class ListaPedidos : Window
    {
        private List<Pedido> pedidosRealizados;
        private Usuario usuarioActual;

        public ListaPedidos(List<Pedido> pedidosRealizados, Usuario usuarioActual)
        {
            InitializeComponent();
            this.usuarioActual = usuarioActual;
            this.pedidosRealizados = pedidosRealizados;
            MostrarPedidos();
            MostrarInformacionUsuario(usuarioActual);
            ConfigurarVisibilidadBotonAgregarDisco();
        }

        private void MostrarPedidos()
        {
            ListBoxPedidos.ItemsSource = pedidosRealizados;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // Abrir la página DetallesQueens y pasar el objeto Disco como parámetro
            Artistas artistas = new Artistas(usuarioActual);
            artistas.Show();
        }
        private void AgregarDisco_Click(object sender, RoutedEventArgs e)
        {
            // Abre un formulario o ventana para agregar discos
            AnadirDiscos anadirDiscos = new AnadirDiscos();
            anadirDiscos.Show();
            Hide();
        }

        private void IrInicio(object sender, RoutedEventArgs e)
        {
            Principal inicio = new Principal(usuarioActual);
            inicio.Show();
            Hide();
        }
        private void MostrarInformacionUsuario(Usuario usuario)
        {
            txtUserName.Text = usuario.Nombre;
            txtUserType.Text = usuario.Tipo;
            txtLastAccess.Text = usuario.HoraEntrada.ToString("g"); // Formato de fecha y hora general
            imgProfile.Source = new BitmapImage(new Uri(usuario.rutaimagen, UriKind.RelativeOrAbsolute));
        }
        private void IrAListaDeDeseos_Click(object sender, RoutedEventArgs e)
        {
            ListaDeDeseos DeseosWindow = new ListaDeDeseos(usuarioActual); // 

            DeseosWindow.MostrarDiscosEnLista();


            DeseosWindow.Show();
            Hide(); // Cierra la ventana actual
        }
        private void IrAListaDePedidos(object sender, RoutedEventArgs e)
        {
            ListaPedidos PedidosWindow = new ListaPedidos(PedidoGlobal.PedidosRealizados, usuarioActual);
            PedidosWindow.Show();
            Hide();
        }
        private void IrOfertas(object sender, RoutedEventArgs e)
        {
            Ofertas PedidosWindow = new Ofertas(usuarioActual);
            PedidosWindow.Show();
            Hide();

        }
        private void ConfigurarVisibilidadBotonAgregarDisco()
        {
            if (usuarioActual.Tipo == "admin")
            {
                AgregarDisco.Visibility = Visibility.Visible;
            }
            else
            {
                AgregarDisco.Visibility = Visibility.Collapsed;
            }
        }
       

        // Otros métodos y lógica que puedas necesitar...

        // Por ejemplo, un método para agregar un pedido a la lista global
        public static void AgregarPedido(Pedido nuevoPedido)
        {
            PedidoGlobal.PedidosRealizados.Add(nuevoPedido);
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
