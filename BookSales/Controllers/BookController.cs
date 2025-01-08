using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stroe.Services.IService;

namespace BookSales.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public BookController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllBooks()
        {
            var response =await _serviceManager.BookService.GetBookAllAsync(false);
            return Ok(response);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetOneBook( int id )
        {
            var response = await _serviceManager.BookService.GetBookByIdAsync(id,false); 
            return Ok(response);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateOneBook(Book book)
        {
            var response = await _serviceManager.BookService.AddBookAsync(book);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateOneBook(int id,Book book)
        {
            var response = await _serviceManager.BookService.UpdateBookAsync(id, book);
            return Ok(response);
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteOnebook(int id)
        {
            var response = await _serviceManager.BookService.DeleteBookByIdAsync(id,true);
            return Ok(response);
        }
    }
}
