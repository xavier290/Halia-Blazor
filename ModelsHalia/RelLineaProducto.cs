using System;
using System.Collections.Generic;

namespace NovaLaundryAppWebAdminBlazor.ModelsHalia;

public partial class RelLineaProducto
{
    public int LineasProductoId { get; set; }

    public int LineaId { get; set; }

    public int ProductoId { get; set; }

    public virtual Linea Linea { get; set; } = null!;

    public virtual Producto Producto { get; set; } = null!;
}
