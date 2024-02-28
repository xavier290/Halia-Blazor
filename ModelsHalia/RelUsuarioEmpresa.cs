using System;
using System.Collections.Generic;

namespace NovaLaundryAppWebAdminBlazor.ModelsHalia;

public partial class RelUsuarioEmpresa
{
    public int RelUsuarioEmpresaId { get; set; }

    public int? UsuariId { get; set; }

    public int? EmpresaId { get; set; }
}
