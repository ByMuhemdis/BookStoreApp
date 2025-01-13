
using AutoMapper;
using Entities.Models;
using NLog;
using Store.Application.AuthorErrorExceptions;
using Store.Application.DTOs.AuthorDtos;
using Store.Application.IRepository;
using Store.Application.IRepository.IAuthor;
using Stroe.Services.IService;
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
        private readonly ILoggerService _logger;
        private readonly IMapper _mapper;

        public AuthorManager(IRepositoryManager manager, ILoggerService logger, IMapper mapper)
        {
            _manager = manager;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<bool> AddAuthorAsync(AuthorDto authorDto)
        {
            if (authorDto == null)
            {
                var message = "Author is null value"; 
                _logger.logWarning(message);
                throw new AuthorBadRequestException(message);

            }
            //bu manuel mapplemedir. biz altta oautomapping işlemini yaparak bundan çakınacagız.
            /*
            var aunhorDto = new Author
            {
                Biography = author.Biography,
                BirthYear = author.BirthYear,
                FirstName = author.FirstName,
                LastName = author.LastName
                
            };
            */
            var authorMapper = _mapper.Map<Author>(authorDto);

            var addAuthor = await _manager.AuthorReposirtory.AddAsync(authorMapper);
            await _manager.AuthorReposirtory.SaveAsync();
            _logger.logInfo("registration successful");
            return addAuthor;
        }

        public async Task<bool> DeleteAuthorByIdAsync(int id, bool tracking)
        {
            if (id == null)
            {
                _logger.logError("incorrect operation");

                throw new AuthorNotfoundException(id);
            }


            var deleteAuthor = await _manager.AuthorReposirtory.GetByIdAsync(id);
            if (deleteAuthor == null)
            {
                var message = "Searched value not found";
                _logger.logWarning(message);
                throw new AuthorBadRequestException(message);
            }

            var result = await _manager.AuthorReposirtory.RemoveAsync(deleteAuthor.Id);
            await _manager.AuthorReposirtory.SaveAsync();
            _logger.logInfo("Searched value  is delete successful.");
            return result;
        }

        public async Task<IEnumerable<AuthorDto>> GetAuthorAllAsync(bool tracking)
        {
            var listAuthor = await _manager.AuthorReposirtory.GetAllAsync(false);
            if (listAuthor == null)
            {
                var mesage = "Searched value not found";
                _logger.logWarning(mesage);
                throw new AuthorBadRequestException(mesage);

            }

            var authorList = _mapper.Map<IEnumerable<AuthorDto>>(listAuthor);

            _logger.logInfo("Searched value  found");
            return authorList;
        }

        public async Task<Author> GetAuthorByIdAsync(int id, bool tracking)
        {
            if (id <= 0)
            {

                _logger.logInfo($"The Author with Id : {id} could not found.");
                throw new AuthorNotfoundException(id);
            }
                
            var oneAuthor = await _manager.AuthorReposirtory.GetByIdAsync(id, false);
            if (oneAuthor == null)
            {
                var mesage = "Searched value not found";
                _logger.logWarning(mesage);
                throw new AuthorBadRequestException(mesage);
            }
            _logger.logInfo($"Searched value id :{id}  found");
            return oneAuthor;


        }

        public async Task<bool> UpdateAuthorAsync(int id, AuthorDto authorDto)
        {
            if (id <= 0 || id == null)
                throw new AuthorNotfoundException(id);
            var updateAuthor = await _manager.AuthorReposirtory.GetByIdAsync(id);

            if (updateAuthor == null || updateAuthor.Id != id)
            {
                var message = $"id: {id} is not found.";
                _logger.logError(message);
                throw new AuthorBadRequestException(message);
            }
            //manule mapping burası 
            /*
            updateAuthor.FirstName = authorDto.FirstName;
            updateAuthor.LastName = authorDto.LastName;
            updateAuthor.Biography = authorDto.Biography;
            updateAuthor.BirthYear = authorDto.BirthYear;

            */
            //autoMapping işlemi 

            var a =_mapper.Map(authorDto, updateAuthor);

            _manager.AuthorReposirtory.Update(a);
            await _manager.AuthorReposirtory.SaveAsync();
            _logger.logInfo("update process successful");
            return true;
        }
    }
}
