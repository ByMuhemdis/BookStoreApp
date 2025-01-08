using Entities.Models;
using Store.Application.IRepository;
using Store.Application.IRepository.IAuthor;
using Stroe.Services.IService.IAuthorServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stroe.Services.ServicesManager.AuthorManagers
{
    public class AuthorManager : IAuthorService
    {
        private readonly IRepositoryManager _manager;

        public AuthorManager(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public async Task<bool> AddAuthorAsync(Author author)
        {
            if(author == null)
                throw new ArgumentNullException(nameof(author));

            var addAuthor = await _manager.AuthorReposirtory.AddAsync(author);
            await _manager.AuthorReposirtory.SaveAsync();
            return addAuthor;
        }

        public async Task<bool> DeleteAuthorByIdAsync(int id, bool tracking)
        {
            if(id== null)
                throw new ArgumentNullException(nameof(id));

           var deleteAuthor= await _manager.AuthorReposirtory.GetByIdAsync(id);
            if(deleteAuthor == null)
                return false;
            var result = await _manager.AuthorReposirtory.RemoveAsync(deleteAuthor.Id);
            await _manager.AuthorReposirtory.SaveAsync();
            return result;
        }

        public async Task<IEnumerable<Author>> GetAuthorAllAsync(bool tracking)
        {
            var listAuthor = await _manager.AuthorReposirtory.GetAllAsync(false);
            return listAuthor.ToList();
        }

        public async Task<Author> GetAuthorByIdAsync(int id, bool tracking)
        {
            if (id <= 0)
                throw new ArgumentNullException($"id :{id} is not found.");
            var oneAuthor= await _manager.AuthorReposirtory.GetByIdAsync(id, false);
            if (oneAuthor == null)
                throw new ArgumentNullException(nameof(oneAuthor));
            return oneAuthor;


        }

        public async Task<bool> UpdateAuthorAsync(int id, Author author)
        {
            if(id<=0|| id == null) 
                throw new ArgumentNullException(nameof(id));
            var updateAuthor = await _manager.AuthorReposirtory.GetByIdAsync(id);

            if (updateAuthor == null || updateAuthor.Id !=id)
            {
                throw new ArgumentNullException($"id: {id} is not found.");
            }
            updateAuthor.FirstName = author.FirstName;
            updateAuthor.LastName = author.LastName;
            updateAuthor.Biography = author.Biography;
            updateAuthor.BirthYear = author.BirthYear;

             _manager.AuthorReposirtory.Update(author);
            await _manager.AuthorReposirtory.SaveAsync();
            return true;
        }
    }
}
