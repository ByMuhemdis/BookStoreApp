using Entities.Models;
using Store.Application.IRepository.IBook;
using Store.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Persistence.Repository.Books
{
    public class BookRepository : Repository<Book>,IBookReposirtory
    {
        public BookRepository(BookStoreAppContext context) : base(context)
        {
        }

       
    }
}
