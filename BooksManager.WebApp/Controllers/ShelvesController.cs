using BooksManager.Business.Mappers;
using BooksManager.Business.Models.View;
using BooksManager.Business.Services.Interfaces;
using BooksManager.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksManager.WebApp.Controllers
{
    public class ShelvesController : Controller
    {
        private IShelvesService _shelvesService;
        private IBooksService _booksService;
        private IMapper _mapper;
        private ILogger _logger;
        public ShelvesController(IShelvesService shelvesService,
                                    IBooksService booksService,
                                    IMapper mapper,
                                    ILogger<ShelvesController> logger)
        {
            _shelvesService = shelvesService;
            _booksService = booksService;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var shelves = await _shelvesService.GetAllShelvesIncludes();
            return View(shelves);
        }

        public async Task<IActionResult> Shelf(int id)
        {
            var shelf = await _shelvesService.GetShelfIncludesById(id);
            if (shelf != null)
            {
                var model = new BookShelfViewModel()
                {
                    Books = shelf.Books,
                    Shelf = shelf
                };

                return View(model);
            }

            return NotFound();
        }

        public IActionResult CreateShelf()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateShelf(Shelf shelf)
        {
            if (!ModelState.IsValid)
                return View();

            await _shelvesService.CreateShelf(shelf);
            return RedirectToAction("Index");
        }


        [HttpPost]
        public async Task<IActionResult> AddBook(int bookId, int shelfId)
        {
            try
            {
                var bookModel = await _booksService.GetBookById(bookId);
                if (bookModel == null)
                    return NotFound();

                var book = _mapper.ToModel(bookModel);
                await _shelvesService.AddToShelf(book, shelfId);
                return Ok();
            } catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> Remove(int id)
        {
            await _shelvesService.RemoveShelf(id);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> RemoveBook(int bookId, int shelfId)
        {
            await _shelvesService.RemoveBook(bookId, shelfId);
            return Ok();
        }
    }
}
