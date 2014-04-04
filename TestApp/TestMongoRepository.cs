using MongoDB.Driver;
using MongoRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    public class TestMongoRepository
    {
        private MongoDatabase db;
        private BookRepository br;
        private ClientRepository cr;
        private OrderRepository or;

        private void getDatabase(string db_name)
        {
            var client = new MongoClient();
            var server = client.GetServer();
            this.db = server.GetDatabase(db_name);
        }

        public void Clear() 
        {
            br.DeleteAll();
            or.DeleteAll();
            cr.DeleteAll();
        }

        public void FillBookRepository() 
        {
           br.Add(new Book("Сирены Титана", "Курт Воннегут", "Эксмо", 1, 100)); 
           br.Add(new Book ("Страх и ненависть в Лас-Вегасе", "Хантер Томпсон", "Эксмо", 1, 150.50));
           br.Add(new Book("Крестовый поход детей", "Курт Воннегут", "Эксмо", 1, 200));
           br.Add(new Book("Сборник рассказов", "Антон Чехов", "Росмен", 1, 200));
           br.Add(new Book("день Опричника ", "владимир сорокин", "РОсмен", 1, 100)); 
        }

        public void FillClientRepository() 
        {
            cr.Add(new Client("Иван", "Иванов",         "+123456789"));
            cr.Add(new Client("Петя", "Петров",         "+876543219"));
            cr.Add(new Client("Вася", "Пупкин",         "+856749845"));
            cr.Add(new Client("Вася", "Василевский",    "+867657845"));
        }

        public void FillOrderRepository() 
        {
            Client client = new Client();

            client = cr.GetAll().First();

            or.Add(new Order (client, 
                   new List<Book> (br.FindByAuthor("Курт Воннегут"))));

            client = cr.FindByFirstName("Вася").First();
            or.Add(new Order(client,
                   new List<Book>(br.FindByAuthor("Антон Чехов"))));
        }

        public void ViewBookRepository() 
        {
            Console.WriteLine("Все книги: ");
            foreach (Book b in br.GetAll()) { Console.WriteLine(b.Author + '\t' + b.Title); }
            Console.WriteLine("---------------------------------------------------------------");
        }

        public void ViewClientRepository()
        {
            Console.WriteLine("Список клиентов: ");
            foreach (Client cli in cr.GetAll()) { Console.WriteLine(cli.FirstName  + '\t' + cli.LastName  + '\t' +  cli.PhoneNumber ); }
        }
        public void ViewOrderRepository() 
        {
            Console.WriteLine("Список ордеров: ");
            foreach (Order order in or.GetAll()) { Console.WriteLine(order.Client.LastName + '\t' + order.Client.PhoneNumber + '\t' + order.Bucket.First().Title); }
            Console.WriteLine("---------------------------------------------------------------");
        }

        public void Find(string query) 
        {
            Console.WriteLine("Поиск по книгам, запрос - '" + query + "' ");
            foreach (Book b in br.FindByAuthor(query)) { Console.WriteLine(b.Author + '\t' + b.Title); }
            Console.WriteLine("---------------------------------------------------------------");
        }

        public void Fill()
        {
            FillBookRepository();
            FillClientRepository();
            FillOrderRepository();
        }

        public void View()
        {
            ViewBookRepository();
            ViewClientRepository();
            ViewOrderRepository();
        }
        public TestMongoRepository(string db_name) 
        {
            getDatabase(db_name);

            this.cr = new ClientRepository(db);
            this.br = new BookRepository(db);
            this.or = new OrderRepository(db);

            Fill();
            //View();
            //Clear();
        }
        
   }
}
