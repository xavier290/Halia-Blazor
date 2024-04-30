using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NovaLaundryAppWebAdminBlazor.ModelsHalia;

public class InventoryService : IInventoryService
{
    public async Task AddInventoryAsync(Inventario inventory)
    {
        using(HaliabdContext db = new HaliabdContext())
        {
            // Set the creation date
            // inventory.Fecha = DateTime.Now;
            
            // Add the inventory to the database
            db.Add(inventory);
            
            // Save changes to the database
            await db.SaveChangesAsync();
        }
    }
}