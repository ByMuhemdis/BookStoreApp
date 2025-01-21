using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Entities.Sort;

namespace Store.Persistence.Extensions.BookSearchExtension
{
    public static class BookSortRepositoryExtencions
    {
        public static IQueryable<Book> Sort(this IQueryable<Book> book, string OrderByQueryString)
        {
            if (string.IsNullOrEmpty(OrderByQueryString))
                return book.OrderBy(b => b.Id);

            
            //buradaki ara işlemleri OrderQueryBuilder buraya tasıdık amac başka bir yerde de sıralama işlemi yapılırsa direk dinamik olarak sınıftan cekilsin.
            //ve aynı kodu defalarca yazman zorun daklmayalım 

            var orderQuery = OrderQueryBuilder.CreateOrderBy<Book>(OrderByQueryString);

            if (orderQuery == null)
                return book.OrderBy(a=>a.Id);

            return book.OrderBy(orderQuery);

        }
    }
}
