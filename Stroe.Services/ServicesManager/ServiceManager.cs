using Store.Application.IRepository;
using Store.Application.IRepository.IBook;
using Stroe.Services.IService;
using Stroe.Services.IService.IAuthorServices;
using Stroe.Services.IService.IBookServices;
using Stroe.Services.IService.ICategoryServices;
using Stroe.Services.ServicesManager.AuthorManagers;
using Stroe.Services.ServicesManager.BookManagers;
using Stroe.Services.ServicesManager.CategoryManagers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stroe.Services.ServicesManager
{
    public class ServiceManager : IServiceManager
    {
        private readonly IRepositoryManager _repositoryManager;

        //Servisleri  uraya tek tek tanıtıp merkezi hale getirelim.

        private readonly Lazy<IAuthorService> _authorService;
        private readonly Lazy<IBookService> _bookService;
        private readonly Lazy<ICategoryService> _categoryService;


        public ServiceManager(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;

            _authorService = new Lazy<IAuthorService> (()=> new AuthorManager(_repositoryManager));
            _bookService = new Lazy<IBookService>(() => new BookManager(_repositoryManager));
            _categoryService = new Lazy<ICategoryService>(() => new CategoryManager(_repositoryManager));

        }

        public IAuthorService AuthorService => _authorService.Value;

        public IBookService BookService => _bookService.Value;

        public ICategoryService CategoryService => _categoryService.Value;

        
    }
}
