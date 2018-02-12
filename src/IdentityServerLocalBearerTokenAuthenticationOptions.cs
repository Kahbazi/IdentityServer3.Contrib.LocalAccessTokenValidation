using Microsoft.Owin.Security;

namespace IdentityServer3.Contrib.LocalAccessTokenValidation
{
    public class IdentityServerLocalBearerTokenAuthenticationOptions : AuthenticationOptions
    {
        public IdentityServerLocalBearerTokenAuthenticationOptions()
            : base("LocalAccessTokenValidation")
        {
        }

        public string ExpectedScope { get; set; }
    }
}