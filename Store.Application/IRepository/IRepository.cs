using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.IRepository
{
    public interface IRepository<T> : IRepositoryBase<T> where T : BaseEntity
    {
        //Read Kısmı burası
        Task<IQueryable<T>> GetAllAsync(bool tracking = true);//butun varlıkları almak 
        Task<IQueryable<T>> GetWhereAsync(Expression<Func<T, bool>> method, bool tracking = true);//belirli bir koşula göre varlıkları almak  bir metot yazdıgımız için bu şekilde içi dolu
        Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true);//belirli bir koşula göre varlık almak 

        Task<T> GetByIdAsync(int id, bool tracking = true);//Id ile uygun olan varlıgı almak 

        //Veri tabanına yazılacak metotlar Write Kısmı

        Task<bool> AddAsync(T entity);
        Task<bool> AddRangeAsync(List<T> entities);//birden fazla ekleme
        Task<bool> RemoveAsync(int id); 

        bool Remove(T entity);
        bool RemoveRange(List<T> datas); //birden fazla silme

        bool Update(T entity);

        Task<int> SaveAsync();

    }
}
