using System;
using System.Collections.Generic;

namespace NovaLaundryAppWebAdminBlazor.ModelsHalia;

public partial class Linea
{
    public int LineaId { get; set; }

    public string? Nombre { get; set; }

    public string? IsActive { get; set; }

    public virtual ICollection<RelLineaProducto> RelLineaProductos { get; } = new List<RelLineaProducto>();
}
