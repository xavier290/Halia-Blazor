using static NovaLaundryAppWebAdminBlazor.Server.Models.UserModel;

namespace NovaLaundryAppWebAdminBlazor.Server.Services.IService
{
    public class IServices
    {
        public interface IServicesModel
        {
            Task<T> GetAll<T>(string token);
            Task<T> GetOneById<T>(int id, string token);
            Task<T> Create<T>(Object dto, string token);
            Task<T> Update<T>(object dto, string token);
            Task<T> Block<T>(int id, string token);
            Task<T> Filter<T>(int NumPage, string filter, string token, string opc);
        }
    }
}
