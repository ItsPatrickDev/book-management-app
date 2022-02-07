using BooksManager.Business.Mappers;
using BooksManager.Business.Services;
using BooksManager.Business.Services.Interfaces;
using BooksManager.Data.Repositories;
using BooksManager.Domain.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksManager.WebApp.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static void AddServices(this IServiceCollection service)
        {
            service.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            service.AddTransient<IBooksService, BooksService>();
            service.AddTransient<IShelvesService, ShelvesService>();
        }

        public static void AddRepositories(this IServiceCollection service)
        {
            service.AddTransient<IBooksRepository, BooksRepository>();
            service.AddTransient<IShelvesRepository, ShelvesRepository>();
        }

        public static void AddMappers(this IServiceCollection service)
        {
            service.AddTransient<IMapper, Mapper>();
        }
    }
}
