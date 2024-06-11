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
    public partial class Editar : Window
    {
        private Disco disco;

        public Editar(Disco disco)
        {
            InitializeComponent();
            this.disco = disco;
            CargarDatosDisco();
        }

        private void CargarDatosDisco()
        {
            if (disco != null)
            {
                TituloTextBox.Text = disco.Titulo;
                PrecioTextBox.Text = disco.Precio.ToString("F2");
                StockTextBox.Text = disco.Stock.ToString();
                ArtistaTextBox.Text = disco.Artista;
                GeneroTextBox.Text = disco.Genero;
                AnioPublicacionTextBox.Text = disco.AnioPublicacion;
                ImagenTextBox.Text = disco.Imagen;
                PaisTextBox.Text = disco.Pais;
                SelloDiscograficoTextBox.Text = disco.SelloDiscografico;
                DescripcionTextBox.Text = disco.Descripcion;
                OfertaCheckBox.IsChecked = disco.Oferta;
                PorcentajeOfertaTextBox.Text = disco.PorcentajeOferta.ToString();
            }
            else
            {
                MessageBox.Show("Error: El objeto 'Disco' es nulo.");
            }
        }

        private void Guardar_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = "Data Source=localhost;Initial Catalog=vinilos;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
            UPDATE DiscosVinilo
            SET Titulo = @Titulo, Precio = @Precio, Stock = @Stock, Artista = @Artista, Genero = @Genero, AnioPublicacion = @AnioPublicacion, Imagen = @Imagen, Pais = @Pais, SelloDiscografico = @SelloDiscografico, Descripcion = @Descripcion,
                Oferta = @Oferta, PorcentajeOferta = @PorcentajeOferta
            WHERE DiscoID = @DiscoID";

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
                    command.Parameters.AddWithValue("@DiscoID", disco.DiscoID);

                    // Agregar parámetros para las nuevas columnas
                    command.Parameters.AddWithValue("@Oferta", OfertaCheckBox.IsChecked);
                    command.Parameters.AddWithValue("@PorcentajeOferta", double.Parse(PorcentajeOfertaTextBox.Text));

                    try
                    {
                        connection.Open();
                        int result = command.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Disco actualizado correctamente.");
                        }
                        else
                        {
                            MessageBox.Show("Error al actualizar el disco.");
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
