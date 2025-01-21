using AutoMapper;
using Entities.Models;
using Entities.Pagination;
using Entities.Search;
using Entities.Sort;
using Microsoft.EntityFrameworkCore;
using Store.Application.BookErrorExceptions;
using Store.Application.DTOs.BookDtos;
using Store.Application.ErrorExceptions.BookErrorExceptions;
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
        private readonly IMapper _mapper;

        public BookManager(IRepositoryManager manager, ILoggerService logger, IMapper mapper)
        {
            _manager = manager;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<bool> AddBookAsync(BookDto bookDto)
        {
            if (bookDto == null)
            {
                var message = "the book  parameters to be saved cannot be left empty. ";
                _logger.logError(message);
                throw new BookBadRequestException(message);
            }

            var UpdateDto =  _mapper.Map<Book>(bookDto);

            var result = await _manager.BookReposirtory.AddAsync(UpdateDto);
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

        public async Task<(IEnumerable<BookDto> books, MetaData metaData)> GetBookAllAsync(BookPaginationParameters bookPaginationParameters,bool tracking)
        {
            // var AllBook = await _manager.BookReposirtory.GetAllAsync(false); //**burası yerine bookrepositoryde oluşturulan sorguyu çagıralım.
            if (!bookPaginationParameters.ValidePriceRagce)
                throw new PriceOutofRangeBadRequestException();

            var allBookPagination = await _manager.BookReposirtory.GetPaginationForBookRequestQueryAsync(bookPaginationParameters, false);
            if (allBookPagination == null)
            {
                var message = "Searched book value not found";
                _logger.logWarning(message);
                throw new BookBadRequestException(message);

            }

            var AllBookDto = _mapper.Map<IEnumerable<BookDto>>(allBookPagination);

            _logger.logInfo("Searched value list found");

            return (AllBookDto,allBookPagination.MetaData);
        }

        public async Task<BookDto> GetBookByIdAsync(int Id, bool tracking)
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
            var oneBookdto = _mapper.Map<BookDto>(result);
            _logger.logInfo($"searching book value id: {Id} found.");

            return oneBookdto;

        }

        public async Task<List<BookDto>> GetBookSearcharametersAsync(BookSearchParameters bookSearchParameters, bool tracking)//Arama
        {
            var bookSearch= await _manager.BookReposirtory.GetSearchBookRequestParameters(bookSearchParameters, false);
            var a= _mapper.Map<List<BookDto>>(bookSearch);
            return a;
        }

        public async Task<List<BookDto>> GetBookSortharametersAsync(BookShortParameters bookShortParameters, bool tracking)//Sıralama
        {
            var bookShort = await _manager.BookReposirtory.GetBookSortharametersAsync(bookShortParameters, false);
            var bookResponse = _mapper.Map<List<BookDto>>(bookShort);

            return bookResponse.ToList();
        }

        public async Task<bool> UpdateBookAsync(int Id, BookUpdateDto bookBDto)
        {
            var updateBook = await _manager.BookReposirtory.GetByIdAsync(Id, true);

            if (updateBook == null)
            {
                var message = "value come empty.";
                _logger.logWarning(message);
                throw new BookBadRequestException(message);
            }

           

            //Manuel mapleme 
            /*
            updateBook.Title = bookBDto.Title;
            updateBook.Description = bookBDto.Description;
            updateBook.PublishhedDate = bookBDto.PublishhedDate;
            updateBook.Price = bookBDto.Price;
            updateBook.Stock = bookBDto.Stock;
            updateBook.CategoryId = bookBDto.CategoryId;
            updateBook.AuthorId = bookBDto.AuthorId;

            */

            var UpdateDto = _mapper.Map(bookBDto, updateBook);

            _manager.BookReposirtory.Update(updateBook);
            await _manager.BookReposirtory.SaveAsync();
            _logger.logInfo("Update Process successfull");
            return true;

        }
    }
}
