using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace BlogApp.Client;

public class ApiAuthenticationStateProvider : AuthenticationStateProvider
{
    private static readonly AuthenticationState _anonymous = new(new ClaimsPrincipal(new ClaimsIdentity()));

    public override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        return Task.FromResult(_anonymous);
    }
}