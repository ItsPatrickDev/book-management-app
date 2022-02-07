using BooksManager.Business.Mappers;
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
    public class BooksController : Controller
    {
        private IBooksService _booksService;
        private IShelvesService _shelvesService;
        private IMapper _mapper;
        private ILogger _logger;

        public BooksController(IBooksService booksService,
                                IShelvesService shelvesService,
                                IMapper mapper,
                                ILogger<BooksController> logger)
        {
            _booksService = booksService;
            _shelvesService = shelvesService;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IActionResult> Favourites()
        {
            var books = await _booksService.GetAllFavouriteBooks();
            return View(books);
        }

        public IActionResult AddBook()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddBook(Book book)
        {
            if (!ModelState.IsValid)
                return View();

            await _booksService.AddBook(book);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditBook(Book book)
        {
            await _booksService.UpdateBook(book);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveBook(int id)
        {
            await _booksService.RemoveBook(id);
            return Ok();       
        }

        [HttpPost]
        public async Task<IActionResult> SetFavourite(int id, bool isFavourite)
        {
            await _booksService.SetBookFavourite(id, isFavourite);
            return Ok();
        }
    }
}
