using System;
using System.Collections.Generic;

namespace NovaLaundryAppWebAdminBlazor.ModelsHalia;

public partial class InventarioProducto
{
    public int InventarioId { get; set; }

    public int? ProductoId { get; set; }

    public int? ProveedorId { get; set; }

    public int? Cantidad { get; set; }

    public int? StockMaximo { get; set; }

    public int? StockMinimo { get; set; }

    public int? SucursalId { get; set; }

    public int? CompraInventarioId { get; set; }

    public decimal? Costo { get; set; }

    public DateTime? Fecha { get; set; }
}
