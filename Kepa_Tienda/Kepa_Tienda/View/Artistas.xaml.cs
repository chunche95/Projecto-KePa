using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
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

    public partial class Artistas : Window
    {

        private Usuario usuarioActual;
        private SqlConnection conexion;
        private DataTable tablaArtistas = new DataTable();
        public Artistas( Usuario usuarioActual)
        {
            InitializeComponent();
            this.usuarioActual = usuarioActual;
            // Usa los datos que has recibido para configurar la ventana de "Artistas"
            string cadenaConexion = "Data Source=localhost;Initial Catalog=vinilos;Integrated Security=True";
            conexion = new SqlConnection(cadenaConexion);
            MostrarInformacionUsuario(usuarioActual);
            CargarArtistasDesdeBaseDatos();
            ConfigurarVisibilidadBotonAgregarDisco();

        }
        private void IrOfertas(object sender, RoutedEventArgs e)
        {

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
        private void Inicio(object sender, RoutedEventArgs e)
        {
            Principal inicio = new Principal(usuarioActual);
            inicio.Show();
            Hide();
        }
        
        public void CargarArtistasDesdeBaseDatos()
        {
            try
            {
                // Abrir la conexión
                conexion.Open();

                // Consulta SQL para seleccionar todos los artistas
                string consulta = "SELECT * FROM Artistas";

                // Crear un adaptador de datos para ejecutar la consulta y llenar un DataTable
                SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);

                // Limpiar la tabla de artistas antes de llenarla
                tablaArtistas.Clear();

                // Llenar el DataTable con los resultados de la consulta
                adaptador.Fill(tablaArtistas);

                // Asignar la tabla de artistas como origen de datos para el ListBox
                ListBoxArtistas.ItemsSource = tablaArtistas.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los artistas desde la base de datos: " + ex.Message);
            }
            finally
            {
                // Cerrar la conexión
                conexion.Close();
            }
        }

        public void MostrarDatosUsuario(string nombreUsuario, string rutaFotoPerfil, RolUsuario tipoUsuario)
        {
            txtUserName.Text = nombreUsuario; // Asignar el nombre de usuario al TextBlock correspondiente
            imgProfile.Source = new BitmapImage(new Uri(rutaFotoPerfil)); // Asignar la imagen de perfil
            txtUserType.Text = tipoUsuario.ToString(); // Convertir el tipo de usuario a string usando ToString()
            txtLastAccess.Text = $"{DateTime.Now}"; // Asignar la fecha de último acceso (fecha actual)
        }
        public void AbrirDetallesArtista(object sender, RoutedEventArgs e)
            {
                // Obtener la fila seleccionada en el ListBox
                DataRowView selectedRow = ListBoxArtistas.SelectedItem as DataRowView;

                if (selectedRow != null)
                {
                // Crear un objeto Artista con la información de la fila seleccionada
                Artista artistaSeleccionado = new Artista
                {
                    ArtistaID = Convert.ToInt32(selectedRow["ArtistaID"]),
                    NombreArtistico = selectedRow["NombreArtistico"].ToString(),

                    NombreReal = selectedRow["NombreReal"].ToString(),
                    Componentes = selectedRow["Componentes"].ToString(),
                    FechaNacimiento = Convert.ToDateTime(selectedRow["FechaNacimiento"]),
                    Descripcion = selectedRow["Descripcion"].ToString(),
                    GeneroMusical = selectedRow["GeneroMusical"].ToString(),
                    EnlacesRedesSociales = selectedRow["EnlacesRedesSociales"].ToString(),
                    NumeroMeGustas = Convert.ToInt32(selectedRow["NumeroMeGustas"]),
                    GaleriaImagenes = selectedRow["GaleriaImagenes"].ToString(), // Asegúrate de llenar esto si es necesario
                    Discografia = selectedRow["Discografia"].ToString(), // Asegúrate de llenar esto si es necesario
                };


                // Abrir la página DetallesArtista y pasar el objeto Artista como parámetro
                DetallesArtistas DetallesArtistaWindow = new DetallesArtistas(artistaSeleccionado, usuarioActual);
                    DetallesArtistaWindow.Show();
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione un disco antes de abrir los detalles.");
                }
            }





            public void ConfigurarUsuarioActual(Usuario usuario)
            {
                usuarioActual = usuario;
                //  ConfigurarInterfazSegunRol();
            }

            private void AgregarDisco_Click(object sender, RoutedEventArgs e)
            {
                // Abre un formulario o ventana para agregar discos
                AnadirDiscos anadirDiscos = new AnadirDiscos();
                anadirDiscos.Show();
                Hide();
            }

            // Método para actualizar la interfaz después de eliminar el disco
            private void Borrar_Click(object sender, RoutedEventArgs e)
            {
                // Obtener el disco seleccionado
                Disco discoSeleccionado = ListBoxArtistas.SelectedItem as Disco;

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
                ListBoxArtistas.ItemsSource = AnadirDiscos.DiscoGlobal.DiscosExistentes.ToList();
            }


            // Método para actualizar la interfaz después de eliminar el disco





            private void btnMinimize_Click(object sender, RoutedEventArgs e)
            {
                WindowState = WindowState.Minimized;
            }

            private void btnClose_Click(object sender, RoutedEventArgs e)
            {
                Application.Current.Shutdown();
            }

            private void IrAListaDeDeseos_Click(object sender, RoutedEventArgs e)
            {
                ListaDeDeseos DeseosWindow = new ListaDeDeseos(usuarioActual); // 

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

            private void cb_elementoSeleccionado(object sender, SelectionChangedEventArgs e)
            {

            }


            private void IrAListaDePedidos(object sender, RoutedEventArgs e)
            {
                ListaPedidos PedidosWindow = new ListaPedidos(PedidoGlobal.PedidosRealizados,usuarioActual);
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
        private void MostrarInformacionUsuario(Usuario usuario)
        {
            txtUserName.Text = usuario.Nombre;
            txtUserType.Text = usuario.Tipo;
            txtLastAccess.Text = usuario.HoraEntrada.ToString("g"); // Formato de fecha y hora general
            imgProfile.Source = new BitmapImage(new Uri(usuario.rutaimagen, UriKind.RelativeOrAbsolute));
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
    }

}
    
