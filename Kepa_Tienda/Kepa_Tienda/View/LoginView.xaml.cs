using Kepa_Tienda.View;
using System;
using System.Collections.Generic;
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
using System.Data.SqlClient;

namespace WPF_LoginForm.View
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
 
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
        }
        private Usuario usuarioActual;
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            // Obtener el nombre de usuario y la contraseña ingresados por el usuario
            string usuario = txtUser.Text;
            string contraseña = txtPass.Password;

            // Cadena de conexión a la base de datos SQL Server
            string connectionString = "Data Source=localhost;Initial Catalog=vinilos;Integrated Security=True";

            // Consulta SQL para verificar las credenciales del usuario en la base de datos
            string query = "SELECT * FROM Usuarios WHERE usuario = @Usuario AND contrasena = @Contrasena";

            // Usar una conexión y un comando SQL para ejecutar la consulta
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Agregar parámetros para evitar la inyección SQL
                    command.Parameters.AddWithValue("@Usuario", usuario);
                    command.Parameters.AddWithValue("@Contrasena", contraseña);

                    // Abrir la conexión y ejecutar la consulta
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read()) // Verificar si se encontró una coincidencia en la base de datos
                        {
                            // Credenciales correctas, crear el objeto Usuario con los datos reales
                            Usuario usuarioActual = new Usuario
                            {
                                Nombre = reader["usuario"].ToString(),
                                Tipo = reader["rol"].ToString(),
                                HoraEntrada = DateTime.Now,
                                rutaimagen = reader["rutaimagen"].ToString() // Asegúrate de que la columna de la base de datos tiene este nombre
                            };

                            // Redirigir a la ventana principal
                            Principal principalWindow = new Principal(usuarioActual);
                            principalWindow.Show();
                            this.Close();
                        }
                        else
                        {
                            // Credenciales incorrectas, mostrar un mensaje de error
                            MessageBox.Show("Usuario o contraseña incorrectos");
                        }
                    }
                }
            }
        }

        private void cb_elementoSeleccionado(object sender, SelectionChangedEventArgs e)
        {
            // Cambia el idioma cuando se selecciona un nuevo elemento en el ComboBox
            ComboBox cb = (ComboBox)sender;
            ComboBoxItem selectedItem = (ComboBoxItem)cb.SelectedItem;
            string languageCode = selectedItem.Content.ToString();
            SetLanguage(languageCode);
        }


        private void cbIdiomas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Obtener el ComboBox seleccionado
            ComboBoxItem selectedItem = (ComboBoxItem)cbIdiomas.SelectedItem;

            // Obtener el idioma seleccionado
            string idioma = selectedItem.Content.ToString();

            // Cambiar el idioma de los recursos
            switch (idioma)
            {
                case "ES":
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("es-ES");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("es-ES");
                    break;
                case "EN":
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    break;
                default:
                    break;
            }

            
        }
        // Método para cambiar el idioma de la aplicación
        private void SetLanguage(string languageCode)
        {
            try
            {
                // Cambiar la cultura de la aplicación
                CultureInfo newCulture = new CultureInfo(languageCode);
                Thread.CurrentThread.CurrentCulture = newCulture;
                Thread.CurrentThread.CurrentUICulture = newCulture;

                // Cargar el diccionario de recursos correspondiente
                ResourceDictionary dict = new ResourceDictionary();
                dict.Source = new Uri($"/Kepa_Tienda;component/resources/StringResources.{languageCode}.xaml", UriKind.Relative);
                this.Resources.MergedDictionaries.Clear();
                this.Resources.MergedDictionaries.Add(dict);
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que pueda ocurrir durante el cambio de idioma
                MessageBox.Show($"Error cambiando el idioma: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

            public Usuario ObtenerUsuario()
        {
            // Devuelve el usuario actual (puede ser un objeto que hayas configurado durante el inicio de sesión)
            return usuarioActual;
        }
            private void Registrarse_Click(object sender, RoutedEventArgs e)
        {
            // Crear una instancia de la ventana Registrarse
            Registrarse registroView = new Registrarse();

            // Mostrar la ventana de registro
            registroView.Show();
        }


    }
}