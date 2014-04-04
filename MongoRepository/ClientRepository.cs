using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoRepository
{
  public   class ClientRepository:GenericMongoRepository<Client>
    {
        public ClientRepository(MongoDatabase database)
            : base(database, "Client") { }

      //FIND
        public IEnumerable<Client> FindByFirstName(string first_name)
        {
            return base.Find(Query.Matches("FirstName", first_name.ToLower().Trim()));
        }

        public IEnumerable<Client> FindByLastName(string last_name)
        {
            return base.Find(Query.Matches("LastName", last_name.ToLower().Trim()));
        }

        public IEnumerable<Client> FindByFullName(string first_name, string last_name)
        {
            return base.Find(Query.And(Query.Matches("FirstName", first_name.ToLower().Trim()), Query.Matches("LastName", last_name.ToLower().Trim())));
        }

        public IEnumerable<Client> FindByPhone(string phone)
        {
            return base.Find(Query.Matches("PhoneNumber", phone.ToLower().Trim()));
        }

    }
}
