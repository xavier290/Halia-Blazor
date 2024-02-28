namespace NovaLaundryAppWebAdminBlazor.Server.Models
{
    public class Almacen
    {
        public string almacenId { get; set; }
        public string almacen { get; set; }
        public bool esMostrador { get; set; }
        public string sucursalId { get; set; }
        public string empresaId { get; set; }
        public string creadoPor { get; set; }
        public DateTime fechaAlta { get; set; }
        public string modificadoPor { get; set; }
        public DateTime? fechaModificacion { get; set; }
        public string estatusId { get; set; }
        public object syncStatus { get; set; }
    }

    public class AlmacenesApiGetAllResponse
    {
        public int statusCode { get; set; }
        public bool isExitoso { get; set; }
        public List<object> errorMessages { get; set; }
        public List<Almacen> resultado { get; set; }
        public int totalPaginas { get; set; }
    }
}
