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
            TestMongoRepository test = new TestMongoRepository("BookStore");

            Console.ReadKey();
        }
    }
}
