using System;
using System.Collections.Generic;
using System.Text;
using WebApi.IApplication.Dto.Account;

namespace WebApi.IApplication.IServices.IAccount
{
    public interface IAccountServices
    {
        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="loginInput"></param>
        /// <returns></returns>

        LoginInOutput LoginIn(LoginInput input);

        /// <summary>
        /// 登出
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        LoginOutOutput LoginOut(LoginOutInput input);
    }
}
