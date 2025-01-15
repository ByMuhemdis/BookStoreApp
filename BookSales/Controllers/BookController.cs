using BookSales.ActionFilter;
using Entities.Models;
using Entities.Pagination;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Application.DTOs.BookDtos;
using Stroe.Services.IService;
using System.Text.Json;

namespace BookSales.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(LogFilterAttrubute))]
    public class BookController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public BookController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet("[action]")]

        public async Task<IActionResult> GetAllBooks([FromQuery] BookPaginationParameters bookPaginationParameters)
        {

            var pegedResult = await _serviceManager.BookService.GetBookAllAsync(bookPaginationParameters, false);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pegedResult.metaData));

            return Ok(pegedResult.books);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetOneBook(int id)
        {

            var response = await _serviceManager.BookService.GetBookByIdAsync(id, false);
            return Ok(response);
        }
        [HttpPost("[action]")]
        [ServiceFilter(typeof(ValidationModelStateFilterAAttribute))]
        public async Task<IActionResult> CreateOneBook(BookDto bookDto)
        {
            /*
              if (!ModelState.IsValid)  //burası  artık ihtiyacımızın olmadıgı bir kısım cunku yurarıda  [ServiceFilter(typeof(ValidationModelStateFilterAAttribute))] bu metotda bu kontrol saglanıyor 
                 {
                   return UnprocessableEntity(ModelState);
                 }
            */
            var response = await _serviceManager.BookService.AddBookAsync(bookDto);
            return Ok(response);
        }

        [HttpPut("[action]")]
        [ServiceFilter(typeof(ValidationModelStateFilterAAttribute))]
        public async Task<IActionResult> UpdateOneBook(int id, BookUpdateDto bookDto)
        {
            /*
             if (!ModelState.IsValid)  //burası  artık ihtiyacımızın olmadıgı bir kısım cunku yurarıda  [ServiceFilter(typeof(ValidationModelStateFilterAAttribute))] bu metotda bu kontrol saglanıyor 
                 {
                      return UnprocessableEntity(ModelState);
                 }
           */
            var response = await _serviceManager.BookService.UpdateBookAsync(id, bookDto);
            return Ok(response);
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteOnebook(int id)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            var response = await _serviceManager.BookService.DeleteBookByIdAsync(id, true);
            return Ok(response);
        }
    }
}
