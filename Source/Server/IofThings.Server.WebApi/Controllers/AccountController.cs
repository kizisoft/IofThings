namespace IofThings.Server.WebApi.Controllers
{
    using System.Net;
    using System.Web.Http;
    using Data.Common.Repositories;
    using Data.Models;

    public class AccountController : ApiController
    {
        private readonly IRepository<User> users;

        public AccountController(IRepository<User> users)
        {
            this.users = users;
        }

        public IHttpActionResult Get()
        {
            return this.Content(HttpStatusCode.Unauthorized, "Test!!!");
        }
    }
}