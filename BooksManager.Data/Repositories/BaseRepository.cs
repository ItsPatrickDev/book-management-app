using BooksManager.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BooksManager.Data.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private DbSet<TEntity> Entities;
        public BaseRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            Entities = _applicationDbContext.Set<TEntity>();
        }

        public async Task Add(TEntity entity)
        {
            await Entities.AddAsync(entity);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task AddRange(IEnumerable<TEntity> entities)
        {
            Entities.AddRange(entities);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> FindAll(Expression<Func<TEntity, bool>> expression)
        {
            return await Entities.Where(expression).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await Entities.ToListAsync();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await Entities.FindAsync(id);
        }

        public async Task Remove(TEntity entity)
        {
            Entities.Remove(entity);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task RemoveRange(IEnumerable<TEntity> entities)
        {
            Entities.RemoveRange(entities);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task Update(TEntity entity)
        {
            Entities.Update(entity);
            await _applicationDbContext.SaveChangesAsync();
        }
    }
}
