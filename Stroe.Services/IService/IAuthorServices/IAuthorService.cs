using Entities.Models;
using Store.Application.DTOs.AuthorDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stroe.Services.IService.IAuthorServices
{
    public interface IAuthorService
    {
        Task<IEnumerable<AuthorDto>> GetAuthorAllAsync(bool tracking);//list alll author
        Task<Author> GetAuthorByIdAsync(int id,bool tracking);//ona author

        Task<bool> UpdateAuthorAsync(int id,AuthorDto authorDto);
        Task<bool> DeleteAuthorByIdAsync(int id,bool tracking );
        Task<bool> AddAuthorAsync(AuthorDto authorDto);   //Added 

    }
}
