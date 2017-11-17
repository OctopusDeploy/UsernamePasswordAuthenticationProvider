using Octopus.Client.Extensibility.Extensions.Infrastructure.Configuration;

namespace Octopus.Server.Extensibility.Authentication.UsernamePassword.Configuration
{
    public class UsernamePasswordConfigurationResource : ExtensionConfigurationResource
    {
        public UsernamePasswordConfigurationResource()
        {
            Id = "authentication-usernamepassword";
        }
    }
}