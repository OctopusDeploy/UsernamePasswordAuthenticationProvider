using Autofac;
using Octopus.Server.Extensibility.Authentication.Extensions;
using Octopus.Server.Extensibility.Authentication.UsernamePassword.Configuration;
using Octopus.Server.Extensibility.Authentication.UsernamePassword.UsernamePasswordAuth;
using Octopus.Server.Extensibility.Authentication.UsernamePassword.Web;
using Octopus.Server.Extensibility.Extensions;
using Octopus.Server.Extensibility.Extensions.Infrastructure.Configuration;
using Octopus.Server.Extensibility.HostServices.Web;

namespace Octopus.Server.Extensibility.Authentication.UsernamePassword
{
    [OctopusPlugin("UsernamePassword", "Octopus Deploy")]
    public class UsernamePasswordExtension : IOctopusExtension
    {
        public void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UsernamePasswordHomeLinksContributor>().As<IHomeLinksContributor>().InstancePerDependency();

            builder.RegisterType<UsernamePasswordConfigurationMapping>().As<IConfigurationDocumentMapper>().InstancePerDependency();

            builder.RegisterType<UsernamePasswordConfigurationStore>()
                .As<IUsernamePasswordConfigurationStore>()
                .As<IHasConfigurationSettings>()
                .InstancePerDependency();

            builder.RegisterType<UsernamePasswordConfigureCommands>()
                .As<IContributeToConfigureCommand>()
                .As<IHandleLegacyWebAuthenticationModeConfigurationCommand>()
                .InstancePerDependency();

            builder.RegisterType<UsernamePasswordCredentialValidator>().As<IUsernamePasswordCredentialValidator>().InstancePerDependency();

            builder.RegisterType<UserLoginAction>().AsSelf().InstancePerDependency();

            builder.RegisterType<UsernamePasswordAuthenticationProvider>().As<IAuthenticationProvider>().InstancePerDependency();
        }
    }
}