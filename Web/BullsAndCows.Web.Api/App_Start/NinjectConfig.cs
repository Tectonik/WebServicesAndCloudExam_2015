﻿namespace Teleimot.Web.Api
{
    using System;
    using System.Web;
    using Teleimot.Common.Constants;
    using Teleimot.Common.Providers;
    using Teleimot.Data;
    using Teleimot.Data.Repositories;
    using Ninject;
    using Ninject.Extensions.Conventions;
    using Ninject.Web.Common;
    using Services.Data.Contracts;
    using Services.Data;

    public static class NinjectConfig
    {
        public static Action<IKernel> DependenciesRegistration = kernel =>
        {
            kernel.Bind<ITeleimotDbContext>().To<TeleimotDbContext>();
            //kernel.Bind<IRealEstateService>().To<RealEstateService>();
            kernel.Bind(typeof(IRepository<>)).To(typeof(GenericRepository<>));
        };

        public static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
                
                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        private static void RegisterServices(IKernel kernel)
        {
            DependenciesRegistration(kernel);

            kernel.Bind<IRandomProvider>().To<RandomProvider>();

            kernel.Bind(b => b
                .From(Assemblies.DataServices)
                .SelectAllClasses()
                .BindDefaultInterface());
        }
    }
}
