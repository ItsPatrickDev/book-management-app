using BooksManager.Business.Services.Interfaces;
using BooksManager.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BooksManager.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBooksService _booksService;
        private readonly IShelvesService _shelvesService;

        public HomeController(ILogger<HomeController> logger,
                                IBooksService booksService,
                                IShelvesService shelvesService)
        {
            _logger = logger;
            _booksService = booksService;
            _shelvesService = shelvesService;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Home";
            ViewBag.Bookshelves = await _shelvesService.GetAllShelves();
            var model = await _booksService.GetAllBooks();

            if(model.Any())
                 model = model.OrderByDescending(book => book.CreationDate);

            return View(model);
        }
    }
}
