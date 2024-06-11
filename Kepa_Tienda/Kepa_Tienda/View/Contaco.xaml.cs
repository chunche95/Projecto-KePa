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
using WPF_LoginForm.View;

namespace Kepa_Tienda.View
{
    
    public partial class Contaco : Window
    {
        public Contaco()
        {
            InitializeComponent();

          
            //string direccion = "C%2F+Escritor+Rafael+Ferreres,+22,+Quatre+Carreres,+46013+Valencia";
           
            //string url = $"https://www.waze.com/en/live-map/directions/es/vc/valencia/c-de-lescriptor-rafael-ferreres,-22?place=ChIJrd0bst1IYA0RszPDyfiMBBU{direccion}";

           // MapaBrowser.Navigate(url);
        }
        private void Enviar_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Gracias por ponerse en contacto con nosotros. Le responderemos lo antes posible.");
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void Carrito_Click(object sender, MouseButtonEventArgs e)
        {
            Carrito carritoWindow = new Carrito();

            
            carritoWindow.MostrarDiscosEnCarrito();

            carritoWindow.Show();
        }


        private void Volver_Click(object sender, RoutedEventArgs e)
        {
            if (WindowManager.MainWindow != null)
            {
              
                WindowManager.MainWindow.Show();
                WindowManager.MainWindow.Activate();
            }

            // Oculta la ventana actual en lugar de cerrarla
            Hide();
        }
        private void Salir_Click(object sender, MouseButtonEventArgs e)
        {
            LoginView loginWindow = new LoginView(); // Crear una instancia de LoginView
            loginWindow.Show(); // Mostrar la ventana LoginView
            Close(); // Cerrar la ventana actual si es necesario
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }

  }
  
