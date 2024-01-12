using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Collections.Generic;
using WPF_LoginForm.View;
using System.ComponentModel;
using System.Linq;

namespace Kepa_Tienda.View
{
    public partial class DetallesKrisschasy : Window
    {

        public List<Disco> carrito = new List<Disco>();
        public List<Disco> discosEnListaDeDeseos = new List<Disco>();
        private Carrito carritoWindow;
        private ListaDeDeseos DeseosWindow;
        private bool isReadOnly;
        private Usuario usuarioActual;
        private bool cargandoInterfaz = false;



        public DetallesKrisschasy(Usuario usuario)
        {
            InitializeComponent();
            ConfigurarUsuarioActual(usuario);

            // Suscribirse al evento TextChanged para detectar cambios en los TextBox
            txtTitulo.TextChanged += TextBox_TextChanged;
            txtStock.TextChanged += TextBox_TextChanged;
            txtPrecio.TextChanged += TextBox_TextChanged;

            CargarInterfaz();
        }

        public void ConfigurarUsuarioActual(Usuario usuario)
        {
            usuarioActual = usuario;
            ConfigurarInterfazSegunRol();
        }


        private bool cambiosRealizados = false;

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Indicar que se han realizado cambios
            cambiosRealizados = true;

            // Puedes habilitar un botón de "Guardar cambios" aquí
            btnGuardarCambios.IsEnabled = true;
        }
        private void GuardarCambios_Click(object sender, RoutedEventArgs e)
        {
            if (cambiosRealizados)
            {
                // Lógica para guardar los cambios
                GuardarCambios();

                // Reiniciar el estado después de guardar
                cambiosRealizados = false;
                btnGuardarCambios.IsEnabled = false;
            }
            else
            {
                MessageBox.Show("No hay cambios para guardar.");
            }
        }

        public static readonly DependencyProperty IsReadOnlyProperty = DependencyProperty.Register(
        "IsReadOnly", typeof(bool), typeof(DetallesKrisschasy), new PropertyMetadata(false));

        // Propiedad IsReadOnly
        public bool IsReadOnly
        {
            get { return (bool)GetValue(IsReadOnlyProperty); }
            set { SetValue(IsReadOnlyProperty, value); }
        }
        private void HabilitarEdicionTextBox(bool habilitar)
        {
            txtTitulo.IsReadOnly = !habilitar;
            txtStock.IsReadOnly = !habilitar;
            txtPrecio.IsReadOnly = !habilitar;
        }

        private void ConfigurarInterfazSegunRol()
        {
            // Verificar el rol del usuario actual
            if (usuarioActual.Rol == RolUsuario.Administrador)
            {
                // Lógica para la interfaz del administrador
                // Por ejemplo, habilitar ciertos controles, mostrar opciones adicionales, etc.
                // Puedes ajustar esto según tus requisitos específicos.
                // Ejemplo:
                btnGuardarCambios.IsEnabled = true;
                // Otros ajustes...
            }
            else
            {
                // Lógica para la interfaz de usuarios no administradores
                // Por ejemplo, deshabilitar ciertos controles, ocultar opciones, etc.
                // Puedes ajustar esto según tus requisitos específicos.
                // Ejemplo:
                btnGuardarCambios.IsEnabled = false;
                // Otros ajustes...
            }
        }


