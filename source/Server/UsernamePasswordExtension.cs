using Autofac;
using Octopus.Node.Extensibility.Authentication.Extensions;
using Octopus.Node.Extensibility.Extensions;
using Octopus.Node.Extensibility.Extensions.Infrastructure;
using Octopus.Node.Extensibility.Extensions.Infrastructure.Configuration;
using Octopus.Server.Extensibility.Authentication.UsernamePassword.Configuration;
using Octopus.Server.Extensibility.Authentication.UsernamePassword.UsernamePasswordAuth;

namespace Octopus.Server.Extensibility.Authentication.UsernamePassword
{
    [OctopusPlugin("UsernamePassword", "Octopus Deploy")] 
    public class UsernamePasswordExtension : IOctopusExtension
    {
        public void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UsernamePasswordConfigurationMapping>().As<IConfigurationDocumentMapper>().InstancePerDependency();

            builder.RegisterType<DatabaseInitializer>().As<IExecuteWhenDatabaseInitializes>().InstancePerDependency();

            builder.RegisterType<UsernamePasswordConfigurationStore>()
                .As<IUsernamePasswordConfigurationStore>()
                .As<IHasConfigurationSettings>()
                .InstancePerDependency();

            builder.RegisterType<UsernamePasswordConfigureCommands>()
                .As<IContributeToConfigureCommand>()
                .InstancePerDependency();

            builder.RegisterType<UsernamePasswordCredentialValidator>()
                .As<IUsernamePasswordCredentialValidator>()
                .As<IDoesBasicAuthentication>()
                .InstancePerDependency();

            builder.RegisterType<UsernamePasswordAuthenticationProvider>().As<IAuthenticationProvider>().InstancePerDependency();
        }
    }
}