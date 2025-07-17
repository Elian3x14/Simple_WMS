using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using TKS_intern_shared.ViewModels.Auth;

namespace TKS_intern_client.Services.Implements
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;
        private readonly NavigationManager _navigationManager;

        public AuthService(HttpClient httpClient,
                          ILocalStorageService localStorage,
                          NavigationManager navigationManager)
        {
            _httpClient = httpClient;
            _localStorage = localStorage;
            _navigationManager = navigationManager;
        }

        public async Task<TokenVM> LoginAsync(string username, string password)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/auth/login", new
                {
                    Username = username,
                    Password = password
                });

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<TokenVM>();
                    if (result == null || string.IsNullOrEmpty(result.AccessToken))
                    {
                        return new TokenVM { Success = false, Message = "Invalid response from server" };
                    }
                    await _localStorage.SetItemAsync("authToken", result.AccessToken);
                    return result;
                }

                return new TokenVM { Success = false, Message = "Sai tên đăng nhập hoặc mật khẩu" };
            }
            catch (Exception ex)
            {
                return new TokenVM { Success = false, Message = ex.Message };
            }
        }

        public async Task LogoutAsync()
        {
            await _localStorage.RemoveItemAsync("authToken");
            _navigationManager.NavigateTo("/login");
        }

        public async Task<bool> IsAuthenticatedAsync()
        {
            var token = await _localStorage.GetItemAsync<string>("authToken");
            return !string.IsNullOrEmpty(token);
        }
    }
}
