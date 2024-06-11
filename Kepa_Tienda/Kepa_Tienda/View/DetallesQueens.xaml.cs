using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

    public partial class DetallesQueens : Window
    {
        private Disco disco;
        private Usuario usuarioActual;

        public DetallesQueens(Disco disco, Usuario usuarioActual)
        {
            InitializeComponent();
            this.usuarioActual = usuarioActual;
            this.disco = disco;

            ConfigurarVisibilidadBotonElimnarDisco();
            MostrarDetallesDisco();
        }

        private void ConfigurarVisibilidadBotonElimnarDisco()
        {
            if (usuarioActual.Tipo == "admin")
            {
                Eliminar.Visibility = Visibility.Visible;
                Editar.Visibility = Visibility.Visible;
            }
            else
            {
                Eliminar.Visibility = Visibility.Collapsed;
                Editar.Visibility = Visibility.Collapsed;
            }
        }

        private void MostrarDetallesDisco()
        {
            TituloTextBlock.Text = disco.Titulo;
            DescripcionTextBox.Text = disco.Descripcion;
            ImagenImage.Source = new BitmapImage(new Uri(disco.Imagen));
            ArtistaTextBlock.Text = disco.Artista;

            // Consulta a la base de datos para obtener la oferta
            using (SqlConnection connection = new SqlConnection("Data Source=localhost;Initial Catalog=vinilos;Integrated Security=True"))
            {
                connection.Open();
                string query = "SELECT Precio, PorcentajeOferta FROM DiscosVinilo WHERE DiscoID = @DiscoID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@DiscoID", disco.DiscoID);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        decimal precioOriginal = reader.GetDecimal(0);
                        decimal? porcentajeOferta = reader.IsDBNull(1) ? null : (decimal?)reader.GetDecimal(1);

                        if (porcentajeOferta.HasValue && porcentajeOferta > 0)
                        {
                            // Calcular el precio con descuento
                            decimal precioConDescuento = precioOriginal - (precioOriginal * porcentajeOferta.Value / 100);

                            PrecioOriginalTextBlock.Text = $"{precioOriginal:C2} (Antes)";
                            PrecioOriginalTextBlock.Foreground = Brushes.White; // Restaurar el color original
                            PrecioOriginalTextBlock.Visibility = Visibility.Visible;

                            PrecioDescuentoTextBlock.Text = $"{precioConDescuento:C2} (Ahora)";
                            PrecioDescuentoTextBlock.Foreground = Brushes.Red; // Cambiar el color a rojo
                            PrecioDescuentoTextBlock.Visibility = Visibility.Visible;
                        }
                        else
                        {
                            // Mostrar solo el precio original si no hay oferta
                            PrecioOriginalTextBlock.Text = precioOriginal.ToString("C2");
                            PrecioOriginalTextBlock.Foreground = Brushes.White; // Restaurar el color original
                            PrecioOriginalTextBlock.Visibility = Visibility.Visible;

                            PrecioDescuentoTextBlock.Visibility = Visibility.Collapsed;
                        }
                    }
                }
            }
        }









        private void RestarCantidad_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(CantidadTextBox.Text, out int cantidadActual))
            {
                if (cantidadActual > 1)
                {
                    cantidadActual--;
                    CantidadTextBox.Text = cantidadActual.ToString();
                }
            }
        }

        private void SumarCantidad_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(CantidadTextBox.Text, out int cantidadActual))
            {
                cantidadActual++;
                CantidadTextBox.Text = cantidadActual.ToString();
            }
        }

        // Ajustar los métodos addCar y addWish para utilizar discoSeleccionado
        private void addCar(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(CantidadTextBox.Text, out int cantidadSeleccionada))
            {
                if (disco != null)
                {
                    disco.Cantidad = cantidadSeleccionada;

                    // Crear una nueva instancia de Disco con los detalles necesarios
                    Disco discoCarrito = new Disco
                    {
                        DiscoID = disco.DiscoID,
                        Titulo = disco.Titulo,
                        Descripcion = disco.Descripcion,
                        Imagen = disco.Imagen,
                        Artista = disco.Artista,
                        Precio = disco.PorcentajeOferta > 0 ? disco.PrecioConDescuento : disco.Precio,
                        Cantidad = disco.Cantidad,
                        PorcentajeOferta = disco.PorcentajeOferta,
                        
                    };

                    // Agregar el disco seleccionado a la lista global de discos seleccionados
                    CarritoGlobal.DiscosSeleccionados.Add(discoCarrito);

                    // Mostrar un cuadro de diálogo de confirmación
                    MessageBox.Show($"Se ha agregado \"{disco.Titulo}\" al carrito.", "Disco Agregado", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("No se ha seleccionado ningún disco.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    

    private void addWish(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(CantidadTextBox.Text, out int cantidadSeleccionada))
            {
                if (disco != null)
                {
                    disco.Cantidad = cantidadSeleccionada;

                    // Crear una nueva instancia de Disco con los detalles necesarios
                    Disco discoDeseo = new Disco
                    {
                        DiscoID = disco.DiscoID,
                        Titulo = disco.Titulo,
                        Descripcion = disco.Descripcion,
                        Imagen = disco.Imagen,
                        Artista = disco.Artista,
                        Precio = disco.PorcentajeOferta > 0 ? disco.PrecioConDescuento : disco.Precio,
                        Cantidad = disco.Cantidad,
                        PorcentajeOferta = disco.PorcentajeOferta
                    };

                    // Agregar el disco seleccionado a la lista de deseos
                    ListaGlobal.DiscosSeleccionados.Add(discoDeseo);

                    // Mostrar un cuadro de diálogo de confirmación
                    MessageBox.Show($"Se ha agregado \"{disco.Titulo}\" a la lista de deseos.", "Disco Agregado", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("No se ha seleccionado ningún disco.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }



        private void Salir_Click(object sender, MouseButtonEventArgs e)
        {
            LoginView loginWindow = new LoginView(); // Crear una instancia de LoginView
            loginWindow.Show(); // Mostrar la ventana LoginView
            Close(); // Cerrar la ventana actual si es necesario
        }
    
    private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
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
            Hide();
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void Carrito_Click(object sender, MouseButtonEventArgs e)
        {
            Carrito carritoWindow = new Carrito();

            // Pasar la lista de discos seleccionados al carrito
            carritoWindow.MostrarDiscosEnCarrito();

            carritoWindow.Show();
            Close();
        }


        private void EliminarDisco(object sender, RoutedEventArgs e)
        {
            try
            {
                // Establece la conexión con tu base de datos
                SqlConnection connection = new SqlConnection("Data Source=localhost;Initial Catalog=vinilos;Integrated Security=True");

                // Abre la conexión
                connection.Open();

                // Crea una consulta SQL para eliminar el disco
                string query = "DELETE FROM DiscosVinilo WHERE DiscoID = @DiscoID"; // Ajusta el nombre del campo según tu estructura de base de datos

                // Crea un comando SQL
                SqlCommand command = new SqlCommand(query, connection);

                // Asigna el valor de DiscoID del disco seleccionado al parámetro del comando SQL
                command.Parameters.AddWithValue("@DiscoID", disco.DiscoID); // Ajusta el nombre de la propiedad según la estructura de tu clase Disco

                // Ejecuta el comando SQL
                command.ExecuteNonQuery();

                // Cierra la conexión
                connection.Close();

                // Muestra un mensaje de éxito
                MessageBox.Show("Disco eliminado correctamente de la base de datos.");
            }
            catch (Exception ex)
            {
                // Muestra un mensaje de error si ocurre alguna excepción
                MessageBox.Show("Error al intentar eliminar el disco: " + ex.Message);
            }
        }

        private void Editar_Click(object sender, RoutedEventArgs e)
        {
            // Crear una instancia de la clase Editar y pasar el objeto Disco como parámetro al constructor
            Editar editarWindow = new Editar(disco);

            // Mostrar la ventana Editar
            editarWindow.Show();

            // Cerrar la ventana actual si es necesario
            Close();
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            // Implementa la lógica para el evento TextBox_TextChanged_1
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // Lógica para el evento Window_MouseDown
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}

