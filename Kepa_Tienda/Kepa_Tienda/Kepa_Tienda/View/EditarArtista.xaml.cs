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
using Kepa_Tienda.View;

namespace Kepa_Tienda.View
{
    public partial class EditarArtista : Window
    {
        private Artista artista;

        public EditarArtista(Artista artista)
        {
            InitializeComponent();
            this.artista = artista;
            CargarDatosArtista();
        }

        private void CargarDatosArtista()
        {
            if (artista != null)
            {
                NombreArtisticoTextBox.Text = artista.NombreArtistico;
                NombreRealTextBox.Text = artista.NombreReal;
                ComponentesTextBox.Text = artista.Componentes;
                FechaNacimientoTextBox.Text = artista.FechaNacimiento.ToString("yyyy-MM-dd");
                DescripcionTextBox.Text = artista.Descripcion;
                GeneroMusicalTextBox.Text = artista.GeneroMusical;
                EnlacesRedesSocialesTextBox.Text = artista.EnlacesRedesSociales;
                NumeroMeGustasTextBox.Text = artista.NumeroMeGustas.ToString();
                GaleriaImagenesTextBox.Text = artista.GaleriaImagenes;
                DiscografiaTextBox.Text = artista.Discografia;
            }
            else
            {
                MessageBox.Show("Error: El objeto 'Artista' es nulo.");
            }
        }

        private void Guardar_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = "Data Source=localhost;Initial Catalog=vinilos;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
                    UPDATE Artistas
                    SET NombreArtistico = @NombreArtistico, NombreReal = @NombreReal, Componentes = @Componentes, FechaNacimiento = @FechaNacimiento, Descripcion = @Descripcion, GeneroMusical = @GeneroMusical, EnlacesRedesSociales = @EnlacesRedesSociales, NumeroMeGustas = @NumeroMeGustas, GaleriaImagenes = @GaleriaImagenes, Discografia = @Discografia
                    WHERE ArtistaID = @ArtistaID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NombreArtistico", NombreArtisticoTextBox.Text);
                    command.Parameters.AddWithValue("@NombreReal", NombreRealTextBox.Text);
                    command.Parameters.AddWithValue("@Componentes", ComponentesTextBox.Text);
                    command.Parameters.AddWithValue("@FechaNacimiento", DateTime.Parse(FechaNacimientoTextBox.Text));
                    command.Parameters.AddWithValue("@Descripcion", DescripcionTextBox.Text);
                    command.Parameters.AddWithValue("@GeneroMusical", GeneroMusicalTextBox.Text);
                    command.Parameters.AddWithValue("@EnlacesRedesSociales", EnlacesRedesSocialesTextBox.Text);
                    command.Parameters.AddWithValue("@NumeroMeGustas", int.Parse(NumeroMeGustasTextBox.Text));
                    command.Parameters.AddWithValue("@GaleriaImagenes", GaleriaImagenesTextBox.Text);
                    command.Parameters.AddWithValue("@Discografia", DiscografiaTextBox.Text);
                    command.Parameters.AddWithValue("@ArtistaID", artista.ArtistaID);

                    try
                    {
                        connection.Open();
                        int result = command.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Artista actualizado correctamente.");
                        }
                        else
                        {
                            MessageBox.Show("Error al actualizar el artista.");
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
