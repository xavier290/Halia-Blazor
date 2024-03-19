using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NovaLaundryAppWebAdminBlazor.Server.Services;
using NovaLaundryAppWebAdminBlazor.Server.ViewModels;
using NovaLaundryAppWebAdminBlazor.ModelsHalia;

using NovaLaundryAppWebAdminBlazor.Server.Services;


public class CatalogService : IcatalogService 
{
    public async Task<List<List<object>>> GetProductAsync(string filter) 
    {
        List<List<object>> rows = new List<List<object>>();

        using(HaliabdContext db = new HaliabdContext())
        {
            List<Producto> productoList = db.Productos.Where(e => e.NombreProducto.Contains(filter)).ToList();

            foreach (var item in productoList)
            {
                List<object> fila = new List<object>();
                fila.Add(item.ProductoId);
                fila.Add(item.NombreProducto);
                fila.Add(item.Descripcion);
                fila.Add(item.Precio);

                rows.Add(fila);
            }
        }

        return rows;
    }
    public async Task AddProductAsync(string name, decimal price, string productService, string code, string description) 
    {
        using(HaliabdContext db = new HaliabdContext())
        {
            Producto producto = new Producto()
            {
                NombreProducto = name.Trim(), 
                Precio = price,
                ProductoServicio = productService.Trim(),
                CodigoProducto = code.Trim(),
                FechaCreacion = DateTime.Now,
                Descripcion = description.Trim()
            };   

            db.Add(producto);
            db.SaveChanges();
        }
    }

    public async Task UpdateProductAsync(int entryId, string name, decimal price, string productService, string code, string description) 
    {
        using(HaliabdContext db = new HaliabdContext())
        {
            Producto producto = db.Productos.Find(entryId);

            if (producto != null)
            {
                producto.NombreProducto = name.Trim();
                producto.Precio = price;
                producto.ProductoServicio = productService.Trim();
                producto.CodigoProducto = code.Trim();
                producto.Descripcion = description.Trim();    
            }

            db.SaveChanges();
        }
    }
}