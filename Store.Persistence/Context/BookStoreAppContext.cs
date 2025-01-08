using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Store.Persistence.TypeConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Persistence.Context
{
    public class BookStoreAppContext : DbContext
    {
        public BookStoreAppContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Tek Tek yazılan Confis class larını bu şekilde kaydetmek yerine 
            /*
            modelBuilder.ApplyConfiguration(new BookConfig());  
            modelBuilder.ApplyConfiguration(new CategoryConfig());
            modelBuilder.ApplyConfiguration(new AuthorConfig());
            */
            //tek satırda kaydetmek daha mantıklıdır.
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BookStoreAppContext).Assembly);

        }
    }
}
