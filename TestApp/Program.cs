using System;
namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string db_name = "BookStore";

            Console.WriteLine("Data Layer tests start..");
            TestMongoRepository test = new TestMongoRepository(db_name);
            test.View();
            test.Find("чехов");
            Console.WriteLine("All good.");
            //TODO сделать  нормальные юнит тесты, а не это безобразие
            Console.WriteLine("Logic Layer tests start..");
            TestLogicLayer test_logic = new TestLogicLayer(db_name);
            test_logic.TestPopularBooks();
            test_logic.TestPopularAuthors();
            Console.WriteLine("All good.");


            test.Clear();
            Console.ReadKey();
        }
    }
}
