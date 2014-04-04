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
            Console.WriteLine("Data Layer tests start..");
            TestMongoRepository test = new TestMongoRepository("BookStore");
            Console.WriteLine("all good.");
            //TODO сделать  нормальные юнит тесты, а не это безобразие



            Console.ReadKey();
        }
    }
}
