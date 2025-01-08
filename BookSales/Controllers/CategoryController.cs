using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stroe.Services.IService;
using System.Security.AccessControl;

namespace BookSales.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
            var response = await _serviceManager.CategoryService.GetCategoryAllAsync(false);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetOneCategory(int id)
        {
            var response = await _serviceManager.CategoryService.GetCategoryByIdAsync( id, false);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddOneCategory(Category category)
        {
            var response = await _serviceManager.CategoryService.AddCategoryAsync(category);
            return Ok(response);
        }
        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteOneCategory(int id)
        {
            var response = await _serviceManager.CategoryService.DeleteCategoryAsync(id,false);
            return Ok(response);
        }
        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateOneCategory(int id,Category category)
        {
            var response = await _serviceManager.CategoryService.UpdateCategoryAsync(id, category);
            return Ok(response);
        }
    }
}
