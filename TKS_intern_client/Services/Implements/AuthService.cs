using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using TKS_intern_client.Providers;
using TKS_intern_shared.ViewModels.Auth;

namespace TKS_intern_client.Services.Implements
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;
        private readonly NavigationManager _navigationManager;
        private readonly AuthenticationStateProvider _authenticationStateProvider;

        public AuthService(HttpClient httpClient,
                          ILocalStorageService localStorage,
                          NavigationManager navigationManager,
                          AuthenticationStateProvider authenticationStateProvider)
        {
            _httpClient = httpClient;
            _localStorage = localStorage;
            _navigationManager = navigationManager;
            _authenticationStateProvider = authenticationStateProvider;
        }

        public async Task<TokenVM?> LoginAsync(string username, string password)
        {
            try
            {
                var loginPayload = new
                {
                    Username = username,
                    Password = password
                };

                var response = await _httpClient.PostAsJsonAsync("api/auth/login", loginPayload);

                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Login failed with status {response.StatusCode}. Message: {errorContent}");
                }

                var result = await response.Content.ReadFromJsonAsync<TokenVM>();

                if (result == null || string.IsNullOrWhiteSpace(result.AccessToken))
                {
                    throw new Exception("Invalid login response: missing access token.");
                }

                await _localStorage.SetItemAsync("authToken", result.AccessToken);

                // Cập nhật AuthenticationState nếu bạn dùng Blazor Authentication
                ((CustomAuthStateProvider)_authenticationStateProvider).NotifyUserAuthentication(result.AccessToken);

                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", result.AccessToken);

                return result;
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("Network error while trying to login.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred during login: {ex.Message}", ex);
            }
        }

        public async Task LogoutAsync()
        {
            await _localStorage.RemoveItemAsync("authToken");
            _navigationManager.NavigateTo("/login");
        }
    }
}
