using BooksManager.Business.Mappers;
using BooksManager.Business.Models;
using BooksManager.Business.Services.Interfaces;
using BooksManager.Domain.Entities;
using BooksManager.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksManager.Business.Services
{
    public class BooksService : IBooksService
    {
        private IBooksRepository _booksRepository;
        private IMapper _mapper;
        public BooksService(IBooksRepository booksRepository,
                            IMapper mapper)
        {
            _booksRepository = booksRepository;
            _mapper = mapper;
        }

        public async Task<BookModel> GetBookById(int id)
        {
            var book = await _booksRepository.GetById(id);

            if (book == null)
                return null;

            return _mapper.ToModel(book);
        }

        public async Task AddBook(Book book)
        {
            await _booksRepository.Add(book);
        }

        public async Task RemoveBook(int id)
        {
            var book = await _booksRepository.GetById(id);

            if (book != null)
                await _booksRepository.Remove(book);
        }

        public async Task UpdateBook(Book book)
        {
            await _booksRepository.Update(book);
        }

        public async Task<IEnumerable<BookModel>> GetAllBooks()
        {
            var books = await _booksRepository.GetAll();

            if (!books.Any())
                return new List<BookModel>();

            return books.Select(book => _mapper.ToModel(book)).ToList();
        }

        public async Task<IEnumerable<BookModel>> GetAllFavouriteBooks()
        {
            var books = await _booksRepository.FindAll(book => book.IsFavourite);
            return books.Select(book => _mapper.ToModel(book)).ToList();
        }

        public async Task SetBookFavourite(int id, bool isFavourite)
        {
            var book = await _booksRepository.GetById(id);
            book.IsFavourite = isFavourite;
            await _booksRepository.Update(book);
        } 
    }
}
