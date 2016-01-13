namespace IofThings.Services.Data.Contracts
{
    using System.Threading.Tasks;
    using Common;
    using IofThings.Data.Models;

    public interface IUsersService : IService
    {
        Task<User> LogIn(string username, string password);
    }
}