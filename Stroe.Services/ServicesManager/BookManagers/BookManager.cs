using Entities.Models;
using Store.Application.BookErrorExceptions;
using Store.Application.IRepository;
using Store.Application.IRepository.IBook;
using Stroe.Services.IService;
using Stroe.Services.IService.IBookServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Stroe.Services.ServicesManager.BookManagers
{
    public class BookManager : IBookService
    {
        // private readonly IBookReposirtory _bookRepository;//bunu bu şekilde kullanmak yerine repository manager kullanarak erkezi yonden hem repositoryleri daha kolay kullanırız hemde karmasıklılıgı önleyebiliriz.

        private readonly IRepositoryManager _manager;
        private readonly ILoggerService _logger;

        public BookManager(IRepositoryManager manager, ILoggerService logger)
        {
            _manager = manager;
            _logger = logger;
        }

        public async Task<bool> AddBookAsync(Book book)
        {
            if (book == null)
            {
                var message = "the book  parameters to be saved cannot be left empty. ";
                _logger.logError(message);
                throw new BookBadRequestException(message);
            }
               

            var result = await _manager.BookReposirtory.AddAsync(book);
            await _manager.BookReposirtory.SaveAsync();
            _logger.logInfo("new Book is   added successful");
            return result;
        }

        public async Task<bool> DeleteBookByIdAsync(int Id, bool tracking)
        {
            if (Id == null || Id <= 0)
            {
                _logger.logError($"The searched id :{Id} was not found in the book list.");
                throw new BookNotFoundException(Id);
            }

            var bookDelete = await _manager.BookReposirtory.GetByIdAsync(Id);
            if (bookDelete == null)
            {
                var message = "Searched value not found.";
                _logger.logWarning(message);
                throw new BookBadRequestException(message);
            }

            await _manager.BookReposirtory.RemoveAsync(bookDelete.Id);
            await _manager.BookReposirtory.SaveAsync();

            _logger.logInfo($"Searched İd: {Id} value delete successful");
            return true;
        }

        public async Task<IEnumerable<Book>> GetBookAllAsync(bool tracking)
        {
            var AllBook = await _manager.BookReposirtory.GetAllAsync(false);
            if (AllBook == null)
            {
                var message = "Searched book value not found";
                _logger.logWarning(message);
                throw new BookBadRequestException(message);

            }
            _logger.logInfo("Searched value list found");
            return AllBook.ToList();
        }

        public async Task<Book> GetBookByIdAsync(int Id, bool tracking)
        {
            if (Id == null || Id <= 0)
            {
                _logger.logInfo($"The book with Id : {Id} could not found.");
                throw new BookNotFoundException(Id);
            }

            var result = await _manager.BookReposirtory.GetByIdAsync(Id, false);
            if (result == null)
            {
                var message = $"searching book value id ={Id} not found";
                _logger.logWarning(message);
                throw new BookBadRequestException(message);
            }
            _logger.logInfo($"searching book value id: {Id} found.");

            return result;

        }


        public async Task<bool> UpdateBookAsync(int Id, Book book)
        {
            var updateBook = await _manager.BookReposirtory.GetByIdAsync(Id, true);

            if (updateBook == null)
            {
                var message = "value come empty.";
                _logger.logWarning(message);
                throw new BookBadRequestException(message);
            }

           


            updateBook.Title = book.Title;
            updateBook.Description = book.Description;
            updateBook.PublishhedDate = book.PublishhedDate;
            updateBook.Price = book.Price;
            updateBook.Stock = book.Stock;
            updateBook.CategoryId = book.CategoryId;
            updateBook.AuthorId = book.AuthorId;

            _manager.BookReposirtory.Update(updateBook);
            await _manager.BookReposirtory.SaveAsync();
            _logger.logInfo("Update Process successfull");
            return true;

        }
    }
}
