using System;
using System.Collections.Generic;

namespace NovaLaundryAppWebAdminBlazor.ModelsHalia;

public partial class AuditoriaSistema
{
    public int IdAuditoria { get; set; }

    public string Usuario { get; set; } = null!;

    public string? Sector { get; set; }

    public string? Campo { get; set; }

    public string? Tipo { get; set; }

    public string? Nivel { get; set; }

    public string? Fecha { get; set; }
}
