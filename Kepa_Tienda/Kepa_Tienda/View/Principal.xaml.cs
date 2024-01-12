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

    public static class WindowManager
    {
        public static Principal MainWindow { get; set; }
    }

    /// <summary>
    /// Lógica de interacción para Principal.xaml
    /// </summary>
    public partial class Principal : Window
    {
        private Usuario usuarioActual;

        public Principal(Usuario usuario)
        {
            InitializeComponent();
            CargarDiscos(); // Cargar los discos al iniciar la ventana

            usuarioActual = usuario;

            // Obtener la instancia de LoginView desde las ventanas abiertas
            LoginView loginView = Application.Current.Windows.OfType<LoginView>().FirstOrDefault();

            // Asegúrate de que loginView no sea null antes de llamar a ObtenerUsuario
            if (loginView != null)
            {
                // Llama a ObtenerUsuario para obtener el usuario actual
                usuarioActual = loginView.ObtenerUsuario();

                // Asegúrate de que usuarioActual no sea null antes de llamar a ConfigurarUsuarioActual
                if (usuarioActual != null)
                {
                    // Llama a ConfigurarUsuarioActual con el usuario obtenido
                    ConfigurarUsuarioActual(usuarioActual);

                    // Llama a MostrarDatosUsuario con la información del usuario
                    MostrarDatosUsuario(usuarioActual.Nombre, usuarioActual.RutaFotoPerfil, usuarioActual.Rol);
                }
            }
            WindowManager.MainWindow = this;
        }
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
                usuarioActual = loginView.ObtenerUsuario();

                // Asegúrate de que usuarioActual no sea null antes de llamar a ConfigurarUsuarioActual
                if (usuarioActual != null)
                {
                    // Llama a ConfigurarUsuarioActual con el usuario obtenido
                    ConfigurarUsuarioActual(usuarioActual);

                    // Llama a MostrarDatosUsuario con la información del usuario
                    MostrarDatosUsuario(usuarioActual.Nombre, usuarioActual.RutaFotoPerfil, usuarioActual.Rol);
                }

            }
            WindowManager.MainWindow = this;
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
            Hide();
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

        

        // Método para obtener el disco seleccionado
        private Disco ObtenerDiscoSeleccionado()
        {
            // Verifica si hay un elemento seleccionado en el ListBox
            if (ListBoxDiscos.SelectedItem is Disco discoSeleccionado)
            {
                return discoSeleccionado;
            }

            return null;
        }

        // Método para actualizar la interfaz después de eliminar el disco
        private void Borrar_Click(object sender, RoutedEventArgs e)
        {
            // Obtener el disco seleccionado
            Disco discoSeleccionado = ListBoxDiscos.SelectedItem as Disco;

            if (discoSeleccionado != null)
            {
                // Mostrar un MessageBox para confirmar la acción
                MessageBoxResult result = MessageBox.Show("¿Estás seguro que deseas eliminar este disco?", "Confirmar Eliminación", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    // Eliminar el disco de la lista
                    AnadirDiscos.DiscoGlobal.DiscosExistentes.Remove(discoSeleccionado);

                    // Actualizar la interfaz para reflejar los cambios
                    ActualizarInterfaz();
                }
            }
        }

        // Método para actualizar la interfaz después de eliminar el disco
        private void ActualizarInterfaz()
        {
            // Volver a cargar la lista de discos en la interfaz
            ListBoxDiscos.ItemsSource = AnadirDiscos.DiscoGlobal.DiscosExistentes.ToList();
        }






        // Método para actualizar la interfaz después de eliminar el disco


        private void Editar_Click(object sender, RoutedEventArgs e)
        {
            // Código para abrir la ventana de DetallesKrisschasy
            DetallesKrisschasy detallesWindow = new DetallesKrisschasy(usuarioActual);
            detallesWindow.Owner = this;  // Establecer la ventana principal como propietaria de la ventana de detalles
            detallesWindow.Show();

            // Ocultar la ventana principal en lugar de cerrarla
            Hide();
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
            Hide(); // Cierra la ventana actual
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
            DetallesKrisschasy detallesWindow = new DetallesKrisschasy(usuarioActual); // Pasar el usuario
            detallesWindow.Show();

            Hide(); // Opcionalmente, puedes cerrar la ventana principal si es necesario
        }



        private void IrADetallesQueens(object sender, RoutedEventArgs e)
        {
            // Código para abrir la ventana de DetallesQueens
            DetallesQueens detallesQWindow = new DetallesQueens();
            detallesQWindow.Show();

            Hide();
        }
        private void IrAListaDePedidos(object sender, RoutedEventArgs e)
        {
            ListaPedidos PedidosWindow = new ListaPedidos(PedidoGlobal.PedidosRealizados);
            PedidosWindow.Show();
            Hide();
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