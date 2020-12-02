using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Core.Entity.User;
using WebApi.EntityFramework;
using WebApi.IApplication.Dto.Account;
using WebApi.IApplication.IServices.IAccount;
using WebApi.Repository.Repository;

namespace WebApi.Application.Services
{
    public class AccountServices : BaseServices, IAccountServices
    {
        private IRepositoryServices<DbAccountUser>  _accountUserRepository = null;

        public AccountServices(IRepositoryServices<DbAccountUser> accountUserRepository)
        {
            _accountUserRepository = accountUserRepository;
        }

        public LoginInOutput LoginIn(LoginInput input)
        {
            var dd = _accountUserRepository.FindSingleEntity(1);


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
