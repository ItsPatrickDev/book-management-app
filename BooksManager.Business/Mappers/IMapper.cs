using BooksManager.Business.Models;
using BooksManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksManager.Business.Mappers
{
    public interface IMapper
    {
        //Books
        BookModel ToModel(Book book, bool includes = true);
        Book ToModel(BookModel bookModel, bool includes = true);

        //Shelves
        ShelfModel ToModel(Shelf shelf, bool includes = true);
        Shelf ToModel(ShelfModel shelfModel, bool includes = true);
    }
}
