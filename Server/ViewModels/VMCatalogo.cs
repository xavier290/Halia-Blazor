using NovaLaundryAppWebAdminBlazor.Server.Models;
using NovaLaundryAppWebAdminBlazor.Server.Services;
using static NovaLaundryAppWebAdminBlazor.Server.Models.UserModel;
using static NovaLaundryAppWebAdminBlazor.Server.Services.IService.IServices;

namespace NovaLaundryAppWebAdminBlazor.Server.ViewModels
{
    public class VMCatalogo : IServicesModel
    {
        IGenericServices genericServices = new IGenericServices();

        
        public List<String> CargarHeaders(string opc)
        { 
            switch (opc)
            {
                case "Almacenes":

                    List<String> headers = new List<string>() 
                    {
                     "Almacén","Mostrador","Sucursal","Empresa"
                    };

                    return headers;

                    break;
            }

            return new List<string> { "..", };
        }

        public Task<T> Create<T>(object dto, string token)
        {
            throw new NotImplementedException();
        }

        public async Task<T> Filter<T>(int NumPage,string filter, string token,string opc)
        {
            switch (opc)
            {
                case "Almacenes":
                    AlmacenesApiGetAllResponse nullObj = new AlmacenesApiGetAllResponse();
                    var userData = await genericServices.SendRequestAsync<AlmacenesApiGetAllResponse, AlmacenesApiGetAllResponse>(HttpMethod.Get, $"Almacenes/AlmacenesPaginado?PageNumber={NumPage.ToString()}&PageSize=10",token).ConfigureAwait(false);

                    return (T)Convert.ChangeType(userData, typeof(T));
                    break;
            }

            throw new InvalidOperationException("Opción no válida para filtrar.");
        }

        public Task<T> GetAll<T>(string token)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetOneById<T>(int id, string token)
        {
            throw new NotImplementedException();
        }

        public Task<T> Block<T>(int id, string token)
        {
            throw new NotImplementedException();
        }

        public Task<T> Update<T>(object dto, string token)
        {
            throw new NotImplementedException();
        }
    }
}
