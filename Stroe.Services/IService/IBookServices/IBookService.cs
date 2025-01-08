using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stroe.Services.IService.IBookServices
{
    public interface IBookService
    {
        Task<Book> GetBookByIdAsync(int Id, bool tracking);
        Task<IEnumerable <Book>> GetBookAllAsync(bool tracking);

        Task<bool> AddBookAsync(Book book);
        Task<bool> DeleteBookByIdAsync(int Id,bool tracking);

        Task<bool> UpdateBookAsync(int Id, Book book);
        

    }
}
