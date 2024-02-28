namespace NovaLaundryAppWebAdminBlazor.Server.Models
{
    public class UserModel
    {



        //Login -------------
        public class LoginRequest
        {
            public string usuarioID { get; set; }
            public string contrasena { get; set; }
        }

        //Request
        public class LoginResponse
        {
            public int StatusCode { get; set; }
            public bool IsExitoso { get; set; }
            public string[] ErrorMessages { get; set; }
            public LoginResult Resultado { get; set; }
            public int TotalPaginas { get; set; }
        }

        public class LoginResult
        {
            public Usuario Usuario { get; set; }
            public string Token { get; set; }
        }

        public class Usuario
        {
            public string UsuarioId { get; set; }
            public string Nombre { get; set; }
            public string Apellidos { get; set; }
            public string Contrasena { get; set; }
            public string RolId { get; set; }
            public object CreadoPor { get; set; }
            public DateTime FechaAlta { get; set; }
            public object ModificadoPor { get; set; }
            public object FechaModificacion { get; set; }
            public string EstatusId { get; set; }
        }
    }
}
