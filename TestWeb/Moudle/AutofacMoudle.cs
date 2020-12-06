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
            #region 指定控制器的服务由autofac进行注册
            var assembly = this.GetType().GetTypeInfo().Assembly;
            var manager = new ApplicationPartManager();
            manager.ApplicationParts.Add(new AssemblyPart(assembly));
            manager.FeatureProviders.Add(new ControllerFeatureProvider());
            var feature = new ControllerFeature();
            manager.PopulateFeature(feature);
            containerBuilder.RegisterType<ApplicationPartManager>().AsSelf().SingleInstance();
            containerBuilder.RegisterTypes(feature.Controllers.Select(ti => ti.AsType()).ToArray()).PropertiesAutowired();
            #endregion

            containerBuilder.RegisterType<WebApiDbContext>().As<DbContext>().InstancePerLifetimeScope();
            containerBuilder.RegisterGeneric(typeof(RepositoryServices<>)).As(typeof(IRepositoryServices<>)).InstancePerLifetimeScope();
            containerBuilder.RegisterType<AccountServices>().As<IAccountServices>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<MusicServices>().As<IMusicServices>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<ImageServices>().As<IImageServices>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<VedioServices>().As<IVedioServices>().InstancePerLifetimeScope();

            var testBuilder = containerBuilder.Build();

            //var a5 = testBuilder.Resolve(typeof(IRepositoryServices<>));
            var a1 = testBuilder.Resolve<IAccountServices>();
            var a2 = testBuilder.Resolve<IMusicServices>();
            var a3 = testBuilder.Resolve<IImageServices>();
            var a4 = testBuilder.Resolve<IVedioServices>();
            var a6 = testBuilder.Resolve<AccountController>();
        }
    }
}
