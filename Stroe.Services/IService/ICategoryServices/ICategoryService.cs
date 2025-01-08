using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stroe.Services.IService.ICategoryServices
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetCategoryAllAsync(bool tracking);
        Task<Category> GetCategoryByIdAsync(int id,bool tracking);
        Task<bool> AddCategoryAsync(Category category);
        Task<bool> UpdateCategoryAsync(int id, Category category);
        Task<bool> DeleteCategoryAsync(int id,bool tracking);
    }
}
