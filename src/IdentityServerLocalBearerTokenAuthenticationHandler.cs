using IdentityServer3.Core.Extensions;
using IdentityServer3.Core.Validation;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Infrastructure;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentityServer3.Contrib.LocalAccessTokenValidation
{
    public class IdentityServerLocalBearerTokenAuthenticationHandler : AuthenticationHandler<IdentityServerLocalBearerTokenAuthenticationOptions>
    {
        protected override async Task<AuthenticationTicket> AuthenticateCoreAsync()
        {
            string requestToken = null;

            string authorization = Request.Headers["Authorization"];

            if (string.IsNullOrEmpty(authorization))
            {
                return null;
            }

            if (authorization.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
            {
                requestToken = authorization.Substring("Bearer ".Length).Trim();
            }

            if (string.IsNullOrEmpty(requestToken))
            {
                return null;
            }

            TokenValidator tokenValidator = Context.Environment.ResolveDependency<TokenValidator>();
            TokenValidationResult result = await tokenValidator.ValidateAccessTokenAsync(requestToken,Options.ExpectedScope);
            if (result.IsError)
            {
                return null;
            }

            AuthenticationProperties properties = new AuthenticationProperties();
            ClaimsIdentity identity = new ClaimsIdentity(result.Claims, Options.AuthenticationType);
            return new AuthenticationTicket(identity, properties);
        }
    }
}