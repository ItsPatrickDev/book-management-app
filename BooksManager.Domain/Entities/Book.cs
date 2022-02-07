using BooksManager.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksManager.Domain.Entities
{
    public class Book : BaseEntity
    {

        [Required(ErrorMessage = "Title is required")]
        [MaxLength(256, ErrorMessage = "Maximum length is 256")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Author is required")]
        [MaxLength(256, ErrorMessage = "Maximum length is 256")]
        public string Author { get; set; }

        [Required]
        public Genre Genre { get; set; }

        [Required]
        public BookStatus Status { get; set; }
        public bool IsFavourite { get; set; }
        public bool IsHardCover { get; set; }
        public DateTime CreationDate { get; set; }
        public int? ShelfId { get; set; }
        public Shelf Shelf { get; set; }
    }
}
