using System;
using System.Collections.Generic;

namespace NovaLaundryAppWebAdminBlazor.ModelsHalia;

public partial class ComprasInventario
{
    public int ComprasInventarioId { get; set; }

    public int? TotalProductos { get; set; }

    public DateTime? Fecha { get; set; }

    public int? TotalCosto { get; set; }

    public string? DetallesCompra { get; set; }
}
