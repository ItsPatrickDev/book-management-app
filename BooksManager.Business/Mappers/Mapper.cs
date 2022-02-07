using BooksManager.Business.Models;
using BooksManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksManager.Business.Mappers
{
    public class Mapper : IMapper
    {
        public BookModel ToModel(Book book, bool includes = true)
        {
            BookModel bookModel = null;
            if(book != null)
            {
                bookModel = new BookModel()
                {
                    Id = book.Id,
                    Title = book.Title,
                    Author = book.Author,
                    Genre = book.Genre,
                    Status = book.Status,
                    IsFavourite = book.IsFavourite,
                    IsHardCover = book.IsHardCover,
                    CreationDate = book.CreationDate,
                    ShelfId = book.ShelfId,
                    Shelf = includes ? ToModel(book.Shelf, false) : null
                };
            }

            return bookModel;
        }

        public Book ToModel(BookModel bookModel, bool includes = true)
        {
            Book book = null;
            if (bookModel != null)
            {
                book = new Book()
                {
                    Id = bookModel.Id,
                    Title = bookModel.Title,
                    Author = bookModel.Author,
                    Genre = bookModel.Genre,
                    Status = bookModel.Status,
                    IsFavourite = bookModel.IsFavourite,
                    IsHardCover = bookModel.IsHardCover,
                    CreationDate = bookModel.CreationDate,
                    ShelfId = bookModel.ShelfId,
                    Shelf = includes ? ToModel(bookModel.Shelf, false) : null
                };
            }

            return book;
        }

        public ShelfModel ToModel(Shelf shelf, bool includes = true)
        {
            ShelfModel shelfModel = null;
            if (shelf != null)
            {
                shelfModel = new ShelfModel()
                {
                    Id = shelf.Id,
                    Name = shelf.Name,
                    Books = includes ? shelf.Books?.Select(b => ToModel(b, false)).ToList() : null
                };
            }

            return shelfModel;
        }

        public Shelf ToModel(ShelfModel shelfModel, bool includes = true)
        {
            Shelf model = null;
            if (shelfModel != null)
            {
                model = new Shelf()
                {
                    Id = shelfModel.Id,
                    Name = shelfModel.Name,
                    Books = includes ? shelfModel.Books?.Select(b => ToModel(b, false)).ToList() : null
                };
            }

            return model;
        }
    }
}
