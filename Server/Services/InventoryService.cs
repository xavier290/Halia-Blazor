using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NovaLaundryAppWebAdminBlazor.ModelsHalia;

public class InventoryService : IInventoryService
{
    public async Task AddInventoryAsync(InventarioProducto inventory)
    {
        using(HaliabdContext db = new HaliabdContext())
        {
            try
            {
                // Set the creation date
                inventory.Fecha = DateTime.Now;
                
                // Add the inventory to the database
                db.Add(inventory);
                
                // Save changes to the database
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Handle the exception
                // This might involve logging the exception, displaying an error message to the user, etc.
                Console.WriteLine(ex.Message);
            }
        }
    }

    public async Task AddPurchaseAsync(Compra compras)
    {
        using(HaliabdContext db = new HaliabdContext())
        {
            try
            {
                // Set the creation date
                compras.Fecha = DateTime.Now;
                
                // Add the inventory to the database
                db.Add(compras);
                
                // Save changes to the database
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Handle the exception
                // This might involve logging the exception, displaying an error message to the user, etc.
                Console.WriteLine(ex.Message);
            }
        }
    }

    public async Task<List<ProductInventory>> GetInventories()
    {
        using(HaliabdContext db = new HaliabdContext())
        {
            try
            {
                // Perform a join between the Inventario and Producto tables
                var inventories = await (from i in db.InventarioProductos
                                        join p in db.Productos on i.ProductoId equals p.ProductoId
                                        group i by new { i.ProductoId, p.NombreProducto, p.Precio, p.CodigoProducto } into g
                                        select new ProductInventory
                                        {
                                            ProductoId = g.Key.ProductoId ?? 0,
                                            NombreProducto = g.Key.NombreProducto,
                                            Precio = g.Key.Precio,
                                            CodigoProducto = g.Key.CodigoProducto,
                                            Cantidad = g.Sum(i => i.Cantidad),
                                            // Other properties...
                                        }).ToListAsync();

                return inventories;
            }
            catch (Exception ex)
            {
                // Handle the exception
                // This might involve logging the exception, displaying an error message to the user, etc.
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }

    public async Task<List<List<object>>> GetInventoryAsync(int id)
    {
        List<List<object>> data = new List<List<object>>();

        using(HaliabdContext db = new HaliabdContext())
        {
            try
            {
                List<InventarioProducto> inventoryList = await db.InventarioProductos.Where(i => i.ProductoId == id).ToListAsync();

                foreach (var item in inventoryList)
                {
                    List<object> d = new List<object>
                    {
                        item.InventarioId,
                        item.Cantidad,
                        item.StockMaximo,
                        item.StockMinimo,
                        item.Fecha
                    };

                    data.Add(d);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        return data;
    }
}