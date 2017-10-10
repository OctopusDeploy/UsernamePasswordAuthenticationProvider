using System.Collections.Generic;
using Octopus.Data.Storage.Configuration;
using Octopus.Node.Extensibility.Extensions.Infrastructure.Configuration;

namespace Octopus.Server.Extensibility.Authentication.UsernamePassword.Configuration
{
    public class UsernamePasswordConfigurationStore : ExtensionConfigurationStore<UsernamePasswordConfiguration, UsernamePasswordConfiguration>, IUsernamePasswordConfigurationStore
    {
        public static string SingletonId = "authentication-usernamepassword";

        public UsernamePasswordConfigurationStore(
            IConfigurationStore configurationStore) : base(configurationStore)
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
    }
}