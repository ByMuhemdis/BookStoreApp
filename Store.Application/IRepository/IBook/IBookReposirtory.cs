using Entities.Models;
using Entities.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.IRepository.IBook
{
    public interface IBookReposirtory : IRepository<Book>
    {
        Task<PageList<Book>> GetPaginationForBookRequestQueryAsync(BookPaginationParameters paginationParameters,bool tracking);
    }
}
