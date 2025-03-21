﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Example.Core.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        T? GetById(int id);
        Task<T?> GetByIdAsync(int id);
        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();
        T? Find(Expression<Func<T, bool>> match, string[]? includes = null);
        IEnumerable<T>? FindAll(Expression<Func<T, bool>> match, string[]? includes = null);
        T Add(T entity);
        IEnumerable<T> AddRange(IEnumerable<T> entity);
        bool Any(Expression<Func<T, bool>> match);
        Task<bool> AnyAsync(Expression<Func<T, bool>> match);
    }
}
