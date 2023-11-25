using System;
using System.Collections.Generic;

namespace MVC_CRUD_KePa.Models;

public partial class Pedido
{
    public int PeClave { get; set; }

    public DateTime PeFechaEnv { get; set; }

    public DateTime? PeFechaEnt { get; set; }

    public string PeDireccion { get; set; } = null!;

    public string PeEstado { get; set; } = null!;
}
