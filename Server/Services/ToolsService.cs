using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NovaLaundryAppWebAdminBlazor.Server.Services;
using NovaLaundryAppWebAdminBlazor.Server.ViewModels;
using NovaLaundryAppWebAdminBlazor.ModelsHalia;

using Microsoft.EntityFrameworkCore;


public class ToolsService : IToolsService
{
    public async Task<List<List<object>>> GetThirdPartyAsync(string filter)
    {
            List<List<object>> rows = new List<List<object>>();

            using(HaliabdContext db = new HaliabdContext())
            {
                List<EmpresasTercera> empresasTerceraList = db.EmpresasTerceras.Where(e => e.NombreComercial.Contains(filter)).ToList();

                foreach (var item in empresasTerceraList)
                {
                    List<object> fila = new List<object>();
                    fila.Add(item.EmpresasTercerasId);
                    fila.Add(item.Nombre);
                    fila.Add(item.NombreComercial);
                    fila.Add(item.Ruc);
                    fila.Add(item.Dirección);
                    fila.Add(item.Telefono);

                    rows.Add(fila);
                }
            }

            return rows;
    }

    public async Task AddThirdPartyAsync(string Name, string ComercialName, string ruc, string direccion, string telefono) 
    {
        using(HaliabdContext db = new HaliabdContext())
        {
            EmpresasTercera empresasTercera = new EmpresasTercera()
            {
                Nombre = Name.Trim(), 
                NombreComercial = ComercialName.Trim(),
                Ruc = ruc.Trim(),
                Dirección = direccion.Trim(),
                Telefono = telefono.Trim()
            };   

            db.Add(empresasTercera);
            db.SaveChanges();
        }
    }

    public async Task UpdateThirdPartyAsync(int entryId, string Name, string ComercialName, string ruc, string direccion, string telefono) 
    {
        using(HaliabdContext db = new HaliabdContext())
        {
            EmpresasTercera empresasTercera = db.EmpresasTerceras.Find(entryId);

            if (empresasTercera != null)
            {
                empresasTercera.Nombre = Name.Trim();
                empresasTercera.NombreComercial = ComercialName.Trim();
                empresasTercera.Ruc = ruc.Trim();
                empresasTercera.Dirección = direccion.Trim();
                empresasTercera.Telefono = telefono.Trim();
            }

            db.SaveChanges();
        }
    }
    public async Task<EmpresasTercera> GetSingleThirdPartyAsync(int entryId)
    {
        using (HaliabdContext db = new HaliabdContext())
        {
            EmpresasTercera empresasTercera = await db.EmpresasTerceras.FirstOrDefaultAsync(e => e.EmpresasTercerasId == entryId);
            return empresasTercera;
        }
    }
}