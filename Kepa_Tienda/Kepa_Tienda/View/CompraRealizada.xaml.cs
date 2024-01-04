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

            List<Disco> discosComprados = new List<Disco>(carrito); // Haciendo una copia de los discos en el carrito

            // Agregar los discos a la lista de pedidos
            Pedidos.AgregarPedido(discosComprados);

            // Vaciar el carrito
            carrito.Clear();

            // Mostrar la ventana principal u otra ventana según sea necesario
            Principal principal = new Principal();
            principal.Show();
            Close();
        }
    }
}
