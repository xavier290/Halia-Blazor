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
}