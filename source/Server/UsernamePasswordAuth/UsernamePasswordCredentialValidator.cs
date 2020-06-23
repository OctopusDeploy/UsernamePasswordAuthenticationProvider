using System.Linq;
using System.Threading;
using Octopus.Data.Model.User;
using Octopus.Data.Storage.User;
using Octopus.Server.Extensibility.Authentication.UsernamePassword.Configuration;
using Octopus.Server.Extensibility.Results;

namespace Octopus.Server.Extensibility.Authentication.UsernamePassword.UsernamePasswordAuth
{
    class UsernamePasswordCredentialValidator : IUsernamePasswordCredentialValidator
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

        public ResultFromExtension<IUser> ValidateCredentials(string username, string password, CancellationToken cancellationToken)
        {
            if (!configurationStore.GetIsEnabled())
            {
                return ResultFromExtension<IUser>.ExtensionDisabled();
            }

            var user = userStore.GetByUsername(username);

            if (user == null)
            {
                var userWithEmailMatchingUsername = userStore.GetByEmailAddress(username);
                if (userWithEmailMatchingUsername.Length == 1)
                {
                    user = userWithEmailMatchingUsername.First();
                }
            }

            if (user != null && user.ValidatePassword(password))
            {
                return ResultFromExtension<IUser>.Success(user);
            }

            return ResultFromExtension<IUser>.Failed("Invalid username or password.");
        }
    }
}