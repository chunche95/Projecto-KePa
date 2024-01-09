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
    /// <summary>
    /// Lógica de interacción para PanelDeAdministrador.xaml
    /// </summary>
    public partial class PanelDeAdministrador : Window
    {
        public PanelDeAdministrador()
        {
            InitializeComponent();
        }
        public void MostrarDatosUsuario(string nombreUsuario, string rutaFotoPerfil, string tipoUsuario)
        {
            txtUserName.Text = nombreUsuario; // Asignar el nombre de usuario al TextBlock correspondiente
            imgProfile.Source = new BitmapImage(new Uri(rutaFotoPerfil)); // Asignar la imagen de perfil
            txtUserType.Text = $"{tipoUsuario}"; // Asignar el tipo de usuario
            txtLastAccess.Text = $"{DateTime.Now}"; // Asignar la fecha de último acceso (fecha actual)
        }






        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void IrAListaDeDeseos_Click(object sender, RoutedEventArgs e)
        {
            ListaDeDeseos DeseosWindow = new ListaDeDeseos(); // 

            DeseosWindow.MostrarDiscosEnLista();


            DeseosWindow.Show();
            this.Close(); // Cierra la ventana actual
        }
        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_TextChanged_2(object sender, TextChangedEventArgs e)
        {

        }

        private void cb_elementoSeleccionado(object sender, SelectionChangedEventArgs e)
        {

        }

        private void IrADetalles(object sender, RoutedEventArgs e)
        {
            // Código para abrir la ventana de DetallesKrisschasy
            DetallesKrisschasy detallesWindow = new DetallesKrisschasy();
            detallesWindow.Show();

            Close(); // O
        }

        private void IrADetallesQueens(object sender, RoutedEventArgs e)
        {
            // Código para abrir la ventana de DetallesQueens
            DetallesQueens detallesQWindow = new DetallesQueens();
            detallesQWindow.Show();

            Close();
        }

        private void EditarKrissChasy(object sender, RoutedEventArgs e)
        {
            // Código para abrir la ventana de DetallesKrisschasy
            DetallesKrisschasy detallesWindow = new DetallesKrisschasy();
            detallesWindow.Show();

            Close(); // O
        }
        private void IrAListaDePedidos(object sender, RoutedEventArgs e)
        {
            ListaPedidos PedidosWindow = new ListaPedidos(PedidoGlobal.PedidosRealizados);
            PedidosWindow.Show();
            this.Close();
        }
        private void Carrito_Click(object sender, MouseButtonEventArgs e)
        {
            Carrito carritoWindow = new Carrito();

            // Pasar la lista de discos seleccionados al carrito
            carritoWindow.MostrarDiscosEnCarrito();

            carritoWindow.Show();
        }
       
            private void Salir_Click(object sender, MouseButtonEventArgs e)
            {
                LoginView loginWindow = new LoginView(); // Crear una instancia de LoginView
                loginWindow.Show(); // Mostrar la ventana LoginView
                Close(); // Cerrar la ventana actual si es necesario
            }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void borrar(object sender, RoutedEventArgs e)
        {

        }
    }
}

