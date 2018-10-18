using System;
using Octopus.Server.Extensibility.Extensions.Infrastructure.Configuration;

namespace Octopus.Server.Extensibility.Authentication.UsernamePassword.Configuration
{
    public class UsernamePasswordConfigurationMapping : IConfigurationDocumentMapper
    {
        public Type GetTypeToMap() => typeof(UsernamePasswordConfiguration);
    }
}