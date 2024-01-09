using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Collections.Generic;
using WPF_LoginForm.View;

namespace Kepa_Tienda.View
{
    public enum RolUsuario
    {
        Usuario,
        Administrador
    }

    public partial class DetallesKrisschasy : Window
    {
        public List<Disco> carrito = new List<Disco>();
        public List<Disco> discosEnListaDeDeseos = new List<Disco>();
        private Carrito carritoWindow;
        private ListaDeDeseos DeseosWindow;

        public DetallesKrisschasy()
        {
            InitializeComponent();
            carritoWindow = new Carrito(); // Crear la instancia de Carrito en el constructor
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


        private void addCar(object sender, RoutedEventArgs e)
        {
            int cantidadSeleccionada;
            if (int.TryParse(CantidadTextBox.Text, out cantidadSeleccionada))
            {
                Disco disco = new Disco
                {
                    Titulo = "United PaPer People",
                    Precio = 5.99,
                    Cantidad = cantidadSeleccionada
                };

                // Agregar el disco a la lista global de discos seleccionados
                CarritoGlobal.DiscosSeleccionados.Add(disco);

                // Si la ventana Carrito ya está abierta, usar esa instancia para mostrar los discos
                if (carritoWindow != null && carritoWindow.IsVisible)
                {
                    // Mostrar los discos en la ventana Carrito
                    carritoWindow.MostrarDiscosEnCarrito();
                }
                else // Si la ventana Carrito no está abierta, abrir una nueva instancia y pasar la lista de discos seleccionados
                {
                    Carrito nuevaInstanciaCarrito = new Carrito();
                    nuevaInstanciaCarrito.MostrarDiscosEnCarrito();

                }

                // Mostrar un mensaje de confirmación
                MessageBox.Show($"Se han agregado {cantidadSeleccionada} disco(s) '{disco.Titulo}' al carrito.");
            }
        }
        private void addWish(object sender, RoutedEventArgs e)
        {
            int cantidadSeleccionada;
            if (int.TryParse(CantidadTextBox.Text, out cantidadSeleccionada))
            {
                Disco disco = new Disco
                {
                    Titulo = "United PaPer People",
                    Precio = 5.99,
                    Cantidad = cantidadSeleccionada
                };

                // Agregar el disco a la lista de deseos
                ListaGlobal.DiscosSeleccionados.Add(disco);

                // Crear o mostrar la ventana de ListaDeDeseos y pasar la lista de deseos
                if (DeseosWindow != null && DeseosWindow.IsVisible)
                {
                    DeseosWindow.MostrarDiscosEnLista();
                  
                }
                else
                {
                    DeseosWindow = new ListaDeDeseos();
                    DeseosWindow.MostrarDiscosEnLista();
               
                }
            }

        }
        private void Carrito_Click(object sender, MouseButtonEventArgs e)
        {
            Carrito carritoWindow = new Carrito();

            // Pasar la lista de discos seleccionados al carrito
            carritoWindow.MostrarDiscosEnCarrito();

            carritoWindow.Show();
        }

        private void Volver(object sender, RoutedEventArgs e)
        {
            Principal mainWindow = new Principal(); // Reemplaza 'MainWindow' con el nombre de tu ventana principal
            mainWindow.Show();
            this.Close(); // Cierra la ventana actual
        }


        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            // Implementa la lógica para el evento TextBox_TextChanged_1
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // Lógica para el evento Window_MouseDown
        }
        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Salir_Click(object sender, MouseButtonEventArgs e)
        {
            LoginView loginWindow = new LoginView(); // Crear una instancia de LoginView
            loginWindow.Show(); // Mostrar la ventana LoginView
            Close(); // Cerrar la ventana actual si es necesario
        }
    }
}
