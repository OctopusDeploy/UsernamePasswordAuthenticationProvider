using System.Collections.Generic;
using Octopus.Node.Extensibility.Extensions.Infrastructure.Configuration;
using Octopus.Node.Extensibility.HostServices.Mapping;

namespace Octopus.Server.Extensibility.Authentication.UsernamePassword.Configuration
{
    public class UsernamePasswordConfigurationSettings : ExtensionConfigurationSettings<UsernamePasswordConfiguration, UsernamePasswordConfigurationResource, IUsernamePasswordConfigurationStore>, IUsernamePasswordConfigurationSettings
    {

        public UsernamePasswordConfigurationSettings(
            IUsernamePasswordConfigurationStore configurationStore,
            IResourceMappingFactory factory) : base(configurationStore, factory)
        {
        }

        public override string Id => UsernamePasswordConfigurationStore.SingletonId;

        public override string ConfigurationSetName => "Username / Password";

        public override string Description => "Usernames and passwords managed by Octopus";

        public override IEnumerable<ConfigurationValue> GetConfigurationValues()
        {
            yield return new ConfigurationValue("Octopus.UsernamePassword.IsEnabled", ConfigurationDocumentStore.GetIsEnabled().ToString(), ConfigurationDocumentStore.GetIsEnabled(), "Is Enabled");
        }

        public override IEnumerable<IResourceMapping> GetMappings()
        {
            return new [] { ResourceMappingFactory
                .Create<UsernamePasswordConfigurationResource, UsernamePasswordConfiguration>() };
        }
    }
}