


namespace NovaLaundryAppWebAdminBlazor.ModelsHalia
{ 
    public class ProductInventory
    {
        public int ProductoId { get; set; }
        public string NombreProducto { get; set; }
        public decimal? Precio { get; set; }
        public string? CodigoProducto { get; set; }
        public int? Cantidad { get; set; }
        public int? StockMaximo { get; set; }
        public int? StockMinimo { get; set; }
        public int? SucursalId { get; set; }
        public DateTime? Fecha { get; set; }
        public int? ProveedorId { get; set; }
        public decimal? Costo { get; set; }
    }
}
