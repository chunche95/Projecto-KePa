using Kepa_Tienda.View;
using System;
using System.Collections.Generic;
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
        private void cb_elementoSeleccionado(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = (ComboBox)sender;
            var selectedItem = comboBox.SelectedItem as ComboBoxItem;

            if (selectedItem != null)
            {
                string idioma = selectedItem.Content.ToString();

                // Cambiar los recursos de cadena según el idioma seleccionado
                if (idioma == "ES")
                {
                    // Establecer el idioma español
                    ResourceDictionary dict = new ResourceDictionary();
                    dict.Source = new Uri("/Kepa_Tienda;component/resources/StringResources.es-ES.xaml", UriKind.Relative);
                    Application.Current.Resources.MergedDictionaries.Add(dict);
                }
                else if (idioma == "EN")
                {
                    // Establecer el idioma inglés
                    ResourceDictionary dict = new ResourceDictionary();
                    dict.Source = new Uri("/Kepa_Tienda;component/resources/StringResources.en-US.xaml", UriKind.Relative);
                    Application.Current.Resources.MergedDictionaries.Add(dict);
                }
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