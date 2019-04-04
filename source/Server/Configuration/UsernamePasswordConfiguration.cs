using Octopus.Server.Extensibility.Extensions.Infrastructure.Configuration;

namespace Octopus.Server.Extensibility.Authentication.UsernamePassword.Configuration
{
    public class UsernamePasswordConfiguration : ExtensionConfigurationDocument
    {
        public  UsernamePasswordConfiguration() : this("UsernamePassword", "Octopus Deploy")
        {
        }

        public UsernamePasswordConfiguration(string name, string extensionAuthor) : base(name, extensionAuthor, "1.0")
        {
            Id = UsernamePasswordConfigurationStore.SingletonId;
        }
    }
}