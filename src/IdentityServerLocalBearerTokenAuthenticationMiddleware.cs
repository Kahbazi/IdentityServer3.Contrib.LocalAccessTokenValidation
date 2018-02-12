using Microsoft.Owin;
using Microsoft.Owin.Security.Infrastructure;

namespace IdentityServer3.Contrib.LocalAccessTokenValidation
{
    public class IdentityServerLocalBearerTokenAuthenticationMiddleware : AuthenticationMiddleware<IdentityServerLocalBearerTokenAuthenticationOptions>
    {
        public IdentityServerLocalBearerTokenAuthenticationMiddleware(OwinMiddleware next, IdentityServerLocalBearerTokenAuthenticationOptions options)
            : base(next, options)
        {
        }

        protected override AuthenticationHandler<IdentityServerLocalBearerTokenAuthenticationOptions> CreateHandler()
        {
            return new IdentityServerLocalBearerTokenAuthenticationHandler();
        }
    }
}