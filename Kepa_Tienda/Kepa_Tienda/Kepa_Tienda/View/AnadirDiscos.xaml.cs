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

namespace Kepa_Tienda.View
{
    /// <summary>
    /// Lógica de interacción para AnadirDiscos.xaml
    /// </summary>
    /// 

    public partial class AnadirDiscos : Window
    {
       
        public AnadirDiscos()
        {
            InitializeComponent();
        }
        public static class DiscoGlobal
        {
            public static List<Disco> DiscosExistentes { get; } = new List<Disco>();
        }
        private void Guardar_Click(object sender, RoutedEventArgs e)
        {
            // Obtener la fila seleccionada del DataGrid (asegúrate de que DataGrid sea del espacio de nombres correcto)
            var selectedRow = (DataRowView)((System.Windows.Controls.DataGrid)sender).SelectedItem;

            if (selectedRow != null)
            {
                // Crear un objeto Disco con los valores de la fila seleccionada
                Disco discoSeleccionado = new Disco
                {
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

                // Insertar el objeto Disco en la base de datos
                InsertarDiscoEnBaseDeDatos(discoSeleccionado);
                System.Windows.MessageBox.Show("Disco añadido con éxito.");
            }
            else
            {
                System.Windows.MessageBox.Show("Por favor, selecciona una fila antes de guardar.");
            }
        }

        private void InsertarDiscoEnBaseDeDatos(Disco disco)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["VinilosDB"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"
                INSERT INTO DiscosVinilo (Titulo, SelloDiscografico, Formato, Pais, AnioPublicacion, Genero, Precio, Stock, Imagen, Artista, Descripcion)
                VALUES (@Titulo, @SelloDiscografico, @Formato, @Pais, @AnioPublicacion, @Genero, @Precio, @Stock, @Imagen, @Artista, @Descripcion)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Titulo", disco.Titulo);
                    command.Parameters.AddWithValue("@SelloDiscografico", string.IsNullOrEmpty(disco.SelloDiscografico) ? (object)DBNull.Value : disco.SelloDiscografico);
                    command.Parameters.AddWithValue("@Pais", string.IsNullOrEmpty(disco.Pais) ? (object)DBNull.Value : disco.Pais);
                    command.Parameters.AddWithValue("@AnioPublicacion", string.IsNullOrEmpty(disco.AnioPublicacion) ? (object)DBNull.Value : disco.AnioPublicacion);
                    command.Parameters.AddWithValue("@Genero", string.IsNullOrEmpty(disco.Genero) ? (object)DBNull.Value : disco.Genero);
                    command.Parameters.AddWithValue("@Precio", disco.Precio);
                    command.Parameters.AddWithValue("@Stock", disco.Stock);
                    command.Parameters.AddWithValue("@Imagen", string.IsNullOrEmpty(disco.Imagen) ? (object)DBNull.Value : disco.Imagen);
                    command.Parameters.AddWithValue("@Artista", string.IsNullOrEmpty(disco.Artista) ? (object)DBNull.Value : disco.Artista);
                    command.Parameters.AddWithValue("@Descripcion", string.IsNullOrEmpty(disco.Descripcion) ? (object)DBNull.Value : disco.Descripcion);

                    command.ExecuteNonQuery();
                }
            }
        }
        // Método para buscar un elemento visual en el árbol visual por su nombre



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

        private void Volver(object sender, RoutedEventArgs e)
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

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }

}
