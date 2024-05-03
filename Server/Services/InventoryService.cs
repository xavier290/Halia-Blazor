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
            // Perform a join between the Inventario and Producto tables
            var inventories = await (from i in db.InventarioProductos
                                    join p in db.Productos on i.ProductoId equals p.ProductoId
                                    select new ProductInventory
                                    {
                                        ProductoId = p.ProductoId,
                                        NombreProducto = p.NombreProducto,
                                        Precio = p.Precio,
                                        CodigoProducto = p.CodigoProducto,
                                        FechaCreacion = p.FechaCreacion,
                                        Descripcion = p.Descripcion,
                                        IsActive = p.IsActive,
                                        Cantidad = i.Cantidad,
                                        StockMaximo = i.StockMaximo,
                                        StockMinimo = i.StockMinimo,
                                        SucursalId = i.SucursalId,
                                        Fecha = i.Fecha,
                                        ProveedorId = i.ProveedorId,
                                        Costo = i.Costo
                                    }).ToListAsync();

            return inventories;
        }
    }
}