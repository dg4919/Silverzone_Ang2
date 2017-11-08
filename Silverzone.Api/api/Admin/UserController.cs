using Silverzone.Api.ViewModel.Admin;
using Silverzone.Data;
using System;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Web;
using System.Web.Http;

namespace Silverzone.Api.api.Admin
{
    public class UserController : ApiController
    {
        private IAccountRepository accountRepository;
        private IRoleRepository roleRepository;

        [HttpPost]
        public IHttpActionResult Register_user(userViewModel model)
        {
            string _result = string.Empty;

            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());

            var ipAddress = host
                .AddressList
                .FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork);

            if (ModelState.IsValid && roleRepository.role_isActive(model.RoleId))
            {
                foreach (string user in model.userName) {
                    accountRepository.Create(new Entities.User
                    {
                        EmailID = user,
                        Password = accountRepository.GetPasswordHash(model.Password),
                        Browser = HttpContext.Current.Request.Browser.Browser,
                        IPAddress = ipAddress.ToString(),
                        OperatingSystem = Environment.OSVersion.ToString(),
                        Location = RegionInfo.CurrentRegion.DisplayName,
                        CreationDate = accountRepository.get_DateTime(),
                        UpdationDate = accountRepository.get_DateTime(),
                        RoleId = model.RoleId
                    }, false);
                }
                accountRepository.Save();
                _result = "ok";   // autiomatically save data for above
            }
            else
            {
                _result = "invalid_Role";   // autiomatically save data for above
            }

            return Ok(new { result = _result });
        }


        public UserController(
         IAccountRepository _accountRepository,
        IRoleRepository _roleRepository
        )
        {
            accountRepository = _accountRepository;
            roleRepository = _roleRepository;
        }

    }
}
