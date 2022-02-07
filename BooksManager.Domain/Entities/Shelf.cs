using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksManager.Domain.Entities
{
    public class Shelf : BaseEntity
    {
        [MaxLength(48, ErrorMessage = "Max length is 48")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        public List<Book> Books { get; set; }
    }
}
