using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Core.Entity.SystemLog;
using WebApi.Repository.Repository;
using Microsoft.Extensions.Logging;
using WebApi.Core.Resut;

namespace WebApi.Attribute
{
    /// <summary>
    /// GlobalExpectionFilter
    /// </summary>
    public class GlobalExpectionFilter : IAsyncExceptionFilter
    {
        private const string AJAX_HEADER = "x-requested-with";
        private const string XMLHTTPREQUEST = "XMLHttpRequest";

        private ILogger _logger = null;

        /// <summary>
        /// DI
        /// </summary>
        /// <param name="logger"></param>
        public GlobalExpectionFilter(ILogger<GlobalExpectionFilter> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// 记录异常信息
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task OnExceptionAsync(ExceptionContext context)
        {
            var request = context.HttpContext.Request;
            if (await CheckIsAjaxRequest(request))
            {
                context.Result = new JsonResult(new AjaxErrorResult
                {
                    Title = "后台异常",
                    ExpectionMessage = "请求的数据出错了"
                });
            }
            else
            {
                context.Result = new RedirectResult("/swagger/index.html");
            }

            _logger.LogError(context.Exception.Message);
        }

        /// <summary>
        /// 判断请求是不是ajax请求
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        private async Task<bool> CheckIsAjaxRequest(HttpRequest request)
        {
            return await Task.Run(() =>
            {
                if (request.Headers.ContainsKey(AJAX_HEADER))
                {
                    if (request.Headers[AJAX_HEADER] == XMLHTTPREQUEST)
                    {
                        return true;
                    }

                    return false;
                }

                return false;
            });
        }
    }
}

