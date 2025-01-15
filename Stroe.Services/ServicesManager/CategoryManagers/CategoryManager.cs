using AutoMapper;
using Entities.Models;
using Store.Application.CategoryErrorExceptions;
using Store.Application.DTOs.CategoryDtos;
using Store.Application.IRepository;
using Stroe.Services.IService;
using Stroe.Services.IService.ICategoryServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Stroe.Services.ServicesManager.CategoryManagers
{
    public class CategoryManager : ICategoryService
    {
        private readonly IRepositoryManager _manager;
        private readonly ILoggerService _logger;
        private readonly IMapper _mapper;

        public CategoryManager(IRepositoryManager manager, ILoggerService logger, IMapper mapper)
        {
            _manager = manager;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<bool> AddCategoryAsync(CategoryDto categoryDto)
        {
            if (categoryDto == null)
            {
                var message = "the Category parameters to be saved cannot be left empty.";
                _logger.logError(message);
                throw new CategoryBadRequestException(message);
            }
            var AddCategoryDto = _mapper.Map<Category>(categoryDto);

            var AddCategory = await _manager.CategoryReposirtory.AddAsync(AddCategoryDto);
            await _manager.CategoryReposirtory.SaveAsync();
            _logger.logInfo("new coategory is added successful.");
            return true;
        }

        public async Task<bool> DeleteCategoryAsync(int id, bool tracking)
        {
            if (id <= 0 || id == null)
            {
                _logger.logError($" the searched id : {id} was not found in the category list.");
                throw new CategoryNoFoundException(id);
            }
                
            var deleteCategory = await _manager.CategoryReposirtory.GetByIdAsync(id);
            if(deleteCategory ==null)
            {
                var message = $"searched value not foun";
                _logger.logWarning(message);
                throw new CategoryBadRequestException(message);
            }

            await _manager.CategoryReposirtory.RemoveAsync(deleteCategory.Id);
            await _manager.CategoryReposirtory.SaveAsync();
            _logger.logInfo($"Searched id: {id} value delete successful ");
            return true;

        }

        public async Task<IEnumerable<CategoryDto>> GetCategoryAllAsync(bool tracking)
        {
            var allCategoryList = await _manager.CategoryReposirtory.GetAllAsync(false);
            if (allCategoryList == null)
            {
                var message = "searched value not foun";
                _logger.logWarning(message);
                throw new CategoryBadRequestException(message);
            }
            var CategoryListDto =_mapper.Map<IEnumerable<CategoryDto>>(allCategoryList);
            _logger.logInfo("Serached value list found.");
            return CategoryListDto;
        }

        public async Task<CategoryDto> GetCategoryByIdAsync(int id, bool tracking)
        {
            if (id <= 0 || id == null)
            {
                _logger.logError($"id: {id} is not found.");
                throw new CategoryNoFoundException(id);
                
            }
                
            var oneCategory = await _manager.CategoryReposirtory.GetByIdAsync(id, false);
            if (oneCategory is null)
            {
                var message = $" Searching value İd : {id} found. ";
                _logger.logWarning(message);
                throw new CategoryBadRequestException(message);
            }
            var categoryDto =_mapper.Map<CategoryDto>(oneCategory);
            _logger.logInfo($"Searching category value id : {id} found."); 
            return categoryDto;
        }

        public async Task<bool> UpdateCategoryAsync(int id, CategoryDto categoryDto)
        {

            if (id <= 0 || id == null)
            {
                _logger.logError($"id: {id} is not found.");
                throw new CategoryNoFoundException(id);
            }
              
            var updateCategory = await _manager.CategoryReposirtory.GetByIdAsync(id);
            if (updateCategory is null)
            {
                _logger.logError("value come empty.");
                throw new ArgumentNullException($"category not found. ");
            }
               
         

            //Manuel Mapping 
            /*
            updateCategory.CategoryName = category.CategoryName;
            */

            //outoMapping

            var updateCategoryDto = _mapper.Map(categoryDto, updateCategory);

            _manager.CategoryReposirtory.Update(updateCategoryDto);
            await _manager.CategoryReposirtory.SaveAsync();
            _logger.logInfo("update process successful");
            return true;

        }

       
    }
}
