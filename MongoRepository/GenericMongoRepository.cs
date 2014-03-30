using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoRepository
{
        public class GenericMongoRepository<T> : IRepository<T> where T : class
        {
            private readonly MongoDatabase _database;

            private readonly MongoCollection<T> _collection;

            public GenericMongoRepository(MongoDatabase database, string collectionName)
            {
                _database = database;

                _collection = _database.GetCollection<T>(collectionName);
            }

            public IEnumerable<T> GetAll()
            {
                return _collection.FindAllAs<T>().AsEnumerable();
            }

            public T GetByID(int id)
            {
                return _collection.FindOneByIdAs<T>(id);
            }

            public void Add(T entity)
            {
                _collection.Insert(entity);
            }

            public void Update(T entity)
            {
                Delete(entity);
                Add(entity);
            }

            public IEnumerable<T> Find(IMongoQuery query)
            {
                MongoCursor cursor = _collection.FindAs<T>(query);
                return cursor.Cast<T>();
            }

            public void Delete(T entity)
            {
                throw new NotImplementedException();
                //var query = Query<T>.EQ(?)
                //_collection.Remove(query);
            }

            public void Delete(IMongoQuery query)
            {
                _collection.Remove(query);
            }
            public void DeleteAll()
            {
                _collection.RemoveAll();
            }

            public void DeleteById(ObjectId Id)
            {
                //var query = Query<T>.EQ(e => e.Id, Id);
                //_collection.Remove(query);

                throw new NotImplementedException();
            }
        }
}
