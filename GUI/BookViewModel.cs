using BookStoreLogicLayer;

namespace GUI
{
    public class BookViewModel : ViewModelBase
    {
        private readonly Book _book;

        public BookViewModel(Book book)
        {
            this._book = book;
        }
        public string Title
        {
            get { return Capitalize( _book.Title); }
        }

        public string Author
        {
            get { return Capitalize( _book.Author); }
        }

        public int Count
        {
            get { return _book.Count;}
        }

        public double Price
        {
            get { return _book.Price; }
        }

        public string Publisher
        {
            get { return Capitalize(_book.Publisher); }
        }

        private string Capitalize(string str) 
        {
            return System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str);
        }
    }
}
