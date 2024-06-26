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
            try
            {
                List<EmpresasTercera> empresasTerceraList = db.EmpresasTerceras.Where(e => e.IsActive == "Activo" && e.NombreComercial.Contains(filter)).ToList();

                foreach (var item in empresasTerceraList)
                {
                    List<object> fila = new List<object>
                    {
                        item.EmpresasTercerasId,
                        item.Nombre,
                        item.NombreComercial,
                        item.CodigoEmpresa,
                        item.Ruc,
                        item.Dirección,
                        item.Telefono
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

    public async Task AddThirdPartyAsync(string Name, string ComercialName, string ruc, string direccion, string telefono, string claveEmpresa) 
    {
        using(HaliabdContext db = new HaliabdContext())
        {
            try
            {
                EmpresasTercera empresasTercera = new EmpresasTercera()
                {
                    Nombre = Name.Trim(), 
                    NombreComercial = ComercialName.Trim(),
                    Ruc = ruc.Trim(),
                    Dirección = direccion.Trim(),
                    Telefono = telefono.Trim(),
                    IsActive = "Activo",
                    CodigoEmpresa = claveEmpresa.Trim(),
                };

                db.Add(empresasTercera);

                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    public async Task UpdateThirdPartyAsync(int entryId, string Name, string ComercialName, string ruc, string direccion, string telefono, string claveEmpresa) 
    {
        using(HaliabdContext db = new HaliabdContext())
        {
            try
            {
                EmpresasTercera empresasTercera = db.EmpresasTerceras.Find(entryId);

                if (empresasTercera != null)
                {
                    empresasTercera.Nombre = Name.Trim();
                    empresasTercera.NombreComercial = ComercialName.Trim();
                    empresasTercera.Ruc = ruc.Trim();
                    empresasTercera.Dirección = direccion.Trim();
                    empresasTercera.Telefono = telefono.Trim();
                    empresasTercera.CodigoEmpresa = claveEmpresa.Trim();
                }

                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
    public async Task<EmpresasTercera> GetSingleThirdPartyAsync(int entryId)
    {
        using (HaliabdContext db = new HaliabdContext())
        {
            try
            {
                EmpresasTercera empresasTercera = await db.EmpresasTerceras.FirstOrDefaultAsync(e => e.EmpresasTercerasId == entryId);
                return empresasTercera;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }

    public async Task BlockThirdPartyAsync(int entryId)
    {
        using (HaliabdContext db = new HaliabdContext())
        {
            try
            {
                EmpresasTercera empresasTercera = await db.EmpresasTerceras.FirstOrDefaultAsync(e => e.EmpresasTercerasId == entryId);

                if (empresasTercera != null)
                {
                    empresasTercera.IsActive = "No";
                }

                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    public async Task<List<List<object>>> GetBranchesAsync(string filter, int empresaId)
    {
        List<List<object>> rows = new List<List<object>>();

        using(HaliabdContext db = new HaliabdContext())
        {
            try
            {
                List<Sucursale> sucursale = db.Sucursales.Where(e => e.EmpresaId == empresaId && e.Estado == "Activo" && e.NombreSucursal.Contains(filter)).ToList();

                foreach (var item in sucursale)
                {
                    List<object> fila = new List<object>();

                    fila.Add(item.SucursalId);
                    fila.Add(item.NombreSucursal);
                    fila.Add(item.Direccion);
                    fila.Add(item.Telefono);
                    fila.Add(item.Correo);

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
    public async Task<Sucursale> GetSingleBranchAsync(int entryId)
    {
        using (HaliabdContext db = new HaliabdContext())
        {
            try
            {
                Sucursale sucursale = await db.Sucursales.FirstOrDefaultAsync(e => e.SucursalId == entryId);
                return sucursale;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
    public async Task AddBranchAsync(string Name, string direccion, string estado, string telefono, string correo, int empresaId)
    {
        using(HaliabdContext db = new HaliabdContext())
        {
            try
            {
                Sucursale sucursale = new Sucursale()
                {
                    NombreSucursal = Name.Trim(), 
                    Direccion = direccion.Trim(),
                    Estado = estado.Trim(),
                    Telefono = telefono.Trim(),
                    Correo = correo.Trim(),
                    EmpresaId = empresaId
                };   

                db.Add(sucursale);
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    public async Task UpdateBranchAsync(int entryId, string Name, string direccion, string estado, string telefono, string correo, int empresaId)
    {
        using(HaliabdContext db = new HaliabdContext())
        {
            try
            {
                Sucursale sucursale = db.Sucursales.Find(entryId);

                if (sucursale != null)
                {
                    sucursale.NombreSucursal = Name.Trim();
                    sucursale.Direccion = direccion.Trim();
                    sucursale.Estado = estado.Trim();
                    sucursale.Telefono = telefono.Trim();
                    sucursale.Correo = correo.Trim();
                    sucursale.EmpresaId = empresaId;
                }

                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    public async Task BlockBranchAsync(int entryId)
    {
        using(HaliabdContext db = new HaliabdContext())
        {
            try
            {
                Sucursale sucursale = db.Sucursales.Find(entryId);

                if (sucursale != null)
                {
                    sucursale.Estado = "No";
                }

                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}