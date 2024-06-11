using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kepa_Tienda.View // Puedes ubicarla en el namespace adecuado
{
    public class Pago
    {
        public string Nombre { get; set; }
        public string NumeroTarjeta { get; set; }
        public string FechaVencimiento { get; set; }
        public string CodigoSeguridad { get; set; }
    }
}

