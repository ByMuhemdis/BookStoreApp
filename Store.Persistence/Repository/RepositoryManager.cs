using Store.Application.IRepository;
using Store.Application.IRepository.IAuthor;
using Store.Application.IRepository.IBook;
using Store.Application.IRepository.ICategory;
using Store.Persistence.Context;
using Store.Persistence.Repository.Authors;
using Store.Persistence.Repository.Books;
using Store.Persistence.Repository.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Persistence.Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly BookStoreAppContext _context;

        private readonly Lazy<IBookReposirtory> _bookReposirtory;//nesne ancak ve ancak kulanıldıgı anda ilgili ifade newlenecek 

        private readonly Lazy<ICategoryReposirtory> _categoryReposirtory;
        private readonly Lazy<IAuthorRepository> _authorReposirtory;

        

        public RepositoryManager(BookStoreAppContext context)
        {
            _context = context;
            _bookReposirtory =new Lazy<IBookReposirtory>(() =>new BookRepository(_context));
            _categoryReposirtory =new Lazy<ICategoryReposirtory>(()=>new CategoryRepository(_context));
            _authorReposirtory =new Lazy<IAuthorRepository>(() =>new AuthorRepository(_context));
        }

        public IBookReposirtory BookReposirtory => _bookReposirtory.Value;

        public ICategoryReposirtory CategoryReposirtory => _categoryReposirtory.Value;

        public IAuthorRepository AuthorReposirtory => _authorReposirtory.Value;
    }
}
