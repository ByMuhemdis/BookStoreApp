using Entities.Models;
using Entities.Pagination;
using Microsoft.EntityFrameworkCore;
using Store.Application.IRepository.IBook;
using Store.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Persistence.Repository.Books
{
    public class BookRepository : Repository<Book>, IBookReposirtory
    {
        public BookRepository(BookStoreAppContext context) : base(context)
        {
        }
        //Sadece sayfalama proje kısmında kullanılacagı için burada getirirken yeni bir getAll yapacagız. ve artık listelemelerde bu metot kyullanılacak.
        public async Task<PageList<Book>> GetPaginationForBookRequestQueryAsync(BookPaginationParameters bookpaginationParameters, bool tracking)
        {
            // birinci yol  Bir Pagedlist yazmadıysak bu şekilde olabilir
            /*
            var resultPagination = await GetAllAsync(tracking);

            resultPagination = resultPagination.Skip((bookpaginationParameters.PageNumber - 1) * bookpaginationParameters.Pagesize)
                                               .Take(bookpaginationParameters.Pagesize);
            return resultPagination;
            */
            /*
              return await (await GetAllAsync(traking))
             .Skip((projectParemeters.PageNumber - 1) * projectParemeters.PageSize)
               //dizinler yazılımda 0 dan başladıgı için burada sayfa sayısı olan pageNumber ilk sayfa için 0 olmalıdır .
               //bu yuzden biz 1 sayfa dedigimizde aslında 0 rıncı sayfayı istyoruz yani ilk sayfa arka planda sıfrıdır.
               //diger tarafda da kullanıcı diyelim li 2 syafaya gecti biz bir sayfada kat kayıt var ise bunu hesaplayıp projectParemeters.PageSize gecerek işlen yapacagız 
             .Take(projectParemeters.PageSize)
             .ToListAsync();

            */
            //2. ol bir pagetlist yazarak daha detaylı bir sayfalama işlemi yapabilirz.
            var booksPagination = await GetAllAsync(tracking);

            var bookPaginations =await booksPagination.ToListAsync();

            return PageList<Book>.ToPagedList(bookPaginations, bookpaginationParameters.PageNumber, bookpaginationParameters.Pagesize);

        }
    }
}
