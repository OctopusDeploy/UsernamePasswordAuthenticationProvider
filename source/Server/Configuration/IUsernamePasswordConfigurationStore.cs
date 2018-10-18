using Octopus.Server.Extensibility.Extensions.Infrastructure.Configuration;

namespace Octopus.Server.Extensibility.Authentication.UsernamePassword.Configuration
{
    public interface IUsernamePasswordConfigurationStore : IExtensionConfigurationStore<UsernamePasswordConfiguration>
    {
    }
}