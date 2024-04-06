using System;
using System.Collections.Generic;

namespace NovaLaundryAppWebAdminBlazor.ModelsHalia;

public partial class ProductosEmpresasTercera
{
    public int ProductoId { get; set; }

    public string? Nombre { get; set; }

    public decimal? Precio { get; set; }

    public string? Codigo { get; set; }

    public string? Descripcion { get; set; }

    public int? EmpresaTercerizadaId { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public int? Cantidad { get; set; }

    public int? CantidadMaxima { get; set; }

    public int? CantidadMinima { get; set; }

    public string? IsActive { get; set; }

    public virtual ICollection<RelCategoriaProductosTercero> RelCategoriaProductosTerceros { get; } = new List<RelCategoriaProductosTercero>();
}
