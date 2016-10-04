using Octopus.Server.Extensibility.HostServices.Model;

namespace Octopus.Server.Extensibility.Authentication.UsernamePassword.UsernamePasswordAuth
{
    public interface IUsernamePasswordCredentialValidator
    {
        IUser ValidateCredentials(string username, string password);
    }
}