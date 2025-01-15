using Entities.Models;
using Store.Application.DTOs.CategoryDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stroe.Services.IService.ICategoryServices
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetCategoryAllAsync(bool tracking);
        Task<CategoryDto> GetCategoryByIdAsync(int id,bool tracking);
        Task<bool> AddCategoryAsync(CategoryDto categoryDto);
        Task<bool> UpdateCategoryAsync(int id, CategoryDto categoryDto);
        Task<bool> DeleteCategoryAsync(int id,bool tracking);
    }
}
