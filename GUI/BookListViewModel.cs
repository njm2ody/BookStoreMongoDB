using System.Collections.Generic;
using BookStoreLogicLayer;

namespace GUI
{
   public class BookListViewModel
    {
        private List<BookViewModel> _books;

        public BookListViewModel(List<BookViewModel> books)
        {
            this._books = books;
        }

        //public BookListViewModel(List<Book> books)
        //{
        //    foreach(Book b in books)
        //    {
        //        BookViewModel k = new BookViewModel(b);
        //        _books.Add(k);
        //    }
        //}

        public List<BookViewModel> Books
        {
            get { return this._books; }
            set { this._books = value; }
        }
    }
}
