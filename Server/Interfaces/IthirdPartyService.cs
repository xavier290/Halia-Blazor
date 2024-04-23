using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NovaLaundryAppWebAdminBlazor.ModelsHalia;


public interface IthirdPartyService
{
    // funcitions for CRUD products
    //Task AddProductAsync(string name, decimal price, string productService, string code, string description);    
    //Task UpdateProductAsync(int entryId, string name, decimal price, string productService, string code, string description);
    //Task<List<List<object>>> GetProductAsync(string filter);
    //Task<Producto> GetSingleProductAsync(int entryId);

    Task<List<List<object>>> GetCategoriesAsync(string filter);
    Task AddCategoryAsync(string name, string active);
    Task UpdateCategoryAsync(int entryId, string name);
    Task<CategoriaTercero> GetSingleCategoryAsync(int entryId);
    Task BlockCategoryAsync(int entryId);


    Task<List<List<object>>> GetProductsTercerosAsync(string filter, int empresaId);
    Task AddProductAsync(ProductosEmpresasTercera product);
    Task UpdateProductAsync(int entryId, List<string> selectedCategoryIds, ProductosEmpresasTercera producto);
    Task BlockProductAsync(int entryId);
    Task AddProductCategoryAsync(int productId, int categoryId);
    Task<ProductosEmpresasTercera> GetSingleProductThirdPartyAsync(int entryId);
    Task<List<string>> GetAssociatedCategoriesAsync(int productId);
}