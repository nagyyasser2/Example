using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Example.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Example.EF.Repositories
{
    public class BaseRepository<T>(ApplicationDbContext context) : IBaseRepository<T>
        where T : class
    {
        public T? GetById(int id)
        {
            return context.Set<T>().Find(id);
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public IEnumerable<T> GetAll()
        {
            return context.Set<T>().ToList();
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }
        public T? Find(Expression<Func<T, bool>> match, string[]? includes = null)
        {
            IQueryable<T> query = context.Set<T>();

            if (includes == null) return query.FirstOrDefault(match);

            query = includes.Aggregate(query, (current, include) => current.Include(include));

            return query.FirstOrDefault(match);
        }

        public IEnumerable<T>? FindAll(Expression<Func<T, bool>> match, string[]? includes = null)
        {
            IQueryable<T> query = context.Set<T>();

            if (includes == null) return query.Where(match).ToList();

            query = includes.Aggregate(query, (current, include) => current.Include(include));

            return query.Where(match).ToList();
        }

        public T Add(T entity)
        {
            context.Set<T>().Add(entity);
            
            return entity;
        }

        public IEnumerable<T> AddRange(IEnumerable<T> entities)
        {
            context.Set<T>().AddRange(entities);
            
            return entities;
        }
    }
}
