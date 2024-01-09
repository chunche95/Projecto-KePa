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
            string usuario = txtUser.Text; // Obtener el nombre de usuario ingresado
            string contraseña = txtPass.Password; // Obtener la contraseña ingresada

            // Verificar las credenciales para redirigir a la ventana correspondiente
            if (usuario == "usuario1" && contraseña == "1234")
            {
                // Usuario normal
                Usuario usuarioNormal = new Usuario
                {
                    Nombre = usuario,
                    Rol = RolUsuario.Usuario // Establecer el rol como Usuario
                };

                // Redirigir a la ventana Principal y configurar el usuario actual
                Principal principalWindow = new Principal();
                principalWindow.ConfigurarUsuarioActual(usuarioNormal);
                principalWindow.Show();
                this.Close(); // Cierra la ventana de inicio de sesión
            }
            else if (usuario == "administrador1" && contraseña == "1234")
            {
                // Usuario administrador
                Usuario usuarioAdmin = new Usuario
                {
                    Nombre = usuario,
                    Rol = RolUsuario.Administrador // Establecer el rol como Administrador
                };

                // Redirigir a la ventana de Panel de Administrador y configurar el usuario actual
                Principal principalWindow = new Principal();
                principalWindow.ConfigurarUsuarioActual(usuarioAdmin);
                principalWindow.Show();
                this.Close(); // Cierra la ventana de inicio de sesión// Cierra la ventana de inicio de sesión
            }
            else
            {
                // Credenciales incorrectas, mostrar un mensaje
                MessageBox.Show("Usuario o contraseña incorrectos");
            }
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