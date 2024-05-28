using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BookManagement.Infrastructure.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll(int pageNumber, int pageSize);
        Task<IEnumerable<T>> GetAll(
            Expression<Func<T, bool>> filter,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy,
            int pageNumber,
            int pageSize);
        Task<T> GetById(Guid id);
        Task Add(T entity);
        Task Delete(Guid id);
        Task Update(T entity);
        Task SaveChangesAsync();
        
    }
}
