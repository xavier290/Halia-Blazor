using System;
using System.Collections.Generic;

namespace NovaLaundryAppWebAdminBlazor.ModelsHalia;

public partial class Almacene
{
    public int AlmacenId { get; set; }

    public string? NombreAlmacen { get; set; }

    public bool? EsMostrador { get; set; }

    public int? SucursalId { get; set; }

    public string? Estatus { get; set; }
}
