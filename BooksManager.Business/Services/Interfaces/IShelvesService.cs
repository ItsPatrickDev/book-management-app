using BooksManager.Business.Models;
using BooksManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksManager.Business.Services.Interfaces
{
    public interface IShelvesService
    {
        Task<IEnumerable<ShelfModel>> GetAllShelves();
        Task<IEnumerable<ShelfModel>> GetAllShelvesIncludes();
        Task<IEnumerable<BookModel>> GetAllBooksFromShelf(int id);
        Task<ShelfModel> GetShelfById(int id);
        Task<ShelfModel> GetShelfIncludesById(int id);
        Task AddToShelf(Book book, int shelfId);
        Task CreateShelf(Shelf shelfModel);
        Task RemoveShelf(int id);
        Task RemoveBook(int bookId, int shelfId);
    }
}
