using BooksManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksManager.Domain.Repositories
{
    public interface IShelvesRepository : IBaseRepository<Shelf>
    {
        Task<IEnumerable<Shelf>> GetAllShelvesIncludes();
        Task<Shelf> GetShelfIncludesById(int id);
    }
}
