using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoRepository
{
    public class OrderRepository: GenericMongoRepository<Order>
    {
        public OrderRepository(MongoDatabase database)
            : base(database, "Order") { }


        /*public IEnumerable<Order> FindByClient(string first_name)
        {
            return base.Find(Query.EQ("FirstName", first_name));
        }*/
    }
}