        private void EditarDatos_Click(object sender, RoutedEventArgs e)
        {
            // Verificar el rol del usuario actual
            if (usuarioActual.Rol == RolUsuario.Administrador)
            {
                // Lógica para la edición de datos (por ejemplo, habilitar controles de edición)
                HabilitarEdicionTextBox(true);
            }
            else
            {
                // Mostrar un mensaje indicando que el usuario no tiene permisos para editar
                MessageBox.Show("No tienes permisos para editar los datos.");
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
            if (WindowManager.MainWindow != null)
            {
                // Muestra y activa la ventana principal
                WindowManager.MainWindow.Show();
                WindowManager.MainWindow.Activate();
            }

            // Oculta la ventana actual en lugar de cerrarla
            this.Hide();
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
        private void GuardarCambios()
        {
            // Obtén el disco actual que se está editando
            Disco discoActual = ObtenerDiscoActual();

            if (discoActual != null)
            {
                // Actualiza las propiedades del disco con los valores de TextBox
                discoActual.Titulo = txtTitulo.Text;
                if (int.TryParse(txtStock.Text, out int stock))
                {
                    discoActual.Stock = stock;
                }
                else
                {
                    // Manejo de error si el texto no es un número válido
                    MessageBox.Show("El valor de Stock no es un número válido.");
                    return; // No actualices la lista si hay un error
                }

                // Puedes guardar la lista actualizada en tu fuente de datos o hacer lo que sea necesario
                ActualizarFuenteDeDatos();

                // Después de guardar, deshabilita la edición
                HabilitarEdicionTextBox(false);
            }
        }

        private Disco ObtenerDiscoActual()
        {

            int indiceDiscoActual = ObtenerIndiceDiscoActual();

            if (indiceDiscoActual != -1 && indiceDiscoActual < AnadirDiscos.DiscoGlobal.DiscosExistentes.Count)
            {
                return AnadirDiscos.DiscoGlobal.DiscosExistentes[indiceDiscoActual];
            }

            return null;
        }

        private void ActualizarFuenteDeDatos()
        {
            // Obtén el disco actual que se está editando
            Disco discoActual = ObtenerDiscoActual();

            if (discoActual != null)
            {
                // Actualiza las propiedades del disco con los valores de TextBox
                discoActual.Titulo = txtTitulo.Text;
                if (int.TryParse(txtStock.Text, out int stock))
                {
                    discoActual.Stock = stock;
                }
                else
                {
                    // Manejo de error si el texto no es un número válido
                    MessageBox.Show("El valor de Stock no es un número válido.");
                    return; // No actualices la lista si hay un error
                }
                // Otros campos del objeto Disco...

                // Actualiza la lista de discos existentes con el disco actualizado
                ActualizarListaDeDiscos(discoActual);

                // Después de guardar, deshabilita la edición
                HabilitarEdicionTextBox(false);

                // Vuelve a cargar la interfaz para reflejar los cambios
                CargarInterfaz();
            }
        }

        private void CargarInterfaz()
        {
            // Evitar llamada recursiva infinita
            if (!cargandoInterfaz)
            {
                // Establecer la bandera
                cargandoInterfaz = true;

                // Lógica para cargar o recargar la interfaz
                // Por ejemplo, puedes asignar los valores actualizados a los TextBox aquí.

                // Obtén el disco actual
                Disco discoActual = ObtenerDiscoActual();

                // Asigna los valores a los TextBox
                if (discoActual != null)
                {
                    txtTitulo.Text = discoActual.Titulo;
                    txtStock.Text = discoActual.Stock.ToString();
                    txtPrecio.Text = discoActual.Precio.ToString(); // Ajusta según la propiedad real de tu clase
                }

                // Restablecer la bandera al final
                cargandoInterfaz = false;
            }
        }


        private void ActualizarListaDeDiscos(Disco discoActual)
        {
            // Obtén el índice del disco actual en la lista de discos existentes
            int indiceDiscoActual = ObtenerIndiceDiscoActual();

            // Si el índice es válido, actualiza el disco en la lista
            if (indiceDiscoActual != -1 && indiceDiscoActual < AnadirDiscos.DiscoGlobal.DiscosExistentes.Count)
            {
                AnadirDiscos.DiscoGlobal.DiscosExistentes[indiceDiscoActual] = discoActual;
            }
        }


        private int ObtenerIndiceDiscoActual()
        {
            // Implementa la lógica para obtener el índice del disco actual según tu diseño
            // Puedes utilizar alguna propiedad del disco actual para identificarlo

            // Aquí un ejemplo simple basado en el título del disco
            string tituloActual = txtTitulo.Text;

            // Busca el índice del disco con el título actual en la lista de discos existentes
            for (int i = 0; i < AnadirDiscos.DiscoGlobal.DiscosExistentes.Count; i++)
            {
                if (AnadirDiscos.DiscoGlobal.DiscosExistentes[i].Titulo == tituloActual)
                {
                    return i; // Se encontró el disco, devuelve el índice
                }
            }

            return -1; // No se encontró el disco
        }

    }
}
