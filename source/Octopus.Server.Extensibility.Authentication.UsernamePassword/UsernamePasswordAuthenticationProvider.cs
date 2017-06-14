using Octopus.Node.Extensibility.Authentication.Extensions;
using Octopus.Node.Extensibility.Authentication.Resources;
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

        public AuthenticationProviderElement GetAuthenticationProviderElement()
        {
            var authenticationProviderElement = new AuthenticationProviderElement
            {
                Name = IdentityProviderName,
                FormsLoginEnabled = true
            };

            return authenticationProviderElement;
        }

        public string[] GetAuthenticationUrls()
        {
            return new string[0];
        }
    }
}