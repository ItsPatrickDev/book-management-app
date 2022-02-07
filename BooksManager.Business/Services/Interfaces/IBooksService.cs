using BooksManager.Business.Models;
using BooksManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksManager.Business.Services.Interfaces
{
    public interface IBooksService
    {
        Task<BookModel> GetBookById(int id);
        Task<IEnumerable<BookModel>> GetAllBooks();
        Task AddBook(Book book);
        Task UpdateBook(Book book);
        Task RemoveBook(int id);
        Task SetBookFavourite(int id, bool isFavourite);
        Task<IEnumerable<BookModel>> GetAllFavouriteBooks();
    }
}
