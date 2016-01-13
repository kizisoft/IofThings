namespace IofThings.Data.Common
{
    using System.Linq;
    using Models;

    public interface IMongoDbContext
    {
        IQueryable<T> GetCollection<T>() where T : BaseDbModel;
    }
}