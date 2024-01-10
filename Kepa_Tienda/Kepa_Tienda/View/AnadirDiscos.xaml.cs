using Microsoft.Win32;
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
    /// <summary>
    /// Lógica de interacción para AnadirDiscos.xaml
    /// </summary>
    public partial class AnadirDiscos : Window
    {
        public AnadirDiscos()
        {
            InitializeComponent();
        }
        public static class     DiscoGlobal
        {
            public static List<Disco> DiscosExistentes { get; } = new List<Disco>();
        }
        private void Guardar_Click(object sender, RoutedEventArgs e)
        {
            // Crea un nuevo disco con los detalles ingresados por el usuario
            Disco nuevoDisco = new Disco
            {
                Titulo = txtTitulo.Text,
                Precio = double.Parse(txtPrecio.Text),
                Artista =txtArtista.Text,
                Stock = int.Parse(txtStock.Text),
                Genero = txtGenero.Text,
                

                // Otros campos según tu modelo de datos
            };

            // Agrega el nuevo disco a la lista de discos existentes
            DiscoGlobal.DiscosExistentes.Add(nuevoDisco);

            // Encuentra la ventana Principal abierta
            Principal mainWindow = Application.Current.Windows.OfType<Principal>().FirstOrDefault();
            if (mainWindow != null)
            {
                // Actualiza la lista de discos en la ventana Principal
                ListBox listBoxDiscos = mainWindow.FindName("ListBoxDiscos") as ListBox;
                if (listBoxDiscos != null)
                {
                    listBoxDiscos.Items.Add(nuevoDisco);
                }
            }
            DiscoGlobal.DiscosExistentes.Add(nuevoDisco);
            Principal inicio = new Principal();
            inicio.Show();
            // Cierra el formulario de agregar disco
            this.Close();
        }

        // Método para buscar un elemento visual en el árbol visual por su nombre
        private T FindVisualChild<T>(DependencyObject parent, string childName) where T : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                string controlName = child.GetValue(Control.NameProperty) as string;

                if (controlName == childName)
                {
                    return child as T;
                }
                else
                {
                    T result = FindVisualChild<T>(child, childName);
                    if (result != null)
                        return result;
                }
            }
            return null;
        }

        private void SeleccionarImagen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.gif;*.bmp";

            if (openFileDialog.ShowDialog() == true)
            {
                string rutaImagen = openFileDialog.FileName;
                BitmapImage bitmap = new BitmapImage(new Uri(rutaImagen));
                ImagenSeleccionada.Source = bitmap;
            }
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

        private void Volver(object sender, RoutedEventArgs e)
        {
            Principal mainWindow = new Principal(); // Reemplaza 'MainWindow' con el nombre de tu ventana principal
            mainWindow.Show();
            this.Close(); // Cierra la ventana actual
        }
    }

}
