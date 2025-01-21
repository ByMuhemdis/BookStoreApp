using Entities.Models;
using Entities.Pagination;
using Entities.Search;
using Entities.Sort;
using Store.Application.DTOs.BookDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.IRepository.IBook
{
    public interface IBookReposirtory : IRepository<Book>
    {
        Task<PageList<Book>> GetPaginationForBookRequestQueryAsync(BookPaginationParameters paginationParameters,bool tracking); //Sayfalama

        Task<IQueryable<Book>> GetSearchBookRequestParameters(BookSearchParameters searchParameters,bool tracking);//Arama 

        Task<IQueryable<Book>> GetBookSortharametersAsync(BookShortParameters bookShortParameters, bool tracking);//Sıralama
    }
}
