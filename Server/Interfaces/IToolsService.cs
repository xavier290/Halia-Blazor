using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NovaLaundryAppWebAdminBlazor.ModelsHalia;


public interface IToolsService
{
    // funcitions for CRUD products
    Task<List<List<object>>> GetThirdPartyAsync(string filter);
    Task<EmpresasTercera> GetSingleThirdPartyAsync(int entryId);
    Task AddThirdPartyAsync(string Name, string ComercialName, string ruc, string direccion, string telefono);
    Task UpdateThirdPartyAsync(int entryId, string Name, string ComercialName, string ruc, string direccion, string telefono);
    Task BlockThirdPartyAsync(int entryId);

    Task<List<List<object>>> GetBranchesAsync(string filter, int empresaId);
    Task<Sucursale> GetSingleBranchAsync(int entryId);
    Task AddBranchAsync(string Name, string direccion, string estado, string telefono, string correo, int empresaId);
    Task UpdateBranchAsync(int entryId, string Name, string direccion, string estado, string telefono, string correo, int empresaId);

}