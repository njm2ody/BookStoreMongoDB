using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace BookStoreLogicLayer
{
    public class Order
    {
        public Client Client { get; set; }

        public ObjectId Id { set; get; }
        private double _TotalPrice;
        public double TotalPrice
        {
            set { if (value >= 0) { _TotalPrice = value; } else{ throw new ArgumentException(); } }
            get { return this._TotalPrice; }
            
        }

        private int _CountBookInBucket;
        public int CountBookInBucket 
        {
            set { if (value >= 0) { this._CountBookInBucket = value; } else{ throw new ArgumentException(); } }
            get { return this._CountBookInBucket; } 
        }

        private DateTime _Date;
        public DateTime Date { set { _Date = value; } get { return _Date; } }

        //public List<Book> Bucket { get; set; }

        public Order()
        {

        }

        private Order(MongoRepository.Order order) 
        {
            double sum = 0;
            foreach (MongoRepository.Book b in order.Bucket) { sum += b.Price; }
            this._TotalPrice = sum;
            this.Id = order.Id;
            this.CountBookInBucket = order.Bucket.Count; 
            this.Client.FromDataObject(order.Client);
        }

        public Order FromDataObject(MongoRepository.Order order){return new Order(order);}

    }
}
