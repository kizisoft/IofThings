namespace IofThings.Data.Common.Repositories
{
    using System;
    using System.Linq;
    using Models;

    public class MongoDbRepository<T> : IRepository<T> where T : BaseDbModel
    {
        private readonly IQueryable<T> collection;

        public MongoDbRepository(IMongoDbContext context)
        {
            this.collection = context.GetCollection<T>();
        }

        public void Add(T entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> All()
        {
            throw new NotImplementedException();
        }

        public void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public T GetById(object id)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}