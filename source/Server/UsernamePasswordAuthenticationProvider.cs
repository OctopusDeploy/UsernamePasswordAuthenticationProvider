using Octopus.Server.Extensibility.Authentication.Extensions;
using Octopus.Server.Extensibility.Authentication.Resources;
using Octopus.Server.Extensibility.Authentication.UsernamePassword.Configuration;

namespace Octopus.Server.Extensibility.Authentication.UsernamePassword
{
    class UsernamePasswordAuthenticationProvider : IAuthenticationProvider
    {
        public const string ProviderName = "Octopus";
        
        readonly IUsernamePasswordConfigurationStore configurationStore;

        public UsernamePasswordAuthenticationProvider(IUsernamePasswordConfigurationStore configurationStore)
        {
            this.configurationStore = configurationStore;
        }

        public string IdentityProviderName => ProviderName;

        public bool IsEnabled => configurationStore.GetIsEnabled();

        public bool SupportsPasswordManagement => true;

        public AuthenticationProviderElement GetAuthenticationProviderElement()
        {
            var authenticationProviderElement = new AuthenticationProviderElement
            {
                Name = IdentityProviderName,
                IdentityType = IdentityType.UsernamePassword,
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