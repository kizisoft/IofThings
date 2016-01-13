[assembly: Microsoft.Owin.OwinStartup(typeof(IofThings.Client.Angular.Startup))]

namespace IofThings.Client.Angular
{
    using Owin;
    using Server.Infrastructure.Auth;
    using Server.WebApi;

    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            AuthStartup.ConfigureAuth(appBuilder);
            WebApiStartup.StartWebApi(appBuilder);
        }
    }
}