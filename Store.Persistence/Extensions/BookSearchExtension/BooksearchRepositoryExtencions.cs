using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Persistence.Extensions.BookSearchExtension
{
    public static class BooksearchRepositoryExtencions
    {
        //Arama da kullanılacak metot
        public static IQueryable<Book> Search(this IQueryable<Book> book, string? searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return book;
            }
            var lowerCase = searchTerm.Trim().ToLower();

            return book.Where(s => s.Title.ToLower().Contains(lowerCase));
        }
    }
}
