using Octopus.Data.Storage.Configuration;
using Octopus.Node.Extensibility.Extensions.Infrastructure.Configuration;
using Octopus.Node.Extensibility.HostServices.Mapping;

namespace Octopus.Server.Extensibility.Authentication.UsernamePassword.Configuration
{
    public class UsernamePasswordConfigurationStore : ExtensionConfigurationStore<UsernamePasswordConfiguration>, IUsernamePasswordConfigurationStore
    {
        public static string SingletonId = "authentication-usernamepassword";

        public UsernamePasswordConfigurationStore(
            IConfigurationStore configurationStore,
            IResourceMappingFactory factory) : base(configurationStore, factory)
        {
        }

        public override string Id => SingletonId;
    }
}