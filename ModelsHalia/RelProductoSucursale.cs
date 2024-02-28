using System;
using System.Collections.Generic;

namespace NovaLaundryAppWebAdminBlazor.ModelsHalia;

public partial class RelProductoSucursale
{
    public string RelProductoSucursalesId { get; set; } = null!;

    public int? ProductoId { get; set; }

    public int? SucursalId { get; set; }
}
