using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksManager.Domain.Enums
{
    public enum Genre : int
    {
        None = 0,
        Fantasy = 1,

        [Display(Name = "Sci-Fi")]
        ScienceFiction = 2,
        Dystopian = 3,
        Adventure = 4,
        Romance = 5,
        Detective = 6,
        Horror = 7,
        Thriller = 8,

        [Display(Name = "Historical Fiction")]
        HistoricalFiction = 9,
        Autobiography = 10,
        Biography = 11,
        Cooking = 12,

        [Display(Name = "Personal Development")]
        PersonalDevelopment = 13,
        History = 14,
        Hobbies = 15,
        Business = 16,
        Politics = 17,
        Travel = 18,
        Science = 19
    }
}
