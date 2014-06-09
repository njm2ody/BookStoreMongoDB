using MongoDB.Driver;
using MongoRepository;
using System.Collections.Generic;
using System.Linq;
using System;

namespace BookStoreLogicLayer
{
   public class LogicLayer: IBookService
    {
        private MongoDatabase db;

        public BookRepository Books { get; private set; }
        public ClientRepository Clients { get; private set; }
        public OrderRepository Orders { get; private set; }

        public LogicLayer(string db_name)
        {
            try
            {
                var client = new MongoClient();
                var server = client.GetServer();
                this.db = server.GetDatabase(db_name);
            }
            catch (Exception e) { throw e; }

            this.Books = new BookRepository(db);
            this.Clients = new ClientRepository(db);
            this.Orders = new OrderRepository(db);

        }

        public LogicLayer()
        {
            string db_name = "BookStore";

            var client = new MongoClient();
            var server = client.GetServer();
            this.db = server.GetDatabase(db_name);

            this.Books = new BookRepository(db);
            this.Clients = new ClientRepository(db);
            this.Orders = new OrderRepository(db);

        }

        public List<Book> GetAllBooks() 
        {
            List<Book> result = new List<Book>();
            foreach (MongoRepository.Book raw_book in new BookRepository(db).GetAll())
            {
                Book b = new Book(raw_book);
                result.Add(b);
            }

            return result;
        }

        private Dictionary<MongoRepository.Book, int> GetAllBooksDictonary()
        {
            //OrderRepository orders = new OrderRepository(db);
            Dictionary<MongoRepository.Book, int> all_books = new Dictionary<MongoRepository.Book, int>();
            foreach (MongoRepository.Order order in Orders.GetAll())
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
            //OrderRepository orders = new OrderRepository(db);
            Dictionary<string, int> all_authors = new Dictionary<string, int>();
            foreach (MongoRepository.Order order in Orders.GetAll())
            {
                foreach (MongoRepository.Book book in order.Bucket)
                {
                    if (!all_authors.ContainsKey(book.Author)) { all_authors.Add(book.Author, 1); }
                    else { all_authors[book.Author]++; }
                }
            }

            return all_authors;
        }

        public IEnumerable<Book>    GetPopularBook() //возвращает 10 самых популярных книг, отсортированных по убыванию
        {
            var all_books = GetAllBooksDictonary();
            return all_books.OrderByDescending(_ => _.Value).Take(10).Select(_ => Book.FromDataObject(_.Key)); 
          
        }

        public IEnumerable<Book>    GetPopularBook(int count) //возвращает COUNT самых популярных книг, отсортированных по убыванию
        {
            var all_books = GetAllBooksDictonary();
            return all_books.OrderByDescending(_ => _.Value).Take(count).Select(_ => Book.FromDataObject(_.Key));

        }

        public IEnumerable<string>  GetPopularAuthors() 
        {
            var all_authors = GetAllAuthorsDictonary();
            return all_authors.OrderByDescending(_ => _.Value).ToList().Take(10).Select(_ => _.Key);
        }

        public IEnumerable<string>  GetPopularAuthors(int count)
        {
            var all_authors = GetAllAuthorsDictonary();
            return all_authors.OrderByDescending(_ => _.Value).ToList().Take(count).Select(_ => _.Key);
        }

        public List<Order> GetLatestOrders() 
        {
            List<Order> result = new List<Order>();
            foreach ( MongoRepository.Order i in  Orders.GetAll().OrderByDescending(e => e.Date))
            {
                Order o = new Order().FromDataObject(i);
                result.Add(o);
            }
            
            return result;
        }

        public List<Book> GetOrderBucketById(int id) 
        {
            List<Book> result = new List<Book>();

            foreach(MongoRepository.Book b in Orders.GetByID(id).Bucket)
            {
                result.Add(new Book(b));
            }

            return result;
        }

        //public void AddBook() { }

        public List<string> GetAllAuthors() {

            List<string> result = new List<string>();
            foreach (MongoRepository.Book raw_book in new BookRepository(db).GetAll())
            {
                if (!result.Contains(raw_book.Author))
                {
                     result.Add(raw_book.Author);
                }
            }

            return result;
        }
    }
}
