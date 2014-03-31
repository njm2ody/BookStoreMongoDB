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

        private Client _Client;
        public Client Client { get { return _Client; } set { _Client = value;} }

        private List<Book> _Bucket;
        public List<Book> Bucket
            {
                set { _Bucket = value; }

                get { return _Bucket; }
            }

       // public double TotalPrice {set; get;}
        private DateTime _Date;
        public DateTime Date { set { _Date = value; } get { return _Date; } }

        public Order() { this.Bucket = new List<Book>(); this.Date = new DateTime(); }

        public Order(Client client, List<Book> list_of_book) 
        { 
          this.Client = client; 
          this.Bucket = list_of_book;
          this.Date = new DateTime();
        }

        public Order(Client client, List<Book> list_of_book, DateTime date)
        {
            this.Client = client;
            this.Bucket = list_of_book;
            this.Date =   date;
        }
       
    }
}
