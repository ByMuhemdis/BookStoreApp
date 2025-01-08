using Stroe.Services.IService.IAuthorServices;
using Stroe.Services.IService.IBookServices;
using Stroe.Services.IService.ICategoryServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stroe.Services.IService
{
    public interface IServiceManager
    {
        IAuthorService AuthorService { get; }
        IBookService BookService { get; }
        ICategoryService CategoryService { get; }

    }
}
