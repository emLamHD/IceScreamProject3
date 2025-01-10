﻿using System.Linq.Expressions;

namespace demoDataFirst.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(object id);
        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate);
        Task AddAsync(T entity);
        Task SaveAsync();
        Task UpdateAsync(T entity);
        Task DeleteAsync(object id);
        Task<T?> GetByConditionAsync(Expression<Func<T, bool>> predicate);
    }
}
