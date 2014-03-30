using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreLogicLayer
{
    class BookStoreLogicLayer: IBookService
    {
        private MongoDatabase db;

        public BookStoreLogicLayer(string db_name)
        {
            var client = new MongoClient();
            var server = client.GetServer();
            db = server.GetDatabase(db_name);

        }

        public IEnumerable<Book> GetPopularBook() //возвращает 10 самых популярных книг, отсортированных по убыванию
        {
            OrderRepository orders = new OrderRepository(db);
            Dictionary<MongoRepository.Book, int> all_books = new Dictionary<MongoRepository.Book,int>(); 
            foreach (MongoRepository.Order order in orders.GetAll())
            {
                foreach (MongoRepository.Book book in order.Bucket)
                {
                    if (!all_books.ContainsKey(book)) { all_books.Add(book, 1); }
                    else { all_books[book]++; }
                }
            }

            return all_books.OrderByDescending(_ => _.Value).Take(10).Select(_ => Book.FromDataObject(_.Key));
          
        }

        public IEnumerable<Book> GetPopularBook(int count) //возвращает COUNT самых популярных книг, отсортированных по убыванию
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

            return all_books.OrderByDescending(_ => _.Value).Take(count).Select(_ => Book.FromDataObject(_.Key));

        }
    }
}
