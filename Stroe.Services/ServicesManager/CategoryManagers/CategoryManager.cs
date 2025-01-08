using Entities.Models;
using Store.Application.IRepository;
using Stroe.Services.IService.ICategoryServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stroe.Services.ServicesManager.CategoryManagers
{
    public class CategoryManager : ICategoryService
    {
        private readonly IRepositoryManager _manager;

        public CategoryManager(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public async Task<bool> AddCategoryAsync(Category category)
        {
            if (category == null)
                throw new ArgumentNullException("Category content cannot be empty.");
            var AddCategory = await _manager.CategoryReposirtory.AddAsync(category);
            await _manager.CategoryReposirtory.SaveAsync();
            return true;
        }

        public async Task<bool> DeleteCategoryAsync(int id, bool tracking)
        {
            if(id <=0||id ==null) 
                throw new ArgumentNullException($"id :{id} is not found.");
            var deleteCategory = await _manager.CategoryReposirtory.GetByIdAsync(id);

             await _manager.CategoryReposirtory.RemoveAsync(deleteCategory.Id);
            await _manager.CategoryReposirtory.SaveAsync();
            return true;

        }

        public async Task<IEnumerable<Category>> GetCategoryAllAsync(bool tracking)
        {
            var allCategoryList= await _manager.CategoryReposirtory.GetAllAsync(false);
            return allCategoryList.ToList();
        }

        public async Task<Category> GetCategoryByIdAsync(int id, bool tracking)
        {
            if(id <=0|| id ==null)
                throw new ArgumentNullException($"id: {id} is not found.");
            var oneCategory = await _manager.CategoryReposirtory.GetByIdAsync(id,false);
            if (oneCategory is null)
                throw new ArgumentNullException($"category not found. ");
            return oneCategory;
        }

        public async Task<bool> UpdateCategoryAsync(int id, Category category)
        {

            if (id <= 0 || id == null)
                throw new ArgumentNullException($"id: {id} is not found.");
            var updateCategory = await _manager.CategoryReposirtory.GetByIdAsync(id);
            if (updateCategory is null)
                throw new ArgumentNullException($"category not found. ");
            if (id != category.Id)
                throw new ArgumentException($"Not Found {id} is Book Table");

            updateCategory.CategoryName = category.CategoryName;

             _manager.CategoryReposirtory.Update(updateCategory);
            await _manager.CategoryReposirtory.SaveAsync();
            return true;

        }
    }
}
