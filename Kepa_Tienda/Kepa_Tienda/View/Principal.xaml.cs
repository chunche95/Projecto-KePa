using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Contracts;
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
    public static class WindowManager
    {
        public static Principal MainWindow { get; set; }
    }

    public partial class Principal : Window
    {
        private Usuario usuarioActual;
        private SqlConnection conexion;
        private DataTable tablaVinilos = new DataTable(); // Declaración de la tabla de datos

        public Principal(Usuario usuarioActual)
        {
            InitializeComponent();
            this.usuarioActual = usuarioActual; // Inicializa el usuario actual

            // Inicializa la conexión con la base de datos
            string cadenaConexion = "Data Source=localhost;Initial Catalog=vinilos;Integrated Security=True";
            conexion = new SqlConnection(cadenaConexion);

            // Obtener la instancia de LoginView desde las ventanas abiertas
            LoginView loginView = Application.Current.Windows.OfType<LoginView>().FirstOrDefault();

            // Cargar los discos desde la base de datos
            CargarDiscosDesdeBaseDatos();
            MostrarInformacionUsuario(usuarioActual);
            WindowManager.MainWindow = this;

            // Configurar la visibilidad del botón según el rol del usuario
            ConfigurarVisibilidadBotonAgregarDisco();
        }

        private void MostrarInformacionUsuario(Usuario usuario)
        {
            txtUserName.Text = usuario.Nombre;
            txtUserType.Text = usuario.Tipo;
            txtLastAccess.Text = usuario.HoraEntrada.ToString("g"); // Formato de fecha y hora general
            imgProfile.Source = new BitmapImage(new Uri(usuario.rutaimagen, UriKind.RelativeOrAbsolute));
        }
        private void AbrirVentanaContacUs(object sender, RoutedEventArgs e)
        {
            Contaco contacUsWindow = new Contaco();
            contacUsWindow.Show();
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // Abrir la página DetallesQueens y pasar el objeto Disco como parámetro
            Artistas artistas = new Artistas(usuarioActual);
            artistas.Show();
        }

        private void CargarDiscosDesdeBaseDatos()
        {
            try
            {
                // Abrir la conexión
                conexion.Open();

                // Consulta SQL para seleccionar todos los discos
                string consulta = "SELECT * FROM DiscosVinilo";

                // Crear un adaptador de datos para ejecutar la consulta y llenar un DataTable
                SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);

                // Limpiar la tabla de discos antes de llenarla
                tablaVinilos.Clear();

                // Llenar el DataTable con los resultados de la consulta
                adaptador.Fill(tablaVinilos);

                // Asignar la tabla de discos como origen de datos para el ListBox
                ListBoxDiscos.ItemsSource = tablaVinilos.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los discos desde la base de datos: " + ex.Message);
            }
            finally
            {
                // Cerrar la conexión
                conexion.Close();
            }
        }

        private void AbrirDetallesQueens(object sender, RoutedEventArgs e)
        {
            // Obtener la fila seleccionada en el ListBox
            DataRowView selectedRow = ListBoxDiscos.SelectedItem as DataRowView;

            if (selectedRow != null)
            {
                // Crear un objeto Disco con la información de la fila seleccionada
                Disco discoSeleccionado = new Disco
                {
                    DiscoID = Convert.ToInt32(selectedRow["DiscoID"]),
                    Titulo = selectedRow["Titulo"].ToString(),
                    Descripcion = selectedRow["Descripcion"].ToString(),
                    Precio = Convert.ToDouble(selectedRow["Precio"]), // Conversión a double
                    Imagen = selectedRow["Imagen"].ToString(),
                    Stock = Convert.ToInt32(selectedRow["Stock"]), // Conversión a int
                    AnioPublicacion = selectedRow["AnioPublicacion"].ToString(),
                    Genero = selectedRow["Genero"].ToString(),
                    Pais = selectedRow["Pais"].ToString(),
                    SelloDiscografico = selectedRow["SelloDiscografico"].ToString(),
                    Artista = selectedRow["Artista"].ToString()
                };

                // Abrir la página DetallesQueens y pasar el objeto Disco como parámetro
                DetallesQueens detallesQueensWindow = new DetallesQueens(discoSeleccionado, usuarioActual);
                detallesQueensWindow.Show();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un disco antes de abrir los detalles.");
            }
        }

        private void AgregarDisco_Click(object sender, RoutedEventArgs e)
        {
            // Abre un formulario o ventana para agregar discos
            AnadirDiscos anadirDiscos = new AnadirDiscos();
            anadirDiscos.Show();
            Hide();
        }

        

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
            ListaDeDeseos DeseosWindow = new ListaDeDeseos(usuarioActual);

            DeseosWindow.MostrarDiscosEnLista();

            DeseosWindow.Show();
            Hide(); // Cierra la ventana actual
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void cb_elementoSeleccionado(object sender, SelectionChangedEventArgs e)
        {

        }

        private void IrAListaDePedidos(object sender, RoutedEventArgs e)
        {
            ListaPedidos PedidosWindow = new ListaPedidos(PedidoGlobal.PedidosRealizados, usuarioActual);
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

    

        private void Salir_Click(object sender, MouseButtonEventArgs e)
        {
            LoginView loginWindow = new LoginView(); // Crear una instancia de LoginView
            loginWindow.Show(); // Mostrar la ventana LoginView
            Close(); // Cerrar la ventana actual si es necesario
        }

        private void IrOfertas(object sender, RoutedEventArgs e)
        {

        }

        private void ListBoxDiscos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
