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
            // Verificar si txtUser y txtPass son nulos
            if (txtUser != null && txtPass != null)
            {
                string usuario = txtUser.Text; // Obtener el nombre de usuario ingresado
                string contraseña = txtPass.Password; // Obtener la contraseña ingresada

                // Verificar si las cadenas de usuario y contraseña son nulas o vacías
                if (!string.IsNullOrEmpty(usuario) && !string.IsNullOrEmpty(contraseña))
                {
                    // Verificar las credenciales para redirigir a la ventana correspondiente
                    if (usuario == "usuario1" && contraseña == "1234")
                    {
                        // Usuario normal
                        usuarioActual = new Usuario
                        {
                            Nombre = usuario,
                            Rol = RolUsuario.Usuario, // Establecer el rol como Usuario
                                RutaFotoPerfil = "pack://application:,,,/Imagenes/avatar.png"
                        };

                        // Redirigir a la ventana Principal y configurar el usuario actual
                        Principal principalWindow = new Principal();
                        principalWindow.ConfigurarUsuarioActual(usuarioActual);
                        principalWindow.Show();
                        this.Close();
                    }
                    else if (usuario == "administrador1" && contraseña == "1234")
                    {
                        // Usuario administrador
                        Usuario usuarioAdmin = new Usuario
                        {
                            Nombre = usuario,
                            Rol = RolUsuario.Administrador,
                            RutaFotoPerfil = "pack://application:,,,/Imagenes/Adminpng.png"
                        };

                        // Redirigir a la ventana de Panel de Administrador y configurar el usuario actual
                        Principal principalWindow = new Principal();
                        principalWindow.ConfigurarUsuarioActual(usuarioAdmin);
                        principalWindow.MostrarDatosUsuario(usuarioAdmin.Nombre, usuarioAdmin.RutaFotoPerfil, usuarioAdmin.Rol);
                        principalWindow.Show();
                        this.Close();
                    }
                    else
                    {
                        // Credenciales incorrectas, mostrar un mensaje
                        MessageBox.Show("Usuario o contraseña incorrectos");
                    }
                }
                else
                {
                    // Usuario o contraseña son nulos o vacíos, mostrar un mensaje
                    MessageBox.Show("Por favor, ingrese un nombre de usuario y una contraseña");
                }
            }
            else
            {
                // txtUser o txtPass son nulos, mostrar un mensaje
                MessageBox.Show("Error en la interfaz de usuario. Inténtelo de nuevo.");
            }
        }
        private void SetLanguage(string languageCode)
        {
           /* try
            {
                // Cambia la cultura de la aplicación
                CultureInfo newCulture = new CultureInfo(languageCode);
                Thread.CurrentThread.CurrentCulture = newCulture;
                Thread.CurrentThread.CurrentUICulture = newCulture;

                // Carga el diccionario de recursos correspondiente
                ResourceDictionary dict = new ResourceDictionary();
                dict.Source = new Uri($"/Kepa_Tienda;component/resources/StringResources.{languageCode}.xaml", UriKind.Relative);
                this.Resources.MergedDictionaries.Clear();
                this.Resources.MergedDictionaries.Add(dict);
            }
            catch (Exception ex)
            {
                // Maneja cualquier excepción que pueda ocurrir durante el cambio de idioma
                MessageBox.Show($"Error cambiando el idioma: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }*/
        }

        private void cb_elementoSeleccionado(object sender, SelectionChangedEventArgs e)
        {
            // Cambia el idioma cuando se selecciona un nuevo elemento en el ComboBox
            ComboBox cb = (ComboBox)sender;
            ComboBoxItem selectedItem = (ComboBoxItem)cb.SelectedItem;
            string languageCode = selectedItem.Content.ToString();
            SetLanguage(languageCode);
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