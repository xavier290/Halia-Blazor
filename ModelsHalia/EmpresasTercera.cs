using System;
using System.Collections.Generic;

namespace NovaLaundryAppWebAdminBlazor.ModelsHalia;

public partial class EmpresasTercera
{
    public int EmpresasTercerasId { get; set; }

    public string? Nombre { get; set; }

    public string? NombreComercial { get; set; }

    public string? Ruc { get; set; }

    public string? Dirección { get; set; }

    public string? Email { get; set; }

    public string? Telefono { get; set; }

    public int? SucursalId { get; set; }

    public string? IsActive { get; set; }
}
