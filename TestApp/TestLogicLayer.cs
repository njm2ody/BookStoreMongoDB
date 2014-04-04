using BookStoreLogicLayer;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
   public class TestLogicLayer
    {
        private MongoDatabase db;
        private LogicLayer logic;

        private void getDatabase(string db_name)
        {
            var client = new MongoClient();
            var server = client.GetServer();
            this.db = server.GetDatabase(db_name);
        }

        public void TestPopularBooks() 
        {
            Console.WriteLine("Популярные книги: ");
            foreach (Book b in logic.GetPopularBook(3) ) { Console.WriteLine(b.Author + '\t' + b.Title); }
            Console.WriteLine("---------------------------------------------------------------");
        }

        public void TestPopularAuthors()
        {
            Console.WriteLine("Популярные авторы: ");
            foreach (string i in logic.GetPopularAuthors()) { Console.WriteLine(i); }
            Console.WriteLine("---------------------------------------------------------------");
        }

        public void TestLatestOrders() 
        {
            Console.WriteLine("Последние заказы: ");
            foreach (MongoRepository.Order i in logic.GetLatestOrders()) { Console.WriteLine(i.Date.ToString() + '\t' + i.Client.LastName); }
            Console.WriteLine("---------------------------------------------------------------");

        }

        public TestLogicLayer(string db_name) 
        {
            getDatabase(db_name);
            logic = new LogicLayer(db_name);
        }
    }
}
