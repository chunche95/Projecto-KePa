using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kepa_Tienda.View
{
    public class Usuario
    {
        
            public string Nombre { get; set; }
            public string Tipo { get; set; }
            public DateTime HoraEntrada { get; set; }
            public string rutaimagen { get; set; } // Ruta de la foto

    }

    public enum RolUsuario
    {
        Usuario,
        admin
    }
}