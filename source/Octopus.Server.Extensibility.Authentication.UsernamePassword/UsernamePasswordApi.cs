using System;
using Nancy;
using Octopus.Server.Extensibility.Authentication.UsernamePassword.Configuration;
using Octopus.Server.Extensibility.Authentication.UsernamePassword.Web;
using Octopus.Server.Extensibility.Extensions.Infrastructure.Web.Api;

namespace Octopus.Server.Extensibility.Authentication.UsernamePassword
{
    public class UsernamePasswordApi : NancyModule
    {
        public const string ApiUsersAuthenticate = "/api/users/authenticate/usernamepassword";

        public UsernamePasswordApi(
            Func<WhenEnabledActionInvoker<UserLoginAction, IUsernamePasswordConfigurationStore>> userLoginActionFactory)
        {
            Post[ApiUsersAuthenticate] = o => userLoginActionFactory().Execute(Context, Response);
        }
    }
}