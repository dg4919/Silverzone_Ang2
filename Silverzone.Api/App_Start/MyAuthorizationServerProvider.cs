using Microsoft.Owin.Security.OAuth;
using Silverzone.Data;
using Silverzone.Entities;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Silverzone.Api
{
    // Code for genrating Token after verify user from login()
    public class MyAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            var verification_type = context.Parameters.Where(f => f.Key == "verificationMode")
                                                      .Select(f => f.Value)
                                                      .SingleOrDefault()[0];

            context.OwinContext.Set<string>("verificationMode", verification_type);

            context.Validated();
            return Task.FromResult<object>(null);
        }

        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            using (IAccountRepository accountRepository = new AccountRepository(new SilverzoneContext()))
            {
                var userName = context.UserName;
                var password = context.Password;

                var value = context.OwinContext.Get<string>("verificationMode");
                var verificationMode = (verificationMode)Enum.Parse(typeof(verificationMode), value);

                var _user = accountRepository.check_User(userName, verificationMode);
                var role = _user.Role.Name;   // get values using navigation property

                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new Claim(ClaimTypes.Role, role));
                identity.AddClaim(new Claim(ClaimTypes.Name, _user.Id.ToString()));

                context.Validated(identity);
            }
            return Task.FromResult<object>(null);
        }

    }
}