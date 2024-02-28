using System;
using System.Collections.Generic;

namespace NovaLaundryAppWebAdminBlazor.ModelsHalia;

public partial class TipoCambio
{
    public int IdTasaCambio { get; set; }

    public double Tasa { get; set; }

    public DateTime FechaCambio { get; set; }
}
