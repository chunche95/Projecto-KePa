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
    /// Lógica de interacción para DetallesArtistas.xaml
    /// </summary>
    public partial class DetallesArtistas : Window
    {
        public List<Disco> discosEnCarrito = new List<Disco>();
        public List<Disco> discosEnListaDeDeseos = new List<Disco>();
        private Carrito carritoWindow;
        private ListaDeDeseos DeseosWindow;
        private Disco disco;
        private Artista artista;
        public DetallesArtistas(Artista artista)
        {
            InitializeComponent();
            
          
        }


        private void Salir_Click(object sender, MouseButtonEventArgs e)
        {
            LoginView loginWindow = new LoginView(); // Crear una instancia de LoginView
            loginWindow.Show(); // Mostrar la ventana LoginView
            Close(); // Cerrar la ventana actual si es necesario
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
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
            Hide();
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void Carrito_Click(object sender, MouseButtonEventArgs e)
        {
            Carrito carritoWindow = new Carrito();

            // Pasar la lista de discos seleccionados al carrito
            carritoWindow.MostrarDiscosEnCarrito();

            carritoWindow.Show();
            Close();
        }



        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            // Implementa la lógica para el evento TextBox_TextChanged_1
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // Lógica para el evento Window_MouseDown
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
