namespace IofThings.Data.Common
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Models;
    using MongoDB.Driver;

    public class MongoDbContext : IMongoDbContext
    {
        private MongoClient client;
        private string databaseName;

        public MongoDbContext(string connectionString)
        {
            var pathLength = connectionString.LastIndexOf("/");
            var path = connectionString.Substring(0, pathLength);
            var client = new MongoClient(path);
            if (client == null)
            {
                throw new ArgumentException("Incorect connection string!");
            }

            this.client = client;
            this.databaseName = connectionString.Substring(pathLength + 1);
        }

        public IQueryable<T> GetCollection<T>() where T : BaseDbModel
        {
            var database = this.client.GetDatabase(this.databaseName);
            var tableAttribute = (TableAttribute)typeof(T).GetCustomAttributes(typeof(TableAttribute), true).FirstOrDefault();
            var collection = database.GetCollection<T>(tableAttribute.Name);
            return (IQueryable<T>)collection.AsQueryable();
        }
    }
}