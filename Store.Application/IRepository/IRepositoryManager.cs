using Store.Application.IRepository.IAuthor;
using Store.Application.IRepository.IBook;
using Store.Application.IRepository.ICategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.IRepository
{
    public interface IRepositoryManager
    {
        IBookReposirtory BookReposirtory { get; }

        ICategoryReposirtory CategoryReposirtory { get; }

        IAuthorRepository AuthorReposirtory { get; }
    }
}
