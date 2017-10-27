using Octopus.Data.Model;
using Octopus.Data.Resources;

namespace Octopus.Server.Extensibility.Authentication.UsernamePassword.Configuration
{
    public class UsernamePasswordConfigurationResource : IResource
    {
        public string Id { get; set; }

        public LinkCollection Links { get; set; }
    }
}