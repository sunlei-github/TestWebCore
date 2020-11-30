using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.IApplication.Dto.Account;
using WebApi.IApplication.IServices.IAccount;

namespace WebApi.Controllers
{
    /// <summary>
    /// 登陆/登出
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IAccountServices _accountServices = null;

        /// <summary>
        /// DI
        /// </summary>
        /// <param name="accountServices"></param>
        public AccountController(IAccountServices accountServices)
        {
            _accountServices = accountServices;
        }

        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public LoginInOutput LoginIn(LoginInput input)
        {
            var result = _accountServices.LoginIn(input);

            return result;
        }

        /// <summary>
        /// 登出
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public LoginOutOutput LoginOut(LoginOutInput input)
        {
            var result = _accountServices.LoginOut(input);

            return result;
        }
    }
}
