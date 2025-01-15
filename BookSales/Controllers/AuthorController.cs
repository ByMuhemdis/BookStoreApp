using BookSales.ActionFilter;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Application.DTOs.AuthorDtos;
using Stroe.Services.IService;

namespace BookSales.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(LogFilterAttrubute))]//butun metotlarda log alıcaz 
   
    public class AuthorController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public AuthorController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }
        [ServiceFilter(typeof(ValidationModelStateFilterAAttribute))]
   
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllAuthor()
        {
            if(!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            var response = await _serviceManager.AuthorService.GetAuthorAllAsync(false);
            return Ok(response);
        }
  
        [HttpGet("[action]")]
        public async Task<IActionResult> GetOneAuthor(int id)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            var response = await _serviceManager.AuthorService.GetAuthorByIdAsync(id,false);
            return Ok(response);
        }
        [ServiceFilter(typeof(ValidationModelStateFilterAAttribute))]
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateOneAuthor(AuthorDto authorDto)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            var response = await _serviceManager.AuthorService.AddAuthorAsync(authorDto);
            return Ok(response);
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteOneAuthor(int id)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            var response =await _serviceManager.AuthorService.DeleteAuthorByIdAsync(id,false);
            return Ok(response);
        }
        [ServiceFilter(typeof(ValidationModelStateFilterAAttribute))]
        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateOneAuthor(int id, AuthorDto authorDto)
        {
           
            var response = await _serviceManager.AuthorService.UpdateAuthorAsync(id, authorDto);
            return Ok(response);

        }
    }
}
