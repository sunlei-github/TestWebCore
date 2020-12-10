using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Common.Utitly;
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
        private IConfiguration _configuration = null;

        public AccountServices(IRepositoryServices<DbAccountUser> accountUserRepository, IConfiguration configuration)
        {
            _accountUserRepository = accountUserRepository;
            _configuration = configuration;
        }

        public async Task<LoginInOutput> LoginIn(LoginInput input)
        {
            var entities = await _accountUserRepository.FindAllEntity();
            var loginUser = entities.FirstOrDefault(c => c.UserName == input.UserName);
            if (loginUser == null)
            {
                return new LoginInOutput
                {
                    ErrorMessage = "用户名错误"
                };
            }

            string pwdMd5 = EncryptUtitly.CreateMD5Encrypt(input.UserName);
            if (loginUser.Password != loginUser.Password)
            {
                return new LoginInOutput
                {
                    ErrorMessage = "密码错误"
                };
            }

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
