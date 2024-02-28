using System;
using System.Collections.Generic;

namespace NovaLaundryAppWebAdminBlazor.ModelsHalia;

public partial class RelBancoTipo
{
    public int RelBancoTarjetaTipo { get; set; }

    public int? TarjetaTipoId { get; set; }

    public int? BancoId { get; set; }
}
