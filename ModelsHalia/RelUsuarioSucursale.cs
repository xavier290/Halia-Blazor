using System;
using System.Collections.Generic;

namespace NovaLaundryAppWebAdminBlazor.ModelsHalia;

public partial class RelUsuarioSucursale
{
    public int RelUsuarioSucursalId { get; set; }

    public int? UsuariId { get; set; }

    public int? SucursalId { get; set; }
}
