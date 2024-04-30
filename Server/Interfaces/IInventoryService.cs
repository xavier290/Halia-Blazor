using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NovaLaundryAppWebAdminBlazor.ModelsHalia;


public interface IInventoryService
{
    // Task GetInventories();
    // Task<Inventario> GetInventory(int id);
Task AddInventoryAsync(Inventario inventory);
    // Task<Inventario> UpdateInventory(Inventario inventory);
    // Task DeleteInventory(int id);
}