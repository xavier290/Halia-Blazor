using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public interface IAuthenticationService
{
    Task<bool> LoginAsync(string username, string password);
    Task<bool> LogoutAsync();

    Task<bool> IsAuthenticatedAsync();
}