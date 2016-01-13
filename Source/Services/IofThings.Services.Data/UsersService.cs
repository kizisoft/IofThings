namespace IofThings.Services.Data
{
    using System;
    using System.Threading.Tasks;
    using Contracts;
    using IofThings.Data.Models;

    public class UsersService : IUsersService
    {
        public Task<User> LogIn(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}