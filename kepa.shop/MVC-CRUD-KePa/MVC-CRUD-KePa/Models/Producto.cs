using System;
using System.Collections.Generic;

namespace MVC_CRUD_KePa.Models;

public partial class Producto
{
    public int PClave { get; set; }

    public string PNombre { get; set; } = null!;

    public string PImagen { get; set; } = null!;

    public string PDescripcion { get; set; } = null!;

    public int PCantidad { get; set; }

    public decimal PCosto { get; set; }
}
