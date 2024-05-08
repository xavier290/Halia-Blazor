using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NovaLaundryAppWebAdminBlazor.ModelsHalia;


public interface IInventoryService
{
    Task<List<ProductInventory>> GetInventories();
    Task<List<List<object>>> GetInventoryAsync(int id);
    Task AddInventoryAsync(InventarioProducto inventory);
    Task AddPurchaseAsync(Compra compras);
    // Task<Inventario> UpdateInventory(Inventario inventory);
    // Task DeleteInventory(int id);
}