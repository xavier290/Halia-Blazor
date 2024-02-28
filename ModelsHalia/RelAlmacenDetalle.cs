using System;
using System.Collections.Generic;

namespace NovaLaundryAppWebAdminBlazor.ModelsHalia;

public partial class RelAlmacenDetalle
{
    public int IdRelAlmacenDetalle { get; set; }

    public int RelAlmacenProducto { get; set; }

    public int? AjusteId { get; set; }

    public string? Serie { get; set; }

    public string? Color { get; set; }

    public string? Talla { get; set; }

    public string? Modelo { get; set; }

    public string? Estado { get; set; }
}
