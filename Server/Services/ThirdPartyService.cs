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
            List<CategoriaTercero> categoriaTercerosList = db.CategoriaTerceros.Where(e => e.Nombre.Contains(filter) && e.IsActive == "Activo").ToList();

            foreach (var item in categoriaTercerosList)
            {
                List<object> fila = new List<object>();
                fila.Add(item.CategoriaId);
                fila.Add(item.Nombre);

                rows.Add(fila);
            }
        }

        return rows;
    }

    public async Task AddCategoryAsync(string name, string active)
    {
        // active = "Activo";
        using(HaliabdContext db = new HaliabdContext())
        {
            CategoriaTercero categoriaTercero = new CategoriaTercero()
            {
                Nombre = name.Trim(),
                IsActive = active
            };   

            db.Add(categoriaTercero);
            db.SaveChanges();
        }
    }

    public async Task UpdateCategoryAsync(int entryId, string name)
    {
        using(HaliabdContext db = new HaliabdContext())
        {
            CategoriaTercero categoriaTercero = db.CategoriaTerceros.Find(entryId);

            if (categoriaTercero != null)
            {
                categoriaTercero.Nombre = name.Trim();    
            }

            db.SaveChanges();
        }
    }

    public async Task<CategoriaTercero> GetSingleCategoryAsync(int entryId)
    {
        using (HaliabdContext db = new HaliabdContext())
        {
            CategoriaTercero categoriaTercero = await db.CategoriaTerceros.FirstOrDefaultAsync(e => e.CategoriaId == entryId);
            return categoriaTercero;
        }
    }

    public async Task<List<List<object>>> GetProductsTercerosAsync(string filter, int empresaId)
    {
        List<List<object>> rows = new List<List<object>>();

        using (HaliabdContext db = new HaliabdContext())
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
                List<object> fila = new List<object>();
                fila.Add(item.ProductoId);
                fila.Add(item.Nombre);
                fila.Add(item.Descripcion);
                fila.Add(item.Precio);
                fila.Add(item.Cantidad);

                rows.Add(fila);
            }
        }

        return rows;
    }

    public async Task AddProductAsync(ProductosEmpresasTercera product)
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
            RelCategoriaProductosTercero rel = new RelCategoriaProductosTercero
            {
                ProductoId = productId,
                CategoriaId = categoryId
            };

            db.Add(rel);
            await db.SaveChangesAsync();
        }
    }

}