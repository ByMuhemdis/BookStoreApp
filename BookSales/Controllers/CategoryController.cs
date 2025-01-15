using BookSales.ActionFilter;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Application.DTOs.CategoryDtos;
using Stroe.Services.IService;
using System.Security.AccessControl;

namespace BookSales.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(LogFilterAttrubute))]

    public class CategoryController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public CategoryController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllCategories()
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            var response = await _serviceManager.CategoryService.GetCategoryAllAsync(false);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetOneCategory(int id)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            var response = await _serviceManager.CategoryService.GetCategoryByIdAsync( id, false);
            return Ok(response);
        }

     
        [ServiceFilter(typeof(ValidationModelStateFilterAAttribute))]//dogrulama işlemi için yazıldı //Gelen parametre eksik mi?
                                                                     //Gelen model istenen kurallara uyuyor mu(örneğin[Required], [Range] gibi)?
                                                                     //Eksiklikler varsa kullanıcıya uygun bir hata yanıtı döner.

        [HttpPost("[action]")]                                                            
        public async Task<IActionResult> AddOneCategory(CategoryDto categoryDto)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            var response = await _serviceManager.CategoryService.AddCategoryAsync(categoryDto);
            return Ok(response);
        }
        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteOneCategory(int id)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            var response = await _serviceManager.CategoryService.DeleteCategoryAsync(id,false);
            return Ok(response);
        }
        [HttpPut("[action]")]
        [ServiceFilter(typeof(ValidationModelStateFilterAAttribute))]
        public async Task<IActionResult> UpdateOneCategory(int id,CategoryDto categoryDto)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            var response = await _serviceManager.CategoryService.UpdateCategoryAsync(id, categoryDto);
            return Ok(response);
        }
    }
}
