using System;
using System.Collections.Generic;

namespace NovaLaundryAppWebAdminBlazor.ModelsHalia;

public partial class RelProveedorProducto
{
    public int ProveedorProductoId { get; set; }

    public int ProveedorId { get; set; }

    public int ProductoId { get; set; }

    public virtual Producto Producto { get; set; } = null!;

    public virtual Proveedor Proveedor { get; set; } = null!;
}
