using BooksManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksManager.Domain.Repositories
{
    public interface IBooksRepository : IBaseRepository<Book>
    {
        Task<IEnumerable<Book>> GetAllBooksIncludeShelves();
    }
}
