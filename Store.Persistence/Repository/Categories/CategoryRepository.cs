using Entities.Models;
using Store.Application.IRepository.ICategory;
using Store.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Persistence.Repository.Categories
{
    public class CategoryRepository : Repository<Category>,ICategoryReposirtory
    {
        public CategoryRepository(BookStoreAppContext context) : base(context)
        {
        }

      
    }
}
