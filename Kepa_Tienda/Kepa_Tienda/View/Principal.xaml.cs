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
using static Kepa_Tienda.View.AnadirDiscos;

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

            // Obtener la instancia de LoginView desde las ventanas abiertas
            LoginView loginView = Application.Current.Windows.OfType<LoginView>().FirstOrDefault();

            // Asegúrate de que loginView no sea null antes de llamar a ObtenerUsuario
            if (loginView != null)
            {
                // Llama a ObtenerUsuario para obtener el usuario actual
                Usuario usuarioActual = loginView.ObtenerUsuario();

                // Asegúrate de que usuarioActual no sea null antes de llamar a ConfigurarUsuarioActual
                if (usuarioActual != null)
                {
                    // Llama a ConfigurarUsuarioActual con el usuario obtenido
                    ConfigurarUsuarioActual(usuarioActual);

                    // Llama a MostrarDatosUsuario con la información del usuario
                    MostrarDatosUsuario(usuarioActual.Nombre, usuarioActual.RutaFotoPerfil, usuarioActual.Rol);
                }

            }
        }


        public void ConfigurarUsuarioActual(Usuario usuario)
        {
            usuarioActual = usuario;
            ConfigurarInterfazSegunRol();
        }

        private void AgregarDisco_Click(object sender, RoutedEventArgs e)
        {
            // Abre un formulario o ventana para agregar discos
            AnadirDiscos anadirDiscos = new AnadirDiscos();
            anadirDiscos.Show();
            Close();
        }


        private void ConfigurarInterfazSegunRol()
        {
            if (usuarioActual.Rol == RolUsuario.Administrador)
            {
                // Si es un administrador, habilitar ciertas funcionalidades
                adminButtonsQueens.Visibility = Visibility.Visible;
                adminButtonsKissChasy.Visibility = Visibility.Visible;// Mostrar los botones para el administrador
                AgregarDisco.Visibility = Visibility.Visible;
            }
            else
            {
                // Si es un usuario normal, deshabilitar ciertas funcionalidades
                adminButtonsQueens.Visibility = Visibility.Collapsed; // Ocultar los botones para el administrador
                adminButtonsKissChasy.Visibility = Visibility.Collapsed;

            }
        }

        private void Borrar_Click(object sender, RoutedEventArgs e)
        {
            // Mostrar un MessageBox para confirmar la acción
            MessageBoxResult result = MessageBox.Show("¿Estás seguro que deseas eliminar este disco?", "Confirmar Eliminación", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                // Obtener el disco seleccionado
                Disco discoSeleccionado = ObtenerDiscoSeleccionado();

                // Eliminar el disco de la lista
                if (discoSeleccionado != null)
                {
                    // Eliminar discoSeleccionado de la lista de discos existentes
                    AnadirDiscos.DiscoGlobal.DiscosExistentes.Remove(discoSeleccionado);

                    // Actualizar la interfaz para reflejar los cambios
                    ActualizarInterfaz();
                }
            }

            // Llamada correcta a la función MostrarDatosUsuario
            MostrarDatosUsuario(usuarioActual.Nombre, usuarioActual.RutaFotoPerfil, usuarioActual.Rol);
        }


        // Método para actualizar la interfaz después de eliminar el disco
        private void ActualizarInterfaz()
        {
            // Actualizar la vista del ListBox
            ListBoxDiscos.Items.Refresh();
        }


        // Método para obtener el disco seleccionado (adaptar según cómo se obtenga el disco seleccionado)
        private Disco ObtenerDiscoSeleccionado()
        {
            // Implementa la lógica para obtener el disco seleccionado, por ejemplo, desde un ListBox
            // Puedes acceder al ListBox y obtener el disco seleccionado de la siguiente manera:
            if (ListBoxDiscos.SelectedItem != null)
            {
                return ListBoxDiscos.SelectedItem as Disco;
            }
            else
            {
                return null;
            }
        }

        // Método para actualizar la interfaz después de eliminar el disco


        private void Editar_Click(object sender, RoutedEventArgs e)
        {

            // Código para abrir la ventana de DetallesKrisschasy
            DetallesKrisschasy detallesWindow = new DetallesKrisschasy();
            detallesWindow.Show();

            Close(); // 
        }

        private List<Disco> listaDeDiscos = new List<Disco>(); // Declaración de la lista de discos

        // Método para cargar la lista de discos (puede variar dependiendo de tu aplicación)
        private void CargarDiscos()
        {
            // Verifica si la ListBox tiene elementos
            if (ListBoxDiscos.Items.IsEmpty)
            {
                // Si está vacía, establece el ItemsSource
                ListBoxDiscos.ItemsSource = AnadirDiscos.DiscoGlobal.DiscosExistentes;
            }
            else
            {
                // Si tiene elementos, itera sobre la colección y actualiza
                foreach (var item in AnadirDiscos.DiscoGlobal.DiscosExistentes)
                {
                    ListBoxDiscos.Items.Add(item);
                }
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
        public void MostrarDatosUsuario(string nombreUsuario, string rutaFotoPerfil, RolUsuario tipoUsuario)
        {
            txtUserName.Text = nombreUsuario; // Asignar el nombre de usuario al TextBlock correspondiente
            imgProfile.Source = new BitmapImage(new Uri(rutaFotoPerfil)); // Asignar la imagen de perfil
            txtUserType.Text = tipoUsuario.ToString(); // Convertir el tipo de usuario a string usando ToString()
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