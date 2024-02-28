namespace NovaLaundryAppWebAdminBlazor.Server.Services
{
    public static class Utilities
    {
        public static string ServerUrl { get; set; } = "http://74.208.237.157:7001/api/v1/";
        public static HttpClient _httpClient { get; set; } = new HttpClient();

        //Scaffold-DbContext "Server=DESKTOP-GKTE05O\SQLEXPRESS;Database=SystemAdmin;Trusted_Connection=True;TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer -OutputDir "ModelsCobranza"-Tables Usuario,RolUsuario,AuditoriaSistema,TipoCambio,Proveedores,TipoServicios,Clientes,RolPermisos,Sucursales,Almacenes,Servicios_Estadares,Imagenes,RelProductoSucursales, RelAlmacenProducto,Inventario,RelAlmacenDetalle,AjustesInventario,MotivosCancelacion,Bancos,TipoTarjeta,RelBancoTipo,Empresas,RelUsuarioEmpresa   -force 
    }
}
