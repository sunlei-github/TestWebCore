using Autofac;
using Autofac.Core;
using Autofac.Core.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;
using WebApi.IApplication.IServices.IAccount;
using WebApi.IApplication.IServices.IResource;
using WebApi.Application.Services;
using WebApi.Repository.Repository;
using WebApi.Application.Resource;
using WebApi.Controllers;
using WebApi.EntityFramework;
using Microsoft.EntityFrameworkCore;
using WebApi.Application.HangfireTask;
using WebApi.IApplication.IServices.IHangefire;

namespace WebApi.Moudle
{
    public class AutofacMoudle : Autofac.Module
    {
        /// <summary>
        /// IOC  服务统一在这里进行注入
        /// </summary>
        /// <param name="containerBuilder"></param>
        protected override void Load(ContainerBuilder containerBuilder)
        {
            var controllersTypesInAssembly = typeof(Startup).Assembly.GetExportedTypes()
                  .Where(type => typeof(Microsoft.AspNetCore.Mvc.ControllerBase).IsAssignableFrom(type)).ToArray();
            containerBuilder.RegisterTypes(controllersTypesInAssembly).PropertiesAutowired(); //允许控制器内属性注入 

            containerBuilder.RegisterType<WebApiDbContext>().As<DbContext>().InstancePerLifetimeScope();
            containerBuilder.RegisterGeneric(typeof(RepositoryServices<>)).As(typeof(IRepositoryServices<>)).InstancePerLifetimeScope();
            containerBuilder.RegisterType<AccountServices>().As<IAccountServices>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<MusicServices>().As<IMusicServices>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<ImageServices>().As<IImageServices>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<VedioServices>().As<IVedioServices>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<HangefireServices>().As<IHangefireServices>().InstancePerLifetimeScope();

        }
    }
}
