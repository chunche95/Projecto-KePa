using System;
using System.Collections.Generic;

namespace MVC_CRUD_KePa.Models;

public partial class Ventum
{
    public int VClave { get; set; }

    public DateTime VFecha { get; set; }

    public string VEstado { get; set; } = null!;

    public int UClave { get; set; }
}
