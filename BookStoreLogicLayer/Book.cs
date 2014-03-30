using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreLogicLayer
{
    public class Book
    {
        private int _Count;
        public int Count
        {
            set { if (value >= 0) { _Count = value; } else { throw new ArgumentException(); } }
            get { return _Count; }
        }

        private double _Price;
        public double Price
        {
            set { if (value >= 0) { _Price = value; } else { throw new ArgumentException(); } }
            get { return _Price; }
        }

        private string _Title;
        public string Title
        {
            set { _Title = value.ToLower(); }
            get { return _Title; }
        }

        private string _Author;
        public string Author
        {
            set { _Author = value.ToLower(); }
            get { return _Author; }
        }

        private string _Publisher;
        public string Publisher
        {
            set { _Publisher = value.ToLower(); }
            get { return _Publisher; }
        }

        public Book() { this.Count = 1; }

        public Book(string title, string author)
        {
            this.Title = title;
            this.Author = author;
            this.Count = 1;
        }

        public Book(string title, string author, string publisher)
        {
            this.Title = title;
            this.Author = author;
            this.Publisher = publisher;
            this.Count = 1;
        }

        public Book(string title, string author, string publisher, int count, double price)
        {
            this.Title = title;
            this.Author = author;
            this.Publisher = publisher;
            this.Count = count;
            this.Price = price;
        }

        private Book(MongoRepository.Book b)
        {
            this.Title = b.Title;
            this.Author = b.Author;
            this.Publisher = b.Publisher;
            this.Count = b.Count;
            this.Price = b.Price;
        }

        public static Book FromDataObject(MongoRepository.Book b){
            return new Book(b);
        }
    }
}
