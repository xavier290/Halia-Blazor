using System;
using System.Collections.Generic;

namespace NovaLaundryAppWebAdminBlazor.ModelsHalia;

public partial class RolPermiso
{
    public int RolId { get; set; }

    public int PermisosId { get; set; }

    public bool? Catalogos { get; set; }

    public bool? CatalogoClientes { get; set; }

    public bool? CatalogoProveedores { get; set; }

    public bool? Contratos { get; set; }

    public bool? ContratosCrearContratos { get; set; }

    public bool? ContratosCrearProforma { get; set; }

    public bool? ContratosBuscarProforma { get; set; }

    public bool? ContratosGestionCuotas { get; set; }

    public bool? ContratosContratosRetirados { get; set; }

    public bool? ContratosInformacionGeneral { get; set; }

    public bool? ContratosRetiroServicios { get; set; }

    public bool? ContratosFactura { get; set; }

    public bool? Ventas { get; set; }

    public bool? VentasCrearProforma { get; set; }

    public bool? VentasBuscarProformas { get; set; }

    public bool? VentasDirectas { get; set; }

    public bool? VentasFacturas { get; set; }

    public bool? Inventario { get; set; }

    public bool? InventarioInventarioServicios { get; set; }

    public bool? InventarioModificacionesProductos { get; set; }

    public bool? Caja { get; set; }

    public bool? CajaRecibosOficiales { get; set; }

    public bool? CajaHistorialRecibos { get; set; }

    public bool? Seguridad { get; set; }

    public bool? SeguridadAuditoria { get; set; }

    public bool? SeguridadGestionUsuario { get; set; }

    public bool? SeguridadGestionPermisos { get; set; }

    public bool? Opciones { get; set; }

    public bool? OpcionesTipoCambio { get; set; }

    public bool? Personal { get; set; }

    public bool? VentarRetiros { get; set; }
}
