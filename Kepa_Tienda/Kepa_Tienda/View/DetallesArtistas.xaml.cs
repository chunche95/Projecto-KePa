using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using WinForms = System.Windows.Forms;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPF_LoginForm.View;
using Application = System.Windows.Application;
using MessageBox = System.Windows.MessageBox;
using System.Diagnostics;

namespace Kepa_Tienda.View
{
    public partial class DetallesArtistas : Window
    {
        private Artista artista;
        private Usuario usuario_actual;

        public DetallesArtistas(Artista artista, Usuario usuario_actual)
        {
            InitializeComponent();
            this.artista = artista;
            this.usuario_actual = usuario_actual;
            CargarDatosArtista();
            ConfigurarVisibilidadBotonVisibilidad();
        }

        private void CargarDatosArtista()
        {
            if (artista != null)
            {

                NombreArtisticoTextBox.Text = artista.NombreArtistico;
                NombreRealTextBox.Text = artista.NombreReal;
                ComponentesTextBox.Text = artista.Componentes;
                FechaNacimientoTextBox.Text = artista.FechaNacimiento.ToShortDateString();
                DescripcionTextBox.Text = artista.Descripcion;
                GeneroMusicalTextBox.Text = artista.GeneroMusical;
               
                NumeroMeGustasTextBox.Text = artista.NumeroMeGustas.ToString();
                ImagenImage.Source = new BitmapImage(new Uri(artista.GaleriaImagenes));
                DiscografiaTextBox.Text = artista.Discografia.ToString();


            }

            else
            {
                MessageBox.Show("Error: El objeto 'Disco' es nulo.");
            }
        }

        private void ConfigurarVisibilidadBotonVisibilidad()
        {
            if (usuario_actual.Tipo == "admin")
            {
                Eliminar_click.Visibility = Visibility.Visible;
                Editar_Click.Visibility = Visibility.Visible;
            }
            else
            {
                Eliminar_click.Visibility = Visibility.Collapsed;
                Editar_Click.Visibility = Visibility.Collapsed;
            }
        }
        private void FacebookButton_Click(object sender, RoutedEventArgs e)
        {
   //desarrollar mas adelante 
        }

        private void Eliminar(object sender, RoutedEventArgs e)
        {
            try
            {
                // Establece la conexión con tu base de datos
                using (SqlConnection connection = new SqlConnection("Data Source=localhost;Initial Catalog=vinilos;Integrated Security=True"))
                {
                    // Abre la conexión
                    connection.Open();

                    // Crea una consulta SQL para eliminar el artista
                    string query = "DELETE FROM Artistas WHERE ArtistaID = @ArtistaID"; // Ajusta el nombre del campo según tu estructura de base de datos

                    // Crea un comando SQL
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Asigna el valor del ArtistaID del artista seleccionado al parámetro del comando SQL
                        command.Parameters.AddWithValue("@ArtistaID", artista.ArtistaID); // Ajusta el nombre de la propiedad según la estructura de tu clase Artista

                        // Ejecuta el comando SQL
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            // Muestra un mensaje de éxito si se eliminó correctamente
                            MessageBox.Show("Artista eliminado correctamente de la base de datos.");
                        }
                        else
                        {
                            // Muestra un mensaje si no se encontró el artista con el ArtistaID proporcionado
                            MessageBox.Show("No se encontró el artista con el ArtistaID especificado.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Muestra un mensaje de error si ocurre alguna excepción
                MessageBox.Show("Error al intentar eliminar el artista: " + ex.Message);
            }
        }
        private void Editar(object sender, RoutedEventArgs e)
        {
            // Crear una instancia de la clase Editar y pasar el objeto Disco como parámetro al constructor
            EditarArtista editarArtistaWindow = new EditarArtista(artista, usuario_actual);

            // Mostrar la ventana Editar
            editarArtistaWindow.Show();

            // Cerrar la ventana actual si es necesario
            Close();
        }

        private void Volver_Click(object sender, RoutedEventArgs e)
        {
            if (WindowManager.MainWindow != null)
            {
                // Muestra y activa la ventana principal
                WindowManager.MainWindow.Show();
                WindowManager.MainWindow.Activate();
            }

            // Oculta la ventana actual en lugar de cerrarla
            this.Hide();
        }


        private void Carrito_Click(object sender, MouseButtonEventArgs e)
        {
            Carrito carritoWindow = new Carrito();
            carritoWindow.Show();
        }
        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void Salir_Click(object sender, MouseButtonEventArgs e)
        {
            LoginView loginWindow = new LoginView(); // Crear una instancia de LoginView
            loginWindow.Show(); // Mostrar la ventana LoginView
            Close(); // Cerrar la ventana actual si es necesario
        }



    }

}
