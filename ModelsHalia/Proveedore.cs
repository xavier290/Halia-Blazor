using System;
using System.Collections.Generic;

namespace NovaLaundryAppWebAdminBlazor.ModelsHalia;

public partial class Proveedore
{
    public int IdProveedor { get; set; }

    public string NombreEmpresa { get; set; } = null!;

    public string NoTelefono { get; set; } = null!;

    public string? NoRuc { get; set; }

    public string? Correo { get; set; }

    public string? Direccion { get; set; }

    public bool? Estatus { get; set; }
}
