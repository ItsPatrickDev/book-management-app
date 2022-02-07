using BooksManager.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksManager.Business.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public Genre Genre { get; set; }
        public BookStatus Status { get; set; }
        public bool IsFavourite { get; set; }
        public bool IsHardCover { get; set; }
        public DateTime CreationDate { get; set; }
        public int? ShelfId { get; set; }
        public ShelfModel Shelf { get; set; }
    }
}
