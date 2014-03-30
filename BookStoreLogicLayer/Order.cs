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
            get { return _CountBookInBucket; } 
            set { if (value >= 0) { this._CountBookInBucket = value; } else{ throw new ArgumentException(); } } 
        }

        private Order(MongoRepository.Order order) 
        {
            double sum = 0;
            foreach (MongoRepository.Book b in order.Bucket)
            { sum += b.Price; }
            this._TotalPrice = sum;
            this.Client = order.Client;
        }

    }
}
