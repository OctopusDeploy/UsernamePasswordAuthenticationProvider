using Octopus.Client.Extensibility.Extensions.Infrastructure.Configuration;

namespace Octopus.Client.Extensibility.Authentication.UsernamePassword.Configuration
{
    public class UsernamePasswordConfigurationResource : ExtensionConfigurationResource
    {
        public UsernamePasswordConfigurationResource()
        {
            Id = "authentication-usernamepassword";
        }
    }
}