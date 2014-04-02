using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreLogicLayer
{
    class Order
    {
        public Client Client { get; set; }

        private double _TotalPrice;
        public double TotalPrice
        {
            set { if (value >= 0) { _TotalPrice = value; } else{ throw new ArgumentException(); } }
            get { return this._TotalPrice; }
            
        }

        private int _CountBookInBucket;
        public int CountBookInBucket {
            set { if (value >= 0) { this._CountBookInBucket = value; } else{ throw new ArgumentException(); }
             get { return _CountBookInBucket; } } 
        }

        private DateTime _Date;
        public DateTime Date { set { _Date = value; } get { return _Date; } }

        private Order(MongoRepository.Order order) 
        {
            double sum = 0;
            foreach (MongoRepository.Book b in order.Bucket) { sum += b.Price; }
            this._TotalPrice = sum;
            this.CountBookInBucket = order.Bucket.Count; 
            this.Client.FromDataObject(order.Client);
        }

        public Order FromDataObject(MongoRepository.Order order){return new Order(order);}

    }
}
