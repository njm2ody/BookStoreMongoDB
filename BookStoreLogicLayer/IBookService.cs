using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreLogicLayer
{
    interface IBookService
    {
        IEnumerable<Book>       GetPopularBook();
        IEnumerable<string>     GetPopularAuthors();
        //IEnumerable<Order>      GetLatestOrders();
    }
}
