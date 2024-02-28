using System;
using System.Collections.Generic;

namespace NovaLaundryAppWebAdminBlazor.ModelsHalia;

public partial class Empresa
{
    public int EmpresaId { get; set; }

    public string? Nombre { get; set; }

    public string? NombreComercial { get; set; }

    public string? RazonSocial { get; set; }

    public string? RegimenFiscal { get; set; }

    public string? PaginaWeb { get; set; }

    public string? EmailPublico { get; set; }

    public string? CreadoPor { get; set; }

    public DateTime? FechaAlta { get; set; }

    public string? ModificadoPor { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public string EstatusId { get; set; } = null!;
}
