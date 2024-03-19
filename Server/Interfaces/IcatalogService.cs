using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public interface IcatalogService
{
    // funcitions for CRUD products
    Task AddProductAsync(string name, decimal price, string productService, string code, string description);
    Task UpdateProductAsync(int entryId, string name, decimal price, string productService, string code, string description);
    Task<List<List<object>>> GetProductAsync(string filter);
}