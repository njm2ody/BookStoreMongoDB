using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoRepository
{

    public class BookRepository : GenericMongoRepository<Book>
    {
        public BookRepository(MongoDatabase database)
            : base(database, "Book") { }

        public IEnumerable<Book> FindByPrice(double price)
        {
            return base.Find(Query.EQ("Price", price));
        }

        public IEnumerable<Book> FindByPrice(double min_price, double max_price)
        {
            return base.Find(Query.And(Query.GT("Price", min_price), Query.LTE("Price", max_price)));
        }

        public IEnumerable<Book> FindByTitle(string title)
        {
            return base.Find(Query.EQ("Title", title.ToLower()));
        }

        public IEnumerable<Book> FindByAuthor(string author)
        {
            return base.Find(Query.EQ("Author", author.ToLower().Trim()));
        }

        public IEnumerable<Book> FindByPublisher(string publisher)
        {
            return base.Find(Query.EQ("Publisher", publisher.ToLower().Trim()));
        }

        public IEnumerable<Book> FindByCount(int count)
        {
            return base.Find(Query.EQ("Count", count));
        }

        public IEnumerable<Book> FindByCount(int min_count, int max_count)
        {
            return base.Find(Query.And(Query.GT("Count", min_count), Query.LTE("Count", max_count)));
        }
    }
    

    
    
}
