using Octopus.Server.Extensibility.Extensions.Infrastructure.Configuration;

namespace Octopus.Server.Extensibility.Authentication.UsernamePassword.Configuration
{
    interface IUsernamePasswordConfigurationStore : IExtensionConfigurationStore<UsernamePasswordConfiguration>
    {
    }
}