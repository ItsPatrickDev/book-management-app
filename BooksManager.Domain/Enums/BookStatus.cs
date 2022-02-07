using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksManager.Domain.Enums
{
    public enum BookStatus
    {
        None = 0,
        Read = 1,
        [Display(Name = "Currently Reading")]
        CurrentlyReading = 2,

        [Display(Name = "Want To Read")]
        WantToRead = 3,

        [Display(Name = "On BookShelf")]
        OnBookShelf = 4
    }
}
