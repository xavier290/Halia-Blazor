using System;
using System.Collections.Generic;

namespace NovaLaundryAppWebAdminBlazor.ModelsHalia;

public partial class Sucursale
{
    public int SucursalId { get; set; }

    public string? NombreSucursal { get; set; }

    public string? Direccion { get; set; }

    public string? Estado { get; set; }

    public string? Telefono { get; set; }

    public string? Correo { get; set; }

    public int? EmpresaId { get; set; }
}
