using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization;

namespace Common.IoT.Core.DbContexts
{
    using DataModels;

     sealed class IoTMongoDbContext
         : IDbContext
    {
         private readonly IMongoClient _client;
         private IMongoDatabase _database;
         
         public string Database 
         {
             get
             { 
                 return null; 
             }
             set
             {
                 _database = _client.GetDatabase(value);
             }
         }

        internal IoTMongoDbContext(string url)
        {
            _client = new MongoClient(url);
            _database = _client.GetDatabase("testdb");

        }

        public async Task<int> InsertAsync<T>(T model)
        {
            var collection = _database.GetCollection<BsonDocument>("data.devices");

            try
            {
                BsonDocumentWriter wrtier = new BsonDocumentWriter(new BsonDocument());
                BsonSerializer.Serialize(wrtier, model, null, new BsonSerializationArgs(typeof(T), false, true));

                await collection.InsertOneAsync(wrtier.Document);
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int Insert<T>(T model)
        {
            Task<int> t = InsertAsync<T>(model);
            t.Wait();

            return t.Result;
        }

        public async Task<IEnumerable<T>> FindAllAsync<T>()
        { 
            IMongoCollection<BsonDocument> collection = _database.GetCollection<BsonDocument>("data.devices");

            using (IAsyncCursor<BsonDocument> cursor = await collection.FindAsync<BsonDocument>(new BsonDocument()))
            {
                List<T> results = new List<T>();
                BsonDocumentReader reader = new BsonDocumentReader(new BsonDocument());
                await cursor.ForEachAsync<BsonDocument>((BsonDocument x) =>
                {
                    results.Add((T) BsonSerializer.Deserialize(x, typeof(T)));

                });
                return results;
            }   
        }
        
        public IEnumerable<T> FindAll<T>()
        {
            Task<IEnumerable<T>> t =  FindAllAsync<T>();
            t.Wait();

            return t.Result;
        }

        public async Task<T> FindAsync<T>()
        {
            throw new NotImplementedException();
        }

        public T Find<T>()
        {
            throw new NotImplementedException();
        }

    }
}
