using Entities.Models;
using Entities.Pagination;
using Store.Application.DTOs.BookDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stroe.Services.IService.IBookServices
{
    public interface IBookService
    {
        Task<BookDto> GetBookByIdAsync(int Id, bool tracking);
        Task<(IEnumerable<BookDto> books, MetaData metaData)> GetBookAllAsync(BookPaginationParameters bookPaginationParameters,bool tracking);//sayfalamadan dolayı burada ProjetcParameter ifadesini ekledik

        Task<bool> AddBookAsync(BookDto bookDto);
        Task<bool> DeleteBookByIdAsync(int Id,bool tracking);

        Task<bool> UpdateBookAsync(int Id, BookUpdateDto bookDto);
        

    }
}
