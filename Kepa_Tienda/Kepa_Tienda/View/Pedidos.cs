using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kepa_Tienda.View
{

    public static class Pedidos
    {
        public static List<List<Disco>> ListaDePedidos { get; } = new List<List<Disco>>();

        public static void AgregarPedido(List<Disco> discos)
        {
            ListaDePedidos.Add(discos);
        }
    }
}
