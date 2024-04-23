using System;
using System.Collections.Generic;

namespace NovaLaundryAppWebAdminBlazor.ModelsHalia;

public partial class Categorium
{
    public int CategoriaId { get; set; }

    public string? Nombre { get; set; }

    public string? IsActive { get; set; }

    public virtual ICollection<RelCategoriaProducto> RelCategoriaProductos { get; } = new List<RelCategoriaProducto>();
}
