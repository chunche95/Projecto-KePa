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
    /// Lógica de interacción para Principal.xaml
    /// </summary>
    public partial class Principal : Window
    {
        private Usuario usuarioActual;

        public Principal()
        {
            InitializeComponent();
            CargarDiscos(); // Cargar los discos al iniciar la ventana
        }
        private void AgregarDisco_Click(object sender, RoutedEventArgs e)
        {
            // Abre un formulario o ventana para agregar discos
            FormularioAgregarDisco formulario = new FormularioAgregarDisco(this);
            formulario.Show();
        }

        public void ConfigurarUsuarioActual(Usuario usuario)
        {
            usuarioActual = usuario;
            ConfigurarInterfazSegunRol();
        }
        private Disco ObtenerDiscoSeleccionado()
        {
            // Lógica para obtener el disco seleccionado
            // Por ejemplo, si tienes una lista de discos en un ListBox y quieres obtener el disco seleccionado:
            if (listBoxDiscos.SelectedItem is Disco discoSeleccionado)
            {
                return discoSeleccionado;
            }

            return null; // En caso de no haber seleccionado ningún disco
        }
        private void ConfigurarInterfazSegunRol()
        {
            if (usuarioActual.Rol == RolUsuario.Administrador)
            {
                // Si es un administrador, habilitar ciertas funcionalidades
                adminButtons.Visibility = Visibility.Visible; // Mostrar los botones para el administrador
            }
            else
            {
                // Si es un usuario normal, deshabilitar ciertas funcionalidades
                adminButtons.Visibility = Visibility.Collapsed; // Ocultar los botones para el administrador
            }
        }
        private void borrar(object sender, RoutedEventArgs e)
        {
            // Mostrar un MessageBox para confirmar la acción
            MessageBoxResult result = MessageBox.Show("¿Estás seguro que deseas eliminar este disco?", "Confirmar Eliminación", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                // Lógica para eliminar el disco aquí
                // Supongamos que tienes una lista de discos y quieres eliminar el disco seleccionado

                // Pseudocódigo:
                // Obtener el disco seleccionado
                Disco discoSeleccionado = ObtenerDiscoSeleccionado();

                // Eliminar el disco de la lista
                if (discoSeleccionado != null)
                {
                    // Eliminar discoSeleccionado de la lista de discos
                    EliminarDisco(discoSeleccionado);

                    // Actualizar la interfaz para reflejar los cambios
                    ActualizarInterfaz();
                }
            }
        }

        private List<Disco> listaDeDiscos = new List<Disco>(); // Declaración de la lista de discos

        // Método para cargar la lista de discos (puede variar dependiendo de tu aplicación)
        private void CargarDiscos()
        {
            // Ejemplo de cómo podrías cargar discos a la lista
            listaDeDiscos.Add(new Disco { Titulo = "Título del Disco 1", Precio = 10.99, ... });
            listaDeDiscos.Add(new Disco { Titulo = "Título del Disco 2", Precio = 15.99, ... });

            // Mostrar los discos en el ListBox
            foreach (var disco in listaDeDiscos)
            {
                ListBoxDiscos.Items.Add(disco); // Añadir el disco al ListBox
            }
        }


        private void EliminarDisco(Disco discoSeleccionado)
        {
            if (discoSeleccionado != null && listaDeDiscos.Contains(discoSeleccionado))
            {
                listaDeDiscos.Remove(discoSeleccionado); // Elimina el disco de la lista

                // Aquí debes actualizar la interfaz para reflejar los cambios.
                // Por ejemplo, si 'listBoxDiscos' es tu ListBox que muestra los discos,
                // podrías hacer algo como:
                listBoxDiscos.Items.Remove(discoSeleccionado); // Elimina el disco del ListBox
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
        public void MostrarDatosUsuario(string nombreUsuario, string rutaFotoPerfil, string tipoUsuario)
        {
            txtUserName.Text = nombreUsuario; // Asignar el nombre de usuario al TextBlock correspondiente
            imgProfile.Source = new BitmapImage(new Uri(rutaFotoPerfil)); // Asignar la imagen de perfil
            txtUserType.Text = $"{tipoUsuario}"; // Asignar el tipo de usuario
            txtLastAccess.Text = $"{DateTime.Now}"; // Asignar la fecha de último acceso (fecha actual)
        }

        private void Salir_Click(object sender, MouseButtonEventArgs e)
        {
            LoginView loginWindow = new LoginView(); // Crear una instancia de LoginView
            loginWindow.Show(); // Mostrar la ventana LoginView
            Close(); // Cerrar la ventana actual si es necesario
        }

    }
}
