using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Store.Application.IRepository;
using Store.Application.IRepository.IBook;
using Store.Application.IRepository.ICategory;
using Store.Persistence.Context;
using Store.Persistence.Repository;
using Store.Persistence.Repository.Books;
using Store.Persistence.Repository.Categories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Persistence.Extensions
{
    public static class ServicesRegistrations
    { 
        public static void ConfugureSqlDbConetxt(this IServiceCollection services,IConfiguration configuration)
        {

            services.AddDbContext<BookStoreAppContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("SqlConnection"))
           );
        }

        public static void ConfugureRepositoryManager(this IServiceCollection services)
        {
            //istersek butun oluşturulan repositoryleride ayrı ayrı kaydedip istenilen tyerde istenilen repo yu çagırarak işlemlere devam edebiliriz istersek de
            //manager ile tek kayıtta butun repolara ualaşa biliriz.
            services.AddScoped<IRepositoryManager, RepositoryManager>();
            //Book Repository IOC kaydı
            services.AddScoped<IBookReposirtory, BookRepository>();
            
            //Contact Repositoris Ioc kaydı.
            services.AddScoped<ICategoryReposirtory, CategoryRepository>();
           
        }
    }
}
