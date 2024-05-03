using System;
using System.Collections.Generic;

namespace NovaLaundryAppWebAdminBlazor.ModelsHalia;

public partial class Compra
{
    public int ComprasInventarioId { get; set; }

    public int? TotalProductos { get; set; }

    public decimal? TotalCosto { get; set; }

    public string? DetallesCompra { get; set; }

    public DateTime? Fecha { get; set; }
}
