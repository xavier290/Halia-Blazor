using System;
using System.Collections.Generic;

namespace NovaLaundryAppWebAdminBlazor.ModelsHalia;

public partial class RelInventarioSucursal
{
    public int InventarioSucursalId { get; set; }

    public int InventarioId { get; set; }

    public int SucursalId { get; set; }

    public virtual Inventario Inventario { get; set; } = null!;

    public virtual Sucursale Sucursal { get; set; } = null!;
}
