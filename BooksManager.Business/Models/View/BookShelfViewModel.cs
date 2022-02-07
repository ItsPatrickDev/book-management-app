using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksManager.Business.Models.View
{
    public class BookShelfViewModel
    {
        public IEnumerable<BookModel> Books { get; set; }
        public ShelfModel Shelf { get; set; }
    }
}
