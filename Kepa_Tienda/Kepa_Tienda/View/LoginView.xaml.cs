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
          
                // Oculta la ventana de inicio de sesión
                this.Hide();

                try
                {
                    // Crea una instancia de la ventana principal
                    Principal principalWindow = new Principal();

                    // Muestra la ventana principal
                    principalWindow.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al abrir la ventana principal: {ex.Message}");
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