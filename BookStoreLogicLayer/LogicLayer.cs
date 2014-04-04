using MongoDB.Driver;
using MongoRepository;
using System.Collections.Generic;
using System.Linq;

namespace BookStoreLogicLayer
{
   public class LogicLayer: IBookService
    {
        private MongoDatabase db;

        public LogicLayer(string db_name)
        {
            var client = new MongoClient();
            var server = client.GetServer();
            this.db = server.GetDatabase(db_name);
        }

        private Dictionary<MongoRepository.Book, int> GetAllBooksDictonary()
        {
            OrderRepository orders = new OrderRepository(db);
            Dictionary<MongoRepository.Book, int> all_books = new Dictionary<MongoRepository.Book, int>();
            foreach (MongoRepository.Order order in orders.GetAll())
            {
                foreach (MongoRepository.Book book in order.Bucket)
                {
                    if (!all_books.ContainsKey(book)) { all_books.Add(book, 1); }
                    else { all_books[book]++; }
                }
            }

            return all_books;
        }

        private Dictionary<string, int> GetAllAuthorsDictonary()
        {
            OrderRepository orders = new OrderRepository(db);
            Dictionary<string, int> all_authors = new Dictionary<string, int>();
            foreach (MongoRepository.Order order in orders.GetAll())
            {
                foreach (MongoRepository.Book book in order.Bucket)
                {
                    if (!all_authors.ContainsKey(book.Author)) { all_authors.Add(book.Author, 1); }
                    else { all_authors[book.Author]++; }
                }
            }

            return all_authors;
        }

        public IEnumerable<Book> GetPopularBook() //возвращает 10 самых популярных книг, отсортированных по убыванию
        {
            var all_books = GetAllBooksDictonary();
            return all_books.OrderByDescending(_ => _.Value).Take(10).Select(_ => Book.FromDataObject(_.Key)); //черная магия авторства Денисова
          
        }

        public IEnumerable<Book> GetPopularBook(int count) //возвращает COUNT самых популярных книг, отсортированных по убыванию
        {
            var all_books = GetAllBooksDictonary();
            return all_books.OrderByDescending(_ => _.Value).Take(count).Select(_ => Book.FromDataObject(_.Key));

        }

        public IEnumerable<string> GetPopularAuthors() 
        {
            var all_authors = GetAllAuthorsDictonary();
            return all_authors.OrderByDescending(_ => _.Value).ToList().Take(10).Select(_ => _.Key);
        }

        public IEnumerable<string> GetPopularAuthors(int count)
        {
            var all_authors = GetAllAuthorsDictonary();
            return all_authors.OrderByDescending(_ => _.Value).ToList().Take(count).Select(_ => _.Key);
        }
    }
}
