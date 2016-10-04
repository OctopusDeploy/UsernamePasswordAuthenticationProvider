using System.Collections.Generic;
using Octopus.Server.Extensibility.Authentication.UsernamePassword.Configuration;
using Octopus.Server.Extensibility.HostServices.Web;

namespace Octopus.Server.Extensibility.Authentication.UsernamePassword.Web
{
    public class UsernamePasswordHomeLinksContributor : IHomeLinksContributor
    {
        readonly IUsernamePasswordConfigurationStore configurationStore;

        public UsernamePasswordHomeLinksContributor(IUsernamePasswordConfigurationStore configurationStore)
        {
            this.configurationStore = configurationStore;
        }

        public IDictionary<string, string> GetLinksToContribute()
        {
            var linksToContribute = new Dictionary<string, string>();

            if (configurationStore.GetIsEnabled())
            {
                linksToContribute.Add("Authenticate_Octopus", "~" + UsernamePasswordApi.ApiUsersAuthenticate);
            }

            return linksToContribute;
        }
    }
}