using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NovaLaundryAppWebAdminBlazor.Server.Services;
using NovaLaundryAppWebAdminBlazor.Server.ViewModels;
using NovaLaundryAppWebAdminBlazor.ModelsHalia;

using Microsoft.EntityFrameworkCore;


public class ThirdPartyService : IthirdPartyService
{
    public async Task<List<List<object>>> GetCategoriesAsync(string filter)
    {
        List<List<object>> rows = new List<List<object>>();

        using(HaliabdContext db = new HaliabdContext())
        {
            try
            {
                List<CategoriaTercero> categoriaTercerosList = await db.CategoriaTerceros.Where(e => e.IsActive == "Activo" && e.Nombre.Contains(filter)).ToListAsync();

                foreach (var item in categoriaTercerosList)
                {
                    List<object> fila = new List<object>
                    {
                        item.CategoriaId,
                        item.Nombre
                    };

                    rows.Add(fila);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        return rows;
    }

    public async Task AddCategoryAsync(string name, string active)
    {
        // active = "Activo";
        using(HaliabdContext db = new HaliabdContext())
        {
            try
            {
                CategoriaTercero categoriaTercero = new CategoriaTercero()
                {
                    Nombre = name.Trim(),
                    IsActive = active
                };   

                db.Add(categoriaTercero);
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    public async Task UpdateCategoryAsync(int entryId, string name)
    {
        using(HaliabdContext db = new HaliabdContext())
        {
            try
            {
                CategoriaTercero categoriaTercero = db.CategoriaTerceros.Find(entryId);

                if (categoriaTercero != null)
                {
                    categoriaTercero.Nombre = name.Trim();    
                }

                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    public async Task BlockCategoryAsync(int entryId)
    {
        using(HaliabdContext db = new HaliabdContext())
        {
            try
            {
                CategoriaTercero categoriaTercero = db.CategoriaTerceros.Find(entryId);

                if (categoriaTercero != null)
                {
                    categoriaTercero.IsActive = "No";
                }

                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    public async Task<CategoriaTercero> GetSingleCategoryAsync(int entryId)
    {
        using (HaliabdContext db = new HaliabdContext())
        {
            try
            {
                CategoriaTercero categoriaTercero = await db.CategoriaTerceros.FirstOrDefaultAsync(e => e.CategoriaId == entryId);
                return categoriaTercero;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }

    public async Task<List<List<object>>> GetProductsTercerosAsync(string filter, int empresaId)
    {
        List<List<object>> rows = new List<List<object>>();

        using (HaliabdContext db = new HaliabdContext())
        {
            try
            {
                IQueryable<ProductosEmpresasTercera> query = db.ProductosEmpresasTerceras.Where(e => e.IsActive == "Activo");

                if (empresaId != 0) // Assuming 0 is the default value when no empresaId is selected
                {
                    query = query.Where(e => e.EmpresaTercerizadaId == empresaId);
                }

                if (!string.IsNullOrWhiteSpace(filter))
                {
                    query = query.Where(e => e.Nombre.Contains(filter));
                }

                List<ProductosEmpresasTercera> productosEmpresasTercera = await query.ToListAsync();

                foreach (var item in productosEmpresasTercera)
                {
                    List<object> fila = new List<object>
                    {
                        item.ProductoId,
                        item.Nombre,
                        item.Descripcion,
                        item.Precio,
                        item.Cantidad
                    };

                    rows.Add(fila);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            
            }
        }

        return rows;
    }

    public async Task AddProductAsync(ProductosEmpresasTercera product)
    {
        using(HaliabdContext db = new HaliabdContext())
        {
            try
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    public async Task AddProductCategoryAsync(int productId, int categoryId)
    {
        using (HaliabdContext db = new HaliabdContext())
        {
            try
            {
                RelCategoriaProductosTercero rel = new RelCategoriaProductosTercero
                {
                    ProductoId = productId,
                    CategoriaId = categoryId
                };

                db.Add(rel);
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    public async Task UpdateProductAsync(int entryId, List<string> selectedCategoryIds, ProductosEmpresasTercera product)
    {
        using(HaliabdContext db = new HaliabdContext())
        {
            try
            {
                ProductosEmpresasTercera productos = db.ProductosEmpresasTerceras.Find(entryId);

                if (productos != null)
                {
                    productos.Nombre = product.Nombre;
                    productos.Precio = product.Precio;
                    productos.Codigo = product.Codigo;
                    productos.Descripcion = product.Descripcion;
                    productos.EmpresaTercerizadaId = product.EmpresaTercerizadaId;
                    productos.Cantidad = product.Cantidad;
                    productos.CantidadMaxima = product.CantidadMaxima;
                    productos.CantidadMinima = product.CantidadMinima;

                    db.RelCategoriaProductosTerceros.RemoveRange(
                        db.RelCategoriaProductosTerceros
                            .Where(rel => rel.ProductoId == entryId && !selectedCategoryIds.Contains(rel.CategoriaId.ToString()))
                    );

                    foreach (string categoryId in selectedCategoryIds)
                    {
                        if (!await db.RelCategoriaProductosTerceros.AnyAsync(rel => rel.ProductoId == entryId && rel.CategoriaId.ToString() == categoryId))
                        {
                            db.RelCategoriaProductosTerceros.Add(new RelCategoriaProductosTercero
                            {
                                ProductoId = entryId,
                                CategoriaId = int.Parse(categoryId)
                            });
                        }
                    }

                    await db.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    public async Task BlockProductAsync(int entryId)
    {
        using(HaliabdContext db = new HaliabdContext())
        {
            try
            {
                ProductosEmpresasTercera productos = db.ProductosEmpresasTerceras.Find(entryId);

                if (productos != null)
                {
                    productos.IsActive = "No";
                }

                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    public async Task<ProductosEmpresasTercera> GetSingleProductThirdPartyAsync(int entryId)
    {
        using (HaliabdContext db = new HaliabdContext())
        {
            try
            {
                ProductosEmpresasTercera productosEmpresasTercera = await db.ProductosEmpresasTerceras.FirstOrDefaultAsync(e => e.ProductoId == entryId);
                return productosEmpresasTercera;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }

    public async Task<List<string>> GetAssociatedCategoriesAsync(int productId)
    {
        using (HaliabdContext db = new HaliabdContext())
        {
            try
            {
                // Query the relational table to get the associated category IDs for the given product ID
                List<string> associatedCategoryIds = await db.RelCategoriaProductosTerceros
                    .Where(rel => rel.ProductoId == productId)
                    .Select(rel => rel.CategoriaId.ToString())
                    .ToListAsync();

                return associatedCategoryIds;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}