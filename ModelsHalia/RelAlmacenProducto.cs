using System;
using System.Collections.Generic;

namespace NovaLaundryAppWebAdminBlazor.ModelsHalia;

public partial class RelAlmacenProducto
{
    public int RelAlmacenProductoId { get; set; }

    public int? AlmacenId { get; set; }

    public int? ProductoId { get; set; }

    public int? Cantidad { get; set; }
}
