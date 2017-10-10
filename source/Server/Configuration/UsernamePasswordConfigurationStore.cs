using System;
using System.Linq;
using System.Collections.Generic;
using Octopus.Data.Storage.Configuration;
using Octopus.Node.Extensibility.Authentication.HostServices;
using Octopus.Node.Extensibility.Extensions.Infrastructure.Configuration;

namespace Octopus.Server.Extensibility.Authentication.UsernamePassword.Configuration
{
    public class UsernamePasswordConfigurationStore : IUsernamePasswordConfigurationStore, IHasConfigurationSettings
    {
        public static string SingletonId = "authentication-usernamepassword";

        readonly IConfigurationStore configurationStore;
        readonly IAuthenticationConfigurationStore authenticationConfigurationStore;

        public UsernamePasswordConfigurationStore(
            IConfigurationStore configurationStore,
            IAuthenticationConfigurationStore authenticationConfigurationStore)
        {
            this.configurationStore = configurationStore;
            this.authenticationConfigurationStore = authenticationConfigurationStore;
        }

        public object GetConfiguration()
        {
            return configurationStore.Get<UsernamePasswordConfiguration>(SingletonId);
        }

        public void SetConfiguration(object config)
        {
            configurationStore.Update(config as UsernamePasswordConfiguration);
        }

        public bool GetIsEnabled()
        {
            var doc = configurationStore.Get<UsernamePasswordConfiguration>(SingletonId);
            if (doc != null)
                return doc.IsEnabled;

            doc = MoveSettingsToDatabase();

            return doc.IsEnabled;
        }

        public void SetIsEnabled(bool isEnabled)
        {
            var doc = configurationStore.Get<UsernamePasswordConfiguration>(SingletonId) ?? MoveSettingsToDatabase();
            doc.IsEnabled = isEnabled;
            configurationStore.Update(doc);
        }

        readonly string[] legacyModes = { "UsernamePassword", "0" };

        UsernamePasswordConfiguration MoveSettingsToDatabase()
        {
            var authenticationMode = authenticationConfigurationStore.GetAuthenticationMode();
            var doc = new UsernamePasswordConfiguration("UsernamePassword", "Octopus Deploy")
            {
                IsEnabled = legacyModes.Any(x => x.Equals(authenticationMode.Replace("\"", ""), StringComparison.InvariantCultureIgnoreCase)),
            };

            configurationStore.Create(doc);

            return doc;
        }

        public string Id => SingletonId;

        public string ConfigurationSetName => "Username / Password";

        public virtual string Description => "Usernames and passwords managed by Octopus";

        public Type MetadataResourceType => typeof(UsernamePasswordConfiguration);

        public IEnumerable<ConfigurationValue> GetConfigurationValues()
        {
            yield return new ConfigurationValue("Octopus.UsernamePassword.IsEnabled", GetIsEnabled().ToString(), GetIsEnabled(), "Is Enabled");
        }
    }
}