using System;
using System.Collections.Generic;

namespace NovaLaundryAppWebAdminBlazor.ModelsHalia;

public partial class Usuario
{
    public int IdUsuarios { get; set; }

    public string? Nombre { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public string? Rol { get; set; }

    public string? Estado { get; set; }

    public string? PrimerNombre { get; set; }

    public string? PrimerApellido { get; set; }

    public string? Pass { get; set; }

    public int? SucursalId { get; set; }
}
