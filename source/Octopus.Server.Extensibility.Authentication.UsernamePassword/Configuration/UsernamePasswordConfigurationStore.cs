using System.Collections.Generic;
using Octopus.Server.Extensibility.Extensions.Infrastructure.Configuration;
using Octopus.Server.Extensibility.HostServices.Authentication;
using Octopus.Server.Extensibility.HostServices.Model;

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

        UsernamePasswordConfiguration MoveSettingsToDatabase()
        {
            var doc = new UsernamePasswordConfiguration
            {
                Id = SingletonId,
                IsEnabled = authenticationConfigurationStore.GetAuthenticationMode() == "UsernamePassword" || authenticationConfigurationStore.GetAuthenticationMode() == "0"
            };

            configurationStore.Create(doc);

            return doc;
        }

        public string ConfigurationSetName => "Usernames and passwords managed by Octopus";
        public IEnumerable<ConfigurationValue> GetConfigurationValues()
        {
            yield return new ConfigurationValue("Octopus.UsernamePassword.IsEnabled", GetIsEnabled().ToString(), GetIsEnabled(), "Is Enabled");
        }
    }
}