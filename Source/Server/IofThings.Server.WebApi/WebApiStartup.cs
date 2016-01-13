namespace IofThings.Server.WebApi
{
    using System.Web.Http;
    using App_Start;
    using Ninject.Web.Common.OwinHost;
    using Ninject.Web.WebApi.OwinHost;
    using Owin;

    public class WebApiStartup
    {
        public static void StartWebApi(IAppBuilder appBuilder)
        {
            // Configure Web API for self-host. 
            HttpConfiguration config = new HttpConfiguration();

            WebApiConfig.Register(config);

            config.EnsureInitialized();

            appBuilder.UseNinjectMiddleware(NinjectConfig.CreateKernel).UseNinjectWebApi(config);

            appBuilder.UseWebApi(config);
        }
    }
}