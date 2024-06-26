﻿using System;
using System.Collections.Generic;

namespace NovaLaundryAppWebAdminBlazor.ModelsHalia;

public partial class Producto
{
    public int ProductoId { get; set; }

    public string NombreProducto { get; set; } = null!;

    public decimal? Precio { get; set; }

    public string? CodigoProducto { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public string? Descripcion { get; set; }

    public string? IsActive { get; set; }

    public virtual ICollection<RelCategoriaProducto> RelCategoriaProductos { get; } = new List<RelCategoriaProducto>();

    public virtual ICollection<RelLineaProducto> RelLineaProductos { get; } = new List<RelLineaProducto>();

    public virtual ICollection<RelProveedorProducto> RelProveedorProductos { get; } = new List<RelProveedorProducto>();
}
