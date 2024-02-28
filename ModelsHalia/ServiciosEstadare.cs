using System;
using System.Collections.Generic;

namespace NovaLaundryAppWebAdminBlazor.ModelsHalia;

public partial class ServiciosEstadare
{
    public int IdEstandar { get; set; }

    public string? NombreEstandar { get; set; }

    public int? IdImagen { get; set; }

    public string? Descripcion { get; set; }

    public string? Estado { get; set; }

    public double? MontoVd { get; set; }

    public double? MontoContrato { get; set; }

    public int? IdProveedor { get; set; }

    public string? TipoServicio { get; set; }

    public double? MontoMejora { get; set; }

    public int? ClasificacionProducto { get; set; }

    public int? ClasificacionTipo { get; set; }

    public string? ClasificacionInventario { get; set; }

    public string? Codigo { get; set; }
}
