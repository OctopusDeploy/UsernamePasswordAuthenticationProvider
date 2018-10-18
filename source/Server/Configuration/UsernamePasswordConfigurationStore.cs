using Octopus.Data.Storage.Configuration;
using Octopus.Server.Extensibility.Extensions.Infrastructure.Configuration;

namespace Octopus.Server.Extensibility.Authentication.UsernamePassword.Configuration
{
    public class UsernamePasswordConfigurationStore : ExtensionConfigurationStore<UsernamePasswordConfiguration>, IUsernamePasswordConfigurationStore
    {
        public static string SingletonId = "authentication-usernamepassword";

        public UsernamePasswordConfigurationStore(
            IConfigurationStore configurationStore) : base(configurationStore)
        {
        }

        public override string Id => SingletonId;
    }
}