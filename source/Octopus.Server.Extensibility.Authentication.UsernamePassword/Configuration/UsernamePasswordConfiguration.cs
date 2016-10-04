using Octopus.Server.Extensibility.HostServices.Model;

namespace Octopus.Server.Extensibility.Authentication.UsernamePassword.Configuration
{
    public class UsernamePasswordConfiguration : IId
    {
        public string Id { get; set; }

        public bool IsEnabled { get; set; }
    }
}