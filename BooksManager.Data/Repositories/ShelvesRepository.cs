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
    public class ShelvesRepository : BaseRepository<Shelf>, IShelvesRepository
    {
        private ApplicationDbContext _dbContext;
        public ShelvesRepository(ApplicationDbContext dbContext)
           : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Shelf>> GetAllShelvesIncludes()
        {
            return await _dbContext.Shelves
                .Include(s => s.Books)
                .ToListAsync();
        }

        public async Task<Shelf> GetShelfIncludesById(int id)
        {
            return await _dbContext.Shelves
                .Where(s => s.Id == id)
                .Include(s => s.Books)
                .FirstOrDefaultAsync();
        }
    }
}
