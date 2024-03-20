using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NovaLaundryAppWebAdminBlazor.ModelsHalia;


public interface IcatalogService
{
    // funcitions for CRUD products
    Task AddProductAsync(string name, decimal price, string productService, string code, string description);
    Task AddProductLineAsync(string name);
    Task AddProviderAsync(string name, string telefono, string direccion, string pais);
    
    
    Task UpdateProductAsync(int entryId, string name, decimal price, string productService, string code, string description);
    Task UpdateProductLineAsync(int entryId, string name);
    Task UpdateProviderAsync(int entryId, string name, string telefono, string direccion, string pais);
    
    
    Task<List<List<object>>> GetProductAsync(string filter);
    Task<List<List<object>>> GetProductLineAsync(string filter);
    Task<List<List<object>>> GetProviderAsync(string filter);
    
    
    Task<Producto> GetSingleProductAsync(int entryId);
    Task<Linea> GetSingleProductLineAsync(int entryId);
    Task<Proveedor> GetSingleProviderAsync(int entryId);
}