using System;
using System.Linq;
using Octopus.Configuration;
using Octopus.Data.Storage.Configuration;
using Octopus.Server.Extensibility.Extensions.Infrastructure;

namespace Octopus.Server.Extensibility.Authentication.UsernamePassword.Configuration
{
    class DatabaseInitializer : ExecuteWhenDatabaseInitializes
    {
        readonly IConfigurationStore configurationStore;
        readonly IKeyValueStore settings;

        bool cleanupRequired = false;

        public DatabaseInitializer(IConfigurationStore configurationStore, IKeyValueStore settings)
        {
            this.configurationStore = configurationStore;
            this.settings = settings;
        }

        readonly string[] legacyModes = { "UsernamePassword", "0" };

        public override void Execute()
        {
            var doc = configurationStore.Get<UsernamePasswordConfiguration>(UsernamePasswordConfigurationStore.SingletonId);
            if (doc != null)
            {
                // TODO: to cover a dev team edge case during 4.0 Alpha. Can be removed before final release
                if (doc.ConfigurationSchemaVersion != "1.0")
                {
                    doc.ConfigurationSchemaVersion = "1.0";
                    configurationStore.Update(doc);
                }
                return;
            }

            var authenticationMode = settings.Get("Octopus.WebPortal.AuthenticationMode", string.Empty);
            doc = new UsernamePasswordConfiguration()
            {
                IsEnabled = legacyModes.Any(x => x.Equals(authenticationMode.Replace("\"", ""), StringComparison.OrdinalIgnoreCase)),
            };

            configurationStore.Create(doc);

            cleanupRequired = true;
        }

        public override void PostExecute()
        {
            if (cleanupRequired == false)
                return;

            settings.Remove("Octopus.WebPortal.AuthenticationMode");
            settings.Save();
        }
    }
}