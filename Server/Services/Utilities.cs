﻿namespace NovaLaundryAppWebAdminBlazor.Server.Services
{
    public static class Utilities
    {
        public static string ServerUrl { get; set; } = "http://74.208.237.157:7001/api/v1/";
        public static HttpClient _httpClient { get; set; } = new HttpClient();

        //Scaffold-DbContext "Server=haliabd.mssql.somee.com;Database=haliabd;UID=Rolando03_SQLLogin_1;PWD=Facil123$;TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer -OutputDir "ModelsHalia"-Tables Usuario,RolUsuario,AuditoriaSistema,TipoCambio,Proveedores,TipoServicios,Clientes,RolPermisos,Sucursales,Almacenes,Servicios_Estadares,Imagenes,RelProductoSucursales, RelAlmacenProducto,Inventario,RelAlmacenDetalle,AjustesInventario,MotivosCancelacion,Bancos,TipoTarjeta,RelBancoTipo,Empresas,RelUsuarioEmpresa,EmpresasTerceras   -force
    }
}
