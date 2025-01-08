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
        Task<Book> GetBookByIdAsync(int Id);
        Task<IEnumerable <Book>> GetBookAllAsync(bool tracking);

        Task<bool> AddBookAsync(Book book);
        Task<bool> DeleteBookById(int Id,bool tracking);

        Task<bool> UpdateBook(int Id, Book book);
        

    }
}
