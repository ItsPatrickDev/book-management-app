using BooksManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksManager.Business.Models
{
    public class ShelfModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<BookModel> Books { get; set; }
    }
}
