using System;

namespace Kepa_Tienda.View
{
    public class Disco
    {
        public string Titulo { get; set; }
        public double Precio { get; set; }
        public int Cantidad { get; set; } // Campo Cantidad descomentado
        public int Stock { get; set; }
        public string Artista { get; set; }
        public string Genero { get; set; }
        public string AnioPublicacion { get; set; }
        public string Imagen { get; set; }
        public string Pais { get; set; }
        public string SelloDiscografico { get; set; }
        public string Descripcion { get; set; }

        // Otros campos o propiedades que puedan representar un disco en tu tienda
    }
}
