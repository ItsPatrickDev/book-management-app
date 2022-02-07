using BooksManager.Domain.Entities;
using BooksManager.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksManager.Data.Repositories
{
    public class BooksRepository : BaseRepository<Book>, IBooksRepository
    {
        private ApplicationDbContext _dbContext;
        public BooksRepository(ApplicationDbContext dbContext) 
            : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Book>> GetAllBooksIncludeShelves()
        {
            return await _dbContext.Books
                .Include(b => b.Shelf)
                .ToListAsync();
        }
    }
}
