using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Application.DTOs.AuthorDtos;
using Stroe.Services.IService;

namespace BookSales.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public AuthorController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllAuthor()
        {
            var response = await _serviceManager.AuthorService.GetAuthorAllAsync(false);
            return Ok(response);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetOneAuthor(int id)
        {
            var response = await _serviceManager.AuthorService.GetAuthorByIdAsync(id,false);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateOneAuthor(AuthorDto authorDto)
        {
            var response = await _serviceManager.AuthorService.AddAuthorAsync(authorDto);
            return Ok(response);
        }
        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteOneAuthor(int id)
        {
            var response =await _serviceManager.AuthorService.DeleteAuthorByIdAsync(id,false);
            return Ok(response);
        }
        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateOneAuthor(int id, AuthorDto authorDto)
        {
            var response = await _serviceManager.AuthorService.UpdateAuthorAsync(id, authorDto);
            return Ok(response);

        }
    }
}
