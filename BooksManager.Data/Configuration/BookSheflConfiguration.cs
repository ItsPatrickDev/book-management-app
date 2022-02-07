using BooksManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksManager.Data.Configuration
{
    public class BookSheflConfiguration : IEntityTypeConfiguration<Shelf>
    {
        public void Configure(EntityTypeBuilder<Shelf> builder)
        {
            builder.HasMany(s => s.Books)
                    .WithOne(b => b.Shelf)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
