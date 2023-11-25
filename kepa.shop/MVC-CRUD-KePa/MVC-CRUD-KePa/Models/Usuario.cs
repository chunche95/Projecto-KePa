using System;
using System.Collections.Generic;

namespace MVC_CRUD_KePa.Models;

public partial class Usuario
{
    public int UClave { get; set; }

    public string UAlias { get; set; } = null!;

    public string UContrasena { get; set; } = null!;

    public string URol { get; set; } = null!;
}
