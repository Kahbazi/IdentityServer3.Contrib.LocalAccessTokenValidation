using Owin;

namespace IdentityServer3.Contrib.LocalAccessTokenValidation
{
    public static class IdentityServerLocalBearerTokenAuthenticationExtensions
    {
        public static IAppBuilder UseIdentityServerLocalBearerTokenAuthentication(this IAppBuilder app, IdentityServerLocalBearerTokenAuthenticationOptions options)
        {
            return app.Use<IdentityServerLocalBearerTokenAuthenticationMiddleware>(options);
        }
    }
}