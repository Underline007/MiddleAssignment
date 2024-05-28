using BookManagement.Entities.Models;
using BookManagement.Infrastructure.Data;
using BookManagement.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BookManagement.Infrastructure.Repositories
{
    public class GenericRepository<T>(ApplicationDbContext context) : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context = context;

        public async Task Add(T entity)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                await _context.Set<T>().AddAsync(entity);
                await SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task Delete(Guid id)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            {
                try
                {
                    var entity = await _context.Set<T>().FindAsync(id);
                    if (entity != null)
                    {
                        _context.Set<T>().Remove(entity);
                        await SaveChangesAsync();
                        await transaction.CommitAsync();
                    }
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }
        }

        public async Task Update(T entity)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            {
                try
                {
                    _context.Entry(entity).State = EntityState.Modified;
                    await SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }
        }

        public async Task<IEnumerable<T>> GetAll(int pageNumber, int pageSize)
        {
            return await _context.Set<T>()
                                 .Skip((pageNumber - 1) * pageSize)
                                 .Take(pageSize)
                                 .ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAll(
            Expression<Func<T, bool>> filter,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy,
            int pageNumber,
            int pageSize)
        {
            IQueryable<T> query = _context.Set<T>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            return await query.Skip((pageNumber - 1) * pageSize)
                              .Take(pageSize)
                              .ToListAsync();
        }   

        public async Task<T> GetById(Guid id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            return entity ?? throw new KeyNotFoundException($"Entity with ID {id} not found.");
        }

        public Task SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
