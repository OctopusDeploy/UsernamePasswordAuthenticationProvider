using System.Collections.Generic;
using Octopus.Data.Storage.Configuration;
using Octopus.Node.Extensibility.Extensions.Infrastructure.Configuration;
using Octopus.Node.Extensibility.HostServices.Mapping;

namespace Octopus.Server.Extensibility.Authentication.UsernamePassword.Configuration
{
    public class UsernamePasswordConfigurationStore : ExtensionConfigurationStore<UsernamePasswordConfiguration, UsernamePasswordConfigurationResource>, IUsernamePasswordConfigurationStore
    {
        public static string SingletonId = "authentication-usernamepassword";

        public UsernamePasswordConfigurationStore(
            IConfigurationStore configurationStore,
            IResourceMappingFactory factory) : base(configurationStore, factory)
        {
        }

        public override string Id => SingletonId;

        public override string ConfigurationSetName => "Username / Password";

        public override string Description => "Usernames and passwords managed by Octopus";

        public override IEnumerable<ConfigurationValue> GetConfigurationValues()
        {
            yield return new ConfigurationValue("Octopus.UsernamePassword.IsEnabled", GetIsEnabled().ToString(), GetIsEnabled(), "Is Enabled");
        }

        public override IResourceMapping GetMapping()
        {
            return ResourceMappingFactory
                .Create<UsernamePasswordConfigurationResource, UsernamePasswordConfiguration>();
        }
    }
}