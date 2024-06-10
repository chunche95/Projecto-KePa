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


        private void Guardar_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = "Data Source=localhost;Initial Catalog=vinilos;Integrated Security=True"; 

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
            INSERT INTO DiscosVinilo (Titulo, Precio, Stock, Artista, Genero, AnioPublicacion, Imagen, Pais, SelloDiscografico, Descripcion) 
            VALUES (@Titulo, @Precio, @Stock, @Artista, @Genero, @AnioPublicacion, @Imagen, @Pais, @SelloDiscografico, @Descripcion)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Titulo", TituloTextBox.Text);
                    command.Parameters.AddWithValue("@Precio", double.Parse(PrecioTextBox.Text));
                    command.Parameters.AddWithValue("@Stock", int.Parse(StockTextBox.Text));
                    command.Parameters.AddWithValue("@Artista", ArtistaTextBox.Text);
                    command.Parameters.AddWithValue("@Genero", GeneroTextBox.Text);
                    command.Parameters.AddWithValue("@AnioPublicacion", AnioPublicacionTextBox.Text);
                    command.Parameters.AddWithValue("@Imagen", ImagenTextBox.Text);
                    command.Parameters.AddWithValue("@Pais", PaisTextBox.Text);
                    command.Parameters.AddWithValue("@SelloDiscografico", SelloDiscograficoTextBox.Text);
                    command.Parameters.AddWithValue("@Descripcion", DescripcionTextBox.Text);

                    try
                    {
                        connection.Open();
                        int result = command.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Disco añadido correctamente.");
                        }
                        else
                        {
                            MessageBox.Show("Error al añadir el disco.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
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

       
    }

}
