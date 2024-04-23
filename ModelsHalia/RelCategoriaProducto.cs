using System;
using System.Collections.Generic;

namespace NovaLaundryAppWebAdminBlazor.ModelsHalia;

public partial class RelCategoriaProducto
{
    public int ProductoCategoriaId { get; set; }

    public int CategoriaId { get; set; }

    public int ProductoId { get; set; }

    public virtual Categorium Categoria { get; set; } = null!;

    public virtual Producto Producto { get; set; } = null!;
}
