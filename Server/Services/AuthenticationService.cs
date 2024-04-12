using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NovaLaundryAppWebAdminBlazor.Server.Services;
using NovaLaundryAppWebAdminBlazor.Server.ViewModels;
using NovaLaundryAppWebAdminBlazor.ModelsHalia;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using Blazored.LocalStorage;


public class AuthenticationService : IAuthenticationService
{

    private readonly ILocalStorageService _localStorage;

    public AuthenticationService(ILocalStorageService localStorage)
    {
        _localStorage = localStorage;
    }
    public async Task<bool> LoginAsync(string username, string password)
    {
        try
        {
            using (SystemAdminContext db = new SystemAdminContext()) 
            {
                // Check if username and password are provided
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    return false;
                }

                // Retrieve user from the database based on username and password
                Usuario user = db.Usuarios.FirstOrDefault(u => u.Nombre == username && u.Pass == password);

                // If user is null, authentication failed
                if (user == null || user.Estado == "Bloqueado")
                {
                    return false;
                }

                await _localStorage.SetItemAsync("IsAuthenticated", true);
                await _localStorage.SetItemAsync("user", user.PrimerNombre.ToString() + " " + user.PrimerApellido.ToString());
                await _localStorage.SetItemAsync("userId",user.IdUsuarios.ToString());
                await _localStorage.SetItemAsync("sucursalId",user.SucursalId.ToString());

                return true;
            }
        }
        catch (Exception ex)
        {
            // Log any exceptions
            Console.WriteLine($"An error occurred during authentication: {ex.Message}");
            return false;
        }
    }

    public async Task<bool> LogoutAsync()
    {
        try
        {
            // Clear authentication status from local storage
            await _localStorage.RemoveItemAsync("IsAuthenticated");
            await _localStorage.RemoveItemAsync("user");
            await _localStorage.RemoveItemAsync("userId");
            await _localStorage.RemoveItemAsync("sucursalId");
            return true;
        }
        catch (Exception ex)
        {
            // Log and handle exceptions
            Console.WriteLine($"An error occurred during logout: {ex.Message}");
            return false;
        }
    }
    public async Task<bool> IsAuthenticatedAsync()
    {
        try
        {
            // Retrieve authentication status from local storage
            return await _localStorage.GetItemAsync<bool>("IsAuthenticated");
        }
        catch (Exception ex)
        {
            // Log and handle exceptions
            Console.WriteLine($"An error occurred while checking authentication status: {ex.Message}");
            return false;
        }
    }
}