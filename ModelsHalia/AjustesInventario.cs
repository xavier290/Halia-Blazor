using System;
using System.Collections.Generic;

namespace NovaLaundryAppWebAdminBlazor.ModelsHalia;

public partial class AjustesInventario
{
    public int AjusteId { get; set; }

    public string? Nombre { get; set; }

    public string? Producto { get; set; }

    public string? TipoProducto { get; set; }

    public int? IdProducto { get; set; }

    public int? IdRelAlmacenDetalle { get; set; }

    public int? CantidadAgregada { get; set; }

    public int? CantidadDisminuidad { get; set; }
}
