using System;
using System.Collections.Generic;

namespace NovaLaundryAppWebAdminBlazor.ModelsHalia;

public partial class CategoriaTercero
{
    public int CategoriaId { get; set; }

    public string? Nombre { get; set; }

    public string? IsActive { get; set; }

    public virtual ICollection<RelCategoriaProductosTercero> RelCategoriaProductosTerceros { get; } = new List<RelCategoriaProductosTercero>();
}
