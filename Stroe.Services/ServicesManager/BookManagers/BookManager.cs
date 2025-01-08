using Entities.Models;
using Store.Application.IRepository;
using Store.Application.IRepository.IBook;
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

        public BookManager(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public async Task<bool> AddBookAsync(Book book)
        {
            if (book == null)
                throw new ArgumentNullException(nameof(book));

            var result = await _manager.BookReposirtory.AddAsync(book);
            await _manager.BookReposirtory.SaveAsync();
            return result;
        }

        public async Task<bool> DeleteBookByIdAsync(int Id, bool tracking)
        {
            if (Id == null)
                throw new ArgumentNullException(nameof(Id));
            var bookDelete = await _manager.BookReposirtory.GetByIdAsync(Id);
            if (bookDelete == null)
                throw new ArgumentNullException(nameof(bookDelete));

            await _manager.BookReposirtory.RemoveAsync(bookDelete.Id);
            await _manager.BookReposirtory.SaveAsync();
            return true;
        }

        public async Task<IEnumerable<Book>> GetBookAllAsync(bool tracking)
        {
            var AllBook = await _manager.BookReposirtory.GetAllAsync(false);
            return AllBook.ToList();
        }

        public async Task<Book> GetBookByIdAsync(int Id, bool tracking)
        {
            if (Id == null)
                throw new ArgumentNullException(nameof(Id));
            var result = await _manager.BookReposirtory.GetByIdAsync(Id, false);
            if (result == null)
                throw new ArgumentNullException(nameof(result));
            return result;

        }


        public async Task<bool> UpdateBookAsync(int Id, Book book)
        {
            var updateBook = await _manager.BookReposirtory.GetByIdAsync(Id, true);

            if (updateBook == null)
                throw new ArgumentNullException(nameof(updateBook));
            if (Id != book.Id)
                throw new ArgumentException($"Not Found {Id} is Book Table");

            updateBook.Title = book.Title;
            updateBook.Description = book.Description;
            updateBook.PublishhedDate = book.PublishhedDate;
            updateBook.Price = book.Price;
            updateBook.Stock = book.Stock;
            updateBook.CategoryId = book.CategoryId;
            updateBook.AuthorId = book.AuthorId;

            _manager.BookReposirtory.Update(updateBook);
            await _manager.BookReposirtory.SaveAsync();
            return true;

        }
    }
}
