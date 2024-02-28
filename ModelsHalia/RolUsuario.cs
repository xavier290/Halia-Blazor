using System;
using System.Collections.Generic;

namespace NovaLaundryAppWebAdminBlazor.ModelsHalia;

public partial class RolUsuario
{
    public int RolId { get; set; }

    public string Rol { get; set; } = null!;

    public string? Estado { get; set; }
}
