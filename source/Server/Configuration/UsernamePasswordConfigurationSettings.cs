using System.Collections.Generic;
using Octopus.Server.Extensibility.Extensions.Infrastructure.Configuration;
using Octopus.Server.Extensibility.HostServices.Mapping;

namespace Octopus.Server.Extensibility.Authentication.UsernamePassword.Configuration
{
    public class UsernamePasswordConfigurationSettings : ExtensionConfigurationSettings<UsernamePasswordConfiguration, UsernamePasswordConfigurationResource, IUsernamePasswordConfigurationStore>, IUsernamePasswordConfigurationSettings
    {

        public UsernamePasswordConfigurationSettings(
            IUsernamePasswordConfigurationStore configurationStore) : base(configurationStore)
        {
        }

        public override string Id => UsernamePasswordConfigurationStore.SingletonId;

        public override string ConfigurationSetName => "Username / Password";

        public override string Description => "Usernames and passwords managed by Octopus";

        public override IEnumerable<ConfigurationValue> GetConfigurationValues()
        {
            yield return new ConfigurationValue("Octopus.UsernamePassword.IsEnabled", ConfigurationDocumentStore.GetIsEnabled().ToString(), ConfigurationDocumentStore.GetIsEnabled(), "Is Enabled");
        }

        public override void BuildMappings(IResourceMappingsBuilder builder)
        {
            builder.Map<UsernamePasswordConfigurationResource, UsernamePasswordConfiguration>();
        }
    }
}