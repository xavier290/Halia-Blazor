using System;
using System.Collections.Generic;

namespace NovaLaundryAppWebAdminBlazor.ModelsHalia;

public partial class RelCategoriaProductosTercero
{
    public int CategoriaProductoId { get; set; }

    public int CategoriaId { get; set; }

    public int ProductoId { get; set; }

    public virtual CategoriaTercero Categoria { get; set; } = null!;

    public virtual ProductosEmpresasTercera Producto { get; set; } = null!;
}
