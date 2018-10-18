using System.Threading;
using Octopus.Data.Storage.User;
using Octopus.Server.Extensibility.Authentication.Storage.User;
using Octopus.Server.Extensibility.Authentication.UsernamePassword.Configuration;

namespace Octopus.Server.Extensibility.Authentication.UsernamePassword.UsernamePasswordAuth
{
    public class UsernamePasswordCredentialValidator : IUsernamePasswordCredentialValidator
    {
        readonly IUsernamePasswordConfigurationStore configurationStore;
        readonly IUserStore userStore;

        public UsernamePasswordCredentialValidator(
            IUsernamePasswordConfigurationStore configurationStore,
            IUserStore userStore)
        {
            this.configurationStore = configurationStore;
            this.userStore = userStore;
        }

        public int Priority => 50;

        public AuthenticationUserCreateResult ValidateCredentials(string username, string password, CancellationToken cancellationToken)
        {
            if (!configurationStore.GetIsEnabled())
            {
                return new AuthenticationUserCreateResult();
            }

            var user = userStore.GetByUsername(username);

            if (user != null && user.ValidatePassword(password))
            {
                return new AuthenticationUserCreateResult(user);
            }

            return new AuthenticationUserCreateResult("Invalid username or password.");
        }
    }
}