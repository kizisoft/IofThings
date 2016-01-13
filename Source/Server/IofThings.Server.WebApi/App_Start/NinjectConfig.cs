namespace IofThings.Server.WebApi.App_Start
{
    using System;
    using System.Web;
    using System.Web.Configuration;
    using Data.Common;
    using Data.Common.Repositories;
    using Ninject;
    using Ninject.Extensions.Conventions;
    using Ninject.Web.Common;
    using Services.Common;
    using Services.Common.ObjectFactory;
    using ServerConstants = IofThings.Server.Common.Constants;

    public static class NinjectConfig
    {
        public static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                ObjectFactory.Initialize(kernel);
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
            // "mongodb://localhost:27017/IofThings"
            var mongoDbConnection = WebConfigurationManager.AppSettings["MongoDbConnection"];

            kernel.Bind<IMongoDbContext>().To<MongoDbContext>().InSingletonScope().WithConstructorArgument(mongoDbConnection);
            kernel.Bind(typeof(IRepository<>)).To(typeof(MongoDbRepository<>));

            kernel.Bind(k => k
               .From(ServerConstants.DataServicesAssembly, ServerConstants.CommonServicesAssembly)
               .SelectAllClasses()
               .InheritedFrom<IService>()
               .BindDefaultInterface());
        }
    }
}