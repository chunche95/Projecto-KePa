using System;
using System.Collections.Generic;

namespace MVC_CRUD_KePa.Models;

public partial class DetalleVentum
{
    public int DClave { get; set; }

    public int VClave { get; set; }

    public int PClave { get; set; }

    public int PCantidad { get; set; }

    public decimal? PCosto { get; set; }
}
