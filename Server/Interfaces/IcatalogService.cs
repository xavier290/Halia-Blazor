using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NovaLaundryAppWebAdminBlazor.ModelsHalia;

 
public interface IcatalogService
{
    // funcitions for CRUD products
    Task AddProductAsync(Producto product);
    Task AddProductLineAsync(string name);
    Task AddProviderAsync(string name, string telefono, string direccion, string pais);
    Task AddCategoryAsync (string name);
    Task AddProductCategoryAsync(int productId, int categoryId);
    Task AddProductProductLineAsync(int productId, int lineId);
    Task AddProductProviderAsync(int productId, int providerId);
    
    
    Task UpdateProductAsync(int entryId, string name, decimal price, string code, string description, List<string> selectedCategoryIds, List<string> selectedLineIds, List<string> selectedProviderIds);
    Task UpdateProductLineAsync(int entryId, string name);
    Task UpdateProviderAsync(int entryId, string name, string telefono, string direccion, string pais);
    Task UpdateCategoryAsync(int entryId, string name);
    
    
    Task<List<List<object>>> GetProductAsync(string filter);
    Task<List<List<object>>> GetProductLineAsync(string filter);
    Task<List<List<object>>> GetProviderAsync(string filter);
    Task<List<List<object>>> GetCategoryAsync(string filter);
    
    
    Task<Producto> GetSingleProductAsync(int entryId);
    Task<Linea> GetSingleProductLineAsync(int entryId);
    Task<Proveedor> GetSingleProviderAsync(int entryId);
    Task<Categorium> GetSingleCategoryAsync(int entryId);

    Task<List<string>> GetAssociatedCategoriesAsync(int productId);
    Task<List<string>> GetAssociatedLinesAsync(int productId);
    Task<List<string>> GetAssociatedProvidersAsync(int productId);

    
    Task BlockCategoryAsync(int entryId);
    Task BlockProductLineAsync(int entryId);
    Task BlockProviderAsync(int entryId);
    Task BlockProductAsync(int entryId);
}