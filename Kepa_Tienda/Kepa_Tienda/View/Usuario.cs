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
        public string RutaFotoPerfil { get; set; }
        public RolUsuario Rol { get; set; }
    }

    public enum RolUsuario
    {
        Usuario,
        Administrador
    }
}