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
    public class ShelvesService : IShelvesService
    {
        private IShelvesRepository _shelvesRepository;
        private IBooksService _booksService;
        private IMapper _mapper;
        public ShelvesService(IShelvesRepository shelvesRepository,
                                IBooksService booksService,
                                IMapper mapper)
        {
            _shelvesRepository = shelvesRepository;
            _booksService = booksService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ShelfModel>> GetAllShelves()
        {
            var shelves = await _shelvesRepository.GetAll();
            return shelves.Select(shelf => _mapper.ToModel(shelf));
        }

        public async Task<IEnumerable<ShelfModel>> GetAllShelvesIncludes()
        {
            var shelves = await _shelvesRepository.GetAllShelvesIncludes();
            return shelves.Select(shelf => _mapper.ToModel(shelf));
        }


        public async Task<IEnumerable<BookModel>> GetAllBooksFromShelf(int id)
        {
            var shelf = await _shelvesRepository.GetById(id);
            return shelf.Books.Select(b => _mapper.ToModel(b));
        }

        public async Task<ShelfModel> GetShelfById(int id)
        {
            var shelf = await _shelvesRepository.GetById(id);

            if (shelf == null)
                return null;

            return _mapper.ToModel(shelf);
        }

        public async Task<ShelfModel> GetShelfIncludesById(int id)
        {
            var shelf = await _shelvesRepository.GetShelfIncludesById(id);

            if (shelf == null)
                return null;

            return _mapper.ToModel(shelf);
        }

        public async Task AddToShelf(Book book, int shelfId)
        {
            if (book != null && shelfId != 0)
            {
                var shelf = await _shelvesRepository.GetShelfIncludesById(shelfId);

                if (shelf.Books == null)
                    shelf.Books = new List<Book>();

                if (shelf.Books.Where(b => b.Id == book.Id).Any())
                    throw new Exception("Book already exists in " + shelf.Name);

                shelf.Books.Add(book);

                await UpdateShelf(shelf);
            }
        }

        public async Task CreateShelf(Shelf shelfModel)
        {
            if(shelfModel != null)
                await _shelvesRepository.Add(shelfModel);
        }

        public async Task RemoveShelf(int id)
        {
            var shelf = await _shelvesRepository.GetShelfIncludesById(id);

            if (shelf != null)
                await _shelvesRepository.Remove(shelf);
        }

        public async Task UpdateShelf(Shelf shelf)
        {
            await _shelvesRepository.Update(shelf);
        }

        public async Task RemoveBook(int bookId, int shelfId)
        {
            var shelf = await _shelvesRepository.GetShelfIncludesById(shelfId);
            shelf.Books.RemoveAll(s => s.Id == bookId);
            await UpdateShelf(shelf);
        }
    }
}
