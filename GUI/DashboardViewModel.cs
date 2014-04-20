using System.Collections.Generic;
using BookStoreLogicLayer;

namespace GUI
{
    public class DashboardViewModel
    {
        private readonly LogicLayer _logic;
        private static List<BookViewModel> _books = new List<BookViewModel>();
            //{
            //    new BookViewModel(
            //        new Book
            //        {
            //            Title="Nissan Teana 2.5L",
            //            Author ="Luxury Car",
            //            Count = 3,
            //            Publisher="teana.jpg",
            //            Price = 12.4
            //        }),
            //       new BookViewModel(
            //        new Book
            //        {
            //            Title="Nissan Teana 2.5L",
            //            Author ="Luxury Car",
            //            Count = 3,
            //            Publisher="teana.jpg",
            //            Price = 12.4
            //        })
            //};
           

        public DashboardViewModel()
        {
           //BookListViewModel = new BookListViewModel(_books);
            _logic = new LogicLayer("BookStore");
            foreach (Book b in _logic.GetAllBooks())
            {
                BookViewModel k = new BookViewModel(b);
                _books.Add(k);
            }

            BookListViewModel = new BookListViewModel(_books);

            // BookListViewModel = new BookListViewModel(_logic.GetAllBooks());
           // BookListViewModel = new BookListViewModel();
        }

        public BookListViewModel BookListViewModel { get; private set; }

        
    }
}
