using System;
using System.Collections.Generic;

namespace NovaLaundryAppWebAdminBlazor.ModelsHalia;

public partial class Proveedor
{
    public int ProveedorId { get; set; }

    public string? NombreProveedor { get; set; }

    public string? Direccion { get; set; }

    public string? NumeroTelefono { get; set; }

    public string? Pais { get; set; }

    public string? DepartamentoEstado { get; set; }
}
