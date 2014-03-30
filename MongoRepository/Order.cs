using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoRepository
{
    public class Order
    {
        [BsonId]
        public ObjectId Id { get; set; }

        public Client Client { get; set; }

        private List<Book> _Bucket;
        public List<Book> Bucket
            {
                set{}

                get { return _Bucket; }
            }

        public double TotalPrice {set; get;}

        public Order() { this.Bucket = new List<Book>(); }
        public Order(Client client, List<Book> list_of_book) { this.Client = client; this.Bucket = list_of_book; }

        //public void setBucket(List<Book> lst) 
        //{
        //    double sum = 0;
        //    foreach (Book i in lst) 
        //    {
        //        sum += i.Price;
        //    }

        //    TotalPrice = sum;
        //}
    }
}
