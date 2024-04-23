using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NovaLaundryAppWebAdminBlazor.Server.Services;
using NovaLaundryAppWebAdminBlazor.Server.ViewModels;
using NovaLaundryAppWebAdminBlazor.ModelsHalia;

using NovaLaundryAppWebAdminBlazor.Server.Services;
using Microsoft.EntityFrameworkCore;


public class CatalogService : IcatalogService 
{
    // public Producto Product { get; set; }
    public async Task<List<List<object>>> GetProductAsync(string filter) 
    {
        List<List<object>> rows = new List<List<object>>();

        using(HaliabdContext db = new HaliabdContext())
        {
            List<Producto> productoList = db.Productos.Where(e => e.NombreProducto.Contains(filter) && e.IsActive == "Activo").ToList();

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

    public async Task<Producto> GetSingleProductAsync(int entryId)
    {
        using (HaliabdContext db = new HaliabdContext())
        {
            Producto producto = await db.Productos.FirstOrDefaultAsync(e => e.ProductoId == entryId);
            return producto;
        }
    }

    public async Task AddProductAsync(Producto product)
    {
        using(HaliabdContext db = new HaliabdContext())
        {
            // Set the IsActive property to "Activo" by default
            product.IsActive = "Activo";
            
            // Set the creation date
            product.FechaCreacion = DateTime.Now;

            // Add the product to the database
            db.Add(product);
            
            // Save changes to the database
            await db.SaveChangesAsync();
        }
    }

    public async Task AddProductCategoryAsync(int productId, int categoryId)
    {
        using (HaliabdContext db = new HaliabdContext())
        {
            RelCategoriaProducto rel = new RelCategoriaProducto
            {
                ProductoId = productId,
                CategoriaId = categoryId
            };

            db.Add(rel);
            await db.SaveChangesAsync();
        }
    }

    public async Task AddProductProductLineAsync(int productId, int lineId)
    {
        using (HaliabdContext db = new HaliabdContext())
        {
            RelLineaProducto rel = new RelLineaProducto
            {
                ProductoId = productId,
                LineaId = lineId
            };

            db.Add(rel);
            await db.SaveChangesAsync();
        }
    }

    public async Task AddProductProviderAsync(int productId, int providerId)
    {
        using (HaliabdContext db = new HaliabdContext())
        {
            RelProveedorProducto rel = new RelProveedorProducto
            {
                ProductoId = productId,
                ProveedorId = providerId
            };

            db.Add(rel);
            await db.SaveChangesAsync();
        }
    }

    public async Task<List<string>> GetAssociatedCategoriesAsync(int productId)
    {
        using (HaliabdContext db = new HaliabdContext())
        {
            // Query the relational table to get the associated category IDs for the given product ID
            List<string> associatedCategoryIds = await db.RelCategoriaProductos
                .Where(rel => rel.ProductoId == productId)
                .Select(rel => rel.CategoriaId.ToString())
                .ToListAsync();

            return associatedCategoryIds;
        }
    }
    
    public async Task<List<string>> GetAssociatedLinesAsync(int productId)
    {
        using (HaliabdContext db = new HaliabdContext())
        {
            // Query the relational table to get the associated category IDs for the given product ID
            List<string> associatedLineIds = await db.RelLineaProductos
                .Where(rel => rel.ProductoId == productId)
                .Select(rel => rel.LineaId.ToString())
                .ToListAsync();

            return associatedLineIds;
        }
    }

    public async Task<List<string>> GetAssociatedProvidersAsync(int productId)
    {
        using (HaliabdContext db = new HaliabdContext())
        {
            // Query the relational table to get the associated category IDs for the given product ID
            List<string> associatedProviderIds = await db.RelProveedorProductos
                .Where(rel => rel.ProductoId == productId)
                .Select(rel => rel.ProveedorId.ToString())
                .ToListAsync();

            return associatedProviderIds;
        }
    }

    public async Task UpdateProductAsync(int entryId, string name, decimal price, string code, string description, List<string> selectedCategoryIds, List<string> selectedLineIds, List<string> selectedProviderIds) 
    {
        using(HaliabdContext db = new HaliabdContext())
        {
            Producto producto = db.Productos.Find(entryId);

            if (producto != null)
            {
                producto.NombreProducto = name.Trim();
                producto.Precio = price;
                producto.CodigoProducto = code.Trim();
                producto.Descripcion = description.Trim();    

                // Remove associations for categories that are no longer linked to the product
                db.RelCategoriaProductos.RemoveRange(
                    db.RelCategoriaProductos
                        .Where(rel => rel.ProductoId == entryId && !selectedCategoryIds.Contains(rel.CategoriaId.ToString()))
                );

                // Add new associations
                foreach (string categoryId in selectedCategoryIds)
                {
                    if (!await db.RelCategoriaProductos.AnyAsync(rel => rel.ProductoId == entryId && rel.CategoriaId.ToString() == categoryId))
                    {
                        db.RelCategoriaProductos.Add(new RelCategoriaProducto
                        {
                            ProductoId = entryId,
                            CategoriaId = int.Parse(categoryId)
                        });
                    }
                }

                // Remove associations for providers that are no longer linked to the product
                db.RelProveedorProductos.RemoveRange(
                    db.RelProveedorProductos
                        .Where(rel => rel.ProductoId == entryId && !selectedProviderIds.Contains(rel.ProveedorId.ToString()))
                );

                // Add new associations
                foreach (string providerId in selectedProviderIds)
                {
                    if (!await db.RelProveedorProductos.AnyAsync(rel => rel.ProductoId == entryId && rel.ProveedorId.ToString() == providerId))
                    {
                        db.RelProveedorProductos.Add(new RelProveedorProducto
                        {
                            ProductoId = entryId,
                            ProveedorId = int.Parse(providerId)
                        });
                    }
                }

                // Remove associations for product lines that are no longer linked to the product
                db.RelLineaProductos.RemoveRange(
                    db.RelLineaProductos
                        .Where(rel => rel.ProductoId == entryId && !selectedLineIds.Contains(rel.LineaId.ToString()))
                );

                // Add new associations
                foreach (string LineId in selectedLineIds)
                {
                    if (!await db.RelLineaProductos.AnyAsync(rel => rel.ProductoId == entryId && rel.LineaId.ToString() == LineId))
                    {
                        db.RelLineaProductos.Add(new RelLineaProducto
                        {
                            ProductoId = entryId,
                            LineaId = int.Parse(LineId)
                        });
                    }
                }
            }

            db.SaveChanges();
        }
    }

    public async Task<List<List<object>>> GetProductLineAsync(string filter) 
    {
        List<List<object>> rows = new List<List<object>>();

        using(HaliabdContext db = new HaliabdContext())
        {
            List<Linea> lineaList = db.Lineas.Where(e => e.Nombre.Contains(filter) && e.IsActive == "Activo").ToList();

            foreach (var item in lineaList)
            {
                List<object> fila = new List<object>();
                fila.Add(item.LineaId);
                fila.Add(item.Nombre);

                rows.Add(fila);
            }
        }

        return rows;
    }

    public async Task<Linea> GetSingleProductLineAsync(int entryId)
    {
        using (HaliabdContext db = new HaliabdContext())
        {
            Linea linea = await db.Lineas.FirstOrDefaultAsync(e => e.LineaId == entryId);
            return linea;
        }
    }

    public async Task AddProductLineAsync(string name) 
    {
        using(HaliabdContext db = new HaliabdContext())
        {
            Linea linea = new Linea()
            {
                Nombre = name.Trim(), 
                IsActive = "Activo"
            };   

            db.Add(linea);
            db.SaveChanges();
        }
    }

    public async Task UpdateProductLineAsync(int entryId, string name) 
    {
        using(HaliabdContext db = new HaliabdContext())
        {
            Linea linea = db.Lineas.Find(entryId);

            if (linea != null)
            {
                linea.Nombre = name.Trim();    
            }

            db.SaveChanges();
        }
    }

    public async Task<List<List<object>>> GetProviderAsync(string filter) 
    {
        List<List<object>> rows = new List<List<object>>();

        using(HaliabdContext db = new HaliabdContext())
        {
            List<Proveedor> proveedorList = db.Proveedors.Where(e => e.NombreProveedor.Contains(filter) && e.IsActive == "Activo").ToList();

            foreach (var item in proveedorList)
            {
                List<object> fila = new List<object>();
                fila.Add(item.ProveedorId);
                fila.Add(item.NombreProveedor);
                fila.Add(item.NumeroTelefono);
                fila.Add(item.Direccion);
                fila.Add(item.Pais);

                rows.Add(fila);
            }
        }

        return rows;
    }

    public async Task<Proveedor> GetSingleProviderAsync(int entryId)
    {
        using (HaliabdContext db = new HaliabdContext())
        {
            Proveedor proveedor = await db.Proveedors.FirstOrDefaultAsync(e => e.ProveedorId == entryId);
            return proveedor;
        }
    }

    public async Task AddProviderAsync(string name, string telefono, string direccion, string pais) 
    {
        using(HaliabdContext db = new HaliabdContext())
        {
            Proveedor proveedor = new Proveedor()
            {
                NombreProveedor = name.Trim(), 
                NumeroTelefono = telefono.Trim(),
                Direccion = direccion.Trim(),
                Pais = pais.Trim(),
                IsActive = "Activo"
            };

            db.Add(proveedor);
            db.SaveChanges();
        }
    }

    public async Task UpdateProviderAsync(int entryId, string name, string telefono, string direccion, string pais) 
    {
        using(HaliabdContext db = new HaliabdContext())
        {
            Proveedor proveedor = db.Proveedors.Find(entryId);

            if (proveedor != null)
            {
                proveedor.NombreProveedor = name.Trim();
                proveedor.NumeroTelefono = telefono.Trim();
                proveedor.Direccion = direccion.Trim();
                proveedor.Pais = pais.Trim();
            }

            db.SaveChanges();
        }
    }

    public async Task AddCategoryAsync (string name)
    {
        using(HaliabdContext db = new HaliabdContext())
        {
            Categorium categoria = new Categorium()
            {
                Nombre = name.Trim(),
                IsActive = "Activo" 
            };   

            db.Add(categoria);
            db.SaveChanges();
        }
    }

    public async Task UpdateCategoryAsync(int entryId, string name)
    {
        using(HaliabdContext db = new HaliabdContext())
        {
            Categorium categoria = db.Categoria.Find(entryId);

            if (categoria != null)
            {
                categoria.Nombre = name.Trim();    
            }

            db.SaveChanges();
        }
    }

    public async Task<List<List<object>>> GetCategoryAsync(string filter)
    {
        List<List<object>> rows = new List<List<object>>();

        using(HaliabdContext db = new HaliabdContext())
        {
            List<Categorium> categoria = db.Categoria.Where(e => e.Nombre.Contains(filter) && e.IsActive == "Activo").ToList();

            foreach (var item in categoria)
            {
                List<object> fila = new List<object>();
                fila.Add(item.CategoriaId);
                fila.Add(item.Nombre);

                rows.Add(fila);
            }
        }

        return rows;
    }

    public async Task<Categorium> GetSingleCategoryAsync(int entryId)
    {
        using (HaliabdContext db = new HaliabdContext())
        {
            Categorium categoria = await db.Categoria.FirstOrDefaultAsync(e => e.CategoriaId == entryId);
            return categoria;
        }
    }

    public async Task BlockCategoryAsync(int entryId)
    {
        using(HaliabdContext db = new HaliabdContext())
        {
            Categorium category = db.Categoria.Find(entryId);

            if (category != null)
            {
                category.IsActive = "No";
            }

            db.SaveChanges();
        }
    }

    public async Task BlockProductLineAsync(int entryId)
    {
        using(HaliabdContext db = new HaliabdContext())
        {
            Linea line = db.Lineas.Find(entryId);

            if (line != null)
            {
                line.IsActive = "No";
            }

            db.SaveChanges();
        }
    }

    public async Task BlockProviderAsync(int entryId)
    {
        using(HaliabdContext db = new HaliabdContext())
        {
            Proveedor provider = db.Proveedors.Find(entryId);

            if (provider != null)
            {
                provider.IsActive = "No";
            }

            db.SaveChanges();
        }
    }

    public async Task BlockProductAsync(int entryId)
    {
        using(HaliabdContext db = new HaliabdContext())
        {
            Producto product = db.Productos.Find(entryId);

            if (product != null)
            {
                product.IsActive = "No";
            }

            db.SaveChanges();
        }
    }
} 