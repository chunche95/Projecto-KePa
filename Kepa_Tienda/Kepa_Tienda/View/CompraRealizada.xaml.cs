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
    /// Lógica de interacción para CompraRealizada.xaml
    /// </summary>
    public partial class CompraRealizada : Window
    { 

        private List<Disco> carrito = new List<Disco>(); // Define la lista de discos seleccionados

    public CompraRealizada()
        {
            InitializeComponent();
        }

        private void Carrito_Click(object sender, MouseButtonEventArgs e)
        {
            Carrito carritoWindow = new Carrito();

            // Pasar la lista de discos seleccionados al carrito
            carritoWindow.MostrarDiscosEnCarrito();

            carritoWindow.Show();
            Close();
        }

        private void confirmar_Click(object sender, RoutedEventArgs e)
        {
            // Vaciar el carrito
            carrito.Clear();
            WindowManager.MainWindow.Show();
            WindowManager.MainWindow.Activate();

            // Oculta la ventana actual en lugar de cerrarla
            this.Hide();
        }
        private void Salir_Click(object sender, MouseButtonEventArgs e)
        {
            LoginView loginWindow = new LoginView(); // Crear una instancia de LoginView
            loginWindow.Show(); // Mostrar la ventana LoginView
            Close(); // Cerrar la ventana actual si es necesario
        }
    }

}
