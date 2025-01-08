using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stroe.Services.IService.IAuthorServices
{
    public interface IAuthorService
    {
        Task<IEnumerable<Author>> GetAuthorAllAsync(bool tracking);//list alll author
        Task<Author> GetAuthorByIdAsync(int id,bool tracking);//ona author

        Task<bool> UpdateAuthorAsync(int id,Author author);
        Task<bool> DeleteAuthorByIdAsync(int id,bool tracking );
        Task<bool> AddAuthorAsync(Author author);   //Added 

    }
}
