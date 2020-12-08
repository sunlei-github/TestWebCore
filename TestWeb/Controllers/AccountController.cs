using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Common.Utitly;
using WebApi.IApplication.Dto.Account;
using WebApi.IApplication.IServices.IAccount;
using Wlniao;
using Microsoft.Net.Http.Headers;
using System.Net.Http;

namespace WebApi.Controllers
{
    /// <summary>
    /// 登陆/登出
    /// </summary>
    public class AccountController : WebApiBaseController
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

        [HttpGet]
        public async Task<FileStreamResult> Show()
        {


            // https://acg.yanwz.cn/api.php

            Stream stream = null;

            using (HttpClient client=new HttpClient ())
            {
                HttpResponseMessage responseMsg = await client.GetAsync("https://acg.yanwz.cn/api.php");
                if (responseMsg.IsSuccessStatusCode)
                {
                    stream = await responseMsg.Content.ReadAsStreamAsync();
                }
            }

            return base.CreateFileStreamResult(stream, "test.jpg");
        }
    }
}
