using Autofac;
using Autofac.Core;
using Autofac.Core.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Moudle
{
    public class AutofacMoudle : Module
    {
        /// <summary>
        /// IOC  服务统一在这里进行注入
        /// </summary>
        /// <param name="builder"></param>
        protected override void Load(ContainerBuilder builder)
        {

        }
    }
}
