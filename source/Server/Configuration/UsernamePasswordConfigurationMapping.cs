using System;
using Octopus.Node.Extensibility.Extensions.Infrastructure.Configuration;

namespace Octopus.Server.Extensibility.Authentication.UsernamePassword.Configuration
{
    public class UsernamePasswordConfigurationMapping : IConfigurationDocumentMapper
    {
        public Type GetTypeToMap() => typeof(UsernamePasswordConfiguration);
    }
}