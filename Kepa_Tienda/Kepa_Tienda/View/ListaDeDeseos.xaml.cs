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
   
    public partial class ListaDeDeseos : Window
    {
        List<Disco> discosDeseos = ListaGlobal.DiscosSeleccionados;
        private Usuario usuarioActual;

        public ListaDeDeseos(Usuario usuarioActual)
        {
            InitializeComponent();
            this.usuarioActual = usuarioActual;
            MostrarInformacionUsuario(usuarioActual);
            ConfigurarVisibilidadBotonAgregarDisco();
            
        }
        private void MostrarInformacionUsuario(Usuario usuario)
        {
            txtUserName.Text = usuario.Nombre;
            txtUserType.Text = usuario.Tipo;
            txtLastAccess.Text = usuario.HoraEntrada.ToString("g"); // Formato de fecha y hora general
            imgProfile.Source = new BitmapImage(new Uri(usuario.rutaimagen, UriKind.RelativeOrAbsolute));
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
        private void IrInicio(object sender, RoutedEventArgs e)
        {
            Principal inicio = new Principal( usuarioActual);
            inicio.Show();
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



