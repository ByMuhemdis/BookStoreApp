using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Store.Application.IRepository;
using Store.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Store.Persistence.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly BookStoreAppContext _context;
        public Repository(BookStoreAppContext context)
        {
                _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task<bool> AddAsync(T entity)
        {
            EntityEntry entityEntry= await Table.AddAsync(entity);
            return entityEntry.State == EntityState.Added;
        }

       
        public async Task<bool> AddRangeAsync(List<T> entities)
        {
            await  Table.AddRangeAsync(entities);
            return true;
        }

        public async Task<IQueryable<T>> GetAllAsync(bool tracking = true)
        {
            var query =  Table.AsQueryable();
            if(!tracking)
                query = query.AsNoTracking();
            return query;
        }

        public async Task<T> GetByIdAsync(int id, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if(!tracking)
                query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(data =>data.Id==id);
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query= Table.AsQueryable();
            if(!tracking)
                query = query.AsNoTracking();
            return await query.SingleOrDefaultAsync(method);
        }

        public async Task<IQueryable<T>> GetWhereAsync(Expression<Func<T, bool>> method, bool tracking = true)
        { 
            var query = Table.AsQueryable();
            if(!tracking)
                query = query.AsNoTracking();
            return query.Where(method);
        }
        public bool Remove(T entities)
        {
            EntityEntry<T> entityEntry = Table.Remove(entities);
            return entityEntry.State == EntityState.Deleted;
        }
        public async Task<bool> RemoveAsync(int id)
        {
            T entity = await Table.FirstOrDefaultAsync(data => data.Id == id);
            return Remove(entity);
        }

        public bool RemoveRange(List<T> datas)
        {
            Table.RemoveRange(datas);
            return true;
        }

       
        public bool Update(T entity)
        {
            EntityEntry entityEntry = Table.Update(entity);
            return entityEntry.State == EntityState.Modified;
        }

        public async Task<int> SaveAsync() => await _context.SaveChangesAsync();

        
    }
}
