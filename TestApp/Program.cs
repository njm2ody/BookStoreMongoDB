using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoRepository;
using MongoDB.Bson;
using MongoDB.Driver;
namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {

            MongoDatabase db = getDatabase("BookStore");

            BookRepository br = new BookRepository(db);
            ClientRepository cr = new ClientRepository(db);
            OrderRepository or = new OrderRepository(db);

            br.DeleteAll();
            or.DeleteAll();
            cr.DeleteAll();



           Book book1 = new Book("Сирены Титана", "Курт Воннегут", "Эксмо", 1, 100);
           Book book2 = new Book("Крестовый поход детей", "Курт Воннегут", "Эксмо", 1, 200);

           br.Add(book1); br.Add(new Book ("Страх и ненависть в Лас-Вегасе", "Хантер Томпсон", "Эксмо", 1, 150.50));
           br.Add(book2); 

           Client client = new Client("Иван", "Иванов", "+12345678");
           List<Book> bucket = new List<Book>(); bucket.Add(book1); bucket.Add(book2);
          
           Order new_order = new Order(client, bucket);
           or.Add(new_order);

           Console.Write(new_order.Client.LastName + '\t' + new_order.Client.PhoneNumber + '\t' + new_order.TotalPrice);
           Console.WriteLine();

           Console.WriteLine("Все книги: ");
           foreach (Book b in br.GetAll()) {  Console.WriteLine(b.Author + '\t' + b.Title); }

           Console.WriteLine("Список ордеров: ");
           foreach (Order order in or.GetAll())  { Console.WriteLine(order.Client.LastName + '\t' + order.Client.PhoneNumber + '\t' + order.TotalPrice);}

            Console.WriteLine("Проверка поиска: ");
            foreach (Book b in br.FindByAuthor("воннегут"))     //проверка регистра 
           {
               Console.WriteLine(b.Author + '\t' + b.Title + '\t' + b.Publisher + '\t' + b.Count + '\t' + b.Price);
           }
            //foreach (Book b in br.FindByPrice(105, 300))
            //{
            //    Console.WriteLine(b.Author + '\t' + b.Title + '\t' +  b.Publisher + '\t' +  b.Count + '\t' + b.Price);
            //}

           //var orders = or.GetAll();
           //Console.WriteLine(orders.Cast<Order>().Count());

            

            Console.ReadKey();
        }

        static MongoDatabase getDatabase(string db_name)
        {
            var client = new MongoClient();
            var server = client.GetServer();
            return server.GetDatabase(db_name);
        }
    }
}
