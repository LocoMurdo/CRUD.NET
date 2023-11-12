using System;
using System.Collections.Generic;

namespace CRUD.Models;

public partial class Producto
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Categoria { get; set; }

    public string? Precio { get; set; }
}
