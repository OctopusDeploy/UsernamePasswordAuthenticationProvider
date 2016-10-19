using Octopus.Data.Model.User;
using Octopus.Data.Storage.User;

namespace Octopus.Server.Extensibility.Authentication.UsernamePassword.UsernamePasswordAuth
{
    public class UsernamePasswordCredentialValidator : IUsernamePasswordCredentialValidator
    {
        readonly IUserStore userStore;

        public UsernamePasswordCredentialValidator(
            IUserStore userStore)
        {
            this.userStore = userStore;
        }

        public IUser ValidateCredentials(string username, string password)
        {
            var user = userStore.GetByUsername(username);

            if (user != null && user.ValidatePassword(password))
            {
                return user;
            }

            return null;
        }
    }
}