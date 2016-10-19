using Octopus.Server.Extensibility.Authentication.Extensions;
using Octopus.Server.Extensibility.Authentication.Resources;
using Octopus.Server.Extensibility.Authentication.UsernamePassword.Configuration;

namespace Octopus.Server.Extensibility.Authentication.UsernamePassword
{
    public class UsernamePasswordAuthenticationProvider : IAuthenticationProvider
    {
        readonly IUsernamePasswordConfigurationStore configurationStore;

        public UsernamePasswordAuthenticationProvider(IUsernamePasswordConfigurationStore configurationStore)
        {
            this.configurationStore = configurationStore;
        }

        public string IdentityProviderName => "Octopus";

        public bool IsEnabled => configurationStore.GetIsEnabled();

        public bool SupportsPasswordManagement => true;

        string AuthenticateUri => UsernamePasswordApi.ApiUsersAuthenticate;

        public AuthenticationProviderElement GetAuthenticationProviderElement(string siteBaseUri)
        {
            var authenticationProviderElement = new AuthenticationProviderElement
            {
                Name = IdentityProviderName,
                FormsLoginEnabled = true
            };
            authenticationProviderElement.Links.Add(AuthenticationProviderElement.FormsAuthenticateLinkName, AuthenticateUri);

            return authenticationProviderElement;
        }
    }
}