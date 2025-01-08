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
    public class AuthorConfig : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasData(
                   new Author { Id = 1, FirstName = "Hakkı", LastName = "Hakkıoglu", Biography = "Cok Çileler çekti.", BirthYear = DateTime.UtcNow }
                );
        }
    }
}
