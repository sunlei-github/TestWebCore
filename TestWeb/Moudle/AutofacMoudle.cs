using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using WebApi.IApplication.IServices.IAccount;
using WebApi.IApplication.IServices.IResource;
using WebApi.Application.Services;
using WebApi.Application.Resource;
using WebApi.EntityFramework;
using Microsoft.EntityFrameworkCore;
using WebApi.Application.HangfireTask;
using WebApi.IApplication.IServices.IHangefire;
using WebApi.Repository.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

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

            Assembly assembly = Assembly.Load("WebApi.Application");
            Assembly iAssembly = Assembly.Load("WebApi.IApplication");

            containerBuilder.RegisterType<WebApiDbContext>().As<DbContext>().InstancePerLifetimeScope();
            containerBuilder.RegisterGeneric(typeof(RepositoryServices<>)).As(typeof(IRepositoryServices<>)).InstancePerLifetimeScope();
            //containerBuilder.RegisterType(typeof(ConfigurationRoot)).As(typeof(IConfiguration)).InstancePerLifetimeScope();
            //containerBuilder.RegisterGeneric(typeof(ILogger<>)).As(typeof(Logger<>)).InstancePerLifetimeScope();

            #region 动态注入
            //List<Type> types = new List<Type>();
            //var realiIntstalls = assembly.GetTypes().Where(c => c.IsClass && c.IsPublic && !c.IsAbstract).ToList();
            //foreach (var realInstall in realiIntstalls)
            //{
            //    Type iRealInstall = realInstall.GetInterfaces().Where(c => c.Assembly.FullName.StartsWith("WebApi.IApplication")).FirstOrDefault();
            //    if (iRealInstall == null)
            //    {
            //        continue;
            //    }

            //     containerBuilder.RegisterType(realInstall).As(iRealInstall).InstancePerLifetimeScope();
            //    containerBuilder.RegisterType<>().As(iRealInstall).InstancePerLifetimeScope();
            //}

            //程序集注入
            //containerBuilder.RegisterAssemblyTypes(assembly, iAssembly).AsImplementedInterfaces().PropertiesAutowired();

            //containerBuilder.RegisterType(typeof(AccountServices)).As(typeof(IAccountServices)).InstancePerLifetimeScope();
            //containerBuilder.RegisterType(typeof(MusicServices)).As(typeof(IMusicServices)).InstancePerLifetimeScope();
            //containerBuilder.RegisterType(typeof(ImageServices)).As(typeof(IImageServices)).InstancePerLifetimeScope();
            //containerBuilder.RegisterType(typeof(VedioServices)).As(typeof(IVedioServices)).InstancePerLifetimeScope();
            //containerBuilder.RegisterType(typeof(HangefireServices)).As(typeof(IHangefireServices)).InstancePerLifetimeScope();

            //var dd = containerBuilder.Build();
            //var cc = dd.Resolve<IMusicServices>();
            //var c3c = dd.Resolve<IImageServices>();
            //var cac = dd.Resolve<IVedioServices>();
            //var cdc = dd.Resolve<IHangefireServices>(); 
            #endregion


            containerBuilder.RegisterType<AccountServices>().As<IAccountServices>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<MusicServices>().As<IMusicServices>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<ImageServices>().As<IImageServices>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<VedioServices>().As<IVedioServices>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<HangefireServices>().As<IHangefireServices>().InstancePerLifetimeScope();

        }
    }
}
