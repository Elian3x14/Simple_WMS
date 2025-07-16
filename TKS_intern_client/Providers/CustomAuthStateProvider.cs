using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using TKS_intern_client.Services;

namespace TKS_intern_client.Providers
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        private readonly IAuthService _authService;

        public CustomAuthStateProvider(IAuthService authService)
        {
            _authService = authService;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var isAuthenticated = await _authService.IsAuthenticatedAsync();

            var identity = isAuthenticated
                ? new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, "user") }, "apiauth")
                : new ClaimsIdentity();

            return new AuthenticationState(new ClaimsPrincipal(identity));
        }
    }
}
