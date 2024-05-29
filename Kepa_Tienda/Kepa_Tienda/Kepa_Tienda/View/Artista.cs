using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kepa_Tienda.View
{
    public class Artista
    {
        public string NombreArtistico { get; set; }
        public string NombreReal { get; set; }
        public string Componentes { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Descripcion { get; set; }
        public string GeneroMusical { get; set; }
        public string EnlacesRedesSociales { get; set; }
        public int MeGustas { get; set; }
        public List<string> GaleriaImagenes { get; set; }
        public List<Disco> Discografia { get; set; }

    }
}
