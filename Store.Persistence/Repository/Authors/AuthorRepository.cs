
using Entities.Models;
using Store.Application.IRepository.IAuthor;
using Store.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Persistence.Repository.Authors
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        public AuthorRepository(BookStoreAppContext context) : base(context)
        {
        }
    }
}
