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
    public static class ListaGlobal
    {
        public static List<Disco> DiscosSeleccionados { get; } = new List<Disco>();
    }
    /// <summary>
    /// Lógica de interacción para Carrito.xaml
    /// </summary>
    public partial class ListaDeDeseos : Window
    {
        List<Disco> discosDeseos = ListaGlobal.DiscosSeleccionados;


        public ListaDeDeseos()
        {
            InitializeComponent();
        }

        private void Carrito_Click(object sender, MouseButtonEventArgs e)
        {
            Carrito carritoWindow = new Carrito();
            carritoWindow.Show();
        }
        private void Volver(object sender, RoutedEventArgs e)
        {
            Principal mainWindow = new Principal(); // Reemplaza 'MainWindow' con el nombre de tu ventana principal
            mainWindow.Show();
            this.Close(); // Cierra la ventana actual
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





    }

}

