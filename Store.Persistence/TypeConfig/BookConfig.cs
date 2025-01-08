using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Persistence.TypeConfig
{
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasData(

                 new Book { Id = 1, Title = "hacivat ve karagöz", Price = 150, Stock = 12, Description = "bu hikaya derinden yaralar", PublishhedDate = DateTime.UtcNow, AuthorId = 1, CategoryId = 1 }

                );
        }
    }
}
