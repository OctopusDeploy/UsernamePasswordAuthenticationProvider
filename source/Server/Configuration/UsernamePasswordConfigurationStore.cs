using System.Collections.Generic;
using Octopus.Data.Storage.Configuration;
using Octopus.Node.Extensibility.Extensions.Infrastructure.Configuration;
using Octopus.Node.Extensibility.HostServices.Mapping;

namespace Octopus.Server.Extensibility.Authentication.UsernamePassword.Configuration
{
    public class UsernamePasswordConfigurationStore : ExtensionConfigurationStore<UsernamePasswordConfiguration, UsernamePasswordConfiguration>, IUsernamePasswordConfigurationStore
    {
        public static string SingletonId = "authentication-usernamepassword";

        public UsernamePasswordConfigurationStore(
            IConfigurationStore configurationStore,
            IResourceMappingFactory factory) : base(configurationStore, factory)
        {
        }

        protected override UsernamePasswordConfiguration MapToResource(UsernamePasswordConfiguration doc)
        {
            return doc;
        }

        protected override UsernamePasswordConfiguration MapFromResource(UsernamePasswordConfiguration resource)
        {
            return resource;
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