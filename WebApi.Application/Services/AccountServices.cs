using System;
using System.Collections.Generic;
using System.Text;
using WebApi.EntityFramework;
using WebApi.IApplication.Dto.Account;
using WebApi.IApplication.IServices.IAccount;

namespace WebApi.Application.Services
{
    public class AccountServices : BaseServices, IAccountServices
    {
        private WebApiDbContext _webApiDbContext = null;

        public AccountServices(WebApiDbContext webApiDbContext)
        {
            _webApiDbContext = webApiDbContext;
        }

        public LoginInOutput LoginIn(LoginInput input)
        {
            return new LoginInOutput
            {
                AccountSatus = Core.Enum.User.AccountSatusEnum.Disabled,
                ErrorMessage = "禁用的用户不能登陆"
            };
        }

        public LoginOutOutput LoginOut(LoginOutInput input)
        {
            return new LoginOutOutput
            {
                Message = "No  Thing"
            };
        }
    }
}
